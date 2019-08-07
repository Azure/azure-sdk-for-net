using System;
using System.Collections.Generic;
namespace ContainerRegistry.Tests
{
    using Microsoft.Azure.ContainerRegistry;
    using Microsoft.Azure.ContainerRegistry.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;
    using System.IdentityModel.Tokens.Jwt;
    using Microsoft.IdentityModel.Tokens;
    using Xunit.Sdk;
    using System.Reflection;

    public class AuthTests
    {
        [Fact]
        public async Task GetAcrRefreshTokenFromExchange()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetAcrRefreshTokenFromExchange)))
            {
                AzureContainerRegistryClient client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var refreshToken = await client.GetAcrRefreshTokenFromExchangeAsync("access_token", ACRTestUtil.ManagedTestRegistryFullName, null, null, await ACRTestUtil.getAADaccessToken());
                validateRefreshToken(refreshToken.RefreshTokenProperty);
            }
        }

        [Fact]
        public async Task GetAcrAccessToken()
        {
            try
            {
                using (var context = MockContext.Start(GetType().FullName, nameof(GetAcrAccessToken)))
                {
                    AzureContainerRegistryClient client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                    var refreshToken = await client.GetAcrRefreshTokenFromExchangeAsync("access_token", ACRTestUtil.ManagedTestRegistryFullName, null, null, await ACRTestUtil.getAADaccessToken());
                    var accessToken = await client.GetAcrAccessTokenAsync(ACRTestUtil.ManagedTestRegistryFullName, ACRTestUtil.Scope, refreshToken.RefreshTokenProperty);
                    validateAccessToken(accessToken.AccessTokenProperty);
                }
            }
            catch (Exception e) {
                Console.WriteLine(e);
                    
            }
            
        }

        [Fact]
        public async Task GetAcrAccessTokenFromLogin()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetAcrAccessToken)))
            {
                AzureContainerRegistryClient client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var accessToken = await client.GetAcrAccessTokenFromLoginAsync(ACRTestUtil.ManagedTestRegistryFullName, ACRTestUtil.Scope);
                validateAccessToken(accessToken.AccessTokenProperty);
            }
        }

        private void validateAccessToken(string accessToken) {
            JwtSecurityTokenHandler JwtSecurityClient = new JwtSecurityTokenHandler();
            JwtSecurityToken fields = JwtSecurityClient.ReadToken(accessToken) as JwtSecurityToken;
            commonTokenValidation(fields);

            //Assert.True((fields.ValidTo - fields.ValidFrom).TotalSeconds == 3600); // 1hr
            Assert.Equal("access_token", fields.Payload["grant_type"]);
        }

        private void validateRefreshToken(string refreshToken)
        {
            JwtSecurityTokenHandler JwtSecurityClient = new JwtSecurityTokenHandler();
            JwtSecurityToken fields = JwtSecurityClient.ReadToken(refreshToken) as JwtSecurityToken;
            commonTokenValidation(fields);

            Assert.Equal("refresh_token", fields.Payload["grant_type"]);
            //Assert.True((fields.ValidTo - fields.ValidFrom).TotalSeconds == 10800); // 1hr
        }

        private void commonTokenValidation(JwtSecurityToken fields) {
            Assert.Equal("azuresdkunittest.azurecr.io", fields.Audiences.ToList<string>()[0]);
            Assert.Equal("Azure Container Registry", fields.Issuer);
            Assert.Equal("RS256", fields.Header.Alg);
            Assert.Equal("JWT", fields.Header.Typ);

            //Custom
            Assert.Equal("1.0", fields.Payload["version"]);
        }
    }
}
