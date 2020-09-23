﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Sas;
using Azure.Storage.Test;
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

        [Test]
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

        [Test]
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
        }

        [Test]
        public async Task Ctor_TokenCredential()
        {
            string fileSystemName = GetNewFileSystemName();
            string parentDirectoryName = GetNewDirectoryName();
            string directoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient parentDirectory = await test.FileSystem.CreateDirectoryAsync(parentDirectoryName);

            // Arrange
            await parentDirectory.CreateSubDirectoryAsync(directoryName);

            TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{parentDirectoryName}/{directoryName}").ToHttps();
            DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(uri, tokenCredential, GetOptions()));

            // Act
            await directoryClient.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(directoryName, directoryClient.Name);
            Assert.AreEqual(fileSystemName, directoryClient.FileSystemName);
            Assert.AreEqual($"{parentDirectoryName}/{directoryName}", directoryClient.Path);
            Assert.AreEqual(uri, directoryClient.Uri);
        }

        [Test]
        public void Ctor_TokenCredential_Http()
        {
            // Arrange
            TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
            Uri uri = new Uri(TestConfigHierarchicalNamespace.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new DataLakeDirectoryClient(uri, tokenCredential),
                new ArgumentException("Cannot use TokenCredential without HTTPS."));

            TestHelper.AssertExpectedException(
                () => new DataLakeDirectoryClient(uri, tokenCredential, new DataLakeClientOptions()),
                new ArgumentException("Cannot use TokenCredential without HTTPS."));
        }

        [Test]
        public async Task CreateAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            var name = GetNewDirectoryName();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(name));

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
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode));
        }

        [Test]
        public async Task CreateAsync_HttpHeaders()
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

        [Test]
        public async Task CreateAsync_Metadata()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await directory.CreateAsync(metadata: metadata);

            // Assert
            Response<PathProperties> getPropertiesResponse = await directory.GetPropertiesAsync();
            AssertMetadataEquality(metadata, getPropertiesResponse.Value.Metadata, isDirectory: true);
        }

        [Test]
        public async Task CreateAsync_PermissionAndUmask()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            string permissions = "0777";
            string umask = "0057";

            // Act
            await directory.CreateAsync(
                permissions: permissions,
                umask: umask);

            // Assert
            Response<PathAccessControl> response = await directory.GetAccessControlAsync();
            AssertPathPermissionsEquality(PathPermissions.ParseSymbolicPermissions("rwx-w----"), response.Value.Permissions);
        }

        [Test]
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

                // Act
                Response<PathInfo> response = await directory.CreateAsync(
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

                // Arrange
                // This directory is intentionally created twice
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
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

        [Test]
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

        [Test]
        public async Task CreateIfNotExistsAsync_Exists()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            await directory.CreateAsync();

            // Act
            Response<PathInfo> response = await directory.CreateIfNotExistsAsync();

            // Assert
            Assert.IsNull(response);
        }

        [Test]
        public async Task CreateIfNotExistsAsync_Error()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient unauthorizedDirecotry = InstrumentClient(new DataLakeDirectoryClient(directory.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedDirecotry.CreateIfNotExistsAsync(),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode));
        }

        [Test]
        public async Task ExistsAsync_Exists()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            await directory.CreateAsync();

            // Act
            Response<bool> response = await directory.ExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);
        }

        [Test]
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

        [Test]
        public async Task ExistsAsync_FileSystemNotExists()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystemClient = service.GetFileSystemClient(GetNewFileSystemName());
            DataLakeDirectoryClient directory = InstrumentClient(fileSystemClient.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            Response<bool> response = await directory.ExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [Test]
        public async Task ExistsAsync_Error()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem(publicAccessType: PublicAccessType.None);
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            DataLakeDirectoryClient unauthorizedDirectory = InstrumentClient(new DataLakeDirectoryClient(directory.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedDirectory.ExistsAsync(),
                e => Assert.AreEqual("NoAuthenticationInformation", e.ErrorCode));
        }

        [Test]
        public async Task DeleteIfExists_Exists()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            await directory.CreateAsync();

            // Act
            Response<bool> response = await directory.DeleteIfExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);

            // Act
            response = await directory.DeleteIfExistsAsync();
        }

        [Test]
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

        [Test]
        public async Task DeleteIfExistsAsync_FileSystemNotExists()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystemClient = service.GetFileSystemClient(GetNewFileSystemName());
            DataLakeDirectoryClient directory = InstrumentClient(fileSystemClient.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            Response<bool> response = await directory.DeleteIfExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [Test]
        public async Task DeleteIfNotExistsAsync_Error()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            DataLakeFileClient unauthorizedDirectory = InstrumentClient(new DataLakeFileClient(directory.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedDirectory.DeleteIfExistsAsync(),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode));
        }

        [Test]
        public async Task DeleteAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            var name = GetNewDirectoryName();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(name));
            await directory.CreateAsync();

            // Act
            Response response = await directory.DeleteAsync();
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        [TestCase("!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("%21%27%28%29%3B%5B%5D%40%26%25%3D%2B%24%2C%23äÄöÖüÜß%3B")]
        [TestCase(" my cool directory ")]
        [TestCase("directory")]
        public async Task RenameAsync_DestinationSpecialCharacters(string destDirectoryName)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeDirectoryClient sourceDirectory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            Uri expectedDestDirectoryUri = new Uri($"https://{test.FileSystem.AccountName}.dfs.core.windows.net/{test.FileSystem.Name}/{Uri.EscapeDataString(destDirectoryName)}");

            // Act
            DataLakeDirectoryClient destDirectory = await sourceDirectory.RenameAsync(destinationPath: destDirectoryName);

            // Assert
            Response<PathProperties> response = await destDirectory.GetPropertiesAsync();
            Assert.AreEqual(destDirectoryName, destDirectory.Name);
            Assert.AreEqual(destDirectoryName, destDirectory.Path);
            Assert.AreEqual(expectedDestDirectoryUri, destDirectory.Uri);
        }

        [Test]
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
            Uri expectedDestDirectoryUri = new Uri($"https://{test.FileSystem.AccountName}.dfs.core.windows.net/{test.FileSystem.Name}/{destDirectoryName}");

            // Act
            DataLakeDirectoryClient destDirectory = await sourceDirectory.RenameAsync(destinationPath: destDirectoryName);

            // Assert
            Response<PathProperties> response = await destDirectory.GetPropertiesAsync();
            Assert.AreEqual(destDirectoryName, destDirectory.Name);
            Assert.AreEqual(destDirectoryName, destDirectory.Path);
            Assert.AreEqual(expectedDestDirectoryUri, destDirectory.Uri);
        }

        [Test]
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

        [Test]
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

        [Test]
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


        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public async Task GetAccessControlAsync_Error()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.GetAccessControlAsync(),
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
        [Test]
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

        [Test]
        public async Task SetAccessControlAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Act
            Response<PathInfo> response = await directory.SetAccessControlListAsync(AccessControlList);

            // Assert
            AssertValidStoragePathInfo(response);
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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
            Assert.IsNull(result.ContinuationToken);
        }

        [Test]
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
                progressHandler: null,
                options: options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(4, result.Counters.ChangedFilesCount);
            Assert.AreEqual(0, result.Counters.FailedChangesCount);
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

            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                BatchSize = 2
            };

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            AccessControlChanges intermediateResult = default;

            // Act
            try
            {
                await directory.SetAccessControlRecursiveAsync(
                    AccessControlList,
                    new Progress<Response<AccessControlChanges>>(x =>
                    {
                        intermediateResult = x;
                        cancellationTokenSource.Cancel();
                    }),
                    options: options,
                    cancellationToken: cancellationTokenSource.Token);
            }
            catch (TaskCanceledException)
            {
                // skip
            }

            AccessControlChangeResult result = await directory.SetAccessControlRecursiveAsync(
                AccessControlList,
                progressHandler: null,
                continuationToken: intermediateResult.ContinuationToken,
                options: options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount + intermediateResult.BatchCounters.ChangedDirectoriesCount);
            Assert.AreEqual(4, result.Counters.ChangedFilesCount + intermediateResult.BatchCounters.ChangedFilesCount);
            Assert.AreEqual(0, result.Counters.FailedChangesCount + intermediateResult.BatchCounters.ChangedFilesCount);
            Assert.IsNull(result.ContinuationToken);
        }

        [Test]
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
                BatchSize = 2
            };

            // Act
            AccessControlChangeResult result = await directory.SetAccessControlRecursiveAsync(
                AccessControlList,
                progress,
                options: options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(4, result.Counters.ChangedFilesCount);
            Assert.AreEqual(0, result.Counters.FailedChangesCount);
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

        [Test]
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
                    progressHandler: null,
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

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetAccessControlRecursiveAsync_WithProgressMonitoring_WithFailure()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{topDirectoryName}").ToHttps();

            // Create tree as AAD App
            DataLakeDirectoryClient directory = InstrumentClient(new DataLakeDirectoryClient(uri, tokenCredential, GetOptions()));
            await directory.CreateAsync();
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Add file as superuser
            DataLakeFileClient file4 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateFileAsync(GetNewFileName());

            InMemoryAccessControlRecursiveChangeProgress progress = new InMemoryAccessControlRecursiveChangeProgress();

            // Act
            AccessControlChangeResult result = await directory.SetAccessControlRecursiveAsync(
                accessControlList: AccessControlList,
                progressHandler: progress);

            // Assert
            Assert.AreEqual(1, result.Counters.FailedChangesCount);
            Assert.AreEqual(1, progress.Failures.Count);
            Assert.That(progress.BatchCounters.FindIndex(x => x.FailedChangesCount > 0) >= 0);
            Assert.That(progress.CummulativeCounters.FindIndex(x => x.FailedChangesCount > 0) >= 0);
            AccessControlChangeFailure failure = progress.Failures[0];
            StringAssert.Contains(file4.Name, failure.Name);
            Assert.IsFalse(failure.IsDirectory);
            Assert.That(failure.ErrorMessage, Is.Not.Null.Or.Empty);
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetAccessControlRecursiveAsync_ContinueOnFailure()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{topDirectoryName}").ToHttps();

            // Create tree as AAD App
            DataLakeDirectoryClient directory = InstrumentClient(new DataLakeDirectoryClient(uri, tokenCredential, GetOptions()));
            await directory.CreateAsync();
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Add file as superuser
            DataLakeFileClient file4 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateFileAsync(GetNewFileName());
            DataLakeFileClient file5 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateFileAsync(GetNewFileName());
            DataLakeFileClient file6 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateFileAsync(GetNewFileName());
            // Add directory as superuser
            DataLakeDirectoryClient subdirectory3 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateSubDirectoryAsync(GetNewDirectoryName());

            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                ContinueOnFailure = true
            };

            // Act
            AccessControlChangeResult result = await directory.SetAccessControlRecursiveAsync(
                accessControlList: AccessControlList,
                progressHandler: null,
                options: options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(3, result.Counters.ChangedFilesCount);
            Assert.AreEqual(4, result.Counters.FailedChangesCount);
            Assert.IsNull(result.ContinuationToken);
        }

        [Test]
        [LiveOnly]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetAccessControlRecursiveAsync_ContinueOnFailure_Batches_StopAndResume()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{topDirectoryName}").ToHttps();

            // Create tree as AAD App
            DataLakeDirectoryClient directory = InstrumentClient(new DataLakeDirectoryClient(uri, tokenCredential, GetOptions()));
            await directory.CreateAsync();
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Add files as superuser
            DataLakeFileClient file4 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateFileAsync(GetNewFileName());
            DataLakeFileClient file5 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateFileAsync(GetNewFileName());
            DataLakeFileClient file6 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateFileAsync(GetNewFileName());
            // Add directory as superuser
            DataLakeDirectoryClient subdirectory3 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateSubDirectoryAsync(GetNewDirectoryName());

            // Add files and a directory as AAD app
            DataLakeFileClient file7 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file8 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory4 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file9 = await subdirectory4.CreateFileAsync(GetNewFileName());

            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                BatchSize = 2,
                ContinueOnFailure = true
            };

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            AccessControlChanges intermediateResult = default;

            // Act
            try
            {
                await directory.SetAccessControlRecursiveAsync(
                    accessControlList: AccessControlList,
                    progressHandler: new Progress<Response<AccessControlChanges>>(x =>
                    {
                        intermediateResult = x;
                        cancellationTokenSource.Cancel();
                    }),
                    options: options,
                    cancellationToken: cancellationTokenSource.Token);
            }
            catch (TaskCanceledException)
            {
                // skip
            }

            // Assert
            Assert.IsNotNull(intermediateResult.ContinuationToken);

            // Act
            AccessControlChangeResult result = await directory.SetAccessControlRecursiveAsync(
                accessControlList: AccessControlList,
                progressHandler: null,
                options: options,
                continuationToken: intermediateResult.ContinuationToken);

            // Assert
            Assert.AreEqual(4, result.Counters.ChangedDirectoriesCount + intermediateResult.BatchCounters.ChangedDirectoriesCount);
            Assert.AreEqual(6, result.Counters.ChangedFilesCount + intermediateResult.BatchCounters.ChangedFilesCount);
            Assert.AreEqual(4, result.Counters.FailedChangesCount + intermediateResult.BatchCounters.FailedChangesCount);
            Assert.IsNull(result.ContinuationToken);
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task SetAccessControlRecursiveAsync_Error()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{topDirectoryName}").ToHttps();

            // Create tree as AAD App
            DataLakeDirectoryClient directory = InstrumentClient(new DataLakeDirectoryClient(uri, tokenCredential, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.SetAccessControlRecursiveAsync(
                    accessControlList: AccessControlList,
                    progressHandler: null),
                    e => { });
        }

        [Test]
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
            Assert.IsNull(result.ContinuationToken);
        }

        [Test]
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
                progressHandler: null,
                options: options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(4, result.Counters.ChangedFilesCount);
            Assert.AreEqual(0, result.Counters.FailedChangesCount);
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

            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                BatchSize = 2
            };

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            AccessControlChanges intermediateResult = default;

            // Act
            try
            {
                await directory.UpdateAccessControlRecursiveAsync(
                    AccessControlList,
                    new Progress<Response<AccessControlChanges>>(x =>
                    {
                        intermediateResult = x;
                        cancellationTokenSource.Cancel();
                    }),
                    options: options,
                    cancellationToken: cancellationTokenSource.Token);
            }
            catch (TaskCanceledException)
            {
                // skip
            }

            AccessControlChangeResult result = await directory.UpdateAccessControlRecursiveAsync(
                AccessControlList,
                progressHandler: null,
                intermediateResult.ContinuationToken,
                options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount + intermediateResult.BatchCounters.ChangedDirectoriesCount);
            Assert.AreEqual(4, result.Counters.ChangedFilesCount + intermediateResult.BatchCounters.ChangedFilesCount);
            Assert.AreEqual(0, result.Counters.FailedChangesCount + intermediateResult.BatchCounters.ChangedFilesCount);
            Assert.IsNull(result.ContinuationToken);
        }

        [Test]
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
                BatchSize = 2
            };

            // Act
            AccessControlChangeResult result = await directory.UpdateAccessControlRecursiveAsync(
                AccessControlList,
                progress,
                options: options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(4, result.Counters.ChangedFilesCount);
            Assert.AreEqual(0, result.Counters.FailedChangesCount);
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

        [Test]
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
                    progressHandler: null,
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
            Assert.IsNull(result.ContinuationToken);
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UpdateAccessControlRecursiveAsync_WithProgressMonitoring_WithFailure()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{topDirectoryName}").ToHttps();

            // Create tree as AAD App
            DataLakeDirectoryClient directory = InstrumentClient(new DataLakeDirectoryClient(uri, tokenCredential, GetOptions()));
            await directory.CreateAsync();
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Add file as superuser
            DataLakeFileClient file4 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateFileAsync(GetNewFileName());

            InMemoryAccessControlRecursiveChangeProgress progress = new InMemoryAccessControlRecursiveChangeProgress();

            // Act
            AccessControlChangeResult result = await directory.UpdateAccessControlRecursiveAsync(
                accessControlList: AccessControlList,
                progressHandler: progress);

            // Assert
            Assert.AreEqual(1, result.Counters.FailedChangesCount);
            Assert.AreEqual(1, progress.Failures.Count);
            Assert.That(progress.BatchCounters.FindIndex(x => x.FailedChangesCount > 0) >= 0);
            Assert.That(progress.CummulativeCounters.FindIndex(x => x.FailedChangesCount > 0) >= 0);
            AccessControlChangeFailure failure = progress.Failures[0];
            StringAssert.Contains(file4.Name, failure.Name);
            Assert.IsFalse(failure.IsDirectory);
            Assert.That(failure.ErrorMessage, Is.Not.Null.Or.Empty);
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UpdateAccessControlRecursiveAsync_ContinueOnFailure()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{topDirectoryName}").ToHttps();

            // Create tree as AAD App
            DataLakeDirectoryClient directory = InstrumentClient(new DataLakeDirectoryClient(uri, tokenCredential, GetOptions()));
            await directory.CreateAsync();
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Add file as superuser
            DataLakeFileClient file4 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateFileAsync(GetNewFileName());
            DataLakeFileClient file5 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateFileAsync(GetNewFileName());
            DataLakeFileClient file6 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateFileAsync(GetNewFileName());
            // Add directory as superuser
            DataLakeDirectoryClient subdirectory3 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateSubDirectoryAsync(GetNewDirectoryName());

            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                ContinueOnFailure = true
            };

            // Act
            AccessControlChangeResult result = await directory.UpdateAccessControlRecursiveAsync(
                accessControlList: AccessControlList,
                progressHandler: null,
                options: options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(3, result.Counters.ChangedFilesCount);
            Assert.AreEqual(4, result.Counters.FailedChangesCount);
            Assert.IsNull(result.ContinuationToken);
        }

        [Test]
        [LiveOnly]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UpdateAccessControlRecursiveAsync_ContinueOnFailure_Batches_StopAndResume()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{topDirectoryName}").ToHttps();

            // Create tree as AAD App
            DataLakeDirectoryClient directory = InstrumentClient(new DataLakeDirectoryClient(uri, tokenCredential, GetOptions()));
            await directory.CreateAsync();
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Add files as superuser
            DataLakeFileClient file4 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateFileAsync(GetNewFileName());
            DataLakeFileClient file5 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateFileAsync(GetNewFileName());
            DataLakeFileClient file6 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateFileAsync(GetNewFileName());
            // Add directory as superuser
            DataLakeDirectoryClient subdirectory3 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateSubDirectoryAsync(GetNewDirectoryName());

            // Add files and a directory as AAD app
            DataLakeFileClient file7 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file8 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory4 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file9 = await subdirectory4.CreateFileAsync(GetNewFileName());

            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                BatchSize = 2,
                ContinueOnFailure = true
            };

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            AccessControlChanges intermediateResult = default;

            // Act
            try
            {
                await directory.UpdateAccessControlRecursiveAsync(
                    accessControlList: AccessControlList,
                    progressHandler: new Progress<Response<AccessControlChanges>>(x =>
                    {
                        intermediateResult = x;
                        cancellationTokenSource.Cancel();
                    }),
                    options: options,
                    cancellationToken: cancellationTokenSource.Token);
            }
            catch (TaskCanceledException)
            {
                // skip
            }

            // Assert
            Assert.IsNotNull(intermediateResult.ContinuationToken);

            // Act
            AccessControlChangeResult result = await directory.UpdateAccessControlRecursiveAsync(
                accessControlList: AccessControlList,
                progressHandler: null,
                options: options,
                continuationToken: intermediateResult.ContinuationToken);

            // Assert
            Assert.AreEqual(4, result.Counters.ChangedDirectoriesCount + intermediateResult.BatchCounters.ChangedDirectoriesCount);
            Assert.AreEqual(6, result.Counters.ChangedFilesCount + intermediateResult.BatchCounters.ChangedFilesCount);
            Assert.AreEqual(4, result.Counters.FailedChangesCount + intermediateResult.BatchCounters.FailedChangesCount);
            Assert.IsNull(result.ContinuationToken);
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UpdateAccessControlRecursiveAsync_Error()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{topDirectoryName}").ToHttps();

            // Create tree as AAD App
            DataLakeDirectoryClient directory = InstrumentClient(new DataLakeDirectoryClient(uri, tokenCredential, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.UpdateAccessControlRecursiveAsync(
                    accessControlList: AccessControlList,
                    progressHandler: null),
                    e => { });
        }

        [Test]
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
            Assert.IsNull(result.ContinuationToken);
        }

        [Test]
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
                progressHandler: null,
                options: options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(4, result.Counters.ChangedFilesCount);
            Assert.AreEqual(0, result.Counters.FailedChangesCount);
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

            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                BatchSize = 2
            };

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            AccessControlChanges intermediateResult = default;

            // Act
            try
            {
                await directory.RemoveAccessControlRecursiveAsync(
                    RemoveAccessControlList,
                    new Progress<Response<AccessControlChanges>>(x =>
                    {
                        intermediateResult = x;
                        cancellationTokenSource.Cancel();
                    }),
                    options: options,
                    cancellationToken: cancellationTokenSource.Token);
            }
            catch (TaskCanceledException)
            {
                // skip
            }

            AccessControlChangeResult result = await directory.RemoveAccessControlRecursiveAsync(
                RemoveAccessControlList,
                progressHandler: null,
                intermediateResult.ContinuationToken,
                options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount + intermediateResult.BatchCounters.ChangedDirectoriesCount);
            Assert.AreEqual(4, result.Counters.ChangedFilesCount + intermediateResult.BatchCounters.ChangedFilesCount);
            Assert.AreEqual(0, result.Counters.FailedChangesCount + intermediateResult.BatchCounters.ChangedFilesCount);
            Assert.IsNull(result.ContinuationToken);
        }

        [Test]
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
                BatchSize = 2
            };

            // Act
            AccessControlChangeResult result = await directory.RemoveAccessControlRecursiveAsync(
                RemoveAccessControlList,
                progress,
                options: options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(4, result.Counters.ChangedFilesCount);
            Assert.AreEqual(0, result.Counters.FailedChangesCount);
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

        [Test]
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
                    progressHandler: null,
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
            Assert.IsNull(result.ContinuationToken);
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task RemoveAccessControlRecursiveAsync_WithProgressMonitoring_WithFailure()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{topDirectoryName}").ToHttps();

            // Create tree as AAD App
            DataLakeDirectoryClient directory = InstrumentClient(new DataLakeDirectoryClient(uri, tokenCredential, GetOptions()));
            await directory.CreateAsync();
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Add file as superuser
            DataLakeFileClient file4 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateFileAsync(GetNewFileName());

            InMemoryAccessControlRecursiveChangeProgress progress = new InMemoryAccessControlRecursiveChangeProgress();

            // Act
            AccessControlChangeResult result = await directory.RemoveAccessControlRecursiveAsync(
                accessControlList: RemoveAccessControlList,
                progressHandler: progress);

            // Assert
            Assert.AreEqual(1, result.Counters.FailedChangesCount);
            Assert.AreEqual(1, progress.Failures.Count);
            Assert.That(progress.BatchCounters.FindIndex(x => x.FailedChangesCount > 0) >= 0);
            Assert.That(progress.CummulativeCounters.FindIndex(x => x.FailedChangesCount > 0) >= 0);
            AccessControlChangeFailure failure = progress.Failures[0];
            StringAssert.Contains(file4.Name, failure.Name);
            Assert.IsFalse(failure.IsDirectory);
            Assert.That(failure.ErrorMessage, Is.Not.Null.Or.Empty);
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task RemoveAccessControlRecursiveAsync_ContinueOnFailure()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{topDirectoryName}").ToHttps();

            // Create tree as AAD App
            DataLakeDirectoryClient directory = InstrumentClient(new DataLakeDirectoryClient(uri, tokenCredential, GetOptions()));
            await directory.CreateAsync();
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Add file as superuser
            DataLakeFileClient file4 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateFileAsync(GetNewFileName());
            DataLakeFileClient file5 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateFileAsync(GetNewFileName());
            DataLakeFileClient file6 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateFileAsync(GetNewFileName());
            // Add directory as superuser
            DataLakeDirectoryClient subdirectory3 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateSubDirectoryAsync(GetNewDirectoryName());

            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                ContinueOnFailure = true
            };

            // Act
            AccessControlChangeResult result = await directory.RemoveAccessControlRecursiveAsync(
                accessControlList: RemoveAccessControlList,
                progressHandler: null,
                options: options);

            // Assert
            Assert.AreEqual(3, result.Counters.ChangedDirectoriesCount);
            Assert.AreEqual(3, result.Counters.ChangedFilesCount);
            Assert.AreEqual(4, result.Counters.FailedChangesCount);
            Assert.IsNull(result.ContinuationToken);
        }

        [Test]
        [LiveOnly]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task RemoveAccessControlRecursiveAsync_ContinueOnFailure_Batches_StopAndResume()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{topDirectoryName}").ToHttps();

            // Create tree as AAD App
            DataLakeDirectoryClient directory = InstrumentClient(new DataLakeDirectoryClient(uri, tokenCredential, GetOptions()));
            await directory.CreateAsync();
            DataLakeDirectoryClient subdirectory1 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file1 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file2 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory2 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file3 = await subdirectory2.CreateFileAsync(GetNewFileName());

            // Add files as superuser
            DataLakeFileClient file4 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateFileAsync(GetNewFileName());
            DataLakeFileClient file5 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateFileAsync(GetNewFileName());
            DataLakeFileClient file6 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateFileAsync(GetNewFileName());
            // Add directory as superuser
            DataLakeDirectoryClient subdirectory3 = await test.FileSystem.GetDirectoryClient(directory.Name)
                .GetSubDirectoryClient(subdirectory2.Name)
                .CreateSubDirectoryAsync(GetNewDirectoryName());

            // Add files and a directory as AAD app
            DataLakeFileClient file7 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeFileClient file8 = await subdirectory1.CreateFileAsync(GetNewFileName());
            DataLakeDirectoryClient subdirectory4 = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file9 = await subdirectory4.CreateFileAsync(GetNewFileName());

            AccessControlChangeOptions options = new AccessControlChangeOptions()
            {
                BatchSize = 2,
                ContinueOnFailure = true
            };

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            AccessControlChanges intermediateResult = default;

            // Act
            try
            {
                await directory.RemoveAccessControlRecursiveAsync(
                    accessControlList: RemoveAccessControlList,
                    progressHandler: new Progress<Response<AccessControlChanges>>(x =>
                    {
                        intermediateResult = x;
                        cancellationTokenSource.Cancel();
                    }),
                    options: options,
                    cancellationToken: cancellationTokenSource.Token);
            }
            catch (TaskCanceledException)
            {
                // skip
            }

            // Assert
            Assert.IsNotNull(intermediateResult.ContinuationToken);

            // Act
            AccessControlChangeResult result = await directory.RemoveAccessControlRecursiveAsync(
                accessControlList: RemoveAccessControlList,
                progressHandler: null,
                options: options,
                continuationToken: intermediateResult.ContinuationToken);

            // Assert
            Assert.AreEqual(4, result.Counters.ChangedDirectoriesCount + intermediateResult.BatchCounters.ChangedDirectoriesCount);
            Assert.AreEqual(6, result.Counters.ChangedFilesCount + intermediateResult.BatchCounters.ChangedFilesCount);
            Assert.AreEqual(4, result.Counters.FailedChangesCount + intermediateResult.BatchCounters.FailedChangesCount);
            Assert.IsNull(result.ContinuationToken);
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task RemoveAccessControlRecursiveAsync_Error()
        {
            string fileSystemName = GetNewFileSystemName();
            string topDirectoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            await test.FileSystem.GetRootDirectoryClient().SetAccessControlListAsync(ExecuteOnlyAccessControlList);

            TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{topDirectoryName}").ToHttps();

            // Create tree as AAD App
            DataLakeDirectoryClient directory = InstrumentClient(new DataLakeDirectoryClient(uri, tokenCredential, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.RemoveAccessControlRecursiveAsync(
                    accessControlList: RemoveAccessControlList,
                    progressHandler: null),
                    e => { });
        }

        [Test]
        public async Task SetPermissionsAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Act
            Response<PathInfo> response = await directory.SetPermissionsAsync(permissions: PathPermissions);

            // Assert
            AssertValidStoragePathInfo(response);
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public async Task GetPropertiesAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Act
            Response<PathProperties> response = await directory.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            Assert.IsTrue(response.Value.IsDirectory);
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public async Task GetPropertiesAsync_PathSasWithIdentifiers()
        {
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            string signedIdentifierId = GetNewString();

            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient directoryClient = InstrumentClient(test.FileSystem.GetDirectoryClient(directoryName));
            await directoryClient.CreateAsync();

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
            Response<PathProperties> response = await sasDirectoryClient.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public async Task SetHttpHeadersAsync()
        {
            var constants = new TestConstants(this);

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

        [Test]
        public async Task SetHttpHeadersAsync_Error()
        {
            var constants = new TestConstants(this);

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

        [Test]
        public async Task SetHttpHeadersAsync_Conditions()
        {
            var constants = new TestConstants(this);
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

        [Test]
        public async Task SetHttpHeadersAsync_ConditionsFail()
        {
            var constants = new TestConstants(this);
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public async Task CreateFileAsync_Metadata()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            DataLakeFileClient file = await directory.CreateFileAsync(GetNewFileName(), metadata: metadata);

            // Assert
            Response<PathProperties> getPropertiesResponse = await file.GetPropertiesAsync();
            AssertMetadataEquality(metadata, getPropertiesResponse.Value.Metadata, isDirectory: false);
        }

        [Test]
        public async Task CreateFileAsync_PermissionAndUmask()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

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
            AssertPathPermissionsEquality(PathPermissions.ParseSymbolicPermissions("rwx-w----"), response.Value.Permissions);
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
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode));
        }

        [Test]
        public async Task DeleteFileAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            string fileName = GetNewFileName();
            DataLakeFileClient fileClient = directory.GetFileClient(fileName);
            await fileClient.CreateAsync();

            // Assert
            await directory.DeleteFileAsync(fileName);
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
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode));
        }

        [Test]
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
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode));
        }

        [Test]
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

        [Test]
        public async Task CreateSubDirectoryAsync_Metadata()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

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

        [Test]
        public async Task CreateSubDirectoryAsync_PermissionAndUmask()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

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
            AssertPathPermissionsEquality(PathPermissions.ParseSymbolicPermissions("rwx-w----"), response.Value.Permissions);
        }

        [Test]
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

                // Act
                Response<PathInfo> response = await subDirectory.CreateAsync(
                    conditions: conditions);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
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

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    subDirectory.CreateAsync(conditions: conditions),
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
            await directoryClient.CreateAsync();

            // Assert
            await directory.DeleteFileAsync(directoryName);
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public async Task GetDirectoryClientAsync_AsciiName()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            string directoryName = GetNewDirectoryName();
            DataLakeDirectoryClient directory = test.FileSystem.GetDirectoryClient(directoryName);
            await directory.CreateAsync();

            List<string> names = new List<string>();
            await foreach (PathItem pathItem in test.FileSystem.GetPathsAsync(recursive: true))
            {
                names.Add(pathItem.Name);
            }

            // Verify the file name exists in the filesystem
            Assert.AreEqual(1, names.Count);
            Assert.Contains(directoryName, names);
        }

        [Test]
        public async Task GetDirectoryClientAsync_NonAsciiName()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            string directoryName = GetNewNonAsciiDirectoryName();
            DataLakeDirectoryClient file = test.FileSystem.GetDirectoryClient(directoryName);
            await file.CreateAsync();

            List<string> names = new List<string>();
            await foreach (PathItem pathItem in test.FileSystem.GetPathsAsync(recursive: true))
            {
                names.Add(pathItem.Name);
            }

            // Verify the file name exists in the filesystem
            Assert.AreEqual(1, names.Count);
            Assert.Contains(directoryName, names);
        }

        [Test]
        public async Task GetSubDirectoryClientAsync_AsciiName()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            string directoryName = GetNewDirectoryName();
            string subDirectoryName = GetNewDirectoryName();
            string fullPathName = string.Join("/", directoryName, subDirectoryName);
            DataLakeDirectoryClient directory = test.FileSystem.GetDirectoryClient(directoryName);
            DataLakeDirectoryClient subdirectory = directory.GetSubDirectoryClient(subDirectoryName);

            await subdirectory.CreateAsync();

            List<string> names = new List<string>();
            await foreach (PathItem pathItem in test.FileSystem.GetPathsAsync(recursive: true))
            {
                names.Add(pathItem.Name);
            }

            // Verify the file name exists in the filesystem
            Assert.AreEqual(2, names.Count);
            Assert.Contains(fullPathName, names);
        }

        [Test]
        public async Task GetSubDirectoryClientAsync_NonAsciiName()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            string directoryName = GetNewDirectoryName();
            string subDirectoryName = GetNewNonAsciiDirectoryName();
            string fullPathName = string.Join("/", directoryName, subDirectoryName);
            DataLakeDirectoryClient directory = test.FileSystem.GetDirectoryClient(directoryName);
            DataLakeDirectoryClient subdirectory = directory.GetSubDirectoryClient(subDirectoryName);

            await subdirectory.CreateAsync();

            List<string> names = new List<string>();
            await foreach (PathItem pathItem in test.FileSystem.GetPathsAsync(recursive: true))
            {
                names.Add(pathItem.Name);
            }

            // Verify the file name exists in the filesystem
            Assert.AreEqual(2, names.Count);
            Assert.Contains(fullPathName, names);
        }

        [Test]
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
            Uri blobUri = new Uri($"https://{test.FileSystem.AccountName}.blob.core.windows.net/{test.FileSystem.Name}/{Uri.EscapeDataString(directoryName)}/{Uri.EscapeDataString(subDirectoryName)}");
            Uri dfsUri = new Uri($"https://{test.FileSystem.AccountName}.dfs.core.windows.net/{test.FileSystem.Name}/{Uri.EscapeDataString(directoryName)}/{Uri.EscapeDataString(subDirectoryName)}");
            string expectedPath = $"{directoryName}/{subDirectoryName}";

            // Act
            Response<PathInfo> createResponse = await subDirectory.CreateAsync();

            List<PathItem> pathItems = new List<PathItem>();
            await foreach (PathItem pathItem in test.FileSystem.GetPathsAsync(recursive: true))
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

        [Test]
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
            Uri blobUri = new Uri($"https://{test.FileSystem.AccountName}.blob.core.windows.net/{test.FileSystem.Name}/{Uri.EscapeDataString(directoryName)}/{Uri.EscapeDataString(fileName)}");
            Uri dfsUri = new Uri($"https://{test.FileSystem.AccountName}.dfs.core.windows.net/{test.FileSystem.Name}/{Uri.EscapeDataString(directoryName)}/{Uri.EscapeDataString(fileName)}");
            string expectedPath = $"{directoryName}/{fileName}";

            // Act
            Response<PathInfo> createResponse = await file.CreateAsync();

            List<PathItem> pathItems = new List<PathItem>();
            await foreach (PathItem pathItem in test.FileSystem.GetPathsAsync(recursive: true))
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

        [Test]
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

        [Test]
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
    }
}
