using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Benchmarks.Local
{
    public class PipelineScenario
    {
        public readonly HttpPipeline _pipeline;

        public PipelineScenario()
        {
            var options = new BenchmarkClientOptions
            {
                Transport = new HttpClientTransport(new HttpClient(new MockHttpMessageHandler()))
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

    /// <summary>
    /// Mock out the network to isolate the performance test to only
    /// Core library pipeline code.
    /// </summary>
    internal class MockHttpMessageHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage httpResponse = new()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("Mock Content")
            };

            httpResponse.Headers.Add("MockHeader1", "Mock Header Value");
            httpResponse.Headers.Add("MockHeader2", "Mock Header Value");

            return Task.FromResult(httpResponse);
        }
    }
    public class BenchmarkClientOptions : ClientOptions { }
}
