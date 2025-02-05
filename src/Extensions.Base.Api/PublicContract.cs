﻿

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

//==============================================
//This file is autogenerated
//==============================================
//Underscore _System assembly will be treated as regular System namespace by ImportModule function of Intstrumentation Engine.
//This is done to avoid conflicts during compilation

namespace _System.Diagnostics
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using Microsoft.Diagnostics.Instrumentation.Extensions.Base;

    /// <summary>
    /// This class defines public contract to register new callbacks
    /// </summary>
    public partial class DebuggerHiddenAttribute : Attribute
    {
        public static void ApplicationInsights_AddCallbacks(int methodId,
            Func<object> onBegin,
            Func<object, object, object> onEnd,
            Action<object, Exception> onException)
        {
           for (int i = 0; i < 20; ++i)
           {
                int originalValue = Interlocked.CompareExchange(ref BCB<int>.Lock0, 1, 0);

                if (originalValue == 0)
                {
                    try
                    {
                        // this thread updated lock0
                        var newBeginCallbacks0 = new Dictionary<int, Func<object>>(BCB<int>.callbacks0);
                        var newEndCallbacks0 = new Dictionary<int, Func<object, object, object>>(ECB<int>.callbacks0);
                        var newExceptionCallbacks0 = new Dictionary<int, Action<object, Exception>>(ExCB<int>.callbacks0);

                        newBeginCallbacks0.Add(methodId, onBegin);
                        newEndCallbacks0.Add(methodId, onEnd);
                        newExceptionCallbacks0.Add(methodId, onException);

                        BCB<int>.callbacks0 = newBeginCallbacks0;
                        ECB<int>.callbacks0 = newEndCallbacks0;
                        ExCB<int>.callbacks0 = newExceptionCallbacks0;
                    }
                    finally
                    {
                        BCB<int>.Lock0 = 0;
                    }

                    break;
                }

                // some other thread updated Lock0; wait and try again
                if (i < 19)
                {
                    Thread.Sleep(5);
                }
                else
                {
                     throw new InvalidOperationException("Could not add callbacks because of the concurrency issue.");
                }
            }
        }

        public static void ApplicationInsights_AddCallbacks(int methodId,
            Func<object, object> onBegin,
            Func<object, object, object, object> onEnd,
            Action<object, Exception, object> onException)
        {
           for (int i = 0; i < 20; ++i)
           {
                int originalValue = Interlocked.CompareExchange(ref BCB<int>.Lock1, 1, 0);

                if (originalValue == 0)
                {
                    try
                    {
                        // this thread updated lock1
                        var newBeginCallbacks1 = new Dictionary<int, Func<object, object>>(BCB<int>.callbacks1);
                        var newEndCallbacks1 = new Dictionary<int, Func<object, object, object, object>>(ECB<int>.callbacks1);
                        var newExceptionCallbacks1 = new Dictionary<int, Action<object, Exception, object>>(ExCB<int>.callbacks1);

                        newBeginCallbacks1.Add(methodId, onBegin);
                        newEndCallbacks1.Add(methodId, onEnd);
                        newExceptionCallbacks1.Add(methodId, onException);

                        BCB<int>.callbacks1 = newBeginCallbacks1;
                        ECB<int>.callbacks1 = newEndCallbacks1;
                        ExCB<int>.callbacks1 = newExceptionCallbacks1;
                    }
                    finally
                    {
                        BCB<int>.Lock1 = 0;
                    }

                    break;
                }

                // some other thread updated Lock1; wait and try again
                if (i < 19)
                {
                    Thread.Sleep(5);
                }
                else
                {
                     throw new InvalidOperationException("Could not add callbacks because of the concurrency issue.");
                }
            }
        }

        public static void ApplicationInsights_AddCallbacks(int methodId,
            Func<object, object, object> onBegin,
            Func<object, object, object, object, object> onEnd,
            Action<object, Exception, object, object> onException)
        {
           for (int i = 0; i < 20; ++i)
           {
                int originalValue = Interlocked.CompareExchange(ref BCB<int>.Lock2, 1, 0);

                if (originalValue == 0)
                {
                    try
                    {
                        // this thread updated lock2
                        var newBeginCallbacks2 = new Dictionary<int, Func<object, object, object>>(BCB<int>.callbacks2);
                        var newEndCallbacks2 = new Dictionary<int, Func<object, object, object, object, object>>(ECB<int>.callbacks2);
                        var newExceptionCallbacks2 = new Dictionary<int, Action<object, Exception, object, object>>(ExCB<int>.callbacks2);

                        newBeginCallbacks2.Add(methodId, onBegin);
                        newEndCallbacks2.Add(methodId, onEnd);
                        newExceptionCallbacks2.Add(methodId, onException);

                        BCB<int>.callbacks2 = newBeginCallbacks2;
                        ECB<int>.callbacks2 = newEndCallbacks2;
                        ExCB<int>.callbacks2 = newExceptionCallbacks2;
                    }
                    finally
                    {
                        BCB<int>.Lock2 = 0;
                    }

                    break;
                }

                // some other thread updated Lock2; wait and try again
                if (i < 19)
                {
                    Thread.Sleep(5);
                }
                else
                {
                     throw new InvalidOperationException("Could not add callbacks because of the concurrency issue.");
                }
            }
        }

        public static void ApplicationInsights_AddCallbacks(int methodId,
            Func<object, object, object, object> onBegin,
            Func<object, object, object, object, object, object> onEnd,
            Action<object, Exception, object, object, object> onException)
        {
           for (int i = 0; i < 20; ++i)
           {
                int originalValue = Interlocked.CompareExchange(ref BCB<int>.Lock3, 1, 0);

                if (originalValue == 0)
                {
                    try
                    {
                        // this thread updated lock3
                        var newBeginCallbacks3 = new Dictionary<int, Func<object, object, object, object>>(BCB<int>.callbacks3);
                        var newEndCallbacks3 = new Dictionary<int, Func<object, object, object, object, object, object>>(ECB<int>.callbacks3);
                        var newExceptionCallbacks3 = new Dictionary<int, Action<object, Exception, object, object, object>>(ExCB<int>.callbacks3);

                        newBeginCallbacks3.Add(methodId, onBegin);
                        newEndCallbacks3.Add(methodId, onEnd);
                        newExceptionCallbacks3.Add(methodId, onException);

                        BCB<int>.callbacks3 = newBeginCallbacks3;
                        ECB<int>.callbacks3 = newEndCallbacks3;
                        ExCB<int>.callbacks3 = newExceptionCallbacks3;
                    }
                    finally
                    {
                        BCB<int>.Lock3 = 0;
                    }

                    break;
                }

                // some other thread updated Lock3; wait and try again
                if (i < 19)
                {
                    Thread.Sleep(5);
                }
                else
                {
                     throw new InvalidOperationException("Could not add callbacks because of the concurrency issue.");
                }
            }
        }

        public static void ApplicationInsights_AddCallbacks(int methodId,
            Func<object, object, object, object, object> onBegin,
            Func<object, object, object, object, object, object, object> onEnd,
            Action<object, Exception, object, object, object, object> onException)
        {
           for (int i = 0; i < 20; ++i)
           {
                int originalValue = Interlocked.CompareExchange(ref BCB<int>.Lock4, 1, 0);

                if (originalValue == 0)
                {
                    try
                    {
                        // this thread updated lock4
                        var newBeginCallbacks4 = new Dictionary<int, Func<object, object, object, object, object>>(BCB<int>.callbacks4);
                        var newEndCallbacks4 = new Dictionary<int, Func<object, object, object, object, object, object, object>>(ECB<int>.callbacks4);
                        var newExceptionCallbacks4 = new Dictionary<int, Action<object, Exception, object, object, object, object>>(ExCB<int>.callbacks4);

                        newBeginCallbacks4.Add(methodId, onBegin);
                        newEndCallbacks4.Add(methodId, onEnd);
                        newExceptionCallbacks4.Add(methodId, onException);

                        BCB<int>.callbacks4 = newBeginCallbacks4;
                        ECB<int>.callbacks4 = newEndCallbacks4;
                        ExCB<int>.callbacks4 = newExceptionCallbacks4;
                    }
                    finally
                    {
                        BCB<int>.Lock4 = 0;
                    }

                    break;
                }

                // some other thread updated Lock4; wait and try again
                if (i < 19)
                {
                    Thread.Sleep(5);
                }
                else
                {
                     throw new InvalidOperationException("Could not add callbacks because of the concurrency issue.");
                }
            }
        }

        public static void ApplicationInsights_AddCallbacks(int methodId,
            Func<object, object, object, object, object, object> onBegin,
            Func<object, object, object, object, object, object, object, object> onEnd,
            Action<object, Exception, object, object, object, object, object> onException)
        {
           for (int i = 0; i < 20; ++i)
           {
                int originalValue = Interlocked.CompareExchange(ref BCB<int>.Lock5, 1, 0);

                if (originalValue == 0)
                {
                    try
                    {
                        // this thread updated lock5
                        var newBeginCallbacks5 = new Dictionary<int, Func<object, object, object, object, object, object>>(BCB<int>.callbacks5);
                        var newEndCallbacks5 = new Dictionary<int, Func<object, object, object, object, object, object, object, object>>(ECB<int>.callbacks5);
                        var newExceptionCallbacks5 = new Dictionary<int, Action<object, Exception, object, object, object, object, object>>(ExCB<int>.callbacks5);

                        newBeginCallbacks5.Add(methodId, onBegin);
                        newEndCallbacks5.Add(methodId, onEnd);
                        newExceptionCallbacks5.Add(methodId, onException);

                        BCB<int>.callbacks5 = newBeginCallbacks5;
                        ECB<int>.callbacks5 = newEndCallbacks5;
                        ExCB<int>.callbacks5 = newExceptionCallbacks5;
                    }
                    finally
                    {
                        BCB<int>.Lock5 = 0;
                    }

                    break;
                }

                // some other thread updated Lock5; wait and try again
                if (i < 19)
                {
                    Thread.Sleep(5);
                }
                else
                {
                     throw new InvalidOperationException("Could not add callbacks because of the concurrency issue.");
                }
            }
        }

        public static void ApplicationInsights_AddCallbacks(int methodId,
            Func<object, object, object, object, object, object, object> onBegin,
            Func<object, object, object, object, object, object, object, object, object> onEnd,
            Action<object, Exception, object, object, object, object, object, object> onException)
        {
           for (int i = 0; i < 20; ++i)
           {
                int originalValue = Interlocked.CompareExchange(ref BCB<int>.Lock6, 1, 0);

                if (originalValue == 0)
                {
                    try
                    {
                        // this thread updated lock6
                        var newBeginCallbacks6 = new Dictionary<int, Func<object, object, object, object, object, object, object>>(BCB<int>.callbacks6);
                        var newEndCallbacks6 = new Dictionary<int, Func<object, object, object, object, object, object, object, object, object>>(ECB<int>.callbacks6);
                        var newExceptionCallbacks6 = new Dictionary<int, Action<object, Exception, object, object, object, object, object, object>>(ExCB<int>.callbacks6);

                        newBeginCallbacks6.Add(methodId, onBegin);
                        newEndCallbacks6.Add(methodId, onEnd);
                        newExceptionCallbacks6.Add(methodId, onException);

                        BCB<int>.callbacks6 = newBeginCallbacks6;
                        ECB<int>.callbacks6 = newEndCallbacks6;
                        ExCB<int>.callbacks6 = newExceptionCallbacks6;
                    }
                    finally
                    {
                        BCB<int>.Lock6 = 0;
                    }

                    break;
                }

                // some other thread updated Lock6; wait and try again
                if (i < 19)
                {
                    Thread.Sleep(5);
                }
                else
                {
                     throw new InvalidOperationException("Could not add callbacks because of the concurrency issue.");
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Maintainability", "CA1502:Method has cyclomatic complexity of '29'", Justification = "This function is not changed often, and should not be updated.")]
        public static void ApplicationInsights_RemoveCallbacks(int methodId, int argsCount)
        {
            switch (argsCount)
            {
                case 0 :
                    for (int i = 0; i < 20; ++i)
                    {
                        int originalValue = Interlocked.CompareExchange(ref BCB<int>.Lock0, 1, 0);

                        if (originalValue == 0)
                        {
                            try
                            {
                                // this thread updated lock0
                                var newBeginCallbacks0 = new Dictionary<int, Func<object>>(BCB<int>.callbacks0);
                                var newEndCallbacks0 = new Dictionary<int, Func<object, object, object>>(ECB<int>.callbacks0);
                                var newExceptionCallbacks0 = new Dictionary<int, Action<object, Exception>>(ExCB<int>.callbacks0);

                                newBeginCallbacks0.Remove(methodId);
                                newEndCallbacks0.Remove(methodId);
                                newExceptionCallbacks0.Remove(methodId);

                                BCB<int>.callbacks0 = newBeginCallbacks0;
                                ECB<int>.callbacks0 = newEndCallbacks0;
                                ExCB<int>.callbacks0 = newExceptionCallbacks0;
                            }
                            finally
                            {
                                BCB<int>.Lock0 = 0;
                            }

                            break;
                        }

                        // some other thread updated Lock0; wait and try again
                        if (i < 19)
                        {
                            Thread.Sleep(5);
                        }
                        else
                        {
                             throw new InvalidOperationException("Could not remove callbacks because of the concurrency issue.");
                        }
                    }

                    break;
                case 1 :
                    for (int i = 0; i < 20; ++i)
                    {
                        int originalValue = Interlocked.CompareExchange(ref BCB<int>.Lock1, 1, 0);

                        if (originalValue == 0)
                        {
                            try
                            {
                                // this thread updated lock1
                                var newBeginCallbacks1 = new Dictionary<int, Func<object, object>>(BCB<int>.callbacks1);
                                var newEndCallbacks1 = new Dictionary<int, Func<object, object, object, object>>(ECB<int>.callbacks1);
                                var newExceptionCallbacks1 = new Dictionary<int, Action<object, Exception, object>>(ExCB<int>.callbacks1);

                                newBeginCallbacks1.Remove(methodId);
                                newEndCallbacks1.Remove(methodId);
                                newExceptionCallbacks1.Remove(methodId);

                                BCB<int>.callbacks1 = newBeginCallbacks1;
                                ECB<int>.callbacks1 = newEndCallbacks1;
                                ExCB<int>.callbacks1 = newExceptionCallbacks1;
                            }
                            finally
                            {
                                BCB<int>.Lock1 = 0;
                            }

                            break;
                        }

                        // some other thread updated Lock1; wait and try again
                        if (i < 19)
                        {
                            Thread.Sleep(5);
                        }
                        else
                        {
                             throw new InvalidOperationException("Could not remove callbacks because of the concurrency issue.");
                        }
                    }

                    break;
                case 2 :
                    for (int i = 0; i < 20; ++i)
                    {
                        int originalValue = Interlocked.CompareExchange(ref BCB<int>.Lock2, 1, 0);

                        if (originalValue == 0)
                        {
                            try
                            {
                                // this thread updated lock2
                                var newBeginCallbacks2 = new Dictionary<int, Func<object, object, object>>(BCB<int>.callbacks2);
                                var newEndCallbacks2 = new Dictionary<int, Func<object, object, object, object, object>>(ECB<int>.callbacks2);
                                var newExceptionCallbacks2 = new Dictionary<int, Action<object, Exception, object, object>>(ExCB<int>.callbacks2);

                                newBeginCallbacks2.Remove(methodId);
                                newEndCallbacks2.Remove(methodId);
                                newExceptionCallbacks2.Remove(methodId);

                                BCB<int>.callbacks2 = newBeginCallbacks2;
                                ECB<int>.callbacks2 = newEndCallbacks2;
                                ExCB<int>.callbacks2 = newExceptionCallbacks2;
                            }
                            finally
                            {
                                BCB<int>.Lock2 = 0;
                            }

                            break;
                        }

                        // some other thread updated Lock2; wait and try again
                        if (i < 19)
                        {
                            Thread.Sleep(5);
                        }
                        else
                        {
                             throw new InvalidOperationException("Could not remove callbacks because of the concurrency issue.");
                        }
                    }

                    break;
                case 3 :
                    for (int i = 0; i < 20; ++i)
                    {
                        int originalValue = Interlocked.CompareExchange(ref BCB<int>.Lock3, 1, 0);

                        if (originalValue == 0)
                        {
                            try
                            {
                                // this thread updated lock3
                                var newBeginCallbacks3 = new Dictionary<int, Func<object, object, object, object>>(BCB<int>.callbacks3);
                                var newEndCallbacks3 = new Dictionary<int, Func<object, object, object, object, object, object>>(ECB<int>.callbacks3);
                                var newExceptionCallbacks3 = new Dictionary<int, Action<object, Exception, object, object, object>>(ExCB<int>.callbacks3);

                                newBeginCallbacks3.Remove(methodId);
                                newEndCallbacks3.Remove(methodId);
                                newExceptionCallbacks3.Remove(methodId);

                                BCB<int>.callbacks3 = newBeginCallbacks3;
                                ECB<int>.callbacks3 = newEndCallbacks3;
                                ExCB<int>.callbacks3 = newExceptionCallbacks3;
                            }
                            finally
                            {
                                BCB<int>.Lock3 = 0;
                            }

                            break;
                        }

                        // some other thread updated Lock3; wait and try again
                        if (i < 19)
                        {
                            Thread.Sleep(5);
                        }
                        else
                        {
                             throw new InvalidOperationException("Could not remove callbacks because of the concurrency issue.");
                        }
                    }

                    break;
                case 4 :
                    for (int i = 0; i < 20; ++i)
                    {
                        int originalValue = Interlocked.CompareExchange(ref BCB<int>.Lock4, 1, 0);

                        if (originalValue == 0)
                        {
                            try
                            {
                                // this thread updated lock4
                                var newBeginCallbacks4 = new Dictionary<int, Func<object, object, object, object, object>>(BCB<int>.callbacks4);
                                var newEndCallbacks4 = new Dictionary<int, Func<object, object, object, object, object, object, object>>(ECB<int>.callbacks4);
                                var newExceptionCallbacks4 = new Dictionary<int, Action<object, Exception, object, object, object, object>>(ExCB<int>.callbacks4);

                                newBeginCallbacks4.Remove(methodId);
                                newEndCallbacks4.Remove(methodId);
                                newExceptionCallbacks4.Remove(methodId);

                                BCB<int>.callbacks4 = newBeginCallbacks4;
                                ECB<int>.callbacks4 = newEndCallbacks4;
                                ExCB<int>.callbacks4 = newExceptionCallbacks4;
                            }
                            finally
                            {
                                BCB<int>.Lock4 = 0;
                            }

                            break;
                        }

                        // some other thread updated Lock4; wait and try again
                        if (i < 19)
                        {
                            Thread.Sleep(5);
                        }
                        else
                        {
                             throw new InvalidOperationException("Could not remove callbacks because of the concurrency issue.");
                        }
                    }

                    break;
                case 5 :
                    for (int i = 0; i < 20; ++i)
                    {
                        int originalValue = Interlocked.CompareExchange(ref BCB<int>.Lock5, 1, 0);

                        if (originalValue == 0)
                        {
                            try
                            {
                                // this thread updated lock5
                                var newBeginCallbacks5 = new Dictionary<int, Func<object, object, object, object, object, object>>(BCB<int>.callbacks5);
                                var newEndCallbacks5 = new Dictionary<int, Func<object, object, object, object, object, object, object, object>>(ECB<int>.callbacks5);
                                var newExceptionCallbacks5 = new Dictionary<int, Action<object, Exception, object, object, object, object, object>>(ExCB<int>.callbacks5);

                                newBeginCallbacks5.Remove(methodId);
                                newEndCallbacks5.Remove(methodId);
                                newExceptionCallbacks5.Remove(methodId);

                                BCB<int>.callbacks5 = newBeginCallbacks5;
                                ECB<int>.callbacks5 = newEndCallbacks5;
                                ExCB<int>.callbacks5 = newExceptionCallbacks5;
                            }
                            finally
                            {
                                BCB<int>.Lock5 = 0;
                            }

                            break;
                        }

                        // some other thread updated Lock5; wait and try again
                        if (i < 19)
                        {
                            Thread.Sleep(5);
                        }
                        else
                        {
                             throw new InvalidOperationException("Could not remove callbacks because of the concurrency issue.");
                        }
                    }

                    break;
                case 6 :
                    for (int i = 0; i < 20; ++i)
                    {
                        int originalValue = Interlocked.CompareExchange(ref BCB<int>.Lock6, 1, 0);

                        if (originalValue == 0)
                        {
                            try
                            {
                                // this thread updated lock6
                                var newBeginCallbacks6 = new Dictionary<int, Func<object, object, object, object, object, object, object>>(BCB<int>.callbacks6);
                                var newEndCallbacks6 = new Dictionary<int, Func<object, object, object, object, object, object, object, object, object>>(ECB<int>.callbacks6);
                                var newExceptionCallbacks6 = new Dictionary<int, Action<object, Exception, object, object, object, object, object, object>>(ExCB<int>.callbacks6);

                                newBeginCallbacks6.Remove(methodId);
                                newEndCallbacks6.Remove(methodId);
                                newExceptionCallbacks6.Remove(methodId);

                                BCB<int>.callbacks6 = newBeginCallbacks6;
                                ECB<int>.callbacks6 = newEndCallbacks6;
                                ExCB<int>.callbacks6 = newExceptionCallbacks6;
                            }
                            finally
                            {
                                BCB<int>.Lock6 = 0;
                            }

                            break;
                        }

                        // some other thread updated Lock6; wait and try again
                        if (i < 19)
                        {
                            Thread.Sleep(5);
                        }
                        else
                        {
                             throw new InvalidOperationException("Could not remove callbacks because of the concurrency issue.");
                        }
                    }

                    break;
            }
        }
    }
}
