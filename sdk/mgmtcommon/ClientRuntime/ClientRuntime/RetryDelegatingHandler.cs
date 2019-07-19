// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest
{
    using Microsoft.Rest.ClientRuntime.Properties;
    using Microsoft.Rest.TransientFaultHandling;
    using System;
    using System.Globalization;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

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
        public RetryDelegatingHandler() : base()
        {
            Init();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryDelegatingHandler"/> class. Sets
        /// the default retry policy base on Exponential Backoff.
        /// </summary>
        /// <param name="innerHandler">Inner http handler.</param>
        public RetryDelegatingHandler(DelegatingHandler innerHandler)
            : this((HttpMessageHandler)innerHandler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryDelegatingHandler"/> class. Sets
        /// the default retry policy base on Exponential Backoff.
        /// </summary>
        /// <param name="innerHandler">Inner http handler.</param>
        public RetryDelegatingHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
            Init();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryDelegatingHandler"/> class.
        /// </summary>
        /// <param name="retryPolicy">Retry policy to use.</param>
        /// <param name="innerHandler">Inner http handler.</param>
        public RetryDelegatingHandler(RetryPolicy retryPolicy, HttpMessageHandler innerHandler)
            : this(innerHandler)
        {
            RetryPolicy = retryPolicy ?? throw new ArgumentNullException("retryPolicy");
        }

        private void Init()
        {
            var retryStrategy = new ExponentialBackoffRetryStrategy(
                DefaultNumberOfAttempts,
                DefaultMinBackoff,
                DefaultMaxBackoff,
                DefaultBackoffDelta);

            RetryPolicy = new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(retryStrategy);
        }

        /// <summary>
        /// Gets or sets retry policy.
        /// </summary>
        public RetryPolicy RetryPolicy { get; set; }

        /// <summary>
        /// Get delegate count associated with the event
        /// </summary>
        public int EventCallbackCount => this.RetryPolicy.EventCallbackCount;

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
            HttpResponseMessage responseMessage = null;
            HttpResponseMessage lastErrorResponseMessage = null;
            try
            {
                await RetryPolicy.ExecuteAsync(async () =>
                {
                    responseMessage = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        try
                        {
                            // Save off the response message and read back its content so it does not go away as this
                            // response will be used if retries continue to fail.
                            // NOTE: If the content is not read and this message is returned later, an IO Exception will end up
                            //       happening indicating that the stream has been aborted.
                            if (responseMessage.Content != null)
                            {
                                await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                            }

                            var oldResponse = lastErrorResponseMessage;
                            lastErrorResponseMessage = responseMessage;
                            oldResponse?.Dispose();
                        }
                        catch
                        {
                            // We can end up getting errors reading the content of the message if the connection was closed.
                            // These errors will be ignored and the previous last error response will continue to be used.
                            if (lastErrorResponseMessage != null)
                            {
                                responseMessage = lastErrorResponseMessage;
                            }
                        }

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
            catch (Exception) when (responseMessage != null || lastErrorResponseMessage != null)
            {
                return responseMessage ?? lastErrorResponseMessage;
            }
        }
    }
}