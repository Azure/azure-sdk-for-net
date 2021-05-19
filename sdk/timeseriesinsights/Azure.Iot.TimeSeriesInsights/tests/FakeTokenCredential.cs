// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Iot.TimeSeriesInsights.Tests
{
    /// <summary>
    /// This class is used for providing incorrect credentials to the service when making requests.
    /// </summary>
    public class FakeTokenCredential : TokenCredential
    {
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new AccessToken("someFakeAccessToken", DateTimeOffset.MaxValue);
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new ValueTask<AccessToken>(new AccessToken("someFakeAccessToken", DateTimeOffset.MaxValue));
        }
    }
}
