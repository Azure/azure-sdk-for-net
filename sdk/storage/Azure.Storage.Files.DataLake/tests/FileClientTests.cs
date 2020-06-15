﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using NUnit.Framework;

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

        [Test]
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
        }

        [Test]
        public async Task Ctor_TokenCredential()
        {
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            string fileName = GetNewFileName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);

            // Arrange
            await directory.CreateFileAsync(fileName);

            TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{directoryName}/{fileName}").ToHttps();
            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(uri, tokenCredential, GetOptions()));

            // Act
            await fileClient.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(fileName, fileClient.Name);
            Assert.AreEqual(fileSystemName, fileClient.FileSystemName);
            Assert.AreEqual($"{directoryName}/{fileName}", fileClient.Path);
            Assert.AreEqual(uri, fileClient.Uri);
        }

        [Test]
        public void Ctor_TokenCredential_Http()
        {
            // Arrange
            TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
            Uri uri = new Uri(TestConfigHierarchicalNamespace.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new DataLakeFileClient(uri, tokenCredential),
                new ArgumentException("Cannot use TokenCredential without HTTPS."));

            TestHelper.AssertExpectedException(
                () => new DataLakeFileClient(uri, tokenCredential, new DataLakeClientOptions()),
                new ArgumentException("Cannot use TokenCredential without HTTPS."));
        }

        [Test]
        public async Task CreateAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            Response<PathInfo> response = await file.CreateAsync();

            // Assert
            AssertValidStoragePathInfo(response.Value);

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
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode));
        }

        [Test]
        public async Task CreateAsync_HttpHeaders()
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

        [Test]
        public async Task CreateAsync_Metadata()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            await file.CreateAsync(metadata: metadata);

            // Assert
            Response<PathProperties> getPropertiesResponse = await file.GetPropertiesAsync();
            AssertMetadataEquality(metadata, getPropertiesResponse.Value.Metadata, isDirectory: false);
        }

        [Test]
        public async Task CreateAsync_PermissionAndUmask()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            string permissions = "0777";
            string umask = "0057";

            // Act
            await file.CreateAsync(
                permissions: permissions,
                umask: umask);

            // Assert
            Response<PathAccessControl> response = await file.GetAccessControlAsync();
            AssertPathPermissionsEquality(PathPermissions.ParseSymbolicPermissions("rwx-w----"), response.Value.Permissions);
        }

        [Test]
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

                // Act
                Response<PathInfo> response = await file.CreateAsync(
                    conditions: conditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
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

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    file.CreateAsync(conditions: conditions),
                    e => { });
            }
        }

        [Test]
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

        [Test]
        public async Task CreateIfNotExistsAsync_Exists()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync();

            // Act
            Response<PathInfo> response = await file.CreateIfNotExistsAsync();

            // Assert
            Assert.IsNull(response);
        }

        [Test]
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
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode));
        }

        [Test]
        public async Task ExistsAsync_Exists()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync();

            // Act
            Response<bool> response = await file.ExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);
        }

        [Test]
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

        [Test]
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
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        public async Task DeleteIfExists_Exists()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync();

            // Act
            Response<bool> response = await file.DeleteIfExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);
        }

        [Test]
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

        [Test]
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
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode));
        }


        [Test]
        public async Task DeleteAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            DataLakeFileClient fileClient = await directory.CreateFileAsync(GetNewFileName());

            // Act
            await fileClient.DeleteAsync();
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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
                startsOn: null,
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

        private void AssertSasUserDelegationKey(Uri uri, UserDelegationKey key)
        {
            DataLakeSasQueryParameters sas = new DataLakeUriBuilder(uri).Sas;
            Assert.AreEqual(key.SignedObjectId, sas.KeyObjectId);
            Assert.AreEqual(key.SignedExpiresOn, sas.KeyExpiresOn);
            Assert.AreEqual(key.SignedService, sas.KeyService);
            Assert.AreEqual(key.SignedStartsOn, sas.KeyStartsOn);
            Assert.AreEqual(key.SignedTenantId, sas.KeyTenantId);
            Assert.AreEqual(key.SignedVersion, sas.Version);
        }

        [Test]
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

        [Test]
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
                startsOn: null,
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

        [Test]
        public async Task GetAccessControlAsync_Error()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.GetAccessControlAsync(),
                e => Assert.AreEqual("404", e.ErrorCode));
        }

        [Test]
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
        [Test]
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
        [Test]
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

        [Test]
        public async Task SetAccessControlAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

            // Act
            Response<PathInfo> response = await file.SetAccessControlListAsync(AccessControlList);

            // Assert
            AssertValidStoragePathInfo(response);
        }

        [Test]
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

        [Test]
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

        [Test]
        public async Task SetPermissionsAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

            // Act
            Response<PathInfo> response = await file.SetPermissionsAsync(permissions: PathPermissions);

            // Assert
            AssertValidStoragePathInfo(response);
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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
                startsOn: null,
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

        [Test]
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

        [Test]
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
                startsOn: null,
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public async Task SetHttpHeadersAsync()
        {
            var constants = new TestConstants(this);

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

        [Test]
        public async Task SetHttpHeadersAsync_Error()
        {
            var constants = new TestConstants(this);

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

        [Test]
        public async Task SetHttpHeadersAsync_Conditions()
        {
            var constants = new TestConstants(this);
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

        [Test]
        public async Task SetHttpHeadersAsync_ConditionsFail()
        {
            var constants = new TestConstants(this);
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public async Task AppendDataAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateAsync();
            var data = GetRandomBuffer(Size);

            // Act
            using (var stream = new MemoryStream(data))
            {
                await file.AppendAsync(stream, 0);
            }
        }

        [Test]
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
                        Assert.AreEqual("Content-Length", e.Data["HeaderName"]);
                        Assert.AreEqual("0", e.Data["HeaderValue"]);
                    });
            }
        }

        [Test]
        public async Task AppendDataAsync_ProgressReporting()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateAsync();
            var data = GetRandomBuffer(Size);
            TestProgress progress = new TestProgress();

            // Act
            using (var stream = new MemoryStream(data))
            {
                await file.AppendAsync(stream, 0, progressHandler: progress);
            }

            // Assert
            Assert.IsFalse(progress.List.Count == 0);

            Assert.AreEqual(Size, progress.List[progress.List.Count - 1]);

        }

        [Test]
        public async Task AppendDataAsync_ContentHash()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateAsync();
            var data = GetRandomBuffer(Size);
            byte[] contentHash = MD5.Create().ComputeHash(data);

            // Act
            using (var stream = new MemoryStream(data))
            {
                await file.AppendAsync(stream, 0, contentHash: contentHash);
            }
        }

        [Test]
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

        [Test]
        public async Task AppendDataAsync_Position()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
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

        [Test]
        public async Task AppendDataAsync_Lease()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
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

        [Test]
        public async Task AppendDataAsync_InvalidLease()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
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

        [Test]
        public async Task AppendDataAsync_NullStream_Error()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateAsync();

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


        [Test]
        public async Task FlushDataAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
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

        [Test]
        public async Task FlushDataAsync_HttpHeaders()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
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

        [Test]
        public async Task FlushDataAsync_Position()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
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

        [Test]
        public async Task FlushDataAsync_RetainUncommittedData()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
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

        [Test]
        public async Task FlushDataAsync_Close()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
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

        [Test]
        public async Task FlushDataAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
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

        [Test]
        public async Task FlushDataAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
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

        [Test]
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

        [Test]
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

            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [Test]
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
                rangeGetContentHash: true);

            // Assert
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data.Skip(256).Take(512).ToArray(), actual.ToArray());
        }

        [Test]
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
                rangeGetContentHash: true);

            // Assert
            Assert.IsNotNull(response.Value.ContentHash);

        }

        [Test]
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
                Response<FileDownloadInfo> response = await file.ReadAsync(
                    conditions: conditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
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
                        var _ = (await file.ReadAsync(
                            conditions: conditions)).Value;
                    });
            }
        }

        [Test]
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

        [Test]
        public async Task AcquireLeaseAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());

            var leaseId = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            // Act
            Response<DataLakeLease> response = await InstrumentClient(file.GetDataLakeLeaseClient(leaseId)).AcquireAsync(duration);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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
                    new DataLakeRequestConditions() { IfModifiedSince = default }));

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

        [Test]
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
                    new DataLakeRequestConditions() { IfModifiedSince = default });
                Verify(resultStream);
            }

            void Verify(MemoryStream resultStream)
            {
                Assert.AreEqual(data.Length, resultStream.Length);
                TestHelper.AssertSequenceEqual(data, resultStream.ToArray());
            }
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public async Task UploadAsync_MinFile()
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public async Task GetFileClient_FromFileSystemAsciiName()
        {
            //Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            string fileName = GetNewFileName();

            //Act
            DataLakeFileClient file = test.FileSystem.GetFileClient(fileName);
            await file.CreateAsync();

            //Assert
            List<string> names = new List<string>();
            await foreach (PathItem pathItem in test.FileSystem.GetPathsAsync(recursive: true))
            {
                names.Add(pathItem.Name);
            }
            // Verify the file name exists in the filesystem
            Assert.AreEqual(1, names.Count);
            Assert.Contains(fileName, names);
        }

        [Test]
        public async Task GetFileClient_FromFileSystemNonAsciiName()
        {
            //Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            string fileName = GetNewNonAsciiFileName();

            //Act
            DataLakeFileClient file = test.FileSystem.GetFileClient(fileName);
            await file.CreateAsync();

            //Assert
            List<string> names = new List<string>();
            await foreach (PathItem pathItem in test.FileSystem.GetPathsAsync(recursive: true))
            {
                names.Add(pathItem.Name);
            }
            // Verify the file name exists in the filesystem
            Assert.AreEqual(1, names.Count);
            Assert.Contains(fileName, names);
        }

        [Test]
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

            //Assert
            List<string> names = new List<string>();
            await foreach (PathItem pathItem in test.FileSystem.GetPathsAsync(recursive: true))
            {
                names.Add(pathItem.Name);
            }
            // Verify the file name exists in the filesystem
            string fullPathName = string.Join("/", directoryName, fileName);
            Assert.AreEqual(2, names.Count);
            Assert.Contains(fullPathName, names);
        }

        [Test]
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

            //Assert
            List<string> names = new List<string>();
            await foreach (PathItem pathItem in test.FileSystem.GetPathsAsync(recursive: true))
            {
                names.Add(pathItem.Name);
            }
            // Verify the file name exists in the filesystem
            string fullPathName = string.Join("/", directoryName, fileName);
            Assert.AreEqual(2, names.Count);
            Assert.Contains(fullPathName, names);
        }
    }
}
