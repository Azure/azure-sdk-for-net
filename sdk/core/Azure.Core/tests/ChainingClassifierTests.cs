// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ChainingClassifierTests
    {
        [Test]
        public void ClassifiesUsingOnlyEndOfChain()
        {
            ChainingClassifier classifier = new ChainingClassifier(
                statusCodes: null,
                handlers: null,
                HelperResponseClassifier.Instance);

            HttpMessage message = new HttpMessage(new MockRequest(), default);

            message.Response = new MockResponse(204);
            Assert.That(classifier.IsErrorResponse(message), Is.False);

            message.Response = new MockResponse(304);
            Assert.That(classifier.IsErrorResponse(message), Is.False);

            message.Response = new MockResponse(404);
            Assert.That(classifier.IsErrorResponse(message), Is.True);

            message.Response = new MockResponse(500);
            Assert.That(classifier.IsErrorResponse(message), Is.True);
        }

        [Test]
        public void ClassifiesUsingHandlersAndEndOfChain()
        {
            ResponseClassificationHandler[] handlers = new ResponseClassificationHandler[]
            {
                new HeaderClassificationHandler(204, "ErrorCode", "Error"),
                new HeaderClassificationHandler(404, "ErrorCode", "NonError"),
            };

            ChainingClassifier classifier = new ChainingClassifier(
                statusCodes: null,
                handlers: handlers,
                HelperResponseClassifier.Instance);

            HttpMessage message = new HttpMessage(new MockRequest(), default);

            var response = new MockResponse(204);
            response.AddHeader("ErrorCode", "Error");
            message.Response = response;
            Assert.That(classifier.IsErrorResponse(message), Is.True);

            response = new MockResponse(304);
            response.AddHeader("ErrorCode", "Error");
            message.Response = response;
            Assert.That(classifier.IsErrorResponse(message), Is.False);

            response = new MockResponse(404);
            response.AddHeader("ErrorCode", "Error");
            message.Response = response;
            Assert.That(classifier.IsErrorResponse(message), Is.False);

            response = new MockResponse(500);
            response.AddHeader("ErrorCode", "Error");
            message.Response = response;
            Assert.That(classifier.IsErrorResponse(message), Is.True);
        }

        [Test]
        public void ClassifiesUsingStatusCodesAndEndOfChain()
        {
            (int Status, bool IsError)[] classifications = new (int Status, bool IsError)[]
            {
                (204, true),
                (404, false),
                (500, false),
            };

            ChainingClassifier classifier = new ChainingClassifier(
                statusCodes: classifications,
                handlers: null,
                HelperResponseClassifier.Instance);

            HttpMessage message = new HttpMessage(new MockRequest(), default);

            message.Response = new MockResponse(204);
            Assert.That(classifier.IsErrorResponse(message), Is.True);

            message.Response = new MockResponse(304);
            Assert.That(classifier.IsErrorResponse(message), Is.False);

            message.Response = new MockResponse(404);
            Assert.That(classifier.IsErrorResponse(message), Is.False);

            message.Response = new MockResponse(500);
            Assert.That(classifier.IsErrorResponse(message), Is.False);
        }

        [Test]
        public void ClassifiesUsingAllHandlersTakePrecedenceOverStatusCodes()
        {
            (int Status, bool IsError)[] classifications = new (int Status, bool IsError)[]
            {
                (204, false),
                (500, false),
            };

            ResponseClassificationHandler[] handlers = new ResponseClassificationHandler[]
            {
                new HeaderClassificationHandler(204, "ErrorCode", "Error"),
                new HeaderClassificationHandler(404, "ErrorCode", "NonError"),
            };

            ChainingClassifier classifier = new ChainingClassifier(
                statusCodes: classifications,
                handlers: handlers,
                HelperResponseClassifier.Instance);

            HttpMessage message = new HttpMessage(new MockRequest(), default);

            // Handler takes precedence
            var response = new MockResponse(204);
            response.AddHeader("ErrorCode", "Error");
            message.Response = response;
            Assert.That(classifier.IsErrorResponse(message), Is.True);

            // End of chain is reached
            message.Response = new MockResponse(304);
            Assert.That(classifier.IsErrorResponse(message), Is.False);

            // Handler takes precedence
            response = new MockResponse(404);
            response.AddHeader("ErrorCode", "Error");
            message.Response = response;
            Assert.That(classifier.IsErrorResponse(message), Is.False);

            // Status code handler is reached
            message.Response = new MockResponse(500);
            Assert.That(classifier.IsErrorResponse(message), Is.False);
        }

        #region Helpers
        private sealed class HelperResponseClassifier : ResponseClassifier
        {
            private static ResponseClassifier _instance;
            public static ResponseClassifier Instance => _instance ??= new HelperResponseClassifier();
            public override bool IsErrorResponse(HttpMessage message)
            {
                return message.Response.Status switch
                {
                    >= 100 and < 400 => false,
                    _ => true
                };
            }
        }

        public class HeaderClassificationHandler : ResponseClassificationHandler
        {
            private readonly int _statusCode;
            private readonly string _headerName;    //  e.g. "ErrorCode";
            private readonly string _headerValue;   //  e.g. "LeaseNotAquired";

            public HeaderClassificationHandler(int statusCode, string headerName, string headerValue)
            {
                _statusCode = statusCode;
                _headerName = headerName;
                _headerValue = headerValue;
            }

            public override bool TryClassify(HttpMessage message, out bool isError)
            {
                isError = false;

                if (message.Response.Status != _statusCode)
                {
                    return false;
                }

                if (message.Response.Headers.TryGetValue(_headerName, out string value) &&
                    _headerValue == value)
                {
                    isError = true;
                }

                return true;
            }
        }
        #endregion
    }
}
