// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Credentials;

namespace Azure.Core.Identity
{
    public class ClientSecretCredential : AzureCredential
    {
        public string TenantId { get; private set; }

        public string ClientId { get; private set; }

        public string ClientSecret { get; private set; }

        internal override async Task<AuthenticationResponse> Authenticate(IEnumerable<string> scopes, CancellationToken cancellationToken = default)
        {
            return await this.Client.AuthenticateAsync(TenantId, ClientId, ClientSecret, scopes, cancellationToken).ConfigureAwait(false);
        }
    }

    

}
