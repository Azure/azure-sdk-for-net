// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    public abstract class HttpPipelineSynchronousPolicy : HttpPipelinePolicy
    {
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            OnSendingRequest(message);
            ProcessNext(message, pipeline);
            OnReceivedResponse(message);
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            OnSendingRequest(message);
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            OnReceivedResponse(message);
        }

        public virtual void OnSendingRequest(HttpMessage message) { }

        public virtual void OnReceivedResponse(HttpMessage message) { }
    }
}
