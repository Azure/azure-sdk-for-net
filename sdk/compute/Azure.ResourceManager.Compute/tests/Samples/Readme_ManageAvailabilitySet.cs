// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.Samples
{
    public class Readme_ManageAvailabilitySet
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateAvailabilitySet()
        {
            // First, initialize the ArmClient and get the default subscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            // Now we get a ResourceGroup collection for that subscription
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

            // With the collection, we can create a new resource group with an specific name
            string rgName = "myRgName";
            Location location = Location.WestUS2;
            ResourceGroupCreateOrUpdateOperation rgLro = await rgCollection.CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
            ResourceGroup resourceGroup = rgLro.Value;
            #region Snippet:Managing_Availability_Set_CreateAnAvailabilitySet
            AvailabilitySetCollection availabilitySetCollection = resourceGroup.GetAvailabilitySets();
            string availabilitySetName = "myAvailabilitySet";
            AvailabilitySetData input = new AvailabilitySetData(location);
            AvailabilitySetCreateOrUpdateOperation lro = await availabilitySetCollection.CreateOrUpdateAsync(availabilitySetName, input);
            AvailabilitySet availabilitySet = lro.Value;
            #endregion Snippet:Managing_Availability_Set_CreateAnAvailabilitySet
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task UpdateAvailabilitySet()
        {
            #region Snippet:Managing_Availability_Set_UpdateAnAvailabilitySet
            // First, initialize the ArmClient and get the default subscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            // Now we get a ResourceGroup collection for that subscription
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

            // With the collection, we can create a new resource group with an specific name
            string rgName = "myRgName";
            ResourceGroup resourceGroup = await rgCollection.GetAsync(rgName);
            AvailabilitySetCollection availabilitySetCollection = resourceGroup.GetAvailabilitySets();
            string availabilitySetName = "myAvailabilitySet";
            AvailabilitySet availabilitySet = await availabilitySetCollection.GetAsync(availabilitySetName);
            // availabilitySet is an AvailabilitySet instance created above
            AvailabilitySetUpdate update = new AvailabilitySetUpdate()
            {
                PlatformFaultDomainCount = 3
            };
            AvailabilitySet updatedAvailabilitySet = await availabilitySet.UpdateAsync(update);
            #endregion Snippet:Managing_Availability_Set_UpdateAnAvailabilitySet
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteAvailabilitySet()
        {
            #region Snippet:Managing_Availability_Set_DeleteAnAvailabilitySet
            // First, initialize the ArmClient and get the default subscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            // Now we get a ResourceGroup collection for that subscription
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

            // With the collection, we can create a new resource group with an specific name
            string rgName = "myRgName";
            ResourceGroup resourceGroup = await rgCollection.GetAsync(rgName);
            AvailabilitySetCollection availabilitySetCollection = resourceGroup.GetAvailabilitySets();
            string availabilitySetName = "myAvailabilitySet";
            AvailabilitySet availabilitySet = await availabilitySetCollection.GetAsync(availabilitySetName);
            // delete the availability set
            await availabilitySet.DeleteAsync();
            #endregion Snippet:Managing_Availability_Set_DeleteAnAvailabilitySet
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CheckIfExists()
        {
            #region Snippet:Managing_Availability_Set_CheckIfExistsForAvailabilitySet
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

            string rgName = "myRgName";
            ResourceGroup resourceGroup = await rgCollection.GetAsync(rgName);
            string availabilitySetName = "myAvailabilitySet";
            bool exists = await resourceGroup.GetAvailabilitySets().CheckIfExistsAsync(availabilitySetName);

            if (exists)
            {
                Console.WriteLine($"Availability Set {availabilitySetName} exists.");
            }
            else
            {
                Console.WriteLine($"Availability Set {availabilitySetName} does not exist.");
            }
            #endregion Snippet:Managing_Availability_Set_CheckIfExistsForAvailabilitySet
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetAllAvailabilitySets()
        {
            #region Snippet:Managing_Availability_Set_GetAllAvailabilitySets
            // First, initialize the ArmClient and get the default subscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            // Now we get a ResourceGroup collection for that subscription
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

            string rgName = "myRgName";
            ResourceGroup resourceGroup = await rgCollection.GetAsync(rgName);
            // First, we get the availability set collection from the resource group
            AvailabilitySetCollection availabilitySetCollection = resourceGroup.GetAvailabilitySets();
            // With GetAllAsync(), we can get a list of the availability sets in the collection
            AsyncPageable<AvailabilitySet> response = availabilitySetCollection.GetAllAsync();
            await foreach (AvailabilitySet availabilitySet in response)
            {
                Console.WriteLine(availabilitySet.Data.Name);
            }
            #endregion Snippet:Managing_Availability_Set_GetAllAvailabilitySets
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetIfExistsAvailabilitySet()
        {
            #region Snippet:Managing_Availability_Set_GetIfExistsForAvailabilitySet
            // First, initialize the ArmClient and get the default subscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            // Now we get a ResourceGroup collection for that subscription
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

            string rgName = "myRgName";
            ResourceGroup resourceGroup = await rgCollection.GetAsync(rgName);
            AvailabilitySetCollection availabilitySetCollection = resourceGroup.GetAvailabilitySets();
            string availabilitySetName = "myAvailabilitySet";
            AvailabilitySet availabilitySet = await availabilitySetCollection.GetIfExistsAsync(availabilitySetName);

            if (availabilitySet == null)
            {
                Console.WriteLine($"Availability Set {availabilitySetName} does not exist.");
                return;
            }

            // At this point, we are sure that availabilitySet is a not null Availability Set, so we can use this object to perform any operations we want.

            #endregion Snippet:Managing_Availability_Set_GetIfExistsForAvailabilitySet
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task AddTagToAvailabilitySet()
        {
            #region Snippet:Managing_Availability_Set_AddTagAvailabilitySet
            // First, initialize the ArmClient and get the default subscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            // Now we get a ResourceGroup collection for that subscription
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

            string rgName = "myRgName";
            ResourceGroup resourceGroup = await rgCollection.GetAsync(rgName);
            AvailabilitySetCollection availabilitySetCollection = resourceGroup.GetAvailabilitySets();
            string availabilitySetName = "myAvailabilitySet";
            AvailabilitySet availabilitySet = await availabilitySetCollection.GetAsync(availabilitySetName);
            // add a tag on this availabilitySet
            AvailabilitySet updatedAvailabilitySet = await availabilitySet.AddTagAsync("key", "value");
            #endregion Snippet:Managing_Availability_Set_AddTagAvailabilitySet
        }
    }
}
