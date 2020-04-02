// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Identity.Tests.Mock
{
    internal class MockTokenCredential : TokenCredential
    {
        public Func<TokenRequestContext, CancellationToken, AccessToken> TokenFactory { get; set; }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            if (TokenFactory != null)
            {
                return TokenFactory(requestContext, cancellationToken);
            }
            else
            {
                return new AccessToken("mockToken", DateTimeOffset.UtcNow.AddMinutes(10));
            }
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new ValueTask<AccessToken>(GetToken(requestContext, cancellationToken));
        }
    }
}
