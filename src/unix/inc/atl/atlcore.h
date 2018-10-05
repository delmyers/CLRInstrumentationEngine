// This is a part of the Active Template Library.
// Copyright (C) Microsoft Corporation
// All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

#ifndef __ATLCORE_H__
#define __ATLCORE_H__

#pragma once

#ifdef _ATL_ALL_WARNINGS
#pragma warning( push )
#endif

#pragma warning(disable: 4786) // identifier was truncated in the debug information
#pragma warning(disable: 4127) // constant expression

#include <atldef.h>
#include <windows.h>
#include <ole2.h>

#include <limits.h>
#include <tchar.h>
#include <mbstring.h>

#include <atlchecked.h>
#include <atlsimpcoll.h>
#include <atlwinverapi.h>

#pragma pack(push,_ATL_PACKING)
namespace ATL
{

/////////////////////////////////////////////////////////////////////////////
// Checking out the string len
inline int AtlStrLen(_In_opt_z_ const WCHAR *str)
{
	if (str == NULL)
		return 0;
	return static_cast<int>(::PAL_wcslen(str));
}


inline int AtlStrLen(_In_opt_z_ const char *str)
{
	if (str == NULL)
		return 0;
	return static_cast<int>(::strlen(str));
}

/////////////////////////////////////////////////////////////////////////////
// Verify that a null-terminated string points to valid memory
inline BOOL AtlIsValidString(
	_In_reads_z_(nMaxLength) LPCWSTR psz,
	_In_ size_t nMaxLength = INT_MAX)
{
	(nMaxLength);
	return (psz != NULL);
}

// Verify that a null-terminated string points to valid memory
inline BOOL AtlIsValidString(
	_In_reads_z_(nMaxLength) LPCSTR psz,
	_In_ size_t nMaxLength = UINT_MAX)
{
	(nMaxLength);
	return (psz != NULL);
}

// Verify that a pointer points to valid memory
inline BOOL AtlIsValidAddress(
	_In_reads_bytes_opt_(nBytes) const void* p,
	_In_ size_t nBytes,
	_In_ BOOL bReadWrite = TRUE)
{
	(bReadWrite);
	(nBytes);
	return (p != NULL);
}

template<typename T>
inline void AtlAssertValidObject(
	_Inout_opt_ const T *pOb)
{
	ATLASSERT(pOb);
	ATLASSERT(AtlIsValidAddress(pOb, sizeof(T)));
	if(pOb)
		pOb->AssertValid();
}
#ifdef _DEBUG
#define ATLASSERT_VALID(x) ATL::AtlAssertValidObject(x)
#else
#define ATLASSERT_VALID(x) 
#endif

// COM Sync Classes
class CComCriticalSection
{
public:
	CComCriticalSection() throw()
	{
		memset(&m_sec, 0, sizeof(CRITICAL_SECTION));
	}

	~CComCriticalSection()
	{
	}

	_Success_(1) _Acquires_lock_(this->m_sec) HRESULT Lock() throw()
	{
		EnterCriticalSection(&m_sec);
		return S_OK;
	}
	_Success_(1) _Releases_lock_(this->m_sec) HRESULT Unlock() throw()
	{
		LeaveCriticalSection(&m_sec);
		return S_OK;
	}
	HRESULT Init() throw()
	{
		HRESULT hRes = S_OK;
		if (!_AtlInitializeCriticalSectionEx(&m_sec, 0, 0))
		{
			hRes = HRESULT_FROM_WIN32(GetLastError());
		}

		return hRes;
	}

	HRESULT Term() throw()
	{
		DeleteCriticalSection(&m_sec);
		return S_OK;
	}
	CRITICAL_SECTION m_sec;
};

class CComAutoCriticalSection : 
	public CComCriticalSection
{
public:
	CComAutoCriticalSection()
	{
		HRESULT hr = CComCriticalSection::Init();
		if (FAILED(hr))
			AtlThrow(hr);
	}
	~CComAutoCriticalSection() throw()
	{
		CComCriticalSection::Term();
	}
private :
	HRESULT Init(); // Not implemented. CComAutoCriticalSection::Init should never be called
	HRESULT Term(); // Not implemented. CComAutoCriticalSection::Term should never be called
};

class CComSafeDeleteCriticalSection : 
	public CComCriticalSection
{
public:
	CComSafeDeleteCriticalSection(): m_bInitialized(false)
	{
	}

	~CComSafeDeleteCriticalSection() throw()
	{
		if (!m_bInitialized)
		{
			return;
		}
		m_bInitialized = false;
		CComCriticalSection::Term();
	}

	HRESULT Init() throw()
	{
		ATLASSERT( !m_bInitialized );
		HRESULT hr = CComCriticalSection::Init();
		if (SUCCEEDED(hr))
		{
			m_bInitialized = true;
		}
		return hr;
	}

	HRESULT Term() throw()
	{
		if (!m_bInitialized)
		{
			return S_OK;
		}
		m_bInitialized = false;
		return CComCriticalSection::Term();
	}

	_Success_(1) _Acquires_lock_(this->m_sec)
	HRESULT Lock()
	{
		// CComSafeDeleteCriticalSection::Init or CComAutoDeleteCriticalSection::Init
		// not called or failed.
		// m_critsec member of CComObjectRootEx is now of type
		// CComAutoDeleteCriticalSection. It has to be initialized
		// by calling CComObjectRootEx::_AtlInitialConstruct
		ATLASSUME(m_bInitialized);
		return CComCriticalSection::Lock();
	}

private:
	bool m_bInitialized;
};

class CComAutoDeleteCriticalSection : 
	public CComSafeDeleteCriticalSection
{
private:
	// CComAutoDeleteCriticalSection::Term should never be called
	HRESULT Term() throw();
};

class CComFakeCriticalSection
{
public:
	HRESULT Lock() throw()
	{
		return S_OK;
	}
	HRESULT Unlock() throw()
	{
		return S_OK;
	}
	HRESULT Init() throw()
	{
		return S_OK;
	}
	HRESULT Term() throw()
	{
		return S_OK;
	}
};

/////////////////////////////////////////////////////////////////////////////
// Module

#ifdef _ATL_USE_WINAPI_FAMILY_DESKTOP_APP

/////////////////////////////////////////////////////////////////////////////
// String resource helpers

#pragma warning(push)
#pragma warning(disable: 4200)
	struct ATLSTRINGRESOURCEIMAGE
	{
		WORD nLength;
		WCHAR achString[];
	};
#pragma warning(pop)	// C4200

inline const ATLSTRINGRESOURCEIMAGE* _AtlGetStringResourceImage(
	_In_ HINSTANCE hInstance,
	_In_ HRSRC hResource,
	_In_ UINT id) throw()
{
	const ATLSTRINGRESOURCEIMAGE* pImage;
	const ATLSTRINGRESOURCEIMAGE* pImageEnd;
	ULONG nResourceSize;
	HGLOBAL hGlobal;
	UINT iIndex;

	hGlobal = ::LoadResource( hInstance, hResource );
	if( hGlobal == NULL )
	{
		return( NULL );
	}

	pImage = (const ATLSTRINGRESOURCEIMAGE*)::LockResource( hGlobal );
	if( pImage == NULL )
	{
		return( NULL );
	}

	nResourceSize = ::SizeofResource( hInstance, hResource );
	pImageEnd = (const ATLSTRINGRESOURCEIMAGE*)(LPBYTE( pImage )+nResourceSize);
	iIndex = id&0x000f;

	while( (iIndex > 0) && (pImage < pImageEnd) )
	{
		pImage = (const ATLSTRINGRESOURCEIMAGE*)(LPBYTE( pImage )+(sizeof( ATLSTRINGRESOURCEIMAGE )+(pImage->nLength*sizeof( WCHAR ))));
		iIndex--;
	}
	if( pImage >= pImageEnd )
	{
		return( NULL );
	}
	if( pImage->nLength == 0 )
	{
		return( NULL );
	}

	return( pImage );
}

inline const ATLSTRINGRESOURCEIMAGE* AtlGetStringResourceImage(
	_In_ HINSTANCE hInstance,
	_In_ UINT id) throw()
{
	HRSRC hResource;
	/*
		The and operation (& static_cast<WORD>(~0)) protects the expression from being greater
		than WORD - this would cause a runtime error when the application is compiled with /RTCc flag.
	*/
	hResource = ::FindResourceW(hInstance, MAKEINTRESOURCEW( (((id>>4)+1) & static_cast<WORD>(~0)) ), (LPWSTR) RT_STRING);
	if( hResource == NULL )
	{
		return( NULL );
	}

	return _AtlGetStringResourceImage( hInstance, hResource, id );
}

inline const ATLSTRINGRESOURCEIMAGE* AtlGetStringResourceImage(
	_In_ HINSTANCE hInstance,
	_In_ UINT id,
	_In_ WORD wLanguage) throw()
{
	HRSRC hResource;
	/*
		The and operation (& static_cast<WORD>(~0)) protects the expression from being greater
		than WORD - this would cause a runtime error when the application is compiled with /RTCc flag.
	*/
	hResource = ::FindResourceExW(hInstance, (LPWSTR) RT_STRING, MAKEINTRESOURCEW( (((id>>4)+1) & static_cast<WORD>(~0)) ), wLanguage);
	if( hResource == NULL )
	{
		return( NULL );
	}

	return _AtlGetStringResourceImage( hInstance, hResource, id );
}

#endif // _ATL_USE_WINAPI_FAMILY_DESKTOP_APP

/*
Needed by both atlcomcli and atlsafe, so needs to be in here
*/
inline HRESULT AtlSafeArrayGetActualVartype(
    _In_ SAFEARRAY *psaArray,
    _Out_ VARTYPE *pvtType)
{
    HRESULT hrSystem=::SafeArrayGetVartype(psaArray, pvtType);

    if(FAILED(hrSystem))
    {
        return hrSystem;
    }

    /*
    When Windows has a SAFEARRAY of type VT_DISPATCH with FADF_HAVEIID,
    it returns VT_UNKNOWN instead of VT_DISPATCH. We patch the value to be correct
    */
    if(pvtType && *pvtType==VT_UNKNOWN)
    {
        if(psaArray && ((psaArray->fFeatures & FADF_HAVEIID)!=0))
        {
            if(psaArray->fFeatures & FADF_DISPATCH)
            {
                *pvtType=VT_DISPATCH;
            }
        }
    }

    return hrSystem;
}
template <typename _CharType>
inline _CharType* AtlCharNext(_In_ const _CharType* p) throw()
{
	ATLASSUME(p != NULL);	// Too expensive to check separately here
	if (*p == '\0')  // ::CharNextA won't increment if we're at a \0 already
		return const_cast<_CharType*>(p+1);
	else
		return ::CharNextA(p);
}

template <>
inline WCHAR* AtlCharNext<WCHAR>(_In_ const WCHAR* p) throw()
{
	return const_cast< WCHAR* >( p+1 );
}
template<typename CharType>
inline const CharType* AtlstrchrT(
	_In_z_ const CharType* p,
	_In_ CharType ch) throw()
{
	ATLASSERT(p != NULL);
	if(p==NULL)
	{
		return NULL;
	}
	while( *p != 0 )
	{
		if (*p == ch)
		{
			return p;
		}
		p = AtlCharNext(p);
	}
	//strchr for '\0' should succeed - the while loop terminates
	//*p == 0, but ch also == 0, so NULL terminator address is returned
	return (*p == ch) ? p : NULL;
}
//Ansi and Unicode versions of printf, used with templated CharType trait classes.
#pragma warning(push)
#pragma warning(disable : 4793)
template<typename CharType>
inline int AtlprintfT(_In_z_ _Printf_format_string_ const CharType* pszFormat,...) throw()
{
	int retval=0;
	va_list argList;
	va_start( argList, pszFormat );
	retval=vprintf(pszFormat,argList);
	va_end( argList );
	return retval;
}
#pragma warning(pop)

#pragma warning(push)
#pragma warning(disable : 4793)
template<>
inline int AtlprintfT(_In_z_ _Printf_format_string_ const WCHAR* pszFormat,... ) throw()
{
	int retval=0;
	va_list argList;
	va_start( argList, pszFormat );
	retval=_vwprintf(pszFormat,	argList);
	va_end( argList );
	return retval;
}
#pragma warning(pop)

#ifdef _ATL_USE_WINAPI_FAMILY_DESKTOP_APP

/////////////////////////////////////////////////////////////////////////////
// DLL Load Helper
#ifdef _WINDOWS_
inline HMODULE AtlLoadSystemLibraryUsingFullPath(_In_z_ const WCHAR *pszLibrary)
{
#if (_ATL_NTDDI_MIN > NTDDI_WIN7)
	return(::LoadLibraryExW(pszLibrary, NULL, LOAD_LIBRARY_SEARCH_SYSTEM32));
#else
#ifndef _USING_V110_SDK71_
	// the LOAD_LIBRARY_SEARCH_SYSTEM32 flag for LoadLibraryExW is only supported if the DLL-preload fixes are installed, so
	// use LoadLibraryExW only if SetDefaultDllDirectories is available (only on Win8, or with KB2533623 on Vista and Win7)...
	IFDYNAMICGETCACHEDFUNCTION(_T("kernel32.dll"), SetDefaultDllDirectories, pfSetDefaultDllDirectories)
	{
		return(::LoadLibraryExW(pszLibrary, NULL, LOAD_LIBRARY_SEARCH_SYSTEM32));
	}

	// ...otherwise fall back to using LoadLibrary from the SYSTEM32 folder explicitly.
#endif
	WCHAR wszLoadPath[MAX_PATH+1];
    UINT rc = ::GetSystemDirectoryW(wszLoadPath, _countof(wszLoadPath));
	if (rc == 0 || rc >= _countof(wszLoadPath))
	{
		return NULL;
	}

	if (wszLoadPath[PAL_wcslen(wszLoadPath)-1] != L'\\')
	{
		if (wcscat_s(wszLoadPath, _countof(wszLoadPath), _T("\\")) != 0)
		{
			return NULL;
		}
	}

	if (wcscat_s(wszLoadPath, _countof(wszLoadPath), pszLibrary) != 0)
	{
		return NULL;
	}

	return(::LoadLibraryW(wszLoadPath));
#endif
}
#endif // _WINDOWS_

/////////////////////////////////////////////////////////////////////////////

#endif // _ATL_USE_WINAPI_FAMILY_DESKTOP_APP

}	// namespace ATL
#pragma pack(pop)

#ifdef _ATL_ALL_WARNINGS
#pragma warning( pop )
#endif

#endif	// __ATLCORE_H__
