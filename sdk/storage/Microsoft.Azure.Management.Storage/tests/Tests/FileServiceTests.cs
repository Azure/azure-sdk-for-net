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
    public class FileServiceTests
    {
        // create share
        // delete share
        [Fact]
        public void FileSharesCreateDeleteListTest()
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
                    string shareName = TestUtilities.GenerateName("share");
                    FileShare share = storageMgmtClient.FileShares.Create(rgName, accountName, shareName, new FileShare());
                    Assert.Null(share.Metadata);

                    share = storageMgmtClient.FileShares.Get(rgName, accountName, shareName);
                    Assert.Null(share.Metadata);

                    string shareName2 = TestUtilities.GenerateName("share");
                    Dictionary<string, string> metaData = new Dictionary<string, string>();
                    metaData.Add("metadata1", "true");
                    metaData.Add("metadata2", "value2");
                    int shareQuota = 500;
                    FileShare share2 = storageMgmtClient.FileShares.Create(rgName, accountName, shareName2, 
                        new FileShare( metadata: metaData,shareQuota: shareQuota, accessTier: ShareAccessTier.Hot));
                    Assert.Equal(2, share2.Metadata.Count);
                    Assert.Equal(metaData, share2.Metadata);
                    Assert.Equal(shareQuota, share2.ShareQuota);
                    Assert.Equal(ShareAccessTier.Hot, share2.AccessTier);

                    share2 = storageMgmtClient.FileShares.Get(rgName, accountName, shareName2);
                    Assert.Equal(2, share2.Metadata.Count);
                    Assert.Equal(metaData, share2.Metadata);
                    Assert.Equal(shareQuota, share2.ShareQuota);
                    Assert.Equal(ShareAccessTier.Hot, share2.AccessTier);

                    //Delete share
                    storageMgmtClient.FileShares.Delete(rgName, accountName, shareName);
                    IPage<FileShareItem> fileShares = storageMgmtClient.FileShares.List(rgName, accountName);
                    Assert.Equal(1, fileShares.Count());

                    storageMgmtClient.FileShares.Delete(rgName, accountName, shareName2);
                    fileShares = storageMgmtClient.FileShares.List(rgName, accountName);
                    Assert.Equal(0, fileShares.Count());

                    //Delete not exist share, won't fail (return 204)
                    storageMgmtClient.FileShares.Delete(rgName, accountName, "notexistshare");
                }
                finally
                {
                    // clean up
                    storageMgmtClient.StorageAccounts.Delete(rgName, accountName);
                    resourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        // update share
        // get share properties
        [Fact]
        public void FileSharesUpdateGetTest()
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
                    string shareName = TestUtilities.GenerateName("share");
                    FileShare share = storageMgmtClient.FileShares.Create(rgName, accountName, shareName, new FileShare());
                    Assert.Null(share.Metadata);

                    Dictionary<string, string> metaData = new Dictionary<string, string>();
                    metaData.Add("metadata1", "true");
                    metaData.Add("metadata2", "value2");
                    int shareQuota = 5200;
                    var shareSet = storageMgmtClient.FileShares.Update(rgName, accountName, shareName,
                        new FileShare(metadata: metaData, shareQuota: shareQuota, accessTier: ShareAccessTier.Cool));
                    Assert.NotNull(shareSet.Metadata);
                    Assert.Equal(shareQuota, shareSet.ShareQuota);
                    Assert.Equal(metaData, shareSet.Metadata);
                    Assert.Equal(ShareAccessTier.Cool, shareSet.AccessTier);

                    var shareGet = storageMgmtClient.FileShares.Get(rgName, accountName, shareName);
                    Assert.NotNull(shareGet.Metadata);
                    Assert.Equal(metaData, shareGet.Metadata);
                    Assert.Equal(shareQuota, shareGet.ShareQuota);
                    Assert.Equal(ShareAccessTier.Cool, shareGet.AccessTier);
                }
                finally
                {
                    // clean up
                    storageMgmtClient.StorageAccounts.Delete(rgName, accountName);
                    resourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        // Get/Set File Service Properties
        [Fact]
        public void FileServiceCorsTest()
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
                    FileServiceProperties properties1 = storageMgmtClient.FileServices.GetServiceProperties(rgName, accountName);
                    Assert.Equal(0, properties1.Cors.CorsRulesProperty.Count);

                    CorsRules cors = new CorsRules();
                    cors.CorsRulesProperty = new List<CorsRule>();
                    cors.CorsRulesProperty.Add(new CorsRule()
                    {
                        AllowedHeaders = new string[] { "x-ms-meta-abc", "x-ms-meta-data*", "x-ms-meta-target*" },
                        AllowedMethods = new string[] { "GET", "HEAD", "POST", "OPTIONS", "MERGE", "PUT" },
                        AllowedOrigins = new string[] { "http://www.contoso.com", "http://www.fabrikam.com" },
                        ExposedHeaders = new string[] { "x-ms-meta-*" },
                        MaxAgeInSeconds = 100
                    });
                    cors.CorsRulesProperty.Add(new CorsRule()
                    {
                        AllowedHeaders = new string[] { "*" },
                        AllowedMethods = new string[] { "GET" },
                        AllowedOrigins = new string[] { "*" },
                        ExposedHeaders = new string[] { "*" },
                        MaxAgeInSeconds = 2
                    });
                    cors.CorsRulesProperty.Add(new CorsRule()
                    {
                        AllowedHeaders = new string[] { "x-ms-meta-12345675754564*" },
                        AllowedMethods = new string[] { "GET", "PUT", "CONNECT" },
                        AllowedOrigins = new string[] { "http://www.abc23.com", "https://www.fabrikam.com/*" },
                        ExposedHeaders = new string[] { "x-ms-meta-abc", "x-ms-meta-data*", "x -ms-meta-target*" },
                        MaxAgeInSeconds = 2000
                    });

                    FileServiceProperties properties3 = storageMgmtClient.FileServices.SetServiceProperties(rgName, accountName, cors);

                    //Validate CORS Rules
                    Assert.Equal(cors.CorsRulesProperty.Count, properties3.Cors.CorsRulesProperty.Count);
                    for (int i = 0; i < cors.CorsRulesProperty.Count; i++)
                    {
                        CorsRule putRule = cors.CorsRulesProperty[i];
                        CorsRule getRule = properties3.Cors.CorsRulesProperty[i];

                        Assert.Equal(putRule.AllowedHeaders, getRule.AllowedHeaders);
                        Assert.Equal(putRule.AllowedMethods, getRule.AllowedMethods);
                        Assert.Equal(putRule.AllowedOrigins, getRule.AllowedOrigins);
                        Assert.Equal(putRule.ExposedHeaders, getRule.ExposedHeaders);
                        Assert.Equal(putRule.MaxAgeInSeconds, getRule.MaxAgeInSeconds);
                    }

                    FileServiceProperties properties4 = storageMgmtClient.FileServices.GetServiceProperties(rgName, accountName);

                    //Validate CORS Rules
                    Assert.Equal(cors.CorsRulesProperty.Count, properties4.Cors.CorsRulesProperty.Count);
                    for (int i = 0; i < cors.CorsRulesProperty.Count; i++)
                    {
                        CorsRule putRule = cors.CorsRulesProperty[i];
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

        // test share soft delete
        [Fact]
        public void FileSharesSoftDeleteTest()
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
                var parameters = new StorageAccountCreateParameters
                {
                    Location = "eastus2euap",
                    Kind = Kind.StorageV2,
                    Sku = new Sku { Name = SkuName.StandardLRS }
                };
                var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);

                // implement case
                try
                {
                    // Enable share soft delete in service properties
                    FileServiceProperties properties = storageMgmtClient.FileServices.GetServiceProperties(rgName, accountName);
                    properties.ShareDeleteRetentionPolicy = new DeleteRetentionPolicy();
                    properties.ShareDeleteRetentionPolicy.Enabled = true;
                    properties.ShareDeleteRetentionPolicy.Days = 5;
                    properties = storageMgmtClient.FileServices.SetServiceProperties(rgName, accountName, shareDeleteRetentionPolicy: properties.ShareDeleteRetentionPolicy);
                    Assert.True(properties.ShareDeleteRetentionPolicy.Enabled);
                    Assert.Equal(5, properties.ShareDeleteRetentionPolicy.Days);

                    //Create 2 shares
                    string shareName1 = TestUtilities.GenerateName("share1");
                    string shareName2 = TestUtilities.GenerateName("share2");
                    FileShare share1 = storageMgmtClient.FileShares.Create(rgName, accountName, shareName1, 
                        new FileShare( accessTier: ShareAccessTier.Hot, 
                            enabledProtocols: EnabledProtocols.NFS,
                            rootSquash: RootSquashType.AllSquash));
                    Assert.Equal(shareName1, share1.Name);
                    Assert.Equal(EnabledProtocols.NFS, share1.EnabledProtocols);
                    Assert.Equal(RootSquashType.AllSquash, share1.RootSquash);
                    //Assert.Equal(ShareAccessTier.Hot, share1.AccessTier);
                    FileShare share2 = storageMgmtClient.FileShares.Create(rgName, accountName, shareName2,
                        new FileShare(accessTier: ShareAccessTier.Cool,
                            enabledProtocols: EnabledProtocols.SMB));
                    Assert.Equal(shareName2, share2.Name);
                    Assert.Equal(EnabledProtocols.SMB, share2.EnabledProtocols);

                    //Update 1 share
                    share1 = storageMgmtClient.FileShares.Update(rgName, accountName, shareName1,
                        new FileShare(accessTier: ShareAccessTier.TransactionOptimized,
                            rootSquash: RootSquashType.RootSquash));
                    Assert.Equal(shareName1, share1.Name);
                    Assert.Equal(RootSquashType.RootSquash, share1.RootSquash);
                    //Assert.Equal(ShareAccessTier.TransactionOptimized, share1.AccessTier);


                    // Delete 1 share
                    storageMgmtClient.FileShares.Delete(rgName, accountName, shareName1);

                    //List normally
                    IPage<FileShareItem> shares = storageMgmtClient.FileShares.List(rgName, accountName);
                    Assert.Single(shares);

                    //List with includeDeleted
                    string deletedShareVersion = null;
                    shares = storageMgmtClient.FileShares.List(rgName, accountName, expand: ListSharesExpand.Deleted);
                    Assert.Equal(2, shares.Count());
                    foreach(FileShareItem share in shares)
                    {
                        if (share.Name == shareName1)
                        {
                            Assert.True(share.Deleted);
                            Assert.NotNull(share.Version);
                            deletedShareVersion = share.Version;
                        }
                    }

                    //Get not deleted share
                    share2 = storageMgmtClient.FileShares.Get(rgName, accountName, shareName2, expand: GetShareExpand.Stats);
                    Assert.NotNull(share2.ShareQuota);
                    Assert.NotNull(share2.ShareUsageBytes);

                    //Get Deleted Share
                    try {
                        share2 = storageMgmtClient.FileShares.Get(rgName, accountName, shareName1);
                        Assert.True(false, "Get Share on deleted Share should fail with NotFound.");
                    }
                    catch (CloudException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }

                    // restore deleted share
                    //Don't need sleep when playback, or Unit test will be very slow. Need sleep when record.
                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                    {
                        System.Threading.Thread.Sleep(30000);
                    }
                    storageMgmtClient.FileShares.Restore(rgName, accountName, shareName1, shareName1, deletedShareVersion);

                    //List normally
                    shares = storageMgmtClient.FileShares.List(rgName, accountName);
                    Assert.Equal(2, shares.Count());

                    //List with includeDeleted
                    shares = storageMgmtClient.FileShares.List(rgName, accountName, expand: ListSharesExpand.Deleted);
                    Assert.Equal(2, shares.Count());
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
