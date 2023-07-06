// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ManagedNetworkFabric.Tests.Scenario
{
    public class NetworkInterfaceTests : ManagedNetworkFabricManagementTestBase
    {
        public NetworkInterfaceTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public NetworkInterfaceTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task NetworkInterfaces()
        {
            string subscriptionId = TestEnvironment.SubscriptionId;
            string resourceGroupName = TestEnvironment.ResourceGroupName;
            string networkDeviceName = TestEnvironment.NetworkDeviceName;
            string networkInterfaceName = TestEnvironment.NetworkInterfaceName;

            TestContext.Out.WriteLine($"Entered into the NetworkInterface tests....");
            TestContext.Out.WriteLine($"Provided NetworkInterface name : {networkInterfaceName}");

            ResourceIdentifier networkDeviceResourceId = NetworkDeviceResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, networkDeviceName);

            NetworkDeviceResource networkDevice = Client.GetNetworkDeviceResource(networkDeviceResourceId);
            networkDevice = await networkDevice.GetAsync();

            ResourceIdentifier networkInterfaceId = NetworkInterfaceResource.CreateResourceIdentifier(subscriptionId, ResourceGroupResource.Id.Name, networkDeviceName, networkInterfaceName);
            TestContext.Out.WriteLine($"networkInterfaceId: {networkInterfaceId}");
            NetworkInterfaceResource networkInterface = Client.GetNetworkInterfaceResource(networkInterfaceId);

            TestContext.Out.WriteLine($"NetworkInterface Test started.....");

            NetworkInterfaceCollection collection = networkDevice.GetNetworkInterfaces();

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            NetworkInterfaceResource getResult = await networkInterface.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, networkInterfaceName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<NetworkInterfaceResource>();
            NetworkInterfaceCollection collectionOp = networkDevice.GetNetworkInterfaces();
            await foreach (NetworkInterfaceResource item in collectionOp.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            // Update Admin State
            TestContext.Out.WriteLine($"POST started.....");
            UpdateAdministrativeState body = new UpdateAdministrativeState()
            {
                State = AdministrativeState.Disable,
            };
            await networkInterface.UpdateAdministrativeStateAsync(WaitUntil.Completed, body);
            body = new UpdateAdministrativeState()
            {
                State = AdministrativeState.Enable,
            };
            await networkInterface.UpdateAdministrativeStateAsync(WaitUntil.Completed, body);
        }
    }
}
