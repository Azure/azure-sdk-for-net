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

namespace Azure.Core.Perf;

[SimpleJob(RuntimeMoniker.Net60)]
[MemoryDiagnoser]
public class PipelineBenchmark
{
    // Azure.Core pipeline
    private HttpPipeline _httpPipeline;

    // System.ClientModel pipeline
    private ClientPipeline _clientPipeline;

    [GlobalSetup]
    public void SetUp()
    {
        ClientOptions clientOptions = new BenchmarkOptions
        {
            Transport = new HttpClientTransport(new HttpClient(new MockHttpMessageHandler()))
        };

        _httpPipeline = HttpPipelineBuilder.Build(clientOptions);

        ClientPipelineOptions pipelineOptions = new()
        {
            Transport = new HttpClientPipelineTransport(new HttpClient(new MockHttpMessageHandler()))
        };

        _clientPipeline = ClientPipeline.Create(pipelineOptions);
    }

    [Benchmark]
    public async Task CreateAndSendAzureCoreMessage()
    {
        HttpMessage message = _httpPipeline.CreateMessage();
        message.Request.Uri.Reset(new Uri("https://www.example.com"));
        await _httpPipeline.SendAsync(message, CancellationToken.None);
    }

    [Benchmark]
    public async Task CreateAndSendClientModelMessage()
    {
        PipelineMessage message = _clientPipeline.CreateMessage();
        message.Request.Uri = new Uri("https://www.example.com");
        await _clientPipeline.SendAsync(message);
    }

    #region Helpers

    /// <summary>
    /// Mock out the network to isolate the performance test to only
    /// Core library pipeline code.
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
