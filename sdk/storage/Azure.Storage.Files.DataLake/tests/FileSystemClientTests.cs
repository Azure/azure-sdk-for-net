// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class FileSystemClientTests : DataLakeTestBase
    {
        public FileSystemClientTests(bool async, DataLakeClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public async Task Ctor_Uri()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            string fileSystemName = GetNewFileSystemName();
            await service.CreateFileSystemAsync(fileSystemName);

            try
            {
                SasQueryParameters sasQueryParameters = GetNewAccountSasCredentials();
                Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}?{sasQueryParameters}");
                DataLakeFileSystemClient fileSystemClient = InstrumentClient(new DataLakeFileSystemClient(uri, GetOptions()));

                // Act
                await fileSystemClient.GetPropertiesAsync();

                // Assert
                Assert.AreEqual(fileSystemName, fileSystemClient.Name);
                Assert.AreEqual(uri, fileSystemClient.Uri);
            }
            finally
            {
                await service.DeleteFileSystemAsync(fileSystemName);
            }
        }

        [Test]
        public async Task Ctor_SharedKey()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            string fileSystemName = GetNewFileSystemName();
            await service.CreateFileSystemAsync(fileSystemName);

            try
            {
                StorageSharedKeyCredential sharedKey = new StorageSharedKeyCredential(
                    TestConfigHierarchicalNamespace.AccountName,
                    TestConfigHierarchicalNamespace.AccountKey);
                Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}");
                DataLakeFileSystemClient fileSystemClient = InstrumentClient(new DataLakeFileSystemClient(uri, sharedKey, GetOptions()));

                // Act
                await fileSystemClient.GetPropertiesAsync();

                // Assert
                Assert.AreEqual(fileSystemName, fileSystemClient.Name);
                Assert.AreEqual(uri, fileSystemClient.Uri);
            }
            finally
            {
                await service.DeleteFileSystemAsync(fileSystemName);
            }
        }

        [Test]
        public async Task Ctor_TokenCredential()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            string fileSystemName = GetNewFileSystemName();
            await service.CreateFileSystemAsync(fileSystemName);

            try
            {
                TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
                Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}").ToHttps();
                DataLakeFileSystemClient fileSystemClient = InstrumentClient(new DataLakeFileSystemClient(uri, tokenCredential, GetOptions()));

                // Act
                await fileSystemClient.GetPropertiesAsync();
            }
            finally
            {
                await service.DeleteFileSystemAsync(fileSystemName);
            }
        }

        [Test]
        public async Task Ctor_ConnectionString_RoundTrip()
        {
            // Arrage
            string connectionString = $"DefaultEndpointsProtocol=https;AccountName={TestConfigHierarchicalNamespace.AccountName};AccountKey={TestConfigHierarchicalNamespace.AccountKey};EndpointSuffix=core.windows.net";
            DataLakeFileSystemClient fileSystem = InstrumentClient(new DataLakeFileSystemClient(connectionString, GetNewFileSystemName(), GetOptions()));

            // Act
            try
            {
                await fileSystem.CreateAsync();
                DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(GetNewDirectoryName()));
                await directory.CreateAsync();

                IList<PathItem> paths = await fileSystem.GetPathsAsync().ToListAsync();

                // Assert
                Assert.AreEqual(1, paths.Count);
            }

            // Cleanup
            finally
            {
                await fileSystem.DeleteAsync();
            }
        }

        [Test]
        public async Task Ctor_ConnectionString_GenerateSas()
        {
            // Arrage
            string connectionString = $"DefaultEndpointsProtocol=https;AccountName={TestConfigHierarchicalNamespace.AccountName};AccountKey={TestConfigHierarchicalNamespace.AccountKey};EndpointSuffix=core.windows.net";
            DataLakeFileSystemClient fileSystem = InstrumentClient(new DataLakeFileSystemClient(connectionString, GetNewFileSystemName(), GetOptions()));

            // Act
            try
            {
                await fileSystem.CreateAsync();
                Uri sasUri = fileSystem.GenerateSasUri(
                    DataLakeFileSystemSasPermissions.All,
                    Recording.UtcNow.AddDays(1));

                DataLakeFileSystemClient sasFileSystem = InstrumentClient(new DataLakeFileSystemClient(sasUri, GetOptions()));

                DataLakeDirectoryClient directory = InstrumentClient(sasFileSystem.GetDirectoryClient(GetNewDirectoryName()));
                await directory.CreateAsync();

                IList<PathItem> paths = await sasFileSystem.GetPathsAsync().ToListAsync();

                // Assert
                Assert.AreEqual(1, paths.Count);
            }

            // Cleanup
            finally
            {
                await fileSystem.DeleteAsync();
            }
        }

        [Test]
        public void Ctor_TokenCredential_Http()
        {
            // Arrange
            TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
            Uri uri = new Uri(TestConfigHierarchicalNamespace.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new DataLakeFileSystemClient(uri, tokenCredential),
                new ArgumentException("Cannot use TokenCredential without HTTPS."));

            TestHelper.AssertExpectedException(
                () => new DataLakeFileSystemClient(uri, tokenCredential, new DataLakeClientOptions()),
                new ArgumentException("Cannot use TokenCredential without HTTPS."));
        }

        [Test]
        public async Task Ctor_AzureSasCredential()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials().ToString();
            await using DisposingFileSystem test = await GetNewFileSystem();
            Uri uri = test.FileSystem.Uri;

            // Act
            var sasClient = InstrumentClient(new DataLakeFileSystemClient(uri, new AzureSasCredential(sas), GetOptions()));
            FileSystemProperties properties = await sasClient.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(properties);
        }

        [Test]
        public async Task Ctor_AzureSasCredential_VerifyNoSasInUri()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials().ToString();
            await using DisposingFileSystem test = await GetNewFileSystem();
            Uri uri = test.FileSystem.Uri;
            uri = new Uri(uri.ToString() + "?" + sas);

            // Act
            TestHelper.AssertExpectedException<ArgumentException>(
                () => new DataLakeFileSystemClient(uri, new AzureSasCredential(sas)),
                e => e.Message.Contains($"You cannot use {nameof(AzureSasCredential)} when the resource URI also contains a Shared Access Signature"));
        }

        [Test]
        public async Task GetFileClient()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient fileClient = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await fileClient.CreateAsync();
            DataLakeFileClient newFileClient = InstrumentClient(test.FileSystem.GetFileClient(fileClient.Name));

            // Act
            Response<PathProperties> response = await newFileClient.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.Value.ETag);
        }

        [Test]
        public async Task GetDirectoryClient()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directoryClient = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            await directoryClient.CreateAsync();
            DataLakeDirectoryClient newDirectoryClient = InstrumentClient(test.FileSystem.GetDirectoryClient(directoryClient.Name));

            // Act
            Response<PathProperties> response = await newDirectoryClient.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.Value.ETag);
        }

        [Test]
        public async Task CreateAsync()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            var fileSystemName = GetNewFileSystemName();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(fileSystemName));

            try
            {
                // Act
                Response<FileSystemInfo> response = await fileSystem.CreateAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                var accountName = new DataLakeUriBuilder(service.Uri).AccountName;
                TestHelper.AssertCacheableProperty(accountName, () => fileSystem.AccountName);
                TestHelper.AssertCacheableProperty(fileSystemName, () => fileSystem.Name);
            }
            finally
            {
                await fileSystem.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task CreateAsync_WithAccountSas()
        {
            // Arrange
            var fileSystemName = GetNewFileSystemName();
            DataLakeServiceClient service = GetServiceClient_AccountSas();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(fileSystemName));

            try
            {
                // Act
                Response<FileSystemInfo> response = await fileSystem.CreateAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
            finally
            {
                await fileSystem.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task CreateAsync_WithDataLakeServiceSas()
        {
            // Arrange
            var fileSystemName = GetNewFileSystemName();
            DataLakeServiceClient service = GetServiceClient_DataLakeServiceSas_FileSystem(fileSystemName);
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(fileSystemName));
            var pass = false;

            try
            {
                // Act
                Response<FileSystemInfo> response = await fileSystem.CreateAsync();

                Assert.Fail("CreateAsync unexpected success: blob service SAS should not be usable to create container");
            }
            catch (RequestFailedException se) when (se.ErrorCode == "AuthorizationFailure") // TODO verify if this is a missing error code
            {
                pass = true;
            }
            finally
            {
                if (!pass)
                {
                    await fileSystem.DeleteIfExistsAsync();
                }
            }
        }

        [Test]
        public async Task CreateAsync_Oauth()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_OAuth();
            var fileSystemName = GetNewFileSystemName();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(fileSystemName));

            try
            {
                // Act
                Response<FileSystemInfo> response = await fileSystem.CreateAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                var accountName = new DataLakeUriBuilder(service.Uri).AccountName;
                TestHelper.AssertCacheableProperty(accountName, () => fileSystem.AccountName);
                TestHelper.AssertCacheableProperty(fileSystemName, () => fileSystem.Name);
            }
            finally
            {
                await fileSystem.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task CreateAsync_Metadata()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await fileSystem.CreateAsync(metadata: metadata);

            // Assert
            Response<FileSystemProperties> response = await fileSystem.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);

            // Cleanup
            await fileSystem.DeleteIfExistsAsync();
        }

        [Test]
        public async Task CreateAsync_PublicAccess()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));

            // Act
            await fileSystem.CreateAsync(publicAccessType: Models.PublicAccessType.Path);

            // Assert
            Response<FileSystemProperties> response = await fileSystem.GetPropertiesAsync();
            Assert.AreEqual(Models.PublicAccessType.Path, response.Value.PublicAccess);

            // Cleanup
            await fileSystem.DeleteIfExistsAsync();
        }

        [Test]
        public async Task CreateAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            // ContainerUri is intentually created twice
            await fileSystemClient.CreateAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileSystemClient.CreateAsync(),
                e => Assert.AreEqual("ContainerAlreadyExists", e.ErrorCode));

            // Cleanup
            await fileSystemClient.DeleteIfExistsAsync();
        }

        [Test]
        public async Task CreateIfNotExistAsync_NotExists()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));

            try
            {
                // Act
                Response<FileSystemInfo> response = await fileSystemClient.CreateIfNotExistsAsync();

                // Assert
                Assert.IsNotNull(response.Value.ETag);
            }
            finally
            {
                // Cleanup
                await fileSystemClient.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task CreateIfNotExistAsync_Exists()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            try
            {
                await fileSystemClient.CreateIfNotExistsAsync();

                // Act
                Response<FileSystemInfo> response = await fileSystemClient.CreateIfNotExistsAsync();

                // Assert
                Assert.IsNull(response);
            }
            finally
            {
                // Cleanup
                await fileSystemClient.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task CreateIfNotExistsAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            DataLakeFileSystemClient unauthorizedFileSystem = InstrumentClient(new DataLakeFileSystemClient(fileSystemClient.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedFileSystem.CreateIfNotExistsAsync(),
                e => Assert.AreEqual("NoAuthenticationInformation", e.ErrorCode));
        }

        [Test]
        public async Task ExistsAsync_Exists()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Act
            Response<bool> response = await test.FileSystem.ExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);
        }

        [Test]
        public async Task ExistsAsync_NotExists()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));

            // Act
            Response<bool> response = await fileSystemClient.ExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [Test]
        public async Task ExistsAsync_Error()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem(publicAccessType: PublicAccessType.None);
            DataLakeFileSystemClient unauthorizedFileSystemClient = InstrumentClient(new DataLakeFileSystemClient(test.FileSystem.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedFileSystemClient.ExistsAsync(),
                e => Assert.AreEqual("NoAuthenticationInformation", e.ErrorCode));
        }

        [Test]
        public async Task DeleteAsync()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            await fileSystem.CreateIfNotExistsAsync();

            // Act
            Response response = await fileSystem.DeleteAsync();

            // Assert
            Assert.IsNotNull(response.Headers.RequestId);
        }

        [Test]
        public async Task DeleteAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileSystem.DeleteAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [Test]
        public async Task DeleteAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                // Arrange
                DataLakeServiceClient service = GetServiceClient_SharedKey();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateIfNotExistsAsync();
                parameters.LeaseId = await SetupFileSystemLeaseCondition(fileSystem, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: true);

                // Act
                Response response = await fileSystem.DeleteAsync(conditions: conditions);

                // Assert
                Assert.IsNotNull(response.Headers.RequestId);
            }
        }

        [Test]
        public async Task DeleteAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in ConditionsFail_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                parameters.LeaseId = await SetupFileSystemLeaseCondition(test.FileSystem, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    test.FileSystem.DeleteAsync(conditions: conditions),
                    e => { });
            }
        }

        [Test]
        public async Task DeleteIfExistsAsync_Exists()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            await fileSystemClient.CreateIfNotExistsAsync();

            // Act
            Response<bool> response = await fileSystemClient.DeleteIfExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);

            // Act
            response = await fileSystemClient.DeleteIfExistsAsync();
        }

        [Test]
        public async Task DeleteIfExistsAsync_NotExists()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));

            // Act
            Response<bool> response = await fileSystemClient.DeleteIfExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [Test]
        public async Task DeleteIfExistsAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            DataLakeFileSystemClient unauthorizedFileSystem = InstrumentClient(new DataLakeFileSystemClient(fileSystemClient.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedFileSystem.DeleteIfExistsAsync(),
                e => Assert.AreEqual("NoAuthenticationInformation", e.ErrorCode));
        }

        [Test]
        public async Task GetPathsAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            await SetUpFileSystemForListing(test.FileSystem);

            // Act
            AsyncPageable<PathItem> response = test.FileSystem.GetPathsAsync();
            IList<PathItem> paths = await response.ToListAsync();

            // Assert
            Assert.AreEqual(3, paths.Count);
            Assert.AreEqual("bar", paths[0].Name);
            Assert.AreEqual("baz", paths[1].Name);
            Assert.AreEqual("foo", paths[2].Name);
        }

        [Test]
        public async Task GetPathsAsync_Recursive()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            await SetUpFileSystemForListing(test.FileSystem);

            // Act
            AsyncPageable<PathItem> response = test.FileSystem.GetPathsAsync(
                recursive: true);
            IList<PathItem> paths = await response.ToListAsync();

            // Assert
            Assert.AreEqual(PathNames.Length, paths.Count);
            Assert.AreEqual("bar", paths[0].Name);
            Assert.AreEqual("baz", paths[1].Name);
            Assert.AreEqual("baz/bar", paths[2].Name);
            Assert.AreEqual("baz/bar/foo", paths[3].Name);
            Assert.AreEqual("baz/foo", paths[4].Name);
            Assert.AreEqual("baz/foo/bar", paths[5].Name);
            Assert.AreEqual("foo", paths[6].Name);
            Assert.AreEqual("foo/bar", paths[7].Name);
            Assert.AreEqual("foo/foo", paths[8].Name);
        }

        [Test]
        public async Task GetPathsAsync_Upn()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            await SetUpFileSystemForListing(test.FileSystem);

            // Act
            AsyncPageable<PathItem> response = test.FileSystem.GetPathsAsync(
                userPrincipalName: true);
            ;
            IList<PathItem> paths = await response.ToListAsync();

            // Assert
            Assert.AreEqual(3, paths.Count);
            Assert.IsNotNull(paths[0].Group);
            Assert.IsNotNull(paths[0].Owner);

            Assert.AreEqual("bar", paths[0].Name);
            Assert.AreEqual("baz", paths[1].Name);
            Assert.AreEqual("foo", paths[2].Name);
        }

        [Test]
        public async Task GetPathsAsync_Path()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            await SetUpFileSystemForListing(test.FileSystem);

            // Act
            AsyncPageable<PathItem> response = test.FileSystem.GetPathsAsync(
                path: "foo");
            IList<PathItem> paths = await response.ToListAsync();

            // Assert
            Assert.AreEqual(2, paths.Count);
            Assert.AreEqual("foo/bar", paths[0].Name);
            Assert.AreEqual("foo/foo", paths[1].Name);
        }

        [Test]
        [AsyncOnly]
        public async Task GetPathsAsync_MaxResults()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            await SetUpFileSystemForListing(test.FileSystem);

            // Act
            Page<PathItem> page = await test.FileSystem.GetPathsAsync().AsPages(pageSizeHint: 2).FirstAsync();

            // Assert
            Assert.AreEqual(2, page.Values.Count);
            Assert.AreEqual("bar", page.Values[0].Name);
            Assert.AreEqual("baz", page.Values[1].Name);
        }

        [Test]
        public async Task GetPathsAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = service.GetFileSystemClient(GetNewFileSystemName());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileSystem.GetPathsAsync().ToListAsync(),
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode));
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem(publicAccessType: PublicAccessType.FileSystem);

            // Act
            Response<FileSystemProperties> response = await test.FileSystem.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(PublicAccessType.FileSystem, response.Value.PublicAccess);
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileService = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileService.GetPropertiesAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [Test]
        public async Task SetMetadataAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await test.FileSystem.SetMetadataAsync(metadata);

            // Assert
            Response<FileSystemProperties> response = await test.FileSystem.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
        }

        [Test]
        public async Task SetMetadataAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient container = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                container.SetMetadataAsync(metadata),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [Test]
        public async Task SetMetadataAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                // Arrange
                DataLakeServiceClient service = GetServiceClient_SharedKey();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateIfNotExistsAsync();
                parameters.LeaseId = await SetupFileSystemLeaseCondition(fileSystem, parameters.LeaseId, garbageLeaseId);
                IDictionary<string, string> metadata = BuildMetadata();
                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: false,
                    lease: true);

                // Act
                Response<FileSystemInfo> response = await fileSystem.SetMetadataAsync(
                    metadata: metadata,
                    conditions: conditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                // Cleanup
                await fileSystem.DeleteIfExistsAsync(new DataLakeRequestConditions
                {
                    LeaseId = parameters.LeaseId
                });
            }
        }

        [Test]
        public async Task SetMetadataAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            AccessConditionParameters[] data = new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { LeaseId = garbageLeaseId }
            };
            foreach (AccessConditionParameters parameters in data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                IDictionary<string, string> metadata = BuildMetadata();
                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: false,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    test.FileSystem.SetMetadataAsync(
                        metadata: metadata,
                        conditions: conditions),
                    e => { });
            }
        }

        [Test]
        public async Task CreateFileAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Act
            string fileName = GetNewFileName();
            Response<DataLakeFileClient> response = await test.FileSystem.CreateFileAsync(fileName);

            // Assert
            Assert.AreEqual(fileName, response.Value.Name);
        }

        [Test]
        public async Task CreateFileAsync_HttpHeaders()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            PathHttpHeaders headers = new PathHttpHeaders
            {
                ContentType = ContentType,
                ContentEncoding = ContentEncoding,
                ContentLanguage = ContentLanguage,
                ContentDisposition = ContentDisposition,
                CacheControl = CacheControl
            };

            // Act
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName(), httpHeaders: headers);

            // Assert
            Response<PathProperties> response = await file.GetPropertiesAsync();
            Assert.AreEqual(ContentType, response.Value.ContentType);
            Assert.AreEqual(ContentEncoding, response.Value.ContentEncoding);
            Assert.AreEqual(ContentLanguage, response.Value.ContentLanguage);
            Assert.AreEqual(ContentDisposition, response.Value.ContentDisposition);
            Assert.AreEqual(CacheControl, response.Value.CacheControl);
        }

        [Test]
        public async Task CreateFileAsync_Metadata()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName(), metadata: metadata);

            // Assert
            Response<PathProperties> getPropertiesResponse = await file.GetPropertiesAsync();
            AssertMetadataEquality(metadata, getPropertiesResponse.Value.Metadata, isDirectory: false);
        }

        [Test]
        public async Task CreateFileAsync_PermissionAndUmask()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            string permissions = "0777";
            string umask = "0057";

            // Act
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(
                GetNewFileName(),
                permissions: permissions,
                umask: umask);

            // Assert
            Response<PathAccessControl> response = await file.GetAccessControlAsync();
            AssertPathPermissionsEquality(PathPermissions.ParseSymbolicPermissions("rwx-w----"), response.Value.Permissions);
        }

        [Test]
        public async Task CreateFileAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileSystem.CreateFileAsync(GetNewFileName()),
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode));
        }

        [Test]
        public async Task DeleteFileAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            string fileName = GetNewFileName();
            await test.FileSystem.CreateFileAsync(fileName);

            // Act
            await test.FileSystem.DeleteFileAsync(fileName);
        }

        [Test]
        public async Task DeleteFileAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileSystem.DeleteFileAsync(GetNewFileName()),
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode));
        }

        [Test]
        public async Task CreateDirectoryAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Act
            string directoryName = GetNewDirectoryName();
            Response<DataLakeDirectoryClient> response = await test.FileSystem.CreateDirectoryAsync(directoryName);

            // Assert
            Assert.AreEqual(directoryName, response.Value.Name);
        }

        [Test]
        public async Task CreateDirectoryAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = service.GetFileSystemClient(GetNewFileSystemName());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileSystem.CreateDirectoryAsync(GetNewDirectoryName()),
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode));
        }

        [Test]
        public async Task CreateDirectoryAsync_HttpHeaders()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            PathHttpHeaders headers = new PathHttpHeaders
            {
                ContentType = ContentType,
                ContentEncoding = ContentEncoding,
                ContentLanguage = ContentLanguage,
                ContentDisposition = ContentDisposition,
                CacheControl = CacheControl
            };

            // Act
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName(), httpHeaders: headers);

            // Assert
            Response<PathProperties> response = await directory.GetPropertiesAsync();
            Assert.AreEqual(ContentType, response.Value.ContentType);
            Assert.AreEqual(ContentEncoding, response.Value.ContentEncoding);
            Assert.AreEqual(ContentLanguage, response.Value.ContentLanguage);
            Assert.AreEqual(ContentDisposition, response.Value.ContentDisposition);
            Assert.AreEqual(CacheControl, response.Value.CacheControl);
        }

        [Test]
        public async Task CreateDirectoryAsync_Metadata()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName(), metadata: metadata);

            // Assert
            Response<PathProperties> getPropertiesResponse = await directory.GetPropertiesAsync();
            AssertMetadataEquality(metadata, getPropertiesResponse.Value.Metadata, isDirectory: true);
        }

        [Test]
        public async Task CreateDirectoryAsync_PermissionAndUmask()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            string permissions = "0777";
            string umask = "0057";

            // Act
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(
                GetNewDirectoryName(),
                permissions: permissions,
                umask: umask);

            // Assert
            Response<PathAccessControl> response = await directory.GetAccessControlAsync();
            AssertPathPermissionsEquality(PathPermissions.ParseSymbolicPermissions("rwx-w----"), response.Value.Permissions);
        }

        [Test]
        public async Task DeleteDirectoryAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            string directoryName = GetNewDirectoryName();
            await test.FileSystem.CreateDirectoryAsync(directoryName);

            // Act
            await test.FileSystem.DeleteDirectoryAsync(directoryName);
        }

        [Test]
        public async Task DeleteDirectoryAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = service.GetFileSystemClient(GetNewFileSystemName());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileSystem.DeleteDirectoryAsync(GetNewDirectoryName()),
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode));
        }

        [Test]
        public async Task AquireLeaseAsync()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            await fileSystem.CreateIfNotExistsAsync();
            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            // Act
            Response<DataLakeLease> response = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(duration: duration);

            // Assert
            Assert.AreEqual(id, response.Value.LeaseId);

            // Cleanup
            await fileSystem.DeleteIfExistsAsync(conditions: new DataLakeRequestConditions
            {
                LeaseId = response.Value.LeaseId
            });
        }

        [Test]
        public async Task AcquireLeaseAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(duration: duration),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [Test]
        public async Task AcquireLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                // Arrange
                DataLakeServiceClient service = GetServiceClient_SharedKey();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateIfNotExistsAsync();
                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                // Act
                Response<DataLakeLease> response = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(
                    duration: duration,
                    conditions: conditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                // cleanup
                await fileSystem.DeleteIfExistsAsync(conditions: new DataLakeRequestConditions
                {
                    LeaseId = response.Value.LeaseId
                });
            }
        }

        [Test]
        public async Task AcquireLeaseAsync_ConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_ConditionsFail_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(test.FileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(
                        duration: duration,
                        conditions: conditions),
                    e => { });
            }
        }

        [Test]
        public async Task RenewLeaseAsync()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            await fileSystem.CreateIfNotExistsAsync();

            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            Response<Models.DataLakeLease> leaseResponse = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(
                duration: duration);

            // Act
            Response<Models.DataLakeLease> renewResponse = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(leaseResponse.Value.LeaseId)).RenewAsync();

            // Assert
            Assert.IsNotNull(renewResponse.GetRawResponse().Headers.RequestId);

            // Cleanup
            await fileSystem.DeleteIfExistsAsync(conditions: new DataLakeRequestConditions
            {
                LeaseId = renewResponse.Value.LeaseId
            });
        }

        [Test]
        public async Task RenewLeaseAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).ReleaseAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [Test]
        public async Task RenewLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                // Arrange
                DataLakeServiceClient service = GetServiceClient_SharedKey();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateIfNotExistsAsync();
                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);
                DataLakeLeaseClient lease = InstrumentClient(fileSystem.GetDataLakeLeaseClient(id));
                _ = await lease.AcquireAsync(duration: duration);

                // Act
                Response<DataLakeLease> response = await lease.RenewAsync(conditions: conditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                // cleanup
                await fileSystem.DeleteIfExistsAsync(conditions: new DataLakeRequestConditions
                {
                    LeaseId = response.Value.LeaseId
                });
            }
        }

        [Test]
        public async Task RenewLeaseAsync_ConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_ConditionsFail_Data)
            {
                // Arrange
                DataLakeServiceClient service = GetServiceClient_SharedKey();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateIfNotExistsAsync();
                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                DataLakeLeaseClient lease = InstrumentClient(fileSystem.GetDataLakeLeaseClient(id));
                Response<DataLakeLease> aquireLeaseResponse = await lease.AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    lease.RenewAsync(conditions: conditions),
                    e => { });

                // cleanup
                await fileSystem.DeleteIfExistsAsync(conditions: new DataLakeRequestConditions
                {
                    LeaseId = aquireLeaseResponse.Value.LeaseId
                });
            }
        }

        [Test]
        public async Task ReleaseLeaseAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);
            Response<DataLakeLease> leaseResponse = await InstrumentClient(test.FileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(duration);

            // Act
            Response<ReleasedObjectInfo> releaseResponse = await InstrumentClient(test.FileSystem.GetDataLakeLeaseClient(leaseResponse.Value.LeaseId)).ReleaseAsync();

            // Assert
            Response<FileSystemProperties> response = await test.FileSystem.GetPropertiesAsync();

            Assert.AreEqual(DataLakeLeaseStatus.Unlocked, response.Value.LeaseStatus);
            Assert.AreEqual(DataLakeLeaseState.Available, response.Value.LeaseState);
        }

        [Test]
        public async Task ReleaseLeaseAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).ReleaseAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [Test]
        public async Task ReleaseLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                // Arrange
                await using DisposingFileSystem test = await GetNewFileSystem();

                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                DataLakeLeaseClient lease = InstrumentClient(test.FileSystem.GetDataLakeLeaseClient(id));
                Response<DataLakeLease> aquireLeaseResponse = await lease.AcquireAsync(duration: duration);

                // Act
                Response<ReleasedObjectInfo> response = await lease.ReleaseAsync(conditions: conditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task ReleaseLeaseAsync_ConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_ConditionsFail_Data)
            {
                // Arrange
                DataLakeServiceClient service = GetServiceClient_SharedKey();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateIfNotExistsAsync();
                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                DataLakeLeaseClient lease = InstrumentClient(fileSystem.GetDataLakeLeaseClient(id));
                Response<DataLakeLease> aquireLeaseResponse = await lease.AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    lease.ReleaseAsync(conditions: conditions),
                    e => { });

                // cleanup
                await fileSystem.DeleteIfExistsAsync(conditions: new DataLakeRequestConditions
                {
                    LeaseId = aquireLeaseResponse.Value.LeaseId
                });
            }
        }

        [Test]
        public async Task ChangeLeaseAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);
            Response<DataLakeLease> leaseResponse = await InstrumentClient(test.FileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(duration);
            var newId = Recording.Random.NewGuid().ToString();

            // Act
            Response<DataLakeLease> changeResponse = await InstrumentClient(test.FileSystem.GetDataLakeLeaseClient(id)).ChangeAsync(newId);

            // Assert
            Assert.AreEqual(newId, changeResponse.Value.LeaseId);

            // Cleanup
            await InstrumentClient(test.FileSystem.GetDataLakeLeaseClient(changeResponse.Value.LeaseId)).ReleaseAsync();
        }

        [Test]
        public async Task ChangeLeaseAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).ChangeAsync(id),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [Test]
        public async Task ChangeLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                // Arrange
                DataLakeServiceClient service = GetServiceClient_SharedKey();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateIfNotExistsAsync();

                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var newId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                Response<DataLakeLease> aquireLeaseResponse = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(duration: duration);

                // Act
                Response<DataLakeLease> response = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(aquireLeaseResponse.Value.LeaseId)).ChangeAsync(
                    proposedId: newId,
                    conditions: conditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                // Cleanup
                await fileSystem.DeleteIfExistsAsync(conditions: new DataLakeRequestConditions
                {
                    LeaseId = response.Value.LeaseId
                });
            }
        }

        [Test]
        public async Task ChangeLeaseAsync_ConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_ConditionsFail_Data)
            {
                // Arrange
                DataLakeServiceClient service = GetServiceClient_SharedKey();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateIfNotExistsAsync();
                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var newId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                Response<DataLakeLease> aquireLeaseResponse = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(fileSystem.GetDataLakeLeaseClient(aquireLeaseResponse.Value.LeaseId)).ChangeAsync(
                        proposedId: newId,
                        conditions: conditions),
                    e => { });

                // cleanup
                await fileSystem.DeleteIfExistsAsync(conditions: new DataLakeRequestConditions
                {
                    LeaseId = aquireLeaseResponse.Value.LeaseId
                });
            }
        }

        [Test]
        public async Task BreakLeaseAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);
            await InstrumentClient(test.FileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(duration);
            TimeSpan breakPeriod = TimeSpan.FromSeconds(0);

            // Act
            Response<DataLakeLease> breakResponse = await InstrumentClient(test.FileSystem.GetDataLakeLeaseClient()).BreakAsync(breakPeriod);

            // Assert
            Response<FileSystemProperties> response = await test.FileSystem.GetPropertiesAsync();
            Assert.AreEqual(DataLakeLeaseStatus.Unlocked, response.Value.LeaseStatus);
            Assert.AreEqual(DataLakeLeaseState.Broken, response.Value.LeaseState);
        }

        [Test]
        public async Task BreakLeaseAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(fileSystem.GetDataLakeLeaseClient()).BreakAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [Test]
        public async Task BreakLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                // Arrange
                DataLakeServiceClient service = GetServiceClient_SharedKey();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateIfNotExistsAsync();

                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                Response<DataLakeLease> aquireLeaseResponse = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(duration: duration);

                // Act
                Response<DataLakeLease> response = await InstrumentClient(fileSystem.GetDataLakeLeaseClient()).BreakAsync(
                    conditions: conditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

                // Cleanup
                await fileSystem.DeleteIfExistsAsync(conditions: new DataLakeRequestConditions
                {
                    LeaseId = aquireLeaseResponse.Value.LeaseId
                });
            }
        }

        [Test]
        public async Task BreakLeaseAsync_ConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_ConditionsFail_Data)
            {
                // Arrange
                DataLakeServiceClient service = GetServiceClient_SharedKey();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateIfNotExistsAsync();
                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                Response<DataLakeLease> aquireLeaseResponse = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(fileSystem.GetDataLakeLeaseClient()).BreakAsync(
                        conditions: conditions),
                    e => { });

                // cleanup
                await fileSystem.DeleteIfExistsAsync(conditions: new DataLakeRequestConditions
                {
                    LeaseId = aquireLeaseResponse.Value.LeaseId
                });
            }
        }

        [Test]
        public async Task GetAccesPolicyAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Act
            Response<FileSystemAccessPolicy> response = await test.FileSystem.GetAccessPolicyAsync();

            // Assert
            Assert.AreEqual(0, response.Value.SignedIdentifiers.Count());
        }

        [Test]
        public async Task GetAccessPolicyAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileSystem.GetAccessPolicyAsync(),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [Test]
        public async Task GetAccessPolicy_Lease()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            await fileSystem.CreateIfNotExistsAsync();
            string garbageLeaseId = GetGarbageLeaseId();
            string leaseId = await SetupFileSystemLeaseCondition(fileSystem, ReceivedLeaseId, garbageLeaseId);
            DataLakeRequestConditions leaseAccessConditions = new DataLakeRequestConditions
            {
                LeaseId = leaseId
            };

            // Act
            Response<FileSystemAccessPolicy> response = await fileSystem.GetAccessPolicyAsync(
                conditions: leaseAccessConditions);

            // Assert
            Assert.AreEqual(0, response.Value.SignedIdentifiers.Count());

            // Cleanup
            await fileSystem.DeleteIfExistsAsync(conditions: leaseAccessConditions);
        }

        [Test]
        public async Task GetAccessPolicy_LeaseFailed()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            string garbageLeaseId = GetGarbageLeaseId();
            DataLakeRequestConditions leaseAccessConditions = new DataLakeRequestConditions
            {
                LeaseId = garbageLeaseId
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                test.FileSystem.GetAccessPolicyAsync(conditions: leaseAccessConditions),
                e => Assert.AreEqual("LeaseNotPresentWithContainerOperation", e.ErrorCode));
        }

        [Test]
        public async Task SetAccessPolicyAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            PublicAccessType publicAccessType = PublicAccessType.FileSystem;
            DataLakeSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();

            // Act
            await test.FileSystem.SetAccessPolicyAsync(
                accessType: publicAccessType,
                permissions: signedIdentifiers
            );

            // Assert
            Response<FileSystemProperties> propertiesResponse = await test.FileSystem.GetPropertiesAsync();
            Assert.AreEqual(publicAccessType, propertiesResponse.Value.PublicAccess);

            Response<FileSystemAccessPolicy> response = await test.FileSystem.GetAccessPolicyAsync();
            Assert.AreEqual(1, response.Value.SignedIdentifiers.Count());

            DataLakeSignedIdentifier acl = response.Value.SignedIdentifiers.First();
            Assert.AreEqual(signedIdentifiers[0].Id, acl.Id);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyStartsOn, acl.AccessPolicy.PolicyStartsOn);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyExpiresOn, acl.AccessPolicy.PolicyExpiresOn);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.Permissions, acl.AccessPolicy.Permissions);
        }

        [Test]
        public async Task SetAccessPolicy_PublicAccessPolicy()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            PublicAccessType publicAccessType = PublicAccessType.FileSystem;

            // Act
            await test.FileSystem.SetAccessPolicyAsync(accessType: publicAccessType);

            // Assert
            DataLakeFileSystemClient publicAccessFileSystemClient
                = InstrumentClient(new DataLakeFileSystemClient(new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{test.FileSystem.Name}"), GetOptions()));
            Response<FileSystemProperties> propertiesResponse = await publicAccessFileSystemClient.GetPropertiesAsync();

            Assert.IsNotNull(propertiesResponse.Value.ETag);
        }

        [Test]
        public async Task SetAccessPolicy_SignedIdentifiers()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();

            // Act
            await test.FileSystem.SetAccessPolicyAsync(permissions: signedIdentifiers);

            // Assert
            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder()
            {
                FileSystemName = test.FileSystem.Name,
                Identifier = signedIdentifiers[0].Id
            };
            DataLakeSasQueryParameters sasQueryParameters = sasBuilder.ToSasQueryParameters(GetNewSharedKeyCredentials());

            DataLakeFileSystemClient sasFileSystem
                = InstrumentClient(new DataLakeFileSystemClient(
                    new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{test.FileSystem.Name}?{sasQueryParameters}"), GetOptions()));
            await sasFileSystem.CreateDirectoryAsync(GetNewDirectoryName());
        }

        [Test]
        public async Task SetAccessPolicyAsync_OldProperties()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange and Act
            DataLakeSignedIdentifier[] signedIdentifiers = new[]
            {
                new DataLakeSignedIdentifier
                {
                    Id = GetNewString(),
                    // Create an AccessPolicy with only StartsOn (old property)
                    AccessPolicy = new DataLakeAccessPolicy
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
            Response<FileSystemInfo> response = await test.FileSystem.SetAccessPolicyAsync(permissions: signedIdentifiers);

            // Assert
            Response<FileSystemAccessPolicy> responseAfter = await test.FileSystem.GetAccessPolicyAsync();
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            DataLakeSignedIdentifier signedIdentifierResponse = responseAfter.Value.SignedIdentifiers.First();
            Assert.AreEqual(1, responseAfter.Value.SignedIdentifiers.Count());
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
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeSignedIdentifier[] signedIdentifiers = new[]
            {
                new DataLakeSignedIdentifier
                {
                    Id = GetNewString(),
                    AccessPolicy = new DataLakeAccessPolicy
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
            Response<FileSystemInfo> response = await test.FileSystem.SetAccessPolicyAsync(permissions: signedIdentifiers);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

            Response<FileSystemAccessPolicy> responseAfter = await test.FileSystem.GetAccessPolicyAsync();
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            DataLakeSignedIdentifier signedIdentifierResponse = responseAfter.Value.SignedIdentifiers.First();
            Assert.AreEqual(1, responseAfter.Value.SignedIdentifiers.Count());
            Assert.AreEqual(signedIdentifiers[0].Id, signedIdentifierResponse.Id);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyStartsOn, signedIdentifierResponse.AccessPolicy.PolicyStartsOn);
            Assert.AreEqual(signedIdentifierResponse.AccessPolicy.PolicyStartsOn, signedIdentifierResponse.AccessPolicy.StartsOn);
            Assert.IsNull(signedIdentifierResponse.AccessPolicy.PolicyExpiresOn);
            Assert.AreEqual(signedIdentifierResponse.AccessPolicy.Permissions, signedIdentifiers[0].AccessPolicy.Permissions);
        }

        [Test]
        public async Task SetAccessPolicyAsync_StartsExpiresProperties()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeSignedIdentifier[] signedIdentifiers = new[]
            {
                new DataLakeSignedIdentifier
                {
                    Id = GetNewString(),
                    AccessPolicy = new DataLakeAccessPolicy
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
            Response<FileSystemInfo> response = await test.FileSystem.SetAccessPolicyAsync(permissions: signedIdentifiers);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);

            Response<FileSystemAccessPolicy> responseAfter = await test.FileSystem.GetAccessPolicyAsync();
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            DataLakeSignedIdentifier signedIdentifierResponse = responseAfter.Value.SignedIdentifiers.First();
            Assert.AreEqual(1, responseAfter.Value.SignedIdentifiers.Count());
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
            PublicAccessType publicAccessType = PublicAccessType.FileSystem;
            DataLakeSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileSystem.SetAccessPolicyAsync(
                    accessType: publicAccessType,
                    permissions: signedIdentifiers),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [Test]
        public async Task SetAccessPolicyAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                // Arrange
                PublicAccessType publicAccessType = PublicAccessType.FileSystem;
                DataLakeSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();
                DataLakeServiceClient service = GetServiceClient_SharedKey();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateIfNotExistsAsync();

                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                // Act
                Response<FileSystemInfo> response = await fileSystem.SetAccessPolicyAsync(
                    accessType: publicAccessType,
                    permissions: signedIdentifiers,
                    conditions: conditions);

                // Assert
                Assert.IsNotNull(response.Value.ETag);
            }
        }

        [Test]
        public async Task SetAccessPolicyAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in ConditionsFail_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                PublicAccessType publicAccessType = PublicAccessType.FileSystem;
                DataLakeSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();
                parameters.LeaseId = await SetupFileSystemLeaseCondition(test.FileSystem, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    test.FileSystem.SetAccessPolicyAsync(
                        accessType: publicAccessType,
                        permissions: signedIdentifiers,
                        conditions: conditions),
                    e => { });
            }
        }

        [Test]
        public async Task SetAccessPolicyAsync_InvalidPermissionOrder()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            PublicAccessType publicAccessType = PublicAccessType.FileSystem;
            DataLakeSignedIdentifier[] signedIdentifiers = new[]
            {
                new DataLakeSignedIdentifier
                {
                    Id = GetNewString(),
                    AccessPolicy = new DataLakeAccessPolicy()
                    {
                        PolicyStartsOn = Recording.UtcNow.AddHours(-1),
                        PolicyExpiresOn = Recording.UtcNow.AddHours(1),
                        Permissions = "wrld"
                    }
                }
            };

            // Act
            await test.FileSystem.SetAccessPolicyAsync(
                accessType: publicAccessType,
                permissions: signedIdentifiers
            );

            // Assert
            Response<FileSystemProperties> propertiesResponse = await test.FileSystem.GetPropertiesAsync();
            Assert.AreEqual(publicAccessType, propertiesResponse.Value.PublicAccess);

            Response<FileSystemAccessPolicy> response = await test.FileSystem.GetAccessPolicyAsync();
            Assert.AreEqual(1, response.Value.SignedIdentifiers.Count());

            DataLakeSignedIdentifier acl = response.Value.SignedIdentifiers.First();
            Assert.AreEqual(signedIdentifiers[0].Id, acl.Id);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyStartsOn, acl.AccessPolicy.PolicyStartsOn);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.PolicyExpiresOn, acl.AccessPolicy.PolicyExpiresOn);
            Assert.AreEqual("rwdl", acl.AccessPolicy.Permissions);
        }

        [Test]
        public void DataLakeAccessPolicyNullStartsOnExpiresOnTest()
        {
            DataLakeAccessPolicy accessPolicy = new DataLakeAccessPolicy()
            {
                Permissions = "rw"
            };

            Assert.AreEqual(new DateTimeOffset(), accessPolicy.StartsOn);
            Assert.AreEqual(new DateTimeOffset(), accessPolicy.ExpiresOn);
        }

        [Test]
        [TestCase("!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("%21%27%28%29%3B%5B%5D%40%26%25%3D%2B%24%2C%23äÄöÖüÜß%3B")]
        [TestCase("my cool directory")]
        [TestCase("directory")]
        public async Task GetDirectoryClient_SpecialCharacters(string directoryName)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(directoryName));
            Uri blobUri = new Uri($"https://{test.FileSystem.AccountName}.blob.core.windows.net/{test.FileSystem.Name}/{Uri.EscapeDataString(directoryName)}");
            Uri dfsUri = new Uri($"https://{test.FileSystem.AccountName}.dfs.core.windows.net/{test.FileSystem.Name}/{Uri.EscapeDataString(directoryName)}");

            // Act
            Response<PathInfo> createResponse = await directory.CreateAsync();

            List<PathItem> pathItems = new List<PathItem>();
            await foreach (PathItem pathItem in test.FileSystem.GetPathsAsync())
            {
                pathItems.Add(pathItem);
            }

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(directory.Uri);

            // Assert
            Assert.AreEqual(directoryName, pathItems[0].Name);
            Assert.AreEqual(directoryName, directory.Name);
            Assert.AreEqual(directoryName, directory.Path);

            Assert.AreEqual(blobUri, directory.Uri);
            Assert.AreEqual(blobUri, directory.BlobUri);
            Assert.AreEqual(dfsUri, directory.DfsUri);

            Assert.AreEqual(directoryName, dataLakeUriBuilder.LastDirectoryOrFileName);
            Assert.AreEqual(directoryName, dataLakeUriBuilder.DirectoryOrFilePath);
            Assert.AreEqual(blobUri, dataLakeUriBuilder.ToUri());
        }

        [Test]
        [TestCase("!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("%21%27%28%29%3B%5B%5D%40%26%25%3D%2B%24%2C%23äÄöÖüÜß%3B")]
        [TestCase("my cool file")]
        [TestCase("file")]
        public async Task GetFileClient_SpecialCharacters(string fileName)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(fileName));
            Uri blobUri = new Uri($"https://{test.FileSystem.AccountName}.blob.core.windows.net/{test.FileSystem.Name}/{Uri.EscapeDataString(fileName)}");
            Uri dfsUri = new Uri($"https://{test.FileSystem.AccountName}.dfs.core.windows.net/{test.FileSystem.Name}/{Uri.EscapeDataString(fileName)}");

            // Act
            Response<PathInfo> createResponse = await file.CreateAsync();

            List<PathItem> pathItems = new List<PathItem>();
            await foreach (PathItem pathItem in test.FileSystem.GetPathsAsync())
            {
                pathItems.Add(pathItem);
            }

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(file.Uri);

            // Assert
            Assert.AreEqual(fileName, pathItems[0].Name);
            Assert.AreEqual(fileName, file.Name);
            Assert.AreEqual(fileName, file.Path);

            Assert.AreEqual(blobUri, file.Uri);
            Assert.AreEqual(blobUri, file.BlobUri);
            Assert.AreEqual(dfsUri, file.DfsUri);

            Assert.AreEqual(fileName, dataLakeUriBuilder.LastDirectoryOrFileName);
            Assert.AreEqual(fileName, dataLakeUriBuilder.DirectoryOrFilePath);
            Assert.AreEqual(blobUri, dataLakeUriBuilder.ToUri());
        }

        #region GenerateSasTests
        [Test]
        public void CanGenerateSas_ClientConstructors()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Act - DataLakeFileSystemClient(Uri blobContainerUri, BlobClientOptions options = default)
            DataLakeFileSystemClient filesystem = InstrumentClient(new DataLakeFileSystemClient(
                blobEndpoint,
                GetOptions()));
            Assert.IsFalse(filesystem.CanGenerateSasUri);

            // Act - DataLakeFileSystemClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            DataLakeFileSystemClient filesystem2 = InstrumentClient(new DataLakeFileSystemClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            Assert.IsTrue(filesystem2.CanGenerateSasUri);

            // Act - DataLakeFileSystemClient(Uri blobContainerUri, TokenCredential credential, BlobClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            DataLakeFileSystemClient filesystem3 = InstrumentClient(new DataLakeFileSystemClient(
                blobEndpoint,
                tokenCredentials,
                GetOptions()));
            Assert.IsFalse(filesystem3.CanGenerateSasUri);
        }

        [Test]
        public void CanGenerateSas_GetFileClient()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Act - DataLakeFileSystemClient(Uri blobContainerUri, BlobClientOptions options = default)
            DataLakeFileSystemClient filesystem = InstrumentClient(new DataLakeFileSystemClient(
                blobEndpoint,
                GetOptions()));
            DataLakeFileClient file = filesystem.GetFileClient(GetNewFileName());
            Assert.IsFalse(file.CanGenerateSasUri);

            // Act - DataLakeFileSystemClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            DataLakeFileSystemClient filesystem2 = InstrumentClient(new DataLakeFileSystemClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            DataLakeFileClient file2 = filesystem2.GetFileClient(GetNewFileName());
            Assert.IsTrue(file2.CanGenerateSasUri);

            // Act - DataLakeFileSystemClient(Uri blobContainerUri, TokenCredential credential, BlobClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            DataLakeFileSystemClient filesystem3 = InstrumentClient(new DataLakeFileSystemClient(
                blobEndpoint,
                tokenCredentials,
                GetOptions()));
            DataLakeFileClient file3 = filesystem3.GetFileClient(GetNewFileName());
            Assert.IsFalse(file3.CanGenerateSasUri);
        }

        [Test]
        public void CanGenerateSas_GetDirectoryClient()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Act - DataLakeFileSystemClient(Uri blobContainerUri, BlobClientOptions options = default)
            DataLakeFileSystemClient filesystem = InstrumentClient(new DataLakeFileSystemClient(
                blobEndpoint,
                GetOptions()));
            DataLakeDirectoryClient directory = filesystem.GetDirectoryClient(GetNewDirectoryName());
            Assert.IsFalse(directory.CanGenerateSasUri);

            // Act - DataLakeFileSystemClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            DataLakeFileSystemClient filesystem2 = InstrumentClient(new DataLakeFileSystemClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            DataLakeDirectoryClient directory2 = filesystem2.GetDirectoryClient(GetNewDirectoryName());
            Assert.IsTrue(directory2.CanGenerateSasUri);

            // Act - DataLakeFileSystemClient(Uri blobContainerUri, TokenCredential credential, BlobClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            DataLakeFileSystemClient filesystem3 = InstrumentClient(new DataLakeFileSystemClient(
                blobEndpoint,
                tokenCredentials,
                GetOptions()));
            DataLakeDirectoryClient directory3 = filesystem3.GetDirectoryClient(GetNewDirectoryName());
            Assert.IsFalse(directory3.CanGenerateSasUri);
        }

        [Test]
        public void GenerateSas_RequiredParameters()
        {
            // Arrange
            var constants = new TestConstants(this);
            string fileSystemName = GetNewFileSystemName();
            DataLakeFileSystemSasPermissions permissions = DataLakeFileSystemSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "/" + fileSystemName);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(new DataLakeFileSystemClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            // Act
            Uri sasUri = fileSystemClient.GenerateSasUri(permissions, expiresOn);

            // Assert
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName
            };
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(blobEndpoint)
            {
                Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.AreEqual(expectedUri.ToUri().ToString(), sasUri.ToString());
        }

        [Test]
        public void GenerateSas_Builder()
        {
            var constants = new TestConstants(this);
            string fileSystemName = GetNewFileSystemName();
            DataLakeFileSystemSasPermissions permissions = DataLakeFileSystemSasPermissions.Read;
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "/" + fileSystemName);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(new DataLakeFileSystemClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemClient.Name,
                StartsOn = startsOn
            };

            // Act
            Uri sasUri = fileSystemClient.GenerateSasUri(sasBuilder);

            // Assert
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(blobEndpoint);
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                StartsOn = startsOn
            };
            expectedUri.Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential);
            Assert.AreEqual(expectedUri.ToUri().ToString(), sasUri.ToString());
        }

        [Test]
        public void GenerateSas_BuilderWrongName()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("http://127.0.0.1/");
            UriBuilder blobUriBuilder = new UriBuilder(blobEndpoint);
            blobUriBuilder.Path += constants.Sas.Account + "/" + GetNewFileSystemName();
            DataLakeFileSystemSasPermissions permissions = DataLakeFileSystemSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(new DataLakeFileSystemClient(
                blobUriBuilder.Uri,
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = GetNewFileSystemName(), // different filesytem name
            };

            // Act
            try
            {
                fileSystemClient.GenerateSasUri(sasBuilder);

                Assert.Fail("DataLakeFileSystemClient.GenerateSasUri should have failed with an ArgumentException.");
            }
            catch (InvalidOperationException)
            {
                //the correct exception came back
            }
        }
        #endregion

        private IEnumerable<AccessConditionParameters> Conditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = NewDate },
                new AccessConditionParameters { LeaseId = ReceivedLeaseId }
            };

        private IEnumerable<AccessConditionParameters> ConditionsFail_Data
            => new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = OldDate },
                new AccessConditionParameters { LeaseId = GarbageETag },
             };

        private IEnumerable<AccessConditionParameters> NoLease_Conditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = NewDate }
            };

        private IEnumerable<AccessConditionParameters> NoLease_ConditionsFail_Data
            => new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = OldDate }
            };

        private DataLakeRequestConditions BuildFileSystemConditions(
            AccessConditionParameters parameters,
            bool ifUnmodifiedSince,
            bool lease)
        {
            DataLakeRequestConditions conditions = new DataLakeRequestConditions()
            {
                IfModifiedSince = parameters.IfModifiedSince
            };

            if (ifUnmodifiedSince)
            {
                conditions.IfUnmodifiedSince = parameters.IfUnmodifiedSince;
            }

            if (lease)
            {
                conditions.LeaseId = parameters.LeaseId;
            }

            return conditions;
        }

        private class AccessConditionParameters
        {
            public DateTimeOffset? IfModifiedSince { get; set; }
            public DateTimeOffset? IfUnmodifiedSince { get; set; }
            public string LeaseId { get; set; }
        }

        private async Task SetUpFileSystemForListing(DataLakeFileSystemClient fileSystem)
        {
            string[] pathNames = PathNames;
            DataLakeDirectoryClient[] directories = new DataLakeDirectoryClient[pathNames.Length];

            // Upload directories
            for (var i = 0; i < pathNames.Length; i++)
            {
                DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(pathNames[i]));
                directories[i] = directory;
                await directory.CreateIfNotExistsAsync();
            }
        }
    }
}
