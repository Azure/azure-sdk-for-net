// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.AI.Agents.Persistent.Tests
{
    internal class MockTokenCredential : TokenCredential
    {
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return await Task.Run(() => new AccessToken(accessToken: "Mock Token", expiresOn: DateTimeOffset.MaxValue));
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new AccessToken(accessToken: "Mock Token", expiresOn: DateTimeOffset.MaxValue);
        }
    }
}
