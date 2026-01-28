// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Files.Shares.Specialized;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Tests.Shared;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Tests
{
    public class DirectoryClientTests : FileTestBase
    {
        public DirectoryClientTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
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

            var connectionString = new StorageConnectionString(credentials, (default, default), (default, default), (fileEndpoint, fileSecondaryEndpoint));

            var shareName = GetNewShareName();
            var directoryPath = GetNewDirectoryName();

            ShareDirectoryClient directory = InstrumentClient(new ShareDirectoryClient(connectionString.ToString(true), shareName, directoryPath, GetOptions()));

            var builder = new ShareUriBuilder(directory.Uri);

            Assert.That(builder.ShareName, Is.EqualTo(shareName));
            Assert.That(builder.DirectoryOrFilePath, Is.EqualTo(directoryPath));
            //Assert.AreEqual("accountName", builder.AccountName);
        }

        [RecordedTest]
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
            Assert.That(propertiesResponse.Value.ETag, Is.EqualTo(createResponse.Value.ETag));
        }

        [Test]
        public void Ctor_ConnectionString_CustomUri()
        {
            var accountName = "accountName";
            var shareName = "shareName";
            var directoryName = "directoryName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var fileEndpoint = new Uri("http://customdomain/" + accountName);
            var fileSecondaryEndpoint = new Uri("http://customdomain/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, (default, default), (default, default), (default, default), (fileEndpoint, fileSecondaryEndpoint));

            ShareDirectoryClient directoryClient = new ShareDirectoryClient(connectionString.ToString(true), shareName, directoryName);

            Assert.That(directoryClient.AccountName, Is.EqualTo(accountName));
            Assert.That(directoryClient.ShareName, Is.EqualTo(shareName));
            Assert.That(directoryClient.Path, Is.EqualTo(directoryName));
        }

        [RecordedTest]
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
            Assert.That(properties, Is.Not.Null);
        }

        [Test]
        public void Ctor_SharedKey_AccountName()
        {
            // Arrange
            var accountName = "accountName";
            var shareName = "shareName";
            var directoryName = "directoryName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });
            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var shareEndpoint = new Uri($"https://customdomain/{shareName}/{directoryName}");

            ShareDirectoryClient ShareDirectoryClient = new ShareDirectoryClient(shareEndpoint, credentials);

            Assert.That(ShareDirectoryClient.AccountName, Is.EqualTo(accountName));
            Assert.That(ShareDirectoryClient.ShareName, Is.EqualTo(shareName));
            Assert.That(ShareDirectoryClient.Path, Is.EqualTo(directoryName));
        }

        [RecordedTest]
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

        [RecordedTest]
        public async Task Ctor_DefaultAudience()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directoryClient = test.Share.GetDirectoryClient(GetNewDirectoryName());
            await directoryClient.CreateIfNotExistsAsync();

            // Act - Create new blob client with the OAuth Credential and Audience
            ShareClientOptions options = GetOptionsWithAudience(ShareAudience.DefaultAudience);

            ShareUriBuilder uriBuilder = new ShareUriBuilder(new Uri(Tenants.TestConfigOAuth.FileServiceEndpoint))
            {
                ShareName = test.Share.Name,
                DirectoryOrFilePath = directoryClient.Path
            };

            ShareDirectoryClient aadDirClient = InstrumentClient(new ShareDirectoryClient(
                uriBuilder.ToUri(),
                TestEnvironment.Credential,
                options));

            // Assert
            bool exists = await aadDirClient.ExistsAsync();
            Assert.That(exists, Is.Not.Null);
        }

        [RecordedTest]
        public async Task Ctor_CustomAudience()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directoryClient = test.Share.GetDirectoryClient(GetNewDirectoryName());
            await directoryClient.CreateIfNotExistsAsync();

            // Act - Create new blob client with the OAuth Credential and Audience
            ShareClientOptions options = GetOptionsWithAudience(new ShareAudience($"https://{directoryClient.AccountName}.file.core.windows.net/"));

            ShareUriBuilder uriBuilder = new ShareUriBuilder(new Uri(Tenants.TestConfigOAuth.FileServiceEndpoint))
            {
                ShareName = test.Share.Name,
                DirectoryOrFilePath = directoryClient.Path
            };

            ShareDirectoryClient aadDirClient = InstrumentClient(new ShareDirectoryClient(
                uriBuilder.ToUri(),
                TestEnvironment.Credential,
                options));

            // Assert
            bool exists = await aadDirClient.ExistsAsync();
            Assert.That(exists, Is.Not.Null);
        }

        [Test]
        public void Ctor_DevelopmentThrows()
        {
            var ex = Assert.Throws<ArgumentException>(() => new ShareDirectoryClient("UseDevelopmentStorage=true", "share", "dir"));
            Assert.That(ex.ParamName, Is.EqualTo("connectionString"));
        }

        [RecordedTest]
        public async Task Ctor_StorageAccountAudience()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directoryClient = test.Share.GetDirectoryClient(GetNewDirectoryName());
            await directoryClient.CreateIfNotExistsAsync();

            // Act - Create new blob client with the OAuth Credential and Audience
            ShareClientOptions options = GetOptionsWithAudience(ShareAudience.CreateShareServiceAccountAudience(directoryClient.AccountName));

            ShareUriBuilder uriBuilder = new ShareUriBuilder(new Uri(Tenants.TestConfigOAuth.FileServiceEndpoint))
            {
                ShareName = test.Share.Name,
                DirectoryOrFilePath = directoryClient.Path
            };

            ShareDirectoryClient aadDirClient = InstrumentClient(new ShareDirectoryClient(
                uriBuilder.ToUri(),
                TestEnvironment.Credential,
                options));

            // Assert
            bool exists = await aadDirClient.ExistsAsync();
            Assert.That(exists, Is.Not.Null);
        }

        [RecordedTest]
        public async Task Ctor_AudienceError()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directoryClient = test.Share.GetDirectoryClient(GetNewDirectoryName());
            await directoryClient.CreateIfNotExistsAsync();

            // Act - Create new blob client with the OAuth Credential and Audience
            ShareClientOptions options = GetOptionsWithAudience(new ShareAudience("https://badaudience.blob.core.windows.net"));

            ShareUriBuilder uriBuilder = new ShareUriBuilder(new Uri(Tenants.TestConfigOAuth.FileServiceEndpoint))
            {
                ShareName = test.Share.Name,
                DirectoryOrFilePath = directoryClient.Path
            };

            ShareDirectoryClient aadDirClient = InstrumentClient(new ShareDirectoryClient(
                uriBuilder.ToUri(),
                new MockCredential(),
                options));

            // Assert
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                aadDirClient.ExistsAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("InvalidAuthenticationInfo")));
        }

        [RecordedTest]
        public async Task Ctor_EscapeDirectoryName()
        {
            // Arrange
            string directoryName = "$=;!#öÖ";
            await using DisposingShare test = await GetTestShareAsync();
            int size = Constants.KB;
            var data = GetRandomBuffer(size);
            ShareDirectoryClient directory = InstrumentClient(test.Share.GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            // Act
            ShareUriBuilder uriBuilder = new ShareUriBuilder(new Uri(Tenants.TestConfigOAuth.FileServiceEndpoint))
            {
                ShareName = directory.ShareName,
                DirectoryOrFilePath = directoryName
            };
            ShareDirectoryClient freshDirectoryClient = InstrumentClient(new ShareDirectoryClient(
                uriBuilder.ToUri(),
                TestEnvironment.Credential,
                GetOptions()));

            // Assert
            Assert.That(freshDirectoryClient.Name, Is.EqualTo(directoryName));
        }

        [RecordedTest]
        public void DirectoryPathsParsing()
        {
            // nested directories
            Uri uri1 = new Uri("http://dummyaccount.file.core.windows.net/share/dir1/dir2");
            var builder1 = new ShareUriBuilder(uri1);
            var directoryClient1 = new ShareDirectoryClient(uri1);
            TestHelper.AssertCacheableProperty("dir2", () => directoryClient1.Name);
            TestHelper.AssertCacheableProperty("dir1/dir2", () => directoryClient1.Path);
            Assert.That(builder1.LastDirectoryOrFileName, Is.EqualTo("dir2"));

            // one directory
            Uri uri2 = new Uri("http://dummyaccount.file.core.windows.net/share/dir1");
            var builder2 = new ShareUriBuilder(uri2);
            var directoryClient2 = new ShareDirectoryClient(uri2);
            TestHelper.AssertCacheableProperty("dir1", () => directoryClient2.Name);
            TestHelper.AssertCacheableProperty("dir1", () => directoryClient2.Path);
            Assert.That(builder2.LastDirectoryOrFileName, Is.EqualTo("dir1"));

            // directory with trailing slash
            Uri uri3 = new Uri("http://dummyaccount.file.core.windows.net/share/dir1/");
            var builder3 = new ShareUriBuilder(uri3);
            var directoryClient3 = new ShareDirectoryClient(uri3);
            TestHelper.AssertCacheableProperty("dir1", () => directoryClient3.Name);
            TestHelper.AssertCacheableProperty("dir1", () => directoryClient3.Path);
            Assert.That(builder3.LastDirectoryOrFileName, Is.EqualTo("dir1"));

            // no directory
            Uri uri4 = new Uri("http://dummyaccount.file.core.windows.net/share");
            var builder4 = new ShareUriBuilder(uri4);
            var directoryClient4 = new ShareDirectoryClient(uri4);
            TestHelper.AssertCacheableProperty(string.Empty, () => directoryClient4.Name);
            TestHelper.AssertCacheableProperty(string.Empty, () => directoryClient4.Path);
            Assert.That(builder4.LastDirectoryOrFileName, Is.Empty);
        }

        [RecordedTest]
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
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            var accountName = new ShareUriBuilder(directory.Uri).AccountName;
            TestHelper.AssertCacheableProperty(accountName, () => directory.AccountName);
            var shareName = new ShareUriBuilder(directory.Uri).ShareName;
            TestHelper.AssertCacheableProperty(shareName, () => directory.ShareName);
            TestHelper.AssertCacheableProperty(name, () => directory.Name);

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.That($"\"{response.GetRawResponse().Headers.ETag}\"", Is.EqualTo(response.Value.ETag.ToString()));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task CreateAsync_OAuth()
        {
            // Arrange
            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));

            // Act
            Response<ShareDirectoryInfo> response = await directory.CreateAsync();

            // Assert
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            var accountName = new ShareUriBuilder(directory.Uri).AccountName;
            TestHelper.AssertCacheableProperty(accountName, () => directory.AccountName);
            TestHelper.AssertCacheableProperty(shareName, () => directory.ShareName);
            TestHelper.AssertCacheableProperty(directoryName, () => directory.Name);

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.That($"\"{response.GetRawResponse().Headers.ETag}\"", Is.EqualTo(response.Value.ETag.ToString()));
        }

        [RecordedTest]
        public async Task CreateAsync_FilePermission()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            ShareDirectoryCreateOptions options = new ShareDirectoryCreateOptions
            {
                FilePermission = new ShareFilePermission
                {
                    Permission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)"
                }
            };

            // Act
            Response<ShareDirectoryInfo> response = await directory.CreateAsync(options);

            // Assert
            AssertValidStorageDirectoryInfo(response);
        }

        [RecordedTest]
        [TestCase(null)]
        [TestCase(FilePermissionFormat.Sddl)]
        [TestCase(FilePermissionFormat.Binary)]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2024_11_04)]
        public async Task CreateAsync_FilePermissionFormat(FilePermissionFormat? filePermissionFormat)
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

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

            ShareDirectoryCreateOptions options = new ShareDirectoryCreateOptions
            {
                FilePermission = new ShareFilePermission
                {
                    Permission = permission,
                    PermissionFormat = filePermissionFormat
                }
            };

            // Act
            Response<ShareDirectoryInfo> response = await directory.CreateAsync(options);

            // Assert
            AssertValidStorageDirectoryInfo(response);
        }

        [RecordedTest]
        public async Task CreateAsync_FilePermissionAndFilePermissionKeySet()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            ShareDirectoryCreateOptions options = new ShareDirectoryCreateOptions
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
                directory.CreateAsync(options),
                e => Assert.That(e.Message, Is.EqualTo("filePermission and filePermissionKey cannot both be set")));
        }

        [RecordedTest]
        public async Task CreateAsync_FilePermissionTooLarge()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            ShareDirectoryCreateOptions options = new ShareDirectoryCreateOptions
            {
                FilePermission = new ShareFilePermission
                {
                    Permission = new string('*', 9 * Constants.KB)
                }
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                directory.CreateAsync(options),
                e =>
                {
                    Assert.That(e.ParamName, Is.EqualTo("filePermission"));
                    Assert.That(e.Message, Does.StartWith("Value must be less than or equal to 8192"));
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

            ShareDirectoryCreateOptions options = new ShareDirectoryCreateOptions
            {
                SmbProperties = new FileSmbProperties
                {
                    FilePermissionKey = createPermissionResponse.Value.FilePermissionKey,
                    FileAttributes = ShareModelExtensions.ToFileAttributes("Directory|ReadOnly"),
                    FileCreatedOn = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero),
                    FileLastWrittenOn = new DateTimeOffset(2019, 8, 26, 5, 15, 25, 60, TimeSpan.Zero),
                }
            };

            // Act
            Response<ShareDirectoryInfo> response = await directory.CreateAsync(options);

            // Assert
            AssertValidStorageDirectoryInfo(response);
            //Assert.AreEqual(smbProperties.FileAttributes, response.Value.SmbProperties.Value.FileAttributes);
            Assert.That(response.Value.SmbProperties.FileCreatedOn, Is.EqualTo(options.SmbProperties.FileCreatedOn));
            Assert.That(response.Value.SmbProperties.FileLastWrittenOn, Is.EqualTo(options.SmbProperties.FileLastWrittenOn));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_06_08)]
        public async Task CreateAsync_ChangeTime()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directoryClient = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));

            ShareDirectoryCreateOptions options = new ShareDirectoryCreateOptions
            {
                SmbProperties = new FileSmbProperties
                {
                    FileChangedOn = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero),
                }
            };

            // Act
            Response<ShareDirectoryInfo> response = await directoryClient.CreateAsync(options);

            // Assert
            AssertValidStorageDirectoryInfo(response);
            Assert.That(response.Value.SmbProperties.FileChangedOn, Is.EqualTo(options.SmbProperties.FileChangedOn));
        }

        [RecordedTest]
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
                e => Assert.That(e.ErrorCode, Is.EqualTo("ResourceAlreadyExists")));
        }

        [RecordedTest]
        public async Task CreateAsync_Metadata()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            ShareDirectoryCreateOptions options = new ShareDirectoryCreateOptions
            {
                Metadata = BuildMetadata()
            };

            // Act
            await directory.CreateAsync(options);

            // Assert
            Response<ShareDirectoryProperties> response = await directory.GetPropertiesAsync();
            AssertDictionaryEquality(options.Metadata, response.Value.Metadata);
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
            await using DisposingShare test = await GetTestShareAsync(options: options);
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient rootDirectory = InstrumentClient(share.GetRootDirectoryClient());
            string directoryName = GetNewDirectoryName();
            string directoryNameWithDot = directoryName + ".";
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(directoryNameWithDot));

            // Act
            await directory.CreateAsync();

            // Assert
            List<ShareFileItem> shareFileItems = new List<ShareFileItem>();
            await foreach (ShareFileItem item in rootDirectory.GetFilesAndDirectoriesAsync())
            {
                shareFileItems.Add(item);
            }
            Assert.That(shareFileItems.Count, Is.EqualTo(1));

            if (allowTrailingDot == true)
            {
                Assert.That(shareFileItems[0].Name, Is.EqualTo(directoryNameWithDot));
            }
            else
            {
                Assert.That(shareFileItems[0].Name, Is.EqualTo(directoryName));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2025_05_05)]
        public async Task CreateAsync_NFS()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync(nfs: true);
            ShareClient share = test.Share;

            // Arrange
            var name = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(name));

            string owner = "345";
            string group = "123";
            string fileMode = "7777";

            ShareDirectoryCreateOptions options = new ShareDirectoryCreateOptions
            {
                PosixProperties = new FilePosixProperties
                {
                    Owner = owner,
                    Group = group,
                    FileMode = NfsFileMode.ParseOctalFileMode(fileMode)
                }
            };

            // Act
            Response<ShareDirectoryInfo> response = await directory.CreateAsync(options);

            // Assert
            Assert.That(response.Value.PosixProperties.FileType, Is.EqualTo(NfsFileType.Directory));
            Assert.That(response.Value.PosixProperties.Owner, Is.EqualTo(owner));
            Assert.That(response.Value.PosixProperties.Group, Is.EqualTo(group));
            Assert.That(response.Value.PosixProperties.FileMode.ToOctalFileMode(), Is.EqualTo(fileMode));

            Assert.That(response.Value.SmbProperties.FileAttributes, Is.Null);
            Assert.That(response.Value.SmbProperties.FilePermissionKey, Is.Null);
        }

        //[TestCase(true)]
        //[TestCase(false)]
        //[RecordedTest]
        //[ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2026_02_06)]
        //public async Task CreateAsync_FilePropertySemantics(bool ifNotExists)
        //{
        //    // Arrange
        //    List<FilePropertySemantics?> filePropertySemanticsList = new List<FilePropertySemantics?>
        //    {
        //        null,
        //        FilePropertySemantics.New,
        //        FilePropertySemantics.Restore
        //    };

        //    foreach (FilePropertySemantics? filePropertySemantics in filePropertySemanticsList)
        //    {
        //        await using DisposingShare test = await GetTestShareAsync();
        //        ShareDirectoryClient directoryClient = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));

        //        ShareDirectoryCreateOptions options = new ShareDirectoryCreateOptions
        //        {
        //            PropertySemantics = filePropertySemantics
        //        };

        //        if (filePropertySemantics == FilePropertySemantics.Restore)
        //        {
        //            options.FilePermission = new ShareFilePermission
        //            {
        //                Permission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)"
        //            };
        //        }

        //        Response<ShareDirectoryInfo> response;

        //        // Act
        //        if (ifNotExists)
        //        {
        //            response = await directoryClient.CreateIfNotExistsAsync(options);
        //        }
        //        else
        //        {
        //            response = await directoryClient.CreateAsync(options);
        //        }
        //    }
        //}

        [RecordedTest]
        public async Task CreateIfNotExists_NotExists()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;
            string name = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(name));

            // Act
            Response<ShareDirectoryInfo> response = await directory.CreateIfNotExistsAsync();

            // Assert
            Assert.That(response, Is.Not.Null);
        }

        [RecordedTest]
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
            Assert.That(response, Is.Null);
        }

        [RecordedTest]
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
                e => Assert.That(e.ErrorCode, Is.EqualTo("NoAuthenticationInformation")));
        }

        [RecordedTest]
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
            Assert.That(response.Value, Is.False);
        }

        [RecordedTest]
        public async Task ExistsAsync_ShareNotExists()
        {
            // Arrange
            ShareServiceClient service = SharesClientBuilder.GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(GetNewShareName()));
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            Response<bool> response = await directory.ExistsAsync();

            // Assert
            Assert.That(response.Value, Is.False);
        }

        [RecordedTest]
        public async Task ExistsAsync_ParentDirectoryNotExists()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient parentDirectory = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
            ShareDirectoryClient directory = InstrumentClient(parentDirectory.GetSubdirectoryClient(GetNewDirectoryName()));

            // Act
            Response<bool> response = await directory.ExistsAsync();

            // Assert
            Assert.That(response.Value, Is.False);
        }

        [RecordedTest]
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
            Assert.That(response.Value, Is.True);
        }

        [RecordedTest]
        public async Task Exists_Error()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            // Make Read Only SAS for the Share
            AccountSasBuilder sas = new AccountSasBuilder
            {
                Services = AccountSasServices.Files,
                ResourceTypes = AccountSasResourceTypes.Service,
                ExpiresOn = Recording.UtcNow.AddHours(1)
            };
            sas.SetPermissions(AccountSasPermissions.Read);
            StorageSharedKeyCredential credential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);
            var sasUri = new ShareUriBuilder(new Uri(TestConfigDefault.FileServiceEndpoint))
            {
                ShareName = test.Share.Name
            };
            sasUri.Query = sas.ToSasQueryParameters(credential).ToString();
            ShareClient share = InstrumentClient(new ShareClient(sasUri.ToUri(), GetOptions()));
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.ExistsAsync(),
                e => { });
        }

        [RecordedTest]
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
            Assert.That(response.Value, Is.True);
        }

        [RecordedTest]
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
            Assert.That(response.Value, Is.False);
        }

        [RecordedTest]
        public async Task DeleteIfExists_ShareNotExists()
        {
            // Arrange
            ShareServiceClient service = SharesClientBuilder.GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient(service.GetShareClient(GetNewShareName()));
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            Response<bool> response = await directory.DeleteIfExistsAsync();

            // Assert
            Assert.That(response.Value, Is.False);
        }

        [RecordedTest]
        public async Task DeleteIfExists_ParentDirectoryNotExists()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient parentDirectory = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
            ShareDirectoryClient directory = InstrumentClient(parentDirectory.GetSubdirectoryClient(GetNewDirectoryName()));

            // Act
            Response<bool> response = await directory.DeleteIfExistsAsync();

            // Assert
            Assert.That(response.Value, Is.False);
        }

        [RecordedTest]
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
                e => Assert.That(e.ErrorCode, Is.EqualTo("DirectoryNotEmpty")));
        }

        [RecordedTest]
        public async Task DeleteAsync()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Act
            Response response = await directory.DeleteAsync();

            // Assert
            Assert.That(response.Headers.RequestId, Is.Not.Null);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task DeleteAsync_OAuth()
        {
            // Arrange
            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            // Act
            Response response = await directory.DeleteAsync();

            // Assert
            Assert.That(response.Headers.RequestId, Is.Not.Null);
        }

        [RecordedTest]
        public async Task DeleteAsync_Error()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.DeleteAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ResourceNotFound")));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task DeleteAsync_TrailingDot()
        {
            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = true;
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync(options: options);
            ShareDirectoryClient directory = test.Directory;

            // Act
            await directory.DeleteAsync();
        }

        [RecordedTest]
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
            Assert.That(getPropertiesResponse.Value.ETag, Is.EqualTo(createResponse.Value.ETag));
            Assert.That(getPropertiesResponse.Value.LastModified, Is.EqualTo(createResponse.Value.LastModified));
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

            // Act
            Response<ShareDirectoryInfo> createResponse = await directory.CreateIfNotExistsAsync();
            Response<ShareDirectoryProperties> getPropertiesResponse = await directory.GetPropertiesAsync();

            // Assert
            Assert.That(getPropertiesResponse.Value.ETag, Is.EqualTo(createResponse.Value.ETag));
            Assert.That(getPropertiesResponse.Value.LastModified, Is.EqualTo(createResponse.Value.LastModified));
            AssertPropertiesEqual(createResponse.Value.SmbProperties, getPropertiesResponse.Value.SmbProperties);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_Error()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.GetPropertiesAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ResourceNotFound")));
        }

        [RecordedTest]
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
            Assert.That(getPropertiesResponse.Value.ETag, Is.Not.Null);
        }

        [RecordedTest]
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
                e => Assert.That(e.ErrorCode, Is.EqualTo(ShareErrorCode.ShareNotFound.ToString())));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task GetPropertiesAsync_TrailingDot()
        {
            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = true;
            await using DisposingShare test = await GetTestShareAsync(options: options);
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            Response<ShareDirectoryInfo> createResponse = await directory.CreateIfNotExistsAsync();
            Response<ShareDirectoryProperties> getPropertiesResponse = await directory.GetPropertiesAsync();

            // Assert
            Assert.That(getPropertiesResponse.Value.ETag, Is.EqualTo(createResponse.Value.ETag));
            Assert.That(getPropertiesResponse.Value.LastModified, Is.EqualTo(createResponse.Value.LastModified));
            AssertPropertiesEqual(createResponse.Value.SmbProperties, getPropertiesResponse.Value.SmbProperties);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2025_05_05)]
        public async Task GetPropertiesAsync_NFS()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync(nfs: true);

            // Act
            Response<ShareDirectoryProperties> response = await test.Directory.GetPropertiesAsync();

            // Assert
            Assert.That(response.Value.PosixProperties.FileType, Is.EqualTo(NfsFileType.Directory));
            Assert.That(response.Value.PosixProperties.Owner, Is.EqualTo("0"));
            Assert.That(response.Value.PosixProperties.Group, Is.EqualTo("0"));
            Assert.That(response.Value.PosixProperties.FileMode.ToOctalFileMode(), Is.EqualTo("0755"));

            Assert.That(response.Value.PosixProperties.LinkCount, Is.Null);
            Assert.That(response.Value.SmbProperties.FileAttributes, Is.Null);
            Assert.That(response.Value.SmbProperties.FilePermissionKey, Is.Null);
        }

        [RecordedTest]
        public async Task SetHttpHeadersAsync()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            await directory.CreateIfNotExistsAsync();

            // Act
            Response<ShareDirectoryInfo> response = await directory.SetHttpHeadersAsync();

            // Assert
            AssertValidStorageDirectoryInfo(response);
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.That($"\"{response.GetRawResponse().Headers.ETag}\"", Is.EqualTo(response.Value.ETag.ToString()));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task SetHttpHeadersAsync_OAuth()
        {
            // Arrange
            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            // Act
            Response<ShareDirectoryInfo> response = await directory.SetHttpHeadersAsync();

            // Assert
            AssertValidStorageDirectoryInfo(response);
            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.That($"\"{response.GetRawResponse().Headers.ETag}\"", Is.EqualTo(response.Value.ETag.ToString()));
        }

        [RecordedTest]
        public async Task SetPropertiesAsync_FilePermission()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            string filePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
            await directory.CreateIfNotExistsAsync();

            ShareDirectorySetHttpHeadersOptions options = new ShareDirectorySetHttpHeadersOptions
            {
                FilePermission = new ShareFilePermission
                {
                    Permission = filePermission
                }
            };

            // Act
            Response<ShareDirectoryInfo> response = await directory.SetHttpHeadersAsync(options);

            // Assert
            AssertValidStorageDirectoryInfo(response);
        }

        [RecordedTest]
        [TestCase(null)]
        [TestCase(FilePermissionFormat.Sddl)]
        [TestCase(FilePermissionFormat.Binary)]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2024_11_04)]
        public async Task SetPropertiesAsync_FilePermissionFormat(FilePermissionFormat? filePermissionFormat)
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            await directory.CreateIfNotExistsAsync();

            string permission;
            if (filePermissionFormat == null || filePermissionFormat == FilePermissionFormat.Sddl)
            {
                permission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)S:NO_ACCESS_CONTROL";
            }
            else
            {
                permission = "AQAUhGwAAACIAAAAAAAAABQAAAACAFgAAwAAAAAAFAD/AR8AAQEAAAAAAAUSAAAAAAAYAP8BHwABAgAAAAAABSAAAAAgAgAAAAAkAKkAEgABBQAAAAAABRUAAABZUbgXZnJdJWRjOwuMmS4AAQUAAAAAAAUVAAAAoGXPfnhLm1/nfIdwr/1IAQEFAAAAAAAFFQAAAKBlz354S5tf53yHcAECAAA=";
            }

            ShareDirectorySetHttpHeadersOptions options = new ShareDirectorySetHttpHeadersOptions
            {
                FilePermission = new ShareFilePermission
                {
                    Permission = permission,
                    PermissionFormat = filePermissionFormat
                }
            };

            // Act
            Response<ShareDirectoryInfo> response = await directory.SetHttpHeadersAsync(options);

            // Assert
            AssertValidStorageDirectoryInfo(response);
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
            ShareDirectorySetHttpHeadersOptions options = new ShareDirectorySetHttpHeadersOptions
            {
                SmbProperties = new FileSmbProperties
                {
                    FilePermissionKey = createPermissionResponse.Value.FilePermissionKey,
                    FileAttributes = ShareModelExtensions.ToFileAttributes("Directory|ReadOnly"),
                    FileCreatedOn = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero),
                    FileLastWrittenOn = new DateTimeOffset(2019, 8, 26, 5, 15, 25, 60, TimeSpan.Zero),
                }
            };

            await directory.CreateIfNotExistsAsync();

            // Act
            Response<ShareDirectoryInfo> response = await directory.SetHttpHeadersAsync(options);

            // Assert
            AssertValidStorageDirectoryInfo(response);
            Assert.That(response.Value.SmbProperties.FileAttributes, Is.EqualTo(options.SmbProperties.FileAttributes));
            Assert.That(response.Value.SmbProperties.FileCreatedOn, Is.EqualTo(options.SmbProperties.FileCreatedOn));
            Assert.That(response.Value.SmbProperties.FileLastWrittenOn, Is.EqualTo(options.SmbProperties.FileLastWrittenOn));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_06_08)]
        public async Task SetPropertiesAsync_ChangeTime()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();

            ShareDirectoryClient directoryClient = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
            ShareDirectorySetHttpHeadersOptions options = new ShareDirectorySetHttpHeadersOptions
            {
                SmbProperties = new FileSmbProperties
                {
                    FileChangedOn = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero),
                }
            };

            await directoryClient.CreateIfNotExistsAsync();

            // Act
            Response<ShareDirectoryInfo> response = await directoryClient.SetHttpHeadersAsync(options);

            // Assert
            AssertValidStorageDirectoryInfo(response);
            Assert.That(response.Value.SmbProperties.FileChangedOn, Is.EqualTo(options.SmbProperties.FileChangedOn));
        }

        [RecordedTest]
        public async Task SetPropertiesAsync_FilePermissionTooLong()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            ShareDirectorySetHttpHeadersOptions options = new ShareDirectorySetHttpHeadersOptions
            {
                FilePermission = new ShareFilePermission
                {
                    Permission = new string('*', 9 * Constants.KB)
                }
            };
            await directory.CreateIfNotExistsAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                directory.SetHttpHeadersAsync(options),
                new ArgumentOutOfRangeException("filePermission", "Value must be less than or equal to 8192"));
        }

        [RecordedTest]
        public async Task SetPropertiesAsync_FilePermissionAndFilePermissionKeySet()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            await directory.CreateIfNotExistsAsync();
            ShareDirectorySetHttpHeadersOptions options = new ShareDirectorySetHttpHeadersOptions
            {
                SmbProperties = new FileSmbProperties
                {
                    FilePermissionKey = "filePermissionKey"
                },
                FilePermission = new ShareFilePermission
                {
                    Permission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)"
                }
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                directory.SetHttpHeadersAsync(options),
                e => Assert.That(e.Message, Is.EqualTo("filePermission and filePermissionKey cannot both be set")));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task SetHttpHeadersAsync_TrailingDot()
        {
            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = true;
            await using DisposingShare test = await GetTestShareAsync(options: options);
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            await directory.CreateIfNotExistsAsync();

            // Act
            await directory.SetHttpHeadersAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2025_05_05)]
        public async Task SetHttpHeadersAsync_NFS()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync(nfs: true);

            string owner = "345";
            string group = "123";
            string fileMode = "7777";

            ShareDirectorySetHttpHeadersOptions options = new ShareDirectorySetHttpHeadersOptions
            {
                PosixProperties = new FilePosixProperties
                {
                    Owner = owner,
                    Group = group,
                    FileMode = NfsFileMode.ParseOctalFileMode(fileMode)
                }
            };

            // Act
            Response<ShareDirectoryInfo> response = await test.Directory.SetHttpHeadersAsync(options);

            // Assert
            Assert.That(response.Value.PosixProperties.Owner, Is.EqualTo(owner));
            Assert.That(response.Value.PosixProperties.Group, Is.EqualTo(group));
            Assert.That(response.Value.PosixProperties.FileMode.ToOctalFileMode(), Is.EqualTo(fileMode));

            Assert.That(response.Value.PosixProperties.LinkCount, Is.Null);
            Assert.That(response.Value.SmbProperties.FileAttributes, Is.Null);
            Assert.That(response.Value.SmbProperties.FilePermissionKey, Is.Null);
        }

        [RecordedTest]
        public async Task SetMetadataAsync()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            Response<ShareDirectoryInfo> setMetadataResponse = await directory.SetMetadataAsync(metadata);
            Assert.That(setMetadataResponse.Value.LastModified, Is.Not.EqualTo(DateTimeOffset.MinValue));

            // Assert
            Response<ShareDirectoryProperties> response = await directory.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task SetMetadataAsync_OAuth()
        {
            // Arrange
            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            Response<ShareDirectoryInfo> setMetadataResponse = await directory.SetMetadataAsync(metadata);
            Assert.That(setMetadataResponse.Value.LastModified, Is.Not.EqualTo(DateTimeOffset.MinValue));

            // Assert
            Response<ShareDirectoryProperties> response = await directory.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
        }

        [RecordedTest]
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
                e => Assert.That(e.ErrorCode, Is.EqualTo("ResourceNotFound")));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task SetMetadataAsync_TrailingDot()
        {
            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = true;
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync(options: options);
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            Response<ShareDirectoryInfo> setMetadataResponse = await directory.SetMetadataAsync(metadata);
            Assert.That(setMetadataResponse.Value.LastModified, Is.Not.EqualTo(DateTimeOffset.MinValue));

            // Assert
            Response<ShareDirectoryProperties> response = await directory.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
        }

        [RecordedTest]
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
            Assert.That(directories.Count, Is.EqualTo(directoryNames.Length));
            Assert.That(files.Count, Is.EqualTo(fileNames.Length));

            var foundDirectoryNames = directories.Select(entry => entry.Name).ToArray();
            var foundFileNames = files.Select(entry => entry.Name).ToArray();

            Assert.That(directoryNames.All(fileName => foundDirectoryNames.Contains(fileName)), Is.True);
            Assert.That(fileNames.All(fileName => foundFileNames.Contains(fileName)), Is.True);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task ListFilesAndDirectoriesSegmentAsync_OAuth()
        {
            // Arrange
            var numFiles = 10;
            var fileNames = Enumerable.Range(0, numFiles).Select(_ => GetNewFileName()).ToArray();

            var numDirectories = 5;
            var directoryNames = Enumerable.Range(0, numDirectories).Select(_ => GetNewFileName()).ToArray();

            string shareName = GetNewShareName();
            ShareServiceClient sharedKeyServiceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
            await using DisposingShare sharedKeyShare = await GetTestShareAsync(sharedKeyServiceClient, shareName);
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();

            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await directory.CreateAsync();

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
            Assert.That(directories.Count, Is.EqualTo(directoryNames.Length));
            Assert.That(files.Count, Is.EqualTo(fileNames.Length));

            var foundDirectoryNames = directories.Select(entry => entry.Name).ToArray();
            var foundFileNames = files.Select(entry => entry.Name).ToArray();

            Assert.That(directoryNames.All(fileName => foundDirectoryNames.Contains(fileName)), Is.True);
            Assert.That(fileNames.All(fileName => foundFileNames.Contains(fileName)), Is.True);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2020_10_02)]
        public async Task ListFilesAndDirectoriesAsync_Include()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient parentDirectoryClient = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
            await parentDirectoryClient.CreateAsync();
            string fileName = GetNewFileName();
            ShareFileClient fileClient = InstrumentClient(parentDirectoryClient.GetFileClient(fileName));
            await fileClient.CreateAsync(Constants.KB);
            string directoryName = GetNewDirectoryName();
            ShareDirectoryClient directoryClient = InstrumentClient(parentDirectoryClient.GetSubdirectoryClient(directoryName));
            await directoryClient.CreateAsync();

            // Act
            List<ShareFileItem> shareFileItems = new List<ShareFileItem>();
            ShareDirectoryGetFilesAndDirectoriesOptions options = new ShareDirectoryGetFilesAndDirectoriesOptions
            {
                Traits = ShareFileTraits.All,
                IncludeExtendedInfo = true
            };
            await foreach (ShareFileItem shareFileItem in parentDirectoryClient.GetFilesAndDirectoriesAsync(options))
            {
                shareFileItems.Add(shareFileItem);
            }

            // Assert
            Assert.That(shareFileItems[0].Name, Is.EqualTo(directoryName));
            Assert.That(shareFileItems[0].IsDirectory, Is.True);
            Assert.That(shareFileItems[0].Id, Is.Not.Null);
            Assert.That(shareFileItems[0].FileAttributes, Is.EqualTo(NtfsFileAttributes.Directory));
            Assert.That(shareFileItems[0].PermissionKey, Is.Not.Null);

            Assert.That(shareFileItems[0].Properties.CreatedOn, Is.Not.Null);
            Assert.That(shareFileItems[0].Properties.LastAccessedOn, Is.Not.Null);
            Assert.That(shareFileItems[0].Properties.LastWrittenOn, Is.Not.Null);
            Assert.That(shareFileItems[0].Properties.ChangedOn, Is.Not.Null);
            Assert.That(shareFileItems[0].Properties.LastModified, Is.Not.Null);
            Assert.That(shareFileItems[0].Properties.ETag, Is.Not.Null);

            Assert.That(shareFileItems[1].Name, Is.EqualTo(fileName));
            Assert.That(shareFileItems[1].IsDirectory, Is.False);
            Assert.That(shareFileItems[1].Id, Is.Not.Null);
            Assert.That(shareFileItems[1].FileAttributes, Is.EqualTo(NtfsFileAttributes.Archive));
            Assert.That(shareFileItems[1].PermissionKey, Is.Not.Null);

            Assert.That(shareFileItems[1].Properties.CreatedOn, Is.Not.Null);
            Assert.That(shareFileItems[1].Properties.LastAccessedOn, Is.Not.Null);
            Assert.That(shareFileItems[1].Properties.LastWrittenOn, Is.Not.Null);
            Assert.That(shareFileItems[1].Properties.ChangedOn, Is.Not.Null);
            Assert.That(shareFileItems[1].Properties.LastModified, Is.Not.Null);
            Assert.That(shareFileItems[1].Properties.ETag, Is.Not.Null);
        }

        [RecordedTest]
        public async Task ListFilesAndDirectoriesSegmentAsync_Error()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.GetFilesAndDirectoriesAsync().ToListAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ResourceNotFound")));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_12_02)]
        public async Task ListFilesAndDirectories_Encoded()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directoryClient = await test.Share.CreateDirectoryAsync(GetNewDirectoryName());
            string specialCharDirectoryName = "directory\uFFFE";
            string specialCharFileName = "file\uFFFE";
            await directoryClient.CreateSubdirectoryAsync(specialCharDirectoryName);
            await directoryClient.CreateFileAsync(specialCharFileName, maxSize: 1024);

            // Act
            List<ShareFileItem> shareFileItems = new List<ShareFileItem>();

            await foreach (ShareFileItem item in directoryClient.GetFilesAndDirectoriesAsync())
            {
                shareFileItems.Add(item);
            }

            // Assert
            Assert.That(shareFileItems.Count, Is.EqualTo(2));
            Assert.That(shareFileItems[0].IsDirectory, Is.True);
            Assert.That(shareFileItems[0].Name, Is.EqualTo(specialCharDirectoryName));
            Assert.That(shareFileItems[1].IsDirectory, Is.False);
            Assert.That(shareFileItems[1].Name, Is.EqualTo(specialCharFileName));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_12_02)]
        public async Task ListFilesAndDirectories_Encoded_ContinutationToken()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directoryClient = await test.Share.CreateDirectoryAsync(GetNewDirectoryName());
            string specialCharFileName0 = "file0\uFFFE";
            string specialCharFileName1 = "file1\uFFFE";
            await directoryClient.CreateFileAsync(specialCharFileName0, maxSize: 1024);
            await directoryClient.CreateFileAsync(specialCharFileName1, maxSize: 1024);

            // Act
            List<ShareFileItem> shareFileItems = new List<ShareFileItem>();

            await foreach (Page<ShareFileItem> page in directoryClient.GetFilesAndDirectoriesAsync().AsPages(pageSizeHint: 1))
            {
                shareFileItems.AddRange(page.Values);
            }

            // Assert
            Assert.That(shareFileItems.Count, Is.EqualTo(2));
            Assert.That(shareFileItems[0].Name, Is.EqualTo(specialCharFileName0));
            Assert.That(shareFileItems[1].Name, Is.EqualTo(specialCharFileName1));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_12_02)]
        public async Task ListFilesAndDirectories_Encoded_Prefix()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directoryClient = await test.Share.CreateDirectoryAsync(GetNewDirectoryName());
            string specialCharDirectoryName = "directory\uFFFE";
            ShareDirectoryClient specialCharDirectoryClient = await directoryClient.CreateSubdirectoryAsync(specialCharDirectoryName);

            // Act
            List<ShareFileItem> shareFileItems = new List<ShareFileItem>();
            ShareDirectoryGetFilesAndDirectoriesOptions options = new ShareDirectoryGetFilesAndDirectoriesOptions
            {
                Prefix = specialCharDirectoryName
            };

            await foreach (ShareFileItem item in directoryClient.GetFilesAndDirectoriesAsync(options))
            {
                shareFileItems.Add(item);
            }

            // Assert
            Assert.That(shareFileItems.Count, Is.EqualTo(1));
            Assert.That(shareFileItems[0].Name, Is.EqualTo(specialCharDirectoryName));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task ListFilesAndDirectories_TrailingDot()
        {
            // Arrange
            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = true;
            await using DisposingShare test = await GetTestShareAsync(options: options);
            ShareDirectoryClient directoryClient = await test.Share.CreateDirectoryAsync(GetNewDirectoryName() + ".");

            // Act
            List<ShareFileItem> shareFileItems = new List<ShareFileItem>();

            await foreach (ShareFileItem item in directoryClient.GetFilesAndDirectoriesAsync())
            {
                shareFileItems.Add(item);
            }
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task ListHandles()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Act
            var handles = (await directory.GetHandlesAsync(recursive: true)
                .AsPages(pageSizeHint: 5)
                .ToListAsync())
                .SelectMany(p => p.Values)
                .ToList();

            // Assert
            Assert.That(handles.Count, Is.EqualTo(0));
        }

        [RecordedTest]
        public async Task ListHandles_Min()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Act
            IList<ShareFileHandle> handles = await directory.GetHandlesAsync().ToListAsync();

            // Assert
            Assert.That(handles.Count, Is.EqualTo(0));
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

            // Act
            IList<ShareFileHandle> handles = await directory.GetHandlesAsync().ToListAsync();

            // Assert
            Assert.That(handles.Count, Is.EqualTo(0));
        }

        [RecordedTest]
        public async Task ListHandles_Error()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.GetHandlesAsync().ToListAsync(),
                actualException => Assert.That(actualException.ErrorCode, Is.EqualTo("ResourceNotFound")));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task ListHandles_TrailingDot()
        {
            // Arrange
            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = true;
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync(options: options);
            ShareDirectoryClient directory = test.Directory;

            // Act
            IList<ShareFileHandle> handles = await directory.GetHandlesAsync().ToListAsync();

            // Assert
            Assert.That(handles.Count, Is.EqualTo(0));
        }

        [RecordedTest]
        public async Task ForceCloseHandles_Min()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Act
            CloseHandlesResult response = await directory.ForceCloseAllHandlesAsync();

            // Assert
            Assert.That(response.ClosedHandlesCount, Is.EqualTo(0));
            Assert.That(response.FailedHandlesCount, Is.EqualTo(0));
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

            // Act
            CloseHandlesResult response = await directory.ForceCloseAllHandlesAsync();

            // Assert
            Assert.That(response.ClosedHandlesCount, Is.EqualTo(0));
            Assert.That(response.FailedHandlesCount, Is.EqualTo(0));
        }

        [RecordedTest]
        public async Task ForceCloseHandles_Recursive()
        {
            // Arrange
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Act
            CloseHandlesResult response = await directory.ForceCloseAllHandlesAsync(recursive: true);

            // Assert
            Assert.That(response.ClosedHandlesCount, Is.EqualTo(0));
            Assert.That(response.FailedHandlesCount, Is.EqualTo(0));
        }

        [RecordedTest]
        public async Task ForceCloseHandles_Error()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.ForceCloseAllHandlesAsync(),
                actualException => Assert.That(actualException.ErrorCode, Is.EqualTo("ResourceNotFound")));
        }

        [RecordedTest]
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
                actualException => Assert.That(actualException.ErrorCode, Is.EqualTo("InvalidHeaderValue")));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2022_11_02)]
        public async Task ForceCloseHandles_TrailingDot()
        {
            // Arrange
            ShareClientOptions options = GetOptions();
            options.AllowTrailingDot = true;
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync(options: options);
            ShareDirectoryClient directory = test.Directory;

            // Act
            CloseHandlesResult response = await directory.ForceCloseAllHandlesAsync();

            // Assert
            Assert.That(response.ClosedHandlesCount, Is.EqualTo(0));
            Assert.That(response.FailedHandlesCount, Is.EqualTo(0));
        }

        [RecordedTest]
        public async Task CreateSubdirectoryAsync()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient dir = test.Directory;

            ShareDirectoryClient subdir = (await dir.CreateSubdirectoryAsync(GetNewDirectoryName())).Value;

            Response<ShareDirectoryProperties> properties = await subdir.GetPropertiesAsync();
            Assert.That(properties.Value, Is.Not.Null);
        }

        [RecordedTest]
        public async Task DeleteSubdirectoryAsync()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient dir = test.Directory;

            var name = GetNewDirectoryName();
            ShareDirectoryClient subdir = (await dir.CreateSubdirectoryAsync(name)).Value;

            await dir.DeleteSubdirectoryAsync(name);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await subdir.GetPropertiesAsync());
        }

        [RecordedTest]
        public async Task CreateFileAsync()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient dir = test.Directory;

            ShareFileClient file = (await dir.CreateFileAsync(GetNewFileName(), 1024)).Value;

            Response<ShareFileProperties> properties = await file.GetPropertiesAsync();
            Assert.That(properties.Value, Is.Not.Null);
        }

        [RecordedTest]
        public async Task DeleteFileAsync()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
            ShareDirectoryClient dir = test.Directory;

            var name = GetNewFileName();
            ShareFileClient file = (await dir.CreateFileAsync(name, 1024)).Value;

            await dir.DeleteFileAsync(name);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await file.GetPropertiesAsync());
        }

        [RecordedTest]
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
            Assert.That(names.Count, Is.EqualTo(1));
            Assert.That(names, Does.Contain(name));
        }

        [RecordedTest]
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
            Assert.That(names.Count, Is.EqualTo(1));
            Assert.That(names, Does.Contain(name));
        }

        [RecordedTest]
        public async Task GetSubdirectoryAsync_AsciiName()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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
            Assert.That(names.Count, Is.EqualTo(1));
            Assert.That(names, Does.Contain(name));
        }

        [RecordedTest]
        public async Task GetSubdirectoryAsync_NonAsciiName()
        {
            await using DisposingDirectory test = await SharesClientBuilder.GetTestDirectoryAsync();
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
            Assert.That(names.Count, Is.EqualTo(1));
            Assert.That(names, Does.Contain(name));
        }

        [RecordedTest]
        [TestCase("directory", "!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("!'();[]", "!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("%21%27%28%29", "!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("directory", "%2C%23äÄöÖüÜß%3B")]
        [TestCase("!'();[]", "%21%27%28%29%3B%5B%23äÄöÖüÜß%3B")]
        [TestCase("%21%27%28%29%3B%5B%5D", "%2B%24%2C%23äÄöÖüÜß%3B")]
        [TestCase("directory", "my cool file")]
        [TestCase("directory", "file")]
        [TestCase("  ", "  ")]
        [RetryOnException(5, typeof(RequestFailedException))]
        public async Task GetFileClient_SpecialCharacters(string directoryName, string fileName)
        {
            await using DisposingShare test = await GetTestShareAsync();
            string path = $"{directoryName}/{fileName}";
            ShareDirectoryClient directoryClient = test.Share.GetDirectoryClient(directoryName);
            await directoryClient.CreateAsync();
            ShareFileClient fileFromDirectoryClient = InstrumentClient(directoryClient.GetFileClient(fileName));
            Response<ShareFileInfo> createResponse = await fileFromDirectoryClient.CreateAsync(Constants.KB);

            Uri expectedUri = new Uri($"{TestConfigDefault.FileServiceEndpoint}/{test.Share.Name}/{Uri.EscapeDataString(directoryName)}/{Uri.EscapeDataString(fileName)}");

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
            Assert.That(propertiesResponse.Value.ETag, Is.EqualTo(createResponse.Value.ETag));

            Assert.That(shareFileItems.Count, Is.EqualTo(1));
            Assert.That(shareFileItems[0].Name, Is.EqualTo(fileName));

            Assert.That(fileFromDirectoryClient.Name, Is.EqualTo(fileName));
            Assert.That(fileFromDirectoryClient.Path, Is.EqualTo(path));
            Assert.That(fileFromDirectoryClient.Uri, Is.EqualTo(expectedUri));

            Assert.That(fileFromConstructor.Name, Is.EqualTo(fileName));
            Assert.That(fileFromConstructor.Path, Is.EqualTo(path));
            Assert.That(fileFromConstructor.Uri, Is.EqualTo(expectedUri));

            Assert.That(shareUriBuilder.LastDirectoryOrFileName, Is.EqualTo(fileName));
            Assert.That(shareUriBuilder.DirectoryOrFilePath, Is.EqualTo(path));
            Assert.That(shareUriBuilder.ToUri(), Is.EqualTo(expectedUri));
        }

        [RecordedTest]
        [TestCase("directory", "!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("!'();[]@&%=+$", "!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("%21%27%28%29%3B%5B%5D", "!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("directory", "%21%27%28%2B%24%2C%23äÄöÖüÜß%3B")]
        [TestCase("!'();[]@&%=+$", "%21%27%24%2C%23äÄöÖüÜß%3B")]
        [TestCase("%21%27%28", "%21%27%28%29%3B%5B%5D%40%26äÄöÖüÜß%3B")]
        [TestCase("directory", "my cool directory")]
        [TestCase("directory0", "directory1")]
        [TestCase(" ", " ")]
        public async Task GetSubDirectoryClient_SpecialCharacters(string directoryName, string subDirectoryName)
        {
            await using DisposingShare test = await GetTestShareAsync();
            string path = $"{directoryName}/{subDirectoryName}";
            ShareDirectoryClient directoryClient = test.Share.GetDirectoryClient(directoryName);
            await directoryClient.CreateAsync();
            ShareDirectoryClient directoryFromDirectoryClient = InstrumentClient(directoryClient.GetSubdirectoryClient(subDirectoryName));
            Response<ShareDirectoryInfo> createResponse = await directoryFromDirectoryClient.CreateAsync();

            Uri expectedUri = new Uri($"{TestConfigDefault.FileServiceEndpoint}/{test.Share.Name}/{Uri.EscapeDataString(directoryName)}/{Uri.EscapeDataString(subDirectoryName)}");

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
            Assert.That(propertiesResponse.Value.ETag, Is.EqualTo(createResponse.Value.ETag));

            Assert.That(shareFileItems.Count, Is.EqualTo(1));
            Assert.That(shareFileItems[0].Name, Is.EqualTo(subDirectoryName));

            Assert.That(directoryFromDirectoryClient.Name, Is.EqualTo(subDirectoryName));
            Assert.That(directoryFromDirectoryClient.Path, Is.EqualTo(path));
            Assert.That(directoryFromDirectoryClient.Uri, Is.EqualTo(expectedUri));

            Assert.That(directoryFromConstructor.Name, Is.EqualTo(subDirectoryName));
            Assert.That(directoryFromConstructor.Path, Is.EqualTo(path));
            Assert.That(directoryFromConstructor.Uri, Is.EqualTo(expectedUri));

            Assert.That(shareUriBuilder.LastDirectoryOrFileName, Is.EqualTo(subDirectoryName));
            Assert.That(shareUriBuilder.DirectoryOrFilePath, Is.EqualTo(path));
            Assert.That(shareUriBuilder.ToUri(), Is.EqualTo(expectedUri));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task RenameAsync()
        {
            // Arrange
            await using DisposingShare test = await SharesClientBuilder.GetTestShareAsync();
            string destDirectoryName = GetNewDirectoryName();
            ShareDirectoryClient sourceDirectory = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
            await sourceDirectory.CreateAsync();

            // Act
            ShareDirectoryClient destDirectory = await sourceDirectory.RenameAsync(destDirectoryName);

            // Assert
            await destDirectory.GetPropertiesAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task RenameAsync_Metadata()
        {
            // Arrange
            await using DisposingShare test = await SharesClientBuilder.GetTestShareAsync();
            string destDirectoryName = GetNewDirectoryName();
            ShareDirectoryClient sourceDirectory = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
            await sourceDirectory.CreateAsync();

            IDictionary<string, string> metadata = BuildMetadata();

            ShareFileRenameOptions options = new ShareFileRenameOptions
            {
                Metadata = metadata
            };

            // Act
            ShareDirectoryClient destDirectory = await sourceDirectory.RenameAsync(
                destinationPath: destDirectoryName,
                options: options);

            // Assert
            Response<ShareDirectoryProperties> response = await destDirectory.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task RenameAsync_DifferentDirectory()
        {
            // Arrange
            await using DisposingShare test = await SharesClientBuilder.GetTestShareAsync();
            ShareDirectoryClient sourceParentDirectory = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
            await sourceParentDirectory.CreateAsync();
            ShareDirectoryClient sourceDirectory = InstrumentClient(sourceParentDirectory.GetSubdirectoryClient(GetNewDirectoryName()));
            await sourceDirectory.CreateAsync();

            ShareDirectoryClient destParentDirectory = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
            await destParentDirectory.CreateAsync();

            string destDirectoryName = GetNewDirectoryName();

            // Act
            ShareDirectoryClient destDirectory = await sourceDirectory.RenameAsync(destParentDirectory.Name + "/" + destDirectoryName);

            // Assert
            await destDirectory.GetPropertiesAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RenameAsync_ReplaceIfExists(bool replaceIfExists)
        {
            // Arrange
            await using DisposingShare test = await SharesClientBuilder.GetTestShareAsync();
            ShareDirectoryClient sourceDir = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
            await sourceDir.CreateAsync();
            ShareDirectoryClient destParentDirectory = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
            await destParentDirectory.CreateAsync();
            ShareFileClient destFile = InstrumentClient(destParentDirectory.GetFileClient(GetNewFileName()));
            await destFile.CreateAsync(Constants.KB);

            ShareFileRenameOptions options = new ShareFileRenameOptions
            {
                ReplaceIfExists = replaceIfExists
            };

            // Act
            if (replaceIfExists)
            {
                ShareDirectoryClient destDir = await sourceDir.RenameAsync(
                    destinationPath: destParentDirectory.Name + "/" + destFile.Name,
                    options: options);

                // Assert
                Response<ShareDirectoryProperties> response = await destDir.GetPropertiesAsync();
            }
            else
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    sourceDir.RenameAsync(
                    destinationPath: destParentDirectory.Name + "/" + destFile.Name,
                    options: options),
                    e => Assert.That(e.ErrorCode, Is.EqualTo(ShareErrorCode.ResourceAlreadyExists.ToString())));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RenameAsync_IgnoreReadOnly(bool ignoreReadOnly)
        {
            // Arrange
            await using DisposingShare test = await SharesClientBuilder.GetTestShareAsync();
            ShareDirectoryClient sourceDir = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
            await sourceDir.CreateAsync();
            ShareDirectoryClient destParentDirectory = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
            await destParentDirectory.CreateAsync();
            ShareFileClient destFile = InstrumentClient(destParentDirectory.GetFileClient(GetNewFileName()));

            ShareFileCreateOptions fileCreateOptions = new ShareFileCreateOptions
            {
                SmbProperties = new FileSmbProperties
                {
                    FileAttributes = NtfsFileAttributes.ReadOnly
                }
            };
            await destFile.CreateAsync(
                maxSize: Constants.KB,
                options: fileCreateOptions);

            ShareFileRenameOptions options = new ShareFileRenameOptions
            {
                ReplaceIfExists = true,
                IgnoreReadOnly = ignoreReadOnly,
                SmbProperties = new FileSmbProperties
                {
                    FileAttributes = NtfsFileAttributes.Directory
                }
            };

            // Act
            if (ignoreReadOnly)
            {
                ShareDirectoryClient destDirectory = await sourceDir.RenameAsync(
                    destinationPath: destParentDirectory.Name + "/" + destFile.Name,
                    options: options);

                // Assert
                Response<ShareDirectoryProperties> response = await destDirectory.GetPropertiesAsync();
            }
            else
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    sourceDir.RenameAsync(
                    destinationPath: destParentDirectory.Name + "/" + destFile.Name,
                    options: options),
                    e => Assert.That(e.ErrorCode, Is.EqualTo(ShareErrorCode.ReadOnlyAttribute.ToString())));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RenameAsync_DestinationLeaseId(bool includeLeaseId)
        {
            // Arrange
            await using DisposingShare test = await SharesClientBuilder.GetTestShareAsync();
            ShareDirectoryClient sourceDir = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
            await sourceDir.CreateAsync();

            ShareDirectoryClient destParentDir = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
            await destParentDir.CreateAsync();
            ShareFileClient destFile = InstrumentClient(destParentDir.GetFileClient(GetNewFileName()));
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
                ShareDirectoryClient destDir = await sourceDir.RenameAsync(
                    destinationPath: destParentDir.Name + "/" + destFile.Name,
                    options: options);

                // Assert
                await destDir.GetPropertiesAsync();
            }
            else
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    sourceDir.RenameAsync(
                    destinationPath: destParentDir.Name + "/" + destFile.Name,
                    options: options),
                    e => Assert.That(e.ErrorCode, Is.EqualTo("LeaseIdMissing")));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task RenameAsync_NonAsciiSourceAndDestination()
        {
            // Arrange
            await using DisposingShare test = await SharesClientBuilder.GetTestShareAsync();
            ShareDirectoryClient sourceDir = InstrumentClient(test.Share.GetDirectoryClient(GetNewNonAsciiDirectoryName()));
            await sourceDir.CreateAsync();

            string destDirName = GetNewNonAsciiDirectoryName();

            // Act
            ShareDirectoryClient destDir = await sourceDir.RenameAsync(destinationPath: destDirName);

            // Assert
            await destDir.GetPropertiesAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task RenameAsync_FilePermission()
        {
            // Arrange
            await using DisposingShare test = await SharesClientBuilder.GetTestShareAsync();
            ShareDirectoryClient sourceDir = InstrumentClient(test.Share.GetDirectoryClient(GetNewNonAsciiDirectoryName()));
            await sourceDir.CreateAsync();

            string destDirName = GetNewDirectoryName();

            ShareFileRenameOptions options = new ShareFileRenameOptions
            {
                FilePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)"
            };

            // Act
            ShareDirectoryClient destDir = await sourceDir.RenameAsync(
                destinationPath: destDirName,
                options: options);

            Response<ShareDirectoryProperties> propertiesResponse = await destDir.GetPropertiesAsync();

            // Assert
            Assert.That(propertiesResponse.Value.SmbProperties.FilePermissionKey, Is.Not.Null);
        }

        [RecordedTest]
        [TestCase(null)]
        [TestCase(FilePermissionFormat.Sddl)]
        [TestCase(FilePermissionFormat.Binary)]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2024_11_04)]
        public async Task RenameAsync_FilePermissionFormat(FilePermissionFormat? filePermissionFormat)
        {
            // Arrange
            await using DisposingShare test = await SharesClientBuilder.GetTestShareAsync();
            ShareDirectoryClient sourceDir = InstrumentClient(test.Share.GetDirectoryClient(GetNewNonAsciiDirectoryName()));
            await sourceDir.CreateAsync();

            string destDirName = GetNewDirectoryName();

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
            ShareDirectoryClient destDir = await sourceDir.RenameAsync(
                destinationPath: destDirName,
                options: options);

            Response<ShareDirectoryProperties> propertiesResponse = await destDir.GetPropertiesAsync();

            // Assert
            Assert.That(propertiesResponse.Value.SmbProperties.FilePermissionKey, Is.Not.Null);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task RenameAsync_FilePermissionAndFilePermissionKeySet()
        {
            // Arrange
            await using DisposingShare test = await SharesClientBuilder.GetTestShareAsync();
            ShareDirectoryClient sourceDir = InstrumentClient(test.Share.GetDirectoryClient(GetNewNonAsciiDirectoryName()));
            await sourceDir.CreateAsync();

            string destDirName = GetNewDirectoryName();

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
                sourceDir.RenameAsync(
                    destinationPath: destDirName,
                    options: options),
                e => Assert.That(e.Message, Is.EqualTo("filePermission and filePermissionKey cannot both be set")));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task RenameAsync_FilePermissionTooLarge()
        {
            // Arrange
            await using DisposingShare test = await SharesClientBuilder.GetTestShareAsync();
            ShareDirectoryClient sourceDir = InstrumentClient(test.Share.GetDirectoryClient(GetNewNonAsciiDirectoryName()));
            await sourceDir.CreateAsync();

            string destDirName = GetNewDirectoryName();

            string filePermission = new string('*', 9 * Constants.KB);

            ShareFileRenameOptions options = new ShareFileRenameOptions
            {
                FilePermission = filePermission
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                sourceDir.RenameAsync(
                    destinationPath: destDirName,
                    options: options),
                e =>
                {
                    Assert.That(e.ParamName, Is.EqualTo("filePermission"));
                    Assert.That(e.Message, Does.StartWith("Value must be less than or equal to 8192"));
                });
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task RenameAsync_SmbPropertie()
        {
            // Arrange
            await using DisposingShare test = await SharesClientBuilder.GetTestShareAsync();
            ShareDirectoryClient sourceDir = InstrumentClient(test.Share.GetDirectoryClient(GetNewNonAsciiDirectoryName()));
            await sourceDir.CreateAsync();

            string destDirName = GetNewDirectoryName();

            string permission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
            ShareFilePermission filePermission = new ShareFilePermission()
            {
                Permission = permission,
            };
            Response<PermissionInfo> createPermissionResponse = await test.Share.CreatePermissionAsync(filePermission);

            FileSmbProperties smbProperties = new FileSmbProperties
            {
                FilePermissionKey = createPermissionResponse.Value.FilePermissionKey,
                FileAttributes = ShareModelExtensions.ToFileAttributes("Directory|ReadOnly"),
                FileCreatedOn = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero),
                FileLastWrittenOn = new DateTimeOffset(2019, 8, 26, 5, 15, 25, 60, TimeSpan.Zero),
                FileChangedOn = new DateTimeOffset(2010, 8, 26, 5, 15, 21, 60, TimeSpan.Zero),
            };

            ShareFileRenameOptions options = new ShareFileRenameOptions
            {
                SmbProperties = smbProperties
            };

            // Act
            ShareDirectoryClient destDir = await sourceDir.RenameAsync(
                destinationPath: destDirName,
                options: options);

            Response<ShareDirectoryProperties> propertiesResponse = await destDir.GetPropertiesAsync();

            // Assert
            Assert.That(propertiesResponse.Value.SmbProperties.FileAttributes, Is.EqualTo(smbProperties.FileAttributes));
            Assert.That(propertiesResponse.Value.SmbProperties.FileCreatedOn, Is.EqualTo(smbProperties.FileCreatedOn));
            Assert.That(propertiesResponse.Value.SmbProperties.FileLastWrittenOn, Is.EqualTo(smbProperties.FileLastWrittenOn));
            Assert.That(propertiesResponse.Value.SmbProperties.FileChangedOn, Is.EqualTo(smbProperties.FileChangedOn));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_04_10)]
        public async Task RenameAsync_ShareSAS()
        {
            // Arrange
            await using DisposingShare test = await SharesClientBuilder.GetTestShareAsync();
            ShareDirectoryClient sourceDir = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
            await sourceDir.CreateAsync();
            string destDirName = GetNewDirectoryName();

            ShareSasBuilder shareSasBuilder = new ShareSasBuilder
            {
                ShareName = test.Share.Name,
                ExpiresOn = Recording.UtcNow.AddDays(1)
            };
            shareSasBuilder.SetPermissions(ShareSasPermissions.All);
            SasQueryParameters sasQueryParameters = shareSasBuilder.ToSasQueryParameters(Tenants.GetNewSharedKeyCredentials());

            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(sourceDir.Uri)
            {
                Sas = sasQueryParameters
            };

            sourceDir = InstrumentClient(new ShareDirectoryClient(shareUriBuilder.ToUri(), GetOptions()));

            // Act
            ShareDirectoryClient destDir = await sourceDir.RenameAsync(
                destinationPath: destDirName + "?" + sasQueryParameters);

            // Assert
            await destDir.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task RenameAsync_SasCredentialFromShare()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            string sas = GetNewAccountSasCredentials(resourceTypes: AccountSasResourceTypes.All, permissions: AccountSasPermissions.All).ToString();
            Uri uri = test.Share.Uri;
            string sourceDirectoryName = GetNewDirectoryName();
            string destinationDirectoryName = GetNewDirectoryName();
            await test.Share.CreateDirectoryAsync(sourceDirectoryName);

            ShareClient sasClient = InstrumentClient(new ShareClient(uri, new AzureSasCredential(sas), GetOptions()));
            ShareDirectoryClient sourceDirectoryClient = sasClient.GetDirectoryClient(sourceDirectoryName);

            // Act
            ShareDirectoryClient destDirectory = await sourceDirectoryClient.RenameAsync(destinationPath: destinationDirectoryName);

            // Assert
            await destDirectory.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task RenameAsync_SasCredentialFromFile()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            string sas = GetNewAccountSasCredentials(resourceTypes: AccountSasResourceTypes.All, permissions: AccountSasPermissions.All).ToString();
            Uri uri = test.Share.Uri;

            string sourceFileName = GetNewFileName();
            string sourceDirectoryName = GetNewDirectoryName();
            string destinationDirectoryName = GetNewDirectoryName();
            ShareUriBuilder sourceUriBuilder = new ShareUriBuilder(uri)
            {
                DirectoryOrFilePath = sourceDirectoryName + "/" + sourceFileName
            };

            // Act
            ShareFileClient sasClient = InstrumentClient(new ShareFileClient(sourceUriBuilder.ToUri(), new AzureSasCredential(sas), GetOptions()));
            ShareDirectoryClient sourceDirectoryClient = sasClient.GetParentShareDirectoryClient();

            await sourceDirectoryClient.CreateAsync();

            // Act
            ShareDirectoryClient destDirectory = await sourceDirectoryClient.RenameAsync(destinationPath: destinationDirectoryName);

            // Assert
            await destDirectory.GetPropertiesAsync();
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

            // Make unique source sas
            SasQueryParameters sourceSas = GetNewFileServiceSasCredentialsShare(shareName);
            ShareUriBuilder sourceUriBuilder = new ShareUriBuilder(sourceDirectoryClient.Uri)
            {
                Sas = sourceSas
            };

            string destDirName = GetNewDirectoryName();

            ShareClient sasShareClient = InstrumentClient(new ShareClient(sourceUriBuilder.ToUri(), GetOptions()));
            ShareDirectoryClient sasDirectoryClient = InstrumentClient(sasShareClient.GetDirectoryClient(sourceDirectoryClient.Path));

            // Make unique destination sas
            string newPath = directoryClient.Path + "/" + destDirName;
            string destSas = GetNewAccountSasCredentials(
                resourceTypes: AccountSasResourceTypes.All,
                permissions: AccountSasPermissions.All).ToString();

            // Act
            ShareDirectoryClient destDirectory = await sasDirectoryClient.RenameAsync(destinationPath: newPath + "?" + destSas);

            // Assert
            Response<ShareDirectoryProperties> response = await destDirectory.GetPropertiesAsync();
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

            // Make unique source sas
            SasQueryParameters sourceSas = GetNewFileServiceSasCredentialsShare(shareName);
            ShareUriBuilder sourceUriBuilder = new ShareUriBuilder(sourceDirectoryClient.Uri)
            {
                Sas = sourceSas
            };

            string destDirName = GetNewDirectoryName();

            ShareClient sasShareClient = InstrumentClient(new ShareClient(sourceUriBuilder.ToUri(), GetOptions()));
            ShareDirectoryClient sasDirectoryClient = InstrumentClient(sasShareClient.GetDirectoryClient(sourceDirectoryClient.Path));

            // Make unique destination sas
            string newPath = directoryClient.Path + "/" + destDirName;

            // Act
            ShareDirectoryClient destDirectory = await sasDirectoryClient.RenameAsync(destinationPath: newPath);

            // Assert
            Response<ShareDirectoryProperties> response = await destDirectory.GetPropertiesAsync();
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

            string destFileName = GetNewFileName();

            // Act
            var sasShareClient = InstrumentClient(new ShareClient(test.Share.Uri, new AzureSasCredential(sas), GetOptions()));
            ShareDirectoryClient sasSourceDirectoryClient = sasShareClient.GetDirectoryClient(directoryClient.Path);

            // Make unique destination sas
            string destSas = GetNewFileServiceSasCredentialsShare(test.Share.Name).ToString();

            // Act
            ShareDirectoryClient destDirectory = await sasSourceDirectoryClient.RenameAsync(destinationPath: destFileName + "?" + destSas);

            // Assert
            Response<ShareDirectoryProperties> response = await destDirectory.GetPropertiesAsync();
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
            await using DisposingShare test = await SharesClientBuilder.GetTestShareAsync(options: options);
            string destDirectoryName = GetNewDirectoryName() + ".";
            ShareDirectoryClient sourceDirectory = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName() + "."));
            await sourceDirectory.CreateAsync();

            // Act
            if (sourceAllowTrailingDot == true)
            {
                ShareDirectoryClient destDirectory = await sourceDirectory.RenameAsync(destDirectoryName);
            }
            else
            {
                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    sourceDirectory.RenameAsync(destDirectoryName),
                    e => Assert.That(e.ErrorCode, Is.EqualTo("ResourceNotFound")));
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
            string destDirectoryName = GetNewDirectoryName();
            ShareDirectoryClient sourceDirectory = InstrumentClient(oauthServiceClient.GetShareClient(shareName).GetDirectoryClient(directoryName));
            await sourceDirectory.CreateAsync();

            // Act
            ShareDirectoryClient destDirectory = await sourceDirectory.RenameAsync(destDirectoryName);

            // Assert
            await destDirectory.GetPropertiesAsync();
        }

        #region GenerateSasTests
        [RecordedTest]
        public void CanGenerateSas_ClientConstructors()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, fileStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Act - ShareDirectoryClient(string connectionString, string blobContainerName, string blobName)
            ShareDirectoryClient directory = InstrumentClient(new ShareDirectoryClient(
                connectionString,
                GetNewShareName(),
                GetNewDirectoryName()));
            Assert.That(directory.CanGenerateSasUri, Is.True);

            // Act - ShareDirectoryClient(string connectionString, string blobContainerName, string blobName, BlobClientOptions options)
            ShareDirectoryClient directory2 = InstrumentClient(new ShareDirectoryClient(
                connectionString,
                GetNewShareName(),
                GetNewDirectoryName(),
                GetOptions()));
            Assert.That(directory2.CanGenerateSasUri, Is.True);

            // Act - ShareDirectoryClient(Uri blobContainerUri, BlobClientOptions options = default)
            ShareDirectoryClient directory3 = InstrumentClient(new ShareDirectoryClient(
                blobEndpoint,
                GetOptions()));
            Assert.That(directory3.CanGenerateSasUri, Is.False);

            // Act - ShareDirectoryClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            ShareDirectoryClient directory4 = InstrumentClient(new ShareDirectoryClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            Assert.That(directory4.CanGenerateSasUri, Is.True);
        }

        [RecordedTest]
        public void CanGenerateSas_GetFileClient()
        {
            // Arrange
            var constants = TestConstants.Create(this);
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
            Assert.That(file.CanGenerateSasUri, Is.True);

            // Act - ShareDirectoryClient(string connectionString, string blobContainerName, string blobName, BlobClientOptions options)
            ShareDirectoryClient directory2 = InstrumentClient(new ShareDirectoryClient(
                connectionString,
                GetNewShareName(),
                GetNewDirectoryName(),
                GetOptions()));
            ShareFileClient file2 = directory2.GetFileClient(GetNewFileName());
            Assert.That(file2.CanGenerateSasUri, Is.True);

            // Act - ShareDirectoryClient(Uri blobContainerUri, BlobClientOptions options = default)
            ShareDirectoryClient directory3 = InstrumentClient(new ShareDirectoryClient(
                blobEndpoint,
                GetOptions()));
            ShareFileClient file3 = directory3.GetFileClient(GetNewFileName());
            Assert.That(file3.CanGenerateSasUri, Is.False);

            // Act - ShareDirectoryClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            ShareDirectoryClient directory4 = InstrumentClient(new ShareDirectoryClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            ShareFileClient file4 = directory4.GetFileClient(GetNewFileName());
            Assert.That(file4.CanGenerateSasUri, Is.True);
        }

        [RecordedTest]
        public void CanGenerateSas_GetSubdirectoryClient()
        {
            // Arrange
            var constants = TestConstants.Create(this);
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
            Assert.That(subdirectory.CanGenerateSasUri, Is.True);

            // Act - ShareDirectoryClient(string connectionString, string blobContainerName, string blobName, BlobClientOptions options)
            ShareDirectoryClient directory2 = InstrumentClient(new ShareDirectoryClient(
                connectionString,
                GetNewShareName(),
                GetNewDirectoryName(),
                GetOptions()));
            ShareDirectoryClient subdirectory2 = directory2.GetSubdirectoryClient(GetNewFileName());
            Assert.That(subdirectory2.CanGenerateSasUri, Is.True);

            // Act - ShareDirectoryClient(Uri blobContainerUri, BlobClientOptions options = default)
            ShareDirectoryClient directory3 = InstrumentClient(new ShareDirectoryClient(
                blobEndpoint,
                GetOptions()));
            ShareDirectoryClient subdirectory3 = directory3.GetSubdirectoryClient(GetNewFileName());
            Assert.That(subdirectory3.CanGenerateSasUri, Is.False);

            // Act - ShareDirectoryClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            ShareDirectoryClient directory4 = InstrumentClient(new ShareDirectoryClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            ShareDirectoryClient subdirectory4 = directory4.GetSubdirectoryClient(GetNewFileName());
            Assert.That(subdirectory4.CanGenerateSasUri, Is.True);
        }

        [RecordedTest]
        public void CanGenerateSas_Mockable()
        {
            // Act
            var directory = new Mock<ShareDirectoryClient>();
            directory.Setup(x => x.CanGenerateSasUri).Returns(false);

            // Assert
            Assert.That(directory.Object.CanGenerateSasUri, Is.False);

            // Act
            directory.Setup(x => x.CanGenerateSasUri).Returns(true);

            // Assert
            Assert.That(directory.Object.CanGenerateSasUri, Is.True);
        }

        [RecordedTest]
        public void GenerateSas_RequiredParameters()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            ShareFileSasPermissions permissions = ShareFileSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);

            string shareName = GetNewShareName();
            string directoryName = GetNewDirectoryName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.file.core.windows.net");
            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(serviceUri)
            {
                ShareName = shareName,
                DirectoryOrFilePath = directoryName
            };
            ShareDirectoryClient directoryClient = InstrumentClient(new ShareDirectoryClient(
                shareUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            string stringToSign = null;

            // Act
            Uri sasUri = directoryClient.GenerateSasUri(permissions, expiresOn, out stringToSign);

            // Assert
            ShareSasBuilder sasBuilder = new ShareSasBuilder(permissions, expiresOn)
            {
                ShareName = shareName,
                FilePath = directoryName,
            };
            ShareUriBuilder expectedUri = new ShareUriBuilder(serviceUri)
            {
                ShareName = shareName,
                DirectoryOrFilePath = directoryName,
                Sas = sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.That(sasUri, Is.EqualTo(expectedUri.ToUri()));
            Assert.That(stringToSign, Is.Not.Null);
        }

        [RecordedTest]
        public void GenerateSas_Builder()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            ShareFileSasPermissions permissions = ShareFileSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);

            string shareName = GetNewShareName();
            string directoryName = GetNewDirectoryName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.file.core.windows.net");
            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(serviceUri)
            {
                ShareName = shareName,
                DirectoryOrFilePath = directoryName
            };

            ShareDirectoryClient directoryClient = InstrumentClient(new ShareDirectoryClient(
                shareUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            ShareSasBuilder sasBuilder = new ShareSasBuilder(permissions, expiresOn)
            {
                ShareName = shareName,
                FilePath = directoryName,
            };

            string stringToSign = null;

            // Act
            Uri sasUri = directoryClient.GenerateSasUri(sasBuilder, out stringToSign);

            // Assert
            ShareSasBuilder sasBuilder2 = new ShareSasBuilder(permissions, expiresOn)
            {
                ShareName = shareName,
                FilePath = directoryName
            };
            ShareUriBuilder expectedUri = new ShareUriBuilder(serviceUri)
            {
                ShareName = shareName,
                DirectoryOrFilePath = directoryName,
                Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.That(sasUri, Is.EqualTo(expectedUri.ToUri()));
            Assert.That(stringToSign, Is.Not.Null);
        }

        [RecordedTest]
        public void GenerateSas_BuilderNullShareName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            ShareFileSasPermissions permissions = ShareFileSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);

            string shareName = GetNewShareName();
            string directoryName = GetNewDirectoryName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.file.core.windows.net");
            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(serviceUri)
            {
                ShareName = shareName,
                DirectoryOrFilePath = directoryName
            };

            ShareDirectoryClient directoryClient = InstrumentClient(new ShareDirectoryClient(
                shareUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            ShareSasBuilder sasBuilder = new ShareSasBuilder(permissions, expiresOn)
            {
                ShareName = null,
                FilePath = directoryName,
            };

            // Act
            Uri sasUri = directoryClient.GenerateSasUri(sasBuilder);

            // Assert
            ShareSasBuilder sasBuilder2 = new ShareSasBuilder(permissions, expiresOn)
            {
                ShareName = shareName,
                FilePath = directoryName
            };
            ShareUriBuilder expectedUri = new ShareUriBuilder(serviceUri)
            {
                ShareName = shareName,
                DirectoryOrFilePath = directoryName,
                Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.That(sasUri, Is.EqualTo(expectedUri.ToUri()));
        }

        [RecordedTest]
        public void GenerateSas_BuilderWrongShareName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string shareName = GetNewShareName();
            string directoryName = GetNewDirectoryName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.file.core.windows.net");
            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(serviceUri)
            {
                ShareName = shareName,
                DirectoryOrFilePath = directoryName
            };
            ShareDirectoryClient directoryClient = InstrumentClient(new ShareDirectoryClient(
                shareUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            ShareSasBuilder sasBuilder = new ShareSasBuilder(ShareFileSasPermissions.All, Recording.UtcNow.AddHours(+1))
            {
                ShareName = GetNewShareName(), // different share name
                FilePath = directoryName
            };

            // Act
            TestHelper.AssertExpectedException(
                () => directoryClient.GenerateSasUri(sasBuilder),
                new InvalidOperationException("SAS Uri cannot be generated. ShareSasBuilder.ShareName does not match ShareName in the Client. ShareSasBuilder.ShareName must either be left empty or match the ShareName in the Client"));
        }

        [RecordedTest]
        public void GenerateSas_builderNullDirectoryName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            ShareFileSasPermissions permissions = ShareFileSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);

            string shareName = GetNewShareName();
            string directoryName = GetNewDirectoryName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.file.core.windows.net");
            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(serviceUri)
            {
                ShareName = shareName,
                DirectoryOrFilePath = directoryName
            };

            ShareDirectoryClient directoryClient = InstrumentClient(new ShareDirectoryClient(
                shareUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            ShareSasBuilder sasBuilder = new ShareSasBuilder(permissions, expiresOn)
            {
                ShareName = shareName,
                FilePath = null,
            };

            // Act
            Uri sasUri = directoryClient.GenerateSasUri(sasBuilder);

            // Assert
            ShareSasBuilder sasBuilder2 = new ShareSasBuilder(permissions, expiresOn)
            {
                ShareName = shareName,
                FilePath = directoryName
            };
            ShareUriBuilder expectedUri = new ShareUriBuilder(serviceUri)
            {
                ShareName = shareName,
                DirectoryOrFilePath = directoryName,
                Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.That(sasUri, Is.EqualTo(expectedUri.ToUri()));
        }

        [RecordedTest]
        public void GenerateSas_BuilderWrongDirectoryName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string shareName = GetNewShareName();
            string directoryName = GetNewDirectoryName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.file.core.windows.net");
            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(serviceUri)
            {
                ShareName = shareName,
                DirectoryOrFilePath = directoryName
            };
            ShareDirectoryClient directoryClient = InstrumentClient(new ShareDirectoryClient(
                shareUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            ShareSasBuilder sasBuilder = new ShareSasBuilder(ShareFileSasPermissions.All, Recording.UtcNow.AddHours(+1))
            {
                ShareName = shareName,
                FilePath = GetNewDirectoryName() // different directory name
            };

            // Act
            TestHelper.AssertExpectedException(
                () => directoryClient.GenerateSasUri(sasBuilder),
                new InvalidOperationException("SAS Uri cannot be generated. ShareSasBuilder.FilePath does not match Path in the Client. ShareSasBuilder.FilePath must either be left empty or match the Path in the Client"));
        }
        #endregion

        [RecordedTest]
        public void CanMockClientConstructors()
        {
            // One has to call .Object to trigger constructor. It's lazy.
            var mock = new Mock<ShareDirectoryClient>(TestConfigDefault.ConnectionString, "name", "name", new ShareClientOptions()).Object;
            mock = new Mock<ShareDirectoryClient>(TestConfigDefault.ConnectionString, "name", "name").Object;
            mock = new Mock<ShareDirectoryClient>(new Uri("https://test/test/test"), new ShareClientOptions()).Object;
            mock = new Mock<ShareDirectoryClient>(new Uri("https://test/test/test"), Tenants.GetNewSharedKeyCredentials(), new ShareClientOptions()).Object;
            mock = new Mock<ShareDirectoryClient>(new Uri("https://test/test/test"), new AzureSasCredential("foo"), new ShareClientOptions()).Object;
        }
    }
}
