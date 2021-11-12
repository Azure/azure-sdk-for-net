// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class PipelineTests : ClientTestBase
    {
        public PipelineTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task PipelineSetsResponseIsErrorTrue()
        {
            var mockTransport = new MockTransport(
                new MockResponse(500));

            var pipeline = new HttpPipeline(mockTransport);

            Request request = pipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://contoso.a.io"));
            Response response = await pipeline.SendRequestAsync(request, CancellationToken.None);

            Assert.IsTrue(response.IsError);
        }

        [Test]
        public async Task PipelineSetsResponseIsErrorFalse()
        {
            var mockTransport = new MockTransport(
                new MockResponse(200));

            var pipeline = new HttpPipeline(mockTransport);

            Request request = pipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://contoso.a.io"));
            Response response = await pipeline.SendRequestAsync(request, CancellationToken.None);

            Assert.IsFalse(response.IsError);
        }

        [Test]
        public async Task CustomClassifierSetsResponseIsError()
        {
            var mockTransport = new MockTransport(
                new MockResponse(404));

            var pipeline = new HttpPipeline(mockTransport, responseClassifier: new CustomResponseClassifier());

            Request request = pipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://contoso.a.io"));
            Response response = await pipeline.SendRequestAsync(request, CancellationToken.None);

            Assert.IsFalse(response.IsError);
        }

        private class CustomResponseClassifier : ResponseClassifier
        {
            public override bool IsRetriableResponse(HttpMessage message)
            {
                return message.Response.Status == 500;
            }

            public override bool IsRetriableException(Exception exception)
            {
                return false;
            }

            public override bool IsErrorResponse(HttpMessage message)
            {
                return IsRetriableResponse(message);
            }
        }
    }
}
