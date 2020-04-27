// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Primitives
{
    using System.Diagnostics;
    using System;
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
            var securityToken = await _tokenProvider.GetTokenAsync(appliesTo, _operationTimeout).ConfigureAwait(false);
            return new CbsToken(securityToken.TokenValue, CbsConstants.ServiceBusSasTokenType, securityToken.ExpiresAtUtc);
        }
    }
}
