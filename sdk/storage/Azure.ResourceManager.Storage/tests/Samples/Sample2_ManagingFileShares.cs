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
        public async Task createStorageAccountAndGetFileShareCollection()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            string rgName = "myRgName";
            Location location = Location.WestUS2;
            ResourceGroupCreateOrUpdateOperation operation= await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
            ResourceGroup resourceGroup = operation.Value;
            this.resourceGroup = resourceGroup;
            Sku sku = new Sku(SkuName.StandardGRS);
            Kind kind = Kind.Storage;
            string locationStr = "westus2";
            StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku, kind, locationStr);
            StorageAccountCollection accountCollection = resourceGroup.GetStorageAccounts();
            string accountName = "myAccount";
            StorageAccountCreateOperation accountCreateOperation = await accountCollection.CreateOrUpdateAsync(accountName, parameters);
            storageAccount = await accountCreateOperation.WaitForCompletionAsync();
            #region Snippet:Managing_FileShares_GetFileService
            FileService fileService = await storageAccount.GetFileService().GetAsync();
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
            FileShareCreateOperation fileShareCreateOperation = await fileShareCollection.CreateOrUpdateAsync(fileShareName, fileShareData);
            FileShare fileShare =await fileShareCreateOperation.WaitForCompletionAsync();
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_FileShares_ListFileShares
            FileShareCollection fileShareCollection = fileService.GetFileShares();
            AsyncPageable<FileShare> response = fileShareCollection.GetAllAsync();
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
            FileShareCollection fileShareCollection = fileService.GetFileShares();
            FileShare fileShare= await fileShareCollection.GetAsync("myFileShare");
            Console.WriteLine(fileShare.Id.Name);
            #endregion
        }
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetIfExist()
        {
            #region Snippet:Managing_FileShares_GetFileShareIFExists
            FileShareCollection fileShareCollection = fileService.GetFileShares();
            FileShare fileShare = await fileShareCollection.GetIfExistsAsync("foo");
            if (fileShare != null)
            {
                Console.WriteLine(fileShare.Id.Name);
            }
            if (await fileShareCollection.CheckIfExistsAsync("bar"))
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
            FileShareCollection fileShareCollection = fileService.GetFileShares();
            FileShare fileShare = await fileShareCollection.GetAsync("myFileShare");
            await fileShare.DeleteAsync();
            #endregion
        }
    }
}
