// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.

// 

namespace Microsoft.Azure.Batch.Protocol
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Net.Http;
    using System.Threading;
    using System.Globalization;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;
    using System.Net.Http.Headers;
    using Rest;

    /// <summary>
    /// Base class for credentials used to authenticate a HTTP request to Azure Batch.
    /// </summary>
    public abstract class BatchCredentials : ServiceClientCredentials
    {
        /// <summary>
        /// Signs a HTTP request with the current <see cref="BatchCredentials"/>.
        /// </summary>
        /// <param name="httpRequest">The HTTP request to be signed.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for the request.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous signing operation.</returns>
        public abstract Task SignRequestAsync(HttpRequestMessage httpRequest, CancellationToken cancellationToken);
    }

    /// <summary>
    /// A <see cref="HttpMessageHandler"/> that adds authentication to outgoing requests using a <see cref="BatchCredentials"/>.
    /// </summary>
    public class BatchAuthenticationDelegatingHandler : DelegatingHandler
    {
        private readonly BatchCredentials credential;

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchAuthenticationDelegatingHandler"/> class.
        /// </summary>
        /// <param name="credential">The <see cref="BatchCredentials"/> to be used for authenticating requests made through this handler.</param>
        public BatchAuthenticationDelegatingHandler(BatchCredentials credential)
        {
            this.credential = credential;
        }

        /// <summary>
        /// Adds authentication to a HTTP request then sends it to the inner handler to send to the server
        /// as an asynchronous operation.
        /// </summary>
        /// <param name="request">The HTTP request message to send to the server.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>The response to the HTTP request</returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            await credential.SignRequestAsync(request, cancellationToken).ConfigureAwait(false);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}