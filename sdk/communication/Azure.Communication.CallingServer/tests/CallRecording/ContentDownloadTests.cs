// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;
using System.Linq;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;

namespace Azure.Communication.CallingServer
{
    public class ContentDownloadTests : CallAutomationTestBase
    {
        private const string DummyRecordingMetadata = "{" +
                                                "\"chunkDocumentId\": \"dummyDocId\"," +
                                                "\"resourceId\": \"dummyResourceId\"," +
                                                "\"callId\": \"dummyCallId\"," +
                                                "\"chunkIndex\": 0," +
                                                "\"chunkStartTime\": \"dummyStartTime\"," +
                                                "\"chunkDuration\": 1.5," +
                                                "\"version\": \"1.0\"," +
                                                "\"pauseResumeIntervals\": [{" +
                                                "\"startTime\": \"pauseStartTime\"," +
                                                "\"duration\": 0.5" +
                                                "}]," +
                                                "\"recordingInfo\": {}," +
                                                "\"participants\": [" +
                                                "{\"participantId\": \"participantId00\"}," +
                                                "{\"participantId\": \"participantId01\"}" +
                                                "]" +
                                                "}";
        private readonly byte[] _dummyRecordingStream = new byte[]
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 0
        };

        private readonly Uri _dummyMetadataLocation = new("https://localhost/documents/metadata/document_id/acsmetadata");
        private readonly Uri _dummyRecordingLocation = new("https://localhost/documents/document_id/");

        private readonly HttpHeader[] _rangeResponseHeaders = new HttpHeader[]
            {
                new HttpHeader("Content-Range", "bytes 0-4/5")
            };

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void DownloadMetadata_Test()
        {
            CallAutomationClient _callAutomationClient = CreateMockCallAutomationClient(200, DummyRecordingMetadata);

            Stream metadata = _callAutomationClient.GetCallRecording().DownloadStreaming(_dummyMetadataLocation);

            VerifyExpectedMetadata(metadata);
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task DownloadMetadataAsync_Test()
        {
            CallAutomationClient _callAutomationClient = CreateMockCallAutomationClient(200, DummyRecordingMetadata);

            Stream metadata = await _callAutomationClient.GetCallRecording().DownloadStreamingAsync(_dummyMetadataLocation);

            VerifyExpectedMetadata(metadata);
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void DownloadRecording_Test()
        {
            CallAutomationClient _callAutomationClient = CreateMockCallAutomationClient(200, _dummyRecordingStream);

            Response<Stream> recording = _callAutomationClient.GetCallRecording().DownloadStreaming(_dummyRecordingLocation);

            VerifyExpectedRecording(recording, 10);
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void DownloadRecordingByRanges_Test()
        {
            CallAutomationClient _callAutomationClient = CreateMockCallAutomationClient(206, _dummyRecordingStream.Take(5).ToArray(), _rangeResponseHeaders);

            Response<Stream> recording = _callAutomationClient.GetCallRecording().DownloadStreaming(_dummyRecordingLocation, new HttpRange(0, 4));

            VerifyExpectedRecording(recording, 5);
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task DownloadRecordingAsync_Test()
        {
            CallAutomationClient _callAutomationClient = CreateMockCallAutomationClient(200, _dummyRecordingStream);

            Response<Stream> recording = await _callAutomationClient.GetCallRecording().DownloadStreamingAsync(_dummyRecordingLocation);

            VerifyExpectedRecording(recording, 10);
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task DownloadRecordingByRangesAsync_Test()
        {
            CallAutomationClient _callAutomationClient = CreateMockCallAutomationClient(206, _dummyRecordingStream.Take(5).ToArray(), _rangeResponseHeaders);

            Response<Stream> recording = await _callAutomationClient.GetCallRecording().DownloadStreamingAsync(_dummyRecordingLocation, new HttpRange(0, 4));

            VerifyExpectedRecording(recording, 5);
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void DownloadRecordingToStream_Test()
        {
            HttpHeader[] rangeHeaderResponse = new HttpHeader[]
            {
                new HttpHeader("Content-Range", "bytes 0-9/10"),
                new HttpHeader("Content-Length", "10"),
            };

            ContentTransferOptions options = new();
            options.InitialTransferSize = 10;

            CallAutomationClient _callAutomationClient = CreateMockCallAutomationClient(206, _dummyRecordingStream, rangeHeaderResponse);

            Stream destination = new MemoryStream();
            _callAutomationClient.GetCallRecording().DownloadTo(_dummyRecordingLocation, destination, options);

            Assert.AreEqual(10, destination.Length);
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void DownloadRecordingToStream_ContentTransferOptions_Test()
        {
            ContentTransferOptions options = new()
            {
                InitialTransferSize = 10,
                MaximumConcurrency = 1,
                MaximumTransferSize = 5
            };

            ContentTransferOptions options_copy = new()
            {
                InitialTransferSize = 10,
                MaximumConcurrency = 1,
                MaximumTransferSize = 5
            };

            ContentTransferOptions options_updated = new()
            {
                InitialTransferSize = 11,
                MaximumConcurrency = 1,
                MaximumTransferSize = 5
            };

            Assert.AreNotEqual(options.GetHashCode(), options_updated.GetHashCode());
            Assert.AreEqual(options.GetHashCode(), options_copy.GetHashCode());
            Assert.True(options.Equals(options_copy));
            Assert.True(options.Equals((object)options_copy));
            Assert.False(options.Equals(options_updated));
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void DownloadNotExistentContent_Failure_Test()
        {
            CallAutomationClient _callAutomationClient = CreateMockCallAutomationClient(404);
            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => _callAutomationClient.GetCallRecording().DownloadStreaming(_dummyMetadataLocation));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void DownloadNotExistentContentAsync_Failure_Test()
        {
            CallAutomationClient _callAutomationClient = CreateMockCallAutomationClient(404);
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await _callAutomationClient.GetCallRecording().DownloadStreamingAsync(_dummyMetadataLocation));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void AccessDenied_Failure_Test()
        {
            CallAutomationClient _callAutomationClient = CreateMockCallAutomationClient(401);
            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => _callAutomationClient.GetCallRecording().DownloadStreaming(_dummyMetadataLocation));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 401);
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void AccessDeniedAsync_Failure_Test()
        {
            CallAutomationClient _callAutomationClient = CreateMockCallAutomationClient(401);
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await _callAutomationClient.GetCallRecording().DownloadStreamingAsync(_dummyMetadataLocation));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 401);
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void ParallelDownloadWithInvalidRangeFirst()
        {
            MockResponse invalidResponse = new(416); // Invalid range
            invalidResponse.AddHeader(new HttpHeader("Content-Range", "bytes */10"));
            MockResponse validResponse1 = new(206);
            validResponse1.AddHeader(new HttpHeader("Content-Length", "5"));
            validResponse1.AddHeader(new HttpHeader("Content-Range", "bytes 0-4/10"));
            validResponse1.SetContent(new byte[] { 0, 1, 2, 3, 4 });
            MockResponse validResponse2 = new(206);
            validResponse2.AddHeader(new HttpHeader("Content-Length", "5"));
            validResponse2.AddHeader(new HttpHeader("Content-Range", "bytes 5-9/10"));
            validResponse2.SetContent(new byte[] { 5, 6, 7, 8, 9 });

            ContentTransferOptions options = new()
            {
                InitialTransferSize = 5,
                MaximumTransferSize = 5
            };

            CallAutomationClient _callAutomationClient = CreateMockCallAutomationClient(new MockResponse[] { invalidResponse, validResponse1, validResponse2 });
            Stream destination = new MemoryStream();
            _callAutomationClient.GetCallRecording().DownloadTo(_dummyRecordingLocation, destination, options);

            Assert.AreEqual(10, destination.Length);
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task ParallelDownloadWithInvalidRangeFirstAsync()
        {
            MockResponse invalidResponse = new(416); // Invalid range
            invalidResponse.AddHeader(new HttpHeader("Content-Range", "bytes */10"));
            MockResponse validResponse1 = new(206);
            validResponse1.AddHeader(new HttpHeader("Content-Length", "5"));
            validResponse1.AddHeader(new HttpHeader("Content-Range", "bytes 0-4/10"));
            validResponse1.SetContent(new byte[] { 0, 1, 2, 3, 4 });
            MockResponse validResponse2 = new(206);
            validResponse2.AddHeader(new HttpHeader("Content-Length", "5"));
            validResponse2.AddHeader(new HttpHeader("Content-Range", "bytes 5-9/10"));
            validResponse2.SetContent(new byte[] { 5, 6, 7, 8, 9 });

            ContentTransferOptions options = new()
            {
                InitialTransferSize = 5,
                MaximumTransferSize = 5
            };

            CallAutomationClient _callAutomationClient = CreateMockCallAutomationClient(new MockResponse[] { invalidResponse, validResponse1, validResponse2 });
            Stream destination = new MemoryStream();
            await _callAutomationClient.GetCallRecording().DownloadToAsync(_dummyRecordingLocation, destination, options);

            Assert.AreEqual(10, destination.Length);
        }

        private static void VerifyExpectedMetadata(Stream metadata)
        {
            Assert.IsNotNull(metadata);
            JsonElement expected = JsonDocument.Parse(DummyRecordingMetadata).RootElement;
            JsonElement actual = JsonDocument.Parse(metadata).RootElement;
            Assert.AreEqual(expected.GetProperty("chunkDocumentId").GetString(), actual.GetProperty("chunkDocumentId").GetString());
        }

        private static void VerifyExpectedRecording(Response<Stream> recording, int recordingLength)
        {
            Assert.IsNotNull(recording.Value);
            Assert.IsTrue(recording.Value.GetType().Name.Contains(typeof(RetriableStream).Name));
            Assert.AreEqual(recordingLength, recording.Value.Length);
        }
    }
}
