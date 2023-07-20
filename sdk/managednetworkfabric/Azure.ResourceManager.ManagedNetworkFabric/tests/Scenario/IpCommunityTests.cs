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
    public class IpCommunityTests : ManagedNetworkFabricManagementTestBase
    {
        public IpCommunityTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public IpCommunityTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task IpCommunitiesCRUD()
        {
            TestContext.Out.WriteLine($"Entered into the IP Community tests....");
            TestContext.Out.WriteLine($"Provided IP CommunityName name : {TestEnvironment.IpCommunityName}");

            ResourceIdentifier ipCommunityResourceId = IPCommunityResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName, TestEnvironment.IpCommunityName);
            TestContext.Out.WriteLine($"IpCommunityResourceId: {ipCommunityResourceId}");

            // Get the collection of this IpCommunity
            IPCommunityCollection collection = ResourceGroupResource.GetIPCommunities();

            TestContext.Out.WriteLine($"IpCommunity Test started.....");

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            IPCommunityData data = new IPCommunityData(new AzureLocation(TestEnvironment.Location))
            {
                Annotation = "annotation",
                IPCommunityRules =
                {
                    new IPCommunityRule( CommunityActionType.Permit, 4155123341, new string[] { "1:1" })
                    {
                        WellKnownCommunities =
                        {
                            WellKnownCommunity.Internet
                        },
                    }
                },
                Tags =
                {
                    ["keyId"] = "KeyValue",
                },
            };

            ArmOperation<IPCommunityResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.IpCommunityName, data);
            IPCommunityResource createResult = lro.Value;
            IPCommunityResource ipCommunity = Client.GetIPCommunityResource(ipCommunityResourceId);
            Assert.AreEqual(createResult.Data.Name, TestEnvironment.IpCommunityName);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            IPCommunityResource getResult = await ipCommunity.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, TestEnvironment.IpCommunityName);

            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<IPCommunityResource>();
            IPCommunityCollection collectionOp = ResourceGroupResource.GetIPCommunities();
            await foreach (IPCommunityResource item in collectionOp.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            ArmOperation deleteResponse = await ipCommunity.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
