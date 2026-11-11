// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Files.DataLake.Models;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class RequestPriorityTests : DataLakeTestBase
    {
        /// <summary>
        /// Priority the service applies when no priority, or an out-of-range priority, is sent.
        /// </summary>
        private const int DefaultEffectivePriority = 3;

        /// <summary>
        /// Priority used by tests that only verify RequestPriority is plumbed through and EffectiveRequestPriority is read back.
        /// Any value other than <see cref="DefaultEffectivePriority"/> fails if the header is dropped.
        /// </summary>
        private const int Priority = 5;

        public RequestPriorityTests(bool async, DataLakeClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        /// <summary>
        /// Effective priority the service is expected to return for the given requested priority.
        /// Unset or out-of-range (outside 0-7) values fall back to the service default.
        /// </summary>
        private static int ExpectedEffectivePriority(int? requested)
            => requested is >= 0 and <= 7 ? requested.Value : DefaultEffectivePriority;

        /// <summary>
        /// Asserts the effective priority on a raw response, for APIs without a result model.
        /// </summary>
        private static void AssertRawPriority(Response response, int? requested)
        {
            Assert.IsTrue(response.Headers.TryGetValue("x-ms-request-priority", out string effectivePriority));
            Assert.AreEqual(ExpectedEffectivePriority(requested).ToString(), effectivePriority);
        }

        private async Task<DataLakeFileClient> CreateFileAsync(DataLakeFileSystemClient fileSystem)
        {
            DataLakeFileClient file = InstrumentClient(fileSystem.GetFileClient(GetNewFileName()));
            await file.UploadAsync(new MemoryStream(GetRandomBuffer(Constants.KB)));
            return file;
        }

        #region File
        [RecordedTest]
        public async Task GetProperties_RequestPriority([Values(null, 0, 5, 7, -1, 8)] int? priority)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await CreateFileAsync(test.FileSystem);

            Response<PathProperties> response = await file.GetPropertiesAsync(
                new DataLakePathGetPropertiesOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task ReadStreaming_RequestPriority([Values(null, 0, 5, 7, -1, 8)] int? priority)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await CreateFileAsync(test.FileSystem);

            Response<DataLakeFileReadStreamingResult> response = await file.ReadStreamingAsync(
                new DataLakeFileReadOptions { RequestPriority = priority });
            using DataLakeFileReadStreamingResult result = response.Value;

            Assert.AreEqual(ExpectedEffectivePriority(priority), result.Details.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task Create_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));

            Response<PathInfo> response = await file.CreateAsync(
                new DataLakePathCreateOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task AppendFlush_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateAsync();

            Response appendResponse = await file.AppendAsync(
                new MemoryStream(GetRandomBuffer(Constants.KB)),
                0,
                new DataLakeFileAppendOptions { RequestPriority = priority });
            AssertRawPriority(appendResponse, priority);

            Response<PathInfo> flushResponse = await file.FlushAsync(
                Constants.KB,
                new DataLakeFileFlushOptions { RequestPriority = priority });
            Assert.AreEqual(ExpectedEffectivePriority(priority), flushResponse.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task Upload_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));

            Response<PathInfo> response = await file.UploadAsync(
                new MemoryStream(GetRandomBuffer(Constants.KB)),
                new DataLakeFileUploadOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task ReadTo_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await CreateFileAsync(test.FileSystem);

            Response response = await file.ReadToAsync(
                new MemoryStream(),
                new DataLakeFileReadToOptions { RequestPriority = priority });

            AssertRawPriority(response, priority);
        }

        [RecordedTest]
        public async Task FileDelete_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await CreateFileAsync(test.FileSystem);

            Response response = await file.DeleteAsync(
                new DataLakeFileDeleteOptions { RequestPriority = priority });

            AssertRawPriority(response, priority);
        }

        [RecordedTest]
        public async Task Rename_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await CreateFileAsync(test.FileSystem);

            Response<DataLakeFileClient> response = await file.RenameAsync(
                GetNewFileName(),
                new DataLakePathRenameOptions { RequestPriority = priority });

            AssertRawPriority(response.GetRawResponse(), priority);
        }

        [RecordedTest]
        public async Task CreateIfNotExists_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));

            Response<PathInfo> response = await file.CreateIfNotExistsAsync(
                new DataLakePathCreateOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task FileDeleteIfExists_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await CreateFileAsync(test.FileSystem);

            Response<bool> response = await file.DeleteIfExistsAsync(
                new DataLakeFileDeleteOptions { RequestPriority = priority });

            Assert.IsTrue(response.Value);
            AssertRawPriority(response.GetRawResponse(), priority);
        }

        [RecordedTest]
        public async Task ReadContent_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await CreateFileAsync(test.FileSystem);

            Response<DataLakeFileReadResult> response = await file.ReadContentAsync(
                new DataLakeFileReadOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.Details.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task Query_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.UploadAsync(new MemoryStream(System.Text.Encoding.UTF8.GetBytes("a,b\n1,2\n")));

            Response<FileDownloadInfo> response = await file.QueryAsync(
                "SELECT * from BlobStorage",
                new DataLakeQueryOptions { RequestPriority = priority });

            AssertRawPriority(response.GetRawResponse(), priority);
        }

        [RecordedTest]
        public async Task ScheduleDeletion_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await CreateFileAsync(test.FileSystem);

            Response<PathInfo> response = await file.ScheduleDeletionAsync(
                new DataLakeFileScheduleDeletionOptions(TimeSpan.FromHours(1), DataLakeFileExpirationOrigin.Now)
                {
                    RequestPriority = priority
                });

            AssertRawPriority(response.GetRawResponse(), priority);
        }

        [RecordedTest]
        public async Task SetHttpHeaders_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await CreateFileAsync(test.FileSystem);

            Response<PathInfo> response = await file.SetHttpHeadersAsync(
                new DataLakePathSetHttpHeadersOptions
                {
                    HttpHeaders = new PathHttpHeaders { ContentType = "text/plain" },
                    RequestPriority = priority
                });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }
        #endregion File

        #region Path
        [RecordedTest]
        public async Task GetAccessControl_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await CreateFileAsync(test.FileSystem);

            Response<PathAccessControl> response = await file.GetAccessControlAsync(
                new DataLakePathGetAccessControlOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task SetPermissions_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await CreateFileAsync(test.FileSystem);

            Response<PathInfo> response = await file.SetPermissionsAsync(
                PathPermissions.ParseSymbolicPermissions("rwxrwxrwx"),
                new DataLakePathSetPermissionsOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task SetMetadata_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await CreateFileAsync(test.FileSystem);

            Response<PathInfo> response = await file.SetMetadataAsync(
                new Dictionary<string, string> { { "key", "value" } },
                new DataLakePathSetMetadataOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task GetSystemProperties_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await CreateFileAsync(test.FileSystem);

            Response<PathSystemProperties> response = await file.GetSystemPropertiesAsync(
                new PathGetSystemPropertiesOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task DirectoryDelete_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            await directory.CreateAsync();

            Response response = await directory.DeleteAsync(
                new DataLakeDirectoryDeleteOptions { RequestPriority = priority });

            AssertRawPriority(response, priority);
        }

        [RecordedTest]
        public async Task Exists_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await CreateFileAsync(test.FileSystem);

            Response<bool> response = await file.ExistsAsync(
                new DataLakePathExistsOptions { RequestPriority = priority });

            Assert.IsTrue(response.Value);
            AssertRawPriority(response.GetRawResponse(), priority);
        }

        [RecordedTest]
        public async Task SetAccessControlList_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await CreateFileAsync(test.FileSystem);

            Response<PathInfo> response = await file.SetAccessControlListAsync(
                PathAccessControlExtensions.ParseAccessControlList("user::rwx,group::r--,other::---"),
                new DataLakePathSetAccessControlListOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task GetSetTags_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await CreateFileAsync(test.FileSystem);

            Response setResponse = await file.SetTagsAsync(
                new Dictionary<string, string> { { "tag", "value" } },
                new DataLakePathSetTagsOptions { RequestPriority = priority });
            AssertRawPriority(setResponse, priority);

            Response<GetPathTagResult> getResponse = await file.GetTagsAsync(
                new DataLakePathGetTagsOptions { RequestPriority = priority });
            Assert.AreEqual(ExpectedEffectivePriority(priority), getResponse.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task SetAccessControlRecursive_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            await directory.CreateAsync();
            await directory.CreateFileAsync(GetNewFileName());

            Response<AccessControlChangeResult> response = await directory.SetAccessControlRecursiveAsync(
                PathAccessControlExtensions.ParseAccessControlList("user::rwx,group::r--,other::---"),
                options: new AccessControlChangeOptions { RequestPriority = priority });

            AssertRawPriority(response.GetRawResponse(), priority);
        }

        [RecordedTest]
        public async Task DirectoryRename_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            await directory.CreateAsync();

            Response<DataLakeDirectoryClient> response = await directory.RenameAsync(
                GetNewDirectoryName(),
                new DataLakePathRenameOptions { RequestPriority = priority });

            AssertRawPriority(response.GetRawResponse(), priority);
        }

        [RecordedTest]
        public async Task DirectoryGetPaths_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            await directory.CreateAsync();
            await directory.CreateFileAsync(GetNewFileName());
            await directory.CreateFileAsync(GetNewFileName());

            List<PathItem> items = new List<PathItem>();
            await foreach (Page<PathItem> page in directory
                .GetPathsAsync(new DataLakeGetPathsOptions { RequestPriority = priority })
                .AsPages(pageSizeHint: 1))
            {
                AssertRawPriority(page.GetRawResponse(), priority);
                items.AddRange(page.Values);
            }

            Assert.AreEqual(2, items.Count);
        }

        [RecordedTest]
        public async Task DirectoryDeleteFile_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            await directory.CreateAsync();
            string fileName = GetNewFileName();
            await directory.CreateFileAsync(fileName);

            Response response = await directory.DeleteFileAsync(
                fileName,
                new DataLakeFileDeleteOptions { RequestPriority = priority });

            AssertRawPriority(response, priority);
        }

        [RecordedTest]
        public async Task DirectoryDeleteSubDirectory_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            await directory.CreateAsync();
            string subDirectoryName = GetNewDirectoryName();
            await directory.CreateSubDirectoryAsync(subDirectoryName);

            Response response = await directory.DeleteSubDirectoryAsync(
                subDirectoryName,
                new DataLakeDirectoryDeleteOptions { RequestPriority = priority });

            AssertRawPriority(response, priority);
        }
        #endregion Path

        #region Lease
        [RecordedTest]
        public async Task LeaseAcquireRelease_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await CreateFileAsync(test.FileSystem);
            DataLakeLeaseClient lease = InstrumentClient(file.GetDataLakeLeaseClient(Recording.Random.NewGuid().ToString()));

            Response<DataLakeLease> acquireResponse = await lease.AcquireAsync(
                TimeSpan.FromSeconds(15),
                new DataLakeLeaseAcquireOptions { RequestPriority = priority });
            Assert.AreEqual(ExpectedEffectivePriority(priority), acquireResponse.Value.EffectiveRequestPriority);

            Response<ReleasedObjectInfo> releaseResponse = await lease.ReleaseAsync(
                new DataLakeLeaseReleaseOptions { RequestPriority = priority });
            Assert.AreEqual(ExpectedEffectivePriority(priority), releaseResponse.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task LeaseRenewChangeBreak_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await CreateFileAsync(test.FileSystem);
            DataLakeLeaseClient lease = InstrumentClient(file.GetDataLakeLeaseClient(Recording.Random.NewGuid().ToString()));
            await lease.AcquireAsync(TimeSpan.FromSeconds(15));

            Response<DataLakeLease> renewResponse = await lease.RenewAsync(
                new DataLakeLeaseRenewOptions { RequestPriority = priority });
            Assert.AreEqual(ExpectedEffectivePriority(priority), renewResponse.Value.EffectiveRequestPriority);

            Response<DataLakeLease> changeResponse = await lease.ChangeAsync(
                Recording.Random.NewGuid().ToString(),
                new DataLakeLeaseChangeOptions { RequestPriority = priority });
            Assert.AreEqual(ExpectedEffectivePriority(priority), changeResponse.Value.EffectiveRequestPriority);

            Response<DataLakeLease> breakResponse = await lease.BreakAsync(
                new DataLakeLeaseBreakOptions { BreakPeriod = TimeSpan.Zero, RequestPriority = priority });
            Assert.AreEqual(ExpectedEffectivePriority(priority), breakResponse.Value.EffectiveRequestPriority);
        }
        #endregion Lease

        #region File system
        [RecordedTest]
        public async Task FileSystemGetProperties_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();

            Response<FileSystemProperties> response = await test.FileSystem.GetPropertiesAsync(
                new DataLakeFileSystemGetPropertiesOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task FileSystemSetMetadata_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();

            Response<Models.FileSystemInfo> response = await test.FileSystem.SetMetadataAsync(
                new Dictionary<string, string> { { "key", "value" } },
                new DataLakeFileSystemSetMetadataOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task FileSystemGetAccessPolicy_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();

            Response<FileSystemAccessPolicy> response = await test.FileSystem.GetAccessPolicyAsync(
                new DataLakeFileSystemGetAccessPolicyOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task FileSystemExists_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();

            Response<bool> response = await test.FileSystem.ExistsAsync(
                new DataLakeFileSystemExistsOptions { RequestPriority = priority });

            Assert.IsTrue(response.Value);
            AssertRawPriority(response.GetRawResponse(), priority);
        }

        [RecordedTest]
        public async Task GetPaths_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            await CreateFileAsync(test.FileSystem);
            await CreateFileAsync(test.FileSystem);

            List<PathItem> items = new List<PathItem>();
            await foreach (Page<PathItem> page in test.FileSystem
                .GetPathsAsync(new DataLakeGetPathsOptions { RequestPriority = priority })
                .AsPages(pageSizeHint: 1))
            {
                AssertRawPriority(page.GetRawResponse(), priority);
                items.AddRange(page.Values);
            }

            Assert.AreEqual(2, items.Count);
        }

        [RecordedTest]
        public async Task FileSystemCreateDelete_RequestPriority()
        {
            int? priority = Priority;
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));

            Response<Models.FileSystemInfo> createResponse = await fileSystem.CreateAsync(
                new DataLakeFileSystemCreateOptions { RequestPriority = priority });
            Assert.AreEqual(ExpectedEffectivePriority(priority), createResponse.Value.EffectiveRequestPriority);

            Response deleteResponse = await fileSystem.DeleteAsync(
                new DataLakeFileSystemDeleteOptions { RequestPriority = priority });
            AssertRawPriority(deleteResponse, priority);
        }

        [RecordedTest]
        public async Task FileSystemCreateIfNotExistsDeleteIfExists_RequestPriority()
        {
            int? priority = Priority;
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));

            Response<Models.FileSystemInfo> createResponse = await fileSystem.CreateIfNotExistsAsync(
                new DataLakeFileSystemCreateOptions { RequestPriority = priority });
            Assert.AreEqual(ExpectedEffectivePriority(priority), createResponse.Value.EffectiveRequestPriority);

            Response<bool> deleteResponse = await fileSystem.DeleteIfExistsAsync(
                new DataLakeFileSystemDeleteIfExistsOptions { RequestPriority = priority });
            Assert.IsTrue(deleteResponse.Value);
            AssertRawPriority(deleteResponse.GetRawResponse(), priority);
        }

        [RecordedTest]
        public async Task FileSystemSetAccessPolicy_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();

            Response<Models.FileSystemInfo> response = await test.FileSystem.SetAccessPolicyAsync(
                new DataLakeFileSystemSetAccessPolicyOptions { RequestPriority = priority });

            Assert.AreEqual(ExpectedEffectivePriority(priority), response.Value.EffectiveRequestPriority);
        }

        [RecordedTest]
        public async Task FileSystemCreateDirectory_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();

            Response<DataLakeDirectoryClient> response = await test.FileSystem.CreateDirectoryAsync(
                GetNewDirectoryName(),
                new DataLakePathCreateOptions { RequestPriority = priority });

            AssertRawPriority(response.GetRawResponse(), priority);
        }

        [RecordedTest]
        public async Task FileSystemDeleteFile_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            string fileName = GetNewFileName();
            await test.FileSystem.CreateFileAsync(fileName);

            Response response = await test.FileSystem.DeleteFileAsync(
                fileName,
                new DataLakeFileDeleteOptions { RequestPriority = priority });

            AssertRawPriority(response, priority);
        }

        [RecordedTest]
        public async Task FileSystemDeleteDirectory_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            string directoryName = GetNewDirectoryName();
            await test.FileSystem.CreateDirectoryAsync(directoryName);

            Response response = await test.FileSystem.DeleteDirectoryAsync(
                directoryName,
                new DataLakeDirectoryDeleteOptions { RequestPriority = priority });

            AssertRawPriority(response, priority);
        }
        #endregion File system

        #region Service
        [RecordedTest]
        public async Task ServiceGetProperties_RequestPriority()
        {
            int? priority = Priority;
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();

            Response<DataLakeServiceProperties> response = await service.GetPropertiesAsync(
                new DataLakeServiceGetPropertiesOptions { RequestPriority = priority });

            AssertRawPriority(response.GetRawResponse(), priority);
        }

        [RecordedTest]
        public async Task GetFileSystems_RequestPriority()
        {
            int? priority = Priority;
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();

            await foreach (Page<FileSystemItem> page in service
                .GetFileSystemsAsync(new DataLakeServiceGetFileSystemsOptions { RequestPriority = priority })
                .AsPages(pageSizeHint: 1))
            {
                AssertRawPriority(page.GetRawResponse(), priority);
                break;
            }
        }

        [RecordedTest]
        public async Task ServiceCreateDeleteFileSystem_RequestPriority()
        {
            int? priority = Priority;
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            string fileSystemName = GetNewFileSystemName();

            Response<DataLakeFileSystemClient> createResponse = await service.CreateFileSystemAsync(
                fileSystemName,
                new DataLakeFileSystemCreateOptions { RequestPriority = priority });
            AssertRawPriority(createResponse.GetRawResponse(), priority);

            Response deleteResponse = await service.DeleteFileSystemAsync(
                fileSystemName,
                new DataLakeServiceDeleteFileSystemOptions { RequestPriority = priority });
            AssertRawPriority(deleteResponse, priority);
        }
        #endregion Service
    }
}
