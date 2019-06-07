// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    public class ManagedIdentityCredential : AzureCredential
    {
        private string _clientId;

        public ManagedIdentityCredential(string clientId = null, IdentityClientOptions options = null)
            : base(options)
        {
            _clientId = clientId;
        }

        protected override async Task<AccessToken> GetTokenCoreAsync(string[] scopes, CancellationToken cancellationToken = default)
        {
            return await this.Client.AuthenticateManagedIdentityAsync(scopes, _clientId, cancellationToken).ConfigureAwait(false);
        }

        protected override AccessToken GetTokenCore(string[] scopes, CancellationToken cancellationToken = default)
        {
            return this.Client.AuthenticateManagedIdentity(scopes, _clientId, cancellationToken);
        }
    }
}
