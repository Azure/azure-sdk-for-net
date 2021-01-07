//Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.Sas;
using Azure.Test.Perf;
using Azure.Storage.Blobs.Perf.Core;
using System.Threading;
using System.IO;
using System.Net.Http;
using Azure.Core.Pipeline;
using Azure.Core;

namespace Azure.Storage.Blobs.Perf
{
    public class HttpPipelineDownloadSasUriTest : SasUriTest<BufferOptions>
    {
        // Stream.CopyToAsync default buffer
        private const int BufferSize = 81920;
        private static readonly HttpPipeline _pipeline = HttpPipelineBuilder.Build(new TestClientOptions());

        public HttpPipelineDownloadSasUriTest(BufferOptions options) : base(options)
        {
        }

        public override void Run(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            var message = _pipeline.CreateMessage();
            message.BufferResponse = Options.Buffer;
            message.Request.Uri.Reset(SasUri);

            await _pipeline.SendAsync(message, cancellationToken);
            await message.Response.ContentStream.CopyToAsync(Stream.Null, BufferSize, cancellationToken);
        }

#pragma warning disable CA1034 // Nested types should not be visible
        public class TestClientOptions : ClientOptions { }
#pragma warning restore CA1034 // Nested types should not be visible
    }
}
