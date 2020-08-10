// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Files.Shares.Tests;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Test
{
    public class ShareClientTests : FileTestBase
    {
        public ShareClientTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public void Ctor_ConnectionString()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var fileEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var fileSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, (default, default), (default, default), (fileEndpoint, fileSecondaryEndpoint));

            var shareName = GetNewShareName();

            ShareClient share = InstrumentClient(new ShareClient(connectionString.ToString(true), shareName, GetOptions()));

            var builder = new ShareUriBuilder(share.Uri);

            Assert.AreEqual(shareName, builder.ShareName);
            Assert.AreEqual("", builder.DirectoryOrFilePath);
            //Assert.AreEqual("accountName", builder.AccountName);
        }

        [Test]
        public async Task Ctor_ConnectionString_Sas()
        {
            // Arrange
            var sasBuilder = new AccountSasBuilder
            {
                ExpiresOn = Recording.UtcNow.AddHours(1),
                Services = AccountSasServices.All,
                ResourceTypes = AccountSasResourceTypes.All,
                Protocol = SasProtocol.Https,
            };

            sasBuilder.SetPermissions(AccountSasPermissions.All);
            var cred = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);
            string sasToken = sasBuilder.ToSasQueryParameters(cred).ToString();
            var sasCred = new SharedAccessSignatureCredentials(sasToken);

            StorageConnectionString conn1 = GetConnectionString(
                credentials: sasCred,
                includeEndpoint: true);

            ShareClient shareClient1 = GetShareClient(conn1.ToString(exportSecrets: true));

            // Also test with a connection string not containing the blob endpoint.
            // This should still work provided account name and Sas credential are present.
            StorageConnectionString conn2 = GetConnectionString(
                credentials: sasCred,
                includeEndpoint: false);

            ShareClient shareClient2 = GetShareClient(conn2.ToString(exportSecrets: true));

            ShareClient GetShareClient(string connectionString) =>
                InstrumentClient(
                    new ShareClient(
                        connectionString,
                        GetNewShareName(),
                        GetOptions()));

            async Task<ShareFileClient> GetFileClient(ShareClient share)
            {
                await share.CreateAsync();
                string dirName = GetNewDirectoryName();
                await share.CreateDirectoryAsync(dirName);
                return InstrumentClient(share.GetDirectoryClient(dirName).GetFileClient(GetNewFileName()));
            }

            try
            {
                // Act
                ShareFileClient file1 = await GetFileClient(shareClient1);
                ShareFileClient file2 = await GetFileClient(shareClient2);

                var data = GetRandomBuffer(Constants.KB);
                var stream1 = new MemoryStream(data);
                var stream2 = new MemoryStream(data);

                await file1.CreateAsync(stream1.Length);
                await file2.CreateAsync(stream2.Length);
                Response<ShareFileUploadInfo> info1 = await file1.UploadAsync(stream1);
                Response<ShareFileUploadInfo> info2 = await file2.UploadAsync(stream2);

                // Assert
                Assert.IsNotNull(info1.Value.ETag);
                Assert.IsNotNull(info2.Value.ETag);
            }
            finally
            {
                // Clean up
                await shareClient1.DeleteAsync();
                await shareClient2.DeleteAsync();
            }
        }

        [Test]
        public void WithSnapshot()
        {
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));
            var builder = new ShareUriBuilder(share.Uri);

            Assert.AreEqual("", builder.Snapshot);

            share = InstrumentClient(share.WithSnapshot("foo"));
            builder = new ShareUriBuilder(share.Uri);

            Assert.AreEqual("foo", builder.Snapshot);

            share = InstrumentClient(share.WithSnapshot(null));
            builder = new ShareUriBuilder(share.Uri);

            Assert.AreEqual("", builder.Snapshot);
            var accountName = new ShareUriBuilder(share.Uri).AccountName;
            TestHelper.AssertCacheableProperty(accountName, () => share.AccountName);
            TestHelper.AssertCacheableProperty(string.Empty, () => share.GetRootDirectoryClient().Name); // make sure shareName is not used when using directory client Name property
            TestHelper.AssertCacheableProperty(shareName, () => share.Name);
        }

        [Test]
        public async Task CreateAsync()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));

            try
            {
                // Act
                Response<ShareInfo> response = await share.CreateAsync(quotaInGB: 1);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
            finally
            {
                await share.DeleteAsync(false);
            }
        }

        [Test]
        public async Task CreateAsync_Metadata()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));
            System.Collections.Generic.IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await share.CreateAsync(metadata: metadata);

            // Assert
            Response<ShareProperties> response = await share.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);

            // Cleanup
            await share.DeleteAsync(false);
        }

        [Test]
        public async Task CreateAsync_Error()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));

            // Share is intentionally created twice
            await share.CreateAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                share.CreateAsync(),
                e => Assert.AreEqual("ShareAlreadyExists", e.ErrorCode));

            // Cleanup
            await share.DeleteAsync(false);
        }

        [Test]
        public async Task CreateAsync_WithAccountSas()
        {
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_AccountSas();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));

            try
            {
                Response<ShareInfo> result = await share.CreateAsync(quotaInGB: 1);

                Assert.AreNotEqual(default, result.GetRawResponse().Headers.RequestId, $"{nameof(result)} may not be populated");
            }
            finally
            {
                await share.DeleteAsync(false);
            }
        }

        [Test]
        public async Task CreateAsync_WithFileServiceSas()
        {
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_FileServiceSasShare(shareName);
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));

            var pass = false;

            try
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    share.CreateAsync(quotaInGB: 1),
                    e =>
                    {
                        Assert.AreEqual(ShareErrorCode.AuthorizationFailure.ToString(), e.ErrorCode);
                        pass = true;
                    }
                    );
            }
            finally
            {
                if (!pass)
                {
                    await share.DeleteAsync();
                }
            }
        }

        [Test]
        public async Task CreateAndGetPermissionAsync()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            var permission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)S:NO_ACCESS_CONTROL";

            // Act
            Response<PermissionInfo> createResponse = await share.CreatePermissionAsync(permission);
            Response<string> getResponse = await share.GetPermissionAsync(createResponse.Value.FilePermissionKey);

            // Assert
            Assert.AreEqual(permission, getResponse.Value);
        }

        [Test]
        public async Task CreatePermissionAsync_Error()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            var permission = "invalidPermission";

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                share.CreatePermissionAsync(permission),
                e => Assert.AreEqual("FileInvalidPermission", e.ErrorCode));
        }

        [Test]
        public async Task GetPermissionAsync_Error()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            var permissionKey = "invalidPermission";

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                share.GetPermissionAsync(permissionKey),
                e => Assert.AreEqual("InvalidHeaderValue", e.ErrorCode));
        }

        [Test]
        public async Task CreateIfNotExistsAsync_NotExists()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));

            // Act
            Response<ShareInfo> response = await share.CreateIfNotExistsAsync();

            // Assert
            Assert.IsNotNull(response);

            // Cleanup
            await share.DeleteAsync();
        }

        [Test]
        public async Task CreateIfNotExistsAsync_Exists()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));
            await share.CreateAsync();

            // Act
            Response<ShareInfo> response = await share.CreateIfNotExistsAsync();

            // Assert
            Assert.IsNull(response);

            // Cleanup
            await share.DeleteAsync();
        }

        [Test]
        public async Task CreateIfNotExistsAsync_Error()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));
            ShareClient unauthorizesShareClient = InstrumentClient(new ShareClient(share.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizesShareClient.CreateIfNotExistsAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        public async Task ExistsAsync_NotExists()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));

            // Act
            Response<bool> response = await share.ExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [Test]
        public async Task ExistsAsync_Exists()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));
            await share.CreateAsync();

            // Act
            Response<bool> response = await share.ExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);

            // Cleanup
            await share.DeleteAsync();
        }

        [Test]
        public async Task ExistsAsync_Error()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));
            ShareClient unauthorizesShareClient = InstrumentClient(new ShareClient(share.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizesShareClient.ExistsAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        public async Task DeleteIfExistsAsync_Exists()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));
            await share.CreateAsync();

            // Act
            Response<bool> response = await share.DeleteIfExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);
        }

        [Test]
        public async Task DeleteIfExistsAsync_NotExists()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));

            // Act
            Response<bool> response = await share.DeleteIfExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [Test]
        public async Task DeleteIfExistsAsync_Error()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));
            ShareClient unauthorizesShareClient = InstrumentClient(new ShareClient(share.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizesShareClient.DeleteIfExistsAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Act
            Response<ShareProperties> response = await share.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.Value.ETag);
            Assert.IsNotNull(response.Value.LastModified);
        }

        [Test]
        public async Task GetPropertiesAsync_Snapshot()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            Response<ShareSnapshotInfo> createSnapshotResponse = await share.CreateSnapshotAsync();
            ShareClient snapshotShareClient = share.WithSnapshot(createSnapshotResponse.Value.Snapshot);

            // Act
            Response<ShareProperties> response = await snapshotShareClient.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.Value.ETag);
            Assert.IsNotNull(response.Value.LastModified);
        }

        [Test]
        public async Task GetPropertiesAsync_SnapshotFailed()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            ShareClient snapshotShareClient = share.WithSnapshot("2020-06-26T00:49:21.0000000Z");

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                snapshotShareClient.GetPropertiesAsync(),
                e => Assert.AreEqual(ShareErrorCode.ShareNotFound.ToString(), e.ErrorCode));
        }

        [Test]
        [Ignore("#10044: Re-enable failing Storage tests")]
        public async Task GetPropertiesAsync_Premium()
        {
            await using DisposingShare test = await GetTestShareAsync(GetServiceClient_Premium());
            ShareClient share = test.Share;

            // Act
            Response<ShareProperties> response = await share.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.Value.ETag);
            Assert.IsNotNull(response.Value.LastModified);
            Assert.IsNotNull(response.Value.NextAllowedQuotaDowngradeTime);
            Assert.IsNotNull(response.Value.ProvisionedEgressMBps);
            Assert.IsNotNull(response.Value.ProvisionedIngressMBps);
            Assert.IsNotNull(response.Value.ProvisionedIops);
            Assert.IsNotNull(response.Value.QuotaInGB);
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                share.GetPropertiesAsync(),
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode));
        }

        [Test]
        public async Task SetMetadataAsync()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            System.Collections.Generic.IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await share.SetMetadataAsync(metadata);

            // Assert
            Response<ShareProperties> response = await share.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
        }

        [Test]
        public async Task SetMetadataAsync_Error()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));
            System.Collections.Generic.IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                share.SetMetadataAsync(metadata),
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode));
        }

        [Test]
        public async Task GetAccessPolicyAsync()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();
            await share.SetAccessPolicyAsync(signedIdentifiers);

            // Act
            Response<System.Collections.Generic.IEnumerable<ShareSignedIdentifier>> response = await share.GetAccessPolicyAsync();

            // Assert
            ShareSignedIdentifier acl = response.Value.First();

            Assert.AreEqual(1, response.Value.Count());
            Assert.AreEqual(signedIdentifiers[0].Id, acl.Id);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyStartsOn, acl.AccessPolicy.PolicyStartsOn);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyExpiresOn, acl.AccessPolicy.PolicyExpiresOn);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.Permissions, acl.AccessPolicy.Permissions);
        }

        [Test]
        public async Task GetAccessPolicyAsync_Error()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                share.GetAccessPolicyAsync(),
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode));
        }

        [Test]
        public async Task SetAccessPolicyAsync()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();

            // Act
            Response<ShareInfo> response = await share.SetAccessPolicyAsync(signedIdentifiers);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task SetAccessPolicyAsync_OldProperties()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange and Act
            ShareSignedIdentifier[] signedIdentifiers = new[]
                {
                    new ShareSignedIdentifier
                    {
                        Id = GetNewString(),
                        // Create an AccessPolicy with only StartsOn (old property)
                        AccessPolicy = new ShareAccessPolicy
                        {
                            StartsOn = Recording.UtcNow.AddHours(-1),
                            ExpiresOn = Recording.UtcNow.AddHours(+1)
                        }
                    }
                };
            // Assert
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyStartsOn, signedIdentifiers[0].AccessPolicy.StartsOn);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyExpiresOn, signedIdentifiers[0].AccessPolicy.ExpiresOn);

            // Act
            Response<ShareInfo> response = await share.SetAccessPolicyAsync(signedIdentifiers);

            // Assert
            Response<System.Collections.Generic.IEnumerable<ShareSignedIdentifier>> responseAfter = await share.GetAccessPolicyAsync();
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            ShareSignedIdentifier signedIdentifierResponse = responseAfter.Value.First();
            Assert.AreEqual(1, responseAfter.Value.Count());
            Assert.AreEqual(signedIdentifiers[0].Id, signedIdentifierResponse.Id);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyStartsOn, signedIdentifierResponse.AccessPolicy.PolicyStartsOn);
            Assert.AreEqual(signedIdentifierResponse.AccessPolicy.StartsOn, signedIdentifierResponse.AccessPolicy.PolicyStartsOn);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyExpiresOn, signedIdentifierResponse.AccessPolicy.PolicyExpiresOn);
            Assert.AreEqual(signedIdentifierResponse.AccessPolicy.ExpiresOn, signedIdentifierResponse.AccessPolicy.PolicyExpiresOn);
            Assert.IsNull(signedIdentifierResponse.AccessPolicy.Permissions);
        }

        [Test]
        public async Task SetAccessPolicyAsync_StartsPermissionsProperties()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareSignedIdentifier[] signedIdentifiers = new[]
            {
                new ShareSignedIdentifier
                {
                    Id = GetNewString(),
                    AccessPolicy = new ShareAccessPolicy
                    {
                        // Create an AccessPolicy without PolicyExpiresOn
                        PolicyStartsOn = Recording.UtcNow.AddHours(-1),
                        Permissions = "rw"
                    }
                }
            };
            // Assert
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyStartsOn, signedIdentifiers[0].AccessPolicy.StartsOn);
            Assert.IsNull(signedIdentifiers[0].AccessPolicy.PolicyExpiresOn);

            // Act
            Response<ShareInfo> response = await share.SetAccessPolicyAsync(signedIdentifiers);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

            Response<System.Collections.Generic.IEnumerable<ShareSignedIdentifier>> responseAfter = await share.GetAccessPolicyAsync();
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            ShareSignedIdentifier signedIdentifierResponse = responseAfter.Value.First();
            Assert.AreEqual(1, responseAfter.Value.Count());
            Assert.AreEqual(signedIdentifiers[0].Id, signedIdentifierResponse.Id);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyStartsOn, signedIdentifierResponse.AccessPolicy.PolicyStartsOn);
            Assert.AreEqual(signedIdentifierResponse.AccessPolicy.PolicyStartsOn, signedIdentifierResponse.AccessPolicy.StartsOn);
            Assert.IsNull(signedIdentifierResponse.AccessPolicy.PolicyExpiresOn);
            Assert.AreEqual(signedIdentifierResponse.AccessPolicy.Permissions, signedIdentifiers[0].AccessPolicy.Permissions);
        }

        [Test]
        public async Task SetAccessPolicyAsync_StartsExpiresProperties()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareSignedIdentifier[] signedIdentifiers = new[]
            {
                new ShareSignedIdentifier
                {
                    Id = GetNewString(),
                    AccessPolicy = new ShareAccessPolicy
                    {
                        // Create an AccessPolicy without PolicyExpiresOn
                        PolicyStartsOn = Recording.UtcNow.AddHours(-1),
                        PolicyExpiresOn = Recording.UtcNow.AddHours(+1)
                    }
                }
            };
            // Assert
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyStartsOn, signedIdentifiers[0].AccessPolicy.StartsOn);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyExpiresOn, signedIdentifiers[0].AccessPolicy.ExpiresOn);

            // Act
            Response<ShareInfo> response = await share.SetAccessPolicyAsync(signedIdentifiers);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

            Response<System.Collections.Generic.IEnumerable<ShareSignedIdentifier>> responseAfter = await share.GetAccessPolicyAsync();
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            ShareSignedIdentifier signedIdentifierResponse = responseAfter.Value.First();
            Assert.AreEqual(1, responseAfter.Value.Count());
            Assert.AreEqual(signedIdentifiers[0].Id, signedIdentifierResponse.Id);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyStartsOn, signedIdentifierResponse.AccessPolicy.PolicyStartsOn);
            Assert.AreEqual(signedIdentifierResponse.AccessPolicy.PolicyStartsOn, signedIdentifierResponse.AccessPolicy.StartsOn);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyExpiresOn, signedIdentifierResponse.AccessPolicy.PolicyExpiresOn);
            Assert.AreEqual(signedIdentifierResponse.AccessPolicy.PolicyExpiresOn, signedIdentifierResponse.AccessPolicy.ExpiresOn);
            Assert.IsNull(signedIdentifierResponse.AccessPolicy.Permissions);
        }

        [Test]
        public async Task SetAccessPolicyAsync_Error()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));
            ShareSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                share.SetAccessPolicyAsync(signedIdentifiers),
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode));
        }

        [Test]
        public async Task GetStatisticsAsync()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Act
            Response<ShareStatistics> response = await share.GetStatisticsAsync();

            // Assert
            Assert.IsNotNull(response);
        }

        [Test]
        public async Task GetStatisticsAsync_LargeShare()
        {
            // Arrange
            long size = 3 * (long)Constants.GB;
            MockResponse mockResponse = new MockResponse(200);
            mockResponse.SetContent($"﻿<?xml version=\"1.0\" encoding=\"utf-8\"?><ShareStats><ShareUsageBytes>{size}</ShareUsageBytes></ShareStats>");
            ShareClientOptions shareClientOption = new ShareClientOptions()
            {
                Transport = new MockTransport(mockResponse)
            };
            ShareClient shareClient = InstrumentClient(new ShareClient(new Uri(TestConfigDefault.FileServiceEndpoint), shareClientOption));

            // Act
            Response<ShareStatistics> response = await shareClient.GetStatisticsAsync();

            // Assert
            Assert.AreEqual(size, response.Value.ShareUsageInBytes);

            TestHelper.AssertExpectedException(
                () => { int intSize = response.Value.ShareUsageBytes; },
                new OverflowException(Constants.File.Errors.ShareUsageBytesOverflow));
        }

        [Test]
        public async Task GetStatisticsAsync_Error()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));
            ShareSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                share.GetStatisticsAsync(),
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode));
        }

        [Test]
        public async Task CreateSnapshotAsync()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Act
            Response<ShareSnapshotInfo> response = await share.CreateSnapshotAsync();

            // Assert
            Assert.IsNotNull(response);
        }

        [Test]
        public async Task CreateSnapshotAsync_Error()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                share.CreateSnapshotAsync(),
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode));
        }

        [Test]
        public async Task SetQuotaAsync()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Act
            await share.SetQuotaAsync(Constants.KB);

            // Assert
            Response<ShareProperties> response = await share.GetPropertiesAsync();
            Assert.AreEqual(Constants.KB, response.Value.QuotaInGB);
        }

        [Test]
        public async Task SetQuotaAsync_Error()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                share.SetQuotaAsync(Constants.KB),
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode));
        }

        [Test]
        public async Task DeleteAsync()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));
            await share.CreateAsync(quotaInGB: 1);

            // Act
            Response response = await share.DeleteAsync(false);

            // Assert
            Assert.IsNotNull(response.Headers.RequestId);
        }

        [Test]
        public async Task DeleteAsync_Snapshot()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));

            await share.CreateAsync(quotaInGB: 1);

            Response<ShareSnapshotInfo> response = await share.CreateSnapshotAsync();
            ShareClient snapshotShareClient = share.WithSnapshot(response.Value.Snapshot);

            // Act
            await snapshotShareClient.DeleteAsync(false);

            // Assert
            Response<bool> shareExistsResponse = await share.ExistsAsync();
            Response<bool> snapshotExistsResponse = await snapshotShareClient.ExistsAsync();

            Assert.IsTrue(shareExistsResponse.Value);
            Assert.IsFalse(snapshotExistsResponse.Value);

            // Cleanup
            await share.DeleteAsync();
        }

        [Test]
        public async Task DeleteAsync_SnapshotFailed()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            ShareClient snapshotShareClient = share.WithSnapshot("2020-06-26T00:49:21.0000000Z");

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
               snapshotShareClient.DeleteAsync(),
               e => Assert.AreEqual(ShareErrorCode.InvalidQueryParameterValue.ToString(), e.ErrorCode));
        }

        [Test]
        public async Task Delete_Error()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));
            ShareSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                share.DeleteAsync(false),
                e => Assert.AreEqual(ShareErrorCode.ShareNotFound.ToString(), e.ErrorCode));
        }

        [Test]
        public async Task CreateDirectoryAsync()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Act
            ShareDirectoryClient directory = await share.CreateDirectoryAsync(GetNewDirectoryName());
        }

        [Test]
        public async Task DeleteDirectoryAsync()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;
            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            // Act
            await share.DeleteDirectoryAsync(directoryName);
        }

        [Test]
        [TestCase("!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("%21%27%28%29%3B%5B%5D%40%26%25%3D%2B%24%2C%23äÄöÖüÜß%3B")]
        [TestCase("my cool directory")]
        [TestCase("directory")]
        public async Task GetDirectoryClient_SpecialCharacters(string directoryName)
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directoryFromShareClient = InstrumentClient(test.Share.GetDirectoryClient(directoryName));
            Uri expectedUri = new Uri($"https://{TestConfigDefault.AccountName}.file.core.windows.net/{test.Share.Name}/{Uri.EscapeDataString(directoryName)}");


            // Act
            Response<ShareDirectoryInfo> createResponse = await directoryFromShareClient.CreateAsync();

            ShareDirectoryClient directoryFromConstructor = new ShareDirectoryClient(
                TestConfigDefault.ConnectionString,
                test.Share.Name,
                directoryName,
                GetOptions());

            Response<ShareDirectoryProperties> propertiesResponse = await directoryFromConstructor.GetPropertiesAsync();

            List<ShareFileItem> shareFileItems = new List<ShareFileItem>();
            await foreach (ShareFileItem shareFileItem in test.Share.GetRootDirectoryClient().GetFilesAndDirectoriesAsync())
            {
                shareFileItems.Add(shareFileItem);
            }

            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(directoryFromConstructor.Uri);

            // Assert
            Assert.AreEqual(createResponse.Value.ETag, propertiesResponse.Value.ETag);

            Assert.AreEqual(1, shareFileItems.Count);
            Assert.AreEqual(directoryName, shareFileItems[0].Name);

            Assert.AreEqual(directoryName, directoryFromShareClient.Name);
            Assert.AreEqual(directoryName, directoryFromShareClient.Path);
            Assert.AreEqual(expectedUri, directoryFromShareClient.Uri);

            Assert.AreEqual(directoryName, directoryFromConstructor.Name);
            Assert.AreEqual(directoryName, directoryFromConstructor.Path);
            Assert.AreEqual(expectedUri, directoryFromConstructor.Uri);

            Assert.AreEqual(directoryName, shareUriBuilder.LastDirectoryOrFileName);
            Assert.AreEqual(directoryName, shareUriBuilder.DirectoryOrFilePath);
            Assert.AreEqual(expectedUri, shareUriBuilder.ToUri());
        }
    }
}
