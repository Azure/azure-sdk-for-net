// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Moq;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ProtocolOperationTests
    {
        [TestCase("""{"wire_name":{"progress":25}}""", 25)]
        [TestCase("""{"wire_name":{}}""", null)]
        [TestCase("""{"wire_name":{"progress":null}}""", null)]
        [TestCase("""{"wire_name":42}""", null)]
        [TestCase("not json", null)]
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
            using var response = CreateJsonResponse("""{"details":{"wire_id":"body-id"}}""");
            Assert.AreEqual("body-id", ProtocolOperationHelpers.GetOperationId(token, response, "/jobs/{jobId}/status", "jobId", ["details", "wire_id"]));
            using var missing = CreateJsonResponse("""{"details":{}}""");
            Assert.AreEqual("path/id", ProtocolOperationHelpers.GetOperationId(token, missing, "/jobs/{jobId}/status", "jobId", ["details", "wire_id"]));
            using var nonString = CreateJsonResponse("""{"details":{"wire_id":42}}""");
            Assert.AreEqual("path/id", ProtocolOperationHelpers.GetOperationId(token, nonString, "/jobs/{jobId}/status", "jobId", ["details", "wire_id"]));
            using var noId = CreateJsonResponse("""{"details":{}}""");
            Assert.AreEqual("NOT_SET", ProtocolOperationHelpers.GetOperationId(null, noId, null, null, ["details", "wire_id"]));
            Assert.AreEqual("NOT_SET", ProtocolOperationHelpers.GetOperationId(token, null, "/other/{jobId}", "jobId", null));
        }

        [Test]
        public void MonitorResponseIsParsedOncePerResponse()
        {
            var first = new RehydrationToken(
                "status", null, "OperationLocation", "https://test/jobs/first/status", "https://test/resource",
                RequestMethod.Post, null, OperationFinalStateVia.OperationLocation.ToString());
            var second = new RehydrationToken(
                "status", null, "OperationLocation", "https://test/jobs/second/status", "https://test/resource",
                RequestMethod.Post, null, OperationFinalStateVia.OperationLocation.ToString());
            using var response = CreateJsonResponse("""{"progress":25}""");

            Assert.AreEqual("first", ProtocolOperationHelpers.GetOperationId(first, response, "/jobs/{jobId}/status", "jobId", null));
            // The ID derived for a monitor response is reused until a poll produces a new response.
            Assert.AreEqual("first", ProtocolOperationHelpers.GetOperationId(second, response, "/jobs/{jobId}/status", "jobId", null));
            using var next = CreateJsonResponse("""{"progress":50}""");
            Assert.AreEqual("second", ProtocolOperationHelpers.GetOperationId(second, next, "/jobs/{jobId}/status", "jobId", null));

            response.SetContent("""{"progress":99}""");
            Assert.AreEqual(25, ProtocolOperationHelpers.GetStatusMetadata(response, "progress")?.GetInt32());
        }

        private static MockResponse CreateJsonResponse(string content)
        {
            var response = new MockResponse(200);
            response.SetContent(content);
            return response;
        }

        [Test]
        public void OperationIdSupportsReservedPathExpansion()
        {
            var token = new RehydrationToken(
                "status", null, "OperationLocation", "https://test/jobs/a/b%2Fc/status?opaque=retained", "https://test/resource",
                RequestMethod.Post, null, OperationFinalStateVia.OperationLocation.ToString());
            Assert.AreEqual("a/b/c", ProtocolOperationHelpers.GetOperationId(token, null, "/jobs/{+jobId}/status", "jobId", null));
        }

        [Test]
        public void MetadataConversionAcceptsCustomOperation()
        {
            using var response = new MockResponse(200);
            var source = new Mock<Operation<int>>();
            source.Setup(operation => operation.GetRawResponse()).Returns(response);
            Func<Response> monitor = null;
            var operation = ProtocolOperationHelpers.ConvertWithMetadata<int, int, Operation<int>>(
                source.Object, _ => 1, new ClientDiagnostics(ClientOptions.Default), "test",
                (inner, getMonitor) =>
                {
                    monitor = getMonitor;
                    return inner;
                });
            Assert.AreSame(response, monitor());
            Assert.AreSame(response, operation.GetRawResponse());
        }

        [TestCase(true, WaitUntil.Started)]
        [TestCase(false, WaitUntil.Started)]
        [TestCase(true, WaitUntil.Completed)]
        [TestCase(false, WaitUntil.Completed)]
        public async Task ProcessesMetadataOperation(bool isAsync, WaitUntil waitUntil)
        {
            const string pollingUri = "https://test/jobs/id/status?opaque=retained";
            using var initial = new MockResponse(202);
            initial.AddHeader("Operation-Location", pollingUri);
            initial.SetContent("""{"progress":1}""");
            using var completed = new MockResponse(200);
            completed.SetContent("""{"status":"Succeeded","progress":100}""");
            var transport = new MockTransport(initial, completed);
            var pipeline = new HttpPipeline(transport, default);
            using var message = pipeline.CreateMessage();
            message.Request.Method = RequestMethod.Post;
            message.Request.Uri.Reset(new Uri("https://test/jobs"));
            Func<Response> monitor = null;
            Func<Operation<BinaryData>, Func<Response>, Operation<BinaryData>> createOperation = (inner, getMonitor) =>
            {
                monitor = getMonitor;
                return inner;
            };
            var diagnostics = new ClientDiagnostics(ClientOptions.Default);
            var operation = isAsync
                ? await ProtocolOperationHelpers.ProcessMessageWithMetadataAsync(
                    pipeline, message, diagnostics, "test", OperationFinalStateVia.OperationLocation, null,
                    waitUntil, response => response.Content, createOperation)
                : ProtocolOperationHelpers.ProcessMessageWithMetadata(
                    pipeline, message, diagnostics, "test", OperationFinalStateVia.OperationLocation, null,
                    waitUntil, response => response.Content, createOperation);

            Assert.AreEqual(waitUntil == WaitUntil.Completed, operation.HasCompleted);
            Assert.AreEqual(waitUntil == WaitUntil.Completed ? 100 : 1,
                ProtocolOperationHelpers.GetStatusMetadata(monitor(), "progress")?.GetInt32());
            Assert.AreEqual(waitUntil == WaitUntil.Completed ? 2 : 1, transport.Requests.Count);
            if (waitUntil == WaitUntil.Completed)
            {
                Assert.AreEqual(pollingUri, transport.Requests[1].Uri.ToUri().AbsoluteUri);
            }
        }

        [TestCase(true)]
        [TestCase(false)]
        public async Task RehydratedMetadataPollsAndTracksLatestMonitor(bool isAsync)
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
            var operation = ProtocolOperationHelpers.RehydrateWithMetadata<BinaryData, Operation<BinaryData>>(
                pipeline, token, null, "Test.Rehydrate", response => response.Content,
                (inner, monitor) =>
                {
                    getMonitorResponse = monitor;
                    return inner;
                });
            Assert.AreEqual(1, transport.Requests.Count);
            Assert.AreSame(running, operation.GetRawResponse());
            Assert.AreEqual(25, ProtocolOperationHelpers.GetStatusMetadata(getMonitorResponse(), "progress")?.GetInt32());
            Assert.AreEqual("job-123", ProtocolOperationHelpers.GetOperationId(operation.GetRehydrationToken(), null, "/jobs/{jobId}/status", "jobId", null));

            if (isAsync)
            {
                await operation.UpdateStatusAsync();
            }
            else
            {
                operation.UpdateStatus();
            }
            Assert.AreEqual(pollingUri, transport.Requests[0].Uri.ToUri().AbsoluteUri);
            Assert.AreEqual(pollingUri, transport.Requests[1].Uri.ToUri().AbsoluteUri);
            Assert.IsNull(ProtocolOperationHelpers.GetStatusMetadata(getMonitorResponse(), "progress"));
        }

        [TestCase("Succeeded", true)]
        [TestCase("Failed", false)]
        [TestCase("Canceled", false)]
        public void RehydrationRetainsTerminalState(string status, bool succeeded)
        {
            const string pollingUri = "https://test/jobs/job-123/status";
            using var response = new MockResponse(200);
            response.SetContent($$"""{"status":"{{status}}","progress":100}""");
            var transport = new MockTransport(response);
            var token = new RehydrationToken(
                "job-123", null, "OperationLocation", pollingUri, "https://test/resource",
                RequestMethod.Post, null, OperationFinalStateVia.OperationLocation.ToString());
            Func<Response> monitor = null;
            var operation = ProtocolOperationHelpers.RehydrateWithMetadata<BinaryData, Operation<BinaryData>>(
                new HttpPipeline(transport, default), token, null, "test", raw => raw.Content,
                (inner, getMonitor) =>
                {
                    monitor = getMonitor;
                    return inner;
                });

            Assert.IsTrue(operation.HasCompleted);
            Assert.AreEqual(succeeded, operation.HasValue);
            Assert.AreSame(response, operation.GetRawResponse());
            Assert.AreEqual(100, ProtocolOperationHelpers.GetStatusMetadata(monitor(), "progress")?.GetInt32());
            if (!succeeded)
            {
                Assert.Throws<RequestFailedException>(() => _ = operation.Value);
            }
        }

        [Test]
        public void FailedHttpPollPreservesLastMonitorMetadata()
        {
            const string pollingUri = "https://test/jobs/job-123/status";
            using var running = new MockResponse(200);
            running.SetContent("""{"status":"Running","progress":25}""");
            using var failed = new MockResponse(400);
            failed.SetContent("""{"progress":99}""");
            var token = new RehydrationToken(
                "job-123", null, "OperationLocation", pollingUri, "https://test/resource",
                RequestMethod.Post, null, OperationFinalStateVia.OperationLocation.ToString());
            Func<Response> monitor = null;
            var operation = ProtocolOperationHelpers.RehydrateWithMetadata<BinaryData, Operation<BinaryData>>(
                new HttpPipeline(new MockTransport(running, failed), default), token, null, "test", raw => raw.Content,
                (inner, getMonitor) =>
                {
                    monitor = getMonitor;
                    return inner;
                });

            Assert.Throws<RequestFailedException>(() => operation.UpdateStatus());
            Assert.AreEqual(25, ProtocolOperationHelpers.GetStatusMetadata(monitor(), "progress")?.GetInt32());
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
