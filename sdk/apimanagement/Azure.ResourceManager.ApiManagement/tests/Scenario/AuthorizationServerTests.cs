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
            Assert.That(listResponse, Is.Not.Null);
            Assert.That(listResponse, Is.Empty);

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
            Assert.That(createResponse, Is.Not.Null);

            // get to check is was created
            var getResponse = (await authCollection.GetAsync(authsid)).Value;
            Assert.That(getResponse, Is.Not.Null);
            Assert.That(getResponse.Data.Name, Is.EqualTo(authsid));
            Assert.That(getResponse.Data.DisplayName, Is.EqualTo(authorizationServerContract.DisplayName));
            Assert.That(getResponse.Data.Description, Is.EqualTo(authorizationServerContract.Description));
            Assert.That(getResponse.Data.DefaultScope, Is.EqualTo(authorizationServerContract.DefaultScope));
            Assert.That(getResponse.Data.AuthorizationEndpoint, Is.EqualTo(authorizationServerContract.AuthorizationEndpoint));
            Assert.That(getResponse.Data.TokenEndpoint, Is.EqualTo(authorizationServerContract.TokenEndpoint));
            Assert.That(getResponse.Data.ClientRegistrationEndpoint, Is.EqualTo(authorizationServerContract.ClientRegistrationEndpoint));
            Assert.That(getResponse.Data.ClientSecret, Is.Null);
            Assert.That(getResponse.Data.ResourceOwnerPassword, Is.Null);
            Assert.That(getResponse.Data.ResourceOwnerUsername, Is.Null);
            Assert.That(getResponse.Data.GrantTypes.Count, Is.EqualTo(authorizationServerContract.GrantTypes.Count));
            Assert.That(getResponse.Data.GrantTypes.All(gt => authorizationServerContract.GrantTypes.Contains(gt)), Is.True);
            Assert.That(getResponse.Data.AuthorizationMethods.Count, Is.EqualTo(authorizationServerContract.AuthorizationMethods.Count));
            Assert.That(getResponse.Data.AuthorizationMethods.All(gt => authorizationServerContract.AuthorizationMethods.Contains(gt)), Is.True);
            Assert.That(getResponse.Data.ClientAuthenticationMethods.Count, Is.EqualTo(authorizationServerContract.ClientAuthenticationMethods.Count));
            Assert.That(getResponse.Data.ClientAuthenticationMethods.All(gt => authorizationServerContract.ClientAuthenticationMethods.Contains(gt)), Is.True);
            Assert.That(getResponse.Data.DoesSupportState, Is.EqualTo(authorizationServerContract.DoesSupportState));
            Assert.That(getResponse.Data.TokenBodyParameters.Count, Is.EqualTo(authorizationServerContract.TokenBodyParameters.Count));
            Assert.That(getResponse.Data.TokenBodyParameters.All(p => authorizationServerContract.TokenBodyParameters.Any(p1 => p1.Name.Equals(p.Name, StringComparison.OrdinalIgnoreCase) && p1.Value.Equals(p.Value, StringComparison.OrdinalIgnoreCase))), Is.True);

            var secretsResponse = (await getResponse.GetSecretsAsync()).Value;
            Assert.That(secretsResponse.ResourceOwnerUsername, Is.EqualTo(authorizationServerContract.ResourceOwnerUsername));
            Assert.That(secretsResponse.ResourceOwnerPassword, Is.EqualTo(authorizationServerContract.ResourceOwnerPassword));

            // list again
            listResponse = await authCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listResponse, Is.Not.Null);
            Assert.That(listResponse.Count, Is.EqualTo(1));
            Assert.That(listResponse.First().Data.ClientSecret, Is.Null);

            // update
            var updateParameters = new ApiManagementAuthorizationServerPatch()
            {
                GrantTypes = { GrantType.AuthorizationCode, GrantType.ResourceOwnerPassword }
            };
            await getResponse.UpdateAsync(ETag.All, updateParameters);

            // get to check is was updated
            getResponse = await getResponse.GetAsync();
            Assert.That(getResponse.Data.Name, Is.EqualTo(authsid));
            Assert.That(getResponse.Data.DisplayName, Is.EqualTo(authorizationServerContract.DisplayName));
            Assert.That(getResponse.Data.Description, Is.EqualTo(authorizationServerContract.Description));
            Assert.That(getResponse.Data.DefaultScope, Is.EqualTo(authorizationServerContract.DefaultScope));
            Assert.That(getResponse.Data.AuthorizationEndpoint, Is.EqualTo(authorizationServerContract.AuthorizationEndpoint));
            Assert.That(getResponse.Data.TokenEndpoint, Is.EqualTo(authorizationServerContract.TokenEndpoint));
            Assert.That(getResponse.Data.ClientRegistrationEndpoint, Is.EqualTo(authorizationServerContract.ClientRegistrationEndpoint));
            Assert.That(getResponse.Data.ClientSecret, Is.Null);
            Assert.That(getResponse.Data.ResourceOwnerPassword, Is.Null);
            Assert.That(getResponse.Data.ResourceOwnerUsername, Is.Null);
            Assert.That(getResponse.Data.GrantTypes.Count, Is.EqualTo(updateParameters.GrantTypes.Count));
            Assert.That(getResponse.Data.GrantTypes.All(gt => updateParameters.GrantTypes.Contains(gt)), Is.True);
            Assert.That(getResponse.Data.AuthorizationMethods.Count, Is.EqualTo(authorizationServerContract.AuthorizationMethods.Count));
            Assert.That(getResponse.Data.AuthorizationMethods.All(gt => authorizationServerContract.AuthorizationMethods.Contains(gt)), Is.True);
            Assert.That(getResponse.Data.ClientAuthenticationMethods.Count, Is.EqualTo(authorizationServerContract.ClientAuthenticationMethods.Count));
            Assert.That(getResponse.Data.ClientAuthenticationMethods.All(gt => authorizationServerContract.ClientAuthenticationMethods.Contains(gt)), Is.True);
            Assert.That(getResponse.Data.DoesSupportState, Is.EqualTo(authorizationServerContract.DoesSupportState));
            Assert.That(getResponse.Data.TokenBodyParameters.Count, Is.EqualTo(authorizationServerContract.TokenBodyParameters.Count));
            Assert.That(getResponse.Data.TokenBodyParameters.All(p => authorizationServerContract.TokenBodyParameters.Any(p1 => p1.Name.Equals(p.Name, StringComparison.OrdinalIgnoreCase) && p1.Value.Equals(p.Value, StringComparison.OrdinalIgnoreCase))), Is.True);

            // delete
            await getResponse.DeleteAsync(WaitUntil.Completed, ETag.All);
            var falseResult = (await authCollection.ExistsAsync(authsid)).Value;
            Assert.That(falseResult, Is.False);
        }
    }
}
