// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage.Tests.Tests.Helpers;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage.Tests.Tests
{
    public class FileShareTests:StorageTestBase
    {
        private ResourceGroup curResourceGroup;
        private StorageAccount curStorageAccount;
        private FileServiceContainer fileServiceContainer;
        private FileService fileService;
        private FileShareContainer fileShareContainer;

        public FileShareTests(bool async) : base(async)
        {
        }
        [SetUp]
        public async Task createStorageAccountAsync()
        {
            curResourceGroup = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("storage");
            StorageAccountContainer storageAccountContainer = curResourceGroup.GetStorageAccounts();
            curStorageAccount = await storageAccountContainer.CreateOrUpdateAsync(accountName, GetDefaultStorageAccountParameters());
            fileServiceContainer = curStorageAccount.GetFileServices();
            fileService = await fileServiceContainer.GetAsync("default");
            fileShareContainer = fileService.GetFileShares();
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
        [Test]
        [RecordedTest]
        public async Task CreateDeleteFileShare()
        {
            //create file share
            string fileShareName = Recording.GenerateAssetName("testfileshare");
            FileShare share1 = await fileShareContainer.CreateOrUpdateAsync(fileShareName, new FileShareData());
            Assert.AreEqual(share1.Id.Name, fileShareName);

            //validate
            FileShareData shareData = share1.Data;
            Assert.IsEmpty(shareData.Metadata);
            FileShare share2 = await fileShareContainer.GetAsync(fileShareName);
            FileHelper.AssertFileShare(share1, share2);
            Assert.IsTrue(await fileShareContainer.CheckIfExistsAsync(fileShareName));
            Assert.IsFalse(await fileShareContainer.CheckIfExistsAsync(fileShareName+"1"));

            //delete blob container
            await share1.DeleteAsync();

            //validate if deleted successfully
            FileShare fileShare3 = await fileShareContainer.GetIfExistsAsync(fileShareName);
            Assert.IsNull(fileShare3);
            Assert.IsFalse(await fileShareContainer.CheckIfExistsAsync(fileShareName));
        }
        [Test]
        [RecordedTest]
        public async Task StartCreateDeleteFileShare()
        {
            //start create file share
            string fileShareName = Recording.GenerateAssetName("testfileshare");
            FileShareCreateOperation shareCreateOp = await fileShareContainer.StartCreateOrUpdateAsync(fileShareName, new FileShareData());
            FileShare share1 = await shareCreateOp.WaitForCompletionAsync();
            Assert.AreEqual(share1.Id.Name, fileShareName);

            //validate
            FileShareData shareData = share1.Data;
            Assert.IsEmpty(shareData.Metadata);
            FileShare share2 = await fileShareContainer.GetAsync(fileShareName);
            FileHelper.AssertFileShare(share1, share2);
            Assert.IsTrue(await fileShareContainer.CheckIfExistsAsync(fileShareName));
            Assert.IsFalse(await fileShareContainer.CheckIfExistsAsync(fileShareName + "1"));

            //start delete blob container
            FileShareDeleteOperation shareDeleteOp = await share1.StartDeleteAsync();
            await shareDeleteOp.WaitForCompletionResponseAsync();

            //validate if deleted successfully
            FileShare fileShare3 = await fileShareContainer.GetIfExistsAsync(fileShareName);
            Assert.IsNull(fileShare3);
            Assert.IsFalse(await fileShareContainer.CheckIfExistsAsync(fileShareName));
        }

        [Test]
        [RecordedTest]
        public async Task UpdateFileShare()
        {
            //create file share
            string fileShareName = Recording.GenerateAssetName("testfileshare");
            FileShare share1 = await fileShareContainer.CreateOrUpdateAsync(fileShareName, new FileShareData());
            Assert.AreEqual(share1.Id.Name, fileShareName);

            //update metadata and share quota
            FileShareData shareData = share1.Data;
            shareData.Metadata.Add("key1", "value1");
            shareData.Metadata.Add("key2", "value2");
            shareData.ShareQuota = 5000;
            FileShare share2 = await share1.UpdateAsync(shareData);

            //validate
            Assert.NotNull(share2.Data.Metadata);
            Assert.AreEqual(share2.Data.ShareQuota, shareData.ShareQuota);
            Assert.AreEqual(share2.Data.Metadata, shareData.Metadata);
            FileShare share3 =await fileShareContainer.GetAsync(fileShareName);
            Assert.NotNull(share3.Data.Metadata);
            Assert.AreEqual(share3.Data.ShareQuota, shareData.ShareQuota);
            Assert.AreEqual(share3.Data.Metadata, shareData.Metadata);
        }
    }
}
