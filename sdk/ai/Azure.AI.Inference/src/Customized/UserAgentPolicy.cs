// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;
using Azure.Core;
using System.Threading.Tasks;

namespace Azure.AI.Inference
{
    internal class UserAgentPolicy(string _userAgent) : HttpPipelinePolicy
    {
        private const string _USER_AGENT = "User-Agent";

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            // Add your desired header name and value
            message.Request.Headers.Add(_USER_AGENT, _userAgent);

            ProcessNext(message, pipeline);
        }

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            // Add your desired header name and value
            message.Request.Headers.Add(_USER_AGENT, _userAgent);

            return ProcessNextAsync(message, pipeline);
        }
    }
}
