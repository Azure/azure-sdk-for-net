// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    public class ManagedIdentityCredential : TokenCredential
    {
        private string _clientId;
        private IdentityClient _client;

        public ManagedIdentityCredential(string clientId = null, IdentityClientOptions options = null)
        {
            _clientId = clientId;

            _client = (options != null) ? new IdentityClient(options) : IdentityClient.SharedClient;
        }

        public override async Task<AccessToken> GetTokenAsync(string[] scopes, CancellationToken cancellationToken = default)
        {
            return await this._client.AuthenticateManagedIdentityAsync(scopes, _clientId, cancellationToken).ConfigureAwait(false);
        }

        public override AccessToken GetToken(string[] scopes, CancellationToken cancellationToken = default)
        {
            return this._client.AuthenticateManagedIdentity(scopes, _clientId, cancellationToken);
        }
    }
}
