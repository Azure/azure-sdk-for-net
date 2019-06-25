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
        private ManagedIdentityClient _client;
        private SemaphoreSlim _initLock = new SemaphoreSlim(1, 1);


        private readonly Uri ImdsEndptoint = new Uri("http://169.254.169.254/metadata/identity/oauth2/token");
        private const string ImdsApiVersion = "2018-02-01";

        public ManagedIdentityCredential(string clientId = null, IdentityClientOptions options = null)
        {
            _clientId = clientId;

            _client = (options != null) ? new ManagedIdentityClient(options) : ManagedIdentityClient.SharedClient;
        }

        public override async Task<AccessToken> GetTokenAsync(string[] scopes, CancellationToken cancellationToken = default)
        {
            return await this._client.AuthenticateAsync(scopes, _clientId, cancellationToken).ConfigureAwait(false);
        }

        public override AccessToken GetToken(string[] scopes, CancellationToken cancellationToken = default)
        {
            return this._client.Authenticate(scopes, _clientId, cancellationToken);
        }
    }
}
