// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Manage_Accounts_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.DeviceUpdate;
using Azure.ResourceManager.DeviceUpdate.Models;
#endregion Manage_Accounts_Namespaces
using NUnit.Framework;

namespace Azure.ResourceManager.DeviceUpdate.Tests.Samples
{
    public class Sample1_ManagingDeviceUpdateAccounts
    {
        private SubscriptionResource subscription;
        private ResourceGroupResource resourceGroup;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateAccounts()
        {
            #region Snippet:Managing_Accounts_CreateAnAccount
            // Get the account collection from the specific resource group and create an account
            string accountName = "myAccount";
            DeviceUpdateAccountData input = new DeviceUpdateAccountData(AzureLocation.WestUS2);
            ArmOperation<DeviceUpdateAccountResource> lro = await resourceGroup.GetDeviceUpdateAccounts().CreateOrUpdateAsync(WaitUntil.Completed, accountName, input);
            DeviceUpdateAccountResource account = lro.Value;
            #endregion Snippet:Managing_Accounts_CreateAnAccount
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListAccounts()
        {
            #region Snippet:Managing_Accounts_ListAllAccounts
            // First we need to get the account collection from the specific resource group
            DeviceUpdateAccountCollection accountCollection = resourceGroup.GetDeviceUpdateAccounts();
            // With GetAllAsync(), we can get a list of the accounts in the collection
            AsyncPageable<DeviceUpdateAccountResource> response = accountCollection.GetAllAsync();
            await foreach (DeviceUpdateAccountResource account in response)
            {
                Console.WriteLine(account.Data.Name);
            }
            //We can also list all accounts in the subscription
            response = subscription.GetDeviceUpdateAccountsAsync();
            await foreach (DeviceUpdateAccountResource account in response)
            {
                Console.WriteLine(account.Data.Name);
            }
            #endregion Snippet:Managing_Accounts_ListAllAccounts
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task UpdateAccounts()
        {
            #region Snippet:Managing_Accounts_UpdateAnAccount
            // First we need to get the account collection from the specific resource group
            DeviceUpdateAccountCollection accountCollection = resourceGroup.GetDeviceUpdateAccounts();
            // Now we can get the account with GetAsync()
            DeviceUpdateAccountResource account = await accountCollection.GetAsync("myAccount");
            // With UpdateAsync(), we can update the account
            DeviceUpdateAccountPatch updateOptions = new DeviceUpdateAccountPatch()
            {
                Location = AzureLocation.WestUS2,
                Identity = new ManagedServiceIdentity(ResourceManager.Models.ManagedServiceIdentityType.None)
            };
            ArmOperation<DeviceUpdateAccountResource> lro = await account.UpdateAsync(WaitUntil.Completed, updateOptions);
            account = lro.Value;
            #endregion Snippet:Managing_Accounts_UpdateAnAccount
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteAccounts()
        {
            #region Snippet:Managing_Accounts_DeleteAnAccount
            // First we need to get the account collection from the specific resource group
            DeviceUpdateAccountCollection accountCollection = resourceGroup.GetDeviceUpdateAccounts();
            // Now we can get the account with GetAsync()
            DeviceUpdateAccountResource account = await accountCollection.GetAsync("myAccount");
            // With DeleteAsync(), we can delete the account
            await account.DeleteAsync(WaitUntil.Completed);
            #endregion Snippet:Managing_Accounts_DeleteAnAccount
        }

        [SetUp]
        protected async Task initialize()
        {
            #region Snippet:Readme_DefaultSubscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            #endregion

            #region Snippet:Readme_GetResourceGroupCollection
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            // With the collection, we can create a new resource group with a specific name
            string rgName = "myRgName";
            AzureLocation location = AzureLocation.WestUS2;
            ArmOperation<ResourceGroupResource> lro = await rgCollection.CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
            ResourceGroupResource resourceGroup = lro.Value;
            #endregion

            this.subscription = subscription;
            this.resourceGroup = resourceGroup;
        }
    }
}
