// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class OperationStateTests
    {
        [Test]
        public void SuccessProperties()
        {
            int expectedValue = 10;
            MockResponse mockResponse = new MockResponse(200);
            OperationState<int> state = OperationState<int>.Success(mockResponse, expectedValue);

            Assert.True(state.HasCompleted);
            Assert.True(state.HasSucceeded);
            Assert.AreEqual(mockResponse, state.RawResponse);
            Assert.AreEqual(expectedValue, state.Value);
            Assert.IsNull(state.OperationFailedException);
        }

        [Test]
        public void SuccessThrowsIfRawResponseIsNull() =>
            Assert.Throws<ArgumentNullException>(() => OperationState<int>.Success(null, 10));

        [Test]
        public void SuccessThrowsIfValueIsNull() =>
            Assert.Throws<ArgumentNullException>(() => OperationState<string>.Success(new MockResponse(200), null));

        [Test]
        public void FailureProperties()
        {
            RequestFailedException expectedException = new RequestFailedException("");
            MockResponse mockResponse = new MockResponse(200);
            OperationState<int> state = OperationState<int>.Failure(mockResponse, expectedException);

            Assert.True(state.HasCompleted);
            Assert.False(state.HasSucceeded);
            Assert.AreEqual(mockResponse, state.RawResponse);
            Assert.AreEqual(default(int), state.Value);
            Assert.AreEqual(expectedException, state.OperationFailedException);
        }

        [Test]
        public void FailureThrowsIfRawResponseIsNull() =>
            Assert.Throws<ArgumentNullException>(() => OperationState<int>.Failure(null, new RequestFailedException("")));

        [Test]
        public void PendingProperties()
        {
            MockResponse mockResponse = new MockResponse(200);
            OperationState<int> state = OperationState<int>.Pending(mockResponse);

            Assert.False(state.HasCompleted);
            Assert.False(state.HasSucceeded);
            Assert.AreEqual(mockResponse, state.RawResponse);
            Assert.AreEqual(default(int), state.Value);
            Assert.IsNull(state.OperationFailedException);
        }

        [Test]
        public void PendingThrowsIfRawResponseIsNull() =>
            Assert.Throws<ArgumentNullException>(() => OperationState<int>.Pending(null));
    }
}
