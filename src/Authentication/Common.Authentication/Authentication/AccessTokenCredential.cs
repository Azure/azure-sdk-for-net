// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Common.Authentication
{
    public class AccessTokenCredential : SubscriptionCloudCredentials
    {
        private readonly Guid subscriptionId;
        private readonly IAccessToken token;

        public AccessTokenCredential(Guid subscriptionId, IAccessToken token)
        {
            this.subscriptionId = subscriptionId;
            this.token = token;
            this.TenantID = token.TenantId;
        }
        
        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            token.AuthorizeRequest((tokenType, tokenValue) => {
                request.Headers.Authorization = new AuthenticationHeaderValue(tokenType, tokenValue);
            });
            return base.ProcessHttpRequestAsync(request, cancellationToken);
        }

        public override string SubscriptionId
        {
            get { return subscriptionId.ToString(); }
        }

        public string TenantID { get; set; }
    }
}