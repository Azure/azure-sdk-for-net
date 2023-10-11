// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ManagedNetworkFabric.Tests.Scenario
{
    public class NetworkDeviceTests : ManagedNetworkFabricManagementTestBase
    {
        public NetworkDeviceTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public NetworkDeviceTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task NetworkDevices()
        {
            TestContext.Out.WriteLine($"Entered into the NetworkDevice tests....");
            TestContext.Out.WriteLine($"Provided networkDevice name : {TestEnvironment.NetworkDeviceNameUnderDeprovisionedNF}");

            ResourceIdentifier networkDeviceResourceId = NetworkDeviceResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName, TestEnvironment.NetworkDeviceNameUnderDeprovisionedNF);
            TestContext.Out.WriteLine($"networkDeviceResourceId: {networkDeviceResourceId}");

            TestContext.Out.WriteLine($"NetworkDevice Test started.....");

            NetworkDeviceCollection collection = ResourceGroupResource.GetNetworkDevices();

            NetworkDeviceResource device = Client.GetNetworkDeviceResource(networkDeviceResourceId);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            NetworkDeviceResource getResult = await device.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, TestEnvironment.NetworkDeviceNameUnderDeprovisionedNF);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<NetworkDeviceResource>();
            await foreach (NetworkDeviceResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            //List by subscription
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId);
            SubscriptionResource subscriptionResource = Client.GetSubscriptionResource(subscriptionResourceId);

            TestContext.Out.WriteLine($"GET - List by Subscription started.....");

            await foreach (NetworkDeviceResource item in subscriptionResource.GetNetworkDevicesAsync())
            {
                NetworkDeviceData resourceData = item.Data;
                TestContext.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            TestContext.Out.WriteLine($"List by Subscription operation succeeded.");

            // Update Serial Number
            NetworkDevicePatch patch = new NetworkDevicePatch()
            {
                Annotation = "null",
                HostName = "networkDeviceName",
                SerialNumber = "Arista;DCS-7280PR3-24;12.05;JPE21330382",
            };
            ArmOperation<NetworkDeviceResource> lro = await device.UpdateAsync(WaitUntil.Completed, patch);
            NetworkDeviceResource result = lro.Value;
            Assert.AreEqual(result.Data.SerialNumber, patch.SerialNumber);
        }
    }
}
