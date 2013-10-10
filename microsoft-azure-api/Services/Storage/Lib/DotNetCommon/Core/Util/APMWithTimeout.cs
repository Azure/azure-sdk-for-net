//-----------------------------------------------------------------------
// <copyright file="APMWithTimeout.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core.Util
{
    using System;
    using System.Threading;

    /// <summary>
    /// Helper class to allow an APM Method to be executed with a given timeout in milliseconds
    /// </summary>
    internal class APMWithTimeout : IDisposable
    {
        public static void RunWithTimeout(Func<AsyncCallback, object, IAsyncResult> beginMethod, AsyncCallback callback, TimerCallback timeoutCallback, object state, TimeSpan timeout)
        {
            CommonUtility.AssertNotNull("beginMethod", beginMethod);
            CommonUtility.AssertNotNull("callback", callback);
            CommonUtility.AssertNotNull("timeoutCallback", timeoutCallback);

            APMWithTimeout operation = new APMWithTimeout(timeoutCallback);
            operation.Begin(beginMethod, callback, state, timeout);
        }

        private TimerCallback timeoutCallback;
        private RegisteredWaitHandle waitHandle;
        private IAsyncResult asyncResult;

#if WINDOWS_PHONE
        // Windows Phone does not let us use IAsyncResult.AsyncWaitHandle
        // on most APM methods, so we will just use a fake event that
        // will never be signaled. That way, we will always timeout, but
        // we will check if the asynchronous operation is completed in the
        // timeout callback. However, we cannot make this static, as
        // RegisterWaitForSingleObject needs a different handle for every call.
        private ManualResetEvent fakeEvent = new ManualResetEvent(false);
#endif

        private APMWithTimeout(TimerCallback timeoutCallback)
        {
            this.timeoutCallback = timeoutCallback;
        }

        private void Begin(Func<AsyncCallback, object, IAsyncResult> beginMethod, AsyncCallback callback, object state, TimeSpan timeout)
        {
            this.asyncResult = beginMethod(callback, state);

#if WINDOWS_PHONE
            WaitHandle asyncWaitHandle = this.fakeEvent;
#else
            WaitHandle asyncWaitHandle = this.asyncResult.AsyncWaitHandle;
#endif
            
            this.waitHandle = ThreadPool.RegisterWaitForSingleObject(
                asyncWaitHandle,
                this.TimeoutCallback,
                state,
                timeout,
                true);
        }

        private void TimeoutCallback(object state, bool timedOut)
        {
            if (timedOut && !this.asyncResult.IsCompleted)
            {
                TimerCallback callback = this.timeoutCallback;
                this.timeoutCallback = null;

                if (callback != null)
                {
                    callback(state);
                }
            }

            this.Dispose();
        }

        public void Dispose()
        {
            if (this.waitHandle != null)
            {
                this.waitHandle.Unregister(null);
                this.waitHandle = null;
            }

            this.timeoutCallback = null;

#if WINDOWS_PHONE
            if (this.fakeEvent != null)
            {
                this.fakeEvent.Close();
                this.fakeEvent = null;
            }
#endif
        }
    }
}
