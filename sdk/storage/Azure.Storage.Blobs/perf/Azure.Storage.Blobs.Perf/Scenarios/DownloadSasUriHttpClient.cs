// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Perf.Infrastructure;
using Azure.Test.Perf;
using CommandLine;

namespace Azure.Storage.Blobs.Perf
{
    public class DownloadSasUriHttpClient : DownloadSasUriTest<DownloadSasUriHttpClient.BufferOptions>
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public DownloadSasUriHttpClient(BufferOptions options) : base(options)
        {
        }

        public override void Run(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            using var response = await _httpClient.GetAsync(
                SasUri,
                Options.Buffer ? HttpCompletionOption.ResponseContentRead : HttpCompletionOption.ResponseHeadersRead,
                cancellationToken
                );

#pragma warning disable CA2016 // Forward the 'CancellationToken' parameter to methods that take one
            await response.Content.CopyToAsync(Stream.Null);
#pragma warning restore CA2016 // Forward the 'CancellationToken' parameter to methods that take one
        }

#pragma warning disable CA1034 // Nested types should not be visible
        public class BufferOptions : SizeOptions
        {
#pragma warning restore CA1034 // Nested types should not be visible
            [Option("buffer", Default = false, HelpText = "Whether to buffer the response")]
            public bool Buffer { get; set; }
        }
    }
}
