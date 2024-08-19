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

        [Test]
        [TestCase(100, false)]
        [TestCase(200, false)]
        [TestCase(201, false)]
        [TestCase(202, false)]
        [TestCase(204, false)]
        [TestCase(300, false)]
        [TestCase(304, false)]
        [TestCase(400, true)]
        [TestCase(404, true)]
        [TestCase(412, true)]
        [TestCase(429, true)]
        [TestCase(500, true)]
        [TestCase(502, true)]
        [TestCase(503, true)]
        [TestCase(504, true)]
        public void SharedClassifierClassifiesError(int code, bool isError)
        {
            var classifier = ResponseClassifier.Shared;
            var message = new HttpMessage(new MockRequest(), classifier);
            message.Response = new MockResponse(code);

            Assert.AreEqual(isError, classifier.IsErrorResponse(message));
        }

        [Test]
        [TestCase(100, false)]
        [TestCase(200, false)]
        [TestCase(201, false)]
        [TestCase(202, false)]
        [TestCase(204, false)]
        [TestCase(300, false)]
        [TestCase(304, false)]
        [TestCase(400, true)]
        [TestCase(404, true)]
        [TestCase(412, true)]
        [TestCase(429, true)]
        [TestCase(500, true)]
        [TestCase(502, true)]
        [TestCase(503, true)]
        [TestCase(504, true)]
        public void SharedClassifierClassifiesErrorResponse(int code, bool isError)
        {
            var classifier = ResponseClassifier.Shared;
            var message = new HttpMessage(new MockRequest(), classifier);
            message.Response = new MockResponse(code);

            Assert.AreEqual(isError, classifier.IsErrorResponse(message));
        }
    }
}
