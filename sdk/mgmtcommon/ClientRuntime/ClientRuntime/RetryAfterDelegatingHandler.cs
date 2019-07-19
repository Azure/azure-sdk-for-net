// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Http retry handler.
    /// </summary>
    public class RetryAfterDelegatingHandler : DelegatingHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetryAfterDelegatingHandler"/> class.
        /// Sets default retry policy base on Exponential Backoff.
        /// </summary>
        public RetryAfterDelegatingHandler()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryAfterDelegatingHandler"/> class.
        /// </summary>
        /// <param name="innerHandler">Inner http handler.</param>
        public RetryAfterDelegatingHandler(DelegatingHandler innerHandler)
            : this((HttpMessageHandler)innerHandler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryAfterDelegatingHandler"/> class.
        /// </summary>
        /// <param name="innerHandler">Inner http handler.</param>
        public RetryAfterDelegatingHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
        }

        /// <summary>
        /// Sends an HTTP request to the inner handler to send to the server as an asynchronous
        /// operation. Retries request if a 429 is returned and there is a retry-after header.
        /// </summary>
        /// <param name="request">The HTTP request message to send to the server.</param>
        /// <param name="cancellationToken">A cancellation token to cancel operation.</param>
        /// <returns>Returns System.Threading.Tasks.Task&lt;TResult&gt;. The
        /// task object representing the asynchronous operation.</returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage previousResponseMessage = null;
            do {
                HttpResponseMessage response = null;

                try
                {
                    response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

                    // if they send back a 429 and there is a retry-after header
                    if (response.StatusCode == (HttpStatusCode)429 && response.Headers.Contains("Retry-After"))
                    {
                        try
                        {
                            // Read back the response message content so it does not go away as this response could be
                            // used if retries continue to fail.
                            // NOTE: If the content is not read and this message is returned later, an IO Exception will end up
                            //       happening indicating that request has been aborted.
                            if (response.Content != null)
                            {
                                await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            }

                            var oldResponse = previousResponseMessage;
                            previousResponseMessage = response;
                            oldResponse?.Dispose();
                        }
                        catch
                        {
                            // We can end up getting errors reading the content of the message if the connection was closed.
                            // These errors will be ignored and the previous response will continue to be used.
                            if (previousResponseMessage != null)
                            {
                                response = previousResponseMessage;
                            }
                        }

                        try
                        {
                            // and we get a number of seconds from the header
                            string retryValue = response.Headers.GetValues("Retry-After").FirstOrDefault();
                            var retryAfter = int.Parse(retryValue, CultureInfo.InvariantCulture);

                            // wait for that duration
                            await Task.Delay(TimeSpan.FromSeconds(retryAfter), cancellationToken).ConfigureAwait(false);

                            // and try again
                            continue;
                        }
                        catch
                        {
                            // if something throws while trying to get the retry-after
                            // we're just going to suppress it. let the response go
                            // back to the consumer.
                        }
                    }
                }
                catch (TaskCanceledException) when (previousResponseMessage != null)
                {
                    // We can get Task Canceled Exceptions while calling the base.SendAsync(...) and
                    // we do not want to let these bubble out when we have a previous response message to return.
                }

                // if we haven't hit continue, then return the response up the stream
                return response ?? previousResponseMessage;
            } while (true);
        }
    }
}