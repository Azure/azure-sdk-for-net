// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core.Tests
{
    public abstract class PolicyTestBase
    {
        protected static Task<Response> SendGetRequest(HttpPipelineTransport transport, HttpPipelinePolicy policy)
        {
            var pipeline = new HttpPipeline(transport, new [] { policy });
            using (HttpPipelineRequest request = pipeline.CreateSampleGetRequest())
            {
                return pipeline.SendRequestAsync(request, CancellationToken.None);
            }
        }
    }
}
