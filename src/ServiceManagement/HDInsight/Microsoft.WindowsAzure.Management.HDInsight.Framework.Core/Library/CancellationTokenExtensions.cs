namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    /// <summary>
    /// Adds extension methods to the Cancelation Token class.
    /// </summary>
#if Non_Public_SDK
    public static class CancellationTokenExtensions
#else
    internal static class CancellationTokenExtensions
#endif
    {
        /// <summary>
        /// Waits on a cancellation token for a given interval.
        /// </summary>
        /// <param name="token">
        /// The Cancellation Token.
        /// </param>
        /// <param name="interval">
        /// The period of time to wait.
        /// </param>
        public static void WaitForInterval(this CancellationToken token, TimeSpan interval)
        {
            var start = DateTime.Now;
            var waitFor = Math.Min((int)interval.TotalMilliseconds, 1000);
            while (DateTime.Now - start < interval)
            {
                if (token.IsCancellationRequested)
                {
                    throw new OperationCanceledException("The operation was canceled by user request.");
                }
                Thread.Sleep(waitFor);
            }
        }
    }
}
