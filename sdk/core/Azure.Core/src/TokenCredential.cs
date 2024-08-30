// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    /// <summary>
    /// Represents a credential capable of providing an OAuth token.
    /// </summary>
    public abstract class TokenCredential : CredentialProvider
    {
        /// <summary>
        /// Gets an <see cref="AccessToken"/> for the specified set of scopes.
        /// </summary>
        /// <param name="requestContext">The <see cref="TokenRequestContext"/> with authentication information.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A valid <see cref="AccessToken"/>.</returns>
        /// <remarks>Caching and management of the lifespan for the <see cref="AccessToken"/> is considered the responsibility of the caller: each call should request a fresh token being requested.</remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/identity")]
        public abstract ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken);

        /// <summary>
        /// Gets an <see cref="AccessToken"/> for the specified set of scopes.
        /// </summary>
        /// <param name="requestContext">The <see cref="TokenRequestContext"/> with authentication information.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A valid <see cref="AccessToken"/>.</returns>
        /// <remarks>Caching and management of the lifespan for the <see cref="AccessToken"/> is considered the responsibility of the caller: each call should request a fresh token being requested.</remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/identity")]
        public abstract AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken);

        /// <summary>
        ///  Gets an <see cref="AccessToken"/> for the specified set of scopes.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Credential GetCredential(IReadOnlyDictionary<string, object> context, CancellationToken cancellationToken) =>
            GetToken(TokenRequestContext.FromDictionary(context), cancellationToken).ToCredential();

        /// <summary>
        ///  Gets an <see cref="AccessToken"/> for the specified set of scopes.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async ValueTask<Credential> GetCredentialAsync(IReadOnlyDictionary<string, object> context, CancellationToken cancellationToken) =>
            (await GetTokenAsync(TokenRequestContext.FromDictionary(context), cancellationToken).ConfigureAwait(false)).ToCredential();
    }
}
