// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ManagedNetworkFabric.Tests
{
    public class NetworkFabricControllerTests : ManagedNetworkFabricManagementTestBase
    {
        public NetworkFabricControllerTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) {}
        public NetworkFabricControllerTests(bool isAsync) : base(isAsync) {}

        /// <summary>
        /// The test takes nearly one hour to complete the process. So max time 3600000ms = 1hr.
        /// </summary>
        /// <returns></returns>
        [TestCase]
        [RecordedTest]
        [AsyncOnly]
        public async Task NetworkFabricControllers()
        {
            ResourceGroupResource NFCResourceGroupResource = null;
            var resourceGroupId = ResourceGroupResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.NFCResourceGroupName);
            NFCResourceGroupResource = Client.GetResourceGroupResource(resourceGroupId);

            NetworkFabricControllerCollection collection = NFCResourceGroupResource.GetNetworkFabricControllers();

            string subscriptionId = TestEnvironment.SubscriptionId;
            string resourceGroupName = TestEnvironment.NFCResourceGroupName;
            string networkFabricControllerName = TestEnvironment.NetworkFabricControllerName;

            TestContext.Out.WriteLine($"Entered into the NetworkFabricController tests....");
            TestContext.Out.WriteLine($"Provided subscription-Id : {subscriptionId}");
            TestContext.Out.WriteLine($"Provided resourceGroup : {resourceGroupName}");
            TestContext.Out.WriteLine($"Provided NetworkFabricController : {networkFabricControllerName}");

            ResourceIdentifier networkFabricControllerResourceId = NetworkFabricControllerResource.CreateResourceIdentifier(subscriptionId, NFCResourceGroupResource.Id.Name, networkFabricControllerName);
            TestContext.Out.WriteLine($"networkFabricControllerId: {networkFabricControllerResourceId}");

            ResourceIdentifier deleteNetworkFabricControllerId = new ResourceIdentifier("/subscriptions/61065ccc-9543-4b91-b2d1-0ce42a914507/resourceGroups/nfa-tool-ts-clisdktest-nfrg060523/providers/Microsoft.ManagedNetworkFabric/networkFabricControllers/nfa-tool-ts-sdk-nfc1-062023");
            TestContext.Out.WriteLine($"NFC Test started.....");

            NetworkFabricControllerResource networkFabricController = Client.GetNetworkFabricControllerResource(networkFabricControllerResourceId);
            NetworkFabricControllerResource deleteNetworkFabricController = Client.GetNetworkFabricControllerResource(deleteNetworkFabricControllerId);

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            NetworkFabricControllerData data = new NetworkFabricControllerData(new AzureLocation(TestEnvironment.NFCLocation))
            {
                InfrastructureExpressRouteConnections =
                {
                    new ExpressRouteConnectionInformation("/subscriptions/xxxxx/resourceGroups/resourceGroupName/providers/Microsoft.Network/expressRouteCircuits/expressRouteCircuitName")
                    {
                        ExpressRouteAuthorizationKey = "asdghjklf"
                    }
                },
                WorkloadExpressRouteConnections =
                {
                    new ExpressRouteConnectionInformation("/subscriptions/xxxxx/resourceGroups/resourceGroupName/providers/Microsoft.Network/expressRouteCircuits/expressRouteCircuitName")
                    {
                        ExpressRouteAuthorizationKey = "asdghjklf"
                    }
                },
                IPv4AddressSpace = "172.253.0.0/19"
            };

            ArmOperation<NetworkFabricControllerResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, networkFabricControllerName, data);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            NetworkFabricControllerResource getResult = await networkFabricController.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, networkFabricControllerName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<NetworkFabricControllerResource>();
            await foreach (var item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }

            TestContext.Out.WriteLine($"GET - List by Subscription started.....");
            var listBySubscription = new List<NetworkFabricControllerResource>();
            await foreach (var item in DefaultSubscription.GetNetworkFabricControllersAsync())
            {
                listBySubscription.Add(item);
            }

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            var deleteResponse = await networkFabricController.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
