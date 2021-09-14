// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Test.Perf;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Sample.Perf
{
    public class HttpPipelineGetTest : PerfTest<UriOptions>
    {
        private HttpPipeline _httpPipeline;

        public HttpPipelineGetTest(UriOptions options) : base(options)
        {
            _httpPipeline = HttpPipelineBuilder.Build(ConfigureClientOptions(new HttpPipelineGetOptions()));
        }

        public override void Run(CancellationToken cancellationToken)
        {
            var response = _httpPipeline.SendRequest(CreateRequest(), cancellationToken);
            response.ContentStream.CopyTo(Stream.Null);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            var response = await _httpPipeline.SendRequestAsync(CreateRequest(), cancellationToken);
            await response.ContentStream.CopyToAsync(Stream.Null);
        }

        // Request object should not be re-used across distinct requests
        private Request CreateRequest()
        {
            var request = _httpPipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(Options.Uri);
            return request;
        }

        private class HttpPipelineGetOptions : ClientOptions { }
    }
}
