// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class PropertiesTests : ApiManagementManagementTestBase
    {
        public PropertiesTests(bool isAsync)
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
            var data = new ApiManagementServiceResourceData(AzureLocation.WestUS2, "Sample@Sample.com", "sample", new ApiManagementServiceSkuProperties(SkuType.StandardV2, 1))
            {
                Identity = new ApiManagementServiceIdentity(ApimIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        [Test]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();
            var collection = ApiServiceResource.GetNamedValues();

            string propertyId = Recording.GenerateAssetName("newproperty");
            string secretPropertyId = Recording.GenerateAssetName("secretproperty");
            string kvPropertyId = Recording.GenerateAssetName("kvproperty");

            string propertyDisplayName = Recording.GenerateAssetName("propertydisplay");
            string propertyValue = Recording.GenerateAssetName("propertyValue");
            var createParameters = new NamedValueCreateContract()
            {
                Value = propertyValue
            };

            // create a property
            var propertyResponse = (await collection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                propertyId,
                createParameters)).Value;

            ValidateProperty(propertyResponse, propertyId, propertyDisplayName, propertyValue, false);

            // get the property
            var getResponse = (await collection.GetAsync(propertyId)).Value;

            ValidateProperty(propertyResponse, propertyId, propertyDisplayName, propertyValue, false);

            // create secret property
            string secretPropertyDisplayName = Recording.GenerateAssetName("secretPropertydisplay");
            string secretPropertyValue = Recording.GenerateAssetName("secretPropertyValue");
            List<string> tags = new List<string> { "secret" };
            var secretCreateParameters = new NamedValueCreateContract()
            {
                Value = secretPropertyValue,
                Secret = true,
                Tags = { "secret" }
            };

            var secretPropertyResponse = (await collection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                secretPropertyId,
                secretCreateParameters)).Value;

            ValidateProperty(secretPropertyResponse, secretPropertyId, secretPropertyDisplayName, secretPropertyValue, true);

            var secretValueResponse = (await collection.GetAsync(secretPropertyId)).Value;

            //create key vault namedvalue
            // Need to assign identity access
            //string kvPropertyDisplayName = Recording.GenerateAssetName("kvPropertydisplay");
            //var kvCreateParameters = new NamedValueCreateContract()
            //{
            //    DisplayName = kvPropertyDisplayName,
            //    KeyVault = new KeyVaultContractCreateProperties
            //    {
            //        SecretIdentifier = Recording.GenerateAssetName("key")
            //    },
            //    Secret = true
            //};

            //var kvPropertyResponse = (await collection.CreateOrUpdateAsync(
            //    WaitUntil.Completed,
            //    kvPropertyId,
            //    kvCreateParameters)).Value;

            //ValidateProperty(kvPropertyResponse, kvPropertyId, kvPropertyDisplayName, string.Empty, true);

            //refresh secret of key vault namedvalue
            //var refreshKvPropertyResponse = (await kvPropertyResponse.RefreshSecretAsync(WaitUntil.Completed)).Value;

            //Assert.NotNull(refreshKvPropertyResponse);
            //Assert.AreEqual("Success", refreshKvPropertyResponse.KeyVault.LastStatus.Code);

            // list the properties
            var listResponse = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(listResponse);

            Assert.AreEqual(2, listResponse.Count);

            // delete a property
            await getResponse.DeleteAsync(WaitUntil.Completed, ETag.All.ToString());
            var resultFalse = (await collection.ExistsAsync(propertyId)).Value;
            Assert.IsFalse(resultFalse);

            // patch the secret property
            var updateProperty = new NamedValuePatch()
            {
                Secret = false
            };
            await secretValueResponse.UpdateAsync(WaitUntil.Completed, ETag.All.ToString(), updateProperty);

            // check it is patched
            var secretResponse = (await secretValueResponse.GetAsync()).Value;

            ValidateProperty(
                secretResponse,
                secretPropertyId,
                secretPropertyDisplayName,
                secretPropertyValue,
                false);
        }

        public void ValidateProperty(
            NamedValueResource contract,
            string propertyId,
            string propertyDisplayName,
            string propertyValue,
            bool isSecret,
            List<string> tags = null)
        {
            Assert.NotNull(contract);
            Assert.AreEqual(propertyDisplayName, contract.Data.DisplayName);
            if (isSecret)
            {
                Assert.IsNull(contract.Data.Value);
            }
            else
            {
                Assert.AreEqual(propertyValue, contract.Data.Value);
            }
            Assert.AreEqual(isSecret, contract.Data.Secret);
            Assert.AreEqual(propertyId, contract.Data.Name);
            if (tags != null)
            {
                Assert.NotNull(contract.Data.Tags);
                Assert.AreEqual(tags.Count, contract.Data.Tags.Count);
            }
        }
    }
}
