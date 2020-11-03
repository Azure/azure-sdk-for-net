// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Tests
{
    public class TokenCredentialStub : TokenCredential
    {
        public TokenCredentialStub(Func<TokenRequestContext, CancellationToken, AccessToken> handler, bool isAsync)
        {
            if (isAsync)
            {
#pragma warning disable 1998
                _getTokenAsyncHandler = async (r, c) => handler(r, c);
#pragma warning restore 1998
            }
            else
            {
                _getTokenHandler = handler;
            }
        }

        private readonly Func<TokenRequestContext, CancellationToken, ValueTask<AccessToken>> _getTokenAsyncHandler;
        private readonly Func<TokenRequestContext, CancellationToken, AccessToken> _getTokenHandler;

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => _getTokenAsyncHandler(requestContext, cancellationToken);

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => _getTokenHandler(requestContext, cancellationToken);
    }
}
