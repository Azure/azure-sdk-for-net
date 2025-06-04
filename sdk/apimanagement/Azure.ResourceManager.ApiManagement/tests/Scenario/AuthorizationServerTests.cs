// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class AuthorizationServerTests : ApiManagementManagementTestBase
    {
        public AuthorizationServerTests(bool isAsync)
                    : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private ApiManagementServiceCollection ApiServiceCollection { get; set; }

        private ApiManagementServiceResource ApiServiceResource { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            ApiServiceCollection = ResourceGroup.GetApiManagementServices();
        }

        private async Task CreateApiServiceAsync()
        {
            await SetCollectionsAsync();
            var apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceData(AzureLocation.WestUS2, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.StandardV2, 1), "Sample@Sample.com", "sample");
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        [Test]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();
            var authCollection = ApiServiceResource.GetApiManagementAuthorizationServers();

            var listResponse = await authCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(listResponse);
            Assert.IsEmpty(listResponse);

            // create server
            string authsid = Recording.GenerateAssetName("authsid");
            var authorizationServerContract = new ApiManagementAuthorizationServerData()
            {
                DisplayName = Recording.GenerateAssetName("authName"),
                DefaultScope = Recording.GenerateAssetName("oauth2scope"),
                AuthorizationEndpoint = "https://contoso.com/auth",
                TokenEndpoint = "https://contoso.com/token",
                ClientRegistrationEndpoint = "https://contoso.com/clients/reg",
                GrantTypes = { GrantType.AuthorizationCode, GrantType.Implicit, GrantType.ResourceOwnerPassword },
                AuthorizationMethods = { AuthorizationMethod.Post, AuthorizationMethod.Get },
                BearerTokenSendingMethods = { BearerTokenSendingMethod.AuthorizationHeader, BearerTokenSendingMethod.Query },
                ClientId = Recording.GenerateAssetName("clientid"),
                Description = Recording.GenerateAssetName("authdescription"),
                ClientAuthenticationMethods = { ClientAuthenticationMethod.Basic },
                ClientSecret = Recording.GenerateAssetName("authclientsecret"),
                ResourceOwnerPassword = Recording.GenerateAssetName("authresourceownerpwd"),
                ResourceOwnerUsername = Recording.GenerateAssetName("authresourceownerusername"),
                DoesSupportState = true,
                TokenBodyParameters = { new TokenBodyParameterContract(Recording.GenerateAssetName("tokenname"), Recording.GenerateAssetName("tokenvalue")) }
            };
            var createResponse = (await authCollection.CreateOrUpdateAsync(WaitUntil.Completed, authsid, authorizationServerContract)).Value;
            Assert.NotNull(createResponse);

            // get to check is was created
            var getResponse = (await authCollection.GetAsync(authsid)).Value;
            Assert.NotNull(getResponse);
            Assert.AreEqual(authsid, getResponse.Data.Name);
            Assert.AreEqual(authorizationServerContract.DisplayName, getResponse.Data.DisplayName);
            Assert.AreEqual(authorizationServerContract.Description, getResponse.Data.Description);
            Assert.AreEqual(authorizationServerContract.DefaultScope, getResponse.Data.DefaultScope);
            Assert.AreEqual(authorizationServerContract.AuthorizationEndpoint, getResponse.Data.AuthorizationEndpoint);
            Assert.AreEqual(authorizationServerContract.TokenEndpoint, getResponse.Data.TokenEndpoint);
            Assert.AreEqual(authorizationServerContract.ClientRegistrationEndpoint, getResponse.Data.ClientRegistrationEndpoint);
            Assert.IsNull(getResponse.Data.ClientSecret);
            Assert.IsNull(getResponse.Data.ResourceOwnerPassword);
            Assert.IsNull(getResponse.Data.ResourceOwnerUsername);
            Assert.AreEqual(authorizationServerContract.GrantTypes.Count, getResponse.Data.GrantTypes.Count);
            Assert.IsTrue(getResponse.Data.GrantTypes.All(gt => authorizationServerContract.GrantTypes.Contains(gt)));
            Assert.AreEqual(authorizationServerContract.AuthorizationMethods.Count, getResponse.Data.AuthorizationMethods.Count);
            Assert.IsTrue(getResponse.Data.AuthorizationMethods.All(gt => authorizationServerContract.AuthorizationMethods.Contains(gt)));
            Assert.AreEqual(authorizationServerContract.ClientAuthenticationMethods.Count, getResponse.Data.ClientAuthenticationMethods.Count);
            Assert.IsTrue(getResponse.Data.ClientAuthenticationMethods.All(gt => authorizationServerContract.ClientAuthenticationMethods.Contains(gt)));
            Assert.AreEqual(authorizationServerContract.DoesSupportState, getResponse.Data.DoesSupportState);
            Assert.AreEqual(authorizationServerContract.TokenBodyParameters.Count, getResponse.Data.TokenBodyParameters.Count);
            Assert.IsTrue(getResponse.Data.TokenBodyParameters.All(p => authorizationServerContract.TokenBodyParameters.Any(p1 => p1.Name.Equals(p.Name, StringComparison.OrdinalIgnoreCase) && p1.Value.Equals(p.Value, StringComparison.OrdinalIgnoreCase))));

            var secretsResponse = (await getResponse.GetSecretsAsync()).Value;
            Assert.AreEqual(authorizationServerContract.ResourceOwnerUsername, secretsResponse.ResourceOwnerUsername);
            Assert.AreEqual(authorizationServerContract.ResourceOwnerPassword, secretsResponse.ResourceOwnerPassword);

            // list again
            listResponse = await authCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(listResponse);
            Assert.AreEqual(listResponse.Count, 1);
            Assert.IsNull(listResponse.First().Data.ClientSecret);

            // update
            var updateParameters = new ApiManagementAuthorizationServerPatch()
            {
                GrantTypes = { GrantType.AuthorizationCode, GrantType.ResourceOwnerPassword }
            };
            await getResponse.UpdateAsync(ETag.All, updateParameters);

            // get to check is was updated
            getResponse = await getResponse.GetAsync();
            Assert.AreEqual(authsid, getResponse.Data.Name);
            Assert.AreEqual(authorizationServerContract.DisplayName, getResponse.Data.DisplayName);
            Assert.AreEqual(authorizationServerContract.Description, getResponse.Data.Description);
            Assert.AreEqual(authorizationServerContract.DefaultScope, getResponse.Data.DefaultScope);
            Assert.AreEqual(authorizationServerContract.AuthorizationEndpoint, getResponse.Data.AuthorizationEndpoint);
            Assert.AreEqual(authorizationServerContract.TokenEndpoint, getResponse.Data.TokenEndpoint);
            Assert.AreEqual(authorizationServerContract.ClientRegistrationEndpoint, getResponse.Data.ClientRegistrationEndpoint);
            Assert.IsNull(getResponse.Data.ClientSecret);
            Assert.IsNull(getResponse.Data.ResourceOwnerPassword);
            Assert.IsNull(getResponse.Data.ResourceOwnerUsername);
            Assert.AreEqual(updateParameters.GrantTypes.Count, getResponse.Data.GrantTypes.Count);
            Assert.IsTrue(getResponse.Data.GrantTypes.All(gt => updateParameters.GrantTypes.Contains(gt)));
            Assert.AreEqual(authorizationServerContract.AuthorizationMethods.Count, getResponse.Data.AuthorizationMethods.Count);
            Assert.IsTrue(getResponse.Data.AuthorizationMethods.All(gt => authorizationServerContract.AuthorizationMethods.Contains(gt)));
            Assert.AreEqual(authorizationServerContract.ClientAuthenticationMethods.Count, getResponse.Data.ClientAuthenticationMethods.Count);
            Assert.IsTrue(getResponse.Data.ClientAuthenticationMethods.All(gt => authorizationServerContract.ClientAuthenticationMethods.Contains(gt)));
            Assert.AreEqual(authorizationServerContract.DoesSupportState, getResponse.Data.DoesSupportState);
            Assert.AreEqual(authorizationServerContract.TokenBodyParameters.Count, getResponse.Data.TokenBodyParameters.Count);
            Assert.IsTrue(getResponse.Data.TokenBodyParameters.All(p => authorizationServerContract.TokenBodyParameters.Any(p1 => p1.Name.Equals(p.Name, StringComparison.OrdinalIgnoreCase) && p1.Value.Equals(p.Value, StringComparison.OrdinalIgnoreCase))));

            // delete
            await getResponse.DeleteAsync(WaitUntil.Completed, ETag.All);
            var falseResult = (await authCollection.ExistsAsync(authsid)).Value;
            Assert.IsFalse(falseResult);
        }
    }
}
