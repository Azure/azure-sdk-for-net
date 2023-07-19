namespace ContainerRegistry.Tests
{
    using Microsoft.Azure.ContainerRegistry;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class AuthTests
    {
        [Fact]
        public async Task GetAcrRefreshTokenFromExchange()
        {
            using (var context = MockContext.Start(GetType(), nameof(GetAcrRefreshTokenFromExchange)))
            {
                AzureContainerRegistryClient client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var refreshToken = await client.RefreshTokens.GetFromExchangeAsync("access_token", ACRTestUtil.ManagedTestRegistryFullName, null, null, await ACRTestUtil.GetAADAccessToken());
                ValidateRefreshToken(refreshToken.RefreshTokenProperty);
            }
        }

        [Fact]
        public async Task GetAcrAccessToken()
        {
            using (var context = MockContext.Start(GetType(), nameof(GetAcrAccessToken)))
            {
                AzureContainerRegistryClient client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var refreshToken = await client.RefreshTokens.GetFromExchangeAsync("access_token", ACRTestUtil.ManagedTestRegistryFullName, null, null, await ACRTestUtil.GetAADAccessToken());
                var accessToken = await client.AccessTokens.GetAsync(ACRTestUtil.ManagedTestRegistryFullName, ACRTestUtil.Scope, refreshToken.RefreshTokenProperty);
                ValidateAccessToken(accessToken.AccessTokenProperty);
            }
        }

        [Fact]
        public async Task GetAcrAccessTokenFromLogin()
        {
            using (var context = MockContext.Start(GetType(), nameof(GetAcrAccessTokenFromLogin)))
            {
                AzureContainerRegistryClient client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var accessToken = await client.AccessTokens.GetFromLoginAsync(ACRTestUtil.ManagedTestRegistryFullName, ACRTestUtil.Scope);
                ValidateAccessToken(accessToken.AccessTokenProperty);
            }
        }

        #region Validation Helpers

        private void ValidateAccessToken(string accessToken)
        {
            JwtSecurityTokenHandler JwtSecurityClient = new JwtSecurityTokenHandler();
            JwtSecurityToken fields = JwtSecurityClient.ReadToken(accessToken) as JwtSecurityToken;
            CommonTokenValidation(fields);
            Assert.Equal("access_token", fields.Payload["grant_type"]);
        }

        private void ValidateRefreshToken(string refreshToken)
        {
            JwtSecurityTokenHandler JwtSecurityClient = new JwtSecurityTokenHandler();
            JwtSecurityToken fields = JwtSecurityClient.ReadToken(refreshToken) as JwtSecurityToken;
            CommonTokenValidation(fields);
            Assert.Equal("refresh_token", fields.Payload["grant_type"]);
        }

        private void CommonTokenValidation(JwtSecurityToken fields)
        {
            Assert.Equal(ACRTestUtil.ManagedTestRegistryFullName, fields.Audiences.ToList<string>()[0]);
            Assert.Equal(ACRTestUtil.ACRJWTIssuer, fields.Issuer);
            Assert.Equal("RS256", fields.Header.Alg);
            Assert.Equal("JWT", fields.Header.Typ);

            //Custom
            Assert.Equal("1.0", fields.Payload["version"]);
        }
        #endregion
    }
}
