// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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