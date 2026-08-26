// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class BlobBaseClientSessionAuthenticationTests : BlobTestBase
    {
        public BlobBaseClientSessionAuthenticationTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        [LiveOnly(Reason = "Cannot record tests caching Session authentication")]
        public async Task DownloadAsync_Sessions()
        {
            var containerNameA = GetNewContainerName();
            var containerNameB = GetNewContainerName();
            var countingPolicy = new SessionAuthCountingPolicy(null);
            BlobClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions()
            {
                SessionMode = SessionMode.Enabled,
                AccountName = Tenants.TestConfigOAuth.AccountName,
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);
            BlobServiceClient oauthServiceClient = GetServiceClient_OAuth(options);
            await using DisposingContainer testA = await GetTestContainerAsync(containerName: containerNameA, service: oauthServiceClient);
            await using DisposingContainer testB = await GetTestContainerAsync(containerName: containerNameB, service: oauthServiceClient);

            // Arrange — 2 blobs per container
            var data = GetRandomBuffer(Constants.KB);
            List<BlockBlobClient> blobsA = new List<BlockBlobClient>(2)
            {
                InstrumentClient(testA.Container.GetBlockBlobClient(GetNewBlobName())),
                InstrumentClient(testA.Container.GetBlockBlobClient(GetNewBlobName()))
            };
            List<BlockBlobClient> blobsB = new List<BlockBlobClient>(2)
            {
                InstrumentClient(testB.Container.GetBlockBlobClient(GetNewBlobName())),
                InstrumentClient(testB.Container.GetBlockBlobClient(GetNewBlobName()))
            };
            foreach (BlockBlobClient blob in blobsA.Concat(blobsB))
            {
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }
            }

            // Act — download 2 from container A, then 2 from container B
            countingPolicy.Start();
            List<Response<BlobDownloadInfo>> responses = new List<Response<BlobDownloadInfo>>();
            foreach (BlockBlobClient blob in blobsA.Concat(blobsB))
            {
                responses.Add(await blob.DownloadAsync());
            }

            // Assert — verify data was downloaded correctly
            foreach (Response<BlobDownloadInfo> response in responses)
            {
                Assert.AreEqual(data.Length, response.Value.ContentLength);
                var actual = new MemoryStream();
                await response.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }

            // Assert — 2 CreateSession calls (one per container), all 4 GETs use session auth
            Assert.AreEqual(2, countingPolicy.CreateSessionCount, "Expected one create session request per container");
            Assert.AreEqual(4, countingPolicy.GetSessionAuthCount, "Expected all download requests to use Session authorization");
            Assert.AreEqual(0, countingPolicy.BearerGetBlobCount, "Expected no GET blob requests to fall back to Bearer authorization");

            // Assert — verify per-container token sharing
            // Ordering: [0]=A0, [1]=A1, [2]=B0, [3]=B1
            IReadOnlyList<string> sessionTokens = countingPolicy.GetBlobSessionTokens;
            Assert.AreEqual(4, sessionTokens.Count, "Expected exactly 4 session-authenticated GET blob requests");

            // Container A's two requests share the same session token
            Assert.AreEqual(sessionTokens[0], sessionTokens[1],
                "Container A requests should share the same session token");
            // Container B's two requests share the same session token
            Assert.AreEqual(sessionTokens[2], sessionTokens[3],
                "Container B requests should share the same session token");
            // Container A and B have different session tokens
            Assert.AreNotEqual(sessionTokens[0], sessionTokens[2],
                "Container A and container B should have different session tokens");
        }

        [RecordedTest]
        public async Task DownloadAsync_Sessions_UriTokenCredentialCtors()
        {
            var containerName = GetNewContainerName();
            var countingPolicy = new SessionAuthCountingPolicy(containerName);
            BlobClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions()
            {
                SessionMode = SessionMode.Enabled,
                AccountName = Tenants.TestConfigOAuth.AccountName,
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);

            // Use a separate (non-session) service client only to create / dispose the test container.
            BlobServiceClient setupServiceClient = GetServiceClient_OAuth();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: setupServiceClient);

            // Build the container URI and construct a BlobContainerClient via the
            // (Uri, TokenCredential, BlobClientOptions) constructor.
            BlobUriBuilder containerUriBuilder = new BlobUriBuilder(new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint))
            {
                BlobContainerName = containerName
            };
            BlobContainerClient containerClient = InstrumentClient(new BlobContainerClient(
                containerUriBuilder.ToUri(),
                TestEnvironment.Credential,
                options));

            // Arrange — upload 3 blobs through clients obtained from the container client.
            var data = GetRandomBuffer(Constants.KB);
            List<string> blobNames = new List<string>(3) { GetNewBlobName(), GetNewBlobName(), GetNewBlobName() };
            foreach (string blobName in blobNames)
            {
                BlockBlobClient uploadClient = InstrumentClient(containerClient.GetBlockBlobClient(blobName));
                using (var stream = new MemoryStream(data))
                {
                    await uploadClient.UploadAsync(stream);
                }
            }

            // Build the 3 BlockBlobClient instances under test, each rooted in a different
            // top-level client construction path so each gets its own pipeline + session policy:
            //  [0] — directly via the BlockBlobClient(Uri, TokenCredential, BlobClientOptions) ctor.
            //  [1] — via the BlobContainerClient(Uri, TokenCredential, BlobClientOptions) ctor + GetBlockBlobClient.
            //  [2] — via the BlobServiceClient(Uri, TokenCredential, BlobClientOptions) ctor
            //        + GetBlobContainerClient + GetBlockBlobClient.
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint))
            {
                BlobContainerName = containerName,
                BlobName = blobNames[0]
            };
            BlockBlobClient blobFromBlobCtor = InstrumentClient(new BlockBlobClient(
                blobUriBuilder.ToUri(),
                TestEnvironment.Credential,
                options));
            BlockBlobClient blobFromContainerCtor = InstrumentClient(containerClient.GetBlockBlobClient(blobNames[1]));

            BlobServiceClient serviceClientFromUriCtor = InstrumentClient(new BlobServiceClient(
                new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint),
                TestEnvironment.Credential,
                options));
            BlockBlobClient blobFromServiceCtor = InstrumentClient(
                serviceClientFromUriCtor.GetBlobContainerClient(containerName).GetBlockBlobClient(blobNames[2]));

            List<BlockBlobClient> blobs = new List<BlockBlobClient>(3)
            {
                blobFromBlobCtor,
                blobFromContainerCtor,
                blobFromServiceCtor
            };

            // Act
            countingPolicy.Start();
            List<Response<BlobDownloadInfo>> responses = new List<Response<BlobDownloadInfo>>();
            for (int i = 0; i < 3; i++)
            {
                responses.Add(await blobs[i].DownloadAsync());
            }

            // Assert — verify data was downloaded correctly
            foreach (Response<BlobDownloadInfo> response in responses)
            {
                Assert.AreEqual(data.Length, response.Value.ContentLength);
                var actual = new MemoryStream();
                await response.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }

            // Assert — every top-level client builds its own pipeline (and therefore its own
            // SessionAuthenticationPolicy + session token cache), so each of the 3 download
            // paths negotiates its own session. All 3 GET blob requests must use Session auth
            // and none should fall back to Bearer.
            Assert.AreEqual(3, countingPolicy.CreateSessionCount, "Expected one create session request per top-level client (3 total)");
            Assert.AreEqual(3, countingPolicy.GetSessionAuthCount, "Expected all 3 download requests to use Session authorization");
            Assert.AreEqual(0, countingPolicy.BearerGetBlobCount, "Expected no GET blob requests to fall back to Bearer authorization");
        }

        [Ignore("Test takes 5+ minutes")]
        [RecordedTest]
        [LiveOnly(Reason = "Test waits 5 minutes for session token expiration; cannot be recorded")]
        public async Task DownloadAsync_SessionTokenExpiration()
        {
            var containerNameA = GetNewContainerName();
            var containerNameB = GetNewContainerName();
            var countingPolicy = new SessionAuthCountingPolicy(null);
            BlobClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions()
            {
                SessionMode = SessionMode.Enabled,
                AccountName = Tenants.TestConfigOAuth.AccountName,
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);
            BlobServiceClient oauthServiceClient = GetServiceClient_OAuth(options);
            await using DisposingContainer testA = await GetTestContainerAsync(containerName: containerNameA, service: oauthServiceClient);
            await using DisposingContainer testB = await GetTestContainerAsync(containerName: containerNameB, service: oauthServiceClient);

            // Arrange — upload 4 blobs per container (2 for first batch, 2 for second batch)
            var data = GetRandomBuffer(Constants.KB);
            List<BlockBlobClient> blobsA = new List<BlockBlobClient>(4);
            List<BlockBlobClient> blobsB = new List<BlockBlobClient>(4);
            for (int i = 0; i < 4; i++)
            {
                BlockBlobClient blobA = InstrumentClient(testA.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await blobA.UploadAsync(stream);
                }
                blobsA.Add(blobA);

                BlockBlobClient blobB = InstrumentClient(testB.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await blobB.UploadAsync(stream);
                }
                blobsB.Add(blobB);
            }

            // Act — first batch: 2 downloads from container A, 2 from container B
            countingPolicy.Start();
            List<Response<BlobDownloadInfo>> firstBatch = new List<Response<BlobDownloadInfo>>();
            for (int i = 0; i < 2; i++)
            {
                firstBatch.Add(await blobsA[i].DownloadAsync());
            }
            for (int i = 0; i < 2; i++)
            {
                firstBatch.Add(await blobsB[i].DownloadAsync());
            }

            // Wait 5 minutes so the existing session tokens expire
            await Task.Delay(TimeSpan.FromMinutes(5.1));

            // Act — second batch: 2 more downloads from container A, 2 more from container B
            List<Response<BlobDownloadInfo>> secondBatch = new List<Response<BlobDownloadInfo>>();
            for (int i = 2; i < 4; i++)
            {
                secondBatch.Add(await blobsA[i].DownloadAsync());
            }
            for (int i = 2; i < 4; i++)
            {
                secondBatch.Add(await blobsB[i].DownloadAsync());
            }

            // Assert — verify data was downloaded correctly for both batches
            foreach (Response<BlobDownloadInfo> response in firstBatch.Concat(secondBatch))
            {
                Assert.AreEqual(data.Length, response.Value.ContentLength);
                var actual = new MemoryStream();
                await response.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }

            // Assert — verify session usage:
            // First batch: 2 CreateSession (one per container), second batch: 2 more after expiration
            Assert.AreEqual(4, countingPolicy.CreateSessionCount,
                "Expected 4 create session requests (one per container per batch)");
            Assert.AreEqual(8, countingPolicy.GetSessionAuthCount,
                "Expected all 8 download requests to use Session authorization");
            Assert.AreEqual(0, countingPolicy.BearerGetBlobCount,
                "Expected no GET blob requests to fall back to Bearer authorization");

            // Assert — verify per-container token sharing and expiration via session tokens
            // Ordering: [0]=A0, [1]=A1, [2]=B0, [3]=B1, [4]=A2, [5]=A3, [6]=B2, [7]=B3
            IReadOnlyList<string> sessionTokens = countingPolicy.GetBlobSessionTokens;
            Assert.AreEqual(8, sessionTokens.Count, "Expected exactly 8 session-authenticated GET blob requests");

            // First batch — container A's two requests share a token
            Assert.AreEqual(sessionTokens[0], sessionTokens[1],
                "First batch container A requests should share the same session token");
            // First batch — container B's two requests share a token
            Assert.AreEqual(sessionTokens[2], sessionTokens[3],
                "First batch container B requests should share the same session token");
            // First batch — container A and B have different tokens
            Assert.AreNotEqual(sessionTokens[0], sessionTokens[2],
                "Container A and container B should have different session tokens");

            // Second batch — container A's two requests share a new token
            Assert.AreEqual(sessionTokens[4], sessionTokens[5],
                "Second batch container A requests should share the same session token");
            // Second batch — container B's two requests share a new token
            Assert.AreEqual(sessionTokens[6], sessionTokens[7],
                "Second batch container B requests should share the same session token");
            // Second batch — container A and B still have different tokens
            Assert.AreNotEqual(sessionTokens[4], sessionTokens[6],
                "Container A and container B should have different session tokens after expiration");

            // Across batches — tokens changed after expiration
            Assert.AreNotEqual(sessionTokens[0], sessionTokens[4],
                "Container A session token after expiration should differ from the original");
            Assert.AreNotEqual(sessionTokens[2], sessionTokens[6],
                "Container B session token after expiration should differ from the original");
        }

        [RecordedTest]
        public async Task DownloadAsync_Sessions_Disabled()
        {
            var containerName = GetNewContainerName();
            var countingPolicy = new SessionAuthCountingPolicy(containerName);
            BlobClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions()
            {
                SessionMode = SessionMode.Disabled,
                AccountName = Tenants.TestConfigOAuth.AccountName
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);
            BlobServiceClient oauthServiceClient = GetServiceClient_OAuth(options);
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthServiceClient);

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            List<BlockBlobClient> blobs = new List<BlockBlobClient>(3)
            {
                InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName())),
                InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName())),
                InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()))
            };
            foreach (BlockBlobClient blob in blobs)
            {
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }
            }

            // Act
            countingPolicy.Start();
            List<Response<BlobDownloadInfo>> responses = new List<Response<BlobDownloadInfo>>();
            for (int i = 0; i < 3; i++)
            {
                responses.Add(await blobs[i].DownloadAsync());
            }

            // Assert — verify data was downloaded correctly
            foreach (Response<BlobDownloadInfo> response in responses)
            {
                Assert.AreEqual(data.Length, response.Value.ContentLength);
                var actual = new MemoryStream();
                await response.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }

            // Assert — verify that no session was created and no session auth was used
            Assert.AreEqual(0, countingPolicy.CreateSessionCount, "Expected no create session request when SessionMode is None");
            Assert.AreEqual(0, countingPolicy.GetSessionAuthCount, "Expected no session authorization when SessionMode is None");
            Assert.AreEqual(3, countingPolicy.BearerGetBlobCount, "Expected GET blob requests to use Bearer authorization when SessionMode is None");
        }

        [RecordedTest]
        public async Task DownloadAsync_Sessions_SharedKey()
        {
            var containerName = GetNewContainerName();
            var countingPolicy = new SessionAuthCountingPolicy(containerName);
            BlobClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions()
            {
                SessionMode = SessionMode.Enabled,
                AccountName = TestConfigDefault.AccountName,
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);

            // Use SharedKey authentication instead of OAuth
            BlobServiceClient sharedKeyServiceClient = InstrumentClient(
                new BlobServiceClient(
                    new Uri(TestConfigDefault.BlobServiceEndpoint),
                    new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey),
                    options));

            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: sharedKeyServiceClient);

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            List<BlockBlobClient> blobs = new List<BlockBlobClient>(3)
            {
                InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName())),
                InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName())),
                InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()))
            };
            foreach (BlockBlobClient blob in blobs)
            {
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }
            }

            // Act
            countingPolicy.Start();
            List<Response<BlobDownloadInfo>> responses = new List<Response<BlobDownloadInfo>>();
            for (int i = 0; i < 3; i++)
            {
                responses.Add(await blobs[i].DownloadAsync());
            }

            // Assert — verify data was downloaded correctly
            foreach (Response<BlobDownloadInfo> response in responses)
            {
                Assert.AreEqual(data.Length, response.Value.ContentLength);
                var actual = new MemoryStream();
                await response.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }

            // Assert — SharedKey auth should not use sessions at all, even with SessionMode enabled
            Assert.AreEqual(0, countingPolicy.CreateSessionCount, "Expected no create session request when using SharedKey authentication");
            Assert.AreEqual(0, countingPolicy.GetSessionAuthCount, "Expected no session authorization when using SharedKey authentication");
            Assert.AreEqual(0, countingPolicy.BearerGetBlobCount, "Expected no Bearer authorization when using SharedKey authentication");
        }

        [RecordedTest]
        [LiveOnly(Reason = "Concurrent downloads cannot be recorded deterministically")]
        public async Task DownloadContentAsync_Sessions_ConcurrentAcrossContainers()
        {
            const int containerCount = 5;
            const int blobsPerContainer = 2;
            var countingPolicy = new SessionAuthCountingPolicy(null);
            BlobClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions()
            {
                SessionMode = SessionMode.Enabled,
                AccountName = Tenants.TestConfigOAuth.AccountName,
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);
            BlobServiceClient oauthServiceClient = GetServiceClient_OAuth(options);

            // Arrange — create 5 containers, each with 2 blobs
            var data = GetRandomBuffer(Constants.KB);
            await using DisposingContainer test1 = await GetTestContainerAsync(service: oauthServiceClient);
            await using DisposingContainer test2 = await GetTestContainerAsync(service: oauthServiceClient);
            await using DisposingContainer test3 = await GetTestContainerAsync(service: oauthServiceClient);
            await using DisposingContainer test4 = await GetTestContainerAsync(service: oauthServiceClient);
            await using DisposingContainer test5 = await GetTestContainerAsync(service: oauthServiceClient);

            DisposingContainer[] containers = new[] { test1, test2, test3, test4, test5 };
            // Blobs grouped by container: [c1b1, c1b2, c2b1, c2b2, ..., c5b1, c5b2]
            List<BlockBlobClient> blobs = new List<BlockBlobClient>(containerCount * blobsPerContainer);
            foreach (DisposingContainer test in containers)
            {
                for (int j = 0; j < blobsPerContainer; j++)
                {
                    BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                    using (var stream = new MemoryStream(data))
                    {
                        await blob.UploadAsync(stream);
                    }
                    blobs.Add(blob);
                }
            }

            // Act — concurrent downloads across all 5 containers simultaneously
            countingPolicy.Start();

            Task<Response<BlobDownloadResult>>[] tasks = blobs
                .Select(blob => blob.DownloadContentAsync())
                .ToArray();

            Response<BlobDownloadResult>[] responses = await Task.WhenAll(tasks);

            // Assert — all downloads returned correct data
            foreach (Response<BlobDownloadResult> response in responses)
            {
                Assert.AreEqual(data.Length, response.Value.Details.ContentLength);
                TestHelper.AssertSequenceEqual(data, response.Value.Content.ToArray());
            }

            // Assert — each container should have its own CreateSession, all GETs use session auth
            Assert.AreEqual(containerCount, countingPolicy.CreateSessionCount,
                "Expected one create session request per container");
            Assert.AreEqual(containerCount * blobsPerContainer, countingPolicy.GetSessionAuthCount,
                "Expected all concurrent downloads to use Session authorization");
            Assert.AreEqual(0, countingPolicy.BearerGetBlobCount,
                "Expected no GET blob requests to fall back to Bearer authorization");

            // Assert — verify per-container token sharing under concurrency
            // Note: with concurrent execution, ordering isn't guaranteed per-container,
            // so group tokens by value and verify we see exactly 5 distinct tokens,
            // each used exactly twice.
            IReadOnlyList<string> sessionTokens = countingPolicy.GetBlobSessionTokens;
            Assert.AreEqual(containerCount * blobsPerContainer, sessionTokens.Count,
                "Expected exactly 10 session-authenticated GET blob requests");

            var tokenGroups = sessionTokens.GroupBy(t => t).ToList();
            Assert.AreEqual(containerCount, tokenGroups.Count,
                "Expected exactly 5 distinct session tokens (one per container)");
            foreach (var group in tokenGroups)
            {
                Assert.AreEqual(blobsPerContainer, group.Count(),
                    $"Expected each session token to be used exactly {blobsPerContainer} times (once per blob in the container)");
            }
        }

        [RecordedTest]
        public async Task GetTagsAsync_Sessions_FallbackToBearer()
        {
            var containerName = GetNewContainerName();
            var countingPolicy = new SessionAuthCountingPolicy(containerName);
            BlobClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions()
            {
                SessionMode = SessionMode.Enabled,
                AccountName = Tenants.TestConfigOAuth.AccountName,
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);
            BlobServiceClient oauthServiceClient = GetServiceClient_OAuth(options);
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthServiceClient);

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            List<BlockBlobClient> blobs = new List<BlockBlobClient>(3)
            {
                InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName())),
                InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName())),
                InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()))
            };
            foreach (BlockBlobClient blob in blobs)
            {
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }
            }

            // Act — GetTags may fail with 403 due to insufficient RBAC permissions,
            // but the counting policy still observes the auth headers on the request.
            countingPolicy.Start();
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    await blobs[i].GetTagsAsync();
                }
                catch (RequestFailedException ex) when (ex.Status == 403 || ex.Status == 404)
                {
                    // Expected when the test identity lacks the required tag permissions.
                }
            }

            // Assert — GetTags should fall back to Bearer, not use Session auth
            Assert.AreEqual(0, countingPolicy.CreateSessionCount, "Expected no create session request for GetTags operations");
            Assert.AreEqual(0, countingPolicy.GetSessionAuthCount, "Expected GetTags requests to not use Session authorization");
            Assert.AreEqual(0, countingPolicy.NonGetSessionAuthCount, "Expected no non-GET requests to use Session authorization");
            Assert.IsTrue(countingPolicy.BearerGetBlobCount >= 3, "Expected GetTags requests to use Bearer authorization");
        }

        [RecordedTest]
        public async Task UploadAsync_Sessions_FallbackToBearer()
        {
            var containerName = GetNewContainerName();
            var countingPolicy = new SessionAuthCountingPolicy(containerName);
            BlobClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions()
            {
                SessionMode = SessionMode.Enabled,
                AccountName = Tenants.TestConfigOAuth.AccountName,
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);
            BlobServiceClient oauthServiceClient = GetServiceClient_OAuth(options);
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthServiceClient);

            // Act — upload blobs
            countingPolicy.Start();
            var data = GetRandomBuffer(Constants.KB);
            for (int i = 0; i < 3; i++)
            {
                BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }
            }

            // Assert — PUT requests should never trigger session creation or use session auth
            Assert.AreEqual(0, countingPolicy.CreateSessionCount, "Expected no create session request for upload-only operations");
            Assert.AreEqual(0, countingPolicy.GetSessionAuthCount, "Expected upload requests to not use Session authorization");
            Assert.AreEqual(0, countingPolicy.NonGetSessionAuthCount, "Expected no non-GET requests to use Session authorization");
            Assert.IsTrue(countingPolicy.BearerNonGetCount >= 3, "Expected upload requests to use Bearer authorization");
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_Sessions_FallbackToBearer()
        {
            var containerName = GetNewContainerName();
            var countingPolicy = new SessionAuthCountingPolicy(containerName);
            BlobClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions()
            {
                SessionMode = SessionMode.Enabled,
                AccountName = Tenants.TestConfigOAuth.AccountName,
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);
            BlobServiceClient oauthServiceClient = GetServiceClient_OAuth(options);
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthServiceClient);

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            List<BlockBlobClient> blobs = new List<BlockBlobClient>(3)
            {
                InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName())),
                InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName())),
                InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()))
            };
            foreach (BlockBlobClient blob in blobs)
            {
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }
            }

            // Act — GetProperties
            countingPolicy.Start();
            for (int i = 0; i < 3; i++)
            {
                await blobs[i].GetPropertiesAsync();
            }

            // Assert — HEAD requests should never trigger session creation or use session auth
            Assert.AreEqual(0, countingPolicy.CreateSessionCount, "Expected no create session request for HEAD-only operations");
            Assert.AreEqual(0, countingPolicy.GetSessionAuthCount, "Expected GetProperties requests to not use Session authorization");
            Assert.AreEqual(0, countingPolicy.NonGetSessionAuthCount, "Expected no non-GET requests to use Session authorization");
            Assert.IsTrue(countingPolicy.BearerNonGetCount >= 3, "Expected GetProperties requests to use Bearer authorization");
        }

        [RecordedTest]
        public async Task MixedOperations_Sessions()
        {
            var containerName = GetNewContainerName();
            var countingPolicy = new SessionAuthCountingPolicy(containerName);
            BlobClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions()
            {
                SessionMode = SessionMode.Enabled,
                AccountName = Tenants.TestConfigOAuth.AccountName,
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);
            BlobServiceClient oauthServiceClient = GetServiceClient_OAuth(options);
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthServiceClient);

            // Arrange — upload a blob outside counting scope for later download
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient existingBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await existingBlob.UploadAsync(stream);
            }

            // Act — mixed operations inside counting scope
            countingPolicy.Start();

            // Upload a new blob (PUT — should use bearer)
            BlockBlobClient newBlob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await newBlob.UploadAsync(stream);
            }

            // Download existing blob (GET — should use session)
            Response<BlobDownloadInfo> downloadResponse = await existingBlob.DownloadAsync();
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());

            // GetProperties (HEAD — should use bearer)
            await existingBlob.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(1, countingPolicy.CreateSessionCount, "Expected create session request to be called");
            Assert.AreEqual(1, countingPolicy.GetSessionAuthCount, "Expected only the download request to use Session authorization");
            Assert.AreEqual(0, countingPolicy.NonGetSessionAuthCount, "Expected upload and GetProperties requests to not use Session authorization");
            Assert.AreEqual(0, countingPolicy.BearerGetBlobCount, "Expected the download request to not use Bearer authorization");
            Assert.IsTrue(countingPolicy.BearerNonGetCount >= 2, "Expected upload and GetProperties requests to use Bearer authorization");
        }

        [RecordedTest]
        [LiveOnly(Reason = "Cannot record tests caching Session authentication")]
        public async Task DownloadToAsync_Parallel_Sessions()
        {
            var containerName = GetNewContainerName();
            var countingPolicy = new SessionAuthCountingPolicy(containerName);
            BlobClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions()
            {
                SessionMode = SessionMode.Enabled,
                AccountName = Tenants.TestConfigOAuth.AccountName,
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);
            BlobServiceClient oauthServiceClient = GetServiceClient_OAuth(options);
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthServiceClient);

            // Arrange — upload a blob large enough to force multiple parallel range GETs
            var data = GetRandomBuffer(10 * Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act — parallel download with small chunk sizes to force many concurrent GET requests
            countingPolicy.Start();
            using var resultStream = new MemoryStream();
            await blob.DownloadToAsync(
                resultStream,
                new BlobDownloadToOptions
                {
                    TransferOptions = new StorageTransferOptions
                    {
                        InitialTransferLength = Constants.KB,
                        MaximumTransferLength = Constants.KB,
                        MaximumConcurrency = 4
                    }
                });

            // Assert — verify data was downloaded correctly
            Assert.AreEqual(data.Length, resultStream.Length);
            TestHelper.AssertSequenceEqual(data, resultStream.ToArray());

            // Assert — verify that Create Session was called and all parallel GET requests used Session auth
            Assert.AreEqual(1, countingPolicy.CreateSessionCount, "Expected create session request to be called");
            Assert.IsTrue(countingPolicy.GetSessionAuthCount > 1, "Expected multiple parallel download requests to use Session authorization");
            Assert.AreEqual(0, countingPolicy.BearerGetBlobCount, "Expected no GET blob requests to fall back to Bearer authorization");
        }

        [RecordedTest]
        [LiveOnly(Reason = "Cannot record tests caching Session authentication")]
        public async Task DownloadStreamingAsync_Sessions()
        {
            var containerNameA = GetNewContainerName();
            var containerNameB = GetNewContainerName();
            var countingPolicy = new SessionAuthCountingPolicy(null);
            BlobClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions()
            {
                SessionMode = SessionMode.Enabled,
                AccountName = Tenants.TestConfigOAuth.AccountName,
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);
            BlobServiceClient oauthServiceClient = GetServiceClient_OAuth(options);
            await using DisposingContainer testA = await GetTestContainerAsync(containerName: containerNameA, service: oauthServiceClient);
            await using DisposingContainer testB = await GetTestContainerAsync(containerName: containerNameB, service: oauthServiceClient);

            // Arrange — 2 blobs per container
            var data = GetRandomBuffer(Constants.KB);
            List<BlockBlobClient> blobsA = new List<BlockBlobClient>(2)
            {
                InstrumentClient(testA.Container.GetBlockBlobClient(GetNewBlobName())),
                InstrumentClient(testA.Container.GetBlockBlobClient(GetNewBlobName()))
            };
            List<BlockBlobClient> blobsB = new List<BlockBlobClient>(2)
            {
                InstrumentClient(testB.Container.GetBlockBlobClient(GetNewBlobName())),
                InstrumentClient(testB.Container.GetBlockBlobClient(GetNewBlobName()))
            };
            foreach (BlockBlobClient blob in blobsA.Concat(blobsB))
            {
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }
            }

            // Act — download 2 from container A, then 2 from container B
            countingPolicy.Start();
            List<Response<BlobDownloadStreamingResult>> responses = new List<Response<BlobDownloadStreamingResult>>();
            foreach (BlockBlobClient blob in blobsA.Concat(blobsB))
            {
                responses.Add(await blob.DownloadStreamingAsync());
            }

            // Assert — verify data was downloaded correctly
            foreach (Response<BlobDownloadStreamingResult> response in responses)
            {
                Assert.AreEqual(data.Length, response.Value.Details.ContentLength);
                var actual = new MemoryStream();
                await response.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }

            // Assert — 2 CreateSession calls (one per container), all 4 GETs use session auth
            Assert.AreEqual(2, countingPolicy.CreateSessionCount, "Expected one create session request per container");
            Assert.AreEqual(4, countingPolicy.GetSessionAuthCount, "Expected all streaming download requests to use Session authorization");
            Assert.AreEqual(0, countingPolicy.BearerGetBlobCount, "Expected no GET blob requests to fall back to Bearer authorization");

            // Assert — verify per-container token sharing
            // Ordering: [0]=A0, [1]=A1, [2]=B0, [3]=B1
            IReadOnlyList<string> sessionTokens = countingPolicy.GetBlobSessionTokens;
            Assert.AreEqual(4, sessionTokens.Count, "Expected exactly 4 session-authenticated GET blob requests");

            // Container A's two requests share the same session token
            Assert.AreEqual(sessionTokens[0], sessionTokens[1],
                "Container A requests should share the same session token");
            // Container B's two requests share the same session token
            Assert.AreEqual(sessionTokens[2], sessionTokens[3],
                "Container B requests should share the same session token");
            // Container A and B have different session tokens
            Assert.AreNotEqual(sessionTokens[0], sessionTokens[2],
                "Container A and container B should have different session tokens");
        }

        [RecordedTest]
        [LiveOnly(Reason = "Cannot record tests caching Session authentication")]
        public async Task DownloadContentAsync_Sessions()
        {
            var containerNameA = GetNewContainerName();
            var containerNameB = GetNewContainerName();
            var countingPolicy = new SessionAuthCountingPolicy(null);
            BlobClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions()
            {
                SessionMode = SessionMode.Enabled,
                AccountName = Tenants.TestConfigOAuth.AccountName,
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);
            BlobServiceClient oauthServiceClient = GetServiceClient_OAuth(options);
            await using DisposingContainer testA = await GetTestContainerAsync(containerName: containerNameA, service: oauthServiceClient);
            await using DisposingContainer testB = await GetTestContainerAsync(containerName: containerNameB, service: oauthServiceClient);

            // Arrange — 2 blobs per container
            var data = GetRandomBuffer(Constants.KB);
            List<BlockBlobClient> blobsA = new List<BlockBlobClient>(2)
            {
                InstrumentClient(testA.Container.GetBlockBlobClient(GetNewBlobName())),
                InstrumentClient(testA.Container.GetBlockBlobClient(GetNewBlobName()))
            };
            List<BlockBlobClient> blobsB = new List<BlockBlobClient>(2)
            {
                InstrumentClient(testB.Container.GetBlockBlobClient(GetNewBlobName())),
                InstrumentClient(testB.Container.GetBlockBlobClient(GetNewBlobName()))
            };
            foreach (BlockBlobClient blob in blobsA.Concat(blobsB))
            {
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }
            }

            // Act — download 2 from container A, then 2 from container B
            countingPolicy.Start();
            List<Response<BlobDownloadResult>> responses = new List<Response<BlobDownloadResult>>();
            foreach (BlockBlobClient blob in blobsA.Concat(blobsB))
            {
                responses.Add(await blob.DownloadContentAsync());
            }

            // Assert — verify data was downloaded correctly
            foreach (Response<BlobDownloadResult> response in responses)
            {
                Assert.AreEqual(data.Length, response.Value.Details.ContentLength);
                TestHelper.AssertSequenceEqual(data, response.Value.Content.ToArray());
            }

            // Assert — 2 CreateSession calls (one per container), all 4 GETs use session auth
            Assert.AreEqual(2, countingPolicy.CreateSessionCount, "Expected one create session request per container");
            Assert.AreEqual(4, countingPolicy.GetSessionAuthCount, "Expected all content download requests to use Session authorization");
            Assert.AreEqual(0, countingPolicy.BearerGetBlobCount, "Expected no GET blob requests to fall back to Bearer authorization");

            // Assert — verify per-container token sharing
            // Ordering: [0]=A0, [1]=A1, [2]=B0, [3]=B1
            IReadOnlyList<string> sessionTokens = countingPolicy.GetBlobSessionTokens;
            Assert.AreEqual(4, sessionTokens.Count, "Expected exactly 4 session-authenticated GET blob requests");

            // Container A's two requests share the same session token
            Assert.AreEqual(sessionTokens[0], sessionTokens[1],
                "Container A requests should share the same session token");
            // Container B's two requests share the same session token
            Assert.AreEqual(sessionTokens[2], sessionTokens[3],
                "Container B requests should share the same session token");
            // Container A and B have different session tokens
            Assert.AreNotEqual(sessionTokens[0], sessionTokens[2],
                "Container A and container B should have different session tokens");
        }

        [RecordedTest]
        [LiveOnly(Reason = "Cannot record tests caching Session authentication")]
        public async Task DownloadAsync_Sessions_WithoutAccountName()
        {
            // SessionOptions.AccountName is optional; when omitted the account will be
            // derived from the client's URI.
            var containerName = GetNewContainerName();
            var countingPolicy = new SessionAuthCountingPolicy(containerName);
            BlobClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions()
            {
                SessionMode = SessionMode.Enabled,
                // AccountName intentionally omitted
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);
            BlobServiceClient oauthServiceClient = GetServiceClient_OAuth(options);
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthServiceClient);

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            List<BlockBlobClient> blobs = new List<BlockBlobClient>(2)
            {
                InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName())),
                InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()))
            };
            foreach (BlockBlobClient blob in blobs)
            {
                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }
            }

            // Act
            countingPolicy.Start();
            List<Response<BlobDownloadInfo>> responses = new List<Response<BlobDownloadInfo>>();
            foreach (BlockBlobClient blob in blobs)
            {
                responses.Add(await blob.DownloadAsync());
            }

            // Assert — verify data was downloaded correctly
            foreach (Response<BlobDownloadInfo> response in responses)
            {
                Assert.AreEqual(data.Length, response.Value.ContentLength);
                var actual = new MemoryStream();
                await response.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }

            // Assert — sessions still negotiated and used without an explicit AccountName
            Assert.AreEqual(1, countingPolicy.CreateSessionCount, "Expected one create session request for the container");
            Assert.AreEqual(2, countingPolicy.GetSessionAuthCount, "Expected all download requests to use Session authorization");
            Assert.AreEqual(0, countingPolicy.BearerGetBlobCount, "Expected no GET blob requests to fall back to Bearer authorization");

            IReadOnlyList<string> sessionTokens = countingPolicy.GetBlobSessionTokens;
            Assert.AreEqual(2, sessionTokens.Count);
            Assert.AreEqual(sessionTokens[0], sessionTokens[1],
                "Both requests should share the same session token");
        }

        [RecordedTest]
        public async Task DownloadAsync_Sessions_IncorrectAccountName()
        {
            // The account name is part of the canonicalized resource in the string-to-sign,
            // so a misconfigured SessionOptions.AccountName produces a signature the service
            // cannot reproduce.
            var containerName = GetNewContainerName();
            var countingPolicy = new SessionAuthCountingPolicy(containerName);
            BlobClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions()
            {
                SessionMode = SessionMode.Enabled,
                // Deliberately not the account under test.
                AccountName = "nottherightaccountname",
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);
            BlobServiceClient oauthServiceClient = GetServiceClient_OAuth(options);
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthServiceClient);

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            countingPolicy.Start();
            Response<BlobDownloadInfo> response = await blob.DownloadAsync();

            // Assert — the download still succeeds, by way of the bearer fallback
            Assert.AreEqual(data.Length, response.Value.ContentLength);
            var actual = new MemoryStream();
            await response.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());

            // Assert — a session was minted and attempted, but the request was served by bearer
            Assert.AreEqual(1, countingPolicy.CreateSessionCount,
                "Expected one create session request for the container");
            Assert.AreEqual(1, countingPolicy.BearerGetBlobCount,
                "Expected the download to fall back to Bearer authorization after the session signature is rejected");
        }

        [RecordedTest]
        [LiveOnly(Reason = "Cannot record tests caching Session authentication")]
        public async Task DownloadAsync_Sessions_SharedSessionProvider()
        {
            // A customer-supplied SessionProvider is the only way two independently
            // constructed clients can share a session cache.
            var countingPolicy = new SessionAuthCountingPolicy(null);

            // The provider owns its own pipeline for CreateSession traffic, so the
            // counting policy has to be attached to the provider's options as well.
            BlobClientOptions providerOptions = GetOptions();
            providerOptions.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);
            SessionProvider sharedProvider = new ContainerSessionProvider(
                new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint),
                TestEnvironment.Credential,
                providerOptions);

            BlobServiceClient setupServiceClient = GetServiceClient_OAuth();
            await using DisposingContainer testA = await GetTestContainerAsync(service: setupServiceClient);
            await using DisposingContainer testB = await GetTestContainerAsync(service: setupServiceClient);

            // Arrange — 2 distinct blobs per container. For each, build an independent top-level client sharing the
            // provider; without the shared provider each would manage its own session.
            var data = GetRandomBuffer(Constants.KB);
            List<BlockBlobClient> blobs = new List<BlockBlobClient>(4);
            foreach (DisposingContainer test in new[] { testA, testB })
            {
                for (int i = 0; i < 2; i++)
                {
                    BlockBlobClient uploadClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                    using (var stream = new MemoryStream(data))
                    {
                        await uploadClient.UploadAsync(stream);
                    }

                    BlobClientOptions options = GetOptions();
                    options.SessionOptions = new SessionOptions()
                    {
                        SessionMode = SessionMode.Enabled,
                        AccountName = Tenants.TestConfigOAuth.AccountName,
                        SessionProvider = sharedProvider,
                    };
                    options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);
                    blobs.Add(InstrumentClient(new BlockBlobClient(
                        uploadClient.Uri,
                        TestEnvironment.Credential,
                        options)));
                }
            }

            // Act
            countingPolicy.Start();
            List<Response<BlobDownloadInfo>> responses = new List<Response<BlobDownloadInfo>>();
            foreach (BlockBlobClient blob in blobs)
            {
                responses.Add(await blob.DownloadAsync());
            }

            // Assert — verify data was downloaded correctly
            foreach (Response<BlobDownloadInfo> response in responses)
            {
                Assert.AreEqual(data.Length, response.Value.ContentLength);
                var actual = new MemoryStream();
                await response.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }

            // Assert — one CreateSession per container despite 4 independent clients
            Assert.AreEqual(2, countingPolicy.CreateSessionCount,
                "A shared provider should mint exactly one session per container, regardless of client count");
            Assert.AreEqual(4, countingPolicy.GetSessionAuthCount,
                "Expected all download requests to use Session authorization");
            Assert.AreEqual(0, countingPolicy.BearerGetBlobCount,
                "Expected no GET blob requests to fall back to Bearer authorization");

            // Assert — per-container token sharing across independent clients
            // Ordering: [0]=A0, [1]=A1, [2]=B0, [3]=B1
            IReadOnlyList<string> sessionTokens = countingPolicy.GetBlobSessionTokens;
            Assert.AreEqual(4, sessionTokens.Count);
            Assert.AreEqual(sessionTokens[0], sessionTokens[1],
                "Independent clients in container A should share the provider's cached session token");
            Assert.AreEqual(sessionTokens[2], sessionTokens[3],
                "Independent clients in container B should share the provider's cached session token");
            Assert.AreNotEqual(sessionTokens[0], sessionTokens[2],
                "Sessions must remain scoped per container even when the provider is shared");
        }

        [RecordedTest]
        [LiveOnly(Reason = "Cannot record tests caching Session authentication")]
        public async Task DownloadContentAsync_Sessions_SharedSessionProvider_SingleContainer()
        {
            var containerName = GetNewContainerName();
            var countingPolicy = new SessionAuthCountingPolicy(containerName);

            // The Session provider owns the shared pipeline for CreateSession traffic.
            // The counting policy is attached purely for testing/asserting purposes.
            BlobClientOptions providerOptions = GetOptions();
            providerOptions.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);
            SessionProvider sharedProvider = new ContainerSessionProvider(
                new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint),
                TestEnvironment.Credential,
                providerOptions);

            BlobServiceClient setupServiceClient = GetServiceClient_OAuth();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: setupServiceClient);

            var data = GetRandomBuffer(Constants.KB);
            countingPolicy.Start();

            // Each iteration uploads a blob, builds an independent client for it sharing the
            // provider, and downloads. Without SessionProvider each client would mint its own session.
            for (int i = 0; i < 3; i++)
            {
                BlockBlobClient uploadClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                using (var stream = new MemoryStream(data))
                {
                    await uploadClient.UploadAsync(stream);
                }

                BlobClientOptions options = GetOptions();
                options.SessionOptions = new SessionOptions()
                {
                    SessionMode = SessionMode.Enabled,
                    AccountName = Tenants.TestConfigOAuth.AccountName,
                    SessionProvider = sharedProvider,
                };
                options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);
                BlockBlobClient blob = InstrumentClient(new BlockBlobClient(
                    uploadClient.Uri,
                    TestEnvironment.Credential,
                    options));

                Response<BlobDownloadResult> response = await blob.DownloadContentAsync();
                TestHelper.AssertSequenceEqual(data, response.Value.Content.ToArray());
            }

            // Assert — a single session served all three independently created clients
            Assert.AreEqual(1, countingPolicy.CreateSessionCount,
                "A shared provider should mint exactly one session for the container, regardless of client count");
            Assert.AreEqual(3, countingPolicy.GetSessionAuthCount,
                "Expected all download requests to use Session authorization");
            Assert.AreEqual(0, countingPolicy.BearerGetBlobCount,
                "Expected no GET blob requests to fall back to Bearer authorization");

            IReadOnlyList<string> sessionTokens = countingPolicy.GetBlobSessionTokens;
            Assert.AreEqual(3, sessionTokens.Count);
            Assert.AreEqual(1, sessionTokens.Distinct().Count(),
                "Independently created clients should share the provider's cached session token");
        }

        [RecordedTest]
        [LiveOnly(Reason = "Cannot record tests caching Session authentication")]
        public async Task DownloadToAsync_Sessions_SharedSessionProvider()
        {
            // DownloadTo fans a single logical download out into many concurrent ranged
            // GETs. Combined with a shared provider and a cold cache, this races several
            // independent clients through session acquisition at once. Verify the provider
            // collapses that race into exactly one CreateSession per container, while
            // still keeping sessions scoped per container.
            var countingPolicy = new SessionAuthCountingPolicy(null);

            // The provider owns its own pipeline for CreateSession traffic, so the
            // counting policy has to be attached to the provider's options as well.
            BlobClientOptions providerOptions = GetOptions();
            providerOptions.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);
            SessionProvider sharedProvider = new ContainerSessionProvider(
                new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint),
                TestEnvironment.Credential,
                providerOptions);

            BlobServiceClient setupServiceClient = GetServiceClient_OAuth();
            await using DisposingContainer testA = await GetTestContainerAsync(service: setupServiceClient);
            await using DisposingContainer testB = await GetTestContainerAsync(service: setupServiceClient);

            // Arrange — 2 distinct blobs per container, each large enough that the transfer
            // options below force the download into multiple parallel range GETs. Distinct
            // blobs prove the cached session is scoped to the container rather than to any
            // single blob.
            var data = GetRandomBuffer(10 * Constants.KB);
            List<BlockBlobClient> blobs = new List<BlockBlobClient>(4);
            foreach (DisposingContainer test in new[] { testA, testB })
            {
                for (int i = 0; i < 2; i++)
                {
                    BlockBlobClient uploadClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                    using (var stream = new MemoryStream(data))
                    {
                        await uploadClient.UploadAsync(stream);
                    }

                    BlobClientOptions options = GetOptions();
                    options.SessionOptions = new SessionOptions()
                    {
                        SessionMode = SessionMode.Enabled,
                        AccountName = Tenants.TestConfigOAuth.AccountName,
                        SessionProvider = sharedProvider,
                    };
                    options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);
                    blobs.Add(InstrumentClient(new BlockBlobClient(
                        uploadClient.Uri,
                        TestEnvironment.Credential,
                        options)));
                }
            }

            // Act — run every partitioned download concurrently against a cold cache.
            countingPolicy.Start();
            List<MemoryStream> resultStreams = new List<MemoryStream>(blobs.Count);
            List<Task> downloads = new List<Task>(blobs.Count);
            foreach (BlockBlobClient blob in blobs)
            {
                var resultStream = new MemoryStream();
                resultStreams.Add(resultStream);
                downloads.Add(blob.DownloadToAsync(
                    resultStream,
                    new BlobDownloadToOptions
                    {
                        TransferOptions = new StorageTransferOptions
                        {
                            InitialTransferLength = Constants.KB,
                            MaximumTransferLength = Constants.KB,
                            MaximumConcurrency = 4
                        }
                    }));
            }
            await Task.WhenAll(downloads);

            // Assert — verify data was downloaded correctly
            foreach (MemoryStream resultStream in resultStreams)
            {
                Assert.AreEqual(data.Length, resultStream.Length);
                TestHelper.AssertSequenceEqual(data, resultStream.ToArray());
                resultStream.Dispose();
            }

            // Assert — the concurrent cold-cache race collapses to one session per
            // container, despite four independent clients and many parallel range GETs.
            Assert.AreEqual(2, countingPolicy.CreateSessionCount,
                "A shared provider should mint exactly one session per container, even when concurrent partitioned downloads race a cold cache");
            Assert.IsTrue(countingPolicy.GetSessionAuthCount > blobs.Count,
                "Expected each download to fan out into multiple range GET requests using Session authorization");
            Assert.AreEqual(0, countingPolicy.BearerGetBlobCount,
                "Expected no GET blob requests to fall back to Bearer authorization");

            // Assert — per-container token sharing. Completion order is nondeterministic
            // under concurrency, so compare the distinct set rather than by index.
            Assert.AreEqual(2, countingPolicy.GetBlobSessionTokens.Distinct().Count(),
                "Expected exactly one distinct session token per container across all clients and partitions");
        }

        /// <summary>
        /// Blob size used by the layout-aware routing tests.  The blob has to be large
        /// enough that the service reports more than one layout segment, otherwise there
        /// is nothing for locality-aware routing to route.
        /// </summary>
        private const int LayoutTestBlobSize = 16 * Constants.MB;

        /// <summary>
        /// Chunk sizes used by the layout-aware routing tests, small enough relative to
        /// <see cref="LayoutTestBlobSize"/> that a transfer fans out into several ranged
        /// requests that can each be routed independently.
        /// </summary>
        private static StorageTransferOptions LayoutTestTransferOptions => new StorageTransferOptions
        {
            InitialTransferSize = 4 * Constants.MB,
            MaximumTransferSize = 4 * Constants.MB,
            MaximumConcurrency = 4
        };

        /// <summary>
        /// Uploads a blob in chunks so that it is genuinely spread across multiple layout
        /// segments rather than landing as a single contiguous extent.
        /// </summary>
        private async Task<BlobClient> UploadLayoutTestBlobAsync(BlobContainerClient container, byte[] data)
        {
            BlobClient blob = InstrumentClient(container.GetBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream, new BlobUploadOptions
                {
                    TransferOptions = LayoutTestTransferOptions
                });
            }
            return blob;
        }

        /// <summary>
        /// Asserts that locality-aware routing was actually applied on the wire, not just
        /// requested.  <c>FetchLayoutInternal</c> soft-fails on 400/5xx and silently falls
        /// back to the client endpoint, so observing the layout call alone is not enough:
        /// we also require that <c>DataLocalityPolicy</c> rewrote at least one request host.
        /// </summary>
        private static void AssertDataLocalityApplied(SessionAuthCountingPolicy countingPolicy)
        {
            Assert.Greater(countingPolicy.GetLayoutCount, 0,
                "Expected at least one Get Blob Layout request when LayoutAwareRouting is Enabled");
            Assert.Greater(countingPolicy.RoutedRequestCount, 0,
                "Expected at least one request to be routed to a layout endpoint. The layout was fetched " +
                "but no request host was rewritten, which means the account returned no usable layout segments.");

            IReadOnlyList<string> routedHosts = countingPolicy.RoutedHosts;
            CollectionAssert.IsNotEmpty(routedHosts, "Expected routed hosts to be recorded");
            CollectionAssert.AllItemsAreNotNull(routedHosts);
        }

        [RecordedTest]
        [LiveOnly(Reason = "Cannot record tests caching Session authentication or data locality routing")]
        public async Task DownloadToAsync_LayoutAwareRouting_Sessions()
        {
            // Layout-aware routing and session authentication both hook the download path:
            // the layout cache chooses the endpoint for each chunk and the session policy
            // signs it. This asserts the two compose rather than one disabling the other.
            var containerName = GetNewContainerName();
            var countingPolicy = new SessionAuthCountingPolicy(containerName);
            BlobClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions()
            {
                SessionMode = SessionMode.Enabled
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);
            BlobServiceClient oauthServiceClient = GetServiceClient_OAuth(options);
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthServiceClient);

            // Arrange
            byte[] data = GetRandomBuffer(LayoutTestBlobSize);
            BlobClient blob = await UploadLayoutTestBlobAsync(test.Container, data);

            // Act
            countingPolicy.Start();
            using var destination = new MemoryStream();
            await blob.DownloadToAsync(destination, new BlobDownloadToOptions
            {
                LayoutAwareRouting = LayoutAwareRouting.Enabled,
                TransferOptions = LayoutTestTransferOptions
            });

            // Assert — verify data was downloaded correctly
            TestHelper.AssertSequenceEqual(data, destination.ToArray());

            // Assert — data locality was applied
            AssertDataLocalityApplied(countingPolicy);

            // Assert — session authentication was applied to every ranged GET, including
            // the ones that were re-routed to a layout endpoint.
            Assert.AreEqual(1, countingPolicy.CreateSessionCount,
                "Expected one create session request for the container");
            Assert.Greater(countingPolicy.GetSessionAuthCount, 1,
                "Expected the download to fan out into multiple ranged GETs, all using Session authorization");
            Assert.AreEqual(0, countingPolicy.BearerGetBlobCount,
                "Expected no GET blob requests to fall back to Bearer authorization");

            IReadOnlyList<string> sessionTokens = countingPolicy.GetBlobSessionTokens;
            CollectionAssert.IsNotEmpty(sessionTokens);
            foreach (string sessionToken in sessionTokens)
            {
                Assert.AreEqual(sessionTokens[0], sessionToken,
                    "All ranged GETs should share the container's cached session token, even when routed to different endpoints");
            }
        }

        [RecordedTest]
        [LiveOnly(Reason = "Cannot record tests caching Session authentication or data locality routing")]
        public async Task OpenReadAsync_LayoutAwareRouting_Sessions_SharedSessionProvider()
        {
            var containerName = GetNewContainerName();
            var countingPolicy = new SessionAuthCountingPolicy(containerName);

            // The provider owns its own pipeline for CreateSession traffic, so the
            // counting policy has to be attached to the provider's options as well.
            BlobClientOptions providerOptions = GetOptions();
            providerOptions.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);
            SessionProvider sharedProvider = new ContainerSessionProvider(
                new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint),
                TestEnvironment.Credential,
                providerOptions);

            BlobClientOptions options = GetOptions();
            options.SessionOptions = new SessionOptions()
            {
                SessionMode = SessionMode.Enabled,
                SessionProvider = sharedProvider,
            };
            options.AddPolicy(countingPolicy, HttpPipelinePosition.PerRetry);
            BlobServiceClient oauthServiceClient = GetServiceClient_OAuth(options);
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthServiceClient);

            // Arrange
            byte[] data = GetRandomBuffer(LayoutTestBlobSize);
            BlobClient blob = await UploadLayoutTestBlobAsync(test.Container, data);

            // Act
            countingPolicy.Start();
            Stream readStream = await blob.OpenReadAsync(new BlobOpenReadOptions(allowModifications: false)
            {
                BufferSize = 4 * Constants.MB,
                LayoutAwareRouting = LayoutAwareRouting.Enabled
            });
            using var destination = new MemoryStream();
            await readStream.CopyToAsync(destination);

            // Assert — verify data was read correctly
            TestHelper.AssertSequenceEqual(data, destination.ToArray());

            // Assert — data locality was applied
            AssertDataLocalityApplied(countingPolicy);

            // Assert — OpenRead's bootstrap contract: a single Get Blob Layout supplies both
            // the layout and the ETag/length/metadata, and seeds the cache, so neither a
            // second layout fetch nor a GetProperties is needed for the life of the stream.
            Assert.AreEqual(1, countingPolicy.GetLayoutCount,
                "Expected exactly one Get Blob Layout request to bootstrap and seed the layout cache");

            // Assert — session authentication was applied to every buffer fill
            Assert.AreEqual(1, countingPolicy.CreateSessionCount,
                "A shared provider should mint exactly one session for the container");
            Assert.Greater(countingPolicy.GetSessionAuthCount, 1,
                "Expected multiple buffer-fill GETs, all using Session authorization");
            Assert.AreEqual(0, countingPolicy.BearerGetBlobCount,
                "Expected no GET blob requests to fall back to Bearer authorization");

            IReadOnlyList<string> sessionTokens = countingPolicy.GetBlobSessionTokens;
            CollectionAssert.IsNotEmpty(sessionTokens);
            foreach (string sessionToken in sessionTokens)
            {
                Assert.AreEqual(sessionTokens[0], sessionToken,
                    "All buffer fills should share the provider's cached session token");
            }
        }
    }
}
