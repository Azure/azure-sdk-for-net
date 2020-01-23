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
    internal class MockExtendedTokenCredential : IExtendedTokenCredential
    {
        public Func<TokenRequestContext, CancellationToken, ExtendedAccessToken> TokenFactory { get; set; }

        ExtendedAccessToken IExtendedTokenCredential.GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            if (TokenFactory != null)
            {
                return TokenFactory(requestContext, cancellationToken);
            }
            else
            {
                return new ExtendedAccessToken(new AccessToken("mockToken", DateTimeOffset.UtcNow.AddMinutes(10)));
            }
        }

        ValueTask<ExtendedAccessToken> IExtendedTokenCredential.GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new ValueTask<ExtendedAccessToken>(((IExtendedTokenCredential)this).GetToken(requestContext, cancellationToken));
        }
    }
}
