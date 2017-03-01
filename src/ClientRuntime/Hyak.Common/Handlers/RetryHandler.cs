// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common.Properties;
using Hyak.Common.TransientFaultHandling;

namespace Hyak.Common
{
    /// <summary>
    /// Http retry handler.
    /// </summary>
    public class RetryHandler : DelegatingHandler
    {
        private const int DefaultNumberOfAttempts = 3;
        private TimeSpan DefaultMinBackoff = new TimeSpan(0, 0, 1);
        private TimeSpan DefaultMaxBackoff = new TimeSpan(0, 0, 10);
        private TimeSpan DefaultBackoffDelta = new TimeSpan(0, 0, 10);

        /// <summary>
        /// Gets or sets retry policy.
        /// </summary>
        public RetryPolicy RetryPolicy { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="RetryHandler"/> class. Sets 
        /// default retry policty base on Exponential Backoff.
        /// </summary>
        public RetryHandler()
            : base()
        {
            var retryStrategy = new ExponentialBackoff(
                DefaultNumberOfAttempts, 
                DefaultMinBackoff,
                DefaultMaxBackoff, 
                DefaultBackoffDelta);
            RetryPolicy = new RetryPolicy<DefaultHttpErrorDetectionStrategy>(retryStrategy);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryHandler"/> class. Sets 
        /// the default retry policty base on Exponential Backoff.
        /// </summary>
        /// <param name="innerHandler">Inner http handler.</param>
        public RetryHandler(DelegatingHandler innerHandler)
            : base(innerHandler)
        {
            var retryStrategy = new ExponentialBackoff(
                DefaultNumberOfAttempts,
                DefaultMinBackoff,
                DefaultMaxBackoff,
                DefaultBackoffDelta);
            RetryPolicy = new RetryPolicy<DefaultHttpErrorDetectionStrategy>(retryStrategy);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryHandler"/> class. 
        /// </summary>
        /// <param name="retryPolicy">Retry policy to use.</param>
        /// <param name="innerHandler">Inner http handler.</param>
        public RetryHandler(RetryPolicy retryPolicy, DelegatingHandler innerHandler)
            : base(innerHandler)
        {
            if (retryPolicy == null)
            {
                throw new ArgumentNullException("retryPolicy");
            }
            RetryPolicy = retryPolicy;
        }

        /// <summary>
        /// Sends an HTTP request to the inner handler to send to the server as an asynchronous
        /// operation. Retries request if needed based on Retry Policy.
        /// </summary>
        /// <param name="request">The HTTP request message to send to the server.</param>
        /// <param name="cancellationToken">A cancellation token to cancel operation.</param>
        /// <returns>Returns System.Threading.Tasks.Task&lt;TResult&gt;. The 
        /// task object representing the asynchronous operation.</returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

             RetryPolicy.Retrying += (sender, args) =>
            {
                if (this.Retrying != null)
                {
                    this.Retrying(sender, args);
                }
           };

           HttpResponseMessage responseMessage = null;
            try
            {
                await RetryPolicy.ExecuteAsync(async () =>
                {
                    responseMessage = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        // dispose the message unless we have stopped retrying
                        this.Retrying += (sender, args) =>
                        {
                            if (responseMessage != null)
                            {
                                responseMessage.Dispose();
                                responseMessage = null;
                            }
                        };

                        throw new HttpRequestExceptionWithStatus(string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.ResponseStatusCodeError,
                            (int) responseMessage.StatusCode,
                            responseMessage.StatusCode)) {StatusCode = responseMessage.StatusCode};
                    }

                    return responseMessage;
                }, cancellationToken).ConfigureAwait(false);

                return responseMessage;
            }
            catch
            {
                if (responseMessage != null)
                {
                    return responseMessage;
                }
                else
                {
                    throw;
                }
            }
            finally
            {
                if (Retrying != null)
                {
                    foreach (EventHandler<RetryingEventArgs> d in Retrying.GetInvocationList())
                    {
                        Retrying -= d;
                    }
                }
            }
        }

        /// <summary>
        /// An instance of a callback delegate that will be invoked whenever a retry condition is encountered.
        /// </summary>
        public event EventHandler<RetryingEventArgs> Retrying;

    }
}
