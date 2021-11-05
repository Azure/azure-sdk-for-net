// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Perf.Infrastructure;
using Azure.Test.Perf;
using CommandLine;

namespace Azure.Storage.Blobs.Perf
{
    public class DownloadSasUriHttpPipeline : DownloadSasUriTest<DownloadSasUriHttpPipeline.BufferOptions>
    {
        // Stream.CopyToAsync default buffer
        private const int BufferSize = 81920;
        private static readonly HttpPipeline _pipeline = HttpPipelineBuilder.Build(new TestClientOptions());

        public DownloadSasUriHttpPipeline(BufferOptions options) : base(options)
        {
        }

        public override void Run(CancellationToken cancellationToken)
        {
            var message = CreateMessage();
            _pipeline.Send(message, cancellationToken);
            message.Response.ContentStream.CopyTo(Stream.Null, BufferSize);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            var message = CreateMessage();
            await _pipeline.SendAsync(message, cancellationToken);
            await message.Response.ContentStream.CopyToAsync(Stream.Null, BufferSize, cancellationToken);
        }

        private HttpMessage CreateMessage()
        {
            var message = _pipeline.CreateMessage();
            message.BufferResponse = Options.Buffer;
            message.Request.Uri.Reset(SasUri);
            return message;
        }

#pragma warning disable CA1034 // Nested types should not be visible
        public class BufferOptions : SizeOptions {
#pragma warning restore CA1034 // Nested types should not be visible
            [Option("buffer", Default = false, HelpText = "Whether to buffer the response")]
            public bool Buffer { get; set; }
        }

        private class TestClientOptions : ClientOptions { }
    }
}
