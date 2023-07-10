// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ManagedNetworkFabric.Tests
{
    public class NetworkFabricTests : ManagedNetworkFabricManagementTestBase
    {
        public NetworkFabricTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public NetworkFabricTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task NetworkFabrics()
        {
            NetworkFabricCollection collection = ResourceGroupResource.GetNetworkFabrics();

            string subscriptionId = TestEnvironment.SubscriptionId;
            string resourceGroupName = TestEnvironment.ResourceGroupName;
            string networkFabricControllerId = TestEnvironment.ValidNetworkFabricControllerId;
            string networkFabricName = TestEnvironment.NetworkFabricName;
            string networkFabricNameForPostAction = TestEnvironment.NetworkFabricNameForPostAction;

            TestContext.Out.WriteLine($"Entered into the NetworkFabric tests....");

            TestContext.Out.WriteLine($"Provided NetworkFabricControllerId : {networkFabricControllerId}");
            TestContext.Out.WriteLine($"Provided NetworkFabric name : {networkFabricName}");
            ResourceIdentifier networkFabricResourceId = NetworkFabricResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, networkFabricName);
            ResourceIdentifier networkFabricResourceIdForPostAction = NetworkFabricResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, networkFabricNameForPostAction);

            TestContext.Out.WriteLine($"networkFabricId: {networkFabricResourceId}");

            TestContext.Out.WriteLine($"Test started.....");

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            NetworkFabricData data = new NetworkFabricData(new AzureLocation(TestEnvironment.Location))
            {
                NetworkFabricSku = "fab1",
                RackCount = 3,
                ServerCountPerRack = 7,
                IPv4Prefix = "10.1.0.0/19",
                FabricASN = 20,
                NetworkFabricControllerId = networkFabricControllerId,
                TerminalServerConfiguration = new TerminalServerConfiguration()
                {
                    Username = "username",
                    Password = "****",
                    SerialNumber = "1234",
                    PrimaryIPv4Prefix = "172.31.0.0/30",
                    SecondaryIPv4Prefix = "172.31.0.20/30"
                },
                ManagementNetworkConfiguration = new ManagementNetworkConfiguration(
                new VpnConfigurationProperties(PeeringOption.OptionB)
                {
                    OptionBProperties = new NetworkFabricOptionBProperties(new string[]
                    {
                        "65541:2001"
                    },
                    new string[]
                    {
                        "65541:2001"
                    })
                },
                new VpnConfigurationProperties(PeeringOption.OptionB)
                {
                    OptionBProperties = new NetworkFabricOptionBProperties(new string[]
                    {
                        "65541:2001"
                    },
                    new string[]
                    {
                        "65541:2001"
                    })
                })
            };
            ArmOperation<NetworkFabricResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, networkFabricName, data);

            NetworkFabricResource networkFabric = Client.GetNetworkFabricResource(networkFabricResourceId);
            NetworkFabricResource networkFabricForPostAction = Client.GetNetworkFabricResource(networkFabricResourceIdForPostAction);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            NetworkFabricResource getResult = await networkFabric.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, networkFabricName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<NetworkFabricResource>();
            await foreach (NetworkFabricResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            TestContext.Out.WriteLine($"GET - List by Subscription started.....");
            var listBySubscription = new List<NetworkFabricResource>();
            await foreach (NetworkFabricResource item in DefaultSubscription.GetNetworkFabricsAsync())
            {
                listBySubscription.Add(item);
            }
            Assert.IsNotEmpty(listBySubscription);

            // provision
            TestContext.Out.WriteLine($"POST - Provision started.....");
            var provisionResponse = networkFabricForPostAction.ProvisionAsync(WaitUntil.Completed);

            // Deprovision
            TestContext.Out.WriteLine($"POST - Deprovision started.....");
            var deProvisionResponse = await networkFabricForPostAction.DeprovisionAsync(WaitUntil.Completed);

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            var deleteResponse = await networkFabric.DeleteAsync(WaitUntil.Completed);
        }
    }
}
