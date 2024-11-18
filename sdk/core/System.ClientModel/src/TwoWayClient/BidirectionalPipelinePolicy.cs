// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives.BidirectionalClients;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public abstract class BidirectionalPipelinePolicy
{
    public abstract void Process(BidirectionalPipelineRequest clientMessage, IReadOnlyList<BidirectionalPipelinePolicy> pipeline, int currentIndex);

    public abstract ValueTask ProcessAsync(BidirectionalPipelineRequest clientMessage, IReadOnlyList<BidirectionalPipelinePolicy> pipeline, int currentIndex);

    protected static void ProcessNext(BidirectionalPipelineRequest clientMessage, IReadOnlyList<BidirectionalPipelinePolicy> pipeline, int currentIndex)
    {
        throw new NotImplementedException();
    }

    protected static ValueTask ProcessNextAsync(BidirectionalPipelineRequest clientMessage, IReadOnlyList<BidirectionalPipelinePolicy> pipeline, int currentIndex)
    {
        throw new NotImplementedException();
    }

    public abstract void Process(BidirectionalPipelineResponse serviceMessage, IReadOnlyList<BidirectionalPipelinePolicy> pipeline, int currentIndex);

    public abstract ValueTask ProcessAsync(BidirectionalPipelineResponse serviceMessage, IReadOnlyList<BidirectionalPipelinePolicy> pipeline, int currentIndex);

    protected static void ProcessNext(BidirectionalPipelineResponse serviceMessage, IReadOnlyList<BidirectionalPipelinePolicy> pipeline, int currentIndex)
    {
        throw new NotImplementedException();
    }

    protected static ValueTask ProcessNextAsync(BidirectionalPipelineResponse serviceMessage, IReadOnlyList<BidirectionalPipelinePolicy> pipeline, int currentIndex)
    {
        throw new NotImplementedException();
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
