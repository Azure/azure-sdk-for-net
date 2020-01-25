// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Primitives
{
    using System.Diagnostics;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;

    /// <summary>
    /// Provides an adapter from TokenProvider to ICbsTokenProvider for AMQP CBS usage.
    /// </summary>
    internal sealed class TokenProviderAdapter : ICbsTokenProvider
    {
        private readonly ITokenProvider _tokenProvider;
        private readonly TimeSpan _operationTimeout;

        public TokenProviderAdapter(ITokenProvider tokenProvider, TimeSpan operationTimeout)
        {
            Debug.Assert(tokenProvider != null, "tokenProvider cannot be null");
            this._tokenProvider = tokenProvider;
            this._operationTimeout = operationTimeout;
        }

        public async Task<CbsToken> GetTokenAsync(Uri namespaceAddress, string appliesTo, string[] requiredClaims)
        {
            var claim = requiredClaims?.FirstOrDefault();
            var securityToken = await this._tokenProvider.GetTokenAsync(appliesTo, this._operationTimeout).ConfigureAwait(false);
            return new CbsToken(securityToken.TokenValue, CbsConstants.ServiceBusSasTokenType, securityToken.ExpiresAtUtc);
        }
    }
}
