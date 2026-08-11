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

            // Create a new file client with OAuth + multi-container session options.
            // CreateSession traffic flows through the provider's own pipeline, not the
            // DataLake client's, so the counting policy must be attached to both.
            var countingPolicy = new SessionAuthCountingPolicy();
            DataLakeClientOptions options = GetSessionOptions(
                countingPolicy,
                GetCountingSessionProvider(file.Uri, countingPolicy));

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

            // Create a new file client with OAuth + multi-container session options.
            // CreateSession traffic flows through the provider's own pipeline, not the
            // DataLake client's, so the counting policy must be attached to both.
            var countingPolicy = new SessionAuthCountingPolicy();
            DataLakeClientOptions options = GetSessionOptions(
                countingPolicy,
                GetCountingSessionProvider(file.Uri, countingPolicy));

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

            // Create a new file client with OAuth + multi-container session options.
            // CreateSession traffic flows through the provider's own pipeline, not the
            // DataLake client's, so the counting policy must be attached to both.
            var countingPolicy = new SessionAuthCountingPolicy();
            DataLakeClientOptions options = GetSessionOptions(
                countingPolicy,
                GetCountingSessionProvider(file.Uri, countingPolicy));

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

            // Create a new file client with OAuth + multi-container session options.
            // CreateSession traffic flows through the provider's own pipeline, not the
            // DataLake client's, so the counting policy must be attached to both.
            var countingPolicy = new SessionAuthCountingPolicy();
            DataLakeClientOptions options = GetSessionOptions(
                countingPolicy,
                GetCountingSessionProvider(file.Uri, countingPolicy));

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

        /// <summary>
        /// <see cref="SessionOptions.AccountName"/> is optional; when omitted it is
        /// derived from the request URL at signing time.
        /// </summary>
        [RecordedTest]
        [LiveOnly(Reason = "Cannot record tests caching Session authentication")]
        public async Task FileClient_Read_EnabledSession_WithoutAccountName()
        {
            // Arrange — 2 files in the same file system, so the second read exercises the
            // session cached by the first.
            await using DisposingFileSystem test = await GetNewFileSystem(service: GetServiceClient_OAuth());
            var data = GetRandomBuffer(Size);
            List<DataLakeFileClient> files = new List<DataLakeFileClient>(2);
            for (int i = 0; i < 2; i++)
            {
                DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
                await file.CreateAsync();
                using (var stream = new MemoryStream(data))
                {
                    await file.AppendAsync(stream, 0);
                    await file.FlushAsync(data.Length);
                }
                files.Add(file);
            }

            var countingPolicy = new SessionAuthCountingPolicy();
            DataLakeClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions
            {
                SessionMode = SessionMode.Enabled,
                // AccountName intentionally omitted
                SessionProvider = GetCountingSessionProvider(files[0].Uri, countingPolicy),
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);

            List<DataLakeFileClient> oauthFileClients = new List<DataLakeFileClient>(2);
            foreach (DataLakeFileClient file in files)
            {
                oauthFileClients.Add(InstrumentClient(
                    new DataLakeFileClient(
                        file.Uri,
                        TestEnvironment.Credential,
                        options)));
            }

            // Act
            countingPolicy.Start();
            foreach (DataLakeFileClient oauthFileClient in oauthFileClients)
            {
                Response<FileDownloadInfo> response = await oauthFileClient.ReadAsync();

                // Assert
                Assert.IsNotNull(response.Value.Content);
                await DrainAsync(response.Value.Content, data.Length);
            }

            Assert.AreEqual(1, countingPolicy.CreateSessionCount, "Expected one create session request for the file system");
            Assert.AreEqual(2, countingPolicy.GetSessionAuthCount,
                "Both reads should have been signed using the URL-derived account name.");
            Assert.AreEqual(0, countingPolicy.BearerGetCount, "Expected no GET requests to fall back to Bearer authorization");
        }

        [RecordedTest]
        public async Task FileClient_Read_IncorrectAccountName()
        {
            // The account name is part of the canonicalized resource in the string-to-sign,
            // so a misconfigured SessionOptions.AccountName produces a signature the service
            // cannot reproduce.

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

            var countingPolicy = new SessionAuthCountingPolicy();
            DataLakeClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions
            {
                SessionMode = SessionMode.Enabled,
                // Deliberately not the account under test.
                AccountName = "nottherightaccountname",
                SessionProvider = GetCountingSessionProvider(file.Uri, countingPolicy),
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
            await DrainAsync(response.Value.Content, data.Length);

            // Assert — a session was minted and attempted, but the read was served by bearer
            Assert.AreEqual(1, countingPolicy.CreateSessionCount,
                "Expected one create session request");
            Assert.AreEqual(1, countingPolicy.BearerGetCount,
                "Expected the read to fall back to Bearer authorization after the session signature is rejected");
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

            // Create a new FileSystemClient with OAuth + session options.
            // CreateSession traffic flows through the provider's own pipeline, not the
            // DataLake client's, so the counting policy must be attached to both.
            var countingPolicy = new SessionAuthCountingPolicy();
            DataLakeClientOptions options = GetSessionOptions(
                countingPolicy,
                GetCountingSessionProvider(test.FileSystem.Uri, countingPolicy));

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

            // Create a new ServiceClient with OAuth + session options.
            // CreateSession traffic flows through the provider's own pipeline, not the
            // DataLake client's, so the counting policy must be attached to both.
            var countingPolicy = new SessionAuthCountingPolicy();
            Uri serviceUri = new System.Uri(TestConfigHierarchicalNamespace.BlobServiceEndpoint).ToHttps();
            DataLakeClientOptions options = GetSessionOptions(
                countingPolicy,
                GetCountingSessionProvider(serviceUri, countingPolicy));

            DataLakeServiceClient oauthServiceClient = InstrumentClient(
                new DataLakeServiceClient(
                    serviceUri,
                    TestEnvironment.Credential,
                    options));
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

            // Create a new DirectoryClient with OAuth + session options.
            // CreateSession traffic flows through the provider's own pipeline, not the
            // DataLake client's, so the counting policy must be attached to both.
            var countingPolicy = new SessionAuthCountingPolicy();
            DataLakeClientOptions options = GetSessionOptions(
                countingPolicy,
                GetCountingSessionProvider(directory.Uri, countingPolicy));

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

        #region Customer-Supplied SessionProvider

        /// <summary>
        /// A customer-supplied <see cref="Blobs.Models.SessionProvider"/> owns the session
        /// cache independently of any client, so two separately constructed clients that
        /// share one provider must mint only a single session for the same file system.
        /// This is the scenario the provider abstraction exists to support: callers may
        /// dispose of clients and build new ones without losing their cached sessions.
        /// </summary>
        [RecordedTest]
        [LiveOnly(Reason = "Cannot record tests caching Session authentication")]
        public async Task FileClient_SharedSessionProvider_AcrossClients_CreatesSessionOnce()
        {
            // Arrange — 2 distinct files in the same file system. Different paths prove the
            // cached session is scoped to the file system rather than to any single file.
            await using DisposingFileSystem test = await GetNewFileSystem(service: GetServiceClient_OAuth());
            var data = GetRandomBuffer(Size);
            List<DataLakeFileClient> files = new List<DataLakeFileClient>(2);
            for (int i = 0; i < 2; i++)
            {
                DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
                await file.CreateAsync();
                using (var stream = new MemoryStream(data))
                {
                    await file.AppendAsync(stream, 0);
                    await file.FlushAsync(data.Length);
                }
                files.Add(file);
            }

            // CreateSession traffic flows through the provider's own pipeline, not the
            // DataLake client's, so the counting policy must be attached to both.
            var countingPolicy = new SessionAuthCountingPolicy();

            Blobs.BlobClientOptions providerOptions = GetBlobOptionsForProvider(countingPolicy);
            var sessionProvider = new Blobs.Models.ContainerSessionProvider(
                GetBlobServiceUri(files[0].Uri),
                TestEnvironment.Credential,
                providerOptions);

            // Act — two independently constructed clients sharing one provider.
            countingPolicy.Start();

            DataLakeFileClient firstClient = InstrumentClient(
                new DataLakeFileClient(
                    files[0].Uri,
                    TestEnvironment.Credential,
                    GetSessionOptions(countingPolicy, sessionProvider)));
            Response<FileDownloadInfo> firstResponse = await firstClient.ReadAsync();
            await DrainAsync(firstResponse.Value.Content, data.Length);

            DataLakeFileClient secondClient = InstrumentClient(
                new DataLakeFileClient(
                    files[1].Uri,
                    TestEnvironment.Credential,
                    GetSessionOptions(countingPolicy, sessionProvider)));
            Response<FileDownloadInfo> secondResponse = await secondClient.ReadAsync();
            await DrainAsync(secondResponse.Value.Content, data.Length);

            // Assert
            Assert.AreEqual(1, countingPolicy.CreateSessionCount,
                "Clients sharing a SessionProvider should reuse a single cached session.");
            Assert.AreEqual(2, countingPolicy.GetSessionAuthCount,
                "Both reads should have used Session authorization.");
            Assert.AreEqual(0, countingPolicy.BearerGetCount,
                "Expected no GET requests to fall back to Bearer authorization");
        }

        /// <summary>
        /// ReadTo fans a single logical read out into multiple ranged GETs. Combined with a
        /// shared provider and a cold cache, concurrent reads from independently constructed
        /// clients race session acquisition at once; the provider must collapse that race
        /// into a single session for the file system.
        /// </summary>
        [RecordedTest]
        [LiveOnly(Reason = "Cannot record tests caching Session authentication")]
        public async Task FileClient_SharedSessionProvider_ConcurrentReadTo_CreatesSessionOnce()
        {
            // Arrange — 2 distinct files in the same file system, each large enough that the
            // transfer options below force the read into multiple ranged GETs.
            await using DisposingFileSystem test = await GetNewFileSystem(service: GetServiceClient_OAuth());
            var data = GetRandomBuffer(10 * Constants.KB);
            List<DataLakeFileClient> files = new List<DataLakeFileClient>(2);
            for (int i = 0; i < 2; i++)
            {
                DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
                await file.CreateAsync();
                using (var stream = new MemoryStream(data))
                {
                    await file.AppendAsync(stream, 0);
                    await file.FlushAsync(data.Length);
                }
                files.Add(file);
            }

            // CreateSession traffic flows through the provider's own pipeline, not the
            // DataLake client's, so the counting policy must be attached to both.
            var countingPolicy = new SessionAuthCountingPolicy();

            Blobs.BlobClientOptions providerOptions = GetBlobOptionsForProvider(countingPolicy);
            var sessionProvider = new Blobs.Models.ContainerSessionProvider(
                GetBlobServiceUri(files[0].Uri),
                TestEnvironment.Credential,
                providerOptions);

            List<DataLakeFileClient> oauthFileClients = new List<DataLakeFileClient>(2);
            foreach (DataLakeFileClient file in files)
            {
                oauthFileClients.Add(InstrumentClient(
                    new DataLakeFileClient(
                        file.Uri,
                        TestEnvironment.Credential,
                        GetSessionOptions(countingPolicy, sessionProvider))));
            }

            // Act — run both partitioned reads concurrently against a cold cache.
            countingPolicy.Start();
            List<MemoryStream> destinations = new List<MemoryStream>(oauthFileClients.Count);
            List<Task> reads = new List<Task>(oauthFileClients.Count);
            foreach (DataLakeFileClient oauthFileClient in oauthFileClients)
            {
                var destination = new MemoryStream();
                destinations.Add(destination);
                reads.Add(oauthFileClient.ReadToAsync(
                    destination,
                    new DataLakeFileReadToOptions
                    {
                        TransferOptions = new StorageTransferOptions
                        {
                            InitialTransferSize = Constants.KB,
                            MaximumTransferSize = Constants.KB,
                            MaximumConcurrency = 4
                        }
                    }));
            }
            await Task.WhenAll(reads);

            // Assert — verify data was read correctly
            foreach (MemoryStream destination in destinations)
            {
                Assert.AreEqual(data.Length, destination.Length);
                destination.Dispose();
            }

            // Assert — the concurrent cold-cache race collapses to a single session
            Assert.AreEqual(1, countingPolicy.CreateSessionCount,
                "Clients sharing a SessionProvider should mint one session, even when concurrent partitioned reads race a cold cache.");
            Assert.Greater(countingPolicy.GetSessionAuthCount, oauthFileClients.Count,
                "Expected each read to fan out into multiple ranged GETs using Session authorization.");
            Assert.AreEqual(0, countingPolicy.BearerGetCount,
                "Expected no GET requests to fall back to Bearer authorization");
        }

        #endregion

        #region Helper Classes

        /// <summary>
        /// Builds a <see cref="Blobs.Models.ContainerSessionProvider"/> whose internal
        /// session-minting pipeline carries <paramref name="countingPolicy"/>. CreateSession
        /// requests never traverse the DataLake client's pipeline, so a test that asserts on
        /// <see cref="SessionAuthCountingPolicy.CreateSessionCount"/> must supply the provider
        /// explicitly rather than relying on the one the client creates by default.
        /// </summary>
        private Blobs.Models.ContainerSessionProvider GetCountingSessionProvider(
            Uri uri,
            HttpPipelinePolicy countingPolicy)
            => new Blobs.Models.ContainerSessionProvider(
                GetBlobServiceUri(uri),
                TestEnvironment.Credential,
                GetBlobOptionsForProvider(countingPolicy));

        /// <summary>
        /// Builds <see cref="DataLakeClientOptions"/> wired to a customer-supplied
        /// <paramref name="sessionProvider"/>.
        /// </summary>
        private DataLakeClientOptions GetSessionOptions(
            HttpPipelinePolicy countingPolicy,
            Blobs.Models.SessionProvider sessionProvider)
        {
            DataLakeClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions
            {
                SessionMode = SessionMode.Enabled,
                AccountName = TestConfigHierarchicalNamespace.AccountName,
                SessionProvider = sessionProvider,
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);
            return options;
        }

        /// <summary>
        /// Builds the <see cref="Blobs.BlobClientOptions"/> used by a standalone
        /// <see cref="Blobs.Models.ContainerSessionProvider"/>, carrying the same
        /// recording transport as the DataLake clients so CreateSession calls are both
        /// recorded and counted.
        /// </summary>
        private Blobs.BlobClientOptions GetBlobOptionsForProvider(HttpPipelinePolicy countingPolicy)
        {
            var options = new Blobs.BlobClientOptions();
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);
            return InstrumentClientOptions(options);
        }

        /// <summary>
        /// Maps a DFS endpoint to its blob counterpart, which is where sessions are minted.
        /// </summary>
        private static Uri GetBlobServiceUri(Uri dfsUri)
        {
            var builder = new UriBuilder(dfsUri)
            {
                Host = dfsUri.Host.Replace(".dfs.", ".blob."),
                Path = string.Empty,
                Query = string.Empty,
            };
            return builder.Uri;
        }

        private static async Task DrainAsync(Stream content, long expectedLength)
        {
            Assert.IsNotNull(content);
            using var reader = new MemoryStream();
            await content.CopyToAsync(reader);
            Assert.AreEqual(expectedLength, reader.Length);
        }

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
