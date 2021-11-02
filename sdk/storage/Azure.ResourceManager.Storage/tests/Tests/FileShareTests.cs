// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage.Tests.Helpers;
using Azure.ResourceManager.Storage.Models;
using System.Collections.Generic;

namespace Azure.ResourceManager.Storage.Tests.Tests
{
    public class FileShareTests : StorageTestBase
    {
        private ResourceGroup _resourceGroup;
        private StorageAccount _storageAccount;
        private FileServiceCollection _fileServiceCollection;
        private FileService _fileService;
        private FileShareCollection _fileShareCollection;

        public FileShareTests(bool async) : base(async)
        {
        }

        [SetUp]
        public async Task CreateStorageAccountAndGetFileShareCollection()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = await CreateValidAccountNameAsync("teststoragemgmt");
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            _storageAccount = (await storageAccountCollection.CreateOrUpdateAsync(accountName, GetDefaultStorageAccountParameters())).Value;
            _fileServiceCollection = _storageAccount.GetFileServices();
            _fileService = await _fileServiceCollection.GetAsync("default");
            _fileShareCollection = _fileService.GetFileShares();
        }

        [TearDown]
        public async Task ClearStorageAccount()
        {
            if (_resourceGroup != null)
            {
                var storageAccountCollection = _resourceGroup.GetStorageAccounts();
                await foreach (StorageAccount account in storageAccountCollection.GetAllAsync())
                {
                    await account.DeleteAsync();
                }
                _resourceGroup = null;
                _storageAccount = null;
            }
        }

        [Test]
        [RecordedTest]
        public async Task CreateDeleteFileShare()
        {
            //create file share
            string fileShareName = Recording.GenerateAssetName("testfileshare");
            FileShare share1 = (await _fileShareCollection.CreateOrUpdateAsync(fileShareName, new FileShareData())).Value;
            Assert.AreEqual(share1.Id.Name, fileShareName);

            //validate if created successfully
            FileShareData shareData = share1.Data;
            Assert.IsEmpty(shareData.Metadata);
            FileShare share2 = await _fileShareCollection.GetAsync(fileShareName);
            AssertFileShareEqual(share1, share2);
            Assert.IsTrue(await _fileShareCollection.CheckIfExistsAsync(fileShareName));
            Assert.IsFalse(await _fileShareCollection.CheckIfExistsAsync(fileShareName + "1"));

            //delete file share
            await share1.DeleteAsync();

            //validate if deleted successfully
            FileShare fileShare3 = await _fileShareCollection.GetIfExistsAsync(fileShareName);
            Assert.IsNull(fileShare3);
            Assert.IsFalse(await _fileShareCollection.CheckIfExistsAsync(fileShareName));
        }

        [Test]
        [RecordedTest]
        public async Task GetAllFileShares()
        {
            //create two file shares
            string fileShareName1 = Recording.GenerateAssetName("testfileshare1");
            string fileShareName2 = Recording.GenerateAssetName("testfileshare2");
            FileShare share1 = (await _fileShareCollection.CreateOrUpdateAsync(fileShareName1, new FileShareData())).Value;
            FileShare share2 = (await _fileShareCollection.CreateOrUpdateAsync(fileShareName2, new FileShareData())).Value;

            //validate if there are two file shares
            FileShare share3 = null;
            FileShare share4 = null;
            int count = 0;
            await foreach (FileShare share in _fileShareCollection.GetAllAsync())
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
            FileShare share1 = (await _fileShareCollection.CreateOrUpdateAsync(fileShareName, new FileShareData())).Value;
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
            FileShare share3 = await _fileShareCollection.GetAsync(fileShareName);
            Assert.NotNull(share3.Data.Metadata);
            Assert.AreEqual(share3.Data.ShareQuota, shareData.ShareQuota);
            Assert.AreEqual(share3.Data.Metadata, shareData.Metadata);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateFileService()
        {
            //update service property
            FileServiceData parameter = new FileServiceData()
            {
                ShareDeleteRetentionPolicy = new DeleteRetentionPolicy()
                {
                    Enabled = true,
                    Days = 5
                }
            };
            _fileService = await _fileService.SetServicePropertiesAsync(parameter);

            //validate
            Assert.IsTrue(_fileService.Data.ShareDeleteRetentionPolicy.Enabled);
            Assert.AreEqual(_fileService.Data.ShareDeleteRetentionPolicy.Days, 5);
        }

        [Test]
        [RecordedTest]
        public async Task RestoreFileShare()
        {
            //enable soft delete in service property
            FileServiceData parameter = new FileServiceData()
            {
                ShareDeleteRetentionPolicy = new DeleteRetentionPolicy()
                {
                    Enabled = true,
                    Days = 5
                }
            };
            _fileService = await _fileService.SetServicePropertiesAsync(parameter);

            //create file share
            string fileShareName = Recording.GenerateAssetName("testfileshare");
            FileShare share1 = (await _fileShareCollection.CreateOrUpdateAsync(fileShareName, new FileShareData())).Value;
            Assert.AreEqual(share1.Id.Name, fileShareName);

            //delete this share
            await share1.DeleteAsync();

            //get the deleted share version
            string deletedShareVersion = null;
            List<FileShare> fileShares = await _fileShareCollection.GetAllAsync(expand: "deleted").ToEnumerableAsync();
            deletedShareVersion = fileShares[0].Data.Version;

            //restore file share
            //Don't need sleep when playback, or test will be very slow. Need sleep when live and record.
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(30000);
            }
            DeletedShare deletedShare = new DeletedShare(fileShareName, deletedShareVersion);
            await share1.RestoreAsync(deletedShare);

            //validate
            fileShares = await _fileShareCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(fileShares.Count, 1);
        }
    }
}
