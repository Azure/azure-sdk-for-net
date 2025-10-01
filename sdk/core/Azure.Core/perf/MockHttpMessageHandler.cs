// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Core.Perf
{
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
}
