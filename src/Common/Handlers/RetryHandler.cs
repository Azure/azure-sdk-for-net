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
    public class RetryHandler : DelegatingHandler
    {
        public RetryPolicy RetryPolicy { get; private set; }
        
        public RetryHandler()
            : base()
        {
            var retryStrategy = new ExponentialBackoff(3, new TimeSpan(0, 0, 1), new TimeSpan(0, 0, 10), new TimeSpan(0, 0, 2));
            RetryPolicy = new RetryPolicy<DefaultHttpErrorDetectionStrategy>(retryStrategy);
        }

        public RetryHandler(RetryPolicy retryPolicy)
            : base()
        {
            if (retryPolicy == null)
            {
                throw new ArgumentNullException("retryPolicy");
            }
            RetryPolicy = retryPolicy;
        }

        public RetryHandler(RetryPolicy retryPolicy, DelegatingHandler innerHandler)
            : base(innerHandler)
        {
            if (retryPolicy == null)
            {
                throw new ArgumentNullException("retryPolicy");
            }
            RetryPolicy = retryPolicy;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            RetryPolicy.Retrying += (sender, args) =>
            {
                if (this.Retrying != null)
                {
                    this.Retrying(sender, args);
                }
            };

            try
            {
                HttpResponseMessage response = await RetryPolicy.ExecuteAction(async () =>
                    {
                        var responseMessage = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

                        if (!responseMessage.IsSuccessStatusCode)
                        {
                            throw new HttpRequestExceptionWithStatus(string.Format(
                                CultureInfo.InvariantCulture,
                                Resources.ResponseStatusCodeError,
                                (int)responseMessage.StatusCode,
                                responseMessage.StatusCode)) { StatusCode = responseMessage.StatusCode };
                        }

                        return responseMessage;
                    });

                return response;
            }
            catch (HttpRequestException)
            {
                return responseMessage;
            }            
        }

        /// <summary>
        /// An instance of a callback delegate that will be invoked whenever a retry condition is encountered.
        /// </summary>
        public event EventHandler<RetryingEventArgs> Retrying;
    }
}
