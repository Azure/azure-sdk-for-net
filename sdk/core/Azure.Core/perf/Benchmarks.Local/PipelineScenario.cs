// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Benchmarks.Local
{
    /// <summary>
    /// Represents a scenario for benchmarking the Azure Core pipeline.
    /// </summary>
    public class PipelineScenario
    {
        /// <summary>
        /// The HTTP pipeline used for sending requests.
        /// </summary>
        public readonly HttpPipeline _pipeline;

        /// <summary>
        /// Initializes a new instance of the <see cref="PipelineScenario"/> class.
        /// </summary>
        public PipelineScenario()
        {
            // Update the code to explicitly use the local BenchmarkClientOptions
            var options = new BenchmarkClientOptions
            {
                Transport = new HttpClientTransport(new HttpClient(new MockHttpMessageHandler()))
            };
            _pipeline = HttpPipelineBuilder.Build(options);
        }

        /// <summary>
        /// Sends an HTTP request asynchronously using the pipeline and returns the response.
        /// </summary>
        /// <returns>The HTTP response.</returns>
        public async Task<Azure.Response> SendAsync()
        {
            var message = _pipeline.CreateMessage();
            message.Request.Uri.Reset(new Uri("https://www.example.com"));
            await _pipeline.SendAsync(message, CancellationToken.None).ConfigureAwait(false);
            return message.Response;
        }
    }
}
