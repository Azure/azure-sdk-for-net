// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Tests.Shared;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class FileClientTests : PathTestBase
    {
        private const long Size = 4 * Constants.KB;

        public FileClientTests(bool async, DataLakeClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        public async Task Ctor_Uri()
        {
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            string fileName = GetNewFileName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);

            // Arrange
            await directory.CreateFileAsync(fileName);

            SasQueryParameters sasQueryParameters = GetNewAccountSasCredentials();
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{directoryName}/{fileName}?{sasQueryParameters}");
            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(uri, GetOptions()));

            // Act
            await fileClient.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(fileName, fileClient.Name);
            Assert.AreEqual(fileSystemName, fileClient.FileSystemName);
            Assert.AreEqual($"{directoryName}/{fileName}", fileClient.Path);
            Assert.AreEqual(uri, fileClient.Uri);
        }

        [RecordedTest]
        public async Task Ctor_SharedKey()
        {
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            string fileName = GetNewFileName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);

            // Arrange
            await directory.CreateFileAsync(fileName);

            StorageSharedKeyCredential sharedKey = new StorageSharedKeyCredential(
                TestConfigHierarchicalNamespace.AccountName,
                TestConfigHierarchicalNamespace.AccountKey);
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{directoryName}/{fileName}");
            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(uri, sharedKey, GetOptions()));

            // Act
            await fileClient.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(fileName, fileClient.Name);
            Assert.AreEqual(fileSystemName, fileClient.FileSystemName);
            Assert.AreEqual($"{directoryName}/{fileName}", fileClient.Path);
            Assert.AreEqual(uri, fileClient.Uri);
            Assert.IsNotNull(fileClient.ClientConfiguration.SharedKeyCredential);
        }

        [Test]
        public void Ctor_SharedKey_AccountName()
        {
            // Arrange
            var accountName = "accountName";
            var fileSystemName = "fileSystemName";
            var directoryName = "directoryName";
            var fileName = "fileName";
            var pathName = $"{directoryName}/{fileName}";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });
            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var blobEndpoint = new Uri($"https://customdomain/{fileSystemName}/{pathName}");

            DataLakeFileClient datalakeFileClient = new DataLakeFileClient(blobEndpoint, credentials);

            Assert.AreEqual(accountName, datalakeFileClient.AccountName);
            Assert.AreEqual(fileSystemName, datalakeFileClient.FileSystemName);
            Assert.AreEqual(pathName, datalakeFileClient.Path);
        }

        [RecordedTest]
        public async Task Ctor_TokenCredential()
        {
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            string fileName = GetNewFileName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);

            // Arrange
            await directory.CreateFileAsync(fileName);

            TokenCredential tokenCredential = TestEnvironment.Credential;
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{directoryName}/{fileName}").ToHttps();
            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(uri, tokenCredential, GetOptions()));

            // Act
            await fileClient.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(fileName, fileClient.Name);
            Assert.AreEqual(fileSystemName, fileClient.FileSystemName);
            Assert.AreEqual($"{directoryName}/{fileName}", fileClient.Path);
            Assert.AreEqual(uri, fileClient.Uri);
            Assert.IsNotNull(fileClient.ClientConfiguration.TokenCredential);
        }

        [RecordedTest]
        public void Ctor_TokenCredential_Http()
        {
            // Arrange
            TokenCredential tokenCredential = TestEnvironment.Credential;
            Uri uri = new Uri(TestConfigHierarchicalNamespace.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new DataLakeFileClient(uri, tokenCredential),
                new ArgumentException("Cannot use TokenCredential without HTTPS."));

            TestHelper.AssertExpectedException(
                () => new DataLakeFileClient(uri, tokenCredential, new DataLakeClientOptions()),
                new ArgumentException("Cannot use TokenCredential without HTTPS."));
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
            string connectionString = $"DefaultEndpointsProtocol=https;AccountName={TestConfigHierarchicalNamespace.AccountName};AccountKey={TestConfigHierarchicalNamespace.AccountKey};BlobEndpoint={TestConfigHierarchicalNamespace.BlobServiceEndpoint};FileEndpoint={TestConfigHierarchicalNamespace.FileServiceEndpoint};QueueEndpoint={TestConfigHierarchicalNamespace.QueueServiceEndpoint};TableEndpoint={TestConfigHierarchicalNamespace.TableServiceEndpoint}";
            DataLakeFileClient connStringFile = InstrumentClient(new DataLakeFileClient(connectionString, fileSystemName, path, GetOptions()));

            // Assert
            await connStringFile.GetPropertiesAsync();
            await connStringFile.GetAccessControlAsync();
            Assert.IsNotNull(connStringFile.ClientConfiguration.SharedKeyCredential);
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
            string connectionString = $"DefaultEndpointsProtocol=https;AccountName={TestConfigHierarchicalNamespace.AccountName};AccountKey={TestConfigHierarchicalNamespace.AccountKey};BlobEndpoint={TestConfigHierarchicalNamespace.BlobServiceEndpoint};FileEndpoint={TestConfigHierarchicalNamespace.FileServiceEndpoint};QueueEndpoint={TestConfigHierarchicalNamespace.QueueServiceEndpoint};TableEndpoint={TestConfigHierarchicalNamespace.TableServiceEndpoint}";
            DataLakeFileClient connStringFile = InstrumentClient(new DataLakeFileClient(connectionString, fileSystemName, path, GetOptions()));
            Uri sasUri = connStringFile.GenerateSasUri(DataLakeSasPermissions.All, Recording.UtcNow.AddDays(1));
            DataLakeFileClient sasFileClient = InstrumentClient(new DataLakeFileClient(sasUri, GetOptions()));

            // Assert
            await sasFileClient.GetPropertiesAsync();
            await sasFileClient.GetAccessControlAsync();
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials().ToString();
            await using DisposingFileSystem test = await GetNewFileSystem();
            var client = test.FileSystem.GetRootDirectoryClient().GetFileClient(GetNewFileName());
            await client.CreateIfNotExistsAsync();
            Uri uri = client.Uri;

            // Act
            var sasClient = InstrumentClient(new DataLakeFileClient(uri, new AzureSasCredential(sas), GetOptions()));
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
            Uri uri = test.FileSystem.GetRootDirectoryClient().GetFileClient(GetNewFileName()).Uri;
            uri = new Uri(uri.ToString() + "?" + sas);

            // Act
            TestHelper.AssertExpectedException<ArgumentException>(
                () => new DataLakeFileClient(uri, new AzureSasCredential(sas)),
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
                () => new DataLakeFileClient(httpUri, dataLakeClientOptions),
                new ArgumentException("Cannot use client-provided key without HTTPS."));
        }

        [RecordedTest]
        public async Task Ctor_DefaultAudience()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();

            DataLakeFileClient pathClient = test.FileSystem.GetFileClient(GetNewFileName());
            await pathClient.CreateIfNotExistsAsync();

            // Act - Create new blob client with the OAuth Credential and Audience
            DataLakeClientOptions options = GetOptionsWithAudience(DataLakeAudience.DefaultAudience);

            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(new Uri(Tenants.TestConfigHierarchicalNamespace.BlobServiceEndpoint))
            {
                FileSystemName = pathClient.FileSystemName,
                DirectoryOrFilePath = pathClient.Name
            };

            DataLakeFileClient aadPathClient = InstrumentClient(new DataLakeFileClient(
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

            DataLakeFileClient fileClient = test.FileSystem.GetFileClient(GetNewFileName());
            await fileClient.CreateIfNotExistsAsync();

            // Act - Create new blob client with the OAuth Credential and Audience
            DataLakeClientOptions options = GetOptionsWithAudience(new DataLakeAudience($"https://{test.FileSystem.AccountName}.blob.core.windows.net/"));

            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(new Uri(Tenants.TestConfigHierarchicalNamespace.BlobServiceEndpoint))
            {
                FileSystemName = fileClient.FileSystemName,
                DirectoryOrFilePath = fileClient.Name
            };

            DataLakeFileClient aadFileClient = InstrumentClient(new DataLakeFileClient(
                uriBuilder.ToUri(),
                GetOAuthHnsCredential(),
                options));

            // Assert
            bool exists = await aadFileClient.ExistsAsync();
            Assert.IsTrue(exists);
        }

        [RecordedTest]
        public async Task Ctor_StorageAccountAudience()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();

            DataLakeFileClient pathClient = test.FileSystem.GetFileClient(GetNewFileName());
            await pathClient.CreateIfNotExistsAsync();

            // Act - Create new blob client with the OAuth Credential and Audience
            DataLakeClientOptions options = GetOptionsWithAudience(DataLakeAudience.CreateDataLakeServiceAccountAudience(test.FileSystem.AccountName));

            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(new Uri(Tenants.TestConfigHierarchicalNamespace.BlobServiceEndpoint))
            {
                FileSystemName = pathClient.FileSystemName,
                DirectoryOrFilePath = pathClient.Name
            };

            DataLakeFileClient aadFileClient = InstrumentClient(new DataLakeFileClient(
                uriBuilder.ToUri(),
                GetOAuthHnsCredential(),
                options));

            // Assert
            bool exists = await aadFileClient.ExistsAsync();
            Assert.IsTrue(exists);
        }

        [RecordedTest]
        public async Task Ctor_AudienceError()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();

            DataLakeFileClient pathClient = test.FileSystem.GetFileClient(GetNewFileName());
            await pathClient.CreateIfNotExistsAsync();

            // Act - Create new blob client with the OAuth Credential and Audience
            DataLakeClientOptions options = GetOptionsWithAudience(new DataLakeAudience("https://badaudience.blob.core.windows.net"));

            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint))
            {
                FileSystemName = pathClient.FileSystemName,
                DirectoryOrFilePath = pathClient.Name
            };

            DataLakeFileClient aadFileClient = InstrumentClient(new DataLakeFileClient(
                uriBuilder.ToUri(),
                new MockCredential(),
                options));

            // Assert
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                aadFileClient.ExistsAsync(),
                e => Assert.AreEqual("InvalidAuthenticationInfo", e.ErrorCode));
        }

        [RecordedTest]
        public async Task Ctor_EscapeName()
        {
            // Arrange
            string fileName = "!*'();[]:@&%=+$,#äÄöÖüÜß";
            await using DisposingFileSystem test = await GetNewFileSystem();
            int size = Constants.KB;
            var data = GetRandomBuffer(size);
            DataLakeFileClient file = InstrumentClient(test.Container.GetFileClient(fileName));
            ETag originalEtag;
            using (var stream = new MemoryStream(data))
            {
                PathInfo info = await file.UploadAsync(stream);
                originalEtag = info.ETag;
            }

            // Act
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(new Uri(Tenants.TestConfigHierarchicalNamespace.BlobServiceEndpoint))
            {
                FileSystemName = file.FileSystemName,
                DirectoryOrFilePath = fileName
            };
            DataLakeFileClient freshFileClient = InstrumentClient(new DataLakeFileClient(
                uriBuilder.ToUri(),
                TestEnvironment.Credential,
                GetOptions()));

            // Assert
            Assert.AreEqual(fileName, freshFileClient.Name);
            PathProperties propertiesResponse = await freshFileClient.GetPropertiesAsync();
            Assert.AreEqual(originalEtag, propertiesResponse.ETag);
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task CreateAsync(bool createIfNotExists)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            Response<PathInfo> response;
            if (createIfNotExists)
            {
                response = await file.CreateIfNotExistsAsync();
            }
            else
            {
                response = await file.CreateAsync();
            }

            // Assert
            AssertValidStoragePathInfo(response.Value);

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.AreEqual(response.Value.ETag.ToString(), $"\"{response.GetRawResponse().Headers.ETag}\"");
        }

        [RecordedTest]
        public async Task CreateAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));

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
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
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
            if (createIfNotExists)
            {
                await file.CreateIfNotExistsAsync(options: options);
            }
            else
            {
                await file.CreateAsync(options: options);
            }

            // Assert
            Response<PathProperties> response = await file.GetPropertiesAsync();
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
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                Metadata = metadata
            };

            // Act
            if (createIfNotExists)
            {
                await file.CreateIfNotExistsAsync(options: options);
            }
            else
            {
                await file.CreateAsync(options: options);
            }

            // Assert
            Response<PathProperties> getPropertiesResponse = await file.GetPropertiesAsync();
            AssertMetadataEquality(metadata, getPropertiesResponse.Value.Metadata, isDirectory: false);
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task CreateAsync_PermissionAndUmask(bool createIfNotExists)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
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
                await file.CreateIfNotExistsAsync(options: options);
            }
            else
            {
                await file.CreateAsync(options: options);
            }

            // Assert
            Response<PathAccessControl> response = await file.GetAccessControlAsync();
            AssertPathPermissionsEquality(PathPermissions.ParseSymbolicPermissions("rwx-w----"), response.Value.Permissions);
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task CreateAsync_Owner(bool createIfNotExists)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
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
                await file.CreateIfNotExistsAsync(options: options);
            }
            else
            {
                await file.CreateAsync(options: options);
            }

            // Assert
            Response<PathAccessControl> response = await file.GetAccessControlAsync();
            Assert.AreEqual(owner, response.Value.Owner);
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task CreateAsync_Group(bool createIfNotExists)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
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
                await file.CreateIfNotExistsAsync(options: options);
            }
            else
            {
                await file.CreateAsync(options: options);
            }

            // Assert
            Response<PathAccessControl> response = await file.GetAccessControlAsync();
            Assert.AreEqual(group, response.Value.Group);
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task CreateAsync_Acl(bool createIfNotExists)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

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
                await file.CreateIfNotExistsAsync(options: options);
            }
            else
            {
                await file.CreateAsync(options: options);
            }

            // Assert
            Response<PathAccessControl> response = await file.GetAccessControlAsync();
            AssertAccessControlListEquality(AccessControlList, response.Value.AccessControlList.ToList());
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task CreateAsync_Lease(bool createIfNotExists)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            string leaseId = Recording.Random.NewGuid().ToString();
            TimeSpan duration = TimeSpan.FromSeconds(15);

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                LeaseId = leaseId,
                LeaseDuration = duration,
            };

            // Act
            if (createIfNotExists)
            {
                await file.CreateIfNotExistsAsync(options: options);
            }
            else
            {
                await file.CreateAsync(options: options);
            }

            // Assert
            Response<PathProperties> propertiesResponse = await file.GetPropertiesAsync();
            Assert.AreEqual(DataLakeLeaseStatus.Locked, propertiesResponse.Value.LeaseStatus);
            Assert.AreEqual(DataLakeLeaseState.Leased, propertiesResponse.Value.LeaseState);
            Assert.AreEqual(DataLakeLeaseDuration.Fixed, propertiesResponse.Value.LeaseDuration);
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        [RetryOnException(5, typeof(AssertionException))]
        public async Task CreateAsync_RelativeExpiry(bool createIfNotExists)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                ScheduleDeletionOptions = new DataLakePathScheduleDeletionOptions(timeToExpire: new TimeSpan(hours: 1, minutes: 0, seconds: 0))
            };

            // Act
            if (createIfNotExists)
            {
                await file.CreateIfNotExistsAsync(options: options);
            }
            else
            {
                await file.CreateAsync(options: options);
            }

            // Assert
            Response<PathProperties> propertiesResponse = await file.GetPropertiesAsync();
            DateTimeOffset expectedExpiryTime = propertiesResponse.Value.CreatedOn.AddHours(1);

            // The expiry time and creation time can sometimes differ by about a second.
            Assert.AreEqual(expectedExpiryTime.Year, propertiesResponse.Value.ExpiresOn.Year);
            Assert.AreEqual(expectedExpiryTime.Month, propertiesResponse.Value.ExpiresOn.Month);
            Assert.AreEqual(expectedExpiryTime.Day, propertiesResponse.Value.ExpiresOn.Day);
            Assert.AreEqual(expectedExpiryTime.Hour, propertiesResponse.Value.ExpiresOn.Hour);
            Assert.AreEqual(expectedExpiryTime.Minute, propertiesResponse.Value.ExpiresOn.Minute);
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task CreateAsync_AbsoluteExpiry(bool createIfNotExists)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                ScheduleDeletionOptions = new DataLakePathScheduleDeletionOptions(expiresOn: new DateTimeOffset(2100, 1, 1, 0, 0, 0, 0, TimeSpan.Zero))
            };

            // Act
            if (createIfNotExists)
            {
                await file.CreateIfNotExistsAsync(options: options);
            }
            else
            {
                await file.CreateAsync(options: options);
            }

            // Assert
            Response<PathProperties> propertiesResponse = await file.GetPropertiesAsync();
            Assert.AreEqual(options.ScheduleDeletionOptions.ExpiresOn, propertiesResponse.Value.ExpiresOn);
        }

        [RecordedTest]
        public async Task CreateAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                // Arrange
                // This directory is intentionally created twice
                DataLakeFileClient file = await directory.CreateFileAsync(GetNewFileName());

                parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(file, parameters.LeaseId, garbageLeaseId);

                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                DataLakePathCreateOptions options = new DataLakePathCreateOptions
                {
                    Conditions = conditions
                };

                // Act
                Response<PathInfo> response = await file.CreateAsync(options: options);

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
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                // Arrange
                // This directory is intentionally created twice
                DataLakeFileClient file = await directory.CreateFileAsync(GetNewFileName());
                parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                DataLakePathCreateOptions options = new DataLakePathCreateOptions
                {
                    Conditions = conditions
                };

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    file.CreateAsync(options: options),
                    e => { });
            }
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_10_02)]
        [LiveOnly(Reason = "Encryption Key cannot be stored in recordings.")]
        public async Task CreateAsync_CPK(bool createIfNotExists)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeCustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()).WithCustomerProvidedKey(customerProvidedKey));

            // Act
            if (createIfNotExists)
            {
                await file.CreateIfNotExistsAsync();
            }
            else
            {
                await file.CreateAsync();
            }

            // Assert
            Response<PathProperties> response = await file.GetPropertiesAsync();
            Assert.IsTrue(response.Value.IsServerEncrypted);
            Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2021_04_10)]
        public async Task Create_EncryptionContext()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            string encryptionContext = "encryptionContext";
            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                EncryptionContext = encryptionContext
            };

            // Act
            await file.CreateAsync(options);

            // Assert.  We are also going to test GetProperties(), Read(), and GetPaths() with this test.
            Response<PathProperties> pathPropertiesResponse = await file.GetPropertiesAsync();
            Assert.AreEqual(encryptionContext, pathPropertiesResponse.Value.EncryptionContext);

            Response<FileDownloadInfo> readResponse = await file.ReadAsync();
            Assert.AreEqual(encryptionContext, readResponse.Value.Properties.EncryptionContext);

            DataLakeGetPathsOptions getPathsOptions = new DataLakeGetPathsOptions
            {
                Recursive = true
            };

            AsyncPageable<PathItem> getPathsResponse = test.FileSystem.GetPathsAsync(getPathsOptions);
            IList<PathItem> paths = await getPathsResponse.ToListAsync();

            Assert.AreEqual(2, paths.Count);
            Assert.AreEqual(encryptionContext, paths[1].EncryptionContext);
        }

        [RecordedTest]
        public async Task CreateIfNotExistsAsync_NotExists()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            Response<PathInfo> response = await file.CreateIfNotExistsAsync();

            // Assert
            Assert.IsNotNull(response.Value.ETag);
        }

        [RecordedTest]
        public async Task CreateIfNotExistsAsync_Exists()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            await file.CreateIfNotExistsAsync();

            // Act
            Response<PathInfo> response = await file.CreateIfNotExistsAsync();

            // Assert
            Assert.IsNull(response);
        }

        [RecordedTest]
        public async Task CreateIfNotExistsAsync_Error()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            DataLakeFileClient unauthorizedFile = InstrumentClient(new DataLakeFileClient(file.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedFile.CreateIfNotExistsAsync(),
                e => Assert.AreEqual("NoAuthenticationInformation", e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_10_02)]
        [LiveOnly(Reason = "Encryption Key cannot be stored in recordings.")]
        public async Task CreateIfNotExistsAsync_CPK()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeCustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()).WithCustomerProvidedKey(customerProvidedKey));

            // Act
            await file.CreateIfNotExistsAsync();

            // Assert
            Response<PathProperties> response = await file.GetPropertiesAsync();
            Assert.IsTrue(response.Value.IsServerEncrypted);
            Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2021_04_10)]
        public async Task CreateIfNotExists_EncryptionContext()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            string encryptionContext = "encryptionContext";
            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                EncryptionContext = encryptionContext
            };

            // Act
            await file.CreateIfNotExistsAsync(options);

            // Assert
            Response<PathProperties> pathProperties = await file.GetPropertiesAsync();
            Assert.AreEqual(encryptionContext, pathProperties.Value.EncryptionContext);
        }

        [RecordedTest]
        public async Task ExistsAsync_Exists()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            await file.CreateIfNotExistsAsync();

            // Act
            Response<bool> response = await file.ExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);
        }

        [RecordedTest]
        public async Task ExistsAsync_NotExists()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            Response<bool> response = await file.ExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [RecordedTest]
        public async Task ExistsAsync_FileSystemNotExists()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystemClient = service.GetFileSystemClient(GetNewFileSystemName());
            DataLakeFileClient file = InstrumentClient(fileSystemClient.GetFileClient(GetNewFileName()));

            // Act
            Response<bool> response = await file.ExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [RecordedTest]
        public async Task ExistsAsync_Error()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem(publicAccessType: PublicAccessType.None);
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            DataLakeFileClient unauthorizedFile = InstrumentClient(new DataLakeFileClient(file.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedFile.ExistsAsync(),
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
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeCustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()).WithCustomerProvidedKey(customerProvidedKey));
            await file.CreateAsync();

            // Act
            Response<bool> response = await file.ExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);
        }

        [RecordedTest]
        public async Task DeleteIfExists_Exists()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            await file.CreateIfNotExistsAsync();

            // Act
            Response<bool> response = await file.DeleteIfExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);
        }

        [RecordedTest]
        public async Task DeleteIfExists_NotExists()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            Response<bool> response = await file.DeleteIfExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [RecordedTest]
        public async Task DeleteIfExistsAsync_FileSystemNotExists()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystemClient = service.GetFileSystemClient(GetNewFileSystemName());
            DataLakeFileClient file = InstrumentClient(fileSystemClient.GetFileClient(GetNewFileName()));

            // Act
            Response<bool> response = await file.DeleteIfExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [RecordedTest]
        public async Task DeleteIfNotExistsAsync_Error()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            DataLakeFileClient unauthorizedFile = InstrumentClient(new DataLakeFileClient(file.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedFile.DeleteIfExistsAsync(),
                e => Assert.AreEqual("NoAuthenticationInformation", e.ErrorCode));
        }

        [RecordedTest]
        public async Task DeleteAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            DataLakeFileClient fileClient = await directory.CreateFileAsync(GetNewFileName());

            // Act
            await fileClient.DeleteAsync();
        }

        [RecordedTest]
        public async Task DeleteAsync_OAuth()
        {
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            await using DisposingFileSystem test = await GetNewFileSystem(oauthService);
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            DataLakeFileClient fileClient = await directory.CreateFileAsync(GetNewFileName());

            // Act
            await fileClient.DeleteAsync();
        }

        [RecordedTest]
        public async Task DeleteFileAsync_Error()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            DataLakeFileClient fileClient = directory.GetFileClient(GetNewFileName());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileClient.DeleteAsync(),
                e => Assert.AreEqual("PathNotFound", e.ErrorCode));
        }

        [RecordedTest]
        public async Task DeleteAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(file, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                await file.DeleteAsync(conditions: conditions);
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
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    file.DeleteAsync(conditions: conditions),
                    e => { });
            }
        }

        [RecordedTest]
        public async Task RenameAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient sourceFile = await test.FileSystem.CreateFileAsync(GetNewFileName());
            string destFileName = GetNewDirectoryName();

            // Act
            DataLakeFileClient destFile = await sourceFile.RenameAsync(destinationPath: destFileName);

            // Assert
            Response<PathProperties> response = await destFile.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task RenameAsync_FileSystem()
        {
            await using DisposingFileSystem sourceTest = await GetNewFileSystem();
            await using DisposingFileSystem destTest = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient sourceFile = await sourceTest.FileSystem.CreateFileAsync(GetNewFileName());
            string destFileName = GetNewDirectoryName();

            // Act
            DataLakeFileClient destFile = await sourceFile.RenameAsync(
                destinationPath: destFileName,
                destinationFileSystem: destTest.FileSystem.Name);

            // Assert
            Response<PathProperties> response = await destFile.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task RenameAsync_Error()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient sourceFile = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            string destPath = GetNewFileName();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                sourceFile.RenameAsync(destinationPath: destPath),
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
                DataLakeFileClient sourceFile = await test.FileSystem.CreateFileAsync(GetNewFileName());
                DataLakeFileClient destFile = await test.FileSystem.CreateFileAsync(GetNewFileName());

                parameters.Match = await SetupPathMatchCondition(destFile, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(destFile, parameters.LeaseId, garbageLeaseId);

                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                destFile = await sourceFile.RenameAsync(
                    destinationPath: destFile.Name,
                    destinationConditions: conditions);

                // Assert
                Response<PathProperties> response = await destFile.GetPropertiesAsync();
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
                DataLakeFileClient sourceFile = await test.FileSystem.CreateFileAsync(GetNewFileName());
                DataLakeFileClient destFile = await test.FileSystem.CreateFileAsync(GetNewFileName());

                parameters.NoneMatch = await SetupPathMatchCondition(destFile, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    sourceFile.RenameAsync(
                        destinationPath: destFile.Name,
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
                DataLakeFileClient sourceFile = await test.FileSystem.CreateFileAsync(GetNewFileName());
                DataLakeFileClient destFile = await test.FileSystem.CreateFileAsync(GetNewFileName());

                parameters.Match = await SetupPathMatchCondition(sourceFile, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(sourceFile, parameters.LeaseId, garbageLeaseId);

                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                destFile = await sourceFile.RenameAsync(
                    destinationPath: destFile.Name,
                    sourceConditions: conditions);

                // Assert
                Response<PathProperties> response = await destFile.GetPropertiesAsync();
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
                DataLakeFileClient sourceFile = await test.FileSystem.CreateFileAsync(GetNewFileName());
                DataLakeFileClient destFile = await test.FileSystem.CreateFileAsync(GetNewFileName());

                parameters.NoneMatch = await SetupPathMatchCondition(sourceFile, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    sourceFile.RenameAsync(
                        destinationPath: destFile.Name,
                        sourceConditions: conditions),
                    e => { });
            }
        }

        [RecordedTest]
        [TestCase("!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("%21%27%28%29%3B%5B%5D%40%26%25%3D%2B%24%2C%23äÄöÖüÜß%3B")]
        [TestCase(" my cool file ")]
        [TestCase("file")]
        public async Task RenameAsync_DestinationSpecialCharacters(string destFileName)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            string directoryName = GetNewDirectoryName();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(directoryName));
            await directory.CreateAsync();
            DataLakeFileClient sourceFile = await test.FileSystem.CreateFileAsync(GetNewFileName());
            Uri expectedDestFileUri = new Uri($"{BlobEndpointToDfsEndpoint(TestConfigHierarchicalNamespace.BlobServiceEndpoint)}/{test.FileSystem.Name}/{directoryName}/{Uri.EscapeDataString(destFileName)}");
            string destFilePath = $"{directoryName}/{destFileName}";

            // Act
            DataLakeFileClient destFile = await sourceFile.RenameAsync(destinationPath: destFilePath);

            // Assert
            Response<PathProperties> response = await destFile.GetPropertiesAsync();
            Assert.AreEqual(destFileName, destFile.Name);
            Assert.AreEqual(destFilePath, destFile.Path);
            Assert.AreEqual(expectedDestFileUri, destFile.Uri);
        }

        [RecordedTest]
        [TestCase("!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("%21%27%28%29%3B%5B%5D%40%26%25%3D%2B%24%2C%23äÄöÖüÜß%3B")]
        [TestCase(" my cool file ")]
        [TestCase("file")]
        public async Task RenameAsync_SourceSpecialCharacters(string sourceFileName)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            string directoryName = GetNewDirectoryName();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(directoryName));
            await directory.CreateAsync();
            DataLakeFileClient sourceFile = await test.FileSystem.CreateFileAsync(sourceFileName);
            string destFileName = GetNewFileName();
            Uri expectedDestFileUri = new Uri($"{BlobEndpointToDfsEndpoint(TestConfigHierarchicalNamespace.BlobServiceEndpoint)}/{test.FileSystem.Name}/{directoryName}/{destFileName}");
            string destFilePath = $"{directoryName}/{destFileName}";

            // Act
            DataLakeFileClient destFile = await sourceFile.RenameAsync(destinationPath: destFilePath);

            // Assert
            Response<PathProperties> response = await destFile.GetPropertiesAsync();
            Assert.AreEqual(destFileName, destFile.Name);
            Assert.AreEqual(destFilePath, destFile.Path);
            Assert.AreEqual(expectedDestFileUri, destFile.Uri);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_10_02)]
        [LiveOnly(Reason = "Encryption Key cannot be stored in recordings.")]
        public async Task RenameAsync_CPK()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeCustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            DataLakeFileClient sourceFile = InstrumentClient(directory.GetFileClient(GetNewFileName()).WithCustomerProvidedKey(customerProvidedKey));
            await sourceFile.CreateAsync();
            string destFileName = GetNewFileName();

            // Act
            DataLakeFileClient destFile = await sourceFile.RenameAsync(destinationPath: destFileName);

            // Assert
            Response<PathProperties> response = await destFile.GetPropertiesAsync();
            Assert.IsTrue(response.Value.IsServerEncrypted);
            Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
        }

        [RecordedTest]
        public async Task RenameAsync_SasCredentialFromFileSystem()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials().ToString();
            await using DisposingFileSystem test = await GetNewFileSystem();
            string sourceFileName = GetNewFileName();
            await test.FileSystem.CreateFileAsync(sourceFileName);

            string destFilename = GetNewFileName();

            // Act
            var sasFileSystemClient = InstrumentClient(new DataLakeFileSystemClient(test.FileSystem.Uri, new AzureSasCredential(sas), GetOptions()));
            DataLakeFileClient sasSourcefileClient = sasFileSystemClient.GetFileClient(sourceFileName);

            // Act
            DataLakeFileClient destFile = await sasSourcefileClient.RenameAsync(destinationPath: destFilename);

            // Assert
            Response<PathProperties> response = await destFile.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task RenameAsync_SasCredentialFromDirectory()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials().ToString();
            await using DisposingFileSystem test = await GetNewFileSystem();
            string sourceDirectoryName = GetNewDirectoryName();
            string sourceFileName = GetNewFileName();
            DataLakeDirectoryClient directoryClient = await test.FileSystem.CreateDirectoryAsync(sourceDirectoryName);
            await directoryClient.CreateFileAsync(sourceFileName);

            string destFilename = GetNewFileName();

            // Act
            var sasFileSystemClient = InstrumentClient(new DataLakeDirectoryClient(directoryClient.Uri, new AzureSasCredential(sas), GetOptions()));
            DataLakeFileClient sasSourcefileClient = sasFileSystemClient.GetFileClient(sourceFileName);

            // Act
            DataLakeFileClient destFile = await sasSourcefileClient.RenameAsync(destinationPath: sourceDirectoryName + "/" + destFilename);

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
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

            // Act
            PathAccessControl accessControl = await file.GetAccessControlAsync();

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
            string fileName = GetNewFileName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);

            // Arrange
            DataLakeFileClient file = await directory.CreateFileAsync(fileName);
            DataLakeFileClient oauthFile = oauthService
                .GetFileSystemClient(fileSystemName)
                .GetDirectoryClient(directoryName)
                .GetFileClient(fileName);

            // Act
            PathAccessControl accessControl = await oauthFile.GetAccessControlAsync();

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
            string fileName = GetNewFileName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);

            // Arrange
            DataLakeFileClient file = await directory.CreateFileAsync(fileName);

            DataLakeFileClient sasFile = InstrumentClient(
                GetServiceClient_DataLakeServiceSas_FileSystem(
                    fileSystemName: fileSystemName)
                .GetFileSystemClient(fileSystemName)
                .GetDirectoryClient(directoryName)
                .GetFileClient(fileName));

            // Act
            PathAccessControl accessControl = await sasFile.GetAccessControlAsync();

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
            string fileName = GetNewFileName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);

            // Arrange
            DataLakeFileClient file = await directory.CreateFileAsync(fileName);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));

            DataLakeFileClient identitySasFile = InstrumentClient(
                GetServiceClient_DataLakeServiceIdentitySas_FileSystem(
                    fileSystemName: fileSystemName,
                    userDelegationKey: userDelegationKey)
                .GetFileSystemClient(fileSystemName)
                .GetDirectoryClient(directoryName)
                .GetFileClient(fileName));

            // Act
            PathAccessControl accessControl = await identitySasFile.GetAccessControlAsync();

            // Assert
            Assert.IsNotNull(accessControl.Owner);
            Assert.IsNotNull(accessControl.Group);
            Assert.IsNotNull(accessControl.Permissions);
            Assert.IsNotNull(accessControl.AccessControlList);
            AssertSasUserDelegationKey(identitySasFile.Uri, userDelegationKey);
        }

        [RecordedTest]
        public async Task GetAccessControlAsync_PathSAS()
        {
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            string fileName = GetNewFileName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);

            // Arrange
            DataLakeFileClient file = await directory.CreateFileAsync(fileName);

            DataLakeFileClient sasFile = InstrumentClient(
                GetServiceClient_DataLakeServiceSas_Path(
                    fileSystemName: fileSystemName,
                    path: directoryName + "/" + fileName)
                .GetFileSystemClient(fileSystemName)
                .GetDirectoryClient(directoryName)
                .GetFileClient(fileName));

            // Act
            PathAccessControl accessControl = await sasFile.GetAccessControlAsync();

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
            string fileName = GetNewFileName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);

            // Arrange
            DataLakeFileClient file = await directory.CreateFileAsync(fileName);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));

            DataLakeFileClient identitySasFile = InstrumentClient(
                GetServiceClient_DataLakeServiceIdentitySas_Path(
                    fileSystemName: fileSystemName,
                    path: directoryName + "/" + fileName,
                    userDelegationKey: userDelegationKey)
                .GetFileSystemClient(fileSystemName)
                .GetDirectoryClient(directoryName)
                .GetFileClient(fileName));

            // Act
            PathAccessControl accessControl = await identitySasFile.GetAccessControlAsync();

            // Assert
            Assert.IsNotNull(accessControl.Owner);
            Assert.IsNotNull(accessControl.Group);
            Assert.IsNotNull(accessControl.Permissions);
            Assert.IsNotNull(accessControl.AccessControlList);
            AssertSasUserDelegationKey(identitySasFile.Uri, userDelegationKey);
        }

        [RecordedTest]
        public async Task GetAccessControlAsync_Error()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.GetAccessControlAsync(),
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
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(file, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                await file.GetAccessControlAsync(conditions: conditions);
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
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    file.GetAccessControlAsync(conditions: conditions),
                    e => { });
            }
        }

        [Ignore("service bug")]
        [RecordedTest]
        public async Task GetAccessControlAsync_InvalidLease()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
            DataLakeRequestConditions conditions = new DataLakeRequestConditions()
            {
                LeaseId = GetGarbageLeaseId()
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.GetAccessControlAsync(conditions: conditions),
                e => Assert.AreEqual("404", e.ErrorCode));
        }

        // Note that FileClient.GetAccessControl() does not need to pass CPK request headers.
        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_10_02)]
        public async Task GetAccessControlAsync_CPK()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeCustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()).WithCustomerProvidedKey(customerProvidedKey));
            await file.CreateAsync();

            // Act
            PathAccessControl accessControl = await file.GetAccessControlAsync();

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
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

            // Act
            Response<PathInfo> response = await file.SetAccessControlListAsync(AccessControlList);

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
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(file, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<PathInfo> response = await file.SetAccessControlListAsync(
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
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    file.SetAccessControlListAsync(
                        accessControlList: AccessControlList,
                        conditions: conditions),
                    e => { });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_10_02)]
        public async Task SetAccessControlList_CPK()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeCustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()).WithCustomerProvidedKey(customerProvidedKey));
            await file.CreateAsync();

            // Act
            Response<PathInfo> response = await file.SetAccessControlListAsync(AccessControlList);

            // Assert
            AssertValidStoragePathInfo(response);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetAccessControlRecursiveAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file = await directory.CreateFileAsync(GetNewFileName());

            // Act
            AccessControlChangeResult result = await file.SetAccessControlRecursiveAsync(AccessControlList, null);

            // Assert
            Assert.AreEqual(0, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(1, result.Counters.ChangedFilesCount);
            Assert.AreEqual(0, result.Counters.FailedChangesCount);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UpdateAccessControlRecursiveAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file = await directory.CreateFileAsync(GetNewFileName());

            // Act
            AccessControlChangeResult result = await file.UpdateAccessControlRecursiveAsync(AccessControlList, null);

            // Assert
            Assert.AreEqual(0, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(1, result.Counters.ChangedFilesCount);
            Assert.AreEqual(0, result.Counters.FailedChangesCount);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task RemoveAccessControlRecursiveAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file = await directory.CreateFileAsync(GetNewFileName());

            // Act
            AccessControlChangeResult result = await file.RemoveAccessControlRecursiveAsync(RemoveAccessControlList, null);

            // Assert
            Assert.AreEqual(0, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(1, result.Counters.ChangedFilesCount);
            Assert.AreEqual(0, result.Counters.FailedChangesCount);
        }

        [RecordedTest]
        public async Task SetPermissionsAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

            // Act
            Response<PathInfo> response = await file.SetPermissionsAsync(permissions: PathPermissions);

            // Assert
            AssertValidStoragePathInfo(response);
        }

        [RecordedTest]
        public async Task SetPermissionAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(file, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<PathInfo> response = await file.SetPermissionsAsync(
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
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    file.SetPermissionsAsync(
                        permissions: PathPermissions,
                        conditions: conditions),
                    e => { });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_10_02)]
        public async Task SetPermissionsAsync_CPK()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeCustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()).WithCustomerProvidedKey(customerProvidedKey));
            await file.CreateAsync();

            // Act
            Response<PathInfo> response = await file.SetPermissionsAsync(permissions: PathPermissions);

            // Assert
            AssertValidStoragePathInfo(response);
        }

        [RecordedTest]
        public async Task SetPermissionsAsync_StickyBitOctal()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
            await file.CreateAsync();

            // Act
            string octalPermissions = "1610";
            PathPermissions permissionsStickyBit = PathPermissions.ParseOctalPermissions(octalPermissions);
            Response<PathInfo> response = await file.SetPermissionsAsync(permissions: permissionsStickyBit);

            // Assert
            AssertValidStoragePathInfo(response);

            Response<PathAccessControl> response2 = await file.GetAccessControlAsync();
            Assert.AreEqual(octalPermissions, response2.Value.Permissions.ToOctalPermissions());
            Assert.AreEqual(permissionsStickyBit.Owner, response2.Value.Permissions.Owner);
            Assert.AreEqual(permissionsStickyBit.Group, response2.Value.Permissions.Group);
            Assert.AreEqual(permissionsStickyBit.Other, response2.Value.Permissions.Other);
        }

        [RecordedTest]
        public async Task SetPermissionsAsync_StickyBitExecute()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
            await file.CreateAsync();

            // Act
            string symbolicPermissions = "rwxrwxrwT";
            PathPermissions permissionsStickyBit = PathPermissions.ParseSymbolicPermissions(symbolicPermissions);
            Response<PathInfo> response = await file.SetPermissionsAsync(permissions: permissionsStickyBit);

            // Assert
            AssertValidStoragePathInfo(response);

            Response<PathAccessControl> response2 = await file.GetAccessControlAsync();
            Assert.AreEqual(symbolicPermissions, response2.Value.Permissions.ToSymbolicPermissions());
            Assert.AreEqual(permissionsStickyBit.Owner, response2.Value.Permissions.Owner);
            Assert.AreEqual(permissionsStickyBit.Group, response2.Value.Permissions.Group);
            Assert.AreEqual(permissionsStickyBit.Other, response2.Value.Permissions.Other);
        }

        [RecordedTest]
        public async Task SetPermissionsAsync_StickyBitNoExecute()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
            await file.CreateAsync();

            // Act
            string symbolicPermissions = "rwxrwxrwt";
            PathPermissions permissionsStickyBit = PathPermissions.ParseSymbolicPermissions(symbolicPermissions);
            Response<PathInfo> response = await file.SetPermissionsAsync(permissions: permissionsStickyBit);

            // Assert
            AssertValidStoragePathInfo(response);

            Response<PathAccessControl> response2 = await file.GetAccessControlAsync();
            Assert.AreEqual(symbolicPermissions, response2.Value.Permissions.ToSymbolicPermissions());
            Assert.AreEqual(permissionsStickyBit.Owner, response2.Value.Permissions.Owner);
            Assert.AreEqual(permissionsStickyBit.Group, response2.Value.Permissions.Group);
            Assert.AreEqual(permissionsStickyBit.Other, response2.Value.Permissions.Other);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

            // Act
            Response<PathProperties> response = await file.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            Assert.IsFalse(response.Value.IsDirectory);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_Oauth()
        {
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            string fileName = GetNewFileName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);

            // Arrange
            DataLakeFileClient file = await directory.CreateFileAsync(fileName);
            DataLakeFileClient oauthFile = oauthService
                .GetFileSystemClient(fileSystemName)
                .GetDirectoryClient(directoryName)
                .GetFileClient(fileName);

            // Act
            Response<PathProperties> response = await file.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_FileSystemSAS()
        {
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            string fileName = GetNewFileName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);

            // Arrange
            DataLakeFileClient file = await directory.CreateFileAsync(fileName);

            DataLakeFileClient sasFile = InstrumentClient(
                GetServiceClient_DataLakeServiceSas_FileSystem(
                    fileSystemName: fileSystemName)
                .GetFileSystemClient(fileSystemName)
                .GetDirectoryClient(directoryName)
                .GetFileClient(fileName));

            // Act
            Response<PathProperties> response = await sasFile.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_FileSystemIdentitySAS()
        {
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            string fileName = GetNewFileName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);

            // Arrange
            DataLakeFileClient file = await directory.CreateFileAsync(fileName);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));

            DataLakeFileClient identitySasFile = InstrumentClient(
                GetServiceClient_DataLakeServiceIdentitySas_FileSystem(
                    fileSystemName: fileSystemName,
                    userDelegationKey: userDelegationKey)
                .GetFileSystemClient(fileSystemName)
                .GetDirectoryClient(directoryName)
                .GetFileClient(fileName));

            // Act
            Response<PathProperties> response = await identitySasFile.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            AssertSasUserDelegationKey(identitySasFile.Uri, userDelegationKey);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_PathSAS()
        {
            var fileSystemName = GetNewFileSystemName();
            var directoryName = GetNewDirectoryName();
            string fileName = GetNewFileName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);

            // Arrange
            DataLakeFileClient file = await directory.CreateFileAsync(fileName);

            DataLakeFileClient sasFile = InstrumentClient(
                GetServiceClient_DataLakeServiceSas_Path(
                    fileSystemName: fileSystemName,
                    path: directoryName + "/" + fileName)
                .GetFileSystemClient(fileSystemName)
                .GetDirectoryClient(directoryName)
                .GetFileClient(fileName));

            // Act
            Response<PathProperties> response = await sasFile.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_PathIdentitySAS()
        {
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            string fileName = GetNewFileName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);

            // Arrange
            DataLakeFileClient file = await directory.CreateFileAsync(fileName);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));

            DataLakeFileClient identitySasFile = InstrumentClient(
                GetServiceClient_DataLakeServiceIdentitySas_Path(
                    fileSystemName: fileSystemName,
                    path: directoryName + "/" + fileName,
                    userDelegationKey: userDelegationKey)
                .GetFileSystemClient(fileSystemName)
                .GetDirectoryClient(directoryName)
                .GetFileClient(fileName));

            // Act
            Response<PathProperties> response = await identitySasFile.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            AssertSasUserDelegationKey(identitySasFile.Uri, userDelegationKey);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                // Arrange
                parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(file, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<PathProperties> response = await file.GetPropertiesAsync(conditions: conditions);

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
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                // Arrange
                parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                // Act
                await TestHelper.CatchAsync<Exception>(
                    async () =>
                    {
                        var _ = (await file.GetPropertiesAsync(
                            conditions: conditions)).Value;
                    });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_10_02)]
        [LiveOnly(Reason = "Encryption Key cannot be stored in recordings.")]
        public async Task GetSetPropertiesAsync_CPK()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeCustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            DataLakeFileClient file = InstrumentClient(directory
                .GetFileClient(GetNewFileName())
                .WithCustomerProvidedKey(customerProvidedKey));
            await file.CreateAsync();

            // Act
            await file.SetHttpHeadersAsync(new PathHttpHeaders
            {
                CacheControl = constants.CacheControl,
                ContentDisposition = constants.ContentDisposition,
                ContentEncoding = constants.ContentEncoding,
                ContentLanguage = constants.ContentLanguage,
                ContentHash = constants.ContentMD5,
                ContentType = constants.ContentType
            });

            Response<PathProperties> response = await file.GetPropertiesAsync();

            // Assert
            Assert.IsTrue(response.Value.IsServerEncrypted);
            Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, response.Value.EncryptionKeySha256);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_Error()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.GetPropertiesAsync(),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [RecordedTest]
        public async Task SetHttpHeadersAsync()
        {
            var constants = TestConstants.Create(this);

            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

            // Act
            await file.SetHttpHeadersAsync(new PathHttpHeaders
            {
                CacheControl = constants.CacheControl,
                ContentDisposition = constants.ContentDisposition,
                ContentEncoding = constants.ContentEncoding,
                ContentLanguage = constants.ContentLanguage,
                ContentHash = constants.ContentMD5,
                ContentType = constants.ContentType
            });

            // Assert
            Response<PathProperties> response = await file.GetPropertiesAsync();
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
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.SetHttpHeadersAsync(new PathHttpHeaders
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
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(file, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<PathInfo> response = await file.SetHttpHeadersAsync(
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
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    file.SetHttpHeadersAsync(
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
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await file.SetMetadataAsync(metadata);

            // Assert
            Response<PathProperties> response = await file.GetPropertiesAsync();
            AssertMetadataEquality(metadata, response.Value.Metadata, isDirectory: false);
        }

        [RecordedTest]
        public async Task SetMetadataAsync_Error()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.SetMetadataAsync(metadata),
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
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
                IDictionary<string, string> metadata = BuildMetadata();

                parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(file, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<PathInfo> response = await file.SetMetadataAsync(
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
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
                IDictionary<string, string> metadata = BuildMetadata();

                parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    file.SetMetadataAsync(
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
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeCustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()).WithCustomerProvidedKey(customerProvidedKey));
            await file.CreateAsync();

            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await file.SetMetadataAsync(metadata);
        }

        [RecordedTest]
        public async Task AppendDataAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateIfNotExistsAsync();
            var data = GetRandomBuffer(Size);

            // Act
            using (var stream = new MemoryStream(data))
            {
                await file.AppendAsync(stream, 0);
            }
        }

        [RecordedTest]
        public async Task AppendDataAsync_EmptyStream()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateAsync();

            // Act
            using (var stream = new MemoryStream())
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    file.AppendAsync(stream, 0),
                    e =>
                    {
                        Assert.AreEqual("InvalidHeaderValue", e.ErrorCode);
                        Assert.IsTrue(e.Message.Contains("The value for one of the HTTP headers is not in the correct format."));
                        if (_serviceVersion > DataLakeClientOptions.ServiceVersion.V2019_02_02)
                        {
                            Assert.AreEqual("Content-Length", e.Data["HeaderName"]);
                            Assert.AreEqual("0", e.Data["HeaderValue"]);
                        }
                    }
                );
            }
        }

        [RecordedTest]
        public async Task AppendDataAsync_ProgressReporting()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateIfNotExistsAsync();
            var data = GetRandomBuffer(Size);
            TestProgress progress = new TestProgress();

            DataLakeFileAppendOptions options = new DataLakeFileAppendOptions
            {
                ProgressHandler = progress
            };

            // Act
            using (var stream = new MemoryStream(data))
            {
                await file.AppendAsync(
                    content: stream,
                    offset: 0,
                    options: options);
                ;
            }

            // Assert
            Assert.IsFalse(progress.List.Count == 0);

            Assert.AreEqual(Size, progress.List[progress.List.Count - 1]);
        }

        [RecordedTest]
        public async Task AppendDataAsync_ContentHash()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateIfNotExistsAsync();
            var data = GetRandomBuffer(Size);
            byte[] contentHash = MD5.Create().ComputeHash(data);

            // Act
            using (var stream = new MemoryStream(data))
            {
                await file.AppendAsync(
                    content: stream,
                    offset: 0,
                    contentHash: contentHash,
                    leaseId: null,
                    progressHandler: null,
                    cancellationToken: CancellationToken.None);
            }
        }

        [RecordedTest]
        public async Task AppendDataAsync_Error()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            var data = GetRandomBuffer(Size);

            // Act
            using (var stream = new MemoryStream(data))
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    file.AppendAsync(stream, 0),
                        e => Assert.AreEqual("PathNotFound", e.ErrorCode));
            }
        }

        [RecordedTest]
        public async Task AppendDataAsync_Position()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateIfNotExistsAsync();
            var data0 = GetRandomBuffer(Constants.KB);
            var data1 = GetRandomBuffer(Constants.KB);

            // Act
            using (var stream = new MemoryStream(data0))
            {
                await file.AppendAsync(stream, 0);
            }
            using (var stream = new MemoryStream(data1))
            {
                await file.AppendAsync(stream, Constants.KB);
            }
            await file.FlushAsync(2 * Constants.KB);

            // Assert
            Response<FileDownloadInfo> response = await file.ReadAsync(new DataLakeFileReadOptions
            {
                Range = new HttpRange(Constants.KB, Constants.KB)
            });
            Assert.AreEqual(data1.Length, response.Value.ContentLength);
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data1, actual.ToArray());
        }

        [RecordedTest]
        public async Task AppendDataAsync_Lease()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateIfNotExistsAsync();
            var data = GetRandomBuffer(Size);
            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);
            Response<DataLakeLease> response = await InstrumentClient(file.GetDataLakeLeaseClient(leaseId)).AcquireAsync(duration);

            DataLakeFileAppendOptions options = new DataLakeFileAppendOptions
            {
                LeaseId = response.Value.LeaseId
            };

            // Act
            using (var stream = new MemoryStream(data))
            {
                await file.AppendAsync(
                    content: stream,
                    offset: 0,
                    options: options);
            }
        }

        [RecordedTest]
        public async Task AppendDataAsync_InvalidLease()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateIfNotExistsAsync();
            var data = GetRandomBuffer(Size);
            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            DataLakeFileAppendOptions options = new DataLakeFileAppendOptions
            {
                LeaseId = Recording.Random.NewGuid().ToString()
            };

            // Act
            using (var stream = new MemoryStream(data))
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    file.AppendAsync(
                        content: stream,
                        offset: 0,
                        options: options),
                        e => Assert.AreEqual("LeaseNotPresent", e.ErrorCode));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_08_04)]
        public async Task AppendDataAsync_Lease_Acquire()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateIfNotExistsAsync();
            byte[] data = GetRandomBuffer(Size);
            string proposedLeaseId = Recording.Random.NewGuid().ToString();
            TimeSpan duration = TimeSpan.FromSeconds(15);

            DataLakeFileAppendOptions options = new DataLakeFileAppendOptions
            {
                LeaseAction = DataLakeLeaseAction.Acquire,
                ProposedLeaseId = proposedLeaseId,
                LeaseDuration = duration
            };

            // Act
            using Stream stream = new MemoryStream(data);
            await file.AppendAsync(stream, 0, options);

            // Assert
            Response<PathProperties> propertiesResponse = await file.GetPropertiesAsync();
            Assert.AreEqual(DataLakeLeaseStatus.Locked, propertiesResponse.Value.LeaseStatus);
            Assert.AreEqual(DataLakeLeaseState.Leased, propertiesResponse.Value.LeaseState);
            Assert.AreEqual(DataLakeLeaseDuration.Fixed, propertiesResponse.Value.LeaseDuration);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_08_04)]
        public async Task AppendDataAsync_Lease_AutoRenew()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateIfNotExistsAsync();

            string leaseId = Recording.Random.NewGuid().ToString();
            TimeSpan duration = TimeSpan.FromSeconds(15);
            DataLakeLeaseClient leaseClient = InstrumentClient(file.GetDataLakeLeaseClient(leaseId));
            Response<DataLakeLease> response = await leaseClient.AcquireAsync(duration);

            byte[] data = GetRandomBuffer(Size);
            DataLakeFileAppendOptions options = new DataLakeFileAppendOptions
            {
                LeaseId = leaseId,
                LeaseAction = DataLakeLeaseAction.AutoRenew
            };

            // Act
            using Stream stream = new MemoryStream(data);
            await file.AppendAsync(stream, 0, options);

            // Assert
            Response<PathProperties> propertiesResponse = await file.GetPropertiesAsync();
            Assert.AreEqual(DataLakeLeaseStatus.Locked, propertiesResponse.Value.LeaseStatus);
            Assert.AreEqual(DataLakeLeaseState.Leased, propertiesResponse.Value.LeaseState);
            Assert.AreEqual(DataLakeLeaseDuration.Fixed, propertiesResponse.Value.LeaseDuration);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_08_04)]
        public async Task AppendDataAsync_Lease_Release()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateIfNotExistsAsync();

            string leaseId = Recording.Random.NewGuid().ToString();
            TimeSpan duration = TimeSpan.FromSeconds(15);
            DataLakeLeaseClient leaseClient = InstrumentClient(file.GetDataLakeLeaseClient(leaseId));
            Response<DataLakeLease> response = await leaseClient.AcquireAsync(duration);

            byte[] data = GetRandomBuffer(Size);
            DataLakeFileAppendOptions options = new DataLakeFileAppendOptions
            {
                LeaseId = leaseId,
                LeaseAction = DataLakeLeaseAction.Release,
                Flush = true
            };

            // Act
            using Stream stream = new MemoryStream(data);
            await file.AppendAsync(stream, 0, options);

            // Assert
            Response<PathProperties> propertiesResponse = await file.GetPropertiesAsync();
            Assert.AreEqual(DataLakeLeaseStatus.Unlocked, propertiesResponse.Value.LeaseStatus);
            Assert.AreEqual(DataLakeLeaseState.Available, propertiesResponse.Value.LeaseState);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_08_04)]
        public async Task AppendDataAsync_Lease_AcquireRelease()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateIfNotExistsAsync();
            byte[] data = GetRandomBuffer(Size);
            string proposedLeaseId = Recording.Random.NewGuid().ToString();
            TimeSpan duration = TimeSpan.FromSeconds(15);

            DataLakeFileAppendOptions options = new DataLakeFileAppendOptions
            {
                Flush = true,
                LeaseAction = DataLakeLeaseAction.AcquireRelease,
                ProposedLeaseId = proposedLeaseId,
                LeaseDuration = duration
            };

            // Act
            using Stream stream = new MemoryStream(data);
            await file.AppendAsync(stream, 0, options);

            // Assert
            Response<PathProperties> propertiesResponse = await file.GetPropertiesAsync();
            Assert.AreEqual(DataLakeLeaseStatus.Unlocked, propertiesResponse.Value.LeaseStatus);
            Assert.AreEqual(DataLakeLeaseState.Available, propertiesResponse.Value.LeaseState);
        }

        [RecordedTest]
        public async Task AppendDataAsync_NullStream_Error()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateIfNotExistsAsync();

            // Act
            using (var stream = (MemoryStream)null)
            {
                // Check if the correct param name that is causing the error is being returned
                await TestHelper.AssertExpectedExceptionAsync<ArgumentNullException>(
                    file.AppendAsync(
                        content: stream,
                        offset: 0),
                    e => Assert.AreEqual("body", e.ParamName));
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task AppendDataAsync_Flush()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateIfNotExistsAsync();
            var data = GetRandomBuffer(Size);

            DataLakeFileAppendOptions options = new DataLakeFileAppendOptions
            {
                Flush = true
            };

            // Act
            using (var stream = new MemoryStream(data))
            {
                await file.AppendAsync(
                    content: stream,
                    offset: 0,
                    options: options);
            }

            // Assert
            Response<FileDownloadInfo> response = await file.ReadAsync();

            Assert.AreEqual(data.Length, response.Value.ContentLength);
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [RecordedTest]
        [LiveOnly(Reason = "Encryption Key cannot be stored in recordings.")]
        public async Task AppendFlushReadAsync_CPK()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeCustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()).WithCustomerProvidedKey(customerProvidedKey));
            await file.CreateAsync();

            // Act
            byte[] data = GetRandomBuffer(Size);
            using Stream stream = new MemoryStream(data);
            await file.AppendAsync(stream, 0);
            await file.FlushAsync(Size);
            Response<FileDownloadInfo> downloadResponse = await file.ReadAsync();

            // Assert
            Assert.IsTrue(downloadResponse.Value.Properties.IsServerEncrypted);
            Assert.AreEqual(customerProvidedKey.EncryptionKeyHash, downloadResponse.Value.Properties.EncryptionKeySha256);
        }

        [RecordedTest]
        public async Task FlushDataAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateIfNotExistsAsync();
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                await file.AppendAsync(stream, Constants.KB);
            }

            // Act
            Response<PathInfo> response = await file.FlushAsync(0);

            // Assert
            AssertValidStoragePathInfo(response.Value);
        }

        [RecordedTest]
        public async Task FlushDataAsync_HttpHeaders()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateIfNotExistsAsync();
            byte[] data = GetRandomBuffer(Constants.KB);
            byte[] contentHash = MD5.Create().ComputeHash(data);
            PathHttpHeaders headers = new PathHttpHeaders
            {
                ContentType = ContentType,
                ContentEncoding = ContentEncoding,
                ContentLanguage = ContentLanguage,
                ContentDisposition = ContentDisposition,
                CacheControl = CacheControl,
                ContentHash = contentHash
            };

            using (var stream = new MemoryStream(data))
            {
                await file.AppendAsync(stream, 0);
            }

            DataLakeFileFlushOptions options = new DataLakeFileFlushOptions
            {
                HttpHeaders = headers
            };

            // Act
            await file.FlushAsync(Constants.KB, options);

            // Assert
            Response<PathProperties> response = await file.GetPropertiesAsync();
            Assert.AreEqual(ContentType, response.Value.ContentType);
            Assert.AreEqual(ContentEncoding, response.Value.ContentEncoding);
            Assert.AreEqual(ContentLanguage, response.Value.ContentLanguage);
            Assert.AreEqual(ContentDisposition, response.Value.ContentDisposition);
            Assert.AreEqual(CacheControl, response.Value.CacheControl);
            TestHelper.AssertSequenceEqual(contentHash, response.Value.ContentHash);
        }

        [RecordedTest]
        public async Task FlushDataAsync_Position()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateIfNotExistsAsync();
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                await file.AppendAsync(stream, 0);
            }

            // Act
            Response<PathInfo> response = await file.FlushAsync(0);

            // Assert
            AssertValidStoragePathInfo(response.Value);
        }

        [RecordedTest]
        public async Task FlushDataAsync_RetainUncommittedData()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateIfNotExistsAsync();
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                await file.AppendAsync(stream, Constants.KB);
            }

            DataLakeFileFlushOptions options = new DataLakeFileFlushOptions
            {
                RetainUncommittedData = true
            };

            // Act
            Response<PathInfo> response = await file.FlushAsync(0, options);

            // Assert
            AssertValidStoragePathInfo(response.Value);
        }

        [RecordedTest]
        public async Task FlushDataAsync_Close()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateIfNotExistsAsync();
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                await file.AppendAsync(stream, Constants.KB);
            }

            DataLakeFileFlushOptions options = new DataLakeFileFlushOptions
            {
                Close = true
            };

            // Act
            Response<PathInfo> response = await file.FlushAsync(0, options);

            // Assert
            AssertValidStoragePathInfo(response.Value);
        }

        [RecordedTest]
        public async Task FlushDataAsync_CloseTwice()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateAsync();
            var data = GetRandomBuffer(Constants.KB);

            using Stream stream = new MemoryStream(data);
            await file.AppendAsync(stream, 0);

            DataLakeFileFlushOptions options = new DataLakeFileFlushOptions
            {
                Close = true
            };

            // Act
            await file.FlushAsync(Constants.KB, options);
            Response<PathInfo> response = await file.FlushAsync(Constants.KB, options);

            // Assert
            AssertValidStoragePathInfo(response.Value);
        }

        [RecordedTest]
        public async Task FlushDataAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
                await file.CreateIfNotExistsAsync();
                var data = GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    await file.AppendAsync(stream, 0);
                }

                parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(file, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                DataLakeFileFlushOptions options = new DataLakeFileFlushOptions
                {
                    Conditions = conditions
                };

                // Act
                await file.FlushAsync(Constants.KB, options);
            }
        }

        [RecordedTest]
        public async Task FlushDataAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
                await file.CreateIfNotExistsAsync();
                var data = GetRandomBuffer(Size);

                using (var stream = new MemoryStream(data))
                {
                    await file.AppendAsync(stream, 0);
                }

                parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                DataLakeFileFlushOptions options = new DataLakeFileFlushOptions
                {
                    Conditions = conditions
                };

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    file.FlushAsync(Constants.KB, options),
                    e => { });
            }
        }

        [RecordedTest]
        public async Task FlushDataAsync_Error()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.FlushAsync(0),
                    e => Assert.AreEqual("PathNotFound", e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_08_04)]
        public async Task FlushDataAsync_Lease_Aquire()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateIfNotExistsAsync();
            byte[] data = GetRandomBuffer(Constants.KB);

            using Stream stream = new MemoryStream(data);
            await file.AppendAsync(stream, 0);

            string leaseId = Recording.Random.NewGuid().ToString();
            TimeSpan duration = TimeSpan.FromSeconds(15);

            DataLakeFileFlushOptions options = new DataLakeFileFlushOptions
            {
                LeaseAction = DataLakeLeaseAction.Acquire,
                ProposedLeaseId = leaseId,
                LeaseDuration = duration
            };

            // Act
            await file.FlushAsync(Constants.KB, options);

            // Assert
            Response<PathProperties> propertiesResponse = await file.GetPropertiesAsync();
            Assert.AreEqual(DataLakeLeaseStatus.Locked, propertiesResponse.Value.LeaseStatus);
            Assert.AreEqual(DataLakeLeaseState.Leased, propertiesResponse.Value.LeaseState);
            Assert.AreEqual(DataLakeLeaseDuration.Fixed, propertiesResponse.Value.LeaseDuration);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_08_04)]
        public async Task FlushDataAsync_Lease_AutoRenew()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateIfNotExistsAsync();
            byte[] data = GetRandomBuffer(Constants.KB);

            using Stream stream = new MemoryStream(data);

            string leaseId = Recording.Random.NewGuid().ToString();
            TimeSpan duration = TimeSpan.FromSeconds(15);

            DataLakeFileAppendOptions appendOptions = new DataLakeFileAppendOptions
            {
                LeaseAction = DataLakeLeaseAction.Acquire,
                ProposedLeaseId = leaseId,
                LeaseDuration = duration
            };

            await file.AppendAsync(stream, 0, appendOptions);

            DataLakeFileFlushOptions options = new DataLakeFileFlushOptions
            {
                LeaseAction = DataLakeLeaseAction.AutoRenew,
                Conditions = new DataLakeRequestConditions
                {
                    LeaseId = leaseId
                }
            };

            // Act
            await file.FlushAsync(Constants.KB, options);

            // Assert
            Response<PathProperties> propertiesResponse = await file.GetPropertiesAsync();
            Assert.AreEqual(DataLakeLeaseStatus.Locked, propertiesResponse.Value.LeaseStatus);
            Assert.AreEqual(DataLakeLeaseState.Leased, propertiesResponse.Value.LeaseState);
            Assert.AreEqual(DataLakeLeaseDuration.Fixed, propertiesResponse.Value.LeaseDuration);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_08_04)]
        public async Task FlushDataAsync_Lease_Release()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateIfNotExistsAsync();
            byte[] data = GetRandomBuffer(Constants.KB);

            using Stream stream = new MemoryStream(data);

            string leaseId = Recording.Random.NewGuid().ToString();
            TimeSpan duration = TimeSpan.FromSeconds(15);

            DataLakeFileAppendOptions appendOptions = new DataLakeFileAppendOptions
            {
                LeaseAction = DataLakeLeaseAction.Acquire,
                ProposedLeaseId = leaseId,
                LeaseDuration = duration
            };

            await file.AppendAsync(stream, 0, appendOptions);

            DataLakeFileFlushOptions options = new DataLakeFileFlushOptions
            {
                LeaseAction = DataLakeLeaseAction.Release,
                Conditions = new DataLakeRequestConditions
                {
                    LeaseId = leaseId
                }
            };

            // Act
            await file.FlushAsync(Constants.KB, options);

            // Assert
            Response<PathProperties> propertiesResponse = await file.GetPropertiesAsync();
            Assert.AreEqual(DataLakeLeaseStatus.Unlocked, propertiesResponse.Value.LeaseStatus);
            Assert.AreEqual(DataLakeLeaseState.Available, propertiesResponse.Value.LeaseState);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_08_04)]
        public async Task FlushDataAsync_Lease_AcquireRelease()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateIfNotExistsAsync();
            byte[] data = GetRandomBuffer(Constants.KB);

            using Stream stream = new MemoryStream(data);

            string leaseId = Recording.Random.NewGuid().ToString();
            TimeSpan duration = TimeSpan.FromSeconds(15);

            await file.AppendAsync(stream, 0);

            DataLakeFileFlushOptions options = new DataLakeFileFlushOptions
            {
                LeaseAction = DataLakeLeaseAction.AcquireRelease,
                ProposedLeaseId = leaseId,
                LeaseDuration = duration
            };

            // Act
            await file.FlushAsync(Constants.KB, options);

            // Assert
            Response<PathProperties> propertiesResponse = await file.GetPropertiesAsync();
            Assert.AreEqual(DataLakeLeaseStatus.Unlocked, propertiesResponse.Value.LeaseStatus);
            Assert.AreEqual(DataLakeLeaseState.Available, propertiesResponse.Value.LeaseState);
        }

        [RecordedTest]
        public async Task ReadAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            DataLakeFileClient fileClient = await test.FileSystem.CreateFileAsync(GetNewFileName());
            using (var stream = new MemoryStream(data))
            {
                await fileClient.AppendAsync(stream, 0);
            }

            await fileClient.FlushAsync(Constants.KB);

            // Act
            Response<FileDownloadInfo> response = await fileClient.ReadAsync();

            // Assert
            Assert.AreEqual(data.Length, response.Value.ContentLength);
            Assert.IsNotNull(response.Value.Properties.LastModified);
            Assert.IsNotNull(response.Value.Properties.AcceptRanges);
            Assert.IsNotNull(response.Value.Properties.ETag);
            Assert.IsNotNull(response.Value.Properties.LeaseStatus);
            Assert.IsNotNull(response.Value.Properties.LeaseState);
            Assert.IsNotNull(response.Value.Properties.IsServerEncrypted);
            Assert.IsNotNull(response.Value.Properties.CreatedOn);

            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [RecordedTest]
        public async Task ReadStreamingAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            byte[] data = GetRandomBuffer(Constants.KB);
            DataLakeFileClient fileClient = await test.FileSystem.CreateFileAsync(GetNewFileName());
            using (MemoryStream stream = new MemoryStream(data))
            {
                await fileClient.AppendAsync(stream, 0);
            }

            await fileClient.FlushAsync(Constants.KB);

            // Act
            Response<DataLakeFileReadStreamingResult> response = await fileClient.ReadStreamingAsync();

            // Assert
            Assert.IsNotNull(response.Value.Details.LastModified);
            Assert.IsNotNull(response.Value.Details.AcceptRanges);
            Assert.IsNotNull(response.Value.Details.ETag);
            Assert.IsNotNull(response.Value.Details.LeaseStatus);
            Assert.IsNotNull(response.Value.Details.LeaseState);
            Assert.IsNotNull(response.Value.Details.IsServerEncrypted);
            Assert.IsNotNull(response.Value.Details.CreatedOn);
            Assert.IsNotNull(response.Value.Details.Metadata);

            MemoryStream actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [RecordedTest]
        public async Task ReadContentAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            byte[] data = GetRandomBuffer(Constants.KB);
            DataLakeFileClient fileClient = await test.FileSystem.CreateFileAsync(GetNewFileName());
            using (MemoryStream stream = new MemoryStream(data))
            {
                await fileClient.AppendAsync(stream, 0);
            }

            await fileClient.FlushAsync(Constants.KB);

            // Act
            Response<DataLakeFileReadResult> response = await fileClient.ReadContentAsync();

            // Assert
            Assert.IsNotNull(response.Value.Details.LastModified);
            Assert.IsNotNull(response.Value.Details.AcceptRanges);
            Assert.IsNotNull(response.Value.Details.ETag);
            Assert.IsNotNull(response.Value.Details.LeaseStatus);
            Assert.IsNotNull(response.Value.Details.LeaseState);
            Assert.IsNotNull(response.Value.Details.IsServerEncrypted);
            Assert.IsNotNull(response.Value.Details.CreatedOn);
            Assert.IsNotNull(response.Value.Details.Metadata);

            byte[] actual = response.Value.Content.ToArray();
            TestHelper.AssertSequenceEqual(data, actual);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2024_05_04)]
        public async Task ReadAsyncACL()
        {
            await using DisposingFileSystem test = await GetNewFileSystem(publicAccessType: PublicAccessType.None);
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            DataLakeFileClient fileClient = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                AccessOptions = new DataLakeAccessOptions
                {
                    AccessControlList = AccessControlList
                }
            };

            await fileClient.CreateAsync(options: options);

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await fileClient.AppendAsync(stream, 0);
            }

            await fileClient.FlushAsync(Constants.KB);

            // Act
            Response<FileDownloadInfo> response = await fileClient.ReadAsync();

            // Assert
            Assert.AreEqual(data.Length, response.Value.ContentLength);
            Assert.IsNotNull(response.Value.Properties.LastModified);
            Assert.IsNotNull(response.Value.Properties.AcceptRanges);
            Assert.IsNotNull(response.Value.Properties.ETag);
            Assert.IsNotNull(response.Value.Properties.LeaseStatus);
            Assert.IsNotNull(response.Value.Properties.LeaseState);
            Assert.IsNotNull(response.Value.Properties.IsServerEncrypted);
            Assert.IsNotNull(response.Value.Properties.CreatedOn);
            AssertAccessControlListEquality(AccessControlList, response.Value.Properties.AccessControlList.ToList());

            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2024_05_04)]
        public async Task ReadStreamingAsyncACL()
        {
            await using DisposingFileSystem test = await GetNewFileSystem(publicAccessType: PublicAccessType.None);
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            DataLakeFileClient fileClient = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                AccessOptions = new DataLakeAccessOptions
                {
                    AccessControlList = AccessControlList
                }
            };

            await fileClient.CreateAsync(options: options);

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await fileClient.AppendAsync(stream, 0);
            }

            await fileClient.FlushAsync(Constants.KB);

            // Act
            Response<DataLakeFileReadStreamingResult> response = await fileClient.ReadStreamingAsync();

            // Assert
            Assert.IsNotNull(response.Value.Details.LastModified);
            Assert.IsNotNull(response.Value.Details.AcceptRanges);
            Assert.IsNotNull(response.Value.Details.ETag);
            Assert.IsNotNull(response.Value.Details.LeaseStatus);
            Assert.IsNotNull(response.Value.Details.LeaseState);
            Assert.IsNotNull(response.Value.Details.IsServerEncrypted);
            Assert.IsNotNull(response.Value.Details.CreatedOn);
            AssertAccessControlListEquality(AccessControlList, response.Value.Details.AccessControlList.ToList());

            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2024_05_04)]
        public async Task ReadContentAsyncACL()
        {
            await using DisposingFileSystem test = await GetNewFileSystem(publicAccessType: PublicAccessType.None);
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            DataLakeFileClient fileClient = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                AccessOptions = new DataLakeAccessOptions
                {
                    AccessControlList = AccessControlList
                }
            };

            await fileClient.CreateAsync(options: options);

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await fileClient.AppendAsync(stream, 0);
            }

            await fileClient.FlushAsync(Constants.KB);

            // Act
            Response<DataLakeFileReadResult> response = await fileClient.ReadContentAsync();

            // Assert
            Assert.IsNotNull(response.Value.Details.LastModified);
            Assert.IsNotNull(response.Value.Details.AcceptRanges);
            Assert.IsNotNull(response.Value.Details.ETag);
            Assert.IsNotNull(response.Value.Details.LeaseStatus);
            Assert.IsNotNull(response.Value.Details.LeaseState);
            Assert.IsNotNull(response.Value.Details.IsServerEncrypted);
            Assert.IsNotNull(response.Value.Details.CreatedOn);
            AssertAccessControlListEquality(AccessControlList, response.Value.Details.AccessControlList.ToList());

            byte[] actual = response.Value.Content.ToArray();
            TestHelper.AssertSequenceEqual(data, actual);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2024_05_04)]
        public async Task GetPropertiesAsyncACL()
        {
            await using DisposingFileSystem test = await GetNewFileSystem(publicAccessType: PublicAccessType.None);
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            DataLakeFileClient fileClient = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                AccessOptions = new DataLakeAccessOptions
                {
                    AccessControlList = AccessControlList
                }
            };

            await fileClient.CreateAsync(options: options);

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await fileClient.AppendAsync(stream, 0);
            }

            await fileClient.FlushAsync(Constants.KB);

            // Act
            Response<PathProperties> response = await fileClient.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(data.Length, response.Value.ContentLength);
            AssertAccessControlListEquality(AccessControlList, response.Value.AccessControlList.ToList());
        }

        [RecordedTest]
        public async Task ReadAsync_Range()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            DataLakeFileClient fileClient = await test.FileSystem.CreateFileAsync(GetNewFileName());
            using (var stream = new MemoryStream(data))
            {
                await fileClient.AppendAsync(stream, 0);
            }

            await fileClient.FlushAsync(Constants.KB);
            HttpRange httpRange = new HttpRange(256, 512);

            // Act
            Response<FileDownloadInfo> response = await fileClient.ReadAsync(
                range: httpRange,
                conditions: default,
                rangeGetContentHash: true,
                cancellationToken: default
                );

            // Assert
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data.Skip(256).Take(512).ToArray(), actual.ToArray());
        }

        [RecordedTest]
        public async Task ReadAsync_RangeGetContentHash()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            DataLakeFileClient fileClient = await test.FileSystem.CreateFileAsync(GetNewFileName());
            using (var stream = new MemoryStream(data))
            {
                await fileClient.AppendAsync(stream, 0);
            }

            await fileClient.FlushAsync(Constants.KB);
            HttpRange httpRange = new HttpRange(0, 1024);

            // Act
            Response<FileDownloadInfo> response = await fileClient.ReadAsync(
                range: httpRange,
                conditions: default,
                rangeGetContentHash: true,
                cancellationToken: default);

            // Assert
            Assert.IsNotNull(response.Value.ContentHash);
        }

        [RecordedTest]
        public async Task ReadAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
                using (var stream = new MemoryStream(data))
                {
                    await file.AppendAsync(stream, 0);
                }

                await file.FlushAsync(Constants.KB);

                parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(file, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<FileDownloadInfo> response = await file.ReadAsync(new DataLakeFileReadOptions
                {
                    Conditions = conditions
                });

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [RecordedTest]
        public async Task ReadStreamingAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
                using (var stream = new MemoryStream(data))
                {
                    await file.AppendAsync(stream, 0);
                }

                await file.FlushAsync(Constants.KB);

                parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(file, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<DataLakeFileReadStreamingResult> response = await file.ReadStreamingAsync(new DataLakeFileReadOptions
                {
                    Conditions = conditions
                });

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [RecordedTest]
        public async Task ReadContentAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
                using (var stream = new MemoryStream(data))
                {
                    await file.AppendAsync(stream, 0);
                }

                await file.FlushAsync(Constants.KB);

                parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(file, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Response<DataLakeFileReadResult> response = await file.ReadContentAsync(new DataLakeFileReadOptions
                {
                    Conditions = conditions
                });

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [RecordedTest]
        public async Task ReadAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
                using (var stream = new MemoryStream(data))
                {
                    await file.AppendAsync(stream, 0);
                }

                await file.FlushAsync(Constants.KB);

                parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                // Act
                await TestHelper.CatchAsync<Exception>(
                    async () =>
                    {
                        var _ = (await file.ReadAsync(new DataLakeFileReadOptions
                        {
                            Conditions = conditions
                        })).Value;
                    });
            }
        }

        [RecordedTest]
        public async Task ReadStreamingAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
                using (var stream = new MemoryStream(data))
                {
                    await file.AppendAsync(stream, 0);
                }

                await file.FlushAsync(Constants.KB);

                parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                // Act
                await TestHelper.CatchAsync<Exception>(
                    async () =>
                    {
                        var _ = (await file.ReadStreamingAsync(new DataLakeFileReadOptions
                        {
                            Conditions = conditions
                        })).Value;
                    });
            }
        }

        [RecordedTest]
        public async Task ReadContentAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
                using (var stream = new MemoryStream(data))
                {
                    await file.AppendAsync(stream, 0);
                }

                await file.FlushAsync(Constants.KB);

                parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                // Act
                await TestHelper.CatchAsync<Exception>(
                    async () =>
                    {
                        var _ = (await file.ReadContentAsync(new DataLakeFileReadOptions
                        {
                            Conditions = conditions
                        })).Value;
                    });
            }
        }

        [RecordedTest]
        public async Task ReadAsync_Error()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.ReadAsync(),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [RecordedTest]
        public async Task ReadStreamingAsync_Error()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.ReadStreamingAsync(),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [RecordedTest]
        public async Task ReadContentAsync_Error()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.ReadContentAsync(),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [RecordedTest]
        public async Task AcquireLeaseAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);
            var leaseClient = InstrumentClient(file.GetDataLakeLeaseClient(leaseId));

            // Act
            Response<DataLakeLease> response = await leaseClient.AcquireAsync(duration);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            Assert.AreEqual(response.Value.LeaseId, leaseClient.LeaseId);
        }

        [RecordedTest]
        public async Task AcquireLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                RequestConditions conditions = BuildRequestConditions(
                    parameters: parameters);

                // Act
                Response<DataLakeLease> response = await InstrumentClient(file.GetDataLakeLeaseClient(leaseId)).AcquireAsync(
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
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                RequestConditions conditions = BuildRequestConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(file.GetDataLakeLeaseClient(leaseId)).AcquireAsync(
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
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(file.GetDataLakeLeaseClient(leaseId)).AcquireAsync(duration),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [RecordedTest]
        public async Task RenewLeaseAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            DataLakeLeaseClient lease = InstrumentClient(file.GetDataLakeLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            Response<DataLakeLease> response = await lease.RenewAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            Assert.AreEqual(response.Value.LeaseId, lease.LeaseId);
        }

        [RecordedTest]
        public async Task RenewLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                RequestConditions conditions = BuildRequestConditions(
                    parameters: parameters);

                DataLakeLeaseClient lease = InstrumentClient(file.GetDataLakeLeaseClient(leaseId));
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
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                RequestConditions conditions = BuildRequestConditions(parameters);

                DataLakeLeaseClient lease = InstrumentClient(file.GetDataLakeLeaseClient(leaseId));
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
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            var leaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(file.GetDataLakeLeaseClient(leaseId)).ReleaseAsync(),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [RecordedTest]
        public async Task ReleaseLeaseAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            DataLakeLeaseClient lease = InstrumentClient(file.GetDataLakeLeaseClient(leaseId));
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
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                RequestConditions conditions = BuildRequestConditions(
                    parameters: parameters);

                DataLakeLeaseClient lease = InstrumentClient(file.GetDataLakeLeaseClient(leaseId));
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
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                RequestConditions conditions = BuildRequestConditions(parameters);

                DataLakeLeaseClient lease = InstrumentClient(file.GetDataLakeLeaseClient(leaseId));
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
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            var leaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(file.GetDataLakeLeaseClient(leaseId)).RenewAsync(),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [RecordedTest]
        public async Task ChangeLeaseAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

            var leaseId = Recording.Random.NewGuid().ToString();
            var newLeaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            DataLakeLeaseClient lease = InstrumentClient(file.GetDataLakeLeaseClient(leaseId));
            await lease.AcquireAsync(duration);

            // Act
            Response<DataLakeLease> response = await lease.ChangeAsync(newLeaseId);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            Assert.AreEqual(response.Value.LeaseId, lease.LeaseId);
        }

        [RecordedTest]
        public async Task ChangeLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var newLeaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                RequestConditions conditions = BuildRequestConditions(
                    parameters: parameters);

                DataLakeLeaseClient lease = InstrumentClient(file.GetDataLakeLeaseClient(leaseId));
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
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var newLeaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                RequestConditions conditions = BuildRequestConditions(parameters);

                DataLakeLeaseClient lease = InstrumentClient(file.GetDataLakeLeaseClient(leaseId));
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
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            var leaseId = Recording.Random.NewGuid().ToString();
            var newLeaseId = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(file.GetDataLakeLeaseClient(leaseId)).ChangeAsync(proposedId: newLeaseId),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [RecordedTest]
        public async Task BreakLeaseAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            DataLakeLeaseClient lease = InstrumentClient(file.GetDataLakeLeaseClient(leaseId));
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
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                RequestConditions conditions = BuildRequestConditions(
                    parameters: parameters);

                DataLakeLeaseClient lease = InstrumentClient(file.GetDataLakeLeaseClient(leaseId));
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
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                RequestConditions conditions = BuildRequestConditions(parameters);

                DataLakeLeaseClient lease = InstrumentClient(file.GetDataLakeLeaseClient(leaseId));
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
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(file.GetDataLakeLeaseClient()).BreakAsync(),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [RecordedTest]
        public async Task ReadToAsync_PathOverloads()
        {
            // Arrange
            var path = System.IO.Path.GetTempFileName();
            try
            {
                await using DisposingFileSystem test = await GetNewFileSystem();
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
                int size = Constants.KB;
                byte[] data = GetRandomBuffer(size);
                using Stream stream = new MemoryStream(data);

                await file.AppendAsync(stream, 0);
                await file.FlushAsync(size);

                await Verify(await file.ReadToAsync(path));
                await Verify(await file.ReadToAsync(
                    path,
                    cancellationToken: CancellationToken.None));

                await Verify(await file.ReadToAsync(
                    path,
                    new DataLakeFileReadToOptions
                    {
                        Conditions = new DataLakeRequestConditions() { IfModifiedSince = default }
                    }));

                async Task Verify(Response response)
                {
                    Assert.AreEqual(size, File.ReadAllBytes(path).Length);
                    using MemoryStream actual = new MemoryStream();
                    using FileStream resultStream = File.OpenRead(path);
                    await resultStream.CopyToAsync(actual);
                    TestHelper.AssertSequenceEqual(data, actual.ToArray());
                }
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        [RecordedTest]
        public async Task ReadToAsync_StreamOverloads()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
            int size = Constants.KB;
            byte[] data = GetRandomBuffer(size);
            using Stream stream = new MemoryStream(data);

            await file.AppendAsync(stream, 0);
            await file.FlushAsync(size);

            using (var resultStream = new MemoryStream(data))
            {
                await file.ReadToAsync(resultStream);
                Verify(resultStream);
            }
            using (var resultStream = new MemoryStream())
            {
                await file.ReadToAsync(
                    resultStream,
                    cancellationToken: CancellationToken.None);
                Verify(resultStream);
            }
            using (var resultStream = new MemoryStream())
            {
                await file.ReadToAsync(
                    resultStream,
                    new DataLakeFileReadToOptions
                    {
                        Conditions = new DataLakeRequestConditions() { IfModifiedSince = default }
                    });
                Verify(resultStream);
            }

            void Verify(MemoryStream resultStream)
            {
                Assert.AreEqual(data.Length, resultStream.Length);
                TestHelper.AssertSequenceEqual(data, resultStream.ToArray());
            }
        }

        [RecordedTest]
        [Ignore("Live tests will run out of memory")]
        public async Task UploadAsync_StreamLarge()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());

            var data = GetRandomBuffer(300 * Constants.MB);

            // Act
            using (var stream = new MemoryStream(data))
            {
                await file.UploadAsync(
                    stream);
            }

            // Assert
            using var actual = new MemoryStream();
            await file.ReadToAsync(
                actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [RecordedTest]
        public async Task UploadAsync_MinStream()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());

            var data = GetRandomBuffer(Constants.KB);

            // Act
            using (var stream = new MemoryStream(data))
            {
                await file.UploadAsync(stream);
            }

            // Assert
            using var actual = new MemoryStream();
            await file.ReadToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [RecordedTest]
        public async Task UploadAsync_MetadataStream()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());
            var data = GetRandomBuffer(Constants.KB);
            IDictionary<string, string> metadata = BuildMetadata();
            DataLakeFileUploadOptions options = new DataLakeFileUploadOptions
            {
                Metadata = metadata
            };

            // Act
            using (var stream = new MemoryStream(data))
            {
                await file.UploadAsync(stream, options);
            }
            Response<PathProperties> response = await file.GetPropertiesAsync();

            // Assert
            AssertMetadataEquality(metadata, response.Value.Metadata, isDirectory: false);
        }

        [RecordedTest]
        public async Task UploadAsync_PermissionsUmaskStream()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());
            var data = GetRandomBuffer(Constants.KB);
            string permissions = "0777";
            string umask = "0057";
            DataLakeFileUploadOptions options = new DataLakeFileUploadOptions
            {
                Permissions = permissions,
                Umask = umask
            };

            // Act
            using (var stream = new MemoryStream(data))
            {
                await file.UploadAsync(stream, options);
            }
            Response<PathAccessControl> response = await file.GetAccessControlAsync();

            // Assert
            AssertPathPermissionsEquality(PathPermissions.ParseSymbolicPermissions("rwx-w----"), response.Value.Permissions);
        }

        [RecordedTest]
        public async Task UploadAsync_MinStreamNoOverride()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());

            var data = GetRandomBuffer(Constants.KB);

            // Act
            using (var stream = new MemoryStream(data))
            {
                await file.UploadAsync(stream, overwrite: false);
            }

            // Assert
            using var actual = new MemoryStream();
            await file.ReadToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());

            // Act - Attempt to Upload again with override = false
            using (var stream = new System.IO.MemoryStream(data))
            {
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    file.UploadAsync(stream, overwrite: false),
                    e => Assert.AreEqual("PathAlreadyExists", e.ErrorCode.Split('\n')[0]));
            }
        }

        [RecordedTest]
        public async Task UploadAsync_MinStreamOverride()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

            var data = GetRandomBuffer(Constants.KB);

            // Act
            using (var stream = new MemoryStream(data))
            {
                await file.UploadAsync(stream, overwrite: true);
            }

            // Assert
            using var actual = new MemoryStream();
            await file.ReadToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [RecordedTest]
        [TestCase(Constants.KB)]
        [TestCase(10 * Constants.KB)]
        [TestCase(Constants.MB)]
        [TestCase(10000000)] // test for scientific notation.
        [TestCase(10 * Constants.MB)]
        [TestCase(100 * Constants.MB)]
        [LiveOnly]
        public async Task UploadAsync_MinStreamOverride_VariousSizes(long size)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

            var data = GetRandomBuffer(size);

            // Act
            using (var stream = new MemoryStream(data))
            {
                await file.UploadAsync(stream, overwrite: true);
            }

            // Assert
            using var actual = new MemoryStream();
            await file.ReadToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [RecordedTest]
        public async Task UploadAsync_Stream_InvalidStreamPosition()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());
            long size = Constants.KB;
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

        [RecordedTest]
        public async Task UploadAsync_NonZeroStreamPosition()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());

            long size = Constants.KB;
            long position = 512;
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
            Response<FileDownloadInfo> downloadResponse = await file.ReadAsync();
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(expectedData, actual.ToArray());
        }

        [RecordedTest]
        public async Task UploadAsync_NonZeroStreamPositionMultipleBlocks()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());

            long size = 2 * Constants.KB;
            long position = 300;
            byte[] data = GetRandomBuffer(size);
            byte[] expectedData = new byte[size - position];
            Array.Copy(data, position, expectedData, 0, size - position);

            using Stream stream = new MemoryStream(data)
            {
                Position = position
            };

            DataLakeFileUploadOptions options = new DataLakeFileUploadOptions
            {
                TransferOptions = new StorageTransferOptions
                {
                    MaximumTransferSize = 512,
                    InitialTransferSize = 512
                }
            };

            // Act
            await file.UploadAsync(
                stream,
                options);

            // Assert
            Response<FileDownloadInfo> downloadResponse = await file.ReadAsync();
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(expectedData, actual.ToArray());
        }

        [RecordedTest]
        public async Task UploadAsync_Close()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());

            byte[] data = GetRandomBuffer(Constants.KB);

            DataLakeFileUploadOptions options = new DataLakeFileUploadOptions
            {
                Close = true,
            };

            // Act
            using Stream stream = new MemoryStream(data);
            await file.UploadAsync(stream, options: options);

            // Assert
            using var actual = new MemoryStream();
            await file.ReadToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [RecordedTest]
        [Ignore("Live tests will run out of memory")]
        public async Task UploadAsync_FileLarge()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());

            var data = GetRandomBuffer(300 * Constants.MB);

            using (var stream = new MemoryStream(data))
            {
                var path = System.IO.Path.GetTempFileName();

                try
                {
                    File.WriteAllBytes(path, data);

                    await file.UploadAsync(path);
                }
                finally
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
            }

            // Assert
            using var actual = new MemoryStream();
            await file.ReadToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task UploadAsync_MinFile(bool readOnlyFile)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());

            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                var path = System.IO.Path.GetTempFileName();

                try
                {
                    File.WriteAllBytes(path, data);

                    if (readOnlyFile)
                    {
                        File.SetAttributes(path, FileAttributes.ReadOnly);
                    }

                    await file.UploadAsync(path);
                }
                finally
                {
                    if (File.Exists(path))
                    {
                        File.SetAttributes(path, FileAttributes.Normal);
                        File.Delete(path);
                    }
                }
            }

            // Assert
            using var actual = new MemoryStream();
            await file.ReadToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [RecordedTest]
        public async Task UploadAsync_MetadataFile()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());
            var data = GetRandomBuffer(Constants.KB);
            IDictionary<string, string> metadata = BuildMetadata();
            DataLakeFileUploadOptions options = new DataLakeFileUploadOptions
            {
                Metadata = metadata
            };

            using (var stream = new MemoryStream(data))
            {
                var path = System.IO.Path.GetTempFileName();

                try
                {
                    File.WriteAllBytes(path, data);

                    await file.UploadAsync(path, options);
                }
                finally
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
            }
            Response<PathProperties> response = await file.GetPropertiesAsync();

            // Assert
            AssertMetadataEquality(metadata, response.Value.Metadata, isDirectory: false);
        }

        [RecordedTest]
        public async Task UploadAsync_PermissionsUmaskFile()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());
            var data = GetRandomBuffer(Constants.KB);
            string permissions = "0777";
            string umask = "0057";
            DataLakeFileUploadOptions options = new DataLakeFileUploadOptions
            {
                Permissions = permissions,
                Umask = umask
            };

            using (var stream = new MemoryStream(data))
            {
                var path = System.IO.Path.GetTempFileName();

                try
                {
                    File.WriteAllBytes(path, data);

                    await file.UploadAsync(path, options);
                }
                finally
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
            }
            Response<PathAccessControl> response = await file.GetAccessControlAsync();

            // Assert
            AssertPathPermissionsEquality(PathPermissions.ParseSymbolicPermissions("rwx-w----"), response.Value.Permissions);
        }

        [RecordedTest]
        public async Task UploadAsync_MinFileNoOverride()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());

            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                var path = System.IO.Path.GetTempFileName();

                try
                {
                    File.WriteAllBytes(path, data);

                    // Act
                    await file.UploadAsync(path, overwrite: false);

                    // Assert
                    using var actual = new MemoryStream();
                    await file.ReadToAsync(actual);
                    TestHelper.AssertSequenceEqual(data, actual.ToArray());

                    // Act - Attempt to Upload again with override = false
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        file.UploadAsync(path, overwrite: false),
                        e => Assert.AreEqual("PathAlreadyExists", e.ErrorCode.Split('\n')[0]));
                }
                finally
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
            }
        }

        [RecordedTest]
        public async Task UploadAsync_MinFileOverride()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                var path = System.IO.Path.GetTempFileName();

                try
                {
                    File.WriteAllBytes(path, data);

                    await file.UploadAsync(path, overwrite: true);
                }
                finally
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
            }

            // Assert
            using var actual = new MemoryStream();
            await file.ReadToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2021_04_10)]
        public async Task UploadAsync_EncryptionContext()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());

            byte[] data = GetRandomBuffer(Constants.KB);

            string encryptionContext = "encryptionContext";
            DataLakeFileUploadOptions options = new DataLakeFileUploadOptions
            {
                EncryptionContext = encryptionContext
            };

            // Act
            using Stream stream = new MemoryStream(data);
            await file.UploadAsync(stream, options: options);

            // Assert
            Response<PathProperties> pathProperties = await file.GetPropertiesAsync();
            Assert.AreEqual(encryptionContext, pathProperties.Value.EncryptionContext);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ScheduleDeletionAsync_Relative()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

            // Delay 1 second, so current times doesn't equal blob creation time.
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(1000);
            }

            DataLakeFileScheduleDeletionOptions options = new DataLakeFileScheduleDeletionOptions(
                new TimeSpan(hours: 1, minutes: 0, seconds: 0),
                DataLakeFileExpirationOrigin.Now);

            // Act
            Response<PathInfo> expiryResponse = await file.ScheduleDeletionAsync(options);
            Response<PathProperties> propertiesResponse = await file.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(expiryResponse.Value.ETag);
            Assert.IsNotNull(expiryResponse.Value.LastModified);
            Assert.AreNotEqual(propertiesResponse.Value.CreatedOn.AddHours(1), propertiesResponse.Value.ExpiresOn);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ScheduleDeletionAsync_RelativeToFileCreationTime()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
            DataLakeFileScheduleDeletionOptions options = new DataLakeFileScheduleDeletionOptions(
                new TimeSpan(hours: 1, minutes: 0, seconds: 0),
                DataLakeFileExpirationOrigin.CreationTime);

            // Act
            Response<PathInfo> expiryResponse = await file.ScheduleDeletionAsync(options);
            Response<PathProperties> propertiesResponse = await file.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(propertiesResponse.Value.CreatedOn.AddHours(1), propertiesResponse.Value.ExpiresOn);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ScheduleDeletionAsync_Error()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            DataLakeFileScheduleDeletionOptions options = new DataLakeFileScheduleDeletionOptions(
                new TimeSpan(hours: 1, minutes: 0, seconds: 0),
                DataLakeFileExpirationOrigin.Now);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.ScheduleDeletionAsync(options),
                e => Assert.AreEqual(Blobs.Models.BlobErrorCode.BlobNotFound.ToString(), e.ErrorCode));
            ;
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ScheduleDeletionAsync_Absolute()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
            DateTimeOffset expiresOn = new DateTimeOffset(2100, 1, 1, 0, 0, 0, 0, TimeSpan.Zero);
            DataLakeFileScheduleDeletionOptions options = new DataLakeFileScheduleDeletionOptions(expiresOn);

            // Act
            Response<PathInfo> expiryResponse = await file.ScheduleDeletionAsync(options);
            Response<PathProperties> propertiesResponse = await file.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(expiryResponse.Value.ETag);
            Assert.IsNotNull(expiryResponse.Value.LastModified);
            Assert.AreEqual(expiresOn, propertiesResponse.Value.ExpiresOn);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ScheduleDeletionAsync_RemoveExpiry()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
            DateTimeOffset expiresOn = new DateTimeOffset(2100, 1, 1, 0, 0, 0, 0, TimeSpan.Zero);
            DataLakeFileScheduleDeletionOptions options = new DataLakeFileScheduleDeletionOptions(expiresOn);
            await file.ScheduleDeletionAsync(options);

            // Act
            await file.ScheduleDeletionAsync(new DataLakeFileScheduleDeletionOptions());
            Response<PathProperties> propertiesResponse = await file.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(default(DateTimeOffset), propertiesResponse.Value.ExpiresOn);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_Min()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());
            Stream stream = CreateDataStream(Constants.KB);
            await file.UploadAsync(stream);

            // Act
            string query = @"SELECT _2 from BlobStorage WHERE _1 > 250;";
            Response<FileDownloadInfo> response = await file.QueryAsync(query);

            using StreamReader streamReader = new StreamReader(response.Value.Content);
            string s = await streamReader.ReadToEndAsync();

            // Assert
            Assert.AreEqual("400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n", s);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_Error()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());
            string query = @"SELECT _2 from BlobStorage WHERE _1 > 250;";

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.QueryAsync(
                    query),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_Progress()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());
            Stream stream = CreateDataStream(Constants.KB);
            await file.UploadAsync(stream);

            // Act
            string query = @"SELECT _2 from BlobStorage WHERE _1 > 250;";
            TestProgress progressReporter = new TestProgress();
            DataLakeQueryOptions options = new DataLakeQueryOptions
            {
                ProgressHandler = progressReporter
            };

            Response<FileDownloadInfo> response = await file.QueryAsync(
                query,
                options);

            using StreamReader streamReader = new StreamReader(response.Value.Content);
            await streamReader.ReadToEndAsync();

            Assert.AreEqual(2, progressReporter.List.Count);
            Assert.AreEqual(Constants.KB, progressReporter.List[0]);
            Assert.AreEqual(Constants.KB, progressReporter.List[1]);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_QueryTextConfigurations()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());
            Stream stream = CreateDataStream(Constants.KB);
            await file.UploadAsync(stream);

            // Act
            string query = @"SELECT _2 from BlobStorage WHERE _1 > 250;";

            DataLakeQueryCsvTextOptions csvTextConfiguration = new DataLakeQueryCsvTextOptions
            {
                ColumnSeparator = ",",
                QuotationCharacter = '"',
                EscapeCharacter = '\\',
                RecordSeparator = "\n",
                HasHeaders = false
            };

            DataLakeQueryJsonTextOptions jsonTextConfiguration = new DataLakeQueryJsonTextOptions
            {
                RecordSeparator = "\n"
            };

            DataLakeQueryOptions options = new DataLakeQueryOptions
            {
                InputTextConfiguration = csvTextConfiguration,
                OutputTextConfiguration = jsonTextConfiguration
            };

            // Act
            Response<FileDownloadInfo> response = await file.QueryAsync(
                query,
                options);

            using StreamReader streamReader = new StreamReader(response.Value.Content);
            string s = await streamReader.ReadToEndAsync();

            // Assert
            Assert.AreEqual("{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n", s);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_NonFatalError()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());

            byte[] data = Encoding.UTF8.GetBytes("100,pizza,300,400\n300,400,500,600\n");
            using MemoryStream stream = new MemoryStream(data);
            await file.UploadAsync(stream);
            string query = @"SELECT _1 from BlobStorage WHERE _2 > 250;";

            // Act - with no IBlobQueryErrorReceiver
            Response<FileDownloadInfo> response = await file.QueryAsync(query);
            using StreamReader streamReader = new StreamReader(response.Value.Content);
            string s = await streamReader.ReadToEndAsync();

            // Act - with  IBlobQueryErrorReceiver
            DataLakeQueryError expectedBlobQueryError = new DataLakeQueryError
            {
                IsFatal = false,
                Name = "InvalidTypeConversion",
                Description = "Invalid type conversion.",
                Position = 0
            };

            ErrorHandler errorHandler = new ErrorHandler(expectedBlobQueryError);

            DataLakeQueryOptions options = new DataLakeQueryOptions();
            options.ErrorHandler += errorHandler.Handle;

            response = await file.QueryAsync(
                query,
                options);
            using StreamReader streamReader2 = new StreamReader(response.Value.Content);
            s = await streamReader2.ReadToEndAsync();
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/12063")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_FatalError()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());
            Stream stream = CreateDataStream(Constants.KB);
            await file.UploadAsync(stream);
            string query = @"SELECT * from BlobStorage;";
            DataLakeQueryJsonTextOptions jsonTextConfiguration = new DataLakeQueryJsonTextOptions
            {
                RecordSeparator = "\n"
            };
            DataLakeQueryOptions options = new DataLakeQueryOptions
            {
                InputTextConfiguration = jsonTextConfiguration
            };

            // Act - with no IBlobQueryErrorReceiver
            Response<FileDownloadInfo> response = await file.QueryAsync(
                query,
                options);
            using StreamReader streamReader = new StreamReader(response.Value.Content);
            string s = await streamReader.ReadToEndAsync();

            // Act - with  IBlobQueryErrorReceiver
            DataLakeQueryError expectedBlobQueryError = new DataLakeQueryError
            {
                IsFatal = true,
                Name = "ParseError",
                Description = "Unexpected token ',' at [byte: 3]. Expecting tokens '{', or '['.",
                Position = 0
            };
            ErrorHandler errorHandler = new ErrorHandler(expectedBlobQueryError);
            options = new DataLakeQueryOptions
            {
                InputTextConfiguration = jsonTextConfiguration
            };
            options.ErrorHandler += errorHandler.Handle;

            response = await file.QueryAsync(
                query,
                options);
            using StreamReader streamReader2 = new StreamReader(response.Value.Content);
            s = await streamReader2.ReadToEndAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                // Arrange
                await using DisposingFileSystem test = await GetNewFileSystem();
                DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());
                Stream stream = CreateDataStream(Constants.KB);
                await file.UploadAsync(stream);

                parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(file, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions accessConditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                DataLakeQueryOptions options = new DataLakeQueryOptions
                {
                    Conditions = accessConditions
                };

                string query = @"SELECT * from BlobStorage";

                // Act
                Response<FileDownloadInfo> response = await file.QueryAsync(
                    query,
                    options);

                // Assert
                Assert.IsNotNull(response.Value.Properties.ETag);
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                // Arrange
                await using DisposingFileSystem test = await GetNewFileSystem();
                DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());
                Stream stream = CreateDataStream(Constants.KB);
                await file.UploadAsync(stream);

                parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                DataLakeRequestConditions accessConditions = BuildDataLakeRequestConditions(parameters);
                DataLakeQueryOptions options = new DataLakeQueryOptions
                {
                    Conditions = accessConditions
                };

                string query = @"SELECT * from BlobStorage";

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    file.QueryAsync(
                        query,
                        options),
                    e => { });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_ArrowConfiguration()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());
            Stream stream = CreateDataStream(Constants.KB);
            await file.UploadAsync(stream);

            // Act
            string query = @"SELECT _2 from BlobStorage WHERE _1 > 250;";
            DataLakeQueryOptions options = new DataLakeQueryOptions
            {
                OutputTextConfiguration = new DataLakeQueryArrowOptions
                {
                    Schema = new List<DataLakeQueryArrowField>()
                    {
                        new DataLakeQueryArrowField
                        {
                            Type = DataLakeQueryArrowFieldType.Decimal,
                            Name = "Name",
                            Precision = 4,
                            Scale = 2
                        }
                    }
                }
            };

            // Act
            await file.QueryAsync(
                query,
                options: options);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_ArrowConfigurationInput()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());
            Stream stream = CreateDataStream(Constants.KB);
            await file.UploadAsync(stream);

            // Act
            string query = @"SELECT _2 from BlobStorage WHERE _1 > 250;";
            DataLakeQueryOptions options = new DataLakeQueryOptions
            {
                InputTextConfiguration = new DataLakeQueryArrowOptions
                {
                    Schema = new List<DataLakeQueryArrowField>()
                    {
                        new DataLakeQueryArrowField
                        {
                            Type = DataLakeQueryArrowFieldType.Decimal,
                            Name = "Name",
                            Precision = 4,
                            Scale = 2
                        }
                    }
                }
            };

            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                file.QueryAsync(
                query,
                options: options),
                e => Assert.AreEqual($"{nameof(DataLakeQueryArrowOptions)} can only be used for output serialization.", e.Message));
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_08_04)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_ParquetConfigurationInput()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());
            using FileStream stream = File.OpenRead(
                $"{System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{System.IO.Path.DirectorySeparatorChar}Resources{System.IO.Path.DirectorySeparatorChar}parquet.parquet");
            await file.UploadAsync(stream);

            // Act
            string query = @"select * from blobstorage where id < 1;";
            DataLakeQueryOptions options = new DataLakeQueryOptions
            {
                InputTextConfiguration = new DataLakeQueryParquetTextOptions()
            };
            Response<FileDownloadInfo> response = await file.QueryAsync(
                query,
                options: options);

            // Assert
            using StreamReader streamReader = new StreamReader(response.Value.Content);
            string s = await streamReader.ReadToEndAsync();

            // Assert
            Assert.AreEqual("0,mdifjt55.ea3,mdifjt55.ea3\n", s);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_08_04)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_ParquetConfigurationOutputError()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());

            // Act
            string query = @"select * from blobstorage where id < 1;";
            DataLakeQueryOptions options = new DataLakeQueryOptions
            {
                OutputTextConfiguration = new DataLakeQueryParquetTextOptions()
            };

            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                file.QueryAsync(
                    query, options),
                e => Assert.AreEqual($"{nameof(DataLakeQueryParquetTextOptions)} can only be used for input serialization.", e.Message));
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/52168")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetSetTags()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
            Dictionary<string, string> tags = BuildTags();

            // Act
            await file.SetTagsAsync(tags);
            Response<GetPathTagResult> getTagsResponse = await file.GetTagsAsync();

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
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
            Dictionary<string, string> tags = BuildTags();

            // Act
            await file.SetTagsAsync(tags);
            Response<GetPathTagResult> getTagsResponse = await file.GetTagsAsync();

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
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
            Dictionary<string, string> tags = BuildTags();

            string leaseId = Recording.Random.NewGuid().ToString();
            TimeSpan duration = TimeSpan.FromSeconds(15);
            await InstrumentClient(file.GetDataLakeLeaseClient(leaseId)).AcquireAsync(duration);

            DataLakeRequestConditions conditions = new DataLakeRequestConditions
            {
                LeaseId = leaseId
            };

            // Act
            await file.SetTagsAsync(tags, conditions);
            Response<GetPathTagResult> getTagsResponse = await file.GetTagsAsync();

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
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
            Dictionary<string, string> tags = BuildTags();

            string leaseId = Recording.Random.NewGuid().ToString();

            DataLakeRequestConditions conditions = new DataLakeRequestConditions
            {
                LeaseId = leaseId
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.GetTagsAsync(conditions),
                e => Assert.AreEqual("LeaseNotPresentWithBlobOperation", e.ErrorCode));
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/52168")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task SetTags_LeaseFailed()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
            Dictionary<string, string> tags = BuildTags();

            string leaseId = Recording.Random.NewGuid().ToString();

            DataLakeRequestConditions conditions = new DataLakeRequestConditions
            {
                LeaseId = leaseId
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.SetTagsAsync(tags, conditions),
                e => Assert.AreEqual("LeaseNotPresentWithBlobOperation", e.ErrorCode));
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/52168")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetTags_Error()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.GetTagsAsync(),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/52168")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetSetTags_FileSas()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
            Uri sasUri = file.GenerateSasUri(DataLakeSasPermissions.All, Recording.UtcNow.AddHours(1));
            file = InstrumentClient(new DataLakeFileClient(sasUri, GetOptions()));

            Dictionary<string, string> tags = BuildTags();

            // Act
            await file.SetTagsAsync(tags);
            Response<GetPathTagResult> getTagsResponse = await file.GetTagsAsync();

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
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
            Uri fileSystemSasUri = test.FileSystem.GenerateSasUri(DataLakeFileSystemSasPermissions.All, Recording.UtcNow.AddHours(1));
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(fileSystemSasUri);
            uriBuilder.DirectoryOrFilePath = file.Name;
            Uri fileSasUri = uriBuilder.ToUri();
            file = InstrumentClient(new DataLakeFileClient(fileSasUri, GetOptions()));

            Dictionary<string, string> tags = BuildTags();

            // Act
            await file.SetTagsAsync(tags);
            Response<GetPathTagResult> getTagsResponse = await file.GetTagsAsync();

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
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(TestConfigHierarchicalNamespace.AccountName, TestConfigHierarchicalNamespace.AccountKey);
            SasQueryParameters sasQueryParameters = DataLakeClientBuilder.GetNewAccountSas(AccountSasResourceTypes.All, AccountSasPermissions.All, sharedKeyCredential);
            file = InstrumentClient(new DataLakeFileClient(new Uri($"{file.Uri}?{sasQueryParameters}"), GetOptions()));

            Dictionary<string, string> tags = BuildTags();

            // Act
            await file.SetTagsAsync(tags);
            Response<GetPathTagResult> getTagsResponse = await file.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, getTagsResponse.Value.Tags);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/52168")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetSetTags_FileIdentitySas()
        {
            // Arrange
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            await using DisposingFileSystem test = await GetNewFileSystem(oauthService);
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));

            Uri sasUri = file.GenerateUserDelegationSasUri(DataLakeSasPermissions.All, Recording.UtcNow.AddHours(1), userDelegationKey);
            file = InstrumentClient(new DataLakeFileClient(sasUri, GetOptions()));

            Dictionary<string, string> tags = BuildTags();

            // Act
            await file.SetTagsAsync(tags);
            Response<GetPathTagResult> getTagsResponse = await file.GetTagsAsync();

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
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));

            Uri fileSystemSasUri = test.FileSystem.GenerateUserDelegationSasUri(DataLakeFileSystemSasPermissions.All, Recording.UtcNow.AddHours(1), userDelegationKey);
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(fileSystemSasUri);
            uriBuilder.DirectoryOrFilePath = file.Name;
            Uri fileSasUri = uriBuilder.ToUri();
            file = InstrumentClient(new DataLakeFileClient(fileSasUri, GetOptions()));

            Dictionary<string, string> tags = BuildTags();

            // Act
            await file.SetTagsAsync(tags);
            Response<GetPathTagResult> getTagsResponse = await file.GetTagsAsync();

            // Assert
            AssertDictionaryEquality(tags, getTagsResponse.Value.Tags);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/52168")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task SetTags_Error()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            Dictionary<string, string> tags = BuildTags();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.SetTagsAsync(tags),
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
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    file.GetTagsAsync(
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
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                Dictionary<string, string> tags = BuildTags();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    file.SetTagsAsync(
                        tags: tags,
                        conditions: conditions),
                    e => { });
            }
        }

        private Stream CreateDataStream(long size)
        {
            MemoryStream stream = new MemoryStream();
            byte[] rowData = Encoding.UTF8.GetBytes("100,200,300,400\n300,400,500,600\n");
            long blockLength = 0;
            while (blockLength < size)
            {
                stream.Write(rowData, 0, rowData.Length);
                blockLength += rowData.Length;
            }

            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }

        private class ErrorHandler
        {
            private readonly DataLakeQueryError _expectedBlobQueryError;

            public ErrorHandler(DataLakeQueryError expected)
            {
                _expectedBlobQueryError = expected;
            }

            public void Handle(DataLakeQueryError blobQueryError)
            {
                Assert.AreEqual(_expectedBlobQueryError.IsFatal, blobQueryError.IsFatal);
                Assert.AreEqual(_expectedBlobQueryError.Name, blobQueryError.Name);
                Assert.AreEqual(_expectedBlobQueryError.Description, blobQueryError.Description);
                Assert.AreEqual(_expectedBlobQueryError.Position, blobQueryError.Position);
            }
        }

        public async Task GetFileClient_FromFileSystemAsciiName()
        {
            //Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            string fileName = GetNewFileName();

            //Act
            DataLakeFileClient file = test.FileSystem.GetFileClient(fileName);
            await file.CreateAsync();

            DataLakeGetPathsOptions options = new DataLakeGetPathsOptions
            {
                Recursive = true
            };

            //Assert
            List<string> names = new List<string>();
            await foreach (PathItem pathItem in test.FileSystem.GetPathsAsync(options))
            {
                names.Add(pathItem.Name);
            }
            // Verify the file name exists in the filesystem
            Assert.AreEqual(1, names.Count);
            Assert.Contains(fileName, names);
        }

        [RecordedTest]
        public async Task GetFileClient_FromFileSystemNonAsciiName()
        {
            //Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            string fileName = GetNewNonAsciiFileName();

            //Act
            DataLakeFileClient file = test.FileSystem.GetFileClient(fileName);
            await file.CreateAsync();

            DataLakeGetPathsOptions options = new DataLakeGetPathsOptions
            {
                Recursive = true
            };

            //Assert
            List<string> names = new List<string>();
            await foreach (PathItem pathItem in test.FileSystem.GetPathsAsync(options))
            {
                names.Add(pathItem.Name);
            }
            // Verify the file name exists in the filesystem
            Assert.AreEqual(1, names.Count);
            Assert.Contains(fileName, names);
        }

        [RecordedTest]
        public async Task GetFileClient_FromDirectoryAsciiName()
        {
            //Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            string directoryName = GetNewDirectoryName();
            string fileName = GetNewFileName();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);

            // Act
            DataLakeFileClient file = directory.GetFileClient(fileName);
            await file.CreateAsync();

            DataLakeGetPathsOptions options = new DataLakeGetPathsOptions
            {
                Recursive = true
            };

            //Assert
            List<string> names = new List<string>();
            await foreach (PathItem pathItem in test.FileSystem.GetPathsAsync(options))
            {
                names.Add(pathItem.Name);
            }
            // Verify the file name exists in the filesystem
            string fullPathName = string.Join("/", directoryName, fileName);
            Assert.AreEqual(2, names.Count);
            Assert.Contains(fullPathName, names);
        }

        [RecordedTest]
        public async Task GetFileClient_FromDirectoryNonAsciiName()
        {
            //Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            string directoryName = GetNewDirectoryName();
            string fileName = GetNewNonAsciiFileName();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);

            // Act
            DataLakeFileClient file = directory.GetFileClient(fileName);
            await file.CreateAsync();

            DataLakeGetPathsOptions options = new DataLakeGetPathsOptions
            {
                Recursive = true
            };

            //Assert
            List<string> names = new List<string>();
            await foreach (PathItem pathItem in test.FileSystem.GetPathsAsync(options))
            {
                names.Add(pathItem.Name);
            }
            // Verify the file name exists in the filesystem
            string fullPathName = string.Join("/", directoryName, fileName);
            Assert.AreEqual(2, names.Count);
            Assert.Contains(fullPathName, names);
        }

        [RecordedTest]
        public async Task OpenWriteAsync_NewFile()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateAsync();

            DataLakeFileOpenWriteOptions options = new DataLakeFileOpenWriteOptions
            {
                BufferSize = Constants.KB
            };

            Stream stream = await file.OpenWriteAsync(
                overwrite: false,
                options);

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
            Response<FileDownloadInfo> result = await file.ReadAsync();
            var dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(data.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(data, dataResult.ToArray());
        }

        [RecordedTest]
        public async Task OpenWriteAsync_NewFile_WithUsing()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateAsync();

            DataLakeFileOpenWriteOptions options = new DataLakeFileOpenWriteOptions
            {
                BufferSize = Constants.KB
            };

            byte[] data = GetRandomBuffer(16 * Constants.KB);

            // Act
            using (Stream stream = await file.OpenWriteAsync(
                overwrite: false,
                options))
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
            Response<FileDownloadInfo> result = await file.ReadAsync();
            var dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(data.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(data, dataResult.ToArray());
        }

        [RecordedTest]
        public async Task OpenWriteAsync_AppendExistingFile()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));

            byte[] originalData = GetRandomBuffer(Constants.KB);
            using Stream originalStream = new MemoryStream(originalData);
            await file.UploadAsync(originalStream);

            byte[] newData = GetRandomBuffer(Constants.KB);
            using Stream newStream = new MemoryStream(newData);

            // Act
            Stream openWriteStream = await file.OpenWriteAsync(overwrite: false);
            await newStream.CopyToAsync(openWriteStream);
            await openWriteStream.FlushAsync();

            // Assert
            byte[] expectedData = new byte[2 * Constants.KB];
            Array.Copy(originalData, 0, expectedData, 0, Constants.KB);
            Array.Copy(newData, 0, expectedData, Constants.KB, Constants.KB);

            Response<FileDownloadInfo> result = await file.ReadAsync();
            MemoryStream dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(expectedData.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(expectedData, dataResult.ToArray());
        }

        [RecordedTest]
        public async Task OpenWriteAsync_AlternatingWriteAndFlush()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));

            byte[] data0 = GetRandomBuffer(512);
            byte[] data1 = GetRandomBuffer(512);
            using Stream dataStream0 = new MemoryStream(data0);
            using Stream dataStream1 = new MemoryStream(data1);
            byte[] expectedData = new byte[Constants.KB];
            Array.Copy(data0, expectedData, 512);
            Array.Copy(data1, 0, expectedData, 512, 512);

            // Act
            Stream writeStream = await file.OpenWriteAsync(
                overwrite: false);
            await dataStream0.CopyToAsync(writeStream);
            await writeStream.FlushAsync();
            await dataStream1.CopyToAsync(writeStream);
            await writeStream.FlushAsync();

            // Assert
            Response<FileDownloadInfo> result = await file.ReadAsync();
            MemoryStream dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(expectedData.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(expectedData, dataResult.ToArray());
        }

        [RecordedTest]
        public async Task OpenWriteAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.OpenWriteAsync(overwrite: false),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [RecordedTest]
        public async Task OpenWriteAsync_ModifiedDuringWrite()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateAsync();

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);

            // Act
            Stream openWriteStream = await file.OpenWriteAsync(overwrite: false);

            await stream.CopyToAsync(openWriteStream);
            await openWriteStream.FlushAsync();
            stream.Position = 0;

            await file.AppendAsync(stream, offset: Constants.KB);
            await file.FlushAsync(2 * Constants.KB);

            await stream.CopyToAsync(openWriteStream);
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                openWriteStream.FlushAsync(),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [RecordedTest]
        public async Task OpenWriteAsync_ProgressReporting()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateAsync();

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);

            TestProgress progress = new TestProgress();
            DataLakeFileOpenWriteOptions options = new DataLakeFileOpenWriteOptions
            {
                ProgressHandler = progress,
                BufferSize = 256
            };

            // Act
            Stream openWriteStream = await file.OpenWriteAsync(
                overwrite: false,
                options);
            await stream.CopyToAsync(openWriteStream);
            await openWriteStream.FlushAsync();

            // Assert
            Assert.IsTrue(progress.List.Count > 0);
            Assert.AreEqual(Constants.KB, progress.List[progress.List.Count - 1]);
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task OpenWriteAsync_Overwite(bool fileExists)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            if (fileExists)
            {
                await file.CreateAsync();
            }

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);

            // Act
            Stream openWriteStream = await file.OpenWriteAsync(
                overwrite: true);
            await stream.CopyToAsync(openWriteStream);
            await openWriteStream.FlushAsync();

            // Assert
            Response<FileDownloadInfo> result = await file.ReadAsync();
            var dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(data.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(data, dataResult.ToArray());
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task OpenWriteAsync_AccessConditions(bool overwrite)
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                // Arrange
                await using DisposingFileSystem test = await GetNewFileSystem();
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(file, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                byte[] data = GetRandomBuffer(Constants.KB);
                using Stream stream = new MemoryStream(data);

                DataLakeFileOpenWriteOptions options = new DataLakeFileOpenWriteOptions
                {
                    OpenConditions = conditions
                };

                // Act
                Stream openWriteStream = await file.OpenWriteAsync(
                    overwrite: overwrite,
                    options);
                await stream.CopyToAsync(openWriteStream);
                await openWriteStream.FlushAsync();

                // Assert
                Response<FileDownloadInfo> result = await file.ReadAsync();
                MemoryStream dataResult = new MemoryStream();
                await result.Value.Content.CopyToAsync(dataResult);
                Assert.AreEqual(data.Length, dataResult.Length);
                TestHelper.AssertSequenceEqual(data, dataResult.ToArray());
            }
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task OpenWriteAsync_AccessConditionsFail(bool overwrite)
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                // Arrange
                await using DisposingFileSystem test = await GetNewFileSystem();
                DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

                parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                DataLakeFileOpenWriteOptions options = new DataLakeFileOpenWriteOptions
                {
                    OpenConditions = conditions
                };

                byte[] data = GetRandomBuffer(Constants.KB);
                using Stream stream = new MemoryStream(data);

                // Assert
                await TestHelper.CatchAsync<Exception>(
                    async () =>
                    {
                        await file.OpenWriteAsync(
                            overwrite: overwrite,
                            options);
                    });
            }
        }

        [RecordedTest]
        public async Task OpenWriteAsync_Close()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateAsync();

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);

            DataLakeFileOpenWriteOptions options = new DataLakeFileOpenWriteOptions
            {
                Close = true,
                BufferSize = 256
            };

            // Act
            Stream openWriteStream = await file.OpenWriteAsync(
                overwrite: false,
                options);
            await stream.CopyToAsync(openWriteStream);
            await openWriteStream.FlushAsync();
        }

        #region GenerateSasTests
        [RecordedTest]
        public void CanGenerateSas_ClientConstructors()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);

            // Act - DataLakeFileClient(Uri blobContainerUri, fileClientOptions options = default)
            DataLakeFileClient file = InstrumentClient(new DataLakeFileClient(
                blobEndpoint,
                GetOptions()));
            Assert.IsFalse(file.CanGenerateSasUri);

            // Act - DataLakeFileClient(Uri blobContainerUri, StorageSharedKeyCredential credential, fileClientOptions options = default)
            DataLakeFileClient file2 = InstrumentClient(new DataLakeFileClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            Assert.IsTrue(file2.CanGenerateSasUri);

            // Act - DataLakeFileClient(Uri blobContainerUri, TokenCredential credential, fileClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            DataLakeFileClient file3 = InstrumentClient(new DataLakeFileClient(
                blobEndpoint,
                tokenCredentials,
                GetOptions()));
            Assert.IsFalse(file3.CanGenerateSasUri);
        }

        [RecordedTest]
        public void CanGenerateSas_Mockable()
        {
            // Act
            var file = new Mock<DataLakeFileClient>();
            file.Setup(x => x.CanGenerateSasUri).Returns(false);

            // Assert
            Assert.IsFalse(file.Object.CanGenerateSasUri);

            // Act
            file.Setup(x => x.CanGenerateSasUri).Returns(true);

            // Assert
            Assert.IsTrue(file.Object.CanGenerateSasUri);
        }

        [RecordedTest]
        public void GenerateSas_RequiredParameters()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(
                dataLakeUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            // Act
            Uri sasUri = fileClient.GenerateSasUri(permissions, expiresOn);

            // Assert
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path
            };
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path,
                Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
        }

        [RecordedTest]
        public void GenerateSas_Builder()
        {
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(
                dataLakeUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path
            };

            // Act
            Uri sasUri = fileClient.GenerateSasUri(sasBuilder);

            // Assert
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
            };
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path,
                Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
        }

        [RecordedTest]
        public void GenerateSas_BuilderNullFileSystemName()
        {
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(
                dataLakeUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = null,
                Path = path
            };

            // Act
            Uri sasUri = fileClient.GenerateSasUri(sasBuilder);

            // Assert
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
            };
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path,
                Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
        }

        [RecordedTest]
        public void GenerateSas_BuilderWrongFileSystemName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(
                dataLakeUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = GetNewFileSystemName(), // different filesystem name
                Path = path,
            };

            // Act
            TestHelper.AssertExpectedException(
                () => fileClient.GenerateSasUri(sasBuilder),
                new InvalidOperationException("SAS Uri cannot be generated. DataLakeSasBuilder.FileSystemName does not match FileSystemName in the Client. DataLakeSasBuilder.FileSystemName must either be left empty or match the FileSystemName in the Client"));
        }

        [RecordedTest]
        public void GenerateSas_BuilderNullFileName()
        {
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(
                dataLakeUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = null
            };

            // Act
            Uri sasUri = fileClient.GenerateSasUri(sasBuilder);

            // Assert
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
            };
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path,
                Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
        }

        [RecordedTest]
        public void GenerateSas_BuilderWrongFileName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(
                dataLakeUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = GetNewFileName(), // different path
            };

            // Act
            TestHelper.AssertExpectedException(
                () => fileClient.GenerateSasUri(sasBuilder),
                new InvalidOperationException("SAS Uri cannot be generated. DataLakeSasBuilder.Path does not match Path in the Client. DataLakeSasBuilder.Path must either be left empty or match the Path in the Client"));
        }

        [RecordedTest]
        public void GenerateSas_BuilderIsDirectoryError()
        {
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string fileName = GetNewFileName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = fileName
            };
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);

            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(
                dataLakeUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = GetNewFileName(),
                IsDirectory = true,
                IPRange = new SasIPRange(System.Net.IPAddress.None, System.Net.IPAddress.None),
                ExpiresOn = Recording.UtcNow.AddHours(+1)
            };

            // Act
            TestHelper.AssertExpectedException(
                () => fileClient.GenerateSasUri(sasBuilder),
                new InvalidOperationException("SAS Uri cannot be generated. Expected builder.IsDirectory to be set to false to generate the respective SAS for the client, GetType"));
        }
        #endregion

        #region GenerateUserDelegationSasTests
        [RecordedTest]
        public async Task GenerateUserDelegationSas_RequiredParameters()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = fileClient.GenerateUserDelegationSasUri(permissions, expiresOn, userDelegationKey);

            // Assert
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path
            };
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path,
                Sas = sasBuilder2.ToSasQueryParameters(userDelegationKey, fileClient.AccountName)
            };
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_Builder()
        {
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path
            };

            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = fileClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey);

            // Assert
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
            };
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path,
                Sas = sasBuilder2.ToSasQueryParameters(userDelegationKey, fileClient.AccountName)
            };
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderNull()
        {
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            TestHelper.AssertExpectedException(
                () => fileClient.GenerateUserDelegationSasUri(null, userDelegationKey),
                 new ArgumentNullException("builder"));
        }

        [RecordedTest]
        public void GenerateUserDelegationSas_UserDelegationKeyNull()
        {
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path
            };

            // Act
            TestHelper.AssertExpectedException(
                () => fileClient.GenerateUserDelegationSasUri(sasBuilder, null),
                 new ArgumentNullException("userDelegationKey"));
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderNullFileSystemName()
        {
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = null,
                Path = path
            };

            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = fileClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey);

            // Assert
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
            };
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path,
                Sas = sasBuilder2.ToSasQueryParameters(userDelegationKey, fileClient.AccountName)
            };
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderWrongFileSystemName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = GetNewFileSystemName(), // different filesystem name
                Path = path,
            };

            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            TestHelper.AssertExpectedException(
                () => fileClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey),
                new InvalidOperationException("SAS Uri cannot be generated. DataLakeSasBuilder.FileSystemName does not match FileSystemName in the Client. DataLakeSasBuilder.FileSystemName must either be left empty or match the FileSystemName in the Client"));
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderNullFileName()
        {
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = null
            };

            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = fileClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey);

            // Assert
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
            };
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path,
                Sas = sasBuilder2.ToSasQueryParameters(userDelegationKey, fileClient.AccountName)
            };
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderWrongFileName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = GetNewFileName(), // different path
            };

            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            TestHelper.AssertExpectedException(
                () => fileClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey),
                new InvalidOperationException("SAS Uri cannot be generated. DataLakeSasBuilder.Path does not match Path in the Client. DataLakeSasBuilder.Path must either be left empty or match the Path in the Client"));
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderNullIsDirectory()
        {
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path
            };
            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                IsDirectory = null
            };

            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = fileClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey);

            // Assert
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                IsDirectory = false
            };
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = path,
                Sas = sasBuilder2.ToSasQueryParameters(userDelegationKey, fileClient.AccountName)
            };
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderIsDirectoryError()
        {
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string fileName = GetNewFileName();
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                DirectoryOrFilePath = fileName
            };
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);

            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = GetNewFileName(),
                IsDirectory = true,
                IPRange = new SasIPRange(System.Net.IPAddress.None, System.Net.IPAddress.None),
                ExpiresOn = Recording.UtcNow.AddHours(+1)
            };

            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            TestHelper.AssertExpectedException(
                () => fileClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey),
                new InvalidOperationException("SAS Uri cannot be generated. Expected builder.IsDirectory to be set to false to generate the respective SAS for the client, GetType"));
        }
        #endregion

        [RecordedTest]
        public void CanMockClientConstructors()
        {
            // One has to call .Object to trigger constructor. It's lazy.
            var mock = new Mock<DataLakeFileClient>(TestConfigDefault.ConnectionString, "name", "name", new DataLakeClientOptions()).Object;
            mock = new Mock<DataLakeFileClient>(TestConfigDefault.ConnectionString, "name", "name").Object;
            mock = new Mock<DataLakeFileClient>(new Uri("https://test/test"), new DataLakeClientOptions()).Object;
            mock = new Mock<DataLakeFileClient>(new Uri("https://test/test"), Tenants.GetNewHnsSharedKeyCredentials(), new DataLakeClientOptions()).Object;
            mock = new Mock<DataLakeFileClient>(new Uri("https://test/test"), new AzureSasCredential("foo"), new DataLakeClientOptions()).Object;
            mock = new Mock<DataLakeFileClient>(new Uri("https://test/test"), TestEnvironment.Credential, new DataLakeClientOptions()).Object;
        }
    }
}
