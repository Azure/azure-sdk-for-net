// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Testing;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class FileSystemClientTests : DataLakeTestBase
    {
        public FileSystemClientTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
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
                await fileSystem.DeleteAsync();
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
                await fileSystem.DeleteAsync();
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
                    await fileSystem.DeleteAsync();
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
                await fileSystem.DeleteAsync();
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
            AssertMetadataEquality(metadata, response.Value.Metadata);

            // Cleanup
            await fileSystem.DeleteAsync();
        }

        [Test]
        public async Task CreateAsync_PublicAccess()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));

            // Act
            await fileSystem.CreateAsync(publicAccessType: Models.PublicAccessType.Blob);

            // Assert
            Response<FileSystemProperties> response = await fileSystem.GetPropertiesAsync();
            Assert.AreEqual(Models.PublicAccessType.Blob, response.Value.PublicAccess);

            // Cleanup
            await fileSystem.DeleteAsync();
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
                e => Assert.AreEqual("ContainerAlreadyExists", e.ErrorCode.Split('\n')[0]));

            // Cleanup
            await fileSystemClient.DeleteAsync();
        }

        [Test]
        public async Task DeleteAsync()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            await fileSystem.CreateAsync();

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
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
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
                await fileSystem.CreateAsync();
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
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    parameters.LeaseId = await SetupFileSystemLeaseCondition(fileSystem, parameters.LeaseId, garbageLeaseId);
                    DataLakeRequestConditions conditions = BuildFileSystemConditions(
                        parameters: parameters,
                        ifUnmodifiedSince: true,
                        lease: true);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        fileSystem.DeleteAsync(conditions: conditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task ListPathsAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                await SetUpFileSystemForListing(fileSystem);

                // Act
                AsyncPageable<PathItem> response = fileSystem.ListPathsAsync();
                IList<PathItem> paths = await response.ToListAsync();

                // Assert
                Assert.AreEqual(3, paths.Count);
            }
        }

        [Test]
        public async Task ListPathsAsync_Recursive()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                await SetUpFileSystemForListing(fileSystem);

                // Act
                AsyncPageable<PathItem> response = fileSystem.ListPathsAsync(recursive: true);
                IList<PathItem> paths = await response.ToListAsync();

                // Assert
                Assert.AreEqual(PathNames.Length, paths.Count);
            }
        }

        [Test]
        public async Task ListPathsAsync_Upn()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                await SetUpFileSystemForListing(fileSystem);

                // Act
                AsyncPageable<PathItem> response = fileSystem.ListPathsAsync(upn: true);
                IList<PathItem> paths = await response.ToListAsync();

                // Assert
                Assert.AreEqual(3, paths.Count);
            }
        }

        [Test]
        public async Task ListPathsAsync_Path()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                await SetUpFileSystemForListing(fileSystem);

                // Act
                AsyncPageable<PathItem> response = fileSystem.ListPathsAsync(path: "foo");
                IList<PathItem> paths = await response.ToListAsync();

                // Assert
                Assert.AreEqual(2, paths.Count);
            }
        }

        [Test]
        [AsyncOnly]
        public async Task ListPathsAsync_MaxResults()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                await SetUpFileSystemForListing(fileSystem);

                // Act
                Page<PathItem> page = await fileSystem.ListPathsAsync().AsPages(pageSizeHint: 2).FirstAsync();

                // Assert
                Assert.AreEqual(2, page.Values.Count);
            }
        }

        [Test]
        public async Task ListPathsAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = service.GetFileSystemClient(GetNewFileSystemName());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileSystem.ListPathsAsync().ToListAsync(),
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem, publicAccessType: Models.PublicAccessType.Container))
            {
                // Act
                Response<FileSystemProperties> response = await fileSystem.GetPropertiesAsync();

                // Assert
                Assert.AreEqual(Models.PublicAccessType.Container, response.Value.PublicAccess);
            }
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
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task SetMetadataAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                IDictionary<string, string> metadata = BuildMetadata();

                // Act
                await fileSystem.SetMetadataAsync(metadata);

                // Assert
                Response<FileSystemProperties> response = await fileSystem.GetPropertiesAsync();
                AssertMetadataEquality(metadata, response.Value.Metadata);
            }
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
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
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
                await fileSystem.CreateAsync();
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
                await fileSystem.DeleteAsync(new DataLakeRequestConditions
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
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    IDictionary<string, string> metadata = BuildMetadata();
                    DataLakeRequestConditions conditions = BuildFileSystemConditions(
                        parameters: parameters,
                        ifUnmodifiedSince: false,
                        lease: true);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        fileSystem.SetMetadataAsync(
                            metadata: metadata,
                            conditions: conditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task CreateFileAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Act
                string fileName = GetNewFileName();
                Response<DataLakeFileClient> response = await fileSystem.CreateFileAsync(fileName);

                // Assert
                Assert.AreEqual(fileName, response.Value.Name);
            }
        }

        [Test]
        public async Task CreateFileAsync_HttpHeaders()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
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
                DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName(), httpHeaders: headers);

                // Assert
                Response<PathProperties> response = await file.GetPropertiesAsync();
                Assert.AreEqual(ContentType, response.Value.ContentType);
                Assert.AreEqual(ContentEncoding, response.Value.ContentEncoding);
                Assert.AreEqual(ContentLanguage, response.Value.ContentLanguage);
                Assert.AreEqual(ContentDisposition, response.Value.ContentDisposition);
                Assert.AreEqual(CacheControl, response.Value.CacheControl);
            }
        }

        [Test]
        public async Task CreateFileAsync_Metadata()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                IDictionary<string, string> metadata = BuildMetadata();

                // Act
                DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName(), metadata: metadata);

                // Assert
                Response<PathProperties> getPropertiesResponse = await file.GetPropertiesAsync();
                AssertMetadataEquality(metadata, getPropertiesResponse.Value.Metadata, isDirectory: false);
            }
        }

        [Test]
        public async Task CreateFileAsync_PermissionAndUmask()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                string permissions = "0777";
                string umask = "0057";

                // Act
                DataLakeFileClient file = await fileSystem.CreateFileAsync(
                    GetNewFileName(),
                    permissions: permissions,
                    umask: umask);

                // Assert
                Response<PathAccessControl> response = await file.GetAccessControlAsync();
                Assert.AreEqual("rwx-w----", response.Value.Permissions);
            }
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
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task DeleteFileAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                string fileName = GetNewFileName();
                await fileSystem.CreateFileAsync(fileName);

                // Act
                await fileSystem.DeleteFileAsync(fileName);
            }
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
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task CreateDirectoryAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Act
                string directoryName = GetNewDirectoryName();
                Response<DataLakeDirectoryClient> response = await fileSystem.CreateDirectoryAsync(directoryName);

                // Assert
                Assert.AreEqual(directoryName, response.Value.Name);
            }
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
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task CreateDirectoryAsync_HttpHeaders()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
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
                DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName(), httpHeaders: headers);

                // Assert
                Response<PathProperties> response = await directory.GetPropertiesAsync();
                Assert.AreEqual(ContentType, response.Value.ContentType);
                Assert.AreEqual(ContentEncoding, response.Value.ContentEncoding);
                Assert.AreEqual(ContentLanguage, response.Value.ContentLanguage);
                Assert.AreEqual(ContentDisposition, response.Value.ContentDisposition);
                Assert.AreEqual(CacheControl, response.Value.CacheControl);
            }
        }

        [Test]
        public async Task CreateDirectoryAsync_Metadata()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                IDictionary<string, string> metadata = BuildMetadata();

                // Act
                DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName(), metadata: metadata);

                // Assert
                Response<PathProperties> getPropertiesResponse = await directory.GetPropertiesAsync();
                AssertMetadataEquality(metadata, getPropertiesResponse.Value.Metadata, isDirectory: true);
            }
        }

        [Test]
        public async Task CreateDirectoryAsync_PermissionAndUmask()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                string permissions = "0777";
                string umask = "0057";

                // Act
                DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(
                    GetNewDirectoryName(),
                    permissions: permissions,
                    umask: umask);

                // Assert
                Response<PathAccessControl> response = await directory.GetAccessControlAsync();
                Assert.AreEqual("rwx-w----", response.Value.Permissions);
            }
        }

        [Test]
        public async Task DeleteDirectoryAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                string directoryName = GetNewDirectoryName();
                await fileSystem.CreateDirectoryAsync(directoryName);

                // Act
                await fileSystem.DeleteDirectoryAsync(directoryName);
            }
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
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task AquireLeaseAsync()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            await fileSystem.CreateAsync();
            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            // Act
            Response<DataLakeLease> response = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(duration: duration);

            // Assert
            Assert.AreEqual(id, response.Value.LeaseId);

            // Cleanup
            await fileSystem.DeleteAsync(conditions: new DataLakeRequestConditions
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
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task AcquireLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                // Arrange
                DataLakeServiceClient service = GetServiceClient_SharedKey();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateAsync();
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
                await fileSystem.DeleteAsync(conditions: new DataLakeRequestConditions
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
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeRequestConditions conditions = BuildFileSystemConditions(
                        parameters: parameters,
                        ifUnmodifiedSince: true,
                        lease: false);

                    var id = Recording.Random.NewGuid().ToString();
                    var duration = TimeSpan.FromSeconds(15);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(
                            duration: duration,
                            conditions: conditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task RenewLeaseAsync()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            await fileSystem.CreateAsync();

            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            Response<Models.DataLakeLease> leaseResponse = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(
                duration: duration);

            // Act
            Response<Models.DataLakeLease> renewResponse = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(leaseResponse.Value.LeaseId)).RenewAsync();

            // Assert
            Assert.IsNotNull(renewResponse.GetRawResponse().Headers.RequestId);

            // Cleanup
            await fileSystem.DeleteAsync(conditions: new DataLakeRequestConditions
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
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task RenewLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                // Arrange
                DataLakeServiceClient service = GetServiceClient_SharedKey();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateAsync();
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
                await fileSystem.DeleteAsync(conditions: new DataLakeRequestConditions
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
                await fileSystem.CreateAsync();
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
                await fileSystem.DeleteAsync(conditions: new DataLakeRequestConditions
                {
                    LeaseId = aquireLeaseResponse.Value.LeaseId
                });
            }
        }

        [Test]
        public async Task ReleaseLeaseAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);
                Response<DataLakeLease> leaseResponse = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(duration);

                // Act
                Response<ReleasedObjectInfo> releaseResponse = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(leaseResponse.Value.LeaseId)).ReleaseAsync();

                // Assert
                Response<FileSystemProperties> response = await fileSystem.GetPropertiesAsync();

                Assert.AreEqual(LeaseStatus.Unlocked, response.Value.LeaseStatus);
                Assert.AreEqual(LeaseState.Available, response.Value.LeaseState);
            }
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
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task ReleaseLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                // Arrange
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    DataLakeRequestConditions conditions = BuildFileSystemConditions(
                        parameters: parameters,
                        ifUnmodifiedSince: true,
                        lease: false);

                    var id = Recording.Random.NewGuid().ToString();
                    var duration = TimeSpan.FromSeconds(15);

                    DataLakeLeaseClient lease = InstrumentClient(fileSystem.GetDataLakeLeaseClient(id));
                    Response<DataLakeLease> aquireLeaseResponse = await lease.AcquireAsync(duration: duration);

                    // Act
                    Response<ReleasedObjectInfo> response = await lease.ReleaseAsync(conditions: conditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
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
                await fileSystem.CreateAsync();
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
                await fileSystem.DeleteAsync(conditions: new DataLakeRequestConditions
                {
                    LeaseId = aquireLeaseResponse.Value.LeaseId
                });
            }
        }

        [Test]
        public async Task ChangeLeaseAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);
                Response<DataLakeLease> leaseResponse = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(duration);
                var newId = Recording.Random.NewGuid().ToString();

                // Act
                Response<DataLakeLease> changeResponse = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).ChangeAsync(newId);

                // Assert
                Assert.AreEqual(newId, changeResponse.Value.LeaseId);

                // Cleanup
                await InstrumentClient(fileSystem.GetDataLakeLeaseClient(changeResponse.Value.LeaseId)).ReleaseAsync();
            }
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
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task ChangeLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                // Arrange
                DataLakeServiceClient service = GetServiceClient_SharedKey();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateAsync();

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
                await fileSystem.DeleteAsync(conditions: new DataLakeRequestConditions
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
                await fileSystem.CreateAsync();
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
                await fileSystem.DeleteAsync(conditions: new DataLakeRequestConditions
                {
                    LeaseId = aquireLeaseResponse.Value.LeaseId
                });
            }
        }

        [Test]
        public async Task BreakLeaseAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);
                await InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(duration);
                TimeSpan breakPeriod = TimeSpan.FromSeconds(0);

                // Act
                Response<DataLakeLease> breakResponse = await InstrumentClient(fileSystem.GetDataLakeLeaseClient()).BreakAsync(breakPeriod);

                // Assert
                Response<FileSystemProperties> response = await fileSystem.GetPropertiesAsync();
                Assert.AreEqual(LeaseStatus.Unlocked, response.Value.LeaseStatus);
                Assert.AreEqual(LeaseState.Broken, response.Value.LeaseState);
            }
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
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task BreakLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                // Arrange
                DataLakeServiceClient service = GetServiceClient_SharedKey();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateAsync();

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
                await fileSystem.DeleteAsync(conditions: new DataLakeRequestConditions
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
                await fileSystem.CreateAsync();
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
                await fileSystem.DeleteAsync(conditions: new DataLakeRequestConditions
                {
                    LeaseId = aquireLeaseResponse.Value.LeaseId
                });
            }
        }

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
            var pathNames = PathNames;
            var directories = new DataLakeDirectoryClient[pathNames.Length];

            // Upload Blobs
            for (var i = 0; i < pathNames.Length; i++)
            {
                DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(pathNames[i]));
                directories[i] = directory;
                await directory.CreateAsync();
            }
        }

        private string[] PathNames
            => new[]
                {
                    "foo",
                    "bar",
                    "baz",
                    "baz/bar",
                    "foo/foo",
                    "foo/bar",
                    "baz/foo",
                    "baz/foo/bar",
                    "baz/bar/foo"
                };
            }
}
