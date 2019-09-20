// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Http;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HttpPipelineFunctionalTests
    {
        [Test]
        public async Task SendRequestBuffersResponse()
        {
            byte[] buffer = { 0 };

            HttpPipeline httpPipeline = HttpPipelineBuilder.Build(new TestOptions());

            using TestServer testServer = new TestServer(
                async context =>
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        await context.Response.Body.WriteAsync(buffer, 0, 1);
                    }
                });
            // Make sure we dispose things correctly and not exhaust the connection pool
            for (int i = 0; i < 100; i++)
            {
                using Request request = httpPipeline.CreateRequest();
                request.UriBuilder.Uri = testServer.Address;

                using Response response = await httpPipeline.SendRequestAsync(request, CancellationToken.None);

                Assert.AreEqual(response.ContentStream.Length, 1000);
            }
        }

        [Test]
        public async Task NonBufferedExtractedStreamReadableAfterMessageDisposed()
        {
            byte[] buffer = { 0 };

            HttpPipeline httpPipeline = HttpPipelineBuilder.Build(new TestOptions());

            using TestServer testServer = new TestServer(
                async context =>
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        await context.Response.Body.WriteAsync(buffer, 0, 1);
                    }
                });

            // Make sure we dispose things correctly and not exhaust the connection pool
            for (int i = 0; i < 100; i++)
            {
                Stream extractedStream;
                using (HttpPipelineMessage message = httpPipeline.CreateMessage())
                {
                    message.Request.UriBuilder.Uri = testServer.Address;
                    message.BufferResponse = false;

                    await httpPipeline.SendAsync(message, CancellationToken.None);

                    Assert.AreEqual(message.Response.ContentStream.CanSeek, false);

                    extractedStream = message.ExtractResponseContent();
                }

                var memoryStream = new MemoryStream();
                await extractedStream.CopyToAsync(memoryStream);
                Assert.AreEqual(memoryStream.Length, 1000);
                extractedStream.Dispose();
            }
        }

        private class TestOptions : ClientOptions
        {
        }
    }
}
