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

namespace Azure.ResourceManager.Storage.Tests.Samples
{
    public class Sample1_ManagingBlobContainers
    {
        private ResourceGroup resourceGroup;
        private StorageAccount storageAccount;
        private BlobService blobService;
        [SetUp]
        public async Task createStorageAccountAndGetBlobContainerContainer()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.DefaultSubscription;
            string rgName = "myRgName";
            Location location = Location.WestUS2;
            ResourceGroupCreateOrUpdateOperation operation= await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
            ResourceGroup resourceGroup = operation.Value;
            this.resourceGroup = resourceGroup;
            Sku sku = new Sku(SkuName.StandardGRS);
            Kind kind = Kind.Storage;
            string locationStr = "westus2";
            StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku, kind, locationStr);
            StorageAccountContainer accountContainer = resourceGroup.GetStorageAccounts();
            string accountName = "myAccount";
            StorageAccountCreateOperation accountCreateOperation = await accountContainer.CreateOrUpdateAsync(accountName, parameters);
            storageAccount = await accountCreateOperation.WaitForCompletionAsync();
            #region Snippet:Managing_BlobContainers_GetBlobService
            BlobServiceContainer blobServiceContainer = storageAccount.GetBlobServices();
            BlobService blobService =await blobServiceContainer.GetAsync("default");
            #endregion
            this.blobService = blobService;
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateOrUpdate()
        {
            #region Snippet:Managing_BlobContainers_CreateBlobContainer
            BlobContainerContainer blobContainerContainer = blobService.GetBlobContainers();
            string blobContainerName = "myBlobContainer";
            BlobContainerData blobContainerData= new BlobContainerData();
            BlobContainerCreateOperation blobContainerCreateOperation = await blobContainerContainer.CreateOrUpdateAsync(blobContainerName, blobContainerData);
            BlobContainer blobContainer = blobContainerCreateOperation.Value;
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_BlobContainers_ListBlobContainers
            BlobContainerContainer blobContainerContainer = blobService.GetBlobContainers();
            AsyncPageable<BlobContainer> response = blobContainerContainer.GetAllAsync();
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
            BlobContainerContainer blobContainerContainer = blobService.GetBlobContainers();
            BlobContainer blobContainer =await blobContainerContainer.GetAsync("myBlobContainer");
            Console.WriteLine(blobContainer.Id.Name);
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetIfExist()
        {
            #region Snippet:Managing_BlobContainers_GetBlobContainerIfExists
            BlobContainerContainer blobContainerContainer = blobService.GetBlobContainers();
            BlobContainer blobContainer = await blobContainerContainer.GetIfExistsAsync("foo");
            if (blobContainer != null)
            {
                Console.WriteLine(blobContainer.Id.Name);
            }
            if (await blobContainerContainer.CheckIfExistsAsync("bar"))
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
            BlobContainerContainer blobContainerContainer = blobService.GetBlobContainers();
            BlobContainer blobContainer = await blobContainerContainer.GetAsync("myBlobContainer");
            await blobContainer.DeleteAsync();
            #endregion
        }
    }
}
