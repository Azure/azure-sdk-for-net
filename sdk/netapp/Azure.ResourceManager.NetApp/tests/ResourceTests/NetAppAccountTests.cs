// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetApp.Models;
using Azure.ResourceManager.NetApp.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using FluentAssertions;

namespace Azure.ResourceManager.NetApp.Tests
{
    public class NetAppAccountTests: NetAppTestBase
    {
        private const string namePrefix = "testNetAppNetSDKmgmt";
        public static new AzureLocation DefaultLocation = "eastus2euap";

        public NetAppAccountTests(bool isAsync) : base(isAsync)
        {
        }

        [TearDown]
        public async Task ClearNetAppAccounts()
        {
            //remove all NetApp accounts under current resource group
            if (_resourceGroup != null)
            {
                NetAppAccountCollection netAppAccountCollection = _resourceGroup.GetNetAppAccounts();
                AsyncPageable<NetAppAccountResource> netAppAccountList = netAppAccountCollection.GetAllAsync();
                await foreach (NetAppAccountResource account in netAppAccountList)
                {
                    await account.DeleteAsync(WaitUntil.Completed);
                }
                _resourceGroup = null;
            }
        }

        [Test]
        [RecordedTest]
        public async Task NetAppAccountGetOperations()
        {
            ArmRestApiCollection operationCollection = DefaultSubscription.GetArmRestApis("Microsoft.NetApp");
            var apiList =  operationCollection.GetAllAsync();
            await LiveDelay(200);
            int count = 0;
            await foreach (var api in apiList)
            {
                count++;
            }
            Assert.IsTrue(count > 1);
        }

        [RecordedTest]
        public async Task CreateDeleteNetAppAccount()
        {
            //create NetApp account
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = await CreateValidAccountNameAsync(_accountNamePrefix, _resourceGroup, DefaultLocation);
            NetAppAccountCollection netAppAccountCollection = _resourceGroup.GetNetAppAccounts();
            NetAppAccountResource account1 = (await netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultNetAppAccountParameters())).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyNetAppAccountProperties(account1, true);
            AssertNetAppAccountEqual(account1, await account1.GetAsync());

            //validate if created successfully
            NetAppAccountResource account2 = await netAppAccountCollection.GetAsync(accountName);
            VerifyNetAppAccountProperties(account2, true);
            AssertNetAppAccountEqual(account1, account2);
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await netAppAccountCollection.GetAsync(accountName + "1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await netAppAccountCollection.ExistsAsync(accountName));
            Assert.IsFalse(await netAppAccountCollection.ExistsAsync(accountName + "1"));

            //delete storage account
            await account1.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            Assert.IsFalse(await netAppAccountCollection.ExistsAsync(accountName));
            exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await netAppAccountCollection.GetAsync(accountName); });
            Assert.AreEqual(404, exception.Status);
        }

        [RecordedTest]
        public async Task CreateDeleteNetAppAccountWithActiveDirectory()
        {
            //create NetApp account
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = await CreateValidAccountNameAsync(_accountNamePrefix, _resourceGroup, AzureLocation.NorthEurope);
            NetAppAccountCollection netAppAccountCollection = _resourceGroup.GetNetAppAccounts();
            NetAppAccountResource account1 = (await netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultNetAppAccountParameters(activeDirectory: ActiveDirectory1, location: AzureLocation.NorthEurope))).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyNetAppAccountProperties(account1, true, location: AzureLocation.NorthEurope);
            AssertNetAppAccountEqual(account1, await account1.GetAsync());
            Assert.IsNotEmpty(account1.Data.ActiveDirectories);
            Assert.NotNull(account1.Data.ActiveDirectories[0]);

            //validate if created successfully
            NetAppAccountResource account2 = await netAppAccountCollection.GetAsync(accountName);
            VerifyNetAppAccountProperties(account2, true, location: AzureLocation.NorthEurope);
            AssertNetAppAccountEqual(account1, account2);
            //Validate ActiveDirectory
            Assert.IsNotEmpty(account2.Data.ActiveDirectories);
            Assert.NotNull(account2.Data.ActiveDirectories[0]);
            account2.Data.ActiveDirectories[0].Should().BeEquivalentTo(account1.Data.ActiveDirectories[0]);

            //remove ad
            account1.Data.ActiveDirectories.Clear();
            account1 = (await netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, account1.Data)).Value;
            Assert.IsEmpty(account1.Data.ActiveDirectories);

            //delete NetApp account
            await account1.DeleteAsync(WaitUntil.Completed);
            //validate if deleted successfully
            Assert.IsFalse(await netAppAccountCollection.ExistsAsync(accountName));
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await netAppAccountCollection.GetAsync(accountName); });
            Assert.AreEqual(404, exception.Status);
        }

        [RecordedTest]
        public async Task UpdateNetAppAccountWithPut()
        {
            //create NetApp account
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = await CreateValidAccountNameAsync(_accountNamePrefix, _resourceGroup, DefaultLocation);
            NetAppAccountCollection netAppAccountCollection = _resourceGroup.GetNetAppAccounts();
            NetAppAccountResource account1 = (await netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultNetAppAccountParameters())).Value;
            VerifyNetAppAccountProperties(account1, true);

            //update
            var keyValue = new KeyValuePair<string, string>("Tag2", "value2");
            account1.Data.Tags.Add(keyValue);

            account1 = (await netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, account1.Data)).Value;
            account1.Data.Tags.Should().Contain(keyValue);

            // validate
            NetAppAccountResource account2 = await netAppAccountCollection.GetAsync(accountName);
            account2.Data.Tags.Should().Contain(keyValue);
        }

        [RecordedTest]
        public async Task UpdateNetAppAccount()
        {
            //create NetApp account
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = await CreateValidAccountNameAsync(_accountNamePrefix, _resourceGroup, DefaultLocation);
            NetAppAccountCollection netAppAccountCollection = _resourceGroup.GetNetAppAccounts();
            NetAppAccountResource account1 = (await netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultNetAppAccountParameters(location:DefaultLocation))).Value;
            VerifyNetAppAccountProperties(account1, true, location:DefaultLocation);

            //update

            NetAppAccountPatch parameters = new(DefaultLocation);
            var keyValue = new KeyValuePair<string, string>("Tag2", "value2");
            parameters.Tags.Add(keyValue);

            account1 = (await account1.UpdateAsync(WaitUntil.Completed, parameters)).Value;
            account1.Data.Tags.Should().Contain(keyValue);

            // validate
            NetAppAccountResource account2 = await netAppAccountCollection.GetAsync(accountName);
            account2.Data.Tags.Should().Contain(keyValue);

            //update encryption, placeholder will be added in api-version 2022-05-01
            //parameters.Encryption = new AccountEncryption(KeySource.MicrosoftNetApp)
            //{
            //    Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } }
            //};
            //account1 = await account1.UpdateAsync(parameters);
            //Assert.NotNull(account1.Data.Encryption);
        }

        [RecordedTest]
        public async Task GetAllNetAppAccountsByResourceGroup()
        {
            //create two NetApp accounts
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName1 = await CreateValidAccountNameAsync(_accountNamePrefix, _resourceGroup, DefaultLocation);
            string accountName2 = await CreateValidAccountNameAsync(_accountNamePrefix, _resourceGroup, DefaultLocation);
            NetAppAccountCollection netAppAccountCollection = _resourceGroup.GetNetAppAccounts();
            NetAppAccountResource account1 = (await netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName1, GetDefaultNetAppAccountParameters())).Value;
            NetAppAccountResource account2 = (await netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName2, GetDefaultNetAppAccountParameters())).Value;

            //validate two NetApp accounts
            int count = 0;
            NetAppAccountResource account3 = null;
            NetAppAccountResource account4 = null;
            await foreach (NetAppAccountResource account in netAppAccountCollection.GetAllAsync())
            {
                count++;
                if (account.Id.Name == accountName1)
                    account3 = account;
                if (account.Id.Name == accountName2)
                    account4 = account;
            }
            Assert.AreEqual(count, 2);
            VerifyNetAppAccountProperties(account3, true);
            VerifyNetAppAccountProperties(account4, true);
        }

        [Ignore("ARM issue with nextLink ignore temporarly")]
        [RecordedTest]
        public async Task GetAllNetAppAccountsBySubscription()
        {
            //create 2 resource groups and 2 NetApp accounts
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName1 = await CreateValidAccountNameAsync(_accountNamePrefix, _resourceGroup, DefaultLocation);

            NetAppAccountCollection netAppAccountCollection = _resourceGroup.GetNetAppAccounts();
            NetAppAccountResource account1 = (await netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName1, GetDefaultNetAppAccountParameters())).Value;

            ResourceGroupResource resourceGroup2 = await CreateResourceGroupAsync();
            string accountName2 = await CreateValidAccountNameAsync(_accountNamePrefix, resourceGroup2, DefaultLocation);
            NetAppAccountCollection netAppAccountCollectionRG2 = resourceGroup2.GetNetAppAccounts();
            NetAppAccountResource account2 = (await netAppAccountCollectionRG2.CreateOrUpdateAsync(WaitUntil.Completed, accountName2, GetDefaultNetAppAccountParameters())).Value;

            //validate two NetApp accounts
            int count = 0;
            NetAppAccountResource account3 = null;
            NetAppAccountResource account4 = null;
            await foreach (NetAppAccountResource account in DefaultSubscription.GetNetAppAccountsAsync())
            {
                count++;
                if (account.Id.Name == accountName1)
                    account3 = account;
                if (account.Id.Name == accountName2)
                    account4 = account;
            }
            VerifyNetAppAccountProperties(account3, true);
            VerifyNetAppAccountProperties(account4, true);
            Assert.AreEqual(account1.Id.ResourceGroupName, _resourceGroup.Id.Name);
            Assert.AreEqual(account2.Id.ResourceGroupName, resourceGroup2.Id.Name);

            await account1.DeleteAsync(WaitUntil.Completed);
            await account2.DeleteAsync(WaitUntil.Completed);
        }
    }
}
