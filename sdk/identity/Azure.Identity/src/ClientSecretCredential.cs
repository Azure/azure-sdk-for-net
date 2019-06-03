// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    public class ClientSecretCredential : AzureCredential
    {
        public string TenantId { get; private set; }

        public string ClientId { get; private set; }

        public string ClientSecret { get; private set; }

        public ClientSecretCredential(string tenantId, string clientId, string clientSecret)
            : this(tenantId, clientId, clientSecret, null)
        {
        }

        public ClientSecretCredential(string tenantId, string clientId, string clientSecret, IdentityClientOptions options)
            : base(options)
        {
            TenantId = tenantId;
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        protected override async Task<AccessToken> GetTokenCoreAsync(string[] scopes, CancellationToken cancellationToken = default)
        {
            return await this.Client.AuthenticateAsync(TenantId, ClientId, ClientSecret, scopes, cancellationToken).ConfigureAwait(false);
        }

        protected override AccessToken GetTokenCore(string[] scopes, CancellationToken cancellationToken = default)
        {
            return this.Client.Authenticate(TenantId, ClientId, ClientSecret, scopes, cancellationToken);
        }
    }
}
