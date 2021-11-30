// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Manage_Instances_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.DeviceUpdate;
using Azure.ResourceManager.DeviceUpdate.Models;
#endregion Manage_Instances_Namespaces
using NUnit.Framework;

namespace Azure.ResourceManager.DeviceUpdate.Tests.Samples
{
    public class Sample2_ManagingDeviceUpdateInstances
    {
        private ResourceGroup resourceGroup;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateInstances()
        {
            #region Snippet:Managing_Instances_CreateAnInstance
            // Create a new account
            string accountName = "myAccount";
            DeviceUpdateAccountData input1 = new DeviceUpdateAccountData(Location.WestUS2);
            DeviceUpdateAccountCreateOperation lro1 = await resourceGroup.GetDeviceUpdateAccounts().CreateOrUpdateAsync(accountName, input1);
            DeviceUpdateAccount account = lro1.Value;
            // Get the instance collection from the specific account and create an instance
            string instanceName = "myInstance";
            DeviceUpdateInstanceData input2 = new DeviceUpdateInstanceData(Location.WestUS2);
            input2.IotHubs.Add(new IotHubSettings("/subscriptions/.../resourceGroups/.../providers/Microsoft.Devices/IotHubs/..."));
            DeviceUpdateInstanceCreateOperation lro2 = await account.GetDeviceUpdateInstances().CreateOrUpdateAsync(instanceName, input2);
            DeviceUpdateInstance instance = lro2.Value;
            #endregion Snippet:Managing_Instances_CreateAnInstance
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListInstances()
        {
            #region Snippet:Managing_Instances_ListAllInstances
            // First we need to get the instance collection from the specific account
            DeviceUpdateAccount account = await resourceGroup.GetDeviceUpdateAccounts().GetAsync("myAccount");
            DeviceUpdateInstanceCollection instanceCollection = account.GetDeviceUpdateInstances();
            // With GetAllAsync(), we can get a list of the instances in the collection
            AsyncPageable<DeviceUpdateInstance> response = instanceCollection.GetAllAsync();
            await foreach (DeviceUpdateInstance instance in response)
            {
                Console.WriteLine(instance.Data.Name);
            }
            #endregion Snippet:Managing_Instances_ListAllInstances
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task UpdateInstances()
        {
            #region Snippet:Managing_Instances_UpdateAnInstance
            // First we need to get the instance collection from the specific account
            DeviceUpdateAccount account = await resourceGroup.GetDeviceUpdateAccounts().GetAsync("myAccount");
            DeviceUpdateInstanceCollection instanceCollection = account.GetDeviceUpdateInstances();
            // Now we can get the instance with GetAsync()
            DeviceUpdateInstance instance = await instanceCollection.GetAsync("myInstance");
            // With UpdateAsync(), we can update the instance
            TagUpdateOptions updateOptions = new TagUpdateOptions();
            updateOptions.Tags.Add("newTag", "newValue");
            instance = await instance.UpdateAsync(updateOptions);
            #endregion Snippet:Managing_Instances_UpdateAnInstance
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteInstances()
        {
            #region Snippet:Managing_Instances_DeleteAnInstance
            // First we need to get the instance collection from the specific account
            DeviceUpdateAccount account = await resourceGroup.GetDeviceUpdateAccounts().GetAsync("myAccount");
            DeviceUpdateInstanceCollection instanceCollection = account.GetDeviceUpdateInstances();
            // Now we can get the instance with GetAsync()
            DeviceUpdateInstance instance = await instanceCollection.GetAsync("myInstance");
            // With DeleteAsync(), we can delete the instance
            await instance.DeleteAsync();
            #endregion Snippet:Managing_Instances_DeleteAnInstance
        }

        [SetUp]
        protected async Task initialize()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();

            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            // With the collection, we can create a new resource group with an specific name
            string rgName = "myRgName";
            Location location = Location.WestUS2;
            ResourceGroupCreateOrUpdateOperation lro = await rgCollection.CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
            ResourceGroup resourceGroup = lro.Value;

            this.resourceGroup = resourceGroup;
        }
    }
}
