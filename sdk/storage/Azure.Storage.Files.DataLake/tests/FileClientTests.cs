// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
    public class FileClientTests : PathTestBase
    {
        private const long Size = 4 * Constants.KB;

        public FileClientTests(bool async)
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
                string fileName = GetNewFileName();
                await fileSystem.CreateFileAsync(fileName);

                SasQueryParameters sasQueryParameters = GetNewAccountSasCredentials();
                Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{fileName}?{sasQueryParameters}");
                DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(uri, GetOptions()));

                // Act
                await fileClient.GetPropertiesAsync();

                // Assert
                Assert.AreEqual(fileName, fileClient.Name);
                Assert.AreEqual(fileSystemName, fileClient.FileSystemName);
                Assert.AreEqual(uri, fileClient.Uri);
            }
        }

        [Test]
        public async Task Ctor_SharedKey()
        {
            string fileSystemName = GetNewFileSystemName();
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem, fileSystemName: fileSystemName))
            {
                // Arrange
                string fileName = GetNewFileName();
                await fileSystem.CreateFileAsync(fileName);

                StorageSharedKeyCredential sharedKey = new StorageSharedKeyCredential(
                    TestConfigHierarchicalNamespace.AccountName,
                    TestConfigHierarchicalNamespace.AccountKey);
                Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{fileName}");
                DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(uri, sharedKey, GetOptions()));

                // Act
                await fileClient.GetPropertiesAsync();

                // Assert
                Assert.AreEqual(fileName, fileClient.Name);
                Assert.AreEqual(fileSystemName, fileClient.FileSystemName);
                Assert.AreEqual(uri, fileClient.Uri);
            }
        }

        [Test]
        public async Task Ctor_TokenCredential()
        {
            string fileSystemName = GetNewFileSystemName();
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem, fileSystemName: fileSystemName))
            {
                // Arrange
                string fileName = GetNewFileName();
                await fileSystem.CreateFileAsync(fileName);

                TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
                Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{fileName}").ToHttps();
                DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(uri, tokenCredential, GetOptions()));

                // Act
                await fileClient.GetPropertiesAsync();

                // Assert
                Assert.AreEqual(fileName, fileClient.Name);
                Assert.AreEqual(fileSystemName, fileClient.FileSystemName);
                Assert.AreEqual(uri, fileClient.Uri);
            }
        }

        [Test]
        public async Task CreateAsync()
        {
            using (GetNewDirectory(out DataLakeDirectoryClient directoryClient))
            {
                // Arrange
                DataLakeFileClient file = InstrumentClient(directoryClient.GetFileClient(GetNewFileName()));

                // Act
                Response<PathInfo> response = await file.CreateAsync();

                // Assert
                AssertValidStoragePathInfo(response.Value);
            }
        }

        [Test]
        public async Task CreateAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileSystem.CreateDirectoryAsync(GetNewDirectoryName()),
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task CreateAsync_HttpHeaders()
        {
            using (GetNewDirectory(out DataLakeDirectoryClient directoryClient))
            {
                // Arrange
                DataLakeFileClient file = InstrumentClient(directoryClient.GetFileClient(GetNewFileName()));
                PathHttpHeaders headers = new PathHttpHeaders
                {
                    ContentType = ContentType,
                    ContentEncoding = ContentEncoding,
                    ContentLanguage = ContentLanguage,
                    ContentDisposition = ContentDisposition,
                    CacheControl = CacheControl
                };

                // Act
                await file.CreateAsync(httpHeaders: headers);

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
        public async Task CreateAsync_Metadata()
        {
            using (GetNewDirectory(out DataLakeDirectoryClient directoryClient))
            {
                // Arrange
                IDictionary<string, string> metadata = BuildMetadata();
                DataLakeFileClient file = InstrumentClient(directoryClient.GetFileClient(GetNewFileName()));

                // Act
                await file.CreateAsync(metadata: metadata);

                // Assert
                Response<PathProperties> getPropertiesResponse = await file.GetPropertiesAsync();
                AssertMetadataEquality(metadata, getPropertiesResponse.Value.Metadata, isDirectory: false);
            }
        }

        [Test]
        public async Task CreateAsync_PermissionAndUmask()
        {
            using (GetNewDirectory(out DataLakeDirectoryClient directoryClient))
            {
                // Arrange
                DataLakeFileClient file = InstrumentClient(directoryClient.GetFileClient(GetNewFileName()));
                string permissions = "0777";
                string umask = "0057";

                // Act
                await file.CreateAsync(
                    permissions: permissions,
                    umask: umask);

                // Assert
                Response<PathAccessControl> response = await file.GetAccessControlAsync();
                Assert.AreEqual("rwx-w----", response.Value.Permissions);
            }
        }

        [Test]
        public async Task CreateAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                using (GetNewDirectory(out DataLakeDirectoryClient directoryClient))
                {
                    // Arrange
                    // This directory is intentionally created twice
                    DataLakeFileClient file = await directoryClient.CreateFileAsync(GetNewFileName());

                    parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                    parameters.LeaseId = await SetupPathLeaseCondition(file, parameters.LeaseId, garbageLeaseId);

                    DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    Response<PathInfo> response = await file.CreateAsync(
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
                using (GetNewDirectory(out DataLakeDirectoryClient directoryClient))
                {
                    // Arrange
                    // This directory is intentionally created twice
                    DataLakeFileClient file = await directoryClient.CreateFileAsync(GetNewFileName());
                    parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                    DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        file.CreateAsync(conditions: conditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task DeleteAsync()
        {
            using (GetNewDirectory(out DataLakeDirectoryClient directoryClient))
            {
                // Arrange
                DataLakeFileClient fileClient = await directoryClient.CreateFileAsync(GetNewFileName());

                // Act
                await fileClient.DeleteAsync();
            }
        }

        [Test]
        public async Task DeleteFileAsync_Error()
        {
            using (GetNewDirectory(out DataLakeDirectoryClient directoryClient))
            {
                // Arrange
                DataLakeFileClient fileClient = directoryClient.GetFileClient(GetNewFileName());

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    fileClient.DeleteAsync(),
                    e => Assert.AreEqual("PathNotFound", e.ErrorCode.Split('\n')[0]));
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
                    DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());

                    parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                    parameters.LeaseId = await SetupPathLeaseCondition(file, parameters.LeaseId, garbageLeaseId);
                    DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    await file.DeleteAsync(conditions: conditions);
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
                    DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());

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
        }

        [Test]
        public async Task RenameAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient sourceFile = await fileSystem.CreateFileAsync(GetNewFileName());
                string destFileName = GetNewDirectoryName();

                // Act
                DataLakeFileClient destFile = await sourceFile.RenameAsync(destinationPath: destFileName);

                // Assert
                Response<PathProperties> response = await destFile.GetPropertiesAsync();
            }
        }

        [Test]
        public async Task RenameAsync_Error()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient sourceFile = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));
                string destPath = GetNewFileName();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    sourceFile.RenameAsync(destinationPath: destPath),
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
                    DataLakeFileClient sourceFile = await fileSystem.CreateFileAsync(GetNewFileName());
                    DataLakeFileClient destFile = await fileSystem.CreateFileAsync(GetNewFileName());

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
                    DataLakeFileClient sourceFile = await fileSystem.CreateFileAsync(GetNewFileName());
                    DataLakeFileClient destFile = await fileSystem.CreateFileAsync(GetNewFileName());

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
                    DataLakeFileClient sourceFile = await fileSystem.CreateFileAsync(GetNewFileName());
                    DataLakeFileClient destFile = await fileSystem.CreateFileAsync(GetNewFileName());

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
                    DataLakeFileClient sourceFile = await fileSystem.CreateFileAsync(GetNewFileName());
                    DataLakeFileClient destFile = await fileSystem.CreateFileAsync(GetNewFileName());

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
        }

        [Test]
        public async Task GetAccessControlAsync()
        {
            using (GetNewFile(out DataLakeFileClient fileClient))
            {
                // Act
                PathAccessControl accessControl = await fileClient.GetAccessControlAsync();

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
            string fileName = GetNewFileName();
            using (GetNewDirectory(out DataLakeDirectoryClient directoryClient, fileSystemName: fileSystemName, directoryName: directoryName))
            {
                // Arrange
                DataLakeFileClient file = await directoryClient.CreateFileAsync(fileName);
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
                Assert.IsNotNull(accessControl.Acl);
            }
        }

        [Test]
        public async Task GetAccessControlAsync_FileSystemSAS()
        {
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            string fileName = GetNewFileName();
            using (GetNewDirectory(out DataLakeDirectoryClient directoryClient, fileSystemName: fileSystemName, directoryName: directoryName))
            {
                // Arrange
                DataLakeFileClient file = await directoryClient.CreateFileAsync(fileName);

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
                Assert.IsNotNull(accessControl.Acl);
            }
        }

        [Test]
        public async Task GetAccessControlAsync_FileSystemIdentitySAS()
        {
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            string fileName = GetNewFileName();
            using (GetNewDirectory(out DataLakeDirectoryClient directoryClient, fileSystemName: fileSystemName, directoryName: directoryName))
            {
                // Arrange
                DataLakeFileClient file = await directoryClient.CreateFileAsync(fileName);

                Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                    start: null,
                    expiry: Recording.UtcNow.AddHours(1));

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
                Assert.IsNotNull(accessControl.Acl);
            }
        }

        [Test]
        public async Task GetAccessControlAsync_PathSAS()
        {
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            string fileName = GetNewFileName();
            using (GetNewDirectory(out DataLakeDirectoryClient directoryClient, fileSystemName: fileSystemName, directoryName: directoryName))
            {
                // Arrange
                DataLakeFileClient file = await directoryClient.CreateFileAsync(fileName);

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
                Assert.IsNotNull(accessControl.Acl);
            }
        }

        [Test]
        public async Task GetAccessControlAsync_PathIdentitySAS()
        {
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            string fileName = GetNewFileName();
            using (GetNewDirectory(out DataLakeDirectoryClient directoryClient, fileSystemName: fileSystemName, directoryName: directoryName))
            {
                // Arrange
                DataLakeFileClient file = await directoryClient.CreateFileAsync(fileName);

                Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                    start: null,
                    expiry: Recording.UtcNow.AddHours(1));

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
                Assert.IsNotNull(accessControl.Acl);
            }
        }

        [Test]
        public async Task GetAccessControlAsync_Error()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystemClient))
            {
                // Arrange
                DataLakeFileClient file = InstrumentClient(fileSystemClient.GetFileClient(GetNewFileName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    file.GetAccessControlAsync(),
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
                    DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());

                    parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                    parameters.LeaseId = await SetupPathLeaseCondition(file, parameters.LeaseId, garbageLeaseId);
                    DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    await file.GetAccessControlAsync(conditions: conditions);
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
                    DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());

                    parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                    DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        file.GetAccessControlAsync(conditions: conditions),
                        e => { });
                }
            }
        }

        [Ignore("service bug")]
        [Test]
        public async Task GetAccessControlAsync_InvalidLease()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystemClient))
            {
                // Arrange
                DataLakeFileClient file = await fileSystemClient.CreateFileAsync(GetNewFileName());
                DataLakeRequestConditions conditions = new DataLakeRequestConditions()
                {
                    LeaseId = GetGarbageLeaseId()
                };

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    file.GetAccessControlAsync(conditions: conditions),
                    e => Assert.AreEqual("404", e.ErrorCode));
            }
        }

        [Test]
        public async Task SetAccessControlAsync()
        {
            using (GetNewFile(out DataLakeFileClient fileClient))
            {
                // Act
                Response<PathInfo> response = await fileClient.SetAccessControlAsync(acl: AccessControl);

                // Assert
                AssertValidStoragePathInfo(response);
            }
        }

        [Test]
        public async Task SetAccessControlAsync_Error()
        {
            using (GetNewFile(out DataLakeFileClient fileClient))
            {
                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    fileClient.SetAccessControlAsync(acl: "asdf"),
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
                    DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());

                    parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                    parameters.LeaseId = await SetupPathLeaseCondition(file, parameters.LeaseId, garbageLeaseId);
                    DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    Response<PathInfo> response = await file.SetAccessControlAsync(
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
                    DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());

                    parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                    DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        file.SetAccessControlAsync(
                            acl: AccessControl,
                            conditions: conditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task SetPermissionsAsync()
        {
            using (GetNewFile(out DataLakeFileClient fileClient))
            {
                // Act
                Response<PathInfo> response = await fileClient.SetPermissionsAsync(permissions: "0777");

                // Assert
                AssertValidStoragePathInfo(response);
            }
        }

        [Test]
        public async Task SetPermissionsAsync_Error()
        {
            using (GetNewFile(out DataLakeFileClient fileClient))
            {
                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    fileClient.SetPermissionsAsync(permissions: "asdf"),
                    e =>
                    {
                        Assert.AreEqual("InvalidPermission", e.ErrorCode);
                        Assert.AreEqual("The permission value is invalid.", e.Message.Split('\n')[0]);
                    });
            }
        }

        [Test]
        public async Task SetPermissionAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());

                    parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                    parameters.LeaseId = await SetupPathLeaseCondition(file, parameters.LeaseId, garbageLeaseId);
                    DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                        parameters: parameters,
                        lease: true);

                    // Act
                    Response<PathInfo> response = await file.SetPermissionsAsync(
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
                    DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());

                    parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                    DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        file.SetPermissionsAsync(
                            permissions: "0777",
                            conditions: conditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            using (GetNewFile(out DataLakeFileClient file))
            {
                // Act
                Response<PathProperties> response = await file.GetPropertiesAsync();

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
            string fileName = GetNewFileName();
            using (GetNewDirectory(out DataLakeDirectoryClient directoryClient, fileSystemName: fileSystemName, directoryName: directoryName))
            {
                // Arrange
                DataLakeFileClient file = await directoryClient.CreateFileAsync(fileName);
                DataLakeFileClient oauthFile = oauthService
                    .GetFileSystemClient(fileSystemName)
                    .GetDirectoryClient(directoryName)
                    .GetFileClient(fileName);

                // Act
                Response<PathProperties> response = await file.GetPropertiesAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task GetPropertiesAsync_FileSystemSAS()
        {
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            string fileName = GetNewFileName();
            using (GetNewDirectory(out DataLakeDirectoryClient directoryClient, fileSystemName: fileSystemName, directoryName: directoryName))
            {
                // Arrange
                DataLakeFileClient file = await directoryClient.CreateFileAsync(fileName);

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
        }

        [Test]
        public async Task GetPropertiesAsync_FileSystemIdentitySAS()
        {
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            string fileName = GetNewFileName();
            using (GetNewDirectory(out DataLakeDirectoryClient directoryClient, fileSystemName: fileSystemName, directoryName: directoryName))
            {
                // Arrange
                DataLakeFileClient file = await directoryClient.CreateFileAsync(fileName);

                Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                    start: null,
                    expiry: Recording.UtcNow.AddHours(1));

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
            }
        }

        [Test]
        public async Task GetPropertiesAsync_PathSAS()
        {
            var fileSystemName = GetNewFileSystemName();
            var directoryName = GetNewDirectoryName();
            string fileName = GetNewFileName();
            using (GetNewDirectory(out DataLakeDirectoryClient directoryClient, fileSystemName: fileSystemName, directoryName: directoryName))
            {
                // Arrange
                DataLakeFileClient file = await directoryClient.CreateFileAsync(fileName);

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
        }

        [Test]
        public async Task GetPropertiesAsync_PathIdentitySAS()
        {
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            string fileName = GetNewFileName();
            using (GetNewDirectory(out DataLakeDirectoryClient directoryClient, fileSystemName: fileSystemName, directoryName: directoryName))
            {
                // Arrange
                DataLakeFileClient file = await directoryClient.CreateFileAsync(fileName);

                Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                    start: null,
                    expiry: Recording.UtcNow.AddHours(1));

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
            }
        }

        [Test]
        public async Task GetPropertiesAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                using (GetNewFile(out DataLakeFileClient file))
                {
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
        }

        [Test]
        public async Task GetPropertiesAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                using (GetNewFile(out DataLakeFileClient file))
                {
                    // Arrange
                    parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                    DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                    // Act
                    Assert.CatchAsync<Exception>(
                        async () =>
                        {
                            var _ = (await file.GetPropertiesAsync(
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
                DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    file.GetPropertiesAsync(),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task SetHttpHeadersAsync()
        {
            var constants = new TestConstants(this);
            using (GetNewFile(out DataLakeFileClient file))
            {
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
        }

        [Test]
        public async Task SetHttpHeadersAsync_Error()
        {
            var constants = new TestConstants(this);
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));

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
                    DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());

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
                    DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());

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
        }

        [Test]
        public async Task SetMetadataAsync()
        {
            using (GetNewFile(out DataLakeFileClient file))
            {
                // Arrange
                IDictionary<string, string> metadata = BuildMetadata();

                // Act
                await file.SetMetadataAsync(metadata);

                // Assert
                Response<PathProperties> response = await file.GetPropertiesAsync();
                AssertMetadataEquality(metadata, response.Value.Metadata, isDirectory: false);
            }
        }

        [Test]
        public async Task SetMetadataAsync_Error()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));
                IDictionary<string, string> metadata = BuildMetadata();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    file.SetMetadataAsync(metadata),
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
                    DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());
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
                    DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());
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
        }

        [Test]
        public async Task AppendDataAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));
                await file.CreateAsync();
                var data = GetRandomBuffer(Size);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await file.AppendAsync(stream, 0);
                }
            }
        }

        [Test]
        public async Task AppendDataAsync_ContentHash()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));
                await file.CreateAsync();
                var data = GetRandomBuffer(Size);
                byte[] contentHash = MD5.Create().ComputeHash(data);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await file.AppendAsync(stream, 0, contentHash: contentHash);
                }
            }
        }

        [Test]
        public async Task AppendDataAsync_Error()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));
                var data = GetRandomBuffer(Size);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        file.AppendAsync(stream, 0),
                         e => Assert.AreEqual("PathNotFound", e.ErrorCode));
                }
            }
        }

        [Test]
        public async Task AppendDataAsync_Position()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));
                await file.CreateAsync();
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
                Response<FileDownloadInfo> response = await file.ReadAsync(new HttpRange(Constants.KB, Constants.KB));
                Assert.AreEqual(data1.Length, response.Value.ContentLength);
                var actual = new MemoryStream();
                await response.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data1, actual.ToArray());
            }
        }

        [Test]
        public async Task AppendDataAsync_Lease()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));
                await file.CreateAsync();
                var data = GetRandomBuffer(Size);
                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);
                Response<DataLakeLease> response = await InstrumentClient(file.GetDataLakeLeaseClient(leaseId)).AcquireAsync(duration);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await file.AppendAsync(stream, 0, leaseId: response.Value.LeaseId);
                }
            }
        }

        [Test]
        public async Task AppendDataAsync_InvalidLease()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));
                await file.CreateAsync();
                var data = GetRandomBuffer(Size);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        file.AppendAsync(stream, 0, leaseId: Recording.Random.NewGuid().ToString()),
                         e => Assert.AreEqual("LeaseNotPresent", e.ErrorCode));
                }
            }
        }

        [Test]
        public async Task FlushDataAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));
                await file.CreateAsync();
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
        }

        [Test]
        public async Task FlushDataAsync_HttpHeaders()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));
                await file.CreateAsync();
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

                // Act
                await file.FlushAsync(Constants.KB, httpHeaders: headers);

                // Assert
                Response<PathProperties> response = await file.GetPropertiesAsync();
                Assert.AreEqual(ContentType, response.Value.ContentType);
                Assert.AreEqual(ContentEncoding, response.Value.ContentEncoding);
                Assert.AreEqual(ContentLanguage, response.Value.ContentLanguage);
                Assert.AreEqual(ContentDisposition, response.Value.ContentDisposition);
                Assert.AreEqual(CacheControl, response.Value.CacheControl);
                TestHelper.AssertSequenceEqual(contentHash, response.Value.ContentHash);
            }
        }

        [Test]
        public async Task FlushDataAsync_Position()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));
                await file.CreateAsync();
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
        }

        [Test]
        public async Task FlushDataAsync_RetainUncommittedData()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));
                await file.CreateAsync();
                var data = GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    await file.AppendAsync(stream, Constants.KB);
                }

                // Act
                Response<PathInfo> response = await file.FlushAsync(0, retainUncommittedData: true);

                // Assert
                AssertValidStoragePathInfo(response.Value);
            }
        }

        [Test]
        public async Task FlushDataAsync_Close()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));
                await file.CreateAsync();
                var data = GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    await file.AppendAsync(stream, Constants.KB);
                }

                // Act
                Response<PathInfo> response = await file.FlushAsync(0, close: true);

                // Assert
                AssertValidStoragePathInfo(response.Value);
            }
        }

        [Test]
        public async Task FlushDataAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));
                    await file.CreateAsync();
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

                    // Act
                    await file.FlushAsync(Constants.KB, conditions: conditions);
                }
            }
        }

        [Test]
        public async Task FlushDataAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));
                    await file.CreateAsync();
                    var data = GetRandomBuffer(Size);

                    using (var stream = new MemoryStream(data))
                    {
                        await file.AppendAsync(stream, 0);
                    }

                    parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                    DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        file.FlushAsync(Constants.KB, conditions: conditions),
                        e => { });
                }
            }
        }

        [Test]
        public async Task FlushDataAsync_Error()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    file.FlushAsync(0),
                     e => Assert.AreEqual("PathNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task ReadAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                DataLakeFileClient fileClient = await fileSystem.CreateFileAsync(GetNewFileName());
                using (var stream = new MemoryStream(data))
                {
                    await fileClient.AppendAsync(stream, 0);
                }

                await fileClient.FlushAsync(Constants.KB);

                // Act
                Response<FileDownloadInfo> response = await fileClient.ReadAsync();

                // Assert
                Assert.AreEqual(data.Length, response.Value.ContentLength);
                Assert.IsNotNull(response.Value.Properties.ContentRange);
                Assert.IsNotNull(response.Value.Properties.LastModified);
                Assert.IsNotNull(response.Value.Properties.AcceptRanges);
                Assert.IsNotNull(response.Value.Properties.ETag);
                Assert.IsNotNull(response.Value.Properties.LeaseStatus);
                Assert.IsNotNull(response.Value.Properties.LeaseState);
                Assert.IsNotNull(response.Value.Properties.IsServerEncrypted);

                var actual = new MemoryStream();
                await response.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }
        }

        [Test]
        public async Task ReadAsync_Range()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                DataLakeFileClient fileClient = await fileSystem.CreateFileAsync(GetNewFileName());
                using (var stream = new MemoryStream(data))
                {
                    await fileClient.AppendAsync(stream, 0);
                }

                await fileClient.FlushAsync(Constants.KB);
                HttpRange httpRange = new HttpRange(256, 512);

                // Act
                Response<FileDownloadInfo> response = await fileClient.ReadAsync(
                    range: httpRange,
                    rangeGetContentHash: true);

                // Assert
                var actual = new MemoryStream();
                await response.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data.Skip(256).Take(512).ToArray(), actual.ToArray());
            }
        }

        [Test]
        public async Task ReadAsync_RangeGetContentHash()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                var data = GetRandomBuffer(Constants.KB);
                DataLakeFileClient fileClient = await fileSystem.CreateFileAsync(GetNewFileName());
                using (var stream = new MemoryStream(data))
                {
                    await fileClient.AppendAsync(stream, 0);
                }

                await fileClient.FlushAsync(Constants.KB);
                HttpRange httpRange = new HttpRange(0, 1024);

                // Act
                Response<FileDownloadInfo> response = await fileClient.ReadAsync(
                    range: httpRange,
                    rangeGetContentHash: true);

                // Assert
                Assert.IsNotNull(response.Value.ContentHash);
            }
        }

        [Test]
        public async Task ReadAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    var data = GetRandomBuffer(Constants.KB);
                    DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());
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
                    Response<FileDownloadInfo> response = await file.ReadAsync(
                        conditions: conditions);

                    // Assert
                    Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
                }
            }
        }

        [Test]
        public async Task ReadAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    var data = GetRandomBuffer(Constants.KB);
                    DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());
                    using (var stream = new MemoryStream(data))
                    {
                        await file.AppendAsync(stream, 0);
                    }

                    await file.FlushAsync(Constants.KB);

                    parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                    DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(parameters);

                    // Act
                    Assert.CatchAsync<Exception>(
                        async () =>
                        {
                            var _ = (await file.ReadAsync(
                                conditions: conditions)).Value;
                        });
                }
            }
        }

        [Test]
        public async Task ReadAsync_Error()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    file.ReadAsync(),
                     e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task AcquireLeaseAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                // Act
                Response<DataLakeLease> response = await InstrumentClient(file.GetDataLakeLeaseClient(leaseId)).AcquireAsync(duration);

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
                    DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());

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
        }

        [Test]
        public async Task AcquireLeaseAsync_ConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_ConditionsFail_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());

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
        }

        [Test]
        public async Task AcquireLeaseAsync_Error()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));
                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(file.GetDataLakeLeaseClient(leaseId)).AcquireAsync(duration),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task RenewLeaseAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                DataLakeLeaseClient lease = InstrumentClient(file.GetDataLakeLeaseClient(leaseId));
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
                    DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());

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
        }

        [Test]
        public async Task RenewLeaseAsync_ConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_ConditionsFail_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());

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
        }

        [Test]
        public async Task RenewLeaseAsync_Error()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));
                var leaseId = Recording.Random.NewGuid().ToString();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(file.GetDataLakeLeaseClient(leaseId)).ReleaseAsync(),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task ReleaseLeaseAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                DataLakeLeaseClient lease = InstrumentClient(file.GetDataLakeLeaseClient(leaseId));
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
                    DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());

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
        }

        [Test]
        public async Task ReleaseLeaseAsync_ConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_ConditionsFail_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());

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
        }

        [Test]
        public async Task ReleaseLeaseAsync_Error()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));
                var leaseId = Recording.Random.NewGuid().ToString();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(file.GetDataLakeLeaseClient(leaseId)).RenewAsync(),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task ChangeLeaseAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var newLeaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                DataLakeLeaseClient lease = InstrumentClient(file.GetDataLakeLeaseClient(leaseId));
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
                    DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());

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
        }

        [Test]
        public async Task ChangeLeaseAsync_ConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_ConditionsFail_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());

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
        }

        [Test]
        public async Task ChangeLeaseAsync_Error()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));
                var leaseId = Recording.Random.NewGuid().ToString();
                var newLeaseId = Recording.Random.NewGuid().ToString();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(file.GetDataLakeLeaseClient(leaseId)).ChangeAsync(proposedId: newLeaseId),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }

        [Test]
        public async Task BreakLeaseAsync()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());

                var leaseId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                DataLakeLeaseClient lease = InstrumentClient(file.GetDataLakeLeaseClient(leaseId));
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
                    DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());

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
        }

        [Test]
        public async Task BreakLeaseAsync_ConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_ConditionsFail_Data)
            {
                using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
                {
                    // Arrange
                    DataLakeFileClient file = await fileSystem.CreateFileAsync(GetNewFileName());

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
        }

        [Test]
        public async Task BreakLeaseAsync_Error()
        {
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem))
            {
                // Arrange
                DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(file.GetDataLakeLeaseClient()).BreakAsync(),
                    e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
            }
        }
    }
}
