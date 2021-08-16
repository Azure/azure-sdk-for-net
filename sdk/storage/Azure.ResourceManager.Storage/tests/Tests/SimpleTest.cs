// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Storage.Tests.Tests.Helpers;
namespace Azure.ResourceManager.Storage.Tests
{
    [TestFixture(true)]
    public class SimpleTest:StorageTestBase
    {
        public SimpleTest(bool async) : base(async)
        {
        }

        [Test]
        public async Task simpletest(){
            int a = 0;
            var b=TestEnvironment;
            List<StorageAccount> accounts =await DefaultSubscription.GetStorageAccountsAsync().ToEnumerableAsync();
            foreach (StorageAccount account in accounts)
            {
                Console.WriteLine(account.Id.Name);
            }
            a++;
        }

        [Test]
        public async Task DeletedAccountList()
        {
            List<DeletedAccount> list = await GetDeletedAccount();
            foreach (DeletedAccount account in list)
            {
                Console.WriteLine(account.Name);
            }
        }

        [Test]
        public async Task ClearLegalHold()
        {
            //DefaultSubscription.CheckStorageAccountNameNameAvailability
            ResourceGroupContainer gc = DefaultSubscription.GetResourceGroups();
            ResourceGroup g = await gc.GetAsync("teststorageRG-7177");
            StorageAccountContainer ac = g.GetStorageAccounts();
            StorageAccount a =await ac.GetAsync("storage1113");
            BlobServiceContainer bsc = a.GetBlobServices();
            BlobService bs = await bsc.GetAsync("default");
            BlobContainerContainer bc = bs.GetBlobContainers();
            BlobContainer b =await  bc.GetAsync("testblob1964");
            LegalHold legalHoldModel = new LegalHold(new List<string> { "tag1", "tag2", "tag3" });
            LegalHold legalHold=await b.ClearLegalHoldAsync(legalHoldModel);
            await b.DeleteAsync();
            await a.DeleteAsync();
        }
    }
}
