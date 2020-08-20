// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using ResourceGroups.Tests;
using Storage.Tests.Helpers;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.Azure;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Rest.Azure.Authentication;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading.Tasks;
using Microsoft.Azure.Test.HttpRecorder;
using System.Net.Http;
using Microsoft.Azure.KeyVault.WebKey;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Storage.Tests
{
    public class BlobServiceTests
    {
        // create container
        // delete container
        [Fact]
        public void BlobContainersCreateDeleteTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgName = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = new StorageAccountCreateParameters
                {
                    Location = "eastus2euap",
                    Kind = Kind.StorageV2,
                    Sku = new Sku { Name = SkuName.StandardLRS },
                    LargeFileSharesState = LargeFileSharesState.Enabled
                };
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);

                // implement case
                try
                {
                    // Enable container soft dlete
                    BlobServiceProperties properties = storageMgmtClient.BlobServices.GetServiceProperties(rgName, accountName);
                    properties.ContainerDeleteRetentionPolicy = new DeleteRetentionPolicy();
                    properties.ContainerDeleteRetentionPolicy.Enabled = true;
                    properties.ContainerDeleteRetentionPolicy.Days = 30;
                    storageMgmtClient.BlobServices.SetServiceProperties(rgName, accountName, properties);
                    BlobServiceProperties properties2 = storageMgmtClient.BlobServices.GetServiceProperties(rgName, accountName);
                    Assert.True(properties2.ContainerDeleteRetentionPolicy.Enabled);
                    Assert.Equal(30, properties2.ContainerDeleteRetentionPolicy.Days);

                    //Create container
                    string containerName = TestUtilities.GenerateName("container");
                    BlobContainer blobContainer = storageMgmtClient.BlobContainers.Create(rgName, accountName, containerName, new BlobContainer());
                    Assert.Null(blobContainer.Metadata);
                    Assert.Null(blobContainer.PublicAccess);

                    //Get container
                    blobContainer = storageMgmtClient.BlobContainers.Get(rgName, accountName, containerName);
                    Assert.Null(blobContainer.Metadata);
                    Assert.Equal(PublicAccess.None, blobContainer.PublicAccess);
                    Assert.False(blobContainer.HasImmutabilityPolicy);
                    Assert.False(blobContainer.HasLegalHold);

                    //Delete container, then no container in the storage account
                    storageMgmtClient.BlobContainers.Delete(rgName, accountName, containerName);
                    IPage<ListContainerItem> blobContainers = storageMgmtClient.BlobContainers.List(rgName, accountName);
                    Assert.Empty(blobContainers.ToList());

                    //List include deleted 
                    IPage<ListContainerItem> containers = storageMgmtClient.BlobContainers.List(rgName, accountName, include: ListContainersInclude.Deleted);

                    //Delete not exist container, won't fail (return 204)
                    storageMgmtClient.BlobContainers.Delete(rgName, accountName, containerName);
                }
                finally
                {
                    // clean up
                    storageMgmtClient.StorageAccounts.Delete(rgName, accountName);
                    resourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        // update container
        // get container properties
        [Fact]
        public void BlobContainersUpdateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgName = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, true);

                // implement case
                try
                {
                    string containerName = TestUtilities.GenerateName("container");
                    BlobContainer blobContainer = storageMgmtClient.BlobContainers.Create(rgName, accountName, containerName, new BlobContainer());
                    Assert.Null(blobContainer.Metadata);
                    Assert.Null(blobContainer.PublicAccess);

                    blobContainer.Metadata = new Dictionary<string, string>();
                    blobContainer.Metadata.Add("metadata", "true");
                    blobContainer.PublicAccess = PublicAccess.Container;
                    var blobContainerSet = storageMgmtClient.BlobContainers.Update(rgName, accountName, containerName, new BlobContainer(metadata:blobContainer.Metadata, publicAccess:blobContainer.PublicAccess));
                    Assert.NotNull(blobContainerSet.Metadata);
                    Assert.Equal(PublicAccess.Container, blobContainerSet.PublicAccess);
                    Assert.Equal(blobContainer.Metadata, blobContainerSet.Metadata);
                    Assert.Equal(blobContainer.PublicAccess, blobContainerSet.PublicAccess);
                    Assert.False(blobContainerSet.HasImmutabilityPolicy);
                    Assert.False(blobContainerSet.HasLegalHold);

                    var storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, storageMgmtClient.StorageAccounts.ListKeys(rgName, accountName).Keys.ElementAt(0).Value), false);
                    var container = storageAccount.CreateCloudBlobClient().GetContainerReference(containerName);
                  //  container.AcquireLeaseAsync(TimeSpan.FromSeconds(45)).Wait();

                    var blobContainerGet = storageMgmtClient.BlobContainers.Get(rgName, accountName, containerName);
                    //Assert.Equal(Microsoft.Azure.Management.Storage.Models.LeaseDuration.Fixed, blobContainerGet.LeaseDuration);
                    Assert.Equal(blobContainerSet.PublicAccess, blobContainerGet.PublicAccess);
                    Assert.Equal(blobContainerSet.Metadata, blobContainerGet.Metadata);
                    Assert.False(blobContainerGet.HasImmutabilityPolicy);
                    Assert.False(blobContainerGet.HasLegalHold);
                }
                finally
                {
                    // clean up
                    storageMgmtClient.StorageAccounts.Delete(rgName, accountName);
                    resourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        // create/update container with EncryptionScope
        [Fact]
        public void BlobContainersEncryptionScopeTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgName = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, true);

                // implement case
                try
                {
                    //Create EcryptionScope
                    string scopeName1 = "testscope1";
                    EncryptionScope es1 = storageMgmtClient.EncryptionScopes.Put(rgName, accountName, scopeName1, new EncryptionScope(name: scopeName1, source: EncryptionScopeSource.MicrosoftStorage, state: EncryptionScopeState.Disabled));

                    string scopeName2 = "testscope2";
                    EncryptionScope es2 = storageMgmtClient.EncryptionScopes.Put(rgName, accountName, scopeName2, new EncryptionScope(name: scopeName2, source: EncryptionScopeSource.MicrosoftStorage, state: EncryptionScopeState.Disabled));


                    //Create container
                    string containerName = TestUtilities.GenerateName("container");
                    BlobContainer blobContainer = storageMgmtClient.BlobContainers.Create(rgName, accountName, containerName, new BlobContainer(defaultEncryptionScope: scopeName1, denyEncryptionScopeOverride: false));
                    Assert.Equal(scopeName1, blobContainer.DefaultEncryptionScope);
                    Assert.False(blobContainer.DenyEncryptionScopeOverride.Value);

                    //Update container not support Encryption scope
                    BlobContainer blobContainer2 = storageMgmtClient.BlobContainers.Update(rgName, accountName, containerName, new BlobContainer());
                    Assert.Equal(scopeName2, blobContainer2.DefaultEncryptionScope);
                    Assert.True(blobContainer2.DenyEncryptionScopeOverride.Value);
                }
                finally
                {
                    // clean up
                    storageMgmtClient.StorageAccounts.Delete(rgName, accountName);
                    resourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        // list containers
        [Fact]
        public void BlobContainersListTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgName = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                parameters.Kind = Kind.StorageV2;
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

                // implement case
                try
                {
                    string containerName1 = TestUtilities.GenerateName("container");
                    BlobContainer blobContainer = storageMgmtClient.BlobContainers.Create(rgName, accountName, containerName1, new BlobContainer());
                    Assert.Null(blobContainer.Metadata);
                    Assert.Null(blobContainer.PublicAccess);

                    blobContainer.Metadata = new Dictionary<string, string>();
                    blobContainer.Metadata.Add("metadata", "true");
                    blobContainer.PublicAccess = PublicAccess.Container;
                    var blobContainerSet = storageMgmtClient.BlobContainers.Update(rgName, accountName, containerName1, new BlobContainer(metadata: blobContainer.Metadata, publicAccess: blobContainer.PublicAccess));
                    Assert.NotNull(blobContainer.Metadata);
                    Assert.NotNull(blobContainer.PublicAccess);
                    Assert.Equal(blobContainer.Metadata, blobContainerSet.Metadata);
                    Assert.Equal(blobContainer.PublicAccess, blobContainerSet.PublicAccess);
                    Assert.False(blobContainerSet.HasImmutabilityPolicy);
                    Assert.False(blobContainerSet.HasLegalHold);

                    string containerName2 = TestUtilities.GenerateName("container");
                    BlobContainer blobContainer2 = storageMgmtClient.BlobContainers.Create(rgName, accountName, containerName2, new BlobContainer());
                    Assert.Null(blobContainer2.Metadata);
                    Assert.Null(blobContainer2.PublicAccess);

                    string containerName3 = TestUtilities.GenerateName("container");
                    BlobContainer blobContainer3 = storageMgmtClient.BlobContainers.Create(rgName, accountName, containerName3, new BlobContainer());
                    Assert.Null(blobContainer3.Metadata);
                    Assert.Null(blobContainer3.PublicAccess);

                    var storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, storageMgmtClient.StorageAccounts.ListKeys(rgName, accountName).Keys.ElementAt(0).Value), false);
                    var container = storageAccount.CreateCloudBlobClient().GetContainerReference(containerName2);
                    //container.AcquireLeaseAsync(TimeSpan.FromSeconds(45)).Wait();

                    //List container
                    IPage<ListContainerItem> containerList = storageMgmtClient.BlobContainers.List(rgName, accountName);
                    Assert.Null(containerList.NextPageLink);
                    Assert.Equal(3, containerList.Count());
                    foreach (ListContainerItem blobContainerList in containerList)
                    {
                        Assert.NotNull(blobContainerList.Name);
                        Assert.NotNull(blobContainerList.PublicAccess);
                        Assert.False(blobContainerList.HasImmutabilityPolicy);
                        Assert.False(blobContainerList.HasLegalHold);
                    }

                    //List container with next link
                    containerList = storageMgmtClient.BlobContainers.List(rgName, accountName, "2");
                    Assert.NotNull(containerList.NextPageLink);
                    Assert.Equal(2, containerList.Count());
                    containerList = storageMgmtClient.BlobContainers.ListNext(containerList.NextPageLink);
                    Assert.Null(containerList.NextPageLink);
                    Assert.Single(containerList);
                }
                finally
                {
                    // clean up
                    storageMgmtClient.StorageAccounts.Delete(rgName, accountName);
                    resourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        [Fact]
        public void BlobContainersGetTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgName = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                parameters.Kind = Kind.StorageV2;
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

                // implement case
                try
                {
                    string containerName = TestUtilities.GenerateName("container");
                    BlobContainer blobContainer = storageMgmtClient.BlobContainers.Create(rgName, accountName, containerName, new BlobContainer());
                    Assert.Null(blobContainer.Metadata);
                    Assert.Null(blobContainer.PublicAccess);

                    LegalHold legalHold = storageMgmtClient.BlobContainers.SetLegalHold(rgName, accountName, containerName, new List<string> { "tag1", "tag2", "tag3" });
                    Assert.True(legalHold.HasLegalHold);
                    Assert.Equal(new List<string> { "tag1", "tag2", "tag3" }, legalHold.Tags);

                    ImmutabilityPolicy immutabilityPolicy = storageMgmtClient.BlobContainers.CreateOrUpdateImmutabilityPolicy(rgName, accountName, containerName, ifMatch: "", immutabilityPeriodSinceCreationInDays: 3);
                    Assert.NotNull(immutabilityPolicy.Id);
                    Assert.NotNull(immutabilityPolicy.Type);
                    Assert.NotNull(immutabilityPolicy.Name);
                    Assert.Equal(3, immutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
                    Assert.Equal(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.State);


                    immutabilityPolicy = storageMgmtClient.BlobContainers.LockImmutabilityPolicy(rgName, accountName, containerName, ifMatch: immutabilityPolicy.Etag);
                    Assert.NotNull(immutabilityPolicy.Id);
                    Assert.NotNull(immutabilityPolicy.Type);
                    Assert.NotNull(immutabilityPolicy.Name);
                    Assert.Equal(3, immutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
                    Assert.Equal(ImmutabilityPolicyState.Locked, immutabilityPolicy.State);

                    immutabilityPolicy = storageMgmtClient.BlobContainers.ExtendImmutabilityPolicy(rgName, accountName, containerName, ifMatch: immutabilityPolicy.Etag, immutabilityPeriodSinceCreationInDays: 100);
                    Assert.NotNull(immutabilityPolicy.Id);
                    Assert.NotNull(immutabilityPolicy.Type);
                    Assert.NotNull(immutabilityPolicy.Name);
                    Assert.Equal(100, immutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
                    Assert.Equal(ImmutabilityPolicyState.Locked, immutabilityPolicy.State);

                    blobContainer = storageMgmtClient.BlobContainers.Get(rgName, accountName, containerName);
                    Assert.Null(blobContainer.Metadata);
                    Assert.Equal(PublicAccess.None, blobContainer.PublicAccess);
                    Assert.Equal(3, blobContainer.ImmutabilityPolicy.UpdateHistory.Count);
                    Assert.Equal(ImmutabilityPolicyUpdateType.Put, blobContainer.ImmutabilityPolicy.UpdateHistory[0].Update);
                    Assert.Equal(ImmutabilityPolicyUpdateType.Lock, blobContainer.ImmutabilityPolicy.UpdateHistory[1].Update);
                    Assert.Equal(ImmutabilityPolicyUpdateType.Extend, blobContainer.ImmutabilityPolicy.UpdateHistory[2].Update);
                    Assert.True(blobContainer.LegalHold.HasLegalHold);
                    Assert.Equal(3, blobContainer.LegalHold.Tags.Count);
                    Assert.Equal("tag1", blobContainer.LegalHold.Tags[0].Tag);
                    Assert.Equal("tag2", blobContainer.LegalHold.Tags[1].Tag);
                    Assert.Equal("tag3", blobContainer.LegalHold.Tags[2].Tag);

                    legalHold = storageMgmtClient.BlobContainers.ClearLegalHold(rgName, accountName, containerName, new List<string> { "tag1", "tag2", "tag3" });
                    Assert.False(legalHold.HasLegalHold);
                    //Assert.Equal(null, legalHold.Tags);

                    storageMgmtClient.BlobContainers.Delete(rgName, accountName, containerName);
                }
                finally
                {
                    // clean up
                    storageMgmtClient.StorageAccounts.Delete(rgName, accountName);
                    resourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        // set/clear legal hold.
        [Fact]
        public void BlobContainersSetLegalHoldTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgName = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                parameters.Kind = Kind.StorageV2;
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

                // implement case
                try
                {
                    string containerName = TestUtilities.GenerateName("container");
                    BlobContainer blobContainer = storageMgmtClient.BlobContainers.Create(rgName, accountName, containerName, new BlobContainer());
                    Assert.Null(blobContainer.Metadata);
                    Assert.Null(blobContainer.PublicAccess);

                    LegalHold legalHold = storageMgmtClient.BlobContainers.SetLegalHold(rgName, accountName, containerName, new List<string> { "tag1", "tag2", "tag3" });
                    Assert.True(legalHold.HasLegalHold);
                    Assert.Equal(new List<string> { "tag1", "tag2", "tag3" }, legalHold.Tags);

                    legalHold = storageMgmtClient.BlobContainers.ClearLegalHold(rgName, accountName, containerName, new List<string> { "tag1", "tag2", "tag3" });
                    Assert.False(legalHold.HasLegalHold);
                    Assert.Equal(0, legalHold.Tags.Count);
                }
                finally
                {
                    // clean up
                    storageMgmtClient.StorageAccounts.Delete(rgName, accountName);
                    resourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        //// Lease Blob Containers
        //[Fact]
        //public void BlobContainersLeaseTest()
        //{
        //    var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

        //    using (MockContext context = MockContext.Start(this.GetType()))
        //    {
        //        var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
        //        var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

        //        //// Create resource group
        //        //var rgName = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

        //        //// Create storage account
        //        //string accountName = TestUtilities.GenerateName("sto");
        //        //var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
        //        //parameters.Kind = Kind.StorageV2;
        //        //var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);
        //        //StorageManagementTestUtilities.VerifyAccountProperties(account, false);

        //        var rgName = "weitry";
        //        string accountName = "weiacl3";
        //        string containerName = TestUtilities.GenerateName("container");

        //        // implement case
        //        try
        //        {
        //            BlobContainer blobContainer = storageMgmtClient.BlobContainers.Create(rgName, accountName, containerName);
        //            Assert.Null(blobContainer.Metadata);
        //            Assert.Null(blobContainer.PublicAccess);

        //            //LeaseContainerResponse leaseResponse = storageMgmtClient.BlobContainers.Lease(rgName, accountName, containerName, new LeaseContainerRequest("Acquire", null, 40, 9));
        //            LeaseContainerResponse leaseResponse = storageMgmtClient.BlobContainers.Lease(rgName, accountName, containerName);
        //            Assert.NotNull(leaseResponse.LeaseId);


        //            blobContainer = storageMgmtClient.BlobContainers.Get(rgName, accountName, containerName);
        //            Assert.Equal("Leased", blobContainer.LeaseState);
        //        }
        //        finally
        //        {
        //            storageMgmtClient.BlobContainers.Delete(rgName, accountName, containerName);
        //            //// clean up
        //            //storageMgmtClient.StorageAccounts.Delete(rgName, accountName);
        //            //resourcesClient.ResourceGroups.Delete(rgName);
        //        }
        //    }
        //}

        // create and delete immutability policies.
        [Fact]
        public void BlobContainersCreateDeleteImmutabilityPolicyTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgName = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                parameters.Kind = Kind.StorageV2;
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

                // implement case
                try
                {
                    string containerName = TestUtilities.GenerateName("container");
                    BlobContainer blobContainer = storageMgmtClient.BlobContainers.Create(rgName, accountName, containerName, new BlobContainer());
                    Assert.Null(blobContainer.Metadata);
                    Assert.Null(blobContainer.PublicAccess);

                    ImmutabilityPolicy immutabilityPolicy = storageMgmtClient.BlobContainers.CreateOrUpdateImmutabilityPolicy(rgName, accountName, containerName, ifMatch:"", immutabilityPeriodSinceCreationInDays:3);
                    Assert.NotNull(immutabilityPolicy.Id);
                    Assert.NotNull(immutabilityPolicy.Type);
                    Assert.NotNull(immutabilityPolicy.Name);
                    Assert.Equal(3, immutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
                    Assert.Equal(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.State);

                    immutabilityPolicy = storageMgmtClient.BlobContainers.DeleteImmutabilityPolicy(rgName, accountName, containerName, ifMatch:immutabilityPolicy.Etag);
                    Assert.NotNull(immutabilityPolicy.Id);
                    Assert.NotNull(immutabilityPolicy.Type);
                    Assert.NotNull(immutabilityPolicy.Name);
                    Assert.Equal(0, immutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
                    Assert.Equal("Deleted", immutabilityPolicy.State);
                }
                finally
                {
                    // clean up
                    storageMgmtClient.StorageAccounts.Delete(rgName, accountName);
                    resourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        // update and get immutability policies.
        [Fact]
        public void BlobContainersUpdateImmutabilityPolicyTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgName = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                parameters.Kind = Kind.StorageV2;
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

                // implement case
                try
                {
                    string containerName = TestUtilities.GenerateName("container");
                    BlobContainer blobContainer = storageMgmtClient.BlobContainers.Create(rgName, accountName, containerName, new BlobContainer());
                    Assert.Null(blobContainer.Metadata);
                    Assert.Null(blobContainer.PublicAccess);

                    ImmutabilityPolicy immutabilityPolicy = storageMgmtClient.BlobContainers.CreateOrUpdateImmutabilityPolicy(rgName, accountName, containerName, ifMatch: "", immutabilityPeriodSinceCreationInDays: 3);
                    Assert.NotNull(immutabilityPolicy.Id);
                    Assert.NotNull(immutabilityPolicy.Type);
                    Assert.NotNull(immutabilityPolicy.Name);
                    Assert.Equal(3, immutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
                    Assert.Equal(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.State);

                    immutabilityPolicy = storageMgmtClient.BlobContainers.CreateOrUpdateImmutabilityPolicy(rgName, accountName, containerName, ifMatch: immutabilityPolicy.Etag, immutabilityPeriodSinceCreationInDays: 5);
                    Assert.NotNull(immutabilityPolicy.Id);
                    Assert.NotNull(immutabilityPolicy.Type);
                    Assert.NotNull(immutabilityPolicy.Name);
                    Assert.Equal(5, immutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
                    Assert.Equal(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.State);

                    immutabilityPolicy = storageMgmtClient.BlobContainers.GetImmutabilityPolicy(rgName, accountName, containerName);
                    Assert.NotNull(immutabilityPolicy.Id);
                    Assert.NotNull(immutabilityPolicy.Type);
                    Assert.NotNull(immutabilityPolicy.Name);
                    Assert.Equal(5, immutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
                    Assert.Equal(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.State);
                }
                finally
                {
                    // clean up
                    storageMgmtClient.StorageAccounts.Delete(rgName, accountName);
                    resourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        // create/update immutability policies with AllowProtectedAppendWrites.
        [Fact]
        public void ImmutabilityPolicyTest_AllowProtectedAppendWrites()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgName = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                parameters.Kind = Kind.StorageV2;
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

                // implement case
                try
                {
                    string containerName = TestUtilities.GenerateName("container");
                    BlobContainer blobContainer = storageMgmtClient.BlobContainers.Create(rgName, accountName, containerName, new BlobContainer());
                    Assert.Null(blobContainer.Metadata);
                    Assert.Null(blobContainer.PublicAccess);

                    ImmutabilityPolicy immutabilityPolicy = storageMgmtClient.BlobContainers.CreateOrUpdateImmutabilityPolicy(rgName, accountName, containerName, ifMatch: "", immutabilityPeriodSinceCreationInDays: 4, allowProtectedAppendWrites: true);
                    Assert.NotNull(immutabilityPolicy.Id);
                    Assert.NotNull(immutabilityPolicy.Type);
                    Assert.NotNull(immutabilityPolicy.Name);
                    Assert.Equal(4, immutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
                    Assert.Equal(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.State);
                    Assert.True(immutabilityPolicy.AllowProtectedAppendWrites.Value);

                    immutabilityPolicy = storageMgmtClient.BlobContainers.CreateOrUpdateImmutabilityPolicy(rgName, accountName, containerName, ifMatch: immutabilityPolicy.Etag, immutabilityPeriodSinceCreationInDays: 5, allowProtectedAppendWrites: false);
                    Assert.NotNull(immutabilityPolicy.Id);
                    Assert.NotNull(immutabilityPolicy.Type);
                    Assert.NotNull(immutabilityPolicy.Name);
                    Assert.Equal(5, immutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
                    Assert.Equal(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.State);
                    Assert.False(immutabilityPolicy.AllowProtectedAppendWrites.Value);

                    immutabilityPolicy = storageMgmtClient.BlobContainers.GetImmutabilityPolicy(rgName, accountName, containerName);
                    Assert.NotNull(immutabilityPolicy.Id);
                    Assert.NotNull(immutabilityPolicy.Type);
                    Assert.NotNull(immutabilityPolicy.Name);
                    Assert.Equal(5, immutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
                    Assert.Equal(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.State);
                    Assert.False(immutabilityPolicy.AllowProtectedAppendWrites.Value);
                }
                finally
                {
                    // clean up
                    storageMgmtClient.StorageAccounts.Delete(rgName, accountName);
                    resourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }


        // lock immutability policies.
        [Fact]
        public void BlobContainersLockImmutabilityPolicyTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgName = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                parameters.Kind = Kind.StorageV2;
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

                // implement case
                try
                {
                    string containerName = TestUtilities.GenerateName("container");
                    BlobContainer blobContainer = storageMgmtClient.BlobContainers.Create(rgName, accountName, containerName, new BlobContainer());
                    Assert.Null(blobContainer.Metadata);
                    Assert.Null(blobContainer.PublicAccess);

                    ImmutabilityPolicy immutabilityPolicy = storageMgmtClient.BlobContainers.CreateOrUpdateImmutabilityPolicy(rgName, accountName, containerName, ifMatch: "", immutabilityPeriodSinceCreationInDays: 3);
                    Assert.NotNull(immutabilityPolicy.Id);
                    Assert.NotNull(immutabilityPolicy.Type);
                    Assert.NotNull(immutabilityPolicy.Name);
                    Assert.Equal(3, immutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
                    Assert.Equal(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.State);

                    immutabilityPolicy = storageMgmtClient.BlobContainers.LockImmutabilityPolicy(rgName, accountName, containerName, ifMatch: immutabilityPolicy.Etag);
                    Assert.NotNull(immutabilityPolicy.Id);
                    Assert.NotNull(immutabilityPolicy.Type);
                    Assert.NotNull(immutabilityPolicy.Name);
                    Assert.Equal(3, immutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
                    Assert.Equal(ImmutabilityPolicyState.Locked, immutabilityPolicy.State);

                    storageMgmtClient.BlobContainers.Delete(rgName, accountName, containerName);
                }
                finally
                {
                    // clean up
                    storageMgmtClient.StorageAccounts.Delete(rgName, accountName);
                    resourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        // extend immutability policies.
        [Fact]
        public void BlobContainersExtendImmutabilityPolicyTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgName = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                parameters.Kind = Kind.StorageV2;
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

                // implement case
                try
                {
                    string containerName = TestUtilities.GenerateName("container");
                    BlobContainer blobContainer = storageMgmtClient.BlobContainers.Create(rgName, accountName, containerName, new BlobContainer());
                    Assert.Null(blobContainer.Metadata);
                    Assert.Null(blobContainer.PublicAccess);

                    ImmutabilityPolicy immutabilityPolicy = storageMgmtClient.BlobContainers.CreateOrUpdateImmutabilityPolicy(rgName, accountName, containerName, ifMatch:"", immutabilityPeriodSinceCreationInDays: 3);
                    Assert.NotNull(immutabilityPolicy.Id);
                    Assert.NotNull(immutabilityPolicy.Type);
                    Assert.NotNull(immutabilityPolicy.Name);
                    Assert.Equal(3, immutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
                    Assert.Equal(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.State);

                    immutabilityPolicy = storageMgmtClient.BlobContainers.LockImmutabilityPolicy(rgName, accountName, containerName, ifMatch: immutabilityPolicy.Etag);
                    Assert.NotNull(immutabilityPolicy.Id);
                    Assert.NotNull(immutabilityPolicy.Type);
                    Assert.NotNull(immutabilityPolicy.Name);
                    Assert.Equal(3, immutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
                    Assert.Equal(ImmutabilityPolicyState.Locked, immutabilityPolicy.State);

                    immutabilityPolicy = storageMgmtClient.BlobContainers.ExtendImmutabilityPolicy(rgName, accountName, containerName, ifMatch: immutabilityPolicy.Etag, immutabilityPeriodSinceCreationInDays: 100);
                    Assert.NotNull(immutabilityPolicy.Id);
                    Assert.NotNull(immutabilityPolicy.Type);
                    Assert.NotNull(immutabilityPolicy.Name);
                    Assert.Equal(100, immutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
                    Assert.Equal(ImmutabilityPolicyState.Locked, immutabilityPolicy.State);

                    storageMgmtClient.BlobContainers.Delete(rgName, accountName, containerName);
                }
                finally
                {
                    // clean up
                    storageMgmtClient.StorageAccounts.Delete(rgName, accountName);
                    resourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        // Get/Set Blob Service Properties
        [Fact]
        public void BlobServiceTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgName = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, true);

                // implement case
                try
                {
                    BlobServiceProperties properties1 = storageMgmtClient.BlobServices.GetServiceProperties(rgName, accountName);
                    Assert.False(properties1.DeleteRetentionPolicy.Enabled);
                    Assert.Null(properties1.DeleteRetentionPolicy.Days);
                    Assert.Null(properties1.DefaultServiceVersion);
                    Assert.Equal(0, properties1.Cors.CorsRulesProperty.Count);
                    Assert.Equal(parameters.Sku.Name, properties1.Sku.Name);
                    //Assert.Null(properties1.AutomaticSnapshotPolicyEnabled);
                    BlobServiceProperties properties2 = properties1;
                    properties2.DeleteRetentionPolicy = new DeleteRetentionPolicy();
                    properties2.DeleteRetentionPolicy.Enabled = true;
                    properties2.DeleteRetentionPolicy.Days = 300;
                    properties2.DefaultServiceVersion = "2017-04-17";
                    //properties2.AutomaticSnapshotPolicyEnabled = true;
                    storageMgmtClient.BlobServices.SetServiceProperties(rgName, accountName, properties2);
                    BlobServiceProperties properties3 = storageMgmtClient.BlobServices.GetServiceProperties(rgName, accountName);
                    Assert.True(properties3.DeleteRetentionPolicy.Enabled);
                    Assert.Equal(300, properties3.DeleteRetentionPolicy.Days);
                    Assert.Equal("2017-04-17", properties3.DefaultServiceVersion);
                    //Assert.True(properties3.AutomaticSnapshotPolicyEnabled);
                }
                finally
                {
                    // clean up
                    storageMgmtClient.StorageAccounts.Delete(rgName, accountName);
                    resourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        // Get/Set Cors rules in Blob Service Properties
        [Fact]
        public void BlobServiceCorsTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgName = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, true);

                // implement case
                try
                {
                    BlobServiceProperties properties1 = storageMgmtClient.BlobServices.GetServiceProperties(rgName, accountName);
                    BlobServiceProperties properties2 = new BlobServiceProperties();
                    properties2.DeleteRetentionPolicy = new DeleteRetentionPolicy();
                    properties2.DeleteRetentionPolicy.Enabled = true;
                    properties2.DeleteRetentionPolicy.Days = 300;
                    properties2.DefaultServiceVersion = "2017-04-17";
                    properties2.Cors = new CorsRules();
                    properties2.Cors.CorsRulesProperty = new List<CorsRule>();
                    properties2.Cors.CorsRulesProperty.Add(new CorsRule()
                    {
                        AllowedHeaders = new string[] { "x-ms-meta-abc", "x-ms-meta-data*", "x-ms-meta-target*" },
                        AllowedMethods = new string[] { "GET", "HEAD", "POST", "OPTIONS", "MERGE", "PUT" },
                        AllowedOrigins = new string[] { "http://www.contoso.com", "http://www.fabrikam.com" },
                        ExposedHeaders = new string[] { "x-ms-meta-*" },
                        MaxAgeInSeconds = 100
                    });
                    properties2.Cors.CorsRulesProperty.Add(new CorsRule()
                    {
                        AllowedHeaders = new string[] { "*" },
                        AllowedMethods = new string[] { "GET" },
                        AllowedOrigins = new string[] { "*" },
                        ExposedHeaders = new string[] { "*" },
                        MaxAgeInSeconds = 2
                    });
                    properties2.Cors.CorsRulesProperty.Add(new CorsRule()
                    {
                        AllowedHeaders = new string[] { "x-ms-meta-12345675754564*" },
                        AllowedMethods = new string[] { "GET", "PUT", "CONNECT" },
                        AllowedOrigins = new string[] { "http://www.abc23.com", "https://www.fabrikam.com/*" },
                        ExposedHeaders = new string[] { "x-ms-meta-abc", "x-ms-meta-data*", "x -ms-meta-target*" },
                        MaxAgeInSeconds = 2000
                    });

                    BlobServiceProperties properties3 = storageMgmtClient.BlobServices.SetServiceProperties(rgName, accountName, properties2);
                    Assert.True(properties3.DeleteRetentionPolicy.Enabled);
                    Assert.Equal(300, properties3.DeleteRetentionPolicy.Days);
                    Assert.Equal("2017-04-17", properties3.DefaultServiceVersion);

                    //Validate CORS Rules
                    Assert.Equal(properties2.Cors.CorsRulesProperty.Count, properties3.Cors.CorsRulesProperty.Count);
                    for (int i = 0; i < properties2.Cors.CorsRulesProperty.Count; i++)
                    {
                        CorsRule putRule = properties2.Cors.CorsRulesProperty[i];
                        CorsRule getRule = properties3.Cors.CorsRulesProperty[i];

                        Assert.Equal(putRule.AllowedHeaders, getRule.AllowedHeaders);
                        Assert.Equal(putRule.AllowedMethods, getRule.AllowedMethods);
                        Assert.Equal(putRule.AllowedOrigins, getRule.AllowedOrigins);
                        Assert.Equal(putRule.ExposedHeaders, getRule.ExposedHeaders);
                        Assert.Equal(putRule.MaxAgeInSeconds, getRule.MaxAgeInSeconds);
                    }

                    BlobServiceProperties properties4 = storageMgmtClient.BlobServices.GetServiceProperties(rgName, accountName);
                    Assert.True(properties4.DeleteRetentionPolicy.Enabled);
                    Assert.Equal(300, properties4.DeleteRetentionPolicy.Days);
                    Assert.Equal("2017-04-17", properties4.DefaultServiceVersion);

                    //Validate CORS Rules
                    Assert.Equal(properties2.Cors.CorsRulesProperty.Count, properties4.Cors.CorsRulesProperty.Count);
                    for (int i = 0; i < properties2.Cors.CorsRulesProperty.Count; i++)
                    {
                        CorsRule putRule = properties2.Cors.CorsRulesProperty[i];
                        CorsRule getRule = properties4.Cors.CorsRulesProperty[i];

                        Assert.Equal(putRule.AllowedHeaders, getRule.AllowedHeaders);
                        Assert.Equal(putRule.AllowedMethods, getRule.AllowedMethods);
                        Assert.Equal(putRule.AllowedOrigins, getRule.AllowedOrigins);
                        Assert.Equal(putRule.ExposedHeaders, getRule.ExposedHeaders);
                        Assert.Equal(putRule.MaxAgeInSeconds, getRule.MaxAgeInSeconds);
                    }

                }
                finally
                {
                    // clean up
                    storageMgmtClient.StorageAccounts.Delete(rgName, accountName);
                    resourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        // List Blob Service 
        [Fact]
        public void ListBlobServiceTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgName = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, true);

                // implement case
                try
                {
                    var properties = storageMgmtClient.BlobServices.List(rgName, accountName);
                    List<BlobServiceProperties> propertiesList = new List<BlobServiceProperties>(properties);
                    Assert.Equal(1, propertiesList.Count);
                    Assert.Equal("default", propertiesList[0].Name);
                }
                finally
                {
                    // clean up
                    storageMgmtClient.StorageAccounts.Delete(rgName, accountName);
                    resourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        // Point In Time Restore test
        [Fact]
        public void PITRTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgName = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = new StorageAccountCreateParameters
                {
                    Location = "eastus2(stage)",
                    Kind = Kind.StorageV2,
                    Sku = new Sku { Name = SkuName.StandardLRS }
                };
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);
                Assert.Equal(SkuName.StandardLRS, account.Sku.Name);

                account = storageMgmtClient.StorageAccounts.GetProperties(rgName, accountName, StorageAccountExpand.BlobRestoreStatus);
                Assert.Null(account.BlobRestoreStatus);

                // implement case
                try
                {
                    //enable changefeed and softdelete, and enable restore policy
                    BlobServiceProperties properties = storageMgmtClient.BlobServices.GetServiceProperties(rgName, accountName);
                    properties.DeleteRetentionPolicy = new DeleteRetentionPolicy();
                    properties.DeleteRetentionPolicy.Enabled = true;
                    properties.DeleteRetentionPolicy.Days = 30;
                    properties.ChangeFeed = new ChangeFeed();
                    properties.ChangeFeed.Enabled = true;
                    properties.IsVersioningEnabled = true;
                    properties.RestorePolicy = new RestorePolicyProperties(true, 5);
                    storageMgmtClient.BlobServices.SetServiceProperties(rgName, accountName, properties);
                    properties = storageMgmtClient.BlobServices.GetServiceProperties(rgName, accountName);
                    Assert.True(properties.RestorePolicy.Enabled);
                    Assert.Equal(5, properties.RestorePolicy.Days);
                    Assert.True(properties.DeleteRetentionPolicy.Enabled);
                    Assert.Equal(30, properties.DeleteRetentionPolicy.Days);
                    Assert.NotNull(properties.RestorePolicy.MinRestoreTime);
                    Assert.True(properties.ChangeFeed.Enabled);

                    // restore blobs
                    //Don't need sleep when playback, or Unit test will be slow. 
                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                    {
                        System.Threading.Thread.Sleep(10000);
                    }

                    //Create restore ranges
                    List<BlobRestoreRange> ranges = new List<BlobRestoreRange>();
                    ranges.Add(new BlobRestoreRange("", "container1/blob1"));
                    ranges.Add(new BlobRestoreRange("container1/blob2", "container2/blob3"));
                    ranges.Add(new BlobRestoreRange("container3/blob3", ""));

                    //Start restore
                    Task<AzureOperationResponse<BlobRestoreStatus>> beginTask = storageMgmtClient.StorageAccounts.BeginRestoreBlobRangesWithHttpMessagesAsync(rgName, accountName, DateTime.Now.AddSeconds(-1), ranges);
                    beginTask.Wait();
                    AzureOperationResponse<BlobRestoreStatus> response = beginTask.Result;
                    Assert.NotNull(response.Body.RestoreId);
                    Assert.Equal("InProgress", response.Body.Status);

                    // wait for restore complete (this test wait at most 5 mins)
                    Task<AzureOperationResponse<BlobRestoreStatus>> waitTask = storageMgmtClient.GetPostOrDeleteOperationResultAsync(response, null, new System.Threading.CancellationToken());
                    waitTask.Wait(5 * 60 * 1000);

                    //Check restore status by get account properties
                    account = storageMgmtClient.StorageAccounts.GetProperties(rgName, accountName, StorageAccountExpand.BlobRestoreStatus);
                    Assert.True(waitTask.Result.Body.Status == "InProgress" || waitTask.Result.Body.Status == "Complete");
                    Assert.Equal(response.Body.RestoreId, waitTask.Result.Body.RestoreId);
                }
                finally
                {
                    // clean up
                    storageMgmtClient.StorageAccounts.Delete(rgName, accountName);
                    resourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        // Object replication test
        [Fact]
        public void ORSTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgName = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string sourceAccountName = TestUtilities.GenerateName("sto");
                string destAccountName = TestUtilities.GenerateName("sto");
                var parameters = new StorageAccountCreateParameters
                {
                    Location = "eastus2euap",
                    Kind = Kind.StorageV2,
                    Sku = new Sku { Name = SkuName.StandardLRS }
                };
                var sourceAccount = storageMgmtClient.StorageAccounts.Create(rgName, sourceAccountName, parameters);
                var destAccount = storageMgmtClient.StorageAccounts.Create(rgName, destAccountName, parameters);
                Assert.Equal(SkuName.StandardLRS, sourceAccount.Sku.Name);
                Assert.Equal(SkuName.StandardLRS, destAccount.Sku.Name);

                // implement case
                try
                {
                    //enable changefeed and versioning
                    BlobServiceProperties properties = storageMgmtClient.BlobServices.GetServiceProperties(rgName, sourceAccountName);
                    properties.ChangeFeed = new ChangeFeed();
                    properties.ChangeFeed.Enabled = true;
                    properties.IsVersioningEnabled = true;
                    storageMgmtClient.BlobServices.SetServiceProperties(rgName, sourceAccountName, properties);
                    properties = storageMgmtClient.BlobServices.GetServiceProperties(rgName, sourceAccountName);
                    Assert.True(properties.IsVersioningEnabled);
                    Assert.True(properties.ChangeFeed.Enabled);

                    properties = storageMgmtClient.BlobServices.GetServiceProperties(rgName, destAccountName);
                    properties.ChangeFeed = new ChangeFeed();
                    properties.ChangeFeed.Enabled = true;
                    properties.IsVersioningEnabled = true;
                    storageMgmtClient.BlobServices.SetServiceProperties(rgName, destAccountName, properties);
                    properties = storageMgmtClient.BlobServices.GetServiceProperties(rgName, destAccountName);
                    Assert.True(properties.IsVersioningEnabled);
                    Assert.True(properties.ChangeFeed.Enabled);

                    //Create Source and dest container
                    string sourceContainerName1 = "src1";
                    string sourceContainerName2 = "src2";
                    string destContainerName1 = "dest1";
                    string destContainerName2 = "dest2";
                    storageMgmtClient.BlobContainers.Create(rgName, sourceAccountName, sourceContainerName1, new BlobContainer());
                    storageMgmtClient.BlobContainers.Create(rgName, sourceAccountName, sourceContainerName2, new BlobContainer());
                    storageMgmtClient.BlobContainers.Create(rgName, destAccountName, destContainerName1, new BlobContainer());
                    storageMgmtClient.BlobContainers.Create(rgName, destAccountName, destContainerName2, new BlobContainer());

                    //new rules
                    List<string> prefix = new List<string>();
                    prefix.Add("aa");
                    prefix.Add("bc d");
                    prefix.Add("123");
                    string minCreationTime = "2020-03-19T16:06:00Z";
                    List<ObjectReplicationPolicyRule> rules = new List<ObjectReplicationPolicyRule>();
                    rules.Add(
                        new ObjectReplicationPolicyRule()
                        {
                            SourceContainer = sourceContainerName1,
                            DestinationContainer = destContainerName1,
                            Filters = new ObjectReplicationPolicyFilter(prefix, minCreationTime),
                        }
                    );
                    rules.Add(
                        new ObjectReplicationPolicyRule()
                        {
                            SourceContainer = sourceContainerName2,
                            DestinationContainer = destContainerName2
                        }
                    );

                    //New policy
                    ObjectReplicationPolicy policy = new ObjectReplicationPolicy()
                    {
                        SourceAccount = sourceAccountName,
                        DestinationAccount = destAccountName,
                        Rules = rules,                      
                    };

                    //Set and list policy
                    storageMgmtClient.ObjectReplicationPolicies.CreateOrUpdate(rgName, destAccountName, "default", policy);
                    ObjectReplicationPolicy destpolicy = storageMgmtClient.ObjectReplicationPolicies.List(rgName, destAccountName).First();

                    // Fix the MinCreationTime format, since deserilize the request the string MinCreationTime will be taken as DateTime, so the format will change. But server only allows format "2020-03-19T16:06:00Z"
                    // This issue can be resolved in the future, when server change MinCreationTime type from string to Datatime
                    FixMinCreationTimeFormat(destpolicy);
                    CompareORsPolicy(policy, destpolicy);

                    storageMgmtClient.ObjectReplicationPolicies.CreateOrUpdate(rgName,sourceAccountName, destpolicy.PolicyId, destpolicy);
                    ObjectReplicationPolicy sourcepolicy = storageMgmtClient.ObjectReplicationPolicies.List(rgName, sourceAccountName).First();
                    FixMinCreationTimeFormat(sourcepolicy);
                    CompareORsPolicy(destpolicy, sourcepolicy, skipIDCompare: false);

                    // Get policy
                    destpolicy = storageMgmtClient.ObjectReplicationPolicies.Get(rgName, destAccountName, destpolicy.PolicyId);
                    FixMinCreationTimeFormat(destpolicy);
                    CompareORsPolicy(policy, destpolicy);
                    sourcepolicy = storageMgmtClient.ObjectReplicationPolicies.Get(rgName, sourceAccountName, destpolicy.PolicyId);
                    FixMinCreationTimeFormat(sourcepolicy);
                    CompareORsPolicy(policy, sourcepolicy);

                    // remove policy
                    storageMgmtClient.ObjectReplicationPolicies.Delete(rgName, sourceAccountName, destpolicy.PolicyId);
                    storageMgmtClient.ObjectReplicationPolicies.Delete(rgName, destAccountName, destpolicy.PolicyId);

                    //// clean up
                    storageMgmtClient.StorageAccounts.Delete(rgName, sourceAccountName);
                    storageMgmtClient.StorageAccounts.Delete(rgName, destAccountName);
                }
                finally
                {
                    resourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        /// <summary>
        /// Fix the MinCreationTime format, since deserilize the request the string MinCreationTime will be taken as DateTime, so the format will change. But server only allows format "2020-03-19T16:06:00Z"
        /// This issue can be resolved in the future, when server change MinCreationTime type from string to Datatime
        /// </summary>
        /// <param name="getPolicy"></param>
        private static void FixMinCreationTimeFormat(ObjectReplicationPolicy getPolicy)
        {
            if (getPolicy !=null && getPolicy.Rules!=null)
            {
                foreach(ObjectReplicationPolicyRule rule in getPolicy.Rules)
                {
                    if (rule!= null && rule.Filters!= null && !string.IsNullOrEmpty(rule.Filters.MinCreationTime))
                    {
                        if (rule.Filters.MinCreationTime.ToUpper()[rule.Filters.MinCreationTime.Length - 1] != 'Z')
                        {
                            rule.Filters.MinCreationTime = Convert.ToDateTime(rule.Filters.MinCreationTime + "Z").ToUniversalTime().ToString("s") + "Z";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Compare 2 ORS policy, check if they are same
        /// </summary>
        /// <param name="skipIDCompare">skip compare policyID and rule ID</param>
        private static void CompareORsPolicy(ObjectReplicationPolicy setPolicy, ObjectReplicationPolicy getPolicy, bool skipIDCompare = true)
        {
            Assert.Equal(setPolicy.SourceAccount, getPolicy.SourceAccount);
            Assert.Equal(setPolicy.DestinationAccount, getPolicy.DestinationAccount);
            Assert.Equal(setPolicy.Rules.Count, getPolicy.Rules.Count);
            if (!skipIDCompare)
            {
                Assert.Equal(setPolicy.PolicyId, getPolicy.PolicyId);
            }
            else
            { 
                Assert.NotNull(getPolicy.PolicyId);
            }

            ObjectReplicationPolicyRule[] setRuleArray = setPolicy.Rules.ToArray();
            ObjectReplicationPolicyRule[] getRuleArray = getPolicy.Rules.ToArray();
            for (int i = 0; i < setRuleArray.Length; i++)
            {
                ObjectReplicationPolicyRule setrule = setRuleArray[i];
                ObjectReplicationPolicyRule getrule = getRuleArray[i];
                Assert.Equal(setrule.SourceContainer, getrule.SourceContainer);
                Assert.Equal(setrule.DestinationContainer, getrule.DestinationContainer);
                if (setrule.Filters == null)
                {
                    Assert.Null(getrule.Filters);
                }
                else
                {
                    Assert.Equal(setrule.Filters.MinCreationTime, getrule.Filters.MinCreationTime);
                    Assert.Equal(setrule.Filters.PrefixMatch, getrule.Filters.PrefixMatch);
                }
                if (!skipIDCompare)
                {
                    Assert.Equal(setrule.RuleId, getrule.RuleId);
                }
                else
                {
                    Assert.NotNull(getrule.RuleId);
                }
            }
        }
    }
}
