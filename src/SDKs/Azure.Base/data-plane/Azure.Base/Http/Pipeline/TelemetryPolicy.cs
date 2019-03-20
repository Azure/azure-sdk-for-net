// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Base.Http.Pipeline
{
    internal class AddHeadersPolicy : HttpPipelinePolicy
    {
        private readonly HttpPipelinePolicy _next;

        private readonly HttpHeader[] _headersToAdd;

        public AddHeadersPolicy(HttpPipelinePolicy next, params HttpHeader[] headersToAdd)
        {
            _next = next;
            _headersToAdd = headersToAdd;
        }

        public override async Task ProcessAsync(HttpMessage message)
        {
            foreach (var header in _headersToAdd) message.AddHeader(header);
            await _next.ProcessAsync(message).ConfigureAwait(false);
        }
    }
}
