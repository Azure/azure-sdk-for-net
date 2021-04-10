// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.Containers.ContainerRegistry.Tests
{
    internal class MockAuthenticationClient : IContainerRegistryAuthenticationClient
    {
        public Response<AcrRefreshToken> ExchangeAadAccessTokenForAcrRefreshToken(string service, string aadAccessToken, CancellationToken token = default)
        {
            AcrRefreshToken refreshToken = new AcrRefreshToken("TestAcrRefreshToken");
            return Response.FromValue(refreshToken, new MockResponse(200));
        }

        public Task<Response<AcrRefreshToken>> ExchangeAadAccessTokenForAcrRefreshTokenAsync(string service, string aadAccessToken, CancellationToken token = default)
        {
            AcrRefreshToken refreshToken = new AcrRefreshToken("TestAcrRefreshToken");
            return Task.FromResult(Response.FromValue(refreshToken, new MockResponse(200)));
        }

        public Response<AcrAccessToken> ExchangeAcrRefreshTokenForAcrAccessToken(string service, string scope, string acrRefreshToken, CancellationToken token = default)
        {
            AcrAccessToken accessToken = new AcrAccessToken("TestAcrAccessToken");
            return Response.FromValue(accessToken, new MockResponse(200));
        }

        public Task<Response<AcrAccessToken>> ExchangeAcrRefreshTokenForAcrAccessTokenAsync(string service, string scope, string acrRefreshToken, CancellationToken token = default)
        {
            AcrAccessToken accessToken = new AcrAccessToken("TestAcrAccessToken");
            return Task.FromResult(Response.FromValue(accessToken, new MockResponse(200)));
        }
    }
}
