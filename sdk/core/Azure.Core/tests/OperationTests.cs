// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Core.Tests.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class OperationTests
    {
        [Test]
        public async Task WaitForCompletionAsync()
        {
            int updateCalled = 0;
            var testResult = 100;
            var testResponse = new MockResponse(200);

            var operation = new TestOperation<int>("operation-id", TimeSpan.FromMilliseconds(10), testResult, testResponse)
            {
                UpdateCalled = () => { updateCalled++; }
            };

            Response<int> operationResult = await operation.WaitForCompletionAsync();

            Assert.Greater(updateCalled, 0);
            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);

            Assert.AreEqual(testResult, operationResult.Value);
            Assert.AreEqual(testResponse, operationResult.GetRawResponse());

            Assert.AreEqual(testResult, operation.Value);
            Assert.AreEqual(testResponse, operation.GetRawResponse());
        }

        [Test]
        public async Task UpdateStatusAsync()
        {
            int updateCalled = 0;
            var testResult = 100;
            var testResponse = new MockResponse(200);

            var operation = new TestOperation<int>("operation-id", TimeSpan.FromMilliseconds(10), testResult, testResponse)
            {
                UpdateCalled = () => { updateCalled++; }
            };

            while (!operation.HasValue)
            {
                Response updateResponse = await operation.UpdateStatusAsync();
                await Task.Delay(1);
            }

            Assert.Greater(updateCalled, 0);
            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);

            Assert.AreEqual(testResult, operation.Value);
            Assert.AreEqual(testResponse, operation.GetRawResponse());
        }

        [Test]
        public void UpdateStatus()
        {
            int updateCalled = 0;
            var testResult = 10;
            var testResponse = new MockResponse(200);

            var operation = new TestOperation<int>("operation-id", TimeSpan.FromMilliseconds(10), testResult, testResponse)
            {
                UpdateCalled = () => { updateCalled++; }
            };

            while (!operation.HasValue)
            {
                Response updateResponse = operation.UpdateStatus();
                Thread.Sleep(1);
            }

            Assert.Greater(updateCalled, 0);
            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);

            Assert.AreEqual(testResult, operation.Value);
            Assert.AreEqual(testResponse, operation.GetRawResponse());
        }

        [Test]
        public void Cancellation()
        {
            var cancel = new CancellationTokenSource();
            cancel.CancelAfter(100);

            int updateCalled = 0;

            var operation = new TestOperation<int>("operation-id", TimeSpan.FromMilliseconds(1000), 100, null)
            {
                UpdateCalled = () => { updateCalled++; }
            };

            Assert.That(async () =>
            {
                _ = await operation.WaitForCompletionAsync(cancel.Token);
            }, Throws.InstanceOf<OperationCanceledException>());

            Assert.IsTrue(cancel.IsCancellationRequested);
            Assert.Greater(updateCalled, 0);
            Assert.IsFalse(operation.HasValue);
        }

        [Test]
        public void NotCompleted()
        {
            var operation = new TestOperation<int>("operation-id", TimeSpan.FromMilliseconds(1000), 100, null);
            Assert.IsFalse(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);
            Assert.Throws<InvalidOperationException>(() =>
            {
                _ = operation.Value;
            });
        }

        [Test]
        public void OperationId()
        {
            string testId = "operation-id";
            var operation = new TestOperation<int>(testId, TimeSpan.Zero, 0, null);
            Assert.AreEqual(testId, operation.Id);
        }

        [Test]
        public void ThrowOnNullArgumentWhileRehydrateAsync()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Operation.RehydrateAsync(null, new RehydrationToken()));
        }

        [Test]
        public void ThrowOnNullArgumentWhileRehydrate()
        {
            Assert.Throws<ArgumentNullException>(() => Operation.Rehydrate(null, new RehydrationToken()));
        }

        [Test]
        public void Rehydrate()
        {
            var pipeline = CreateMockHttpPipeline(HttpStatusCode.Accepted, out _);
            var operationId = Guid.NewGuid().ToString();
            var rehydrationToken = new RehydrationToken(operationId, null, "Location", "test", "https://test", RequestMethod.Put, null, OperationFinalStateVia.AzureAsyncOperation.ToString());
            var operation = Operation.Rehydrate(pipeline, rehydrationToken);
            Assert.NotNull(operation);
            Assert.AreEqual(operationId, operation.Id);
            Assert.False(operation.HasCompleted);
            Assert.AreEqual((int)HttpStatusCode.Accepted,operation.GetRawResponse().Status);
        }

        [Test]
        public async Task RehydrateAsync()
        {
            var pipeline = CreateMockHttpPipeline(HttpStatusCode.Accepted, out _);
            var operationId = Guid.NewGuid().ToString();
            var rehydrationToken = new RehydrationToken(operationId, null, "Location", "test", "https://test", RequestMethod.Put, null, OperationFinalStateVia.AzureAsyncOperation.ToString());
            var operation = await Operation.RehydrateAsync(pipeline, rehydrationToken);
            Assert.NotNull(operation);
            Assert.AreEqual(operationId, operation.Id);
            Assert.False(operation.HasCompleted);
            Assert.AreEqual((int)HttpStatusCode.Accepted, operation.GetRawResponse().Status);
        }

        [Test]
        public void RehydrateOfT()
        {
            var pipeline = CreateMockHttpPipeline(HttpStatusCode.OK, out var mockJsonModel);
            var operationId = Guid.NewGuid().ToString();
            var rehydrationToken = new RehydrationToken(operationId, null, "None", "test", "https://test", RequestMethod.Delete, null, OperationFinalStateVia.AzureAsyncOperation.ToString());
            var operation = Operation.Rehydrate<MockJsonModel>(pipeline, rehydrationToken);
            Assert.NotNull(operation);
            Assert.AreEqual(operationId, operation.Id);
            Assert.True(operation.HasCompleted);
            Assert.True(operation.HasValue);
            Assert.AreEqual((int)HttpStatusCode.OK, operation.GetRawResponse().Status);
            Assert.AreEqual(ModelReaderWriter.Write(mockJsonModel).ToString(), ModelReaderWriter.Write(operation.Value).ToString());
        }

        [Test]
        public async Task RehydrateAsyncOfT()
        {
            var pipeline = CreateMockHttpPipeline(HttpStatusCode.OK, out var mockJsonModel);
            var rehydrationToken = new RehydrationToken(null, null, "None", "test", "https://test", RequestMethod.Delete, null, OperationFinalStateVia.AzureAsyncOperation.ToString());
            var operation = await Operation.RehydrateAsync<MockJsonModel>(pipeline, rehydrationToken);
            Assert.NotNull(operation);
            Assert.True(operation.HasCompleted);
            Assert.True(operation.HasValue);
            Assert.AreEqual((int)HttpStatusCode.OK, operation.GetRawResponse().Status);
            Assert.AreEqual(ModelReaderWriter.Write(mockJsonModel).ToString(), ModelReaderWriter.Write(operation.Value).ToString());
        }

        [Test]
        public async Task ConstructOperationForRehydrationWithFailure()
        {
            HttpPipeline pipeline = CreateMockHttpPipeline(HttpStatusCode.InternalServerError, out _);
            var rehydrationToken = new RehydrationToken(null, null, "None", "test", "https://test", RequestMethod.Delete, null, OperationFinalStateVia.AzureAsyncOperation.ToString());
            var operation = await Operation.RehydrateAsync<MockJsonModel>(pipeline, rehydrationToken);
            Assert.NotNull(operation);
            Assert.AreEqual(500, operation.GetRawResponse().Status);
            Assert.True(operation.HasCompleted);
        }

        [Test]
        public async Task GetRehydrationTokenAsync()
        {
            var pipeline = CreateMockHttpPipeline(HttpStatusCode.OK, out _);
            var rehydrationToken = new RehydrationToken(NextLinkOperationImplementation.NotSet, null, "None", "test", "https://test/", RequestMethod.Delete, null, OperationFinalStateVia.AzureAsyncOperation.ToString());
            var operation = await Operation.RehydrateAsync(pipeline, rehydrationToken);
            var token = operation.GetRehydrationToken();
            Assert.AreEqual(ModelReaderWriter.Write(rehydrationToken).ToString(), ModelReaderWriter.Write(token).ToString());
        }

        [Test]
        public async Task GetRehydrationTokenOfTAsync()
        {
            var pipeline = CreateMockHttpPipeline(HttpStatusCode.OK, out _);
            var rehydrationToken = new RehydrationToken(NextLinkOperationImplementation.NotSet, null, "None", "test", "https://test/", RequestMethod.Delete, null, OperationFinalStateVia.AzureAsyncOperation.ToString());
            var operation = await Operation.RehydrateAsync<MockJsonModel>(pipeline, rehydrationToken);
            var token = operation.GetRehydrationToken();
            Assert.AreEqual(ModelReaderWriter.Write(rehydrationToken).ToString(), ModelReaderWriter.Write(token).ToString());
        }

        private static HttpPipeline CreateMockHttpPipeline(HttpStatusCode statusCode, out MockJsonModel mockJsonModel)
        {
            var mockResponse = new MockResponse((int)statusCode);
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
