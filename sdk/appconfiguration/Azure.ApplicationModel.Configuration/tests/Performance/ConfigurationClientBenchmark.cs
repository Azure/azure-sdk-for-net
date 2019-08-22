// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using BenchmarkDotNet.Attributes;

namespace Azure.Data.AppConfiguration.Performance
{
    [MemoryDiagnoser]
    public class ConfigurationClientBenchmark
    {
        private static readonly string MockConnectionString = "Endpoint=https://contoso.appconfig.io;Id=b1d9b31;Secret=aabbccdd";

        private static readonly MockClientHandler GetResponseMessage = new MockClientHandler(request => new HttpResponseMessage((HttpStatusCode)200)
        {
            Content = new ByteArrayContent(GetResponseBytes)
        });

        private static readonly ConfigurationClient ConfigurationClient = new ConfigurationClient(MockConnectionString, new ConfigurationClientOptions()
        {
            Transport = new HttpClientTransport(new HttpClient(GetResponseMessage))
        });

        private static readonly byte[] GetResponseBytes = Encoding.UTF8.GetBytes(
@"{
  ""etag"": ""4f6dd610dd5e4deebc7fbaef685fb903"",
  ""key"": ""key"",
  ""label"": ""label"",
  ""content_type"": null,
  ""value"": ""example value"",
  ""last_modified"": ""2017-12-05T02:41:26+00:00"",
  ""locked"": false,
  ""tags"": {
    ""t1"": ""value1"",
    ""t2"": ""value2""
  }
}");

        [Benchmark]
        public async Task GetAsync()
        {
            await ConfigurationClient.GetAsync("key");
        }


        private class MockClientHandler : HttpClientHandler
        {
            private readonly Func<HttpRequestMessage, HttpResponseMessage> _responseMessage;

            public MockClientHandler(Func<HttpRequestMessage, HttpResponseMessage> responseMessage)
            {
                _responseMessage = responseMessage;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Task.FromResult(_responseMessage(request));
            }
        }
    }
}
