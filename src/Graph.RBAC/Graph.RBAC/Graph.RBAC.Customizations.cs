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
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Graph.RBAC
{
    public class TenantCloudCredentials : SubscriptionCloudCredentials
    {
        /// <summary>
        /// Gets an empty subscription Id.
        /// </summary>
        public override string SubscriptionId
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// Gets or sets tenant ID for AAD. 
        /// </summary>
        public string TenantID { get; set; }

        /// <summary>
        /// Gets or sets secure token used to authenticate against Azure API. 
        /// No anonymous requests are allowed.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Apply the credentials to the HTTP request.
        /// </summary>
        /// <param name="request">The HTTP request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// Task that will complete when processing has completed.
        /// </returns>
        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            return base.ProcessHttpRequestAsync(request, cancellationToken);
        }
    }
}
