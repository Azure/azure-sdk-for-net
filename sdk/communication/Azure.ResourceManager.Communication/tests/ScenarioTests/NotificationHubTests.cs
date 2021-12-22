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
    public class NotificationHubTests : CommunicationManagementClientLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationHubTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public NotificationHubTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public void Setup()
        {
            InitializeClients();
        }

        [Test]
        public async Task LinkNotificationHub()
        {
            // Setup resource group for the test. This resource group is deleted by CleanupResourceGroupsAsync after the test ends
            var lro = await ArmClient.GetDefaultSubscription().GetResourceGroups().CreateOrUpdateAsync(
                NotificationHubsResourceGroupName,
                new ResourceGroupData(Location));
            ResourceGroup rg = lro.Value;

            var resourceName = Recording.GenerateAssetName("sdk-test-link-notif-hub-");

            // Create a new resource with a our test parameters
            CommunicationServiceCreateOrUpdateOperation result = await rg.GetCommunicationServices().CreateOrUpdateAsync(
                resourceName,
                new CommunicationServiceData { Location = ResourceLocation, DataLocation = ResourceDataLocation });
            await result.WaitForCompletionAsync();

            // Check that our resource has been created successfully
            Assert.IsTrue(result.HasCompleted);
            Assert.IsTrue(result.HasValue);
            CommunicationService resource = result.Value;

            // Retrieve
            CommunicationService resourceRetrieved = await resource.GetAsync();

            Assert.AreEqual(
                resourceName,
                resourceRetrieved.Data.Name);
            Assert.AreEqual(
                "Succeeded",
                resourceRetrieved.Data.ProvisioningState.ToString());

            // Link NotificationHub
            var linkNotificationHubResponse = await resource.LinkNotificationHubAsync(
                new LinkNotificationHubParameters(NotificationHubsResourceId, NotificationHubsConnectionString));
            Assert.AreEqual(NotificationHubsResourceId, linkNotificationHubResponse.Value.ResourceId);

            // Delete
            CommunicationServiceDeleteOperation deleteResult = await resource.DeleteAsync();
            await deleteResult.WaitForCompletionResponseAsync();

            // Check that our resource has been deleted successfully
            Assert.IsTrue(deleteResult.HasCompleted);
        }
    }
}
