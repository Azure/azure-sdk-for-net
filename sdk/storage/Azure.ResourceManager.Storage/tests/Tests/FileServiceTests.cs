// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage.Tests.Tests.Helpers;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage.Tests.Tests
{
    public class FileServiceTests:StorageTestBase
    {
        private ResourceGroup curResourceGroup;
        private StorageAccount curStorageAccount;
        public FileServiceTests(bool async) : base(async)
        {
        }
        [SetUp]
        public async Task createStorageAccountAsync()
        {
            curResourceGroup = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("teststorage");
            var storageAccountContainer = curResourceGroup.GetStorageAccounts();
            curStorageAccount = await storageAccountContainer.CreateOrUpdateAsync(accountName, GetDefaultStorageAccountParameters());
        }
        [TearDown]
        public async Task clearStorageAccountAsync()
        {
            if (curResourceGroup != null)
            {
                var storageAccountContainer = curResourceGroup.GetStorageAccounts();
                await foreach (StorageAccount account in storageAccountContainer.GetAllAsync())
                {
                    await account.DeleteAsync();
                }
                curResourceGroup = null;
                curStorageAccount = null;
            }
        }
        //[Test]
        //public async Task CreateDeleteFileShare()
        //{
        //    string fileShareName = Recording.GenerateAssetName("testfileshare");
        //    FileShareContainer fileShareContainer = curStorageAccount.GetFileShares();
        //    FileShare fileShare = await fileShareContainer.CreateOrUpdateAsync(fileShareName, new FileShareData());
        //    Assert.AreEqual(fileShare.Id.Name, fileShareName);
        //}
    }
}
