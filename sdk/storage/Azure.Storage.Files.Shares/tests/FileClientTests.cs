// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Files.Shares.Specialized;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.Storage.Files.Shares.Tests
{
    public class FileClientTests : FileTestBase
    {
        public FileClientTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
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

        [RecordedTest]
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
        public void Ctor_ConnectionString_CustomUri()
        {
            var accountName = "accountName";
            var shareName = "shareName";
            var directoryName = "directoryName";
            var fileName = "fileName";
            var filePath = $"{directoryName}/{fileName}";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var fileEndpoint = new Uri("http://customdomain/" + accountName);
            var fileSecondaryEndpoint = new Uri("http://customdomain/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, (default, default), (default, default), (default, default), (fileEndpoint, fileSecondaryEndpoint));

            ShareFileClient fileClient = new ShareFileClient(connectionString.ToString(true), shareName, filePath);

            Assert.AreEqual(accountName, fileClient.AccountName);
            Assert.AreEqual(shareName, fileClient.ShareName);
            Assert.AreEqual(filePath, fileClient.Path);
        }

        [Test]
        public void Ctor_SharedKey_AccountName()
        {
            // Arrange
            var accountName = "accountName";
            var shareName = "shareName";
            var directoryName = "directoryName";
            var fileName = "fileName";
            var filePath = $"{directoryName}/{fileName}";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });
            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var shareEndpoint = new Uri($"https://customdomain/{shareName}/{filePath}");

            ShareDirectoryClient ShareDirectoryClient = new ShareDirectoryClient(shareEndpoint, credentials);

            Assert.AreEqual(accountName, ShareDirectoryClient.AccountName);
            Assert.AreEqual(shareName, ShareDirectoryClient.ShareName);
            Assert.AreEqual(filePath, ShareDirectoryClient.Path);
        }

        [RecordedTest]
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

        [RecordedTest]
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

                [RecordedTest]
        public async Task Ctor_DefaultAudience()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directoryClient = test.Share.GetDirectoryClient(GetNewDirectoryName());
            await directoryClient.CreateIfNotExistsAsync();
            ShareFileClient fileClient = directoryClient.GetFileClient(GetNewFileName());
            await fileClient.CreateAsync(Constants.KB);

            // Act - Create new Share client with the OAuth Credential and Audience
            ShareClientOptions options = GetOptionsWithAudience(ShareAudience.DefaultAudience);

            ShareUriBuilder uriBuilder = new ShareUriBuilder(new Uri(Tenants.TestConfigOAuth.FileServiceEndpoint))
            {
                ShareName = test.Share.Name,
                DirectoryOrFilePath = fileClient.Path
            };

            ShareFileClient aadFileClient = InstrumentClient(new ShareFileClient(
                uriBuilder.ToUri(),
                TestEnvironment.Credential,
                options));

            // Assert
            bool exists = await aadFileClient.ExistsAsync();
            Assert.IsNotNull(exists);
        }

        [Test]
        public void Ctor_DevelopmentThrows()
        {
            var ex = Assert.Throws<ArgumentException>(() => new ShareFileClient("UseDevelopmentStorage=true", "share", "dir/file"));
            Assert.AreEqual("connectionString", ex.ParamName);
        }

        [RecordedTest]
        public async Task Ctor_CustomAudience()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directoryClient = test.Share.GetDirectoryClient(GetNewDirectoryName());
            await directoryClient.CreateIfNotExistsAsync();
            ShareFileClient fileClient = directoryClient.GetFileClient(GetNewFileName());
            await fileClient.CreateAsync(Constants.KB);

            // Act - Create new Share client with the OAuth Credential and Audience
            ShareClientOptions options = GetOptionsWithAudience(new ShareAudience($"https://{test.Share.AccountName}.file.core.windows.net/"));

            ShareUriBuilder uriBuilder = new ShareUriBuilder(new Uri(Tenants.TestConfigOAuth.FileServiceEndpoint))
            {
                ShareName = test.Share.Name,
                DirectoryOrFilePath = fileClient.Path
            };

            ShareFileClient aadFileClient = InstrumentClient(new ShareFileClient(
                uriBuilder.ToUri(),
                TestEnvironment.Credential,
                options));

            // Assert
            bool exists = await aadFileClient.ExistsAsync();
            Assert.IsNotNull(exists);
        }

        [RecordedTest]
        public async Task Ctor_StorageAccountAudience()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directoryClient = test.Share.GetDirectoryClient(GetNewDirectoryName());
            await directoryClient.CreateIfNotExistsAsync();
            ShareFileClient fileClient = directoryClient.GetFileClient(GetNewFileName());
            await fileClient.CreateAsync(Constants.KB);

            // Act - Create new Share client with the OAuth Credential and Audience
            ShareClientOptions options = GetOptionsWithAudience(ShareAudience.CreateShareServiceAccountAudience(test.Share.AccountName));

            ShareUriBuilder uriBuilder = new ShareUriBuilder(new Uri(Tenants.TestConfigOAuth.FileServiceEndpoint))
            {
                ShareName = test.Share.Name,
                DirectoryOrFilePath = fileClient.Path
            };

            ShareFileClient aadFileClient = InstrumentClient(new ShareFileClient(
                uriBuilder.ToUri(),
                TestEnvironment.Credential,
                options));

            // Assert
            bool exists = await aadFileClient.ExistsAsync();
            Assert.IsNotNull(exists);
        }

        [RecordedTest]
        public async Task Ctor_EscapeFileName()
        {
            // Arrange
            string fileName = "$=;!#öÖ";
            await using DisposingShare test = await GetTestShareAsync();
            int size = Constants.KB;
            var data = GetRandomBuffer(size);
            ShareFileClient file = InstrumentClient(test.Share.GetRootDirectoryClient().GetFileClient(fileName));
            ETag originalEtag;
            await file.CreateAsync(size);
            using (var stream = new MemoryStream(data))
            {
                ShareFileUploadInfo info = await file.UploadAsync(stream);
                originalEtag = info.ETag;
            }

            // Act
            ShareUriBuilder uriBuilder = new ShareUriBuilder(new Uri(Tenants.TestConfigOAuth.FileServiceEndpoint))
            {
                ShareName = test.Share.Name,
                DirectoryOrFilePath = fileName
            };
            ShareClientOptions options = GetOptions();
            options.ShareTokenIntent = ShareTokenIntent.Backup;
            ShareFileClient freshFileClient = InstrumentClient(new ShareFileClient(
                uriBuilder.ToUri(),
                TestEnvironment.Credential,
                options));

            // Assert
            Assert.AreEqual(fileName, freshFileClient.Name);
            ShareFileProperties propertiesResponse = await freshFileClient.GetPropertiesAsync();
            Assert.AreEqual(originalEtag, propertiesResponse.ETag);
        }

        [RecordedTest]
        public async Task Ctor_AudienceError()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directoryClient = test.Share.GetDirectoryClient(GetNewDirectoryName());
            await directoryClient.CreateIfNotExistsAsync();
            ShareFileClient fileClient = directoryClient.GetFileClient(GetNewFileName());
            await fileClient.CreateAsync(Constants.KB);

            // Act - Create new Share client with the OAuth Credential and Audience
            ShareClientOptions options = GetOptionsWithAudience(new ShareAudience("https://badaudience.Share.core.windows.net"));

            ShareUriBuilder uriBuilder = new ShareUriBuilder(new Uri(Tenants.TestConfigOAuth.FileServiceEndpoint))
            {
                ShareName = test.Share.Name,
                DirectoryOrFilePath = fileClient.Path
            };

            ShareFileClient aadFileClient = InstrumentClient(new ShareFileClient(
                uriBuilder.ToUri(),
                new MockCredential(),
                options));

            // Assert
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                aadFileClient.ExistsAsync(),
                e => Assert.AreEqual("InvalidAuthenticationInfo", e.ErrorCode));
        }

        [RecordedTest]
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

        [RecordedTest]
        public async Task CreateAsync()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task CreateAsync_OAuth()
        {
            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            // Arrange
            var name = GetNewFileName();
            ShareFileClient file = InstrumentClient(directory.GetFileClient(name));

            // Act
            Response<ShareFileInfo> response = await file.CreateAsync(maxSize: Constants.MB);

            // Assert
            AssertValidStorageFileInfo(response);
            var accountName = new ShareUriBuilder(file.Uri).AccountName;
            TestHelper.AssertCacheableProperty(accountName, () => file.AccountName);
            TestHelper.AssertCacheableProperty(shareName, () => file.ShareName);
            TestHelper.AssertCacheableProperty(name, () => file.Name);
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task CreateAsync_Lease()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task CreateAsync_InvalidLease()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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

        [RecordedTest]
        public async Task CreateAsync_FilePermission()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            string filePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
            ShareFileCreateOptions options = new ShareFileCreateOptions
            {
                FilePermission = new ShareFilePermission
                {
                    Permission = filePermission
                }
            };

            // Act
            Response<ShareFileInfo> response = await file.CreateAsync(
                maxSize: Constants.MB,
                options: options);

            // Assert
            AssertValidStorageFileInfo(response);
        }

        [RecordedTest]
        [TestCase(null)]
        [TestCase(FilePermissionFormat.Sddl)]
        [TestCase(FilePermissionFormat.Binary)]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2024_11_04)]
        public async Task CreateAsync_FilePermissionFormat(FilePermissionFormat? filePermissionFormat)
        {
            // Arrange
            string permission;
            if (filePermissionFormat == null || filePermissionFormat == FilePermissionFormat.Sddl)
            {
                permission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)S:NO_ACCESS_CONTROL";
            }
            else
            {
                permission = "AQAUhGwAAACIAAAAAAAAABQAAAACAFgAAwAAAAAAFAD/AR8AAQEAAAAAAAUSAAAAAAAYAP8BHwABAgAAAAAABSAAAAAgAgAAAAAkAKkAEgABBQAAAAAABRUAAABZUbgXZnJdJWRjOwuMmS4AAQUAAAAAAAUVAAAAoGXPfnhLm1/nfIdwr/1IAQEFAAAAAAAFFQAAAKBlz354S5tf53yHcAECAAA=";
            }
            ShareFileCreateOptions options = new ShareFileCreateOptions
            {
                FilePermission = new ShareFilePermission
                {
                    Permission = permission,
                    PermissionFormat = filePermissionFormat
                }
            };

            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            await file.CreateAsync(
                maxSize: Constants.MB,
                options: options);
        }

        [RecordedTest]
        public async Task CreateAsync_FilePermissionAndFilePermissionKeySet()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            ShareFileCreateOptions options = new ShareFileCreateOptions
            {
                FilePermission = new ShareFilePermission
                {
                    Permission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)"
                },
                SmbProperties = new FileSmbProperties
                {
                    FilePermissionKey = "filePermissionKey"
                }
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                file.CreateAsync(
                    maxSize: Constants.MB,
                    options: options),
                e => Assert.AreEqual("filePermission and filePermissionKey cannot both be set", e.Message));
        }

        [RecordedTest]
        public async Task CreateAsync_FilePermissionTooLarge()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            ShareFilePermission filePermission = new ShareFilePermission
            {
                Permission = new string('*', 9 * Constants.KB)
            };
            ShareFileCreateOptions options = new ShareFileCreateOptions
            {
                FilePermission = filePermission
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                file.CreateAsync(
                    maxSize: Constants.MB,
                    options: options),
                e =>
                {
                    Assert.AreEqual("filePermission", e.ParamName);
                    StringAssert.StartsWith("Value must be less than or equal to 8192", e.Message);
                });
        }

        [RecordedTest]
        public async Task CreateAsync_SmbProperties()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            string permission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
            ShareFilePermission filePermission = new ShareFilePermission()
            {
                Permission = permission,
            };
            Response<PermissionInfo> createPermissionResponse = await share.CreatePermissionAsync(filePermission);

            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            await directory.CreateIfNotExistsAsync();

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            ShareFileCreateOptions options = new ShareFileCreateOptions
            {
                SmbProperties = new FileSmbProperties
                {
                    FilePermissionKey = createPermissionResponse.Value.FilePermissionKey,
                    FileAttributes = ShareModelExtensions.ToFileAttributes("Archive|ReadOnly"),
                    FileCreatedOn = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero),
                    FileLastWrittenOn = new DateTimeOffset(2019, 8, 26, 5, 15, 25, 60, TimeSpan.Zero),
                }
            };

            // Act
            Response<ShareFileInfo> response = await file.CreateAsync(
                maxSize: Constants.KB,
                options: options);

            // Assert
            AssertValidStorageFileInfo(response);
            Assert.AreEqual(options.SmbProperties.FileAttributes, response.Value.SmbProperties.FileAttributes);
            Assert.AreEqual(options.SmbProperties.FileCreatedOn, response.Value.SmbProperties.FileCreatedOn);
            Assert.AreEqual(options.SmbProperties.FileLastWrittenOn, response.Value.SmbProperties.FileLastWrittenOn);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_06_08)]
        public async Task CreateAsync_ChangeTime()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directoryClient = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
            await directoryClient.CreateIfNotExistsAsync();
            ShareFileClient fileClient = InstrumentClient(directoryClient.GetFileClient(GetNewFileName()));
            ShareFileCreateOptions options = new ShareFileCreateOptions
            {
                SmbProperties = new FileSmbProperties
                {
                    FileChangedOn = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero)
                }
            };

            // Act
            Response<ShareFileInfo> response = await fileClient.CreateAsync(
                maxSize: Constants.KB,
                options: options);

            // Assert
            AssertValidStorageFileInfo(response);
            Assert.AreEqual(options.SmbProperties.FileChangedOn, response.Value.SmbProperties.FileChangedOn);
        }

        [RecordedTest]
        public async Task CreateAsync_Metadata()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            ShareFileCreateOptions options = new ShareFileCreateOptions
            {
                Metadata = BuildMetadata()
            };

            // Act
            await file.CreateAsync(
                maxSize: Constants.MB,
                options: options);

            // Assert
            Response<ShareFileProperties> response = await file.GetPropertiesAsync();
            AssertDictionaryEquality(options.Metadata, response.Value.Metadata);
        }

        [RecordedTest]
        public async Task CreateAsync_Headers()
        {
            var constants = TestConstants.Create(this);

            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            ShareFileCreateOptions options = new ShareFileCreateOptions
            {
                HttpHeaders = new ShareFileHttpHeaders
                {
                    CacheControl = constants.CacheControl,
                    ContentDisposition = constants.ContentDisposition,
                    ContentEncoding = new string[] { constants.ContentEncoding },
                    ContentLanguage = new string[] { constants.ContentLanguage },
                    ContentHash = constants.ContentMD5,
                    ContentType = constants.ContentType
                }
            };

            // Act
            await file.CreateAsync(
                maxSize: Constants.MB,
                options: options);

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

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2020_02_10)]
        public async Task CreateAsync_4TB()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            Response<ShareFileInfo> response = await file.CreateAsync(4 * Constants.TB);

            // Assert
            AssertValidStorageFileInfo(response);
        }

        [RecordedTest]
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

        [RecordedTest]
        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task CreateAsync_TrailingDot(bool? allowTrailingDot)
        {
            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = allowTrailingDot;
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync(options: options);

            // Arrange
            string fileName = GetNewFileName();
            string fileNameWithDot = fileName + ".";
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(fileNameWithDot));

            // Act
            await file.CreateAsync(maxSize: 1024);

            // Assert
            List<ShareFileItem> shareFileItems = new List<ShareFileItem>();
            await foreach (ShareFileItem item in test.Directory.GetFilesAndDirectoriesAsync())
            {
                shareFileItems.Add(item);
            }
            Assert.AreEqual(1, shareFileItems.Count);

            if (allowTrailingDot == true)
            {
                Assert.AreEqual(fileNameWithDot, shareFileItems[0].Name);
            }
            else
            {
                Assert.AreEqual(fileName, shareFileItems[0].Name);
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2025_05_05)]
        public async Task CreateAsync_NFS()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync(nfs: true);
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            string name = GetNewFileName();
            ShareFileClient file = InstrumentClient(directory.GetFileClient(name));

            string owner = "345";
            string group = "123";
            string fileMode = "7777";

            ShareFileCreateOptions options = new ShareFileCreateOptions
            {
                PosixProperties = new FilePosixProperties
                {
                    Owner = owner,
                    Group = group,
                    FileMode = NfsFileMode.ParseOctalFileMode(fileMode)
                }
            };

            // Act
            Response<ShareFileInfo> response = await file.CreateAsync(
                maxSize: Constants.MB,
                options: options);

            // Assert
            Assert.AreEqual(NfsFileType.Regular, response.Value.PosixProperties.FileType);
            Assert.AreEqual(owner, response.Value.PosixProperties.Owner);
            Assert.AreEqual(group, response.Value.PosixProperties.Group);
            Assert.AreEqual(fileMode, response.Value.PosixProperties.FileMode.ToOctalFileMode());

            Assert.IsNull(response.Value.SmbProperties.FileAttributes);
            Assert.IsNull(response.Value.SmbProperties.FilePermissionKey);
        }

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
        public async Task ExistsAsync_ShareNotExists()
        {
            // Arrange
            ShareServiceClient service = SharesClientBuilder.GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(GetNewShareName()));
            ShareFileClient file = InstrumentClient(share.GetRootDirectoryClient().GetFileClient(GetNewFileName()));

            // Act
            Response<bool> response = await file.ExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
        public async Task DeleteIfExistsAsync_ShareNotExists()
        {
            // Arrange
            ShareServiceClient service = SharesClientBuilder.GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(GetNewShareName()));
            ShareFileClient file = InstrumentClient(share.GetRootDirectoryClient().GetFileClient(GetNewFileName()));

            // Act
            Response<bool> response = await file.DeleteIfExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
        public async Task SetMetadataAsync()
        {
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient file = test.File;

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await file.SetMetadataAsync(metadata);

            // Assert
            Response<ShareFileProperties> response = await file.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task SetMetadataAsync_OAuth()
        {
            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            ShareFileClient file = await directory.CreateFileAsync(GetNewFileName(), Constants.MB);

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await file.SetMetadataAsync(metadata);

            // Assert
            Response<ShareFileProperties> response = await file.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task SetMetadataAsync_Lease()
        {
            // Arrange
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
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

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task SetMetadataAsync_InvalidLease()
        {
            // Arrange
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
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

        [RecordedTest]
        public async Task SetMetadataAsync_Error()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.SetMetadataAsync(metadata),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task SetMetadataAsync_TrailingDot()
        {
            // Arrange
            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = true;
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync(options: options);
            ShareFileClient file = test.File;

            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await file.SetMetadataAsync(metadata);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            Response<ShareFileInfo> createResponse = await file.CreateAsync(maxSize: Constants.KB);

            // Act
            Response<ShareFileProperties> getPropertiesResponse = await file.GetPropertiesAsync();

            // Assert
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(getPropertiesResponse.Value.ETag.ToString(), $"\"{getPropertiesResponse.GetRawResponse().Headers.ETag}\"");
            Assert.AreEqual(createResponse.Value.ETag, getPropertiesResponse.Value.ETag);
            Assert.AreEqual(createResponse.Value.LastModified, getPropertiesResponse.Value.LastModified);
            Assert.AreEqual(createResponse.Value.IsServerEncrypted, getPropertiesResponse.Value.IsServerEncrypted);
            AssertPropertiesEqual(createResponse.Value.SmbProperties, getPropertiesResponse.Value.SmbProperties);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task GetPropertiesAsync_OAuth()
        {
            // Arrange
            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            Response<ShareFileInfo> createResponse = await file.CreateAsync(maxSize: Constants.KB);

            // Act
            Response<ShareFileProperties> getPropertiesResponse = await file.GetPropertiesAsync();

            // Assert
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(getPropertiesResponse.Value.ETag.ToString(), $"\"{getPropertiesResponse.GetRawResponse().Headers.ETag}\"");
            Assert.AreEqual(createResponse.Value.ETag, getPropertiesResponse.Value.ETag);
            Assert.AreEqual(createResponse.Value.LastModified, getPropertiesResponse.Value.LastModified);
            Assert.AreEqual(createResponse.Value.IsServerEncrypted, getPropertiesResponse.Value.IsServerEncrypted);
            AssertPropertiesEqual(createResponse.Value.SmbProperties, getPropertiesResponse.Value.SmbProperties);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_Snapshot()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();

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

        [RecordedTest]
        public async Task GetPropertiesAsync_SnapshotFailed()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();

            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(maxSize: Constants.KB);

            ShareClient snapshotShareClient = test.Share.WithSnapshot("2020-06-26T00:49:21.0000000Z");

            ShareFileClient snapshotFileClient = snapshotShareClient.GetDirectoryClient(test.Directory.Name).GetFileClient(file.Name);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                snapshotFileClient.GetPropertiesAsync(),
                e => Assert.AreEqual(ShareErrorCode.ShareNotFound.ToString(), e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task GetPropertiesAsync_NoLease()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            Response<ShareFileInfo> createResponse = await file.CreateAsync(maxSize: Constants.KB);
            await InstrumentClient(file.GetShareLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync();

            // Act
            Response<ShareFileProperties> getPropertiesResponse = await file.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(createResponse.Value.ETag, getPropertiesResponse.Value.ETag);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task GetPropertiesAsync_Lease()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task GetPropertiesAsync_InvalidLease()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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

        [RecordedTest]
        public async Task GetPropertiesAsync_ShareSAS()
        {
            var shareName = GetNewShareName();
            var directoryName = GetNewDirectoryName();
            var fileName = GetNewFileName();

            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync(shareName: shareName, directoryName: directoryName, fileName: fileName);
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

        [RecordedTest]
        public async Task GetPropertiesAsync_FileSAS()
        {
            var shareName = GetNewShareName();
            var directoryName = GetNewDirectoryName();
            var fileName = GetNewFileName();

            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync(shareName: shareName, directoryName: directoryName, fileName: fileName);
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

        [RecordedTest]
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
            SasQueryParameters sasQueryParameters = sasBuilder.ToSasQueryParameters(Tenants.GetNewSharedKeyCredentials());

            ShareUriBuilder uriBuilder = new ShareUriBuilder(fileClient.Uri)
            {
                Sas = sasQueryParameters
            };

            ShareFileClient sasFileClient = InstrumentClient(new ShareFileClient(
                uriBuilder.ToUri(),
                GetOptions()));

            // Act
            Response<ShareFileProperties> response = await RetryAsync(
                operation: async () => await sasFileClient.GetPropertiesAsync(),
                // The SetAccessPolicyAsync call may take up to 30 seconds to take effect
                // per https://docs.microsoft.com/en-us/rest/api/storageservices/set-share-acl.
                shouldRetry: e => e.Status == 403);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_Error()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task GetPropertiesAsync_TrailingDot()
        {
            // Arrange
            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = true;
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync(options: options);
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName() + "."));
            Response<ShareFileInfo> createResponse = await file.CreateAsync(maxSize: Constants.KB);

            // Act
            Response<ShareFileProperties> getPropertiesResponse = await file.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(createResponse.Value.ETag, getPropertiesResponse.Value.ETag);
            Assert.AreEqual(createResponse.Value.LastModified, getPropertiesResponse.Value.LastModified);
            Assert.AreEqual(createResponse.Value.IsServerEncrypted, getPropertiesResponse.Value.IsServerEncrypted);
            AssertPropertiesEqual(createResponse.Value.SmbProperties, getPropertiesResponse.Value.SmbProperties);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2025_05_05)]
        public async Task GetProperties_NFS()
        {
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync(nfs: true);

            // Act
            Response<ShareFileProperties> response = await test.File.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(NfsFileType.Regular, response.Value.PosixProperties.FileType);
            Assert.AreEqual("0", response.Value.PosixProperties.Owner);
            Assert.AreEqual("0", response.Value.PosixProperties.Group);
            Assert.AreEqual("0664", response.Value.PosixProperties.FileMode.ToOctalFileMode());
            Assert.AreEqual(1, response.Value.PosixProperties.LinkCount);

            Assert.IsNull(response.Value.SmbProperties.FileAttributes);
            Assert.IsNull(response.Value.SmbProperties.FilePermissionKey);
        }

        [RecordedTest]
        public async Task SetHttpHeadersAsync()
        {
            var constants = TestConstants.Create(this);

            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient file = test.File;
            ShareFileSetHttpHeadersOptions options = new ShareFileSetHttpHeadersOptions
            {
                HttpHeaders = new ShareFileHttpHeaders
                {
                    CacheControl = constants.CacheControl,
                    ContentDisposition = constants.ContentDisposition,
                    ContentEncoding = new string[] { constants.ContentEncoding },
                    ContentLanguage = new string[] { constants.ContentLanguage },
                    ContentHash = constants.ContentMD5,
                    ContentType = constants.ContentType
                }
            };

            // Act
            Response<ShareFileInfo> response = await file.SetHttpHeadersAsync(options);

            // Assert

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");

            // Ensure the correct values are set by calling GetProperties
            Response<ShareFileProperties> propertiesResponse = await file.GetPropertiesAsync();
            Assert.AreEqual(constants.ContentType, propertiesResponse.Value.ContentType);
            TestHelper.AssertSequenceEqual(constants.ContentMD5.ToList(), propertiesResponse.Value.ContentHash.ToList());
            Assert.AreEqual(1, propertiesResponse.Value.ContentEncoding.Count());
            Assert.AreEqual(constants.ContentEncoding, propertiesResponse.Value.ContentEncoding.First());
            Assert.AreEqual(1, propertiesResponse.Value.ContentLanguage.Count());
            Assert.AreEqual(constants.ContentLanguage, propertiesResponse.Value.ContentLanguage.First());
            Assert.AreEqual(constants.ContentDisposition, propertiesResponse.Value.ContentDisposition);
            Assert.AreEqual(constants.CacheControl, propertiesResponse.Value.CacheControl);
        }

        [RecordedTest]
        [TestCase(null)]
        [TestCase(FilePermissionFormat.Sddl)]
        [TestCase(FilePermissionFormat.Binary)]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2024_11_04)]
        public async Task SetHttpHeadersAsync_FilePermissionFormat(FilePermissionFormat? filePermissionFormat)
        {
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient file = test.File;

            string permission;
            if (filePermissionFormat == null || filePermissionFormat == FilePermissionFormat.Sddl)
            {
                permission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)S:NO_ACCESS_CONTROL";
            }
            else
            {
                permission = "AQAUhGwAAACIAAAAAAAAABQAAAACAFgAAwAAAAAAFAD/AR8AAQEAAAAAAAUSAAAAAAAYAP8BHwABAgAAAAAABSAAAAAgAgAAAAAkAKkAEgABBQAAAAAABRUAAABZUbgXZnJdJWRjOwuMmS4AAQUAAAAAAAUVAAAAoGXPfnhLm1/nfIdwr/1IAQEFAAAAAAAFFQAAAKBlz354S5tf53yHcAECAAA=";
            }

            ShareFileSetHttpHeadersOptions options = new ShareFileSetHttpHeadersOptions
            {
                FilePermission = new ShareFilePermission
                {
                    Permission = permission,
                    PermissionFormat = filePermissionFormat
                }
            };

            // Act
            Response<ShareFileInfo> response = await file.SetHttpHeadersAsync(options);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task SetHttpHeadersAsync_OAuth()
        {
            var constants = TestConstants.Create(this);

            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            ShareFileClient file = await directory.CreateFileAsync(GetNewFileName(), Constants.MB);
            ShareFileSetHttpHeadersOptions options = new ShareFileSetHttpHeadersOptions
            {
                HttpHeaders = new ShareFileHttpHeaders
                {
                    CacheControl = constants.CacheControl,
                    ContentDisposition = constants.ContentDisposition,
                    ContentEncoding = new string[] { constants.ContentEncoding },
                    ContentLanguage = new string[] { constants.ContentLanguage },
                    ContentHash = constants.ContentMD5,
                    ContentType = constants.ContentType
                }
            };

            // Act
            Response<ShareFileInfo> response = await file.SetHttpHeadersAsync(options);

            // Assert

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");

            // Ensure the correct values are set by calling GetProperties
            Response<ShareFileProperties> propertiesResponse = await file.GetPropertiesAsync();
            Assert.AreEqual(constants.ContentType, propertiesResponse.Value.ContentType);
            TestHelper.AssertSequenceEqual(constants.ContentMD5.ToList(), propertiesResponse.Value.ContentHash.ToList());
            Assert.AreEqual(1, propertiesResponse.Value.ContentEncoding.Count());
            Assert.AreEqual(constants.ContentEncoding, propertiesResponse.Value.ContentEncoding.First());
            Assert.AreEqual(1, propertiesResponse.Value.ContentLanguage.Count());
            Assert.AreEqual(constants.ContentLanguage, propertiesResponse.Value.ContentLanguage.First());
            Assert.AreEqual(constants.ContentDisposition, propertiesResponse.Value.ContentDisposition);
            Assert.AreEqual(constants.CacheControl, propertiesResponse.Value.CacheControl);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task SetHttpHeadersAsync_Lease()
        {
            var constants = TestConstants.Create(this);

            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient file = test.File;
            ShareFileLease fileLease = await InstrumentClient(file.GetShareLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync();
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = fileLease.LeaseId
            };

            ShareFileSetHttpHeadersOptions options = new ShareFileSetHttpHeadersOptions
            {
                HttpHeaders = new ShareFileHttpHeaders
                {
                    ContentType = constants.ContentType
                }
            };

            // Act
            await file.SetHttpHeadersAsync(
                options: options,
                conditions: conditions);

            // Assert
            Response<ShareFileProperties> response = await file.GetPropertiesAsync();
            Assert.AreEqual(constants.ContentType, response.Value.ContentType);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task SetHttpHeadersAsync_InvalidLease()
        {
            var constants = TestConstants.Create(this);

            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient file = test.File;
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = Recording.Random.NewGuid().ToString()
            };

            ShareFileSetHttpHeadersOptions options = new ShareFileSetHttpHeadersOptions
            {
                HttpHeaders = new ShareFileHttpHeaders
                {
                    ContentType = constants.ContentType
                }
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.SetHttpHeadersAsync(
                    options: options,
                    conditions: conditions),
                e => Assert.AreEqual("LeaseNotPresentWithFileOperation", e.ErrorCode));
        }

        [RecordedTest]
        public async Task SetPropertiesAsync_FilePermission()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(maxSize: Constants.KB);

            ShareFileSetHttpHeadersOptions options = new ShareFileSetHttpHeadersOptions
            {
                FilePermission = new ShareFilePermission
                {
                    Permission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)"
                }
            };

            // Act
            Response<ShareFileInfo> response = await file.SetHttpHeadersAsync(options);

            // Assert
            AssertValidStorageFileInfo(response);
        }

        [RecordedTest]
        public async Task SetPropertiesAsync_SmbProperties()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            string permission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
            ShareFilePermission filePermission = new ShareFilePermission()
            {
                Permission = permission,
            };
            Response<PermissionInfo> createPermissionResponse = await share.CreatePermissionAsync(filePermission);

            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            await directory.CreateIfNotExistsAsync();

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            ShareFileSetHttpHeadersOptions options = new ShareFileSetHttpHeadersOptions
            {
                SmbProperties = new FileSmbProperties
                {
                    FilePermissionKey = createPermissionResponse.Value.FilePermissionKey,
                    FileAttributes = ShareModelExtensions.ToFileAttributes("Archive|ReadOnly"),
                    FileCreatedOn = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero),
                    FileLastWrittenOn = new DateTimeOffset(2019, 8, 26, 5, 15, 25, 60, TimeSpan.Zero),
                }
            };

            await file.CreateAsync(maxSize: Constants.KB);

            // Act
            Response<ShareFileInfo> response = await file.SetHttpHeadersAsync(options);

            // Assert
            AssertValidStorageFileInfo(response);
            Assert.AreEqual(options?.SmbProperties.FileAttributes, response.Value.SmbProperties.FileAttributes);
            Assert.AreEqual(options?.SmbProperties.FileCreatedOn, response.Value.SmbProperties.FileCreatedOn);
            Assert.AreEqual(options?.SmbProperties.FileLastWrittenOn, response.Value.SmbProperties.FileLastWrittenOn);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_06_08)]
        public async Task SetPropertiesAsync_ChangeTime()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directoryClient = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
            await directoryClient.CreateIfNotExistsAsync();

            ShareFileClient fileClient = InstrumentClient(directoryClient.GetFileClient(GetNewFileName()));
            ShareFileSetHttpHeadersOptions options = new ShareFileSetHttpHeadersOptions
            {
                SmbProperties = new FileSmbProperties
                {
                    FileChangedOn = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero),
                }
            };

            await fileClient.CreateAsync(maxSize: Constants.KB);

            // Act
            Response<ShareFileInfo> response = await fileClient.SetHttpHeadersAsync(options);

            // Assert
            AssertValidStorageFileInfo(response);
            Assert.AreEqual(options.SmbProperties.FileChangedOn, response.Value.SmbProperties.FileChangedOn);
        }

        [RecordedTest]
        public async Task SetPropertiesAsync_FilePermissionTooLong()
        {
            var constants = TestConstants.Create(this);

            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(maxSize: Constants.KB);

            ShareFileSetHttpHeadersOptions options = new ShareFileSetHttpHeadersOptions
            {
                FilePermission = new ShareFilePermission
                {
                    Permission = new string('*', 9 * Constants.KB)
                }
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                file.SetHttpHeadersAsync(options),
                new ArgumentOutOfRangeException("filePermission", "Value must be less than or equal to 8192"));
        }

        [RecordedTest]
        public async Task SetPropertiesAsync_FilePermissionAndFilePermissionKeySet()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(maxSize: Constants.KB);

            ShareFileSetHttpHeadersOptions options = new ShareFileSetHttpHeadersOptions
            {
                FilePermission = new ShareFilePermission
                {
                    Permission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)"
                },
                SmbProperties = new FileSmbProperties
                {
                    FilePermissionKey = "filePermissionKey"
                }
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                file.SetHttpHeadersAsync(options),
                e => Assert.AreEqual("filePermission and filePermissionKey cannot both be set", e.Message));
        }

        [RecordedTest]
        public async Task SetPropertiesAsync_Error()
        {
            var constants = TestConstants.Create(this);
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            ShareFileSetHttpHeadersOptions options = new ShareFileSetHttpHeadersOptions
            {
                HttpHeaders = new ShareFileHttpHeaders
                {
                    CacheControl = constants.CacheControl,
                    ContentDisposition = constants.ContentDisposition,
                    ContentEncoding = new string[] { constants.ContentEncoding },
                    ContentLanguage = new string[] { constants.ContentLanguage },
                    ContentHash = constants.ContentMD5,
                    ContentType = constants.ContentType
                }
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.SetHttpHeadersAsync(options),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task SetHttpHeadersAsync_TrailingDot()
        {
            var constants = TestConstants.Create(this);
            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = true;
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync(options: options);
            ShareFileClient file = test.File;

            ShareFileSetHttpHeadersOptions setHttpHeadersOptions = new ShareFileSetHttpHeadersOptions
            {
                HttpHeaders = new ShareFileHttpHeaders
                {
                    CacheControl = constants.CacheControl,
                    ContentDisposition = constants.ContentDisposition,
                    ContentEncoding = new string[] { constants.ContentEncoding },
                    ContentLanguage = new string[] { constants.ContentLanguage },
                    ContentHash = constants.ContentMD5,
                    ContentType = constants.ContentType
                }
            };

            // Act
            Response<ShareFileInfo> response = await file.SetHttpHeadersAsync(setHttpHeadersOptions);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2025_05_05)]
        public async Task SetHttpHeadersAsync_NFS()
        {
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync(nfs: true);

            string owner = "345";
            string group = "123";
            string fileMode = "7777";

            ShareFileSetHttpHeadersOptions options = new ShareFileSetHttpHeadersOptions
            {
                PosixProperties = new FilePosixProperties
                {
                    Owner = owner,
                    Group = group,
                    FileMode = NfsFileMode.ParseOctalFileMode(fileMode)
                }
            };

            // Act
            Response<ShareFileInfo> response = await test.File.SetHttpHeadersAsync(options);

            // Assert
            Assert.AreEqual(owner, response.Value.PosixProperties.Owner);
            Assert.AreEqual(group, response.Value.PosixProperties.Group);
            Assert.AreEqual(fileMode, response.Value.PosixProperties.FileMode.ToOctalFileMode());
            Assert.AreEqual(1, response.Value.PosixProperties.LinkCount);

            Assert.IsNull(response.Value.SmbProperties.FileAttributes);
            Assert.IsNull(response.Value.SmbProperties.FilePermissionKey);
        }

        [RecordedTest]
        public async Task DeleteAsync()
        {
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient file = test.File;

            // Act
            Response response = await file.DeleteAsync();

            // Assert
            Assert.IsNotNull(response.Headers.RequestId);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task DeleteAsync_OAuth()
        {
            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            ShareFileClient file = await directory.CreateFileAsync(GetNewFileName(), Constants.MB);

            // Act
            Response response = await file.DeleteAsync();

            // Assert
            Assert.IsNotNull(response.Headers.RequestId);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task DeleteAsync_Lease()
        {
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
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

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task DeleteAsync_InvalidLease()
        {
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
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

        [RecordedTest]
        public async Task DeleteAsync_Error()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.DeleteAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task DeleteAsync_TrailingDot()
        {
            // Arrange
            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = true;
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync(options: options);
            ShareFileClient file = test.File;

            // Act
            Response response = await file.DeleteAsync();
        }

        [RecordedTest]
        public async Task StartCopyAsync()
        {
            // Arrange
            await using DisposingFile testSource = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient source = testSource.File;
            await using DisposingFile testDest = await SharesClientBuilder.GetTestFileAsync();
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
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task StartCopyAsync_OAuth()
        {
            // Arrange
            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            ShareFileClient source = await directory.CreateFileAsync(GetNewFileName(), Constants.KB);
            ShareFileClient dest = await directory.CreateFileAsync(GetNewFileName(), Constants.KB);

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
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task StartCopyAsync_IgnoreReadOnlyAndSetArchive()
        {
            // Arrange
            await using DisposingFile testSource = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient source = testSource.File;
            await using DisposingFile testDest = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient dest = testSource.File;

            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await source.UploadRangeAsync(
                    range: new HttpRange(0, Constants.KB),
                    content: stream);
            }

            ShareFileCopyOptions options = new ShareFileCopyOptions
            {
                IgnoreReadOnly = true,
                Archive = true,
            };

            // Act
            Response<ShareFileCopyInfo> response = await dest.StartCopyAsync(
                sourceUri: source.Uri,
                options: options);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task StartCopyAsync_FilePermission()
        {
            // Arrange
            await using DisposingFile testSource = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient source = testSource.File;
            await using DisposingFile testDest = await SharesClientBuilder.GetTestFileAsync();
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
                FileAttributes = ShareModelExtensions.ToFileAttributes("Archive|ReadOnly"),
                FileCreatedOn = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero),
                FileLastWrittenOn = new DateTimeOffset(2019, 8, 26, 5, 15, 25, 60, TimeSpan.Zero)
            };
            string filePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";

            ShareFileCopyOptions options = new ShareFileCopyOptions
            {
                SmbProperties = smbProperties,
                FilePermission = filePermission,
                FilePermissionCopyMode = PermissionCopyMode.Override
            };

            // Act
            await dest.StartCopyAsync(
                sourceUri: source.Uri,
                options: options);

            Response<ShareFileProperties> propertiesResponse = await dest.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(smbProperties.FileAttributes, propertiesResponse.Value.SmbProperties.FileAttributes);
            Assert.AreEqual(smbProperties.FileCreatedOn, propertiesResponse.Value.SmbProperties.FileCreatedOn);
            Assert.AreEqual(smbProperties.FileLastWrittenOn, propertiesResponse.Value.SmbProperties.FileLastWrittenOn);
        }

        [RecordedTest]
        [TestCase(null)]
        [TestCase(FilePermissionFormat.Sddl)]
        [TestCase(FilePermissionFormat.Binary)]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2025_01_05)]
        public async Task StartCopyAsync_FilePermission_Format(FilePermissionFormat? filePermissionFormat)
        {
            // Arrange
            await using DisposingFile testSource = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient source = testSource.File;
            await using DisposingFile testDest = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient dest = testSource.File;

            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await source.UploadRangeAsync(
                    writeType: ShareFileRangeWriteType.Update,
                    range: new HttpRange(0, Constants.KB),
                    content: stream);
            }
            string filePermission;
            if (filePermissionFormat == null || filePermissionFormat == FilePermissionFormat.Sddl)
            {
                filePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)S:NO_ACCESS_CONTROL";
            }
            else
            {
                filePermission = "AQAUhGwAAACIAAAAAAAAABQAAAACAFgAAwAAAAAAFAD/AR8AAQEAAAAAAAUSAAAAAAAYAP8BHwABAgAAAAAABSAAAAAgAgAAAAAkAKkAEgABBQAAAAAABRUAAABZUbgXZnJdJWRjOwuMmS4AAQUAAAAAAAUVAAAAoGXPfnhLm1/nfIdwr/1IAQEFAAAAAAAFFQAAAKBlz354S5tf53yHcAECAAA=";
            }

            ShareFileCopyOptions options = new ShareFileCopyOptions
            {
                FilePermission = filePermission,
                PermissionFormat = filePermissionFormat,
                FilePermissionCopyMode = PermissionCopyMode.Override
            };

            // Act
            await dest.StartCopyAsync(
                sourceUri: source.Uri,
                options: options);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_06_08)]
        public async Task StartCopyAsync_ChangeTime()
        {
            // Arrange
            await using DisposingFile testSource = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient source = testSource.File;
            await using DisposingFile testDest = await SharesClientBuilder.GetTestFileAsync();
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
                FileChangedOn = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero),
            };

            string filePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";

            ShareFileCopyOptions options = new ShareFileCopyOptions
            {
                SmbProperties = smbProperties,
                FilePermission = filePermission,
                FilePermissionCopyMode = PermissionCopyMode.Override
            };

            // Act
            await dest.StartCopyAsync(
                sourceUri: source.Uri,
                options: options);

            Response<ShareFileProperties> propertiesResponse = await dest.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(smbProperties.FileChangedOn, propertiesResponse.Value.SmbProperties.FileChangedOn);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task StartCopyAsync_CopySmbPropertiesFilePermissionKey()
        {
            // Arrange
            await using DisposingFile testSource = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient source = testSource.File;
            await using DisposingFile testDest = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient dest = testSource.File;

            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await source.UploadRangeAsync(
                    range: new HttpRange(0, Constants.KB),
                    content: stream);
            }

            string permission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
            ShareFilePermission filePermission = new ShareFilePermission()
            {
                Permission = permission,
            };
            Response<PermissionInfo> createPermissionResponse = await testSource.Share.CreatePermissionAsync(filePermission);

            FileSmbProperties smbProperties = new FileSmbProperties
            {
                FilePermissionKey = createPermissionResponse.Value.FilePermissionKey,
                FileAttributes = ShareModelExtensions.ToFileAttributes("Archive|ReadOnly"),
                FileCreatedOn = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero),
                FileLastWrittenOn = new DateTimeOffset(2019, 8, 26, 5, 15, 25, 60, TimeSpan.Zero)
            };

            ShareFileCopyOptions options = new ShareFileCopyOptions
            {
                SmbProperties = smbProperties,
                FilePermissionCopyMode = PermissionCopyMode.Override
            };

            // Act
            await dest.StartCopyAsync(
                sourceUri: source.Uri,
                options: options);

            Response<ShareFileProperties> propertiesResponse = await dest.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(smbProperties.FileAttributes, propertiesResponse.Value.SmbProperties.FileAttributes);
            Assert.AreEqual(smbProperties.FileCreatedOn, propertiesResponse.Value.SmbProperties.FileCreatedOn);
            Assert.AreEqual(smbProperties.FileLastWrittenOn, propertiesResponse.Value.SmbProperties.FileLastWrittenOn);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task StartCopyAsync_Lease()
        {
            // Arrange
            await using DisposingFile testSource = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient source = testSource.File;
            await using DisposingFile testDest = await SharesClientBuilder.GetTestFileAsync();
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

            ShareFileCopyOptions options = new ShareFileCopyOptions
            {
                Conditions = conditions
            };

            // Act
            Response<ShareFileCopyInfo> response = await dest.StartCopyAsync(
                sourceUri: source.Uri,
                options: options);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task StartCopyAsync_InvalidLease()
        {
            // Arrange
            await using DisposingFile testSource = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient source = testSource.File;
            await using DisposingFile testDest = await SharesClientBuilder.GetTestFileAsync();
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

            ShareFileCopyOptions options = new ShareFileCopyOptions
            {
                Conditions = conditions
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                dest.StartCopyAsync(
                    sourceUri: source.Uri,
                    options: options),
                e => Assert.AreEqual("LeaseNotPresentWithFileOperation", e.ErrorCode));
        }

        [RecordedTest]
        public async Task StartCopyAsync_Metata()
        {
            // Arrange
            await using DisposingFile testSource = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient source = testSource.File;
            await using DisposingFile testDest = await SharesClientBuilder.GetTestFileAsync();
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

            ShareFileCopyOptions options = new ShareFileCopyOptions
            {
                Metadata = metadata
            };

            // Act
            Response<ShareFileCopyInfo> copyResponse = await dest.StartCopyAsync(
                sourceUri: source.Uri,
                options: options);

            await WaitForCopy(dest);

            // Assert
            Response<ShareFileProperties> response = await dest.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
        }

        [RecordedTest]
        public async Task StartCopyAsync_NonAsciiSourceUri()
        {
            // Arrange
            await using DisposingFile testSource = await SharesClientBuilder.GetTestFileAsync(fileName: GetNewNonAsciiFileName());
            ShareFileClient source = testSource.File;
            await using DisposingFile testDest = await SharesClientBuilder.GetTestFileAsync();
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

        [RecordedTest]
        public async Task StartCopyAsync_Error()
        {
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient file = test.File;

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.StartCopyAsync(sourceUri: s_invalidUri),
                e => Assert.AreEqual("CannotVerifyCopySource", e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2024_08_04)]
        public async Task StartCopyAsync_SourceErrorAndStatusCode()
        {
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient srcFile = InstrumentClient(test.File.GetParentShareDirectoryClient().GetFileClient(GetNewFileName()));
            await srcFile.CreateAsync(maxSize: Constants.KB);
            ShareFileClient destFile = InstrumentClient(test.File.GetParentShareDirectoryClient().GetFileClient(GetNewFileName()));
            await destFile.CreateAsync(maxSize: Constants.KB);
            Uri sourceUri = srcFile.GenerateSasUri(ShareFileSasPermissions.Write, GetUtcNow().AddDays(1));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destFile.StartCopyAsync(sourceUri: sourceUri),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains("CopySourceStatusCode: 403"));
                    Assert.IsTrue(e.Message.Contains("CopySourceErrorCode: AuthorizationPermissionMismatch"));
                    Assert.IsTrue(e.Message.Contains("CopySourceErrorMessage: This request is not authorized to perform this operation using this permission."));
                });
        }

        [RecordedTest]
        public async Task StartCopyAsync_CopySourceFileCreatedOnError()
        {
            // Arrange
            await using DisposingFile testSource = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient source = testSource.File;
            await using DisposingFile testDest = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient dest = testDest.File;

            ShareFileCopyOptions options = new ShareFileCopyOptions
            {
                SmbPropertiesToCopy = CopyableFileSmbProperties.CreatedOn,
                SmbProperties = new FileSmbProperties
                {
                    FileCreatedOn = Recording.UtcNow
                }
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                dest.StartCopyAsync(
                    sourceUri: source.Uri,
                    options: options),
                e => Assert.AreEqual($"{nameof(ShareFileCopyOptions)}.{nameof(ShareFileCopyOptions.SmbProperties)}.{nameof(ShareFileCopyOptions.SmbProperties.FileCreatedOn)} and {nameof(ShareFileCopyOptions)}.{nameof(CopyableFileSmbProperties)}.{nameof(CopyableFileSmbProperties.CreatedOn)} cannot both be set.",
                e.Message));
        }

        [RecordedTest]
        public async Task StartCopyAsync_CopySourceFileLastWrittenOnError()
        {
            // Arrange
            await using DisposingFile testSource = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient source = testSource.File;
            await using DisposingFile testDest = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient dest = testDest.File;

            ShareFileCopyOptions options = new ShareFileCopyOptions
            {
                SmbPropertiesToCopy = CopyableFileSmbProperties.LastWrittenOn,
                SmbProperties = new FileSmbProperties
                {
                    FileLastWrittenOn = Recording.UtcNow
                }
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                dest.StartCopyAsync(
                    sourceUri: source.Uri,
                    options: options),
                e => Assert.AreEqual($"{nameof(ShareFileCopyOptions)}.{nameof(ShareFileCopyOptions.SmbProperties)}.{nameof(ShareFileCopyOptions.SmbProperties.FileLastWrittenOn)} and {nameof(ShareFileCopyOptions)}.{nameof(CopyableFileSmbProperties)}.{nameof(CopyableFileSmbProperties.LastWrittenOn)} cannot both be set.",
                e.Message));
        }

        [RecordedTest]
        public async Task StartCopyAsync_CopySourceFileChanagedOnError()
        {
            // Arrange
            await using DisposingFile testSource = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient source = testSource.File;
            await using DisposingFile testDest = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient dest = testDest.File;

            ShareFileCopyOptions options = new ShareFileCopyOptions
            {
                SmbPropertiesToCopy = CopyableFileSmbProperties.ChangedOn,
                SmbProperties = new FileSmbProperties
                {
                    FileChangedOn = Recording.UtcNow
                }
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                dest.StartCopyAsync(
                    sourceUri: source.Uri,
                    options: options),
                e => Assert.AreEqual($"{nameof(ShareFileCopyOptions)}.{nameof(ShareFileCopyOptions.SmbProperties)}.{nameof(ShareFileCopyOptions.SmbProperties.FileChangedOn)} and {nameof(ShareFileCopyOptions)}.{nameof(CopyableFileSmbProperties)}.{nameof(CopyableFileSmbProperties.ChangedOn)} cannot both be set.",
                e.Message));
        }

        [RecordedTest]
        public async Task StartCopyAsync_CopySourceFileAttributesError()
        {
            // Arrange
            await using DisposingFile testSource = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient source = testSource.File;
            await using DisposingFile testDest = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient dest = testDest.File;

            ShareFileCopyOptions options = new ShareFileCopyOptions
            {
                SmbPropertiesToCopy = CopyableFileSmbProperties.FileAttributes,
                SmbProperties = new FileSmbProperties
                {
                    FileAttributes = ShareModelExtensions.ToFileAttributes("Archive|ReadOnly")
                }
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                dest.StartCopyAsync(
                    sourceUri: source.Uri,
                    options: options),
                e => Assert.AreEqual($"{nameof(ShareFileCopyOptions)}.{nameof(ShareFileCopyOptions.SmbProperties)}.{nameof(ShareFileCopyOptions.SmbProperties.FileAttributes)} and {nameof(ShareFileCopyOptions)}.{nameof(CopyableFileSmbProperties)}.{nameof(CopyableFileSmbProperties.FileAttributes)} cannot both be set.",
                e.Message));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_06_08)]
        public async Task StartCopyAsync_CopySourceFileSmbPropertiesAll()
        {
            // Arrange
            await using DisposingFile testSource = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient source = testSource.File;
            await using DisposingFile testDest = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient dest = testDest.File;

            ShareFileCopyOptions options = new ShareFileCopyOptions
            {
                SmbPropertiesToCopy = CopyableFileSmbProperties.All
            };

            // Act
            await dest.StartCopyAsync(
                sourceUri: source.Uri,
                options: options);

            // Assert
            Response<ShareFileProperties> sourcePropertiesResponse = await source.GetPropertiesAsync();
            Response<ShareFileProperties> destPropertiesResponse = await dest.GetPropertiesAsync();

            Assert.AreEqual(
                sourcePropertiesResponse.Value.SmbProperties.FileCreatedOn,
                destPropertiesResponse.Value.SmbProperties.FileCreatedOn);

            Assert.AreEqual(
                sourcePropertiesResponse.Value.SmbProperties.FileLastWrittenOn,
                destPropertiesResponse.Value.SmbProperties.FileLastWrittenOn);

            Assert.AreEqual(
                sourcePropertiesResponse.Value.SmbProperties.FileAttributes,
                destPropertiesResponse.Value.SmbProperties.FileAttributes);

            Assert.AreEqual(
                sourcePropertiesResponse.Value.SmbProperties.FileChangedOn,
                destPropertiesResponse.Value.SmbProperties.FileChangedOn);
        }

        [RecordedTest]
        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task StartCopyAsync_TrailingDot(bool? sourceAllowTrailingDot)
        {
            // Arrange
            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = true;
            options.AllowSourceTrailingDot = sourceAllowTrailingDot;
            string sourceName = GetNewFileName() + ".";
            await using DisposingFile testSource = await SharesClientBuilder.GetTestFileAsync(fileName: sourceName, options: options);
            ShareFileClient source = testSource.File;
            string destName = GetNewFileName() + ".";
            await using DisposingFile testDest = await SharesClientBuilder.GetTestFileAsync(fileName: destName, options: options);
            ShareFileClient dest = testDest.File;

            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await source.UploadRangeAsync(
                    range: new HttpRange(0, Constants.KB),
                    content: stream);
            }

            if (sourceAllowTrailingDot == true)
            {
                await dest.StartCopyAsync(source.Uri);
            }
            else
            {
                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    dest.StartCopyAsync(source.Uri),
                    e => Assert.AreEqual(e.ErrorCode, "ResourceNotFound"));
            }
        }

        [RecordedTest]
        [TestCase(null)]
        [TestCase(ModeCopyMode.Source)]
        [TestCase(ModeCopyMode.Override)]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2025_05_05)]
        public async Task StartCopy_NFS(ModeCopyMode? modeAndOwnerCopyMode)
        {
            // Arrange
            await using DisposingFile source = await SharesClientBuilder.GetTestFileAsync(nfs: true);
            await using DisposingFile destination = await SharesClientBuilder.GetTestFileAsync(nfs: true);

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            await source.File.UploadRangeAsync(
                range: new HttpRange(0, Constants.KB),
                content: stream);

            await source.File.SetHttpHeadersAsync(new ShareFileSetHttpHeadersOptions
            {
                PosixProperties = new FilePosixProperties
                {
                    Owner = "999",
                    Group = "888",
                    FileMode = NfsFileMode.ParseOctalFileMode("0111")
                }
            });

            Response<ShareFileProperties> sourceProperties =  await source.File.GetPropertiesAsync();

            string owner;
            string group;
            NfsFileMode fileMode;

            ShareFileCopyOptions options = new ShareFileCopyOptions
            {
                PosixProperties = new FilePosixProperties()
            };

            if (modeAndOwnerCopyMode == ModeCopyMode.Override)
            {
                owner = "54321";
                group = "12345";
                fileMode = NfsFileMode.ParseOctalFileMode("7777");
                options.ModeCopyMode = ModeCopyMode.Override;
                options.OwnerCopyMode = OwnerCopyMode.Override;
                options.PosixProperties.Owner = owner;
                options.PosixProperties.Group = group;
                options.PosixProperties.FileMode = fileMode;
            }
            else if (modeAndOwnerCopyMode == ModeCopyMode.Source)
            {
                options.ModeCopyMode = ModeCopyMode.Source;
                options.OwnerCopyMode = OwnerCopyMode.Source;
                owner = sourceProperties.Value.PosixProperties.Owner;
                fileMode = sourceProperties.Value.PosixProperties.FileMode;
                group = sourceProperties.Value.PosixProperties.Group;
            }
            else
            {
                owner = "0";
                group = "0";
                fileMode = NfsFileMode.ParseOctalFileMode("0664");
            }

            // Act
            await destination.File.StartCopyAsync(source.File.Uri, options);
            Response<ShareFileProperties> destinationProperties = await destination.File.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(owner, destinationProperties.Value.PosixProperties.Owner);
            Assert.AreEqual(group, destinationProperties.Value.PosixProperties.Group);
            Assert.AreEqual(fileMode.ToOctalFileMode(), destinationProperties.Value.PosixProperties.FileMode.ToOctalFileMode());
        }

        [RecordedTest]
        public async Task AbortCopyAsync()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task AbortCopyAsync_OAuth()
        {
            // Arrange
            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await directory.CreateAsync();

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

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task AbortCopyAsync_Lease()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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

            ShareFileCopyOptions options = new ShareFileCopyOptions
            {
                Conditions = conditions
            };

            Response<ShareFileCopyInfo> copyResponse = await dest.StartCopyAsync(
                sourceUri: source.Uri,
                options: options);

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

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task AbortCopyAsync_InvalidLease()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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

        [RecordedTest]
        public async Task AbortCopyAsync_Error()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(maxSize: Constants.MB);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.AbortCopyAsync("id"),
                e => Assert.AreEqual("InvalidQueryParameterValue", e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task AbortCopyAsync_TrailingDot()
        {
            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = true;
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync(options: options);
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

            ShareFileClient dest = InstrumentClient(directory.GetFileClient(GetNewFileName() + "."));
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

        [RecordedTest]
        public void WithSnapshot()
        {
            var shareName = GetNewShareName();
            var directoryName = GetNewDirectoryName();
            var fileName = GetNewFileName();

            ShareServiceClient service = SharesClientBuilder.GetServiceClient_SharedKey();

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

        [RecordedTest]
        public async Task DownloadAsync()
        {
            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient file = test.File;

            using (var stream = new MemoryStream(data))
            {
                await file.UploadRangeAsync(
                    range: new HttpRange(Constants.KB, data.LongLength),
                    content: stream);

                // Act
                Response<ShareFileProperties> getPropertiesResponse = await file.GetPropertiesAsync();

                Response<ShareFileDownloadInfo> downloadResponse = await file.DownloadAsync(new ShareFileDownloadOptions
                {
                    Range = new HttpRange(Constants.KB, data.LongLength)
                });

                // Assert

                // Content is equal
                Assert.AreEqual(data.Length, downloadResponse.Value.ContentLength);
                var actual = new MemoryStream();
                await downloadResponse.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
                // Ensure that we grab the whole ETag value from the service without removing the quotes
                Assert.AreEqual(downloadResponse.Value.Details.ETag.ToString(), $"\"{downloadResponse.GetRawResponse().Headers.ETag}\"");

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

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task DownloadAsync_OAuth()
        {
            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            ShareFileClient file = await directory.CreateFileAsync(GetNewFileName(), Constants.MB);

            using (var stream = new MemoryStream(data))
            {
                await file.UploadRangeAsync(
                    range: new HttpRange(Constants.KB, data.LongLength),
                    content: stream);

                // Act
                Response<ShareFileProperties> getPropertiesResponse = await file.GetPropertiesAsync();

                ShareFileDownloadOptions options = new ShareFileDownloadOptions
                {
                    Range = new HttpRange(Constants.KB, data.LongLength)
                };

                Response<ShareFileDownloadInfo> downloadResponse = await file.DownloadAsync(options);

                // Assert

                // Content is equal
                Assert.AreEqual(data.Length, downloadResponse.Value.ContentLength);
                var actual = new MemoryStream();
                await downloadResponse.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
                // Ensure that we grab the whole ETag value from the service without removing the quotes
                Assert.AreEqual(downloadResponse.Value.Details.ETag.ToString(), $"\"{downloadResponse.GetRawResponse().Headers.ETag}\"");

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

        [RecordedTest]
        public async Task DownloadAsync_ZeroFile()
        {
            // Arrange
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
            var fileName = GetNewFileName();
            var file = test.Directory.GetFileClient(fileName);
            await file.CreateAsync(0);

            // Act
            Response<ShareFileDownloadInfo> downloadResponse = await file.DownloadAsync();
            using var targetStream = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(targetStream);

            // Assert
            Assert.AreEqual(0, downloadResponse.Value.ContentLength);
            Assert.AreEqual(0, targetStream.Length);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task DownloadAsync_NoLease()
        {
            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient file = test.File;

            using (var stream = new MemoryStream(data))
            {
                await file.UploadRangeAsync(
                    writeType: ShareFileRangeWriteType.Update,
                    range: new HttpRange(Constants.KB, data.LongLength),
                    content: stream);

                await InstrumentClient(file.GetShareLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync();

                // Act
                Response<ShareFileDownloadInfo> downloadResponse = await file.DownloadAsync(new ShareFileDownloadOptions
                {
                    Range = new HttpRange(Constants.KB, data.LongLength)
                });

                // Assert
                Assert.IsNotNull(downloadResponse.Value.Details.ETag);
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task DownloadAsync_Lease()
        {
            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
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
                Response<ShareFileDownloadInfo> downloadResponse = await file.DownloadAsync(new ShareFileDownloadOptions
                {
                    Range = new HttpRange(Constants.KB, data.LongLength),
                    Conditions = conditions
                });

                // Assert
                Assert.AreEqual(ShareLeaseDuration.Infinite, downloadResponse.Value.Details.LeaseDuration);
                Assert.AreEqual(ShareLeaseState.Leased, downloadResponse.Value.Details.LeaseState);
                Assert.AreEqual(ShareLeaseStatus.Locked, downloadResponse.Value.Details.LeaseStatus);
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task DownloadAsync_InvalidLease()
        {
            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
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
                    file.DownloadAsync(new ShareFileDownloadOptions
                    {
                        Range = new HttpRange(Constants.KB, data.LongLength),
                        Conditions = conditions
                    }),
                    e => Assert.AreEqual("LeaseNotPresentWithFileOperation", e.ErrorCode));
            }
        }

        [RecordedTest]
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
            Response<ShareFileDownloadInfo> downloadResponse = await fileFaulty.DownloadAsync(new ShareFileDownloadOptions
            {
                Range = new HttpRange(offset, data.LongLength)
            });
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual, 128 * Constants.KB);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/45377")]
        [RecordedTest]
        public async Task DownloadAsync_WithUnreliableConnection_ConcurrentModification()
        {
            var fileSize = 2 * Constants.MB;
            var dataSize = 2 * Constants.MB;

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
            var modifiedData = GetRandomBuffer(dataSize);
            await fileFaulty.UploadAsync(new MemoryStream(data));

            // Act
            using ShareFileDownloadInfo downloadInfo = await fileFaulty.DownloadAsync();

            // Modify content after we got response but haven't read data stream yet.
            // The faulty stream will simulate service side closing connection.
            await fileFaulty.UploadAsync(new MemoryStream(modifiedData));

            // Read data stream
            var actual = new MemoryStream();
            await TestHelper.AssertExpectedExceptionAsync<ShareFileModifiedException>(
                downloadInfo.Content.CopyToAsync(actual, 4 * Constants.KB),
                e => {
                    Assert.AreEqual(e.ResourceUri, file.Uri);
                    Assert.AreNotEqual(e.ExpectedETag, e.ActualETag);
                    Assert.IsNotNull(e.Range);
                });
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task DownloadAsync_TrailingDot()
        {
            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = true;
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync(options: options);
            ShareFileClient file = test.File;

            using (var stream = new MemoryStream(data))
            {
                await file.UploadRangeAsync(
                    range: new HttpRange(Constants.KB, data.LongLength),
                    content: stream);

                // Act
                Response<ShareFileDownloadInfo> downloadResponse = await file.DownloadAsync(new ShareFileDownloadOptions
                {
                    Range = new HttpRange(Constants.KB, data.LongLength)
                });

                // Assert

                // Content is equal
                Assert.AreEqual(data.Length, downloadResponse.Value.ContentLength);
                var actual = new MemoryStream();
                await downloadResponse.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2025_05_05)]
        public async Task DownloadAsync_NFS()
        {
            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync(nfs: true);
            ShareFileClient file = test.File;

            using Stream stream = new MemoryStream(data);
            await file.UploadRangeAsync(
                range: new HttpRange(0, Constants.KB),
                content: stream);

            // Act
            Response<ShareFileDownloadInfo> response = await file.DownloadAsync(new ShareFileDownloadOptions
            {
                Range = new HttpRange(0, Constants.KB)
            });

            // Assert
            Assert.AreEqual("0", response.Value.Details.PosixProperties.Owner);
            Assert.AreEqual("0", response.Value.Details.PosixProperties.Group);
            Assert.AreEqual("0664", response.Value.Details.PosixProperties.FileMode.ToOctalFileMode());
            Assert.AreEqual(1, response.Value.Details.PosixProperties.LinkCount);

            Assert.IsNull(response.Value.Details.SmbProperties.FileAttributes);
            Assert.IsNull(response.Value.Details.SmbProperties.FilePermissionKey);
        }

        [RecordedTest]
        public async Task GetRangeListAsync()
        {
            // Arrange
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient file = test.File;

            // Act
            Response<ShareFileRangeInfo> response = await file.GetRangeListAsync(range: new HttpRange(0, Constants.MB));

            // Assert

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");
            Assert.IsNotNull(response.Value.LastModified);
            Assert.IsTrue(response.Value.FileContentLength > 0);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task GetRangeListAsync_OAuth()
        {
            // Arrange
            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            ShareFileClient file = await directory.CreateFileAsync(GetNewFileName(), Constants.MB);

            // Act
            Response<ShareFileRangeInfo> response = await file.GetRangeListAsync(range: new HttpRange(0, Constants.MB));

            // Assert

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");
            Assert.IsNotNull(response.Value.LastModified);
            Assert.IsTrue(response.Value.FileContentLength > 0);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task GetRangeListAsync_NoLease()
        {
            // Arrange
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
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

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task GetRangeListAsync_Lease()
        {
            // Arrange
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
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

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task GetRangeListAsync_InvalidLease()
        {
            // Arrange
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
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

        [RecordedTest]
        public async Task GetRangeListAsync_Error()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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

        [RecordedTest]
        public async Task GetRangeListAsync_NoRange()
        {
            // Arrange
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
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

        [RecordedTest]
        public async Task GetRangeListAsync_Snapshot()
        {
            // Arrange
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
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

        [RecordedTest]
        public async Task GetRangeListAsync_SnapshotFailed()
        {
            // Arrange
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
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

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task GetRangeListAsync_TrailingDot()
        {
            // Arrange
            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = true;
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync(options: options);
            ShareFileClient file = test.File;

            // Act
            Response<ShareFileRangeInfo> response = await file.GetRangeListAsync(range: new HttpRange(0, Constants.MB));

            // Assert

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");
            Assert.IsNotNull(response.Value.LastModified);
            Assert.IsTrue(response.Value.FileContentLength > 0);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2020_02_10)]
        public async Task GetRangeListDiffAsync()
        {
            // Arrange
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
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
            Response<ShareFileUploadInfo> response = await file.ClearRangeAsync(range3);

            Response<ShareSnapshotInfo> snapshotResponse1 = await test.Share.CreateSnapshotAsync();

            ShareFileGetRangeListDiffOptions options = new ShareFileGetRangeListDiffOptions
            {
                Snapshot = snapshotResponse1.Value.Snapshot,
                PreviousSnapshot = snapshotResponse0.Value.Snapshot
            };

            // Act
            Response<ShareFileRangeInfo> rangeListResponse = await file.GetRangeListDiffAsync(options);

            // Assert
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");

            // Ensure the ranges list is correct after the clear call by doing a GetRangeListDiff call
            Assert.AreEqual(1, rangeListResponse.Value.Ranges.Count());
            Assert.AreEqual(range2, rangeListResponse.Value.Ranges.First());
            Assert.AreEqual(1, rangeListResponse.Value.ClearRanges.Count());
            Assert.AreEqual(range3, rangeListResponse.Value.ClearRanges.First());
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2024_05_04)]
        [TestCase(null)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetRangeListDiffWithRenameAsync(bool? renameSupport)
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            string destFileName = GetNewFileName();
            ShareFileClient sourceFile = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await sourceFile.CreateAsync(Constants.MB);

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            HttpRange range = new HttpRange(Constants.KB, Constants.KB);
            await sourceFile.UploadRangeAsync(
                   range: range,
                   content: stream);

            Response<ShareSnapshotInfo> snapshotResponse0 = await test.Share.CreateSnapshotAsync();

            stream.Position = 0;
            HttpRange range2 = new HttpRange(3 * Constants.KB, Constants.KB);
            await sourceFile.UploadRangeAsync(
                   range: range2,
                   content: stream);

            HttpRange range3 = new HttpRange(0, 512);
            Response<ShareFileUploadInfo> response = await sourceFile.ClearRangeAsync(range3);

            // rename file after first snapshot
            ShareFileClient destFile = await sourceFile.RenameAsync(destinationPath: test.Directory.Name + "/" + destFileName);

            // take another share snapshot
            Response<ShareSnapshotInfo> snapshotResponse1 = await test.Share.CreateSnapshotAsync();

            ShareFileGetRangeListDiffOptions options = new ShareFileGetRangeListDiffOptions
            {
                Snapshot = snapshotResponse1.Value.Snapshot,
                PreviousSnapshot = snapshotResponse0.Value.Snapshot,
                IncludeRenames = renameSupport
            };

            try
            {
                if (renameSupport == true)
                {
                    // Act - renamed file range diff
                    Response<ShareFileRangeInfo> rangeListResponse = await destFile.GetRangeListDiffAsync(options);
                    // Assert
                    // Ensure that we grab the whole ETag value from the service without removing the quotes
                    Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");

                    // Ensure the ranges list is correct after the clear call by doing a GetRangeListDiff call
                    Assert.AreEqual(1, rangeListResponse.Value.Ranges.Count());
                    Assert.AreEqual(range2, rangeListResponse.Value.Ranges.First());
                    Assert.AreEqual(1, rangeListResponse.Value.ClearRanges.Count());
                    Assert.AreEqual(range3, rangeListResponse.Value.ClearRanges.First());
                }
                else
                {
                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        destFile.GetRangeListDiffAsync(options),
                        e => Assert.AreEqual(ShareErrorCode.PreviousSnapshotNotFound.ToString(), e.ErrorCode));
                }
            }
            finally
            {
                await destFile.DeleteAsync();
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task GetRangeListDiffAsync_OAuth()
        {
            // Arrange
            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            ShareFileClient file = await directory.CreateFileAsync(GetNewFileName(), Constants.MB);

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            HttpRange range = new HttpRange(Constants.KB, Constants.KB);
            await file.UploadRangeAsync(
                   range: range,
                   content: stream);

            Response<ShareSnapshotInfo> snapshotResponse0 = await sharedKeyShare.Share.CreateSnapshotAsync();

            stream.Position = 0;
            HttpRange range2 = new HttpRange(3 * Constants.KB, Constants.KB);
            await file.UploadRangeAsync(
                   range: range2,
                   content: stream);

            HttpRange range3 = new HttpRange(0, 512);
            Response<ShareFileUploadInfo> response = await file.ClearRangeAsync(range3);

            Response<ShareSnapshotInfo> snapshotResponse1 = await sharedKeyShare.Share.CreateSnapshotAsync();

            ShareFileGetRangeListDiffOptions options = new ShareFileGetRangeListDiffOptions
            {
                Snapshot = snapshotResponse1.Value.Snapshot,
                PreviousSnapshot = snapshotResponse0.Value.Snapshot
            };

            // Act
            Response<ShareFileRangeInfo> rangeListResponse = await file.GetRangeListDiffAsync(options);

            // Assert
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");

            // Ensure the ranges list is correct after the clear call by doing a GetRangeListDiff call
            Assert.AreEqual(1, rangeListResponse.Value.Ranges.Count());
            Assert.AreEqual(range2, rangeListResponse.Value.Ranges.First());
            Assert.AreEqual(1, rangeListResponse.Value.ClearRanges.Count());
            Assert.AreEqual(range3, rangeListResponse.Value.ClearRanges.First());
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2020_02_10)]
        public async Task GetRangeListDiffAsync_Error()
        {
            // Arrange
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
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

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2020_02_10)]
        public async Task GetRangeListDiffAsync_Lease()
        {
            // Arrange
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
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

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2020_02_10)]
        public async Task GetRangeListDiffAsync_InvalidLease()
        {
            // Arrange
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
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

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task GetRangeListDiffAsync_TrailingDot()
        {
            // Arrange
            ShareClientOptions shareClientOptions = GetOptions();
            shareClientOptions.AllowTrailingDot = true;
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync(options: shareClientOptions);
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
            Response<ShareFileUploadInfo> response = await file.ClearRangeAsync(range3);

            Response<ShareSnapshotInfo> snapshotResponse1 = await test.Share.CreateSnapshotAsync();

            ShareFileGetRangeListDiffOptions options = new ShareFileGetRangeListDiffOptions
            {
                Snapshot = snapshotResponse1.Value.Snapshot,
                PreviousSnapshot = snapshotResponse0.Value.Snapshot
            };

            // Act
            Response<ShareFileRangeInfo> rangeListResponse = await file.GetRangeListDiffAsync(options);

            // Assert
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");

            // Ensure the ranges list is correct after the clear call by doing a GetRangeListDiff call
            Assert.AreEqual(1, rangeListResponse.Value.Ranges.Count());
            Assert.AreEqual(range2, rangeListResponse.Value.Ranges.First());
            Assert.AreEqual(1, rangeListResponse.Value.ClearRanges.Count());
            Assert.AreEqual(range3, rangeListResponse.Value.ClearRanges.First());
        }

        [RecordedTest]
        public async Task UploadRangeAsync()
        {
            var data = GetRandomBuffer(Constants.KB);

            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient file = test.File;

            using (var stream = new MemoryStream(data))
            {
                Response<ShareFileUploadInfo> response = await file.UploadRangeAsync(
                    writeType: ShareFileRangeWriteType.Update,
                    range: new HttpRange(Constants.KB, Constants.KB),
                    content: stream);

                Assert.AreNotEqual(new ETag(""), response.Value.ETag);
                Assert.AreNotEqual(DateTimeOffset.MinValue, response.Value.LastModified);
                Assert.IsNotNull(response.Value.ContentHash);
                Assert.IsTrue(response.Value.IsServerEncrypted);
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_06_08)]
        [TestCase(null)]
        [TestCase(FileLastWrittenMode.Now)]
        [TestCase(FileLastWrittenMode.Preserve)]
        public async Task UploadRangeAsync_PreserveFileLastWrittenOn(FileLastWrittenMode fileLastWrittenMode)
        {
            // Arrange
            byte[] data = GetRandomBuffer(Constants.KB);

            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient fileClient = test.File;

            Response<ShareFileProperties> initalPropertiesResponse = await fileClient.GetPropertiesAsync();

            using Stream stream = new MemoryStream(data);
            ShareFileUploadRangeOptions options = new ShareFileUploadRangeOptions
            {
                FileLastWrittenMode = fileLastWrittenMode
            };

            // Act
            await fileClient.UploadRangeAsync(
                range: new HttpRange(Constants.KB, Constants.KB),
                content: stream,
                options: options);

            // Assert
            Response<ShareFileProperties> propertiesResponse = await fileClient.GetPropertiesAsync();

            if (fileLastWrittenMode == FileLastWrittenMode.Preserve)
            {
                Assert.AreEqual(
                    initalPropertiesResponse.Value.SmbProperties.FileLastWrittenOn,
                    propertiesResponse.Value.SmbProperties.FileLastWrittenOn);
            }
            else
            {
                Assert.AreNotEqual(
                    initalPropertiesResponse.Value.SmbProperties.FileLastWrittenOn,
                    propertiesResponse.Value.SmbProperties.FileLastWrittenOn);
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task UploadRangeAsync_OAuth()
        {
            var data = GetRandomBuffer(Constants.KB);

            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            ShareFileClient file = await directory.CreateFileAsync(GetNewFileName(), Constants.MB);

            using (var stream = new MemoryStream(data))
            {
                Response<ShareFileUploadInfo> response = await file.UploadRangeAsync(
                    writeType: ShareFileRangeWriteType.Update,
                    range: new HttpRange(Constants.KB, Constants.KB),
                    content: stream);

                Assert.AreNotEqual(new ETag(""), response.Value.ETag);
                Assert.AreNotEqual(DateTimeOffset.MinValue, response.Value.LastModified);
                Assert.IsNotNull(response.Value.ContentHash);
                Assert.IsTrue(response.Value.IsServerEncrypted);
            }
        }

        [RecordedTest]
        public async Task UploadRangeAsync_MD5()
        {
            // Arrange
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient fileClient = test.File;
            byte[] data = GetRandomBuffer(Constants.KB);
            Stream stream = new MemoryStream(data);

            byte[] md5 = MD5.Create().ComputeHash(data);

            ShareFileUploadRangeOptions options = new ShareFileUploadRangeOptions
            {
                TransactionalContentHash = md5
            };

            // Act
            Response<ShareFileUploadInfo> response = await fileClient.UploadRangeAsync(
                range: new HttpRange(0, Constants.KB),
                content: stream,
                options: options);

            // Assert
            Assert.AreEqual(md5, response.Value.ContentHash);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task UploadRangeAsync_Lease()
        {
            var data = GetRandomBuffer(Constants.KB);

            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient file = test.File;
            ShareFileLease fileLease = await InstrumentClient(file.GetShareLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync();
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = fileLease.LeaseId
            };

            ShareFileUploadRangeOptions options = new ShareFileUploadRangeOptions
            {
                Conditions = conditions
            };

            using (var stream = new MemoryStream(data))
            {
                Response<ShareFileUploadInfo> response = await file.UploadRangeAsync(
                    range: new HttpRange(Constants.KB, Constants.KB),
                    content: stream,
                    options: options);

                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task UploadRangeAsync_InvalidLease()
        {
            var data = GetRandomBuffer(Constants.KB);

            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient file = test.File;
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = Recording.Random.NewGuid().ToString()
            };

            ShareFileUploadRangeOptions options = new ShareFileUploadRangeOptions
            {
                Conditions = conditions
            };

            using (var stream = new MemoryStream(data))
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    file.UploadRangeAsync(
                        range: new HttpRange(Constants.KB, Constants.KB),
                        content: stream,
                        options: options),
                    e => Assert.AreEqual("LeaseNotPresentWithFileOperation", e.ErrorCode));
            }
        }

        [RecordedTest]
        public async Task UploadRangeAsync_Error()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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

        [RecordedTest]
        public async Task UploadRangeAsync_InvalidStreamPosition()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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

        [RecordedTest]
        public async Task UploadRangeAsync_NonZeroStreamPosition()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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

        [RecordedTest]
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

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task UploadRangeAsync_TrailingDot()
        {
            // Arrange
            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = true;
            var data = GetRandomBuffer(Constants.KB);

            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync(options: options);
            ShareFileClient file = test.File;

            using (var stream = new MemoryStream(data))
            {
                // Act
                Response<ShareFileUploadInfo> response = await file.UploadRangeAsync(
                    writeType: ShareFileRangeWriteType.Update,
                    range: new HttpRange(Constants.KB, Constants.KB),
                    content: stream);
            }
        }

        [RecordedTest]
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

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task UploadAsync_OAuth()
        {
            const int size = 10 * Constants.KB;
            var data = this.GetRandomBuffer(size);

            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await directory.CreateAsync();
            ShareFileClient file = await directory.CreateFileAsync(GetNewFileName(), size);

            await file.CreateAsync(size);
            using var stream = new MemoryStream(data);
            await file.UploadAsync(stream);

            using var bufferedContent = new MemoryStream();
            var download = await file.DownloadAsync();
            await download.Value.Content.CopyToAsync(bufferedContent);
            TestHelper.AssertSequenceEqual(data, bufferedContent.ToArray());
        }

        [RecordedTest]
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
                stream,
                new ShareFileUploadOptions
                {
                    Conditions = conditions
                });

            using var bufferedContent = new MemoryStream();
            var download = await file.DownloadAsync();
            await download.Value.Content.CopyToAsync(bufferedContent);
            TestHelper.AssertSequenceEqual(data, bufferedContent.ToArray());
        }

        [RecordedTest]
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
                file.UploadAsync(stream,
                new ShareFileUploadOptions
                {
                    Conditions = conditions
                }),
                e => Assert.AreEqual("LeaseNotPresentWithFileOperation", e.ErrorCode));
        }

        [RecordedTest]
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

        [RecordedTest]
        public async Task UploadAsync_Stream_InvalidStreamPosition()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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
                stream),
                e => Assert.AreEqual("content.Position must be less than content.Length. Please set content.Position to the start of the data to upload.", e.Message));
        }

        [RecordedTest]
        public async Task UploadAsync_NonZeroStreamPosition()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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

        [RecordedTest]
        public async Task UploadAsync_NonZeroStreamPositionMultipleBlocks()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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
                transferValidationOverride: default,
                new StorageTransferOptions
                {
                    InitialTransferSize = 512,
                    MaximumTransferSize = 512
                },
                async: IsAsync,
                cancellationToken: CancellationToken.None);

            // Assert
            Response<ShareFileDownloadInfo> response = await file.DownloadAsync();

            var actualData = new byte[size - position];
            using var actualStream = new MemoryStream(actualData);
            await response.Value.Content.CopyToAsync(actualStream);
            TestHelper.AssertSequenceEqual(expectedData, actualData);
        }

        [Test]
        public void UploadAsync_ThrowOnConcurrency()
        {
            byte[] data = new byte[Constants.KB];
            // test doesn't hit wire, don't record random
            new Random().NextBytes(data);

            Assert.ThrowsAsync<ArgumentOutOfRangeException>(
                async () => await new ShareFileClient(new Uri("https://www.example.com"))
                    .UploadAsync(new MemoryStream(data), new ShareFileUploadOptions
                    {
                        TransferOptions = new StorageTransferOptions
                        {
                            MaximumConcurrency = 2
                        }
                    })
            );
        }

        public async Task ClearRangeAsync()
        {
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient file = test.File;

            Response<ShareFileUploadInfo> response = await file.ClearRangeAsync(
                range: new HttpRange(Constants.KB, Constants.KB));

            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task ClearRangeAsync_OAuth()
        {
            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            ShareFileClient file = await directory.CreateFileAsync(GetNewFileName(), Constants.MB);

            Response<ShareFileUploadInfo> response = await file.ClearRangeAsync(
                range: new HttpRange(Constants.KB, Constants.KB));

            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [RecordedTest]
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

        [RecordedTest]
        public async Task ClearRangeAsync_Error()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.ClearRangeAsync(
                    range: new HttpRange(Constants.KB, Constants.KB)),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task ClearRangeAsync_TrailingDot()
        {
            // Arrange
            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = true;
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync(options: options);
            ShareFileClient file = test.File;

            // Act
            Response<ShareFileUploadInfo> response = await file.ClearRangeAsync(
                range: new HttpRange(Constants.KB, Constants.KB));
        }

        [RecordedTest]
        [TestCase(512)]
        [TestCase(1 * Constants.KB)]
        [TestCase(2 * Constants.KB)]
        [TestCase(4 * Constants.KB)]
        [TestCase(10 * Constants.KB)]
        [TestCase(20 * Constants.KB)]
        [TestCase(30 * Constants.KB)]
        [TestCase(50 * Constants.KB)]
        [TestCase(501 * Constants.KB)]
        public async Task UploadAsync_SmallShares(int size) =>
             // Use a 1KB threshold so we get a lot of individual blocks
             await UploadAndVerify(size, Constants.KB);

        [Test]
        [LiveOnly]
        [TestCase(33 * Constants.MB)]
        [TestCase(257 * Constants.MB)]
        [TestCase(1 * Constants.GB)]
        [Explicit("https://github.com/Azure/azure-sdk-for-net/issues/9120")]
        public async Task UploadAsync_LargeShares(int size) =>
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
                    transferValidationOverride: default,
                    new StorageTransferOptions
                    {
                        InitialTransferSize = singleRangeThreshold,
                        MaximumTransferSize = singleRangeThreshold
                    },
                    async: true,
                    cancellationToken: CancellationToken.None);
            }

            using var bufferedContent = new MemoryStream();
            Response<ShareFileDownloadInfo> download = await file.DownloadAsync();
            await download.Value.Content.CopyToAsync(bufferedContent);
            TestHelper.AssertSequenceEqual(data, bufferedContent.ToArray());
        }

        [RecordedTest]
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

            ShareFileUploadRangeOptions options = new ShareFileUploadRangeOptions
            {
                ProgressHandler = progressHandler
            };

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
                    options: options);

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
            Response<ShareFileDownloadInfo> downloadResponse = await file.DownloadAsync(new ShareFileDownloadOptions
            {
                Range = new HttpRange(offset, data.LongLength)
            });
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
            Assert.AreNotEqual(0, timesFaulted);
        }

        [Test]
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
            Response<ShareFileUploadInfo> response =  await destFile.UploadRangeFromUriAsync(
                sourceUri: sasFile.Uri,
                range: destRange,
                sourceRange: sourceRange);

            // Assert
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");

            // Ensure the contents of the source and destination Files after the UploadRangeFromUri call
            var sourceDownloadResponse = await sourceFile.DownloadAsync(new ShareFileDownloadOptions
            {
                Range = sourceRange
            });
            var destDownloadResponse = await destFile.DownloadAsync(new ShareFileDownloadOptions
            {
                Range = destRange
            });

            var sourceStream = new MemoryStream();
            await sourceDownloadResponse.Value.Content.CopyToAsync(sourceStream);

            var destStream = new MemoryStream();
            await destDownloadResponse.Value.Content.CopyToAsync(destStream);

            TestHelper.AssertSequenceEqual(sourceStream.ToArray(), destStream.ToArray());
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
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

            ShareFileUploadRangeFromUriOptions options = new ShareFileUploadRangeFromUriOptions
            {
                Conditions = conditions
            };

            // Act
            await destFile.UploadRangeFromUriAsync(
                sourceUri: sasFile.Uri,
                range: destRange,
                sourceRange: sourceRange,
                options: options);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
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

            ShareFileUploadRangeFromUriOptions options = new ShareFileUploadRangeFromUriOptions
            {
                Conditions = conditions
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destFile.UploadRangeFromUriAsync(
                    sourceUri: sasFile.Uri,
                    range: destRange,
                    sourceRange: sourceRange,
                    options: options),
                e => Assert.AreEqual("LeaseNotPresentWithFileOperation", e.ErrorCode));
        }

        [Test]
        [LiveOnly]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/9085")]
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
            var sourceDownloadResponse = await sourceFile.DownloadAsync(new ShareFileDownloadOptions
            {
                Range = sourceRange
            });

            var destDownloadResponse = await destFile.DownloadAsync(new ShareFileDownloadOptions
            {
                Range = destRange
            });

            var sourceStream = new MemoryStream();
            await sourceDownloadResponse.Value.Content.CopyToAsync(sourceStream);

            var destStream = new MemoryStream();
            await destDownloadResponse.Value.Content.CopyToAsync(destStream);

            TestHelper.AssertSequenceEqual(sourceStream.ToArray(), destStream.ToArray());
        }

        [RecordedTest]
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

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2024_08_04)]
        public async Task UploadRangeFromUriAsync_SourceErrorAndStatusCode()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync(shareName: GetNewShareName());
            ShareClient share = test.Share;

            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            await directory.CreateIfNotExistsAsync();

            ShareFileClient sourceFile = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            ShareFileClient destFile = directory.GetFileClient(GetNewFileName());
            await destFile.CreateAsync(maxSize: Constants.KB);

            HttpRange range = new HttpRange(0, Constants.KB);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destFile.UploadRangeFromUriAsync(
                sourceUri: destFile.Uri,
                range: range,
                sourceRange: range),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains("CopySourceStatusCode: 401"));
                    Assert.IsTrue(e.Message.Contains("CopySourceErrorCode: NoAuthenticationInformation"));
                    Assert.IsTrue(e.Message.Contains("CopySourceErrorMessage: Server failed to authenticate the request. Please refer to the information in the www-authenticate header."));
                });
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_06_08)]
        [TestCase(null)]
        [TestCase(FileLastWrittenMode.Now)]
        [TestCase(FileLastWrittenMode.Preserve)]
        public async Task UploadRangeFromUriAsync_PreserveFileLastWrittenOn(FileLastWrittenMode fileLastWrittenMode)
        {
            // Arrange
            await using DisposingFile testSource = await SharesClientBuilder.GetTestFileAsync();
            await using DisposingFile testDestination = await SharesClientBuilder.GetTestFileAsync();

            Response<ShareFileProperties> initalPropertiesResponse = await testDestination.File.GetPropertiesAsync();

            HttpRange httpRange = new HttpRange(0, Constants.KB);

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            await testSource.File.UploadRangeAsync(httpRange, stream);

            ShareFileUploadRangeFromUriOptions options = new ShareFileUploadRangeFromUriOptions
            {
                FileLastWrittenMode = fileLastWrittenMode
            };

            // Act
            await testDestination.File.UploadRangeFromUriAsync(
                sourceUri: testSource.File.GenerateSasUri(ShareFileSasPermissions.Read, Recording.UtcNow.AddDays(1)),
                range: httpRange,
                sourceRange: httpRange,
                options: options);

            // Assert
            Response<ShareFileProperties> propertiesResponse = await testDestination.File.GetPropertiesAsync();

            if (fileLastWrittenMode == FileLastWrittenMode.Preserve)
            {
                Assert.AreEqual(
                    initalPropertiesResponse.Value.SmbProperties.FileLastWrittenOn,
                    propertiesResponse.Value.SmbProperties.FileLastWrittenOn);
            }
            else
            {
                Assert.AreNotEqual(
                    initalPropertiesResponse.Value.SmbProperties.FileLastWrittenOn,
                    propertiesResponse.Value.SmbProperties.FileLastWrittenOn);
            }
        }

        [Test]
        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task UploadRangeFromUriAsync_TrailingDot(bool? sourceAllowTrailingDot)
        {
            // Arrange
            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = true;
            options.AllowSourceTrailingDot = sourceAllowTrailingDot;
            await using DisposingShare test = await GetTestShareAsync(options: options);
            ShareDirectoryClient directory = test.Share.GetDirectoryClient(GetNewDirectoryName());
            await directory.CreateAsync();

            string sourceName = GetNewFileName() + ".";
            var data = GetRandomBuffer(Constants.KB);
            var sourceFile = InstrumentClient(directory.GetFileClient(sourceName));
            await sourceFile.CreateAsync(maxSize: 1024);
            using Stream stream = new MemoryStream(data);
            await sourceFile.UploadRangeAsync(new HttpRange(0, 1024), stream);

            var destFile = directory.GetFileClient(GetNewFileName() + ".");
            await destFile.CreateAsync(maxSize: 1024);
            var destRange = new HttpRange(256, 256);
            var sourceRange = new HttpRange(512, 256);

            Uri sourceUri = sourceFile.GenerateSasUri(ShareFileSasPermissions.All, Recording.UtcNow.AddDays(1));

            // Act
            if (sourceAllowTrailingDot == true)
            {
                await destFile.UploadRangeFromUriAsync(
                    sourceUri: sourceUri,
                    range: destRange,
                    sourceRange: sourceRange);
            }
            else
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    destFile.UploadRangeFromUriAsync(
                        sourceUri: sourceUri,
                        range: destRange,
                        sourceRange: sourceRange),
                    e => Assert.AreEqual(e.ErrorCode, "CannotVerifyCopySource"));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task UploadRangeFromUriAsync_OAuth()
        {
            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();
            ShareClient oauthShareClient = InstrumentClient(oauthServiceClient.GetShareClient(shareName));

            // Arrange
            var directoryName = GetNewDirectoryName();
            var directory = InstrumentClient(oauthShareClient.GetDirectoryClient(directoryName));
            await directory.CreateIfNotExistsAsync();

            var fileName = GetNewFileName();
            var data = GetRandomBuffer(Constants.KB);
            var sourceFile = InstrumentClient(directory.GetFileClient(fileName));
            await sourceFile.CreateAsync(maxSize: 1024);
            using (var stream = new MemoryStream(data))
            {
                await sourceFile.UploadRangeAsync(new HttpRange(0, 1024), stream);
            }

            var destFile = directory.GetFileClient("destFile");
            await destFile.CreateAsync(maxSize: 1024);
            var destRange = new HttpRange(256, 256);
            var sourceRange = new HttpRange(512, 256);

            var sasFile = InstrumentClient(
                GetServiceClient_FileServiceSasShare(shareName)
                .GetShareClient(shareName)
                .GetDirectoryClient(directoryName)
                .GetFileClient(fileName));

            // Act
            Response<ShareFileUploadInfo> response = await destFile.UploadRangeFromUriAsync(
                sourceUri: sasFile.Uri,
                range: destRange,
                sourceRange: sourceRange);

            // Assert
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");

            // Ensure the contents of the source and destination Files after the UploadRangeFromUri call
            var sourceDownloadResponse = await sourceFile.DownloadAsync(new ShareFileDownloadOptions
            {
                Range = sourceRange
            });
            var destDownloadResponse = await destFile.DownloadAsync(new ShareFileDownloadOptions
            {
                Range = destRange
            });

            var sourceStream = new MemoryStream();
            await sourceDownloadResponse.Value.Content.CopyToAsync(sourceStream);

            var destStream = new MemoryStream();
            await destDownloadResponse.Value.Content.CopyToAsync(destStream);

            TestHelper.AssertSequenceEqual(sourceStream.ToArray(), destStream.ToArray());
        }

        [RecordedTest]
        public async Task ListHandles()
        {
            // Arrange
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient file = test.File;

            // Act
            IList<ShareFileHandle> handles = await file.GetHandlesAsync().ToListAsync();

            // Assert
            Assert.AreEqual(0, handles.Count);
        }

        [PlaybackOnly("Not possible to make this test live")]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2024_02_04)]
        public async Task ListHandlesWithClientName()
        {
            ShareServiceClient serviceClient = SharesClientBuilder.GetServiceClient_SharedKey();
            ShareClient shareClient = serviceClient.GetShareClient("myshare");
            ShareDirectoryClient directoryClient = shareClient.GetDirectoryClient("directory");
            ShareFileClient fileClient = directoryClient.GetFileClient("file");
            IList<ShareFileHandle> handles = await fileClient.GetHandlesAsync().ToListAsync();
            // Assert
            Assert.NotNull(handles[0].ClientName);
        }

        [RecordedTest]
        public async Task ListHandles_Min()
        {
            // Arrange
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient file = test.File;

            // Act
            IList<ShareFileHandle> handles = await file.GetHandlesAsync().ToListAsync();

            // Assert
            Assert.AreEqual(0, handles.Count);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task ListHandles_OAuth()
        {
            // Arrange
            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            ShareFileClient file = await directory.CreateFileAsync(GetNewFileName(), Constants.MB);

            // Act
            IList<ShareFileHandle> handles = await file.GetHandlesAsync().ToListAsync();

            // Assert
            Assert.AreEqual(0, handles.Count);
        }

        [RecordedTest]
        public async Task ListHandles_Error()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.GetHandlesAsync().ToListAsync(),
                actualException => Assert.AreEqual("ResourceNotFound", actualException.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task ListHandles_TrailingDot()
        {
            // Arrange
            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = true;
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync(options: options);
            ShareFileClient file = test.File;

            // Act
            IList<ShareFileHandle> handles = await file.GetHandlesAsync().ToListAsync();

            // Assert
            Assert.AreEqual(0, handles.Count);
        }

        [Test]
        [PlaybackOnly("Not possible to make this test live")]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2023_01_03)]
        public async Task ListHandles_AccessRights()
        {
            ShareServiceClient serviceClient = SharesClientBuilder.GetServiceClient_SharedKey();
            ShareClient shareClient = serviceClient.GetShareClient("myshare");
            ShareDirectoryClient directoryClient = shareClient.GetDirectoryClient("directory");
            ShareFileClient fileClient = directoryClient.GetFileClient("file");
            IList<ShareFileHandle> handles = await fileClient.GetHandlesAsync().ToListAsync();
            Assert.AreEqual(ShareFileHandleAccessRights.Write, handles[0].AccessRights);
        }

        [RecordedTest]
        public async Task ForceCloseHandles_Min()
        {
            // Arrange
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync();
            ShareFileClient file = test.File;

            // Act
            CloseHandlesResult reponse = await file.ForceCloseAllHandlesAsync();

            // Assert
            Assert.AreEqual(0, reponse.ClosedHandlesCount);
            Assert.AreEqual(0, reponse.FailedHandlesCount);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task ForceCloseHandles_OAuth()
        {
            // Arrange
            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            ShareFileClient file = await directory.CreateFileAsync(GetNewFileName(), Constants.MB);

            // Act
            CloseHandlesResult reponse = await file.ForceCloseAllHandlesAsync();

            // Assert
            Assert.AreEqual(0, reponse.ClosedHandlesCount);
            Assert.AreEqual(0, reponse.FailedHandlesCount);
        }

        [RecordedTest]
        public async Task ForceCloseHandles_Error()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.ForceCloseAllHandlesAsync(),
                actualException => Assert.AreEqual("ResourceNotFound", actualException.ErrorCode));
        }

        [RecordedTest]
        public async Task ForceCloseHandle_Error()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.ForceCloseHandleAsync("nonExistantHandleId"),
                actualException => Assert.AreEqual("InvalidHeaderValue", actualException.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task ForceCloseHandles_TrailingDot()
        {
            // Arrange
            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = true;
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync(options: options);
            ShareFileClient file = test.File;

            // Act
            CloseHandlesResult reponse = await file.ForceCloseAllHandlesAsync();

            // Assert
            Assert.AreEqual(0, reponse.ClosedHandlesCount);
            Assert.AreEqual(0, reponse.FailedHandlesCount);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task AcquireLeaseAsync()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));
            await file.CreateAsync(1024);
            string leaseId = Recording.Random.NewGuid().ToString();

            // Act
            var leaseClient = InstrumentClient(file.GetShareLeaseClient(leaseId));
            Response<ShareFileLease> response = await leaseClient.AcquireAsync();

            // Assert

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");

            Assert.AreEqual(response.Value.LeaseId, leaseClient.LeaseId);
            Assert.AreNotEqual(new DateTimeOffset(), response.Value.LastModified);
            Assert.IsNotNull(response.Value.LeaseId);
            Assert.IsNull(response.Value.LeaseTime);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task AcquireLeaseAsync_OAuth()
        {
            // Arrange
            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));
            await file.CreateAsync(1024);
            string leaseId = Recording.Random.NewGuid().ToString();

            // Act
            var leaseClient = InstrumentClient(file.GetShareLeaseClient(leaseId));
            Response<ShareFileLease> response = await leaseClient.AcquireAsync();

            // Assert

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");

            Assert.AreEqual(response.Value.LeaseId, leaseClient.LeaseId);
            Assert.AreNotEqual(new DateTimeOffset(), response.Value.LastModified);
            Assert.IsNotNull(response.Value.LeaseId);
            Assert.IsNull(response.Value.LeaseTime);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task AcquireLeaseAsync_Error()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));
            string leaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(file.GetShareLeaseClient(leaseId)).AcquireAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task AcquireLeaseAsync_TrailingDot()
        {
            // Arrange
            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = true;
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync(options: options);
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName() + "."));
            await file.CreateAsync(1024);
            string leaseId = Recording.Random.NewGuid().ToString();

            // Act
            var leaseClient = InstrumentClient(file.GetShareLeaseClient(leaseId));
            Response<ShareFileLease> response = await leaseClient.AcquireAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task ReleaseLeaseAsync()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));
            await file.CreateAsync(1024);
            string leaseId = Recording.Random.NewGuid().ToString();
            ShareLeaseClient leaseClient = InstrumentClient(file.GetShareLeaseClient(leaseId));
            await leaseClient.AcquireAsync();

            // Act
            Response<FileLeaseReleaseInfo> response = await leaseClient.ReleaseAsync();

            // Assert
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");
            Assert.IsNotNull(response.Value.LastModified);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task ReleaseLeaseAsync_OAuth()
        {
            // Arrange
            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            ShareFileClient file = await directory.CreateFileAsync(GetNewFileName(), Constants.KB);
            string leaseId = Recording.Random.NewGuid().ToString();
            ShareLeaseClient leaseClient = InstrumentClient(file.GetShareLeaseClient(leaseId));
            await leaseClient.AcquireAsync();

            // Act
            Response<FileLeaseReleaseInfo> response = await leaseClient.ReleaseAsync();

            // Assert
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");
            Assert.IsNotNull(response.Value.LastModified);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task ReleaseLeaseAsync_Error()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));
            string leaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(file.GetShareLeaseClient(leaseId)).ReleaseAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task ReleaseLeaseAsync_TrailingDot()
        {
            // Arrange
            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = true;
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync(options: options);
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName() + "."));
            await file.CreateAsync(1024);
            string leaseId = Recording.Random.NewGuid().ToString();
            ShareLeaseClient leaseClient = InstrumentClient(file.GetShareLeaseClient(leaseId));
            await leaseClient.AcquireAsync();

            // Act
            Response<FileLeaseReleaseInfo> response = await leaseClient.ReleaseAsync();

            // Assert
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");
            Assert.IsNotNull(response.Value.LastModified);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task ChangeLeaseAsync()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");

            Assert.AreEqual(response.Value.LeaseId, newLeaseId);
            Assert.AreEqual(response.Value.LeaseId, leaseClient.LeaseId);
            Assert.AreNotEqual(new DateTimeOffset(), response.Value.LastModified);
            Assert.IsNotNull(response.Value.LeaseId);
            Assert.IsNull(response.Value.LeaseTime);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task ChangeLeaseAsync_OAuth()
        {
            // Arrange
            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));
            await file.CreateAsync(1024);
            string leaseId = Recording.Random.NewGuid().ToString();
            string newLeaseId = Recording.Random.NewGuid().ToString();
            ShareLeaseClient leaseClient = InstrumentClient(file.GetShareLeaseClient(leaseId));
            await leaseClient.AcquireAsync();

            // Act
            Response<ShareFileLease> response = await leaseClient.ChangeAsync(newLeaseId);

            // Assert

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");

            Assert.AreEqual(response.Value.LeaseId, newLeaseId);
            Assert.AreEqual(response.Value.LeaseId, leaseClient.LeaseId);
            Assert.AreNotEqual(new DateTimeOffset(), response.Value.LastModified);
            Assert.IsNotNull(response.Value.LeaseId);
            Assert.IsNull(response.Value.LeaseTime);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task ChangeLeaseAsync_Error()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));
            string leaseId = Recording.Random.NewGuid().ToString();
            string newLeaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(file.GetShareLeaseClient(leaseId)).ChangeAsync(newLeaseId),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task ChangeLeaseAsync_TrailingDot()
        {
            // Arrange
            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = true;
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync(options: options);
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName() + "."));
            await file.CreateAsync(1024);
            string leaseId = Recording.Random.NewGuid().ToString();
            string newLeaseId = Recording.Random.NewGuid().ToString();
            ShareLeaseClient leaseClient = InstrumentClient(file.GetShareLeaseClient(leaseId));
            await leaseClient.AcquireAsync();

            // Act
            Response<ShareFileLease> response = await leaseClient.ChangeAsync(newLeaseId);

            // Assert

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");

            Assert.AreEqual(response.Value.LeaseId, newLeaseId);
            Assert.AreEqual(response.Value.LeaseId, leaseClient.LeaseId);
            Assert.AreNotEqual(new DateTimeOffset(), response.Value.LastModified);
            Assert.IsNotNull(response.Value.LeaseId);
            Assert.IsNull(response.Value.LeaseTime);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2020_02_10)]
        public async Task RenewLeaseAsync_Error()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));
            string id = Recording.Random.NewGuid().ToString();
            ShareLeaseClient leaseClient = InstrumentClient(file.GetShareLeaseClient(id));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<InvalidOperationException>(
                leaseClient.RenewAsync(),
                e => Assert.AreEqual(e.Message, "Renew only supports Share Leases"));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task BreakLeaseAsync()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));
            await file.CreateAsync(1024);
            string leaseId = Recording.Random.NewGuid().ToString();
            ShareLeaseClient leaseClient = InstrumentClient(file.GetShareLeaseClient(leaseId));
            await leaseClient.AcquireAsync();

            // Act
            Response<ShareFileLease> response = await leaseClient.BreakAsync();

            // Assert
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");
            Assert.AreNotEqual(new DateTimeOffset(), response.Value.LastModified);
            Assert.IsNull(response.Value.LeaseId);
            Assert.AreEqual(0, response.Value.LeaseTime);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task BreakLeaseAsync_OAuth()
        {
            // Arrange
            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));
            await file.CreateAsync(1024);
            string leaseId = Recording.Random.NewGuid().ToString();
            ShareLeaseClient leaseClient = InstrumentClient(file.GetShareLeaseClient(leaseId));
            await leaseClient.AcquireAsync();

            // Act
            Response<ShareFileLease> response = await leaseClient.BreakAsync();

            // Assert
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");
            Assert.AreNotEqual(new DateTimeOffset(), response.Value.LastModified);
            Assert.IsNull(response.Value.LeaseId);
            Assert.AreEqual(0, response.Value.LeaseTime);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task BreakLeaseAsync_Error()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));
            string leaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(file.GetShareLeaseClient(leaseId)).BreakAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task BreakLeaseAsync_TrailingDot()
        {
            // Arrange
            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = true;
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync(options: options);
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName() + "."));
            await file.CreateAsync(1024);
            string leaseId = Recording.Random.NewGuid().ToString();
            ShareLeaseClient leaseClient = InstrumentClient(file.GetShareLeaseClient(leaseId));
            await leaseClient.AcquireAsync();

            // Act
            Response<ShareFileLease> response = await leaseClient.BreakAsync();
        }

        public async Task GetFileClient_AsciiName()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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

        [RecordedTest]
        public async Task GetFileClient_NonAsciiName()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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

        [RecordedTest]
        public async Task OpenWriteAsync_NewFile()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task OpenWriteAsync_OAuth()
        {
            // Arrange
            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await directory.CreateAsync();
            ShareFileClient file = directory.GetFileClient(GetNewFileName());
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

        [RecordedTest]
        public async Task OpenWriteAsync_NewFile_WithUsing()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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

        [RecordedTest]
        public async Task OpenWriteAsync_ModifyExistingFile()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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

            Response<ShareFileDownloadInfo> result = await file.DownloadAsync(new ShareFileDownloadOptions
            {
                Range = new HttpRange(0, 2 * Constants.KB)
            });
            MemoryStream dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(expectedData.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(expectedData, dataResult.ToArray());
        }

        [RecordedTest]
        public async Task OpenWriteAsync_AlternatingWriteAndFlush()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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

        [RecordedTest]
        public async Task OpenWriteAsync_Error()
        {
            // Arrange
            ShareServiceClient service = SharesClientBuilder.GetServiceClient_SharedKey();
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

        [RecordedTest]
        public async Task OpenWriteAsync_ProgressReporting()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task OpenWriteAsync_Overwite(bool fileExists)
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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

        [RecordedTest]
        public async Task OpenWriteAsync_OverwriteNoSize()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                file.OpenWriteAsync(
                    overwrite: true,
                    position: 0),
                e => Assert.AreEqual("options.MaxSize must be set if overwrite is set to true", e.Message));
        }

        [RecordedTest]
        public async Task OpenWriteAsync_NewFileNoSize()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                file.OpenWriteAsync(
                    overwrite: false,
                    position: 0),
                e => Assert.AreEqual("options.MaxSize must be set if the File is being created for the first time", e.Message));
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task OpenWriteAsync_Lease(bool overwrite)
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        public async Task OpenWriteAsync_InvalidLease(bool overwrite)
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task RenameAsync()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            string destFileName = GetNewFileName();
            ShareFileClient sourceFile = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await sourceFile.CreateAsync(Constants.KB);

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            await sourceFile.UploadAsync(stream);

            // Act
            ShareFileClient destFile = await sourceFile.RenameAsync(destinationPath: test.Directory.Name + "/" + destFileName);

            // Assert
            Response<ShareFileDownloadInfo> downloadResponse = await destFile.DownloadAsync(new ShareFileDownloadOptions
            {
                Range = new HttpRange(0, Constants.KB)
            });

            Assert.AreEqual(data.Length, downloadResponse.Value.ContentLength);
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task RenameAsync_Metadata()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            string destFileName = GetNewFileName();
            ShareFileClient sourceFile = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await sourceFile.CreateAsync(Constants.KB);

            IDictionary<string, string> metadata = BuildMetadata();

            ShareFileRenameOptions options = new ShareFileRenameOptions
            {
                Metadata = metadata
            };

            // Act
            ShareFileClient destFile = await sourceFile.RenameAsync(
                destinationPath: test.Directory.Name + "/" + destFileName,
                options: options);

            // Assert
            Response<ShareFileProperties> response = await destFile.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task RenameAsync_DifferentDirectory()
        {
            // Arrange
            await using DisposingShare test = await SharesClientBuilder.GetTestShareAsync();

            ShareDirectoryClient sourceDirectory = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
            await sourceDirectory.CreateAsync();
            ShareFileClient sourceFile = InstrumentClient(sourceDirectory.GetFileClient(GetNewFileName()));
            await sourceFile.CreateAsync(Constants.KB);

            ShareDirectoryClient destDirectory = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
            await destDirectory.CreateAsync();
            string destFileName = GetNewFileName();

            // Act
            ShareFileClient destFile = await sourceFile.RenameAsync(destinationPath: destDirectory.Name + "/" + destFileName);

            // Assert
            Response<ShareFileProperties> response = await destFile.GetPropertiesAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RenameAsync_ReplaceIfExists(bool replaceIfExists)
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareFileClient sourceFile = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await sourceFile.CreateAsync(Constants.KB);
            ShareFileClient destFile = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await destFile.CreateAsync(Constants.KB);

            ShareFileRenameOptions options = new ShareFileRenameOptions
            {
                ReplaceIfExists = replaceIfExists
            };

            // Act
            if (replaceIfExists)
            {
                destFile = await sourceFile.RenameAsync(
                    destinationPath: test.Directory.Name + "/" + destFile.Name,
                    options: options);

                // Assert
                Response<ShareFileProperties> response = await destFile.GetPropertiesAsync();
            }
            else
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    sourceFile.RenameAsync(
                    destinationPath: test.Directory.Name + "/" + destFile.Name,
                    options: options),
                    e => Assert.AreEqual(ShareErrorCode.ResourceAlreadyExists.ToString(), e.ErrorCode));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RenameAsync_IgnoreReadOnly(bool ignoreReadOnly)
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareFileClient sourceFile = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await sourceFile.CreateAsync(Constants.KB);
            ShareFileClient destFile = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            ShareFileCreateOptions createOptions = new ShareFileCreateOptions
            {
                SmbProperties = new FileSmbProperties
                {
                    FileAttributes = NtfsFileAttributes.ReadOnly
                }
            };
            await destFile.CreateAsync(
                maxSize: Constants.KB,
                options: createOptions);

            ShareFileRenameOptions options = new ShareFileRenameOptions
            {
                ReplaceIfExists = true,
                IgnoreReadOnly = ignoreReadOnly
            };

            // Act
            if (ignoreReadOnly)
            {
                destFile = await sourceFile.RenameAsync(
                    destinationPath: test.Directory.Name + "/" + destFile.Name,
                    options: options);

                // Assert
                Response<ShareFileProperties> response = await destFile.GetPropertiesAsync();
            }
            else
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    sourceFile.RenameAsync(
                    destinationPath: test.Directory.Name + "/" + destFile.Name,
                    options: options),
                    e => Assert.AreEqual(ShareErrorCode.ReadOnlyAttribute.ToString(), e.ErrorCode));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RenameAsync_SourceLeaseId(bool includeLeaseId)
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareFileClient sourceFile = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await sourceFile.CreateAsync(Constants.KB);
            string leaseId = Recording.Random.NewGuid().ToString();
            ShareLeaseClient shareLeaseClient = InstrumentClient(sourceFile.GetShareLeaseClient(leaseId));
            await shareLeaseClient.AcquireAsync();
            string destFileName = GetNewFileName();

            // Act
            if (includeLeaseId)
            {
                ShareFileRenameOptions options = new ShareFileRenameOptions
                {
                    SourceConditions = new ShareFileRequestConditions
                    {
                        LeaseId = leaseId
                    }
                };

                ShareFileClient destFile = await sourceFile.RenameAsync(
                    destinationPath: test.Directory.Name + "/" + destFileName,
                    options: options);

                // Assert
                await destFile.GetPropertiesAsync();
            }
            else
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    sourceFile.RenameAsync(
                    destinationPath: test.Directory.Name + "/" + destFileName),
                    e => Assert.AreEqual("LeaseIdMissing", e.ErrorCode));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RenameAsync_DestinationLeaseId(bool includeLeaseId)
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareFileClient sourceFile = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await sourceFile.CreateAsync(Constants.KB);
            ShareFileClient destFile = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await destFile.CreateAsync(Constants.KB);
            string leaseId = Recording.Random.NewGuid().ToString();
            ShareLeaseClient shareLeaseClient = InstrumentClient(destFile.GetShareLeaseClient(leaseId));
            await shareLeaseClient.AcquireAsync();

            ShareFileRenameOptions options = new ShareFileRenameOptions
            {
                ReplaceIfExists = true
            };

            // Act
            if (includeLeaseId)
            {
                options.DestinationConditions = new ShareFileRequestConditions
                {
                    LeaseId = leaseId
                };
                destFile = await sourceFile.RenameAsync(
                    destinationPath: test.Directory.Name + "/" + destFile.Name,
                    options: options);

                // Assert
                await destFile.GetPropertiesAsync();
            }
            else
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    sourceFile.RenameAsync(
                    destinationPath: test.Directory.Name + "/" + destFile.Name,
                    options: options),
                    e => Assert.AreEqual("LeaseIdMissing", e.ErrorCode));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task RenameAsync_NonAsciiSourceAndDestination()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareFileClient sourceFile = InstrumentClient(test.Directory.GetFileClient(GetNewNonAsciiFileName()));
            await sourceFile.CreateAsync(Constants.KB);

            string destFileName = GetNewNonAsciiFileName();

            // Act
            ShareFileClient destFile = await sourceFile.RenameAsync(destinationPath: test.Directory.Name + "/" + destFileName);

            // Assert
            await destFile.GetPropertiesAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task RenameAsync_FilePermission()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareFileClient sourceFile = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await sourceFile.CreateAsync(Constants.KB);
            string destFileName = GetNewFileName();

            ShareFileRenameOptions options = new ShareFileRenameOptions
            {
                FilePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)"
            };

            // Act
            ShareFileClient destFile = await sourceFile.RenameAsync(
                destinationPath: test.Directory.Name + "/" + destFileName,
                options: options);

            Response<ShareFileProperties> propertiesResponse = await destFile.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(propertiesResponse.Value.SmbProperties.FilePermissionKey);
        }

        [RecordedTest]
        [TestCase(null)]
        [TestCase(FilePermissionFormat.Sddl)]
        [TestCase(FilePermissionFormat.Binary)]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2024_11_04)]
        public async Task RenameAsync_FilePermissionFormat(FilePermissionFormat? filePermissionFormat)
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareFileClient sourceFile = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await sourceFile.CreateAsync(Constants.KB);
            string destFileName = GetNewFileName();

            string permission;
            if (filePermissionFormat == null || filePermissionFormat == FilePermissionFormat.Sddl)
            {
                permission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)S:NO_ACCESS_CONTROL";
            }
            else
            {
                permission = "AQAUhGwAAACIAAAAAAAAABQAAAACAFgAAwAAAAAAFAD/AR8AAQEAAAAAAAUSAAAAAAAYAP8BHwABAgAAAAAABSAAAAAgAgAAAAAkAKkAEgABBQAAAAAABRUAAABZUbgXZnJdJWRjOwuMmS4AAQUAAAAAAAUVAAAAoGXPfnhLm1/nfIdwr/1IAQEFAAAAAAAFFQAAAKBlz354S5tf53yHcAECAAA=";
            }

            ShareFileRenameOptions options = new ShareFileRenameOptions
            {
                FilePermission = permission,
                FilePermissionFormat = filePermissionFormat
            };

            // Act
            ShareFileClient destFile = await sourceFile.RenameAsync(
                destinationPath: test.Directory.Name + "/" + destFileName,
                options: options);

            Response<ShareFileProperties> propertiesResponse = await destFile.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(propertiesResponse.Value.SmbProperties.FilePermissionKey);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task RenameAsync_FilePermissionAndFilePermissionKeySet()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareFileClient sourceFile = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await sourceFile.CreateAsync(Constants.KB);
            string destFileName = GetNewFileName();

            ShareFileRenameOptions options = new ShareFileRenameOptions
            {
                FilePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)",
                SmbProperties = new FileSmbProperties
                {
                    FilePermissionKey = "filePermissionKey"
                }
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                sourceFile.RenameAsync(
                    destinationPath: test.Directory.Name + "/" + destFileName,
                    options: options),
                e => Assert.AreEqual("filePermission and filePermissionKey cannot both be set", e.Message));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task RenameAsync_FilePermissionTooLarge()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareFileClient sourceFile = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await sourceFile.CreateAsync(Constants.KB);
            string destFileName = GetNewFileName();

            string filePermission = new string('*', 9 * Constants.KB);

            ShareFileRenameOptions options = new ShareFileRenameOptions
            {
                FilePermission = filePermission
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                sourceFile.RenameAsync(
                    destinationPath: test.Directory.Name + "/" + destFileName,
                    options: options),
                e =>
                {
                    Assert.AreEqual("filePermission", e.ParamName);
                    StringAssert.StartsWith("Value must be less than or equal to 8192", e.Message);
                });
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task RenameAsync_SmbProperties()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareFileClient sourceFile = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await sourceFile.CreateAsync(Constants.KB);
            string destFileName = GetNewFileName();

            string permission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
            ShareFilePermission filePermission = new ShareFilePermission()
            {
                Permission = permission,
            };
            Response<PermissionInfo> createPermissionResponse = await test.Share.CreatePermissionAsync(filePermission);

            FileSmbProperties smbProperties = new FileSmbProperties
            {
                FilePermissionKey = createPermissionResponse.Value.FilePermissionKey,
                FileAttributes = ShareModelExtensions.ToFileAttributes("Archive|ReadOnly"),
                FileCreatedOn = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero),
                FileLastWrittenOn = new DateTimeOffset(2019, 8, 26, 5, 15, 25, 60, TimeSpan.Zero),
                FileChangedOn = new DateTimeOffset(2010, 8, 26, 5, 15, 21, 60, TimeSpan.Zero),
            };

            ShareFileRenameOptions options = new ShareFileRenameOptions
            {
                SmbProperties = smbProperties
            };

            // Act
            ShareFileClient destFile = await sourceFile.RenameAsync(
                destinationPath: test.Directory.Name + "/" + destFileName,
                options: options);

            Response<ShareFileProperties> propertiesResponse = await destFile.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(smbProperties.FileAttributes, propertiesResponse.Value.SmbProperties.FileAttributes);
            Assert.AreEqual(smbProperties.FileCreatedOn, propertiesResponse.Value.SmbProperties.FileCreatedOn);
            Assert.AreEqual(smbProperties.FileLastWrittenOn, propertiesResponse.Value.SmbProperties.FileLastWrittenOn);
            Assert.AreEqual(smbProperties.FileChangedOn, propertiesResponse.Value.SmbProperties.FileChangedOn);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task RenameAsync_ShareSAS()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareFileClient sourceFile = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await sourceFile.CreateAsync(Constants.KB);
            string destFileName = GetNewFileName();

            ShareSasBuilder shareSasBuilder = new ShareSasBuilder
            {
                ShareName = test.Share.Name,
                ExpiresOn = Recording.UtcNow.AddDays(1)
            };
            shareSasBuilder.SetPermissions(ShareSasPermissions.All);
            SasQueryParameters sasQueryParameters = shareSasBuilder.ToSasQueryParameters(Tenants.GetNewSharedKeyCredentials());

            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(sourceFile.Uri)
            {
                Sas = sasQueryParameters
            };

            sourceFile = InstrumentClient(new ShareFileClient(shareUriBuilder.ToUri(), GetOptions()));

            // Act
            ShareFileClient destFile = await sourceFile.RenameAsync(
                destinationPath: test.Directory.Name + "/" + destFileName + "?" + sasQueryParameters);

            // Assert
            await destFile.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task RenameAsync_SasCredentialFromShare()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            string sas = GetNewAccountSasCredentials(resourceTypes: AccountSasResourceTypes.All, permissions: AccountSasPermissions.All).ToString();
            Uri uri = test.Share.Uri;
            string directoryName = GetNewDirectoryName();
            await test.Share.CreateDirectoryAsync(directoryName);

            ShareClient sasClient = InstrumentClient(new ShareClient(uri, new AzureSasCredential(sas), GetOptions()));
            ShareFileClient sourcefileClient = sasClient.GetDirectoryClient(directoryName).GetFileClient(GetNewFileName());

            string destFileName = GetNewFileName();

            await sourcefileClient.CreateAsync(Constants.KB);

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            await sourcefileClient.UploadAsync(stream);

            // Act
            ShareFileClient destFile = await sourcefileClient.RenameAsync(destinationPath: directoryName + "/" + destFileName);

            // Assert
            Response<ShareFileDownloadInfo> downloadResponse = await destFile.DownloadAsync(
                new ShareFileDownloadOptions
                {
                    Range = new HttpRange(0, Constants.KB)
                });

            Assert.AreEqual(data.Length, downloadResponse.Value.ContentLength);
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [RecordedTest]
        public async Task RenameAsync_SasCredentialFromDirectory()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            string sas = GetNewAccountSasCredentials(resourceTypes: AccountSasResourceTypes.All, permissions: AccountSasPermissions.All).ToString();
            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directoryClient = await test.Share.CreateDirectoryAsync(directoryName);

            // Act
            ShareDirectoryClient sasDirectoryClient = InstrumentClient(new ShareDirectoryClient(directoryClient.Uri, new AzureSasCredential(sas), GetOptions()));
            ShareFileClient sourcefileClient = sasDirectoryClient.GetFileClient(GetNewFileName());

            await sourcefileClient.CreateAsync(Constants.KB);

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            await sourcefileClient.UploadAsync(stream);

            // Act
            string destFileName = GetNewFileName();
            ShareFileClient destFile = await sourcefileClient.RenameAsync(destinationPath: directoryName + "/" + destFileName);

            // Assert
            Response<ShareFileDownloadInfo> downloadResponse = await destFile.DownloadAsync(
                new ShareFileDownloadOptions
                {
                    Range = new HttpRange(0, Constants.KB)
                });

            Assert.AreEqual(data.Length, downloadResponse.Value.ContentLength);
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task RenameAsync_ContentType()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            string destFileName = GetNewFileName();
            ShareFileClient sourceFile = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            await sourceFile.CreateAsync(Constants.KB);

            string contentType = "contentType";

            ShareFileRenameOptions options = new ShareFileRenameOptions
            {
                ContentType = contentType
            };

            // Act
            ShareFileClient destFile = await sourceFile.RenameAsync(
                destinationPath: test.Directory.Name + "/" + destFileName,
                options: options);

            // Assert
            Response<ShareFileProperties> response = await destFile.GetPropertiesAsync();
            Assert.AreEqual(contentType, response.Value.ContentType);
        }

        [LiveOnly]
        [Test]
        public async Task RenameAsync_DifferentSasUri()
        {
            // Arrange
            string shareName = GetNewShareName();
            await using DisposingShare test = await GetTestShareAsync(shareName: shareName);
            string sourceDirectoryName = GetNewDirectoryName();
            ShareDirectoryClient directoryClient = await test.Share.CreateDirectoryAsync(GetNewDirectoryName());
            ShareDirectoryClient sourceDirectoryClient = await directoryClient.CreateSubdirectoryAsync(sourceDirectoryName);
            ShareFileClient sourceFile = await sourceDirectoryClient.CreateFileAsync(GetNewFileName(), Constants.MB);

            // Make unique source sas
            SasQueryParameters sourceSas = GetNewFileServiceSasCredentialsShare(shareName);
            ShareUriBuilder sourceUriBuilder = new ShareUriBuilder(sourceDirectoryClient.Uri)
            {
                Sas = sourceSas
            };

            string destFileName = GetNewFileName();

            ShareDirectoryClient sasDirectoryClient = InstrumentClient(new ShareDirectoryClient(sourceUriBuilder.ToUri(), GetOptions()));
            ShareFileClient sasFileClient = InstrumentClient(sasDirectoryClient.GetFileClient(sourceFile.Name));

            // Make unique destination sas
            string newPath = sourceDirectoryClient.Path + "/" + destFileName;
            string destSas = GetNewAccountSasCredentials(
                resourceTypes: AccountSasResourceTypes.All,
                permissions: AccountSasPermissions.All).ToString();

            // Act
            ShareFileClient destFile = await sasFileClient.RenameAsync(destinationPath: newPath + "?" + destSas);

            // Assert
            Response<ShareFileProperties> response = await destFile.GetPropertiesAsync();
        }

        [LiveOnly]
        [Test]
        public async Task RenameAsync_SourceSasUri()
        {
            // Arrange
            string shareName = GetNewShareName();
            await using DisposingShare test = await GetTestShareAsync(shareName: shareName);
            string sourceDirectoryName = GetNewDirectoryName();
            ShareDirectoryClient directoryClient = await test.Share.CreateDirectoryAsync(GetNewDirectoryName());
            ShareDirectoryClient sourceDirectoryClient = await directoryClient.CreateSubdirectoryAsync(sourceDirectoryName);
            ShareFileClient sourceFile = await sourceDirectoryClient.CreateFileAsync(GetNewFileName(), Constants.MB);

            // Make unique source sas
            SasQueryParameters sourceSas = GetNewFileServiceSasCredentialsShare(shareName);
            ShareUriBuilder sourceUriBuilder = new ShareUriBuilder(sourceDirectoryClient.Uri)
            {
                Sas = sourceSas
            };

            string destFileName = GetNewFileName();

            ShareDirectoryClient sasDirectoryClient = InstrumentClient(new ShareDirectoryClient(sourceUriBuilder.ToUri(), GetOptions()));
            ShareFileClient sasFileClient = InstrumentClient(sasDirectoryClient.GetFileClient(sourceFile.Name));

            // Make unique destination sas
            string newPath = sourceDirectoryClient.Path + "/" + destFileName;

            // Act
            ShareFileClient destFile = await sasFileClient.RenameAsync(destinationPath: newPath);

            // Assert
            Response<ShareFileProperties> response = await destFile.GetPropertiesAsync();
        }

        [LiveOnly]
        [Test]
        public async Task RenameAsync_SourceSasCredentialDestSasUri()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials().ToString();
            await using DisposingShare test = await GetTestShareAsync();
            string sourceDirectoryName = GetNewDirectoryName();
            ShareDirectoryClient directoryClient = await test.Share.CreateDirectoryAsync(sourceDirectoryName);
            ShareFileClient sourceFile = await directoryClient.CreateFileAsync(GetNewFileName(), Constants.MB);

            string destFileName = GetNewFileName();

            // Act
            var sasDirectoryClient = InstrumentClient(new ShareDirectoryClient(directoryClient.Uri, new AzureSasCredential(sas), GetOptions()));
            ShareFileClient sasSourceFileClient = sasDirectoryClient.GetFileClient(sourceFile.Name);

            // Make unique destination sas
            string destSas = GetNewFileServiceSasCredentialsShare(test.Share.Name).ToString();

            // Act
            ShareFileClient destDirectory = await sasSourceFileClient.RenameAsync(destinationPath: destFileName + "?" + destSas);

            // Assert
            Response<ShareFileProperties> response = await destDirectory.GetPropertiesAsync();
        }

        [RecordedTest]
        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task RenameAsync_TrailingDot(bool? sourceAllowTrailingDot)
        {
            // Arrange
            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = true;
            options.AllowSourceTrailingDot = sourceAllowTrailingDot;
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync(options: options);
            string destFileName = GetNewFileName() + ".";
            ShareFileClient sourceFile = InstrumentClient(test.Directory.GetFileClient(GetNewFileName() + "."));
            await sourceFile.CreateAsync(Constants.KB);

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            await sourceFile.UploadAsync(stream);

            // Act
            if (sourceAllowTrailingDot == true)
            {
                ShareFileClient destFile = await sourceFile.RenameAsync(destinationPath: test.Directory.Name + "/" + destFileName);

                // Assert
                Response<ShareFileDownloadInfo> downloadResponse = await destFile.DownloadAsync(new ShareFileDownloadOptions
                {
                    Range = new HttpRange(0, Constants.KB)
                });

                Assert.AreEqual(data.Length, downloadResponse.Value.ContentLength);
                var actual = new MemoryStream();
                await downloadResponse.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }
            else
            {
                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    sourceFile.RenameAsync(destinationPath: test.Directory.Name + "/" + destFileName),
                    e => Assert.AreEqual(e.ErrorCode, "ResourceNotFound"));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task RenameAsync_OAuth()
        {
            // Arrange
            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            string destFileName = GetNewFileName();
            ShareFileClient sourceFile = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            await sourceFile.CreateAsync(Constants.KB);

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            await sourceFile.UploadAsync(stream);

            // Act
            ShareFileClient destFile = await sourceFile.RenameAsync(destinationPath: directory.Name + "/" + destFileName);

            // Assert
            Response<ShareFileDownloadInfo> downloadResponse = await destFile.DownloadAsync(new ShareFileDownloadOptions
            {
                Range = new HttpRange(0, Constants.KB)
            });

            Assert.AreEqual(data.Length, downloadResponse.Value.ContentLength);
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2025_05_05)]
        public async Task CreateGetSymbolicLinkAsync()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync(nfs: true);
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient source = InstrumentClient(await directory.CreateFileAsync(GetNewFileName(), maxSize: Constants.KB));
            ShareFileClient symlink = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            IDictionary<string, string> metdata = BuildMetadata();
            string owner = "345";
            string group = "123";
            DateTimeOffset fileCreatedOn = new DateTimeOffset(2024, 10, 15, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset fileLastWrittenOn = new DateTimeOffset(2025, 5, 2, 0, 0, 0, TimeSpan.Zero);

            ShareFileCreateSymbolicLinkOptions options = new ShareFileCreateSymbolicLinkOptions
            {
                Metadata = metdata,
                FileCreatedOn = fileCreatedOn,
                FileLastWrittenOn = fileLastWrittenOn,
                Owner = owner,
                Group = group
            };

            // Act
            Response<ShareFileInfo> response = await symlink.CreateSymbolicLinkAsync(
                linkText: source.Uri.ToString(),
                options: options);

            // Assert
            Assert.AreEqual(NfsFileType.SymLink, response.Value.PosixProperties.FileType);
            Assert.AreEqual(owner, response.Value.PosixProperties.Owner);
            Assert.AreEqual(group, response.Value.PosixProperties.Group);
            Assert.AreEqual(fileCreatedOn, response.Value.SmbProperties.FileCreatedOn);
            Assert.AreEqual(fileLastWrittenOn, response.Value.SmbProperties.FileLastWrittenOn);

            Assert.IsNull(response.Value.SmbProperties.FileAttributes);
            Assert.IsNull(response.Value.SmbProperties.FilePermissionKey);

            Assert.IsNotNull(response.Value.SmbProperties.FileId);
            Assert.IsNotNull(response.Value.SmbProperties.ParentId);

            // Act
            Response<ShareFileSymbolicLinkInfo> getSymLinkResponse = await symlink.GetSymbolicLinkAsync();

            // Assert
            Assert.AreNotEqual(default, getSymLinkResponse.Value.ETag);
            Assert.AreNotEqual(default, getSymLinkResponse.Value.LastModified);
            Assert.AreEqual(WebUtility.UrlEncode(source.Uri.ToString()), getSymLinkResponse.Value.LinkText);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2025_05_05)]
        public async Task CreateGetSymbolicLinkAsync_Error()
        {
            // Arrange
            await using DisposingShare test = await SharesClientBuilder.GetTestShareAsync(nfs: true);
            // Note that the parent directory was not created in this test case.
            ShareDirectoryClient directory = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));

            ShareFileClient source = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            ShareFileClient symlink = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                symlink.CreateSymbolicLinkAsync(linkText: source.Uri.ToString()),
                e => Assert.AreEqual("ParentNotFound", e.ErrorCode));

            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                symlink.GetSymbolicLinkAsync(),
                e => Assert.AreEqual("ParentNotFound", e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2025_05_05)]
        public async Task CreateGetSymbolicLinkAsync_OAuth()
        {
            // Arrange
            ShareServiceClient oauthServiceClient = GetServiceClient_PremiumFileOAuth();
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync(
                service: oauthServiceClient,
                nfs: true);
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient source = InstrumentClient(await directory.CreateFileAsync(GetNewFileName(), maxSize: Constants.KB));
            ShareFileClient symlink = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            await symlink.CreateSymbolicLinkAsync(linkText: source.Uri.ToString());
            await symlink.GetSymbolicLinkAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2025_05_05)]
        public async Task CreateHardLinkAsync()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync(nfs: true);
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient source = InstrumentClient(await directory.CreateFileAsync(GetNewFileName(), maxSize: Constants.KB));
            ShareLeaseClient leaseClient = InstrumentClient(test.Share.GetShareLeaseClient(Recording.Random.NewGuid().ToString()));
            ShareFileLease lease = await leaseClient.AcquireAsync();
            try
            {
                ShareFileClient hardLink = InstrumentClient(directory.GetFileClient(GetNewFileName()));

                // Act
                Response<ShareFileInfo> response = await hardLink.CreateHardLinkAsync(
                    targetFile: $"{directory.Name}/{source.Name}",
                    conditions: new ShareFileRequestConditions() { LeaseId = lease.LeaseId });

                // Assert
                Assert.AreEqual(NfsFileType.Regular, response.Value.PosixProperties.FileType);
                Assert.AreEqual("0", response.Value.PosixProperties.Owner);
                Assert.AreEqual("0", response.Value.PosixProperties.Group);
                Assert.AreEqual("0664", response.Value.PosixProperties.FileMode.ToOctalFileMode());
                Assert.AreEqual(2, response.Value.PosixProperties.LinkCount);

                Assert.IsNotNull(response.Value.SmbProperties.FileCreatedOn);
                Assert.IsNotNull(response.Value.SmbProperties.FileLastWrittenOn);
                Assert.IsNotNull(response.Value.SmbProperties.FileChangedOn);
                Assert.IsNotNull(response.Value.SmbProperties.FileId);
                Assert.IsNotNull(response.Value.SmbProperties.ParentId);

                Assert.IsNull(response.Value.SmbProperties.FileAttributes);
                Assert.IsNull(response.Value.SmbProperties.FilePermissionKey);
            }
            finally
            {
                await leaseClient.ReleaseAsync();
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2025_05_05)]
        public async Task CreateHardLinkAsync_OAuth()
        {
            // Arrange
            ShareServiceClient oauthServiceClient = GetServiceClient_PremiumFileOAuth();
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync(
                service: oauthServiceClient,
                nfs: true);
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient source = InstrumentClient(await directory.CreateFileAsync(GetNewFileName(), maxSize: Constants.KB));
            ShareFileClient hardLink = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            Response<ShareFileInfo> response = await hardLink.CreateHardLinkAsync(
                targetFile: $"{directory.Name}/{source.Name}");
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2025_05_05)]
        public async Task CreateGetHardLinkAsync_Error()
        {
            // Arrange
            await using DisposingShare test = await SharesClientBuilder.GetTestShareAsync(nfs: true);
            // Note that the parent directory was not created in this test case.
            ShareDirectoryClient directory = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));

            ShareFileClient source = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            ShareFileClient hardLink = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                hardLink.CreateHardLinkAsync(targetFile: $"{directory.Name}/{source.Name}"),
                e => Assert.AreEqual("ParentNotFound", e.ErrorCode));
        }

        #region GenerateSasTests
        [RecordedTest]
        public void CanGenerateSas_ClientConstructors()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var ShareEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var ShareSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, fileStorageUri: (ShareEndpoint, ShareSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Act - ShareDirectoryClient(string connectionString, string ShareContainerName, string ShareName)
            ShareFileClient directory = InstrumentClient(new ShareFileClient(
                connectionString,
                GetNewShareName(),
                GetNewDirectoryName()));
            Assert.IsTrue(directory.CanGenerateSasUri);

            // Act - ShareFileClient(string connectionString, string ShareContainerName, string ShareName, ShareClientOptions options)
            ShareFileClient directory2 = InstrumentClient(new ShareFileClient(
                connectionString,
                GetNewShareName(),
                GetNewDirectoryName(),
                GetOptions()));
            Assert.IsTrue(directory2.CanGenerateSasUri);

            // Act - ShareFileClient(Uri ShareContainerUri, ShareClientOptions options = default)
            ShareFileClient directory3 = InstrumentClient(new ShareFileClient(
                ShareEndpoint,
                GetOptions()));
            Assert.IsFalse(directory3.CanGenerateSasUri);

            // Act - ShareFileClient(Uri ShareContainerUri, StorageSharedKeyCredential credential, ShareClientOptions options = default)
            ShareFileClient directory4 = InstrumentClient(new ShareFileClient(
                ShareEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            Assert.IsTrue(directory4.CanGenerateSasUri);
        }

        [RecordedTest]
        public void CanGenerateSas_Mockable()
        {
            // Act
            var directory = new Mock<ShareFileClient>();
            directory.Setup(x => x.CanGenerateSasUri).Returns(false);

            // Assert
            Assert.IsFalse(directory.Object.CanGenerateSasUri);

            // Act
            directory.Setup(x => x.CanGenerateSasUri).Returns(true);

            // Assert
            Assert.IsTrue(directory.Object.CanGenerateSasUri);
        }

        [RecordedTest]
        public void GenerateSas_RequiredParameters()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            ShareFileSasPermissions permissions = ShareFileSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            string shareName = GetNewShareName();
            string fileName = GetNewFileName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.file.core.windows.net");
            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(serviceUri)
            {
                ShareName = shareName,
                DirectoryOrFilePath = fileName
            };
            ShareFileClient fileClient = InstrumentClient(new ShareFileClient(
                shareUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            string stringToSign = null;

            // Act
            Uri sasUri = fileClient.GenerateSasUri(permissions, expiresOn, out stringToSign);

            // Assert
            ShareSasBuilder sasBuilder = new ShareSasBuilder(permissions, expiresOn)
            {
                ShareName = shareName,
                FilePath = fileName,
            };
            ShareUriBuilder expectedUri = new ShareUriBuilder(serviceUri)
            {
                ShareName = shareName,
                DirectoryOrFilePath = fileName,
                Sas = sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        public void GenerateSas_Builder()
        {
            var constants = TestConstants.Create(this);
            ShareFileSasPermissions permissions = ShareFileSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);

            string shareName = GetNewShareName();
            string fileName = GetNewFileName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.file.core.windows.net");
            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(serviceUri)
            {
                ShareName = shareName,
                DirectoryOrFilePath = fileName
            };

            ShareFileClient directoryClient = InstrumentClient(new ShareFileClient(
                shareUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            ShareSasBuilder sasBuilder = new ShareSasBuilder(permissions, expiresOn)
            {
                ShareName = shareName,
                FilePath = fileName
            };

            string stringToSign = null;

            // Act
            Uri sasUri = directoryClient.GenerateSasUri(sasBuilder, out stringToSign);

            // Assert
            ShareSasBuilder sasBuilder2 = new ShareSasBuilder(permissions, expiresOn)
            {
                ShareName = shareName,
                FilePath = fileName
            };
            ShareUriBuilder expectedUri = new ShareUriBuilder(serviceUri)
            {
                ShareName = shareName,
                DirectoryOrFilePath = fileName,
                Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        public void GenerateSas_BuilderNullShareName()
        {
            var constants = TestConstants.Create(this);
            ShareFileSasPermissions permissions = ShareFileSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);

            string shareName = GetNewShareName();
            string fileName = GetNewFileName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.file.core.windows.net");
            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(serviceUri)
            {
                ShareName = shareName,
                DirectoryOrFilePath = fileName
            };

            ShareFileClient directoryClient = InstrumentClient(new ShareFileClient(
                shareUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            ShareSasBuilder sasBuilder = new ShareSasBuilder(permissions, expiresOn)
            {
                ShareName = null,
                FilePath = fileName
            };

            // Act
            Uri sasUri = directoryClient.GenerateSasUri(sasBuilder);

            // Assert
            ShareSasBuilder sasBuilder2 = new ShareSasBuilder(permissions, expiresOn)
            {
                ShareName = shareName,
                FilePath = fileName
            };
            ShareUriBuilder expectedUri = new ShareUriBuilder(serviceUri)
            {
                ShareName = shareName,
                DirectoryOrFilePath = fileName,
                Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
        }

        [RecordedTest]
        public void GenerateSas_BuilderWrongShareName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string shareName = GetNewShareName();
            string fileName = GetNewFileName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.file.core.windows.net");
            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(serviceUri)
            {
                ShareName = shareName,
                DirectoryOrFilePath = fileName
            };
            ShareFileClient fileClient = InstrumentClient(new ShareFileClient(
                shareUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            ShareSasBuilder sasBuilder = new ShareSasBuilder(ShareFileSasPermissions.All, Recording.UtcNow.AddHours(+1))
            {
                ShareName = GetNewShareName(), // different share name
                FilePath = fileName
            };

            // Act
            TestHelper.AssertExpectedException(
                () => fileClient.GenerateSasUri(sasBuilder),
                new InvalidOperationException("SAS Uri cannot be generated. ShareSasBuilder.ShareName does not match ShareName in the Client. ShareSasBuilder.ShareName must either be left empty or match the ShareName in the Client"));
        }

        [RecordedTest]
        public void GenerateSas_BuilderNullFileName()
        {
            var constants = TestConstants.Create(this);
            ShareFileSasPermissions permissions = ShareFileSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);

            string shareName = GetNewShareName();
            string fileName = GetNewFileName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.file.core.windows.net");
            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(serviceUri)
            {
                ShareName = shareName,
                DirectoryOrFilePath = fileName
            };

            ShareFileClient directoryClient = InstrumentClient(new ShareFileClient(
                shareUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            ShareSasBuilder sasBuilder = new ShareSasBuilder(permissions, expiresOn)
            {
                ShareName = shareName,
                FilePath = null
            };

            // Act
            Uri sasUri = directoryClient.GenerateSasUri(sasBuilder);

            // Assert
            ShareSasBuilder sasBuilder2 = new ShareSasBuilder(permissions, expiresOn)
            {
                ShareName = shareName,
                FilePath = fileName
            };
            ShareUriBuilder expectedUri = new ShareUriBuilder(serviceUri)
            {
                ShareName = shareName,
                DirectoryOrFilePath = fileName,
                Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
        }

        [RecordedTest]
        public void GenerateSas_BuilderWrongFileName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string shareName = GetNewShareName();
            string fileName = GetNewFileName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.file.core.windows.net");
            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(serviceUri)
            {
                ShareName = shareName,
                DirectoryOrFilePath = fileName
            };
            ShareFileClient fileClient = InstrumentClient(new ShareFileClient(
                shareUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            ShareSasBuilder sasBuilder = new ShareSasBuilder(ShareFileSasPermissions.All, Recording.UtcNow.AddHours(+1))
            {
                ShareName = shareName,
                FilePath = GetNewFileName() // different file name
            };

            // Act
            TestHelper.AssertExpectedException(
                () => fileClient.GenerateSasUri(sasBuilder),
                new InvalidOperationException("SAS Uri cannot be generated. ShareSasBuilder.FilePath does not match Path in the Client. ShareSasBuilder.FilePath must either be left empty or match the Path in the Client"));
        }
        #endregion

        [RecordedTest]
        public void CanMockClientConstructors()
        {
            // One has to call .Object to trigger constructor. It's lazy.
            var mock = new Mock<ShareFileClient>(TestConfigDefault.ConnectionString, "name", "name", new ShareClientOptions()).Object;
            mock = new Mock<ShareFileClient>(TestConfigDefault.ConnectionString, "name", "name").Object;
            mock = new Mock<ShareFileClient>(new Uri("https://test/test/test"), new ShareClientOptions()).Object;
            mock = new Mock<ShareFileClient>(new Uri("https://test/test/test"), Tenants.GetNewSharedKeyCredentials(), new ShareClientOptions()).Object;
            mock = new Mock<ShareFileClient>(new Uri("https://test/test/test"), new AzureSasCredential("foo"), new ShareClientOptions()).Object;
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
