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
            var perCallClassifier = new StatusCodeClassifier(404, false);
            var perClientClassifier = new StatusCodeClassifier(404, true);

            var context = new RequestContext();
            context.AddClassifier(perCallClassifier);

            var message = new HttpMessage(new MockRequest(), ResponseClassifier.Shared);
            message.PerClientClassifier = perClientClassifier;
            message.ApplyRequestContext(context);
            message.Response = new MockResponse(404);

            var isError = message.ResponseClassifier.IsError(message);

            Assert.IsFalse(isError);
        }

        [Test]
        public void PerClientClassifierTakesPrecedence()
        {
            var perClientClassifier = new StatusCodeClassifier(404, false);

            var message = new HttpMessage(new MockRequest(), ResponseClassifier.Shared);
            message.PerClientClassifier = perClientClassifier;
            message.Response = new MockResponse(404);

            var isError = message.ResponseClassifier.IsError(message);

            Assert.IsFalse(isError);
        }

        #region Helpers
        private class StatusCodeClassifier : MessageClassifier
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
        #endregion
    }
}
