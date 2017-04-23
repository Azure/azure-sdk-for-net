// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest.ClientRuntime.Properties;
using Microsoft.Rest.TransientFaultHandling;

namespace Microsoft.Rest
{
    /// <summary>
    /// Http retry handler.
    /// </summary>
    public class RetryDelegatingHandler : DelegatingHandler
    {
        private const int DefaultNumberOfAttempts = 3;
        private readonly TimeSpan DefaultBackoffDelta = new TimeSpan(0, 0, 10);
        private readonly TimeSpan DefaultMaxBackoff = new TimeSpan(0, 0, 10);
        private readonly TimeSpan DefaultMinBackoff = new TimeSpan(0, 0, 1);

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryDelegatingHandler"/> class. 
        /// Sets default retry policy base on Exponential Backoff.
        /// </summary>
        public RetryDelegatingHandler()
        {
            var retryStrategy = new ExponentialBackoffRetryStrategy(
                DefaultNumberOfAttempts,
                DefaultMinBackoff,
                DefaultMaxBackoff,
                DefaultBackoffDelta);
            RetryPolicy = new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(retryStrategy);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryDelegatingHandler"/> class. Sets 
        /// the default retry policy base on Exponential Backoff.
        /// </summary>
        /// <param name="innerHandler">Inner http handler.</param>
        public RetryDelegatingHandler(DelegatingHandler innerHandler)
            : base(innerHandler)
        {
            var retryStrategy = new ExponentialBackoffRetryStrategy(
                DefaultNumberOfAttempts,
                DefaultMinBackoff,
                DefaultMaxBackoff,
                DefaultBackoffDelta);
            RetryPolicy = new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(retryStrategy);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryDelegatingHandler"/> class. 
        /// </summary>
        /// <param name="retryPolicy">Retry policy to use.</param>
        /// <param name="innerHandler">Inner http handler.</param>
        public RetryDelegatingHandler(RetryPolicy retryPolicy, DelegatingHandler innerHandler)
            : base(innerHandler)
        {
            if (retryPolicy == null)
            {
                throw new ArgumentNullException("retryPolicy");
            }
            RetryPolicy = retryPolicy;
        }

        /// <summary>
        /// Gets or sets retry policy.
        /// </summary>
        public RetryPolicy RetryPolicy { get; set; }

        /// <summary>
        /// Sends an HTTP request to the inner handler to send to the server as an asynchronous
        /// operation. Retries request if needed based on Retry Policy.
        /// </summary>
        /// <param name="request">The HTTP request message to send to the server.</param>
        /// <param name="cancellationToken">A cancellation token to cancel operation.</param>
        /// <returns>Returns System.Threading.Tasks.Task&lt;TResult&gt;. The 
        /// task object representing the asynchronous operation.</returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            RetryPolicy.Retrying += (sender, args) =>
            {
                if (Retrying != null)
                {
                    Retrying(sender, args);
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

                        throw new HttpRequestWithStatusException(string.Format(
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
        private event EventHandler<RetryingEventArgs> Retrying;
    }
}