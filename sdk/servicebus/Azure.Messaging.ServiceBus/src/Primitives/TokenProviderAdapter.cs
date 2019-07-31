// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
    sealed class TokenProviderAdapter : ICbsTokenProvider
    {
        readonly TokenCredential tokenProvider;
        readonly TimeSpan operationTimeout;

        public TokenProviderAdapter(TokenCredential tokenProvider, TimeSpan operationTimeout)
        {
            Debug.Assert(tokenProvider != null, "tokenProvider cannot be null");
            this.tokenProvider = tokenProvider;
            this.operationTimeout = operationTimeout;
        }

        public async Task<CbsToken> GetTokenAsync(Uri namespaceAddress, string appliesTo, string[] requiredClaims)
        {
            var claim = requiredClaims?.FirstOrDefault();
            var securityToken = await this.tokenProvider.GetTokenAsync(new [] { appliesTo }, CancellationToken.None).ConfigureAwait(false);
            return new CbsToken(securityToken.Token, CbsConstants.ServiceBusSasTokenType, securityToken.ExpiresOn.DateTime);
        }
    }
}
