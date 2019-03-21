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

        public override async Task ProcessAsync(HttpPipelineContext pipelineContext, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            _logged.Append($"REQUEST: {pipelineContext.ToString()}\n");
            await ProcessNextAsync(pipeline, pipelineContext).ConfigureAwait(false);
            _logged.Append($"RESPONSE: {pipelineContext.Response.Status}\n");
        }

        public override string ToString()
            => _logged.ToString();
    }
}
