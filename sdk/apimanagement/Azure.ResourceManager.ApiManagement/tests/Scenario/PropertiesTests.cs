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
            var data = new ApiManagementServiceData(AzureLocation.WestUS2, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.StandardV2, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        [Test]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();
            var collection = ApiServiceResource.GetApiManagementNamedValues();

            string propertyId = Recording.GenerateAssetName("newproperty");
            string secretPropertyId = Recording.GenerateAssetName("secretproperty");
            string kvPropertyId = Recording.GenerateAssetName("kvproperty");

            string propertyDisplayName = Recording.GenerateAssetName("propertydisplay");
            string propertyValue = Recording.GenerateAssetName("propertyValue");
            var createParameters = new ApiManagementNamedValueCreateOrUpdateContent()
            {
                DisplayName = propertyDisplayName,
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
            var secretCreateParameters = new ApiManagementNamedValueCreateOrUpdateContent()
            {
                DisplayName = secretPropertyDisplayName,
                Value = secretPropertyValue,
                IsSecret = true,
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
            //var kvCreateParameters = new ApiManagementNamedValueCreateOrUpdateContent()
            //{
            //    DisplayName = kvPropertyDisplayName,
            //    KeyVault = new KeyVaultContractCreateProperties
            //    {
            //        SecretIdentifier = Recording.GenerateAssetName("key")
            //    },
            //    IsSecret = true
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
            Assert.That(listResponse, Is.Not.Null);

            Assert.That(listResponse.Count, Is.EqualTo(2));

            // delete a property
            await getResponse.DeleteAsync(WaitUntil.Completed, ETag.All);
            var resultFalse = (await collection.ExistsAsync(propertyId)).Value;
            Assert.That(resultFalse, Is.False);

            // patch the secret property
            var updateProperty = new ApiManagementNamedValuePatch()
            {
                IsSecret = false
            };
            await secretValueResponse.UpdateAsync(WaitUntil.Completed, ETag.All, updateProperty);

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
            ApiManagementNamedValueResource contract,
            string propertyId,
            string propertyDisplayName,
            string propertyValue,
            bool isSecret,
            List<string> tags = null)
        {
            Assert.That(contract, Is.Not.Null);
            Assert.That(contract.Data.DisplayName, Is.EqualTo(propertyDisplayName));
            if (isSecret)
            {
                Assert.That(contract.Data.Value, Is.Null);
            }
            else
            {
                Assert.That(contract.Data.Value, Is.EqualTo(propertyValue));
            }
            Assert.That(contract.Data.IsSecret, Is.EqualTo(isSecret));
            Assert.That(contract.Data.Name, Is.EqualTo(propertyId));
            if (tags != null)
            {
                Assert.That(contract.Data.Tags, Is.Not.Null);
                Assert.That(contract.Data.Tags.Count, Is.EqualTo(tags.Count));
            }
        }
    }
}
