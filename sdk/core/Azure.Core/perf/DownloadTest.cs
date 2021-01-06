// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Identity;
using Azure.Test.Perf;

namespace Azure.Template.Perf
{
    public class DownloadTest : PerfTest<DownloadTestOptions>
    {
        // Stream.CopyToAsync default buffer
        private const int BufferSize = 81920;
        private static InProcTestServer _server;
        private static HttpPipeline _pipeline;

        public DownloadTest(DownloadTestOptions options) : base(options)
        {
            _server ??= InProcTestServer.CreateStaticResponse(options.Size);
            _pipeline ??= HttpPipelineBuilder.Build(new DefaultAzureCredentialOptions());
        }

        public override void Run(CancellationToken cancellationToken)
        {
            var message = _pipeline.CreateMessage();
            message.Request.Uri.Reset(_server.Address);

            _pipeline.Send(message, cancellationToken);
            message.Response.ContentStream.CopyTo(Stream.Null, BufferSize);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            var message = _pipeline.CreateMessage();
            message.BufferResponse = Options.Buffer;
            message.Request.Uri.Reset(_server.Address);

            await _pipeline.SendAsync(message, cancellationToken);
            await message.Response.ContentStream.CopyToAsync(Stream.Null, BufferSize, cancellationToken);
        }

        public override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _server.Dispose();
        }
    }
}
