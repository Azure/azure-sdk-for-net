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
            RequestContext context = new RequestContext();
            context.AddClassifier(204, isError: true);

            HttpMessage message = new HttpMessage(new MockRequest(), default);
            message.ApplyRequestContext(context, DpgClassifier.Instance);

            message.Response = new MockResponse(204);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(304);
            Assert.IsFalse(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(404);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(500);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));
        }

        [Test]
        public void AppliesResponseClassifierNonErrors()
        {
            RequestContext context = new RequestContext();
            context.AddClassifier(404, isError: false);

            HttpMessage message = new HttpMessage(new MockRequest(), default);
            message.ApplyRequestContext(context, DpgClassifier.Instance);

            message.Response = new MockResponse(204);
            Assert.IsFalse(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(304);
            Assert.IsFalse(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(404);
            Assert.IsFalse(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(500);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));
        }

        [Test]
        public void AppliesResponseClassifierBothErrorsAndNonErrors()
        {
            RequestContext context = new RequestContext();
            context.AddClassifier(301, isError: true);
            context.AddClassifier(304, isError: true);
            context.AddClassifier(404, isError: false);

            HttpMessage message = new HttpMessage(new MockRequest(), default);
            message.ApplyRequestContext(context, DpgClassifier.Instance);

            message.Response = new MockResponse(204);
            Assert.IsFalse(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(301);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(304);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(404);
            Assert.IsFalse(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(500);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));
        }

        [Test]
        public void SettingResponseClassifierReplacesBaseClassifier()
        {
            HttpMessage message = new HttpMessage(new MockRequest(), DpgClassifier.Instance);

            message.Response = new MockResponse(404);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));

            // This replaces the base classifier with one that thinks
            // only 404 is a non-error.
            message.ResponseClassifier = new CoreResponseClassifier(stackalloc int[] { 404 });

            message.Response = new MockResponse(204);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(304);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(404);
            Assert.IsFalse(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(500);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));
        }

        [Test]
        public void SettingResponseClassifierReplacesBaseClassifier_PerCallCustomization()
        {
            HttpMessage message = new HttpMessage(new MockRequest(), DpgClassifier.Instance);

            message.Response = new MockResponse(404);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));

            RequestContext context = new RequestContext();
            context.AddClassifier(new StatusCodeHandler(304, true));

            message.ResponseClassifier = context.Apply(DpgClassifier.Instance);

            // This replaces the base classifier with one that only thinks 404 is a non-error
            // and doesn't have opinions on anything else.
            message.ResponseClassifier = new CoreResponseClassifier(stackalloc int[] { 404 });

            message.Response = new MockResponse(304);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(404);
            Assert.IsFalse(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(500);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));
        }

        [Test]
        public void SettingResponseClassifierReplacesBaseClassifier_PerClientCustomizationClobbered()
        {
            var pipeline = HttpPipelineBuilder.Build(
                ClientOptions.Default,
                new HttpPipelinePolicy[] { },
                new HttpPipelinePolicy[] { },
                new CoreResponseClassifier(stackalloc int[] { 404 }));

            var message = pipeline.CreateMessage();

            message.Response = new MockResponse(304);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(404);
            Assert.IsFalse(message.ResponseClassifier.IsErrorResponse(message));

            message.ResponseClassifier = new CoreResponseClassifier(stackalloc int[] { 304 });

            message.Response = new MockResponse(304);
            Assert.IsFalse(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(404);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));

            message.ResponseClassifier = DpgClassifier.Instance;

            message.Response = new MockResponse(304);
            Assert.IsFalse(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(404);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(500);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));
        }

        [Test]
        public void AppliesHandler()
        {
            RequestContext context = new RequestContext();
            context.AddClassifier(new StatusCodeHandler(204, isError: true));

            HttpMessage message = new HttpMessage(new MockRequest(), default);
            message.ApplyRequestContext(context, DpgClassifier.Instance);

            message.Response = new MockResponse(204);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(304);
            Assert.IsFalse(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(404);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(500);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));
        }

        [Test]
        public void AppliesHandlerBeforeResponseClassifier()
        {
            RequestContext context = new RequestContext();
            context.AddClassifier(new StatusCodeHandler(204, true));
            context.AddClassifier(204, isError: false);

            HttpMessage message = new HttpMessage(new MockRequest(), default);
            message.ApplyRequestContext(context, DpgClassifier.Instance);

            message.Response = new MockResponse(204);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(304);
            Assert.IsFalse(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(404);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(500);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));
        }

        [Test]
        public void AppliesResponseClassifier()
        {
            HttpMessage message = new HttpMessage(new MockRequest(), default);
            message.ApplyRequestContext(new RequestContext(), HeadResponseClassifier.Instance);

            message.Response = new MockResponse(204);
            Assert.IsFalse(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(304);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(404);
            Assert.IsFalse(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(500);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));
        }

        [Test]
        public void ChainsClassifiers_StatusCodes()
        {
            RequestContext context = new RequestContext();
            context.AddClassifier(404, true);
            context.AddClassifier(500, false);

            HttpMessage message = new HttpMessage(new MockRequest(), default);
            message.ApplyRequestContext(context, HeadResponseClassifier.Instance);

            message.Response = new MockResponse(204);
            Assert.IsFalse(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(304);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(404);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(500);
            Assert.IsFalse(message.ResponseClassifier.IsErrorResponse(message));
        }

        [Test]
        public void ChainsClassifiers_StatusCodesAndHandlers()
        {
            RequestContext context = new RequestContext();
            context.AddClassifier(404, true);
            context.AddClassifier(500, false);
            context.AddClassifier(new StatusCodeHandler(404, false));

            HttpMessage message = new HttpMessage(new MockRequest(), default);
            message.ApplyRequestContext(context, HeadResponseClassifier.Instance);

            message.Response = new MockResponse(204);
            Assert.IsFalse(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(304);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(404);
            Assert.IsFalse(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(500);
            Assert.IsFalse(message.ResponseClassifier.IsErrorResponse(message));
        }

        [Test]
        public void AppliesHandlerWithLastSetWinsSemantics()
        {
            RequestContext context = new RequestContext();
            context.AddClassifier(new StatusCodeHandler(204, true));
            context.AddClassifier(new StatusCodeHandler(204, false));

            HttpMessage message = new HttpMessage(new MockRequest(), default);
            message.ApplyRequestContext(context, DpgClassifier.Instance);

            message.Response = new MockResponse(204);
            Assert.IsFalse(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(304);
            Assert.IsFalse(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(404);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));

            message.Response = new MockResponse(500);
            Assert.IsTrue(message.ResponseClassifier.IsErrorResponse(message));
        }

        #region Helpers
        private class StatusCodeHandler : ResponseClassificationHandler
        {
            private readonly int _statusCode;
            private readonly bool _isError;

            public StatusCodeHandler(int statusCode, bool isError)
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

        /// <summary>
        /// Example DPG classifier for testing purposes.
        /// </summary>
        private sealed class DpgClassifier : CoreResponseClassifier
        {
            private static CoreResponseClassifier _instance;
            public static CoreResponseClassifier Instance => _instance ??= new DpgClassifier();

            public DpgClassifier() : base(stackalloc int[] { 200, 204, 304 })
            {
            }
        }

        private sealed class HeadResponseClassifier : ResponseClassifier
        {
            private static ResponseClassifier _instance;
            public static ResponseClassifier Instance => _instance ??= new HeadResponseClassifier();
            public override bool IsErrorResponse(HttpMessage message)
            {
                return message.Response.Status switch
                {
                    >= 200 and < 300 => false,
                    >= 400 and < 500 => false,
                    _ => true
                };
            }
        }
        #endregion
    }
}
