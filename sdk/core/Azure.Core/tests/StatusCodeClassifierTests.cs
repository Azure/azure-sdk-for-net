// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    internal class StatusCodeClassifierTests
    {
        [Test]
        public void ClassifiesSingleCodeAsNonError()
        {
            // test classifiers for each of the status codes
            for (int nonError = 100; nonError <= 599; nonError++)
            {
                StatusCodeClassifier classifier = new StatusCodeClassifier(new int[] { nonError });
                HttpMessage message = new HttpMessage(new MockRequest(), classifier);

                // test all the status codes against the classifier
                for (int code = 100; code <= 599; code++)
                {
                    message.Response = new MockResponse(code);
                    var isNonError = !message.ResponseClassifier.IsError(message);

                    if (nonError == code)
                    {
                        Assert.True(isNonError);
                    }
                    else
                    {
                        Assert.False(isNonError);
                    }
                }
            }
        }

        [Test]
        [TestCase(200, false)]
        [TestCase(204, true)]
        [TestCase(404, false)]
        [TestCase(500, true)]
        [TestCase(502, true)]
        public void ClassifiesMultipleCodesAsNonErrors(int code, bool isError)
        {
            StatusCodeClassifier classifier = new StatusCodeClassifier(stackalloc int[] { 200, 404 });

            HttpMessage message = new HttpMessage(new MockRequest(), classifier);

            message.Response = new MockResponse(code);
            Assert.AreEqual(isError, message.ResponseClassifier.IsError(message));
        }
    }
}
