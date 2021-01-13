// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Tests
{
    public class DirectoryClientTests : FileTestBase
    {
        public DirectoryClientTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
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
            var directoryPath = GetNewDirectoryName();

            ShareDirectoryClient directory = InstrumentClient(new ShareDirectoryClient(connectionString.ToString(true), shareName, directoryPath, GetOptions()));

            var builder = new ShareUriBuilder(directory.Uri);

            Assert.AreEqual(shareName, builder.ShareName);
            Assert.AreEqual(directoryPath, builder.DirectoryOrFilePath);
            //Assert.AreEqual("accountName", builder.AccountName);
        }

        [Test]
        //Test framework doesn't allow recorded tests with connection string because the word 'Sanitized' is not base-64 encoded,
        // so we can't pass connection string validation"
        [LiveOnly]
        public async Task Ctor_ConnectionStringEscapePath()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            string directoryName = "!#@&=;äÄöÖüÜß";
            ShareDirectoryClient initalDirectory = InstrumentClient(test.Share.GetDirectoryClient(directoryName));
            Response<ShareDirectoryInfo> createResponse = await initalDirectory.CreateAsync();

            // Act
            ShareDirectoryClient directory = new ShareDirectoryClient(
                TestConfigDefault.ConnectionString,
                test.Share.Name,
                directoryName,
                GetOptions());
            Response<ShareDirectoryProperties> propertiesResponse = await directory.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(createResponse.Value.ETag, propertiesResponse.Value.ETag);
        }

        [Test]
        public async Task Ctor_AzureSasCredential()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            string sas = GetNewFileServiceSasCredentialsShare(test.Share.Name).ToString();
            var client = test.Share.GetDirectoryClient(GetNewDirectoryName());
            await client.CreateAsync();
            Uri uri = client.Uri;

            // Act
            var sasClient = InstrumentClient(new ShareDirectoryClient(uri, new AzureSasCredential(sas), GetOptions()));
            ShareDirectoryProperties properties = await sasClient.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(properties);
        }

        [Test]
        public async Task Ctor_AzureSasCredential_VerifyNoSasInUri()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            string sas = GetNewFileServiceSasCredentialsShare(test.Share.Name).ToString();
            Uri uri = test.Share.GetDirectoryClient(GetNewDirectoryName()).Uri;
            uri = new Uri(uri.ToString() + "?" + sas);

            // Act
            TestHelper.AssertExpectedException<ArgumentException>(
                () => new ShareDirectoryClient(uri, new AzureSasCredential(sas)),
                e => e.Message.Contains($"You cannot use {nameof(AzureSasCredential)} when the resource URI also contains a Shared Access Signature"));
        }

        [Test]
        public void DirectoryPathsParsing()
        {
            // nested directories
            Uri uri1 = new Uri("http://dummyaccount.file.core.windows.net/share/dir1/dir2");
            var builder1 = new ShareUriBuilder(uri1);
            var directoryClient1 = new ShareDirectoryClient(uri1);
            TestHelper.AssertCacheableProperty("dir2", () => directoryClient1.Name);
            TestHelper.AssertCacheableProperty("dir1/dir2", () => directoryClient1.Path);
            Assert.AreEqual("dir2", builder1.LastDirectoryOrFileName);

            // one directory
            Uri uri2 = new Uri("http://dummyaccount.file.core.windows.net/share/dir1");
            var builder2 = new ShareUriBuilder(uri2);
            var directoryClient2 = new ShareDirectoryClient(uri2);
            TestHelper.AssertCacheableProperty("dir1", () => directoryClient2.Name);
            TestHelper.AssertCacheableProperty("dir1", () => directoryClient2.Path);
            Assert.AreEqual("dir1", builder2.LastDirectoryOrFileName);

            // directory with trailing slash
            Uri uri3 = new Uri("http://dummyaccount.file.core.windows.net/share/dir1/");
            var builder3 = new ShareUriBuilder(uri3);
            var directoryClient3 = new ShareDirectoryClient(uri3);
            TestHelper.AssertCacheableProperty("dir1", () => directoryClient3.Name);
            TestHelper.AssertCacheableProperty("dir1", () => directoryClient3.Path);
            Assert.AreEqual("dir1", builder3.LastDirectoryOrFileName);

            // no directory
            Uri uri4 = new Uri("http://dummyaccount.file.core.windows.net/share");
            var builder4 = new ShareUriBuilder(uri4);
            var directoryClient4 = new ShareDirectoryClient(uri4);
            TestHelper.AssertCacheableProperty(string.Empty, () => directoryClient4.Name);
            TestHelper.AssertCacheableProperty(string.Empty, () => directoryClient4.Path);
            Assert.AreEqual(string.Empty, builder4.LastDirectoryOrFileName);
        }

        [Test]
        public async Task CreateAsync()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            var name = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(name));

            // Act
            Response<ShareDirectoryInfo> response = await directory.CreateAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            var accountName = new ShareUriBuilder(directory.Uri).AccountName;
            TestHelper.AssertCacheableProperty(accountName, () => directory.AccountName);
            var shareName = new ShareUriBuilder(directory.Uri).ShareName;
            TestHelper.AssertCacheableProperty(shareName, () => directory.ShareName);
            TestHelper.AssertCacheableProperty(name, () => directory.Name);
        }

        [Test]
        public async Task CreateAsync_FilePermission()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            var filePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";

            // Act
            Response<ShareDirectoryInfo> response = await directory.CreateAsync(filePermission: filePermission);

            // Assert
            AssertValidStorageDirectoryInfo(response);
        }

        [Test]
        public async Task CreateAsync_FilePermissionAndFilePermissionKeySet()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            var filePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
            var fileSmbProperties = new FileSmbProperties()
            {
                FilePermissionKey = "filePermissionKey"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                directory.CreateAsync(
                    smbProperties: fileSmbProperties,
                    filePermission: filePermission),
                e => Assert.AreEqual("filePermission and filePermissionKey cannot both be set", e.Message));
        }

        [Test]
        public async Task CreateAsync_FilePermissionTooLarge()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            var filePermission = new string('*', 9 * Constants.KB);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                directory.CreateAsync(filePermission: filePermission),
                e =>
                {
                    Assert.AreEqual("filePermission", e.ParamName);
                    StringAssert.StartsWith("Value must be less than or equal to 8192", e.Message);
                });
        }

        [Test]
        public async Task CreateAsync_SmbProperties()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            var permission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
            Response<PermissionInfo> createPermissionResponse = await share.CreatePermissionAsync(permission);

            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            var smbProperties = new FileSmbProperties
            {
                FilePermissionKey = createPermissionResponse.Value.FilePermissionKey,
                FileAttributes = ShareExtensions.ToFileAttributes("Directory|ReadOnly"),
                FileCreatedOn = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero),
                FileLastWrittenOn = new DateTimeOffset(2019, 8, 26, 5, 15, 25, 60, TimeSpan.Zero),
            };

            // Act
            Response<ShareDirectoryInfo> response = await directory.CreateAsync(smbProperties: smbProperties);

            // Assert
            AssertValidStorageDirectoryInfo(response);
            //Assert.AreEqual(smbProperties.FileAttributes, response.Value.SmbProperties.Value.FileAttributes);
            Assert.AreEqual(smbProperties.FileCreatedOn, response.Value.SmbProperties.FileCreatedOn);
            Assert.AreEqual(smbProperties.FileLastWrittenOn, response.Value.SmbProperties.FileLastWrittenOn);
        }

        [Test]
        public async Task CreateAsync_Error()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            // Directory is intentionally created twice
            await directory.CreateIfNotExistsAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.CreateAsync(),
                e => Assert.AreEqual("ResourceAlreadyExists", e.ErrorCode));
        }

        [Test]
        public async Task CreateAsync_Metadata()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await directory.CreateAsync(metadata: metadata);

            // Assert
            Response<ShareDirectoryProperties> response = await directory.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
        }

        [Test]
        public async Task CreateIfNotExists_NotExists()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;
            string  name = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(name));

            // Act
            Response<ShareDirectoryInfo> response = await directory.CreateIfNotExistsAsync();

            // Assert
            Assert.IsNotNull(response);
        }

        [Test]
        public async Task CreateIfNotExists_Exists()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;
            string name = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(name));
            await directory.CreateIfNotExistsAsync();

            // Act
            Response<ShareDirectoryInfo> response = await directory.CreateIfNotExistsAsync();

            // Assert
            Assert.IsNull(response);
        }

        [Test]
        public async Task CreateIfNotExists_Error()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;
            string name = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(name));
            ShareDirectoryClient unauthorizedDirectory = InstrumentClient(new ShareDirectoryClient(directory.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedDirectory.CreateIfNotExistsAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        public async Task Exists_NotExists()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;
            string name = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(name));

            // Act
            Response<bool> response = await directory.ExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [Test]
        public async Task ExistsAsync_ShareNotExists()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(GetNewShareName()));
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            Response<bool> response = await directory.ExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [Test]
        public async Task ExistsAsync_ParentDirectoryNotExists()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient parentDirectory = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
            ShareDirectoryClient directory = InstrumentClient(parentDirectory.GetSubdirectoryClient(GetNewDirectoryName()));

            // Act
            Response<bool> response = await directory.ExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [Test]
        public async Task Exists_Exists()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;
            string name = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(name));
            await directory.CreateIfNotExistsAsync();

            // Act
            Response<bool> response = await directory.ExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);
        }

        [Test]
        public async Task Exists_Error()
        {
            // Arrange
            // Make Read Only SAS for the Share
            AccountSasBuilder sas = new AccountSasBuilder
            {
                Services = AccountSasServices.Files,
                ResourceTypes = AccountSasResourceTypes.Service,
                ExpiresOn = Recording.UtcNow.AddHours(1)
            };
            sas.SetPermissions(AccountSasPermissions.Read);
            StorageSharedKeyCredential credential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);
            UriBuilder sasUri = new UriBuilder(TestConfigDefault.FileServiceEndpoint);
            sasUri.Query = sas.ToSasQueryParameters(credential).ToString();
            ShareClient share = InstrumentClient(new ShareClient(sasUri.Uri, GetOptions()));
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.ExistsAsync(),
                e => { });
        }

        [Test]
        public async Task DeleteIfExists_Exists()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;
            string name = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(name));
            await directory.CreateIfNotExistsAsync();

            // Act
            Response<bool> response = await directory.DeleteIfExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);
        }

        [Test]
        public async Task DeleteIfExists_NotExists()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;
            string name = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(name));

            // Act
            Response<bool> response = await directory.DeleteIfExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [Test]
        public async Task DeleteIfExists_ShareNotExists()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(GetNewShareName()));
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            Response<bool> response = await directory.DeleteIfExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [Test]
        public async Task DeleteIfExists_ParentDirectoryNotExists()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient parentDirectory = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
            ShareDirectoryClient directory = InstrumentClient(parentDirectory.GetSubdirectoryClient(GetNewDirectoryName()));

            // Act
            Response<bool> response = await directory.DeleteIfExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [Test]
        public async Task DeleteIfExists_Error()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;
            string name = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(name));
            await directory.CreateIfNotExistsAsync();
            await directory.CreateFileAsync(GetNewFileName(), Constants.KB);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.DeleteIfExistsAsync(),
                e => Assert.AreEqual("DirectoryNotEmpty", e.ErrorCode));
        }

        [Test]
        public async Task DeleteAsync()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Act
            Response response = await directory.DeleteAsync();

            // Assert
            Assert.IsNotNull(response.Headers.RequestId);
        }

        [Test]
        public async Task DeleteAsync_Error()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.DeleteAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            Response<ShareDirectoryInfo> createResponse = await directory.CreateIfNotExistsAsync();
            Response<ShareDirectoryProperties> getPropertiesResponse = await directory.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(createResponse.Value.ETag, getPropertiesResponse.Value.ETag);
            Assert.AreEqual(createResponse.Value.LastModified, getPropertiesResponse.Value.LastModified);
            AssertPropertiesEqual(createResponse.Value.SmbProperties, getPropertiesResponse.Value.SmbProperties);
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.GetPropertiesAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        public async Task GetPropertiesAsync_Snapshot()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directory = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
            await directory.CreateAsync();

            Response<ShareSnapshotInfo> createSnapshotResponse = await test.Share.CreateSnapshotAsync();
            ShareClient snapshotShareClient = test.Share.WithSnapshot(createSnapshotResponse.Value.Snapshot);
            ShareDirectoryClient snapshotDirectoryClient = snapshotShareClient.GetDirectoryClient(directory.Name);

            // Act
            Response<ShareDirectoryProperties> getPropertiesResponse = await directory.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(getPropertiesResponse.Value.ETag);
        }

        [Test]
        public async Task GetPropertiesAsync_SnapshotFailed()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directory = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
            await directory.CreateAsync();

            ShareClient snapshotShareClient = test.Share.WithSnapshot("2020-06-26T00:49:21.0000000Z");
            ShareDirectoryClient snapshotDirectoryClient = snapshotShareClient.GetDirectoryClient(directory.Name);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                snapshotShareClient.GetPropertiesAsync(),
                e => Assert.AreEqual(ShareErrorCode.ShareNotFound.ToString(), e.ErrorCode));
        }

        [Test]
        public async Task SetPropertiesAsync_FilePermission()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            var filePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
            await directory.CreateIfNotExistsAsync();

            // Act
            Response<ShareDirectoryInfo> response = await directory.SetHttpHeadersAsync(filePermission: filePermission);

            // Assert
            AssertValidStorageDirectoryInfo(response);
        }

        [Test]
        public async Task SetPropertiesAsync_SmbProperties()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            var permission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
            Response<PermissionInfo> createPermissionResponse = await share.CreatePermissionAsync(permission);

            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            var smbProperties = new FileSmbProperties
            {
                FilePermissionKey = createPermissionResponse.Value.FilePermissionKey,
                FileAttributes = ShareExtensions.ToFileAttributes("Directory|ReadOnly"),
                FileCreatedOn = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero),
                FileLastWrittenOn = new DateTimeOffset(2019, 8, 26, 5, 15, 25, 60, TimeSpan.Zero),
            };

            await directory.CreateIfNotExistsAsync();

            // Act
            Response<ShareDirectoryInfo> response = await directory.SetHttpHeadersAsync(smbProperties: smbProperties);

            // Assert
            AssertValidStorageDirectoryInfo(response);
            Assert.AreEqual(smbProperties.FileAttributes, response.Value.SmbProperties.FileAttributes);
            Assert.AreEqual(smbProperties.FileCreatedOn, response.Value.SmbProperties.FileCreatedOn);
            Assert.AreEqual(smbProperties.FileLastWrittenOn, response.Value.SmbProperties.FileLastWrittenOn);
        }

        [Test]
        public async Task SetPropertiesAsync_FilePermissionTooLong()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            var filePermission = new string('*', 9 * Constants.KB);
            await directory.CreateIfNotExistsAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                directory.SetHttpHeadersAsync(
                    filePermission: filePermission),
                new ArgumentOutOfRangeException("filePermission", "Value must be less than or equal to 8192"));
        }

        [Test]
        public async Task SetPropertiesAsync_FilePermissionAndFilePermissionKeySet()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            var filePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
            var fileSmbProperties = new FileSmbProperties()
            {
                FilePermissionKey = "filePermissionKey"
            };
            await directory.CreateIfNotExistsAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                directory.SetHttpHeadersAsync(
                    smbProperties: fileSmbProperties,
                    filePermission: filePermission),
                e => Assert.AreEqual("filePermission and filePermissionKey cannot both be set", e.Message));
        }

        [Test]
        public async Task SetMetadataAsync()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await directory.SetMetadataAsync(metadata);

            // Assert
            Response<ShareDirectoryProperties> response = await directory.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
        }

        [Test]
        public async Task SetMetadataAsync_Error()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.SetMetadataAsync(metadata),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        public async Task ListFilesAndDirectoriesSegmentAsync()
        {
            // Arrange
            var numFiles = 10;
            var fileNames = Enumerable.Range(0, numFiles).Select(_ => GetNewFileName()).ToArray();

            var numDirectories = 5;
            var directoryNames = Enumerable.Range(0, numDirectories).Select(_ => GetNewFileName()).ToArray();

            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            await directory.CreateIfNotExistsAsync();

            foreach (var fileName in fileNames)
            {
                ShareFileClient file = InstrumentClient(directory.GetFileClient(fileName));

                await file.CreateAsync(maxSize: Constants.MB);
            }

            foreach (var subDirName in directoryNames)
            {
                ShareDirectoryClient subDir = InstrumentClient(directory.GetSubdirectoryClient(subDirName));

                await subDir.CreateIfNotExistsAsync();
            }

            var directories = new List<ShareFileItem>();
            var files = new List<ShareFileItem>();

            // Act
            await foreach (Page<ShareFileItem> page in directory.GetFilesAndDirectoriesAsync().AsPages())
            {
                directories.AddRange(page.Values.Where(item => item.IsDirectory));
                files.AddRange(page.Values.Where(item => !item.IsDirectory));
            }

            // Assert
            Assert.AreEqual(directoryNames.Length, directories.Count);
            Assert.AreEqual(fileNames.Length, files.Count);

            var foundDirectoryNames = directories.Select(entry => entry.Name).ToArray();
            var foundFileNames = files.Select(entry => entry.Name).ToArray();

            Assert.IsTrue(directoryNames.All(fileName => foundDirectoryNames.Contains(fileName)));
            Assert.IsTrue(fileNames.All(fileName => foundFileNames.Contains(fileName)));
        }

        [Test]
        public async Task ListFilesAndDirectoriesSegmentAsync_Error()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.GetFilesAndDirectoriesAsync().ToListAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        [AsyncOnly]
        public async Task ListHandles()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Act
            var handles = (await directory.GetHandlesAsync(recursive: true)
                .AsPages(pageSizeHint: 5)
                .ToListAsync())
                .SelectMany(p => p.Values)
                .ToList();

            // Assert
            Assert.AreEqual(0, handles.Count);
        }

        [Test]
        public async Task ListHandles_Min()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Act
            IList<ShareFileHandle> handles = await directory.GetHandlesAsync().ToListAsync();

            // Assert
            Assert.AreEqual(0, handles.Count);
        }

        [Test]
        public async Task ListHandles_Error()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.GetHandlesAsync().ToListAsync(),
                actualException => Assert.AreEqual("ResourceNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task ForceCloseHandles_Min()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Act
            CloseHandlesResult response = await directory.ForceCloseAllHandlesAsync();

            // Assert
            Assert.AreEqual(0, response.ClosedHandlesCount);
            Assert.AreEqual(0, response.FailedHandlesCount);
        }

        [Test]
        public async Task ForceCloseHandles_Recursive()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Act
            CloseHandlesResult response = await directory.ForceCloseAllHandlesAsync(recursive: true);

            // Assert
            Assert.AreEqual(0, response.ClosedHandlesCount);
            Assert.AreEqual(0, response.FailedHandlesCount);
        }

        [Test]
        public async Task ForceCloseHandles_Error()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.ForceCloseAllHandlesAsync(),
                actualException => Assert.AreEqual("ResourceNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task ForceCloseHandle_Error()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            AsyncPageable<ShareFileHandle> handles = directory.GetHandlesAsync();
            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.ForceCloseHandleAsync("nonExistantHandleId"),
                actualException => Assert.AreEqual("InvalidHeaderValue", actualException.ErrorCode));
        }

        [Test]
        public async Task CreateSubdirectoryAsync()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient dir = test.Directory;

            ShareDirectoryClient subdir = (await dir.CreateSubdirectoryAsync(GetNewDirectoryName())).Value;

            Response<ShareDirectoryProperties> properties = await subdir.GetPropertiesAsync();
            Assert.IsNotNull(properties.Value);
        }

        [Test]
        public async Task DeleteSubdirectoryAsync()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient dir = test.Directory;

            var name = GetNewDirectoryName();
            ShareDirectoryClient subdir = (await dir.CreateSubdirectoryAsync(name)).Value;

            await dir.DeleteSubdirectoryAsync(name);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await subdir.GetPropertiesAsync());
        }

        [Test]
        public async Task CreateFileAsync()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient dir = test.Directory;

            ShareFileClient file = (await dir.CreateFileAsync(GetNewFileName(), 1024)).Value;

            Response<ShareFileProperties> properties = await file.GetPropertiesAsync();
            Assert.IsNotNull(properties.Value);
        }

        [Test]
        public async Task DeleteFileAsync()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient dir = test.Directory;

            var name = GetNewFileName();
            ShareFileClient file = (await dir.CreateFileAsync(name, 1024)).Value;

            await dir.DeleteFileAsync(name);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await file.GetPropertiesAsync());
        }

        [Test]
        public async Task GetDirectoryAsync_AsciiName()
        {
            await using DisposingShare test = await GetTestShareAsync();
            string name = GetNewDirectoryName();

            ShareDirectoryClient subdir = InstrumentClient(test.Share.GetDirectoryClient(name));
            await subdir.CreateAsync();

            // Assert
            List<string> names = new List<string>();
            ShareDirectoryClient rootDirectory = InstrumentClient(test.Share.GetRootDirectoryClient());
            await foreach (ShareFileItem item in rootDirectory.GetFilesAndDirectoriesAsync())
            {
                names.Add(item.Name);
            }
            Assert.AreEqual(1, names.Count);
            Assert.Contains(name, names);
        }

        [Test]
        public async Task GetDirectoryAsync_NonAsciiName()
        {
            await using DisposingShare test = await GetTestShareAsync();
            string name = GetNewNonAsciiDirectoryName();

            ShareDirectoryClient subdir = InstrumentClient(test.Share.GetDirectoryClient(name));
            await subdir.CreateAsync();

            // Assert
            List<string> names = new List<string>();
            ShareDirectoryClient rootDirectory = InstrumentClient(test.Share.GetRootDirectoryClient());
            await foreach (ShareFileItem item in rootDirectory.GetFilesAndDirectoriesAsync())
            {
                names.Add(item.Name);
            }
            Assert.AreEqual(1, names.Count);
            Assert.Contains(name, names);
        }

        [Test]
        public async Task GetSubdirectoryAsync_AsciiName()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient dir = test.Directory;
            string name = GetNewDirectoryName();

            ShareDirectoryClient subdir = InstrumentClient(dir.GetSubdirectoryClient(name));
            await subdir.CreateAsync();

            // Assert
            List<string> names = new List<string>();
            await foreach (ShareFileItem item in test.Directory.GetFilesAndDirectoriesAsync())
            {
                names.Add(item.Name);
            }
            Assert.AreEqual(1, names.Count);
            Assert.Contains(name, names);
        }

        [Test]
        public async Task GetSubdirectoryAsync_NonAsciiName()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient dir = test.Directory;
            string name = GetNewDirectoryName();

            ShareDirectoryClient subdir = InstrumentClient(dir.GetSubdirectoryClient(name));
            await subdir.CreateAsync();

            // Assert
            List<string> names = new List<string>();
            await foreach (ShareFileItem item in test.Directory.GetFilesAndDirectoriesAsync())
            {
                names.Add(item.Name);
            }
            Assert.AreEqual(1, names.Count);
            Assert.Contains(name, names);
        }

        [Test]
        [TestCase("directory", "!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("!'();[]", "!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("%21%27%28%29", "!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("directory", "%2C%23äÄöÖüÜß%3B")]
        [TestCase("!'();[]", "%21%27%28%29%3B%5B%23äÄöÖüÜß%3B")]
        [TestCase("%21%27%28%29%3B%5B%5D", "%2B%24%2C%23äÄöÖüÜß%3B")]
        [TestCase("directory", "my cool file")]
        [TestCase("directory", "file")]
        public async Task GetFileClient_SpecialCharacters(string directoryName, string fileName)
        {
            await using DisposingShare test = await GetTestShareAsync();
            string path = $"{directoryName}/{fileName}";
            ShareDirectoryClient directoryClient = test.Share.GetDirectoryClient(directoryName);
            await directoryClient.CreateAsync();
            ShareFileClient fileFromDirectoryClient = InstrumentClient(directoryClient.GetFileClient(fileName));
            Response<ShareFileInfo> createResponse = await fileFromDirectoryClient.CreateAsync(Constants.KB);

            Uri expectedUri = new Uri($"https://{TestConfigDefault.AccountName}.file.core.windows.net/{test.Share.Name}/{Uri.EscapeDataString(directoryName)}/{Uri.EscapeDataString(fileName)}");

            ShareFileClient fileFromConstructor = new ShareFileClient(
                TestConfigDefault.ConnectionString,
                test.Share.Name,
                $"{directoryName}/{fileName}",
                GetOptions());

            Response<ShareFileProperties> propertiesResponse = await fileFromConstructor.GetPropertiesAsync();

            List<ShareFileItem> shareFileItems = new List<ShareFileItem>();
            await foreach (ShareFileItem shareFileItem in directoryClient.GetFilesAndDirectoriesAsync())
            {
                shareFileItems.Add(shareFileItem);
            }

            // SAS
            ShareFileClient sasFile = GetServiceClient_FileServiceSasFile(test.Share.Name, path)
                .GetShareClient(test.Share.Name)
                .GetDirectoryClient(directoryName)
                .GetFileClient(fileName);

            await sasFile.GetPropertiesAsync();

            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(fileFromConstructor.Uri);

            // Assert
            Assert.AreEqual(createResponse.Value.ETag, propertiesResponse.Value.ETag);

            Assert.AreEqual(1, shareFileItems.Count);
            Assert.AreEqual(fileName, shareFileItems[0].Name);

            Assert.AreEqual(fileName, fileFromDirectoryClient.Name);
            Assert.AreEqual(path, fileFromDirectoryClient.Path);
            Assert.AreEqual(expectedUri, fileFromDirectoryClient.Uri);

            Assert.AreEqual(fileName, fileFromConstructor.Name);
            Assert.AreEqual(path, fileFromConstructor.Path);
            Assert.AreEqual(expectedUri, fileFromConstructor.Uri);

            Assert.AreEqual(fileName, shareUriBuilder.LastDirectoryOrFileName);
            Assert.AreEqual(path, shareUriBuilder.DirectoryOrFilePath);
            Assert.AreEqual(expectedUri, shareUriBuilder.ToUri());
        }

        [Test]
        [TestCase("directory", "!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("!'();[]@&%=+$", "!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("%21%27%28%29%3B%5B%5D", "!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("directory", "%21%27%28%2B%24%2C%23äÄöÖüÜß%3B")]
        [TestCase("!'();[]@&%=+$", "%21%27%24%2C%23äÄöÖüÜß%3B")]
        [TestCase("%21%27%28", "%21%27%28%29%3B%5B%5D%40%26äÄöÖüÜß%3B")]
        [TestCase("directory", "my cool directory")]
        [TestCase("directory0", "directory1")]
        public async Task GetSubDirectoryClient_SpecialCharacters(string directoryName, string subDirectoryName)
        {
            await using DisposingShare test = await GetTestShareAsync();
            string path = $"{directoryName}/{subDirectoryName}";
            ShareDirectoryClient directoryClient = test.Share.GetDirectoryClient(directoryName);
            await directoryClient.CreateAsync();
            ShareDirectoryClient directoryFromDirectoryClient = InstrumentClient(directoryClient.GetSubdirectoryClient(subDirectoryName));
            Response<ShareDirectoryInfo> createResponse = await directoryFromDirectoryClient.CreateAsync();

            Uri expectedUri = new Uri($"https://{TestConfigDefault.AccountName}.file.core.windows.net/{test.Share.Name}/{Uri.EscapeDataString(directoryName)}/{Uri.EscapeDataString(subDirectoryName)}");

            ShareDirectoryClient directoryFromConstructor = new ShareDirectoryClient(
                TestConfigDefault.ConnectionString,
                test.Share.Name,
                $"{directoryName}/{subDirectoryName}",
                GetOptions());

            Response<ShareDirectoryProperties> propertiesResponse = await directoryFromConstructor.GetPropertiesAsync();

            List<ShareFileItem> shareFileItems = new List<ShareFileItem>();
            await foreach (ShareFileItem shareFileItem in directoryClient.GetFilesAndDirectoriesAsync())
            {
                shareFileItems.Add(shareFileItem);
            }

            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(directoryFromConstructor.Uri);

            // Assert
            Assert.AreEqual(createResponse.Value.ETag, propertiesResponse.Value.ETag);

            Assert.AreEqual(1, shareFileItems.Count);
            Assert.AreEqual(subDirectoryName, shareFileItems[0].Name);

            Assert.AreEqual(subDirectoryName, directoryFromDirectoryClient.Name);
            Assert.AreEqual(path, directoryFromDirectoryClient.Path);
            Assert.AreEqual(expectedUri, directoryFromDirectoryClient.Uri);

            Assert.AreEqual(subDirectoryName, directoryFromConstructor.Name);
            Assert.AreEqual(path, directoryFromConstructor.Path);
            Assert.AreEqual(expectedUri, directoryFromConstructor.Uri);

            Assert.AreEqual(subDirectoryName, shareUriBuilder.LastDirectoryOrFileName);
            Assert.AreEqual(path, shareUriBuilder.DirectoryOrFilePath);
            Assert.AreEqual(expectedUri, shareUriBuilder.ToUri());
        }

        #region GenerateSasTests
        [Test]
        public void CanGenerateSas_ClientConstructors()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, fileStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Act - ShareDirectoryClient(string connectionString, string blobContainerName, string blobName)
            ShareDirectoryClient directory = InstrumentClient(new ShareDirectoryClient(
                connectionString,
                GetNewShareName(),
                GetNewDirectoryName()));
            Assert.IsTrue(directory.CanGenerateSasUri);

            // Act - ShareDirectoryClient(string connectionString, string blobContainerName, string blobName, BlobClientOptions options)
            ShareDirectoryClient directory2 = InstrumentClient(new ShareDirectoryClient(
                connectionString,
                GetNewShareName(),
                GetNewDirectoryName(),
                GetOptions()));
            Assert.IsTrue(directory2.CanGenerateSasUri);

            // Act - ShareDirectoryClient(Uri blobContainerUri, BlobClientOptions options = default)
            ShareDirectoryClient directory3 = InstrumentClient(new ShareDirectoryClient(
                blobEndpoint,
                GetOptions()));
            Assert.IsFalse(directory3.CanGenerateSasUri);

            // Act - ShareDirectoryClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            ShareDirectoryClient directory4 = InstrumentClient(new ShareDirectoryClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            Assert.IsTrue(directory4.CanGenerateSasUri);
        }

        [Test]
        public void CanGenerateSas_GetFileClient()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, fileStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Act - ShareDirectoryClient(string connectionString, string blobContainerName, string blobName)
            ShareDirectoryClient directory = InstrumentClient(new ShareDirectoryClient(
                connectionString,
                GetNewShareName(),
                GetNewDirectoryName()));
            ShareFileClient file = directory.GetFileClient(GetNewFileName());
            Assert.IsTrue(file.CanGenerateSasUri);

            // Act - ShareDirectoryClient(string connectionString, string blobContainerName, string blobName, BlobClientOptions options)
            ShareDirectoryClient directory2 = InstrumentClient(new ShareDirectoryClient(
                connectionString,
                GetNewShareName(),
                GetNewDirectoryName(),
                GetOptions()));
            ShareFileClient file2 = directory2.GetFileClient(GetNewFileName());
            Assert.IsTrue(file2.CanGenerateSasUri);

            // Act - ShareDirectoryClient(Uri blobContainerUri, BlobClientOptions options = default)
            ShareDirectoryClient directory3 = InstrumentClient(new ShareDirectoryClient(
                blobEndpoint,
                GetOptions()));
            ShareFileClient file3 = directory3.GetFileClient(GetNewFileName());
            Assert.IsFalse(file3.CanGenerateSasUri);

            // Act - ShareDirectoryClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            ShareDirectoryClient directory4 = InstrumentClient(new ShareDirectoryClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            ShareFileClient file4 = directory4.GetFileClient(GetNewFileName());
            Assert.IsTrue(file4.CanGenerateSasUri);
        }

        [Test]
        public void CanGenerateSas_GetSubdirectoryClient()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, fileStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Act - ShareDirectoryClient(string connectionString, string blobContainerName, string blobName)
            ShareDirectoryClient directory = InstrumentClient(new ShareDirectoryClient(
                connectionString,
                GetNewShareName(),
                GetNewDirectoryName()));
            ShareDirectoryClient subdirectory = directory.GetSubdirectoryClient(GetNewFileName());
            Assert.IsTrue(subdirectory.CanGenerateSasUri);

            // Act - ShareDirectoryClient(string connectionString, string blobContainerName, string blobName, BlobClientOptions options)
            ShareDirectoryClient directory2 = InstrumentClient(new ShareDirectoryClient(
                connectionString,
                GetNewShareName(),
                GetNewDirectoryName(),
                GetOptions()));
            ShareDirectoryClient subdirectory2 = directory2.GetSubdirectoryClient(GetNewFileName());
            Assert.IsTrue(subdirectory2.CanGenerateSasUri);

            // Act - ShareDirectoryClient(Uri blobContainerUri, BlobClientOptions options = default)
            ShareDirectoryClient directory3 = InstrumentClient(new ShareDirectoryClient(
                blobEndpoint,
                GetOptions()));
            ShareDirectoryClient subdirectory3 = directory3.GetSubdirectoryClient(GetNewFileName());
            Assert.IsFalse(subdirectory3.CanGenerateSasUri);

            // Act - ShareDirectoryClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            ShareDirectoryClient directory4 = InstrumentClient(new ShareDirectoryClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            ShareDirectoryClient subdirectory4 = directory4.GetSubdirectoryClient(GetNewFileName());
            Assert.IsTrue(subdirectory4.CanGenerateSasUri);
        }

        [Test]
        public void GenerateSas_RequiredParameters()
        {
            // Arrange
            var constants = new TestConstants(this);
            ShareFileSasPermissions permissions =ShareFileSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, fileStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);
            string shareName = GetNewShareName();
            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directoryClient = InstrumentClient(new ShareDirectoryClient(
                connectionString,
                shareName,
                directoryName,
                GetOptions()));

            // Act
            Uri sasUri = directoryClient.GenerateSasUri(permissions, expiresOn);

            // Assert
            ShareSasBuilder sasBuilder = new ShareSasBuilder(permissions, expiresOn)
            {
                ShareName = shareName,
                FilePath = directoryName,
            };
            ShareUriBuilder expectedUri = new ShareUriBuilder(blobEndpoint)
            {
                ShareName = shareName,
                DirectoryOrFilePath = directoryName,
                Sas = sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.AreEqual(expectedUri.ToUri().ToString(), sasUri.ToString());
        }

        [Test]
        public void GenerateSas_Builder()
        {
            var constants = new TestConstants(this);
            ShareFileSasPermissions permissions = ShareFileSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, fileStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);
            string shareName = GetNewShareName();
            string directoryName = GetNewDirectoryName();

            ShareDirectoryClient directoryClient = InstrumentClient(new ShareDirectoryClient(
                connectionString,
                shareName,
                directoryName,
                GetOptions()));

            ShareSasBuilder sasBuilder = new ShareSasBuilder(permissions, expiresOn)
            {
                ShareName = shareName,
                FilePath = directoryName,
                StartsOn = startsOn
            };

            // Act
            Uri sasUri = directoryClient.GenerateSasUri(sasBuilder);

            // Assert
            ShareSasBuilder sasBuilder2 = new ShareSasBuilder(permissions, expiresOn)
            {
                ShareName = shareName,
                FilePath = directoryName,
                StartsOn = startsOn
            };
            ShareUriBuilder expectedUri = new ShareUriBuilder(blobEndpoint)
            {
                ShareName = shareName,
                DirectoryOrFilePath = directoryName,
                Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.AreEqual(expectedUri.ToUri().ToString(), sasUri.ToString());
        }

        [Test]
        public void GenerateSas_BuilderWrongShareName()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("http://127.0.0.1/");
            UriBuilder blobUriBuilder = new UriBuilder(blobEndpoint);
            string directoryName = GetNewDirectoryName();
            blobUriBuilder.Path += constants.Sas.Account + "/" + GetNewShareName() + "/" + directoryName;
            ShareDirectoryClient directoryClient = InstrumentClient(new ShareDirectoryClient(
                blobUriBuilder.Uri,
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            ShareSasBuilder sasBuilder = new ShareSasBuilder(ShareFileSasPermissions.All, Recording.UtcNow.AddHours(+1))
            {
                ShareName = GetNewShareName(), // different share name
                FilePath = directoryName
            };

            // Act
            try
            {
                Uri sasUri = directoryClient.GenerateSasUri(sasBuilder);

                Assert.Fail("ShareDirectoryClient.GenerateSasUri should have failed with an ArgumentException.");
            }
            catch (InvalidOperationException)
            {
                //the correct exception came back
            }
        }

        [Test]
        public void GenerateSas_BuilderWrongDirectoryName()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("http://127.0.0.1/");
            UriBuilder blobUriBuilder = new UriBuilder(blobEndpoint);
            string shareName = GetNewShareName();
            blobUriBuilder.Path += constants.Sas.Account + "/" + shareName + "/" + GetNewDirectoryName();
            ShareDirectoryClient directoryClient = InstrumentClient(new ShareDirectoryClient(
                blobUriBuilder.Uri,
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            ShareSasBuilder sasBuilder = new ShareSasBuilder(ShareFileSasPermissions.All, Recording.UtcNow.AddHours(+1))
            {
                ShareName = shareName,
                FilePath = GetNewDirectoryName() // different directory name
            };

            // Act
            try
            {
                Uri sasUri = directoryClient.GenerateSasUri(sasBuilder);

                Assert.Fail("ShareDirectoryClient.GenerateSasUri should have failed with an ArgumentException.");
            }
            catch (InvalidOperationException)
            {
                //the correct exception came back
            }
        }
        #endregion
    }
}
