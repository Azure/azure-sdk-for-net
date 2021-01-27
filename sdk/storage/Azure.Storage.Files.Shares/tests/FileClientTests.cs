// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Files.Shares.Specialized;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using BenchmarkDotNet.Toolchains.Roslyn;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Tests
{
    public class FileClientTests : FileTestBase
    {
        public FileClientTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
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

            var connectionString = new StorageConnectionString(credentials, fileStorageUri: (fileEndpoint, fileSecondaryEndpoint));

            var shareName = GetNewShareName();
            var filePath = GetNewFileName();

            ShareFileClient file = InstrumentClient(new ShareFileClient(connectionString.ToString(true), shareName, filePath, GetOptions()));

            var builder = new ShareUriBuilder(file.Uri);

            Assert.AreEqual(shareName, builder.ShareName);
            Assert.AreEqual(filePath, builder.DirectoryOrFilePath);
            //Assert.AreEqual("accountName", builder.AccountName);
        }

        [Test]
        public async Task Ctor_ConnectionStringEscapePath()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            string directoryName = "!#@&=;äÄ";
            string fileName = "#$=;!öÖ";
            ShareDirectoryClient directory = InstrumentClient(test.Share.GetDirectoryClient(directoryName));
            await directory.CreateAsync();
            ShareFileClient initalFile = InstrumentClient(directory.GetFileClient(fileName));
            Response<ShareFileInfo> createResponse = await initalFile.CreateAsync(Constants.KB);

            // Act
            ShareFileClient file = new ShareFileClient(
                TestConfigDefault.ConnectionString,
                test.Share.Name,
                $"{directoryName}/{fileName}",
                GetOptions());
            Response<ShareFileProperties> propertiesResponse = await file.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(createResponse.Value.ETag, propertiesResponse.Value.ETag);
        }

        [Test]
        public async Task Ctor_AzureSasCredential()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            string sas = GetNewFileServiceSasCredentialsShare(test.Share.Name).ToString();
            var client = test.Share.GetRootDirectoryClient().GetFileClient(GetNewFileName());
            await client.CreateAsync(1024);
            Uri uri = client.Uri;

            // Act
            var sasClient = InstrumentClient(new ShareFileClient(uri, new AzureSasCredential(sas), GetOptions()));
            ShareFileProperties properties = await sasClient.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(properties);
        }

        [Test]
        public async Task Ctor_AzureSasCredential_VerifyNoSasInUri()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            string sas = GetNewFileServiceSasCredentialsShare(test.Share.Name).ToString();
            Uri uri = test.Share.GetRootDirectoryClient().GetFileClient(GetNewFileName()).Uri;
            uri = new Uri(uri.ToString() + "?" + sas);

            // Act
            TestHelper.AssertExpectedException<ArgumentException>(
                () => new ShareFileClient(uri, new AzureSasCredential(sas)),
                e => e.Message.Contains($"You cannot use {nameof(AzureSasCredential)} when the resource URI also contains a Shared Access Signature"));
        }

        [Test]
        public void FilePathsParsing()
        {
            // nested directories
            Uri uri1 = new Uri("http://dummyaccount.file.core.windows.net/share/dir1/dir2/file.txt");
            var builder1 = new ShareUriBuilder(uri1);
            var fileClient1 = new ShareFileClient(uri1);
            TestHelper.AssertCacheableProperty("file.txt", () => fileClient1.Name);
            TestHelper.AssertCacheableProperty("dir1/dir2/file.txt", () => fileClient1.Path);
            Assert.AreEqual("file.txt", builder1.LastDirectoryOrFileName);

            // one directory
            Uri uri2 = new Uri("http://dummyaccount.file.core.windows.net/share/dir1/file.txt");
            var builder2 = new ShareUriBuilder(uri2);
            var fileClient2 = new ShareFileClient(uri2);
            TestHelper.AssertCacheableProperty("file.txt", () => fileClient2.Name);
            TestHelper.AssertCacheableProperty("dir1/file.txt", () => fileClient2.Path);
            Assert.AreEqual("file.txt", builder2.LastDirectoryOrFileName);

            // trailing slash
            Uri uri3 = new Uri("http://dummyaccount.file.core.windows.net/share/dir1/file.txt/");
            var builder3 = new ShareUriBuilder(uri3);
            var fileClient3 = new ShareFileClient(uri3);
            TestHelper.AssertCacheableProperty("file.txt", () => fileClient3.Name);
            TestHelper.AssertCacheableProperty("dir1/file.txt", () => fileClient3.Path);
            Assert.AreEqual("file.txt", builder3.LastDirectoryOrFileName);

            // no directories
            Uri uri4 = new Uri("http://dummyaccount.file.core.windows.net/share/file.txt");
            var builder4 = new ShareUriBuilder(uri4);
            var fileClient4 = new ShareFileClient(uri4);
            TestHelper.AssertCacheableProperty("file.txt", () => fileClient4.Name);
            TestHelper.AssertCacheableProperty("file.txt", () => fileClient4.Path);
            Assert.AreEqual("file.txt", builder4.LastDirectoryOrFileName);

            // no directories or files
            Uri uri5 = new Uri("http://dummyaccount.file.core.windows.net/share");
            var builder5 = new ShareUriBuilder(uri5);
            var fileClient5 = new ShareFileClient(uri5);
            TestHelper.AssertCacheableProperty(string.Empty, () => fileClient5.Name);
            TestHelper.AssertCacheableProperty(string.Empty, () => fileClient5.Path);
            Assert.AreEqual(string.Empty, builder5.LastDirectoryOrFileName);
        }

        [Test]
        public async Task CreateAsync()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            var name = GetNewFileName();
            ShareFileClient file = InstrumentClient(directory.GetFileClient(name));

            // Act
            Response<ShareFileInfo> response = await file.CreateAsync(maxSize: Constants.MB);

            // Assert
            AssertValidStorageFileInfo(response);
            var accountName = new ShareUriBuilder(file.Uri).AccountName;
            TestHelper.AssertCacheableProperty(accountName, () => file.AccountName);
            var shareName = new ShareUriBuilder(file.Uri).ShareName;
            TestHelper.AssertCacheableProperty(shareName, () => file.ShareName);
            TestHelper.AssertCacheableProperty(name, () => file.Name);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task CreateAsync_Lease()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(maxSize: Constants.MB);
            ShareFileLease fileLease = await InstrumentClient(file.GetShareLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync();
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = fileLease.LeaseId
            };

            // Act
            Response<ShareFileInfo> response = await file.CreateAsync(
                maxSize: Constants.MB,
                conditions: conditions);

            // Assert
            AssertValidStorageFileInfo(response);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task CreateAsync_InvalidLease()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(maxSize: Constants.MB);
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = Recording.Random.NewGuid().ToString()
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
            file.CreateAsync(
                    maxSize: Constants.MB,
                    conditions: conditions),
                e => Assert.AreEqual("LeaseNotPresentWithFileOperation", e.ErrorCode));
        }

        [Test]
        public async Task CreateAsync_FilePermission()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            var filePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";

            // Act
            Response<ShareFileInfo> response = await file.CreateAsync(
                maxSize: Constants.MB,
                filePermission: filePermission);

            // Assert
            AssertValidStorageFileInfo(response);
        }

        [Test]
        public async Task CreateAsync_FilePermissionAndFilePermissionKeySet()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            var filePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
            var fileSmbProperties = new FileSmbProperties()
            {
                FilePermissionKey = "filePermissionKey"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                file.CreateAsync(
                    maxSize: Constants.MB,
                    smbProperties: fileSmbProperties,
                    filePermission: filePermission),
                e => Assert.AreEqual("filePermission and filePermissionKey cannot both be set", e.Message));
        }

        [Test]
        public async Task CreateAsync_FilePermissionTooLarge()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            var filePermission = new string('*', 9 * Constants.KB);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                file.CreateAsync(
                    maxSize: Constants.MB,
                    filePermission: filePermission),
                e => {
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
            await directory.CreateIfNotExistsAsync();

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            var smbProperties = new FileSmbProperties
            {
                FilePermissionKey = createPermissionResponse.Value.FilePermissionKey,
                FileAttributes = ShareExtensions.ToFileAttributes("Archive|ReadOnly"),
                FileCreatedOn = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero),
                FileLastWrittenOn = new DateTimeOffset(2019, 8, 26, 5, 15, 25, 60, TimeSpan.Zero),
            };

            // Act
            Response<ShareFileInfo> response = await file.CreateAsync(
                maxSize: Constants.KB,
                smbProperties: smbProperties);

            // Assert
            AssertValidStorageFileInfo(response);
            Assert.AreEqual(smbProperties.FileAttributes, response.Value.SmbProperties.FileAttributes);
            Assert.AreEqual(smbProperties.FileCreatedOn, response.Value.SmbProperties.FileCreatedOn);
            Assert.AreEqual(smbProperties.FileLastWrittenOn, response.Value.SmbProperties.FileLastWrittenOn);
        }

        [Test]
        public async Task CreateAsync_Metadata()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await file.CreateAsync(
                maxSize: Constants.MB,
                metadata: metadata);

            // Assert
            Response<ShareFileProperties> response = await file.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
        }

        [Test]
        public async Task CreateAsync_Headers()
        {
            var constants = new TestConstants(this);

            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            await file.CreateAsync(
                maxSize: Constants.MB,
                httpHeaders: new ShareFileHttpHeaders
                {
                    CacheControl = constants.CacheControl,
                    ContentDisposition = constants.ContentDisposition,
                    ContentEncoding = new string[] { constants.ContentEncoding },
                    ContentLanguage = new string[] { constants.ContentLanguage },
                    ContentHash = constants.ContentMD5,
                    ContentType = constants.ContentType
                });

            // Assert
            Response<ShareFileProperties> response = await file.GetPropertiesAsync();
            Assert.AreEqual(constants.ContentType, response.Value.ContentType);
            TestHelper.AssertSequenceEqual(constants.ContentMD5.ToList(), response.Value.ContentHash.ToList());
            Assert.AreEqual(1, response.Value.ContentEncoding.Count());
            Assert.AreEqual(constants.ContentEncoding, response.Value.ContentEncoding.First());
            Assert.AreEqual(1, response.Value.ContentLanguage.Count());
            Assert.AreEqual(constants.ContentLanguage, response.Value.ContentLanguage.First());
            Assert.AreEqual(constants.ContentDisposition, response.Value.ContentDisposition);
            Assert.AreEqual(constants.CacheControl, response.Value.CacheControl);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2020_02_10)]
        public async Task CreateAsync_4TB()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            Response<ShareFileInfo> response = await file.CreateAsync(4 * Constants.TB);

            // Assert
            AssertValidStorageFileInfo(response);
        }

        [Test]
        public async Task CreateAsync_Error()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.CreateAsync(maxSize: Constants.KB),
                e => Assert.AreEqual("ParentNotFound", e.ErrorCode));
        }

        [Test]
        public async Task ExistsAsync_Exists()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;
            ShareFileClient file = InstrumentClient(share.GetRootDirectoryClient().GetFileClient(GetNewFileName()));
            await file.CreateAsync(Constants.KB);

            // Act
            Response<bool> response = await file.ExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);
        }

        [Test]
        public async Task ExistsAsync_NotExists()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;
            ShareFileClient file = InstrumentClient(share.GetRootDirectoryClient().GetFileClient(GetNewFileName()));

            // Act
            Response<bool> response = await file.ExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [Test]
        public async Task ExistsAsync_ParentDirectoryNotExists()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient parentDirectory = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
            ShareFileClient file = InstrumentClient(parentDirectory.GetFileClient(GetNewFileName()));

            // Act
            Response<bool> response = await file.ExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [Test]
        public async Task ExistsAsync_ShareNotExists()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(GetNewShareName()));
            ShareFileClient file = InstrumentClient(share.GetRootDirectoryClient().GetFileClient(GetNewFileName()));

            // Act
            Response<bool> response = await file.ExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [Test]
        public async Task ExistsAsync_Error()
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
            ShareFileClient file = InstrumentClient(share.GetRootDirectoryClient().GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.ExistsAsync(),
                e => { });
        }

        [Test]
        public async Task DeleteIfExistsAsync_Exists()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;
            ShareFileClient file = InstrumentClient(share.GetRootDirectoryClient().GetFileClient(GetNewFileName()));
            await file.CreateAsync(Constants.KB);

            // Act
            Response<bool> response = await file.DeleteIfExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);
        }

        [Test]
        public async Task DeleteIfExistsAsync_NotExists()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;
            ShareFileClient file = InstrumentClient(share.GetRootDirectoryClient().GetFileClient(GetNewFileName()));

            // Act
            Response<bool> response = await file.DeleteIfExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [Test]
        public async Task DeleteIfExistsAsync_ShareNotExists()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(GetNewShareName()));
            ShareFileClient file = InstrumentClient(share.GetRootDirectoryClient().GetFileClient(GetNewFileName()));

            // Act
            Response<bool> response = await file.DeleteIfExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [Test]
        public async Task DeleteIfExistsAsync_ParentDirectoryNotExists()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient parentDirectory = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
            ShareFileClient file = InstrumentClient(parentDirectory.GetFileClient(GetNewFileName()));

            // Act
            Response<bool> response = await file.DeleteIfExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [Test]
        public async Task DeleteIfExistsAsync_Error()
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
            ShareFileClient file = InstrumentClient(share.GetRootDirectoryClient().GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.DeleteIfExistsAsync(),
                e => { });
        }

        [Test]
        public async Task SetMetadataAsync()
        {
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await file.SetMetadataAsync(metadata);

            // Assert
            Response<ShareFileProperties> response = await file.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task SetMetadataAsync_Lease()
        {
            // Arrange
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;
            IDictionary<string, string> metadata = BuildMetadata();
            ShareFileLease fileLease = await InstrumentClient(file.GetShareLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync();
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = fileLease.LeaseId
            };

            // Act
            await file.SetMetadataAsync(
                metadata: metadata,
                conditions: conditions);

            // Assert
            Response<ShareFileProperties> response = await file.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task SetMetadataAsync_InvalidLease()
        {
            // Arrange
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;
            IDictionary<string, string> metadata = BuildMetadata();
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = Recording.Random.NewGuid().ToString()
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.SetMetadataAsync(
                    metadata: metadata,
                    conditions: conditions),
                e => Assert.AreEqual("LeaseNotPresentWithFileOperation", e.ErrorCode));
        }

        [Test]
        public async Task SetMetadataAsync_Error()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.SetMetadataAsync(metadata),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            Response<ShareFileInfo> createResponse = await file.CreateAsync(maxSize: Constants.KB);

            // Act
            Response<ShareFileProperties> getPropertiesResponse = await file.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(createResponse.Value.ETag, getPropertiesResponse.Value.ETag);
            Assert.AreEqual(createResponse.Value.LastModified, getPropertiesResponse.Value.LastModified);
            Assert.AreEqual(createResponse.Value.IsServerEncrypted, getPropertiesResponse.Value.IsServerEncrypted);
            AssertPropertiesEqual(createResponse.Value.SmbProperties, getPropertiesResponse.Value.SmbProperties);
        }

        [Test]
        public async Task GetPropertiesAsync_Snapshot()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();

            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(maxSize: Constants.KB);

            Response<ShareSnapshotInfo> createSnapshotResponse = await test.Share.CreateSnapshotAsync();
            ShareClient snapshotShareClient = test.Share.WithSnapshot(createSnapshotResponse.Value.Snapshot);

            ShareFileClient snapshotFileClient = snapshotShareClient.GetDirectoryClient(test.Directory.Name).GetFileClient(file.Name);

            // Act
            Response<ShareFileProperties> getPropertiesResponse = await snapshotFileClient.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(getPropertiesResponse.Value.ETag);
        }

        [Test]
        public async Task GetPropertiesAsync_SnapshotFailed()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();

            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(maxSize: Constants.KB);

            ShareClient snapshotShareClient = test.Share.WithSnapshot("2020-06-26T00:49:21.0000000Z");

            ShareFileClient snapshotFileClient = snapshotShareClient.GetDirectoryClient(test.Directory.Name).GetFileClient(file.Name);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                snapshotFileClient.GetPropertiesAsync(),
                e => Assert.AreEqual(ShareErrorCode.ShareNotFound.ToString(), e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task GetPropertiesAsync_NoLease()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            Response<ShareFileInfo> createResponse = await file.CreateAsync(maxSize: Constants.KB);
            await InstrumentClient(file.GetShareLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync();

            // Act
            Response<ShareFileProperties> getPropertiesResponse = await file.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(createResponse.Value.ETag, getPropertiesResponse.Value.ETag);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task GetPropertiesAsync_Lease()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            Response<ShareFileInfo> createResponse = await file.CreateAsync(maxSize: Constants.KB);

            ShareFileLease fileLease = await InstrumentClient(file.GetShareLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync();
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = fileLease.LeaseId
            };

            // Act
            Response<ShareFileProperties> getPropertiesResponse = await file.GetPropertiesAsync(
                conditions: conditions);

            // Assert
            Assert.AreEqual(ShareLeaseDuration.Infinite, getPropertiesResponse.Value.LeaseDuration);
            Assert.AreEqual(ShareLeaseState.Leased, getPropertiesResponse.Value.LeaseState);
            Assert.AreEqual(ShareLeaseStatus.Locked, getPropertiesResponse.Value.LeaseStatus);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task GetPropertiesAsync_InvalidLease()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            Response<ShareFileInfo> createResponse = await file.CreateAsync(maxSize: Constants.KB);

            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = Recording.Random.NewGuid().ToString()
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.GetPropertiesAsync(
                    conditions: conditions),
                e => Assert.AreEqual("LeaseNotPresentWithFileOperation", e.ErrorCode));
        }

        [Test]
        public async Task GetPropertiesAsync_ShareSAS()
        {
            var shareName = GetNewShareName();
            var directoryName = GetNewDirectoryName();
            var fileName = GetNewFileName();

            await using DisposingFile test = await GetTestFileAsync(shareName: shareName, directoryName: directoryName, fileName: fileName);
            ShareFileClient file = test.File;

            // Arrange
            ShareFileClient sasFile = InstrumentClient(
                GetServiceClient_FileServiceSasShare(shareName)
                .GetShareClient(shareName)
                .GetDirectoryClient(directoryName)
                .GetFileClient(fileName));

            // Act
            Response<ShareFileProperties> response = await sasFile.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task GetPropertiesAsync_FileSAS()
        {
            var shareName = GetNewShareName();
            var directoryName = GetNewDirectoryName();
            var fileName = GetNewFileName();

            await using DisposingFile test = await GetTestFileAsync(shareName: shareName, directoryName: directoryName, fileName: fileName);
            ShareFileClient file = test.File;

            // Arrange
            ShareFileClient sasFile = InstrumentClient(
                GetServiceClient_FileServiceSasFile(shareName, directoryName + "/" + fileName)
                .GetShareClient(shareName)
                .GetDirectoryClient(directoryName)
                .GetFileClient(fileName));

            // Act
            Response<ShareFileProperties> response = await sasFile.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task GetPropertiesAsync_FileSasWithIdentifier()
        {
            // Arrange
            string shareName = GetNewShareName();
            string fileName = GetNewFileName();
            string signedIdentifierId = GetNewString();
            await using DisposingShare test = await GetTestShareAsync(shareName: shareName);
            ShareFileClient fileClient = InstrumentClient(
                test.Share.GetRootDirectoryClient().GetFileClient(fileName));
            await fileClient.CreateAsync(Constants.KB);

            ShareSignedIdentifier signedIdentifier = new ShareSignedIdentifier
            {
                Id = signedIdentifierId,
                AccessPolicy = new ShareAccessPolicy
                {
                    PolicyStartsOn = Recording.UtcNow.AddHours(-1),
                    PolicyExpiresOn = Recording.UtcNow.AddHours(1),
                    Permissions = "rw"
                }
            };

            await test.Share.SetAccessPolicyAsync(new ShareSignedIdentifier[] { signedIdentifier });

            ShareSasBuilder sasBuilder = new ShareSasBuilder
            {
                ShareName = shareName,
                Identifier = signedIdentifierId
            };
            SasQueryParameters sasQueryParameters = sasBuilder.ToSasQueryParameters(GetNewSharedKeyCredentials());

            ShareUriBuilder uriBuilder = new ShareUriBuilder(fileClient.Uri)
            {
                Sas = sasQueryParameters
            };

            ShareFileClient sasFileClient = InstrumentClient(new ShareFileClient(
                uriBuilder.ToUri(),
                GetOptions()));

            // Act
            Response<ShareFileProperties> response = await sasFileClient.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.GetPropertiesAsync(),
                e =>
                {
                    Assert.AreEqual("ResourceNotFound", e.ErrorCode);
                    if (Mode != RecordedTestMode.Playback)
                    {
                        // The MockResponse type doesn't supply the ReasonPhrase we're
                        // checking for with this test
                        Assert.AreEqual("The specified resource does not exist.", e.Message.Split('(')[1].Split(')')[0].Trim());
                    }
                });
        }

        [Test]
        public async Task SetHttpHeadersAsync()
        {
            var constants = new TestConstants(this);

            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            // Act
            await file.SetHttpHeadersAsync(
                httpHeaders: new ShareFileHttpHeaders
                {
                    CacheControl = constants.CacheControl,
                    ContentDisposition = constants.ContentDisposition,
                    ContentEncoding = new string[] { constants.ContentEncoding },
                    ContentLanguage = new string[] { constants.ContentLanguage },
                    ContentHash = constants.ContentMD5,
                    ContentType = constants.ContentType
                });

            // Assert
            Response<ShareFileProperties> response = await file.GetPropertiesAsync();
            Assert.AreEqual(constants.ContentType, response.Value.ContentType);
            TestHelper.AssertSequenceEqual(constants.ContentMD5.ToList(), response.Value.ContentHash.ToList());
            Assert.AreEqual(1, response.Value.ContentEncoding.Count());
            Assert.AreEqual(constants.ContentEncoding, response.Value.ContentEncoding.First());
            Assert.AreEqual(1, response.Value.ContentLanguage.Count());
            Assert.AreEqual(constants.ContentLanguage, response.Value.ContentLanguage.First());
            Assert.AreEqual(constants.ContentDisposition, response.Value.ContentDisposition);
            Assert.AreEqual(constants.CacheControl, response.Value.CacheControl);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task SetHttpHeadersAsync_Lease()
        {
            var constants = new TestConstants(this);

            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;
            ShareFileLease fileLease = await InstrumentClient(file.GetShareLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync();
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = fileLease.LeaseId
            };

            // Act
            await file.SetHttpHeadersAsync(
                httpHeaders: new ShareFileHttpHeaders
                {
                    ContentType = constants.ContentType
                },
                conditions: conditions);

            // Assert
            Response<ShareFileProperties> response = await file.GetPropertiesAsync();
            Assert.AreEqual(constants.ContentType, response.Value.ContentType);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task SetHttpHeadersAsync_InvalidLease()
        {
            var constants = new TestConstants(this);

            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = Recording.Random.NewGuid().ToString()
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.SetHttpHeadersAsync(
                    httpHeaders: new ShareFileHttpHeaders
                    {
                        ContentType = constants.ContentType
                    },
                    conditions: conditions),
                e => Assert.AreEqual("LeaseNotPresentWithFileOperation", e.ErrorCode));
        }

        [Test]
        public async Task SetPropertiesAsync_FilePermission()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            var filePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
            await file.CreateAsync(maxSize: Constants.KB);

            // Act
            Response<ShareFileInfo> response = await file.SetHttpHeadersAsync(filePermission: filePermission);

            // Assert
            AssertValidStorageFileInfo(response);
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
            await directory.CreateIfNotExistsAsync();

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            var smbProperties = new FileSmbProperties
            {
                FilePermissionKey = createPermissionResponse.Value.FilePermissionKey,
                FileAttributes = ShareExtensions.ToFileAttributes("Archive|ReadOnly"),
                FileCreatedOn = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero),
                FileLastWrittenOn = new DateTimeOffset(2019, 8, 26, 5, 15, 25, 60, TimeSpan.Zero),
            };

            await file.CreateAsync(maxSize: Constants.KB);

            // Act
            Response<ShareFileInfo> response = await file.SetHttpHeadersAsync(smbProperties: smbProperties);

            // Assert
            AssertValidStorageFileInfo(response);
            Assert.AreEqual(smbProperties.FileAttributes, response.Value.SmbProperties.FileAttributes);
            Assert.AreEqual(smbProperties.FileCreatedOn, response.Value.SmbProperties.FileCreatedOn);
            Assert.AreEqual(smbProperties.FileLastWrittenOn, response.Value.SmbProperties.FileLastWrittenOn);
        }

        [Test]
        public async Task SetPropertiesAsync_FilePermissionTooLong()
        {
            var constants = new TestConstants(this);

            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            var filePermission = new string('*', 9 * Constants.KB);
            await file.CreateAsync(maxSize: Constants.KB);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                file.SetHttpHeadersAsync(
                    filePermission: filePermission),
                new ArgumentOutOfRangeException("filePermission", "Value must be less than or equal to 8192"));
        }

        [Test]
        public async Task SetPropertiesAsync_FilePermissionAndFilePermissionKeySet()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(maxSize: Constants.KB);

            var filePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
            var fileSmbProperties = new FileSmbProperties()
            {
                FilePermissionKey = "filePermissionKey"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                file.SetHttpHeadersAsync(
                    smbProperties: fileSmbProperties,
                    filePermission: filePermission),
                e => Assert.AreEqual("filePermission and filePermissionKey cannot both be set", e.Message));
        }

        [Test]
        public async Task SetPropertiesAsync_Error()
        {
            var constants = new TestConstants(this);
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.SetHttpHeadersAsync(
                    httpHeaders: new ShareFileHttpHeaders
                    {
                        CacheControl = constants.CacheControl,
                        ContentDisposition = constants.ContentDisposition,
                        ContentEncoding = new string[] { constants.ContentEncoding },
                        ContentLanguage = new string[] { constants.ContentLanguage },
                        ContentHash = constants.ContentMD5,
                        ContentType = constants.ContentType
                    }),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        public async Task DeleteAsync()
        {
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            // Act
            Response response = await file.DeleteAsync();

            // Assert
            Assert.IsNotNull(response.Headers.RequestId);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task DeleteAsync_Lease()
        {
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;
            ShareFileLease fileLease = await InstrumentClient(file.GetShareLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync();
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = fileLease.LeaseId
            };

            // Act
            Response response = await file.DeleteAsync(conditions: conditions);

            // Assert
            Assert.IsNotNull(response.Headers.RequestId);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task DeleteAsync_InvalidLease()
        {
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = Recording.Random.NewGuid().ToString()
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.DeleteAsync(conditions: conditions),
                e => Assert.AreEqual("LeaseNotPresentWithFileOperation", e.ErrorCode));
        }

        [Test]
        public async Task DeleteAsync_Error()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.DeleteAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        public async Task StartCopyAsync()
        {
            // Arrange
            await using DisposingFile testSource = await GetTestFileAsync();
            ShareFileClient source = testSource.File;
            await using DisposingFile testDest = await GetTestFileAsync();
            ShareFileClient dest = testDest.File;

            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await source.UploadRangeAsync(
                    range: new HttpRange(0, Constants.KB),
                    content: stream);
            }

            // Act
            Response<ShareFileCopyInfo> response = await dest.StartCopyAsync(source.Uri);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task StartCopyAsync_IgnoreReadOnlyAndSetArchive()
        {
            // Arrange
            await using DisposingFile testSource = await GetTestFileAsync();
            ShareFileClient source = testSource.File;
            await using DisposingFile testDest = await GetTestFileAsync();
            ShareFileClient dest = testSource.File;

            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await source.UploadRangeAsync(
                    range: new HttpRange(0, Constants.KB),
                    content: stream);
            }

            // Act
            Response<ShareFileCopyInfo> response = await dest.StartCopyAsync(
                sourceUri: source.Uri,
                ignoreReadOnly: true,
                setArchiveAttribute: true);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task StartCopyAsync_FilePermission()
        {
            // Arrange
            await using DisposingFile testSource = await GetTestFileAsync();
            ShareFileClient source = testSource.File;
            await using DisposingFile testDest = await GetTestFileAsync();
            ShareFileClient dest = testSource.File;

            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await source.UploadRangeAsync(
                    writeType: ShareFileRangeWriteType.Update,
                    range: new HttpRange(0, Constants.KB),
                    content: stream);
            }

            FileSmbProperties smbProperties = new FileSmbProperties
            {
                FileAttributes = ShareExtensions.ToFileAttributes("Archive|ReadOnly"),
                FileCreatedOn = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero),
                FileLastWrittenOn = new DateTimeOffset(2019, 8, 26, 5, 15, 25, 60, TimeSpan.Zero)
            };
            string filePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";

            // Act
            await dest.StartCopyAsync(
                sourceUri: source.Uri,
                smbProperties: smbProperties,
                filePermission: filePermission,
                filePermissionCopyMode: PermissionCopyMode.Override);

            Response<ShareFileProperties> propertiesResponse = await dest.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(smbProperties.FileAttributes, propertiesResponse.Value.SmbProperties.FileAttributes);
            Assert.AreEqual(smbProperties.FileCreatedOn, propertiesResponse.Value.SmbProperties.FileCreatedOn);
            Assert.AreEqual(smbProperties.FileLastWrittenOn, propertiesResponse.Value.SmbProperties.FileLastWrittenOn);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task StartCopyAsync_CopySmbPropertiesFilePermissionKey()
        {
            // Arrange
            await using DisposingFile testSource = await GetTestFileAsync();
            ShareFileClient source = testSource.File;
            await using DisposingFile testDest = await GetTestFileAsync();
            ShareFileClient dest = testSource.File;

            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await source.UploadRangeAsync(
                    range: new HttpRange(0, Constants.KB),
                    content: stream);
            }

            string permission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
            Response<PermissionInfo> createPermissionResponse = await testSource.Share.CreatePermissionAsync(permission);

            FileSmbProperties smbProperties = new FileSmbProperties
            {
                FilePermissionKey = createPermissionResponse.Value.FilePermissionKey,
                FileAttributes = ShareExtensions.ToFileAttributes("Archive|ReadOnly"),
                FileCreatedOn = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero),
                FileLastWrittenOn = new DateTimeOffset(2019, 8, 26, 5, 15, 25, 60, TimeSpan.Zero)
            };

            // Act
            await dest.StartCopyAsync(
                sourceUri: source.Uri,
                smbProperties: smbProperties,
                filePermissionCopyMode: PermissionCopyMode.Override);

            Response<ShareFileProperties> propertiesResponse = await dest.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(smbProperties.FileAttributes, propertiesResponse.Value.SmbProperties.FileAttributes);
            Assert.AreEqual(smbProperties.FileCreatedOn, propertiesResponse.Value.SmbProperties.FileCreatedOn);
            Assert.AreEqual(smbProperties.FileLastWrittenOn, propertiesResponse.Value.SmbProperties.FileLastWrittenOn);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task StartCopyAsync_Lease()
        {
            // Arrange
            await using DisposingFile testSource = await GetTestFileAsync();
            ShareFileClient source = testSource.File;
            await using DisposingFile testDest = await GetTestFileAsync();
            ShareFileClient dest = testDest.File;
            ShareFileLease fileLease = await InstrumentClient(dest.GetShareLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync();
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = fileLease.LeaseId
            };

            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await source.UploadRangeAsync(
                    writeType: ShareFileRangeWriteType.Update,
                    range: new HttpRange(0, Constants.KB),
                    content: stream);
            }

            // Act
            Response<ShareFileCopyInfo> response = await dest.StartCopyAsync(
                sourceUri: source.Uri,
                conditions: conditions);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task StartCopyAsync_InvalidLease()
        {
            // Arrange
            await using DisposingFile testSource = await GetTestFileAsync();
            ShareFileClient source = testSource.File;
            await using DisposingFile testDest = await GetTestFileAsync();
            ShareFileClient dest = testDest.File;
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = Recording.Random.NewGuid().ToString()
            };

            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await source.UploadRangeAsync(
                    writeType: ShareFileRangeWriteType.Update,
                    range: new HttpRange(0, Constants.KB),
                    content: stream);
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                dest.StartCopyAsync(
                    sourceUri: source.Uri,
                    conditions: conditions),
                e => Assert.AreEqual("LeaseNotPresentWithFileOperation", e.ErrorCode));
        }

        [Test]
        public async Task StartCopyAsync_Metata()
        {
            // Arrange
            await using DisposingFile testSource = await GetTestFileAsync();
            ShareFileClient source = testSource.File;
            await using DisposingFile testDest = await GetTestFileAsync();
            ShareFileClient dest = testSource.File;

            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await source.UploadRangeAsync(
                    writeType: ShareFileRangeWriteType.Update,
                    range: new HttpRange(0, Constants.KB),
                    content: stream);
            }

            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            Response<ShareFileCopyInfo> copyResponse = await dest.StartCopyAsync(
                sourceUri: source.Uri,
                metadata: metadata);

            await WaitForCopy(dest);

            // Assert
            Response<ShareFileProperties> response = await dest.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
        }

        [Test]
        public async Task StartCopyAsync_NonAsciiSourceUri()
        {
            // Arrange
            await using DisposingFile testSource = await GetTestFileAsync(fileName: GetNewNonAsciiFileName());
            ShareFileClient source = testSource.File;
            await using DisposingFile testDest = await GetTestFileAsync();
            ShareFileClient dest = testDest.File;

            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await source.UploadRangeAsync(
                    range: new HttpRange(0, Constants.KB),
                    content: stream);
            }

            // Act
            Response<ShareFileCopyInfo> response = await dest.StartCopyAsync(source.Uri);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task StartCopyAsync_Error()
        {
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.StartCopyAsync(sourceUri: s_invalidUri),
                e => Assert.AreEqual("CannotVerifyCopySource", e.ErrorCode));
        }

        [Test]
        public async Task AbortCopyAsync()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient source = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            await source.CreateAsync(maxSize: Constants.MB);
            var data = GetRandomBuffer(Constants.MB);

            using (var stream = new MemoryStream(data))
            {
                await source.UploadRangeAsync(
                    writeType: ShareFileRangeWriteType.Update,
                    range: new HttpRange(0, Constants.MB),
                    content: stream);
            }

            ShareFileClient dest = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            await dest.CreateAsync(maxSize: Constants.MB);
            Response<ShareFileCopyInfo> copyResponse = await dest.StartCopyAsync(source.Uri);

            // Act
            try
            {
                Response response = await dest.AbortCopyAsync(copyResponse.Value.CopyId);

                // Assert
                Assert.IsNotNull(response.Headers.RequestId);
            }
            catch (RequestFailedException e) when (e.ErrorCode == "NoPendingCopyOperation")
            {
                // This exception is intentionally.  It is difficult to test AbortCopyAsync() in a deterministic way.
                // this.WarnCopyCompletedTooQuickly();
            }
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task AbortCopyAsync_Lease()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient source = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            await source.CreateAsync(maxSize: Constants.MB);
            var data = GetRandomBuffer(Constants.MB);

            using (var stream = new MemoryStream(data))
            {
                await source.UploadRangeAsync(
                    writeType: ShareFileRangeWriteType.Update,
                    range: new HttpRange(0, Constants.MB),
                    content: stream);
            }

            ShareFileClient dest = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            await dest.CreateAsync(maxSize: Constants.MB);

            ShareFileLease fileLease = await InstrumentClient(dest.GetShareLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync();
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = fileLease.LeaseId
            };

            Response<ShareFileCopyInfo> copyResponse = await dest.StartCopyAsync(
                sourceUri: source.Uri,
                conditions: conditions);

            // Act
            try
            {
                Response response = await dest.AbortCopyAsync(
                    copyId: copyResponse.Value.CopyId,
                    conditions: conditions);

                // Assert
                Assert.IsNotNull(response.Headers.RequestId);
            }
            catch (RequestFailedException e) when (e.ErrorCode == "NoPendingCopyOperation")
            {
                // This exception is intentionally.  It is difficult to test AbortCopyAsync() in a deterministic way.
                // this.WarnCopyCompletedTooQuickly();
            }
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task AbortCopyAsync_InvalidLease()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient source = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            await source.CreateAsync(maxSize: Constants.MB);
            var data = GetRandomBuffer(Constants.MB);

            using (var stream = new MemoryStream(data))
            {
                await source.UploadRangeAsync(
                    writeType: ShareFileRangeWriteType.Update,
                    range: new HttpRange(0, Constants.MB),
                    content: stream);
            }

            ShareFileClient dest = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            await dest.CreateAsync(maxSize: Constants.MB);

            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = Recording.Random.NewGuid().ToString()
            };

            Response<ShareFileCopyInfo> copyResponse = await dest.StartCopyAsync(
                sourceUri: source.Uri);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
            dest.AbortCopyAsync(
                    copyId: copyResponse.Value.CopyId,
                    conditions: conditions),
                e => Assert.AreEqual("LeaseNotPresentWithFileOperation", e.ErrorCode));
        }

        [Test]
        public async Task AbortCopyAsync_Error()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(maxSize: Constants.MB);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.AbortCopyAsync("id"),
                e => Assert.AreEqual("InvalidQueryParameterValue", e.ErrorCode));
        }

        [Test]
        public void WithSnapshot()
        {
            var shareName = GetNewShareName();
            var directoryName = GetNewDirectoryName();
            var fileName = GetNewFileName();

            ShareServiceClient service = GetServiceClient_SharedKey();

            ShareClient share = InstrumentClient(service.GetShareClient(shareName));

            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(directoryName));

            ShareFileClient file = InstrumentClient(directory.GetFileClient(fileName));

            var builder = new ShareUriBuilder(file.Uri);

            Assert.AreEqual("", builder.Snapshot);

            file = InstrumentClient(file.WithSnapshot("foo"));

            builder = new ShareUriBuilder(file.Uri);

            Assert.AreEqual("foo", builder.Snapshot);

            file = InstrumentClient(file.WithSnapshot(null));

            builder = new ShareUriBuilder(file.Uri);

            Assert.AreEqual("", builder.Snapshot);
        }

        [Test]
        public async Task DownloadAsync()
        {
            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            using (var stream = new MemoryStream(data))
            {
                await file.UploadRangeAsync(
                    range: new HttpRange(Constants.KB, data.LongLength),
                    content: stream);

                // Act
                Response<ShareFileProperties> getPropertiesResponse = await file.GetPropertiesAsync();
                Response<ShareFileDownloadInfo> downloadResponse = await file.DownloadAsync(
                    range: new HttpRange(Constants.KB, data.LongLength));

                // Assert

                // Content is equal
                Assert.AreEqual(data.Length, downloadResponse.Value.ContentLength);
                var actual = new MemoryStream();
                await downloadResponse.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());

                // Properties are equal
                Assert.AreEqual(getPropertiesResponse.Value.LastModified, downloadResponse.Value.Details.LastModified);
                AssertDictionaryEquality(getPropertiesResponse.Value.Metadata, downloadResponse.Value.Details.Metadata);
                Assert.AreEqual(getPropertiesResponse.Value.ContentType, downloadResponse.Value.ContentType);
                Assert.AreEqual(getPropertiesResponse.Value.ETag, downloadResponse.Value.Details.ETag);
                Assert.AreEqual(getPropertiesResponse.Value.ContentEncoding, downloadResponse.Value.Details.ContentEncoding);
                Assert.AreEqual(getPropertiesResponse.Value.CacheControl, downloadResponse.Value.Details.CacheControl);
                Assert.AreEqual(getPropertiesResponse.Value.ContentDisposition, downloadResponse.Value.Details.ContentDisposition);
                Assert.AreEqual(getPropertiesResponse.Value.ContentLanguage, downloadResponse.Value.Details.ContentLanguage);
                Assert.AreEqual(getPropertiesResponse.Value.CopyCompletedOn, downloadResponse.Value.Details.CopyCompletedOn);
                Assert.AreEqual(getPropertiesResponse.Value.CopyStatusDescription, downloadResponse.Value.Details.CopyStatusDescription);
                Assert.AreEqual(getPropertiesResponse.Value.CopyId, downloadResponse.Value.Details.CopyId);
                Assert.AreEqual(getPropertiesResponse.Value.CopyProgress, downloadResponse.Value.Details.CopyProgress);
                Assert.AreEqual(getPropertiesResponse.Value.CopySource, downloadResponse.Value.Details.CopySource);
                Assert.AreEqual(getPropertiesResponse.Value.CopyStatus, downloadResponse.Value.Details.CopyStatus);
                Assert.AreEqual(getPropertiesResponse.Value.IsServerEncrypted, downloadResponse.Value.Details.IsServerEncrypted);
                AssertPropertiesEqual(getPropertiesResponse.Value.SmbProperties, downloadResponse.Value.Details.SmbProperties);
            }
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task DownloadAsync_NoLease()
        {
            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            using (var stream = new MemoryStream(data))
            {
                await file.UploadRangeAsync(
                    writeType: ShareFileRangeWriteType.Update,
                    range: new HttpRange(Constants.KB, data.LongLength),
                    content: stream);

                await InstrumentClient(file.GetShareLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync();

                // Act
                Response<ShareFileDownloadInfo> downloadResponse = await file.DownloadAsync(
                    range: new HttpRange(Constants.KB, data.LongLength));

                // Assert
                Assert.IsNotNull(downloadResponse.Value.Details.ETag);
            }
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task DownloadAsync_Lease()
        {
            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            using (var stream = new MemoryStream(data))
            {
                await file.UploadRangeAsync(
                    writeType: ShareFileRangeWriteType.Update,
                    range: new HttpRange(Constants.KB, data.LongLength),
                    content: stream);

                ShareFileLease fileLease = await InstrumentClient(file.GetShareLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync();
                ShareFileRequestConditions conditions = new ShareFileRequestConditions
                {
                    LeaseId = fileLease.LeaseId
                };

                // Act
                Response<ShareFileDownloadInfo> downloadResponse = await file.DownloadAsync(
                    range: new HttpRange(Constants.KB, data.LongLength),
                    conditions: conditions);

                // Assert
                Assert.AreEqual(ShareLeaseDuration.Infinite, downloadResponse.Value.Details.LeaseDuration);
                Assert.AreEqual(ShareLeaseState.Leased, downloadResponse.Value.Details.LeaseState);
                Assert.AreEqual(ShareLeaseStatus.Locked, downloadResponse.Value.Details.LeaseStatus);
            }
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task DownloadAsync_InvalidLease()
        {
            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            using (var stream = new MemoryStream(data))
            {
                await file.UploadRangeAsync(
                    writeType: ShareFileRangeWriteType.Update,
                    range: new HttpRange(Constants.KB, data.LongLength),
                    content: stream);

                ShareFileRequestConditions conditions = new ShareFileRequestConditions
                {
                    LeaseId = Recording.Random.NewGuid().ToString()
                };

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    file.DownloadAsync(
                        range: new HttpRange(Constants.KB, data.LongLength),
                        conditions: conditions),
                    e => Assert.AreEqual("LeaseNotPresentWithFileOperation", e.ErrorCode));
            }
        }

        [Test]
        public async Task DownloadAsync_WithUnreliableConnection()
        {
            var fileSize = 2 * Constants.MB;
            var dataSize = 1 * Constants.MB;
            var offset = 512 * Constants.KB;

            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            ShareDirectoryClient directoryFaulty = InstrumentClient(
                new ShareDirectoryClient(
                    directory.Uri,
                    new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey),
                    GetFaultyFileConnectionOptions(raiseAt: 256 * Constants.KB)));

            await directory.CreateIfNotExistsAsync();

            // Arrange
            var fileName = GetNewFileName();
            ShareFileClient fileFaulty = InstrumentClient(directoryFaulty.GetFileClient(fileName));
            ShareFileClient file = InstrumentClient(directory.GetFileClient(fileName));
            await file.CreateAsync(maxSize: fileSize);

            var data = GetRandomBuffer(dataSize);

            // Act
            using (var stream = new MemoryStream(data))
            {
                await fileFaulty.UploadRangeAsync(
                    range: new HttpRange(offset, dataSize),
                    content: stream);
            }

            // Assert
            Response<ShareFileDownloadInfo> downloadResponse = await fileFaulty.DownloadAsync(range: new HttpRange(offset, data.LongLength));
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual, 128 * Constants.KB);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [Test]
        public async Task GetRangeListAsync()
        {
            // Arrange
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            // Act
            Response<ShareFileRangeInfo> response = await file.GetRangeListAsync(range: new HttpRange(0, Constants.MB));

            // Assert
            Assert.IsNotNull(response.Value.ETag);
            Assert.IsNotNull(response.Value.LastModified);
            Assert.IsTrue(response.Value.FileContentLength > 0);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task GetRangeListAsync_NoLease()
        {
            // Arrange
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            await InstrumentClient(file.GetShareLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync();

            ShareFileGetRangeListOptions options = new ShareFileGetRangeListOptions
            {
                Range = new HttpRange(0, Constants.MB)
            };

            // Act
            Response<ShareFileRangeInfo> response = await file.GetRangeListAsync(options);

            // Assert
            Assert.IsNotNull(response.Value.ETag);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task GetRangeListAsync_Lease()
        {
            // Arrange
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            ShareFileLease fileLease = await InstrumentClient(file.GetShareLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync();

            ShareFileGetRangeListOptions options = new ShareFileGetRangeListOptions
            {
                Range = new HttpRange(0, Constants.MB),
                Conditions = new ShareFileRequestConditions
                {
                    LeaseId = fileLease.LeaseId
                }
            };

            // Act
            Response<ShareFileRangeInfo> response = await file.GetRangeListAsync(options);

            // Assert
            Assert.IsNotNull(response.Value.ETag);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task GetRangeListAsync_InvalidLease()
        {
            // Arrange
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            ShareFileGetRangeListOptions options = new ShareFileGetRangeListOptions
            {
                Range = new HttpRange(0, Constants.MB),
                Conditions = new ShareFileRequestConditions
                {
                    LeaseId = Recording.Random.NewGuid().ToString()
                }
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.GetRangeListAsync(options),
                e => Assert.AreEqual("LeaseNotPresentWithFileOperation", e.ErrorCode));
        }

        [Test]
        public async Task GetRangeListAsync_Error()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            ShareFileGetRangeListOptions options = new ShareFileGetRangeListOptions
            {
                Range = new HttpRange(0, Constants.MB)
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.GetRangeListAsync(options),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        public async Task GetRangeListAsync_NoRange()
        {
            // Arrange
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            HttpRange range = new HttpRange(Constants.KB, Constants.KB);
            await file.UploadRangeAsync(
                   writeType: ShareFileRangeWriteType.Update,
                   range: range,
                   content: stream);

            // Act
            Response<ShareFileRangeInfo> response = await file.GetRangeListAsync();

            // Assert
            Assert.AreEqual(1, response.Value.Ranges.Count());
            Assert.AreEqual(range, response.Value.Ranges.First());
        }

        [Test]
        public async Task GetRangeListAsync_Snapshot()
        {
            // Arrange
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            HttpRange range = new HttpRange(Constants.KB, Constants.KB);
            await file.UploadRangeAsync(
                   writeType: ShareFileRangeWriteType.Update,
                   range: range,
                   content: stream);

            Response<ShareSnapshotInfo> snapshotResponse = await test.Share.CreateSnapshotAsync();

            ShareFileGetRangeListOptions options = new ShareFileGetRangeListOptions
            {
                Snapshot = snapshotResponse.Value.Snapshot
            };

            // Act
            Response<ShareFileRangeInfo> response = await file.GetRangeListAsync(options);

            // Assert
            Assert.AreEqual(1, response.Value.Ranges.Count());
            Assert.AreEqual(range, response.Value.Ranges.First());
        }

        [Test]
        public async Task GetRangeListAsync_SnapshotFailed()
        {
            // Arrange
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            ShareFileGetRangeListOptions options = new ShareFileGetRangeListOptions
            {
                Snapshot = "2020-08-07T16:58:02.0000000Z"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.GetRangeListAsync(options),
                e => Assert.AreEqual(ShareErrorCode.ShareNotFound.ToString(), e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2020_02_10)]
        public async Task GetRangeListDiffAsync()
        {
            // Arrange
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            HttpRange range = new HttpRange(Constants.KB, Constants.KB);
            await file.UploadRangeAsync(
                   range: range,
                   content: stream);

            Response<ShareSnapshotInfo> snapshotResponse0 = await test.Share.CreateSnapshotAsync();

            stream.Position = 0;
            HttpRange range2 = new HttpRange(3 * Constants.KB, Constants.KB);
            await file.UploadRangeAsync(
                   range: range2,
                   content: stream);

            HttpRange range3 = new HttpRange(0, 512);
            await file.ClearRangeAsync(range3);

            Response<ShareSnapshotInfo> snapshotResponse1 = await test.Share.CreateSnapshotAsync();

            ShareFileGetRangeListDiffOptions options = new ShareFileGetRangeListDiffOptions
            {
                Snapshot = snapshotResponse1.Value.Snapshot,
                PreviousSnapshot = snapshotResponse0.Value.Snapshot
            };

            // Act
            Response<ShareFileRangeInfo> response = await file.GetRangeListDiffAsync(options);

            // Assert
            Assert.AreEqual(1, response.Value.Ranges.Count());
            Assert.AreEqual(range2, response.Value.Ranges.First());
            Assert.AreEqual(1, response.Value.ClearRanges.Count());
            Assert.AreEqual(range3, response.Value.ClearRanges.First());
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2020_02_10)]
        public async Task GetRangeListDiffAsync_Error()
        {
            // Arrange
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            ShareFileGetRangeListDiffOptions options = new ShareFileGetRangeListDiffOptions
            {
                PreviousSnapshot = "2020-08-07T16:58:02.0000000Z"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.GetRangeListDiffAsync(options),
                e => Assert.AreEqual(ShareErrorCode.ShareNotFound.ToString(), e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2020_02_10)]
        public async Task GetRangeListDiffAsync_Lease()
        {
            // Arrange
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            ShareFileLease fileLease = await InstrumentClient(file.GetShareLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync();

            ShareFileGetRangeListDiffOptions options = new ShareFileGetRangeListDiffOptions
            {
                Range = new HttpRange(0, Constants.MB),
                Conditions = new ShareFileRequestConditions
                {
                    LeaseId = fileLease.LeaseId
                }
            };

            // Act
            Response<ShareFileRangeInfo> response = await file.GetRangeListDiffAsync(options);

            // Assert
            Assert.IsNotNull(response.Value.ETag);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2020_02_10)]
        public async Task GetRangeListDiffAsync_InvalidLease()
        {
            // Arrange
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            ShareFileGetRangeListDiffOptions options = new ShareFileGetRangeListDiffOptions
            {
                Range = new HttpRange(0, Constants.MB),
                Conditions = new ShareFileRequestConditions
                {
                    LeaseId = Recording.Random.NewGuid().ToString()
                }
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.GetRangeListDiffAsync(options),
                e => Assert.AreEqual("LeaseNotPresentWithFileOperation", e.ErrorCode));
        }

        [Test]
        public async Task UploadRangeAsync()
        {
            var data = GetRandomBuffer(Constants.KB);

            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            using (var stream = new MemoryStream(data))
            {
                Response<ShareFileUploadInfo> response = await file.UploadRangeAsync(
                    writeType: ShareFileRangeWriteType.Update,
                    range: new HttpRange(Constants.KB, Constants.KB),
                    content: stream);

                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task UploadRangeAsync_Lease()
        {
            var data = GetRandomBuffer(Constants.KB);

            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;
            ShareFileLease fileLease = await InstrumentClient(file.GetShareLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync();
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = fileLease.LeaseId
            };

            using (var stream = new MemoryStream(data))
            {
                Response<ShareFileUploadInfo> response = await file.UploadRangeAsync(
                    range: new HttpRange(Constants.KB, Constants.KB),
                    content: stream,
                    conditions: conditions);

                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task UploadRangeAsync_InvalidLease()
        {
            var data = GetRandomBuffer(Constants.KB);

            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = Recording.Random.NewGuid().ToString()
            };

            using (var stream = new MemoryStream(data))
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    file.UploadRangeAsync(
                        range: new HttpRange(Constants.KB, Constants.KB),
                        content: stream,
                        conditions: conditions),
                    e => Assert.AreEqual("LeaseNotPresentWithFileOperation", e.ErrorCode));
            }
        }

        [Test]
        public async Task UploadRangeAsync_Error()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.UploadRangeAsync(
                    range: new HttpRange(Constants.KB, Constants.KB),
                    content: stream),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task UploadRangeAsync_InvalidStreamPosition()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            long size = Constants.KB;
            await file.CreateAsync(size);

            byte[] data = GetRandomBuffer(size);

            using Stream stream = new MemoryStream(data)
            {
                Position = size
            };

            HttpRange range = new HttpRange(0, stream.Length);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                file.UploadRangeAsync(
                range: range,
                content: stream),
                e => Assert.AreEqual("content.Position must be less than content.Length. Please set content.Position to the start of the data to upload.", e.Message));
        }

        [Test]
        public async Task UploadRangeAsync_NonZeroStreamPosition()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            long size = Constants.KB;
            long position = 512;
            await file.CreateAsync(size - position);

            byte[] data = GetRandomBuffer(size);
            byte[] expectedData = new byte[size - position];
            Array.Copy(data, position, expectedData, 0, size - position);

            using Stream stream = new MemoryStream(data)
            {
                Position = position
            };

            HttpRange range = new HttpRange(0, stream.Length - stream.Position);

            // Act
            await file.UploadRangeAsync(
                range: range,
                stream);

            // Assert
            Response<ShareFileDownloadInfo> response = await file.DownloadAsync();

            var actualData = new byte[512];
            using var actualStream = new MemoryStream(actualData);
            await response.Value.Content.CopyToAsync(actualStream);
            TestHelper.AssertSequenceEqual(expectedData, actualData);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2020_02_10)]
        public async Task UploadRangeAsync_4TB()
        {
            long fileSize = 4 * Constants.TB;
            var data = GetRandomBuffer(Constants.KB);

            await using DisposingShare test = await GetTestShareAsync();
            ShareFileClient file = InstrumentClient(test.Share.GetRootDirectoryClient().GetFileClient(GetNewFileName()));
            await file.CreateAsync(fileSize);

            using (var stream = new MemoryStream(data))
            {
                Response<ShareFileUploadInfo> response = await file.UploadRangeAsync(
                    writeType: ShareFileRangeWriteType.Update,
                    range: new HttpRange(fileSize - Constants.KB, Constants.KB),
                    content: stream);

                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task UploadAsync_Simple()
        {
            const int size = 10 * Constants.KB;
            var data = this.GetRandomBuffer(size);

            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            var name = this.GetNewFileName();
            var file = this.InstrumentClient(share.GetRootDirectoryClient().GetFileClient(name));

            await file.CreateAsync(size);
            using var stream = new MemoryStream(data);
            await file.UploadAsync(stream);

            using var bufferedContent = new MemoryStream();
            var download = await file.DownloadAsync();
            await download.Value.Content.CopyToAsync(bufferedContent);
            TestHelper.AssertSequenceEqual(data, bufferedContent.ToArray());
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task UploadAsync_Lease()
        {
            // Arrange
            const int size = 10 * Constants.KB;
            var data = this.GetRandomBuffer(size);

            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            var name = this.GetNewFileName();
            var file = this.InstrumentClient(share.GetRootDirectoryClient().GetFileClient(name));

            await file.CreateAsync(size);
            ShareFileLease fileLease = await InstrumentClient(file.GetShareLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync();
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = fileLease.LeaseId
            };

            // Act
            using var stream = new MemoryStream(data);
            await file.UploadAsync(
                content: stream,
                conditions: conditions);

            using var bufferedContent = new MemoryStream();
            var download = await file.DownloadAsync();
            await download.Value.Content.CopyToAsync(bufferedContent);
            TestHelper.AssertSequenceEqual(data, bufferedContent.ToArray());
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task UploadAsync_InvalidLease()
        {
            // Arrange
            const int size = 10 * Constants.KB;
            var data = this.GetRandomBuffer(size);

            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            var name = this.GetNewFileName();
            var file = this.InstrumentClient(share.GetRootDirectoryClient().GetFileClient(name));

            await file.CreateAsync(size);
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = Recording.Random.NewGuid().ToString()
            };

            // Act
            using var stream = new MemoryStream(data);
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.UploadAsync(
                    content: stream,
                    conditions: conditions),
                e => Assert.AreEqual("LeaseNotPresentWithFileOperation", e.ErrorCode));
        }

        [Test]
        public async Task UploadAsync_ReadOnlyError()
        {
            // Arrange
            const int size = 10 * Constants.KB;
            var data = this.GetRandomBuffer(size);
            string shareName = GetNewShareName();

            await using DisposingShare test = await GetTestShareAsync(shareName: shareName);
            ShareFileClient fileClient = InstrumentClient(test.Share.GetRootDirectoryClient().GetFileClient(GetNewFileName()));

            await fileClient.CreateAsync(size);
            ShareSasBuilder sasBuilder = new ShareSasBuilder
            {
                ShareName = shareName,
                Resource = "f",
                FilePath = fileClient.Path,
                ExpiresOn = Recording.UtcNow.AddHours(+1)
            };
            sasBuilder.SetPermissions(ShareFileSasPermissions.Read);
            UriBuilder sasUri = new UriBuilder(fileClient.Uri)
            {
                Query = sasBuilder.ToSasQueryParameters(new StorageSharedKeyCredential(
                        TestConfigDefault.AccountName,
                        TestConfigDefault.AccountKey)).ToString()
            };

            ShareFileClient readOnlyClient = InstrumentClient(
                new ShareFileClient(new Uri(sasUri.ToString()), GetOptions()));

            using (var stream = new MemoryStream(data))
            {
                // Throws AuthorizationMismatchPermissions or AuthorizationFailed
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    readOnlyClient.UploadAsync(stream),
                    e => Assert.IsNotNull(e.ErrorCode));
            }
        }

        [Test]
        public async Task UploadAsync_Stream_InvalidStreamPosition()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            long size = Constants.KB;
            await file.CreateAsync(size);

            byte[] data = GetRandomBuffer(size);

            using Stream stream = new MemoryStream(data)
            {
                Position = size
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                file.UploadAsync(
                content: stream),
                e => Assert.AreEqual("content.Position must be less than content.Length. Please set content.Position to the start of the data to upload.", e.Message));
        }

        [Test]
        public async Task UploadAsync_NonZeroStreamPosition()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            long size = Constants.KB;
            long position = 512;
            await file.CreateAsync(size - position);

            byte[] data = GetRandomBuffer(size);
            byte[] expectedData = new byte[size - position];
            Array.Copy(data, position, expectedData, 0, size - position);

            using Stream stream = new MemoryStream(data)
            {
                Position = position
            };

            // Act
            await file.UploadAsync(stream);

            // Assert
            Response<ShareFileDownloadInfo> response = await file.DownloadAsync();

            var actualData = new byte[512];
            using var actualStream = new MemoryStream(actualData);
            await response.Value.Content.CopyToAsync(actualStream);
            TestHelper.AssertSequenceEqual(expectedData, actualData);
        }

        [Test]
        public async Task UploadAsync_NonZeroStreamPositionMultipleBlocks()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            long size = 2 * Constants.KB;
            long position = 300;
            await file.CreateAsync(size - position);

            byte[] data = GetRandomBuffer(size);
            byte[] expectedData = new byte[size - position];
            Array.Copy(data, position, expectedData, 0, size - position);

            using Stream stream = new MemoryStream(data)
            {
                Position = position
            };

            // Act
            await file.UploadInternal(
                stream,
                progressHandler: null,
                conditions: null,
                singleRangeThreshold: 512,
                async: IsAsync,
                cancellationToken: CancellationToken.None);

            // Assert
            Response<ShareFileDownloadInfo> response = await file.DownloadAsync();

            var actualData = new byte[size - position];
            using var actualStream = new MemoryStream(actualData);
            await response.Value.Content.CopyToAsync(actualStream);
            TestHelper.AssertSequenceEqual(expectedData, actualData);
        }

        public async Task ClearRangeAsync()
        {
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            Response<ShareFileUploadInfo> response = await file.ClearRangeAsync(
                range: new HttpRange(Constants.KB, Constants.KB));

            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task ClearRangeAsync_Lease()
        {
            // Arrange
            const int size = 10 * Constants.KB;
            var data = this.GetRandomBuffer(size);

            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            var name = this.GetNewFileName();
            var file = this.InstrumentClient(share.GetRootDirectoryClient().GetFileClient(name));

            await file.CreateAsync(size);
            ShareFileLease fileLease = await InstrumentClient(file.GetShareLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync();
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = fileLease.LeaseId
            };

            // Act

            Response<ShareFileUploadInfo> response = await file.ClearRangeAsync(
                range: new HttpRange(Constants.KB, Constants.KB),
                conditions: conditions);

            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task ClearRangeAsync_Error()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.ClearRangeAsync(
                    range: new HttpRange(Constants.KB, Constants.KB)),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        [TestCase(512)]
        [TestCase(1 * Constants.KB)]
        [TestCase(2 * Constants.KB)]
        [TestCase(4 * Constants.KB)]
        [TestCase(10 * Constants.KB)]
        [TestCase(20 * Constants.KB)]
        [TestCase(30 * Constants.KB)]
        [TestCase(50 * Constants.KB)]
        [TestCase(501 * Constants.KB)]
        public async Task UploadAsync_SmallBlobs(int size) =>
            // Use a 1KB threshold so we get a lot of individual blocks
            await UploadAndVerify(size, Constants.KB);

        [Test]
        [LiveOnly]
        [TestCase(33 * Constants.MB)]
        [TestCase(257 * Constants.MB)]
        [TestCase(1 * Constants.GB)]
        [Explicit("https://github.com/Azure/azure-sdk-for-net/issues/9120")]
        public async Task UploadAsync_LargeBlobs(int size) =>
            // TODO: #6781 We don't want to add 1GB of random data in the recordings
            await UploadAndVerify(size, Constants.MB);

        private async Task UploadAndVerify(long size, int singleRangeThreshold)
        {
            var data = GetRandomBuffer(size);

            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            var name = GetNewFileName();
            ShareFileClient file = InstrumentClient(share.GetRootDirectoryClient().GetFileClient(name));
            await file.CreateAsync(size);
            using (var stream = new MemoryStream(data))
            {
                await file.UploadInternal(
                    content: stream,
                    progressHandler: default,
                    conditions: default,
                    singleRangeThreshold: singleRangeThreshold,
                    async: true,
                    cancellationToken: CancellationToken.None);
            }

            using var bufferedContent = new MemoryStream();
            Response<ShareFileDownloadInfo> download = await file.DownloadAsync();
            await download.Value.Content.CopyToAsync(bufferedContent);
            TestHelper.AssertSequenceEqual(data, bufferedContent.ToArray());
        }

        [Test]
        public async Task UploadRangeAsync_WithUnreliableConnection()
        {
            var fileSize = 2 * Constants.MB;
            var dataSize = 1 * Constants.MB;
            var offset = 512 * Constants.KB;

            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            ShareDirectoryClient directoryFaulty = InstrumentClient(
                new ShareDirectoryClient(
                    directory.Uri,
                    new StorageSharedKeyCredential(
                        TestConfigDefault.AccountName,
                        TestConfigDefault.AccountKey),
                    GetFaultyFileConnectionOptions()));

            await directory.CreateIfNotExistsAsync();

            // Arrange
            var fileName = GetNewFileName();
            ShareFileClient fileFaulty = InstrumentClient(directoryFaulty.GetFileClient(fileName));
            ShareFileClient file = InstrumentClient(directory.GetFileClient(fileName));
            await file.CreateAsync(maxSize: fileSize);

            var data = GetRandomBuffer(dataSize);
            var progressBag = new System.Collections.Concurrent.ConcurrentBag<long>();
            var progressHandler = new Progress<long>(progress => progressBag.Add(progress));
            var timesFaulted = 0;

            // Act
            using (var stream = new FaultyStream(
                new MemoryStream(data),
                256 * Constants.KB,
                1,
                new IOException("Simulated stream fault"),
                () => timesFaulted++))
            {
                Response<ShareFileUploadInfo> result = await fileFaulty.UploadRangeAsync(
                    range: new HttpRange(offset, dataSize),
                    content: stream,
                    progressHandler: progressHandler);

                Assert.IsNotNull(result);
                Assert.IsNotNull(result.GetRawResponse().Headers.Date);
                Assert.IsNotNull(result.GetRawResponse().Headers.RequestId);
                result.GetRawResponse().Headers.TryGetValue("x-ms-version", out var version);
                Assert.IsNotNull(version);

                await WaitForProgressAsync(progressBag, data.LongLength);
                Assert.IsTrue(progressBag.Count > 1, "Too few progress received");
                Assert.GreaterOrEqual(data.LongLength, progressBag.Max(), "Final progress has unexpected value");
            }

            // Assert
            Response<ShareFileDownloadInfo> downloadResponse = await file.DownloadAsync(range: new HttpRange(offset, data.LongLength));
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
            Assert.AreNotEqual(0, timesFaulted);
        }

        [Test]
        [LiveOnly]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/9085")]
        // TODO: #7645
        public async Task UploadRangeFromUriAsync()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            var directoryName = this.GetNewDirectoryName();
            var directory = this.InstrumentClient(share.GetDirectoryClient(directoryName));
            await directory.CreateIfNotExistsAsync();

            var fileName = this.GetNewFileName();
            var data = this.GetRandomBuffer(Constants.KB);
            var sourceFile = this.InstrumentClient(directory.GetFileClient(fileName));
            await sourceFile.CreateAsync(maxSize: 1024);
            using (var stream = new MemoryStream(data))
            {
                await sourceFile.UploadRangeAsync(new HttpRange(0, 1024), stream);
            }

            var destFile = directory.GetFileClient("destFile");
            await destFile.CreateAsync(maxSize: 1024);
            var destRange = new HttpRange(256, 256);
            var sourceRange = new HttpRange(512, 256);

            var sasFile = this.InstrumentClient(
                this.GetServiceClient_FileServiceSasShare(test.Share.Name)
                .GetShareClient(test.Share.Name)
                .GetDirectoryClient(directoryName)
                .GetFileClient(fileName));

            // Act
            await destFile.UploadRangeFromUriAsync(
                sourceUri: sasFile.Uri,
                range: destRange,
                sourceRange: sourceRange);

            // Assert
            var sourceDownloadResponse = await sourceFile.DownloadAsync(range: sourceRange);
            var destDownloadResponse = await destFile.DownloadAsync(range: destRange);

            var sourceStream = new MemoryStream();
            await sourceDownloadResponse.Value.Content.CopyToAsync(sourceStream);

            var destStream = new MemoryStream();
            await destDownloadResponse.Value.Content.CopyToAsync(destStream);

            TestHelper.AssertSequenceEqual(sourceStream.ToArray(), destStream.ToArray());
        }

        [Test]
        [LiveOnly]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        // TODO: #7645
        public async Task UploadRangeFromUriAsync_Lease()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            var directoryName = this.GetNewDirectoryName();
            var directory = this.InstrumentClient(share.GetDirectoryClient(directoryName));
            await directory.CreateIfNotExistsAsync();

            var fileName = this.GetNewFileName();
            var data = this.GetRandomBuffer(Constants.KB);
            var sourceFile = this.InstrumentClient(directory.GetFileClient(fileName));
            await sourceFile.CreateAsync(maxSize: 1024);
            using (var stream = new MemoryStream(data))
            {
                await sourceFile.UploadRangeAsync(ShareFileRangeWriteType.Update, new HttpRange(0, 1024), stream);
            }

            var destFile = directory.GetFileClient("destFile");
            await destFile.CreateAsync(maxSize: 1024);

            ShareFileLease fileLease = await InstrumentClient(destFile.GetShareLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync();
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = fileLease.LeaseId
            };

            var destRange = new HttpRange(256, 256);
            var sourceRange = new HttpRange(512, 256);

            var sasFile = this.InstrumentClient(
                this.GetServiceClient_FileServiceSasShare(test.Share.Name)
                    .GetShareClient(test.Share.Name)
                    .GetDirectoryClient(directoryName)
                    .GetFileClient(fileName));

            // Act
            await destFile.UploadRangeFromUriAsync(
                sourceUri: sasFile.Uri,
                range: destRange,
                sourceRange: sourceRange,
                conditions: conditions);
        }

        [Test]
        [LiveOnly]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        // TODO: #7645
        public async Task UploadRangeFromUriAsync_InvalidLease()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            var directoryName = this.GetNewDirectoryName();
            var directory = this.InstrumentClient(share.GetDirectoryClient(directoryName));
            await directory.CreateIfNotExistsAsync();

            var fileName = this.GetNewFileName();
            var data = this.GetRandomBuffer(Constants.KB);
            var sourceFile = this.InstrumentClient(directory.GetFileClient(fileName));
            await sourceFile.CreateAsync(maxSize: 1024);
            using (var stream = new MemoryStream(data))
            {
                await sourceFile.UploadRangeAsync(ShareFileRangeWriteType.Update, new HttpRange(0, 1024), stream);
            }

            var destFile = directory.GetFileClient("destFile");
            await destFile.CreateAsync(maxSize: 1024);

            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = Recording.Random.NewGuid().ToString()
            };

            var destRange = new HttpRange(256, 256);
            var sourceRange = new HttpRange(512, 256);

            var sasFile = this.InstrumentClient(
                this.GetServiceClient_FileServiceSasShare(test.Share.Name)
                    .GetShareClient(test.Share.Name)
                    .GetDirectoryClient(directoryName)
                    .GetFileClient(fileName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destFile.UploadRangeFromUriAsync(
                    sourceUri: sasFile.Uri,
                    range: destRange,
                    sourceRange: sourceRange,
                    conditions: conditions),
                e => Assert.AreEqual("LeaseNotPresentWithFileOperation", e.ErrorCode));
        }

        [Test]
        [LiveOnly]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/9085")]
        // TODO: #7645
        public async Task UploadRangeFromUriAsync_NonAsciiSourceUri()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            var directoryName = this.GetNewDirectoryName();
            var directory = this.InstrumentClient(share.GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            var fileName = this.GetNewNonAsciiFileName();
            var data = this.GetRandomBuffer(Constants.KB);
            var sourceFile = this.InstrumentClient(directory.GetFileClient(fileName));
            await sourceFile.CreateAsync(maxSize: 1024);
            using (var stream = new MemoryStream(data))
            {
                await sourceFile.UploadRangeAsync(new HttpRange(0, 1024), stream);
            }

            var destFile = directory.GetFileClient("destFile");
            await destFile.CreateAsync(maxSize: 1024);
            var destRange = new HttpRange(256, 256);
            var sourceRange = new HttpRange(512, 256);

            var sasFile = this.InstrumentClient(
                this.GetServiceClient_FileServiceSasShare(test.Share.Name)
                .GetShareClient(test.Share.Name)
                .GetDirectoryClient(directoryName)
                .GetFileClient(fileName));

            // Act
            await destFile.UploadRangeFromUriAsync(
                sourceUri: sasFile.Uri,
                range: destRange,
                sourceRange: sourceRange);

            // Assert
            var sourceDownloadResponse = await sourceFile.DownloadAsync(range: sourceRange);
            var destDownloadResponse = await destFile.DownloadAsync(range: destRange);

            var sourceStream = new MemoryStream();
            await sourceDownloadResponse.Value.Content.CopyToAsync(sourceStream);

            var destStream = new MemoryStream();
            await destDownloadResponse.Value.Content.CopyToAsync(destStream);

            TestHelper.AssertSequenceEqual(sourceStream.ToArray(), destStream.ToArray());
        }

        [Test]
        public async Task UploadRangeFromUriAsync_Error()
        {
            var shareName = this.GetNewShareName();
            await using DisposingShare test = await GetTestShareAsync(shareName: shareName);
            ShareClient share = test.Share;

            // Arrange
            var directoryName = this.GetNewDirectoryName();
            var directory = this.InstrumentClient(share.GetDirectoryClient(directoryName));
            await directory.CreateIfNotExistsAsync();

            var fileName = this.GetNewFileName();
            var sourceFile = this.InstrumentClient(directory.GetFileClient(fileName));

            var destFile = directory.GetFileClient("destFile");
            await destFile.CreateAsync(maxSize: 1024);
            var destRange = new HttpRange(256, 256);
            var sourceRange = new HttpRange(512, 256);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destFile.UploadRangeFromUriAsync(
                sourceUri: destFile.Uri,
                range: destRange,
                sourceRange: sourceRange),
                e => Assert.AreEqual("CannotVerifyCopySource", e.ErrorCode));
        }

        [Test]
        public async Task ListHandles()
        {
            // Arrange
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            // Act
            IList<ShareFileHandle> handles = await file.GetHandlesAsync().ToListAsync();

            // Assert
            Assert.AreEqual(0, handles.Count);
        }

        [Test]
        public async Task ListHandles_Min()
        {
            // Arrange
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            // Act
            IList<ShareFileHandle> handles = await file.GetHandlesAsync().ToListAsync();

            // Assert
            Assert.AreEqual(0, handles.Count);
        }

        [Test]
        public async Task ListHandles_Error()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.GetHandlesAsync().ToListAsync(),
                actualException => Assert.AreEqual("ResourceNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task ForceCloseHandles_Min()
        {
            // Arrange
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            // Act
            CloseHandlesResult reponse = await file.ForceCloseAllHandlesAsync();

            // Assert
            Assert.AreEqual(0, reponse.ClosedHandlesCount);
            Assert.AreEqual(0, reponse.FailedHandlesCount);
        }

        [Test]
        public async Task ForceCloseHandles_Error()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.ForceCloseAllHandlesAsync(),
                actualException => Assert.AreEqual("ResourceNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task ForceCloseHandle_Error()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.ForceCloseHandleAsync("nonExistantHandleId"),
                actualException => Assert.AreEqual("InvalidHeaderValue", actualException.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task AcquireLeaseAsync()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));
            await file.CreateAsync(1024);
            string leaseId = Recording.Random.NewGuid().ToString();

            // Act
            Response<ShareFileLease> response = await InstrumentClient(file.GetShareLeaseClient(leaseId)).AcquireAsync();

            // Assert
            Assert.IsNotNull(response.Value.ETag);
            Assert.IsNotNull(response.Value.LastModified);
            Assert.IsNotNull(response.Value.LeaseId);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task AcquireLeaseAsync_Error()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));
            string leaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(file.GetShareLeaseClient(leaseId)).AcquireAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task ReleaseLeaseAsync()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));
            await file.CreateAsync(1024);
            string leaseId = Recording.Random.NewGuid().ToString();
            ShareLeaseClient leaseClient = InstrumentClient(file.GetShareLeaseClient(leaseId));
            await leaseClient.AcquireAsync();

            // Act
            Response<FileLeaseReleaseInfo> response = await leaseClient.ReleaseAsync();

            // Assert
            Assert.IsNotNull(response.Value.ETag);
            Assert.IsNotNull(response.Value.LastModified);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task ReleaseLeaseAsync_Error()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));
            string leaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(file.GetShareLeaseClient(leaseId)).ReleaseAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task ChangeLeaseAsync()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));
            await file.CreateAsync(1024);
            string leaseId = Recording.Random.NewGuid().ToString();
            string newLeaseId = Recording.Random.NewGuid().ToString();
            ShareLeaseClient leaseClient = InstrumentClient(file.GetShareLeaseClient(leaseId));
            await leaseClient.AcquireAsync();

            // Act
            Response<ShareFileLease> response = await leaseClient.ChangeAsync(newLeaseId);

            // Assert
            Assert.IsNotNull(response.Value.ETag);
            Assert.IsNotNull(response.Value.LastModified);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task ChangeLeaseAsync_Error()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));
            string leaseId = Recording.Random.NewGuid().ToString();
            string newLeaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(file.GetShareLeaseClient(leaseId)).ChangeAsync(newLeaseId),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task BreakLeaseAsync()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));
            await file.CreateAsync(1024);
            string leaseId = Recording.Random.NewGuid().ToString();
            ShareLeaseClient leaseClient = InstrumentClient(file.GetShareLeaseClient(leaseId));
            await leaseClient.AcquireAsync();

            // Act
            Response<ShareFileLease> response = await leaseClient.BreakAsync();

            // Assert
            Assert.IsNotNull(response.Value.ETag);
            Assert.IsNotNull(response.Value.LastModified);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task BreakLeaseAsync_Error()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));
            string leaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(file.GetShareLeaseClient(leaseId)).BreakAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        public async Task OpenReadAsync()
        {
            int size = Constants.KB;
            await using DisposingDirectory test = await GetTestDirectoryAsync();

            // Arrange
            var data = GetRandomBuffer(size);
            ShareFileClient file = await test.Directory.CreateFileAsync(GetNewFileName(), size);
            using Stream stream = new MemoryStream(data);
            await file.UploadAsync(stream);

            // Act
            Stream outputStream = await file.OpenReadAsync().ConfigureAwait(false);
            byte[] outputBytes = new byte[size];
            await outputStream.ReadAsync(outputBytes, 0, size);

            // Assert
            Assert.AreEqual(data.Length, outputStream.Length);
            TestHelper.AssertSequenceEqual(data, outputBytes);
        }

        [Test]
        public async Task OpenReadAsync_BufferSize()
        {
            int size = Constants.KB;
            await using DisposingDirectory test = await GetTestDirectoryAsync();

            // Arrange
            var data = GetRandomBuffer(size);
            ShareFileClient file = await test.Directory.CreateFileAsync(GetNewFileName(), size);
            using Stream stream = new MemoryStream(data);
            await file.UploadAsync(stream);

            ShareFileOpenReadOptions options = new ShareFileOpenReadOptions(allowModifications: false)
            {
                BufferSize = size / 8
            };

            // Act
            Stream outputStream = await file.OpenReadAsync(options).ConfigureAwait(false);
            byte[] outputBytes = new byte[size];

            int downloadedBytes = 0;

            while (downloadedBytes < size)
            {
                downloadedBytes += await outputStream.ReadAsync(outputBytes, downloadedBytes, size / 4);
            }

            // Assert
            Assert.AreEqual(data.Length, outputStream.Length);
            TestHelper.AssertSequenceEqual(data, outputBytes);
        }

        [Test]
        public async Task OpenReadAsync_OffsetAndBufferSize()
        {
            int size = Constants.KB;
            await using DisposingDirectory test = await GetTestDirectoryAsync();

            // Arrange
            var data = GetRandomBuffer(size);
            ShareFileClient file = await test.Directory.CreateFileAsync(GetNewFileName(), size);
            using Stream stream = new MemoryStream(data);
            await file.UploadAsync(stream);

            byte[] expected = new byte[size];
            Array.Copy(data, size / 2, expected, size / 2, size / 2);

            ShareFileOpenReadOptions options = new ShareFileOpenReadOptions(allowModifications: false)
            {
                Position = size / 2,
                BufferSize = size / 8
            };

            // Act
            Stream outputStream = await file.OpenReadAsync(options)
                .ConfigureAwait(false);
            byte[] outputBytes = new byte[size];
            int downloadedBytes = size / 2;

            while (downloadedBytes < size)
            {
                downloadedBytes += await outputStream.ReadAsync(outputBytes, downloadedBytes, size / 4);
            }

            // Assert
            Assert.AreEqual(data.Length, outputStream.Length);
            TestHelper.AssertSequenceEqual(expected, outputBytes);
        }

        [Test]
        public async Task OpenReadAsync_Error()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareFileClient file = test.Directory.GetFileClient(GetNewFileName());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.OpenReadAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        public async Task OpenReadAsync_Lease()
        {
            int size = Constants.KB;
            await using DisposingDirectory test = await GetTestDirectoryAsync();

            // Arrange
            var data = GetRandomBuffer(size);
            ShareFileClient file = await test.Directory.CreateFileAsync(GetNewFileName(), size);
            using Stream stream = new MemoryStream(data);
            await file.UploadAsync(stream);
            ShareFileLease fileLease = await InstrumentClient(file.GetShareLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync();
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = fileLease.LeaseId
            };

            ShareFileOpenReadOptions options = new ShareFileOpenReadOptions(allowModifications: false)
            {
                Conditions = conditions
            };

            // Act
            Stream outputStream = await file.OpenReadAsync(options).ConfigureAwait(false);
            byte[] outputBytes = new byte[size];
            await outputStream.ReadAsync(outputBytes, 0, size);

            // Assert
            Assert.AreEqual(data.Length, outputStream.Length);
            TestHelper.AssertSequenceEqual(data, outputBytes);
        }

        [Test]
        public async Task OpenReadAsync_InvalidLease()
        {
            int size = Constants.KB;
            await using DisposingDirectory test = await GetTestDirectoryAsync();

            // Arrange
            var data = GetRandomBuffer(size);
            ShareFileClient file = await test.Directory.CreateFileAsync(GetNewFileName(), size);
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = Recording.Random.NewGuid().ToString()
            };

            ShareFileOpenReadOptions options = new ShareFileOpenReadOptions(allowModifications: false)
            {
                Conditions = conditions
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.OpenReadAsync(options),
                e => Assert.AreEqual("LeaseNotPresentWithFileOperation", e.ErrorCode));
        }

        [Test]
        public async Task OpenReadAsync_StrangeOffsetsTest()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();

            int size = Constants.KB;
            byte[] exectedData = GetRandomBuffer(size);
            ShareFileClient file = await test.Directory.CreateFileAsync(GetNewFileName(), size);
            using Stream stream = new MemoryStream(exectedData);
            await file.UploadAsync(stream);

            ShareFileOpenReadOptions options = new ShareFileOpenReadOptions(allowModifications: false)
            {
                Position = 0,
                BufferSize = 157
            };

            Stream outputStream = await file.OpenReadAsync(options);
            byte[] actualData = new byte[size];
            int offset = 0;

            // Act
            int count = 0;
            int readBytes = -1;
            while (readBytes != 0)
            {
                for (count = 6; count < 37; count += 6)
                {
                    readBytes = await outputStream.ReadAsync(actualData, offset, count);
                    if (readBytes == 0)
                    {
                        break;
                    }
                    offset += readBytes;
                }
            }

            // Assert
            TestHelper.AssertSequenceEqual(exectedData, actualData);
        }

        [Test]
        [Ignore("Don't want to record 1 GB of data.")]
        public async Task OpenReadAsync_LargeData()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            int size = 1 * Constants.GB;
            byte[] exectedData = GetRandomBuffer(size);
            ShareFileClient file = await test.Directory.CreateFileAsync(GetNewFileName(), size);
            using Stream stream = new MemoryStream(exectedData);
            await file.UploadAsync(stream);

            Stream outputStream = await file.OpenReadAsync();
            int readSize = 8 * Constants.MB;
            byte[] actualData = new byte[readSize];
            int offset = 0;

            // Act
            for (int i = 0; i < size / readSize; i++)
            {
                await outputStream.ReadAsync(actualData, 0, readSize);
                for (int j = 0; j < readSize; j++)
                {
                    // Assert
                    if (actualData[j] != exectedData[offset + j])
                    {
                        Assert.Fail($"Index {offset + j} does not match.  Expected: {exectedData[offset + j]} Actual: {actualData[j]}");
                    }
                }
                offset += readSize;
            }
        }

        [Test]
        public async Task OpenReadAsync_CopyReadStreamToAnotherStream()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            long size = 4 * Constants.MB;
            byte[] exectedData = GetRandomBuffer(size);
            ShareFileClient fileClient = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await fileClient.CreateAsync(size);
            using Stream stream = new MemoryStream(exectedData);
            await fileClient.UploadAsync(stream);

            MemoryStream outputStream = new MemoryStream();

            // Act
            using Stream fileStream = await fileClient.OpenReadAsync();
            await fileStream.CopyToAsync(outputStream);

            TestHelper.AssertSequenceEqual(exectedData, outputStream.ToArray());
        }

        [Test]
        public async Task OpenReadAsync_InvalidParameterTests()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            long size = 4 * Constants.MB;
            byte[] exectedData = GetRandomBuffer(size);
            ShareFileClient fileClient = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await fileClient.CreateAsync(size);
            await fileClient.UploadAsync(new MemoryStream(exectedData));
            Stream stream = await fileClient.OpenReadAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentNullException>(
                stream.ReadAsync(buffer: null, offset: 0, count: 10),
                new ArgumentNullException("buffer", "buffer cannot be null."));

            await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                stream.ReadAsync(buffer: new byte[10], offset: -1, count: 10),
                new ArgumentOutOfRangeException("offset cannot be less than 0.", $"Specified argument was out of the range of valid values."));

            await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                stream.ReadAsync(buffer: new byte[10], offset: 11, count: 10),
                new ArgumentOutOfRangeException("offset cannot exceed buffer length.", "Specified argument was out of the range of valid values."));

            await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                stream.ReadAsync(buffer: new byte[10], offset: 1, count: -1),
                new ArgumentOutOfRangeException("count cannot be less than 0.", "Specified argument was out of the range of valid values."));
        }

        [Test]
        public async Task OpenReadAsync_Seek_PositionUnchanged()
        {
            int size = Constants.KB;
            await using DisposingDirectory test = await GetTestDirectoryAsync();

            // Arrange
            var data = GetRandomBuffer(size);
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(size);
            using Stream stream = new MemoryStream(data);
            await file.UploadAsync(stream);

            // Act
            Stream outputStream = await file.OpenReadAsync().ConfigureAwait(false);
            byte[] outputBytes = new byte[size];
            outputStream.Seek(0, SeekOrigin.Begin);

            Assert.AreEqual(0, outputStream.Position);

            await outputStream.ReadAsync(outputBytes, 0, size);

            // Assert
            Assert.AreEqual(data.Length, outputStream.Length);
            TestHelper.AssertSequenceEqual(data, outputBytes);
        }

        [Test]
        public async Task OpenReadAsync_Seek_NegativeNewPosition()
        {
            int size = Constants.KB;
            await using DisposingDirectory test = await GetTestDirectoryAsync();

            // Arrange
            var data = GetRandomBuffer(size);
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(size);
            using Stream stream = new MemoryStream(data);
            await file.UploadAsync(stream);

            // Act
            Stream outputStream = await file.OpenReadAsync().ConfigureAwait(false);
            TestHelper.AssertExpectedException<ArgumentException>(
                () => outputStream.Seek(-10, SeekOrigin.Begin),
                new ArgumentException("New offset cannot be less than 0.  Value was -10"));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task OpenReadAsync_Seek_NewPositionGreaterThanFileLength(bool allowModifications)
        {
            int size = Constants.KB;
            await using DisposingDirectory test = await GetTestDirectoryAsync();

            // Arrange
            var data = GetRandomBuffer(size);
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(size);
            using Stream stream = new MemoryStream(data);
            await file.UploadAsync(stream);

            ShareFileOpenReadOptions options = new ShareFileOpenReadOptions(allowModifications: allowModifications);

            // Act
            Stream outputStream = await file.OpenReadAsync(options: options).ConfigureAwait(false);
            TestHelper.AssertExpectedException<ArgumentException>(
                () => outputStream.Seek(size + 10, SeekOrigin.Begin),
                new ArgumentException("You cannot seek past the last known length of the underlying blob or file."));

            Assert.AreEqual(size, outputStream.Length);
        }

        [Test]
        [TestCase(0, SeekOrigin.Begin)]
        [TestCase(10, SeekOrigin.Begin)]
        [TestCase(-10, SeekOrigin.Current)]
        [TestCase(0, SeekOrigin.Current)]
        [TestCase(10, SeekOrigin.Current)]
        [TestCase(0, SeekOrigin.End)]
        [TestCase(-10, SeekOrigin.End)]
        public async Task OpenReadAsync_Seek_Position(long offset, SeekOrigin origin)
        {
            int size = Constants.KB;
            await using DisposingDirectory test = await GetTestDirectoryAsync();

            // Arrange
            var data = GetRandomBuffer(size);
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(size);
            using Stream stream = new MemoryStream(data);
            await file.UploadAsync(stream);

            ShareFileOpenReadOptions options = new ShareFileOpenReadOptions(allowModifications: false);

            Stream outputStream = await file.OpenReadAsync(options: options).ConfigureAwait(false);
            int readBytes = 512;
            await outputStream.ReadAsync(new byte[readBytes], 0, readBytes);
            Assert.AreEqual(512, outputStream.Position);

            // Act
            outputStream.Seek(offset, origin);

            // Assert
            if (origin == SeekOrigin.Begin)
            {
                Assert.AreEqual(offset, outputStream.Position);
            }
            else if (origin == SeekOrigin.Current)
            {
                Assert.AreEqual(readBytes + offset, outputStream.Position);
            }
            else
            {
                Assert.AreEqual(size + offset, outputStream.Position);
            }

            Assert.AreEqual(size, outputStream.Length);
        }

        [Test]
        // lower position within _buffer
        [TestCase(-50)]
        // higher positiuon within _buffer
        [TestCase(50)]
        // lower position below _buffer
        [TestCase(-100)]
        // higher position above _buffer
        [TestCase(100)]
        public async Task OpenReadAsync_Seek(long offset)
        {
            int size = Constants.KB;
            int initalPosition = 450;
            await using DisposingDirectory test = await GetTestDirectoryAsync();

            // Arrange
            byte[] data = GetRandomBuffer(size);
            byte[] expectedData = new byte[size - (initalPosition + offset)];
            Array.Copy(data, initalPosition + offset, expectedData, 0, size - (initalPosition + offset));
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(size);
            using Stream stream = new MemoryStream(data);
            await file.UploadAsync(stream);

            ShareFileOpenReadOptions options = new ShareFileOpenReadOptions(allowModifications: false)
            {
                BufferSize = 128
            };

            // Act
            Stream openReadStream = await file.OpenReadAsync(options: options).ConfigureAwait(false);
            int readbytes = initalPosition;
            while (readbytes > 0)
            {
                readbytes -= await openReadStream.ReadAsync(new byte[readbytes], 0, readbytes);
            }

            openReadStream.Seek(offset, SeekOrigin.Current);

            using MemoryStream outputStream = new MemoryStream();
            await openReadStream.CopyToAsync(outputStream);

            // Assert
            Assert.AreEqual(expectedData.Length, outputStream.ToArray().Length);
            TestHelper.AssertSequenceEqual(expectedData, outputStream.ToArray());
            Assert.AreEqual(size, openReadStream.Length);
        }

        [Test]
        // lower position within _buffer
        [TestCase(400)]
        // higher positiuon within _buffer
        [TestCase(500)]
        // lower position below _buffer
        [TestCase(250)]
        // higher position above _buffer
        [TestCase(550)]
        public async Task OpenReadAsync_SetPosition(long position)
        {
            int size = Constants.KB;
            int initalPosition = 450;
            await using DisposingDirectory test = await GetTestDirectoryAsync();

            // Arrange
            byte[] data = GetRandomBuffer(size);
            byte[] expectedData = new byte[size - position];
            Array.Copy(data, position, expectedData, 0, size - position);
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(size);
            using Stream stream = new MemoryStream(data);
            await file.UploadAsync(stream);

            ShareFileOpenReadOptions options = new ShareFileOpenReadOptions(allowModifications: false)
            {
                BufferSize = 128
            };

            // Act
            Stream openReadStream = await file.OpenReadAsync(options: options).ConfigureAwait(false);
            int readbytes = initalPosition;
            while (readbytes > 0)
            {
                readbytes -= await openReadStream.ReadAsync(new byte[readbytes], 0, readbytes);
            }

            openReadStream.Position = position;

            using MemoryStream outputStream = new MemoryStream();
            await openReadStream.CopyToAsync(outputStream);

            // Assert
            Assert.AreEqual(expectedData.Length, outputStream.ToArray().Length);
            TestHelper.AssertSequenceEqual(expectedData, outputStream.ToArray());
        }

        public async Task GetFileClient_AsciiName()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Act
            var name = GetNewFileName();
            ShareFileClient file = InstrumentClient(directory.GetFileClient(name));
            Response<ShareFileInfo> response = await file.CreateAsync(maxSize: Constants.MB);

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
        public async Task GetFileClient_NonAsciiName()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Act
            var name = GetNewNonAsciiFileName();
            ShareFileClient file = InstrumentClient(directory.GetFileClient(name));
            Response<ShareFileInfo> response = await file.CreateAsync(maxSize: Constants.MB);

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
        public async Task OpenWriteAsync_NewFile()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(16 * Constants.KB);

            ShareFileOpenWriteOptions options = new ShareFileOpenWriteOptions
            {
                BufferSize = Constants.KB
            };

            Stream stream = await file.OpenWriteAsync(
                overwrite: false,
                position: 0,
                options: options);

            byte[] data = GetRandomBuffer(16 * Constants.KB);

            // Act
            await stream.WriteAsync(data, 0, 512);
            await stream.WriteAsync(data, 512, 1024);
            await stream.WriteAsync(data, 1536, 2048);
            await stream.WriteAsync(data, 3584, 77);
            await stream.WriteAsync(data, 3661, 2066);
            await stream.WriteAsync(data, 5727, 4096);
            await stream.WriteAsync(data, 9823, 6561);
            await stream.FlushAsync();

            // Assert
            Response<ShareFileDownloadInfo> result = await file.DownloadAsync();
            var dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(data.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(data, dataResult.ToArray());
        }

        [Test]
        public async Task OpenWriteAsync_NewFile_WithUsing()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(16 * Constants.KB);

            ShareFileOpenWriteOptions options = new ShareFileOpenWriteOptions
            {
                BufferSize = Constants.KB
            };

            byte[] data = GetRandomBuffer(16 * Constants.KB);

            // Act
            using (Stream stream = await file.OpenWriteAsync(
                overwrite: false,
                position: 0,
                options: options))
            {
                await stream.WriteAsync(data, 0, 512);
                await stream.WriteAsync(data, 512, 1024);
                await stream.WriteAsync(data, 1536, 2048);
                await stream.WriteAsync(data, 3584, 77);
                await stream.WriteAsync(data, 3661, 2066);
                await stream.WriteAsync(data, 5727, 4096);
                await stream.WriteAsync(data, 9823, 6561);
            }

            // Assert
            Response<ShareFileDownloadInfo> result = await file.DownloadAsync();
            var dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(data.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(data, dataResult.ToArray());
        }

        [Test]
        public async Task OpenWriteAsync_ModifyExistingFile()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(2 * Constants.KB);

            byte[] originalData = GetRandomBuffer(Constants.KB);
            using Stream originalStream = new MemoryStream(originalData);

            await file.UploadAsync(originalStream);

            byte[] newData = GetRandomBuffer(Constants.KB);
            using Stream newStream = new MemoryStream(newData);

            // Act
            Stream openWriteStream = await file.OpenWriteAsync(
                overwrite: false,
                position: Constants.KB);
            await newStream.CopyToAsync(openWriteStream);
            await openWriteStream.FlushAsync();

            // Assert
            byte[] expectedData = new byte[2 * Constants.KB];
            Array.Copy(originalData, 0, expectedData, 0, Constants.KB);
            Array.Copy(newData, 0, expectedData, Constants.KB, Constants.KB);

            Response<ShareFileDownloadInfo> result = await file.DownloadAsync(new HttpRange(0, 2 * Constants.KB));
            MemoryStream dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(expectedData.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(expectedData, dataResult.ToArray());
        }

        [Test]
        public async Task OpenWriteAsync_AlternatingWriteAndFlush()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(Constants.KB);

            byte[] data0 = GetRandomBuffer(512);
            byte[] data1 = GetRandomBuffer(512);
            using Stream dataStream0 = new MemoryStream(data0);
            using Stream dataStream1 = new MemoryStream(data1);
            byte[] expectedData = new byte[Constants.KB];
            Array.Copy(data0, expectedData, 512);
            Array.Copy(data1, 0, expectedData, 512, 512);

            // Act
            Stream writeStream = await file.OpenWriteAsync(
                overwrite: false,
                position: 0);
            await dataStream0.CopyToAsync(writeStream);
            await writeStream.FlushAsync();
            await dataStream1.CopyToAsync(writeStream);
            await writeStream.FlushAsync();

            // Assert
            Response<ShareFileDownloadInfo> result = await file.DownloadAsync();
            MemoryStream dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(expectedData.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(expectedData, dataResult.ToArray());
        }

        [Test]
        public async Task OpenWriteAsync_Error()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(GetNewShareName()));
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.OpenWriteAsync(
                    overwrite: false,
                    position: 0),
                e => Assert.AreEqual(ShareErrorCode.ShareNotFound.ToString(), e.ErrorCode));
        }

        [Test]
        public async Task OpenWriteAsync_ProgressReporting()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(Constants.KB);

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);

            TestProgress progress = new TestProgress();
            ShareFileOpenWriteOptions options = new ShareFileOpenWriteOptions
            {
                ProgressHandler = progress,
                BufferSize = 256
            };

            // Act
            Stream openWriteStream = await file.OpenWriteAsync(
                overwrite: false,
                position: 0,
                options: options);
            await stream.CopyToAsync(openWriteStream);
            await openWriteStream.FlushAsync();

            Assert.IsTrue(progress.List.Count > 0);
            Assert.AreEqual(Constants.KB, progress.List[progress.List.Count - 1]);
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public async Task OpenWriteAsync_Overwite(bool fileExists)
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            if (fileExists)
            {
                await file.CreateAsync(Constants.KB);
            }

            byte[] expectedData = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(expectedData);

            ShareFileOpenWriteOptions options = new ShareFileOpenWriteOptions
            {
                MaxSize = Constants.KB
            };

            // Act
            Stream openWriteStream = await file.OpenWriteAsync(
                overwrite: true,
                position: 0,
                options: options);
            await stream.CopyToAsync(openWriteStream);
            await openWriteStream.FlushAsync();

            // Assert
            Response<ShareFileDownloadInfo> result = await file.DownloadAsync();
            var dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(expectedData.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(expectedData, dataResult.ToArray());
        }

        [Test]
        public async Task OpenWriteAsync_OverwriteNoSize()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                file.OpenWriteAsync(
                    overwrite: true,
                    position: 0),
                e => Assert.AreEqual("options.MaxSize must be set if overwrite is set to true", e.Message));
        }

        [Test]
        public async Task OpenWriteAsync_NewFileNoSize()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                file.OpenWriteAsync(
                    overwrite: false,
                    position: 0),
                e => Assert.AreEqual("options.MaxSize must be set if the File is being created for the first time", e.Message));
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task OpenWriteAsync_Lease(bool overwrite)
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(Constants.KB);

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);

            ShareFileLease fileLease = await InstrumentClient(file.GetShareLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync();
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = fileLease.LeaseId
            };

            ShareFileOpenWriteOptions options = new ShareFileOpenWriteOptions
            {
                OpenConditions = conditions,
                MaxSize = Constants.KB
            };

            // Act
            Stream openWriteStream = await file.OpenWriteAsync(
                overwrite: overwrite,
                position: 0,
                options: options);
            await stream.CopyToAsync(openWriteStream);
            await openWriteStream.FlushAsync();
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task OpenWriteAsync_InvalidLease(bool overwrite)
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(Constants.KB);

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);

            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = Recording.Random.NewGuid().ToString()
            };

            ShareFileOpenWriteOptions options = new ShareFileOpenWriteOptions
            {
                OpenConditions = conditions,
                MaxSize = Constants.KB
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                 file.OpenWriteAsync(
                     overwrite: overwrite,
                     position: 0,
                     options: options),
                e => Assert.AreEqual("LeaseNotPresentWithFileOperation", e.ErrorCode));
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
            ShareFileClient directory = InstrumentClient(new ShareFileClient(
                connectionString,
                GetNewShareName(),
                GetNewDirectoryName()));
            Assert.IsTrue(directory.CanGenerateSasUri);

            // Act - ShareFileClient(string connectionString, string blobContainerName, string blobName, BlobClientOptions options)
            ShareFileClient directory2 = InstrumentClient(new ShareFileClient(
                connectionString,
                GetNewShareName(),
                GetNewDirectoryName(),
                GetOptions()));
            Assert.IsTrue(directory2.CanGenerateSasUri);

            // Act - ShareFileClient(Uri blobContainerUri, BlobClientOptions options = default)
            ShareFileClient directory3 = InstrumentClient(new ShareFileClient(
                blobEndpoint,
                GetOptions()));
            Assert.IsFalse(directory3.CanGenerateSasUri);

            // Act - ShareFileClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            ShareFileClient directory4 = InstrumentClient(new ShareFileClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            Assert.IsTrue(directory4.CanGenerateSasUri);
        }

        [Test]
        public void GenerateSas_RequiredParameters()
        {
            // Arrange
            var constants = new TestConstants(this);
            ShareFileSasPermissions permissions = ShareFileSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, fileStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);
            string shareName = GetNewShareName();
            string fileName = GetNewFileName();
            ShareFileClient fileClient = InstrumentClient(new ShareFileClient(
                connectionString,
                shareName,
                fileName,
                GetOptions()));

            // Act
            Uri sasUri = fileClient.GenerateSasUri(permissions, expiresOn);

            // Assert
            ShareSasBuilder sasBuilder = new ShareSasBuilder(permissions, expiresOn)
            {
                ShareName = shareName,
                FilePath = fileName,
            };
            ShareUriBuilder expectedUri = new ShareUriBuilder(blobEndpoint)
            {
                ShareName = shareName,
                DirectoryOrFilePath = fileName,
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
            string fileName = GetNewFileName();

            ShareFileClient directoryClient = InstrumentClient(new ShareFileClient(
                connectionString,
                shareName,
                fileName,
                GetOptions()));

            ShareSasBuilder sasBuilder = new ShareSasBuilder(permissions, expiresOn)
            {
                ShareName = shareName,
                FilePath = fileName,
                StartsOn = startsOn
            };

            // Act
            Uri sasUri = directoryClient.GenerateSasUri(sasBuilder);

            // Assert
            ShareSasBuilder sasBuilder2 = new ShareSasBuilder(permissions, expiresOn)
            {
                ShareName = shareName,
                FilePath = fileName,
                StartsOn = startsOn
            };
            ShareUriBuilder expectedUri = new ShareUriBuilder(blobEndpoint)
            {
                ShareName = shareName,
                DirectoryOrFilePath = fileName,
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
            UriBuilder uriBuilder = new UriBuilder(blobEndpoint);
            string fileName = GetNewFileName();
            uriBuilder.Path += constants.Sas.Account + "/" + GetNewShareName() + "/" + fileName;
            ShareFileClient fileClient = InstrumentClient(new ShareFileClient(
                uriBuilder.Uri,
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            ShareSasBuilder sasBuilder = new ShareSasBuilder(ShareFileSasPermissions.All, Recording.UtcNow.AddHours(+1))
            {
                ShareName = GetNewShareName(), // different share name
                FilePath = fileName
            };

            // Act
            try
            {
                fileClient.GenerateSasUri(sasBuilder);

                Assert.Fail("ShareFileClient.GenerateSasUri should have failed with an ArgumentException.");
            }
            catch (InvalidOperationException)
            {
                //the correct exception came back
            }
        }

        [Test]
        public void GenerateSas_BuilderWrongFileName()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("http://127.0.0.1/");
            string shareName = GetNewShareName();
            UriBuilder blobUriBuilder = new UriBuilder(blobEndpoint);
            blobUriBuilder.Path += constants.Sas.Account + "/" + shareName + "/" + GetNewFileName();
            ShareFileClient containerClient = InstrumentClient(new ShareFileClient(
                blobUriBuilder.Uri,
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            ShareSasBuilder sasBuilder = new ShareSasBuilder(ShareFileSasPermissions.All, Recording.UtcNow.AddHours(+1))
            {
                ShareName = shareName,
                FilePath = GetNewFileName() // different file name
            };

            // Act
            try
            {
                containerClient.GenerateSasUri(sasBuilder);

                Assert.Fail("ShareFileClient.GenerateSasUri should have failed with an ArgumentException.");
            }
            catch (InvalidOperationException)
            {
                //the correct exception came back
            }
        }
        #endregion

        private async Task WaitForCopy(ShareFileClient file, int milliWait = 200)
        {
            CopyStatus status = CopyStatus.Pending;
            DateTimeOffset start = Recording.Now;
            while (status != CopyStatus.Success)
            {
                status = (await file.GetPropertiesAsync()).Value.CopyStatus;
                DateTimeOffset currentTime = Recording.Now;
                if (status == CopyStatus.Failed || currentTime.AddMinutes(-1) > start)
                {
                    throw new Exception("Copy failed or took too long");
                }
                await Delay(milliWait);
            }
        }
    }
}
