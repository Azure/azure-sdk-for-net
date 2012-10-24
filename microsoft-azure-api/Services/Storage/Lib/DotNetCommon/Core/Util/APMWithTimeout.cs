namespace Microsoft.WindowsAzure.Storage.Core.Util
{
    using System;
    using System.Threading;

    /// <summary>
    /// Helper class to allow an APM Method to be executed with a given timeout in milliseconds
    /// </summary>
    internal class APMWithTimeout
    {
        public static void RunWithTimeout(Func<AsyncCallback, object, IAsyncResult> beginMethod, AsyncCallback callback, object state, int? timeoutInMS)
        {
            CommonUtils.AssertNotNull("beginMethod", beginMethod);
            CommonUtils.AssertNotNull("callback", callback);
            new APMWithTimeout(beginMethod, callback, state, timeoutInMS);
        }

        /// <summary>
        /// Flag to store completion status, 0 = non complete, 1 = complete
        /// </summary>
        private int completed = 0;

        /// <summary>
        /// Users Callback
        /// </summary>
        private AsyncCallback callback;

        /// <summary>
        /// Stores the native timer used to trigger after the specified delay.
        /// </summary>
        private Timer timer;

        private APMWithTimeout(Func<AsyncCallback, object, IAsyncResult> beginMethod, AsyncCallback callback, object state, int? timeoutInMS)
        {
            this.callback = callback;
            beginMethod(this.Complete, state);

            if (timeoutInMS.HasValue)
            {
                this.timer = new Timer((t) => this.Complete(null));
                this.timer.Change(TimeSpan.FromMilliseconds(timeoutInMS.Value), TimeSpan.FromMilliseconds(-1));
            }
        }

        private void Complete(IAsyncResult res)
        {
            // Only one winner gets to dispose timer and callback user
            if (Interlocked.CompareExchange(ref this.completed, 1, 0) == 0)
            {
                try
                {
                    if (this.timer != null)
                    {
                        this.timer.Dispose();
                        this.timer = null;
                    }
                }
                catch (Exception)
                {
                    // no op
                }
                finally
                {
                    // call users callback
                    this.callback(res);
                }
            }
        }
    }
}
