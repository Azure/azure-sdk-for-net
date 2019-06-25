// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    public class ClientSecretCredential : TokenCredential
    {
        private string _tenantId;
        private string _clientId;
        private string _clientSecret;
        private AadClient _client;


        public ClientSecretCredential(string tenantId, string clientId, string clientSecret)
            : this(tenantId, clientId, clientSecret, null)
        {
        }

        public ClientSecretCredential(string tenantId, string clientId, string clientSecret, IdentityClientOptions options)
        {
            _tenantId = tenantId;
            _clientId = clientId;
            _clientSecret = clientSecret;

            _client = (options != null) ? new AadClient(options) : AadClient.SharedClient;
        }

        public override async Task<AccessToken> GetTokenAsync(string[] scopes, CancellationToken cancellationToken = default)
        {
            return await this._client.AuthenticateAsync(_tenantId, _clientId, _clientSecret, scopes, cancellationToken).ConfigureAwait(false);
        }

        public override AccessToken GetToken(string[] scopes, CancellationToken cancellationToken = default)
        {
            return this._client.Authenticate(_tenantId, _clientId, _clientSecret, scopes, cancellationToken);
        }
    }
}
