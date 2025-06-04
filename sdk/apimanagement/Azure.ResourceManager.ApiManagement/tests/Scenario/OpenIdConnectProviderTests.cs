// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class OpenIdConnectProviderTests : ApiManagementManagementTestBase
    {
        public OpenIdConnectProviderTests(bool isAsync)
                    : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private ApiManagementServiceResource ApiServiceResource { get; set; }

        private ApiManagementServiceCollection ApiServiceCollection { get; set; }

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

        public string GetOpenIdMetadataEndpointUrl()
        {
            return "https://" + Recording.GenerateAssetName("provider") + "." + Recording.GenerateAssetName("endpoint");
        }

        [Test]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();
            var collection = ApiServiceResource.GetApiManagementOpenIdConnectProviders();

            string openIdNoSecret = Recording.GenerateAssetName("openId");
            string openId2 = Recording.GenerateAssetName("openId");
            string openIdProviderName = Recording.GenerateAssetName("openIdName");
            string metadataEndpoint = GetOpenIdMetadataEndpointUrl();
            string clientId = Recording.GenerateAssetName("clientId");
            var openIdConnectCreateParameters = new ApiManagementOpenIdConnectProviderData()
            {
                DisplayName = openIdProviderName,
                MetadataEndpoint = metadataEndpoint,
                ClientId = clientId
            };

            var createResponse = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, openIdNoSecret,openIdConnectCreateParameters)).Value;

            Assert.NotNull(createResponse);
            Assert.AreEqual(openIdProviderName, createResponse.Data.DisplayName);
            Assert.AreEqual(openIdNoSecret, createResponse.Data.Name);

            // get to check it was created
            var openIdConnectProviderContract = (await collection.GetAsync(openIdNoSecret)).Value;

            Assert.NotNull(openIdConnectProviderContract);
            Assert.AreEqual(openIdProviderName, openIdConnectProviderContract.Data.DisplayName);
            Assert.AreEqual(metadataEndpoint, openIdConnectProviderContract.Data.MetadataEndpoint);
            Assert.AreEqual(openIdNoSecret, openIdConnectProviderContract.Data.Name);
            Assert.IsNull(openIdConnectProviderContract.Data.ClientSecret);
            Assert.IsNull(openIdConnectProviderContract.Data.Description);

            // create a Secret property
            string openIdProviderName2 = Recording.GenerateAssetName("openIdName");
            string metadataEndpoint2 = GetOpenIdMetadataEndpointUrl();
            string clientId2 = Recording.GenerateAssetName("clientId");
            string clientSecret = Recording.GenerateAssetName("clientSecret");
            var openIdConnectCreateParameters2 = new ApiManagementOpenIdConnectProviderData()
            {
                DisplayName = openIdProviderName2,
                MetadataEndpoint = metadataEndpoint2,
                ClientId = clientId2,
            };
            openIdConnectCreateParameters2.ClientSecret = clientSecret;
            openIdConnectCreateParameters2.Description = Recording.GenerateAssetName("description");

            var createResponse2 = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, openId2, openIdConnectCreateParameters2)).Value;

            Assert.NotNull(createResponse2);
            Assert.AreEqual(openIdProviderName2, createResponse2.Data.DisplayName);
            Assert.AreEqual(openId2, createResponse2.Data.Name);

            // get to check it was created
            var getResponse2 = (await collection.GetAsync(openId2)).Value;

            Assert.NotNull(getResponse2);
            Assert.AreEqual(openIdProviderName2, getResponse2.Data.DisplayName);
            Assert.AreEqual(metadataEndpoint2, getResponse2.Data.MetadataEndpoint);
            Assert.IsNull(getResponse2.Data.ClientSecret);
            Assert.NotNull(getResponse2.Data.Description);
            Assert.AreEqual(openId2, getResponse2.Data.Name);

            var secretResponse = (await getResponse2.GetSecretsAsync()).Value;

            // list the openId Connect Providers
            var listResponse = await collection.GetAllAsync().ToEnumerableAsync();

            Assert.NotNull(listResponse);

            // there should be atleast 2 openId connect Providers.
            Assert.GreaterOrEqual(listResponse.Count, 2);

            // delete a OpenId Connect Provider
            await openIdConnectProviderContract.DeleteAsync(WaitUntil.Completed, ETag.All);

            // get the deleted openId Connect Provider to make sure it was deleted
            var falseResult = (await collection.ExistsAsync(openIdNoSecret)).Value;
            Assert.IsFalse(falseResult);

            // patch the openId Connect Provider
            string updateMetadataEndpoint = GetOpenIdMetadataEndpointUrl();
            string updatedClientId = Recording.GenerateAssetName("updatedClient");
            await getResponse2.UpdateAsync(ETag.All,
                new ApiManagementOpenIdConnectProviderPatch
                {
                    MetadataEndpoint = updateMetadataEndpoint,
                    ClientId = updatedClientId
                });

            // get to check it was patched
            var getResponseOpendId2 = (await getResponse2.GetAsync()).Value;

            Assert.NotNull(getResponseOpendId2);
            Assert.AreEqual(openId2, getResponseOpendId2.Data.Name);
            Assert.AreEqual(updateMetadataEndpoint, getResponseOpendId2.Data.MetadataEndpoint);
            Assert.IsNull(getResponseOpendId2.Data.ClientSecret);
            Assert.NotNull(getResponseOpendId2.Data.Description);

            var secretsResponse = (await getResponseOpendId2.GetSecretsAsync()).Value;

            // delete the openId Connect Provider
            await getResponseOpendId2.DeleteAsync(WaitUntil.Completed, ETag.All);
            falseResult = (await collection.ExistsAsync(openId2)).Value;
            Assert.IsFalse(falseResult);
        }
    }
}
