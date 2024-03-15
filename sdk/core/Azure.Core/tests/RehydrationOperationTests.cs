// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class RehydrationOperationTests
    {
        [Test]
        public void ThrowOnNullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => new RehydrationOperation(null, new RehydrationToken()));
        }

        [Test]
        public void ConstructOperationForRehydration()
        {
            HttpPipeline pipeline = CreateMockHttpPipeline(out _);
            var operationId = Guid.NewGuid().ToString();
            var rehydrationToken = new RehydrationToken(null, null, "None", $"https://management.azure.com/subscriptions/subscription-id/providers/Microsoft.Compute/locations/region/operations/{operationId}?api-version=2019-12-01", "https://test", RequestMethod.Delete, null, OperationFinalStateVia.AzureAsyncOperation.ToString());
            var operation = new RehydrationOperation(pipeline, rehydrationToken);
            Assert.NotNull(operation);
            Assert.AreEqual(operationId, operation.Id);
            Assert.Throws<InvalidOperationException>(() => operation.GetRawResponse());
            Assert.False(operation.HasCompleted);

            operation.UpdateStatus();
            Assert.AreEqual(200, operation.GetRawResponse().Status);
        }

        [Test]
        public void ConstructOperationOfTForRehydration()
        {
            var pipeline = CreateMockHttpPipeline(out var mockJsonModel);
            var operationId = Guid.NewGuid().ToString();
            var rehydrationToken = new RehydrationToken(null, null, "None", $"https://management.azure.com/subscriptions/subscription-id/providers/Microsoft.Compute/locations/region/operations/{operationId}?api-version=2019-12-01", "https://test", RequestMethod.Delete, null, OperationFinalStateVia.AzureAsyncOperation.ToString());
            var operation = new RehydrationOperation<MockJsonModel>(pipeline, rehydrationToken);
            Assert.NotNull(operation);
            Assert.AreEqual(operationId, operation.Id);
            Assert.Throws<InvalidOperationException>(() => operation.GetRawResponse());
            Assert.False(operation.HasCompleted);

            operation.UpdateStatus();
            Assert.AreEqual(200, operation.GetRawResponse().Status);
            Assert.AreEqual(ModelReaderWriter.Write(mockJsonModel).ToString(), ModelReaderWriter.Write(operation.Value).ToString());
        }

        [Test]
        public void GetRehydrationToken()
        {
            var operationId = Guid.NewGuid().ToString();
            var rehydrationToken = new RehydrationToken(operationId, null, "None", $"https://management.azure.com/subscriptions/subscription-id/providers/Microsoft.Compute/locations/region/operations/{operationId}?api-version=2019-12-01", "https://test/", RequestMethod.Delete, null, OperationFinalStateVia.AzureAsyncOperation.ToString());
            var operation = new RehydrationOperation(HttpPipelineBuilder.Build(new MockClientOptions()), rehydrationToken);
            var token = operation.GetRehydrationToken();
            Assert.AreEqual(ModelReaderWriter.Write(rehydrationToken).ToString(), ModelReaderWriter.Write(token).ToString());
        }

        [Test]
        public void GetRehydrationTokenOfT()
        {
            var operationId = Guid.NewGuid().ToString();
            var rehydrationToken = new RehydrationToken(operationId, null, "None", $"https://management.azure.com/subscriptions/subscription-id/providers/Microsoft.Compute/locations/region/operations/{operationId}?api-version=2019-12-01", "https://test/", RequestMethod.Delete, null, OperationFinalStateVia.AzureAsyncOperation.ToString());
            var operation = new RehydrationOperation<MockJsonModel>(HttpPipelineBuilder.Build(new MockClientOptions()), rehydrationToken);
            var token = operation.GetRehydrationToken();
            Assert.AreEqual(ModelReaderWriter.Write(rehydrationToken).ToString(), ModelReaderWriter.Write(token).ToString());
        }

        private static HttpPipeline CreateMockHttpPipeline(out MockJsonModel mockJsonModel)
        {
            var mockResponse = new MockResponse(200);
            mockJsonModel = new MockJsonModel(1, "a");
            mockResponse.SetContent(ModelReaderWriter.Write(mockJsonModel).ToString());
            var transport = new MockTransport(mockResponse);
            var pipeline = new HttpPipeline(transport, default);
            return pipeline;
        }

        private class MockClientOptions : ClientOptions
        {
        }
    }
}
