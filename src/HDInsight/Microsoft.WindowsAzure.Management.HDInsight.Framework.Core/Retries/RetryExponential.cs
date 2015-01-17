namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;

    /// <summary>
    /// Defines an exponential retry.
    /// </summary>
    internal class RetryExponential : IRetryPolicy
    {
        private static Random random = new Random();

        private readonly TimeSpan maxBackoff, minBackoff, deltaBackoff;

        private int maxAttemptCount;

        private double randomizationQuotient;

        /// <summary>
        /// Initializes a new instance of the RetryExponential class.
        /// </summary>
        /// <param name="minBackoff">The minimum backoff.</param>
        /// <param name="maxBackoff">The maximum backoff.</param>
        /// <param name="deltaBackoff">The delta backoff.</param>
        /// <param name="maxAttemptCount">The number of times the operation will be attempted before giving up.</param>
        /// <param name="randomizationTolerance">The randomization tolerance.</param>
        public RetryExponential(TimeSpan minBackoff, TimeSpan maxBackoff, TimeSpan deltaBackoff, int maxAttemptCount, double randomizationTolerance)
        {
            this.maxBackoff = maxBackoff;
            this.deltaBackoff = deltaBackoff;
            this.maxAttemptCount = maxAttemptCount;
            this.randomizationQuotient = randomizationTolerance;
            this.minBackoff = minBackoff;
        }

        /// <summary>
        /// Initializes a new instance of the RetryExponential class.
        /// </summary>
        public RetryExponential()
        {
            this.maxBackoff = RetryDefaultConstants.DefaultMaxBackOff;
            this.deltaBackoff = RetryDefaultConstants.DefaultBackOff;
            this.maxAttemptCount = RetryDefaultConstants.DefaultRetryCount;
            this.randomizationQuotient = RetryDefaultConstants.DefaultRandomizationQuotient;
            this.minBackoff = RetryDefaultConstants.DefaultMinBackOff;
        }

        private bool IsTransient(Exception ex)
        {
            ex = ex.GetFirstException();

            //should retry on timeout
            if (RetryUtils.FindFirstExceptionOfType<TimeoutException>(ex).IsNotNull())
            {
                return true;
            }

            //should not retry on task cancelled or operation cancelled if not timeout
            if (RetryUtils.FindFirstExceptionOfType<TaskCanceledException>(ex).IsNotNull() ||
                RetryUtils.FindFirstExceptionOfType<OperationCanceledException>(ex).IsNotNull())
            {
                return false;
            }

            //if the http layer exception contains an http status code of 409, 449, of 5xx, we retry. any other valid http status code we don't retry
            var hlex = RetryUtils.FindFirstExceptionOfType<HttpLayerException>(ex);
            if (hlex.IsNotNull())
            {
                HttpStatusCode responseStatusCode = hlex.RequestStatusCode;
                return RetryUtils.IsTransientHttpStatusCode(responseStatusCode);
            }

            var webEx = RetryUtils.FindFirstExceptionOfType<WebException>(ex);
            if (webEx.IsNotNull())
            {
                return RetryUtils.IsTransientWebException(webEx);
            }
           
            return false;
        }

        /// <summary>
        /// Gets or sets the number of times the operation will be attempted before giving up.
        /// </summary>
        public int MaxAttemptCount
        {
            get
            {
                return this.maxAttemptCount;
            }

            set
            {
                this.maxAttemptCount = value;
            }
        }

        /// <summary>
        /// Gets the RetryParameters.
        /// </summary>
        /// <param name="currentRetryCount">Specifies the current count of attempted retries.</param>
        /// <param name="exception">Specifies the error associated with the latest retry.</param>
        /// <returns>The RetryParameters corresponding with the parameters provided.</returns>
        public RetryParameters GetRetryParameters(int currentRetryCount, Exception exception)
        {
            int incrementMilliseconds = (int)(Math.Pow(2, currentRetryCount) - 1) * random.Next(
                                     (int)(this.randomizationQuotient * this.deltaBackoff.TotalMilliseconds),
                                     (int)((1 - this.randomizationQuotient) * this.deltaBackoff.TotalMilliseconds));
            int delayInMilliseconds = (int)Math.Min(this.minBackoff.TotalMilliseconds + incrementMilliseconds, this.maxBackoff.TotalMilliseconds);
            var delay = TimeSpan.FromMilliseconds(delayInMilliseconds);
            return new RetryParameters(currentRetryCount < this.maxAttemptCount && this.IsTransient(exception), delay);
        }
    }
}
