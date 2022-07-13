// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class AppendFileClientTests : PathTestBase
    {
        public AppendFileClientTests(bool async, DataLakeClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task CreateAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            DataLakeAppendFileClient file = InstrumentClient(directory.GetAppendFileClient(GetNewFileName()));

            // Act
            Response<PathInfo> response = await file.CreateAsync();

            // Assert
            AssertValidStoragePathInfo(response.Value);
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task CreateAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            DataLakeAppendFileClient file = InstrumentClient(fileSystem.GetAppendFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileSystem.CreateDirectoryAsync(GetNewDirectoryName()),
                e => Assert.AreEqual("FilesystemNotFound", e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task CreateAsync_HttpHeaders()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            DataLakeAppendFileClient file = InstrumentClient(directory.GetAppendFileClient(GetNewFileName()));
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
                HttpHeaders = headers,
            };

            // Act
            await file.CreateAsync(options);

            // Assert
            Response<PathProperties> response = await file.GetPropertiesAsync();
            Assert.AreEqual(ContentType, response.Value.ContentType);
            // TODO service bug
            //Assert.AreEqual(ContentEncoding, response.Value.ContentEncoding);
            Assert.AreEqual(ContentLanguage, response.Value.ContentLanguage);
            Assert.AreEqual(ContentDisposition, response.Value.ContentDisposition);
            Assert.AreEqual(CacheControl, response.Value.CacheControl);
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task CreateAsync_Metadata()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();
            DataLakeAppendFileClient file = InstrumentClient(directory.GetAppendFileClient(GetNewFileName()));

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                Metadata = metadata
            };

            // Act
            await file.CreateAsync(options);

            // Assert
            Response<PathProperties> getPropertiesResponse = await file.GetPropertiesAsync();
            AssertMetadataEquality(metadata, getPropertiesResponse.Value.Metadata, isDirectory: false);
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task CreateAsync_PermissionAndUmask()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            DataLakeAppendFileClient file = InstrumentClient(directory.GetAppendFileClient(GetNewFileName()));
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
            await file.CreateAsync(options);

            // Assert
            Response<PathAccessControl> response = await file.GetAccessControlAsync();
            AssertPathPermissionsEquality(PathPermissions.ParseSymbolicPermissions("rwx-w----"), response.Value.Permissions);
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task CreateAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                // Arrange
                // This file is intentionally created twice
                DataLakeFileClient file = InstrumentClient(directory.GetAppendFileClient(GetNewFileName()));
                await file.CreateAsync();

                parameters.Match = await SetupPathMatchCondition(file, parameters.Match);
                parameters.LeaseId = await SetupPathLeaseCondition(file, parameters.LeaseId, garbageLeaseId);

                DataLakeRequestConditions conditions = BuildDataLakeRequestConditions(
                    parameters: parameters,
                    lease: true);

                DataLakePathCreateOptions options = new DataLakePathCreateOptions
                {
                    Conditions = conditions,
                };

                // Act
                Response<PathInfo> response = await file.CreateAsync(options);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task CreateAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetConditionsFail_Data(garbageLeaseId))
            {
                await using DisposingFileSystem test = await GetNewFileSystem();
                DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

                // Arrange
                // This file is intentionally created twice
                DataLakeFileClient file = InstrumentClient(directory.GetAppendFileClient(GetNewFileName()));
                await file.CreateAsync();
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
                    file.CreateAsync(options),
                    e => { });
            }
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task CreateIfNotExistsAsync_NotExists()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeAppendFileClient file = InstrumentClient(directory.GetAppendFileClient(GetNewFileName()));

            // Act
            Response<PathInfo> response = await file.CreateIfNotExistsAsync();

            // Assert
            Assert.IsNotNull(response.Value.ETag);
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task CreateIfNotExistsAsync_Exists()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeAppendFileClient file = InstrumentClient(directory.GetAppendFileClient(GetNewFileName()));
            await file.CreateAsync();

            // Act
            Response<PathInfo> response = await file.CreateIfNotExistsAsync();

            // Assert
            Assert.IsNull(response);
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task CreateIfNotExistsAsync_Error()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeAppendFileClient file = InstrumentClient(directory.GetAppendFileClient(GetNewFileName()));
            DataLakeAppendFileClient unauthorizedFile = InstrumentClient(new DataLakeAppendFileClient(file.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedFile.CreateIfNotExistsAsync(),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_12_06)]
        public async Task AppendAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeAppendFileClient file = InstrumentClient(test.FileSystem.GetAppendFileClient(GetNewFileName()));
            await file.CreateAsync();
            var data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);

            // Act
            Response<ConcurrentAppendResult> concurrentAppendResponse = await file.AppendAsync(stream);

            // Assert
            Assert.AreEqual(1, concurrentAppendResponse.Value.CommittedBlockCount);
            Response<FileDownloadInfo> downloadResponse = await file.ReadAsync();
            MemoryStream actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task AppendAsync_Error()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeAppendFileClient file = InstrumentClient(test.FileSystem.GetAppendFileClient(GetNewFileName()));
            var data = GetRandomBuffer(Constants.KB);

            // Act
            using Stream stream = new MemoryStream(data);
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.AppendAsync(stream, 0),
                    e => Assert.AreEqual("PathNotFound", e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task AppendAsync_ContentHash()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeAppendFileClient file = InstrumentClient(test.FileSystem.GetAppendFileClient(GetNewFileName()));
            await file.CreateAsync();
            byte[] data = GetRandomBuffer(Constants.KB);
            byte[] contentHash = MD5.Create().ComputeHash(data);

            // Act
            Stream stream = new MemoryStream(data);
            await file.AppendAsync(stream, 0, contentHash: contentHash);
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task AppendAsync_ProgressReporting()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateAsync();
            var data = GetRandomBuffer(Constants.KB);
            TestProgress progress = new TestProgress();
            using Stream stream = new MemoryStream(data);

            // Act
            await file.AppendAsync(stream, 0, progressHandler: progress);

            // Assert
            Assert.IsFalse(progress.List.Count == 0);

            Assert.AreEqual(Constants.KB, progress.List[progress.List.Count - 1]);
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task AppendAsync_CreateIfNotExists()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeAppendFileClient file = InstrumentClient(test.FileSystem.GetAppendFileClient(GetNewFileName()));
            var data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);

            // Act
            await file.AppendAsync(stream, createIfNotExists: true);

            // Assert
            Response<FileDownloadInfo> downloadResponse = await file.ReadAsync();
            MemoryStream actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [Test]
        //[ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2021_08_06)]
        public async Task AppendAsync_FastPath()
        {
            DataLakeServiceClient service = GetServiceClient_OAuth();
            await using DisposingFileSystem test = await GetNewFileSystem(service);

            // Arrange
            DataLakeAppendFileClient file = InstrumentClient(test.FileSystem.GetAppendFileClient(GetNewFileName()));
            await file.CreateAsync();
            var data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);
            string fastPathSessionData = "refresh";

            // Act
            Response<ConcurrentAppendResult> concurrentAppendResponse = await file.AppendAsync(
                content: stream,
                fastPathSessionData: fastPathSessionData);

            // Assert
            Assert.IsNotNull(concurrentAppendResponse.Value.FastPathSessionData);
            Assert.IsNotNull(concurrentAppendResponse.Value.FastPathSessionDataExpiresOn);

            using Stream stream2 = new MemoryStream(data);
            concurrentAppendResponse = await file.AppendAsync(
                content: stream2,
                fastPathSessionData: concurrentAppendResponse.Value.FastPathSessionData);

            Assert.IsNull(concurrentAppendResponse.Value.FastPathSessionData);
            Assert.IsNull(concurrentAppendResponse.Value.FastPathSessionDataExpiresOn);
        }
    }
}
