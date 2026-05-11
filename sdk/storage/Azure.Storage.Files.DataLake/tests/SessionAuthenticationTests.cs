// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Files.DataLake.Models;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class SessionAuthenticationTests : PathTestBase
    {
        private const long Size = 4 * Constants.KB;

        public SessionAuthenticationTests(bool async, DataLakeClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        #region DataLakeFileClient Tests

        [RecordedTest]
        public async Task FileClient_Read_EnabledSession()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem(service: GetServiceClient_OAuth());
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateAsync();

            var data = GetRandomBuffer(Size);
            using (var stream = new MemoryStream(data))
            {
                await file.AppendAsync(stream, 0);
                await file.FlushAsync(data.Length);
            }

            // Create a new file client with OAuth + multi-container session options
            var countingPolicy = new SessionAuthCountingPolicy();
            DataLakeClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions
            {
                SessionMode = SessionMode.Enabled,
                AccountName = TestConfigHierarchicalNamespace.AccountName,
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);

            DataLakeFileClient oauthFileClient = InstrumentClient(
                new DataLakeFileClient(
                    file.Uri,
                    TestEnvironment.Credential,
                    options));

            // Act
            countingPolicy.Start();
            Response<FileDownloadInfo> response = await oauthFileClient.ReadAsync();

            // Assert
            Assert.IsNotNull(response.Value.Content);
            using var reader = new MemoryStream();
            await response.Value.Content.CopyToAsync(reader);
            Assert.AreEqual(data.Length, reader.Length);

            Assert.AreEqual(1, countingPolicy.CreateSessionCount, "Expected one create session request");
            Assert.AreEqual(1, countingPolicy.GetSessionAuthCount, "Expected the download request to use Session authorization");
            Assert.AreEqual(0, countingPolicy.BearerGetCount, "Expected no GET requests to fall back to Bearer authorization");
        }

        [RecordedTest]
        public async Task FileClient_ReadStreaming_EnabledSession()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem(service: GetServiceClient_OAuth());
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateAsync();

            var data = GetRandomBuffer(Size);
            using (var stream = new MemoryStream(data))
            {
                await file.AppendAsync(stream, 0);
                await file.FlushAsync(data.Length);
            }

            // Create a new file client with OAuth + multi-container session options
            var countingPolicy = new SessionAuthCountingPolicy();
            DataLakeClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions
            {
                SessionMode = SessionMode.Enabled,
                AccountName = TestConfigHierarchicalNamespace.AccountName,
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);

            DataLakeFileClient oauthFileClient = InstrumentClient(
                new DataLakeFileClient(
                    file.Uri,
                    TestEnvironment.Credential,
                    options));

            // Act
            countingPolicy.Start();
            Response<DataLakeFileReadStreamingResult> response = await oauthFileClient.ReadStreamingAsync();

            // Assert
            Assert.IsNotNull(response.Value.Content);
            using var reader = new MemoryStream();
            await response.Value.Content.CopyToAsync(reader);
            Assert.AreEqual(data.Length, reader.Length);

            Assert.AreEqual(1, countingPolicy.CreateSessionCount, "Expected one create session request");
            Assert.AreEqual(1, countingPolicy.GetSessionAuthCount, "Expected the read request to use Session authorization");
            Assert.AreEqual(0, countingPolicy.BearerGetCount, "Expected no GET requests to fall back to Bearer authorization");
        }

        [RecordedTest]
        public async Task FileClient_ReadContent_EnabledSession()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem(service: GetServiceClient_OAuth());
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateAsync();

            var data = GetRandomBuffer(Size);
            using (var stream = new MemoryStream(data))
            {
                await file.AppendAsync(stream, 0);
                await file.FlushAsync(data.Length);
            }

            // Create a new file client with OAuth + multi-container session options
            var countingPolicy = new SessionAuthCountingPolicy();
            DataLakeClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions
            {
                SessionMode = SessionMode.Enabled,
                AccountName = TestConfigHierarchicalNamespace.AccountName,
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);

            DataLakeFileClient oauthFileClient = InstrumentClient(
                new DataLakeFileClient(
                    file.Uri,
                    TestEnvironment.Credential,
                    options));

            // Act
            countingPolicy.Start();
            Response<DataLakeFileReadResult> response = await oauthFileClient.ReadContentAsync();

            // Assert
            Assert.IsNotNull(response.Value.Content);
            Assert.AreEqual(data.Length, response.Value.Content.ToMemory().Length);

            Assert.AreEqual(1, countingPolicy.CreateSessionCount, "Expected one create session request");
            Assert.AreEqual(1, countingPolicy.GetSessionAuthCount, "Expected the read request to use Session authorization");
            Assert.AreEqual(0, countingPolicy.BearerGetCount, "Expected no GET requests to fall back to Bearer authorization");
        }

        [RecordedTest]
        public async Task FileClient_ReadTo_EnabledSession()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem(service: GetServiceClient_OAuth());
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateAsync();

            var data = GetRandomBuffer(Size);
            using (var stream = new MemoryStream(data))
            {
                await file.AppendAsync(stream, 0);
                await file.FlushAsync(data.Length);
            }

            // Create a new file client with OAuth + multi-container session options
            var countingPolicy = new SessionAuthCountingPolicy();
            DataLakeClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions
            {
                SessionMode = SessionMode.Enabled,
                AccountName = TestConfigHierarchicalNamespace.AccountName,
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);

            DataLakeFileClient oauthFileClient = InstrumentClient(
                new DataLakeFileClient(
                    file.Uri,
                    TestEnvironment.Credential,
                    options));

            // Act — download into a destination stream
            countingPolicy.Start();
            using var destination = new MemoryStream();
            Response response = await oauthFileClient.ReadToAsync(destination);

            // Assert
            Assert.AreEqual(data.Length, destination.Length);

            // Note: ReadToAsync may issue *more than one* GET if the file is large enough
            // to trigger parallel/ranged downloads. With Size = 4 KB and default options,
            // we expect a single GET, but assert with >= 1 to keep the test robust to
            // future changes in the default download partitioning threshold.
            Assert.AreEqual(1, countingPolicy.CreateSessionCount,
                "Expected one create session request — the per-container cache should serve all parallel reads.");
            Assert.GreaterOrEqual(countingPolicy.GetSessionAuthCount, 1,
                "Expected the read request(s) to use Session authorization");
            Assert.AreEqual(0, countingPolicy.BearerGetCount,
                "Expected no GET requests to fall back to Bearer authorization");
        }

        [RecordedTest]
        public async Task FileClient_Read_DisabledSession_UsesBearer()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem(service: GetServiceClient_OAuth());
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateAsync();

            var data = GetRandomBuffer(Size);
            using (var stream = new MemoryStream(data))
            {
                await file.AppendAsync(stream, 0);
                await file.FlushAsync(data.Length);
            }

            // Create a new file client with OAuth + SessionMode.None
            var countingPolicy = new SessionAuthCountingPolicy();
            DataLakeClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions
            {
                SessionMode = SessionMode.Disabled,
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);

            DataLakeFileClient oauthFileClient = InstrumentClient(
                new DataLakeFileClient(
                    file.Uri,
                    TestEnvironment.Credential,
                    options));

            // Act - should succeed using bearer token
            countingPolicy.Start();
            Response<FileDownloadInfo> response = await oauthFileClient.ReadAsync();

            // Assert
            Assert.IsNotNull(response.Value.Content);
            using var reader = new MemoryStream();
            await response.Value.Content.CopyToAsync(reader);
            Assert.AreEqual(data.Length, reader.Length);

            Assert.AreEqual(0, countingPolicy.CreateSessionCount, "Expected no create session requests when disabled");
            Assert.AreEqual(0, countingPolicy.GetSessionAuthCount, "Expected no Session authorization when disabled");
            Assert.AreEqual(1, countingPolicy.BearerGetCount, "Expected the GET request to use Bearer authorization");
        }

        [RecordedTest]
        public async Task FileClient_Create_EnabledSession_UsesBearer()
        {
            // Arrange - verify non-GET operations work with session options configured
            await using DisposingFileSystem test = await GetNewFileSystem(service: GetServiceClient_OAuth());

            var countingPolicy = new SessionAuthCountingPolicy();
            DataLakeClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions
            {
                SessionMode = SessionMode.Enabled,
                AccountName = TestConfigHierarchicalNamespace.AccountName,
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);

            DataLakeFileClient oauthFileClient = InstrumentClient(
                new DataLakeFileClient(
                    test.FileSystem.GetFileClient(GetNewFileName()).Uri,
                    TestEnvironment.Credential,
                    options));

            // Act - Create is a PUT, should fall through to bearer token
            countingPolicy.Start();
            Response<PathInfo> response = await oauthFileClient.CreateAsync();

            // Assert
            Assert.IsNotNull(response.Value);
            AssertValidStoragePathInfo(response.Value);

            Assert.AreEqual(0, countingPolicy.GetSessionAuthCount, "Expected no Session authorization for non-GET operations");
            Assert.AreEqual(0, countingPolicy.BearerGetCount, "Expected no Bearer GET requests for a PUT operation");
        }

        #endregion

        #region DataLakeFileSystemClient Tests

        [RecordedTest]
        public async Task FileSystemClient_GetFileClient_Read_EnabledSession()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem(service: GetServiceClient_OAuth());
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateAsync();

            var data = GetRandomBuffer(Size);
            using (var stream = new MemoryStream(data))
            {
                await file.AppendAsync(stream, 0);
                await file.FlushAsync(data.Length);
            }

            // Create a new FileSystemClient with OAuth + session options
            var countingPolicy = new SessionAuthCountingPolicy();
            DataLakeClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions
            {
                SessionMode = SessionMode.Enabled,
                AccountName = TestConfigHierarchicalNamespace.AccountName,
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);

            DataLakeFileSystemClient oauthFsClient = InstrumentClient(
                new DataLakeFileSystemClient(
                    test.FileSystem.Uri,
                    TestEnvironment.Credential,
                    options));

            // Get a file client from the filesystem client — should share the session-enabled pipeline
            DataLakeFileClient childFileClient = InstrumentClient(oauthFsClient.GetFileClient(file.Name));

            // Act
            countingPolicy.Start();
            Response<FileDownloadInfo> response = await childFileClient.ReadAsync();

            // Assert
            Assert.IsNotNull(response.Value.Content);
            using var reader = new MemoryStream();
            await response.Value.Content.CopyToAsync(reader);
            Assert.AreEqual(data.Length, reader.Length);

            Assert.AreEqual(1, countingPolicy.CreateSessionCount, "Expected one create session request");
            Assert.AreEqual(1, countingPolicy.GetSessionAuthCount, "Expected the download request to use Session authorization");
            Assert.AreEqual(0, countingPolicy.BearerGetCount, "Expected no GET requests to fall back to Bearer authorization");
        }

        [RecordedTest]
        public async Task FileSystemClient_GetPaths_EnabledSession_UsesBearer()
        {
            // Arrange — ListPaths is a DFS GET at the container level (no blob name),
            // so SessionAuthenticationPolicy should fall back to Bearer.
            await using DisposingFileSystem test = await GetNewFileSystem(service: GetServiceClient_OAuth());
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateAsync();

            var countingPolicy = new SessionAuthCountingPolicy();
            DataLakeClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions
            {
                SessionMode = SessionMode.Enabled,
                AccountName = TestConfigHierarchicalNamespace.AccountName,
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);

            DataLakeFileSystemClient oauthFsClient = InstrumentClient(
                new DataLakeFileSystemClient(
                    test.FileSystem.Uri,
                    TestEnvironment.Credential,
                    options));

            // Act
            countingPolicy.Start();
            IList<PathItem> paths = await oauthFsClient.GetPathsAsync().ToListAsync();

            // Assert — the file we created should appear
            Assert.IsTrue(paths.Count >= 1, "Expected at least one path from ListPaths");

            // ListPaths is a container-level GET (no blob name), so it must NOT use session auth
            Assert.AreEqual(0, countingPolicy.CreateSessionCount, "Expected no create session requests for ListPaths");
            Assert.AreEqual(0, countingPolicy.GetSessionAuthCount, "Expected no Session authorization for ListPaths");
            Assert.AreEqual(1, countingPolicy.BearerGetCount, "Expected ListPaths GET request(s) to use Bearer authorization");
        }

        #endregion

        #region DataLakeServiceClient Tests

        [RecordedTest]
        public async Task ServiceClient_GetFileSystemClient_GetFileClient_Read_EnabledSession()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem(service: GetServiceClient_OAuth());
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await file.CreateAsync();

            var data = GetRandomBuffer(Size);
            using (var stream = new MemoryStream(data))
            {
                await file.AppendAsync(stream, 0);
                await file.FlushAsync(data.Length);
            }

            // Create a new ServiceClient with OAuth + session options
            var countingPolicy = new SessionAuthCountingPolicy();
            DataLakeClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions
            {
                SessionMode = SessionMode.Enabled,
                AccountName = TestConfigHierarchicalNamespace.AccountName,
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);

            DataLakeServiceClient oauthServiceClient = InstrumentClient(
                new DataLakeServiceClient(
                    new System.Uri(TestConfigHierarchicalNamespace.BlobServiceEndpoint).ToHttps(),
                    TestEnvironment.Credential,
                    options));

            // Navigate the full hierarchy: service → filesystem → file
            DataLakeFileSystemClient fsClient = InstrumentClient(oauthServiceClient.GetFileSystemClient(test.FileSystem.Name));
            DataLakeFileClient childFileClient = InstrumentClient(fsClient.GetFileClient(file.Name));

            // Act
            countingPolicy.Start();
            Response<FileDownloadInfo> response = await childFileClient.ReadAsync();

            // Assert
            Assert.IsNotNull(response.Value.Content);
            using var reader = new MemoryStream();
            await response.Value.Content.CopyToAsync(reader);
            Assert.AreEqual(data.Length, reader.Length);

            Assert.AreEqual(1, countingPolicy.CreateSessionCount, "Expected one create session request");
            Assert.AreEqual(1, countingPolicy.GetSessionAuthCount, "Expected the download request to use Session authorization");
            Assert.AreEqual(0, countingPolicy.BearerGetCount, "Expected no GET requests to fall back to Bearer authorization");
        }

        [RecordedTest]
        public async Task ServiceClient_GetFileSystemsAsync_EnabledSession_UsesBearer()
        {
            // Arrange — GetFileSystemsAsync delegates to BlobServiceClient.GetBlobContainersAsync
            // which is a blob-endpoint GET with comp=list, so SessionAuthenticationPolicy should
            // reject it (comp query param guard) and fall back to Bearer.
            await using DisposingFileSystem test = await GetNewFileSystem(service: GetServiceClient_OAuth());

            var countingPolicy = new SessionAuthCountingPolicy();
            DataLakeClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions
            {
                SessionMode = SessionMode.Enabled,
                AccountName = TestConfigHierarchicalNamespace.AccountName,
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);

            DataLakeServiceClient oauthServiceClient = InstrumentClient(
                new DataLakeServiceClient(
                    new System.Uri(TestConfigHierarchicalNamespace.BlobServiceEndpoint).ToHttps(),
                    TestEnvironment.Credential,
                    options));

            // Act
            countingPolicy.Start();
            IList<FileSystemItem> fileSystems = await oauthServiceClient.GetFileSystemsAsync().ToListAsync();

            // Assert — at least the filesystem we created should appear
            Assert.IsTrue(fileSystems.Count >= 1, "Expected at least one file system");

            // GetBlobContainersAsync has comp=list, so it must NOT use session auth
            Assert.AreEqual(0, countingPolicy.CreateSessionCount, "Expected no create session requests for GetFileSystems");
            Assert.AreEqual(0, countingPolicy.GetSessionAuthCount, "Expected no Session authorization for GetFileSystems");
            Assert.IsTrue(countingPolicy.BearerGetCount >= 1, "Expected GetFileSystems GET request(s) to use Bearer authorization");
        }

        #endregion

        #region DataLakeDirectoryClient Tests

        [RecordedTest]
        public async Task DirectoryClient_GetFileClient_Read_EnabledSession()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem(service: GetServiceClient_OAuth());
            string directoryName = GetNewDirectoryName();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            string fileName = GetNewFileName();
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(fileName));
            await file.CreateAsync();

            var data = GetRandomBuffer(Size);
            using (var stream = new MemoryStream(data))
            {
                await file.AppendAsync(stream, 0);
                await file.FlushAsync(data.Length);
            }

            // Create a new DirectoryClient with OAuth + session options
            var countingPolicy = new SessionAuthCountingPolicy();
            DataLakeClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions
            {
                SessionMode = SessionMode.Enabled,
                AccountName = TestConfigHierarchicalNamespace.AccountName,
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);

            DataLakeDirectoryClient oauthDirClient = InstrumentClient(
                new DataLakeDirectoryClient(
                    directory.Uri,
                    TestEnvironment.Credential,
                    options));

            // Get a file client from the directory client
            DataLakeFileClient childFileClient = InstrumentClient(oauthDirClient.GetFileClient(fileName));

            // Act
            countingPolicy.Start();
            Response<FileDownloadInfo> response = await childFileClient.ReadAsync();

            // Assert
            Assert.IsNotNull(response.Value.Content);
            using var reader = new MemoryStream();
            await response.Value.Content.CopyToAsync(reader);
            Assert.AreEqual(data.Length, reader.Length);

            Assert.AreEqual(1, countingPolicy.CreateSessionCount, "Expected one create session request");
            Assert.AreEqual(1, countingPolicy.GetSessionAuthCount, "Expected the download request to use Session authorization");
            Assert.AreEqual(0, countingPolicy.BearerGetCount, "Expected no GET requests to fall back to Bearer authorization");
        }

        #endregion

        #region Helper Classes

        /// <summary>
        /// Thread-safe pipeline policy that counts session-auth and CreateSession
        /// requests. Used by session tests to assert the correct authentication
        /// strategy without manual message iteration.
        /// </summary>
        private class SessionAuthCountingPolicy : HttpPipelineSynchronousPolicy
        {
            private int _getSessionAuthCount;
            private int _createSessionCount;
            private int _bearerGetCount;
            private volatile bool _enabled;

            public int GetSessionAuthCount => _getSessionAuthCount;
            public int CreateSessionCount => _createSessionCount;
            public int BearerGetCount => _bearerGetCount;

            public void Start() => _enabled = true;

            public override void OnReceivedResponse(HttpMessage message)
            {
                if (!_enabled)
                {
                    return;
                }

                bool hasAuth = message.Request.Headers.TryGetValue("Authorization", out string authHeader);
                bool hasSessionAuth = hasAuth && authHeader.StartsWith("Session ", StringComparison.Ordinal);
                bool hasBearerAuth = hasAuth && authHeader.StartsWith("Bearer ", StringComparison.Ordinal);
                bool isGet = message.Request.Method == RequestMethod.Get;

                if (hasSessionAuth && isGet)
                {
                    Interlocked.Increment(ref _getSessionAuthCount);
                }

                if (hasBearerAuth && isGet)
                {
                    Interlocked.Increment(ref _bearerGetCount);
                }

                string query = message.Request.Uri.ToUri().Query;
                if (message.Request.Method == RequestMethod.Post
                    && query != null
                    && query.Contains("restype=container")
                    && query.Contains("comp=session"))
                {
                    Interlocked.Increment(ref _createSessionCount);
                }
            }
        }

        #endregion
    }
}
