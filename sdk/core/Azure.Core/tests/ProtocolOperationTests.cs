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
        private const string JobPath = "/jobs/{jobId}/status";

        [TestCase("""{"details":{"wire_id":"body-id"}}""", "body-id")]
        [TestCase("""{"details":{}}""", "path/id")]
        [TestCase("""{"details":{"wire_id":42}}""", "path/id")]
        [TestCase("not json", "path/id")]
        public void OperationIdPrefersMonitorBodyThenPollingUri(string body, string expected)
        {
            var (operation, monitor, _) = Start(body, "Operation-Location", "https://test/base/jobs/path%2Fid/status?api-version=1");

            Assert.AreEqual(expected, ProtocolOperationHelpers.GetOperationId(
                operation, monitor(), ["details", "wire_id"], "Operation-Location", JobPath, "jobId", null));
            Assert.AreEqual(body.Contains("body-id") ? "body-id" : "NOT_SET", ProtocolOperationHelpers.GetOperationId(
                operation, monitor(), ["details", "wire_id"], null, null, null, null));
        }

        [TestCase("Operation-Location", "Operation-Location", "job")]
        [TestCase("Operation-Location", "operation-location", "job")]
        [TestCase("Operation-Location", "Azure-AsyncOperation", "NOT_SET")]
        [TestCase("Operation-Location", null, "NOT_SET")]
        [TestCase("Operation-Location", "Custom-Link", "NOT_SET")]
        [TestCase("Azure-AsyncOperation", "Azure-AsyncOperation", "job")]
        [TestCase("Location", "Location", "job")]
        [TestCase(null, null, "job")]
        [TestCase(null, "Operation-Location", "NOT_SET")]
        public void OperationIdOnlyUsesSelectedPollingLink(string responseHeader, string selectedHeader, string expected)
        {
            var (operation, monitor, _) = Start("{}", responseHeader, "https://test/jobs/job/status", requestUri: "https://test/jobs/job/status");

            Assert.AreEqual(expected, ProtocolOperationHelpers.GetOperationId(
                operation, monitor(), null, selectedHeader, JobPath, "jobId", null));
        }

        [TestCase("/primitive.a", null, ".a")]
        [TestCase("/primitive.a", "Simple", ".a")]
        [TestCase("/primitive.a", "Label", "a")]
        [TestCase("/primitive;id=a", "Matrix", "a")]
        [TestCase("/primitive;id=a%3Bb", "Matrix", "a;b")]
        [TestCase("/primitive;id", "Matrix", "")]
        [TestCase("/primitive;other=a", "Matrix", "NOT_SET")]
        [TestCase("/primitive;id=a;other=b", "Matrix", "NOT_SET")]
        [TestCase("/primitive;id=a", "Simple", ";id=a")]
        [TestCase("/primitive/a%20b", "Path", "a b")]
        [TestCase("/primitive#a", "Fragment", "a")]
        [TestCase("/primitivea", "Label", "NOT_SET")]
        public void OperationIdUsesPathParameterStyle(string path, string style, string expected)
        {
            var (operation, monitor, _) = Start("{}", "Operation-Location", "https://test" + path);

            Assert.AreEqual(expected, ProtocolOperationHelpers.GetOperationId(
                operation, monitor(), null, "Operation-Location", "/primitive{id}", "id", style));
        }

        [TestCase("/jobs/west/abc/status", "abc")]
        [TestCase("/jobs.west/abc/status", "abc")]
        [TestCase("/jobs;region=west/abc/status", "abc")]
        [TestCase("/jobswest/abc/status", "abc")]
        [TestCase("/jobs/abc/status", "abc")]
        public void OperationIdAllowsAnyExpansionOfOtherPlaceholders(string path, string expected)
        {
            var (operation, monitor, _) = Start("{}", "Operation-Location", "https://test" + path);

            Assert.AreEqual(expected, ProtocolOperationHelpers.GetOperationId(
                operation, monitor(), null, "Operation-Location", "/jobs{region}/{id}/status", "id", "Simple"));
        }

        [Test]
        public void OperationIdSupportsReservedPathExpansion()
        {
            var (operation, monitor, _) = Start("{}", "Operation-Location", "https://test/jobs/a/b%2Fc/status?opaque=retained");

            Assert.AreEqual("a/b/c", ProtocolOperationHelpers.GetOperationId(
                operation, monitor(), null, "Operation-Location", "/jobs/{+jobId}/status", "jobId", null));
        }

        [TestCase(true, WaitUntil.Started)]
        [TestCase(false, WaitUntil.Started)]
        [TestCase(true, WaitUntil.Completed)]
        [TestCase(false, WaitUntil.Completed)]
        public async Task ProcessMessageWithMonitorTracksLatestMonitorAndPollsCompleteUrl(bool isAsync, WaitUntil waitUntil)
        {
            const string pollingUri = "https://test/jobs/job/status?api-version=1&opaque=retained";
            using var initial = new MockResponse(202);
            initial.AddHeader("Operation-Location", pollingUri);
            initial.SetContent("""{"id":"initial"}""");
            using var completed = new MockResponse(200);
            completed.SetContent("""{"status":"Succeeded","id":"latest"}""");
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
                ? await ProtocolOperationHelpers.ProcessMessageWithMonitorAsync(
                    pipeline, message, diagnostics, "test", OperationFinalStateVia.OperationLocation, null,
                    waitUntil, response => response.Content, createOperation)
                : ProtocolOperationHelpers.ProcessMessageWithMonitor(
                    pipeline, message, diagnostics, "test", OperationFinalStateVia.OperationLocation, null,
                    waitUntil, response => response.Content, createOperation);

            Assert.AreEqual(waitUntil == WaitUntil.Completed, operation.HasCompleted);
            Assert.AreEqual(waitUntil == WaitUntil.Completed ? "latest" : "initial",
                ProtocolOperationHelpers.GetOperationId(operation, monitor(), ["id"], null, null, null, null));
            Assert.AreEqual("job", ProtocolOperationHelpers.GetOperationId(
                operation, null, null, "Operation-Location", JobPath, "jobId", null));
            Assert.AreEqual(waitUntil == WaitUntil.Completed ? 2 : 1, transport.Requests.Count);
            if (waitUntil == WaitUntil.Completed)
            {
                Assert.AreEqual(pollingUri, transport.Requests[1].Uri.ToUri().AbsoluteUri);
            }

            var converted = ProtocolOperationHelpers.Convert(operation, response => response.Content, diagnostics, "test");
            Assert.AreEqual(pollingUri, ProtocolOperationHelpers.GetPollingUri(converted, "Operation-Location").AbsoluteUri);
            Assert.AreSame(monitor(), ((IStatusMonitorOperation)converted).GetStatusMonitorResponse());
        }

        [Test]
        public void ConvertedPlainOperationFallsBackToRawResponse()
        {
            using var response = new MockResponse(200);
            var source = new Mock<Operation<int>>();
            source.Setup(operation => operation.GetRawResponse()).Returns(response);
            var converted = ProtocolOperationHelpers.Convert(source.Object, _ => 1, new ClientDiagnostics(ClientOptions.Default), "test");

            Assert.AreSame(response, ((IStatusMonitorOperation)converted).GetStatusMonitorResponse());
            Assert.IsNull(ProtocolOperationHelpers.GetPollingUri(converted, null));
            Assert.AreEqual("NOT_SET", ProtocolOperationHelpers.GetOperationId(converted, response, null, null, JobPath, "jobId", null));
        }

        private static (Operation<BinaryData> Operation, Func<Response> Monitor, MockTransport Transport) Start(
            string body, string header, string pollingUri, string requestUri = "https://test/jobs")
        {
            var initial = new MockResponse(202);
            if (header is not null)
            {
                initial.AddHeader(header, pollingUri);
            }
            initial.SetContent(body);
            var transport = new MockTransport(initial);
            var pipeline = new HttpPipeline(transport, default);
            var message = pipeline.CreateMessage();
            message.Request.Method = RequestMethod.Post;
            message.Request.Uri.Reset(new Uri(requestUri));
            Func<Response> monitor = null;
            var operation = ProtocolOperationHelpers.ProcessMessageWithMonitor<BinaryData, Operation<BinaryData>>(
                pipeline, message, new ClientDiagnostics(ClientOptions.Default), "test", OperationFinalStateVia.OperationLocation,
                null, WaitUntil.Started, response => response.Content, (inner, getMonitor) =>
                {
                    monitor = getMonitor;
                    return inner;
                });
            return (operation, monitor, transport);
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
