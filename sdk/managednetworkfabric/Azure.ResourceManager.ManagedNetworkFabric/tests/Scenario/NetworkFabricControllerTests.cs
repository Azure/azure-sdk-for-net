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
    public class NetworkFabricControllerTests : ManagedNetworkFabricManagementTestBase
    {
        public NetworkFabricControllerTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public NetworkFabricControllerTests(bool isAsync) : base(isAsync) { }

        /// <summary>
        /// The test takes nearly one hour to complete the process. So max time 3600000ms = 1hr.
        /// </summary>
        /// <returns></returns>
        [TestCase]
        [RecordedTest]
        [AsyncOnly]
        public async Task NetworkFabricControllers()
        {
            NetworkFabricControllerCollection collection = ResourceGroupResource.GetNetworkFabricControllers();

            ResourceIdentifier networkFabricControllerResourceId = NetworkFabricControllerResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName, TestEnvironment.NetworkFabricControllerName);
            TestContext.Out.WriteLine($"networkFabricControllerId: {networkFabricControllerResourceId}");

            ResourceIdentifier deleteNetworkFabricControllerId = new ResourceIdentifier("/subscriptions/61065ccc-9543-4b91-b2d1-0ce42a914507/resourceGroups/nfa-tool-ts-clisdktest-nfrg060523/providers/Microsoft.ManagedNetworkFabric/networkFabricControllers/nfa-tool-ts-sdk-nfc1-062023");
            TestContext.Out.WriteLine($"NFC Test started.....");

            NetworkFabricControllerResource networkFabricController = Client.GetNetworkFabricControllerResource(networkFabricControllerResourceId);

            #region NFC Create Test

            TestContext.Out.WriteLine($"NFC create started.....");
            NetworkFabricControllerData data = new NetworkFabricControllerData(new AzureLocation(TestEnvironment.Location))
            {
                Annotation = "annotation",
                InfrastructureExpressRouteConnections =
                {
                    new ExpressRouteConnectionInformation(new ResourceIdentifier("/subscriptions/1234ABCD-0A1B-1234-5678-123456ABCDEF/resourceGroups/example-rg/providers/Microsoft.Network/expressRouteCircuits/expressRouteCircuitName"))
                    {
                        ExpressRouteAuthorizationKey = "1234ABCD-0A1B-1234-5678-123456ABCDEF",
                    }
                },
                WorkloadExpressRouteConnections =
                {
                    new ExpressRouteConnectionInformation(new ResourceIdentifier("/subscriptions/1234ABCD-0A1B-1234-5678-123456ABCDEF/resourceGroups/example-rg/providers/Microsoft.Network/expressRouteCircuits/expressRouteCircuitName"))
                    {
                        ExpressRouteAuthorizationKey = "1234ABCD-0A1B-1234-5678-123456ABCDEF",
                    }
                },
                ManagedResourceGroupConfiguration = new ManagedResourceGroupConfiguration()
                {
                    Name = "managedResourceGroupName",
                    Location = new AzureLocation("eastus"),
                },
                IsWorkloadManagementNetworkEnabled = IsWorkloadManagementNetworkEnabled.True,
                IPv4AddressSpace = "172.253.0.0/19",
                IPv6AddressSpace = "::/60",
                NfcSku = NfcSku.Standard,
            };

            ArmOperation<NetworkFabricControllerResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.NetworkFabricControllerName, data);

            #endregion

/*            #region NFC Update test
            NetworkFabricControllerPatch patch = new NetworkFabricControllerPatch()
            {
                InfrastructureExpressRouteConnections =
                {
                    new ExpressRouteConnectionInformation(new ResourceIdentifier("/subscriptions/1234ABCD-0A1B-1234-5678-123456ABCDEF/resourceGroups/example-rg/providers/Microsoft.Network/expressRouteCircuits/expressRouteCircuitName"))
                    {
                        ExpressRouteAuthorizationKey = "1234ABCD-0A1B-1234-5678-123456ABCDEF",
                    }
                },
                WorkloadExpressRouteConnections =
                {
                    new ExpressRouteConnectionInformation(new ResourceIdentifier("/subscriptions/1234ABCD-0A1B-1234-5678-123456ABCDEF/resourceGroups/example-rg/providers/Microsoft.Network/expressRouteCircuits/expressRouteCircuitName"))
                    {
                        ExpressRouteAuthorizationKey = "1234ABCD-0A1B-1234-5678-123456ABCDEF",
                    }
                },
            };
            ArmOperation<NetworkFabricControllerResource> updatedNFC = await networkFabricController.UpdateAsync(WaitUntil.Completed, patch);

            NetworkFabricControllerResource updatedResource = updatedNFC.Value;

            NetworkFabricControllerData updatedData = updatedResource.Data;

            #endregion*/

            // Get
            TestContext.Out.WriteLine($"NFC GET started.....");
            NetworkFabricControllerResource getResult = await networkFabricController.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, TestEnvironment.NetworkFabricControllerName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<NetworkFabricControllerResource>();
            await foreach (var item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }

/*            TestContext.Out.WriteLine($"GET - List by Subscription started.....");
            var listBySubscription = new List<NetworkFabricControllerResource>();
            await foreach (NetworkFabricControllerResource item in DefaultSubscription.GetNetworkFabricControllersAsync())
            {
                listBySubscription.Add(item);
            }*/

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            ArmOperation deleteResponse = await networkFabricController.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
