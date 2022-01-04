#region Snippet:Managing_Resource_Groups_Namespaces
using System;
using System.Threading.Tasks;
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
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            #endregion Snippet:Managing_Resource_Groups_DefaultSubscription
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateResourceGroup()
        {
            #region Snippet:Managing_Resource_Groups_CreateAResourceGroup
            // First, initialize the ArmClient and get the default subscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            // Now we get a ResourceGroup collection for that subscription
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

            // With the collection, we can create a new resource group with an specific name
            string rgName = "myRgName";
            Location location = Location.WestUS2;
            ResourceGroupData rgData = new ResourceGroupData(location);
            ResourceGroupCreateOrUpdateOperation operation = await rgCollection.CreateOrUpdateAsync(rgName, rgData);
            ResourceGroup resourceGroup = operation.Value;
            #endregion Snippet:Managing_Resource_Groups_CreateAResourceGroup
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GettingResourceGroupCollection()
        {
            #region Snippet:Managing_Resource_Groups_GetResourceGroupCollection

            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

            // code omitted for brevity

            string rgName = "myRgName";
#if !SNIPPET
            //Check if "myRgName" exists, if not, create it first or run CreateResourceGroup()
            ResourceGroup rg = await subscription.GetResourceGroups().GetIfExistsAsync(rgName);
            if (rg == null)
            {
                Location location = Location.WestUS2;
                ResourceGroupData rgData = new ResourceGroupData(location);
                _ = await rgCollection.CreateOrUpdateAsync(rgName, rgData);
            }
#endif
            ResourceGroup resourceGroup = await rgCollection.GetAsync(rgName);
            #endregion Snippet:Managing_Resource_Groups_GetResourceGroupCollection
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListAllResourceGroups()
        {
            #region Snippet:Managing_Resource_Groups_ListAllResourceGroup
            // First, initialize the ArmClient and get the default subscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            // Now we get a ResourceGroup collection for that subscription
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            // With GetAllAsync(), we can get a list of the resources in the collection
            await foreach (ResourceGroup rg in rgCollection.GetAllAsync())
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
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            string rgName = "myRgName";
#if !SNIPPET
            //Check if 'myRgName' exists, if not, create it first or run CreateResourceGroup()
            ResourceGroup rg = await subscription.GetResourceGroups().GetIfExistsAsync(rgName);
            if (rg == null)
            {
                Location location = Location.WestUS2;
                ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
                ResourceGroupData rgData = new ResourceGroupData(location);
                _ = await rgCollection.CreateOrUpdateAsync(rgName, rgData);
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
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            string rgName = "myRgName";
            ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
            await resourceGroup.DeleteAsync();
            #endregion Snippet:Managing_Resource_Groups_DeleteResourceGroup
        }
    }
}
