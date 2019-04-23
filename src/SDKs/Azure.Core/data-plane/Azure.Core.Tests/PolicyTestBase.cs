// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core.Tests
{
    public abstract class PolicyTestBase
    {
        protected static Task<Response> SendGetRequest(HttpPipelineTransport transport, HttpPipelinePolicy policy)
        {
            using (Request request = transport.CreateRequest(null))
            {
                request.Method = HttpPipelineMethod.Get;
                request.UriBuilder.Uri = new Uri("http://example.com");
                var pipeline = new HttpPipeline(transport, new [] { policy });
                return pipeline.SendRequestAsync(request, CancellationToken.None);
            }
        }
    }
}
