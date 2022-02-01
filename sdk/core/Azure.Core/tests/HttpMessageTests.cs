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
            context.AddClassifier(new int[] { 204 }, isError: true);
            message.ApplyRequestContext(context);
            Assert.IsTrue(message.TryClassify(204, out bool isError));
            Assert.IsTrue(isError);
        }

        [Test]
        public void AppliesResponseClassifierNonErrors()
        {
            HttpMessage message = new HttpMessage(new MockRequest(), responseClassifier: null);
            RequestContext context = new RequestContext();
            context.AddClassifier(new int[] { 404 }, isError: false);
            message.ApplyRequestContext(context);
            Assert.IsTrue(message.TryClassify(404, out bool isError));
            Assert.IsFalse(isError);
        }

        [Test]
        public void DoesNotClassify()
        {
            HttpMessage message = new HttpMessage(new MockRequest(), responseClassifier: null);
            RequestContext context = new RequestContext();
            context.AddClassifier(new int[] { 404 }, isError: false);
            message.ApplyRequestContext(context);
            Assert.IsFalse(message.TryClassify(202, out bool isError));
        }
    }
}
