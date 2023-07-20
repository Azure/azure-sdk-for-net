// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
            TestContext.Out.WriteLine($"Entered into the NetworkInterface tests....");
            TestContext.Out.WriteLine($"Provided NetworkInterface name : {TestEnvironment.NetworkInterfaceName}");

            ResourceIdentifier networkDeviceResourceId = NetworkDeviceResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName, TestEnvironment.NetworkDeviceNameUnderProvisionedNF);

            NetworkDeviceResource networkDevice = Client.GetNetworkDeviceResource(networkDeviceResourceId);
            networkDevice = await networkDevice.GetAsync();

            ResourceIdentifier networkInterfaceId = NetworkInterfaceResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceGroupResource.Id.Name, TestEnvironment.NetworkDeviceNameUnderProvisionedNF, TestEnvironment.NetworkInterfaceName);
            TestContext.Out.WriteLine($"networkInterfaceId: {networkInterfaceId}");
            NetworkInterfaceResource networkInterface = Client.GetNetworkInterfaceResource(networkInterfaceId);

            TestContext.Out.WriteLine($"NetworkInterface Test started.....");

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            NetworkInterfaceResource getResult = await networkInterface.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, TestEnvironment.NetworkInterfaceName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<NetworkInterfaceResource>();
            NetworkInterfaceCollection collectionOp = networkDevice.GetNetworkInterfaces();
            await foreach (NetworkInterfaceResource item in collectionOp.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            UpdateAdministrativeState body = new UpdateAdministrativeState()
            {
                State = EnableDisableState.Disable
            };
            ArmOperation<CommonPostActionResponseForStateUpdate> disableAdminStateResponse = await networkInterface.UpdateAdministrativeStateAsync(WaitUntil.Completed, body);
            CommonPostActionResponseForStateUpdate result = disableAdminStateResponse.Value;
            TestContext.WriteLine($"Succeeded: {result}");

            body = new UpdateAdministrativeState()
            {
                State = EnableDisableState.Enable
            };
            ArmOperation<CommonPostActionResponseForStateUpdate> enableAdminStateResponse = await networkInterface.UpdateAdministrativeStateAsync(WaitUntil.Completed, body);
            result = enableAdminStateResponse.Value;
            TestContext.WriteLine($"Succeeded: {result}");
        }
    }
}
