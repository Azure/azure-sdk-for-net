// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.TestFramework
{
    public class MockCredential : TokenCredential
    {
        public Action<TokenRequestContext, CancellationToken> GetTokenCallback { get; set; }
        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new(GetToken(requestContext, cancellationToken));
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            if (GetTokenCallback != null)
            {
                GetTokenCallback(requestContext, cancellationToken);
            }
            return new AccessToken("TEST TOKEN " + string.Join(" ", requestContext.Scopes), DateTimeOffset.MaxValue);
        }
    }
}
