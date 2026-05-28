// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Tests.Samples
{
    public class Sample3_ManagingFileShares
    {
        private ResourceGroupResource resourceGroup;
        private StorageAccountResource storageAccount;
        private FileServiceResource fileService;
        [SetUp]
        public async Task createStorageAccountAndGetFileShareCollection()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            string rgName = "myRgName";
            AzureLocation location = AzureLocation.WestUS2;
            ArmOperation<ResourceGroupResource> operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
            ResourceGroupResource resourceGroup = operation.Value;
            this.resourceGroup = resourceGroup;
            StorageSku sku = new StorageSku(StorageSkuName.StandardGrs);
            StorageKind kind = StorageKind.Storage;
            string locationStr = "westus2";
            StorageAccountCreateOrUpdateContent parameters = new StorageAccountCreateOrUpdateContent(sku, kind, locationStr);
            StorageAccountCollection accountCollection = resourceGroup.GetStorageAccounts();
            string accountName = "myAccount";
            ArmOperation<StorageAccountResource> accountCreateOperation = await accountCollection.CreateOrUpdateAsync(WaitUntil.Started, accountName, parameters);
            storageAccount = await accountCreateOperation.WaitForCompletionAsync();
            #region Snippet:Managing_FileShares_GetFileService
            FileServiceResource fileService = await storageAccount.GetFileService().GetAsync();
            #endregion
            this.fileService = fileService;
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateOrUpdate()
        {
            #region Snippet:Managing_FileShares_CreateFileShare
            FileShareCollection fileShareCollection = fileService.GetFileShares();
            string fileShareName = "myFileShare";
            FileShareData fileShareData = new FileShareData();
            ArmOperation<FileShareResource> fileShareCreateOperation = await fileShareCollection.CreateOrUpdateAsync(WaitUntil.Started, fileShareName, fileShareData);
            FileShareResource fileShare =await fileShareCreateOperation.WaitForCompletionAsync();
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_FileShares_ListFileShares
            FileShareCollection fileShareCollection = fileService.GetFileShares();
            AsyncPageable<FileShareResource> response = fileShareCollection.GetAllAsync();
            await foreach (FileShareResource fileShare in response)
            {
                Console.WriteLine(fileShare.Id.Name);
            }
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Get()
        {
            #region Snippet:Managing_FileShares_GetFileShare
            FileShareCollection fileShareCollection = fileService.GetFileShares();
            FileShareResource fileShare = await fileShareCollection.GetAsync("myFileShare");
            Console.WriteLine(fileShare.Id.Name);
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Delete()
        {
            #region Snippet:Managing_FileShares_DeleteFileShare
            FileShareCollection fileShareCollection = fileService.GetFileShares();
            FileShareResource fileShare = await fileShareCollection.GetAsync("myFileShare");
            await fileShare.DeleteAsync(WaitUntil.Completed);
            #endregion
        }
    }
}
