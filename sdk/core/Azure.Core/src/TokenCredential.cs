// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    /// <summary>
    /// Represents a credential capable of providing an OAuth token
    /// </summary>
    public abstract class TokenCredential
    {
        public abstract Task<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken);

        public abstract AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken);
    }
}
