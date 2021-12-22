// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Communication.Models;
using Azure.Core.TestFramework;

namespace Azure.ResourceManager.Communication.Tests
{
    public class CrudTests : CommunicationManagementClientLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrudTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public CrudTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public void Setup()
        {
            InitializeClients();
        }

        [Test]
        public async Task CrudSimpleResource()
        {
            // Setup resource group for the test. This resource group is deleted by CleanupResourceGroupsAsync after the test ends
            var lro = await ArmClient.GetDefaultSubscription().GetResourceGroups().CreateOrUpdateAsync(
                Recording.GenerateAssetName(ResourceGroupPrefix),
                new ResourceGroupData(Location));
            ResourceGroup rg = lro.Value;

            var resourceName = Recording.GenerateAssetName("sdk-test-crud-simple-");

            // Create a new resource with a our test parameters
            CommunicationServiceCreateOrUpdateOperation result = await rg.GetCommunicationServices().CreateOrUpdateAsync(
                resourceName,
                new CommunicationServiceData { Location = ResourceLocation, DataLocation = ResourceDataLocation });
            await result.WaitForCompletionAsync();

            // Check that our resource has been created successfully
            Assert.IsTrue(result.HasCompleted);
            Assert.IsTrue(result.HasValue);
            CommunicationService resource = result.Value;

            // Check that the keys are there.
            // Note: These values have been sanitized.
            var keys = await resource.GetKeysAsync();
            Assert.NotNull(keys.Value.PrimaryKey);
            Assert.NotNull(keys.Value.SecondaryKey);
            Assert.NotNull(keys.Value.PrimaryConnectionString);
            Assert.NotNull(keys.Value.SecondaryConnectionString);

            keys = await resource.RegenerateKeyAsync(new RegenerateKeyParameters{ KeyType = KeyType.Primary });
            Assert.NotNull(keys.Value.PrimaryKey);
            Assert.Null(keys.Value.SecondaryKey);
            Assert.NotNull(keys.Value.PrimaryConnectionString);
            Assert.Null(keys.Value.SecondaryConnectionString);

            keys = await resource.RegenerateKeyAsync(new RegenerateKeyParameters { KeyType = KeyType.Secondary });
            Assert.Null(keys.Value.PrimaryKey);
            Assert.NotNull(keys.Value.SecondaryKey);
            Assert.Null(keys.Value.PrimaryConnectionString);
            Assert.NotNull(keys.Value.SecondaryConnectionString);

            // Retrieve
            CommunicationService resourceRetrieved = await resource.GetAsync();

            Assert.AreEqual(
                resourceName,
                resourceRetrieved.Data.Name);
            Assert.AreEqual(
                "Succeeded",
                resourceRetrieved.Data.ProvisioningState.ToString());

            // Update
            CommunicationServiceData emptyResource = new CommunicationServiceData();
            resource = await resource.UpdateAsync(emptyResource);

            Assert.True(resource.Data.Tags.Count == 0);

            // Delete
            CommunicationServiceDeleteOperation deleteResult = await resource.DeleteAsync();
            await deleteResult.WaitForCompletionResponseAsync();

            // Check that our resource has been deleted successfully
            Assert.IsTrue(deleteResult.HasCompleted);
        }

        [Test]
        public async Task CrudResourceWithTags()
        {
            // Setup resource group for the test. This resource group is deleted by CleanupResourceGroupsAsync after the test ends
            var lro = await ArmClient.GetDefaultSubscription().GetResourceGroups().CreateOrUpdateAsync(
                Recording.GenerateAssetName(ResourceGroupPrefix),
                new ResourceGroupData(Location));
            ResourceGroup rg = lro.Value;

            var resourceName = Recording.GenerateAssetName("sdk-test-crud-with-tags-");

            // Create a new resource with a our test parameters
            CommunicationServiceData serviceResource = new CommunicationServiceData { Location = ResourceLocation, DataLocation = ResourceDataLocation };
            serviceResource.Tags.Add("tag1", "tag1val");
            serviceResource.Tags.Add("tag2", "tag2val");
            CommunicationServiceCreateOrUpdateOperation result = await rg.GetCommunicationServices().CreateOrUpdateAsync(
                resourceName,
                serviceResource);
            await result.WaitForCompletionAsync();

            // Check that our resource has been created successfully
            Assert.IsTrue(result.HasCompleted);
            Assert.IsTrue(result.HasValue);
            CommunicationService resource = result.Value;

            Assert.AreEqual("tag1val", resource.Data.Tags["tag1"]);
            Assert.AreEqual("tag2val", resource.Data.Tags["tag2"]);
            Assert.IsFalse(resource.Data.Tags.ContainsKey("tag3"));

            // Check that the keys are there.
            // Note: These values have been sanitized.
            var keys = await resource.GetKeysAsync();
            Assert.NotNull(keys.Value.PrimaryKey);
            Assert.NotNull(keys.Value.SecondaryKey);
            Assert.NotNull(keys.Value.PrimaryConnectionString);
            Assert.NotNull(keys.Value.SecondaryConnectionString);

            // Retrieve
            CommunicationService resourceRetrieved = await resource.GetAsync();

            Assert.AreEqual(
                resourceName,
                resourceRetrieved.Data.Name);
            Assert.AreEqual(
                "Succeeded",
                resourceRetrieved.Data.ProvisioningState.ToString());;
            Assert.AreEqual(
                resource.Data.Tags as IEnumerable<KeyValuePair<string, string>>,
                resourceRetrieved.Data.Tags as IEnumerable<KeyValuePair<string, string>>);

            // Update
            resource.Data.Tags.Remove("tag1");
            resource.Data.Tags["tag2"] = "tag2newval";
            resource.Data.Tags.Add("tag3", "tag3val");

            resource = await resource.UpdateAsync(resource.Data);

            Assert.False(resource.Data.Tags.ContainsKey("tag1"));
            Assert.AreEqual("tag2newval", resource.Data.Tags["tag2"]);
            Assert.AreEqual("tag3val", resource.Data.Tags["tag3"]);

            // Delete
            CommunicationServiceDeleteOperation deleteResult = await resource.DeleteAsync();
            await deleteResult.WaitForCompletionResponseAsync();

            // Check that our resource has been deleted successfully
            Assert.IsTrue(deleteResult.HasCompleted);
        }
    }
}
