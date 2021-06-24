﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// Represents a credential capable of providing an OAuth token.
    /// </summary>
    public abstract class TokenCredential
    {
        /// <summary>
        /// Gets an <see cref="AccessToken"/> for the specified set of scopes.
        /// </summary>
        /// <param name="requestContext">The <see cref="TokenRequestContext"/> with authentication information.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A valid <see cref="AccessToken"/>.</returns>
        public abstract ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken);

        /// <summary>
        /// Gets an <see cref="AccessToken"/> for the specified set of scopes.
        /// </summary>
        /// <param name="requestContext">The <see cref="TokenRequestContext"/> with authentication information.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A valid <see cref="AccessToken"/>.</returns>
        public abstract AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken);

        /// <summary>
        /// Indicates if a <see cref="TokenCredential"/> supports token caching.
        /// If <c>true</c>, upstream components such as a <see cref="HttpPipelinePolicy"/> should rely on the credential itself to manage any token caching.
        /// </summary>
        public virtual bool SupportsCaching => false;
    }
}
