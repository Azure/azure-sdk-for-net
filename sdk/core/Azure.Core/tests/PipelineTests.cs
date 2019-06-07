﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;
using Azure.Core.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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

            var pipeline = new HttpPipeline(mockTransport, new [] { new FixedRetryPolicy() { Delay = TimeSpan.Zero, MaxRetries = 5 } }, responseClassifier: new CustomResponseClassifier());

            var request = pipeline.CreateRequest();
            request.SetRequestLine(HttpPipelineMethod.Get, new Uri("https://contoso.a.io"));
            var response = await pipeline.SendRequestAsync(request, CancellationToken.None);

            Assert.AreEqual(1, response.Status);
        }

        [Test]
        public void TryGetPropertyReturnsFalseIfNotExist()
        {
            HttpPipelineMessage message = new HttpPipelineMessage(CancellationToken.None);

            Assert.False(message.TryGetProperty("someName", out _));
        }

        [Test]
        public void TryGetPropertyReturnsValueIfSet()
        {
            HttpPipelineMessage message = new HttpPipelineMessage(CancellationToken.None);
            message.SetProperty("someName", "value");

            Assert.True(message.TryGetProperty("someName", out object value));
            Assert.AreEqual("value", value);
        }

        [Test]
        public void TryGetPropertyIsCaseSensitive()
        {
            HttpPipelineMessage message = new HttpPipelineMessage(CancellationToken.None);
            message.SetProperty("someName", "value");

            Assert.False(message.TryGetProperty("SomeName", out object value));
        }

        class CustomResponseClassifier : ResponseClassifier
        {
            public override bool IsRetriableResponse(Response response)
            {
                return response.Status == 500;
            }

            public override bool IsRetriableException(Exception exception)
            {
                return false;
            }

            public override bool IsErrorResponse(Response response)
            {
                return IsRetriableResponse(response);
            }
        }
    }
}
