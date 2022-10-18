// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry
{
    internal partial class AuthenticationClient : IContainerRegistryAuthenticationClient
    {
        public Response<AcrRefreshToken> ExchangeAadAccessTokenForAcrRefreshToken(PostContentSchemaGrantType grantType, string service, string tenant = null, string refreshToken = null, string accessToken = null, CancellationToken cancellationToken = default)
        {
            var content = new FormUrlEncodedContent();
            content.Add("grant_type", grantType.ToString());
            content.Add("service", service);
            if (tenant != null)
            {
                content.Add("tenant", tenant);
            }
            if (refreshToken != null)
            {
                content.Add("refresh_token", refreshToken);
            }
            if (accessToken != null)
            {
                content.Add("access_token", accessToken);
            }

            Response response = ExchangeAadAccessTokenForAcrRefreshToken(content, FromCancellationToken(cancellationToken));
            JsonDocument json = JsonDocument.Parse(response.Content);
            return Response.FromValue(AcrRefreshToken.DeserializeAcrRefreshToken(json.RootElement), response);
        }

        public async Task<Response<AcrRefreshToken>> ExchangeAadAccessTokenForAcrRefreshTokenAsync(PostContentSchemaGrantType grantType, string service, string tenant = null, string refreshToken = null, string accessToken = null, CancellationToken cancellationToken = default)
        {
            var content = new FormUrlEncodedContent();
            content.Add("grant_type", grantType.ToString());
            content.Add("service", service);
            if (tenant != null)
            {
                content.Add("tenant", tenant);
            }
            if (refreshToken != null)
            {
                content.Add("refresh_token", refreshToken);
            }
            if (accessToken != null)
            {
                content.Add("access_token", accessToken);
            }

            Response response = await ExchangeAadAccessTokenForAcrRefreshTokenAsync(content, FromCancellationToken(cancellationToken)).ConfigureAwait(false);
            JsonDocument json = JsonDocument.Parse(response.Content);
            return Response.FromValue(AcrRefreshToken.DeserializeAcrRefreshToken(json.RootElement), response);
        }

        public Response<AcrAccessToken> ExchangeAcrRefreshTokenForAcrAccessToken(string service, string scope, string acrRefreshToken, TokenGrantType grantType = TokenGrantType.RefreshToken, CancellationToken cancellationToken = default)
        {
            var content = new FormUrlEncodedContent();
            content.Add("service", service);
            content.Add("scope", scope);
            content.Add("refresh_token", acrRefreshToken);
            content.Add("grant_type", grantType.ToSerialString());

            Response response = ExchangeAcrRefreshTokenForAcrAccessToken(content, FromCancellationToken(cancellationToken));
            JsonDocument json = JsonDocument.Parse(response.Content);
            return Response.FromValue(AcrAccessToken.DeserializeAcrAccessToken(json.RootElement), response);
        }

        public async Task<Response<AcrAccessToken>> ExchangeAcrRefreshTokenForAcrAccessTokenAsync(string service, string scope, string acrRefreshToken, TokenGrantType grantType = TokenGrantType.RefreshToken, CancellationToken cancellationToken = default)
        {
            var content = new FormUrlEncodedContent();
            content.Add("service", service);
            content.Add("scope", scope);
            content.Add("refresh_token", acrRefreshToken);
            content.Add("grant_type", grantType.ToSerialString());

            Response response = await ExchangeAcrRefreshTokenForAcrAccessTokenAsync(content, FromCancellationToken(cancellationToken)).ConfigureAwait(false);
            JsonDocument json = JsonDocument.Parse(response.Content);
            return Response.FromValue(AcrAccessToken.DeserializeAcrAccessToken(json.RootElement), response);
        }

        private static RequestContext DefaultRequestContext = new RequestContext();

        internal static RequestContext FromCancellationToken(CancellationToken cancellationToken)
        {
            if (cancellationToken == CancellationToken.None)
            {
                return DefaultRequestContext;
            }

            return new RequestContext() { CancellationToken = cancellationToken };
        }
    }
}
