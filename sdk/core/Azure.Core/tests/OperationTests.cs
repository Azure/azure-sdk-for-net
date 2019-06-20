// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Testing;
using Azure.Core.Tests.TestFramework;
using NUnit;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class OperationTests
    {
        [Test]
        public async Task WaitCompletionAsync()
        {
            int updateCalled = 0;
            var testResult = 100;
            var testResponse = new MockResponse(200);

            var operation = new TestOperation<int>(TimeSpan.FromMilliseconds(10), testResult, testResponse);
            operation.PollingInterval = TimeSpan.FromMilliseconds(1);
            operation.UpdateCalled = () => { updateCalled++; };

            Response<int> operationResult = await operation.WaitCompletionAsync();

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

            var operation = new TestOperation<int>(TimeSpan.FromMilliseconds(10), testResult, testResponse);
            operation.UpdateCalled = () => { updateCalled++; };

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

            var operation = new TestOperation<int>(TimeSpan.FromMilliseconds(10), testResult, testResponse);
            operation.UpdateCalled = () => { updateCalled++; };

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
    }
}

