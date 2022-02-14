// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HttpMessageTests
    {
        [Test]
        public void TryGetPropertyReturnsFalseIfNotExist()
        {
            HttpMessage message = new HttpMessage(new MockRequest(), ResponseClassifier.Shared);

            Assert.False(message.TryGetProperty("someName", out _));
        }

        [Test]
        public void TryGetPropertyReturnsValueIfSet()
        {
            HttpMessage message = new HttpMessage(new MockRequest(), ResponseClassifier.Shared);
            message.SetProperty("someName", "value");

            Assert.True(message.TryGetProperty("someName", out object value));
            Assert.AreEqual("value", value);
        }

        [Test]
        public void TryGetPropertyIsCaseSensitive()
        {
            HttpMessage message = new HttpMessage(new MockRequest(), ResponseClassifier.Shared);
            message.SetProperty("someName", "value");

            Assert.False(message.TryGetProperty("SomeName", out _));
        }

        [Test]
        public void AppliesResponseClassifierErrors()
        {
            HttpMessage message = new HttpMessage(new MockRequest(), ResponseClassifier.Shared);
            RequestContext context = new RequestContext();
            context.AddClassifier(204, isError: true);
            message.ApplyRequestContext(context);

            message.Response = new MockResponse(204);
            Assert.IsTrue(message.ResponseClassifier.IsError(message));

            message.Response = new MockResponse(304);
            Assert.IsFalse(message.ResponseClassifier.IsError(message));

            message.Response = new MockResponse(404);
            Assert.IsTrue(message.ResponseClassifier.IsError(message));

            message.Response = new MockResponse(500);
            Assert.IsTrue(message.ResponseClassifier.IsError(message));
        }

        [Test]
        public void AppliesResponseClassifierNonErrors()
        {
            HttpMessage message = new HttpMessage(new MockRequest(), ResponseClassifier.Shared);
            RequestContext context = new RequestContext();
            context.AddClassifier(404, isError: false);
            message.ApplyRequestContext(context);

            message.Response = new MockResponse(304);
            Assert.IsFalse(message.ResponseClassifier.IsError(message));

            message.Response = new MockResponse(404);
            Assert.IsFalse(message.ResponseClassifier.IsError(message));

            message.Response = new MockResponse(500);
            Assert.IsTrue(message.ResponseClassifier.IsError(message));
        }

        [Test]
        public void AppliesResponseClassifierBothErrorsAndNonErrors()
        {
            HttpMessage message = new HttpMessage(new MockRequest(), ResponseClassifier.Shared);
            RequestContext context = new RequestContext();
            context.AddClassifier(404, isError: false);
            context.AddClassifier(301, isError: true);
            context.AddClassifier(304, isError: true);
            message.ApplyRequestContext(context);

            message.Response = new MockResponse(301);
            Assert.IsTrue(message.ResponseClassifier.IsError(message));

            message.Response = new MockResponse(304);
            Assert.IsTrue(message.ResponseClassifier.IsError(message));

            message.Response = new MockResponse(404);
            Assert.IsFalse(message.ResponseClassifier.IsError(message));

            message.Response = new MockResponse(500);
            Assert.IsTrue(message.ResponseClassifier.IsError(message));
        }

        [Test]
        public void SettingResponseClassifierReplacesBaseClassifier()
        {
            HttpMessage message = new HttpMessage(new MockRequest(), ResponseClassifier.Shared);

            message.Response = new MockResponse(404);
            Assert.IsTrue(message.ResponseClassifier.IsError(message));

            // This replaces the base classifier with one that only thinks 404 is a non-error
            // and doesn't have opinions on anything else.
            message.ResponseClassifier = new StatusCodeClassifier(404, false);

            message.Response = new MockResponse(304);
            Assert.IsFalse(message.ResponseClassifier.IsError(message));

            message.Response = new MockResponse(404);
            Assert.IsFalse(message.ResponseClassifier.IsError(message));

            message.Response = new MockResponse(500);
            Assert.IsFalse(message.ResponseClassifier.IsError(message));
        }

        [Test]
        public void SettingResponseClassifierReplacesBaseClassifier_PerCallCustomization()
        {
            HttpMessage message = new HttpMessage(new MockRequest(), ResponseClassifier.Shared);

            message.Response = new MockResponse(404);
            Assert.IsTrue(message.ResponseClassifier.IsError(message));

            RequestContext context = new RequestContext();
            context.AddClassifier(new StatusCodeMessageClassifier(304, true));

            message.ApplyRequestContext(context);

            // This replaces the base classifier with one that only thinks 404 is a non-error
            // and doesn't have opinions on anything else.
            message.ResponseClassifier = new StatusCodeClassifier(404, false);

            message.Response = new MockResponse(304);
            Assert.IsTrue(message.ResponseClassifier.IsError(message));

            message.Response = new MockResponse(404);
            Assert.IsFalse(message.ResponseClassifier.IsError(message));

            message.Response = new MockResponse(500);
            Assert.IsFalse(message.ResponseClassifier.IsError(message));
        }

        [Test]
        public void SettingResponseClassifierReplacesBaseClassifier_PerClientCustomizationMaintained()
        {
            var pipeline = HttpPipelineBuilder.Build(
                ClientOptions.Default,
                new HttpPipelinePolicy[] { },
                new HttpPipelinePolicy[] { },
                new StatusCodeMessageClassifier(404, false));

            var message = pipeline.CreateMessage();

            message.Response = new MockResponse(304);
            Assert.IsFalse(message.ResponseClassifier.IsError(message));

            message.Response = new MockResponse(404);
            Assert.IsFalse(message.ResponseClassifier.IsError(message));

            message.ResponseClassifier = new StatusCodeClassifier(304, true);

            message.Response = new MockResponse(304);
            Assert.IsTrue(message.ResponseClassifier.IsError(message));

            message.Response = new MockResponse(404);
            Assert.IsFalse(message.ResponseClassifier.IsError(message));

            message.ResponseClassifier = ResponseClassifier.Shared;

            message.Response = new MockResponse(304);
            Assert.IsFalse(message.ResponseClassifier.IsError(message));

            message.Response = new MockResponse(404);
            Assert.IsFalse(message.ResponseClassifier.IsError(message));

            message.Response = new MockResponse(500);
            Assert.IsTrue(message.ResponseClassifier.IsError(message));
        }

        [Test]
        public void SettingResponseClassifierReplacesBaseClassifier_PerClientCustomizationClobbered()
        {
            var pipeline = HttpPipelineBuilder.Build(
                ClientOptions.Default,
                new HttpPipelinePolicy[] { },
                new HttpPipelinePolicy[] { },
                new StatusCodeClassifier(404, false));

            var message = pipeline.CreateMessage();

            message.Response = new MockResponse(304);
            Assert.IsFalse(message.ResponseClassifier.IsError(message));

            message.Response = new MockResponse(404);
            Assert.IsFalse(message.ResponseClassifier.IsError(message));

            message.ResponseClassifier = new StatusCodeClassifier(304, true);

            message.Response = new MockResponse(304);
            Assert.IsTrue(message.ResponseClassifier.IsError(message));

            message.Response = new MockResponse(404);
            Assert.IsFalse(message.ResponseClassifier.IsError(message));

            message.ResponseClassifier = ResponseClassifier.Shared;

            message.Response = new MockResponse(304);
            Assert.IsFalse(message.ResponseClassifier.IsError(message));

            message.Response = new MockResponse(404);
            Assert.IsTrue(message.ResponseClassifier.IsError(message));

            message.Response = new MockResponse(500);
            Assert.IsTrue(message.ResponseClassifier.IsError(message));
        }

        #region Helpers
        private class StatusCodeMessageClassifier : HttpMessageClassifier
        {
            private readonly int _statusCode;
            private readonly bool _isError;

            public StatusCodeMessageClassifier(int statusCode, bool isError)
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

        private class StatusCodeClassifier : ResponseClassifier
        {
            private readonly int _statusCode;
            private readonly bool _isError;

            public StatusCodeClassifier(int statusCode, bool isError)
            {
                _statusCode = statusCode;
                _isError = isError;
            }

            public override bool IsErrorResponse(HttpMessage message)
            {
                if (message.Response.Status == _statusCode)
                {
                    return _isError;
                }

                return false;
            }
        }
        #endregion
    }
}
