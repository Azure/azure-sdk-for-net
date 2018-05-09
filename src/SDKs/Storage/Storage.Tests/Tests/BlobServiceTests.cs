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

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
                    BlobContainer blobContainer = storageMgmtClient.BlobContainers.Create(rgName, accountName, containerName);
                    Assert.Null(blobContainer.Metadata);
                    Assert.Null(blobContainer.PublicAccess);

                    blobContainer = storageMgmtClient.BlobContainers.Get(rgName, accountName, containerName);
                    Assert.Null(blobContainer.Metadata);
                    Assert.Equal(PublicAccess.None, blobContainer.PublicAccess);
                    Assert.False(blobContainer.HasImmutabilityPolicy);
                    Assert.False(blobContainer.HasLegalHold);

                    //Delete container, then no container in the storage account
                    storageMgmtClient.BlobContainers.Delete(rgName, accountName, containerName);
                    ListContainerItems blobContainers = storageMgmtClient.BlobContainers.List(rgName, accountName);
                    Assert.Equal(0, blobContainers.Value.Count);

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

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
                    BlobContainer blobContainer = storageMgmtClient.BlobContainers.Create(rgName, accountName, containerName);
                    Assert.Null(blobContainer.Metadata);
                    Assert.Null(blobContainer.PublicAccess);

                    blobContainer.Metadata = new Dictionary<string, string>();
                    blobContainer.Metadata.Add("metadata", "true");
                    blobContainer.PublicAccess = PublicAccess.Container;
                    var blobContainerSet = storageMgmtClient.BlobContainers.Update(rgName, accountName, containerName, metadata:blobContainer.Metadata, publicAccess:blobContainer.PublicAccess);
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

        // list containers
        [Fact]
        public void BlobContainersListTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
                    string containerName1 = TestUtilities.GenerateName("container");
                    BlobContainer blobContainer = storageMgmtClient.BlobContainers.Create(rgName, accountName, containerName1);
                    Assert.Null(blobContainer.Metadata);
                    Assert.Null(blobContainer.PublicAccess);

                    blobContainer.Metadata = new Dictionary<string, string>();
                    blobContainer.Metadata.Add("metadata", "true");
                    blobContainer.PublicAccess = PublicAccess.Container;
                    var blobContainerSet = storageMgmtClient.BlobContainers.Update(rgName, accountName, containerName1, metadata:blobContainer.Metadata, publicAccess:blobContainer.PublicAccess);
                    Assert.NotNull(blobContainer.Metadata);
                    Assert.NotNull(blobContainer.PublicAccess);
                    Assert.Equal(blobContainer.Metadata, blobContainerSet.Metadata);
                    Assert.Equal(blobContainer.PublicAccess, blobContainerSet.PublicAccess);
                    Assert.False(blobContainerSet.HasImmutabilityPolicy);
                    Assert.False(blobContainerSet.HasLegalHold);

                    string containerName2 = TestUtilities.GenerateName("container");
                    BlobContainer blobContainer2 = storageMgmtClient.BlobContainers.Create(rgName, accountName, containerName2);
                    Assert.Null(blobContainer2.Metadata);
                    Assert.Null(blobContainer2.PublicAccess);

                    var storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, storageMgmtClient.StorageAccounts.ListKeys(rgName, accountName).Keys.ElementAt(0).Value), false);
                    var container = storageAccount.CreateCloudBlobClient().GetContainerReference(containerName2);
                    //container.AcquireLeaseAsync(TimeSpan.FromSeconds(45)).Wait();

                    ListContainerItems containerList = storageMgmtClient.BlobContainers.List(rgName, accountName);
                    foreach (ListContainerItem blobContainerList in containerList.Value)
                    {
                        Assert.NotNull(blobContainer.Metadata);
                        Assert.NotNull(blobContainer.PublicAccess);
                        Assert.False(blobContainerSet.HasImmutabilityPolicy);
                        Assert.False(blobContainerSet.HasLegalHold);
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

        [Fact]
        public void BlobContainersGetTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
                    BlobContainer blobContainer = storageMgmtClient.BlobContainers.Create(rgName, accountName, containerName);
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

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
                    BlobContainer blobContainer = storageMgmtClient.BlobContainers.Create(rgName, accountName, containerName);
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

        // create and delete immutability policies.
        [Fact]
        public void BlobContainersCreateDeleteImmutabilityPolicyTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
                    BlobContainer blobContainer = storageMgmtClient.BlobContainers.Create(rgName, accountName, containerName);
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

        // update and get immutability policies.
        [Fact]
        public void BlobContainersUpdateImmutabilityPolicyTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
                    BlobContainer blobContainer = storageMgmtClient.BlobContainers.Create(rgName, accountName, containerName);
                    Assert.Null(blobContainer.Metadata);
                    Assert.Null(blobContainer.PublicAccess);

                    ImmutabilityPolicy immutabilityPolicy = storageMgmtClient.BlobContainers.CreateOrUpdateImmutabilityPolicy(rgName, accountName, containerName, ifMatch:"", immutabilityPeriodSinceCreationInDays: 3);
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


        // lock immutability policies.
        [Fact]
        public void BlobContainersLockImmutabilityPolicyTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
                    BlobContainer blobContainer = storageMgmtClient.BlobContainers.Create(rgName, accountName, containerName);
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

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
                    BlobContainer blobContainer = storageMgmtClient.BlobContainers.Create(rgName, accountName, containerName);
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

    }
}
