// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Test.Perf;
using CommandLine;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Sample.Perf
{
    public class HttpPipelineGetTest : PerfTest<HttpPipelineGetTest.HttpPipelineGetOptions>
    {
        private HttpPipeline _httpPipeline;
        private bool _firstRun = true;

        public HttpPipelineGetTest(HttpPipelineGetOptions options) : base(options)
        {
            _httpPipeline = HttpPipelineBuilder.Build(ConfigureClientOptions(new HttpPipelineGetClientOptions()));
        }

        public override void Run(CancellationToken cancellationToken)
        {
            Response response;

            if (_firstRun)
            {
                for (var i=0; i < Options.FirstRunExtraRequests; i++)
                {
                    response = _httpPipeline.SendRequest(CreateRequest(), cancellationToken);
                    response.ContentStream.CopyTo(Stream.Null);
                }
                _firstRun = false;
            }

            response = _httpPipeline.SendRequest(CreateRequest(), cancellationToken);
            response.ContentStream.CopyTo(Stream.Null);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            Response response;

            if (_firstRun)
            {
                for (var i=0; i < Options.FirstRunExtraRequests; i++)
                {
                    response = await _httpPipeline.SendRequestAsync(CreateRequest(), cancellationToken);
                    await response.ContentStream.CopyToAsync(Stream.Null);
                }
                _firstRun = false;
            }

            response = await _httpPipeline.SendRequestAsync(CreateRequest(), cancellationToken);
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

        private class HttpPipelineGetClientOptions : ClientOptions { }

        public class HttpPipelineGetOptions : UriOptions {
            [Option("first-run-extra-requests", Default = 0, HelpText = "Extra requests to send on first run. " +
                "Simulates SDKs which require extra requests (like authentication) on first API call.")]
            public int FirstRunExtraRequests { get; set; }
        }
    }
}
