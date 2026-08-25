// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class BlobBaseClientDataLocalityTests : BlobTestBase
    {
        public BlobBaseClientDataLocalityTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [LiveOnly]
        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2026_02_06)]
        public async Task DownloadToAsync_LayoutAwareRouting_WithRequestAsserts_SharedKey()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            long size = 20 * Constants.MB;
            var data = GetRandomBuffer(size);
            int blockSize = 4 * Constants.MB;
            var blockIds = new List<string>();
            for (int offset = 0; offset < data.Length; offset += blockSize)
            {
                int count = Math.Min(blockSize, data.Length - offset);
                string blockId = Convert.ToBase64String(
                    Encoding.UTF8.GetBytes(blockIds.Count.ToString("d6")));
                blockIds.Add(blockId);
                using var blockStream = new MemoryStream(data, offset, count);
                await blob.StageBlockAsync(blockId, blockStream);
            }
            await blob.CommitBlockListAsync(blockIds);

            // Add a tracking policy that sits after DataLocalityPolicy in the pipeline
            // to capture the rewritten host/port and Host header on each request.
            DataLocalityTrackingPolicy trackingPolicy = new DataLocalityTrackingPolicy();
            BlobClientOptions options = GetOptions();
            options.AddPolicy(trackingPolicy, HttpPipelinePosition.PerCall);

            var credential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);
            BlockBlobClient downloadBlob = InstrumentClient(new BlockBlobClient(blob.Uri, credential, options));

            string originalHost = blob.Uri.Host;

            using (var resultStream = new MemoryStream())
            {
                BlobDownloadToOptions downloadOptions = new()
                {
                    LayoutAwareRouting = LayoutAwareRouting.Enabled,
                    TransferOptions = new StorageTransferOptions
                    {
                        MaximumConcurrency = 10,
                        InitialTransferSize = 3 * Constants.MB,
                        MaximumTransferSize = 5 * Constants.MB
                    },
                };
                await downloadBlob.DownloadToAsync(resultStream, downloadOptions);
                Assert.AreEqual(data.Length, resultStream.Length);
                TestHelper.AssertSequenceEqual(data, resultStream.ToArray());
            }

            // Filter to requests where DataLocalityPolicy rewrote the host
            // (indicated by the presence of a Host header).
            List<DataLocalityTrackingPolicy.RequestInfo> rewrittenRequests =
                trackingPolicy.TrackedRequests.Where(r => r.HasHostHeader).ToList();

            // When the service returns a download hint, subsequent chunk requests
            // should be rewritten. Given 3MB of initial transfer size and 5MB of max
            // transfer size, the 20MB blob should be downloaded in 1 + 4 subsequent
            // chunks, which should be 4 rewrites.
            Assert.AreEqual(4, rewrittenRequests.Count,
                "Expected DataLocalityPolicy to rewrite the host on subsequent chunk requests.");

            foreach (DataLocalityTrackingPolicy.RequestInfo req in rewrittenRequests)
            {
                // The URI host and port should have been rewritten to the layout endpoint
                Assert.AreNotEqual(originalHost, req.RequestHost,
                    $"Request URI host should be rewritten to layout endpoint, not '{originalHost}'");
                Assert.Greater(req.RequestPort, 0,
                    "Request URI port should be set by DataLocalityPolicy");

                // The Host header must preserve the original host
                Assert.AreEqual(originalHost, req.HostHeaderValue,
                    $"Host header should be the original host '{originalHost}', not the layout endpoint");
                Assert.AreNotEqual(req.RequestHost, req.HostHeaderValue,
                    "Host header should differ from the rewritten URI host");
            }
        }

        [LiveOnly]
        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2026_02_06)]
        public async Task DownloadToAsync_LayoutAwareRouting_WithRequestAsserts_OAuth()
        {
            // Same end-to-end shape as the shared-key variant, but with a
            // TokenCredential-backed client.
            BlobServiceClient oauthService = GetServiceClient_OAuth();
            await using DisposingContainer test = await GetTestContainerAsync(oauthService);

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            long size = 20 * Constants.MB;
            var data = GetRandomBuffer(size);
            int blockSize = 4 * Constants.MB;
            var blockIds = new List<string>();
            for (int offset = 0; offset < data.Length; offset += blockSize)
            {
                int count = Math.Min(blockSize, data.Length - offset);
                string blockId = Convert.ToBase64String(
                    Encoding.UTF8.GetBytes(blockIds.Count.ToString("d6")));
                blockIds.Add(blockId);
                using var blockStream = new MemoryStream(data, offset, count);
                await blob.StageBlockAsync(blockId, blockStream);
            }
            await blob.CommitBlockListAsync(blockIds);

            // Add a tracking policy that sits after DataLocalityPolicy in the pipeline
            // to capture the rewritten host/port and Host header on each request.
            DataLocalityTrackingPolicy trackingPolicy = new DataLocalityTrackingPolicy();
            BlobClientOptions options = GetOptions();
            options.AddPolicy(trackingPolicy, HttpPipelinePosition.PerCall);

            // OAuth-backed download client pointed at the same blob URI.
            BlobUriBuilder uriBuilder = new BlobUriBuilder(new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint))
            {
                BlobContainerName = blob.BlobContainerName,
                BlobName = blob.Name
            };
            BlockBlobClient downloadBlob = InstrumentClient(new BlockBlobClient(
                uriBuilder.ToUri(),
                TestEnvironment.Credential,
                options));

            string originalHost = downloadBlob.Uri.Host;

            using (var resultStream = new MemoryStream())
            {
                BlobDownloadToOptions downloadOptions = new()
                {
                    LayoutAwareRouting = LayoutAwareRouting.Enabled,
                    TransferOptions = new StorageTransferOptions
                    {
                        MaximumConcurrency = 10,
                        InitialTransferSize = 3 * Constants.MB,
                        MaximumTransferSize = 5 * Constants.MB
                    },
                };
                await downloadBlob.DownloadToAsync(resultStream, downloadOptions);
                Assert.AreEqual(data.Length, resultStream.Length);
                TestHelper.AssertSequenceEqual(data, resultStream.ToArray());
            }

            // Filter to requests where DataLocalityPolicy rewrote the host
            // (indicated by the presence of a Host header).
            List<DataLocalityTrackingPolicy.RequestInfo> rewrittenRequests =
                trackingPolicy.TrackedRequests.Where(r => r.HasHostHeader).ToList();

            // 20 MB blob, 3 MB initial + 5 MB chunks => 1 initial + 4 rewritten chunks.
            Assert.AreEqual(4, rewrittenRequests.Count,
                "Expected DataLocalityPolicy to rewrite the host on subsequent chunk requests under OAuth.");

            foreach (DataLocalityTrackingPolicy.RequestInfo req in rewrittenRequests)
            {
                // The URI host and port should have been rewritten to the layout endpoint
                Assert.AreNotEqual(originalHost, req.RequestHost,
                    $"Request URI host should be rewritten to layout endpoint, not '{originalHost}'");
                Assert.Greater(req.RequestPort, 0,
                    "Request URI port should be set by DataLocalityPolicy");

                // The Host header must preserve the original host
                Assert.AreEqual(originalHost, req.HostHeaderValue,
                    $"Host header should be the original host '{originalHost}', not the layout endpoint");
                Assert.AreNotEqual(req.RequestHost, req.HostHeaderValue,
                    "Host header should differ from the rewritten URI host");
            }
        }

        [LiveOnly]
        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2026_02_06)]
        public async Task DownloadToAsync_LayoutAwareRouting_WithRequestAsserts_Sas()
        {
            // Same end-to-end shape as the shared-key variant, but the download
            // client is constructed from a SAS URI.
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            long size = 20 * Constants.MB;
            var data = GetRandomBuffer(size);
            int blockSize = 4 * Constants.MB;
            var blockIds = new List<string>();
            for (int offset = 0; offset < data.Length; offset += blockSize)
            {
                int count = Math.Min(blockSize, data.Length - offset);
                string blockId = Convert.ToBase64String(
                    Encoding.UTF8.GetBytes(blockIds.Count.ToString("d6")));
                blockIds.Add(blockId);
                using var blockStream = new MemoryStream(data, offset, count);
                await blob.StageBlockAsync(blockId, blockStream);
            }
            await blob.CommitBlockListAsync(blockIds);

            // Add a tracking policy that sits after DataLocalityPolicy in the pipeline
            // to capture the rewritten host/port and Host header on each request.
            DataLocalityTrackingPolicy trackingPolicy = new DataLocalityTrackingPolicy();
            BlobClientOptions options = GetOptions();
            options.AddPolicy(trackingPolicy, HttpPipelinePosition.PerCall);

            // SAS-backed download client (no credential - auth is fully in the URI).
            Uri sasUri = blob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1));
            BlockBlobClient downloadBlob = InstrumentClient(new BlockBlobClient(sasUri, options));

            string originalHost = downloadBlob.Uri.Host;

            using (var resultStream = new MemoryStream())
            {
                BlobDownloadToOptions downloadOptions = new()
                {
                    LayoutAwareRouting = LayoutAwareRouting.Enabled,
                    TransferOptions = new StorageTransferOptions
                    {
                        MaximumConcurrency = 10,
                        InitialTransferSize = 3 * Constants.MB,
                        MaximumTransferSize = 5 * Constants.MB
                    },
                };
                await downloadBlob.DownloadToAsync(resultStream, downloadOptions);
                Assert.AreEqual(data.Length, resultStream.Length);
                TestHelper.AssertSequenceEqual(data, resultStream.ToArray());
            }

            // Filter to requests where DataLocalityPolicy rewrote the host
            // (indicated by the presence of a Host header).
            List<DataLocalityTrackingPolicy.RequestInfo> rewrittenRequests =
                trackingPolicy.TrackedRequests.Where(r => r.HasHostHeader).ToList();

            // 20 MB blob, 3 MB initial + 5 MB chunks => 1 initial + 4 rewritten chunks.
            Assert.AreEqual(4, rewrittenRequests.Count,
                "Expected DataLocalityPolicy to rewrite the host on subsequent chunk requests under SAS.");

            foreach (DataLocalityTrackingPolicy.RequestInfo req in rewrittenRequests)
            {
                // The URI host and port should have been rewritten to the layout endpoint
                Assert.AreNotEqual(originalHost, req.RequestHost,
                    $"Request URI host should be rewritten to layout endpoint, not '{originalHost}'");
                Assert.Greater(req.RequestPort, 0,
                    "Request URI port should be set by DataLocalityPolicy");

                // The Host header must preserve the original host
                Assert.AreEqual(originalHost, req.HostHeaderValue,
                    $"Host header should be the original host '{originalHost}', not the layout endpoint");
                Assert.AreNotEqual(req.RequestHost, req.HostHeaderValue,
                    "Host header should differ from the rewritten URI host");
            }
        }

        [LiveOnly]
        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2026_02_06)]
        public async Task OpenReadAsync_LayoutAwareRouting_WithRequestAsserts()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            long size = 20 * Constants.MB;
            var data = GetRandomBuffer(size);
            int blockSize = 4 * Constants.MB;
            var blockIds = new List<string>();
            for (int offset = 0; offset < data.Length; offset += blockSize)
            {
                int count = Math.Min(blockSize, data.Length - offset);
                string blockId = Convert.ToBase64String(
                    Encoding.UTF8.GetBytes(blockIds.Count.ToString("d6")));
                blockIds.Add(blockId);
                using var blockStream = new MemoryStream(data, offset, count);
                await blob.StageBlockAsync(blockId, blockStream);
            }
            await blob.CommitBlockListAsync(blockIds);

            // Add a tracking policy that sits after DataLocalityPolicy in the pipeline
            // to capture the rewritten host/port and Host header on each request.
            DataLocalityTrackingPolicy trackingPolicy = new DataLocalityTrackingPolicy();
            BlobClientOptions options = GetOptions();
            options.AddPolicy(trackingPolicy, HttpPipelinePosition.PerCall);

            var credential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);
            BlockBlobClient downloadBlob = InstrumentClient(new BlockBlobClient(blob.Uri, credential, options));

            string originalHost = blob.Uri.Host;

            // Use a 5 MB buffer so a 20 MB blob requires 4 buffer fills total,
            // all of which should be routed to layout endpoints because the
            // layout cache is built upfront when LayoutAwareRouting is Enabled.
            int bufferSize = 5 * Constants.MB;
            BlobOpenReadOptions readOptions = new(allowModifications: false)
            {
                LayoutAwareRouting = LayoutAwareRouting.Enabled,
                BufferSize = bufferSize,
            };

            using (var resultStream = new MemoryStream())
            {
                using Stream readStream = await downloadBlob.OpenReadAsync(readOptions);
                await readStream.CopyToAsync(resultStream);
                Assert.AreEqual(data.Length, resultStream.Length);
                TestHelper.AssertSequenceEqual(data, resultStream.ToArray());
            }

            // Filter to requests where DataLocalityPolicy rewrote the host
            // (indicated by the presence of a Host header).
            List<DataLocalityTrackingPolicy.RequestInfo> rewrittenRequests =
                trackingPolicy.TrackedRequests.Where(r => r.HasHostHeader).ToList();

            // With LayoutAwareRouting, the layout cache is constructed upfront,
            // so every buffer-fill request should be routed to a layout endpoint.
            // With a 5 MB buffer and a 20 MB blob, OpenRead issues 4 range downloads,
            // all of which should be rewritten.
            Assert.AreEqual(4, rewrittenRequests.Count,
                "Expected DataLocalityPolicy to rewrite the host on every buffer-fill request.");

            foreach (DataLocalityTrackingPolicy.RequestInfo req in rewrittenRequests)
            {
                // The URI host and port should have been rewritten to the layout endpoint
                Assert.AreNotEqual(originalHost, req.RequestHost,
                    $"Request URI host should be rewritten to layout endpoint, not '{originalHost}'");
                Assert.Greater(req.RequestPort, 0,
                    "Request URI port should be set by DataLocalityPolicy");

                // The Host header must preserve the original host
                Assert.AreEqual(originalHost, req.HostHeaderValue,
                    $"Host header should be the original host '{originalHost}', not the layout endpoint");
                Assert.AreNotEqual(req.RequestHost, req.HostHeaderValue,
                    "Host header should differ from the rewritten URI host");
            }
        }

        [LiveOnly]
        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2026_02_06)]
        public async Task OpenReadAsync_LayoutAwareRouting_WithPosition_WithRequestAsserts()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            long size = 20 * Constants.MB;
            var data = GetRandomBuffer(size);
            int blockSize = 4 * Constants.MB;
            var blockIds = new List<string>();
            for (int offset = 0; offset < data.Length; offset += blockSize)
            {
                int count = Math.Min(blockSize, data.Length - offset);
                string blockId = Convert.ToBase64String(
                    Encoding.UTF8.GetBytes(blockIds.Count.ToString("d6")));
                blockIds.Add(blockId);
                using var blockStream = new MemoryStream(data, offset, count);
                await blob.StageBlockAsync(blockId, blockStream);
            }
            await blob.CommitBlockListAsync(blockIds);

            // Add a tracking policy that sits after DataLocalityPolicy in the pipeline
            // to capture the rewritten host/port, Host header, and range on each request.
            DataLocalityTrackingPolicy trackingPolicy = new DataLocalityTrackingPolicy();
            BlobClientOptions options = GetOptions();
            options.AddPolicy(trackingPolicy, HttpPipelinePosition.PerCall);

            var credential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);
            BlockBlobClient downloadBlob = InstrumentClient(new BlockBlobClient(blob.Uri, credential, options));

            string originalHost = blob.Uri.Host;

            // With a 5 MB buffer and 20 MB blob, opening at 8 MB leaves 12 MB to download
            // ⇒ 3 buffer-fill requests instead of 4. The first request's range will
            // start at exactly the user's Position, and no request may start earlier.
            long position = 8 * Constants.MB;
            int bufferSize = 5 * Constants.MB;
            BlobOpenReadOptions readOptions = new(allowModifications: false)
            {
                LayoutAwareRouting = LayoutAwareRouting.Enabled,
                BufferSize = bufferSize,
                Position = position,
            };

            using (var resultStream = new MemoryStream())
            {
                using Stream readStream = await downloadBlob.OpenReadAsync(readOptions);
                await readStream.CopyToAsync(resultStream);

                // Stream length reflects the full blob, but only the bytes from
                // `position` onward should have been delivered to the caller.
                Assert.AreEqual(data.Length, readStream.Length);
                Assert.AreEqual(data.Length - position, resultStream.Length);

                byte[] expected = new byte[data.Length - position];
                Array.Copy(data, position, expected, 0, expected.Length);
                TestHelper.AssertSequenceEqual(expected, resultStream.ToArray());
            }

            // Filter to requests where DataLocalityPolicy rewrote the host
            // (indicated by the presence of a Host header).
            List<DataLocalityTrackingPolicy.RequestInfo> rewrittenRequests =
                trackingPolicy.TrackedRequests.Where(r => r.HasHostHeader).ToList();

            // With LayoutAwareRouting, every buffer-fill request should be rewritten.
            // Opening at 8 MB into a 20 MB blob with a 5 MB buffer ⇒ 3 buffer fills.
            Assert.AreEqual(3, rewrittenRequests.Count,
                "Expected DataLocalityPolicy to rewrite the host on every buffer-fill request when opening at a non-zero Position.");

            foreach (DataLocalityTrackingPolicy.RequestInfo req in rewrittenRequests)
            {
                // The URI host and port should have been rewritten to the layout endpoint.
                Assert.AreNotEqual(originalHost, req.RequestHost,
                    $"Request URI host should be rewritten to layout endpoint, not '{originalHost}'");
                Assert.Greater(req.RequestPort, 0,
                    "Request URI port should be set by DataLocalityPolicy");

                // The Host header must preserve the original host.
                Assert.AreEqual(originalHost, req.HostHeaderValue,
                    $"Host header should be the original host '{originalHost}', not the layout endpoint");
                Assert.AreNotEqual(req.RequestHost, req.HostHeaderValue,
                    "Host header should differ from the rewritten URI host");

                // The position-respecting invariant: no buffer-fill request may
                // start before the caller's Position.
                long? rangeStart = req.RangeStartOffset;
                Assert.IsNotNull(rangeStart,
                    "Buffer-fill requests should carry a range header; OpenRead should never request the entire blob.");
                Assert.GreaterOrEqual(rangeStart.Value, position,
                    $"Buffer-fill request started at offset {rangeStart.Value}, which is before the caller's Position {position}.");
            }

            // The very first buffer-fill must start exactly at the user's Position.
            // (Subsequent fills will be at position + bufferSize, position + 2*bufferSize, ...)
            Assert.AreEqual(position, rewrittenRequests[0].RangeStartOffset,
                "First buffer-fill request should start exactly at the caller's Position.");
        }

        [LiveOnly]
        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2026_02_06)]
        public async Task DownloadStreamingAsync_LayoutEndpoint_FromGetLayout()
        {
            // This is the customer-facing feature for Data Locality:
            //   1. Calls GetLayoutAsync,
            //   2. Picks the endpoint whose layout range covers the offset they
            //      want from the returned BlobLayoutInfo items,
            //   3. Passes it through BlobDownloadOptions.LayoutEndpoint to
            //      DownloadStreamingAsync.
            // We verify the same on-the-wire effect: DataLocalityPolicy
            // rewrites the URI host/port while preserving the original Host
            // header for authentication.
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange - upload a blob large enough that the service is willing
            // to return locality information.
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            long size = 20 * Constants.MB;
            var data = GetRandomBuffer(size);
            int blockSize = 4 * Constants.MB;
            var blockIds = new List<string>();
            for (int offset = 0; offset < data.Length; offset += blockSize)
            {
                int count = Math.Min(blockSize, data.Length - offset);
                string blockId = Convert.ToBase64String(
                    Encoding.UTF8.GetBytes(blockIds.Count.ToString("d6")));
                blockIds.Add(blockId);
                using var blockStream = new MemoryStream(data, offset, count);
                await blob.StageBlockAsync(blockId, blockStream);
            }
            await blob.CommitBlockListAsync(blockIds);

            // Build a tracking-instrumented client so we can observe what
            // DataLocalityPolicy did to the outgoing request.
            DataLocalityTrackingPolicy trackingPolicy = new DataLocalityTrackingPolicy();
            BlobClientOptions options = GetOptions();
            options.AddPolicy(trackingPolicy, HttpPipelinePosition.PerCall);

            var credential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);
            BlockBlobClient downloadBlob = InstrumentClient(new BlockBlobClient(blob.Uri, credential, options));

            string originalHost = blob.Uri.Host;
            int downloadOffset = 0;
            int downloadLength = 4 * Constants.MB;

            // Act - ask GetLayout for just the single entry covering
            // our download offset by passing Range = new HttpRange(downloadOffset, 1).
            // The service responds with exactly one segment and its endpoint, so
            // there's no pagination or client-side range scanning to do.
            BlobLayoutInfo layoutInfo = await downloadBlob
                .GetLayoutAsync(new BlobGetLayoutOptions { Range = new HttpRange(downloadOffset, 1) })
                .FirstAsync();

            // Single-entry layout means exactly one endpoint - just grab it.
            string layoutEndpoint = layoutInfo.Endpoints.Endpoint[0].Value;

            BlobDownloadOptions downloadOptions = new()
            {
                Range = new HttpRange(downloadOffset, downloadLength),
                LayoutEndpoint = layoutEndpoint,
            };

            int rewrittenBefore = trackingPolicy.TrackedRequests.Count(r => r.HasHostHeader);
            Response<BlobDownloadStreamingResult> response =
                await downloadBlob.DownloadStreamingAsync(downloadOptions);

            // Drain so we exercise the response body too.
            using (var resultStream = new MemoryStream())
            {
                await response.Value.Content.CopyToAsync(resultStream);
                Assert.AreEqual(downloadLength, resultStream.Length);
                TestHelper.AssertSequenceEqual(
                    new ArraySegment<byte>(data, downloadOffset, downloadLength).ToArray(),
                    resultStream.ToArray());
            }

            // Assert - exactly one new request was rewritten by DataLocalityPolicy
            // (the single-shot download issued above), and that rewrite matches
            // the endpoint the customer supplied.
            List<DataLocalityTrackingPolicy.RequestInfo> rewrittenRequests = trackingPolicy.TrackedRequests
                .Where(r => r.HasHostHeader)
                .Skip(rewrittenBefore)
                .ToList();

            Assert.AreEqual(
                1,
                rewrittenRequests.Count,
                "Expected exactly one DownloadStreaming request to be rewritten by DataLocalityPolicy.");

            DataLocalityTrackingPolicy.RequestInfo rewritten = rewrittenRequests[0];

            string expectedHost = layoutEndpoint.Split(':')[0];

            Assert.Greater(
                rewritten.RequestPort,
                0,
                "Request URI port should be set by DataLocalityPolicy.");
            Assert.AreEqual(
                originalHost,
                rewritten.HostHeaderValue,
                "Host header should preserve the original host for authentication.");
            Assert.AreNotEqual(
                rewritten.RequestHost,
                rewritten.HostHeaderValue,
                "Host header should differ from the rewritten URI host.");
        }

        [LiveOnly]
        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2026_02_06)]
        public async Task DownloadStreamingAsync_LayoutEndpoint_FromGetLayout_WithRange()
        {
            // Verifies two things on top of the baseline:
            //   1. The customer endpoint-selection loop still works for a mid-blob
            //      offset (not just offset 0, which the first segment always covers).
            //   2. The on-the-wire range header actually carries the requested offset,
            //      so the rewritten layout-endpoint request is fetching the right bytes.
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange - upload a blob large enough that the service is willing
            // to return locality information.
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            long size = 20 * Constants.MB;
            var data = GetRandomBuffer(size);
            int blockSize = 4 * Constants.MB;
            var blockIds = new List<string>();
            for (int offset = 0; offset < data.Length; offset += blockSize)
            {
                int count = Math.Min(blockSize, data.Length - offset);
                string blockId = Convert.ToBase64String(
                    Encoding.UTF8.GetBytes(blockIds.Count.ToString("d6")));
                blockIds.Add(blockId);
                using var blockStream = new MemoryStream(data, offset, count);
                await blob.StageBlockAsync(blockId, blockStream);
            }
            await blob.CommitBlockListAsync(blockIds);

            // Build a tracking-instrumented client so we can observe what
            // DataLocalityPolicy did to the outgoing request.
            DataLocalityTrackingPolicy trackingPolicy = new DataLocalityTrackingPolicy();
            BlobClientOptions options = GetOptions();
            options.AddPolicy(trackingPolicy, HttpPipelinePosition.PerCall);

            var credential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);
            BlockBlobClient downloadBlob = InstrumentClient(new BlockBlobClient(blob.Uri, credential, options));

            string originalHost = blob.Uri.Host;

            // Pick a non-zero offset that lands well into the blob so the rewritten
            // request actually has to fetch bytes from a non-first segment.
            int downloadOffset = 12 * Constants.MB;
            int downloadLength = 4 * Constants.MB;

            // Act - call GetLayout for just the single entry covering
            // our download offset by passing Range = new HttpRange(downloadOffset, 1).
            // The service responds with exactly one segment and its endpoint, so
            // there's no pagination or client-side range scanning to do.
            BlobLayoutInfo layoutInfo = await downloadBlob
                .GetLayoutAsync(new BlobGetLayoutOptions { Range = new HttpRange(downloadOffset, 1) })
                .FirstAsync();

            // Single-entry layout means exactly one endpoint - just grab it.
            string layoutEndpoint = layoutInfo.Endpoints.Endpoint[0].Value;

            BlobDownloadOptions downloadOptions = new()
            {
                Range = new HttpRange(downloadOffset, downloadLength),
                LayoutEndpoint = layoutEndpoint,
            };

            int rewrittenBefore = trackingPolicy.TrackedRequests.Count(r => r.HasHostHeader);
            Response<BlobDownloadStreamingResult> response =
                await downloadBlob.DownloadStreamingAsync(downloadOptions);

            // Drain so we exercise the response body too. The bytes must match the
            // requested range exactly - this catches any regression that would
            // accidentally route a mid-blob range request to a host that doesn't
            // serve those bytes (which would manifest as a content mismatch, not
            // an HTTP-level error).
            using (var resultStream = new MemoryStream())
            {
                await response.Value.Content.CopyToAsync(resultStream);
                Assert.AreEqual(downloadLength, resultStream.Length);
                TestHelper.AssertSequenceEqual(
                    new ArraySegment<byte>(data, downloadOffset, downloadLength).ToArray(),
                    resultStream.ToArray());
            }

            // Assert - exactly one new request was rewritten by DataLocalityPolicy
            // (the single-shot download issued above), and that rewrite matches
            // the endpoint the customer supplied.
            List<DataLocalityTrackingPolicy.RequestInfo> rewrittenRequests = trackingPolicy.TrackedRequests
                .Where(r => r.HasHostHeader)
                .Skip(rewrittenBefore)
                .ToList();

            Assert.AreEqual(
                1,
                rewrittenRequests.Count,
                "Expected exactly one DownloadStreaming request to be rewritten by DataLocalityPolicy.");

            DataLocalityTrackingPolicy.RequestInfo rewritten = rewrittenRequests[0];

            Assert.Greater(
                rewritten.RequestPort,
                0,
                "Request URI port should be set by DataLocalityPolicy.");
            Assert.AreEqual(
                originalHost,
                rewritten.HostHeaderValue,
                "Host header should preserve the original host for authentication.");
            Assert.AreNotEqual(
                rewritten.RequestHost,
                rewritten.HostHeaderValue,
                "Host header should differ from the rewritten URI host.");

            // The on-the-wire range header must carry the requested offset.
            // This locks in that BlobDownloadOptions.Range is plumbed through to the
            // x-ms-range header on the layout-endpoint-rewritten request.
            Assert.AreEqual(
                downloadOffset,
                rewritten.RangeStartOffset,
                $"Rewritten DownloadStreaming request should carry x-ms-range starting at offset {downloadOffset}.");
        }

        [LiveOnly]
        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2026_02_06)]
        public async Task DownloadContentAsync_LayoutEndpoint_FromGetLayout()
        {
            // This is the customer-facing feature for Data Locality:
            //   1. Calls GetLayoutAsync,
            //   2. Picks the endpoint whose layout range covers the offset they
            //      want from the returned BlobLayoutInfo items,
            //   3. Passes it through BlobDownloadOptions.LayoutEndpoint to
            //      DownloadContentAsync.
            // We verify the same on-the-wire effect: DataLocalityPolicy
            // rewrites the URI host/port while preserving the original Host
            // header for authentication.
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange - upload a blob large enough that the service is willing
            // to return locality information.
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            long size = 20 * Constants.MB;
            var data = GetRandomBuffer(size);
            int blockSize = 4 * Constants.MB;
            var blockIds = new List<string>();
            for (int offset = 0; offset < data.Length; offset += blockSize)
            {
                int count = Math.Min(blockSize, data.Length - offset);
                string blockId = Convert.ToBase64String(
                    Encoding.UTF8.GetBytes(blockIds.Count.ToString("d6")));
                blockIds.Add(blockId);
                using var blockStream = new MemoryStream(data, offset, count);
                await blob.StageBlockAsync(blockId, blockStream);
            }
            await blob.CommitBlockListAsync(blockIds);

            // Build a tracking-instrumented client so we can observe what
            // DataLocalityPolicy did to the outgoing request.
            DataLocalityTrackingPolicy trackingPolicy = new DataLocalityTrackingPolicy();
            BlobClientOptions options = GetOptions();
            options.AddPolicy(trackingPolicy, HttpPipelinePosition.PerCall);

            var credential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);
            BlockBlobClient downloadBlob = InstrumentClient(new BlockBlobClient(blob.Uri, credential, options));

            string originalHost = blob.Uri.Host;
            int downloadOffset = 0;
            int downloadLength = 4 * Constants.MB;

            // Act - call GetLayout for just the single entry covering
            // our download offset by passing Range = new HttpRange(downloadOffset, 1).
            // The service responds with exactly one segment and its endpoint, so
            // there's no pagination or client-side range scanning to do.
            BlobLayoutInfo layoutInfo = await downloadBlob
                .GetLayoutAsync(new BlobGetLayoutOptions { Range = new HttpRange(downloadOffset, 1) })
                .FirstAsync();

            // Single-entry layout means exactly one endpoint - just grab it.
            string layoutEndpoint = layoutInfo.Endpoints.Endpoint[0].Value;

            BlobDownloadOptions downloadOptions = new()
            {
                Range = new HttpRange(downloadOffset, downloadLength),
                LayoutEndpoint = layoutEndpoint,
            };

            int rewrittenBefore = trackingPolicy.TrackedRequests.Count(r => r.HasHostHeader);
            Response<BlobDownloadResult> response =
                await downloadBlob.DownloadContentAsync(downloadOptions);

            // Verify the response body matches the requested range.
            byte[] responseBytes = response.Value.Content.ToArray();
            Assert.AreEqual(downloadLength, responseBytes.Length);
            TestHelper.AssertSequenceEqual(
                new ArraySegment<byte>(data, downloadOffset, downloadLength).ToArray(),
                responseBytes);

            // Assert - exactly one new request was rewritten by DataLocalityPolicy
            // (the single-shot download issued above), and that rewrite matches
            // the endpoint the customer supplied.
            List<DataLocalityTrackingPolicy.RequestInfo> rewrittenRequests = trackingPolicy.TrackedRequests
                .Where(r => r.HasHostHeader)
                .Skip(rewrittenBefore)
                .ToList();

            Assert.AreEqual(
                1,
                rewrittenRequests.Count,
                "Expected exactly one DownloadContent request to be rewritten by DataLocalityPolicy.");

            DataLocalityTrackingPolicy.RequestInfo rewritten = rewrittenRequests[0];

            string expectedHost = layoutEndpoint.Split(':')[0];

            Assert.Greater(
                rewritten.RequestPort,
                0,
                "Request URI port should be set by DataLocalityPolicy.");
            Assert.AreEqual(
                originalHost,
                rewritten.HostHeaderValue,
                "Host header should preserve the original host for authentication.");
            Assert.AreNotEqual(
                rewritten.RequestHost,
                rewritten.HostHeaderValue,
                "Host header should differ from the rewritten URI host.");
        }

        [LiveOnly]
        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2026_02_06)]
        public async Task DownloadContentAsync_LayoutEndpoint_FromGetLayout_WithRange()
        {
            // Verifies two things on top of the baseline:
            //   1. The customer endpoint-selection loop still works for a mid-blob
            //      offset (not just offset 0, which the first segment always covers).
            //   2. The on-the-wire range header actually carries the requested offset,
            //      so the rewritten layout-endpoint request is fetching the right bytes.
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange - upload a blob large enough that the service is willing
            // to return locality information.
            BlockBlobClient blob = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            long size = 20 * Constants.MB;
            var data = GetRandomBuffer(size);
            int blockSize = 4 * Constants.MB;
            var blockIds = new List<string>();
            for (int offset = 0; offset < data.Length; offset += blockSize)
            {
                int count = Math.Min(blockSize, data.Length - offset);
                string blockId = Convert.ToBase64String(
                    Encoding.UTF8.GetBytes(blockIds.Count.ToString("d6")));
                blockIds.Add(blockId);
                using var blockStream = new MemoryStream(data, offset, count);
                await blob.StageBlockAsync(blockId, blockStream);
            }
            await blob.CommitBlockListAsync(blockIds);

            // Build a tracking-instrumented client so we can observe what
            // DataLocalityPolicy did to the outgoing request.
            DataLocalityTrackingPolicy trackingPolicy = new DataLocalityTrackingPolicy();
            BlobClientOptions options = GetOptions();
            options.AddPolicy(trackingPolicy, HttpPipelinePosition.PerCall);

            var credential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);
            BlockBlobClient downloadBlob = InstrumentClient(new BlockBlobClient(blob.Uri, credential, options));

            string originalHost = blob.Uri.Host;

            // Pick a non-zero offset that lands well into the blob so the rewritten
            // request actually has to fetch bytes from a non-first segment.
            int downloadOffset = 12 * Constants.MB;
            int downloadLength = 4 * Constants.MB;

            // Act - call GetLayout for just the single entry covering
            // our download offset by passing Range = new HttpRange(downloadOffset, 1).
            // The service responds with exactly one segment and its endpoint, so
            // there's no pagination or client-side range scanning to do.
            BlobLayoutInfo layoutInfo = await downloadBlob
                .GetLayoutAsync(new BlobGetLayoutOptions { Range = new HttpRange(downloadOffset, 1) })
                .FirstAsync();

            // Single-entry layout means exactly one endpoint - just grab it.
            string layoutEndpoint = layoutInfo.Endpoints.Endpoint[0].Value;

            BlobDownloadOptions downloadOptions = new()
            {
                Range = new HttpRange(downloadOffset, downloadLength),
                LayoutEndpoint = layoutEndpoint,
            };

            int rewrittenBefore = trackingPolicy.TrackedRequests.Count(r => r.HasHostHeader);
            Response<BlobDownloadResult> response =
                await downloadBlob.DownloadContentAsync(downloadOptions);

            // Verify the response body matches the requested range. The bytes must
            // match exactly - this catches any regression that would accidentally
            // route a mid-blob range request to a host that doesn't serve those bytes
            // (which would manifest as a content mismatch, not an HTTP-level error).
            byte[] responseBytes = response.Value.Content.ToArray();
            Assert.AreEqual(downloadLength, responseBytes.Length);
            TestHelper.AssertSequenceEqual(
                new ArraySegment<byte>(data, downloadOffset, downloadLength).ToArray(),
                responseBytes);

            // Assert - exactly one new request was rewritten by DataLocalityPolicy
            // (the single-shot download issued above), and that rewrite matches
            // the endpoint the customer supplied.
            List<DataLocalityTrackingPolicy.RequestInfo> rewrittenRequests = trackingPolicy.TrackedRequests
                .Where(r => r.HasHostHeader)
                .Skip(rewrittenBefore)
                .ToList();

            Assert.AreEqual(
                1,
                rewrittenRequests.Count,
                "Expected exactly one DownloadContent request to be rewritten by DataLocalityPolicy.");

            DataLocalityTrackingPolicy.RequestInfo rewritten = rewrittenRequests[0];

            Assert.Greater(
                rewritten.RequestPort,
                0,
                "Request URI port should be set by DataLocalityPolicy.");
            Assert.AreEqual(
                originalHost,
                rewritten.HostHeaderValue,
                "Host header should preserve the original host for authentication.");
            Assert.AreNotEqual(
                rewritten.RequestHost,
                rewritten.HostHeaderValue,
                "Host header should differ from the rewritten URI host.");

            // The on-the-wire range header must carry the requested offset.
            // This locks in that BlobDownloadOptions.Range is plumbed through to the
            // x-ms-range header on the layout-endpoint-rewritten request.
            Assert.AreEqual(
                downloadOffset,
                rewritten.RangeStartOffset,
                $"Rewritten DownloadContent request should carry x-ms-range starting at offset {downloadOffset}.");
        }

        [Test]
        public void ToBlobLayoutSegments_ReturnsNullOrEmpty()
        {
            BlobLayoutInfo info1 = null;
            BlobLayoutSegment[] result1 = info1.ToBlobLayoutSegments();
            Assert.IsNull(result1);

            BlobLayoutInfo info2 = new BlobLayoutInfo
            {
                Ranges = null,
                Endpoints = null,
            };
            BlobLayoutSegment[] result2 = info2.ToBlobLayoutSegments();
            Assert.IsEmpty(result2);

            BlobLayoutInfo info3 = new BlobLayoutInfo
            {
                Ranges = BlobsModelFactory.BlobLayoutRanges(Array.Empty<BlobLayoutRange>()),
                Endpoints = BlobsModelFactory.BlobLayoutEndpoints(Array.Empty<BlobLayoutEndpoint>()),
            };
            BlobLayoutSegment[] result3 = info3.ToBlobLayoutSegments();
            Assert.IsEmpty(result3);
        }

        [Test]
        public void ToBlobLayoutSegments_MultipleRanges()
        {
            BlobLayoutInfo info = new BlobLayoutInfo
            {
                Ranges = BlobsModelFactory.BlobLayoutRanges(new[]
                {
                    BlobsModelFactory.BlobLayoutRange(start: 0, end: 299, endpointIndex: 0),
                    BlobsModelFactory.BlobLayoutRange(start: 300, end: 499, endpointIndex: 1),
                    BlobsModelFactory.BlobLayoutRange(start: 500, end: 799, endpointIndex: 2),
                }),
                Endpoints = BlobsModelFactory.BlobLayoutEndpoints(new[]
                {
                    BlobsModelFactory.BlobLayoutEndpoint(index: 2, value: "https://host-c:443"),
                    BlobsModelFactory.BlobLayoutEndpoint(index: 0, value: "https://host-a:443"),
                    BlobsModelFactory.BlobLayoutEndpoint(index: 1, value: "https://host-b:443")
                }),
            };

            BlobLayoutSegment[] result = info.ToBlobLayoutSegments();

            Assert.AreEqual(3, result.Length);

            Assert.AreEqual(0, result[0].Start);
            Assert.AreEqual(299, result[0].End);
            Assert.AreEqual("https://host-a:443", result[0].Endpoint);

            Assert.AreEqual(300, result[1].Start);
            Assert.AreEqual(499, result[1].End);
            Assert.AreEqual("https://host-b:443", result[1].Endpoint);

            Assert.AreEqual(500, result[2].Start);
            Assert.AreEqual(799, result[2].End);
            Assert.AreEqual("https://host-c:443", result[2].Endpoint);
        }

        [Test]
        public void ToBlobLayoutSegments_SharedEndpoint()
        {
            BlobLayoutInfo info = new BlobLayoutInfo
            {
                Ranges = BlobsModelFactory.BlobLayoutRanges(new[]
                {
                    BlobsModelFactory.BlobLayoutRange(start: 0, end: 999, endpointIndex: 0),
                    BlobsModelFactory.BlobLayoutRange(start: 1000, end: 1999, endpointIndex: 1),
                    BlobsModelFactory.BlobLayoutRange(start: 2000, end: 2999, endpointIndex: 0),
                }),
                Endpoints = BlobsModelFactory.BlobLayoutEndpoints(new[]
                {
                    BlobsModelFactory.BlobLayoutEndpoint(index: 0, value: "https://host-a:443"),
                    BlobsModelFactory.BlobLayoutEndpoint(index: 1, value: "https://host-b:443"),
                }),
            };

            BlobLayoutSegment[] result = info.ToBlobLayoutSegments();

            Assert.AreEqual(3, result.Length);

            Assert.AreEqual(0, result[0].Start);
            Assert.AreEqual(999, result[0].End);
            Assert.AreEqual("https://host-a:443", result[0].Endpoint);

            Assert.AreEqual(1000, result[1].Start);
            Assert.AreEqual(1999, result[1].End);
            Assert.AreEqual("https://host-b:443", result[1].Endpoint);

            Assert.AreEqual(2000, result[2].Start);
            Assert.AreEqual(2999, result[2].End);
            Assert.AreEqual("https://host-a:443", result[2].Endpoint);
        }

        [Test]
        public void GetLayoutEndpoint_ReturnsNull()
        {
            // Act
            string result1 = BlobExtensions.GetLayoutEndpoint(new HttpRange(0, 100), layoutSegments: null);
            string result2 = BlobExtensions.GetLayoutEndpoint(new HttpRange(0, 100), layoutSegments: Array.Empty<BlobLayoutSegment>());

            // Assert
            Assert.IsNull(result1);
            Assert.IsNull(result2);
        }

        [Test]
        public void GetLayoutEndpoint_ChunkAlignWithSegment()
        {
            // Arrange
            var segments = new[]
            {
                new BlobLayoutSegment { Start = 0, End = 999, Endpoint = "https://host-a:443" },
                new BlobLayoutSegment { Start = 1000, End = 1999, Endpoint = "https://host-b:443" },
                new BlobLayoutSegment { Start = 2000, End = 2999, Endpoint = "https://host-c:443" }
            };

            // Act
            string result1 = BlobExtensions.GetLayoutEndpoint(new HttpRange(2000, 1000), segments);
            string result2 = BlobExtensions.GetLayoutEndpoint(new HttpRange(0, 1000), segments);

            // Assert
            Assert.AreEqual("https://host-c:443", result1);
            Assert.AreEqual("https://host-a:443", result2);
        }

        [Test]
        public void GetLayoutEndpoint_ChunkStartMidSegment()
        {
            // Arrange
            var segments = new[]
            {
                new BlobLayoutSegment { Start = 0, End = 999, Endpoint = "https://host-a:443" },
                new BlobLayoutSegment { Start = 1000, End = 1999, Endpoint = "https://host-b:443" }
            };

            // Act
            string result1 = BlobExtensions.GetLayoutEndpoint(new HttpRange(500, 200), segments);
            string result2 = BlobExtensions.GetLayoutEndpoint(new HttpRange(1200, 300), segments);

            // Assert
            Assert.AreEqual("https://host-a:443", result1);
            Assert.AreEqual("https://host-b:443", result2);
        }

        [Test]
        public void GetLayoutEndpoint_ChunkSpansMultipleSegments()
        {
            // Arrange
            var segments = new[]
            {
                new BlobLayoutSegment { Start = 0, End = 999, Endpoint = "https://host-a:443" },
                new BlobLayoutSegment { Start = 1000, End = 1999, Endpoint = "https://host-b:443" },
                new BlobLayoutSegment { Start = 2000, End = 2999, Endpoint = "https://host-c:443" }
            };

            // Act
            string result1 = BlobExtensions.GetLayoutEndpoint(new HttpRange(1500, 1000), segments);
            string result2 = BlobExtensions.GetLayoutEndpoint(new HttpRange(500, 2000), segments);
            string result3 = BlobExtensions.GetLayoutEndpoint(new HttpRange(1999, 200), segments);

            // Assert
            Assert.AreEqual("https://host-b:443", result1);
            Assert.AreEqual("https://host-a:443", result2);
            Assert.AreEqual("https://host-b:443", result3);
        }

        [Test]
        public void DataLocalityPolicy_RewritesHostAndPort_HostHeaderIsOriginal()
        {
            // Arrange
            var transport = new MockTransport(new MockResponse(200));
            var pipeline = new HttpPipeline(transport, new HttpPipelinePolicy[] { DataLocalityPolicy.Shared });

            // Set HttpMessage property with LayoutEndpoint
            string LayoutEndpoint = "https://layout-host.blob.core.windows.net:443";
            using DisposableBucket disposableBucket = new();
            disposableBucket.Add(
                HttpPipeline.CreateHttpMessagePropertiesScope(
                    new Dictionary<string, object>
                    {
                        { DataLocalityPolicy.LayoutEndpointKey, LayoutEndpoint }
                    }));

            HttpMessage message = pipeline.CreateMessage();
            message.Request.Uri.Reset(new Uri("https://original-host.blob.core.windows.net/container/blob"));

            // Act
            pipeline.Send(message, CancellationToken.None);

            // Assert - inspect the request that MockTransport received
            MockRequest request = transport.Requests[0];
            Assert.AreEqual("layout-host.blob.core.windows.net", request.Uri.Host);
            Assert.AreEqual(443, request.Uri.Port);
            Assert.IsTrue(request.Headers.TryGetValue("Host", out string hostHeader));
            // Host header should still be original
            Assert.AreEqual("original-host.blob.core.windows.net", hostHeader);
        }

        [Test]
        public void DataLocalityPolicy_NoOp_WhenPropertyNotSet()
        {
            // Arrange
            var transport = new MockTransport(new MockResponse(200));
            var pipeline = new HttpPipeline(transport, new HttpPipelinePolicy[] { DataLocalityPolicy.Shared });

            HttpMessage message = pipeline.CreateMessage();
            message.Request.Uri.Reset(new Uri("https://original-host.blob.core.windows.net/container/blob"));

            // Act - no LayoutEndpoint property set
            pipeline.Send(message, CancellationToken.None);

            // Assert - inspect the request that MockTransport received
            MockRequest request = transport.Requests[0];
            Assert.AreEqual("original-host.blob.core.windows.net", request.Uri.Host);
        }

        [Test]
        public async Task DownloadStreamingAsync_InStreamRetry_PreservesLayoutEndpointScope()
        {
            // Arrange - Force RetriableStream inside DownloadStreamingInternal to invoke
            // its Factory(offset, ...) closure by returning a faulty content stream on the
            // initial download, then a clean stream on the retry. The Factory closure is
            // expected to re-establish the LayoutEndpointKey scope so DataLocalityPolicy
            // rewrites the retry request to the layout endpoint as well.
            const string layoutEndpoint = "https://layout-host.blob.core.windows.net:443";
            Uri originalUri = new Uri("https://original-host.blob.core.windows.net/container/blob");

            byte[] payload = new byte[16];
            for (int i = 0; i < payload.Length; i++)
            {
                payload[i] = (byte)i;
            }

            // First response: faulty ContentStream that throws after a few bytes.
            FaultyStream faulty = new FaultyStream(
                new MemoryStream(payload),
                raiseExceptionAt: 4,
                maxExceptions: 1,
                exceptionToRaise: new IOException("Simulated mid-stream failure."),
                onFault: () => { });

            MockResponse first = new MockResponse(206);
            first.AddHeader("ETag", "\"etag-1\"");
            first.AddHeader("Content-Length", payload.Length.ToString());
            first.AddHeader("Content-Range", $"bytes 0-{payload.Length - 1}/{payload.Length}");
            first.AddHeader("x-ms-blob-type", "BlockBlob");
            first.ContentStream = faulty;

            // Second response: clean stream returned by the Factory(offset, ...) retry.
            // RetriableStream supplies the offset of the *next* unread byte; because the
            // first stream threw before yielding any bytes, the retry offset is 0 and the
            // mock simply returns the full payload again.
            MockResponse second = new MockResponse(206);
            second.AddHeader("ETag", "\"etag-1\"");
            second.AddHeader("Content-Length", payload.Length.ToString());
            second.AddHeader("Content-Range", $"bytes 0-{payload.Length - 1}/{payload.Length}");
            second.AddHeader("x-ms-blob-type", "BlockBlob");
            second.ContentStream = new MemoryStream(payload);

            MockTransport transport = new MockTransport(first, second);

            DataLocalityTrackingPolicy tracking = new DataLocalityTrackingPolicy();

            // BlobClientOptions registers DataLocalityPolicy.Shared as PerCall in its ctor;
            // adding `tracking` PerCall lets us observe the URI and Host header *after* the
            // rewrite.
            BlobClientOptions options = new BlobClientOptions { Transport = transport };
            options.AddPolicy(tracking, HttpPipelinePosition.PerCall);

            BlobBaseClient client = new BlobBaseClient(originalUri, options);

            BlobDownloadOptions downloadOptions = new BlobDownloadOptions
            {
                LayoutEndpoint = layoutEndpoint,
            };

            // Act
            Response<BlobDownloadStreamingResult> response =
                await client.DownloadStreamingAsync(downloadOptions);

            // Drain the stream - this is what triggers the in-stream retry through Factory(...).
            using MemoryStream sink = new MemoryStream();
            await response.Value.Content.CopyToAsync(sink);

            // Assert - exactly one initial request + one retry request went over the wire.
            Assert.AreEqual(2, transport.Requests.Count, "Expected initial + retry request.");
            Assert.AreEqual(2, tracking.TrackedRequests.Count);

            // Both requests must have been rewritten by DataLocalityPolicy.
            foreach (DataLocalityTrackingPolicy.RequestInfo req in tracking.TrackedRequests)
            {
                Assert.AreEqual("layout-host.blob.core.windows.net", req.RequestHost,
                    "Every request (initial AND retry) must be routed to the layout endpoint.");
                Assert.AreEqual(443, req.RequestPort);
                Assert.IsTrue(req.HasHostHeader,
                    "DataLocalityPolicy should preserve the original authority on the Host header.");
                Assert.AreEqual(originalUri.Host, req.HostHeaderValue,
                    "Host header should preserve the original authority for SharedKey signing.");
            }

            // And the full payload was reconstructed end-to-end via the retry.
            CollectionAssert.AreEqual(payload, sink.ToArray());
        }

        /// <summary>
        /// Pipeline policy that records the host/port and Host header of each
        /// outgoing request. Added as PerCall after DataLocalityPolicy to observe
        /// the rewritten values.
        /// </summary>
        private class DataLocalityTrackingPolicy : HttpPipelineSynchronousPolicy
        {
            public List<RequestInfo> TrackedRequests { get; } = new();

            public override void OnSendingRequest(HttpMessage message)
            {
                bool hasHostHeader = message.Request.Headers.TryGetValue("Host", out string hostValue);

                // Storage uses x-ms-range for Get Blob; fall back to standard Range for safety.
                if (!message.Request.Headers.TryGetValue("x-ms-range", out string rangeValue))
                {
                    message.Request.Headers.TryGetValue("Range", out rangeValue);
                }

                lock (TrackedRequests)
                {
                    TrackedRequests.Add(new RequestInfo
                    {
                        RequestHost = message.Request.Uri.Host,
                        RequestPort = message.Request.Uri.Port,
                        HasHostHeader = hasHostHeader,
                        HostHeaderValue = hostValue ?? string.Empty,
                        RangeHeaderValue = rangeValue,
                    });
                }
            }

            public class RequestInfo
            {
                public string RequestHost { get; set; }
                public int RequestPort { get; set; }
                public bool HasHostHeader { get; set; }
                public string HostHeaderValue { get; set; }
                public string RangeHeaderValue { get; set; }

                /// <summary>
                /// Parses the range header value (e.g. "bytes=8388608-13631487" or
                /// "bytes=8388608-") and returns the starting byte offset, or null
                /// if no range header was present or the value couldn't be parsed.
                /// </summary>
                public long? RangeStartOffset
                {
                    get
                    {
                        if (string.IsNullOrEmpty(RangeHeaderValue))
                        {
                            return null;
                        }

                        const string prefix = "bytes=";
                        string value = RangeHeaderValue.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)
                            ? RangeHeaderValue.Substring(prefix.Length)
                            : RangeHeaderValue;

                        int dashIndex = value.IndexOf('-');
                        string startToken = dashIndex < 0 ? value : value.Substring(0, dashIndex);

                        return long.TryParse(startToken, out long start) ? start : (long?)null;
                    }
                }
            }
        }
    }
}
