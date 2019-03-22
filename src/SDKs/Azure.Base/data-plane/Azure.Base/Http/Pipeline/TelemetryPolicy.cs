﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Base.Http.Pipeline
{
    public class AddHeadersPolicy : HttpPipelinePolicy
    {
        List<HttpHeader> _headersToAdd = new List<HttpHeader>();

        public void AddHeader(HttpHeader header)
            => _headersToAdd.Add(header);

        public override async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            foreach (var header in _headersToAdd) message.Request.AddHeader(header);
            await ProcessNextAsync(pipeline, message).ConfigureAwait(false);
        }
    }
}
