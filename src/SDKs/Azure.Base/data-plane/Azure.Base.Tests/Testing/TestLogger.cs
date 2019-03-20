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
        private readonly HttpPipelinePolicy _next;

        public TestLoggingPolicy(HttpPipelinePolicy next)
        {
            _next = next;
        }

        StringBuilder _logged = new StringBuilder();

        public override async Task ProcessAsync(HttpMessage message)
        {
            _logged.Append($"REQUEST: {message.ToString()}\n");
            await _next.ProcessAsync(message).ConfigureAwait(false);
            _logged.Append($"RESPONSE: {message.Response.Status}\n");
        }

        public override string ToString()
            => _logged.ToString();
    }
}
