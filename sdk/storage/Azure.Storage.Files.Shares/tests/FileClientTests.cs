// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Files.Shares.Specialized;
using Azure.Storage.Files.Shares.Tests;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Test
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
        // "Test framework doesn't allow recorded tests with connection string because the word 'Sanitized' is not base-64 encoded,
        // so we can't pass connection string validation"
        [LiveOnly]
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
                e => Assert.AreEqual(
                    "Value must be less than or equal to 8192" + Environment.NewLine
                    + "Parameter name: filePermission", e.Message));
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
            await directory.CreateAsync();

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
        public async Task ExistsAsync_Error()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));
            ShareFileClient file = InstrumentClient(share.GetRootDirectoryClient().GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.ExistsAsync(),
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode));
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
        public async Task DeleteIfExistsAsync_Error()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));
            ShareFileClient file = InstrumentClient(share.GetRootDirectoryClient().GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.DeleteIfExistsAsync(),
                e => Assert.AreEqual("ShareNotFound", e.ErrorCode));
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
                    StartsOn = Recording.UtcNow.AddHours(-1),
                    ExpiresOn = Recording.UtcNow.AddHours(1),
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
            await directory.CreateAsync();

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
                e => Assert.AreEqual(
                    "Value must be less than or equal to 8192" + Environment.NewLine
                    + "Parameter name: filePermission", e.Message));
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

            await directory.CreateAsync();

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

            // Act
            Response<ShareFileRangeInfo> response = await file.GetRangeListAsync(range: new HttpRange(0, Constants.MB));

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
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = fileLease.LeaseId
            };

            // Act
            Response<ShareFileRangeInfo> response = await file.GetRangeListAsync(
                range: new HttpRange(0, Constants.MB),
                conditions: conditions);

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

            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = Recording.Random.NewGuid().ToString()
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.GetRangeListAsync(
                    range: new HttpRange(0, Constants.MB),
                    conditions: conditions),
                e => Assert.AreEqual("LeaseNotPresentWithFileOperation", e.ErrorCode));
        }

        [Test]
        public async Task GetRangeListAsync_Error()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.GetRangeListAsync(range: new HttpRange(0, Constants.MB)),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
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

            await directory.CreateAsync();

            // Arrange
            var fileName = GetNewFileName();
            ShareFileClient fileFaulty = InstrumentClient(directoryFaulty.GetFileClient(fileName));
            ShareFileClient file = InstrumentClient(directory.GetFileClient(fileName));
            await file.CreateAsync(maxSize: fileSize);

            var data = GetRandomBuffer(dataSize);
            var progressList = new List<long>();
            var progressHandler = new Progress<long>(progress => { progressList.Add(progress); /*logger.LogTrace("Progress: {progress}", progress.BytesTransferred);*/ });
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

                await WaitForProgressAsync(progressList, data.LongLength);
                Assert.IsTrue(progressList.Count > 1, "Too few progress received");
                Assert.GreaterOrEqual(data.LongLength, progressList.Last(), "Final progress has unexpected value");
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
            await directory.CreateAsync();

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
            await directory.CreateAsync();

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
            await directory.CreateAsync();

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
            await directory.CreateAsync();

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
