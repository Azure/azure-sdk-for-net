// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Communication.Models;

namespace Azure.ResourceManager.Communication.Tests
{
    public class CrudTests : CommunicationManagementClientLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrudTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public CrudTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void Setup()
        {
            InitializeClients();
        }

        [TearDown]
        public async Task Cleanup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public async Task CrudSimpleResource()
        {
            // Setup resource group for the test. This resource group is deleted by CleanupResourceGroupsAsync after the test ends
            Subscription sub = await ResourcesManagementClient.GetDefaultSubscriptionAsync();
            var lro = await sub.GetResourceGroups().CreateOrUpdateAsync(
                Recording.GenerateAssetName(ResourceGroupPrefix),
                new ResourceGroupData(Location));
            ResourceGroup rg = lro.Value;

            CommunicationManagementClient acsClient = GetCommunicationManagementClient();
            var resourceName = Recording.GenerateAssetName("sdk-test-crud-simple-");

            // Create a new resource with a our test parameters
            CommunicationServiceCreateOrUpdateOperation result = await acsClient.CommunicationService.StartCreateOrUpdateAsync(
                rg.Data.Name,
                resourceName,
                new CommunicationServiceResource { Location = ResourceLocation, DataLocation = ResourceDataLocation });
            await result.WaitForCompletionAsync();

            // Check that our resource has been created successfully
            Assert.IsTrue(result.HasCompleted);
            Assert.IsTrue(result.HasValue);
            CommunicationServiceResource resource = result.Value;

            // Check that the keys are there.
            // Note: These values have been sanitized.
            var keys = await acsClient.CommunicationService.ListKeysAsync(rg.Data.Name, resourceName);
            Assert.NotNull(keys.Value.PrimaryKey);
            Assert.NotNull(keys.Value.SecondaryKey);
            Assert.NotNull(keys.Value.PrimaryConnectionString);
            Assert.NotNull(keys.Value.SecondaryConnectionString);

            keys = await acsClient.CommunicationService.RegenerateKeyAsync(rg.Data.Name, resourceName, new RegenerateKeyParameters{ KeyType = KeyType.Primary });
            Assert.NotNull(keys.Value.PrimaryKey);
            Assert.Null(keys.Value.SecondaryKey);
            Assert.NotNull(keys.Value.PrimaryConnectionString);
            Assert.Null(keys.Value.SecondaryConnectionString);

            keys = await acsClient.CommunicationService.RegenerateKeyAsync(rg.Data.Name, resourceName, new RegenerateKeyParameters { KeyType = KeyType.Secondary });
            Assert.Null(keys.Value.PrimaryKey);
            Assert.NotNull(keys.Value.SecondaryKey);
            Assert.Null(keys.Value.PrimaryConnectionString);
            Assert.NotNull(keys.Value.SecondaryConnectionString);

            // Retrieve
            var resourceRetrieved = await acsClient.CommunicationService.GetAsync(rg.Data.Name, resourceName);

            Assert.AreEqual(
                resourceName,
                resourceRetrieved.Value.Name);
            Assert.AreEqual(
                "Succeeded",
                resourceRetrieved.Value.ProvisioningState.ToString());

            // Update
            CommunicationServiceResource emptyResource = new CommunicationServiceResource();
            resource = await acsClient.CommunicationService.UpdateAsync(
                rg.Data.Name,
                resourceName,
                emptyResource);

            Assert.True(resource.Tags.Count == 0);

            // Delete
            CommunicationServiceDeleteOperation deleteResult = await acsClient.CommunicationService.StartDeleteAsync(rg.Data.Name, resourceName);
            await deleteResult.WaitForCompletionAsync();

            // Check that our resource has been deleted successfully
            Assert.IsTrue(deleteResult.HasCompleted);
            Assert.IsTrue(deleteResult.HasValue);
        }

        [Test]
        public async Task CrudResourceWithTags()
        {
            // Setup resource group for the test. This resource group is deleted by CleanupResourceGroupsAsync after the test ends
            Subscription sub = await ResourcesManagementClient.GetDefaultSubscriptionAsync();
            var lro = await sub.GetResourceGroups().CreateOrUpdateAsync(
                Recording.GenerateAssetName(ResourceGroupPrefix),
                new ResourceGroupData(Location));
            ResourceGroup rg = lro.Value;

            CommunicationManagementClient acsClient = GetCommunicationManagementClient();
            var resourceName = Recording.GenerateAssetName("sdk-test-crud-with-tags-");

            // Create a new resource with a our test parameters
            CommunicationServiceResource serviceResource = new CommunicationServiceResource { Location = ResourceLocation, DataLocation = ResourceDataLocation };
            serviceResource.Tags.Add("tag1", "tag1val");
            serviceResource.Tags.Add("tag2", "tag2val");
            CommunicationServiceCreateOrUpdateOperation result = await acsClient.CommunicationService.StartCreateOrUpdateAsync(
                rg.Data.Name,
                resourceName,
                serviceResource);
            await result.WaitForCompletionAsync();

            // Check that our resource has been created successfully
            Assert.IsTrue(result.HasCompleted);
            Assert.IsTrue(result.HasValue);
            CommunicationServiceResource resource = result.Value;

            Assert.AreEqual("tag1val", resource.Tags["tag1"]);
            Assert.AreEqual("tag2val", resource.Tags["tag2"]);
            Assert.IsFalse(resource.Tags.ContainsKey("tag3"));

            // Check that the keys are there.
            // Note: These values have been sanitized.
            var keys = await acsClient.CommunicationService.ListKeysAsync(rg.Data.Name, resourceName);
            Assert.NotNull(keys.Value.PrimaryKey);
            Assert.NotNull(keys.Value.SecondaryKey);
            Assert.NotNull(keys.Value.PrimaryConnectionString);
            Assert.NotNull(keys.Value.SecondaryConnectionString);

            // Retrieve
            var resourceRetrieved = await acsClient.CommunicationService.GetAsync(rg.Data.Name, resourceName);

            Assert.AreEqual(
                resourceName,
                resourceRetrieved.Value.Name);
            Assert.AreEqual(
                "Succeeded",
                resourceRetrieved.Value.ProvisioningState.ToString());;
            Assert.AreEqual(
                resource.Tags as IEnumerable<KeyValuePair<string, string>>,
                resourceRetrieved.Value.Tags as IEnumerable<KeyValuePair<string, string>>);

            // Update
            resource.Tags.Remove("tag1");
            resource.Tags["tag2"] = "tag2newval";
            resource.Tags.Add("tag3", "tag3val");

            resource = await acsClient.CommunicationService.UpdateAsync(
                rg.Data.Name,
                resourceName,
                resource);

            Assert.False(resource.Tags.ContainsKey("tag1"));
            Assert.AreEqual("tag2newval", resource.Tags["tag2"]);
            Assert.AreEqual("tag3val", resource.Tags["tag3"]);

            // Delete
            CommunicationServiceDeleteOperation deleteResult = await acsClient.CommunicationService.StartDeleteAsync(rg.Data.Name, resourceName);
            await deleteResult.WaitForCompletionAsync();

            // Check that our resource has been deleted successfully
            Assert.IsTrue(deleteResult.HasCompleted);
            Assert.IsTrue(deleteResult.HasValue);
        }
    }
}
