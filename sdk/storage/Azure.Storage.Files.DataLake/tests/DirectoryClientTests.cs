// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Testing;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using NUnit.Framework;
using TestConstants = Azure.Storage.Test.Constants;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class DirectoryClientTests : PathTestBase
    {
        public DirectoryClientTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public async Task Ctor_Uri()
        {
            string fileSystemName = GetNewFileSystemName();
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem, fileSystemName: fileSystemName))
            {
                // Arrange
                string directoryName = GetNewDirectoryName();
                await fileSystem.CreateDirectoryAsync(directoryName);

                SasQueryParameters sasQueryParameters = GetNewAccountSasCredentials();
                Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{directoryName}?{sasQueryParameters}");
                DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(uri, GetOptions()));

                // Act
                await directoryClient.GetPropertiesAsync();

                // Assert
                Assert.AreEqual(directoryName, directoryClient.Name);
                Assert.AreEqual(fileSystemName, directoryClient.FileSystemName);
                Assert.AreEqual(uri, directoryClient.Uri);
            }
        }

        [Test]
        public async Task Ctor_SharedKey()
        {
            string fileSystemName = GetNewFileSystemName();
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem, fileSystemName: fileSystemName))
            {
                // Arrange
                string directoryName = GetNewDirectoryName();
                await fileSystem.CreateDirectoryAsync(directoryName);

                StorageSharedKeyCredential sharedKey = new StorageSharedKeyCredential(
                    TestConfigHierarchicalNamespace.AccountName,
                    TestConfigHierarchicalNamespace.AccountKey);
                Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{directoryName}");
                DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(uri, sharedKey, GetOptions()));

                // Act
                await directoryClient.GetPropertiesAsync();

                // Assert
                Assert.AreEqual(directoryName, directoryClient.Name);
                Assert.AreEqual(fileSystemName, directoryClient.FileSystemName);
                Assert.AreEqual(uri, directoryClient.Uri);
            }
        }

        [Test]
        public async Task Ctor_TokenCredential()
        {
            string fileSystemName = GetNewFileSystemName();
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem, fileSystemName: fileSystemName))
            {
                // Arrange
                string directoryName = GetNewDirectoryName();
                await fileSystem.CreateDirectoryAsync(directoryName);

                TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
                Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{directoryName}").ToHttps();
                DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(uri, tokenCredential, GetOptions()));

                // Act
                await directoryClient.GetPropertiesAsync();

                // Assert
                Assert.AreEqual(directoryName, directoryClient.Name);
                Assert.AreEqual(fileSystemName, directoryClient.FileSystemName);
                Assert.AreEqual(uri, directoryClient.Uri);
            }
        }

        [Test]
        public async Task CreateAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                var name = GetNewDirectoryName();
                DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(name));

                // Act
                Response<PathInfo> response = await directory.CreateAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                var accountName = new DataLakeUriBuilder(directory.Uri).AccountName;
                TestHelper.AssertCacheableProperty(accountName, () => directory.AccountName);
                var fileSystemName = new DataLakeUriBuilder(directory.Uri).FileSystemName;
                TestHelper.AssertCacheableProperty(fileSystemName, () => directory.FileSystemName);
                TestHelper.AssertCacheableProperty(name, () => directory.Name);
            }
        }

        [Test]
        public async Task CreateAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileSystem.CreateDirectoryAsync(GetNewDirectoryName()),
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task CreateAsync_HttpHeaders()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(GetNewDirectoryName()));
                PathHttpHeaders headers = new PathHttpHeaders
                {
                    ContentType = ContentType,
                    ContentEncoding = ContentEncoding,
                    ContentLanguage = ContentLanguage,
                    ContentDisposition = ContentDisposition,
                    CacheControl = CacheControl
                };

                // Act
                await directory.CreateAsync(httpHeaders: headers);

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
        public async Task CreateAsync_Metadata()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                IDictionary<string, string> metadata = BuildMetadata();
                DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(GetNewDirectoryName()));

                // Act
                await directory.CreateAsync(metadata: metadata);

                // Assert
                Response<PathProperties> getPropertiesResponse = await directory.GetPropertiesAsync();
                AssertMetadataEquality(metadata, getPropertiesResponse.Value.Metadata, isDirectory: true);
            }
        }

        [Test]
        public async Task CreateAsync_PermissionAndUmask()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(GetNewDirectoryName()));
                string permissions = "0777";
                string umask = "0057";

                // Act
                await directory.CreateAsync(
                    permissions: permissions,
                    umask: umask);

                // Assert
                Response<PathAccessControl> response = await directory.GetAccessControlAsync();
                Assert.AreEqual("rwx-w----", response.Value.Permissions);
            }
        }

        [Test]
        public async Task CreateAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    // This directory is intentionally created twice
                    DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                    parameters.Match = await SetupPathMatchCondition(directory, parameters.Match);
                    parameters.LeaseId = await SetupPathLeaseCondition(directory, parameters.LeaseId, garbageLeaseId);

                    DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    Response<PathInfo> response = await directory.CreateAsync(
                        conditions: conditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task CreateAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    // This directory is intentionally created twice
                    DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());
                    parameters.NoneMatch = await SetupPathMatchCondition(directory, parameters.NoneMatch);
                    DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        directory.CreateAsync(conditions: conditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task DeleteAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                var name = GetNewDirectoryName();
                DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(name));
                await directory.CreateAsync();

                // Act
                Response response = await directory.DeleteAsync();
            }
        }

        [Test]
        public async Task DeleteAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                    parameters.Match = await SetupPathMatchCondition(directory, parameters.Match);
                    parameters.LeaseId = await SetupPathLeaseCondition(directory, parameters.LeaseId, garbageLeaseId);
                    DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    await directory.DeleteAsync(conditions: conditions);
                }
            }
        }

        [Test]
        public async Task DeleteAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

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
        }

        [Test]
        public async Task RenameAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeDirectoryClient sourceDirectory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());
                string destDirectoryName = GetNewDirectoryName();

                // Act
                DataLakeDirectoryClient destDirectory = await sourceDirectory.RenameAsync(destinationPath: destDirectoryName);

                // Assert
                Response<PathProperties> response = await destDirectory.GetPropertiesAsync();
            }
        }

        [Test]
        public async Task RenameAsync_Error()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                var sourceDirectoryName = GetNewDirectoryName();
                DataLakeDirectoryClient sourceDirectory = InstrumentClient(fileSystem.GetDirectoryClient(sourceDirectoryName));
                string destPath = GetNewDirectoryName();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    sourceDirectory.RenameAsync(destinationPath: destPath),
                    e => Assert.AreEqual("SourcePathNotFound", e.ErrorCode.Split('\n')[0]));
            }
        }

        [Test]
        public async Task RenameAsync_DestinationConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient sourceDirectory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());
                    DataLakeDirectoryClient destDirectory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

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
        }

        [Test]
        public async Task RenameAsync_DestinationConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient sourceDirectory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());
                    DataLakeDirectoryClient destDirectory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

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
        }

        [Test]
        public async Task RenameAsync_SourceConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient sourceDirectory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());
                    DataLakeDirectoryClient destDirectory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

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
        }

        [Test]
        public async Task RenameAsync_SourceConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient sourceDirectory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());
                    DataLakeDirectoryClient destDirectory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

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
        }

        [Test]
        public async Task GetAccessControlAsync()
        {
            using (GetNewDirectory(out DataLakeDirectoryClient directoryClient))
            {
                // Act
                PathAccessControl accessControl = await directoryClient.GetAccessControlAsync();

                // Assert
                Assert.IsNotNull(accessControl.Owner);
                Assert.IsNotNull(accessControl.Group);
                Assert.IsNotNull(accessControl.Permissions);
                Assert.IsNotNull(accessControl.Acl);
            }
        }

        [Test]
        public async Task GetAccessControlAsync_Oauth()
        {
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem, fileSystemName: fileSystemName, service: oauthService))
            {
                // Arrange
                DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(directoryName);
                DataLakeDirectoryClient oauthDirectory = oauthService
                    .GetFileSystemClient(fileSystemName)
                    .GetDirectoryClient(directoryName);

                // Act
                PathAccessControl accessControl = await oauthDirectory.GetAccessControlAsync();

                // Assert
                Assert.IsNotNull(accessControl.Owner);
                Assert.IsNotNull(accessControl.Group);
                Assert.IsNotNull(accessControl.Permissions);
                Assert.IsNotNull(accessControl.Acl);
            }
        }


        [Test]
        public async Task GetAccessControlAsync_FileSystemSAS()
        {
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem, fileSystemName: fileSystemName))
            {
                // Arrange
                DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(directoryName);

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
                Assert.IsNotNull(accessControl.Acl);
            }
        }

        [Test]
        public async Task GetAccessControlAsync_FileSystemIdentitySAS()
        {
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem, fileSystemName: fileSystemName, service: oauthService))
            {
                // Arrange
                DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(directoryName);

                Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                    start: null,
                    expiry: Recording.UtcNow.AddHours(1));

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
                Assert.IsNotNull(accessControl.Acl);
            }
        }

        [Test]
        public async Task GetAccessControlAsync_PathSAS()
        {
            var fileSystemName = GetNewFileSystemName();
            var directoryName = GetNewDirectoryName();
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem, fileSystemName: fileSystemName))
            {
                // Arrange
                DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(directoryName);

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
                Assert.IsNotNull(accessControl.Acl);
            }
        }

        [Test]
        public async Task GetAccessControlAsync_PathIdentitySAS()
        {
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem, fileSystemName: fileSystemName, service: oauthService))
            {
                // Arrange
                DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(directoryName);

                Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                    start: null,
                    expiry: Recording.UtcNow.AddHours(1));

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
                Assert.IsNotNull(accessControl.Acl);
            }
        }

        [Test]
        public async Task GetAccessControlAsync_Error()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystemClient))
            {
                // Arrange
                DataLakeDirectoryClient directory = InstrumentClient(fileSystemClient.GetDirectoryClient(GetNewDirectoryName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    directory.GetAccessControlAsync(),
                    e => Assert.AreEqual("404", e.ErrorCode));
            }
        }

        [Test]
        public async Task GetAccessControlAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                    parameters.Match = await SetupPathMatchCondition(directory, parameters.Match);
                    parameters.LeaseId = await SetupPathLeaseCondition(directory, parameters.LeaseId, garbageLeaseId);
                    DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    await directory.GetAccessControlAsync(conditions: conditions);
                }
            }
        }

        [Ignore("service bug")]
        [Test]
        public async Task GetAccessControlAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                    parameters.NoneMatch = await SetupPathMatchCondition(directory, parameters.NoneMatch);
                    DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        directory.GetAccessControlAsync(conditions: conditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task SetAccessControlAsync()
        {
            using (GetNewDirectory(out DataLakeDirectoryClient directoryClient))
            {
                // Act
                Response<PathInfo>  response = await directoryClient.SetAccessControlAsync(acl: AccessControl);

                // Assert
                AssertValidStoragePathInfo(response);
            }
        }

        [Test]
        public async Task SetAccessControlAsync_Error()
        {
            using (GetNewDirectory(out DataLakeDirectoryClient directoryClient))
            {
                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    directoryClient.SetAccessControlAsync(acl: "asdf"),
                    e =>
                    {
                        Assert.AreEqual("InvaldAccessControlList", e.ErrorCode);
                        Assert.AreEqual("The access control list value is invalid.", e.Message.Split('\n')[0]);
                    });
            }
        }

        [Test]
        public async Task SetAccessControlAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                    parameters.Match = await SetupPathMatchCondition(directory, parameters.Match);
                    parameters.LeaseId = await SetupPathLeaseCondition(directory, parameters.LeaseId, garbageLeaseId);
                    DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    Response<PathInfo> response = await directory.SetAccessControlAsync(
                        acl: AccessControl,
                        conditions: conditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task SetAccessControlAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                    parameters.NoneMatch = await SetupPathMatchCondition(directory, parameters.NoneMatch);
                    DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        directory.SetAccessControlAsync(
                            acl: AccessControl,
                            conditions: conditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task SetPermissionsAsync()
        {
            using (GetNewDirectory(out DataLakeDirectoryClient directoryClient))
            {
                // Act
                Response<PathInfo> response = await directoryClient.SetPermissionsAsync(permissions: "0777");

                // Assert
                AssertValidStoragePathInfo(response);
            }
        }

        [Test]
        public async Task SetPermissionsAsync_Error()
        {
            using (GetNewDirectory(out DataLakeDirectoryClient directoryClient))
            {
                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    directoryClient.SetPermissionsAsync(permissions: "asdf"),
                    e =>
                    {
                        Assert.AreEqual("InvalidPermission", e.ErrorCode);
                        Assert.AreEqual("The permission value is invalid.", e.Message.Split('\n')[0]);
                    });
            }
        }

        [Test]
        public async Task SetPermissionsAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                    parameters.Match = await SetupPathMatchCondition(directory, parameters.Match);
                    parameters.LeaseId = await SetupPathLeaseCondition(directory, parameters.LeaseId, garbageLeaseId);
                    DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    Response<PathInfo> response = await directory.SetPermissionsAsync(
                        permissions: "0777",
                        conditions: conditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task SetPermissionsAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                    parameters.NoneMatch = await SetupPathMatchCondition(directory, parameters.NoneMatch);
                    DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        directory.SetPermissionsAsync(
                        permissions: "0777",
                            conditions: conditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            using (GetNewDirectory(out DataLakeDirectoryClient directory))
            {
                // Act
                Response<PathProperties> response = await directory.GetPropertiesAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task GetPropertiesAsync_Oauth()
        {
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem, fileSystemName: fileSystemName, service: oauthService))
            {
                // Arrange
                DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(directoryName);
                DataLakeDirectoryClient oauthDirectory = oauthService
                    .GetFileSystemClient(fileSystemName)
                    .GetDirectoryClient(directoryName);

                // Act
                Response<PathProperties> response = await directory.GetPropertiesAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task GetPropertiesAsync_FileSystemSAS()
        {
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem, fileSystemName: fileSystemName))
            {
                // Arrange
                DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(directoryName);

                DataLakeDirectoryClient sasDirectory = InstrumentClient(
                    GetServiceClient_DataLakeServiceSas_FileSystem(
                        fileSystemName: fileSystemName)
                    .GetFileSystemClient(fileSystemName)
                    .GetDirectoryClient(directoryName));

                // Act
                Response<PathProperties> response = await sasDirectory.GetPropertiesAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                var accountName = new DataLakeUriBuilder(fileSystem.Uri).AccountName;
                TestHelper.AssertCacheableProperty(accountName, () => directory.AccountName);
                TestHelper.AssertCacheableProperty(fileSystemName, () => directory.FileSystemName);
                TestHelper.AssertCacheableProperty(directoryName, () => directory.Name);
            }
        }

        [Test]
        public async Task GetPropertiesAsync_FileSystemIdentitySAS()
        {
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem, fileSystemName: fileSystemName, service: oauthService))
            {
                // Arrange
                DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(directoryName);

                Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                    start: null,
                    expiry: Recording.UtcNow.AddHours(1));

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
        }

        [Test]
        public async Task GetPropertiesAsync_PathSAS()
        {
            var fileSystemName = GetNewFileSystemName();
            var directoryName = GetNewDirectoryName();
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem, fileSystemName: fileSystemName))
            {
                // Arrange
                DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(directoryName);

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
        }

        [Test]
        public async Task GetPropertiesAsync_PathIdentitySAS()
        {
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem, fileSystemName: fileSystemName, service: oauthService))
            {
                // Arrange
                DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(directoryName);

                Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                    start: null,
                    expiry: Recording.UtcNow.AddHours(1));

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
        }

        [Test]
        public async Task GetPropertiesAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                using (GetNewDirectory(out DataLakeDirectoryClient directory))
                {
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
        }

        [Test]
        public async Task GetPropertiesAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                using (GetNewDirectory(out DataLakeDirectoryClient directory))
                {
                    // Arrange
                    parameters.NoneMatch = await SetupPathMatchCondition(directory, parameters.NoneMatch);
                    DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                    // Act
                    Assert.CatchAsync<Exception>(
                        async () =>
                        {
                            var _ = (await directory.GetPropertiesAsync(
                                conditions: conditions)).Value;
                        });
                }
            }
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(GetNewDirectoryName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    directory.GetPropertiesAsync(),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task SetHttpHeadersAsync()
        {
            var constants = new TestConstants(this);
            using (GetNewDirectory(out DataLakeDirectoryClient directory))
            {
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
        }

        [Test]
        public async Task SetHttpHeadersAsync_Error()
        {
            var constants = new TestConstants(this);
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(GetNewDirectoryName()));

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
        }

        [Test]
        public async Task SetHttpHeadersAsync_Conditions()
        {
            var constants = new TestConstants(this);
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

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
        }

        [Test]
        public async Task SetHttpHeadersAsync_ConditionsFail()
        {
            var constants = new TestConstants(this);
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

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
        }

        [Test]
        public async Task SetMetadataAsync()
        {
            using (GetNewDirectory(out DataLakeDirectoryClient directory))
            {
                // Arrange
                IDictionary<string, string> metadata = BuildMetadata();

                // Act
                await directory.SetMetadataAsync(metadata);

                // Assert
                Response<PathProperties> response = await directory.GetPropertiesAsync();
                AssertMetadataEquality(metadata, response.Value.Metadata, isDirectory: true);
            }
        }

        [Test]
        public async Task SetMetadataAsync_Error()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(GetNewDirectoryName()));
                IDictionary<string, string> metadata = BuildMetadata();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    directory.SetMetadataAsync(metadata),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task SetMetadataAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());
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
        }

        [Test]
        public async Task SetMetadataAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());
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
        }

        [Test]
        public async Task CreateFileAsync()
        {
            using (GetNewDirectory(out DataLakeDirectoryClient directory))
            {
                // Arrange
                string fileName = GetNewFileName();

                // Act
                Response<DataLakeFileClient> response = await directory.CreateFileAsync(fileName);

                // Assert
                Assert.AreEqual(fileName, response.Value.Name);
            }
        }

        [Test]
        public async Task CreateFileAsync_HttpHeaders()
        {
            using (GetNewDirectory(out DataLakeDirectoryClient directory))
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
                DataLakeFileClient file = await directory.CreateFileAsync(GetNewFileName(), httpHeaders: headers);

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
            using (GetNewDirectory(out DataLakeDirectoryClient directory))
            {
                // Arrange
                IDictionary<string, string> metadata = BuildMetadata();

                // Act
                DataLakeFileClient file = await directory.CreateFileAsync(GetNewFileName(), metadata: metadata);

                // Assert
                Response<PathProperties> getPropertiesResponse = await file.GetPropertiesAsync();
                AssertMetadataEquality(metadata, getPropertiesResponse.Value.Metadata, isDirectory: false);
            }
        }

        [Test]
        public async Task CreateFileAsync_PermissionAndUmask()
        {
            using (GetNewDirectory(out DataLakeDirectoryClient directory))
            {
                // Arrange
                string permissions = "0777";
                string umask = "0057";

                // Act
                DataLakeFileClient file = await directory.CreateFileAsync(
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
            DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.CreateFileAsync(GetNewFileName()),
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task DeleteFileAsync()
        {
            using (GetNewDirectory(out DataLakeDirectoryClient directory))
            {
                // Arrange
                string fileName = GetNewFileName();
                DataLakeFileClient fileClient = directory.GetFileClient(fileName);
                await fileClient.CreateAsync();

                // Assert
                await directory.DeleteFileAsync(fileName);
            }
        }

        [Test]
        public async Task DeleteFileAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.DeleteFileAsync(GetNewFileName()),
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task CreateSubDirectoryAsync()
        {
            using (GetNewDirectory(out DataLakeDirectoryClient directory))
            {
                // Arrange
                string directoryName = GetNewDirectoryName();

                // Act
                Response<DataLakeDirectoryClient> response = await directory.CreateSubDirectoryAsync(directoryName);

                // Assert
                Assert.AreEqual(directoryName, response.Value.Name);
            }
        }

        [Test]
        public async Task CreateSubDirectoryAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.CreateSubDirectoryAsync(GetNewDirectoryName()),
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task CreateSubDirectoryAsync_HttpHeaders()
        {
            using (GetNewDirectory(out DataLakeDirectoryClient directory))
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
                DataLakeDirectoryClient subDirectory = await directory.CreateSubDirectoryAsync(
                    GetNewDirectoryName(),
                    httpHeaders: headers);

                // Assert
                Response<PathProperties> response = await subDirectory.GetPropertiesAsync();
                Assert.AreEqual(ContentType, response.Value.ContentType);
                Assert.AreEqual(ContentEncoding, response.Value.ContentEncoding);
                Assert.AreEqual(ContentLanguage, response.Value.ContentLanguage);
                Assert.AreEqual(ContentDisposition, response.Value.ContentDisposition);
                Assert.AreEqual(CacheControl, response.Value.CacheControl);
            }
        }

        [Test]
        public async Task CreateSubDirectoryAsync_Metadata()
        {
            using (GetNewDirectory(out DataLakeDirectoryClient directory))
            {
                // Arrange
                IDictionary<string, string> metadata = BuildMetadata();

                // Act
                DataLakeDirectoryClient subDirectory = await directory.CreateSubDirectoryAsync(
                    GetNewDirectoryName(),
                    metadata: metadata);

                // Assert
                Response<PathProperties> getPropertiesResponse = await subDirectory.GetPropertiesAsync();
                AssertMetadataEquality(metadata, getPropertiesResponse.Value.Metadata, isDirectory: true);
            }
        }

        [Test]
        public async Task CreateSubDirectoryAsync_PermissionAndUmask()
        {
            using (GetNewDirectory(out DataLakeDirectoryClient directory))
            {
                // Arrange
                string permissions = "0777";
                string umask = "0057";

                // Act
                DataLakeDirectoryClient subDirectory = await directory.CreateSubDirectoryAsync(
                    GetNewDirectoryName(),
                    permissions: permissions,
                    umask: umask);

                // Assert
                Response<PathAccessControl> response = await subDirectory.GetAccessControlAsync();
                Assert.AreEqual("rwx-w----", response.Value.Permissions);
            }
        }

        [Test]
        public async Task CreateSubDirectoryAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                using (GetNewDirectory(out DataLakeDirectoryClient directory))
                {
                    // Arrange
                    // This directory is intentionally created twice
                    DataLakeDirectoryClient subDirectory = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());

                    parameters.Match = await SetupPathMatchCondition(subDirectory, parameters.Match);
                    parameters.LeaseId = await SetupPathLeaseCondition(subDirectory, parameters.LeaseId, garbageLeaseId);

                    DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    Response<PathInfo> response = await subDirectory.CreateAsync(
                        conditions: conditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task CreateSubDirectoryAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                using (GetNewDirectory(out DataLakeDirectoryClient directory))
                {
                    // Arrange
                    // This directory is intentionally created twice
                    DataLakeDirectoryClient subDirectory = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
                    parameters.NoneMatch = await SetupPathMatchCondition(subDirectory, parameters.NoneMatch);
                    DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        subDirectory.CreateAsync(conditions: conditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task DeleteSubDirectoryAsync()
        {
            using (GetNewDirectory(out DataLakeDirectoryClient directory))
            {
                // Arrange
                string directoryName = GetNewDirectoryName();
                DataLakeDirectoryClient directoryClient = directory.GetSubDirectoryClient(directoryName);
                await directoryClient.CreateAsync();

                // Assert
                await directory.DeleteFileAsync(directoryName);
            }
        }

        [Test]
        public async Task DeleteSubDirectoryAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                using (GetNewDirectory(out DataLakeDirectoryClient directory))
                {
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
        }

        [Test]
        public async Task DeleteSubDirectoryAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                using (GetNewDirectory(out DataLakeDirectoryClient directory))
                {
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
        }

        [Test]
        public async Task AcquireLeaseAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                // Act
                Response<DataLakeLease> response = await InstrumentClient(directory.GetDataLakeLeaseClient(leaseId)).AcquireAsync(duration);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task AcquireLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

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
        }

        [Test]
        public async Task AcquireLeaseAsync_ConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_ConditionsFail_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

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
        }

        [Test]
        public async Task AcquireLeaseAsync_Error()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(GetNewDirectoryName()));
                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(directory.GetDataLakeLeaseClient(leaseId)).AcquireAsync(duration),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task RenewLeaseAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                DataLakeLeaseClient lease = InstrumentClient(directory.GetDataLakeLeaseClient(leaseId));
                await lease.AcquireAsync(duration);

                // Act
                Response<DataLakeLease> response = await lease.RenewAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task RenewLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

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
        }

        [Test]
        public async Task RenewLeaseAsync_ConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_ConditionsFail_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

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
        }

        [Test]
        public async Task RenewLeaseAsync_Error()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(GetNewDirectoryName()));
                var leaseId = Recording.Random.NewGuid().ToString();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(directory.GetDataLakeLeaseClient(leaseId)).ReleaseAsync(),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task ReleaseLeaseAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                DataLakeLeaseClient lease = InstrumentClient(directory.GetDataLakeLeaseClient(leaseId));
                await lease.AcquireAsync(duration);

                // Act
                Response<ReleasedObjectInfo> response = await lease.ReleaseAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task ReleaseLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

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
        }

        [Test]
        public async Task ReleaseLeaseAsync_ConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_ConditionsFail_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

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
        }

        [Test]
        public async Task ReleaseLeaseAsync_Error()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(GetNewDirectoryName()));
                var leaseId = Recording.Random.NewGuid().ToString();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(directory.GetDataLakeLeaseClient(leaseId)).RenewAsync(),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task ChangeLeaseAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

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
        }

        [Test]
        public async Task ChangeLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

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
        }

        [Test]
        public async Task ChangeLeaseAsync_ConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_ConditionsFail_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

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
        }

        [Test]
        public async Task ChangeLeaseAsync_Error()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(GetNewDirectoryName()));
                var leaseId = Recording.Random.NewGuid().ToString();
                var newLeaseId = Recording.Random.NewGuid().ToString();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(directory.GetDataLakeLeaseClient(leaseId)).ChangeAsync(proposedId: newLeaseId),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task BreakLeaseAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                DataLakeLeaseClient lease = InstrumentClient(directory.GetDataLakeLeaseClient(leaseId));
                await lease.AcquireAsync(duration);

                // Act
                Response<DataLakeLease> response = await lease.BreakAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task BreakLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

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
        }

        [Test]
        public async Task BreakLeaseAsync_ConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_ConditionsFail_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeDirectoryClient directory = await fileSystem.CreateDirectoryAsync(GetNewDirectoryName());

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
        }

        [Test]
        public async Task BreakLeaseAsync_Error()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(GetNewDirectoryName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(directory.GetDataLakeLeaseClient()).BreakAsync(),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }
    }
}
