// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Azure.Core.Perf;

[SimpleJob(RuntimeMoniker.Net60)]
public class HttpPipelineBenchmark
{
    private HttpPipeline _pipeline;

    [GlobalSetup]
    public void SetUp()
    {
        ClientOptions options = new BenchmarkOptions
        {
            Transport = new HttpClientTransport(new HttpClient(new MockHttpMessageHandler()))
        };

        _pipeline = HttpPipelineBuilder.Build(options);
    }

    [Benchmark]
    public async Task CreateAndSendMessage()
    {
        HttpMessage message = _pipeline.CreateMessage();
        message.Request.Uri.Reset(new Uri("https://www.example.com"));
        await _pipeline.SendAsync(message, CancellationToken.None);
    }

    #region Helpers

    /// <summary>
    /// Mock out the network to isolate the performance test to only
    /// Azure.Core pipeline code.
    /// </summary>
    private class MockHttpMessageHandler : HttpMessageHandler
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

    private class BenchmarkOptions : ClientOptions
    {
    }

    #endregion
}
