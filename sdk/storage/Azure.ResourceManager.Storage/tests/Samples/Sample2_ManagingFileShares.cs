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
    public class Sample2_ManagingFileShares
    {
        private ResourceGroup resourceGroup;
        private StorageAccount storageAccount;
        private FileService fileService;
        [SetUp]
        public async Task createStorageAccountAndGetFileShareContainer()
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
            #region Snippet:Managing_FileShares_GetFileService
            FileServiceContainer fileServiceContainer = storageAccount.GetFileServices();
            FileService fileService = await fileServiceContainer.GetAsync("default");
            #endregion
            this.fileService = fileService;
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateOrUpdate()
        {
            #region Snippet:Managing_FileShares_CreateFileShare
            FileShareContainer fileShareContainer = fileService.GetFileShares();
            string fileShareName = "myFileShare";
            FileShareData fileShareData = new FileShareData();
            FileShareCreateOperation fileShareCreateOperation = await fileShareContainer.CreateOrUpdateAsync(fileShareName, fileShareData);
            FileShare fileShare =await fileShareCreateOperation.WaitForCompletionAsync();
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_FileShares_ListFileShares
            FileShareContainer fileShareContainer = fileService.GetFileShares();
            AsyncPageable<FileShare> response = fileShareContainer.GetAllAsync();
            await foreach (FileShare fileShare in response)
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
            FileShareContainer fileShareContainer = fileService.GetFileShares();
            FileShare fileShare= await fileShareContainer.GetAsync("myFileShare");
            Console.WriteLine(fileShare.Id.Name);
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetIfExist()
        {
            #region Snippet:Managing_FileShares_GetFileShareIFExists
            FileShareContainer fileShareContainer = fileService.GetFileShares();
            FileShare fileShare = await fileShareContainer.GetIfExistsAsync("foo");
            if (fileShare != null)
            {
                Console.WriteLine(fileShare.Id.Name);
            }
            if (await fileShareContainer.CheckIfExistsAsync("bar"))
            {
                Console.WriteLine("file share 'bar' exists");
            }
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Delete()
        {
            #region Snippet:Managing_FileShares_DeleteFileShare
            FileShareContainer fileShareContainer = fileService.GetFileShares();
            FileShare fileShare = await fileShareContainer.GetAsync("myFileShare");
            await fileShare.DeleteAsync();
            #endregion
        }
    }
}
