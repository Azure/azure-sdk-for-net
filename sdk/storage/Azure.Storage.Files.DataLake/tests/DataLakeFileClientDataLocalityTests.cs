// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class DataLakeFileClientDataLocalityTests : PathTestBase
    {
        public DataLakeFileClientDataLocalityTests(bool async, DataLakeClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [LiveOnly]
        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task ReadToAsync_LayoutAwareRouting_WithRequestAsserts()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
            long size = 20 * Constants.MB;
            byte[] data = GetRandomBuffer(size);

            // Upload the file in chunks via Append/Flush.
            int chunkSize = 4 * Constants.MB;
            for (int offset = 0; offset < data.Length; offset += chunkSize)
            {
                int count = Math.Min(chunkSize, data.Length - offset);
                using var chunk = new MemoryStream(data, offset, count);
                await file.AppendAsync(chunk, offset);
            }
            await file.FlushAsync(size);

            // Add a tracking policy that sits after DataLocalityPolicy in the pipeline
            // to capture the rewritten host/port and Host header on each request.
            DataLocalityTrackingPolicy trackingPolicy = new DataLocalityTrackingPolicy();
            DataLakeClientOptions options = GetOptions();
            options.AddPolicy(trackingPolicy, HttpPipelinePosition.PerCall);

            DataLakeFileClient downloadFile = InstrumentClient(new DataLakeFileClient(
                file.Uri,
                Tenants.GetNewHnsSharedKeyCredentials(),
                options));

            string originalHost = file.Uri.Host;

            using (var resultStream = new MemoryStream())
            {
                DataLakeFileReadToOptions readOptions = new()
                {
                    LayoutAwareRouting = Blobs.Models.LayoutAwareRouting.Enabled,
                    TransferOptions = new StorageTransferOptions
                    {
                        MaximumConcurrency = 10,
                        InitialTransferSize = 3 * Constants.MB,
                        MaximumTransferSize = 5 * Constants.MB
                    },
                };
                await downloadFile.ReadToAsync(resultStream, readOptions);
                Assert.AreEqual(data.Length, resultStream.Length);
                TestHelper.AssertSequenceEqual(data, resultStream.ToArray());
            }

            // Filter to requests where DataLocalityPolicy rewrote the host
            // (indicated by the presence of a Host header).
            List<DataLocalityTrackingPolicy.RequestInfo> rewrittenRequests =
                trackingPolicy.TrackedRequests.Where(r => r.HasHostHeader).ToList();

            // When the service returns a download hint, subsequent chunk requests
            // should be rewritten. Given 3MB of initial transfer size and 5MB of max
            // transfer size, the 20MB file should be downloaded in 1 + 4 subsequent
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
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task OpenReadAsync_LayoutAwareRouting_WithRequestAsserts()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
            long size = 20 * Constants.MB;
            byte[] data = GetRandomBuffer(size);

            // Upload the file in chunks via Append/Flush.
            int chunkSize = 4 * Constants.MB;
            for (int offset = 0; offset < data.Length; offset += chunkSize)
            {
                int count = Math.Min(chunkSize, data.Length - offset);
                using var chunk = new MemoryStream(data, offset, count);
                await file.AppendAsync(chunk, offset);
            }
            await file.FlushAsync(size);

            // Add a tracking policy that sits after DataLocalityPolicy in the pipeline
            // to capture the rewritten host/port and Host header on each request.
            DataLocalityTrackingPolicy trackingPolicy = new DataLocalityTrackingPolicy();
            DataLakeClientOptions options = GetOptions();
            options.AddPolicy(trackingPolicy, HttpPipelinePosition.PerCall);

            DataLakeFileClient downloadFile = InstrumentClient(new DataLakeFileClient(
                file.Uri,
                Tenants.GetNewHnsSharedKeyCredentials(),
                options));

            string originalHost = file.Uri.Host;

            // Use a 5 MB buffer so a 20 MB file requires 4 buffer fills total,
            // all of which should be routed to layout endpoints because the
            // layout cache is built upfront when LayoutAwareRouting is Enabled.
            int bufferSize = 5 * Constants.MB;
            DataLakeOpenReadOptions readOptions = new(allowModifications: false)
            {
                LayoutAwareRouting = Blobs.Models.LayoutAwareRouting.Enabled,
                BufferSize = bufferSize,
            };

            using (var resultStream = new MemoryStream())
            {
                using Stream readStream = await downloadFile.OpenReadAsync(readOptions);
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
            // With a 5 MB buffer and a 20 MB file, OpenRead issues 4 range downloads,
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
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task OpenReadAsync_LayoutAwareRouting_WithPosition_WithRequestAsserts()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
            long size = 20 * Constants.MB;
            byte[] data = GetRandomBuffer(size);

            // Upload the file in chunks via Append/Flush.
            int chunkSize = 4 * Constants.MB;
            for (int offset = 0; offset < data.Length; offset += chunkSize)
            {
                int count = Math.Min(chunkSize, data.Length - offset);
                using var chunk = new MemoryStream(data, offset, count);
                await file.AppendAsync(chunk, offset);
            }
            await file.FlushAsync(size);

            // Add a tracking policy that sits after DataLocalityPolicy in the pipeline
            // to capture the rewritten host/port, Host header, and range on each request.
            DataLocalityTrackingPolicy trackingPolicy = new DataLocalityTrackingPolicy();
            DataLakeClientOptions options = GetOptions();
            options.AddPolicy(trackingPolicy, HttpPipelinePosition.PerCall);

            DataLakeFileClient downloadFile = InstrumentClient(new DataLakeFileClient(
                file.Uri,
                Tenants.GetNewHnsSharedKeyCredentials(),
                options));

            string originalHost = file.Uri.Host;

            // With a 5 MB buffer and 20 MB file, opening at 8 MB leaves 12 MB to download
            // ⇒ 3 buffer-fill requests instead of 4. The first request's range will
            // start at exactly the user's Position, and no request may start earlier.
            long position = 8 * Constants.MB;
            int bufferSize = 5 * Constants.MB;
            DataLakeOpenReadOptions readOptions = new(allowModifications: false)
            {
                LayoutAwareRouting = Blobs.Models.LayoutAwareRouting.Enabled,
                BufferSize = bufferSize,
                Position = position,
            };

            using (var resultStream = new MemoryStream())
            {
                using Stream readStream = await downloadFile.OpenReadAsync(readOptions);
                await readStream.CopyToAsync(resultStream);

                // Stream length reflects the full file, but only the bytes from
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
            // Opening at 8 MB into a 20 MB file with a 5 MB buffer ⇒ 3 buffer fills.
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
                    "Buffer-fill requests should carry a range header; OpenRead should never request the entire file.");
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
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task ReadStreamingAsync_LayoutEndpoint_FromGetLayout()
        {
            // This is the customer-facing feature for Data Locality on the
            // one-shot read path:
            //   1. Calls GetLayoutAsync,
            //   2. Picks the endpoint whose layout range covers the offset they
            //      want from the returned DataLakeFileLayoutInfo items,
            //   3. Passes it through DataLakeFileReadOptions.LayoutEndpoint to
            //      ReadStreamingAsync.
            // We verify the same on-the-wire effect: DataLocalityPolicy
            // rewrites the URI host/port while preserving the original Host
            // header for authentication.
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange - upload a file large enough that the service is willing
            // to return locality information.
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
            long size = 20 * Constants.MB;
            byte[] data = GetRandomBuffer(size);
            int chunkSize = 4 * Constants.MB;
            for (int offset = 0; offset < data.Length; offset += chunkSize)
            {
                int count = Math.Min(chunkSize, data.Length - offset);
                using var chunk = new MemoryStream(data, offset, count);
                await file.AppendAsync(chunk, offset);
            }
            await file.FlushAsync(size);

            // Build a tracking-instrumented client so we can observe what
            // DataLocalityPolicy did to the outgoing request.
            DataLocalityTrackingPolicy trackingPolicy = new DataLocalityTrackingPolicy();
            DataLakeClientOptions options = GetOptions();
            options.AddPolicy(trackingPolicy, HttpPipelinePosition.PerCall);

            DataLakeFileClient downloadFile = InstrumentClient(new DataLakeFileClient(
                file.Uri,
                Tenants.GetNewHnsSharedKeyCredentials(),
                options));

            string originalHost = file.Uri.Host;
            int downloadOffset = 0;
            int downloadLength = 4 * Constants.MB;

            // Act - call GetLayout for just the single entry covering
            // our read offset by passing Range = new HttpRange(downloadOffset, 1).
            // The service responds with exactly one segment and its endpoint, so
            // there's no pagination or client-side range scanning to do.
            DataLakeFileLayoutInfo layoutInfo = await downloadFile
                .GetLayoutAsync(new DataLakeFileGetLayoutOptions { Range = new HttpRange(downloadOffset, 1) })
                .FirstAsync();

            // Single-entry layout means exactly one endpoint - just grab it.
            string layoutEndpoint = layoutInfo.Endpoints.Endpoint[0].Value;

            DataLakeFileReadOptions readOptions = new()
            {
                Range = new HttpRange(downloadOffset, downloadLength),
                LayoutEndpoint = layoutEndpoint,
            };

            int rewrittenBefore = trackingPolicy.TrackedRequests.Count(r => r.HasHostHeader);
            Response<DataLakeFileReadStreamingResult> response =
                await downloadFile.ReadStreamingAsync(readOptions);

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
            // (the single-shot read issued above), and that rewrite matches
            // the endpoint the customer supplied.
            List<DataLocalityTrackingPolicy.RequestInfo> rewrittenRequests = trackingPolicy.TrackedRequests
                .Where(r => r.HasHostHeader)
                .Skip(rewrittenBefore)
                .ToList();

            Assert.AreEqual(
                1,
                rewrittenRequests.Count,
                "Expected exactly one ReadStreaming request to be rewritten by DataLocalityPolicy.");

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
        }

        [LiveOnly]
        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task ReadStreamingAsync_LayoutEndpoint_FromGetLayout_WithRange()
        {
            // Verifies two things on top of the baseline:
            //   1. The customer endpoint-selection loop still works for a mid-file
            //      offset (not just offset 0, which the first segment always covers).
            //   2. The on-the-wire range header actually carries the requested offset,
            //      so the rewritten layout-endpoint request is fetching the right bytes.
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange - upload a file large enough that the service is willing
            // to return locality information.
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
            long size = 20 * Constants.MB;
            byte[] data = GetRandomBuffer(size);
            int chunkSize = 4 * Constants.MB;
            for (int offset = 0; offset < data.Length; offset += chunkSize)
            {
                int count = Math.Min(chunkSize, data.Length - offset);
                using var chunk = new MemoryStream(data, offset, count);
                await file.AppendAsync(chunk, offset);
            }
            await file.FlushAsync(size);

            // Build a tracking-instrumented client so we can observe what
            // DataLocalityPolicy did to the outgoing request.
            DataLocalityTrackingPolicy trackingPolicy = new DataLocalityTrackingPolicy();
            DataLakeClientOptions options = GetOptions();
            options.AddPolicy(trackingPolicy, HttpPipelinePosition.PerCall);

            DataLakeFileClient downloadFile = InstrumentClient(new DataLakeFileClient(
                file.Uri,
                Tenants.GetNewHnsSharedKeyCredentials(),
                options));

            string originalHost = file.Uri.Host;

            // Pick a non-zero offset that lands well into the file so the customer's
            // segment-selection loop has to actually walk past the first range.
            int downloadOffset = 12 * Constants.MB;
            int downloadLength = 4 * Constants.MB;

            // Act - call GetLayout for just the single entry covering
            // our read offset by passing Range = new HttpRange(downloadOffset, 1).
            // The service responds with exactly one segment and its endpoint, so
            // there's no pagination or client-side range scanning to do.
            DataLakeFileLayoutInfo layoutInfo = await downloadFile
                .GetLayoutAsync(new DataLakeFileGetLayoutOptions { Range = new HttpRange(downloadOffset, 1) })
                .FirstAsync();

            // Single-entry layout means exactly one endpoint - just grab it.
            string layoutEndpoint = layoutInfo.Endpoints.Endpoint[0].Value;

            DataLakeFileReadOptions readOptions = new()
            {
                Range = new HttpRange(downloadOffset, downloadLength),
                LayoutEndpoint = layoutEndpoint,
            };

            int rewrittenBefore = trackingPolicy.TrackedRequests.Count(r => r.HasHostHeader);
            Response<DataLakeFileReadStreamingResult> response =
                await downloadFile.ReadStreamingAsync(readOptions);

            // Drain so we exercise the response body too. The bytes must match the
            // requested range exactly - this catches any regression that would
            // accidentally route a mid-file range request to a host that doesn't
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
            // (the single-shot read issued above), and that rewrite matches
            // the endpoint the customer supplied.
            List<DataLocalityTrackingPolicy.RequestInfo> rewrittenRequests = trackingPolicy.TrackedRequests
                .Where(r => r.HasHostHeader)
                .Skip(rewrittenBefore)
                .ToList();

            Assert.AreEqual(
                1,
                rewrittenRequests.Count,
                "Expected exactly one ReadStreaming request to be rewritten by DataLocalityPolicy.");

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
            // This locks in that DataLakeFileReadOptions.Range is plumbed through to the
            // x-ms-range header on the layout-endpoint-rewritten request.
            Assert.AreEqual(
                downloadOffset,
                rewritten.RangeStartOffset,
                $"Rewritten ReadStreaming request should carry x-ms-range starting at offset {downloadOffset}.");
        }

        [LiveOnly]
        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task ReadContentAsync_LayoutEndpoint_FromGetLayout()
        {
            // This is the customer-facing feature for Data Locality on the
            // one-shot read-content path:
            //   1. Calls GetLayoutAsync,
            //   2. Picks the endpoint whose layout range covers the offset they
            //      want from the returned DataLakeFileLayoutInfo items,
            //   3. Passes it through DataLakeFileReadOptions.LayoutEndpoint to
            //      ReadContentAsync.
            // We verify the same on-the-wire effect: DataLocalityPolicy
            // rewrites the URI host/port while preserving the original Host
            // header for authentication.
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange - upload a file large enough that the service is willing
            // to return locality information.
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
            long size = 20 * Constants.MB;
            byte[] data = GetRandomBuffer(size);
            int chunkSize = 4 * Constants.MB;
            for (int offset = 0; offset < data.Length; offset += chunkSize)
            {
                int count = Math.Min(chunkSize, data.Length - offset);
                using var chunk = new MemoryStream(data, offset, count);
                await file.AppendAsync(chunk, offset);
            }
            await file.FlushAsync(size);

            // Build a tracking-instrumented client so we can observe what
            // DataLocalityPolicy did to the outgoing request.
            DataLocalityTrackingPolicy trackingPolicy = new DataLocalityTrackingPolicy();
            DataLakeClientOptions options = GetOptions();
            options.AddPolicy(trackingPolicy, HttpPipelinePosition.PerCall);

            DataLakeFileClient downloadFile = InstrumentClient(new DataLakeFileClient(
                file.Uri,
                Tenants.GetNewHnsSharedKeyCredentials(),
                options));

            string originalHost = file.Uri.Host;
            int downloadOffset = 0;
            int downloadLength = 4 * Constants.MB;

            // Act - call GetLayout for just the single entry covering
            // our read offset by passing Range = new HttpRange(downloadOffset, 1).
            // The service responds with exactly one segment and its endpoint, so
            // there's no pagination or client-side range scanning to do.
            DataLakeFileLayoutInfo layoutInfo = await downloadFile
                .GetLayoutAsync(new DataLakeFileGetLayoutOptions { Range = new HttpRange(downloadOffset, 1) })
                .FirstAsync();

            // Single-entry layout means exactly one endpoint - just grab it.
            string layoutEndpoint = layoutInfo.Endpoints.Endpoint[0].Value;

            DataLakeFileReadOptions readOptions = new()
            {
                Range = new HttpRange(downloadOffset, downloadLength),
                LayoutEndpoint = layoutEndpoint,
            };

            int rewrittenBefore = trackingPolicy.TrackedRequests.Count(r => r.HasHostHeader);
            Response<DataLakeFileReadResult> response =
                await downloadFile.ReadContentAsync(readOptions);

            // Verify the response body matches the requested range.
            byte[] responseBytes = response.Value.Content.ToArray();
            Assert.AreEqual(downloadLength, responseBytes.Length);
            TestHelper.AssertSequenceEqual(
                new ArraySegment<byte>(data, downloadOffset, downloadLength).ToArray(),
                responseBytes);

            // Assert - exactly one new request was rewritten by DataLocalityPolicy
            // (the single-shot read issued above), and that rewrite matches
            // the endpoint the customer supplied.
            List<DataLocalityTrackingPolicy.RequestInfo> rewrittenRequests = trackingPolicy.TrackedRequests
                .Where(r => r.HasHostHeader)
                .Skip(rewrittenBefore)
                .ToList();

            Assert.AreEqual(
                1,
                rewrittenRequests.Count,
                "Expected exactly one ReadContent request to be rewritten by DataLocalityPolicy.");

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
        }

        [LiveOnly]
        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task ReadContentAsync_LayoutEndpoint_FromGetLayout_WithRange()
        {
            // Verifies two things on top of the baseline:
            //   1. The customer endpoint-selection loop still works for a mid-file
            //      offset (not just offset 0, which the first segment always covers).
            //   2. The on-the-wire range header actually carries the requested offset,
            //      so the rewritten layout-endpoint request is fetching the right bytes.
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange - upload a file large enough that the service is willing
            // to return locality information.
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName());
            long size = 20 * Constants.MB;
            byte[] data = GetRandomBuffer(size);
            int chunkSize = 4 * Constants.MB;
            for (int offset = 0; offset < data.Length; offset += chunkSize)
            {
                int count = Math.Min(chunkSize, data.Length - offset);
                using var chunk = new MemoryStream(data, offset, count);
                await file.AppendAsync(chunk, offset);
            }
            await file.FlushAsync(size);

            // Build a tracking-instrumented client so we can observe what
            // DataLocalityPolicy did to the outgoing request.
            DataLocalityTrackingPolicy trackingPolicy = new DataLocalityTrackingPolicy();
            DataLakeClientOptions options = GetOptions();
            options.AddPolicy(trackingPolicy, HttpPipelinePosition.PerCall);

            DataLakeFileClient downloadFile = InstrumentClient(new DataLakeFileClient(
                file.Uri,
                Tenants.GetNewHnsSharedKeyCredentials(),
                options));

            string originalHost = file.Uri.Host;

            // Pick a non-zero offset that lands well into the file so the chosen
            // layout segment isn't necessarily the first one.
            int downloadOffset = 12 * Constants.MB;
            int downloadLength = 4 * Constants.MB;

            // Act - call GetLayout for just the single entry covering
            // our read offset by passing Range = new HttpRange(downloadOffset, 1).
            // The service responds with exactly one segment and its endpoint, so
            // there's no pagination or client-side range scanning to do.
            DataLakeFileLayoutInfo layoutInfo = await downloadFile
                .GetLayoutAsync(new DataLakeFileGetLayoutOptions { Range = new HttpRange(downloadOffset, 1) })
                .FirstAsync();

            // Single-entry layout means exactly one endpoint - just grab it.
            string layoutEndpoint = layoutInfo.Endpoints.Endpoint[0].Value;

            DataLakeFileReadOptions readOptions = new()
            {
                Range = new HttpRange(downloadOffset, downloadLength),
                LayoutEndpoint = layoutEndpoint,
            };

            int rewrittenBefore = trackingPolicy.TrackedRequests.Count(r => r.HasHostHeader);
            Response<DataLakeFileReadResult> response =
                await downloadFile.ReadContentAsync(readOptions);

            // Verify the response body matches the requested range. The bytes must
            // match exactly - this catches any regression that would accidentally
            // route a mid-file range request to a host that doesn't serve those bytes
            // (which would manifest as a content mismatch, not an HTTP-level error).
            byte[] responseBytes = response.Value.Content.ToArray();
            Assert.AreEqual(downloadLength, responseBytes.Length);
            TestHelper.AssertSequenceEqual(
                new ArraySegment<byte>(data, downloadOffset, downloadLength).ToArray(),
                responseBytes);

            // Assert - exactly one new request was rewritten by DataLocalityPolicy
            // (the single-shot read issued above), and that rewrite matches
            // the endpoint the customer supplied.
            List<DataLocalityTrackingPolicy.RequestInfo> rewrittenRequests = trackingPolicy.TrackedRequests
                .Where(r => r.HasHostHeader)
                .Skip(rewrittenBefore)
                .ToList();

            Assert.AreEqual(
                1,
                rewrittenRequests.Count,
                "Expected exactly one ReadContent request to be rewritten by DataLocalityPolicy.");

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
            // This locks in that DataLakeFileReadOptions.Range is plumbed through to the
            // x-ms-range header on the layout-endpoint-rewritten request.
            Assert.AreEqual(
                downloadOffset,
                rewritten.RangeStartOffset,
                $"Rewritten ReadContent request should carry x-ms-range starting at offset {downloadOffset}.");
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
