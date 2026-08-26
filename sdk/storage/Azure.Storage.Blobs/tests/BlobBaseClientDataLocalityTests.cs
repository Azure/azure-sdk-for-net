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
using Moq;
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

            // Set the LayoutEndpoint property on this message only
            string LayoutEndpoint = "https://layout-host.blob.core.windows.net:443";

            HttpMessage message = pipeline.CreateMessage();
            message.Request.Uri.Reset(new Uri("https://original-host.blob.core.windows.net/container/blob"));
            message.SetProperty(DataLocalityPolicy.LayoutEndpointKey, LayoutEndpoint);

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
            // initial download, then a clean stream on the retry. The Factory closure passes
            // the layout endpoint back down so it is set on the retry's own HttpMessage and
            // DataLocalityPolicy rewrites the retry request to the layout endpoint as well.
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

        #region OpenRead Data Locality

        private static readonly CancellationToken s_openReadCancellationToken = new CancellationTokenSource().Token;
        private static readonly ETag s_openReadETag = new ETag("0xQWERTY");

        [Test]
        public async Task OpenRead_LayoutAwareRouting_FetchesLayoutAndRoutesChunksToLayoutEndpoints()
        {
            // Arrange - 100 byte blob, 20 byte buffer ⇒ 5 chunked reads at
            // offsets 0, 20, 40, 60, 80. Layout splits the blob across two hosts.
            const int blobLength = 100;
            const int bufferSize = 20;

            Mock<BlobBaseClient> blockClient = CreateMockBlobBaseClient();
            SetupGetProperties(blockClient, blobLength);

            MockDataSource dataSource = new MockDataSource(blobLength);
            var capturedCalls = new List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)>();
            SetupDownloadStreamingWithCapture(blockClient, dataSource, capturedCalls);

            BlobLayoutSegment[] expectedSegments = new[]
            {
                new BlobLayoutSegment { Start = 0, End = 49, Endpoint = "https://host-a:443" },
                new BlobLayoutSegment { Start = 50, End = 99, Endpoint = "https://host-b:443" },
            };
            SetupGetLayout(blockClient, expectedSegments, blobContentLength: blobLength);

            // Act
            Stream readStream = await InvokeOpenReadAsync(blockClient.Object, bufferSize, layoutAwareRouting: LayoutAwareRouting.Enabled);
            MemoryStream destination = new MemoryStream();
            await CopyAsync(readStream, destination);

            // Assert - content is intact end-to-end
            AssertOpenReadContent(blobLength, destination);

            // Assert - exactly 5 chunked DownloadStreamingInternal calls were made,
            // and EVERY call (including the first) received the same layout cache.
            Assert.AreEqual(5, capturedCalls.Count, "Expected 5 buffer-fill downloads (100 bytes / 20-byte buffer)");

            AutoRefreshingCache<BlobLayoutSegmentCacheValue> sharedCache = capturedCalls[0].LayoutCache;
            Assert.IsNotNull(sharedCache, "OpenRead with LayoutAwareRouting.Enabled should pass a layout cache to the very first chunk");

            int hostACount = 0;
            int hostBCount = 0;
            for (int i = 0; i < capturedCalls.Count; i++)
            {
                var (range, layoutCache) = capturedCalls[i];
                Assert.AreSame(sharedCache, layoutCache,
                    $"Chunk {i} at offset {range.Offset} should receive the same AutoRefreshingCache instance as chunk 0");

                BlobLayoutSegmentCacheValue cached = await layoutCache.GetAsync(async: IsAsync, CancellationToken.None);
                BlobLayoutSegment[] segments = cached.Segments;
                Assert.IsNotNull(segments, $"Chunk {i} at offset {range.Offset} should have layout segments");

                string layoutEndpoint = BlobExtensions.GetLayoutEndpoint(range, segments);
                Assert.IsNotNull(layoutEndpoint, $"Chunk at offset {range.Offset} should resolve to a layout endpoint");

                if (range.Offset < 50)
                {
                    Assert.AreEqual("https://host-a:443", layoutEndpoint,
                        $"Chunk at offset {range.Offset} should route to host-a");
                    hostACount++;
                }
                else
                {
                    Assert.AreEqual("https://host-b:443", layoutEndpoint,
                        $"Chunk at offset {range.Offset} should route to host-b");
                    hostBCount++;
                }
            }

            Assert.AreEqual(3, hostACount, "Chunks at offsets 0, 20, 40 should route to host-a");
            Assert.AreEqual(2, hostBCount, "Chunks at offsets 60, 80 should route to host-b");

            // Assert - GetLayout was invoked exactly once and over the FULL blob
            // (default range). This is the OpenRead bootstrap+seed contract: a single
            // GetLayout call supplies both the layout AND the BlobContentLength/ETag/Metadata
            // headers, so OpenRead does not also issue GetProperties on the success path.
            VerifyGetLayoutCalledOnceForFullBlob(blockClient);
            VerifyGetPropertiesNotCalled(blockClient);
        }

        [TestCase(0)] // position == 0 (no-op range)
        [TestCase(1)] // very small offset
        [TestCase(50)] // mid-blob (boundary between two layout segments)
        [TestCase(99)] // last byte
        public async Task OpenRead_LayoutAwareRouting_Position_ReturnsRangedData(long position)
        {
            // Arrange - 100 byte blob, 20 byte buffer, layout split across two hosts.
            // OpenRead is invoked with a non-zero starting position; the returned
            // stream should expose the full blob length but only contain bytes
            // [position, blobLength) starting at offset position in the stream.
            const int blobLength = 100;
            const int bufferSize = 20;

            Mock<BlobBaseClient> blockClient = CreateMockBlobBaseClient();
            SetupGetProperties(blockClient, blobLength);

            MockDataSource dataSource = new MockDataSource(blobLength);
            var capturedCalls = new List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)>();
            SetupDownloadStreamingWithCapture(blockClient, dataSource, capturedCalls);

            BlobLayoutSegment[] segments = new[]
            {
                new BlobLayoutSegment { Start = 0, End = 49, Endpoint = "https://host-a:443" },
                new BlobLayoutSegment { Start = 50, End = 99, Endpoint = "https://host-b:443" },
            };
            SetupGetLayout(blockClient, segments, blobContentLength: blobLength);

            // Act
            Stream readStream = await InvokeOpenReadAsync(blockClient.Object, bufferSize, layoutAwareRouting: LayoutAwareRouting.Enabled, position: position);
            MemoryStream destination = new MemoryStream();
            await CopyAsync(readStream, destination);

            // Assert - stream length is the full blob length, but only the bytes
            // from `position` onward were actually downloaded.
            Assert.AreEqual(blobLength, readStream.Length);
            Assert.AreEqual(blobLength - position, destination.Length);

            // The MockDataSource writes byte (offset + i) at each position, so the
            // first byte returned at this position should equal (byte)position.
            byte[] downloaded = destination.ToArray();
            for (int i = 0; i < downloaded.Length; i++)
            {
                Assert.AreEqual((byte)(position + i), downloaded[i],
                    $"Byte {i} (blob offset {position + i}) did not match expected payload");
            }

            // Assert - every chunk download started at or after `position`.
            // OpenRead must never request bytes before the user's starting position.
            Assert.IsTrue(capturedCalls.Count > 0, "Expected at least one chunk download");
            foreach (var (range, _) in capturedCalls)
            {
                Assert.GreaterOrEqual(range.Offset, position,
                    $"DownloadStreamingInternal at offset {range.Offset} requested data before position {position}");
            }

            // Assert - the bootstrap GetLayout contract is unchanged by `position`:
            // OpenRead still seeds the layout cache for the full blob (default range)
            // so backward seeks remain layout-routed.
            VerifyGetLayoutCalledOnceForFullBlob(blockClient);
            VerifyGetPropertiesNotCalled(blockClient);
        }

        [Test]
        public async Task OpenRead_DataLocality_Disabled_NoLayoutCacheConstructed()
        {
            // Arrange - feature disabled. No cache should be constructed and GetLayout
            // must not be called even though the data source could supply layout.
            const int blobLength = 100;
            const int bufferSize = 20;

            Mock<BlobBaseClient> blockClient = CreateMockBlobBaseClient();
            SetupGetProperties(blockClient, blobLength);

            MockDataSource dataSource = new MockDataSource(blobLength);
            var capturedCalls = new List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)>();
            SetupDownloadStreamingWithCapture(blockClient, dataSource, capturedCalls);

            // Act
            Stream readStream = await InvokeOpenReadAsync(blockClient.Object, bufferSize, layoutAwareRouting: LayoutAwareRouting.Disabled);
            MemoryStream destination = new MemoryStream();
            await CopyAsync(readStream, destination);

            // Assert - content correct
            AssertOpenReadContent(blobLength, destination);

            // Assert - GetLayout was NOT called
            blockClient.Verify(c => c.GetLayoutAsync(It.IsAny<BlobGetLayoutOptions>(), It.IsAny<CancellationToken>()), Times.Never);
            blockClient.Verify(c => c.GetLayout(It.IsAny<BlobGetLayoutOptions>(), It.IsAny<CancellationToken>()), Times.Never);

            // Assert - every chunk received a null cache
            Assert.AreEqual(5, capturedCalls.Count);
            foreach (var (range, layoutCache) in capturedCalls)
            {
                Assert.IsNull(layoutCache, $"Layout cache should be null at offset {range.Offset} when LayoutAwareRouting is Disabled");
            }
        }

        [TestCase(400)]
        [TestCase(503)]
        public async Task OpenRead_DataLocality_GetLayoutSoftFailure_StillSucceeds(int status)
        {
            // Arrange - GetLayout fails with a soft (400 or 5xx) error. The shared
            // FetchLayoutInternal helper should swallow it, the cache should store a
            // null-Segments value, and OpenRead should still complete successfully
            // (chunks fall back to the original endpoint via null layout endpoint).
            const int blobLength = 100;
            const int bufferSize = 20;

            Mock<BlobBaseClient> blockClient = CreateMockBlobBaseClient();
            SetupGetProperties(blockClient, blobLength);

            MockDataSource dataSource = new MockDataSource(blobLength);
            var capturedCalls = new List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)>();
            SetupDownloadStreamingWithCapture(blockClient, dataSource, capturedCalls);

            RequestFailedException softFailure = new RequestFailedException(
                status: status,
                message: $"Soft failure ({status})",
                errorCode: null,
                innerException: null);

            blockClient.Setup(c => c.GetLayoutAsync(It.IsAny<BlobGetLayoutOptions>(), It.IsAny<CancellationToken>())).Throws(softFailure);
            blockClient.Setup(c => c.GetLayout(It.IsAny<BlobGetLayoutOptions>(), It.IsAny<CancellationToken>())).Throws(softFailure);

            // Act
            Stream readStream = await InvokeOpenReadAsync(blockClient.Object, bufferSize, layoutAwareRouting: LayoutAwareRouting.Enabled);
            MemoryStream destination = new MemoryStream();
            await CopyAsync(readStream, destination);

            // Assert - content downloaded correctly despite layout failure
            AssertOpenReadContent(blobLength, destination);

            Assert.AreEqual(5, capturedCalls.Count);
            for (int i = 0; i < capturedCalls.Count; i++)
            {
                Assert.IsNotNull(capturedCalls[i].LayoutCache, $"Chunk {i} should have a layout cache");
                BlobLayoutSegmentCacheValue cached = await capturedCalls[i].LayoutCache.GetAsync(async: IsAsync, CancellationToken.None);
                Assert.IsNull(cached.Segments, $"Chunk {i} should see null Segments after a soft GetLayout failure");
            }

            // Assert - GetLayout invoked exactly once across the bootstrap (and the
            // cache stores the failure as a null-Segments value so subsequent chunks
            // don't retry it). The seeding range still covers the entire blob.
            VerifyGetLayoutCalledOnceForFullBlob(blockClient);

            // Assert - on soft GetLayout failure we DO fall back to GetProperties exactly
            // once (this is the only branch in OpenRead that issues GetProperties when
            // LayoutAwareRouting is Enabled).
            VerifyGetPropertiesCalledOnce(blockClient);
        }

        [TestCase(401)] // Unauthorized
        [TestCase(403)] // Forbidden
        [TestCase(404)] // NotFound
        [TestCase(409)] // Conflict
        public void OpenRead_DataLocality_GetLayoutHardFailure_PropagatesToCaller(int status)
        {
            // Arrange - GetLayout fails with a HARD error (anything that is NOT 400 and
            // NOT >= 500). FetchLayoutInternal only swallows 400/5xx, so any
            // other status MUST propagate. This guards against a regression that would
            // accidentally widen the soft-failure catch and mask a permissions/state error
            // (e.g., 401/403/404) by silently falling back to GetProperties.
            const int blobLength = 100;
            const int bufferSize = 20;

            Mock<BlobBaseClient> blockClient = CreateMockBlobBaseClient();
            // Intentionally still set up GetProperties so a regression that wrongly
            // falls back to it surfaces as an explicit Verify(Times.Never) failure
            // rather than a Moq strict-mode "no setup" exception (clearer signal).
            SetupGetProperties(blockClient, blobLength);

            MockDataSource dataSource = new MockDataSource(blobLength);
            var capturedCalls = new List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)>();
            SetupDownloadStreamingWithCapture(blockClient, dataSource, capturedCalls);

            RequestFailedException hardFailure = new RequestFailedException(
                status: status,
                message: $"Hard failure ({status})",
                errorCode: null,
                innerException: null);

            blockClient.Setup(c => c.GetLayoutAsync(It.IsAny<BlobGetLayoutOptions>(), It.IsAny<CancellationToken>())).Throws(hardFailure);
            blockClient.Setup(c => c.GetLayout(It.IsAny<BlobGetLayoutOptions>(), It.IsAny<CancellationToken>())).Throws(hardFailure);

            // Act + Assert - OpenRead must propagate the exception unchanged.
            RequestFailedException thrown = Assert.ThrowsAsync<RequestFailedException>(
                async () => await InvokeOpenReadAsync(blockClient.Object, bufferSize, layoutAwareRouting: LayoutAwareRouting.Enabled));

            Assert.AreEqual(status, thrown.Status, "OpenRead should propagate the original status");
            Assert.AreSame(hardFailure, thrown, "OpenRead should propagate the original exception instance, not wrap it");

            // Assert - GetLayout was attempted exactly once (the bootstrap call); the
            // exception must short-circuit OpenRead before any chunk download is issued.
            VerifyGetLayoutCalledOnceForFullBlob(blockClient);
            Assert.AreEqual(0, capturedCalls.Count,
                "No chunk downloads should be issued when GetLayout hard-fails during bootstrap");

            // Assert - critically, the hard failure must NOT silently fall back to
            // GetProperties. Doing so would mask the real error (e.g., turn a 403 into
            // a successful read of stale data, or a 404 into a property-fetch 404).
            VerifyGetPropertiesNotCalled(blockClient);
        }

        [Test]
        public async Task OpenRead_LayoutAwareRouting_LayoutCacheSharedAcrossEveryChunk()
        {
            // Arrange - assert that the same AutoRefreshingCache instance is passed
            // to every buffer-fill download. This guards against a refactor that
            // accidentally rebuilds the cache per chunk and would defeat both the
            // de-dup of GetLayout and the locality routing.
            const int blobLength = 100;
            const int bufferSize = 25;

            Mock<BlobBaseClient> blockClient = CreateMockBlobBaseClient();
            SetupGetProperties(blockClient, blobLength);

            MockDataSource dataSource = new MockDataSource(blobLength);
            var capturedCalls = new List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)>();
            SetupDownloadStreamingWithCapture(blockClient, dataSource, capturedCalls);

            BlobLayoutSegment[] segments = new[]
            {
                new BlobLayoutSegment { Start = 0, End = 99, Endpoint = "https://host-a:443" },
            };
            SetupGetLayout(blockClient, segments, blobContentLength: blobLength);

            // Act
            Stream readStream = await InvokeOpenReadAsync(blockClient.Object, bufferSize, layoutAwareRouting: LayoutAwareRouting.Enabled);
            MemoryStream destination = new MemoryStream();
            await CopyAsync(readStream, destination);

            // Assert - 4 chunks, one shared cache, one GetLayout call.
            AssertOpenReadContent(blobLength, destination);
            Assert.AreEqual(4, capturedCalls.Count, "Expected 4 buffer-fill downloads (100 bytes / 25-byte buffer)");

            AutoRefreshingCache<BlobLayoutSegmentCacheValue> shared = capturedCalls[0].LayoutCache;
            Assert.IsNotNull(shared);
            for (int i = 1; i < capturedCalls.Count; i++)
            {
                Assert.AreSame(shared, capturedCalls[i].LayoutCache,
                    $"Chunk {i} should reuse the same AutoRefreshingCache instance as chunk 0");
            }

            // The mocked DownloadStreamingInternal short-circuits the production code path
            // that resolves the layout cache, so trigger the resolve here to drive
            // GetLayout/GetLayoutAsync exactly once and validate the seeding range.
            BlobLayoutSegmentCacheValue resolved = await shared.GetAsync(async: IsAsync, CancellationToken.None);
            Assert.IsNotNull(resolved.Segments, "Resolved layout cache should expose segments returned by GetLayout");

            VerifyGetLayoutCalledOnceForFullBlob(blockClient);
            VerifyGetPropertiesNotCalled(blockClient);
        }

        [Test]
        public async Task OpenRead_LayoutAwareRouting_DoesNotCallGetProperties_GetLayoutOnceEvenAcrossChunks()
        {
            // This test locks in the bootstrap-swap contract directly:
            //   1. With LayoutAwareRouting.Enabled, OpenRead must NOT call GetProperties.
            //      The single GetLayout call supplies ETag, BlobContentLength, and Metadata.
            //   2. GetLayout must be called exactly once for the entire OpenRead lifetime,
            //      even when many chunk-downloads happen (the layout cache de-dups them).
            //
            // Use a small buffer to force many chunk downloads and prove the invariant
            // holds across all of them, not just on the first chunk.
            const int blobLength = 200;
            const int bufferSize = 10; // ⇒ 20 buffer-fill DownloadStreamingInternal calls

            Mock<BlobBaseClient> blockClient = CreateMockBlobBaseClient();
            // Intentionally still set up GetProperties so a regression that calls it
            // surfaces as an explicit Verify(Times.Never) failure rather than a Moq
            // strict-mode "no setup" exception (which would obscure the contract).
            SetupGetProperties(blockClient, blobLength);

            MockDataSource dataSource = new MockDataSource(blobLength);
            var capturedCalls = new List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)>();
            SetupDownloadStreamingWithCapture(blockClient, dataSource, capturedCalls);

            BlobLayoutSegment[] segments = new[]
            {
                new BlobLayoutSegment { Start = 0, End = 199, Endpoint = "https://host-a:443" },
            };
            SetupGetLayout(blockClient, segments, blobContentLength: blobLength);

            // Act
            Stream readStream = await InvokeOpenReadAsync(blockClient.Object, bufferSize, layoutAwareRouting: LayoutAwareRouting.Enabled);
            MemoryStream destination = new MemoryStream();
            await CopyAsync(readStream, destination);

            // Assert - content correct end-to-end
            AssertOpenReadContent(blobLength, destination);

            // Assert - many chunk downloads happened (sanity check the test is exercising
            // the multi-chunk path, not just a single buffer fill).
            Assert.AreEqual(20, capturedCalls.Count, "Expected 20 buffer-fill downloads (200 bytes / 10-byte buffer)");

            // The mocked DownloadStreamingInternal short-circuits the production code path
            // that resolves the layout cache, so trigger the resolve here to drive
            // GetLayout/GetLayoutAsync exactly once. In production, the very first chunk's
            // layout-aware download routing would resolve the cache and seed it from the
            // bootstrap segments; subsequent chunks reuse the cached value and never re-call
            // GetLayout.
            BlobLayoutSegmentCacheValue resolved = await capturedCalls[0].LayoutCache.GetAsync(async: IsAsync, CancellationToken.None);
            Assert.IsNotNull(resolved.Segments, "Bootstrap should seed the cache with segments returned by GetLayout");

            // Resolve the cache from every chunk to model what production routing does.
            // None of these resolves should trigger an additional GetLayout call because
            // the cache is seeded once at bootstrap and reused for the lifetime of the stream.
            for (int i = 0; i < capturedCalls.Count; i++)
            {
                BlobLayoutSegmentCacheValue perChunk = await capturedCalls[i].LayoutCache.GetAsync(async: IsAsync, CancellationToken.None);
                Assert.IsNotNull(perChunk.Segments, $"Chunk {i} should see the seeded layout segments");
            }

            // The two invariants the user asked us to lock in.
            VerifyGetLayoutCalledOnceForFullBlob(blockClient);
            VerifyGetPropertiesNotCalled(blockClient);
        }

        #region OpenRead Helpers

        private Mock<BlobBaseClient> CreateMockBlobBaseClient()
        {
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(
                MockBehavior.Strict,
                new Uri("http://mock"),
                new BlobClientOptions());
            blockClient.SetupGet(c => c.ClientConfiguration).CallBase();
            blockClient.SetupGet(c => c.UsingClientSideEncryption).Returns(false);
            return blockClient;
        }

        private static void SetupGetProperties(Mock<BlobBaseClient> blockClient, long contentLength)
        {
            BlobProperties properties = BlobsModelFactory.BlobProperties(
                contentLength: contentLength,
                eTag: s_openReadETag,
                lastModified: DateTimeOffset.UtcNow,
                metadata: new Dictionary<string, string>());

            Response<BlobProperties> response = Response.FromValue(properties, new MockResponse(200));

            blockClient.Setup(c => c.GetPropertiesInternal(
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<bool>(),
                It.IsAny<RequestContext>(),
                It.IsAny<string>())).ReturnsAsync(response);
        }

        private void SetupDownloadStreamingWithCapture(
            Mock<BlobBaseClient> blockClient,
            MockDataSource dataSource,
            List<(HttpRange Range, AutoRefreshingCache<BlobLayoutSegmentCacheValue> LayoutCache)> capturedCalls)
        {
            // NOTE: cannot match the cancellation token with a literal here. The OpenRead path
            // returns a stream and subsequent Read/ReadAsync invocations route through
            // LazyLoadingReadOnlyStream, which forwards whatever token the caller passes in
            // (CancellationToken.None when CopyTo/CopyToAsync are invoked without args). The
            // IsAsync parameter is still forwarded faithfully and so can be matched directly.
            blockClient.Setup(c => c.DownloadStreamingInternal(
                It.IsAny<HttpRange>(),
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<DownloadTransferValidationOptions>(),
                It.IsAny<IProgress<long>>(),
                It.IsAny<string>(),
                IsAsync,
                It.IsAny<CancellationToken>(),
                It.IsAny<AutoRefreshingCache<BlobLayoutSegmentCacheValue>>(),
                It.IsAny<string>())
            ).Returns<HttpRange, BlobRequestConditions, DownloadTransferValidationOptions, IProgress<long>, string, bool, CancellationToken, AutoRefreshingCache<BlobLayoutSegmentCacheValue>, string>(
                (range, conditions, validation, progress, operationName, async, cancellation, layoutCache, layoutEndpoint) =>
                {
                    lock (capturedCalls)
                    {
                        capturedCalls.Add((range, layoutCache));
                    }
                    return async
                        ? dataSource.GetStreamAsync(range)
                        : new ValueTask<Response<BlobDownloadStreamingResult>>(dataSource.GetStream(range));
                });
        }

        private static void SetupGetLayout(Mock<BlobBaseClient> blockClient, BlobLayoutSegment[] segments, long blobContentLength)
        {
            var rangeItems = new List<BlobLayoutRange>();
            var endpointItems = new List<BlobLayoutEndpoint>();
            var endpointMap = new Dictionary<string, int>();

            foreach (var seg in segments)
            {
                if (!endpointMap.TryGetValue(seg.Endpoint, out int idx))
                {
                    idx = endpointMap.Count;
                    endpointMap[seg.Endpoint] = idx;
                    endpointItems.Add(BlobsModelFactory.BlobLayoutEndpoint(index: idx, value: seg.Endpoint));
                }
                rangeItems.Add(BlobsModelFactory.BlobLayoutRange(start: seg.Start, end: seg.End, endpointIndex: idx));
            }

            // OpenRead bootstraps from GetLayout when LayoutAwareRouting is Enabled, so the
            // returned BlobLayoutInfo must carry the headers that previously came from
            // GetProperties (BlobContentLength, ETag, Metadata).
            BlobLayoutInfo layoutInfo = new BlobLayoutInfo
            {
                Ranges = BlobsModelFactory.BlobLayoutRanges(rangeItems),
                Endpoints = BlobsModelFactory.BlobLayoutEndpoints(endpointItems),
                BlobContentLength = blobContentLength,
                ETag = s_openReadETag,
                Metadata = new Dictionary<string, string>(),
            };

            blockClient.Setup(c => c.GetLayoutAsync(
                It.IsAny<BlobGetLayoutOptions>(),
                It.IsAny<CancellationToken>()
            )).Returns(new MockAsyncPageable(layoutInfo));

            blockClient.Setup(c => c.GetLayout(
                It.IsAny<BlobGetLayoutOptions>(),
                It.IsAny<CancellationToken>()
            )).Returns(new MockPageable(layoutInfo));
        }

        private void VerifyGetLayoutCalledOnceForFullBlob(Mock<BlobBaseClient> blockClient)
        {
            // OpenRead bootstrap doesn't yet know the blob's length, so it calls
            // GetLayout with the default HttpRange (offset 0, length null) which the
            // service interprets as "the whole blob". This is the contract we lock in.
            if (IsAsync)
            {
                blockClient.Verify(c => c.GetLayoutAsync(
                    It.Is<BlobGetLayoutOptions>(o => (o == null ? default(HttpRange) : o.Range).Offset == 0 && (o == null ? default(HttpRange) : o.Range).Length == null),
                    It.IsAny<CancellationToken>()), Times.Once);
            }
            else
            {
                blockClient.Verify(c => c.GetLayout(
                    It.Is<BlobGetLayoutOptions>(o => (o == null ? default(HttpRange) : o.Range).Offset == 0 && (o == null ? default(HttpRange) : o.Range).Length == null),
                    It.IsAny<CancellationToken>()), Times.Once);
            }
        }

        private static void VerifyGetPropertiesNotCalled(Mock<BlobBaseClient> blockClient)
        {
            // With LayoutAwareRouting.Enabled and a successful GetLayout, OpenRead must not
            // also issue a GetProperties call — the layout response carries the headers
            // (ETag, BlobContentLength, Metadata) needed to bootstrap the stream.
            blockClient.Verify(c => c.GetPropertiesInternal(
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<bool>(),
                It.IsAny<RequestContext>(),
                It.IsAny<string>()), Times.Never);
        }

        private static void VerifyGetPropertiesCalledOnce(Mock<BlobBaseClient> blockClient)
        {
            // The locality soft-failure path falls back to a single GetProperties call to
            // recover ETag/length/metadata when GetLayout returned a 400/5xx.
            blockClient.Verify(c => c.GetPropertiesInternal(
                It.IsAny<BlobRequestConditions>(),
                It.IsAny<bool>(),
                It.IsAny<RequestContext>(),
                It.IsAny<string>()), Times.Once);
        }

        private async Task<Stream> InvokeOpenReadAsync(BlobBaseClient client, int bufferSize, LayoutAwareRouting layoutAwareRouting, long position = 0)
        {
            BlobOpenReadOptions options = new BlobOpenReadOptions(allowModifications: false)
            {
                BufferSize = bufferSize,
                LayoutAwareRouting = layoutAwareRouting,
                Position = position,
            };

            // Internal overload exposes the LayoutAwareRouting + async + cancellationToken parameters directly.
            return await client.OpenReadInternal(
                position: options.Position,
                bufferSize: options.BufferSize,
                conditions: options.Conditions,
                allowModifications: false,
                transferValidationOverride: options.TransferValidation,
                layoutAwareRouting: options.LayoutAwareRouting,
                async: IsAsync,
                cancellationToken: s_openReadCancellationToken).ConfigureAwait(false);
        }

        private async Task CopyAsync(Stream source, Stream destination)
        {
            if (IsAsync)
            {
                await source.CopyToAsync(destination).ConfigureAwait(false);
            }
            else
            {
                source.CopyTo(destination);
            }
        }

        private static void AssertOpenReadContent(int expectedLength, MemoryStream stream)
        {
            Assert.AreEqual(expectedLength, stream.Length);

            byte[] array = stream.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual((byte)i, array[i]);
            }
        }

        #endregion

        #region OpenRead Mock Plumbing

        private class MockAsyncPageable : AsyncPageable<BlobLayoutInfo>
        {
            private readonly BlobLayoutInfo[] _layoutInfos;

            public MockAsyncPageable(BlobLayoutInfo layoutInfo)
                : this(new[] { layoutInfo })
            {
            }

            public MockAsyncPageable(BlobLayoutInfo[] layoutInfos)
            {
                _layoutInfos = layoutInfos;
            }

            public override async IAsyncEnumerable<Page<BlobLayoutInfo>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                await Task.CompletedTask;
                foreach (BlobLayoutInfo layoutInfo in _layoutInfos)
                {
                    yield return Page<BlobLayoutInfo>.FromValues(new[] { layoutInfo }, null, new MockResponse(200));
                }
            }
        }

        private class MockPageable : Pageable<BlobLayoutInfo>
        {
            private readonly BlobLayoutInfo[] _layoutInfos;

            public MockPageable(BlobLayoutInfo layoutInfo)
                : this(new[] { layoutInfo })
            {
            }

            public MockPageable(BlobLayoutInfo[] layoutInfos)
            {
                _layoutInfos = layoutInfos;
            }

            public override IEnumerable<Page<BlobLayoutInfo>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                foreach (BlobLayoutInfo layoutInfo in _layoutInfos)
                {
                    yield return Page<BlobLayoutInfo>.FromValues(new[] { layoutInfo }, null, new MockResponse(200));
                }
            }
        }

        private class MockDataSource
        {
            private readonly int _length;

            public MockDataSource(int length)
            {
                _length = length;
            }

            public async ValueTask<Response<BlobDownloadStreamingResult>> GetStreamAsync(HttpRange range)
            {
                await Task.Delay(1).ConfigureAwait(false);
                return GetStream(range);
            }

            public Response<BlobDownloadStreamingResult> GetStream(HttpRange range)
            {
                long offset = range.Offset;
                long requested = range.Length ?? (_length - offset);
                long remaining = Math.Max(0, _length - offset);
                int contentLength = (int)Math.Min(requested, remaining);

                MemoryStream memoryStream = new MemoryStream();
                for (int i = 0; i < contentLength; i++)
                {
                    memoryStream.WriteByte((byte)(offset + i));
                }
                memoryStream.Position = 0;

                string contentRange = $"bytes {offset}-{Math.Max(offset, offset + contentLength - 1)}/{_length}";

                // LazyLoadingReadOnlyStream parses the blob length from the raw Content-Range
                // response header (not from BlobDownloadDetails.ContentRange), so it must be
                // present on the underlying MockResponse for OpenRead chunked reads.
                MockResponse rawResponse = new MockResponse(200);
                rawResponse.AddHeader("Content-Range", contentRange);

                return Response.FromValue(new BlobDownloadStreamingResult()
                {
                    Content = memoryStream,
                    Details = new BlobDownloadDetails()
                    {
                        BlobType = BlobType.Block,
                        ContentLength = contentLength,
                        ContentType = "test",
                        LastModified = DateTimeOffset.UtcNow,
                        Metadata = new Dictionary<string, string>(),
                        ContentRange = contentRange,
                        ETag = s_openReadETag,
                    }
                }, rawResponse);
            }
        }

        #endregion

        #endregion

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
