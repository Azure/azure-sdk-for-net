// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Threading.Tasks;

using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.EventHubs.Tests;

using NUnit.Framework;

namespace Azure.Management.EventHub.Tests
{
    public partial class ScenarioTests : EventHubsManagementClientBase
    {
        [Test]
        public async Task ConsumerGroupsCreateGetUpdateDelete()
        {
            var location = await GetLocation();
            var resourceGroupName = Recording.GenerateAssetName(Helper.ResourceGroupPrefix);
            Subscription sub = await ArmClient.GetDefaultSubscriptionAsync();
            await sub.GetResourceGroups().CreateOrUpdateAsync(resourceGroupName, new ResourceGroupData(location));
            var namespaceName = Recording.GenerateAssetName(Helper.NamespacePrefix);
            var createNamespaceResponse = await NamespacesOperations.StartCreateOrUpdateAsync(resourceGroupName, namespaceName,
                new EHNamespace()
                {
                    Location = location,
                    Sku= new Sku(SkuName.Standard)
                    {
                        Tier = SkuTier.Standard,
                    },
                    Tags =
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
            var eventhubName = Recording.GenerateAssetName(Helper.EventHubPrefix);
            var createEventhubResponse = await EventHubsOperations.CreateOrUpdateAsync(resourceGroupName, namespaceName, eventhubName,
            new Eventhub() { MessageRetentionInDays = 5 });
            Assert.NotNull(createEventhubResponse);
            Assert.AreEqual(createEventhubResponse.Value.Name, eventhubName);
            //Get the created EventHub
            var getEventHubResponse = await EventHubsOperations.GetAsync(resourceGroupName, namespaceName, eventhubName);
            Assert.NotNull(getEventHubResponse);
            Assert.AreEqual(EntityStatus.Active, getEventHubResponse.Value.Status);
            Assert.AreEqual(getEventHubResponse.Value.Name, eventhubName);
            // Create ConsumerGroup.
            var consumergroupName = Recording.GenerateAssetName(Helper.ConsumerGroupPrefix);
            string UserMetadata = "Newly Created";
            var createConsumergroupResponse =await ConsumerGroupsOperations.CreateOrUpdateAsync(resourceGroupName, namespaceName, eventhubName, consumergroupName, new ConsumerGroup { UserMetadata = UserMetadata });
            Assert.NotNull(createConsumergroupResponse);
            Assert.AreEqual(createConsumergroupResponse.Value.Name, consumergroupName);
            // Get Created ConsumerGroup
            var getConsumergroupGetResponse =await ConsumerGroupsOperations.GetAsync(resourceGroupName, namespaceName, eventhubName, consumergroupName);
            Assert.NotNull(getConsumergroupGetResponse);
            Assert.AreEqual(getConsumergroupGetResponse.Value.Name, consumergroupName);
            // Get all ConsumerGroup
            var getSubscriptionsListAllResponse = ConsumerGroupsOperations.ListByEventHubAsync(resourceGroupName, namespaceName, eventhubName);
            Assert.NotNull(getSubscriptionsListAllResponse);
            bool isContainresourceGroup = false;
            var list = await getSubscriptionsListAllResponse.ToEnumerableAsync();
            foreach (var detail in list)
            {
                if (detail.Id.Contains(resourceGroupName))
                {
                    isContainresourceGroup = true;
                    break;
                }
            }
            Assert.True(isContainresourceGroup);
            //Update the Created consumergroup
            createConsumergroupResponse.Value.UserMetadata = "Updated the user meta data";
            var updateconsumergroupResponse = ConsumerGroupsOperations.CreateOrUpdateAsync(resourceGroupName, namespaceName, eventhubName, consumergroupName, createConsumergroupResponse);
            Assert.NotNull(updateconsumergroupResponse);
            Assert.AreEqual(updateconsumergroupResponse.Result.Value.Name, createConsumergroupResponse.Value.Name);
            Assert.AreEqual("Updated the user meta data", updateconsumergroupResponse.Result.Value.UserMetadata);
            // Get Created ConsumerGroup
            var getConsumergroupResponse = ConsumerGroupsOperations.GetAsync(resourceGroupName, namespaceName, eventhubName, consumergroupName);
            Assert.NotNull(getConsumergroupResponse);
            Assert.AreEqual(getConsumergroupResponse.Result.Value.Name, consumergroupName);
            Assert.AreEqual(getConsumergroupResponse.Result.Value.UserMetadata, updateconsumergroupResponse.Result.Value.UserMetadata);
            // Delete Created ConsumerGroup and check for the NotFound exception
            await ConsumerGroupsOperations.DeleteAsync(resourceGroupName, namespaceName, eventhubName, consumergroupName);
            // Delete Created EventHub  and check for the NotFound exception
            await EventHubsOperations.DeleteAsync(resourceGroupName, namespaceName, eventhubName);
            // Delete namespace
            await WaitForCompletionAsync(await NamespacesOperations.StartDeleteAsync(resourceGroupName, namespaceName));
            //Subscription end
        }
    }
}
