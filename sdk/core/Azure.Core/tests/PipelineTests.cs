// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Core.Testing;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Tests
{
    public class PipelineTests
    {
        [Test]
        public async Task Basics()
        {
            var mockTransport = new MockTransport(
                new MockResponse(500),
                new MockResponse(1));

            var pipeline = new HttpPipeline(mockTransport, new[] {
                new RetryPolicy(RetryMode.Exponential, TimeSpan.Zero, TimeSpan.Zero, 5)
            }, responseClassifier: new CustomResponseClassifier());

            Http.Request request = pipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            request.UriBuilder.Uri = new Uri("https://contoso.a.io");
            Response response = await pipeline.SendRequestAsync(request, CancellationToken.None);

            Assert.AreEqual(1, response.Status);
        }

        [Test]
        public void TryGetPropertyReturnsFalseIfNotExist()
        {
            HttpPipelineMessage message = new HttpPipelineMessage(new MockRequest(), new ResponseClassifier(), CancellationToken.None);

            Assert.False(message.TryGetProperty("someName", out _));
        }

        [Test]
        public void TryGetPropertyReturnsValueIfSet()
        {
            HttpPipelineMessage message = new HttpPipelineMessage(new MockRequest(), new ResponseClassifier(), CancellationToken.None);
            message.SetProperty("someName", "value");

            Assert.True(message.TryGetProperty("someName", out object value));
            Assert.AreEqual("value", value);
        }

        [Test]
        public void TryGetPropertyIsCaseSensitive()
        {
            HttpPipelineMessage message = new HttpPipelineMessage(new MockRequest(), new ResponseClassifier(), CancellationToken.None);
            message.SetProperty("someName", "value");


            Assert.False(message.TryGetProperty("SomeName", out _));
        }

        private class CustomResponseClassifier : ResponseClassifier
        {
            public override bool IsRetriableResponse(HttpPipelineMessage message)
            {
                return message.Response.Status == 500;
            }

            public override bool IsRetriableException(Exception exception)
            {
                return false;
            }

            public override bool IsErrorResponse(HttpPipelineMessage message)
            {
                return IsRetriableResponse(message);
            }
        }
    }
}
