// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core.Tests.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class PageableOperationTests
    {
        [Test]
        public async Task ValueAndGetValuesAndGetValuesAsync()
        {
            int updateCalled = 0;
            var testResponse = new MockResponse(200);
            var pageOne = Page<int>.FromValues(new int[] { 1, 2 }, "next", new MockResponse(200));
            var pageTwo = Page<int>.FromValues(new int[] { 3, 4 }, null, new MockResponse(200));

            var operation = new TestPageableOperation<int>("operation-id", TimeSpan.FromMilliseconds(10), pageOne, pageTwo, testResponse)
            {
                UpdateCalled = () => { updateCalled++; }
            };

            await operation.WaitForCompletionAsync();

            Assert.Greater(updateCalled, 0);
            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(testResponse, operation.GetRawResponse());

            Assert.AreEqual(new[] { 1, 2, 3, 4 }, operation.GetValues().ToArray());
            Assert.AreEqual(new[] { 1, 2, 3, 4 }, await operation.GetValuesAsync().ToEnumerableAsync());
            Assert.AreEqual(new[] { 1, 2, 3, 4 }, await operation.Value.ToEnumerableAsync());
        }

        [Test]
        public void NotCompleted()
        {
            var operation = new TestPageableOperation<int>("operation-id", TimeSpan.FromMilliseconds(10), null, null, null);
            Assert.IsFalse(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);
            Assert.Throws<InvalidOperationException>(() =>
            {
                _ = operation.Value;
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                _ = operation.GetValues();
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                _ = operation.GetValuesAsync();
            });
        }
    }
}
