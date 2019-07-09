// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Http;
using Azure.Core.Pipeline;

namespace Azure.Core.Tests
{
    public class PipelineTestBase
    {
        protected static async Task<Response> ExecuteRequest(Request request, HttpClientTransport transport)
        {
            var message = new HttpPipelineMessage(CancellationToken.None) { Request = request };
            await transport.ProcessAsync(message);
            return message.Response;
        }
    }
}
