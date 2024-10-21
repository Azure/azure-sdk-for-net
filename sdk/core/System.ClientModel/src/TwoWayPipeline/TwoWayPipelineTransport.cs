// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives.TwoWayPipeline;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class TwoWayPipelineTransport : TwoWayPipelinePolicy
{
    public override void Process(TwoWayPipelineClientMessage clientMessage, IReadOnlyList<TwoWayPipelinePolicy> pipeline, int currentIndex)
    {
        throw new NotImplementedException();
    }

    public override ValueTask ProcessAsync(TwoWayPipelineClientMessage clientMessage, IReadOnlyList<TwoWayPipelinePolicy> pipeline, int currentIndex)
    {
        throw new NotImplementedException();
    }

    public override void Process(TwoWayPipelineServiceMessage serviceMessage, IReadOnlyList<TwoWayPipelinePolicy> pipeline, int currentIndex)
    {
        throw new NotImplementedException();
    }

    public override ValueTask ProcessAsync(TwoWayPipelineServiceMessage serviceMessage, IReadOnlyList<TwoWayPipelinePolicy> pipeline, int currentIndex)
    {
        throw new NotImplementedException();
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
