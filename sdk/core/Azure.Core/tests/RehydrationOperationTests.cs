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
            var mockResponse = new MockResponse(200);
            var mockJsonModel = new MockJsonModel(1, "a");
            mockResponse.SetContent(ModelReaderWriter.Write(mockJsonModel).ToString());
            var transport = new MockTransport(mockResponse);
            var pipeline = new HttpPipeline(transport, default);
            var operationId = Guid.NewGuid().ToString();
            var rehydrationToken = new RehydrationToken(null, null, "None", $"https://management.azure.com/subscriptions/subscription-id/providers/Microsoft.Compute/locations/region/operations/{operationId}?api-version=2019-12-01", "https://test", RequestMethod.Delete, null, OperationFinalStateVia.AzureAsyncOperation.ToString());
            var operation = new RehydrationOperation(pipeline, rehydrationToken);
            Assert.NotNull(operation);
            Assert.AreEqual(operationId, operation.Id);
            Assert.Throws<InvalidOperationException>(() => operation.GetRawResponse());
            Assert.False(operation.HasCompleted);

            operation.UpdateStatus();
            var rawResponse = operation.GetRawResponse();
            Assert.AreEqual(200, rawResponse.Status);
        }

        [Test]
        public void ConstructOperationOfTForRehydration()
        {
            var mockResponse = new MockResponse(200);
            var mockJsonModel = new MockJsonModel(1, "a");
            mockResponse.SetContent(ModelReaderWriter.Write(mockJsonModel).ToString());
            var transport = new MockTransport(mockResponse);
            var pipeline = new HttpPipeline(transport, default);
            var operationId = Guid.NewGuid().ToString();
            var rehydrationToken = new RehydrationToken(null, null, "None", $"https://management.azure.com/subscriptions/subscription-id/providers/Microsoft.Compute/locations/region/operations/{operationId}?api-version=2019-12-01", "https://test", RequestMethod.Delete, null, OperationFinalStateVia.AzureAsyncOperation.ToString());
            var operation = new RehydrationOperation<MockJsonModel>(pipeline, rehydrationToken);

            operation.UpdateStatus();
            var rawResponse = operation.GetRawResponse();
            Assert.AreEqual(200, rawResponse.Status);
            Assert.AreEqual(ModelReaderWriter.Write(mockJsonModel).ToString(), ModelReaderWriter.Write(operation.Value).ToString());
        }

        private class MockClientOptions : ClientOptions
        {
        }
    }
}
