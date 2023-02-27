// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.AI.TextTranslator.Tests
{
    /// <summary>
    /// Represents a static access token credential.
    /// Implements the <see cref="TokenCredential" />.
    /// </summary>
    /// <seealso cref="TokenCredential" />
    internal class StaticAccessTokenCredential : TokenCredential
    {
        private readonly AccessToken _token;

        /// <summary>
        /// Initializes a new instance of the <see cref="StaticAccessTokenCredential"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        public StaticAccessTokenCredential(AccessToken token) => _token = token;

        /// <summary>
        /// Gets an <see cref="AccessToken" /> for the specified set of scopes.
        /// </summary>
        /// <param name="requestContext">The <see cref="TokenRequestContext" /> with authentication information.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /> to use.</param>
        /// <returns>A valid <see cref="AccessToken" />.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => this._token;

        /// <summary>
        /// Gets an <see cref="AccessToken" /> for the specified set of scopes.
        /// </summary>
        /// <param name="requestContext">The <see cref="TokenRequestContext" /> with authentication information.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /> to use.</param>
        /// <returns>A valid <see cref="AccessToken" />.</returns>
        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => new ValueTask<AccessToken>(this._token);
    }
}
