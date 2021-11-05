// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.Containers.ContainerRegistry.Tests
{
    internal class MockAuthenticationClient : IContainerRegistryAuthenticationClient
    {
        private readonly Func<string, AcrRefreshToken> _acrRefreshTokenFunc;
        private readonly Func<string, string, AcrAccessToken> _acrAccessTokenFunc;

        public MockAuthenticationClient(Func<string, AcrRefreshToken> acrRefreshTokenFunc, Func<string, string, AcrAccessToken> acrAccessTokenFunc)
        {
            _acrRefreshTokenFunc = acrRefreshTokenFunc;
            _acrAccessTokenFunc = acrAccessTokenFunc;
        }

        public Response<AcrRefreshToken> ExchangeAadAccessTokenForAcrRefreshToken(string service, string aadAccessToken, CancellationToken token = default)
        {
            return Response.FromValue(_acrRefreshTokenFunc(service), new MockResponse(200));
        }

        public Task<Response<AcrRefreshToken>> ExchangeAadAccessTokenForAcrRefreshTokenAsync(string service, string aadAccessToken, CancellationToken token = default)
        {
            return Task.FromResult(Response.FromValue(_acrRefreshTokenFunc(service), new MockResponse(200)));
        }

        public Response<AcrAccessToken> ExchangeAcrRefreshTokenForAcrAccessToken(string service, string scope, string acrRefreshToken, TokenGrantType grantType = TokenGrantType.RefreshToken, CancellationToken token = default)
        {
            return Response.FromValue(_acrAccessTokenFunc(service, scope), new MockResponse(200));
        }

        public Task<Response<AcrAccessToken>> ExchangeAcrRefreshTokenForAcrAccessTokenAsync(string service, string scope, string acrRefreshToken, TokenGrantType grantType = TokenGrantType.RefreshToken, CancellationToken token = default)
        {
            return Task.FromResult(Response.FromValue(_acrAccessTokenFunc(service, scope), new MockResponse(200)));
        }
    }
}
