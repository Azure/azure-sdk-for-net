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

namespace Microsoft.Azure.Batch.Protocol
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// BatchCredentials which implement Azure AD auth
    /// </summary>
    internal class BatchTokenCredential : BatchCredentials
    {
        private const string BearerAuthenticationScheme = "Bearer";

        private Func<Task<string>> TokenProvider { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchTokenCredential"/> class.
        /// </summary>
        /// <param name="token">An authentication token provided by Azure Active Directory.</param>
        public BatchTokenCredential(string token) 
            : this(TokenToProvider(token))
        {
        }

        private static Func<Task<string>> TokenToProvider(string token)
        {
            var task = Task.FromResult(token);
            return () => task;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchTokenCredential" /> class with the specified Batch service endpoint and authentication token provider function.
        /// </summary>
        /// <param name="tokenProvider">A function that returns an authentication token.</param>
        public BatchTokenCredential(Func<Task<string>> tokenProvider)
        {
            this.TokenProvider = tokenProvider;
        }

        /// <summary>
        /// Signs a HTTP request with the current <see cref="BatchCredentials"/>.
        /// </summary>
        /// <param name="request">The HTTP request</param>
        /// <param name="cancellationToken">A <see cref="System.Threading.CancellationToken"/> for the request.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous signing operation.</returns>
        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return this.SignRequestAsync(request, cancellationToken);
        }

        /// <summary>
        /// Sign request
        /// </summary>
        /// <param name="httpRequest">The HTTP request to be signed.</param>
        /// <param name="cancellationToken">A <see cref="System.Threading.CancellationToken"/> for the request.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous signing operation.</returns>
        public override async Task SignRequestAsync(HttpRequestMessage httpRequest, System.Threading.CancellationToken cancellationToken)
        {
            if (httpRequest != null)
            {
                string token = await TokenProvider().ConfigureAwait(false);
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue(BearerAuthenticationScheme, token);
            }
        }
    }
}
