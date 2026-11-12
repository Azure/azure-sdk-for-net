// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ProtocolOperationTests
    {
        [TestCase("""{"wire_name":{"progress":25}}""", 25)]
        [TestCase("""{"wire_name":{}}""", null)]
        [TestCase("""{"wire_name":{"progress":null}}""", null)]
        public void ReadsSelectedMetadataPath(string json, int? expected)
        {
            using var response = new MockResponse(200);
            response.SetContent(json);
            var value = ProtocolOperationHelpers.GetStatusMetadata(response, "wire_name", "progress");
            Assert.AreEqual(expected, value?.GetInt32());
            Assert.IsNull(ProtocolOperationHelpers.GetStatusMetadata(null, "progress"));
        }

        [Test]
        public void OperationIdUsesSelectedPathAndBodyFallback()
        {
            const string pollingUri = "https://test/base/jobs/path%2Fid/status?api-version=1&opaque=retained";
            var token = new RehydrationToken(
                "status", null, "OperationLocation", pollingUri, "https://test/resource",
                RequestMethod.Post, null, OperationFinalStateVia.OperationLocation.ToString());
            using var response = new MockResponse(200);
            response.SetContent("""{"details":{"wire_id":"body-id"}}""");
            Assert.AreEqual("body-id", ProtocolOperationHelpers.GetOperationId(token, response, "/jobs/{jobId}/status", "jobId", ["details", "wire_id"]));
            response.SetContent("""{"details":{}}""");
            Assert.AreEqual("path/id", ProtocolOperationHelpers.GetOperationId(token, response, "/jobs/{jobId}/status", "jobId", ["details", "wire_id"]));
            Assert.AreEqual("NOT_SET", ProtocolOperationHelpers.GetOperationId(null, response, null, null, ["details", "wire_id"]));
            Assert.AreEqual("NOT_SET", ProtocolOperationHelpers.GetOperationId(token, null, "/other/{jobId}", "jobId", null));
        }

        [TestCase(true)]
        [TestCase(false)]
        public async Task RehydratedMetadataStartsAbsentAndTracksLatestMonitor(bool isAsync)
        {
            const string pollingUri = "https://test/jobs/job-123/status?api-version=1&opaque=retained";
            var running = new MockResponse(200);
            running.SetContent("""{"status":"Running","progress":25}""");
            var missing = new MockResponse(200);
            missing.SetContent("""{"status":"Running"}""");
            var transport = new MockTransport(running, missing);
            var pipeline = new HttpPipeline(transport, default);
            var token = new RehydrationToken(
                "job-123", null, "OperationLocation", pollingUri, "https://test/resource",
                RequestMethod.Post, null, OperationFinalStateVia.OperationLocation.ToString());
            Func<Response> getMonitorResponse = null;
            var operation = ProtocolOperationHelpers.Rehydrate<BinaryData, Operation<BinaryData>>(
                pipeline, token, null, "Test.Rehydrate", response => response.Content,
                (inner, monitor) =>
                {
                    getMonitorResponse = monitor;
                    return inner;
                });
            Assert.IsEmpty(transport.Requests);
            Assert.IsNull(getMonitorResponse());
            Assert.Throws<InvalidOperationException>(() => operation.GetRawResponse());
            Assert.AreEqual("job-123", ProtocolOperationHelpers.GetOperationId(operation.GetRehydrationToken(), null, "/jobs/{jobId}/status", "jobId", null));

            if (isAsync)
            {
                await operation.UpdateStatusAsync();
            }
            else
            {
                operation.UpdateStatus();
            }
            Assert.AreEqual(25, ProtocolOperationHelpers.GetStatusMetadata(getMonitorResponse(), "progress")?.GetInt32());
            Assert.AreEqual(pollingUri, transport.Requests[0].Uri.ToUri().AbsoluteUri);
            if (isAsync)
            {
                await operation.UpdateStatusAsync();
            }
            else
            {
                operation.UpdateStatus();
            }
            Assert.IsNull(ProtocolOperationHelpers.GetStatusMetadata(getMonitorResponse(), "progress"));
        }

        [Test]
        public void GetRehydrationToken()
        {
            const string OperationId = "oper-ati-oni-d00";
            const string RequestUri = "https://www.example.com/request";
            const string LocationUri = $"https://www.example.com/{OperationId}";

            using var request = new MockRequest() { Method = RequestMethod.Post };
            using var response = new MockResponse(200);
            var transport = new MockTransport();
            var pipeline = new HttpPipeline(transport);

            request.Uri.Reset(new Uri(RequestUri));
            response.AddHeader("Location", LocationUri);

            var operation = new ProtocolOperation<MockJsonModel>(null, pipeline, request, response, OperationFinalStateVia.Location, null, null);
            var token = operation.GetRehydrationToken();

            Assert.True(token.HasValue);
            Assert.AreEqual(OperationId, token.Value.Id);
            Assert.AreEqual(NextLinkOperationImplementation.RehydrationTokenVersion, token.Value.Version);
            Assert.AreEqual("Location", token.Value.HeaderSource);
            Assert.AreEqual(LocationUri, token.Value.NextRequestUri);
            Assert.AreEqual(RequestUri, token.Value.InitialUri);
            Assert.AreEqual(RequestMethod.Post, token.Value.RequestMethod);
            Assert.AreEqual(LocationUri, token.Value.LastKnownLocation);
            Assert.AreEqual("Location", token.Value.FinalStateVia);
        }

        [Test]
        public void GetRehydrationTokenWithCompletedOperation()
        {
            const string RequestUri = "https://www.example.com/request";

            using var request = new MockRequest() { Method = RequestMethod.Post };
            using var response = new MockResponse(200);
            var transport = new MockTransport();
            var pipeline = new HttpPipeline(transport);

            request.Uri.Reset(new Uri(RequestUri));

            var operation = new ProtocolOperation<MockJsonModel>(null, pipeline, request, response, OperationFinalStateVia.Location, null, null);
            var token = operation.GetRehydrationToken();

            Assert.True(token.HasValue);
            Assert.AreEqual("NOT_SET", token.Value.Id);
            Assert.AreEqual(NextLinkOperationImplementation.RehydrationTokenVersion, token.Value.Version);
            Assert.AreEqual("None", token.Value.HeaderSource);
            Assert.AreEqual(RequestUri, token.Value.NextRequestUri);
            Assert.AreEqual(RequestUri, token.Value.InitialUri);
            Assert.AreEqual(RequestMethod.Post, token.Value.RequestMethod);
            Assert.Null(token.Value.LastKnownLocation);
            Assert.AreEqual("Location", token.Value.FinalStateVia);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RehydrationOperationCanPoll(bool isAsync)
        {
            const string RequestUri = "https://www.example.com/request";
            const string LocationUri = "https://www.example.com/oper-ati-oni-d00";

            using var request = new MockRequest() { Method = RequestMethod.Post };
            using var response = new MockResponse(200);
            var transport = new MockTransport(response);
            var pipeline = new HttpPipeline(transport);

            request.Uri.Reset(new Uri(RequestUri));
            response.AddHeader("Location", LocationUri);

            var operation = new ProtocolOperation<MockJsonModel>(null, pipeline, request, response, OperationFinalStateVia.Location, null, null);
            var token = operation.GetRehydrationToken();
            _ = isAsync
                ? await Operation.RehydrateAsync(pipeline, token.Value)
                : Operation.Rehydrate(pipeline, token.Value);
            var rehydrationUpdateRequest = transport.SingleRequest;

            Assert.AreEqual(LocationUri, rehydrationUpdateRequest.Uri.ToString());
            Assert.AreEqual(RequestMethod.Get, rehydrationUpdateRequest.Method);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RehydrationOperationWithCompletedOperationCanPoll(bool isAsync)
        {
            const string RequestUri = "https://www.example.com/request";

            using var request = new MockRequest() { Method = RequestMethod.Post };
            using var response = new MockResponse(200);
            var transport = new MockTransport(response);
            var pipeline = new HttpPipeline(transport);

            request.Uri.Reset(new Uri(RequestUri));

            var operation = new ProtocolOperation<MockJsonModel>(null, pipeline, request, response, OperationFinalStateVia.Location, null, null);
            var token = operation.GetRehydrationToken();
            _ = isAsync
                ? await Operation.RehydrateAsync(pipeline, token.Value)
                : Operation.Rehydrate(pipeline, token.Value);
            var rehydrationUpdateRequest = transport.SingleRequest;

            Assert.AreEqual(RequestUri, rehydrationUpdateRequest.Uri.ToString());
            Assert.AreEqual(RequestMethod.Get, rehydrationUpdateRequest.Method);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RehydrationOperationOfTCanPoll(bool isAsync)
        {
            const string RequestUri = "https://www.example.com/request";
            const string LocationUri = "https://www.example.com/oper-ati-oni-d00";

            using var request = new MockRequest() { Method = RequestMethod.Post };
            using var response = new MockResponse(200);
            var transport = new MockTransport(response);
            var pipeline = new HttpPipeline(transport);
            using var responseContentStream = new MemoryStream(Encoding.UTF8.GetBytes("""
                {
                    "IntValue": 1,
                    "StringValue": "one"
                }
                """));

            request.Uri.Reset(new Uri(RequestUri));
            response.AddHeader("Location", LocationUri);
            response.ContentStream = responseContentStream;

            var operation = new ProtocolOperation<MockJsonModel>(null, pipeline, request, response, OperationFinalStateVia.Location, null, null);
            var token = operation.GetRehydrationToken();
            var rehydrationOperation = isAsync
                ? await Operation.RehydrateAsync<MockJsonModel>(pipeline, token.Value)
                : Operation.Rehydrate<MockJsonModel>(pipeline, token.Value);
            var rehydrationUpdateRequest = transport.SingleRequest;

            Assert.AreEqual(LocationUri, rehydrationUpdateRequest.Uri.ToString());
            Assert.AreEqual(RequestMethod.Get, rehydrationUpdateRequest.Method);

            Assert.True(rehydrationOperation.HasValue);
            Assert.AreEqual(rehydrationOperation.Value.IntValue, 1);
            Assert.AreEqual(rehydrationOperation.Value.StringValue, "one");
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RehydrationOperationOfTWithCompletedOperationCanPoll(bool isAsync)
        {
            const string RequestUri = "https://www.example.com/request";

            using var request = new MockRequest() { Method = RequestMethod.Post };
            using var response = new MockResponse(200);
            var transport = new MockTransport(response);
            var pipeline = new HttpPipeline(transport);
            using var responseContentStream = new MemoryStream(Encoding.UTF8.GetBytes("""
                {
                    "IntValue": 1,
                    "StringValue": "one"
                }
                """));

            request.Uri.Reset(new Uri(RequestUri));
            response.ContentStream = responseContentStream;

            var operation = new ProtocolOperation<MockJsonModel>(null, pipeline, request, response, OperationFinalStateVia.Location, null, null);
            var token = operation.GetRehydrationToken();
            var rehydrationOperation = isAsync
                ? await Operation.RehydrateAsync<MockJsonModel>(pipeline, token.Value)
                : Operation.Rehydrate<MockJsonModel>(pipeline, token.Value);
            var rehydrationUpdateRequest = transport.SingleRequest;

            Assert.AreEqual(RequestUri, rehydrationUpdateRequest.Uri.ToString());
            Assert.AreEqual(RequestMethod.Get, rehydrationUpdateRequest.Method);

            Assert.True(rehydrationOperation.HasValue);
            Assert.AreEqual(rehydrationOperation.Value.IntValue, 1);
            Assert.AreEqual(rehydrationOperation.Value.StringValue, "one");
        }
    }
}
