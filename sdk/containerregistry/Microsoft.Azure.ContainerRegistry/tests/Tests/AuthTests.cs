using System;
using System.Collections.Generic;
namespace ContainerRegistry.Tests
{
    using Microsoft.Azure.ContainerRegistry;
    using Microsoft.Azure.ContainerRegistry.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System.Linq;
    using System.Reflection.Metadata.Ecma335;
    using System.Threading.Tasks;
    using Xunit;

    public class AuthTests
    {
        [Fact]
        public async Task GetAcrRefreshTokenFromExchange()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetAcrRefreshTokenFromExchange)))
            {
                AzureContainerRegistryClient client = await ACRTestUtil.GetCredentialLessClient(context, ACRTestUtil.ManagedTestRegistry);
                var refreshToken = await client.GetAcrRefreshTokenFromExchangeAsync("access_token", ACRTestUtil.ManagedTestRegistryFullName, null, ACRTestUtil.AadAccessToken);
            }
        }

        [Fact]
        public async Task GetAcrAccessToken()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetAcrAccessToken)))
            {
                AzureContainerRegistryClient client = await ACRTestUtil.GetCredentialLessClient(context, ACRTestUtil.ManagedTestRegistry);
                var accessToken = await client.GetAcrAccessTokenAsync(ACRTestUtil.ManagedTestRegistryFullName, ACRTestUtil.Scope, ACRTestUtil.RefreshToken);
            }
        }

        [Fact]
        public async Task GetAcrAccessTokenFromLogin()
        {
            AzureContainerRegistryClient client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
            var accessToken = await client.GetAcrAccessTokenFromLoginAsync(ACRTestUtil.ManagedTestRegistryFullName, ACRTestUtil.Scope);
        }
    }
}
