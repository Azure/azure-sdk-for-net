// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Files.DataLake.Specialized;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class RequestPriorityTests : DataLakeTestBase
    {
        private const string RequestPriorityHeaderName = "x-ms-request-priority";
        private const int DefaultServicePriority = 3;

        public RequestPriorityTests(bool async, DataLakeClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        private DataLakeServiceClient GetServiceClient(int? requestPriority, AssertMessageContentsPolicy policy)
        {
            DataLakeClientOptions options = GetOptions();
            options.RequestPriority = requestPriority;
            options.AddPolicy(policy, HttpPipelinePosition.BeforeTransport);
            return InstrumentClient(new DataLakeServiceClient(
                new Uri(TestConfigHierarchicalNamespace.BlobServiceEndpoint),
                GetStorageSharedKeyCredentials(),
                options));
        }

        /// <summary>
        /// The service honors priorities from 0 through 7. Unset or out-of-range
        /// values fall back to the default priority of 3.
        /// </summary>
        private static int GetEffectivePriority(int? requestPriority)
            => requestPriority is >= 0 and <= 7 ? requestPriority.Value : DefaultServicePriority;

        private static AssertMessageContentsPolicy GetAssertPolicy(int? requestPriority, List<string> observedRequests)
            => new AssertMessageContentsPolicy(
                checkRequest: request =>
                {
                    observedRequests.Add($"{request.Method} {request.Uri}");
                    if (requestPriority.HasValue)
                    {
                        Assert.IsTrue(
                            request.Headers.TryGetValue(RequestPriorityHeaderName, out string value),
                            $"Missing {RequestPriorityHeaderName} header on {request.Method} {request.Uri}");
                        Assert.AreEqual(requestPriority.Value.ToString(), value);
                    }
                    else
                    {
                        Assert.IsFalse(
                            request.Headers.TryGetValue(RequestPriorityHeaderName, out _),
                            $"Unexpected {RequestPriorityHeaderName} header on {request.Method} {request.Uri}");
                    }
                });

        private static void AssertResponsePriority(Response response, int? requestPriority)
        {
            Assert.IsTrue(
                response.Headers.TryGetValue(RequestPriorityHeaderName, out string value),
                $"Missing {RequestPriorityHeaderName} response header");
            Assert.AreEqual(GetEffectivePriority(requestPriority).ToString(), value);
        }

        [RecordedTest]
        [TestCase(null)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(7)]
        [TestCase(8)]
        public async Task RequestPriority_SingleRequestOperations(int? priority)
        {
            // Arrange
            List<string> observedRequests = new();
            AssertMessageContentsPolicy policy = GetAssertPolicy(priority, observedRequests);
            DataLakeServiceClient service = GetServiceClient(priority, policy);
            await using DisposingFileSystem test = await GetNewFileSystem(service: service);
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));

            using (policy.CheckRequestScope())
            {
                // Act - DFS endpoint
                Response<PathInfo> create = await file.CreateAsync();
                Response<PathAccessControl> accessControl = await file.GetAccessControlAsync();

                // Act - Blob endpoint (internal Blob clients)
                Response<PathProperties> properties = await file.GetPropertiesAsync();
                Response<FileSystemProperties> fileSystemProperties = await test.FileSystem.GetPropertiesAsync();
                Response<DataLakeServiceProperties> serviceProperties = await service.GetPropertiesAsync();

                DataLakeLeaseClient lease = InstrumentClient(file.GetDataLakeLeaseClient(Recording.Random.NewGuid().ToString()));
                Response<DataLakeLease> acquired = await lease.AcquireAsync(TimeSpan.FromSeconds(15));
                Response<ReleasedObjectInfo> released = await lease.ReleaseAsync();

                // Assert
                AssertResponsePriority(create.GetRawResponse(), priority);
                AssertResponsePriority(accessControl.GetRawResponse(), priority);
                AssertResponsePriority(properties.GetRawResponse(), priority);
                AssertResponsePriority(fileSystemProperties.GetRawResponse(), priority);
                AssertResponsePriority(serviceProperties.GetRawResponse(), priority);
                AssertResponsePriority(acquired.GetRawResponse(), priority);
                AssertResponsePriority(released.GetRawResponse(), priority);
            }

            Assert.IsNotEmpty(observedRequests);
        }

        [RecordedTest]
        [TestCase(null)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(7)]
        [TestCase(8)]
        public async Task RequestPriority_MultiRequestOperations(int? priority)
        {
            // Arrange
            const int dataSize = 4 * Constants.KB;
            List<string> observedRequests = new();
            AssertMessageContentsPolicy policy = GetAssertPolicy(priority, observedRequests);
            DataLakeServiceClient service = GetServiceClient(priority, policy);
            await using DisposingFileSystem test = await GetNewFileSystem(service: service);
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            byte[] data = GetRandomBuffer(dataSize);
            byte[] appendData = GetRandomBuffer(Constants.KB);
            StorageTransferOptions transferOptions = new()
            {
                InitialTransferSize = Constants.KB,
                MaximumTransferSize = Constants.KB,
                MaximumConcurrency = 1,
            };

            using (policy.CheckRequestScope())
            {
                await directory.CreateAsync();

                // Act - partitioned upload (create + appends + flush)
                await file.UploadAsync(
                    new MemoryStream(data),
                    new DataLakeFileUploadOptions { TransferOptions = transferOptions });

                // Act - explicit append + flush
                Response append = await file.AppendAsync(new MemoryStream(appendData), offset: dataSize);
                Response<PathInfo> flush = await file.FlushAsync(position: dataSize + appendData.Length);

                // Act - partitioned download (multiple ranged GETs)
                using MemoryStream destination = new();
                Response download = await file.ReadToAsync(
                    destination,
                    new DataLakeFileReadToOptions { TransferOptions = transferOptions });

                // Act - paging
                List<PathItem> paths = new();
                await foreach (Page<PathItem> page in test.FileSystem.GetPathsAsync(new DataLakeGetPathsOptions { Recursive = true }).AsPages(pageSizeHint: 1))
                {
                    paths.AddRange(page.Values);
                    AssertResponsePriority(page.GetRawResponse(), priority);
                }

                // Act - recursive ACL in batches (multiple continuation requests)
                await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
                await directory.CreateFileAsync(GetNewFileName());
                Response<AccessControlChangeResult> aclResult = await directory.SetAccessControlRecursiveAsync(
                    AccessControlList,
                    options: new AccessControlChangeOptions { BatchSize = 1 });

                // Assert
                AssertResponsePriority(append, priority);
                AssertResponsePriority(flush.GetRawResponse(), priority);
                AssertResponsePriority(download, priority);
                CollectionAssert.AreEqual(data.Concat(appendData).ToArray(), destination.ToArray());
                Assert.AreEqual(2, paths.Count);
                Assert.AreEqual(2, aclResult.Value.Counters.ChangedDirectoriesCount);
                Assert.AreEqual(2, aclResult.Value.Counters.ChangedFilesCount);
                Assert.AreEqual(0, aclResult.Value.Counters.FailedChangesCount);
            }

            // Upload: create + 4 appends + flush; append + flush; download: 5 ranged GETs;
            // list: 2 pages; recursive ACL: multiple batches.
            Assert.GreaterOrEqual(observedRequests.Count, 18);
        }

        [RecordedTest]
        [TestCase(null)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(7)]
        [TestCase(8)]
        public async Task RequestPriority_DerivedClientsInheritPriority(int? priority)
        {
            // Arrange
            List<string> observedRequests = new();
            AssertMessageContentsPolicy policy = GetAssertPolicy(priority, observedRequests);
            DataLakeServiceClient service = GetServiceClient(priority, policy);
            await using DisposingFileSystem test = await GetNewFileSystem(service: service);

            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            DataLakeDirectoryClient subdirectory = InstrumentClient(directory.GetSubDirectoryClient(GetNewDirectoryName()));
            DataLakeFileClient file = InstrumentClient(subdirectory.GetFileClient(GetNewFileName()));
            DataLakeFileClient rootFile = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));

            using (policy.CheckRequestScope())
            {
                // Act
                Response<PathInfo> directoryCreate = await directory.CreateAsync();
                Response<PathInfo> subdirectoryCreate = await subdirectory.CreateAsync();
                Response<PathInfo> fileCreate = await file.CreateAsync();
                Response<PathInfo> rootFileCreate = await rootFile.CreateAsync();

                DataLakeDirectoryClient parentDirectory = InstrumentClient(file.GetParentDirectoryClient());
                Response<PathProperties> parentDirectoryProperties = await parentDirectory.GetPropertiesAsync();

                DataLakeFileSystemClient parentFileSystem = InstrumentClient(file.GetParentFileSystemClient());
                Response<FileSystemProperties> parentFileSystemProperties = await parentFileSystem.GetPropertiesAsync();

                DataLakeServiceClient parentService = InstrumentClient(parentFileSystem.GetParentServiceClient());
                Response<DataLakeServiceProperties> parentServiceProperties = await parentService.GetPropertiesAsync();

                DataLakeFileClient renamed = InstrumentClient(
                    (await file.RenameAsync($"{directory.Path}/{GetNewFileName()}")).Value);
                Response<PathProperties> renamedProperties = await renamed.GetPropertiesAsync();
                Response<PathAccessControl> renamedAccessControl = await renamed.GetAccessControlAsync();

                // Assert
                AssertResponsePriority(directoryCreate.GetRawResponse(), priority);
                AssertResponsePriority(subdirectoryCreate.GetRawResponse(), priority);
                AssertResponsePriority(fileCreate.GetRawResponse(), priority);
                AssertResponsePriority(rootFileCreate.GetRawResponse(), priority);
                AssertResponsePriority(parentDirectoryProperties.GetRawResponse(), priority);
                AssertResponsePriority(parentFileSystemProperties.GetRawResponse(), priority);
                AssertResponsePriority(parentServiceProperties.GetRawResponse(), priority);
                AssertResponsePriority(renamedProperties.GetRawResponse(), priority);
                AssertResponsePriority(renamedAccessControl.GetRawResponse(), priority);
            }

            Assert.IsNotEmpty(observedRequests);
        }
    }
}
