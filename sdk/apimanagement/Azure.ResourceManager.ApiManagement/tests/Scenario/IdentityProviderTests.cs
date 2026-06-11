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
    public class IdentityProviderTests : ApiManagementManagementTestBase
    {
        public IdentityProviderTests(bool isAsync)
                    : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private ApiManagementServiceResource ApiServiceResource { get; set; }

        private ApiManagementServiceResourceCollection ApiServiceCollection { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            ApiServiceCollection = ResourceGroup.GetApiManagementServiceResources();
        }

        private async Task CreateApiServiceAsync()
        {
            await SetCollectionsAsync();
            var apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceResourceData(AzureLocation.WestUS2, "Sample@Sample.com", "sample", new ApiManagementServiceSkuProperties(SkuType.Standard, 1));
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        [Test]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();
            var collection = ApiServiceResource.GetApiManagementIdentityProviders();

            // create facebook external identity provider
            string clientId = Recording.GenerateAssetName("clientId");
            string clientSecret = Recording.GenerateAssetName("clientSecret");

            var identityProviderCreateParameters = new IdentityProviderCreateContract();

            var identityProviderContract = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, IdentityProviderType.Facebook, identityProviderCreateParameters)).Value;
            Assert.NotNull(identityProviderContract);
            Assert.AreEqual(IdentityProviderType.Facebook, identityProviderContract.Data.Type);

            // list
            var listIdentityProviders = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(listIdentityProviders.Count, 1);

            // patch identity provider
            string patchedSecret = Recording.GenerateAssetName("clientSecret");
            var patch = new ApiManagementIdentityProviderPatch
            {
                ClientSecret = patchedSecret
            };
            await identityProviderContract.UpdateAsync(ETag.All.ToString(), patch);

            // get to check it was patched
            identityProviderContract = await collection.GetAsync(IdentityProviderType.Facebook);
            Assert.AreEqual(IdentityProviderType.Facebook, identityProviderContract.Data.Type);
            Assert.IsNull(identityProviderContract.Data.ClientSecret);

            var secret = (await identityProviderContract.GetSecretsAsync()).Value;

            // delete the identity provider
            await identityProviderContract.DeleteAsync(WaitUntil.Completed, ETag.All.ToString());
            var resultFalse = (await collection.ExistsAsync(IdentityProviderType.Facebook)).Value;
            Assert.IsFalse(resultFalse);
        }
    }
}
