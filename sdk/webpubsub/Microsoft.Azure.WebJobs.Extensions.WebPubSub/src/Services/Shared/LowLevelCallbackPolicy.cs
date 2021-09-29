// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;

#nullable enable

namespace Azure.Core.Pipeline
{
    // Chain to RequestOptions.PerCallPolicy if added to a request
    internal class LowLevelCallbackPolicy : HttpPipelinePolicy
    {
        private const string RequestOptionsKey = "RequestOptionsPerCallPolicyCallback";
        public LowLevelCallbackPolicy()
        {
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            if (message.TryGetProperty(RequestOptionsKey, out object? value))
            {
                if (value is HttpPipelineSynchronousPolicy policy)
                {
                    policy.Process(message, pipeline);
                    return;
                }
            }
            ProcessNext(message, pipeline);
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            if (message.TryGetProperty(RequestOptionsKey, out object? value))
            {
                if (value is HttpPipelineSynchronousPolicy policy)
                {
                    await policy.ProcessAsync(message, pipeline).ConfigureAwait(false);
                    return;
                }
            }
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
        }
    }
}
