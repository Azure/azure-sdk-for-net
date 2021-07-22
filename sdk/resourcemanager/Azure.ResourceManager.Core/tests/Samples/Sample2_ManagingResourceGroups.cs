﻿#region Snippet:Managing_Resource_Groups_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Core;
#endregion
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests.Samples
{
    class Sample2_ManagingResourceGroups
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void SetUpWithDefaultSubscription()
        {
            #region Snippet:Managing_Resource_Groups_DefaultSubscription
            var armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.DefaultSubscription;
            #endregion Snippet:Managing_Resource_Groups_DefaultSubscription
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateResourceGroup()
        {
            #region Snippet:Managing_Resource_Groups_CreateAResourceGroup
            // First, initialize the ArmClient and get the default subscription
            var armClient = new ArmClient(new DefaultAzureCredential());
            // Now we get a ResourceGroup container for that subscription
            Subscription subscription = armClient.DefaultSubscription;
            ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
            
            // With the container, we can create a new resource group with an specific name
            string rgName = "myRgName";
            Location location = Location.WestUS2;
            ResourceGroup resourceGroup = await rgContainer.Construct(location).CreateOrUpdateAsync(rgName);
            #endregion Snippet:Managing_Resource_Groups_CreateAResourceGroup
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GettingResourceGroupContainer()
        {
            #region Snippet:Managing_Resource_Groups_GetResourceGroupContainer
            var armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.DefaultSubscription;
            ResourceGroupContainer rgContainer = subscription.GetResourceGroups();

            // code omitted for brevity

            string rgName = "myRgName";
#if !SNIPPET
            //Check if "myRgName" exists, if not, create it first or run CreateResourceGroup()
            var rg = await subscription.GetResourceGroups().TryGetAsync(rgName);
            if (rg == null)
            {
                Location location = Location.WestUS2;
                _ = await rgContainer.Construct(location).CreateOrUpdateAsync(rgName);
            }
#endif
            ResourceGroup resourceGroup = await rgContainer.GetAsync(rgName);
            #endregion Snippet:Managing_Resource_Groups_GetResourceGroupContainer
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListAllResourceGroups()
        {
            #region Snippet:Managing_Resource_Groups_ListAllResourceGroup
            // First, initialize the ArmClient and get the default subscription
            var armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.DefaultSubscription;
            // Now we get a ResourceGroup container for that subscription
            ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
            // With ListAsync(), we can get a list of the resources in the container
            AsyncPageable<ResourceGroup> response = rgContainer.ListAsync();
            await foreach (ResourceGroup rg in response)
            {
                Console.WriteLine(rg.Data.Name);
            }
            #endregion Snippet:Managing_Resource_Groups_ListAllResourceGroup
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task UpdateAResourceGroup()
        {
            #region Snippet:Managing_Resource_Groups_UpdateAResourceGroup
            // Note: Resource group named 'myRgName' should exist for this example to work.
            var armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.DefaultSubscription;
            string rgName = "myRgName";
#if !SNIPPET
            //Check if 'myRgName' exists, if not, create it first or run CreateResourceGroup()
            var rg = await subscription.GetResourceGroups().TryGetAsync(rgName);
            if (rg == null)
            {
                Location location = Location.WestUS2;
                var rgContainer = subscription.GetResourceGroups();
                _ = await rgContainer.Construct(location).CreateOrUpdateAsync(rgName);
            }
#endif
            ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
            resourceGroup = await resourceGroup.AddTagAsync("key", "value");
            #endregion Snippet:Managing_Resource_Groups_UpdateAResourceGroup
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteResourceGroup()
        {
            #region Snippet:Managing_Resource_Groups_DeleteResourceGroup
            var armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.DefaultSubscription;
            string rgName = "myRgName";
            ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
            await resourceGroup.DeleteAsync();
            #endregion Snippet:Managing_Resource_Groups_DeleteResourceGroup
        }
    }
}
