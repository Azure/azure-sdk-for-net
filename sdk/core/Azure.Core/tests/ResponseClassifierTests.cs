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
            var httpMessage = new HttpMessage(new MockRequest(), new ResponseClassifier());
            httpMessage.Response = new MockResponse(code);

            Assert.True(httpMessage.ResponseClassifier.IsRetriableResponse(httpMessage));
        }

        [Test]
        public void RetriesRequestFailedExceptionsWithoutCode()
        {
            var classifier = new ResponseClassifier();

            Assert.True(classifier.IsRetriableException(new RequestFailedException(0, "IO Exception")));
        }

        [Test]
        public void DoesntRetryRequestFailedExceptionsWithStatusCode()
        {
            var classifier = new ResponseClassifier();

            Assert.False(classifier.IsRetriableException(new RequestFailedException(500, "IO Exception")));
        }

        [Test]
        public void RetriesNonCustomerOperationCancelledExceptions()
        {
            var httpMessage = new HttpMessage(new MockRequest(), new ResponseClassifier());

            Assert.True(httpMessage.ResponseClassifier.IsRetriable(httpMessage, new OperationCanceledException()));
        }

        [Test]
        public void TreatsAll4xAnd5xAsErrors()
        {
            var classifier = new ResponseClassifier();
            var httpMessage = new HttpMessage(new MockRequest(), new ResponseClassifier());
            for (int i = 400; i < 600; i++)
            {
                httpMessage.Response = new MockResponse(i);
                Assert.True(classifier.IsErrorResponse(httpMessage));
            }
        }
    }
}