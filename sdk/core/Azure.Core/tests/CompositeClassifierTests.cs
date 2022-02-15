// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class CompositeClassifierTests
    {
        [Test]
        public void PerCallClassifierTakesPrecedence()
        {
            CompositeClassifier classifier = new CompositeClassifier(ResponseClassifier.Shared);
            classifier.PerCallClassifier = new StatusCodeClassifier(404, false);

            var message = new HttpMessage(new MockRequest(), classifier);
            message.Response = new MockResponse(404);

            Assert.IsFalse(message.ResponseClassifier.IsError(message));
        }

        [Test]
        public void BaseClassifierTakesPrecedence()
        {
            CompositeClassifier classifier = new CompositeClassifier(new CustomClassifier());

            var message = new HttpMessage(new MockRequest(), classifier);
            message.Response = new MockResponse(404);

            Assert.IsFalse(message.ResponseClassifier.IsError(message));
        }

        #region Helpers
        private class StatusCodeClassifier : HttpMessageClassifier
        {
            private readonly int _statusCode;
            private readonly bool _isError;

            public StatusCodeClassifier(int statusCode, bool isError)
            {
                _statusCode = statusCode;
                _isError = isError;
            }

            public override bool TryClassify(HttpMessage message, out bool isError)
            {
                if (message.Response.Status == _statusCode)
                {
                    isError = _isError;
                    return true;
                }

                isError = false;
                return false;
            }
        }

        private class CustomClassifier : ResponseClassifier
        {
            public override bool IsErrorResponse(HttpMessage message)
            {
                if (message.Response.Status == 404)
                {
                    return false;
                }

                return true;
            }
        }
        #endregion
    }
}
