// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Files.DataLake.Specialized;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Tests.Shared;
using Moq;
using NUnit.Framework;
using TestConstants = Azure.Storage.Test.TestConstants;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class DirectoryClientTests : PathTestBase
    {
        public DirectoryClientTests(bool async, DataLakeClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        public async Task Ctor_Uri()
        {
            string fileSystemName = GetNewFileSystemName();
            string parentDirectoryName = GetNewDirectoryName();
            string directoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient parentDirectory = await test.FileSystem.CreateDirectoryAsync(parentDirectoryName);

            // Arrange
            await parentDirectory.CreateSubDirectoryAsync(directoryName);

            SasQueryParameters sasQueryParameters = GetNewAccountSasCredentials();
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{parentDirectoryName}/{directoryName}?{sasQueryParameters}");
            DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(uri, GetOptions()));

            // Act
            await directoryClient.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(directoryName, directoryClient.Name);
            Assert.AreEqual(fileSystemName, directoryClient.FileSystemName);
            Assert.AreEqual($"{parentDirectoryName}/{directoryName}", directoryClient.Path);
            Assert.AreEqual(uri, directoryClient.Uri);
        }

        [RecordedTest]
        public async Task Ctor_SharedKey()
        {
            string fileSystemName = GetNewFileSystemName();
            string parentDirectoryName = GetNewDirectoryName();
            string directoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient parentDirectory = await test.FileSystem.CreateDirectoryAsync(parentDirectoryName);

            // Arrange
            await parentDirectory.CreateSubDirectoryAsync(directoryName);

            StorageSharedKeyCredential sharedKey = new StorageSharedKeyCredential(
                TestConfigHierarchicalNamespace.AccountName,
                TestConfigHierarchicalNamespace.AccountKey);
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{parentDirectoryName}/{directoryName}");
            DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(uri, sharedKey, GetOptions()));

            // Act
            await directoryClient.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(directoryName, directoryClient.Name);
            Assert.AreEqual(fileSystemName, directoryClient.FileSystemName);
            Assert.AreEqual($"{parentDirectoryName}/{directoryName}", directoryClient.Path);
            Assert.AreEqual(uri, directoryClient.Uri);
            Assert.IsNotNull(directoryClient.ClientConfiguration.SharedKeyCredential);
        }

        [Test]
        public void Ctor_SharedKey_AccountName()
        {
            // Arrange
            var accountName = "accountName";
            var fileSystemName = "fileSystemName";
            var directoryName = "directoryName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });
            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var blobEndpoint = new Uri($"https://customdomain/{fileSystemName}/{directoryName}");

            DataLakeDirectoryClient datalakeDirectoryClient = new DataLakeDirectoryClient(blobEndpoint, credentials);

            Assert.AreEqual(accountName, datalakeDirectoryClient.AccountName);
            Assert.AreEqual(fileSystemName, datalakeDirectoryClient.FileSystemName);
            Assert.AreEqual(directoryName, datalakeDirectoryClient.Path);
        }

        [RecordedTest]
        public async Task Ctor_TokenCredential()
        {
            string fileSystemName = GetNewFileSystemName();
            string parentDirectoryName = GetNewDirectoryName();
            string directoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient parentDirectory = await test.FileSystem.CreateDirectoryAsync(parentDirectoryName);

            // Arrange
            await parentDirectory.CreateSubDirectoryAsync(directoryName);

            TokenCredential tokenCredential = TestEnvironment.Credential;
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{parentDirectoryName}/{directoryName}").ToHttps();
            DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(uri, tokenCredential, GetOptions()));

            // Act
            await directoryClient.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(directoryName, directoryClient.Name);
            Assert.AreEqual(fileSystemName, directoryClient.FileSystemName);
            Assert.AreEqual($"{parentDirectoryName}/{directoryName}", directoryClient.Path);
            Assert.AreEqual(uri, directoryClient.Uri);
            Assert.IsNotNull(directoryClient.ClientConfiguration.TokenCredential);
        }

        [RecordedTest]
        public async Task Ctor_ConnectionString_RoundTrip()
        {
            // Arrange
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewDirectoryName();
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient directoryClient = InstrumentClient(test.FileSystem.GetDirectoryClient(path));
            await directoryClient.CreateAsync();

            // Act
            string connectionString = $"DefaultEndpointsProtocol=https;AccountName={TestConfigHierarchicalNamespace.AccountName};AccountKey={TestConfigHierarchicalNamespace.AccountKey};BlobEndpoint={TestConfigHierarchicalNamespace.BlobServiceEndpoint};FileEndpoint={TestConfigHierarchicalNamespace.FileServiceEndpoint};QueueEndpoint={TestConfigHierarchicalNamespace.QueueServiceEndpoint}";
            DataLakeDirectoryClient connStringDirectory = InstrumentClient(new DataLakeDirectoryClient(connectionString, fileSystemName, path, GetOptions()));

            // Assert
            await connStringDirectory.GetPropertiesAsync();
            await connStringDirectory.GetAccessControlAsync();
            Assert.IsNotNull(connStringDirectory.ClientConfiguration.SharedKeyCredential);
        }

        [RecordedTest]
        public async Task Ctor_ConnectionString_GenerateSas()
        {
            // Arrange
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewDirectoryName();
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient directoryClient = InstrumentClient(test.FileSystem.GetDirectoryClient(path));
            await directoryClient.CreateAsync();

            // Act
            string connectionString = $"DefaultEndpointsProtocol=https;AccountName={TestConfigHierarchicalNamespace.AccountName};AccountKey={TestConfigHierarchicalNamespace.AccountKey};BlobEndpoint={TestConfigHierarchicalNamespace.BlobServiceEndpoint};FileEndpoint={TestConfigHierarchicalNamespace.FileServiceEndpoint};QueueEndpoint={TestConfigHierarchicalNamespace.QueueServiceEndpoint}";
            DataLakeDirectoryClient connStringDirectory = InstrumentClient(new DataLakeDirectoryClient(connectionString, fileSystemName, path, GetOptions()));
            Uri sasUri = connStringDirectory.GenerateSasUri(DataLakeSasPermissions.All, Recording.UtcNow.AddDays(1));
            DataLakeDirectoryClient sasDirectoryClient = InstrumentClient(new DataLakeDirectoryClient(sasUri, GetOptions()));

            // Assert
            await sasDirectoryClient.GetPropertiesAsync();
            await sasDirectoryClient.GetAccessControlAsync();
        }

        [RecordedTest]
        public void Ctor_TokenCredential_Http()
        {
            // Arrange
            TokenCredential tokenCredential = TestEnvironment.Credential;
            Uri uri = new Uri(TestConfigHierarchicalNamespace.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new DataLakeDirectoryClient(uri, tokenCredential),
                new ArgumentException("Cannot use TokenCredential without HTTPS."));

            TestHelper.AssertExpectedException(
                () => new DataLakeDirectoryClient(uri, tokenCredential, new DataLakeClientOptions()),
                new ArgumentException("Cannot use TokenCredential without HTTPS."));
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials().ToString();
            await using DisposingFileSystem test = await GetNewFileSystem();
            var client = test.FileSystem.GetDirectoryClient(GetNewDirectoryName());
            await client.CreateIfNotExistsAsync();
            Uri uri = client.Uri;

            // Act
            var sasClient = InstrumentClient(new DataLakeDirectoryClient(uri, new AzureSasCredential(sas), GetOptions()));
            PathProperties properties = await sasClient.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(properties);
            Assert.IsNotNull(sasClient.ClientConfiguration.SasCredential);
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential_VerifyNoSasInUri()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials().ToString();
            await using DisposingFileSystem test = await GetNewFileSystem();
            Uri uri = test.FileSystem.GetDirectoryClient(GetNewDirectoryName()).Uri;
            uri = new Uri(uri.ToString() + "?" + sas);

            // Act
            TestHelper.AssertExpectedException<ArgumentException>(
                () => new DataLakeDirectoryClient(uri, new AzureSasCredential(sas)),
                e => e.Message.Contains($"You cannot use {nameof(AzureSasCredential)} when the resource URI also contains a Shared Access Signature"));
        }

        [RecordedTest]
        public void Ctor_CPK_Http()
        {
            // Arrange
            Models.DataLakeCustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            DataLakeClientOptions dataLakeClientOptions = new DataLakeClientOptions
            {
                CustomerProvidedKey = customerProvidedKey
            };
            Uri httpUri = new Uri(TestConfigHierarchicalNamespace.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new DataLakeDirectoryClient(httpUri, dataLakeClientOptions),
                new ArgumentException("Cannot use client-provided key without HTTPS."));
        }

        [RecordedTest]
        public async Task Ctor_DefaultAudience()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();

            DataLakeDirectoryClient pathClient = test.FileSystem.GetDirectoryClient(GetNewFileName());
            await pathClient.CreateIfNotExistsAsync();

            // Act - Create new blob client with the OAuth Credential and Audience
            DataLakeClientOptions options = GetOptionsWithAudience(DataLakeAudience.DefaultAudience);

            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(new Uri(Tenants.TestConfigHierarchicalNamespace.BlobServiceEndpoint))
            {
                FileSystemName = pathClient.FileSystemName,
                DirectoryOrFilePath = pathClient.Name
            };

            DataLakeDirectoryClient aadPathClient = InstrumentClient(new DataLakeDirectoryClient(
                uriBuilder.ToUri(),
                GetOAuthHnsCredential(),
                options));

            // Assert
            bool exists = await aadPathClient.ExistsAsync();
            Assert.IsTrue(exists);
        }

        [RecordedTest]
        public async Task Ctor_CustomAudience()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();

            DataLakeDirectoryClient fileClient = test.FileSystem.GetDirectoryClient(GetNewFileName());
            await fileClient.CreateIfNotExistsAsync();

            // Act - Create new blob client with the OAuth Credential and Audience
            DataLakeClientOptions options = GetOptionsWithAudience(new DataLakeAudience($"https://{test.FileSystem.AccountName}.blob.core.windows.net/"));

            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(new Uri(Tenants.TestConfigHierarchicalNamespace.BlobServiceEndpoint))
            {
                FileSystemName = fileClient.FileSystemName,
                DirectoryOrFilePath = fileClient.Name
            };

            DataLakeDirectoryClient aadDirClient = InstrumentClient(new DataLakeDirectoryClient(
                uriBuilder.ToUri(),
                GetOAuthHnsCredential(),
                options));

            // Assert
            bool exists = await aadDirClient.ExistsAsync();
            Assert.IsTrue(exists);
        }

        [RecordedTest]
        public async Task Ctor_StorageAccountAudience()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();

            DataLakeDirectoryClient pathClient = test.FileSystem.GetDirectoryClient(GetNewFileName());
            await pathClient.CreateIfNotExistsAsync();

            // Act - Create new blob client with the OAuth Credential and Audience
            DataLakeClientOptions options = GetOptionsWithAudience(DataLakeAudience.CreateDataLakeServiceAccountAudience(test.FileSystem.AccountName));

            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(new Uri(Tenants.TestConfigHierarchicalNamespace.BlobServiceEndpoint))
            {
                FileSystemName = pathClient.FileSystemName,
                DirectoryOrFilePath = pathClient.Name
            };

            DataLakeDirectoryClient aadDirClient = InstrumentClient(new DataLakeDirectoryClient(
                uriBuilder.ToUri(),
                GetOAuthHnsCredential(),
                options));

            // Assert
            bool exists = await aadDirClient.ExistsAsync();
            Assert.IsTrue(exists);
        }

        [RecordedTest]
        public async Task Ctor_AudienceError()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();

            DataLakeDirectoryClient pathClient = test.FileSystem.GetDirectoryClient(GetNewFileName());
            await pathClient.CreateIfNotExistsAsync();

            // Act - Create new blob client with the OAuth Credential and Audience
            DataLakeClientOptions options = GetOptionsWithAudience(new DataLakeAudience("https://badaudience.blob.core.windows.net"));

            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint))
            {
                FileSystemName = pathClient.FileSystemName,
                DirectoryOrFilePath = pathClient.Name
            };

            DataLakeDirectoryClient aadDirClient = InstrumentClient(new DataLakeDirectoryClient(
                uriBuilder.ToUri(),
                new MockCredential(),
                options));

            // Assert
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                aadDirClient.ExistsAsync(),
                e => Assert.AreEqual("InvalidAuthenticationInfo", e.ErrorCode));
        }

        [RecordedTest]
        public async Task Ctor_EscapeName()
        {
            // Arrange
            string directoryName = "!*'();[]:@&%=+$,#äÄöÖüÜß";
            await using DisposingFileSystem test = await GetNewFileSystem();
            int size = Constants.KB;
            var data = GetRandomBuffer(size);
            DataLakeDirectoryClient directory = InstrumentClient(test.Container.GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            // Act
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(new Uri(Tenants.TestConfigHierarchicalNamespace.BlobServiceEndpoint))
            {
                FileSystemName = directory.FileSystemName,
                DirectoryOrFilePath = directoryName
            };
            DataLakeDirectoryClient freshDirectoryClient = InstrumentClient(new DataLakeDirectoryClient(
                uriBuilder.ToUri(),
                TestEnvironment.Credential,
                GetOptions()));

            // Assert
            bool exists = await freshDirectoryClient.ExistsAsync();
            Assert.True(exists);
            Assert.AreEqual(directoryName, freshDirectoryClient.Name);
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task CreateAsync(bool createIfNotExists)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            var name = GetNewDirectoryName();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(name));

            // Act
            Response<PathInfo> response;
            if (createIfNotExists)
            {
                response = await directory.CreateIfNotExistsAsync();
            }
            else
            {
                response = await directory.CreateAsync();
            }

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            var accountName = new DataLakeUriBuilder(directory.Uri).AccountName;
            TestHelper.AssertCacheableProperty(accountName, () => directory.AccountName);
            var fileSystemName = new DataLakeUriBuilder(directory.Uri).FileSystemName;
            TestHelper.AssertCacheableProperty(fileSystemName, () => directory.FileSystemName);
            TestHelper.AssertCacheableProperty(name, () => directory.Name);
        }

        [RecordedTest]
        public async Task CreateAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileSystem.CreateDirectoryAsync(GetNewDirectoryName()),
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode));
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task CreateAsync_HttpHeaders(bool createIfNotExists)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            PathHttpHeaders headers = new PathHttpHeaders
            {
                ContentType = ContentType,
                ContentEncoding = ContentEncoding,
                ContentLanguage = ContentLanguage,
                ContentDisposition = ContentDisposition,
                CacheControl = CacheControl
            };

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                HttpHeaders = headers
            };

            // Act
            // Act
            if (createIfNotExists)
            {
                await directory.CreateIfNotExistsAsync(options: options);
            }
            else
            {
                await directory.CreateAsync(options: options);
            }

            // Assert
            Response<PathProperties> response = await directory.GetPropertiesAsync();
            Assert.AreEqual(ContentType, response.Value.ContentType);
            Assert.AreEqual(ContentEncoding, response.Value.ContentEncoding);
            Assert.AreEqual(ContentLanguage, response.Value.ContentLanguage);
            Assert.AreEqual(ContentDisposition, response.Value.ContentDisposition);
            Assert.AreEqual(CacheControl, response.Value.CacheControl);
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task CreateAsync_Metadata(bool createIfNotExists)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                Metadata = metadata
            };

            // Act
            if (createIfNotExists)
            {
                await directory.CreateIfNotExistsAsync(options: options);
            }
            else
            {
                await directory.CreateAsync(options: options);
            }

            // Assert
            Response<PathProperties> getPropertiesResponse = await directory.GetPropertiesAsync();
            AssertMetadataEquality(metadata, getPropertiesResponse.Value.Metadata, isDirectory: true);
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task CreateAsync_PermissionAndUmask(bool createIfNotExists)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            string permissions = "0777";
            string umask = "0057";

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                AccessOptions = new DataLakeAccessOptions
                {
                    Permissions = permissions,
                    Umask = umask
                }
            };

            // Act
            if (createIfNotExists)
            {
                await directory.CreateIfNotExistsAsync(options: options);
            }
            else
            {
                await directory.CreateAsync(options: options);
            }

            // Assert
            Response<PathAccessControl> response = await directory.GetAccessControlAsync();
            AssertPathPermissionsEquality(PathPermissions.ParseSymbolicPermissions("rwx-w----"), response.Value.Permissions);
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task CreateAsync_Owner(bool createIfNotExists)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            string owner = Recording.Random.NewGuid().ToString();

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                AccessOptions = new DataLakeAccessOptions
                {
                    Owner = owner,
                }
            };

            // Act
            if (createIfNotExists)
            {
                await directory.CreateIfNotExistsAsync(options: options);
            }
            else
            {
                await directory.CreateAsync(options: options);
            }

            // Assert
            Response<PathAccessControl> response = await directory.GetAccessControlAsync();
            Assert.AreEqual(owner, response.Value.Owner);
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task CreateAsync_Group(bool createIfNotExists)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            string group = Recording.Random.NewGuid().ToString();

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                AccessOptions = new DataLakeAccessOptions
                {
                    Group = group,
                }
            };

            // Act
            if (createIfNotExists)
            {
                await directory.CreateIfNotExistsAsync(options: options);
            }
            else
            {
                await directory.CreateAsync(options: options);
            }

            // Assert
            Response<PathAccessControl> response = await directory.GetAccessControlAsync();
            Assert.AreEqual(group, response.Value.Group);
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task CreateAsync_Acl(bool createIfNotExists)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                AccessOptions = new DataLakeAccessOptions
                {
                    AccessControlList = AccessControlList
                }
            };

            // Act
            if (createIfNotExists)
            {
                await directory.CreateIfNotExistsAsync(options: options);
            }
            else
            {
                await directory.CreateAsync(options: options);
            }

            // Assert
            Response<PathAccessControl> response = await directory.GetAccessControlAsync();
            AssertAccessControlListEquality(AccessControlList, response.Value.AccessControlList.ToList());
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task CreateAsync_LeaseId(bool createIfNotExists)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                LeaseId = "leaseId"
            };

            // Act
            if (createIfNotExists)
            {
                await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                    directory.CreateIfNotExistsAsync(options: options),
                    e => Assert.AreEqual(
                        $"{nameof(DataLakePathCreateOptions)}.{nameof(DataLakePathCreateOptions.LeaseId)} does not apply to directories.",
                        e.Message));
            }
            else
            {
                await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                    directory.CreateAsync(options: options),
                    e => Assert.AreEqual(
                        $"{nameof(DataLakePathCreateOptions)}.{nameof(DataLakePathCreateOptions.LeaseId)} does not apply to directories.",
                        e.Message));
            }
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task CreateAsync_LeaseDuration(bool createIfNotExists)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                LeaseDuration = new TimeSpan(5, 5, 5)
            };

            // Act
            if (createIfNotExists)
            {
                await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                    directory.CreateIfNotExistsAsync(options: options),
                    e => Assert.AreEqual(
                        $"{nameof(DataLakePathCreateOptions)}.{nameof(DataLakePathCreateOptions.LeaseDuration)} does not apply to directories.",
                        e.Message));
            }
            else
            {
                await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                    directory.CreateAsync(options: options),
                    e => Assert.AreEqual(
                        $"{nameof(DataLakePathCreateOptions)}.{nameof(DataLakePathCreateOptions.LeaseDuration)} does not apply to directories.",
                        e.Message));
            }
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task CreateAsync_TimeToExpire(bool createIfNotExists)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                ScheduleDeletionOptions = new DataLakePathScheduleDeletionOptions(timeToExpire: new TimeSpan(5, 5, 5))
            };

            // Act
            if (createIfNotExists)
            {
                await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                    directory.CreateIfNotExistsAsync(options: options),
                    e => Assert.AreEqual(
                        $"{nameof(DataLakePathCreateOptions)}.{nameof(DataLakePathCreateOptions.ScheduleDeletionOptions.TimeToExpire)} does not apply to directories.",
                        e.Message));
            }
            else
            {
                await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                    directory.CreateAsync(options: options),
                    e => Assert.AreEqual(
                        $"{nameof(DataLakePathCreateOptions)}.{nameof(DataLakePathCreateOptions.ScheduleDeletionOptions.TimeToExpire)} does not apply to directories.",
                        e.Message));
            }
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task CreateAsync_ExpiresOn(bool createIfNotExists)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                ScheduleDeletionOptions = new DataLakePathScheduleDeletionOptions(expiresOn: Recording.UtcNow)
            };

            // Act
            if (createIfNotExists)
            {
                await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                    directory.CreateIfNotExistsAsync(options: options),
                    e => Assert.AreEqual(
                        $"{nameof(DataLakePathCreateOptions)}.{nameof(DataLakePathCreateOptions.ScheduleDeletionOptions.ExpiresOn)} does not apply to directories.",
                        e.Message));
            }
            else
            {
                await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                    directory.CreateAsync(options: options),
                    e => Assert.AreEqual(
                        $"{nameof(DataLakePathCreateOptions)}.{nameof(DataLakePathCreateOptions.ScheduleDeletionOptions.ExpiresOn)} does not apply to directories.",
                        e.Message));
            }
        }

        [RecordedTest]
        public async Task CreateAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                // This directory is intentionally created twice
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                parameters.Match = await SetupPathMatchCondition(directory, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(directory, parameters.LeaseId, garbageLeaseId);

                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                DataLakePathCreateOptions options = new DataLakePathCreateOptions
                {
                    Conditions = conditions
                };

                // Act
                Response<PathInfo> response = await directory.CreateAsync(
                    options: options);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [RecordedTest]
        public async Task CreateAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                // This directory is intentionally created twice
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
                parameters.NoneMatch = await SetupPathMatchCondition(directory, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                DataLakePathCreateOptions options = new DataLakePathCreateOptions
                {
                    Conditions = conditions
                };

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    directory.CreateAsync(options: options),
                    e => { });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_10_02)]
        [LiveOnly(Reason = "Encryption Key cannot be stored in recordings.")]
        public async Task CreateAsync_CPK()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeCustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem
                .GetDirectoryClient(GetNewDirectoryName())
                .WithCustomerProvidedKey(customerProvidedKey));

            // Act
            await directory.CreateAsync();

            // Assert
            Response<PathProperties> response = await directory.GetPropertiesAsync();
            Assert.IsTrue(response.Value.IsServerEncrypted);
            Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
        }

        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_12_06)]
        public async Task CreateAsync_EncryptionScopeSas()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            string directoryName = GetNewDirectoryName();

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder
            {
                FileSystemName = test.FileSystem.Name,
                Path = directoryName,
                EncryptionScope = TestConfigHierarchicalNamespace.EncryptionScope,
                ExpiresOn = Recording.UtcNow.AddDays(1)
            };
            sasBuilder.SetPermissions(DataLakeSasPermissions.All);

            DataLakeSasQueryParameters sasQueryParameters = sasBuilder.ToSasQueryParameters(
                new StorageSharedKeyCredential(
                    TestConfigHierarchicalNamespace.AccountName,
                    TestConfigHierarchicalNamespace.AccountKey));

            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(test.FileSystem.Uri)
            {
                DirectoryOrFilePath = directoryName,
                Sas = sasQueryParameters
            };

            DataLakeDirectoryClient sasDirectoryClient = InstrumentClient(new DataLakeDirectoryClient(uriBuilder.ToUri(), GetOptions()));

            // Act
            Response<PathInfo> response = await sasDirectoryClient.CreateAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_12_06)]
        public async Task CreateAsync_EncryptionScopeAccountSas()
        {
            // Arrange
            string fileSystemName = GetNewFileSystemName();
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeServiceClient serviceClient = DataLakeClientBuilder.GetServiceClient_Hns();

            AccountSasBuilder accountSasBuilder = new AccountSasBuilder(
                permissions: AccountSasPermissions.Write,
                expiresOn: Recording.UtcNow.AddDays(1),
                services: AccountSasServices.All,
                resourceTypes: AccountSasResourceTypes.All);
            accountSasBuilder.EncryptionScope = TestConfigHierarchicalNamespace.EncryptionScope;

            Uri accountSasUri = serviceClient.GenerateAccountSasUri(accountSasBuilder);
            serviceClient = InstrumentClient(new DataLakeServiceClient(accountSasUri, GetOptions()));
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(serviceClient.GetFileSystemClient(fileSystemName));
            DataLakeDirectoryClient directoryClient = InstrumentClient(fileSystemClient.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await directoryClient.CreateAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_12_06)]
        public async Task CreateAsync_EncryptionScopeIdentitySas()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            Response<UserDelegationKey> userDelegationKey = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            string directoryName = GetNewDirectoryName();

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder
            {
                FileSystemName = test.FileSystem.Name,
                Path = directoryName,
                EncryptionScope = TestConfigHierarchicalNamespace.EncryptionScope,
                ExpiresOn = Recording.UtcNow.AddDays(1)
            };
            sasBuilder.SetPermissions(DataLakeSasPermissions.All);

            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(test.FileSystem.Uri)
            {
                DirectoryOrFilePath = directoryName,
                Sas = sasBuilder.ToSasQueryParameters(userDelegationKey.Value, TestConfigHierarchicalNamespace.AccountName)
            };

            DataLakeDirectoryClient sasDirectoryClient = InstrumentClient(new DataLakeDirectoryClient(uriBuilder.ToUri(), GetOptions()));

            // Act
            await sasDirectoryClient.CreateAsync();
        }

        [RecordedTest]
        public async Task CreateIfNotExistsAsync_NotExists()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            Response<PathInfo> response = await directory.CreateIfNotExistsAsync();

            // Assert
            Assert.IsNotNull(response.Value.ETag);
        }

        [RecordedTest]
        public async Task CreateIfNotExistsAsync_Exists()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            await directory.CreateIfNotExistsAsync();

            // Act
            Response<PathInfo> response = await directory.CreateIfNotExistsAsync();

            // Assert
            Assert.IsNull(response);
        }

        [RecordedTest]
        public async Task CreateIfNotExistsAsync_Error()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient unauthorizedDirecotry = InstrumentClient(new DataLakeDirectoryClient(directory.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedDirecotry.CreateIfNotExistsAsync(),
                e => Assert.AreEqual("NoAuthenticationInformation", e.ErrorCode));
        }

        [RecordedTest]
        public async Task ExistsAsync_Exists()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            await directory.CreateIfNotExistsAsync();

            // Act
            Response<bool> response = await directory.ExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);
        }

        [RecordedTest]
        public async Task ExistsAsync_NotExists()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            Response<bool> response = await directory.ExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [RecordedTest]
        public async Task ExistsAsync_FileSystemNotExists()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystemClient = service.GetFileSystemClient(GetNewFileSystemName());
            DataLakeDirectoryClient directory = InstrumentClient(fileSystemClient.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            Response<bool> response = await directory.ExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [RecordedTest]
        public async Task ExistsAsync_Error()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem(publicAccessType: PublicAccessType.None);
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            DataLakeDirectoryClient unauthorizedDirectory = InstrumentClient(new DataLakeDirectoryClient(directory.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedDirectory.ExistsAsync(),
                e => Assert.AreEqual(
                    _serviceVersion >= DataLakeClientOptions.ServiceVersion.V2019_12_12 ?
                        "NoAuthenticationInformation" :
                        "ResourceNotFound",
                    e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_10_02)]
        public async Task ExistsAsync_CPK()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeCustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem
                .GetDirectoryClient(GetNewDirectoryName())
                .WithCustomerProvidedKey(customerProvidedKey));
            await directory.CreateAsync();

            // Act
            Response<bool> response = await directory.ExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);
        }

        [RecordedTest]
        public async Task DeleteIfExists_Exists()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            await directory.CreateIfNotExistsAsync();

            // Act
            Response<bool> response = await directory.DeleteIfExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);

            // Act
            response = await directory.DeleteIfExistsAsync();
        }

        [RecordedTest]
        public async Task DeleteIfExists_NotExists()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            Response<bool> response = await directory.DeleteIfExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [RecordedTest]
        public async Task DeleteIfExistsAsync_FileSystemNotExists()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystemClient = service.GetFileSystemClient(GetNewFileSystemName());
            DataLakeDirectoryClient directory = InstrumentClient(fileSystemClient.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            Response<bool> response = await directory.DeleteIfExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [RecordedTest]
        public async Task DeleteIfNotExistsAsync_Error()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            DataLakeFileClient unauthorizedDirectory = InstrumentClient(new DataLakeFileClient(directory.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedDirectory.DeleteIfExistsAsync(),
                e => Assert.AreEqual("NoAuthenticationInformation", e.ErrorCode));
        }

        [RecordedTest]
        public async Task DeleteAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            var name = GetNewDirectoryName();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(name));
            await directory.CreateIfNotExistsAsync();

            // Act
            Response response = await directory.DeleteAsync();
        }

        [RecordedTest]
        public async Task DeleteAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                parameters.Match = await SetupPathMatchCondition(directory, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(directory, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                await directory.DeleteAsync(conditions: conditions);
            }
        }

        [RecordedTest]
        public async Task DeleteAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                parameters.NoneMatch = await SetupPathMatchCondition(directory, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    directory.DeleteAsync(conditions: conditions),
                    e => { });
            }
        }

        // To run this test, the NamespaceTenant AAD info needs to be set to an AAD app that does not have any RBAC permissions,
        // and entityId needs to be set to the entity ID of the application.
        [RecordedTest]
        [Ignore("AAD app not configured for this test")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2023_08_03)]
        public async Task DeleteAsync_Paginated()
        {
            // object ID of AAD app that has no RBAC permissions
            string entityId = "a251dfc9-65c7-4ec3-84d8-f3f3bec0a96f";
            string fileSystemName = GetNewFileSystemName();
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);

            // Arrange
            string directoryName = GetNewDirectoryName();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(directoryName));
            await directory.CreateIfNotExistsAsync();

            for (int i = 0; i < 5020; i++)
            {
                DataLakeFileClient fileClient = directory.GetFileClient(GetNewFileName());
                await fileClient.CreateIfNotExistsAsync();
            };

            DataLakeDirectoryClient rootDirectory = InstrumentClient(test.FileSystem.GetDirectoryClient("/"));

            Response<PathAccessControl> aclResponse = await rootDirectory.GetAccessControlAsync();

            IList<PathAccessControlItem> accessControlList = aclResponse.Value.AccessControlList.ToList();
            accessControlList.Add(
                new PathAccessControlItem
                {
                    Permissions = RolePermissions.Read | RolePermissions.Write | RolePermissions.Execute,
                    AccessControlType = AccessControlType.User,
                    EntityId = entityId
                });

            await rootDirectory.SetAccessControlRecursiveAsync(accessControlList);

            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            DataLakeFileSystemClient oauthFileSystem = InstrumentClient(oauthService.GetFileSystemClient(fileSystemName));
            DataLakeDirectoryClient oauthDirectory = InstrumentClient(oauthFileSystem.GetDirectoryClient(directoryName));

            // Act
            Response response = await oauthDirectory.DeleteAsync();
        }

        [RecordedTest]
        public async Task RenameAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeDirectoryClient sourceDirectory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            string destDirectoryName = GetNewDirectoryName();

            // Act
            DataLakeDirectoryClient destDirectory = await sourceDirectory.RenameAsync(destinationPath: destDirectoryName);

            // Assert
            Response<PathProperties> response = await destDirectory.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task RenameAsync_FileSystemSAS()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeDirectoryClient sourceDirectory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder
            {
                FileSystemName = test.FileSystem.Name,
                Path = null,
                Protocol = SasProtocol.None,
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(+1),
                IPRange = new SasIPRange(IPAddress.None, IPAddress.None)
            };
            sasBuilder.SetPermissions(DataLakeSasPermissions.All);
            SasQueryParameters sourceSasQueryParameters = sasBuilder.ToSasQueryParameters(GetStorageSharedKeyCredentials());
            string destDirectoryName = GetNewDirectoryName();
            sourceDirectory = new DataLakeDirectoryClient(
                new Uri(sourceDirectory.Uri.ToString() + "?" + sourceSasQueryParameters), GetOptions());

            sasBuilder = new DataLakeSasBuilder
            {
                FileSystemName = test.FileSystem.Name,
                Path = null,
                Protocol = SasProtocol.None,
                StartsOn = Recording.UtcNow.AddHours(-2),
                ExpiresOn = Recording.UtcNow.AddHours(+2),
                IPRange = new SasIPRange(IPAddress.None, IPAddress.None)
            };
            sasBuilder.SetPermissions(DataLakeSasPermissions.All);
            SasQueryParameters destSasQueryParameters = sasBuilder.ToSasQueryParameters(GetStorageSharedKeyCredentials());

            // Act
            DataLakeDirectoryClient destDirectory = await sourceDirectory.RenameAsync(
                destinationPath: destDirectoryName + "?" + destSasQueryParameters);

            // Assert
            await destDirectory.GetPropertiesAsync();
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(destDirectory.Uri);
            Assert.AreEqual(destSasQueryParameters.ToString(), uriBuilder.Sas.ToString());
        }

        [RecordedTest]
        public async Task RenameAsync_FileSystem()
        {
            await using DisposingFileSystem sourceTest = await GetNewFileSystem();
            await using DisposingFileSystem destTest = await GetNewFileSystem();

            // Arrange
            DataLakeDirectoryClient sourceDirectory = await sourceTest.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            string destDirectoryName = GetNewDirectoryName();

            // Act
            DataLakeDirectoryClient destDirectory = await sourceDirectory.RenameAsync(
                destinationPath: destDirectoryName,
                destinationFileSystem: destTest.FileSystem.Name);

            // Assert
            Response<PathProperties> response = await destDirectory.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task RenameAsync_Error()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            var sourceDirectoryName = GetNewDirectoryName();
            DataLakeDirectoryClient sourceDirectory = InstrumentClient(test.FileSystem.GetDirectoryClient(sourceDirectoryName));
            string destPath = GetNewDirectoryName();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                sourceDirectory.RenameAsync(destinationPath: destPath),
                e => Assert.AreEqual("SourcePathNotFound", e.ErrorCode));
        }

        [RecordedTest]
        public async Task RenameAsync_DestinationConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient sourceDirectory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
                DataLakeDirectoryClient destDirectory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                parameters.Match = await SetupPathMatchCondition(destDirectory, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(destDirectory, parameters.LeaseId, garbageLeaseId);

                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                destDirectory = await sourceDirectory.RenameAsync(
                    destinationPath: destDirectory.Name,
                    destinationConditions: conditions);

                // Assert
                Response<PathProperties> response = await destDirectory.GetPropertiesAsync();
            }
        }

        [RecordedTest]
        public async Task RenameAsync_DestinationConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient sourceDirectory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
                DataLakeDirectoryClient destDirectory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                parameters.NoneMatch = await SetupPathMatchCondition(destDirectory, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    sourceDirectory.RenameAsync(
                        destinationPath: destDirectory.Name,
                        destinationConditions: conditions),
                    e => { });
            }
        }

        [RecordedTest]
        public async Task RenameAsync_SourceConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient sourceDirectory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
                DataLakeDirectoryClient destDirectory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                parameters.Match = await SetupPathMatchCondition(sourceDirectory, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(sourceDirectory, parameters.LeaseId, garbageLeaseId);

                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                destDirectory = await sourceDirectory.RenameAsync(
                    destinationPath: destDirectory.Name,
                    sourceConditions: conditions);

                // Assert
                Response<PathProperties> response = await destDirectory.GetPropertiesAsync();
            }
        }

        [RecordedTest]
        public async Task RenameAsync_SourceConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient sourceDirectory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
                DataLakeDirectoryClient destDirectory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                parameters.NoneMatch = await SetupPathMatchCondition(sourceDirectory, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    sourceDirectory.RenameAsync(
                        destinationPath: destDirectory.Name,
                        sourceConditions: conditions),
                    e => { });
            }
        }

        [RecordedTest]
        [TestCase("!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("%21%27%28%29%3B%5B%5D%40%26%25%3D%2B%24%2C%23äÄöÖüÜß%3B")]
        [TestCase(" my cool directory ")]
        [TestCase("directory")]
        public async Task RenameAsync_DestinationSpecialCharacters(string destDirectoryName)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeDirectoryClient sourceDirectory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            Uri expectedDestDirectoryUri = new Uri($"{BlobEndpointToDfsEndpoint(TestConfigHierarchicalNamespace.BlobServiceEndpoint)}/{test.FileSystem.Name}/{Uri.EscapeDataString(destDirectoryName)}");

            // Act
            DataLakeDirectoryClient destDirectory = await sourceDirectory.RenameAsync(destinationPath: destDirectoryName);

            // Assert
            Response<PathProperties> response = await destDirectory.GetPropertiesAsync();
            Assert.AreEqual(destDirectoryName, destDirectory.Name);
            Assert.AreEqual(destDirectoryName, destDirectory.Path);
            Assert.AreEqual(expectedDestDirectoryUri, destDirectory.Uri);
        }

        [RecordedTest]
        [TestCase("!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("%21%27%28%29%3B%5B%5D%40%26%25%3D%2B%24%2C%23äÄöÖüÜß%3B")]
        [TestCase(" my cool directory ")]
        [TestCase("directory")]
        public async Task RenameAsync_SourceSpecialCharacters(string sourceDirectoryName)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            string destDirectoryName = GetNewDirectoryName();
            DataLakeDirectoryClient sourceDirectory = await test.FileSystem.CreateDirectoryAsync(sourceDirectoryName);
            Uri expectedDestDirectoryUri = new Uri($"{BlobEndpointToDfsEndpoint(TestConfigHierarchicalNamespace.BlobServiceEndpoint)}/{test.FileSystem.Name}/{destDirectoryName}");

            // Act
            DataLakeDirectoryClient destDirectory = await sourceDirectory.RenameAsync(destinationPath: destDirectoryName);

            // Assert
            Response<PathProperties> response = await destDirectory.GetPropertiesAsync();
            Assert.AreEqual(destDirectoryName, destDirectory.Name);
            Assert.AreEqual(destDirectoryName, destDirectory.Path);
            Assert.AreEqual(expectedDestDirectoryUri, destDirectory.Uri);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_10_02)]
        [LiveOnly(Reason = "Encryption Key cannot be stored in recordings.")]
        public async Task RenameAsync_CPK()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeCustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            DataLakeDirectoryClient sourceDirectory = InstrumentClient(test.FileSystem
                .GetDirectoryClient(GetNewDirectoryName())
                .WithCustomerProvidedKey(customerProvidedKey));
            await sourceDirectory.CreateAsync();
            string destDirectoryName = GetNewDirectoryName();

            // Act
            DataLakeDirectoryClient destDirectory = await sourceDirectory.RenameAsync(destinationPath: destDirectoryName);

            // Assert
            Response<PathProperties> response = await destDirectory.GetPropertiesAsync();
            Assert.IsTrue(response.Value.IsServerEncrypted);
            Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
        }

        [RecordedTest]
        public async Task RenameAsync_SasCredentialFromFileSystem()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials().ToString();
            await using DisposingFileSystem test = await GetNewFileSystem();
            string sourceDirectoryName = GetNewDirectoryName();
            await test.FileSystem.CreateDirectoryAsync(sourceDirectoryName);

            string destDirectoryName = GetNewDirectoryName();

            var sasFileSystemClient = InstrumentClient(new DataLakeFileSystemClient(test.FileSystem.Uri, new AzureSasCredential(sas), GetOptions()));
            DataLakeDirectoryClient sasSourceDirectoryClient = sasFileSystemClient.GetDirectoryClient(sourceDirectoryName);

            // Act
            DataLakeDirectoryClient destDirectory = await sasSourceDirectoryClient.RenameAsync(destinationPath: destDirectoryName);

            // Assert
            Response<PathProperties> response = await destDirectory.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task RenameAsync_SasCredentialFromDirectory()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials().ToString();
            await using DisposingFileSystem test = await GetNewFileSystem();
            string sourceDirectoryName = GetNewDirectoryName();
            DataLakeDirectoryClient directoryClient = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            await directoryClient.CreateSubDirectoryAsync(sourceDirectoryName);

            string destDirectoryName = GetNewDirectoryName();

            var sasDirectoryClient = InstrumentClient(new DataLakeDirectoryClient(directoryClient.Uri, new AzureSasCredential(sas), GetOptions()));
            DataLakeDirectoryClient sasSourceDirectoryClient = sasDirectoryClient.GetSubDirectoryClient(sourceDirectoryName);

            // Act
            DataLakeDirectoryClient destDirectory = await sasSourceDirectoryClient.RenameAsync(destinationPath: destDirectoryName);

            // Assert
            Response<PathProperties> response = await destDirectory.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task RenameAsync_SasCredentialFromFile()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials().ToString();
            await using DisposingFileSystem test = await GetNewFileSystem();
            string sourceDirectoryName = GetNewDirectoryName();
            DataLakeDirectoryClient directoryClient = await test.FileSystem.CreateDirectoryAsync(sourceDirectoryName);
            DataLakeFileClient sourceFile = await directoryClient.CreateFileAsync(sourceDirectoryName);

            string destDirectoryName = GetNewDirectoryName();

            var sasFileClient = InstrumentClient(new DataLakeFileClient(sourceFile.Uri, new AzureSasCredential(sas), GetOptions()));
            DataLakeDirectoryClient sasSourceDirectoryClient = sasFileClient.GetParentDirectoryClient();

            // Act
            DataLakeDirectoryClient destDirectory = await sasSourceDirectoryClient.RenameAsync(destinationPath: destDirectoryName);

            // Assert
            Response<PathProperties> response = await destDirectory.GetPropertiesAsync();
        }

        [LiveOnly]
        [Test]
        public async Task RenameAsync_DifferentSasUri()
        {
            // Arrange
            string fileSystemName = GetNewFileSystemName();
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            string sourceDirectoryName = GetNewDirectoryName();
            DataLakeDirectoryClient directoryClient = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient sourceDirectoryClient = await directoryClient.CreateSubDirectoryAsync(sourceDirectoryName);
            DataLakeFileClient sourceFile = await sourceDirectoryClient.CreateFileAsync(GetNewFileName());

            // Make unique source sas
            DataLakeSasQueryParameters sourceSas = GetNewDataLakeServiceSasCredentialsPath(fileSystemName, sourceDirectoryClient.Path, isDirectory: true);
            DataLakeUriBuilder sourceUriBuilder = new DataLakeUriBuilder(sourceDirectoryClient.Uri)
            {
                Sas = sourceSas
            };

            string destFileName = GetNewFileName();

            DataLakeDirectoryClient sasDirectoryClient = InstrumentClient(new DataLakeDirectoryClient(sourceUriBuilder.ToUri(), GetOptions()));
            DataLakeFileClient sasFileClient = InstrumentClient(sasDirectoryClient.GetFileClient(sourceFile.Name));

            // Make unique destination sas
            string newPath = directoryClient.Path + "/" + destFileName;
            string destSas = GetNewDataLakeServiceSasCredentialsPath(fileSystemName, directoryClient.Path, isDirectory: true).ToString();

            // Act
            DataLakeFileClient destFile = await sasFileClient.RenameAsync(destinationPath: newPath + "?" + destSas);

            // Assert
            Response<PathProperties> response = await destFile.GetPropertiesAsync();
        }

        [LiveOnly]
        [Test]
        public async Task RenameAsync_SourceSasUri()
        {
            // Arrange
            string fileSystemName = GetNewFileSystemName();
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            string sourceDirectoryName = GetNewDirectoryName();
            DataLakeDirectoryClient directoryClient = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient sourceDirectoryClient = await directoryClient.CreateSubDirectoryAsync(sourceDirectoryName);
            DataLakeFileClient sourceFile = await sourceDirectoryClient.CreateFileAsync(GetNewFileName());

            // Make unique source sas
            DataLakeSasQueryParameters sourceSas = GetNewDataLakeServiceSasCredentialsFileSystem(fileSystemName);
            DataLakeUriBuilder sourceUriBuilder = new DataLakeUriBuilder(sourceDirectoryClient.Uri)
            {
                Sas = sourceSas
            };

            string destFileName = GetNewFileName();

            DataLakeDirectoryClient sasDirectoryClient = InstrumentClient(new DataLakeDirectoryClient(sourceUriBuilder.ToUri(), GetOptions()));
            DataLakeFileClient sasFileClient = InstrumentClient(sasDirectoryClient.GetFileClient(sourceFile.Name));

            // Make unique destination sas
            string newPath = directoryClient.Path + "/" + destFileName;

            // Act
            DataLakeFileClient destFile = await sasFileClient.RenameAsync(destinationPath: newPath);

            // Assert
            Response<PathProperties> response = await destFile.GetPropertiesAsync();
        }

        [LiveOnly]
        [Test]
        public async Task RenameAsync_SourceSasCredentialDestSasUri()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials().ToString();
            await using DisposingFileSystem test = await GetNewFileSystem();
            string sourceDirectoryName = GetNewDirectoryName();
            DataLakeDirectoryClient directoryClient = await test.FileSystem.CreateDirectoryAsync(sourceDirectoryName);
            DataLakeFileClient sourceFile = await directoryClient.CreateFileAsync(sourceDirectoryName);

            string destFileName = GetNewFileName();

            // Act
            var sasDirectoryClient = InstrumentClient(new DataLakeDirectoryClient(directoryClient.Uri, new AzureSasCredential(sas), GetOptions()));
            DataLakeFileClient sasSourceFileClient = sasDirectoryClient.GetFileClient(sourceFile.Name);

            // Make unique destination sas
            string destSas = GetNewDataLakeServiceSasCredentialsFileSystem(test.FileSystem.Name).ToString();

            // Act
            DataLakeFileClient destDirectory = await sasSourceFileClient.RenameAsync(destinationPath: destFileName + "?" + destSas);

            // Assert
            Response<PathProperties> response = await destDirectory.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task GetAccessControlAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Act
            PathAccessControl accessControl = await directory.GetAccessControlAsync();

            // Assert
            Assert.IsNotNull(accessControl.Owner);
            Assert.IsNotNull(accessControl.Group);
            Assert.IsNotNull(accessControl.Permissions);
            Assert.IsNotNull(accessControl.AccessControlList);
        }

        [RecordedTest]
        public async Task GetAccessControlAsync_RootDirectory()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetRootDirectoryClient());

            // Act
            PathAccessControl accessControl = await directory.GetAccessControlAsync();

            // Assert
            Assert.IsNotNull(accessControl.Owner);
            Assert.IsNotNull(accessControl.Group);
            Assert.IsNotNull(accessControl.Permissions);
            Assert.IsNotNull(accessControl.AccessControlList);
        }

        [RecordedTest]
        public async Task GetAccessControlAsync_Oauth()
        {
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(service: oauthService, fileSystemName: fileSystemName);

            // Arrange
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);
            DataLakeDirectoryClient oauthDirectory = oauthService
                .GetFileSystemClient(fileSystemName)
                .GetDirectoryClient(directoryName);

            // Act
            PathAccessControl accessControl = await oauthDirectory.GetAccessControlAsync();

            // Assert
            Assert.IsNotNull(accessControl.Owner);
            Assert.IsNotNull(accessControl.Group);
            Assert.IsNotNull(accessControl.Permissions);
            Assert.IsNotNull(accessControl.AccessControlList);
        }

        [RecordedTest]
        public async Task GetAccessControlAsync_FileSystemSAS()
        {
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);

            // Arrange
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);

            DataLakeDirectoryClient sasDirectory = InstrumentClient(
                GetServiceClient_DataLakeServiceSas_FileSystem(
                    fileSystemName: fileSystemName)
                .GetFileSystemClient(fileSystemName)
                .GetDirectoryClient(directoryName));

            // Act
            PathAccessControl accessControl = await sasDirectory.GetAccessControlAsync();

            // Assert
            Assert.IsNotNull(accessControl.Owner);
            Assert.IsNotNull(accessControl.Group);
            Assert.IsNotNull(accessControl.Permissions);
            Assert.IsNotNull(accessControl.AccessControlList);
        }

        [RecordedTest]
        public async Task GetAccessControlAsync_FileSystemIdentitySAS()
        {
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(service: oauthService, fileSystemName: fileSystemName);

            // Arrange
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            DataLakeDirectoryClient identitySasDirectory = InstrumentClient(
                GetServiceClient_DataLakeServiceIdentitySas_FileSystem(
                    fileSystemName: fileSystemName,
                    userDelegationKey: userDelegationKey)
                .GetFileSystemClient(fileSystemName)
                .GetDirectoryClient(directoryName));

            // Act
            PathAccessControl accessControl = await identitySasDirectory.GetAccessControlAsync();

            // Assert
            Assert.IsNotNull(accessControl.Owner);
            Assert.IsNotNull(accessControl.Group);
            Assert.IsNotNull(accessControl.Permissions);
            Assert.IsNotNull(accessControl.AccessControlList);
        }

        [RecordedTest]
        public async Task GetAccessControlAsync_PathSAS()
        {
            var fileSystemName = GetNewFileSystemName();
            var directoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);

            // Arrange
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);

            DataLakeDirectoryClient sasDirectory = InstrumentClient(
                GetServiceClient_DataLakeServiceSas_Path(
                    fileSystemName: fileSystemName,
                    path: directoryName)
                .GetFileSystemClient(fileSystemName)
                .GetDirectoryClient(directoryName));

            // Act
            PathAccessControl accessControl = await sasDirectory.GetAccessControlAsync();

            // Assert
            Assert.IsNotNull(accessControl.Owner);
            Assert.IsNotNull(accessControl.Group);
            Assert.IsNotNull(accessControl.Permissions);
            Assert.IsNotNull(accessControl.AccessControlList);
        }

        [RecordedTest]
        public async Task GetAccessControlAsync_PathIdentitySAS()
        {
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(service: oauthService, fileSystemName: fileSystemName);

            // Arrange
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            DataLakeDirectoryClient identitySasDirectory = InstrumentClient(
                GetServiceClient_DataLakeServiceIdentitySas_Path(
                    fileSystemName: fileSystemName,
                    path: directoryName,
                    userDelegationKey: userDelegationKey)
                .GetFileSystemClient(fileSystemName)
                .GetDirectoryClient(directoryName));

            // Act
            PathAccessControl accessControl = await identitySasDirectory.GetAccessControlAsync();

            // Assert
            Assert.IsNotNull(accessControl.Owner);
            Assert.IsNotNull(accessControl.Group);
            Assert.IsNotNull(accessControl.Permissions);
            Assert.IsNotNull(accessControl.AccessControlList);
        }

        [RecordedTest]
        public async Task GetAccessControlAsync_Error()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.GetAccessControlAsync(),
                e => Assert.AreEqual("PathNotFound", e.ErrorCode));
        }

        [RecordedTest]
        public async Task GetAccessControlAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                parameters.Match = await SetupPathMatchCondition(directory, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(directory, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                await directory.GetAccessControlAsync(conditions: conditions);
            }
        }

        [Ignore("service bug")]
        [RecordedTest]
        public async Task GetAccessControlAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                parameters.NoneMatch = await SetupPathMatchCondition(directory, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    directory.GetAccessControlAsync(conditions: conditions),
                    e => { });
            }
        }

        // Note that FileClient.GetAccessControl() does not need to pass CPK request headers.
        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_10_02)]
        public async Task GetAccessControlAsync_CPK()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeCustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem
                .GetDirectoryClient(GetNewDirectoryName())
                .WithCustomerProvidedKey(customerProvidedKey));
            await directory.CreateAsync();

            // Act
            PathAccessControl accessControl = await directory.GetAccessControlAsync();

            // Assert
            Assert.IsNotNull(accessControl.Owner);
            Assert.IsNotNull(accessControl.Group);
            Assert.IsNotNull(accessControl.Permissions);
            Assert.IsNotNull(accessControl.AccessControlList);
        }

        [RecordedTest]
        public async Task SetAccessControlAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Act
            Response<PathInfo> response = await directory.SetAccessControlListAsync(AccessControlList);

            // Assert
            AssertValidStoragePathInfo(response);
        }

        [RecordedTest]
        public async Task SetAccessControlAsync_RootDirectory()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            //DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetRootDirectoryClient());
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(""));

            // Act
            Response<PathInfo> response = await directory.SetPermissionsAsync(permissions: PathPermissions);

            // Assert
            AssertValidStoragePathInfo(response);
        }

        [RecordedTest]
        public async Task SetAccessControlAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                parameters.Match = await SetupPathMatchCondition(directory, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(directory, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<PathInfo> response = await directory.SetAccessControlListAsync(
                    accessControlList: AccessControlList,
                    conditions: conditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [RecordedTest]
        public async Task SetAccessControlAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                parameters.NoneMatch = await SetupPathMatchCondition(directory, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    directory.SetAccessControlListAsync(
                        accessControlList: AccessControlList,
                        conditions: conditions),
                    e => { });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_10_02)]
        public async Task SetAccessControlAsync_CPK()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeCustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem
                .GetDirectoryClient(GetNewDirectoryName())
                .WithCustomerProvidedKey(customerProvidedKey));
            await directory.CreateAsync();

            // Act
            Response<PathInfo> response = await directory.SetAccessControlListAsync(AccessControlList);

            // Assert
            AssertValidStoragePathInfo(response);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetAccessControlRecursiveAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file4 = await directory.CreateFileAsync(GetNewFileName());

            // Act
            AccessControlChangeResult result = await directory.SetAccessControlRecursiveAsync(AccessControlList, null);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(4, result.Counters.ChangedFilesCount);
            Assert.AreEqual(0, result.Counters.FailedChangesCount);
            Assert.IsNull(result.BatchFailures);
            Assert.IsNull(result.ContinuationToken);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetAccessControlRecursiveAsync_InBatches()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file4 = await directory.CreateFileAsync(GetNewFileName());

            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                BatchSize = 2
            };

            // Act
            AccessControlChangeResult result = await directory.SetAccessControlRecursiveAsync(
                AccessControlList,
                options: options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(4, result.Counters.ChangedFilesCount);
            Assert.AreEqual(0, result.Counters.FailedChangesCount);
            Assert.IsNull(result.BatchFailures);
            Assert.IsNull(result.ContinuationToken);
        }

        [Test]
        [LiveOnly]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetAccessControlRecursiveAsync_InBatches_StopAndResume()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file4 = await directory.CreateFileAsync(GetNewFileName());
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            AccessControlChanges? intermediateResult = default;
            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                BatchSize = 2,
                ProgressHandler = new Progress<Response<AccessControlChanges>>(x =>
                {
                    if (!intermediateResult.HasValue)
                    {
                        intermediateResult = x;
                    }
                    // sometimes cancellation fires late.
                    cancellationTokenSource.Cancel();
                })
            };

            // Act
            try
            {
                await directory.SetAccessControlRecursiveAsync(
                    AccessControlList,
                    options: options,
                    cancellationToken: cancellationTokenSource.Token);
            }
            catch (DataLakeAclChangeFailedException)
            {
                // skip Task Cancelled Exception
            }

            Assert.IsTrue(intermediateResult.HasValue);
            Assert.That(intermediateResult.Value.ContinuationToken, Is.Not.Null.Or.Empty, "Make sure it stopped in the middle");

            options.ProgressHandler = null;

            AccessControlChangeResult result = await directory.SetAccessControlRecursiveAsync(
                AccessControlList,
                continuationToken: intermediateResult.Value.ContinuationToken,
                options: options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount + intermediateResult.Value.BatchCounters.ChangedDirectoriesCount);
            Assert.AreEqual(4, result.Counters.ChangedFilesCount + intermediateResult.Value.BatchCounters.ChangedFilesCount);
            Assert.AreEqual(0, result.Counters.FailedChangesCount + intermediateResult.Value.BatchCounters.ChangedFilesCount);
            Assert.IsNull(result.BatchFailures);
            Assert.IsNull(result.ContinuationToken);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetAccessControlRecursiveAsync_InBatches_WithProgressMonitoring()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file4 = await directory.CreateFileAsync(GetNewFileName());

            InMemoryAccessControlRecursiveChangeProgress progress = new InMemoryAccessControlRecursiveChangeProgress();

            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                BatchSize = 2,
                ProgressHandler = progress
            };

            // Act
            AccessControlChangeResult result = await directory.SetAccessControlRecursiveAsync(
                AccessControlList,
                options: options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(4, result.Counters.ChangedFilesCount);
            Assert.AreEqual(0, result.Counters.FailedChangesCount);
            Assert.IsNull(result.BatchFailures);
            Assert.IsNull(result.ContinuationToken);
            Assert.AreEqual(4, progress.BatchCounters.Count);
            Assert.AreEqual(2, progress.BatchCounters[0].ChangedDirectoriesCount + progress.BatchCounters[0].ChangedFilesCount);
            Assert.AreEqual(2, progress.BatchCounters[1].ChangedDirectoriesCount + progress.BatchCounters[1].ChangedFilesCount);
            Assert.AreEqual(2, progress.BatchCounters[2].ChangedDirectoriesCount + progress.BatchCounters[2].ChangedFilesCount);
            Assert.AreEqual(1, progress.BatchCounters[3].ChangedDirectoriesCount + progress.BatchCounters[3].ChangedFilesCount);
            Assert.AreEqual(4, progress.CummulativeCounters.Count);
            Assert.AreEqual(2, progress.CummulativeCounters[0].ChangedDirectoriesCount + progress.CummulativeCounters[0].ChangedFilesCount);
            Assert.AreEqual(4, progress.CummulativeCounters[1].ChangedDirectoriesCount + progress.CummulativeCounters[1].ChangedFilesCount);
            Assert.AreEqual(6, progress.CummulativeCounters[2].ChangedDirectoriesCount + progress.CummulativeCounters[2].ChangedFilesCount);
            Assert.AreEqual(7, progress.CummulativeCounters[3].ChangedDirectoriesCount + progress.CummulativeCounters[3].ChangedFilesCount);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetAccessControlRecursiveAsync_InBatches_WithExplicitIteration()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file4 = await directory.CreateFileAsync(GetNewFileName());

            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                BatchSize = 2,
                MaxBatches = 2,
            };

            long changedDirectoriesCount = 0;
            long changedFilesCount = 0;
            long failedChangesCount = 0;
            int iterationCount = 0;
            AccessControlChangeResult result = default;

            // Act
            do
            {
                result = await directory.SetAccessControlRecursiveAsync(
                    AccessControlList,
                    continuationToken: result.ContinuationToken,
                    options);
                changedDirectoriesCount += result.Counters.ChangedDirectoriesCount;
                changedFilesCount += result.Counters.ChangedFilesCount;
                failedChangesCount += result.Counters.FailedChangesCount;
                iterationCount++;
            } while (!string.IsNullOrWhiteSpace(result.ContinuationToken) && iterationCount < 10);

            // Assert
            Assert.AreEqual(3, changedDirectoriesCount);
            Assert.AreEqual(4, changedFilesCount);
            Assert.AreEqual(0, failedChangesCount);
            Assert.AreEqual(2, iterationCount);
            Assert.IsNull(result.ContinuationToken);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task SetAccessControlRecursiveAsync_WithProgressMonitoring_WithFailure()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            // Create tree as AAD App
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Only allow subowner rights to the directory and it's subpaths
            string subowner = Recording.Random.NewGuid().ToString();
            await directory.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file3.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);

            // Add file without assigning subowner permissions to the file
            DataLakeFileClient file4 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Create a User Delegation SAS that delegates an owner when creating files
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            DataLakeUriBuilder dataLakeUriBuilderOwner1 = new DataLakeUriBuilder(directory.Uri)
            {
                Sas = GetNewDataLakeSasCredentialsOwner(fileSystemName, subowner, userDelegationKey, test.FileSystem.AccountName)
            };

            InMemoryAccessControlRecursiveChangeProgress progress = new InMemoryAccessControlRecursiveChangeProgress();

            // Create DirectoryClient with the SAS that the owner only has access to
            DataLakeDirectoryClient subownerDirectoryClient = new DataLakeDirectoryClient(dataLakeUriBuilderOwner1.ToUri(), GetOptions());

            // Act
            AccessControlChangeResult result = await subownerDirectoryClient.SetAccessControlRecursiveAsync(
                accessControlList: AccessControlList,
                options: new AccessControlChangeOptions() { ProgressHandler = progress });

            // Assert
            Assert.AreEqual(1, result.Counters.FailedChangesCount);
            Assert.AreEqual(1, progress.Failures.Count);
            Assert.AreEqual(1, result.BatchFailures.Length);
            Assert.AreEqual(file4.Path, result.BatchFailures.First().Name);
            Assert.AreEqual(false, result.BatchFailures.First().IsDirectory);
            Assert.That(progress.BatchCounters.FindIndex(x => x.FailedChangesCount > 0) >= 0);
            Assert.That(progress.CummulativeCounters.FindIndex(x => x.FailedChangesCount > 0) >= 0);
            AccessControlChangeFailure failure = progress.Failures[0];
            StringAssert.Contains(file4.Name, failure.Name);
            Assert.IsFalse(failure.IsDirectory);
            Assert.That(failure.ErrorMessage, Is.Not.Null.Or.Empty);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task SetAccessControlRecursiveAsync_ContinueOnFailure()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            // Create tree as AAD App
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Only allow subowner rights to the directory and it's subpaths
            string subowner = Recording.Random.NewGuid().ToString();
            await directory.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file3.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);

            // Add files without assigning subowner permissions to the files
            DataLakeFileClient file4 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file5 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file6 = await subdirectory2.CreateFileAsync(GetNewFileName());
            // Add directory without assigning subowner permissions to the directory
            DataLakeDirectoryClient subdirectory3 = await subdirectory2.CreateSubDirectoryAsync(GetNewDirectoryName());
            string[] failedPathNames = { file4.Path, file5.Path, file6.Path, subdirectory3.Path };

            // Create a User Delegation SAS that delegates an owner when creating files
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            DataLakeUriBuilder dataLakeUriBuilderOwner1 = new DataLakeUriBuilder(directory.Uri)
            {
                Sas = GetNewDataLakeSasCredentialsOwner(fileSystemName, subowner, userDelegationKey, test.FileSystem.AccountName)
            };

            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                ContinueOnFailure = true
            };

            // Create DirectoryClient with the SAS that the owner only has access to
            DataLakeDirectoryClient subownerDirectoryClient = new DataLakeDirectoryClient(dataLakeUriBuilderOwner1.ToUri(), GetOptions());

            // Act
            AccessControlChangeResult result = await subownerDirectoryClient.SetAccessControlRecursiveAsync(
                accessControlList: AccessControlList,
                options: options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(3, result.Counters.ChangedFilesCount);
            Assert.AreEqual(4, result.Counters.FailedChangesCount);
            Assert.AreEqual(4, result.BatchFailures.Length);
            foreach (AccessControlChangeFailure failure in result.BatchFailures)
            {
                Assert.Contains(failure.Name, failedPathNames);
            }
            Assert.IsNull(result.ContinuationToken);
        }

        [Test]
        [LiveOnly]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task SetAccessControlRecursiveAsync_ContinueOnFailure_Batches_StopAndResume()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            // Create tree as AAD App
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Only allow subowner permissions to the directory and it's subpaths
            string subowner = Recording.Random.NewGuid().ToString();
            await directory.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file3.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);

            // Add files without assigning subowner permissions to the files
            DataLakeFileClient file4 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file5 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file6 = await subdirectory2.CreateFileAsync(GetNewFileName());
            // Add directory without assigning subowner permissions to the directory
            DataLakeDirectoryClient subdirectory3 = await subdirectory2.CreateSubDirectoryAsync(GetNewDirectoryName());
            string[] failedPathNames = { file4.Path, file5.Path, file6.Path, subdirectory3.Path };

            // Add files and a directory and only allow subowner permissions
            DataLakeFileClient file7 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file8 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory4 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file9 = await subdirectory4.CreateFileAsync(GetNewFileName());
            await file7.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file8.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory4.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file9.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);

            // Create a User Delegation SAS that delegates an owner when creating files
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            DataLakeUriBuilder dataLakeUriBuilderOwner1 = new DataLakeUriBuilder(directory.Uri)
            {
                Sas = GetNewDataLakeSasCredentialsOwner(fileSystemName, subowner, userDelegationKey, test.FileSystem.AccountName)
            };

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            AccessControlChanges? intermediateResult = default;
            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                BatchSize = 2,
                ContinueOnFailure = true,
                ProgressHandler = new Progress<Response<AccessControlChanges>>(x =>
                {
                    if (!intermediateResult.HasValue)
                    {
                        intermediateResult = x;
                    }
                    // sometimes cancellation fires late.
                    cancellationTokenSource.Cancel();
                })
            };

            // Create DirectoryClient with the SAS that the owner only has access to
            DataLakeDirectoryClient subownerDirectoryClient = new DataLakeDirectoryClient(dataLakeUriBuilderOwner1.ToUri(), GetOptions());

            // Act
            try
            {
                await subownerDirectoryClient.SetAccessControlRecursiveAsync(
                    accessControlList: AccessControlList,
                    options: options,
                    cancellationToken: cancellationTokenSource.Token);
            }
            catch (DataLakeAclChangeFailedException)
            {
                // skip Task Canceled Exception
            }

            // Assert
            Assert.IsTrue(intermediateResult.HasValue);
            Assert.IsNotNull(intermediateResult.Value.ContinuationToken);

            // Arrange
            options.ProgressHandler = null;

            // Act
            AccessControlChangeResult result = await subownerDirectoryClient.SetAccessControlRecursiveAsync(
                accessControlList: AccessControlList,
                options: options,
                continuationToken: intermediateResult.Value.ContinuationToken);

            // Assert
            Assert.AreEqual(4, result.Counters.ChangedDirectoriesCount + intermediateResult.Value.BatchCounters.ChangedDirectoriesCount);
            Assert.AreEqual(6, result.Counters.ChangedFilesCount + intermediateResult.Value.BatchCounters.ChangedFilesCount);
            Assert.AreEqual(4, result.Counters.FailedChangesCount + intermediateResult.Value.BatchCounters.FailedChangesCount);
            foreach (AccessControlChangeFailure failure in result.BatchFailures)
            {
                Assert.Contains(failure.Name, failedPathNames);
            }
            foreach (AccessControlChangeFailure failure in intermediateResult.Value.BatchFailures)
            {
                Assert.Contains(failure.Name, failedPathNames);
            }
            Assert.IsNull(result.ContinuationToken);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task SetAccessControlRecursiveAsync_BatchFailures_BatchSize()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            // Create tree as AAD App
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            await directory.CreateAsync();
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Only allow subowner permissions to the directory and it's subpaths
            string subowner = Recording.Random.NewGuid().ToString();
            await directory.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file3.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);

            // Add files and directories without subowner permissions
            DataLakeFileClient file4 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file5 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file6 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory3 = await subdirectory2.CreateSubDirectoryAsync(GetNewDirectoryName());
            string[] failedPathNames = { file4.Path, file5.Path, file6.Path, subdirectory3.Path };

            // Create a User Delegation SAS that delegates an owner when creating files
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            DataLakeUriBuilder dataLakeUriBuilderOwner1 = new DataLakeUriBuilder(directory.Uri)
            {
                Sas = GetNewDataLakeSasCredentialsOwner(fileSystemName, subowner, userDelegationKey, test.FileSystem.AccountName)
            };

            // Create DirectoryClient with the SAS that the owner only has access to
            DataLakeDirectoryClient subownerDirectoryClient = new DataLakeDirectoryClient(dataLakeUriBuilderOwner1.ToUri(), GetOptions());

            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                MaxBatches = 2,
                BatchSize = 2,
                ContinueOnFailure = true
            };

            long changedDirectoriesCount = 0;
            long changedFilesCount = 0;
            long failedChangesCount = 0;
            int iterationCount = 0;
            AccessControlChangeResult result = default;

            // Act
            do
            {
                InMemoryAccessControlRecursiveChangeProgress progress = new InMemoryAccessControlRecursiveChangeProgress();
                options.ProgressHandler = progress;
                result = await subownerDirectoryClient.SetAccessControlRecursiveAsync(
                    accessControlList: AccessControlList,
                    continuationToken: result.ContinuationToken,
                    options: options);
                changedDirectoriesCount += result.Counters.ChangedDirectoriesCount;
                changedFilesCount += result.Counters.ChangedFilesCount;
                failedChangesCount += result.Counters.FailedChangesCount;
                if (result.Counters.FailedChangesCount > 0)
                {
                    Assert.AreEqual(progress.BatchFailures.First(), result.BatchFailures);
                    foreach (AccessControlChangeFailure failure in result.BatchFailures)
                    {
                        Assert.Contains(failure.Name, failedPathNames);
                    }
                }
                iterationCount++;
            } while (!string.IsNullOrWhiteSpace(result.ContinuationToken) && iterationCount < 10);

            // Assert
            Assert.AreEqual(3, changedDirectoriesCount);
            Assert.AreEqual(3, changedFilesCount);
            Assert.AreEqual(4, failedChangesCount);
            Assert.IsNull(result.ContinuationToken);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task SetAccessControlRecursiveAsync_ContinueOnFailure_RetrieveBatchFailures()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            // Create tree as AAD App
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            await directory.CreateAsync();
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Only allow subowner permissions to the directory and it's subpaths
            string subowner = Recording.Random.NewGuid().ToString();
            await directory.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file3.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);

            // Add files and directories without subowner permissions
            DataLakeFileClient file4 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file5 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file6 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory3 = await subdirectory2.CreateSubDirectoryAsync(GetNewDirectoryName());
            string[] failedPathNames = { file4.Path, file5.Path, file6.Path, subdirectory3.Path };

            // Create a User Delegation SAS that delegates an owner when creating files
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            DataLakeUriBuilder dataLakeUriBuilderOwner1 = new DataLakeUriBuilder(directory.Uri)
            {
                Sas = GetNewDataLakeSasCredentialsOwner(fileSystemName, subowner, userDelegationKey, test.FileSystem.AccountName)
            };

            InMemoryAccessControlRecursiveChangeProgress progress = new InMemoryAccessControlRecursiveChangeProgress();
            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                ContinueOnFailure = true,
                ProgressHandler = progress,
                BatchSize = 2
            };

            // Create DirectoryClient with the SAS that the owner only has access to
            DataLakeDirectoryClient subownerDirectoryClient = new DataLakeDirectoryClient(dataLakeUriBuilderOwner1.ToUri(), GetOptions());

            // Act
            AccessControlChangeResult result = await subownerDirectoryClient.SetAccessControlRecursiveAsync(
                accessControlList: AccessControlList,
                options: options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(3, result.Counters.ChangedFilesCount);
            Assert.AreEqual(4, result.Counters.FailedChangesCount);
            Assert.Greater(result.BatchFailures.Length, 0);
            Assert.AreEqual(progress.BatchFailures.First(), result.BatchFailures);
            Assert.IsNull(result.ContinuationToken);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetAccessControlRecursiveAsync_NetworkError()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();
            string sampleToken = Recording.Random.ToString().Substring(0, 16);

            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient rootDirectory = test.FileSystem.GetRootDirectoryClient();
            await rootDirectory.SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            TokenCredential tokenCredential = TestEnvironment.Credential;
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{topDirectoryName}").ToHttps();

            // Create tree as AAD App
            DataLakeClientOptions options = GetFaultyDataLakeConnectionOptions(
                raise: new RequestFailedException((int)HttpStatusCode.InternalServerError, "Internal Server Interuption"));
            DataLakeDirectoryClient directory = InstrumentClient(new DataLakeDirectoryClient(uri, tokenCredential, options));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<DataLakeAclChangeFailedException>(
                directory.SetAccessControlRecursiveAsync(
                    accessControlList: AccessControlList,
                    continuationToken: sampleToken),
                    e => Assert.AreEqual(e.ContinuationToken, sampleToken));
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetAccessControlRecursiveAsync_TaskCanceledError()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();
            string sampleToken = Recording.Random.ToString().Substring(0, 16);

            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient rootDirectory = test.FileSystem.GetRootDirectoryClient();
            await rootDirectory.SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            TokenCredential tokenCredential = TestEnvironment.Credential;
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{topDirectoryName}").ToHttps();

            // Create tree as AAD App
            DataLakeDirectoryClient directory = InstrumentClient(new DataLakeDirectoryClient(uri, tokenCredential, GetOptions()));

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<DataLakeAclChangeFailedException>(
                directory.SetAccessControlRecursiveAsync(
                    accessControlList: AccessControlList,
                    continuationToken: sampleToken,
                    cancellationToken: cancellationTokenSource.Token),
                    e => Assert.AreEqual(e.ContinuationToken, sampleToken));
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetAccessControlRecursiveAsync_Error()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            TokenCredential tokenCredential = TestEnvironment.Credential;
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{topDirectoryName}").ToHttps();

            // Create tree as AAD App
            DataLakeDirectoryClient directory = InstrumentClient(new DataLakeDirectoryClient(uri, tokenCredential, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<DataLakeAclChangeFailedException>(
                directory.SetAccessControlRecursiveAsync(accessControlList: AccessControlList),
                    e => { });
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UpdateAccessControlRecursiveAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file4 = await directory.CreateFileAsync(GetNewFileName());

            // Act
            AccessControlChangeResult result = await directory.UpdateAccessControlRecursiveAsync(AccessControlList, null);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(4, result.Counters.ChangedFilesCount);
            Assert.AreEqual(0, result.Counters.FailedChangesCount);
            Assert.IsNull(result.BatchFailures);
            Assert.IsNull(result.ContinuationToken);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UpdateAccessControlRecursiveAsync_InBatches()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file4 = await directory.CreateFileAsync(GetNewFileName());

            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                BatchSize = 2
            };

            // Act
            AccessControlChangeResult result = await directory.UpdateAccessControlRecursiveAsync(
                accessControlList: AccessControlList,
                options: options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(4, result.Counters.ChangedFilesCount);
            Assert.AreEqual(0, result.Counters.FailedChangesCount);
            Assert.IsNull(result.BatchFailures);
            Assert.IsNull(result.ContinuationToken);
        }

        [Test]
        [LiveOnly]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UpdateAccessControlRecursiveAsync_InBatches_StopAndResume()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file4 = await directory.CreateFileAsync(GetNewFileName());

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            AccessControlChanges? intermediateResult = default;
            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                BatchSize = 2,
                ProgressHandler = new Progress<Response<AccessControlChanges>>(x =>
                {
                    if (!intermediateResult.HasValue)
                    {
                        intermediateResult = x;
                    }
                    // sometimes cancellation fires late.
                    cancellationTokenSource.Cancel();
                })
            };

            // Act
            try
            {
                await directory.UpdateAccessControlRecursiveAsync(
                    AccessControlList,
                    options: options,
                    cancellationToken: cancellationTokenSource.Token);
            }
            catch (DataLakeAclChangeFailedException)
            {
                // skip Task Canceled Exception
            }

            Assert.IsTrue(intermediateResult.HasValue);
            Assert.That(intermediateResult.Value.ContinuationToken, Is.Not.Null.Or.Empty, "Make sure it stopped in the middle");

            options.ProgressHandler = null;
            AccessControlChangeResult result = await directory.UpdateAccessControlRecursiveAsync(
                AccessControlList,
                intermediateResult.Value.ContinuationToken,
                options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount + intermediateResult.Value.BatchCounters.ChangedDirectoriesCount);
            Assert.AreEqual(4, result.Counters.ChangedFilesCount + intermediateResult.Value.BatchCounters.ChangedFilesCount);
            Assert.AreEqual(0, result.Counters.FailedChangesCount + intermediateResult.Value.BatchCounters.ChangedFilesCount);
            Assert.IsNull(result.BatchFailures);
            Assert.IsNull(result.ContinuationToken);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UpdateAccessControlRecursiveAsync_InBatches_WithProgressMonitoring()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file4 = await directory.CreateFileAsync(GetNewFileName());

            InMemoryAccessControlRecursiveChangeProgress progress = new InMemoryAccessControlRecursiveChangeProgress();

            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                BatchSize = 2,
                ProgressHandler = progress
            };

            // Act
            AccessControlChangeResult result = await directory.UpdateAccessControlRecursiveAsync(
                AccessControlList,
                options: options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(4, result.Counters.ChangedFilesCount);
            Assert.AreEqual(0, result.Counters.FailedChangesCount);
            Assert.IsNull(result.BatchFailures);
            Assert.IsNull(result.ContinuationToken);
            Assert.AreEqual(4, progress.BatchCounters.Count);
            Assert.AreEqual(2, progress.BatchCounters[0].ChangedDirectoriesCount + progress.BatchCounters[0].ChangedFilesCount);
            Assert.AreEqual(2, progress.BatchCounters[1].ChangedDirectoriesCount + progress.BatchCounters[1].ChangedFilesCount);
            Assert.AreEqual(2, progress.BatchCounters[2].ChangedDirectoriesCount + progress.BatchCounters[2].ChangedFilesCount);
            Assert.AreEqual(1, progress.BatchCounters[3].ChangedDirectoriesCount + progress.BatchCounters[3].ChangedFilesCount);
            Assert.AreEqual(4, progress.CummulativeCounters.Count);
            Assert.AreEqual(2, progress.CummulativeCounters[0].ChangedDirectoriesCount + progress.CummulativeCounters[0].ChangedFilesCount);
            Assert.AreEqual(4, progress.CummulativeCounters[1].ChangedDirectoriesCount + progress.CummulativeCounters[1].ChangedFilesCount);
            Assert.AreEqual(6, progress.CummulativeCounters[2].ChangedDirectoriesCount + progress.CummulativeCounters[2].ChangedFilesCount);
            Assert.AreEqual(7, progress.CummulativeCounters[3].ChangedDirectoriesCount + progress.CummulativeCounters[3].ChangedFilesCount);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UpdateAccessControlRecursiveAsync_InBatches_WithExplicitIteration()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file4 = await directory.CreateFileAsync(GetNewFileName());

            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                BatchSize = 2,
                MaxBatches = 2,
            };

            long changedDirectoriesCount = 0;
            long changedFilesCount = 0;
            long failedChangesCount = 0;
            int iterationCount = 0;
            AccessControlChangeResult result = default;

            // Act
            do
            {
                result = await directory.UpdateAccessControlRecursiveAsync(
                    AccessControlList,
                    result.ContinuationToken,
                    options);
                changedDirectoriesCount += result.Counters.ChangedDirectoriesCount;
                changedFilesCount += result.Counters.ChangedFilesCount;
                failedChangesCount += result.Counters.FailedChangesCount;
                iterationCount++;
            } while (!string.IsNullOrWhiteSpace(result.ContinuationToken) && iterationCount < 10);

            // Assert
            Assert.AreEqual(3, changedDirectoriesCount);
            Assert.AreEqual(4, changedFilesCount);
            Assert.AreEqual(0, failedChangesCount);
            Assert.AreEqual(2, iterationCount);
            Assert.IsNull(result.BatchFailures);
            Assert.IsNull(result.ContinuationToken);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task UpdateAccessControlRecursiveAsync_WithProgressMonitoring_WithFailure()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            TokenCredential tokenCredential = TestEnvironment.Credential;
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{topDirectoryName}").ToHttps();

            // Create tree as AAD App
            DataLakeDirectoryClient directory = InstrumentClient(new DataLakeDirectoryClient(uri, tokenCredential, GetOptions()));
            await directory.CreateAsync();
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Only allow subowner rights to the directory and it's subpaths
            string subowner = Recording.Random.NewGuid().ToString();
            await directory.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file3.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);

            // Add file without subowner rights
            DataLakeFileClient file4 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Create a User Delegation SAS that delegates an owner when creating files
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            DataLakeUriBuilder dataLakeUriBuilderOwner1 = new DataLakeUriBuilder(directory.Uri)
            {
                Sas = GetNewDataLakeSasCredentialsOwner(fileSystemName, subowner, userDelegationKey, test.FileSystem.AccountName)
            };

            InMemoryAccessControlRecursiveChangeProgress progress = new InMemoryAccessControlRecursiveChangeProgress();
            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                ProgressHandler = progress
            };

            // Create DirectoryClient with the SAS that the owner only has access to
            DataLakeDirectoryClient subownerDirectoryClient = new DataLakeDirectoryClient(dataLakeUriBuilderOwner1.ToUri(), GetOptions());

            // Act
            AccessControlChangeResult result = await subownerDirectoryClient.UpdateAccessControlRecursiveAsync(
                accessControlList: AccessControlList,
                options: options);

            // Assert
            Assert.AreEqual(1, result.Counters.FailedChangesCount);
            Assert.AreEqual(1, progress.Failures.Count);
            Assert.AreEqual(1, result.BatchFailures.Length);
            Assert.AreEqual(file4.Path, result.BatchFailures.First().Name);
            Assert.AreEqual(false, result.BatchFailures.First().IsDirectory);
            Assert.That(progress.BatchCounters.FindIndex(x => x.FailedChangesCount > 0) >= 0);
            Assert.That(progress.CummulativeCounters.FindIndex(x => x.FailedChangesCount > 0) >= 0);
            AccessControlChangeFailure failure = progress.Failures[0];
            StringAssert.Contains(file4.Name, failure.Name);
            Assert.IsFalse(failure.IsDirectory);
            Assert.That(failure.ErrorMessage, Is.Not.Null.Or.Empty);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task UpdateAccessControlRecursiveAsync_ContinueOnFailure()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            // Create tree as AAD App
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Only allow subowner rights to the directory and it's subpaths
            string subowner = Recording.Random.NewGuid().ToString();
            await directory.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file3.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);

            // Add file as superuser
            DataLakeFileClient file4 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file5 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file6 = await subdirectory2.CreateFileAsync(GetNewFileName());
            // Add directory as superuser
            DataLakeDirectoryClient subdirectory3 = await subdirectory2.CreateSubDirectoryAsync(GetNewDirectoryName());
            string[] failedPathNames = { file4.Path, file5.Path, file6.Path, subdirectory3.Path };

            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                ContinueOnFailure = true
            };

            // Create a User Delegation SAS that delegates an owner when creating files
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            DataLakeUriBuilder dataLakeUriBuilderOwner1 = new DataLakeUriBuilder(directory.Uri)
            {
                Sas = GetNewDataLakeSasCredentialsOwner(fileSystemName, subowner, userDelegationKey, test.FileSystem.AccountName)
            };

            // Create DirectoryClient with the SAS that the owner only has access to
            DataLakeDirectoryClient subownerDirectoryClient = new DataLakeDirectoryClient(dataLakeUriBuilderOwner1.ToUri(), GetOptions());

            // Act
            AccessControlChangeResult result = await subownerDirectoryClient.UpdateAccessControlRecursiveAsync(
                accessControlList: AccessControlList,
                options: options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(3, result.Counters.ChangedFilesCount);
            Assert.AreEqual(4, result.Counters.FailedChangesCount);
            Assert.AreEqual(4, result.BatchFailures.Length);
            foreach (AccessControlChangeFailure failure in result.BatchFailures)
            {
                Assert.Contains(failure.Name, failedPathNames);
            }
            Assert.IsNull(result.ContinuationToken);
        }

        [Test]
        [LiveOnly]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task UpdateAccessControlRecursiveAsync_ContinueOnFailure_Batches_StopAndResume()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            // Create tree as AAD App
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Only allow subowner permissions to the directory and it's subpaths
            string subowner = Recording.Random.NewGuid().ToString();
            await directory.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file3.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);

            // Add files as superuser
            DataLakeFileClient file4 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file5 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file6 = await subdirectory2.CreateFileAsync(GetNewFileName());
            // Add directory as superuser
            DataLakeDirectoryClient subdirectory3 = await subdirectory2.CreateSubDirectoryAsync(GetNewDirectoryName());
            string[] failedPathNames = { file4.Path, file5.Path, file6.Path, subdirectory3.Path };

            // Add files and a directory as AAD app
            DataLakeFileClient file7 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file8 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory4 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file9 = await subdirectory4.CreateFileAsync(GetNewFileName());
            await file7.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file8.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory4.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file9.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);

            // Create a User Delegation SAS that delegates an owner when creating files
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            DataLakeUriBuilder dataLakeUriBuilderOwner1 = new DataLakeUriBuilder(directory.Uri)
            {
                Sas = GetNewDataLakeSasCredentialsOwner(fileSystemName, subowner, userDelegationKey, test.FileSystem.AccountName)
            };

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            AccessControlChanges? intermediateResult = default;
            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                BatchSize = 2,
                ContinueOnFailure = true,
                ProgressHandler = new Progress<Response<AccessControlChanges>>(x =>
                {
                    if (!intermediateResult.HasValue)
                    {
                        intermediateResult = x;
                    }
                    // sometimes cancellation fires late.
                    cancellationTokenSource.Cancel();
                })
            };

            // Create DirectoryClient with the SAS that the owner only has access to
            DataLakeDirectoryClient subownerDirectoryClient = new DataLakeDirectoryClient(dataLakeUriBuilderOwner1.ToUri(), GetOptions());

            // Act
            try
            {
                await subownerDirectoryClient.UpdateAccessControlRecursiveAsync(
                    accessControlList: AccessControlList,
                    options: options,
                    cancellationToken: cancellationTokenSource.Token);
            }
            catch (DataLakeAclChangeFailedException)
            {
                // skip Task Canceled Exception
            }

            // Assert
            Assert.IsTrue(intermediateResult.HasValue);
            Assert.IsNotNull(intermediateResult.Value.ContinuationToken);

            // Arrange
            options.ProgressHandler = null;

            // Act
            AccessControlChangeResult result = await subownerDirectoryClient.UpdateAccessControlRecursiveAsync(
                accessControlList: AccessControlList,
                options: options,
                continuationToken: intermediateResult.Value.ContinuationToken);

            // Assert
            Assert.AreEqual(4, result.Counters.ChangedDirectoriesCount + intermediateResult.Value.BatchCounters.ChangedDirectoriesCount);
            Assert.AreEqual(6, result.Counters.ChangedFilesCount + intermediateResult.Value.BatchCounters.ChangedFilesCount);
            Assert.AreEqual(4, result.Counters.FailedChangesCount + intermediateResult.Value.BatchCounters.FailedChangesCount);
            foreach (AccessControlChangeFailure failure in result.BatchFailures)
            {
                Assert.Contains(failure.Name, failedPathNames);
            }
            foreach (AccessControlChangeFailure failure in intermediateResult.Value.BatchFailures)
            {
                Assert.Contains(failure.Name, failedPathNames);
            }
            Assert.IsNull(result.ContinuationToken);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task UpdateAccessControlRecursiveAsync_BatchFailures_BatchSize()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            // Create tree as AAD App
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            await directory.CreateAsync();
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Only allow subowner permissions to the directory and it's subpaths
            string subowner = Recording.Random.NewGuid().ToString();
            await directory.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file3.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);

            // Add files and directories without subowner permissions
            DataLakeFileClient file4 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file5 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file6 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory3 = await subdirectory2.CreateSubDirectoryAsync(GetNewDirectoryName());
            string[] failedPathNames = { file4.Path, file5.Path, file6.Path, subdirectory3.Path };

            // Create a User Delegation SAS that delegates an owner when creating files
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            DataLakeUriBuilder dataLakeUriBuilderOwner1 = new DataLakeUriBuilder(directory.Uri)
            {
                Sas = GetNewDataLakeSasCredentialsOwner(fileSystemName, subowner, userDelegationKey, test.FileSystem.AccountName)
            };

            // Create DirectoryClient with the SAS that the owner only has access to
            DataLakeDirectoryClient subownerDirectoryClient = new DataLakeDirectoryClient(dataLakeUriBuilderOwner1.ToUri(), GetOptions());

            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                MaxBatches = 2,
                BatchSize = 2,
                ContinueOnFailure = true
            };

            long changedDirectoriesCount = 0;
            long changedFilesCount = 0;
            long failedChangesCount = 0;
            int iterationCount = 0;
            AccessControlChangeResult result = default;

            // Act
            do
            {
                InMemoryAccessControlRecursiveChangeProgress progress = new InMemoryAccessControlRecursiveChangeProgress();
                options.ProgressHandler = progress;
                result = await subownerDirectoryClient.UpdateAccessControlRecursiveAsync(
                    accessControlList: AccessControlList,
                    continuationToken: result.ContinuationToken,
                    options: options);
                changedDirectoriesCount += result.Counters.ChangedDirectoriesCount;
                changedFilesCount += result.Counters.ChangedFilesCount;
                failedChangesCount += result.Counters.FailedChangesCount;
                if (result.Counters.FailedChangesCount > 0)
                {
                    Assert.AreEqual(progress.BatchFailures.First(), result.BatchFailures);
                    foreach (AccessControlChangeFailure failure in result.BatchFailures)
                    {
                        Assert.Contains(failure.Name, failedPathNames);
                    }
                }
                iterationCount++;
            } while (!string.IsNullOrWhiteSpace(result.ContinuationToken) && iterationCount < 10);

            // Assert
            Assert.AreEqual(3, changedDirectoriesCount);
            Assert.AreEqual(3, changedFilesCount);
            Assert.AreEqual(4, failedChangesCount);
            Assert.IsNull(result.ContinuationToken);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task UpdateAccessControlRecursiveAsync_ContinueOnFailure_RetrieveBatchFailures()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            // Create tree as AAD App
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            await directory.CreateAsync();
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Only allow subowner permissions to the directory and it's subpaths
            string subowner = Recording.Random.NewGuid().ToString();
            await directory.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file3.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);

            // Add files and directories without subowner permissions
            DataLakeFileClient file4 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file5 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file6 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory3 = await subdirectory2.CreateSubDirectoryAsync(GetNewDirectoryName());
            string[] failedPathNames = { file4.Path, file5.Path, file6.Path, subdirectory3.Path };

            // Create a User Delegation SAS that delegates an owner when creating files
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            DataLakeUriBuilder dataLakeUriBuilderOwner1 = new DataLakeUriBuilder(directory.Uri)
            {
                Sas = GetNewDataLakeSasCredentialsOwner(fileSystemName, subowner, userDelegationKey, test.FileSystem.AccountName)
            };

            InMemoryAccessControlRecursiveChangeProgress progress = new InMemoryAccessControlRecursiveChangeProgress();
            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                ContinueOnFailure = true,
                ProgressHandler = progress,
                BatchSize = 2
            };

            // Create DirectoryClient with the SAS that the owner only has access to
            DataLakeDirectoryClient subownerDirectoryClient = new DataLakeDirectoryClient(dataLakeUriBuilderOwner1.ToUri(), GetOptions());

            // Act
            AccessControlChangeResult result = await subownerDirectoryClient.UpdateAccessControlRecursiveAsync(
                accessControlList: AccessControlList,
                options: options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(3, result.Counters.ChangedFilesCount);
            Assert.AreEqual(4, result.Counters.FailedChangesCount);
            Assert.Greater(result.BatchFailures.Length, 0);
            Assert.AreEqual(progress.BatchFailures.First(), result.BatchFailures);
            Assert.IsNull(result.ContinuationToken);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UpdateAccessControlRecursiveAsync_NetworkError()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();
            string sampleToken = Recording.Random.ToString().Substring(0, 16);

            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient rootDirectory = test.FileSystem.GetRootDirectoryClient();
            await rootDirectory.SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            TokenCredential tokenCredential = TestEnvironment.Credential;
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{topDirectoryName}").ToHttps();

            // Create tree as AAD App
            DataLakeClientOptions options = GetFaultyDataLakeConnectionOptions(
                raise: new RequestFailedException((int)HttpStatusCode.InternalServerError, "Internal Server Interuption"));
            DataLakeDirectoryClient directory = InstrumentClient(new DataLakeDirectoryClient(uri, tokenCredential, options));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<DataLakeAclChangeFailedException>(
                directory.UpdateAccessControlRecursiveAsync(
                    accessControlList: AccessControlList,
                    continuationToken: sampleToken),
                    e => Assert.AreEqual(e.ContinuationToken, sampleToken));
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UpdateAccessControlRecursiveAsync_TaskCanceledError()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();
            string sampleToken = Recording.Random.ToString().Substring(0, 16);

            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient rootDirectory = test.FileSystem.GetRootDirectoryClient();
            await rootDirectory.SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            TokenCredential tokenCredential = TestEnvironment.Credential;
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{topDirectoryName}").ToHttps();

            // Create tree as AAD App
            DataLakeDirectoryClient directory = InstrumentClient(new DataLakeDirectoryClient(uri, tokenCredential, GetOptions()));

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<DataLakeAclChangeFailedException>(
                directory.UpdateAccessControlRecursiveAsync(
                    accessControlList: AccessControlList,
                    continuationToken: sampleToken,
                    cancellationToken: cancellationTokenSource.Token),
                    e => Assert.AreEqual(e.ContinuationToken, sampleToken));
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UpdateAccessControlRecursiveAsync_Error()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            TokenCredential tokenCredential = TestEnvironment.Credential;
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{topDirectoryName}").ToHttps();

            // Create tree as AAD App
            DataLakeDirectoryClient directory = InstrumentClient(new DataLakeDirectoryClient(uri, tokenCredential, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<DataLakeAclChangeFailedException>(
                directory.UpdateAccessControlRecursiveAsync(
                    accessControlList: AccessControlList),
                    e => { });
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task RemoveAccessControlRecursiveAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file4 = await directory.CreateFileAsync(GetNewFileName());

            // Act
            AccessControlChangeResult result = await directory.RemoveAccessControlRecursiveAsync(RemoveAccessControlList, null);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(4, result.Counters.ChangedFilesCount);
            Assert.AreEqual(0, result.Counters.FailedChangesCount);
            Assert.IsNull(result.BatchFailures);
            Assert.IsNull(result.ContinuationToken);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task RemoveAccessControlRecursiveAsync_InBatches()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file4 = await directory.CreateFileAsync(GetNewFileName());

            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                BatchSize = 2
            };

            // Act
            AccessControlChangeResult result = await directory.RemoveAccessControlRecursiveAsync(
                RemoveAccessControlList,
                options: options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(4, result.Counters.ChangedFilesCount);
            Assert.AreEqual(0, result.Counters.FailedChangesCount);
            Assert.IsNull(result.BatchFailures);
            Assert.IsNull(result.ContinuationToken);
        }

        [Test]
        [LiveOnly]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task RemoveAccessControlRecursiveAsync_InBatches_StopAndResume()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file4 = await directory.CreateFileAsync(GetNewFileName());

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            AccessControlChanges? intermediateResult = default;
            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                BatchSize = 2,
                ProgressHandler = new Progress<Response<AccessControlChanges>>(x =>
                {
                    if (!intermediateResult.HasValue)
                    {
                        intermediateResult = x;
                    }
                    // sometimes cancellation fires late.
                    cancellationTokenSource.Cancel();
                })
            };

            // Act
            try
            {
                await directory.RemoveAccessControlRecursiveAsync(
                    RemoveAccessControlList,
                    options: options,
                    cancellationToken: cancellationTokenSource.Token);
            }
            catch (DataLakeAclChangeFailedException)
            {
                // skip Task Canceled Exception
            }

            Assert.IsTrue(intermediateResult.HasValue);
            Assert.That(intermediateResult.Value.ContinuationToken, Is.Not.Null.Or.Empty, "Make sure it stopped in the middle");

            options.ProgressHandler = null;

            AccessControlChangeResult result = await directory.RemoveAccessControlRecursiveAsync(
                RemoveAccessControlList,
                intermediateResult.Value.ContinuationToken,
                options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount + intermediateResult.Value.BatchCounters.ChangedDirectoriesCount);
            Assert.AreEqual(4, result.Counters.ChangedFilesCount + intermediateResult.Value.BatchCounters.ChangedFilesCount);
            Assert.AreEqual(0, result.Counters.FailedChangesCount + intermediateResult.Value.BatchCounters.ChangedFilesCount);
            Assert.IsNull(result.BatchFailures);
            Assert.IsNull(result.ContinuationToken);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task RemoveAccessControlRecursiveAsync_InBatches_WithProgressMonitoring()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file4 = await directory.CreateFileAsync(GetNewFileName());

            InMemoryAccessControlRecursiveChangeProgress progress = new InMemoryAccessControlRecursiveChangeProgress();

            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                BatchSize = 2,
                ProgressHandler = progress
            };

            // Act
            AccessControlChangeResult result = await directory.RemoveAccessControlRecursiveAsync(
                RemoveAccessControlList,
                options: options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(4, result.Counters.ChangedFilesCount);
            Assert.AreEqual(0, result.Counters.FailedChangesCount);
            Assert.IsNull(result.BatchFailures);
            Assert.IsNull(result.ContinuationToken);
            Assert.AreEqual(4, progress.BatchCounters.Count);
            Assert.AreEqual(2, progress.BatchCounters[0].ChangedDirectoriesCount + progress.BatchCounters[0].ChangedFilesCount);
            Assert.AreEqual(2, progress.BatchCounters[1].ChangedDirectoriesCount + progress.BatchCounters[1].ChangedFilesCount);
            Assert.AreEqual(2, progress.BatchCounters[2].ChangedDirectoriesCount + progress.BatchCounters[2].ChangedFilesCount);
            Assert.AreEqual(1, progress.BatchCounters[3].ChangedDirectoriesCount + progress.BatchCounters[3].ChangedFilesCount);
            Assert.AreEqual(4, progress.CummulativeCounters.Count);
            Assert.AreEqual(2, progress.CummulativeCounters[0].ChangedDirectoriesCount + progress.CummulativeCounters[0].ChangedFilesCount);
            Assert.AreEqual(4, progress.CummulativeCounters[1].ChangedDirectoriesCount + progress.CummulativeCounters[1].ChangedFilesCount);
            Assert.AreEqual(6, progress.CummulativeCounters[2].ChangedDirectoriesCount + progress.CummulativeCounters[2].ChangedFilesCount);
            Assert.AreEqual(7, progress.CummulativeCounters[3].ChangedDirectoriesCount + progress.CummulativeCounters[3].ChangedFilesCount);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task RemoveAccessControlRecursiveAsync_InBatches_WithExplicitIteration()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file4 = await directory.CreateFileAsync(GetNewFileName());

            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                BatchSize = 2,
                MaxBatches = 2,
            };

            long changedDirectoriesCount = 0;
            long changedFilesCount = 0;
            long failedChangesCount = 0;
            int iterationCount = 0;
            AccessControlChangeResult result = default;

            // Act
            do
            {
                result = await directory.RemoveAccessControlRecursiveAsync(
                    RemoveAccessControlList,
                    result.ContinuationToken,
                    options);
                changedDirectoriesCount += result.Counters.ChangedDirectoriesCount;
                changedFilesCount += result.Counters.ChangedFilesCount;
                failedChangesCount += result.Counters.FailedChangesCount;
                iterationCount++;
            } while (!string.IsNullOrWhiteSpace(result.ContinuationToken) && iterationCount < 10);

            // Assert
            Assert.AreEqual(3, changedDirectoriesCount);
            Assert.AreEqual(4, changedFilesCount);
            Assert.AreEqual(0, failedChangesCount);
            Assert.AreEqual(2, iterationCount);
            Assert.IsNull(result.BatchFailures);
            Assert.IsNull(result.ContinuationToken);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task RemoveAccessControlRecursiveAsync_WithProgressMonitoring_WithFailure()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            // Create tree as AAD App
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Only allow subowner permissions to the directory and it's subpaths
            string subowner = Recording.Random.NewGuid().ToString();
            await directory.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file3.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);

            // Add file without subowner permissions
            DataLakeFileClient file4 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateFileAsync(GetNewFileName());

            InMemoryAccessControlRecursiveChangeProgress progress = new InMemoryAccessControlRecursiveChangeProgress();

            // Create a User Delegation SAS that delegates an owner when creating files
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            DataLakeUriBuilder dataLakeUriBuilderOwner1 = new DataLakeUriBuilder(directory.Uri)
            {
                Sas = GetNewDataLakeSasCredentialsOwner(fileSystemName, subowner, userDelegationKey, test.FileSystem.AccountName)
            };

            // Create DirectoryClient with the SAS that the owner only has access to
            DataLakeDirectoryClient subownerDirectoryClient = new DataLakeDirectoryClient(dataLakeUriBuilderOwner1.ToUri(), GetOptions());

            // Act
            AccessControlChangeResult result = await subownerDirectoryClient.RemoveAccessControlRecursiveAsync(
                accessControlList: RemoveAccessControlList,
                options: new AccessControlChangeOptions() { ProgressHandler = progress });

            // Assert
            Assert.AreEqual(1, result.Counters.FailedChangesCount);
            Assert.AreEqual(1, progress.Failures.Count);
            Assert.AreEqual(1, result.BatchFailures.Length);
            Assert.AreEqual(file4.Path, result.BatchFailures.First().Name);
            Assert.AreEqual(false, result.BatchFailures.First().IsDirectory);
            Assert.That(progress.BatchCounters.FindIndex(x => x.FailedChangesCount > 0) >= 0);
            Assert.That(progress.CummulativeCounters.FindIndex(x => x.FailedChangesCount > 0) >= 0);
            AccessControlChangeFailure failure = progress.Failures[0];
            StringAssert.Contains(file4.Name, failure.Name);
            Assert.IsFalse(failure.IsDirectory);
            Assert.That(failure.ErrorMessage, Is.Not.Null.Or.Empty);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task RemoveAccessControlRecursiveAsync_ContinueOnFailure()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            // Create tree as AAD App
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Only allow subowner permissions to the directory and it's subpaths
            string subowner = Recording.Random.NewGuid().ToString();
            await directory.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file3.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);

            // Add files without assigning subowner permissions to the files
            DataLakeFileClient file4 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file5 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file6 = await subdirectory2.CreateFileAsync(GetNewFileName());
            // Add directory without assigning subowner permissions to the directory
            DataLakeDirectoryClient subdirectory3 = await subdirectory2.CreateSubDirectoryAsync(GetNewDirectoryName());
            string[] failedPathNames = { file4.Path, file5.Path, file6.Path, subdirectory3.Path };

            // Create a User Delegation SAS that delegates an owner when creating files
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            DataLakeUriBuilder dataLakeUriBuilderOwner1 = new DataLakeUriBuilder(directory.Uri)
            {
                Sas = GetNewDataLakeSasCredentialsOwner(fileSystemName, subowner, userDelegationKey, test.FileSystem.AccountName)
            };

            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                ContinueOnFailure = true
            };

            // Create DirectoryClient with the SAS that the owner only has access to
            DataLakeDirectoryClient subownerDirectoryClient = new DataLakeDirectoryClient(dataLakeUriBuilderOwner1.ToUri(), GetOptions());

            // Act
            AccessControlChangeResult result = await subownerDirectoryClient.RemoveAccessControlRecursiveAsync(
                accessControlList: RemoveAccessControlList,
                options: options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(3, result.Counters.ChangedFilesCount);
            Assert.AreEqual(4, result.Counters.FailedChangesCount);
            Assert.AreEqual(4, result.BatchFailures.Length);
            foreach (AccessControlChangeFailure failure in result.BatchFailures)
            {
                Assert.Contains(failure.Name, failedPathNames);
            }
            Assert.IsNull(result.ContinuationToken);
        }

        [Test]
        [LiveOnly]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task RemoveAccessControlRecursiveAsync_ContinueOnFailure_Batches_StopAndResume()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            // Create tree as AAD App
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Only allow subowner permissions to the directory and it's subpaths
            string subowner = Recording.Random.NewGuid().ToString();
            await directory.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file3.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);

            // Add files without assigning subowner permissions to the files
            DataLakeFileClient file4 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file5 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file6 = await subdirectory2.CreateFileAsync(GetNewFileName());
            // Add directory without assigning subowner permissions to the directory
            DataLakeDirectoryClient subdirectory3 = await subdirectory2.CreateSubDirectoryAsync(GetNewDirectoryName());
            string[] failedPathNames = { file4.Path, file5.Path, file6.Path, subdirectory3.Path };

            // Add files and a directory and only allow subowner permissions
            DataLakeFileClient file7 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file8 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory4 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file9 = await subdirectory4.CreateFileAsync(GetNewFileName());
            await file7.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file8.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory4.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file9.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);

            // Create a User Delegation SAS that delegates an owner when creating files
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            DataLakeUriBuilder dataLakeUriBuilderOwner1 = new DataLakeUriBuilder(directory.Uri)
            {
                Sas = GetNewDataLakeSasCredentialsOwner(fileSystemName, subowner, userDelegationKey, test.FileSystem.AccountName)
            };

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            AccessControlChanges? intermediateResult = default;
            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                BatchSize = 2,
                ContinueOnFailure = true,
                ProgressHandler = new Progress<Response<AccessControlChanges>>(x =>
                {
                    if (!intermediateResult.HasValue)
                    {
                        intermediateResult = x;
                    }
                    // sometimes cancellation fires late.
                    cancellationTokenSource.Cancel();
                })
            };

            // Create DirectoryClient with the SAS that the owner only has access to
            DataLakeDirectoryClient subownerDirectoryClient = new DataLakeDirectoryClient(dataLakeUriBuilderOwner1.ToUri(), GetOptions());
            // Act
            try
            {
                await subownerDirectoryClient.RemoveAccessControlRecursiveAsync(
                    accessControlList: RemoveAccessControlList,
                    options: options,
                    cancellationToken: cancellationTokenSource.Token);
            }
            catch (DataLakeAclChangeFailedException)
            {
                // skip Task Canceled Exception
            }

            // Assert
            Assert.IsTrue(intermediateResult.HasValue);
            Assert.IsNotNull(intermediateResult.Value.ContinuationToken);

            // Arrange
            options.ProgressHandler = null;

            // Act
            AccessControlChangeResult result = await subownerDirectoryClient.RemoveAccessControlRecursiveAsync(
                accessControlList: RemoveAccessControlList,
                options: options,
                continuationToken: intermediateResult.Value.ContinuationToken);

            // Assert
            Assert.AreEqual(4, result.Counters.ChangedDirectoriesCount + intermediateResult.Value.BatchCounters.ChangedDirectoriesCount);
            Assert.AreEqual(6, result.Counters.ChangedFilesCount + intermediateResult.Value.BatchCounters.ChangedFilesCount);
            Assert.AreEqual(4, result.Counters.FailedChangesCount + intermediateResult.Value.BatchCounters.FailedChangesCount);
            foreach (AccessControlChangeFailure failure in result.BatchFailures)
            {
                Assert.Contains(failure.Name, failedPathNames);
            }
            foreach (AccessControlChangeFailure failure in intermediateResult.Value.BatchFailures)
            {
                Assert.Contains(failure.Name, failedPathNames);
            }
            Assert.IsNull(result.ContinuationToken);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task RemoveAccessControlRecursiveAsync_BatchFailures_BatchSize()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            // Create tree as AAD App
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            await directory.CreateAsync();
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Only allow subowner permissions to the directory and it's subpaths
            string subowner = Recording.Random.NewGuid().ToString();
            await directory.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file3.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);

            // Add files and directories without subowner permissions
            DataLakeFileClient file4 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file5 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file6 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory3 = await subdirectory2.CreateSubDirectoryAsync(GetNewDirectoryName());
            string[] failedPathNames = { file4.Path, file5.Path, file6.Path, subdirectory3.Path };

            // Create a User Delegation SAS that delegates an owner when creating files
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            DataLakeUriBuilder dataLakeUriBuilderOwner1 = new DataLakeUriBuilder(directory.Uri)
            {
                Sas = GetNewDataLakeSasCredentialsOwner(fileSystemName, subowner, userDelegationKey, test.FileSystem.AccountName)
            };

            // Create DirectoryClient with the SAS that the owner only has access to
            DataLakeDirectoryClient subownerDirectoryClient = new DataLakeDirectoryClient(dataLakeUriBuilderOwner1.ToUri(), GetOptions());

            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                MaxBatches = 2,
                BatchSize = 2,
                ContinueOnFailure = true
            };

            long changedDirectoriesCount = 0;
            long changedFilesCount = 0;
            long failedChangesCount = 0;
            int iterationCount = 0;
            AccessControlChangeResult result = default;

            // Act
            do
            {
                InMemoryAccessControlRecursiveChangeProgress progress = new InMemoryAccessControlRecursiveChangeProgress();
                options.ProgressHandler = progress;
                result = await subownerDirectoryClient.RemoveAccessControlRecursiveAsync(
                    accessControlList: RemoveAccessControlList,
                    continuationToken: result.ContinuationToken,
                    options: options);
                changedDirectoriesCount += result.Counters.ChangedDirectoriesCount;
                changedFilesCount += result.Counters.ChangedFilesCount;
                failedChangesCount += result.Counters.FailedChangesCount;
                if (result.Counters.FailedChangesCount > 0)
                {
                    Assert.AreEqual(progress.BatchFailures.First(), result.BatchFailures);
                    foreach (AccessControlChangeFailure failure in result.BatchFailures)
                    {
                        Assert.Contains(failure.Name, failedPathNames);
                    }
                }
                iterationCount++;
            } while (!string.IsNullOrWhiteSpace(result.ContinuationToken) && iterationCount < 10);

            // Assert
            Assert.AreEqual(3, changedDirectoriesCount);
            Assert.AreEqual(3, changedFilesCount);
            Assert.AreEqual(4, failedChangesCount);
            Assert.IsNull(result.ContinuationToken);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task RemoveAccessControlRecursiveAsync_ContinueOnFailure_RetrieveBatchFailures()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            // Create tree as AAD App
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            await directory.CreateAsync();
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Only allow subowner permissions to the directory and it's subpaths
            string subowner = Recording.Random.NewGuid().ToString();
            await directory.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file1.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await subdirectory2.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);
            await file3.SetPermissionsAsync(permissions: PathPermissions, owner: subowner);

            // Add files and directories without subowner permissions
            DataLakeFileClient file4 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file5 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file6 = await subdirectory2.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory3 = await subdirectory2.CreateSubDirectoryAsync(GetNewDirectoryName());
            string[] failedPathNames = { file4.Path, file5.Path, file6.Path, subdirectory3.Path };

            // Create a User Delegation SAS that delegates an owner when creating files
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            DataLakeUriBuilder dataLakeUriBuilderOwner1 = new DataLakeUriBuilder(directory.Uri)
            {
                Sas = GetNewDataLakeSasCredentialsOwner(fileSystemName, subowner, userDelegationKey, test.FileSystem.AccountName)
            };

            InMemoryAccessControlRecursiveChangeProgress progress = new InMemoryAccessControlRecursiveChangeProgress();
            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                ContinueOnFailure = true,
                ProgressHandler = progress,
                BatchSize = 2
            };

            // Create DirectoryClient with the SAS that the owner only has access to
            DataLakeDirectoryClient subownerDirectoryClient = new DataLakeDirectoryClient(dataLakeUriBuilderOwner1.ToUri(), GetOptions());

            // Act
            AccessControlChangeResult result = await subownerDirectoryClient.RemoveAccessControlRecursiveAsync(
                accessControlList: RemoveAccessControlList,
                options: options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(3, result.Counters.ChangedFilesCount);
            Assert.AreEqual(4, result.Counters.FailedChangesCount);
            Assert.Greater(result.BatchFailures.Length, 0);
            Assert.AreEqual(progress.BatchFailures.First(), result.BatchFailures);
            Assert.IsNull(result.ContinuationToken);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task RemoveAccessControlRecursiveAsync_NetworkError()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();
            string sampleToken = Recording.Random.ToString().Substring(0, 16);

            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient rootDirectory = test.FileSystem.GetRootDirectoryClient();
            await rootDirectory.SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            TokenCredential tokenCredential = TestEnvironment.Credential;
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{topDirectoryName}").ToHttps();

            // Create tree as AAD App
            DataLakeClientOptions options = GetFaultyDataLakeConnectionOptions(
                raise: new RequestFailedException((int)HttpStatusCode.InternalServerError, "Internal Server Interuption"));
            DataLakeDirectoryClient directory = InstrumentClient(new DataLakeDirectoryClient(uri, tokenCredential, options));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<DataLakeAclChangeFailedException>(
                directory.RemoveAccessControlRecursiveAsync(
                    accessControlList: RemoveAccessControlList,
                    continuationToken: sampleToken),
                    e => Assert.AreEqual(e.ContinuationToken, sampleToken));
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task RemoveAccessControlRecursiveAsync_TaskCanceledError()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();
            string sampleToken = Recording.Random.ToString().Substring(0, 16);

            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient rootDirectory = test.FileSystem.GetRootDirectoryClient();
            await rootDirectory.SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            TokenCredential tokenCredential = TestEnvironment.Credential;
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{topDirectoryName}").ToHttps();

            // Create tree as AAD App
            DataLakeDirectoryClient directory = InstrumentClient(new DataLakeDirectoryClient(uri, tokenCredential, GetOptions()));

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<DataLakeAclChangeFailedException>(
                directory.RemoveAccessControlRecursiveAsync(
                    accessControlList: RemoveAccessControlList,
                    continuationToken: sampleToken,
                    cancellationToken: cancellationTokenSource.Token),
                    e => Assert.AreEqual(e.ContinuationToken, sampleToken));
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task RemoveAccessControlRecursiveAsync_Error()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            TokenCredential tokenCredential = TestEnvironment.Credential;
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{topDirectoryName}").ToHttps();

            // Create tree as AAD App
            DataLakeDirectoryClient directory = InstrumentClient(new DataLakeDirectoryClient(uri, tokenCredential, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<DataLakeAclChangeFailedException>(
                directory.RemoveAccessControlRecursiveAsync(
                    accessControlList: RemoveAccessControlList),
                    e => { });
        }

        [RecordedTest]
        public async Task SetPermissionsAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Act
            Response<PathInfo> response = await directory.SetPermissionsAsync(permissions: PathPermissions);

            // Assert
            AssertValidStoragePathInfo(response);
        }

        [RecordedTest]
        public async Task SetPermissionsAsync_JustOwner_JustGroup()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            string owner = Recording.Random.NewGuid().ToString();
            string group = Recording.Random.NewGuid().ToString();

            Response<PathAccessControl> initalGetAccessControlResponse = await directory.GetAccessControlAsync();

            // Act
            Response<PathInfo> response = await directory.SetPermissionsAsync(owner: owner);

            // Assert
            AssertValidStoragePathInfo(response);

            // Act
            response = await directory.SetPermissionsAsync(group: group);

            // Assert
            await directory.GetAccessControlAsync();
            AssertValidStoragePathInfo(response);
        }

        [RecordedTest]
        public async Task SetPermissionsAsync_RootDirectory()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            //DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetRootDirectoryClient());
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(""));

            // Act
            Response<PathInfo> response = await directory.SetPermissionsAsync(permissions: PathPermissions);

            // Assert
            AssertValidStoragePathInfo(response);
        }

        [RecordedTest]
        public async Task SetPermissionsAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                parameters.Match = await SetupPathMatchCondition(directory, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(directory, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<PathInfo> response = await directory.SetPermissionsAsync(
                    permissions: PathPermissions,
                    conditions: conditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [RecordedTest]
        public async Task SetPermissionsAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                parameters.NoneMatch = await SetupPathMatchCondition(directory, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    directory.SetPermissionsAsync(
                    permissions: PathPermissions,
                        conditions: conditions),
                    e => { });
            }
        }

        [RecordedTest]
        public async Task SetPermissionsAsync_CPK()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeCustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem
                .GetDirectoryClient(GetNewDirectoryName())
                .WithCustomerProvidedKey(customerProvidedKey));
            await directory.CreateAsync();

            // Act
            Response<PathInfo> response = await directory.SetPermissionsAsync(permissions: PathPermissions);

            // Assert
            AssertValidStoragePathInfo(response);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Act
            Response<PathProperties> response = await directory.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            Assert.IsTrue(response.Value.IsDirectory);

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_10_02)]
        public async Task GetPropertiesAsync_EncryptionScope()
        {
            // Arrange
            DataLakeFileSystemEncryptionScopeOptions encryptionScopeOptions = new DataLakeFileSystemEncryptionScopeOptions
            {
                DefaultEncryptionScope = TestConfigHierarchicalNamespace.EncryptionScope
            };
            await using DisposingFileSystem test = await GetNewFileSystem(encryptionScopeOptions: encryptionScopeOptions);
            DataLakeDirectoryClient directoryClient = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            await directoryClient.CreateAsync();

            // Act
            Response<PathProperties> response = await directoryClient.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(TestConfigHierarchicalNamespace.EncryptionScope, response.Value.EncryptionScope);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_Oauth()
        {
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(service: oauthService, fileSystemName: fileSystemName);

            // Arrange
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);
            DataLakeDirectoryClient oauthDirectory = oauthService
                .GetFileSystemClient(fileSystemName)
                .GetDirectoryClient(directoryName);

            // Act
            Response<PathProperties> response = await directory.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_FileSystemSAS()
        {
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);

            // Arrange
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);

            DataLakeDirectoryClient sasDirectory = InstrumentClient(
                GetServiceClient_DataLakeServiceSas_FileSystem(
                    fileSystemName: fileSystemName)
                .GetFileSystemClient(fileSystemName)
                .GetDirectoryClient(directoryName));

            // Act
            Response<PathProperties> response = await sasDirectory.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            var accountName = new DataLakeUriBuilder(test.FileSystem.Uri).AccountName;
            TestHelper.AssertCacheableProperty(accountName, () => directory.AccountName);
            TestHelper.AssertCacheableProperty(fileSystemName, () => directory.FileSystemName);
            TestHelper.AssertCacheableProperty(directoryName, () => directory.Name);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_FileSystemIdentitySAS()
        {
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(service: oauthService, fileSystemName: fileSystemName);

            // Arrange
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            DataLakeDirectoryClient identitySasDirectory = InstrumentClient(
                GetServiceClient_DataLakeServiceIdentitySas_FileSystem(
                    fileSystemName: fileSystemName,
                    userDelegationKey: userDelegationKey)
                .GetFileSystemClient(fileSystemName)
                .GetDirectoryClient(directoryName));

            // Act
            Response<PathProperties> response = await identitySasDirectory.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_PathSAS()
        {
            var fileSystemName = GetNewFileSystemName();
            var directoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);

            // Arrange
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);

            DataLakeDirectoryClient sasDirectory = InstrumentClient(
                GetServiceClient_DataLakeServiceSas_Path(
                    fileSystemName: fileSystemName,
                    path: directoryName)
                .GetFileSystemClient(fileSystemName)
                .GetDirectoryClient(directoryName));

            // Act
            Response<PathProperties> response = await sasDirectory.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_PathSasWithIdentifiers()
        {
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            string signedIdentifierId = GetNewString();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient directoryClient = InstrumentClient(test.FileSystem.GetDirectoryClient(directoryName));
            await directoryClient.CreateIfNotExistsAsync();

            DataLakeSignedIdentifier signedIdentifier = new DataLakeSignedIdentifier
            {
                Id = signedIdentifierId,
                AccessPolicy = new DataLakeAccessPolicy
                {
                    PolicyStartsOn = Recording.UtcNow.AddHours(-1),
                    PolicyExpiresOn = Recording.UtcNow.AddHours(1),
                    Permissions = "rw"
                }
            };

            await test.FileSystem.SetAccessPolicyAsync(permissions: new DataLakeSignedIdentifier[] { signedIdentifier });

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder
            {
                FileSystemName = fileSystemName,
                Identifier = signedIdentifierId
            };
            DataLakeSasQueryParameters sasQueryParameters = sasBuilder.ToSasQueryParameters(GetStorageSharedKeyCredentials());

            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(directoryClient.Uri)
            {
                Sas = sasQueryParameters
            };

            DataLakeDirectoryClient sasDirectoryClient = new DataLakeDirectoryClient(
                uriBuilder.ToUri(),
                GetOptions());

            // Act
            // It may take up to 30 seconds for policy to take effect.
            Response<PathProperties> response = await RetryAsync(async () => await sasDirectoryClient.GetPropertiesAsync(), e => e.Status == 403);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_PathIdentitySAS()
        {
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(service: oauthService, fileSystemName: fileSystemName);

            // Arrange
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            DataLakeDirectoryClient identitySasDirectory = InstrumentClient(
                GetServiceClient_DataLakeServiceIdentitySas_Path(
                    fileSystemName: fileSystemName,
                    path: directoryName,
                    userDelegationKey: userDelegationKey)
                .GetFileSystemClient(fileSystemName)
                .GetDirectoryClient(directoryName));

            // Act
            Response<PathProperties> response = await identitySasDirectory.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                // Arrange
                parameters.Match = await SetupPathMatchCondition(directory, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(directory, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<PathProperties> response = await directory.GetPropertiesAsync(conditions: conditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingFileSystem test = await GetNewFileSystem();
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                // Arrange
                parameters.NoneMatch = await SetupPathMatchCondition(directory, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                // Act
                await TestHelper.CatchAsync<Exception>(
                    async () =>
                    {
                        var _ = (await directory.GetPropertiesAsync(
                            conditions: conditions)).Value;
                    });
            }
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_Error()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.GetPropertiesAsync(),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_10_02)]
        [LiveOnly(Reason = "Encryption Key cannot be stored in recordings.")]
        public async Task GetSetPropertiesAsync_CPK()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeCustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem
                .GetDirectoryClient(GetNewDirectoryName())
                .WithCustomerProvidedKey(customerProvidedKey));
            await directory.CreateAsync();

            // Act
            await directory.SetHttpHeadersAsync(new PathHttpHeaders
            {
                CacheControl = constants.CacheControl,
                ContentDisposition = constants.ContentDisposition,
                ContentEncoding = constants.ContentEncoding,
                ContentLanguage = constants.ContentLanguage,
                ContentHash = constants.ContentMD5,
                ContentType = constants.ContentType
            });

            Response<PathProperties> response = await directory.GetPropertiesAsync();

            // Assert
            Assert.IsTrue(response.Value.IsServerEncrypted);
            Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_06_12)]
        [LiveOnly(Reason = "Encryption Key cannot be stored in recordings.")]
        public async Task GetPropertiesAsync_OwnerGroupPermissions()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Act
            Response<PathProperties> response = await directory.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.Value.Owner);
            Assert.IsNotNull(response.Value.Group);
            Assert.IsNotNull(response.Value.Permissions);
        }

        [RecordedTest]
        public async Task SetHttpHeadersAsync()
        {
            var constants = TestConstants.Create(this);

            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Act
            await directory.SetHttpHeadersAsync(new PathHttpHeaders
            {
                CacheControl = constants.CacheControl,
                ContentDisposition = constants.ContentDisposition,
                ContentEncoding = constants.ContentEncoding,
                ContentLanguage = constants.ContentLanguage,
                ContentHash = constants.ContentMD5,
                ContentType = constants.ContentType
            });

            // Assert
            Response<PathProperties> response = await directory.GetPropertiesAsync();
            Assert.AreEqual(constants.ContentType, response.Value.ContentType);
            TestHelper.AssertSequenceEqual(constants.ContentMD5, response.Value.ContentHash);
            Assert.AreEqual(constants.ContentEncoding, response.Value.ContentEncoding);
            Assert.AreEqual(constants.ContentLanguage, response.Value.ContentLanguage);
            Assert.AreEqual(constants.ContentDisposition, response.Value.ContentDisposition);
            Assert.AreEqual(constants.CacheControl, response.Value.CacheControl);
        }

        [RecordedTest]
        public async Task SetHttpHeadersAsync_Error()
        {
            var constants = TestConstants.Create(this);

            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.SetHttpHeadersAsync(new PathHttpHeaders
                {
                    CacheControl = constants.CacheControl,
                    ContentDisposition = constants.ContentDisposition,
                    ContentEncoding = constants.ContentEncoding,
                    ContentLanguage = constants.ContentLanguage,
                    ContentHash = constants.ContentMD5,
                    ContentType = constants.ContentType
                }),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [RecordedTest]
        public async Task SetHttpHeadersAsync_Conditions()
        {
            var constants = TestConstants.Create(this);
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                parameters.Match = await SetupPathMatchCondition(directory, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(directory, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<PathInfo> response = await directory.SetHttpHeadersAsync(
                    httpHeaders: new PathHttpHeaders
                    {
                        CacheControl = constants.CacheControl,
                        ContentDisposition = constants.ContentDisposition,
                        ContentEncoding = constants.ContentEncoding,
                        ContentLanguage = constants.ContentLanguage,
                        ContentHash = constants.ContentMD5,
                        ContentType = constants.ContentType
                    },
                    conditions: conditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [RecordedTest]
        public async Task SetHttpHeadersAsync_ConditionsFail()
        {
            var constants = TestConstants.Create(this);
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                parameters.NoneMatch = await SetupPathMatchCondition(directory, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    directory.SetHttpHeadersAsync(
                        httpHeaders: new PathHttpHeaders
                        {
                            CacheControl = constants.CacheControl,
                            ContentDisposition = constants.ContentDisposition,
                            ContentEncoding = constants.ContentEncoding,
                            ContentLanguage = constants.ContentLanguage,
                            ContentHash = constants.ContentMD5,
                            ContentType = constants.ContentType
                        },
                        conditions: conditions),
                    e => { });
            }
        }

        [RecordedTest]
        public async Task SetMetadataAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await directory.SetMetadataAsync(metadata);

            // Assert
            Response<PathProperties> response = await directory.GetPropertiesAsync();
            AssertMetadataEquality(metadata, response.Value.Metadata, isDirectory: true);
        }

        [RecordedTest]
        public async Task SetMetadataAsync_Error()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.SetMetadataAsync(metadata),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [RecordedTest]
        public async Task SetMetadataAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
                IDictionary<string, string> metadata = BuildMetadata();

                parameters.Match = await SetupPathMatchCondition(directory, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(directory, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<PathInfo> response = await directory.SetMetadataAsync(
                    metadata: metadata,
                    conditions: conditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [RecordedTest]
        public async Task SetMetadataAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
                IDictionary<string, string> metadata = BuildMetadata();

                parameters.NoneMatch = await SetupPathMatchCondition(directory, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    directory.SetMetadataAsync(
                        metadata: metadata,
                        conditions: conditions),
                    e => { });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_10_02)]
        public async Task SetMetadataAsync_CPK()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeCustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem
                .GetDirectoryClient(GetNewDirectoryName())
                .WithCustomerProvidedKey(customerProvidedKey));
            await directory.CreateAsync();

            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await directory.SetMetadataAsync(metadata);
        }

        [RecordedTest]
        public async Task CreateFileAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            string fileName = GetNewFileName();

            // Act
            Response<DataLakeFileClient> response = await directory.CreateFileAsync(fileName);

            // Assert
            Assert.AreEqual(fileName, response.Value.Name);
        }

        [RecordedTest]
        public async Task CreateFileAsync_HttpHeaders()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            PathHttpHeaders headers = new PathHttpHeaders
            {
                ContentType = ContentType,
                ContentEncoding = ContentEncoding,
                ContentLanguage = ContentLanguage,
                ContentDisposition = ContentDisposition,
                CacheControl = CacheControl
            };

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                HttpHeaders = headers
            };

            // Act
            DataLakeFileClient file = await directory.CreateFileAsync(GetNewFileName(), options: options);

            // Assert
            Response<PathProperties> response = await file.GetPropertiesAsync();
            Assert.AreEqual(ContentType, response.Value.ContentType);
            Assert.AreEqual(ContentEncoding, response.Value.ContentEncoding);
            Assert.AreEqual(ContentLanguage, response.Value.ContentLanguage);
            Assert.AreEqual(ContentDisposition, response.Value.ContentDisposition);
            Assert.AreEqual(CacheControl, response.Value.CacheControl);
        }

        [RecordedTest]
        public async Task CreateFileAsync_Metadata()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                Metadata = metadata
            };

            // Act
            DataLakeFileClient file = await directory.CreateFileAsync(GetNewFileName(), options: options);

            // Assert
            Response<PathProperties> getPropertiesResponse = await file.GetPropertiesAsync();
            AssertMetadataEquality(metadata, getPropertiesResponse.Value.Metadata, isDirectory: false);
        }

        [RecordedTest]
        public async Task CreateFileAsync_PermissionAndUmask()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            string permissions = "0777";
            string umask = "0057";

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                AccessOptions = new DataLakeAccessOptions
                {
                    Permissions = permissions,
                    Umask = umask
                }
            };

            // Act
            DataLakeFileClient file = await directory.CreateFileAsync(
                GetNewFileName(),
                options: options);

            // Assert
            Response<PathAccessControl> response = await file.GetAccessControlAsync();
            AssertPathPermissionsEquality(PathPermissions.ParseSymbolicPermissions("rwx-w----"), response.Value.Permissions);
        }

        [RecordedTest]
        public async Task CreateFileAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.CreateFileAsync(GetNewFileName()),
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode));
        }

        [RecordedTest]
        public async Task DeleteFileAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            string fileName = GetNewFileName();
            DataLakeFileClient fileClient = directory.GetFileClient(fileName);
            await fileClient.CreateIfNotExistsAsync();

            // Assert
            await directory.DeleteFileAsync(fileName);
        }

        [RecordedTest]
        public async Task DeleteFileAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.DeleteFileAsync(GetNewFileName()),
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode));
        }

        [RecordedTest]
        public async Task CreateSubDirectoryAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            string directoryName = GetNewDirectoryName();

            // Act
            Response<DataLakeDirectoryClient> response = await directory.CreateSubDirectoryAsync(directoryName);

            // Assert
            Assert.AreEqual(directoryName, response.Value.Name);
        }

        [RecordedTest]
        public async Task CreateSubDirectoryAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.CreateSubDirectoryAsync(GetNewDirectoryName()),
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode));
        }

        [RecordedTest]
        public async Task CreateSubDirectoryAsync_HttpHeaders()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            PathHttpHeaders headers = new PathHttpHeaders
            {
                ContentType = ContentType,
                ContentEncoding = ContentEncoding,
                ContentLanguage = ContentLanguage,
                ContentDisposition = ContentDisposition,
                CacheControl = CacheControl
            };

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                HttpHeaders = headers
            };

            // Act
            DataLakeDirectoryClient subDirectory = await directory.CreateSubDirectoryAsync(
                GetNewDirectoryName(),
                options: options);

            // Assert
            Response<PathProperties> response = await subDirectory.GetPropertiesAsync();
            Assert.AreEqual(ContentType, response.Value.ContentType);
            Assert.AreEqual(ContentEncoding, response.Value.ContentEncoding);
            Assert.AreEqual(ContentLanguage, response.Value.ContentLanguage);
            Assert.AreEqual(ContentDisposition, response.Value.ContentDisposition);
            Assert.AreEqual(CacheControl, response.Value.CacheControl);
        }

        [RecordedTest]
        public async Task CreateSubDirectoryAsync_Metadata()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                Metadata = metadata
            };

            // Act
            DataLakeDirectoryClient subDirectory = await directory.CreateSubDirectoryAsync(
                GetNewDirectoryName(),
                options: options);

            // Assert
            Response<PathProperties> getPropertiesResponse = await subDirectory.GetPropertiesAsync();
            AssertMetadataEquality(metadata, getPropertiesResponse.Value.Metadata, isDirectory: true);
        }

        [RecordedTest]
        public async Task CreateSubDirectoryAsync_PermissionAndUmask()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            string permissions = "0777";
            string umask = "0057";

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                AccessOptions = new DataLakeAccessOptions
                {
                    Permissions = permissions,
                    Umask = umask
                }
            };

            // Act
            DataLakeDirectoryClient subDirectory = await directory.CreateSubDirectoryAsync(
                GetNewDirectoryName(),
                options: options);

            // Assert
            Response<PathAccessControl> response = await subDirectory.GetAccessControlAsync();
            AssertPathPermissionsEquality(PathPermissions.ParseSymbolicPermissions("rwx-w----"), response.Value.Permissions);
        }

        [RecordedTest]
        public async Task CreateSubDirectoryAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                // Arrange
                // This directory is intentionally created twice
                DataLakeDirectoryClient subDirectory = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());

                parameters.Match = await SetupPathMatchCondition(subDirectory, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(subDirectory, parameters.LeaseId, garbageLeaseId);

                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                DataLakePathCreateOptions options = new DataLakePathCreateOptions
                {
                    Conditions = conditions
                };

                // Act
                Response<PathInfo> response = await subDirectory.CreateAsync(
                    options: options);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [RecordedTest]
        public async Task CreateSubDirectoryAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingFileSystem test = await GetNewFileSystem();
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                // Arrange
                // This directory is intentionally created twice
                DataLakeDirectoryClient subDirectory = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
                parameters.NoneMatch = await SetupPathMatchCondition(subDirectory, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                DataLakePathCreateOptions options = new DataLakePathCreateOptions
                {
                    Conditions = conditions
                };

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    subDirectory.CreateAsync(options: options),
                    e => { });
            }
        }

        [Test]
        [Ignore("Nightly live test is failing")]
        public async Task DeleteSubDirectoryAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            string directoryName = GetNewDirectoryName();
            DataLakeDirectoryClient directoryClient = directory.GetSubDirectoryClient(directoryName);
            await directoryClient.CreateIfNotExistsAsync();

            // Assert
            await directory.DeleteFileAsync(directoryName);
        }

        [RecordedTest]
        public async Task DeleteSubDirectoryAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                // Arrange
                DataLakeDirectoryClient subDirectory = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());

                parameters.Match = await SetupPathMatchCondition(subDirectory, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(subDirectory, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                await subDirectory.DeleteAsync(conditions: conditions);
            }
        }

        [RecordedTest]
        public async Task DeleteSubDirectoryAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingFileSystem test = await GetNewFileSystem();
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                // Arrange
                DataLakeDirectoryClient subDirectory = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());

                parameters.NoneMatch = await SetupPathMatchCondition(subDirectory, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    subDirectory.DeleteAsync(conditions: conditions),
                    e => { });
            }
        }

        [RecordedTest]
        public async Task AcquireLeaseAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            // Act
            Response<DataLakeLease> response = await InstrumentClient(directory.GetDataLakeLeaseClient(leaseId)).AcquireAsync(duration);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [RecordedTest]
        public async Task AcquireLeaseAsync_ExtendedExceptionMessage()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            string leaseId = Recording.Random.NewGuid().ToString();
            TimeSpan duration = TimeSpan.FromSeconds(10);
            DataLakeLeaseClient leaseClient = InstrumentClient(directory.GetDataLakeLeaseClient(leaseId));

            // Assert
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                leaseClient.AcquireAsync(duration),
                e =>
                {
                    Assert.AreEqual("InvalidHeaderValue", e.ErrorCode);
                    Assert.IsTrue(e.Message.Contains($"Additional Information:{Environment.NewLine}HeaderName: x-ms-lease-duration{Environment.NewLine}HeaderValue: 10"));
                });
        }

        [RecordedTest]
        public async Task AcquireLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.Match = await SetupPathMatchCondition(directory, parameters.Match);
                RequestConditions conditions = BuildRequestConditions(
                    parameters: parameters);

                // Act
                Response<DataLakeLease> response = await InstrumentClient(directory.GetDataLakeLeaseClient(leaseId)).AcquireAsync(
                    duration: duration,
                    conditions: conditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [RecordedTest]
        public async Task AcquireLeaseAsync_ConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_ConditionsFail_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.NoneMatch = await SetupPathMatchCondition(directory, parameters.NoneMatch);
                RequestConditions conditions = BuildRequestConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(directory.GetDataLakeLeaseClient(leaseId)).AcquireAsync(
                        duration: duration,
                        conditions: conditions),
                    e => { });
            }
        }

        [RecordedTest]
        public async Task AcquireLeaseAsync_Error()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(directory.GetDataLakeLeaseClient(leaseId)).AcquireAsync(duration),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [RecordedTest]
        public async Task RenewLeaseAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            DataLakeLeaseClient lease = InstrumentClient(directory.GetDataLakeLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            Response<DataLakeLease> response = await lease.RenewAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [RecordedTest]
        public async Task RenewLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.Match = await SetupPathMatchCondition(directory, parameters.Match);
                RequestConditions conditions = BuildRequestConditions(
                    parameters: parameters);

                DataLakeLeaseClient lease = InstrumentClient(directory.GetDataLakeLeaseClient(leaseId));
                await lease.AcquireAsync(duration: duration);

                // Act
                Response<DataLakeLease> response = await lease.RenewAsync(conditions: conditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [RecordedTest]
        public async Task RenewLeaseAsync_ConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_ConditionsFail_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.NoneMatch = await SetupPathMatchCondition(directory, parameters.NoneMatch);
                RequestConditions conditions = BuildRequestConditions(parameters);

                DataLakeLeaseClient lease = InstrumentClient(directory.GetDataLakeLeaseClient(leaseId));
                await lease.AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    lease.RenewAsync(conditions: conditions),
                    e => { });
            }
        }

        [RecordedTest]
        public async Task RenewLeaseAsync_Error()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            var leaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(directory.GetDataLakeLeaseClient(leaseId)).ReleaseAsync(),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [RecordedTest]
        public async Task ReleaseLeaseAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            DataLakeLeaseClient lease = InstrumentClient(directory.GetDataLakeLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            Response<ReleasedObjectInfo> response = await lease.ReleaseAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [RecordedTest]
        public async Task ReleaseLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.Match = await SetupPathMatchCondition(directory, parameters.Match);
                RequestConditions conditions = BuildRequestConditions(
                    parameters: parameters);

                DataLakeLeaseClient lease = InstrumentClient(directory.GetDataLakeLeaseClient(leaseId));
                await lease.AcquireAsync(duration: duration);

                // Act
                Response<ReleasedObjectInfo> response = await lease.ReleaseAsync(conditions: conditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [RecordedTest]
        public async Task ReleaseLeaseAsync_ConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_ConditionsFail_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.NoneMatch = await SetupPathMatchCondition(directory, parameters.NoneMatch);
                RequestConditions conditions = BuildRequestConditions(parameters);

                DataLakeLeaseClient lease = InstrumentClient(directory.GetDataLakeLeaseClient(leaseId));
                await lease.AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    lease.ReleaseAsync(conditions: conditions),
                    e => { });
            }
        }

        [RecordedTest]
        public async Task ReleaseLeaseAsync_Error()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            var leaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(directory.GetDataLakeLeaseClient(leaseId)).RenewAsync(),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [RecordedTest]
        public async Task ChangeLeaseAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            var leaseId = Recording.Random.NewGuid().ToString();
            var newLeaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            DataLakeLeaseClient lease = InstrumentClient(directory.GetDataLakeLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            Response<DataLakeLease> response = await lease.ChangeAsync(newLeaseId);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [RecordedTest]
        public async Task ChangeLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var newLeaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.Match = await SetupPathMatchCondition(directory, parameters.Match);
                RequestConditions conditions = BuildRequestConditions(
                    parameters: parameters);

                DataLakeLeaseClient lease = InstrumentClient(directory.GetDataLakeLeaseClient(leaseId));
                await lease.AcquireAsync(duration: duration);

                // Act
                Response<DataLakeLease> response = await lease.ChangeAsync(
                    proposedId: newLeaseId,
                    conditions: conditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [RecordedTest]
        public async Task ChangeLeaseAsync_ConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_ConditionsFail_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var newLeaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.NoneMatch = await SetupPathMatchCondition(directory, parameters.NoneMatch);
                RequestConditions conditions = BuildRequestConditions(parameters);

                DataLakeLeaseClient lease = InstrumentClient(directory.GetDataLakeLeaseClient(leaseId));
                await lease.AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    lease.ChangeAsync(
                        proposedId: newLeaseId,
                        conditions: conditions),
                    e => { });
            }
        }

        [RecordedTest]
        public async Task ChangeLeaseAsync_Error()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            var leaseId = Recording.Random.NewGuid().ToString();
            var newLeaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(directory.GetDataLakeLeaseClient(leaseId)).ChangeAsync(proposedId: newLeaseId),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [RecordedTest]
        public async Task BreakLeaseAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            DataLakeLeaseClient lease = InstrumentClient(directory.GetDataLakeLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            Response<DataLakeLease> response = await lease.BreakAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [RecordedTest]
        public async Task BreakLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.Match = await SetupPathMatchCondition(directory, parameters.Match);
                RequestConditions conditions = BuildRequestConditions(
                    parameters: parameters);

                DataLakeLeaseClient lease = InstrumentClient(directory.GetDataLakeLeaseClient(leaseId));
                await lease.AcquireAsync(duration: duration);

                // Act
                Response<DataLakeLease> response = await lease.BreakAsync(conditions: conditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [RecordedTest]
        public async Task BreakLeaseAsync_ConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_ConditionsFail_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.NoneMatch = await SetupPathMatchCondition(directory, parameters.NoneMatch);
                RequestConditions conditions = BuildRequestConditions(parameters);

                DataLakeLeaseClient lease = InstrumentClient(directory.GetDataLakeLeaseClient(leaseId));
                await lease.AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    lease.BreakAsync(conditions: conditions),
                    e => { });
            }
        }

        [RecordedTest]
        public async Task BreakLeaseAsync_Error()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(directory.GetDataLakeLeaseClient()).BreakAsync(),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [RecordedTest]
        public async Task GetDirectoryClientAsync_AsciiName()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            string directoryName = GetNewDirectoryName();
            DataLakeDirectoryClient directory = test.FileSystem.GetDirectoryClient(directoryName);
            await directory.CreateAsync();

            List<string> names = new List<string>();

            DataLakeGetPathsOptions options = new DataLakeGetPathsOptions
            {
                Recursive = true
            };

            await foreach (PathItem pathItem in test.FileSystem.GetPathsAsync(options))
            {
                names.Add(pathItem.Name);
            }

            // Verify the file name exists in the filesystem
            Assert.AreEqual(1, names.Count);
            Assert.Contains(directoryName, names);
        }

        [RecordedTest]
        public async Task GetDirectoryClientAsync_NonAsciiName()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            string directoryName = GetNewNonAsciiDirectoryName();
            DataLakeDirectoryClient file = test.FileSystem.GetDirectoryClient(directoryName);
            await file.CreateAsync();

            DataLakeGetPathsOptions options = new DataLakeGetPathsOptions
            {
                Recursive = true
            };

            List<string> names = new List<string>();
            await foreach (PathItem pathItem in test.FileSystem.GetPathsAsync(options))
            {
                names.Add(pathItem.Name);
            }

            // Verify the file name exists in the filesystem
            Assert.AreEqual(1, names.Count);
            Assert.Contains(directoryName, names);
        }

        [RecordedTest]
        public async Task GetSubDirectoryClientAsync_AsciiName()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            string directoryName = GetNewDirectoryName();
            string subDirectoryName = GetNewDirectoryName();
            string fullPathName = string.Join("/", directoryName, subDirectoryName);
            DataLakeDirectoryClient directory = test.FileSystem.GetDirectoryClient(directoryName);
            DataLakeDirectoryClient subdirectory = directory.GetSubDirectoryClient(subDirectoryName);

            await subdirectory.CreateAsync();

            DataLakeGetPathsOptions options = new DataLakeGetPathsOptions
            {
                Recursive = true
            };

            List<string> names = new List<string>();
            await foreach (PathItem pathItem in test.FileSystem.GetPathsAsync(options))
            {
                names.Add(pathItem.Name);
            }

            // Verify the file name exists in the filesystem
            Assert.AreEqual(2, names.Count);
            Assert.Contains(fullPathName, names);
        }

        [RecordedTest]
        public async Task GetSubDirectoryClientAsync_NonAsciiName()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            string directoryName = GetNewDirectoryName();
            string subDirectoryName = GetNewNonAsciiDirectoryName();
            string fullPathName = string.Join("/", directoryName, subDirectoryName);
            DataLakeDirectoryClient directory = test.FileSystem.GetDirectoryClient(directoryName);
            DataLakeDirectoryClient subdirectory = directory.GetSubDirectoryClient(subDirectoryName);

            await subdirectory.CreateAsync();

            DataLakeGetPathsOptions options = new DataLakeGetPathsOptions
            {
                Recursive = true
            };

            List<string> names = new List<string>();
            await foreach (PathItem pathItem in test.FileSystem.GetPathsAsync(options))
            {
                names.Add(pathItem.Name);
            }

            // Verify the file name exists in the filesystem
            Assert.AreEqual(2, names.Count);
            Assert.Contains(fullPathName, names);
        }

        [RecordedTest]
        [TestCase("directory", "!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("!'();[]", "!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("%21%27%28%29", "!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("directory", "%25%3D%2B%24%2C%23äÄöÖüÜß%3B")]
        [TestCase("!'();[]", "%21%27%28%29%5DäÄöÖüÜß%3B")]
        [TestCase("%21%27%28%", "%24%2C%23äÄöÖüÜß%3B")]
        [TestCase("directory", "my cool directory")]
        [TestCase("directory0", "directory1")]
        public async Task GetSubDirectoryClient_SpecialCharacters(string directoryName, string subDirectoryName)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);

            DataLakeDirectoryClient subDirectory = InstrumentClient(directory.GetSubDirectoryClient(subDirectoryName));
            Uri blobUri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{test.FileSystem.Name}/{Uri.EscapeDataString(directoryName)}/{Uri.EscapeDataString(subDirectoryName)}");
            Uri dfsUri = new Uri($"{BlobEndpointToDfsEndpoint(TestConfigHierarchicalNamespace.BlobServiceEndpoint)}/{test.FileSystem.Name}/{Uri.EscapeDataString(directoryName)}/{Uri.EscapeDataString(subDirectoryName)}");
            string expectedPath = $"{directoryName}/{subDirectoryName}";

            // Act
            Response<PathInfo> createResponse = await subDirectory.CreateAsync();

            DataLakeGetPathsOptions options = new DataLakeGetPathsOptions
            {
                Recursive = true
            };

            List<PathItem> pathItems = new List<PathItem>();
            await foreach (PathItem pathItem in test.FileSystem.GetPathsAsync(options))
            {
                pathItems.Add(pathItem);
            }

            PathItem filePathItem = pathItems.Where(r => r.Name == expectedPath).FirstOrDefault();

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(subDirectory.Uri);

            // Assert
            Assert.IsNotNull(filePathItem);
            Assert.AreEqual(subDirectoryName, subDirectory.Name);
            Assert.AreEqual(expectedPath, subDirectory.Path);

            Assert.AreEqual(blobUri, subDirectory.Uri);
            Assert.AreEqual(blobUri, subDirectory.BlobUri);
            Assert.AreEqual(dfsUri, subDirectory.DfsUri);

            Assert.AreEqual(subDirectoryName, dataLakeUriBuilder.LastDirectoryOrFileName);
            Assert.AreEqual(expectedPath, dataLakeUriBuilder.DirectoryOrFilePath);
            Assert.AreEqual(blobUri, dataLakeUriBuilder.ToUri());
        }

        [RecordedTest]
        [TestCase("directory", "!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("!'();[]", "!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("%21%27%28%29", "!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("directory", "%2B%24%2C%23äÄöÖüÜß%3B")]
        [TestCase("!'();[]", "%21%27%28%29%2C%23äÄöÖüÜß%3B")]
        [TestCase("%29%3B%5B%5D", "%24%2C%23äÄöÖüÜß%3B")]
        [TestCase("directory", "my cool file")]
        [TestCase("directory", "file")]
        public async Task GetFileClient_SpecialCharacters(string directoryName, string fileName)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(fileName));
            Uri blobUri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{test.FileSystem.Name}/{Uri.EscapeDataString(directoryName)}/{Uri.EscapeDataString(fileName)}");
            Uri dfsUri = new Uri($"{BlobEndpointToDfsEndpoint(TestConfigHierarchicalNamespace.BlobServiceEndpoint)}/{test.FileSystem.Name}/{Uri.EscapeDataString(directoryName)}/{Uri.EscapeDataString(fileName)}");
            string expectedPath = $"{directoryName}/{fileName}";

            // Act
            Response<PathInfo> createResponse = await file.CreateAsync();

            DataLakeGetPathsOptions options = new DataLakeGetPathsOptions
            {
                Recursive = true
            };

            List<PathItem> pathItems = new List<PathItem>();
            await foreach (PathItem pathItem in test.FileSystem.GetPathsAsync(options))
            {
                pathItems.Add(pathItem);
            }

            PathItem filePathItem = pathItems.Where(r => r.Name == expectedPath).FirstOrDefault();

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(file.Uri);

            // Assert
            Assert.IsNotNull(filePathItem);
            Assert.AreEqual(fileName, file.Name);
            Assert.AreEqual(expectedPath, file.Path);

            Assert.AreEqual(blobUri, file.Uri);
            Assert.AreEqual(blobUri, file.BlobUri);
            Assert.AreEqual(dfsUri, file.DfsUri);

            Assert.AreEqual(fileName, dataLakeUriBuilder.LastDirectoryOrFileName);
            Assert.AreEqual(expectedPath, dataLakeUriBuilder.DirectoryOrFilePath);
            Assert.AreEqual(blobUri, dataLakeUriBuilder.ToUri());
        }

        [RecordedTest]
        public async Task CreateSubDirectoryAndFileAsync()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            string subDirectoryName = GetNewDirectoryName();
            string fileName = GetNewFileName();

            // Act
            DataLakeDirectoryClient subdirectory = await directory.CreateSubDirectoryAsync(subDirectoryName);
            DataLakeFileClient file = await subdirectory.CreateFileAsync(fileName);

            // Assert
            Assert.AreEqual($"{subdirectory.DfsUri.AbsoluteUri}/{fileName}", file.DfsUri.AbsoluteUri);
            Assert.AreEqual($"{subdirectory.BlobUri.AbsoluteUri}/{fileName}", file.BlobUri.AbsoluteUri);
            Assert.AreEqual($"{subdirectory.Path}/{fileName}", file.Path);
        }

        [RecordedTest]
        public async Task CreateSubDirectoryAndSubDirectoryAsync()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            string subDirectoryName = GetNewDirectoryName();
            string lowerSubDirectoryName = GetNewDirectoryName();

            // Act
            DataLakeDirectoryClient subdirectory = await directory.CreateSubDirectoryAsync(subDirectoryName);
            DataLakeDirectoryClient lowerSubDirectory = await subdirectory.CreateSubDirectoryAsync(lowerSubDirectoryName);

            // Assert
            Assert.AreEqual($"{subdirectory.DfsUri.AbsoluteUri}/{lowerSubDirectoryName}", lowerSubDirectory.DfsUri.AbsoluteUri);
            Assert.AreEqual($"{subdirectory.BlobUri.AbsoluteUri}/{lowerSubDirectoryName}", lowerSubDirectory.BlobUri.AbsoluteUri);
            Assert.AreEqual($"{subdirectory.Path}/{lowerSubDirectoryName}", lowerSubDirectory.Path);
        }

        [RecordedTest]
        public async Task GetPathsAsync()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            string directoryName = GetNewDirectoryName();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);
            await SetUpDirectoryForListing(directory);

            // Act
            AsyncPageable<PathItem> response = directory.GetPathsAsync();
            IList<PathItem> paths = await response.ToListAsync();

            // Assert
            Assert.AreEqual(3, paths.Count);
            Assert.AreEqual($"{directoryName}/bar", paths[0].Name);
            Assert.AreEqual($"{directoryName}/baz", paths[1].Name);
            Assert.AreEqual($"{directoryName}/foo", paths[2].Name);
        }

        [RecordedTest]
        public async Task GetPathsAsync_UriCtor()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            string directoryName = GetNewDirectoryName();
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(test.FileSystem.Uri)
            {
                DirectoryOrFilePath = directoryName
            };
            DataLakeDirectoryClient directory = InstrumentClient(
                new DataLakeDirectoryClient(uriBuilder.ToUri(), GetStorageSharedKeyCredentials(), GetOptions()));
            await SetUpDirectoryForListing(directory);

            // Act
            AsyncPageable<PathItem> response = directory.GetPathsAsync();
            IList<PathItem> paths = await response.ToListAsync();

            // Assert
            Assert.AreEqual(3, paths.Count);
            Assert.AreEqual($"{directoryName}/bar", paths[0].Name);
            Assert.AreEqual($"{directoryName}/baz", paths[1].Name);
            Assert.AreEqual($"{directoryName}/foo", paths[2].Name);
        }

        [RecordedTest]
        public async Task GetPathsAsync_Recursive()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            string directoryName = GetNewDirectoryName();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);
            await SetUpDirectoryForListing(directory);

            DataLakeGetPathsOptions options = new DataLakeGetPathsOptions
            {
                Recursive = true
            };

            // Act
            AsyncPageable<PathItem> response = directory.GetPathsAsync(options);
            IList<PathItem> paths = await response.ToListAsync();

            // Assert
            Assert.AreEqual(PathNames.Length, paths.Count);
            Assert.AreEqual($"{directoryName}/bar", paths[0].Name);
            Assert.AreEqual($"{directoryName}/baz", paths[1].Name);
            Assert.AreEqual($"{directoryName}/baz/bar", paths[2].Name);
            Assert.AreEqual($"{directoryName}/baz/bar/foo", paths[3].Name);
            Assert.AreEqual($"{directoryName}/baz/foo", paths[4].Name);
            Assert.AreEqual($"{directoryName}/baz/foo/bar", paths[5].Name);
            Assert.AreEqual($"{directoryName}/foo", paths[6].Name);
            Assert.AreEqual($"{directoryName}/foo/bar", paths[7].Name);
            Assert.AreEqual($"{directoryName}/foo/foo", paths[8].Name);
        }

        [RecordedTest]
        public async Task GetPathsAsync_Upn()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            string directoryName = GetNewDirectoryName();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);
            await SetUpDirectoryForListing(directory);

            DataLakeGetPathsOptions options = new DataLakeGetPathsOptions
            {
                UserPrincipalName = true
            };

            // Act
            AsyncPageable<PathItem> response = directory.GetPathsAsync(options);
            IList<PathItem> paths = await response.ToListAsync();

            // Assert
            Assert.AreEqual(3, paths.Count);
            Assert.IsNotNull(paths[0].Group);
            Assert.IsNotNull(paths[0].Owner);

            Assert.AreEqual($"{directoryName}/bar", paths[0].Name);
            Assert.AreEqual($"{directoryName}/baz", paths[1].Name);
            Assert.AreEqual($"{directoryName}/foo", paths[2].Name);
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task GetPathsAsync_MaxResults()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            string directoryName = GetNewDirectoryName();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);
            await SetUpDirectoryForListing(directory);

            // Act
            Page<PathItem> page = await directory.GetPathsAsync().AsPages(pageSizeHint: 2).FirstAsync();

            // Assert
            Assert.AreEqual(2, page.Values.Count);
            Assert.AreEqual($"{directoryName}/bar", page.Values[0].Name);
            Assert.AreEqual($"{directoryName}/baz", page.Values[1].Name);
        }

        [RecordedTest]
        public async Task GetPathsAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.GetPathsAsync().ToListAsync(),
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode));
        }

        [RecordedTest]
        [RetryOnException(5, typeof(RequestFailedException))]
        public async Task GetPathsAsync_NonHns()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem(hnsEnabled: false);
            string directoryName = GetNewDirectoryName();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);
            await SetUpDirectoryForListing(directory);

            // Act
            AsyncPageable<PathItem> response = directory.GetPathsAsync();
            IList<PathItem> paths = await response.ToListAsync();

            // Assert
            Assert.AreEqual(3, paths.Count);
            Assert.AreEqual($"{directoryName}/bar", paths[0].Name);
            Assert.AreEqual($"{directoryName}/baz", paths[1].Name);
            Assert.AreEqual($"{directoryName}/foo", paths[2].Name);
            Assert.NotNull(paths[0].CreatedOn);
            Assert.NotNull(paths[1].CreatedOn);
            Assert.NotNull(paths[2].CreatedOn);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/52168")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetSetTags()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            Dictionary<string, string> tags = BuildTags();

            // Act
            await directory.SetTagsAsync(tags);
            Response<GetPathTagResult> getTagsResponse = await directory.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, getTagsResponse.Value.Tags);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/52168")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetSetTagsOAuth()
        {
            // Arrange
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            await using DisposingFileSystem test = await GetNewFileSystem(oauthService);
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            Dictionary<string, string> tags = BuildTags();

            // Act
            await directory.SetTagsAsync(tags);
            Response<GetPathTagResult> getTagsResponse = await directory.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, getTagsResponse.Value.Tags);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/52168")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetSetTags_Lease()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            Dictionary<string, string> tags = BuildTags();

            string leaseId = Recording.Random.NewGuid().ToString();
            TimeSpan duration = TimeSpan.FromSeconds(15);
            await InstrumentClient(directory.GetDataLakeLeaseClient(leaseId)).AcquireAsync(duration);

            DataLakeRequestConditions conditions = new DataLakeRequestConditions
            {
                LeaseId = leaseId
            };

            // Act
            await directory.SetTagsAsync(tags, conditions);
            Response<GetPathTagResult> getTagsResponse = await directory.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, getTagsResponse.Value.Tags);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/52168")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetTags_LeaseFailed()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            string leaseId = Recording.Random.NewGuid().ToString();

            DataLakeRequestConditions conditions = new DataLakeRequestConditions
            {
                LeaseId = leaseId
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.GetTagsAsync(conditions),
                e => Assert.AreEqual("LeaseNotPresentWithBlobOperation", e.ErrorCode));
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/52168")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task SetTags_LeaseFailed()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            Dictionary<string, string> tags = BuildTags();

            string leaseId = Recording.Random.NewGuid().ToString();

            DataLakeRequestConditions conditions = new DataLakeRequestConditions
            {
                LeaseId = leaseId
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.SetTagsAsync(tags, conditions),
                e => Assert.AreEqual("LeaseNotPresentWithBlobOperation", e.ErrorCode));
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/52168")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetSetTags_DirectorySas()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            Uri sasUri = directory.GenerateSasUri(DataLakeSasPermissions.All, Recording.UtcNow.AddHours(1));
            directory = InstrumentClient(new DataLakeDirectoryClient(sasUri, GetOptions()));

            Dictionary<string, string> tags = BuildTags();

            // Act
            await directory.SetTagsAsync(tags);
            Response<GetPathTagResult> getTagsResponse = await directory.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, getTagsResponse.Value.Tags);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/52168")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetSetTags_FileSystemSas()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            Uri fileSystemSasUri = test.FileSystem.GenerateSasUri(DataLakeFileSystemSasPermissions.All, Recording.UtcNow.AddHours(1));
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(fileSystemSasUri);
            uriBuilder.DirectoryOrFilePath = directory.Name;
            Uri fileSasUri = uriBuilder.ToUri();
            directory = InstrumentClient(new DataLakeDirectoryClient(fileSasUri, GetOptions()));

            Dictionary<string, string> tags = BuildTags();

            // Act
            await directory.SetTagsAsync(tags);
            Response<GetPathTagResult> getTagsResponse = await directory.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, getTagsResponse.Value.Tags);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/52168")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetSetTags_AccountSas()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(TestConfigHierarchicalNamespace.AccountName, TestConfigHierarchicalNamespace.AccountKey);
            SasQueryParameters sasQueryParameters = DataLakeClientBuilder.GetNewAccountSas(AccountSasResourceTypes.All, AccountSasPermissions.All, sharedKeyCredential);
            directory = InstrumentClient(new DataLakeDirectoryClient(new Uri($"{directory.Uri}?{sasQueryParameters}"), GetOptions()));

            Dictionary<string, string> tags = BuildTags();

            // Act
            await directory.SetTagsAsync(tags);
            Response<GetPathTagResult> getTagsResponse = await directory.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, getTagsResponse.Value.Tags);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/52168")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetSetTags_DirectoryIdentitySas()
        {
            // Arrange
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            await using DisposingFileSystem test = await GetNewFileSystem(oauthService);
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            Uri sasUri = directory.GenerateUserDelegationSasUri(DataLakeSasPermissions.All, Recording.UtcNow.AddHours(1), userDelegationKey);
            directory = InstrumentClient(new DataLakeDirectoryClient(sasUri, GetOptions()));

            Dictionary<string, string> tags = BuildTags();

            // Act
            await directory.SetTagsAsync(tags);
            Response<GetPathTagResult> getTagsResponse = await directory.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, getTagsResponse.Value.Tags);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/52168")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetSetTags_FileSystemIdentitySas()
        {
            // Arrange
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            await using DisposingFileSystem test = await GetNewFileSystem(oauthService);
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            Uri fileSystemSasUri = test.FileSystem.GenerateUserDelegationSasUri(DataLakeFileSystemSasPermissions.All, Recording.UtcNow.AddHours(1), userDelegationKey);
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(fileSystemSasUri);
            uriBuilder.DirectoryOrFilePath = directory.Name;
            Uri directorySasUri = uriBuilder.ToUri();
            directory = InstrumentClient(new DataLakeDirectoryClient(directorySasUri, GetOptions()));

            Dictionary<string, string> tags = BuildTags();

            // Act
            await directory.SetTagsAsync(tags);
            Response<GetPathTagResult> getTagsResponse = await directory.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, getTagsResponse.Value.Tags);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/52168")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetTags_Error()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.GetTagsAsync(),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/52168")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task SetTags_Error()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            Dictionary<string, string> tags = BuildTags();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.SetTagsAsync(tags),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/52168")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetSetTags_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                // Arrange
                await using DisposingFileSystem test = await GetNewFileSystem();
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                // Arrange
                parameters.Match = await SetupPathMatchCondition(directory, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(directory, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                Dictionary<string, string> tags = BuildTags();

                // Act
                await directory.SetTagsAsync(
                   tags: tags,
                   conditions: conditions);

                Response<GetPathTagResult> response = await directory.GetTagsAsync(
                    conditions: conditions);

                // Assert
                AssertDictionaryEquality(tags, response.Value.Tags);
            }
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/52168")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetTags_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                // Arrange
                await using DisposingFileSystem test = await GetNewFileSystem();
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                parameters.NoneMatch = await SetupPathMatchCondition(directory, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    directory.GetTagsAsync(
                        conditions: conditions),
                    e => { });
            }
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/52168")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task SetTags_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                // Arrange
                await using DisposingFileSystem test = await GetNewFileSystem();
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                parameters.NoneMatch = await SetupPathMatchCondition(directory, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                Dictionary<string, string> tags = BuildTags();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    directory.SetTagsAsync(
                        tags: tags,
                        conditions: conditions),
                    e => { });
            }
        }
        public async Task GetPathsAsync_BeginFrom()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            string directoryName = GetNewDirectoryName();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);
            await SetUpDirectoryForListing(directory);
            DataLakeGetPathsOptions options = new DataLakeGetPathsOptions
            {
                Recursive = true,
                StartFrom = "foo"
            };

            // Act
            AsyncPageable<PathItem> response = directory.GetPathsAsync(options);
            IList<PathItem> paths = await response.ToListAsync();

            // Assert
            Assert.AreEqual(3, paths.Count);
        }

        private async Task SetUpDirectoryForListing(DataLakeDirectoryClient directoryClient)
        {
            string[] pathNames = PathNames;
            DataLakeDirectoryClient[] subDirectories = new DataLakeDirectoryClient[pathNames.Length];

            // Upload directories
            for (var i = 0; i < pathNames.Length; i++)
            {
                DataLakeDirectoryClient directory = InstrumentClient(directoryClient.GetSubDirectoryClient(pathNames[i]));
                subDirectories[i] = directory;
                await directory.CreateIfNotExistsAsync();
            }
        }

        #region GenerateSasTests
        [RecordedTest]
        public void CanGenerateSas_ClientConstructors()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);

            // Act - DataLakeDirectoryClient(Uri blobContainerUri, fileClientOptions options = default)
            DataLakeDirectoryClient directory = InstrumentClient(new DataLakeDirectoryClient(
                blobEndpoint,
                GetOptions()));
            Assert.IsFalse(directory.CanGenerateSasUri);

            // Act - DataLakeDirectoryClient(Uri blobContainerUri, StorageSharedKeyCredential credential, fileClientOptions options = default)
            DataLakeDirectoryClient directory2 = InstrumentClient(new DataLakeDirectoryClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            Assert.IsTrue(directory2.CanGenerateSasUri);

            // Act - DataLakeDirectoryClient(Uri blobContainerUri, TokenCredential credential, fileClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            DataLakeDirectoryClient directory3 = InstrumentClient(new DataLakeDirectoryClient(
                blobEndpoint,
                tokenCredentials,
                GetOptions()));
            Assert.IsFalse(directory3.CanGenerateSasUri);
        }

        [RecordedTest]
        public void CanGenerateSas_GetFileClient()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);

            // Act - DataLakeDirectoryClient(Uri blobContainerUri, fileClientOptions options = default)
            DataLakeDirectoryClient directory = InstrumentClient(new DataLakeDirectoryClient(
                blobEndpoint,
                GetOptions()));
            DataLakeFileClient file = directory.GetFileClient(GetNewFileName());
            Assert.IsFalse(file.CanGenerateSasUri);

            // Act - DataLakeDirectoryClient(Uri blobContainerUri, StorageSharedKeyCredential credential, fileClientOptions options = default)
            DataLakeDirectoryClient directory2 = InstrumentClient(new DataLakeDirectoryClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            DataLakeFileClient file2 = directory2.GetFileClient(GetNewFileName());
            Assert.IsTrue(file2.CanGenerateSasUri);

            // Act - DataLakeDirectoryClient(Uri blobContainerUri, TokenCredential credential, fileClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            DataLakeDirectoryClient directory3 = InstrumentClient(new DataLakeDirectoryClient(
                blobEndpoint,
                tokenCredentials,
                GetOptions()));
            DataLakeFileClient file3 = directory3.GetFileClient(GetNewFileName());
            Assert.IsFalse(file3.CanGenerateSasUri);
        }

        [RecordedTest]
        public void CanGenerateSas_GetSubDirectoryClient()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);

            // Act - DataLakeDirectoryClient(Uri blobContainerUri, fileClientOptions options = default)
            DataLakeDirectoryClient directory = InstrumentClient(new DataLakeDirectoryClient(
                blobEndpoint,
                GetOptions()));
            DataLakeDirectoryClient subdirectory = directory.GetSubDirectoryClient(GetNewDirectoryName());
            Assert.IsFalse(subdirectory.CanGenerateSasUri);

            // Act - DataLakeDirectoryClient(Uri blobContainerUri, StorageSharedKeyCredential credential, fileClientOptions options = default)
            DataLakeDirectoryClient directory2 = InstrumentClient(new DataLakeDirectoryClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            DataLakeDirectoryClient subdirectory2 = directory2.GetSubDirectoryClient(GetNewDirectoryName());
            Assert.IsTrue(subdirectory2.CanGenerateSasUri);

            // Act - DataLakeDirectoryClient(Uri blobContainerUri, TokenCredential credential, fileClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            DataLakeDirectoryClient directory3 = InstrumentClient(new DataLakeDirectoryClient(
                blobEndpoint,
                tokenCredentials,
                GetOptions()));
            DataLakeDirectoryClient subdirectory3 = directory3.GetSubDirectoryClient(GetNewDirectoryName());
            Assert.IsFalse(subdirectory3.CanGenerateSasUri);
        }

        [RecordedTest]
        public void CanGenerateSas_Mockable()
        {
            // Act
            var directory = new Mock<DataLakeDirectoryClient>();
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
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewDirectoryName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(
                dataLakeUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            string stringToSign = null;

            // Act
            Uri sasUri = directoryClient.GenerateSasUri(permissions, expiresOn, out stringToSign);

            // Assert
            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                IsDirectory = true
            };
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path,
                Sas = sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };

            Assert.AreEqual(expectedUri.ToUri(), sasUri);
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        public void GenerateSas_Builder()
        {
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewDirectoryName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(
                dataLakeUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                IsDirectory = true,
            };

            string stringToSign = null;

            // Act
            Uri sasUri = directoryClient.GenerateSasUri(sasBuilder, out stringToSign);

            // Assert
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                IsDirectory = true,
            };
            expectedUri.Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential);
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        public void GenerateSas_BuilderNullFileSystemName()
        {
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewDirectoryName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(
                dataLakeUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = null,
                Path = path,
                IsDirectory = true,
            };

            // Act
            Uri sasUri = directoryClient.GenerateSasUri(sasBuilder);

            // Assert
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                IsDirectory = true,
            };
            expectedUri.Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential);
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
        }

        [RecordedTest]
        public void GenerateSas_BuilderWrongFileSystemName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = directoryName
            };
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(
                dataLakeUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = GetNewFileSystemName(), // different filesytem name
                Path = directoryName,
                IsDirectory = true
            };

            // Act
            TestHelper.AssertExpectedException(
                () => directoryClient.GenerateSasUri(sasBuilder),
                new InvalidOperationException("SAS Uri cannot be generated. DataLakeSasBuilder.FileSystemName does not match FileSystemName in the Client. DataLakeSasBuilder.FileSystemName must either be left empty or match the FileSystemName in the Client"));
        }

        [RecordedTest]
        public void GenerateSas_BuilderNullPath()
        {
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewDirectoryName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(
                dataLakeUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = null,
                IsDirectory = true,
            };

            // Act
            Uri sasUri = directoryClient.GenerateSasUri(sasBuilder);

            // Assert
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                IsDirectory = true,
            };
            expectedUri.Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential);
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
        }

        [RecordedTest]
        public void GenerateSas_BuilderWrongDirectoryName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string directoryName = GetNewDirectoryName();
            string fileSystemName = GetNewFileSystemName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = directoryName
            };
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(
                dataLakeUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = GetNewDirectoryName(), // different directory name
                IsDirectory = true,
            };

            // Act
            TestHelper.AssertExpectedException(
                () => directoryClient.GenerateSasUri(sasBuilder),
                new InvalidOperationException("SAS Uri cannot be generated. DataLakeSasBuilder.Path does not match Path in the Client. DataLakeSasBuilder.Path must either be left empty or match the Path in the Client"));
        }

        [RecordedTest]
        public void GenerateSas_BuilderIsDirectoryNull()
        {
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewDirectoryName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(
                dataLakeUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                IsDirectory = null,
            };

            // Act
            Uri sasUri = directoryClient.GenerateSasUri(sasBuilder);

            // Assert
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                IsDirectory = true,
            };
            expectedUri.Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential);
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
        }

        [RecordedTest]
        public void GenerateSas_BuilderIsDirectoryError()
        {
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = directoryName
            };
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(
                dataLakeUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = directoryName,
                IsDirectory = false,
            };

            // Act
            TestHelper.AssertExpectedException(
                () => directoryClient.GenerateSasUri(sasBuilder),
                new InvalidOperationException("SAS Uri cannot be generated. Expected builder.IsDirectory to be set to true to generate the respective SAS for the client, GetType"));
        }
        #endregion

        #region GenerateUserDelegationSasTests
        [RecordedTest]
        public async Task GenerateUserDelegationSas_RequiredParameters()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewDirectoryName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            string stringToSign = null;
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = directoryClient.GenerateUserDelegationSasUri(permissions, expiresOn, userDelegationKey, out stringToSign);

            // Assert
            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                IsDirectory = true
            };
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path,
                Sas = sasBuilder.ToSasQueryParameters(userDelegationKey, directoryClient.AccountName)
            };

            Assert.AreEqual(expectedUri.ToUri(), sasUri);
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_Builder()
        {
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewDirectoryName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                IsDirectory = true,
            };

            string stringToSign = null;
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = directoryClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey, out stringToSign);

            // Assert
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                IsDirectory = true,
            };
            expectedUri.Sas = sasBuilder2.ToSasQueryParameters(userDelegationKey, directoryClient.AccountName);
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderNull()
        {
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewDirectoryName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            string stringToSign = null;
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            TestHelper.AssertExpectedException(
                () => directoryClient.GenerateUserDelegationSasUri(null, userDelegationKey, out stringToSign),
                 new ArgumentNullException("builder"));
        }

        [RecordedTest]
        public void GenerateUserDelegationSas_UserDelegationKeyNull()
        {
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewDirectoryName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                IsDirectory = true,
            };

            string stringToSign = null;

            // Assert
            TestHelper.AssertExpectedException(
                () => directoryClient.GenerateUserDelegationSasUri(sasBuilder, null, out stringToSign),
                 new ArgumentNullException("userDelegationKey"));
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderNullFileSystemName()
        {
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewDirectoryName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = null,
                Path = path,
                IsDirectory = true,
            };

            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = directoryClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey);

            // Assert
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                IsDirectory = true,
            };
            expectedUri.Sas = sasBuilder2.ToSasQueryParameters(userDelegationKey, directoryClient.AccountName);
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderWrongFileSystemName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = directoryName
            };
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = GetNewFileSystemName(), // different filesytem name
                Path = directoryName,
                IsDirectory = true
            };

            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            TestHelper.AssertExpectedException(
                () => directoryClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey),
                new InvalidOperationException("SAS Uri cannot be generated. DataLakeSasBuilder.FileSystemName does not match FileSystemName in the Client. DataLakeSasBuilder.FileSystemName must either be left empty or match the FileSystemName in the Client"));
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderNullPath()
        {
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewDirectoryName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = null,
                IsDirectory = true,
            };

            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = directoryClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey);

            // Assert
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                IsDirectory = true,
            };
            expectedUri.Sas = sasBuilder2.ToSasQueryParameters(userDelegationKey, directoryClient.AccountName);
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderWrongPathName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string directoryName = GetNewDirectoryName();
            string fileSystemName = GetNewFileSystemName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = directoryName
            };
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = GetNewDirectoryName(), // different directory name
                IsDirectory = true,
            };

            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            TestHelper.AssertExpectedException(
                () => directoryClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey),
                new InvalidOperationException("SAS Uri cannot be generated. DataLakeSasBuilder.Path does not match Path in the Client. DataLakeSasBuilder.Path must either be left empty or match the Path in the Client"));
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderIsDirectoryNull()
        {
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewDirectoryName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                IsDirectory = null,
            };

            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = directoryClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey);

            // Assert
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                IsDirectory = true,
            };
            expectedUri.Sas = sasBuilder2.ToSasQueryParameters(userDelegationKey, directoryClient.AccountName);
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderIsDirectoryError()
        {
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = directoryName
            };
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = directoryName,
                IsDirectory = false,
            };

            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            TestHelper.AssertExpectedException(
                () => directoryClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey),
                new InvalidOperationException("SAS Uri cannot be generated. Expected builder.IsDirectory to be set to true to generate the respective SAS for the client, GetType"));
        }
        #endregion

        [RecordedTest]
        public void CanMockClientConstructors()
        {
            // One has to call .Object to trigger constructor. It's lazy.
            var mock = new Mock<DataLakeDirectoryClient>(TestConfigDefault.ConnectionString, "name", "name", new DataLakeClientOptions()).Object;
            mock = new Mock<DataLakeDirectoryClient>(TestConfigDefault.ConnectionString, "name", "name").Object;
            mock = new Mock<DataLakeDirectoryClient>(new Uri("https://test/test"), new DataLakeClientOptions()).Object;
            mock = new Mock<DataLakeDirectoryClient>(new Uri("https://test/test"), Tenants.GetNewHnsSharedKeyCredentials(), new DataLakeClientOptions()).Object;
            mock = new Mock<DataLakeDirectoryClient>(new Uri("https://test/test"), new AzureSasCredential("foo"), new DataLakeClientOptions()).Object;
            mock = new Mock<DataLakeDirectoryClient>(new Uri("https://test/test"), TestEnvironment.Credential, new DataLakeClientOptions()).Object;
        }
    }
}
