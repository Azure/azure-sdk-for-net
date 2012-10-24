namespace Microsoft.WindowsAzure.Storage.Core.Util
{
    using System;
    using System.Threading;

    /// <summary>
    /// Helper class to allow an APM Method to be executed with a given timeout in milliseconds
    /// </summary>
    internal class APMWithTimeout
    {
        public static void RunWithTimeout(Func<AsyncCallback, object, IAsyncResult> beginMethod, AsyncCallback callback, object state, int? timeoutInMS, AsyncCallback timeoutCallback)
        {
            CommonUtils.AssertNotNull("beginMethod", beginMethod);
            CommonUtils.AssertNotNull("callback", callback);
            CommonUtils.AssertNotNull("timeoutCallback", timeoutCallback);
            new APMWithTimeout(beginMethod, callback, state, timeoutInMS, timeoutCallback);
        }

        /// <summary>
        /// User's timeout callback
        /// </summary>
        private AsyncCallback timeoutCallback;

        private APMWithTimeout(Func<AsyncCallback, object, IAsyncResult> beginMethod, AsyncCallback callback, object state, int? timeoutInMS, AsyncCallback timeoutCallback)
        {
            this.timeoutCallback = timeoutCallback;
            IAsyncResult result = beginMethod(callback, state);

            if (timeoutInMS.HasValue)
            {
                ThreadPool.RegisterWaitForSingleObject(
                    result.AsyncWaitHandle,
                    (_, isTimedOut) =>
                    {
                        if (isTimedOut)
                        {
                            this.timeoutCallback(result);
                        }
                    },
                    null,
                    timeoutInMS.Value,
                    true);
            }
        }
    }
}
