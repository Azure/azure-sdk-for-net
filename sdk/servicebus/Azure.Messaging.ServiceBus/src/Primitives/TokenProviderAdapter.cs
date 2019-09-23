// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;

namespace Azure.Messaging.ServiceBus.Primitives
{
    using System.Diagnostics;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;

    /// <summary>
    /// Provides an adapter from TokenCredential to ICbsTokenProvider for AMQP CBS usage.
    /// </summary>
    internal sealed class TokenProviderAdapter : ICbsTokenProvider
    {
        private readonly TokenCredential tokenProvider;

        private readonly TimeSpan operationTimeout;

        public TokenProviderAdapter(TokenCredential tokenProvider, TimeSpan operationTimeout)
        {
            Debug.Assert(tokenProvider != null, "tokenProvider cannot be null");
            this.tokenProvider = tokenProvider;
            this.operationTimeout = operationTimeout;
        }

        public async Task<CbsToken> GetTokenAsync(Uri namespaceAddress, string appliesTo, string[] requiredClaims)
        {
            var claim = requiredClaims?.FirstOrDefault();
            var securityToken = await this.tokenProvider.GetTokenAsync(new TokenRequest(new[] { appliesTo }), CancellationToken.None).ConfigureAwait(false);
            return new CbsToken(securityToken.Token, CbsConstants.ServiceBusSasTokenType, securityToken.ExpiresOn.DateTime);
        }
    }
}
