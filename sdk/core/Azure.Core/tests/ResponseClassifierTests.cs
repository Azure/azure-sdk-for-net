// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ResponseClassifierTests
    {
        [Theory]
        [TestCase(500)]
        [TestCase(429)]
        [TestCase(408)]
        [TestCase(502)]
        [TestCase(503)]
        [TestCase(504)]
        public void RetriesStatusCodes(int code)
        {
            var httpMessage = new HttpMessage(new MockRequest(), ResponseClassifier.Shared);
            httpMessage.Response = new MockResponse(code);

            Assert.True(httpMessage.ResponseClassifier.IsRetriableResponse(httpMessage));
        }

        [Test]
        public void RetriesRequestFailedExceptionsWithoutCode()
        {
            var classifier = ResponseClassifier.Shared;

            Assert.True(classifier.IsRetriableException(new RequestFailedException(0, "IO Exception")));
        }

        [Test]
        public void DoesntRetryRequestFailedExceptionsWithStatusCode()
        {
            var classifier = ResponseClassifier.Shared;

            Assert.False(classifier.IsRetriableException(new RequestFailedException(500, "IO Exception")));
        }

        [Test]
        public void RetriesNonCustomerOperationCancelledExceptions()
        {
            var httpMessage = new HttpMessage(new MockRequest(), ResponseClassifier.Shared);

            Assert.True(httpMessage.ResponseClassifier.IsRetriable(httpMessage, new OperationCanceledException()));
        }
    }
}