// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Files.Shares.Tests;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Test
{
    public class ShareClientTests : FileTestBase
    {
        public ShareClientTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
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

            var connectionString = new StorageConnectionString(credentials, (default, default), (default, default), (default, default), (fileEndpoint, fileSecondaryEndpoint));

            var shareName = GetNewShareName();

            ShareClient share = InstrumentClient(new ShareClient(connectionString.ToString(true), shareName, GetOptions()));

            var builder = new ShareUriBuilder(share.Uri);

            Assert.AreEqual(shareName, builder.ShareName);
            Assert.AreEqual("", builder.DirectoryOrFilePath);
            //Assert.AreEqual("accountName", builder.AccountName);
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
            AssertMetadataEquality(metadata, response.Value.Metadata);

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
                e => Assert.AreEqual("ShareAlreadyExists", e.ErrorCode.Split('\n')[0]));

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
        public async Task GetPropertiesAsync()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Act
            Response<ShareProperties> reponse = await share.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(reponse.GetRawResponse().Headers.RequestId);
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
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode.Split('\n')[0]));
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
            AssertMetadataEquality(metadata, response.Value.Metadata);
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
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode.Split('\n')[0]));
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
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.StartsOn, acl.AccessPolicy.StartsOn);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.ExpiresOn, acl.AccessPolicy.ExpiresOn);
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
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode.Split('\n')[0]));
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
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task GetStatisticsAsync()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Act
            Response<ShareStatistics> response = await share.GetStatisticsAsync();

            // Assert
            Assert.IsNotNull(response);
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
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode.Split('\n')[0]));
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
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode.Split('\n')[0]));
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
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode.Split('\n')[0]));
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
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task CreateDirectoryAsync()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            ShareDirectoryClient dir = InstrumentClient((await share.CreateDirectoryAsync(GetNewDirectoryName())).Value);

            Response<ShareDirectoryProperties> properties = await dir.GetPropertiesAsync();
            Assert.IsNotNull(properties.Value);
        }

        [Test]
        public async Task DeleteDirectoryAsync()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            var name = GetNewDirectoryName();
            ShareDirectoryClient dir = InstrumentClient((await share.CreateDirectoryAsync(name)).Value);

            await share.DeleteDirectoryAsync(name);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await dir.GetPropertiesAsync());
        }
    }
}
