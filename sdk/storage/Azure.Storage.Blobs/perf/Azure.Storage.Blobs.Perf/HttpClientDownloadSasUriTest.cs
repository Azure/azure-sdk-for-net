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

namespace Azure.Storage.Blobs.Perf
{
    public class HttpClientDownloadSasUriTest : SasUriTest<BufferOptions>
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public HttpClientDownloadSasUriTest(BufferOptions options) : base(options)
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
    }
}
