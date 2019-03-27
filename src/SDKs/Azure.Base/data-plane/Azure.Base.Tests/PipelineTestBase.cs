// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Base.Http;
using Azure.Base.Http.Pipeline;

namespace Azure.Base.Tests
{
    public class PipelineTestBase
    {
        protected static async Task<HttpPipelineResponse> ExecuteRequest(HttpPipelineRequest request, HttpClientTransport transport)
        {
            using (var message = new HttpPipelineMessage(CancellationToken.None)
            {
                Request = request
            })
            {
                await transport.ProcessAsync(message);
                return message.Response;
            }
        }
    }
}