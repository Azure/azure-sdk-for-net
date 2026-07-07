// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Core.Tests.Identity.Samples.DocSnippets
{
    /// <summary>
    /// Placeholder <see cref="TokenCredential"/> used by the
    /// <c>MyVaultCredentialResolver</c> snippet.
    /// </summary>
    internal class MyVaultTokenCredential : TokenCredential
    {
        public MyVaultTokenCredential(string vaultUri)
        {
            VaultUri = vaultUri;
        }

        public string VaultUri { get; }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => default;

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => new(default(AccessToken));
    }
}
