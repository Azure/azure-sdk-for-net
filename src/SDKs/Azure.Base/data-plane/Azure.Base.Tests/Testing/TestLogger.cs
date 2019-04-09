// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Http;
using Azure.Base.Http.Pipeline;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Base.Testing
{
    public class TestLoggingPolicy : HttpPipelineIOAgnosticPolicy
    {
        StringBuilder _logged = new StringBuilder();

        public override void OnSendingRequest(HttpPipelineMessage message)
        {
            _logged.Append($"REQUEST: {message.ToString()}\n");
        }

        public override void OnReceivedResponse(HttpPipelineMessage message)
        {
            _logged.Append($"RESPONSE: {message.Response.Status}\n");
        }

        public override string ToString()
            => _logged.ToString();
    }
}
