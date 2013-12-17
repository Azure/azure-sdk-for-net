//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Common.Properties;
using Microsoft.WindowsAzure.Common.TransientFaultHandling;

namespace Microsoft.WindowsAzure
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
                            throw new HttpRequestExceptionWithStatus(string.Format(
                                CultureInfo.InvariantCulture,
                                Resources.ResponseStatusCodeError,
                                (int)responseMessage.StatusCode,
                                responseMessage.StatusCode)) { StatusCode = responseMessage.StatusCode };
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
        }

        /// <summary>
        /// An instance of a callback delegate that will be invoked whenever a retry condition is encountered.
        /// </summary>
        public event EventHandler<RetryingEventArgs> Retrying;
    }
}
