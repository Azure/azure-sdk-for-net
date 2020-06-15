// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
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
        public async Task NamespaceCreateGetUpdateDelete()
        {
            var location = GetLocation();
            var resourceGroup = Recording.GenerateAssetName(Helper.ResourceGroupPrefix);
            await Helper.TryRegisterResourceGroupAsync(ResourceGroupsOperations, location.Result, resourceGroup);
            var namespaceName = Recording.GenerateAssetName(Helper.NamespacePrefix);
            var operationsResponse = Operations.ListAsync();
            var checkNameAvailable = NamespacesOperations.CheckNameAvailabilityAsync(new CheckNameAvailabilityParameter(namespaceName));
            var createNamespaceResponse = await NamespacesOperations.StartCreateOrUpdateAsync(resourceGroup, namespaceName,
                new EHNamespace()
                {
                    Location = location.Result
                }
                );
            var np = (await WaitForCompletionAsync(createNamespaceResponse)).Value;
            Assert.NotNull(createNamespaceResponse);
            Assert.AreEqual(np.Name,namespaceName);
            DelayInTest(60);
            //get the created namespace
            var getNamespaceResponse = await NamespacesOperations.GetAsync(resourceGroup, namespaceName);
            if (string.Compare(getNamespaceResponse.Value.ProvisioningState, "Succeeded", true) != 0)
                DelayInTest(10);
            getNamespaceResponse = await NamespacesOperations.GetAsync(resourceGroup, namespaceName);
            Assert.NotNull(getNamespaceResponse);
            Assert.AreEqual("Succeeded", getNamespaceResponse.Value.ProvisioningState,StringComparer.CurrentCultureIgnoreCase.ToString());
            Assert.AreEqual(location.Result, getNamespaceResponse.Value.Location);
            // Get all namespaces created within a resourceGroup
            var getAllNamespacesResponse =  NamespacesOperations.ListByResourceGroupAsync(resourceGroup);
            Assert.NotNull(getAllNamespacesResponse);
            //Assert.True(getAllNamespacesResponse.AsPages.c >= 1);
            bool isContainnamespaceName = false;
            bool isContainresourceGroup = false;
            var list = await getAllNamespacesResponse.ToEnumerableAsync();
            foreach (var name in list)
            {
                if (name.Name == namespaceName)
                {
                    isContainnamespaceName = true;
                }
            }
           foreach (var name in list)
            {
                if (name.Id.Contains(resourceGroup))
                {
                    isContainresourceGroup = true;
                    break;
                }
            }
            Assert.True(isContainnamespaceName);
            Assert.True(isContainresourceGroup);
            // Get all namespaces created within the subscription irrespective of the resourceGroup
            var getAllNpResponse = NamespacesOperations.ListAsync();
            Assert.NotNull(getAllNamespacesResponse);
            // Update namespace tags and make the namespace critical
            var updateNamespaceParameter = new EHNamespace()
            {
                Tags = new Dictionary<string, string>()
                        {
                            {"tag3", "value3"},
                            {"tag4", "value4"}
                        }
            };
            // Will uncomment the assertions once the service is deployed
            var updateNamespaceResponse = NamespacesOperations.UpdateAsync(resourceGroup, namespaceName, updateNamespaceParameter);
            Assert.NotNull(updateNamespaceResponse);
            // Get the updated namespace and also verify the Tags.
            getNamespaceResponse = await NamespacesOperations.GetAsync(resourceGroup, namespaceName);
            DelayInTest(15);
            Assert.NotNull(getNamespaceResponse);
            Assert.AreEqual(location.Result, getNamespaceResponse.Value.Location);
            Assert.AreEqual(namespaceName, getNamespaceResponse.Value.Name);
            Assert.AreEqual(2, getNamespaceResponse.Value.Tags.Count);
            bool IsContainKey = false;
            bool IsContainValue = false;
            foreach (var tag in updateNamespaceParameter.Tags)
            {
                foreach (var t in getNamespaceResponse.Value.Tags)
                {
                    if (t.Key == tag.Key)
                    {
                        IsContainKey = true;
                        break;
                    }
                }
                foreach (var t in getNamespaceResponse.Value.Tags)
                {
                    if (t.Value == tag.Value)
                    {
                        IsContainValue = true;
                        break;
                    }
                }
            }
            Assert.True(IsContainKey);
            Assert.True(IsContainValue);
            //delete namespace
            await WaitForCompletionAsync(await NamespacesOperations.StartDeleteAsync(resourceGroup, namespaceName));
        }
    }
}
