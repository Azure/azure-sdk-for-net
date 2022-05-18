// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Communication.Models;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using Azure.Core;

namespace Azure.ResourceManager.Communication.Tests
{
    public class NotificationHubTests : CommunicationManagementClientLiveTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;
        private string _notificationHubsResourceId;
        private string _notificationHubsConnectionString;
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationHubTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public NotificationHubTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName(ResourceGroupPrefix), new ResourceGroupData(new AzureLocation("westus2")));
            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;

            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task Setup()
        {
            ArmClient = GetArmClient();
            _notificationHubsResourceId = TestEnvironment.NotificationHubsResourceId;
            _notificationHubsConnectionString = TestEnvironment.NotificationHubsConnectionString;
            _resourceGroup = await ArmClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            var list = await _resourceGroup.GetCommunicationServices().GetAllAsync().ToEnumerableAsync();
            foreach (var communicationService in list)
            {
                await communicationService.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        public async Task LinkNotificationHub()
        {
            // Create communication service
            string communicationServiceName = Recording.GenerateAssetName("communication-service-");
            CommunicationServiceResource resource = await CreateDefaultCommunicationServices(communicationServiceName, _resourceGroup);

            // Link NotificationHub
            var linkNotificationHubResponse = await resource.LinkNotificationHubAsync(
                new LinkNotificationHubContent(_notificationHubsResourceId, _notificationHubsConnectionString));
            Assert.AreEqual(_notificationHubsResourceId, linkNotificationHubResponse.Value.ResourceId);
        }
    }
}
