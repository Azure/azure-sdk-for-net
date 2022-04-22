// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using Sku = Azure.ResourceManager.Storage.Models.Sku;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Tests.Samples
{
    public class Sample1_ManagingBlobContainers
    {
        private ResourceGroup resourceGroup;
        private StorageAccount storageAccount;
        private BlobService blobService;
        [SetUp]
        public async Task createStorageAccountAndGetBlobContainerCollection()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            string rgName = "myRgName";
            AzureLocation location = AzureLocation.WestUS2;
            ResourceGroupCreateOrUpdateOperation operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(true, rgName, new ResourceGroupData(location));
            ResourceGroup resourceGroup = operation.Value;
            this.resourceGroup = resourceGroup;
            Sku sku = new Sku(SkuName.StandardGRS);
            Kind kind = Kind.Storage;
            string locationStr = "westus2";
            StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku, kind, locationStr);
            StorageAccountCollection accountCollection = resourceGroup.GetStorageAccounts();
            string accountName = "myAccount";
            StorageAccountCreateOrUpdateOperation accountCreateOperation = await accountCollection.CreateOrUpdateAsync(false, accountName, parameters);
            storageAccount = await accountCreateOperation.WaitForCompletionAsync();
            #region Snippet:Managing_BlobContainers_GetBlobService
            BlobService blobService = storageAccount.GetBlobService();
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
            BlobContainerCreateOrUpdateOperation blobContainerCreateOperation = await blobContainerCollection.CreateOrUpdateAsync(true, blobContainerName, blobContainerData);
            BlobContainer blobContainer = blobContainerCreateOperation.Value;
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_BlobContainers_ListBlobContainers
            BlobContainerCollection blobContainerCollection = blobService.GetBlobContainers();
            AsyncPageable<BlobContainer> response = blobContainerCollection.GetAllAsync();
            await foreach (BlobContainer blobContainer in response)
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
            BlobContainer blobContainer = await blobContainerCollection.GetAsync("myBlobContainer");
            Console.WriteLine(blobContainer.Id.Name);
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetIfExist()
        {
            #region Snippet:Managing_BlobContainers_GetBlobContainerIfExists
            BlobContainerCollection blobContainerCollection = blobService.GetBlobContainers();
            BlobContainer blobContainer = await blobContainerCollection.GetIfExistsAsync("foo");
            if (blobContainer != null)
            {
                Console.WriteLine(blobContainer.Id.Name);
            }
            if (await blobContainerCollection.ExistsAsync("bar"))
            {
                Console.WriteLine("blob container 'bar' exists");
            }
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Delete()
        {
            #region Snippet:Managing_BlobContainers_DeleteBlobContainer
            BlobContainerCollection blobContainerCollection = blobService.GetBlobContainers();
            BlobContainer blobContainer = await blobContainerCollection.GetAsync("myBlobContainer");
            await blobContainer.DeleteAsync(true);
            #endregion
        }
    }
}
