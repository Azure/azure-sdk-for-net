// Copyright (c) Microsoft Corporation. All rights reserved.
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
/* Issue https://github.com/Azure/azure-sdk-for-net/issues/5773 test skipped for net461 */
#if !FullNetFx
        [Test]
        public async Task Basics()
        {
            var mockTransport = new MockTransport(
                new MockResponse(500),
                new MockResponse(1));

            var pipeline = new HttpPipeline(mockTransport, new [] { new CustomRetryPolicy() });

            var request = pipeline.CreateRequest();
            request.SetRequestLine(HttpPipelineMethod.Get, new Uri("https://contoso.a.io"));
            var response = await pipeline.SendRequestAsync(request, CancellationToken.None);

            Assert.AreEqual(1, response.Status);
        }
#endif

/* Issue https://github.com/Azure/azure-sdk-for-net/issues/5773 test skipped for net461 */
#if !FullNetFx
        class CustomRetryPolicy : RetryPolicy
        {
            protected override bool IsRetriableResponse(HttpPipelineMessage message, int attempted, out TimeSpan delay)
            {
                delay = TimeSpan.Zero;
                if (attempted > 5) return false;
                if (message.Response.Status == 1) return false;
                return true;
            }

            protected override bool IsRetriableException(Exception exception, int attempted, out TimeSpan delay)
            {
                return false;
            }
        }
#endif

        class TestClientOptions : HttpClientOptions
        {
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
