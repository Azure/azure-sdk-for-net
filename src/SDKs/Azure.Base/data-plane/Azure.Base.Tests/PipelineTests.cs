// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Http;
using Azure.Base.Http.Pipeline;
using Azure.Base.Testing;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Azure.Base.Tests
{
    public class PipelineTests
    {
        [Test]
        public void Basics()
        {
            var options = new HttpPipelineOptions(new MockTransport(500, 1));
            options.RetryPolicy = new CustomRetryPolicy();

            var pipeline = options.Build("test", "1.0.0");

            using (var message = pipeline.CreateMessage(cancellation: default))
            {
                message.SetRequestLine(HttpVerb.Get, new Uri("https://contoso.a.io"));
                pipeline.SendMessageAsync(message).Wait();

                Assert.AreEqual(1, message.Response.Status);
            }
        }

        [Test]
        public async Task EmptyPipeline()
        {
            var pipeline = new HttpPipeline();
            await pipeline.SendMessageAsync(new NullMessage());
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

        class NullMessage : HttpMessage
        {
            public NullMessage() : base(default) { }
            public override HttpVerb Method => throw new NotImplementedException();

            protected internal override int Status => throw new NotImplementedException();

            protected internal override Stream ResponseContentStream => throw new NotImplementedException();

            public override void AddHeader(HttpHeader header)
            {
                throw new NotImplementedException();
            }

            public override void SetContent(HttpMessageContent content)
            {
                throw new NotImplementedException();
            }

            public override void SetRequestLine(HttpVerb method, Uri uri)
            {
                throw new NotImplementedException();
            }

            protected internal override bool TryGetHeader(ReadOnlySpan<byte> name, out ReadOnlySpan<byte> value)
            {
                throw new NotImplementedException();
            }
        }
    }
}
