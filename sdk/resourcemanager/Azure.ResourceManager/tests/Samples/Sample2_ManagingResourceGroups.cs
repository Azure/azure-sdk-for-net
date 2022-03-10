﻿#region Snippet:Managing_Resource_Groups_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
#endregion
using NUnit.Framework;

namespace Azure.ResourceManager.Tests.Samples
{
    class Sample2_ManagingResourceGroups
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task SetUpWithDefaultSubscription()
        {
            #region Snippet:Managing_Resource_Groups_DefaultSubscription
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await client.GetDefaultSubscriptionAsync();
            #endregion Snippet:Managing_Resource_Groups_DefaultSubscription
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateResourceGroup()
        {
            #region Snippet:Managing_Resource_Groups_CreateAResourceGroup
            // First, initialize the ArmClient and get the default subscription
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            // Now we get a ResourceGroup collection for that subscription
            Subscription subscription = await client.GetDefaultSubscriptionAsync();
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();

            // With the collection, we can create a new resource group with an specific name
            string resourceGroupName = "myRgName";
            AzureLocation location = AzureLocation.WestUS2;
            ResourceGroupData resourceGroupData = new ResourceGroupData(location);
            ArmOperation<ResourceGroup> operation = await resourceGroups.CreateOrUpdateAsync(true, resourceGroupName, resourceGroupData);
            ResourceGroup resourceGroup = operation.Value;
            #endregion Snippet:Managing_Resource_Groups_CreateAResourceGroup
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GettingResourceGroupCollection()
        {
            #region Snippet:Managing_Resource_Groups_GetResourceGroupCollection

            ArmClient client = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await client.GetDefaultSubscriptionAsync();
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();

            // code omitted for brevity

            string resourceGroupName = "myRgName";
            ResourceGroup resourceGroup = await resourceGroups.GetAsync(resourceGroupName);
            #endregion Snippet:Managing_Resource_Groups_GetResourceGroupCollection
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListAllResourceGroups()
        {
            #region Snippet:Managing_Resource_Groups_ListAllResourceGroup
            // First, initialize the ArmClient and get the default subscription
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await client.GetDefaultSubscriptionAsync();
            // Now we get a ResourceGroup collection for that subscription
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
            // We can then iterate over this collection to get the resources in the collection
            await foreach (ResourceGroup resourceGroup in resourceGroups)
            {
                Console.WriteLine(resourceGroup.Data.Name);
            }
            #endregion Snippet:Managing_Resource_Groups_ListAllResourceGroup
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task UpdateAResourceGroup()
        {
            #region Snippet:Managing_Resource_Groups_UpdateAResourceGroup
            // Note: Resource group named 'myRgName' should exist for this example to work.
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await client.GetDefaultSubscriptionAsync();
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
            string resourceGroupName = "myRgName";
            ResourceGroup resourceGroup = await resourceGroups.GetAsync(resourceGroupName);
            resourceGroup = await resourceGroup.AddTagAsync("key", "value");
            #endregion Snippet:Managing_Resource_Groups_UpdateAResourceGroup
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteResourceGroup()
        {
            #region Snippet:Managing_Resource_Groups_DeleteResourceGroup
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await client.GetDefaultSubscriptionAsync();
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
            string resourceGroupName = "myRgName";
            ResourceGroup resourceGroup = await resourceGroups.GetAsync(resourceGroupName);
            await resourceGroup.DeleteAsync(true);
            #endregion Snippet:Managing_Resource_Groups_DeleteResourceGroup
        }
    }
}
