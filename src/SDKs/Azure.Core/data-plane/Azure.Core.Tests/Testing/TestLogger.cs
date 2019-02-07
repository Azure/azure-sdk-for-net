// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core.Http;
using Azure.Core.Http.Pipeline;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Core.Testing
{
    public class TestLoggingPolicy : PipelinePolicy
    {
        StringBuilder _logged = new StringBuilder();

        public override async Task ProcessAsync(HttpMessage message, ReadOnlyMemory<PipelinePolicy> pipeline)
        {
            _logged.Append($"REQUEST: {message.ToString()}\n");
            await ProcessNextAsync(pipeline, message).ConfigureAwait(false);
            _logged.Append($"RESPONSE: {message.Response.Status}\n");
        }

        public override string ToString()
            => _logged.ToString();
    }
}
