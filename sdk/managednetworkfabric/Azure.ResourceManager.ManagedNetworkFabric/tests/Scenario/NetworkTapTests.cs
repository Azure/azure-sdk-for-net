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
    public class NetworkTapTests : ManagedNetworkFabricManagementTestBase
    {
        public NetworkTapTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public NetworkTapTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task NetworkTap()
        {
            TestContext.Out.WriteLine($"Entered into the NetworkTap tests....");
            TestContext.Out.WriteLine($"Provided TestEnvironment.NetworkTapName name : {TestEnvironment.NetworkTapName}");
            ResourceIdentifier networkTapRuleResourceId = NetworkTapResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName, TestEnvironment.NetworkTapName);
            TestContext.Out.WriteLine($"networkTapRuleResourceId: {networkTapRuleResourceId}");
            TestContext.Out.WriteLine($"NetworkTap Test started.....");
            NetworkTapCollection collection = ResourceGroupResource.GetNetworkTaps();

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            NetworkTapData data = new NetworkTapData(new AzureLocation("eastus"),
                new ResourceIdentifier("/subscriptions/1234ABCD-0A1B-1234-5678-123456ABCDEF/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/networkpacketbrokers/default"), new NetworkTapPropertiesDestinationsItem[]
                    {
                        new NetworkTapPropertiesDestinationsItem()
                        {
                            Name = "example-destinaionName",
                            DestinationType = NetworkTapDestinationType.IsolationDomain,
                            DestinationId = new ResourceIdentifier("/subscriptions/1234ABCD-0A1B-1234-5678-123456ABCDEF/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/l3isolationdomains/npbl3isd/internalnetworks/npbv4int"),
                            IsolationDomainProperties = new IsolationDomainProperties()
                            {
                                Encapsulation = IsolationDomainEncapsulationType.None,
                                NeighborGroupIds =
                                    {
                                        new ResourceIdentifier("/subscriptions/1234ABCD-0A1B-1234-5678-123456ABCDEF/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/neighborGroups/ngh1")
                                    },
                            },
                            DestinationTapRuleId = new ResourceIdentifier("/subscriptions/1234ABCD-0A1B-1234-5678-123456ABCDEF/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/networktaprules/trafficrule1"),
                        }
                    }
                 )
                {
                    Annotation = "annotation",
                    PollingType = NetworkTapPollingType.Pull,
                    Tags =
                    {
                    ["key6024"] = "1234",
                    },
                };

            ArmOperation<NetworkTapResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.NetworkTapName, data);
            NetworkTapResource createResult = lro.Value;
            Assert.AreEqual(createResult.Data.Name, TestEnvironment.NetworkTapName);
            TestContext.Out.WriteLine($"Created.....{createResult.Data.Id}");

            // Update
            // Patch not supported now. Will enable it once supported.
            /*
            NetworkTapPatch patch = new NetworkTapPatch()
            {
                Annotation = "annotation1",
                PollingType = NetworkTapPollingType.Pull,
                Destinations =
                    {
                    new NetworkTapPatchableParametersDestinationsItem()
                        {
                            Name = "example-destinaionName",
                            DestinationType = NetworkTapDestinationType.IsolationDomain,
                            DestinationId = new ResourceIdentifier("/subscriptions/1234ABCD-0A1B-1234-5678-123456ABCDEF/resourcegroups/example-rg/providers/Microsoft.ManagedNetworkFabric/l3IsloationDomains/example-l3Domain/internalNetworks/example-internalNetwork"),
                            IsolationDomainProperties = new IsolationDomainProperties()
                            {
                                Encapsulation = IsolationDomainEncapsulationType.None,
                                NeighborGroupIds =
                                    {
                                    new ResourceIdentifier("/subscriptions/1234ABCD-0A1B-1234-5678-123456ABCDEF/resourcegroups/example-rg/providers/Microsoft.ManagedNetworkFabric/neighborGroups/example-neighborGroup")
                                    },
                                },
                                DestinationTapRuleId = new ResourceIdentifier("/subscriptions/xxxx-xxxx-xxxx-xxxx/resourcegroups/example-rg/providers/Microsoft.ManagedNetworkFabric/networkTapRules/example-destinationTapRule"),
                            }
                        },
                Tags =
                    {
                    ["key6025"] = "1235",
                    },
            };
            NetworkTapResource networkTapRule = Client.GetNetworkTapResource(createResult.Data.Id);
            TestContext.Out.WriteLine($"PATCH - test started.");
            ArmOperation<NetworkTapResource> lroPatch = await networkTapRule.UpdateAsync(WaitUntil.Completed, patch);
            NetworkTapResource result = lroPatch.Value;
            NetworkTapData resourceData = result.Data;
            Assert.IsTrue(resourceData.Tags.Keys.Contains("key6025"));
            TestContext.Out.WriteLine($"PATCH - test completed.");
            */

            NetworkTapResource ntResource = Client.GetNetworkTapResource(networkTapRuleResourceId);
            // Get
            TestContext.Out.WriteLine($"GET started.....{networkTapRuleResourceId.ToString()}");
            NetworkTapResource getResult = await ntResource.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, TestEnvironment.NetworkTapName);

            // Post
            //TODO: uncomment this once post action issue fixed in southbound side.
            /*
            UpdateAdministrativeStateContent content = new UpdateAdministrativeStateContent()
            {
                State = AdministrativeEnableState.Enable,
                ResourceIds =
                    {
                    new ResourceIdentifier("")
                    },
            };
            TestContext.Out.WriteLine($"Enabling administrative state - AdministrativeEnableState.Enable");
            var enablePostResponse = await ntResource.UpdateAdministrativeStateAsync(WaitUntil.Completed, content);
            getResult = await ntResource.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.AdministrativeState, AdministrativeEnableState.Enable);

            TestContext.Out.WriteLine($"Disabling administrative state - AdministrativeEnableState.Disable");
            content.State = AdministrativeEnableState.Disable;
            var disablePostResponse = await ntResource.UpdateAdministrativeStateAsync(WaitUntil.Completed, content);
            getResult = await ntResource.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.AdministrativeState, AdministrativeEnableState.Disable);
            TestContext.Out.WriteLine($"AdministrativeEnableState test completed.");
            */

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<NetworkTapResource>();
            await foreach (NetworkTapResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            //List by subscription
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId);
            SubscriptionResource subscriptionResource = Client.GetSubscriptionResource(subscriptionResourceId);
            TestContext.Out.WriteLine($"GET - List by Subscription started.....");
            await foreach (NetworkTapResource item in subscriptionResource.GetNetworkTapsAsync())
            {
                NetworkTapData rData = item.Data;
                TestContext.WriteLine($"Succeeded on id: {rData.Id}");
            }
            TestContext.Out.WriteLine($"List by Subscription operation succeeded.");

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            var deleteResponse = await ntResource.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
