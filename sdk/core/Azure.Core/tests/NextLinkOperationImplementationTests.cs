// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class NextLinkOperationImplementationTests
    {
        [TestCase(true, "Succeeded")]
        [TestCase(false, "Succeeded")]
        [TestCase(true, "Failed")]
        [TestCase(false, "Canceled")]
        public async Task ObservesMonitorResponseBeforeFinalResult(bool async, string status)
        {
            var monitorResponse = new MockResponse(200);
            monitorResponse.SetContent($$"""{"status":"{{status}}","progress":100}""");
            var finalResponse = new MockResponse(200);
            finalResponse.SetContent("""{"value":"result"}""");
            var pipeline = new HttpPipeline(new MockTransport(monitorResponse, finalResponse), default);
            var initialResponse = new MockResponse(202);
            initialResponse.AddHeader("Operation-Location", "https://test/operations/job-123?api-version=1");
            var observed = new List<Response>();
            var operation = NextLinkOperationImplementation.Create(
                pipeline, RequestMethod.Post, new Uri("https://test/resource"), initialResponse,
                OperationFinalStateVia.OriginalUri, statusMonitorResponseReceived: observed.Add);

            var state = await operation.UpdateStateAsync(async, default);

            Assert.AreEqual(1, observed.Count);
            Assert.AreSame(monitorResponse, observed[0]);
            Assert.AreSame(status == "Succeeded" ? finalResponse : monitorResponse, state.RawResponse);
            Assert.AreEqual(status == "Succeeded", state.HasSucceeded);
        }

        [TestCase(true)]
        [TestCase(false)]
        public async Task ObservesMonitorAfterRehydration(bool async)
        {
            const string pollingUri = "https://test/operations/job-123?api-version=1&opaque=retained";
            var response = new MockResponse(200);
            response.SetContent("""{"status":"Running","progress":25}""");
            var transport = new MockTransport(response);
            var pipeline = new HttpPipeline(transport, default);
            var token = new RehydrationToken(
                "job-123", null, "OperationLocation", pollingUri, "https://test/resource",
                RequestMethod.Post, null, OperationFinalStateVia.OperationLocation.ToString());
            Response observed = null;
            var operation = NextLinkOperationImplementation.Create(
                pipeline, token, statusMonitorResponseReceived: value => observed = value);

            Assert.IsNull(observed);
            var state = await operation.UpdateStateAsync(async, default);

            Assert.AreSame(response, observed);
            Assert.IsFalse(state.HasCompleted);
            Assert.AreEqual(pollingUri, transport.Requests[0].Uri.ToUri().AbsoluteUri);
        }

        [Test]
        public void ConstructRehydrationToken()
        {
            var requetMethod = RequestMethod.Get;
            var startRequestUri = new Uri("https://test");
            var nextRequestUri = "nextRequestUri";
            var headerSource = "None";
            string lastKnownLocation = null;
            var finalStateVia = OperationFinalStateVia.OperationLocation.ToString();
            var token = NextLinkOperationImplementation.GetRehydrationToken(requetMethod, startRequestUri, nextRequestUri, headerSource, lastKnownLocation, finalStateVia);
            Assert.AreEqual(requetMethod, token.RequestMethod);
            Assert.AreEqual(startRequestUri, token.InitialUri);
            Assert.AreEqual(nextRequestUri, token.NextRequestUri);
            Assert.AreEqual(headerSource, token.HeaderSource);
            Assert.AreEqual(lastKnownLocation, token.LastKnownLocation);
            Assert.AreEqual(finalStateVia, token.FinalStateVia);
        }

        [Test]
        public void CreateWithValidNextRequestUri()
        {
            var operationId = Guid.NewGuid().ToString();
            var pipeline = CreateMockHttpPipelineWithHeaders(HttpStatusCode.Accepted, operationId, out var mockResponse);
            var requetMethod = RequestMethod.Get;
            var startRequestUri = new Uri("https://test");
            var finalStateVia = OperationFinalStateVia.OperationLocation;
            var operation = (NextLinkOperationImplementation)NextLinkOperationImplementation.Create(pipeline, requetMethod, startRequestUri, mockResponse, finalStateVia);
            Assert.NotNull(operation);
            Assert.AreEqual(operationId, operation.OperationId);
        }

        [Test]
        public void CreateWithIncompleteNextRequestUri()
        {
            var pipeline = CreateMockHttpPipeline(HttpStatusCode.Accepted);
            var resourceId = Guid.NewGuid().ToString();
            var operationId = Guid.NewGuid().ToString();
            var requestMethod = RequestMethod.Put;
            var lastKnowLocation = $"/operations/{operationId}?api-version=xxx";
            var rehydrationToken = new RehydrationToken(null, null, "None", $"/resource/{resourceId}?api-version=xxx", "https://test", requestMethod, lastKnowLocation, OperationFinalStateVia.AzureAsyncOperation.ToString());
            var operation = (NextLinkOperationImplementation)NextLinkOperationImplementation.Create(pipeline, rehydrationToken);
            Assert.NotNull(operation);
            Assert.AreEqual(NextLinkOperationImplementation.NotSet, operation.OperationId);
            Assert.AreEqual(requestMethod, operation.RequestMethod);
        }

        [Test]
        public void ConstructNextLinkOperation()
        {
            var operationId = Guid.NewGuid().ToString();
            var requestMethod = RequestMethod.Delete;
            var rehydrationToken = new RehydrationToken(null, null, "None", $"https://test.com/operations/{operationId}?api-version=2019-12-01", "https://test", requestMethod, null, OperationFinalStateVia.AzureAsyncOperation.ToString());
            var operation = (NextLinkOperationImplementation)NextLinkOperationImplementation.Create(HttpPipelineBuilder.Build(new MockClientOptions()), rehydrationToken);
            Assert.NotNull(operation);
            Assert.AreEqual(NextLinkOperationImplementation.NotSet, operation.OperationId);
            Assert.AreEqual(requestMethod, operation.RequestMethod);
        }

        [Test]
        public async Task FinalGetForDeleteLRO()
        {
            var operationId = Guid.NewGuid().ToString();
            var requestMethod = RequestMethod.Delete;
            var rehydrationToken = new RehydrationToken(null, null, "None", $"https://test.com/operations/{operationId}?api-version=2019-12-01", "https://test", requestMethod, null, OperationFinalStateVia.AzureAsyncOperation.ToString());
            var operation = (NextLinkOperationImplementation)NextLinkOperationImplementation.Create(CreateMockHttpPipeline(HttpStatusCode.NotFound), rehydrationToken);
            Assert.NotNull(operation);

            var result = await operation.UpdateStateAsync(async: true, default);
            Assert.AreEqual(204, result.RawResponse.Status);
        }

        [Test]
        public void ThrowWithDefaultRehydrationToken()
        {
            Assert.Throws<ArgumentException>(() => NextLinkOperationImplementation.Create(HttpPipelineBuilder.Build(new MockClientOptions()), default));
        }

        [Test]
        public void ThrowOnInvalidUri()
        {
            Assert.Throws<ArgumentException>(() => NextLinkOperationImplementation.Create(HttpPipelineBuilder.Build(new MockClientOptions()), default));
        }

        [Test]
        public void ThrowOnNextLinkOperationImplementationCreateWithNullHttpPipeline()
        {
            Assert.Throws<ArgumentNullException>(() => NextLinkOperationImplementation.Create(null, new RehydrationToken(null, null, "None", "nextRequestUri", "https://test", RequestMethod.Delete, null, OperationFinalStateVia.AzureAsyncOperation.ToString())));
        }

        private static HttpPipeline CreateMockHttpPipeline(HttpStatusCode statusCode)
        {
            var mockResponse = new MockResponse((int)statusCode);
            var transport = new MockTransport(mockResponse, mockResponse);
            var pipeline = new HttpPipeline(transport, default);
            return pipeline;
        }

        private static HttpPipeline CreateMockHttpPipelineWithHeaders(HttpStatusCode statusCode, string operationId, out MockResponse mockResponse)
        {
            mockResponse = new MockResponse((int)statusCode);
            mockResponse.AddHeader("location", $"https://test.com/operations/{operationId}");
            var transport = new MockTransport(mockResponse, mockResponse);
            var pipeline = new HttpPipeline(transport, default);
            return pipeline;
        }

        private class MockClientOptions : ClientOptions
        {
        }
    }
}
