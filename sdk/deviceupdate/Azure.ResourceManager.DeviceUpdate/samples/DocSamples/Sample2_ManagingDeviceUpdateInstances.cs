// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Manage_Instances_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
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
        private ResourceGroupResource resourceGroup;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateInstances()
        {
            #region Snippet:Managing_Instances_CreateAnInstance
            // Create a new account
            string accountName = "myAccount";
            DeviceUpdateAccountData input1 = new DeviceUpdateAccountData(AzureLocation.WestUS2);
            ArmOperation<DeviceUpdateAccountResource> lro1 = await resourceGroup.GetDeviceUpdateAccounts().CreateOrUpdateAsync(WaitUntil.Completed, accountName, input1);
            DeviceUpdateAccountResource account = lro1.Value;
            // Get the instance collection from the specific account and create an instance
            string instanceName = "myInstance";
            DeviceUpdateInstanceData input2 = new DeviceUpdateInstanceData(AzureLocation.WestUS2);
            input2.IotHubs.Add(new DeviceUpdateIotHubSettings(new ResourceIdentifier("/subscriptions/.../resourceGroups/.../providers/Microsoft.Devices/IotHubs/...")));
            ArmOperation<DeviceUpdateInstanceResource> lro2 = await account.GetDeviceUpdateInstances().CreateOrUpdateAsync(WaitUntil.Completed, instanceName, input2);
            DeviceUpdateInstanceResource instance = lro2.Value;
            #endregion Snippet:Managing_Instances_CreateAnInstance
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListInstances()
        {
            #region Snippet:Managing_Instances_ListAllInstances
            // First we need to get the instance collection from the specific account
            DeviceUpdateAccountResource account = await resourceGroup.GetDeviceUpdateAccounts().GetAsync("myAccount");
            DeviceUpdateInstanceCollection instanceCollection = account.GetDeviceUpdateInstances();
            // With GetAllAsync(), we can get a list of the instances in the collection
            AsyncPageable<DeviceUpdateInstanceResource> response = instanceCollection.GetAllAsync();
            await foreach (DeviceUpdateInstanceResource instance in response)
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
            DeviceUpdateAccountResource account = await resourceGroup.GetDeviceUpdateAccounts().GetAsync("myAccount");
            DeviceUpdateInstanceCollection instanceCollection = account.GetDeviceUpdateInstances();
            // Now we can get the instance with GetAsync()
            DeviceUpdateInstanceResource instance = await instanceCollection.GetAsync("myInstance");
            // With AddTagAsync(), we can add tag to the instance
            instance = await instance.AddTagAsync("newTag", "newValue");
            #endregion Snippet:Managing_Instances_UpdateAnInstance
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteInstances()
        {
            #region Snippet:Managing_Instances_DeleteAnInstance
            // First we need to get the instance collection from the specific account
            DeviceUpdateAccountResource account = await resourceGroup.GetDeviceUpdateAccounts().GetAsync("myAccount");
            DeviceUpdateInstanceCollection instanceCollection = account.GetDeviceUpdateInstances();
            // Now we can get the instance with GetAsync()
            DeviceUpdateInstanceResource instance = await instanceCollection.GetAsync("myInstance");
            // With DeleteAsync(), we can delete the instance
            await instance.DeleteAsync(WaitUntil.Completed);
            #endregion Snippet:Managing_Instances_DeleteAnInstance
        }

        [SetUp]
        protected async Task initialize()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();

            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            // With the collection, we can create a new resource group with an specific name
            string rgName = "myRgName";
            AzureLocation location = AzureLocation.WestUS2;
            ArmOperation<ResourceGroupResource> lro = await rgCollection.CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
            ResourceGroupResource resourceGroup = lro.Value;

            this.resourceGroup = resourceGroup;
        }
    }
}
