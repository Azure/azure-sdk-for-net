// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Communication.Models;

namespace Azure.ResourceManager.Communication.Tests
{
    public class NotificationHubTests : CommunicationManagementClientLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationHubTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public NotificationHubTests(bool isAsync) : base(isAsync)
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
        public async Task LinkNotificationHub()
        {
            // Setup resource group for the test. This resource group is deleted by CleanupResourceGroupsAsync after the test ends
            ResourceGroup rg = await ResourcesManagementClient.ResourceGroups.CreateOrUpdateAsync(
                NotificationHubsResourceGroupName,
                new ResourceGroup(Location));

            CommunicationManagementClient acsClient = GetCommunicationManagementClient();
            var resourceName = Recording.GenerateAssetName("sdk-test-link-notif-hub-");

            // Create a new resource with a our test parameters
            CommunicationServiceCreateOrUpdateOperation result = await acsClient.CommunicationService.StartCreateOrUpdateAsync(
                rg.Name,
                resourceName,
                new CommunicationServiceResource { Location = ResourceLocation, DataLocation = ResourceDataLocation });
            await result.WaitForCompletionAsync();

            // Check that our resource has been created successfully
            Assert.IsTrue(result.HasCompleted);
            Assert.IsTrue(result.HasValue);
            CommunicationServiceResource resource = result.Value;

            // Retrieve
            var resourceRetrieved = await acsClient.CommunicationService.GetAsync(rg.Name, resourceName);

            Assert.AreEqual(
                resourceName,
                resourceRetrieved.Value.Name);
            Assert.AreEqual(
                "Succeeded",
                resourceRetrieved.Value.ProvisioningState.ToString());

            // Link NotificationHub
            var linkNotificationHubResponse = await acsClient.CommunicationService.LinkNotificationHubAsync(
                rg.Name,
                resourceName,
                new LinkNotificationHubParameters(NotificationHubsResourceId, NotificationHubsConnectionString));
            Assert.AreEqual(NotificationHubsResourceId, linkNotificationHubResponse.Value.ResourceId);

            // Delete
            CommunicationServiceDeleteOperation deleteResult = await acsClient.CommunicationService.StartDeleteAsync(rg.Name, resourceName);
            await deleteResult.WaitForCompletionAsync();

            // Check that our resource has been deleted successfully
            Assert.IsTrue(deleteResult.HasCompleted);
            Assert.IsTrue(deleteResult.HasValue);
        }
    }
}
