// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Http;
using Azure.Base.Http.Pipeline;
using Azure.Base.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Base.Tests
{
    public class PipelineTests
    {
        [Test]
        public async Task Basics()
        {
            var options = new HttpPipelineOptions(new MockTransport(500, 1));
            options.RetryPolicy = new CustomRetryPolicy();

            var pipeline = options.Build("test", "1.0.0");

            var request = pipeline.CreateRequest();
            request.SetRequestLine(HttpVerb.Get, new Uri("https://contoso.a.io"));
            var response = await pipeline.SendRequestAsync(request, CancellationToken.None);

            Assert.AreEqual(1, response.Status);
        }

        [Test]
        public async Task EmptyPipeline()
        {
            var pipeline = new HttpPipeline();
            await pipeline.SendRequestAsync(new NullPipelineContext(), CancellationToken.None);
        }

        class CustomRetryPolicy : RetryPolicy
        {
            protected override bool ShouldRetry(HttpPipelineMessage message, int retry, out TimeSpan delay)
            {
                delay = TimeSpan.Zero;
                if (retry > 5) return false;
                if (message.Response.Status == 1) return false;
                return true;
            }
        }

        class NullPipelineContext : HttpPipelineRequest
        {
            public override void AddHeader(HttpHeader header)
            {
            }

            public override bool TryGetHeader(string name, out string value)
            {
                value = null;
                return false;
            }

            public override IEnumerable<HttpHeader> Headers
            {
                get
                {
                    yield break;
                }
            }

            public override string RequestId { get; set; }

            public override void Dispose()
            {
            }
        }
    }
}
