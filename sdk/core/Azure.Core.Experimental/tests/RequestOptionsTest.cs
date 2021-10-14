// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class RequestOptionsTest
    {
        [Test]
        public void CanOverrideDefaultClassificationSuccess()
        {
            var m = CreateTestMessage(404);

            var options = new RequestOptions();
            options.AddClassifier(new[] { 404 }, ResponseClassification.Success);

            RequestOptions.Apply(options, m);

            Assert.False(m.ResponseClassifier.IsErrorResponse(m));
        }

        [Test]
        public void CanOverrideDefaultClassificationThrow()
        {
            var m = CreateTestMessage(200);

            var options = new RequestOptions();
            options.AddClassifier(new[] { 200 }, ResponseClassification.Throw);

            RequestOptions.Apply(options, m);

            Assert.True(m.ResponseClassifier.IsErrorResponse(m));
        }

        [Test]
        public void CanOverrideDefaultClassificationRetry()
        {
            var m = CreateTestMessage(200);

            var options = new RequestOptions();
            options.AddClassifier(new[] { 200 }, ResponseClassification.Retry);

            RequestOptions.Apply(options, m);

            Assert.True(m.ResponseClassifier.IsRetriableResponse(m));
        }

        [Test]
        public void CanOverrideDefaultClassificationNoRetry()
        {
            var m = CreateTestMessage(500);

            var options = new RequestOptions();
            options.AddClassifier(new[] { 500 }, ResponseClassification.DontRetry);

            RequestOptions.Apply(options, m);

            Assert.False(m.ResponseClassifier.IsRetriableResponse(m));
        }

        [Test]
        public void CanOverrideDefaultClassificationWithFunc()
        {
            HttpMessage m = new HttpMessage(new MockRequest(), new ResponseClassifier())
            {
                Response = new MockResponse(500)
            };

            var options = new RequestOptions();
            options.AddClassifier(_ => ResponseClassification.Success);

            RequestOptions.Apply(options, m);

            Assert.False(m.ResponseClassifier.IsErrorResponse(m));
        }

        private static HttpMessage CreateTestMessage(int status)
        {
            HttpMessage m = new HttpMessage(new MockRequest(), new ResponseClassifier())
            {
                Response = new MockResponse(status)
            };
            return m;
        }
    }
}