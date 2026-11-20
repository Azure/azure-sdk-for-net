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
        [TestCase("Succeeded", true)]
        [TestCase("Succeeded", false)]
        [TestCase("Failed", true)]
        [TestCase("Canceled", false)]
        public async Task TracksLatestStatusMonitorResponse(string status, bool isAsync)
        {
            using var initial = new MockResponse(202);
            initial.AddHeader("Operation-Location", "https://test/jobs/job-1/status");
            initial.AddHeader("Location", "https://test/resources/r");
            initial.SetContent("""{"status":"NotStarted","progress":0}""");
            using var monitor = new MockResponse(200);
            monitor.SetContent($$"""{"status":"{{status}}","progress":100}""");
            using var final = new MockResponse(200);
            final.SetContent("""{"name":"r"}""");
            var pipeline = new HttpPipeline(new MockTransport(initial, monitor, final));
            using var message = pipeline.CreateMessage();
            message.Request.Method = RequestMethod.Post;
            message.Request.Uri.Reset(new Uri("https://test/jobs"));
            var diagnostics = new ClientDiagnostics(ClientOptions.Default);
            var operation = isAsync
                ? await ProtocolOperationHelpers.ProcessMessageAsync(pipeline, message, diagnostics, "test", OperationFinalStateVia.Location, null, WaitUntil.Started)
                : ProtocolOperationHelpers.ProcessMessage(pipeline, message, diagnostics, "test", OperationFinalStateVia.Location, null, WaitUntil.Started);
            var converted = ProtocolOperationHelpers.Convert(operation, r => r.Content.ToString(), diagnostics, "test");
            Assert.AreSame(initial, ProtocolOperationHelpers.GetStatusMonitorResponse(converted));

            if (status == "Succeeded")
            {
                await converted.UpdateStatusAsync();
                Assert.AreSame(final, converted.GetRawResponse());
            }
            else
            {
                Assert.ThrowsAsync<RequestFailedException>(async () => await converted.UpdateStatusAsync());
            }

            Assert.IsTrue(converted.HasCompleted);
            Assert.AreSame(monitor, ProtocolOperationHelpers.GetStatusMonitorResponse(operation));
            Assert.AreSame(monitor, ProtocolOperationHelpers.GetStatusMonitorResponse(converted));
        }

        [Test]
        public void HttpErrorPollKeepsLastStatusMonitorResponse()
        {
            using var initial = new MockResponse(202);
            initial.AddHeader("Operation-Location", "https://test/jobs/job-1/status");
            using var running = new MockResponse(200);
            running.SetContent("""{"status":"Running"}""");
            using var error = new MockResponse(500);
            var pipeline = new HttpPipeline(new MockTransport(running, error));
            using var request = new MockRequest() { Method = RequestMethod.Post };
            request.Uri.Reset(new Uri("https://test/jobs"));
            var operation = new ProtocolOperation<BinaryData>(new ClientDiagnostics(ClientOptions.Default), pipeline, request, initial,
                OperationFinalStateVia.OperationLocation, "test", r => r.Content);
            var token = operation.GetRehydrationToken();

            operation.UpdateStatus();
            Assert.Throws<RequestFailedException>(() => operation.UpdateStatus());

            Assert.AreSame(running, ProtocolOperationHelpers.GetStatusMonitorResponse(operation));
            Assert.AreEqual(token, operation.GetRehydrationToken());
        }

        [Test]
        public void MetadataWrappersFallBackToRawResponseForCustomOperations()
        {
            using var response = new MockResponse(200);
            var source = new Mock<Operation<int>>();
            source.Setup(o => o.GetRawResponse()).Returns(response);
            Func<Response> converted = null;
            Func<Response> wrapped = null;

            var conversion = ProtocolOperationHelpers.ConvertWithMetadata<int, string, Operation<string>>(source.Object, _ => "value",
                new ClientDiagnostics(ClientOptions.Default), "test", (inner, getMonitor) =>
                {
                    converted = getMonitor;
                    return inner;
                });
            var wrapping = ProtocolOperationHelpers.WrapWithMetadata<Operation>(source.Object, (inner, getMonitor) =>
            {
                wrapped = getMonitor;
                return inner;
            });

            Assert.AreSame(response, converted());
            Assert.AreSame(response, wrapped());
            Assert.AreSame(response, ProtocolOperationHelpers.GetStatusMonitorResponse(conversion));
            Assert.AreSame(source.Object, wrapping);
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
