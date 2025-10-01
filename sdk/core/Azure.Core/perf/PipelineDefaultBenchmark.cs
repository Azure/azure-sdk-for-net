// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace Azure.Core.Perf
{
    [SimpleJob(RuntimeMoniker.Net80)]

    [MemoryDiagnoser]
    public class PipelineDefaultBenchmark
    {
        /// <summary>
        /// The HTTP pipeline used for sending requests.
        /// </summary>
        public HttpPipeline _pipeline;

        [GlobalSetup]
        public void SetUp()
        {
            // Update the code to explicitly use the local BenchmarkClientOptions
            var options = new BenchmarkClientOptions
            {
                Transport = new HttpClientTransport(new HttpClient(new MockHttpMessageHandler()))
            };
            _pipeline = HttpPipelineBuilder.Build(options);
        }

        [Benchmark]
        public async Task<Response> CreateAndSendWithDefaultPipeline()
        {
            var message = _pipeline.CreateMessage();
            message.Request.Uri.Reset(new Uri("https://www.example.com"));
            await _pipeline.SendAsync(message, CancellationToken.None).ConfigureAwait(false);
            return message.Response;
        }
    }
}
