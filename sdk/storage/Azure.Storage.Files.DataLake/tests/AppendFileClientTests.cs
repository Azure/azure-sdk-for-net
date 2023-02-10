// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Test;
using Azure.Storage.Tests.Shared;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class AppendFileClientTests : PathTestBase
    {
        public AppendFileClientTests(bool async, DataLakeClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task CreateAsync(bool createIfNotExists)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            // Arrange
            DataLakeAppendFileClient file = InstrumentClient(directory.GetAppendFileClient(GetNewFileName()));

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
        }

        [RecordedTest]
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

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task CreateAsync_HttpHeaders(bool createIfNotExists)
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
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task CreateAsync_Metadata(bool createIfNotExists)
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
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task CreateAsync_PermissionAndUmask(bool createIfNotExists)
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
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task CreateAsync_Owner(bool createIfNotExists)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            DataLakeAppendFileClient file = InstrumentClient(directory.GetAppendFileClient(GetNewFileName()));
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
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task CreateAsync_Group(bool createIfNotExists)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            DataLakeAppendFileClient file = InstrumentClient(directory.GetAppendFileClient(GetNewFileName()));
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
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task CreateAsync_Acl(bool createIfNotExists)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            DataLakeAppendFileClient file = InstrumentClient(directory.GetAppendFileClient(GetNewFileName()));

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
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task CreateAsync_Lease(bool createIfNotExists)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());

            DataLakeAppendFileClient file = InstrumentClient(directory.GetAppendFileClient(GetNewFileName()));
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
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        [RetryOnException(5, typeof(AssertionException))]
        public async Task CreateAsync_RelativeExpiry(bool createIfNotExists)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeAppendFileClient file = InstrumentClient(directory.GetAppendFileClient(GetNewFileName()));

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
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task CreateAsync_AbsoluteExpiry(bool createIfNotExists)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeAppendFileClient file = InstrumentClient(directory.GetAppendFileClient(GetNewFileName()));

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
            await file.AppendAsync(stream, contentHash: contentHash);
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task AppendAsync_ProgressReporting()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeAppendFileClient file = InstrumentClient(test.FileSystem.GetAppendFileClient(GetNewFileName()));
            await file.CreateAsync();
            var data = GetRandomBuffer(Constants.KB);
            TestProgress progress = new TestProgress();
            using Stream stream = new MemoryStream(data);

            // Act
            await file.AppendAsync(stream, progressHandler: progress);

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
