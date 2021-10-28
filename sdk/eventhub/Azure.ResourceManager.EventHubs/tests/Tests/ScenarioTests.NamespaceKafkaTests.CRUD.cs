// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.EventHubs.Tests;

using NUnit.Framework;

namespace Azure.Management.EventHub.Tests
{
    public partial class ScenarioTests: EventHubsManagementClientBase
    {
        [Test]
        public async Task NamespaceKafkaCreateGetUpdateDelete()
        {
            var location = "West US";
            var resourceGroupName = Recording.GenerateAssetName(Helper.ResourceGroupPrefix);
            Subscription sub = await ArmClient.GetDefaultSubscriptionAsync();
            await sub.GetResourceGroups().CreateOrUpdateAsync(resourceGroupName, new ResourceGroupData(location));
            var namespaceName = Recording.GenerateAssetName(Helper.NamespacePrefix);
            var createNamespaceResponse = await NamespacesOperations.StartCreateOrUpdateAsync(resourceGroupName, namespaceName,
                new EHNamespace()
                {
                    Location = location,
                    Tags =
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        },
                    IsAutoInflateEnabled = true,
                    MaximumThroughputUnits = 10,
                    KafkaEnabled = true
                }
                );
            var np = (await WaitForCompletionAsync(createNamespaceResponse)).Value;
            Assert.NotNull(createNamespaceResponse);
            Assert.AreEqual(np.Name, namespaceName);
            Assert.True(np.KafkaEnabled, "KafkaEnabled is false");
            DelayInTest(5);
            //get the created namespace
            var getNamespaceResponse = await NamespacesOperations.GetAsync(resourceGroupName, namespaceName);
            if (string.Compare(getNamespaceResponse.Value.ProvisioningState, "Succeeded", true) != 0)
                DelayInTest(5);
            getNamespaceResponse = await NamespacesOperations.GetAsync(resourceGroupName, namespaceName);
            Assert.NotNull(getNamespaceResponse);
            Assert.AreEqual("Succeeded", getNamespaceResponse.Value.ProvisioningState,StringComparer.CurrentCultureIgnoreCase.ToString());
            Assert.AreEqual(location, getNamespaceResponse.Value.Location);
            // Get all namespaces created within a resourceGroupName
            var getAllNamespacesResponse = NamespacesOperations.ListByResourceGroupAsync(resourceGroupName);
            Assert.NotNull(getAllNamespacesResponse);
            //Assert.True(getAllNamespacesResponse.AsPages.c >= 1);
            var getAllNamespRespList = await getAllNamespacesResponse.ToEnumerableAsync();
            bool isContainnamespaceName = false;
            bool isContainresourceGroup = false;
            foreach (var name in getAllNamespRespList)
            {
                if (name.Name == namespaceName)
                {
                    isContainnamespaceName = true;
                    break;
                }
            }
             foreach (var name in getAllNamespRespList)
            {
                if (name.Id.Contains(resourceGroupName))
                {
                    isContainresourceGroup = true;
                    break;
                }
            }
            Assert.True(isContainnamespaceName);
            Assert.True(isContainresourceGroup);
            // Get all namespaces created within the subscription irrespective of the resourceGroupName
            getAllNamespacesResponse =NamespacesOperations.ListAsync();
            Assert.NotNull(getAllNamespacesResponse);
            bool isContainNamespacename = false;
            getAllNamespRespList = await getAllNamespacesResponse.ToEnumerableAsync();
            foreach (var getNameSpResp in getAllNamespRespList)
            {
                if (getNameSpResp.Name == namespaceName)
                {
                    isContainNamespacename = true;
                    break;
                }
            }
            Assert.IsTrue(isContainNamespacename);
            // Update namespace tags and make the namespace critical
            var updateNamespaceParameter = new EHNamespace()
            {
                Tags =
                        {
                            {"tag3", "value3"},
                            {"tag4", "value4"}
                        }
            };
            // Will uncomment the assertions once the service is deployed
            var updateNamespaceResponse =await NamespacesOperations.UpdateAsync(resourceGroupName, namespaceName, updateNamespaceParameter);
            Assert.NotNull(updateNamespaceResponse);
            Assert.True(updateNamespaceResponse.Value.ProvisioningState.Equals("Active", StringComparison.CurrentCultureIgnoreCase) ||
            updateNamespaceResponse.Value.ProvisioningState.Equals("Updating", StringComparison.CurrentCultureIgnoreCase));
            Assert.AreEqual(namespaceName, updateNamespaceResponse.Value.Name);
            // Get the updated namespace and also verify the Tags.
            getNamespaceResponse = await NamespacesOperations.GetAsync(resourceGroupName, namespaceName);
            Assert.NotNull(getNamespaceResponse);
            Assert.AreEqual(location, getNamespaceResponse.Value.Location);
            Assert.AreEqual(namespaceName, getNamespaceResponse.Value.Name);
            Assert.AreEqual(2, getNamespaceResponse.Value.Tags.Count);
            bool isContainKey = false;
            bool isContainValue = false;
            foreach (var tag in updateNamespaceParameter.Tags)
            {
                foreach (var key in getNamespaceResponse.Value.Tags)
                {
                    if (key.Key == tag.Key)
                    {
                        isContainKey = true;
                        break;
                    }
                }
                foreach (var value in getNamespaceResponse.Value.Tags)
                {
                    if (value.Value == tag.Value)
                    {
                        isContainValue = true;
                        break;
                    }
                }
                //Assert.Contains(getNamespaceResponse.Value.Tags, t => t.Key.Equals(tag.Key));
                //Assert.Contains(getNamespaceResponse.Value.Tags, t => t.Value.Equals(tag.Value));
            }
            Assert.True(isContainKey);
            Assert.True(isContainValue);
            DelayInTest(5);
            // Delete namespace
            await WaitForCompletionAsync(await NamespacesOperations.StartDeleteAsync(resourceGroupName, namespaceName));
        }
    }
}
