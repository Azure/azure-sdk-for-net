// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class NextLinkOperationImplementationTests
    {
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
            Assert.That(token.RequestMethod, Is.EqualTo(requetMethod));
            Assert.That(token.InitialUri, Is.EqualTo(startRequestUri));
            Assert.That(token.NextRequestUri, Is.EqualTo(nextRequestUri));
            Assert.That(token.HeaderSource, Is.EqualTo(headerSource));
            Assert.That(token.LastKnownLocation, Is.EqualTo(lastKnownLocation));
            Assert.That(token.FinalStateVia, Is.EqualTo(finalStateVia));
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
            Assert.That(operation, Is.Not.Null);
            Assert.That(operation.OperationId, Is.EqualTo(operationId));
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
            Assert.That(operation, Is.Not.Null);
            Assert.That(operation.OperationId, Is.EqualTo(NextLinkOperationImplementation.NotSet));
            Assert.That(operation.RequestMethod, Is.EqualTo(requestMethod));
        }

        [Test]
        public void ConstructNextLinkOperation()
        {
            var operationId = Guid.NewGuid().ToString();
            var requestMethod = RequestMethod.Delete;
            var rehydrationToken = new RehydrationToken(null, null, "None", $"https://test.com/operations/{operationId}?api-version=2019-12-01", "https://test", requestMethod, null, OperationFinalStateVia.AzureAsyncOperation.ToString());
            var operation = (NextLinkOperationImplementation)NextLinkOperationImplementation.Create(HttpPipelineBuilder.Build(new MockClientOptions()), rehydrationToken);
            Assert.That(operation, Is.Not.Null);
            Assert.That(operation.OperationId, Is.EqualTo(NextLinkOperationImplementation.NotSet));
            Assert.That(operation.RequestMethod, Is.EqualTo(requestMethod));
        }

        [Test]
        public async Task FinalGetForDeleteLRO()
        {
            var operationId = Guid.NewGuid().ToString();
            var requestMethod = RequestMethod.Delete;
            var rehydrationToken = new RehydrationToken(null, null, "None", $"https://test.com/operations/{operationId}?api-version=2019-12-01", "https://test", requestMethod, null, OperationFinalStateVia.AzureAsyncOperation.ToString());
            var operation = (NextLinkOperationImplementation)NextLinkOperationImplementation.Create(CreateMockHttpPipeline(HttpStatusCode.NotFound), rehydrationToken);
            Assert.That(operation, Is.Not.Null);

            var result = await operation.UpdateStateAsync(async: true, default);
            Assert.That(result.RawResponse.Status, Is.EqualTo(204));
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
