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
    public class Sample2_ManagingBlobContainers
    {
        private ResourceGroupResource resourceGroup;
        private StorageAccountResource storageAccount;
        private BlobServiceResource blobService;
        [SetUp]
        public async Task createStorageAccountAndGetBlobContainerCollection()
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
            #region Snippet:Managing_BlobContainers_GetBlobService
            BlobServiceResource blobService = storageAccount.GetBlobService();
            #endregion
            this.blobService = blobService;
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateOrUpdate()
        {
            #region Snippet:Managing_BlobContainers_CreateBlobContainer
            BlobContainerCollection blobContainerCollection = blobService.GetBlobContainers();
            string blobContainerName = "myBlobContainer";
            BlobContainerData blobContainerData = new BlobContainerData();
            ArmOperation<BlobContainerResource> blobContainerCreateOperation = await blobContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, blobContainerName, blobContainerData);
            BlobContainerResource blobContainer = blobContainerCreateOperation.Value;
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_BlobContainers_ListBlobContainers
            BlobContainerCollection blobContainerCollection = blobService.GetBlobContainers();
            AsyncPageable<BlobContainerResource> response = blobContainerCollection.GetAllAsync();
            await foreach (BlobContainerResource blobContainer in response)
            {
                Console.WriteLine(blobContainer.Id.Name);
            }
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Get()
        {
            #region Snippet:Managing_BlobContainers_GetBlobContainer
            BlobContainerCollection blobContainerCollection = blobService.GetBlobContainers();
            BlobContainerResource blobContainer = await blobContainerCollection.GetAsync("myBlobContainer");
            Console.WriteLine(blobContainer.Id.Name);
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Delete()
        {
            #region Snippet:Managing_BlobContainers_DeleteBlobContainer
            BlobContainerCollection blobContainerCollection = blobService.GetBlobContainers();
            BlobContainerResource blobContainer = await blobContainerCollection.GetAsync("myBlobContainer");
            await blobContainer.DeleteAsync(WaitUntil.Completed);
            #endregion
        }
    }
}
