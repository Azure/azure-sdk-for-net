// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Core.Testing
{
    public class TestLoggingPolicy : SynchronousHttpPipelinePolicy
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
