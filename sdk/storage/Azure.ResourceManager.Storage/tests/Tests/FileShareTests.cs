// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage.Tests.Helpers;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage.Tests.Tests
{
    public class FileShareTests:StorageTestBase
    {
        private ResourceGroup resourceGroup;
        private StorageAccount storageAccount;
        private FileServiceContainer fileServiceContainer;
        private FileService fileService;
        private FileShareContainer fileShareContainer;

        public FileShareTests(bool async) : base(async)
        {
        }
        [SetUp]
        public async Task CreateStorageAccountAndGetFileShareContainer()
        {
            resourceGroup = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("storage");
            StorageAccountContainer storageAccountContainer = resourceGroup.GetStorageAccounts();
            StorageAccountCreateOperation accountCreateOperation = await storageAccountContainer.CreateOrUpdateAsync(accountName, GetDefaultStorageAccountParameters());
            storageAccount = await accountCreateOperation.WaitForCompletionAsync();
            fileServiceContainer = storageAccount.GetFileServices();
            fileService = await fileServiceContainer.GetAsync("default");
            fileShareContainer = fileService.GetFileShares();
        }
        [TearDown]
        public async Task ClearStorageAccount()
        {
            if (resourceGroup != null)
            {
                var storageAccountContainer = resourceGroup.GetStorageAccounts();
                await foreach (StorageAccount account in storageAccountContainer.GetAllAsync())
                {
                    await account.DeleteAsync();
                }
                resourceGroup = null;
                storageAccount = null;
            }
        }
        [Test]
        [RecordedTest]
        public async Task CreateDeleteFileShare()
        {
            //create file share
            string fileShareName = Recording.GenerateAssetName("testfileshare");
            FileShareCreateOperation fileShareCreateOperation=await fileShareContainer.CreateOrUpdateAsync(fileShareName, new FileShareData());
            FileShare share1 = await fileShareCreateOperation.WaitForCompletionAsync();
            Assert.AreEqual(share1.Id.Name, fileShareName);

            //validate if created successfully
            FileShareData shareData = share1.Data;
            Assert.IsEmpty(shareData.Metadata);
            FileShare share2 = await fileShareContainer.GetAsync(fileShareName);
            AssertFileShareEqual(share1, share2);
            Assert.IsTrue(await fileShareContainer.CheckIfExistsAsync(fileShareName));
            Assert.IsFalse(await fileShareContainer.CheckIfExistsAsync(fileShareName+"1"));

            //delete file share
            await share1.DeleteAsync();

            //validate if deleted successfully
            FileShare fileShare3 = await fileShareContainer.GetIfExistsAsync(fileShareName);
            Assert.IsNull(fileShare3);
            Assert.IsFalse(await fileShareContainer.CheckIfExistsAsync(fileShareName));
        }
        [Test]
        [RecordedTest]
        public async Task GetAllFileShares()
        {
            //create two file shares
            string fileShareName1 = Recording.GenerateAssetName("testfileshare1");
            string fileShareName2 = Recording.GenerateAssetName("testfileshare2");
            FileShareCreateOperation fileShareCreateOperation1 = await fileShareContainer.CreateOrUpdateAsync(fileShareName1, new FileShareData());
            FileShare share1 = await fileShareCreateOperation1.WaitForCompletionAsync();
            FileShareCreateOperation fileShareCreateOperation2 = await fileShareContainer.CreateOrUpdateAsync(fileShareName2, new FileShareData());
            FileShare share2 = await fileShareCreateOperation2.WaitForCompletionAsync();

            //validate if there are two file shares
            FileShare share3 = null;
            FileShare share4 = null;
            int count = 0;
            await foreach (FileShare share in fileShareContainer.GetAllAsync())
            {
                count++;
                if (share.Id.Name == fileShareName1)
                    share3 = share;
                if (share.Id.Name == fileShareName2)
                    share4 = share;
            }
            Assert.AreEqual(count, 2);
            Assert.IsNotNull(share3);
            Assert.IsNotNull(share4);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateFileShare()
        {
            //create file share
            string fileShareName = Recording.GenerateAssetName("testfileshare");
            FileShareCreateOperation fileShareCreateOperation = await fileShareContainer.CreateOrUpdateAsync(fileShareName, new FileShareData());
            FileShare share1 = await fileShareCreateOperation.WaitForCompletionAsync();
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
