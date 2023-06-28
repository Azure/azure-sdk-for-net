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
    public class NetworkDeviceTests : ManagedNetworkFabricManagementTestBase
    {
        public NetworkDeviceTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public NetworkDeviceTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task NetworkDevices()
        {
            string subscriptionId = TestEnvironment.SubscriptionId;
            string resourceGroupName = TestEnvironment.ResourceGroupName;
            string networkDeviceName = TestEnvironment.NetworkDeviceName;

            TestContext.Out.WriteLine($"Entered into the NetworkDevice tests....");
            TestContext.Out.WriteLine($"Provided networkDevice name : {networkDeviceName}");

            ResourceIdentifier networkDeviceResourceId = NetworkDeviceResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, networkDeviceName);
            TestContext.Out.WriteLine($"networkDeviceResourceId: {networkDeviceResourceId}");

            TestContext.Out.WriteLine($"NetworkDevice Test started.....");

            NetworkDeviceCollection collection = ResourceGroupResource.GetNetworkDevices();

            NetworkDeviceResource device = Client.GetNetworkDeviceResource(networkDeviceResourceId);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            NetworkDeviceResource getResult = await device.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, networkDeviceName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<NetworkDeviceResource>();
            await foreach (NetworkDeviceResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            TestContext.Out.WriteLine($"GET - List by Subscription started.....");
            var listBySubscription = new List<NetworkDeviceResource>();
            await foreach (NetworkDeviceResource item in DefaultSubscription.GetNetworkDevicesAsync())
            {
                listBySubscription.Add(item);
                Console.WriteLine($"Succeeded on id: {item}");
            }
            Assert.IsNotEmpty(listBySubscription);

            // Update Serial Number
            NetworkDevicePatch patch = new NetworkDevicePatch()
            {
                Annotation = "null",
                HostName = "networkDeviceName",
                SerialNumber = "Arista;DCS-7280PR3-24;12.05;JPE21330382",
            };
            ArmOperation<NetworkDeviceResource> lro = await device.UpdateAsync(WaitUntil.Completed, patch);
            NetworkDeviceResource result = lro.Value;
        }
    }
}