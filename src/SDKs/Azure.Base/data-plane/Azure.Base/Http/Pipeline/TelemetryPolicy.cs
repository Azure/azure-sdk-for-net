// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Base.Http.Pipeline
{
    public class AddHeadersPolicy : HttpPipelineIOAgnosticPolicy
    {
        List<HttpHeader> _headersToAdd = new List<HttpHeader>();

        public void AddHeader(HttpHeader header)
            => _headersToAdd.Add(header);

        public override void OnSendingRequest(HttpPipelineMessage message)
        {
            foreach (var header in _headersToAdd)
            {
                message.Request.AddHeader(header);
            }
        }
    }
}
