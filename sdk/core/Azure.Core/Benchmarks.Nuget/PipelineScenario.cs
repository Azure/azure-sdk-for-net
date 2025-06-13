using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Benchmarks.Nuget
{
    public class PipelineScenario
    {
        public readonly HttpPipeline _pipeline;

        public PipelineScenario()
        {
            var options = new BenchmarkClientOptions
            {
                Transport = new HttpClientTransport(new HttpClient())
            };
            _pipeline = HttpPipelineBuilder.Build(options);
        }

        public async Task<Azure.Response> SendAsync()
        {
            var message = _pipeline.CreateMessage();
            message.Request.Uri.Reset(new Uri("https://www.example.com"));
            await _pipeline.SendAsync(message, CancellationToken.None);
            return message.Response;
        }
    }

    public class BenchmarkClientOptions : ClientOptions { }
}
