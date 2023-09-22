// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core.Pipeline
{
    /// <summary>
    /// TBD.
    /// </summary>
    public abstract class PipelinePolicy
    {
        protected abstract ValueTask ProcessAsync(RestMessage message, ReadOnlyMemory<PipelinePolicy> pipeline);

        protected abstract void Process(RestMessage message, ReadOnlyMemory<PipelinePolicy> pipeline);

        protected static ValueTask ProcessNextAsync(RestMessage message, ReadOnlyMemory<PipelinePolicy> pipeline)
        {
            return pipeline.Span[0].ProcessAsync(message, pipeline.Slice(1));
        }

        protected static void ProcessNext(RestMessage message, ReadOnlyMemory<PipelinePolicy> pipeline)
        {
            pipeline.Span[0].Process(message, pipeline.Slice(1));
        }
    }
}
