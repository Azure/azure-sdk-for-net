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
    // TODO (pri 2): Do use the EventRegister NuGet package or the standalone eventRegister.exe tool, to run build-time validation of the event source classes defined in your assemblies.
    public class PipelineTests
    {
        string expected = @"ProcessingRequest : Get https://contoso.a.io/ # ErrorResponse : 500 # ProcessingResponse : Get https://contoso.a.io/ # ProcessingRequest : Get https://contoso.a.io/ # ProcessingResponse : Get https://contoso.a.io/";

        [Test]
        public async Task Basics() {

            var options = new HttpPipelineOptions(new MockTransport(500, 1));
            options.RetryPolicy = new CustomRetryPolicy();
            options.LoggingPolicy = new LoggingPolicy();

            var listener = new TestEventListener();
            listener.EnableEvents(EventLevel.LogAlways);

            var pipeline = options.Build("test", "1.0.0");

            var request = pipeline.CreateRequest();
            request.SetRequestLine(HttpVerb.Get, new Uri("https://contoso.a.io"));
            var response = await pipeline.SendRequestAsync(request, CancellationToken.None);

            Assert.AreEqual(1, response.Status);
            var result = listener.ToString();
            Assert.AreEqual(expected, result);
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

            public override IEnumerable<HttpHeader> GetHeaders()
            {
                yield break;
            }

            public override void Dispose()
            {
            }
        }
    }
}
