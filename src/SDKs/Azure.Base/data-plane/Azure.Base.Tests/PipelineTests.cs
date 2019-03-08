// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Http;
using Azure.Base.Http.Pipeline;
using Azure.Base.Testing;
using NUnit.Framework;
using System;
using System.Diagnostics.Tracing;

namespace Azure.Base.Tests
{
    // TODO (pri 2): Do use the EventRegister NuGet package or the standalone eventRegister.exe tool, to run build-time validation of the event source classes defined in your assemblies.
    public class PipelineTests
    {
        string expected = @"ProcessingRequest : Get https://contoso.a.io/ # ErrorResponse : 500 # ProcessingResponse : Get https://contoso.a.io/ # ProcessingRequest : Get https://contoso.a.io/ # ProcessingResponse : Get https://contoso.a.io/";

        [Test]
        public void Basics() {

            var options = new HttpPipeline.Options();
            options.Transport = new MockTransport(500, 1);
            options.RetryPolicy = new CustomRetryPolicy();

            var listener = new TestEventListener();
            listener.EnableEvents(EventLevel.LogAlways);

            var pipeline = HttpPipeline.Create(options, "test", "1.0.0");

            using (var message = pipeline.CreateMessage(options, cancellation: default))
            {
                message.SetRequestLine(HttpVerb.Get, new Uri("https://contoso.a.io"));
                pipeline.SendMessageAsync(message).Wait();

                Assert.AreEqual(1, message.Response.Status);
                var result = listener.ToString();
                Assert.AreEqual(expected, result);
            }
        }

        class CustomRetryPolicy : RetryPolicy
        {
            protected override bool ShouldRetry(HttpMessage message, int retry, out TimeSpan delay)
            {
                delay = TimeSpan.Zero;
                if (retry > 5) return false;
                if (message.Response.Status == 1) return false;
                return true;
            }
        }
    }
}
