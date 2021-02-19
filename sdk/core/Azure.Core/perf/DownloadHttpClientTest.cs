// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Template.Perf
{
    public class DownloadHttpClientTest : PerfTest<DownloadTestOptions>
    {
        private static HttpClient _client;
        private static InProcTestServer _server;

        public DownloadHttpClientTest(DownloadTestOptions options) : base(options)
        {
            _server ??= InProcTestServer.CreateStaticResponse(options.Size);
            _client ??= new HttpClient();
        }

        public override void Run(CancellationToken cancellationToken)
        {
#if NET5_0
            using var response = _client.Send(new HttpRequestMessage(HttpMethod.Get, _server.Address), Options.Buffer ? HttpCompletionOption.ResponseContentRead : HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            response.Content.CopyTo(Stream.Null, null, cancellationToken);
#else
            RunAsync(cancellationToken).GetAwaiter().GetResult();
#endif
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            using var response = await _client.GetAsync(_server.Address, Options.Buffer ? HttpCompletionOption.ResponseContentRead : HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            await response.Content.CopyToAsync(Stream.Null);
        }

        public override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _server.Dispose();
        }
    }
}
