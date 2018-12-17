﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
                parameters.Kind = Kind.StorageV2;
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

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
                parameters.Kind = Kind.StorageV2;
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

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
                parameters.Kind = Kind.StorageV2;
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

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
                parameters.Kind = Kind.StorageV2;
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

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
                parameters.Kind = Kind.StorageV2;
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

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
                parameters.Kind = Kind.StorageV2;
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

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
                parameters.Kind = Kind.StorageV2;
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

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

        // Get/Set Blob Service Properties
        [Fact]
        public void BlobServiceTest()
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
                    BlobServiceProperties properties1 = storageMgmtClient.BlobServices.GetServiceProperties(rgName, accountName);
                    Assert.False(properties1.DeleteRetentionPolicy.Enabled);
                    Assert.Null(properties1.DeleteRetentionPolicy.Days);
                    Assert.Null(properties1.DefaultServiceVersion);
                    Assert.Equal(0, properties1.Cors.CorsRulesProperty.Count);
                    BlobServiceProperties properties2 = properties1;
                    properties2.DeleteRetentionPolicy = new DeleteRetentionPolicy();
                    properties2.DeleteRetentionPolicy.Enabled = true;
                    properties2.DeleteRetentionPolicy.Days = 300;
                    properties2.DefaultServiceVersion = "2017-04-17";
                    storageMgmtClient.BlobServices.SetServiceProperties(rgName, accountName, properties2);
                    BlobServiceProperties properties3 = storageMgmtClient.BlobServices.GetServiceProperties(rgName, accountName);
                    Assert.True(properties3.DeleteRetentionPolicy.Enabled);
                    Assert.Equal(300, properties3.DeleteRetentionPolicy.Days);
                    Assert.Equal("2017-04-17", properties3.DefaultServiceVersion);
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
    }
}
