// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Primitives
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;

    /// <summary>
    /// Provides an adapter from TokenProvider to ICbsTokenProvider for AMQP CBS usage.
    /// </summary>
    sealed class TokenProviderAdapter : ICbsTokenProvider
    {
        readonly TokenProvider tokenProvider;
        readonly TimeSpan operationTimeout;

        public TokenProviderAdapter(TokenProvider tokenProvider, TimeSpan operationTimeout)
        {
            Fx.Assert(tokenProvider != null, "tokenProvider cannot be null");
            this.tokenProvider = tokenProvider;
            this.operationTimeout = operationTimeout;
        }

        public async Task<CbsToken> GetTokenAsync(Uri namespaceAddress, string appliesTo, string[] requiredClaims)
        {
            string claim = requiredClaims?.FirstOrDefault();
            SecurityToken token = await this.tokenProvider.GetTokenAsync(appliesTo, claim, this.operationTimeout).ConfigureAwait(false);
            return new CbsToken(token.TokenValue, CbsConstants.ServiceBusSasTokenType, token.ExpiresAtUtc);
        }
    }
}