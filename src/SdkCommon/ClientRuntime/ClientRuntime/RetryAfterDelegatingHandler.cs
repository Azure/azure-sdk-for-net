// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Rest
{
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
            do {
                var response = await base.SendAsync(request, cancellationToken);
                
                // if they send back a 429
                if( response.StatusCode == ((HttpStatusCode)429) ) {

                    // and there is a retry-after header
                    if (response.Headers.Contains("Retry-After"))
                    {
                        try {
                            // and we get a number of seconds from the header
                            string retryValue = response.Headers.GetValues("Retry-After").FirstOrDefault();
                            var retryAfter = int.Parse(retryValue, CultureInfo.InvariantCulture);
                            
                            // wait for that duration
                            await Task.Delay(retryAfter,cancellationToken);

                            // and try again
                            continue;
                        } catch {
                            // if something throws while trying to get the retry-after
                            // we're just going to suppress it. let the response go
                            // back to the consumer.
                        }
                    }
                }
                // if we haven't hit continue, then return the response up the stream
                return response;
            } while( true );
        }
    }
}
