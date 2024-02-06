// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace ClientModel.Tests.Internal.Perf;

[SimpleJob(RuntimeMoniker.Net60)]
[MemoryDiagnoser]
public class ClientPipelineBenchmark
{
    private ClientPipeline _pipeline;

    [GlobalSetup]
    public void SetUp()
    {
        ClientPipelineOptions options = new()
        {
            Transport = new HttpClientPipelineTransport(new HttpClient(new MockHttpMessageHandler()))
        };

        _pipeline = ClientPipeline.Create(options);
    }

    [Benchmark]
    public async Task CreateAndSendMessage()
    {
        PipelineMessage message = _pipeline.CreateMessage();
        message.Request.Uri = new Uri("https://www.example.com");
        await _pipeline.SendAsync(message);
    }

    #region Helpers

    /// <summary>
    /// Mock out the network to isolate the performance test to only
    /// System.ClientModel pipeline code.
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

    #endregion
}
