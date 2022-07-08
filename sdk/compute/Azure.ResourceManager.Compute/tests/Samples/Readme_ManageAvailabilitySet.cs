// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
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
            // Now we get a ResourceGroupResource collection for that subscription
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

            // With the collection, we can create a new resource group with an specific name
            string rgName = "myRgName";
            AzureLocation location = AzureLocation.WestUS2;
            ArmOperation<ResourceGroupResource> rgLro = await rgCollection.CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
            ResourceGroupResource resourceGroup = rgLro.Value;
            #region Snippet:Managing_Availability_Set_CreateAnAvailabilitySet
            AvailabilitySetCollection availabilitySetCollection = resourceGroup.GetAvailabilitySets();
            string availabilitySetName = "myAvailabilitySet";
            AvailabilitySetData input = new AvailabilitySetData(location);
            ArmOperation<AvailabilitySetResource> lro = await availabilitySetCollection.CreateOrUpdateAsync(WaitUntil.Completed, availabilitySetName, input);
            AvailabilitySetResource availabilitySet = lro.Value;
            #endregion Snippet:Managing_Availability_Set_CreateAnAvailabilitySet
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task UpdateAvailabilitySet()
        {
            #region Snippet:Managing_Availability_Set_UpdateAnAvailabilitySet
            // First, initialize the ArmClient and get the default subscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            // Now we get a ResourceGroupResource collection for that subscription
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

            // With the collection, we can create a new resource group with an specific name
            string rgName = "myRgName";
            ResourceGroupResource resourceGroup = await rgCollection.GetAsync(rgName);
            AvailabilitySetCollection availabilitySetCollection = resourceGroup.GetAvailabilitySets();
            string availabilitySetName = "myAvailabilitySet";
            AvailabilitySetResource availabilitySet = await availabilitySetCollection.GetAsync(availabilitySetName);
            // availabilitySet is an AvailabilitySetResource instance created above
            AvailabilitySetPatch update = new AvailabilitySetPatch()
            {
                PlatformFaultDomainCount = 3
            };
            AvailabilitySetResource updatedAvailabilitySet = await availabilitySet.UpdateAsync(update);
            #endregion Snippet:Managing_Availability_Set_UpdateAnAvailabilitySet
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteAvailabilitySet()
        {
            #region Snippet:Managing_Availability_Set_DeleteAnAvailabilitySet
            // First, initialize the ArmClient and get the default subscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            // Now we get a ResourceGroupResource collection for that subscription
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

            // With the collection, we can create a new resource group with an specific name
            string rgName = "myRgName";
            ResourceGroupResource resourceGroup = await rgCollection.GetAsync(rgName);
            AvailabilitySetCollection availabilitySetCollection = resourceGroup.GetAvailabilitySets();
            string availabilitySetName = "myAvailabilitySet";
            AvailabilitySetResource availabilitySet = await availabilitySetCollection.GetAsync(availabilitySetName);
            // delete the availability set
            await availabilitySet.DeleteAsync(WaitUntil.Completed);
            #endregion Snippet:Managing_Availability_Set_DeleteAnAvailabilitySet
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CheckIfExists()
        {
            #region Snippet:Managing_Availability_Set_CheckIfExistsForAvailabilitySet
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

            string rgName = "myRgName";
            ResourceGroupResource resourceGroup = await rgCollection.GetAsync(rgName);
            string availabilitySetName = "myAvailabilitySet";
            bool exists = await resourceGroup.GetAvailabilitySets().ExistsAsync(availabilitySetName);

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
            // Now we get a ResourceGroupResource collection for that subscription
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

            string rgName = "myRgName";
            ResourceGroupResource resourceGroup = await rgCollection.GetAsync(rgName);
            // First, we get the availability set collection from the resource group
            AvailabilitySetCollection availabilitySetCollection = resourceGroup.GetAvailabilitySets();
            // With GetAllAsync(), we can get a list of the availability sets in the collection
            AsyncPageable<AvailabilitySetResource> response = availabilitySetCollection.GetAllAsync();
            await foreach (AvailabilitySetResource availabilitySet in response)
            {
                Console.WriteLine(availabilitySet.Data.Name);
            }
            #endregion Snippet:Managing_Availability_Set_GetAllAvailabilitySets
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task AddTagToAvailabilitySet()
        {
            #region Snippet:Managing_Availability_Set_AddTagAvailabilitySet
            // First, initialize the ArmClient and get the default subscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            // Now we get a ResourceGroupResource collection for that subscription
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

            string rgName = "myRgName";
            ResourceGroupResource resourceGroup = await rgCollection.GetAsync(rgName);
            AvailabilitySetCollection availabilitySetCollection = resourceGroup.GetAvailabilitySets();
            string availabilitySetName = "myAvailabilitySet";
            AvailabilitySetResource availabilitySet = await availabilitySetCollection.GetAsync(availabilitySetName);
            // add a tag on this availabilitySet
            AvailabilitySetResource updatedAvailabilitySet = await availabilitySet.AddTagAsync("key", "value");
            #endregion Snippet:Managing_Availability_Set_AddTagAvailabilitySet
        }
    }
}
