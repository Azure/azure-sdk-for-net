// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Core.Tests.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Internal;

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
            Assert.Null(operation.GetRehydrationToken());
        }

        [Test]
        public void ThrowOnNullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => new Operation(null, new RehydrationToken()));
        }

        [Test]
        public void ConstructOperationForRehydration()
        {
            var operationId = Guid.NewGuid().ToString();
            var rehydrationToken = new RehydrationToken(null, null, "None", $"https://management.azure.com/subscriptions/subscription-id/providers/Microsoft.Compute/locations/region/operations/{operationId}?api-version=2019-12-01", "https://test", RequestMethod.Delete, null, OperationFinalStateVia.AzureAsyncOperation.ToString());
            var operation = new Operation(HttpPipelineBuilder.Build(new MockClientOptions()), rehydrationToken);
            Assert.NotNull(operation);
            Assert.AreEqual(operationId, operation.Id);
            Assert.Null(operation.GetRawResponse());
            Assert.False(operation.HasCompleted);
        }

        [Test]
        public void ConstructOperationOfTForRehydration()
        {
            var operationId = Guid.NewGuid().ToString();
            var rehydrationToken = new RehydrationToken(null, null, "None", $"https://management.azure.com/subscriptions/subscription-id/providers/Microsoft.Compute/locations/region/operations/{operationId}?api-version=2019-12-01", "https://test", RequestMethod.Delete, null, OperationFinalStateVia.AzureAsyncOperation.ToString());
            var operation = new Operation<int>(HttpPipelineBuilder.Build(new MockClientOptions()), rehydrationToken);
            Assert.NotNull(operation);
            Assert.AreEqual(operationId, operation.Id);
            Assert.Null(operation.GetRawResponse());
            Assert.False(operation.HasCompleted);
            Assert.Throws<InvalidOperationException>(() => { var value = operation.Value; });
            Assert.False(operation.HasValue);
        }

        private class MockClientOptions : ClientOptions
        {
        }
    }
}
