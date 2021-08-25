// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// Used internally to indiate the client is intended for use with anonymous access authentication.
    /// </summary>
    internal class ContainerRegistryAnonymousAccessCredential : TokenCredential
    {
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            throw new InvalidOperationException();
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            throw new InvalidOperationException();
        }
    }
}
