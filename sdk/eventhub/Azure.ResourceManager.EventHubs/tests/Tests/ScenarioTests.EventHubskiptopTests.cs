// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Azure.Core.TestFramework;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.EventHubs.Tests;

using NUnit.Framework;

namespace Azure.Management.EventHub.Tests
{
    public partial class ScenarioTests : EventHubsManagementClientBase
    {
        [Test]
        public async Task EventHubskiptop()
        {
            var location = GetLocation();
            var resourceGroup = Recording.GenerateAssetName(Helper.ResourceGroupPrefix);
            await Helper.TryRegisterResourceGroupAsync(ResourceGroupsOperations,location.Result, resourceGroup);
            var namespaceName = Recording.GenerateAssetName(Helper.NamespacePrefix);
            var createNamespaceResponse = await NamespacesOperations.StartCreateOrUpdateAsync(resourceGroup, namespaceName,
                new EHNamespace()
                {
                    Location = location.Result,
                    Sku = new Sku(SkuName.Standard)
                    {
                        Tier = SkuTier.Standard
                    },
                    Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        }
                }
                );
            var np = (await WaitForCompletionAsync(createNamespaceResponse)).Value;
            Assert.NotNull(createNamespaceResponse);
            Assert.AreEqual(np.Name, namespaceName);
            DelayInTest(5);
            // Create Eventhub
            var eventHubName = Recording.GenerateAssetName(Helper.EventHubPrefix);
            for (int ehCount = 0; ehCount < 10; ehCount++)
            {
                var eventhubNameLoop = eventHubName + "_" + ehCount.ToString();
                var createEventHubResponseForLoop =await EventHubsOperations.CreateOrUpdateAsync(resourceGroup, namespaceName, eventhubNameLoop, new Eventhub());

                Assert.NotNull(createEventHubResponseForLoop);
                Assert.AreEqual(createEventHubResponseForLoop.Value.Name, eventhubNameLoop);
            }
            //get EventHubs in the same namespace
            var createEventHubResponseList = EventHubsOperations.ListByNamespaceAsync(resourceGroup, namespaceName);
            var createEHResplist = await createEventHubResponseList.ToEnumerableAsync();
            //may cause a misktake
            Assert.AreEqual(10, createEHResplist.Count());
            var gettop10EventHub = EventHubsOperations.ListByNamespaceAsync(resourceGroup, namespaceName, skip: 5, top: 5);
            var ListByNamespAsync = await gettop10EventHub.ToEnumerableAsync();
            Assert.AreEqual(5, ListByNamespAsync.Count());
            // Create a ConsumerGroup
            var consumergroupName = Recording.GenerateAssetName(Helper.ConsumerGroupPrefix);
            for (int consumergroupCount = 0; consumergroupCount < 10; consumergroupCount++)
            {
                var consumergroupNameLoop = consumergroupName + "_" + consumergroupCount.ToString();
                var createConsumerGroupResponseForLoop =await ConsumerGroupsOperations.CreateOrUpdateAsync(resourceGroup, namespaceName, createEHResplist.ElementAt<Eventhub>(0).Name, consumergroupNameLoop, new ConsumerGroup());
                Assert.NotNull(createConsumerGroupResponseForLoop);
                Assert.AreEqual(createConsumerGroupResponseForLoop.Value.Name, consumergroupNameLoop);
            }
            var createConsumerGroupResponseList = ConsumerGroupsOperations.ListByEventHubAsync(resourceGroup, namespaceName, createEHResplist.ElementAt<Eventhub>(0).Name);
            var createConResList = await createConsumerGroupResponseList.ToEnumerableAsync();
            Assert.AreEqual(11, createConResList.Count<ConsumerGroup>());
            var gettop10ConsumerGroup = ConsumerGroupsOperations.ListByEventHubAsync(resourceGroup, namespaceName, createEHResplist.ElementAt<Eventhub>(0).Name, skip: 5, top: 4);
            var ConsGrClientList = await gettop10ConsumerGroup.ToEnumerableAsync();
            Assert.AreEqual(6, ConsGrClientList.Count<ConsumerGroup>());
            // Delete namespace and check for the NotFound exception
            await WaitForCompletionAsync(await NamespacesOperations.StartDeleteAsync(resourceGroup, namespaceName));
        }
    }
}
