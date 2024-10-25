// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives.TwoWayCommunication;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public abstract class TwoWayPipelinePolicy
{
    public abstract void Process(TwoWayPipelineClientMessage clientMessage, IReadOnlyList<TwoWayPipelinePolicy> pipeline, int currentIndex);

    public abstract ValueTask ProcessAsync(TwoWayPipelineClientMessage clientMessage, IReadOnlyList<TwoWayPipelinePolicy> pipeline, int currentIndex);

    protected static void ProcessNext(TwoWayPipelineClientMessage clientMessage, IReadOnlyList<TwoWayPipelinePolicy> pipeline, int currentIndex)
    {
        throw new NotImplementedException();
    }

    protected static ValueTask ProcessNextAsync(TwoWayPipelineClientMessage clientMessage, IReadOnlyList<TwoWayPipelinePolicy> pipeline, int currentIndex)
    {
        throw new NotImplementedException();
    }

    public abstract void Process(TwoWayPipelineServiceMessage serviceMessage, IReadOnlyList<TwoWayPipelinePolicy> pipeline, int currentIndex);

    public abstract ValueTask ProcessAsync(TwoWayPipelineServiceMessage serviceMessage, IReadOnlyList<TwoWayPipelinePolicy> pipeline, int currentIndex);

    protected static void ProcessNext(TwoWayPipelineServiceMessage serviceMessage, IReadOnlyList<TwoWayPipelinePolicy> pipeline, int currentIndex)
    {
        throw new NotImplementedException();
    }

    protected static ValueTask ProcessNextAsync(TwoWayPipelineServiceMessage serviceMessage, IReadOnlyList<TwoWayPipelinePolicy> pipeline, int currentIndex)
    {
        throw new NotImplementedException();
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
