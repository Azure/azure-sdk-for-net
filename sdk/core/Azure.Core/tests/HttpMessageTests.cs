// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            HttpMessage message = new HttpMessage(new MockRequest(), responseClassifier: null);
            RequestContext context = new RequestContext();
            context.AddClassifier(204, isError: true);
            message.ApplyRequestContext(context);
            Assert.IsTrue(message.ResponseClassifier.IsError(message));
        }

        [Test]
        public void AppliesResponseClassifierNonErrors()
        {
            HttpMessage message = new HttpMessage(new MockRequest(), responseClassifier: null);
            RequestContext context = new RequestContext();
            context.AddClassifier(404, isError: false);
            message.ApplyRequestContext(context);
            message.Response = new MockResponse(404);
            Assert.IsFalse(message.ResponseClassifier.IsError(message));
        }

        [Test]
        public void AppliesResponseClassifierBothErrorsAndNonErrors()
        {
            HttpMessage message = new HttpMessage(new MockRequest(), responseClassifier: null);
            RequestContext context = new RequestContext();
            context.AddClassifier(404, isError: false);
            context.AddClassifier(301, isError: true);
            context.AddClassifier(304, isError: true);
            message.ApplyRequestContext(context);

            message.Response = new MockResponse(404);
            Assert.IsFalse(message.ResponseClassifier.IsError(message));

            message.Response = new MockResponse(301);
            Assert.IsTrue(message.ResponseClassifier.IsError(message));

            message.Response = new MockResponse(304);
            Assert.IsTrue(message.ResponseClassifier.IsError(message));
        }
    }
}
