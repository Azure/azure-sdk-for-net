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

            Assert.That(state.HasCompleted, Is.True);
            Assert.That(state.HasSucceeded, Is.True);
            Assert.That(state.RawResponse, Is.EqualTo(mockResponse));
            Assert.That(state.Value, Is.EqualTo(expectedValue));
            Assert.That(state.OperationFailedException, Is.Null);
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

            Assert.That(state.HasCompleted, Is.True);
            Assert.That(state.HasSucceeded, Is.False);
            Assert.That(state.RawResponse, Is.EqualTo(mockResponse));
            Assert.That(state.Value, Is.EqualTo(default(int)));
            Assert.That(state.OperationFailedException, Is.EqualTo(expectedException));
        }

        [Test]
        public void FailureThrowsIfRawResponseIsNull() =>
            Assert.Throws<ArgumentNullException>(() => OperationState<int>.Failure(null, new RequestFailedException("")));

        [Test]
        public void PendingProperties()
        {
            MockResponse mockResponse = new MockResponse(200);
            OperationState<int> state = OperationState<int>.Pending(mockResponse);

            Assert.That(state.HasCompleted, Is.False);
            Assert.That(state.HasSucceeded, Is.False);
            Assert.That(state.RawResponse, Is.EqualTo(mockResponse));
            Assert.That(state.Value, Is.EqualTo(default(int)));
            Assert.That(state.OperationFailedException, Is.Null);
        }

        [Test]
        public void PendingThrowsIfRawResponseIsNull() =>
            Assert.Throws<ArgumentNullException>(() => OperationState<int>.Pending(null));
    }
}
