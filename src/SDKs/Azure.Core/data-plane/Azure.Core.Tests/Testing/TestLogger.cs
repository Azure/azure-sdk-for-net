// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Core.Testing
{
    public class TestLoggingPolicy : HttpPipelinePolicy
    {
        StringBuilder _logged = new StringBuilder();

        public override async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            _logged.Append($"REQUEST: {message.ToString()}\n");
            await ProcessNextAsync(pipeline, message).ConfigureAwait(false);
            _logged.Append($"RESPONSE: {message.Response.Status}\n");
        }

        public override string ToString()
            => _logged.ToString();
    }
}
