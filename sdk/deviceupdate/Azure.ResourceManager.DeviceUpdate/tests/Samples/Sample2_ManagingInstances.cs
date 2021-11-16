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
    public class Sample2_ManagingInstances
    {
        private ResourceGroup resourceGroup;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateInstances()
        {
            #region Snippet:Managing_Instances_CreateAnInstance
            // Create a new account
            string accountName = "myAccount";
            AccountData input1 = new AccountData(Location.WestUS2);
            AccountCreateOperation lro1 = await resourceGroup.GetAccounts().CreateOrUpdateAsync(accountName, input1);
            Account account = lro1.Value;
            // Get the instance collection from the specific account and create an instance
            string instanceName = "myInstance";
            InstanceData input2 = new InstanceData(Location.WestUS2);
            input2.IotHubs.Add(new IotHubSettings("/subscriptions/.../resourceGroups/.../providers/Microsoft.Devices/IotHubs/..."));
            InstanceCreateOperation lro2 = await account.GetInstances().CreateOrUpdateAsync(instanceName, input2);
            Instance instance = lro2.Value;
            #endregion Snippet:Managing_Instances_CreateAnInstance
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListInstances()
        {
            #region Snippet:Managing_Instances_ListAllInstances
            // First we need to get the instance collection from the specific account
            Account account = await resourceGroup.GetAccounts().GetAsync("myAccount");
            InstanceCollection instanceCollection = account.GetInstances();
            // With GetAllAsync(), we can get a list of the instances in the collection
            AsyncPageable<Instance> response = instanceCollection.GetAllAsync();
            await foreach (Instance instance in response)
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
            Account account = await resourceGroup.GetAccounts().GetAsync("myAccount");
            InstanceCollection instanceCollection = account.GetInstances();
            // Now we can get the instance with GetAsync()
            Instance instance = await instanceCollection.GetAsync("myInstance");
            // With UpdateAsync(), we can update the instance
            TagUpdate updateParameters = new TagUpdate();
            updateParameters.Tags.Add("newTag", "newValue");
            instance = await instance.UpdateAsync(updateParameters);
            #endregion Snippet:Managing_Instances_UpdateAnInstance
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteInstances()
        {
            #region Snippet:Managing_Instances_DeleteAnInstance
            // First we need to get the instance collection from the specific account
            Account account = await resourceGroup.GetAccounts().GetAsync("myAccount");
            InstanceCollection instanceCollection = account.GetInstances();
            // Now we can get the instance with GetAsync()
            Instance instance = await instanceCollection.GetAsync("myInstance");
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
