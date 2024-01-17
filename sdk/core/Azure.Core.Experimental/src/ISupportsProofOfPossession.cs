// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    /// <summary>
    /// An interface used to decorate a <see cref="TokenCredential"/> that supports <see href="https://learn.microsoft.com/entra/msal/dotnet/advanced/proof-of-possession-tokens">Proof of Possession tokens</see> for authenticating to Microsoft Entra ID.
    /// </summary>
    public interface ISupportsProofOfPossession
    {
        /// <summary>
        /// Gets an <see cref="AccessToken"/> for the specified set of scopes.
        /// </summary>
        /// <param name="requestContext">The <see cref="PopTokenRequestContext"/> with authentication information.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A valid <see cref="AccessToken"/>.</returns>
        /// <remarks>Caching and management of the lifespan for the <see cref="AccessToken"/> is considered the responsibility of the caller. Each call should request a fresh token.</remarks>
        public ValueTask<AccessToken> GetTokenAsync(PopTokenRequestContext requestContext, CancellationToken cancellationToken);

        /// <summary>
        /// Gets an <see cref="AccessToken"/> for the specified set of scopes.
        /// </summary>
        /// <param name="requestContext">The <see cref="PopTokenRequestContext"/> with authentication information.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A valid <see cref="AccessToken"/>.</returns>
        /// <remarks>Caching and management of the lifespan for the <see cref="AccessToken"/> is considered the responsibility of the caller. Each call should request a fresh token.</remarks>
        public AccessToken GetToken(PopTokenRequestContext requestContext, CancellationToken cancellationToken);
    }
}
