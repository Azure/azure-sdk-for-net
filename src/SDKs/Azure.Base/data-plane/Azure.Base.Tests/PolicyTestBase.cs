// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Base.Http;
using Azure.Base.Http.Pipeline;

namespace Azure.Base.Tests
{
    public abstract class PolicyTestBase
    {
        protected static Task<Response> SendGetRequest(HttpPipelineTransport transport, HttpPipelinePolicy policy)
        {
            using (HttpPipelineRequest request = transport.CreateRequest(null))
            {
                request.Method = HttpPipelineMethod.Get;
                request.UriBuilder.Uri = new Uri("http://example.com");
                var pipeline = new HttpPipeline(transport, new [] { policy });
                return pipeline.SendRequestAsync(request, CancellationToken.None);
            }
        }
    }
}
