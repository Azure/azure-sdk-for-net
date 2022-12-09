// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.IotHub.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.IotHub.Tests.Scenario
{
    internal class IotHubPrivateEndpointTests : IotHubManagementTestBase
    {
        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceGroupResource _resourceGroup;
        public IotHubPrivateEndpointTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            string rgName = SessionRecording.GenerateAssetName("IotHub-RG-");
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
            _resourceGroupIdentifier = rgLro.Value.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await Client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [Test]
        [RecordedTest]
        [Ignore("SDK does not provide create a PrivateEndpointLinkConnect.It needs to be created manually.")]
        public async Task CreateOrUpdate()
        {
            string iotHubName = Recording.GenerateAssetName("IotHub-");
            var iothub = await CreateIotHub(_resourceGroup, iotHubName);
            var collection = iothub.GetIotHubPrivateEndpointConnections();

            // [Update the status of a private endpoint connection with the specified name]
            // The Sdk does not support create it.
            string privateEndpointConnectionName = $"{iotHubName}.{Guid.NewGuid()}";
            var connectionState = new IotHubPrivateLinkServiceConnectionState(IotHubPrivateLinkServiceConnectionStatus.Approved, "description");
            var privateEndpointConnectionProperties = new IotHubPrivateEndpointConnectionProperties(connectionState) { };
            var iotHubPrivateEndpointConnectionData = new IotHubPrivateEndpointConnectionData(privateEndpointConnectionProperties) {};
            var connection = await collection.CreateOrUpdateAsync(WaitUntil.Completed, privateEndpointConnectionName, iotHubPrivateEndpointConnectionData);
            Assert.IsNotNull(connection);
        }

        [Test]
        [RecordedTest]
        [Ignore("SDK does not provide create a PrivateEndpointLinkConnect.It needs to be created manually.")]
        public async Task Get()
        {
            string iotHubName = Recording.GenerateAssetName("IotHub-");
            string connectionName = "IotHub-6981.c3c46102-efff-4ced-b7c1-52dbfb1e5111";
            var iothub = await CreateIotHub(_resourceGroup, iotHubName);
            var connect  = await iothub.GetIotHubPrivateEndpointConnections().GetAsync(connectionName);
            Assert.IsNotNull(connect);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string iotHubName = Recording.GenerateAssetName("IotHub-");
            var iothub = await CreateIotHub(_resourceGroup, iotHubName);
            var list =  await iothub.GetIotHubPrivateEndpointConnections().GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
