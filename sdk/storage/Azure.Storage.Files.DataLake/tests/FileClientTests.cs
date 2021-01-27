// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public async Task Ctor_ConnectionString_RoundTrip()
        {
            // Arrange
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewDirectoryName();
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient directoryClient = InstrumentClient(test.FileSystem.GetDirectoryClient(path));
            await directoryClient.CreateAsync();

            // Act
            string connectionString = $"DefaultEndpointsProtocol=https;AccountName={TestConfigHierarchicalNamespace.AccountName};AccountKey={TestConfigHierarchicalNamespace.AccountKey};EndpointSuffix=core.windows.net";
            DataLakeFileClient connStringFile = InstrumentClient(new DataLakeFileClient(connectionString, fileSystemName, path, GetOptions()));

            // Assert
            await connStringFile.GetPropertiesAsync();
            await connStringFile.GetAccessControlAsync();
        }

        [Test]
        public async Task Ctor_ConnectionString_GenerateSas()
        {
            // Arrange
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewDirectoryName();
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient directoryClient = InstrumentClient(test.FileSystem.GetDirectoryClient(path));
            await directoryClient.CreateAsync();

            // Act
            string connectionString = $"DefaultEndpointsProtocol=https;AccountName={TestConfigHierarchicalNamespace.AccountName};AccountKey={TestConfigHierarchicalNamespace.AccountKey};EndpointSuffix=core.windows.net";
            DataLakeFileClient connStringFile = InstrumentClient(new DataLakeFileClient(connectionString, fileSystemName, path, GetOptions()));
            Uri sasUri = connStringFile.GenerateSasUri(DataLakeSasPermissions.All, Recording.UtcNow.AddDays(1));
            DataLakeFileClient sasFileClient = InstrumentClient(new DataLakeFileClient(sasUri, GetOptions()));

            // Assert
            await sasFileClient.GetPropertiesAsync();
            await sasFileClient.GetAccessControlAsync();
        }

        [Test]
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
        }

        [Test]
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
            await file.CreateIfNotExistsAsync();

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
            await file.CreateIfNotExistsAsync();

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
        public async Task ExistsAsync_FileSystemNotExists()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystemClient = service.GetFileSystemClient(GetNewFileSystemName());
            DataLakeFileClient file = InstrumentClient(fileSystemClient.GetFileClient(GetNewFileName()));

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
                e => Assert.AreEqual("NoAuthenticationInformation", e.ErrorCode));
        }

        [Test]
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
        public async Task DeleteIfExistsAsync_FileSystemNotExists()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystemClient = service.GetFileSystemClient(GetNewFileSystemName());
            DataLakeFileClient file = InstrumentClient(fileSystemClient.GetFileClient(GetNewFileName()));

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
            Uri expectedDestFileUri = new Uri($"https://{test.FileSystem.AccountName}.dfs.core.windows.net/{test.FileSystem.Name}/{directoryName}/{Uri.EscapeDataString(destFileName)}");
            string destFilePath = $"{directoryName}/{destFileName}";

            // Act
            DataLakeFileClient destFile = await sourceFile.RenameAsync(destinationPath: destFilePath);

            // Assert
            Response<PathProperties> response = await destFile.GetPropertiesAsync();
            Assert.AreEqual(destFileName, destFile.Name);
            Assert.AreEqual(destFilePath, destFile.Path);
            Assert.AreEqual(expectedDestFileUri, destFile.Uri);
        }

        [Test]
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
            Uri expectedDestFileUri = new Uri($"https://{test.FileSystem.AccountName}.dfs.core.windows.net/{test.FileSystem.Name}/{directoryName}/{destFileName}");
            string destFilePath = $"{directoryName}/{destFileName}";

            // Act
            DataLakeFileClient destFile = await sourceFile.RenameAsync(destinationPath: destFilePath);

            // Assert
            Response<PathProperties> response = await destFile.GetPropertiesAsync();
            Assert.AreEqual(destFileName, destFile.Name);
            Assert.AreEqual(destFilePath, destFile.Path);
            Assert.AreEqual(expectedDestFileUri, destFile.Uri);
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
            //Assert.AreEqual(key.SignedVersion, sas.Version);
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

        [Test]
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

        [Test]
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
            await file.CreateIfNotExistsAsync();
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
            await file.CreateIfNotExistsAsync();
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
            await file.CreateIfNotExistsAsync();
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
            await file.CreateIfNotExistsAsync();
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
            await file.CreateIfNotExistsAsync();
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

        [Test]
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

        [Test]
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

        [Test]
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
            await file.CreateIfNotExistsAsync();
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
        public async Task FlushDataAsync_CloseTwice()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateAsync();
            var data = GetRandomBuffer(Constants.KB);

            using Stream stream = new MemoryStream(data);
            await file.AppendAsync(stream, 0);

            // Act
            await file.FlushAsync(Constants.KB, close: true);
            Response<PathInfo> response = await file.FlushAsync(Constants.KB, close: true);

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
                await file.CreateIfNotExistsAsync();
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
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

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
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

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
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

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/12063")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
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

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
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

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/12063")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
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

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
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

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
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

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
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
            Response<FileDownloadInfo> response = await file.QueryAsync(
                query,
                options: options);

            MemoryStream memoryStream = new MemoryStream();
            await response.Value.Content.CopyToAsync(memoryStream);

            // Assert
            Assert.AreEqual("/////4AAAAAQAAAAAAAKAAwABgAFAAgACgAAAAABAwAMAAAACAAIAAAABAAIAAAABAAAAAEAAAAUAAAAEAAUAAgABgAHAAwAAAAQABAAAAAAAAEHJAAAABQAAAAEAAAAAAAAAAgADAAEAAgACAAAAAQAAAACAAAABAAAAE5hbWUAAAAAAAAAAP////9wAAAAEAAAAAAACgAOAAYABQAIAAoAAAAAAwMAEAAAAAAACgAMAAAABAAIAAoAAAAwAAAABAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAAAAAAAAAAAAAAAAAAAAAAAAAP////+IAAAAFAAAAAAAAAAMABYABgAFAAgADAAMAAAAAAMDABgAAAAAAgAAAAAAAAAACgAYAAwABAAIAAoAAAA8AAAAEAAAACAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAABAAAAIAAAAAAAAAAAAAAAAAAAAJABAAAAAAAAAAAAAAAAAACQAQAAAAAAAAAAAAAAAAAAkAEAAAAAAAAAAAAAAAAAAJABAAAAAAAAAAAAAAAAAACQAQAAAAAAAAAAAAAAAAAAkAEAAAAAAAAAAAAAAAAAAJABAAAAAAAAAAAAAAAAAACQAQAAAAAAAAAAAAAAAAAAkAEAAAAAAAAAAAAAAAAAAJABAAAAAAAAAAAAAAAAAACQAQAAAAAAAAAAAAAAAAAAkAEAAAAAAAAAAAAAAAAAAJABAAAAAAAAAAAAAAAAAACQAQAAAAAAAAAAAAAAAAAAkAEAAAAAAAAAAAAAAAAAAJABAAAAAAAAAAAAAAAAAACQAQAAAAAAAAAAAAAAAAAAkAEAAAAAAAAAAAAAAAAAAJABAAAAAAAAAAAAAAAAAACQAQAAAAAAAAAAAAAAAAAAkAEAAAAAAAAAAAAAAAAAAJABAAAAAAAAAAAAAAAAAACQAQAAAAAAAAAAAAAAAAAAkAEAAAAAAAAAAAAAAAAAAJABAAAAAAAAAAAAAAAAAACQAQAAAAAAAAAAAAAAAAAAkAEAAAAAAAAAAAAAAAAAAJABAAAAAAAAAAAAAAAAAACQAQAAAAAAAAAAAAAAAAAAkAEAAAAAAAAAAAAAAAAAAJABAAAAAAAAAAAAAAAAAACQAQAAAAAAAAAAAAAAAAAA", Convert.ToBase64String(memoryStream.ToArray()));
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
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

        public async Task OpenReadAsync()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());
            int size = Constants.KB;
            var data = GetRandomBuffer(size);
            using Stream stream = new MemoryStream(data);
            await file.UploadAsync(stream);

            // Act
            Stream outputStream = await file.OpenReadAsync();
            byte[] outputBytes = new byte[size];
            await outputStream.ReadAsync(outputBytes, 0, size);

            // Assert
            Assert.AreEqual(data.Length, outputStream.Length);
            TestHelper.AssertSequenceEqual(data, outputBytes);
        }

        [Test]
        public async Task OpenReadAsync_BufferSize()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());
            int size = Constants.KB;
            var data = GetRandomBuffer(size);
            using Stream stream = new MemoryStream(data);
            await file.UploadAsync(stream);

            DataLakeOpenReadOptions options = new DataLakeOpenReadOptions(allowModifications: false)
            {
                BufferSize = size / 8
            };

            // Act
            Stream outputStream = await file.OpenReadAsync(options).ConfigureAwait(false);
            byte[] outputBytes = new byte[size];
            int downloadedBytes = 0;

            while (downloadedBytes < size)
            {
                downloadedBytes += await outputStream.ReadAsync(outputBytes, downloadedBytes, size / 4);
            }

            // Assert
            Assert.AreEqual(data.Length, outputStream.Length);
            TestHelper.AssertSequenceEqual(data, outputBytes);
        }

        [Test]
        public async Task OpenReadAsync_OffsetAndBufferSize()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());
            int size = Constants.KB;
            var data = GetRandomBuffer(size);
            using Stream stream = new MemoryStream(data);
            await file.UploadAsync(stream);

            byte[] expected = new byte[size];
            Array.Copy(data, size / 2, expected, size / 2, size / 2);

            DataLakeOpenReadOptions options = new DataLakeOpenReadOptions(allowModifications: false)
            {
                Position = size / 2,
                BufferSize = size / 8
            };

            // Act
            Stream outputStream = await file.OpenReadAsync(options).ConfigureAwait(false);
            byte[] outputBytes = new byte[size];

            int downloadedBytes = size / 2;

            while (downloadedBytes < size)
            {
                downloadedBytes += await outputStream.ReadAsync(outputBytes, downloadedBytes, size / 4);
            }

            // Assert
            Assert.AreEqual(data.Length, outputStream.Length);
            TestHelper.AssertSequenceEqual(expected, outputBytes);
        }

        [Test]
        public async Task OpenReadAsync_Error()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.OpenReadAsync(),
                e => Assert.AreEqual("BlobNotFound", e.ErrorCode));
        }

        [Test]
        public async Task OpenReadAsync_AccessConditions()
        {
            // Arrange
            int size = Constants.KB;
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();
                var data = GetRandomBuffer(size);
                DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
                using (var stream = new MemoryStream(data))
                {
                    await file.UploadAsync(stream);
                }

                parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(file, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions accessConditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                DataLakeOpenReadOptions options = new DataLakeOpenReadOptions(allowModifications: false)
                {
                    BufferSize = size / 4,
                    Conditions = accessConditions
                };

                // Act
                Stream outputStream = await file.OpenReadAsync(options).ConfigureAwait(false);
                byte[] outputBytes = new byte[size];

                int downloadedBytes = 0;

                while (downloadedBytes < size)
                {
                    downloadedBytes += await outputStream.ReadAsync(outputBytes, downloadedBytes, size / 4);
                }

                // Assert
                Assert.AreEqual(data.Length, outputStream.Length);
                TestHelper.AssertSequenceEqual(data, outputBytes);
            }
        }

        [Test]
        public async Task OpenReadAsync_AccessConditionsFail()
        {
            // Arrange
            int size = Constants.KB;
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingFileSystem test = await GetNewFileSystem();
                var data = GetRandomBuffer(size);
                DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
                using (var stream = new MemoryStream(data))
                {
                    await file.UploadAsync(stream);
                }

                parameters.NoneMatch = await SetupPathMatchCondition(file, parameters.NoneMatch);
                DataLakeRequestConditions accessConditions = BuildDataLakeRequestConditions(parameters);

                DataLakeOpenReadOptions options = new DataLakeOpenReadOptions(allowModifications: false)
                {
                    BufferSize = size / 4,
                    Conditions = accessConditions
                };

                // Act
                await TestHelper.CatchAsync<Exception>(
                    async () =>
                    {
                        var _ = await file.OpenReadAsync(options).ConfigureAwait(false);
                    });
            }
        }

        [Test]
        public async Task OpenReadAsync_StrangeOffsetsTest()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();

            int length = Constants.KB;
            byte[] exectedData = GetRandomBuffer(length);
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            using (var stream = new MemoryStream(exectedData))
            {
                await file.UploadAsync(stream);
            }

            DataLakeOpenReadOptions options = new DataLakeOpenReadOptions(allowModifications: false)
            {
                Position = 0,
                BufferSize = 157
            };

            Stream outputStream = await file.OpenReadAsync(options);
            byte[] actualData = new byte[length];
            int offset = 0;

            // Act
            int count = 0;
            int readBytes = -1;
            while (readBytes != 0)
            {
                for (count = 6; count < 37; count += 6)
                {
                    readBytes = await outputStream.ReadAsync(actualData, offset, count);
                    if (readBytes == 0)
                    {
                        break;
                    }
                    offset += readBytes;
                }
            }

            // Assert
            TestHelper.AssertSequenceEqual(exectedData, actualData);
        }

        [Test]
        public async Task OpenReadAsync_Modified()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());
            int size = Constants.KB;
            var data = GetRandomBuffer(size);
            using Stream stream = new MemoryStream(data);
            await file.UploadAsync(stream);

            DataLakeOpenReadOptions options = new DataLakeOpenReadOptions(allowModifications: false)
            {
                BufferSize = size / 2
            };

            // Act
            Stream outputStream = await file.OpenReadAsync(options);
            byte[] outputBytes = new byte[size];
            await outputStream.ReadAsync(outputBytes, 0, size / 2);

            // Modify the file.
            stream.Position = 0;
            await file.AppendAsync(
                content: stream,
                offset: size);

            await file.FlushAsync(2 * size);

            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                outputStream.ReadAsync(outputBytes, size / 2, size / 2),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [Test]
        public async Task OpenReadAsync_ModifiedAllowBlobModifications()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = test.FileSystem.GetFileClient(GetNewFileName());
            int size = Constants.KB;
            byte[] data0 = GetRandomBuffer(size);
            byte[] data1 = GetRandomBuffer(size);
            byte[] expectedData = new byte[2 * size];
            Array.Copy(data0, 0, expectedData, 0, size);
            Array.Copy(data1, 0, expectedData, size, size);
            using Stream stream0 = new MemoryStream(data0);
            await file.UploadAsync(stream0);

            DataLakeOpenReadOptions options = new DataLakeOpenReadOptions(allowModifications: true);

            // Act
            Stream outputStream = await file.OpenReadAsync(options);
            byte[] outputBytes = new byte[size * 2];
            await outputStream.ReadAsync(outputBytes, 0, size);

            // Modify the file.
            using Stream stream1 = new MemoryStream(data1);
            await file.AppendAsync(
                content: stream1,
                offset: size);

            await file.FlushAsync(2 * size);

            await outputStream.ReadAsync(outputBytes, size, size);

            // Assert
            TestHelper.AssertSequenceEqual(expectedData, outputBytes);
        }

        [Test]
        [Ignore("Don't want to record 1 GB of data.")]
        public async Task OpenReadAsync_LargeData()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            int length = 1 * Constants.GB;
            byte[] exectedData = GetRandomBuffer(length);
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            using (var stream = new MemoryStream(exectedData))
            {
                await file.UploadAsync(stream,
                    transferOptions: new StorageTransferOptions
                    {
                        MaximumTransferLength = 8 * Constants.MB,
                        MaximumConcurrency = 8
                    });
            }

            Stream outputStream = await file.OpenReadAsync();
            int readSize = 8 * Constants.MB;
            byte[] actualData = new byte[readSize];
            int offset = 0;

            // Act
            for (int i = 0; i < length / readSize; i++)
            {
                await outputStream.ReadAsync(actualData, 0, readSize);
                for (int j = 0; j < readSize; j++)
                {
                    // Assert
                    if (actualData[j] != exectedData[offset + j])
                    {
                        Assert.Fail($"Index {offset + j} does not match.  Expected: {exectedData[offset + j]} Actual: {actualData[j]}");
                    }
                }
                offset += readSize;
            }
        }

        [Test]
        public async Task OpenReadAsync_CopyReadStreamToAnotherStream()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            long size = 4 * Constants.MB;
            byte[] exectedData = GetRandomBuffer(size);
            DataLakeFileClient fileClient = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            using Stream stream = new MemoryStream(exectedData);
            await fileClient.UploadAsync(stream);

            MemoryStream outputStream = new MemoryStream();

            // Act
            using Stream blobStream = await fileClient.OpenReadAsync();
            await blobStream.CopyToAsync(outputStream);

            TestHelper.AssertSequenceEqual(exectedData, outputStream.ToArray());
        }

        [Test]
        public async Task OpenReadAsync_InvalidParameterTests()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            long size = 4 * Constants.MB;
            byte[] exectedData = GetRandomBuffer(size);
            DataLakeFileClient fileClient = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await fileClient.UploadAsync(new MemoryStream(exectedData));
            Stream stream = await fileClient.OpenReadAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentNullException>(
                stream.ReadAsync(buffer: null, offset: 0, count: 10),
                new ArgumentNullException("buffer", $"buffer cannot be null."));

            await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                stream.ReadAsync(buffer: new byte[10], offset: -1, count: 10),
                new ArgumentOutOfRangeException("offset cannot be less than 0.", "Specified argument was out of the range of valid values."));

            await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                stream.ReadAsync(buffer: new byte[10], offset: 11, count: 10),
                new ArgumentOutOfRangeException("offset cannot exceed buffer length.", "Specified argument was out of the range of valid values."));

            await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                stream.ReadAsync(buffer: new byte[10], offset: 1, count: -1),
                new ArgumentOutOfRangeException("count cannot be less than 0.", "Specified argument was out of the range of valid values."));
        }

        [Test]
        public async Task OpenReadAsync_Seek_PositionUnchanged()
        {
            int size = Constants.KB;
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            var data = GetRandomBuffer(size);
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            using Stream stream = new MemoryStream(data);
            await file.UploadAsync(stream);

            // Act
            Stream outputStream = await file.OpenReadAsync().ConfigureAwait(false);
            byte[] outputBytes = new byte[size];
            outputStream.Seek(0, SeekOrigin.Begin);

            Assert.AreEqual(0, outputStream.Position);

            await outputStream.ReadAsync(outputBytes, 0, size);

            // Assert
            Assert.AreEqual(data.Length, outputStream.Length);
            TestHelper.AssertSequenceEqual(data, outputBytes);
        }

        [Test]
        public async Task OpenReadAsync_Seek_NegativeNewPosition()
        {
            int size = Constants.KB;
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            var data = GetRandomBuffer(size);
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            using Stream stream = new MemoryStream(data);
            await file.UploadAsync(stream);

            // Act
            Stream outputStream = await file.OpenReadAsync().ConfigureAwait(false);
            TestHelper.AssertExpectedException<ArgumentException>(
                () => outputStream.Seek(-10, SeekOrigin.Begin),
                new ArgumentException("New offset cannot be less than 0.  Value was -10"));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task OpenReadAsync_Seek_NewPositionGreaterThanFileLength(bool allowModifications)
        {
            int size = Constants.KB;
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            var data = GetRandomBuffer(size);
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            using Stream stream = new MemoryStream(data);
            await file.UploadAsync(stream);

            DataLakeOpenReadOptions options = new DataLakeOpenReadOptions(allowModifications: allowModifications);

            // Act
            Stream outputStream = await file.OpenReadAsync(options: options).ConfigureAwait(false);
            TestHelper.AssertExpectedException<ArgumentException>(
                () => outputStream.Seek(size + 10, SeekOrigin.Begin),
                new ArgumentException("You cannot seek past the last known length of the underlying blob or file."));

            Assert.AreEqual(size, outputStream.Length);
        }

        [Test]
        [TestCase(0, SeekOrigin.Begin)]
        [TestCase(10, SeekOrigin.Begin)]
        [TestCase(-10, SeekOrigin.Current)]
        [TestCase(0, SeekOrigin.Current)]
        [TestCase(10, SeekOrigin.Current)]
        [TestCase(0, SeekOrigin.End)]
        [TestCase(-10, SeekOrigin.End)]
        public async Task OpenReadAsync_Seek_Position(long offset, SeekOrigin origin)
        {
            int size = Constants.KB;
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            var data = GetRandomBuffer(size);
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            using Stream stream = new MemoryStream(data);
            await file.UploadAsync(stream);

            DataLakeOpenReadOptions options = new DataLakeOpenReadOptions(allowModifications: false);

            Stream outputStream = await file.OpenReadAsync(options: options).ConfigureAwait(false);
            int readBytes = 512;
            await outputStream.ReadAsync(new byte[readBytes], 0, readBytes);
            Assert.AreEqual(512, outputStream.Position);

            // Act
            outputStream.Seek(offset, origin);

            // Assert
            if (origin == SeekOrigin.Begin)
            {
                Assert.AreEqual(offset, outputStream.Position);
            }
            else if (origin == SeekOrigin.Current)
            {
                Assert.AreEqual(readBytes + offset, outputStream.Position);
            }
            else
            {
                Assert.AreEqual(size + offset, outputStream.Position);
            }

            Assert.AreEqual(size, outputStream.Length);
        }

        [Test]
        // lower position within _buffer
        [TestCase(-50)]
        // higher positiuon within _buffer
        [TestCase(50)]
        // lower position below _buffer
        [TestCase(-100)]
        // higher position above _buffer
        [TestCase(100)]
        public async Task OpenReadAsync_Seek(long offset)
        {
            int size = Constants.KB;
            int initalPosition = 450;
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            byte[] data = GetRandomBuffer(size);
            byte[] expectedData = new byte[size - (initalPosition + offset)];
            Array.Copy(data, initalPosition + offset, expectedData, 0, size - (initalPosition + offset));
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            using Stream stream = new MemoryStream(data);
            await file.UploadAsync(stream);

            DataLakeOpenReadOptions options = new DataLakeOpenReadOptions(allowModifications: false)
            {
                BufferSize = 128
            };

            // Act
            Stream openReadStream = await file.OpenReadAsync(options: options).ConfigureAwait(false);
            int readbytes = initalPosition;
            while (readbytes > 0)
            {
                readbytes -= await openReadStream.ReadAsync(new byte[readbytes], 0, readbytes);
            }

            openReadStream.Seek(offset, SeekOrigin.Current);

            using MemoryStream outputStream = new MemoryStream();
            await openReadStream.CopyToAsync(outputStream);

            // Assert
            Assert.AreEqual(expectedData.Length, outputStream.ToArray().Length);
            Assert.AreEqual(size, openReadStream.Length);
            TestHelper.AssertSequenceEqual(expectedData, outputStream.ToArray());
        }

        [Test]
        // lower position within _buffer
        [TestCase(400)]
        // higher positiuon within _buffer
        [TestCase(500)]
        // lower position below _buffer
        [TestCase(250)]
        // higher position above _buffer
        [TestCase(550)]
        public async Task OpenReadAsync_SetPosition(long position)
        {
            int size = Constants.KB;
            int initalPosition = 450;
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            byte[] data = GetRandomBuffer(size);
            byte[] expectedData = new byte[size - position];
            Array.Copy(data, position, expectedData, 0, size - position);
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            using Stream stream = new MemoryStream(data);
            await file.UploadAsync(stream);

            DataLakeOpenReadOptions options = new DataLakeOpenReadOptions(allowModifications: false)
            {
                BufferSize = 128
            };

            // Act
            Stream openReadStream = await file.OpenReadAsync(options: options).ConfigureAwait(false);
            int readbytes = initalPosition;
            while (readbytes > 0)
            {
                readbytes -= await openReadStream.ReadAsync(new byte[readbytes], 0, readbytes);
            }

            openReadStream.Position = position;

            using MemoryStream outputStream = new MemoryStream();
            await openReadStream.CopyToAsync(outputStream);

            // Assert
            Assert.AreEqual(expectedData.Length, outputStream.ToArray().Length);
            TestHelper.AssertSequenceEqual(expectedData, outputStream.ToArray());
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public async Task OpenWriteAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.OpenWriteAsync(overwrite: false),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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
        [Test]
        public void CanGenerateSas_ClientConstructors()
        {
            // Arrange
            var constants = new TestConstants(this);
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

        [Test]
        public void GenerateSas_RequiredParameters()
        {
            // Arrange
            var constants = new TestConstants(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "/" + fileSystemName + "/" + path);
            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(
                blobEndpoint,
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
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(blobEndpoint);
            expectedUri.Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential);
            Assert.AreEqual(expectedUri.ToUri().ToString(), sasUri.ToString());
        }

        [Test]
        public void GenerateSas_Builder()
        {
            var constants = new TestConstants(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "/" + fileSystemName + "/" + path);
            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                StartsOn = startsOn
            };

            // Act
            Uri sasUri = fileClient.GenerateSasUri(sasBuilder);

            // Assert
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(blobEndpoint);
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                StartsOn = startsOn
            };
            expectedUri.Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential);
            Assert.AreEqual(expectedUri.ToUri().ToString(), sasUri.ToString());
        }

        [Test]
        public void GenerateSas_BuilderWrongFileSystemName()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("http://127.0.0.1/");
            UriBuilder blobUriBuilder = new UriBuilder(blobEndpoint);
            string path = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            blobUriBuilder.Path += constants.Sas.Account + "/" + GetNewFileSystemName() + "/" + path;
            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(
                blobUriBuilder.Uri,
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = GetNewFileSystemName(), // different filesystem name
                Path = path,
            };

            // Act
            try
            {
                fileClient.GenerateSasUri(sasBuilder);

                Assert.Fail("DataLakeFileClient.GenerateSasUri should have failed with an ArgumentException.");
            }
            catch (InvalidOperationException)
            {
                //the correct exception came back
            }
        }

        [Test]
        public void GenerateSas_BuilderWrongFileName()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("http://127.0.0.1/");
            UriBuilder blobUriBuilder = new UriBuilder(blobEndpoint);
            string fileSystemName = GetNewFileSystemName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            blobUriBuilder.Path += constants.Sas.Account + "/" + fileSystemName + "/" + GetNewFileName();
            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(
                blobUriBuilder.Uri,
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = GetNewFileName(), // different path
            };

            // Act
            try
            {
                fileClient.GenerateSasUri(sasBuilder);

                Assert.Fail("DataLakeFileClient.GenerateSasUri should have failed with an ArgumentException.");
            }
            catch (InvalidOperationException)
            {
                //the correct exception came back
            }
        }

        [Test]
        public void GenerateSas_BuilderIsDirectoryError()
        {
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("http://127.0.0.1/");
            UriBuilder blobUriBuilder = new UriBuilder(blobEndpoint);
            string fileSystemName = GetNewFileSystemName();
            string fileName = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            blobUriBuilder.Path += constants.Sas.Account + "/" + fileSystemName + "/" + fileName;

            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(
                blobUriBuilder.Uri,
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
            try
            {
                fileClient.GenerateSasUri(sasBuilder);

                Assert.Fail("DataLakeFileClient.GenerateSasUri should have failed with an ArgumentException.");
            }
            catch (InvalidOperationException)
            {
                //the correct exception came back
            }
        }
        #endregion
    }
}
