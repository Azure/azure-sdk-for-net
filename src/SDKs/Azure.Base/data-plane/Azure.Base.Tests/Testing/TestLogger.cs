// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Http;
using Azure.Base.Http.Pipeline;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Base.Testing
{
    public class TestLoggingPolicy : HttpPipelinePolicy
    {
        StringBuilder _logged = new StringBuilder();

        public override async Task ProcessAsync(HttpPipelineMessage pipelineMessage, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            _logged.Append($"REQUEST: {pipelineMessage.ToString()}\n");
            await ProcessNextAsync(pipeline, pipelineMessage).ConfigureAwait(false);
            _logged.Append($"RESPONSE: {pipelineMessage.Response.Status}\n");
        }

        public override string ToString()
            => _logged.ToString();
    }
}
