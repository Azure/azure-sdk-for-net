// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.Containers.ContainerRegistry
{
    internal partial class AuthenticationClient : IContainerRegistryAuthenticationClient
    {
        public Response<AcrRefreshToken> ExchangeAadAccessTokenForAcrRefreshToken(PostContentSchemaGrantType grantType, string service, string tenant = null, string refreshToken = null, string accessToken = null, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<AcrRefreshToken>> ExchangeAadAccessTokenForAcrRefreshTokenAsync(PostContentSchemaGrantType grantType, string service, string tenant = null, string refreshToken = null, string accessToken = null, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Response<AcrAccessToken> ExchangeAcrRefreshTokenForAcrAccessToken(string service, string scope, string acrRefreshToken, TokenGrantType grantType = TokenGrantType.RefreshToken, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<AcrAccessToken>> ExchangeAcrRefreshTokenForAcrAccessTokenAsync(string service, string scope, string acrRefreshToken, TokenGrantType grantType = TokenGrantType.RefreshToken, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
