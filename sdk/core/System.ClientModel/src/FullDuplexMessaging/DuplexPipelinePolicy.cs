// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives.FullDuplexMessaging;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public abstract class DuplexPipelinePolicy
{
    public abstract void Process(DuplexPipelineRequest clientMessage, IReadOnlyList<DuplexPipelinePolicy> pipeline, int currentIndex);

    public abstract ValueTask ProcessAsync(DuplexPipelineRequest clientMessage, IReadOnlyList<DuplexPipelinePolicy> pipeline, int currentIndex);

    protected static void ProcessNext(DuplexPipelineRequest clientMessage, IReadOnlyList<DuplexPipelinePolicy> pipeline, int currentIndex)
    {
        throw new NotImplementedException();
    }

    protected static ValueTask ProcessNextAsync(DuplexPipelineRequest clientMessage, IReadOnlyList<DuplexPipelinePolicy> pipeline, int currentIndex)
    {
        throw new NotImplementedException();
    }

    public abstract void Process(DuplexPipelineResponse serviceMessage, IReadOnlyList<DuplexPipelinePolicy> pipeline, int currentIndex);

    public abstract ValueTask ProcessAsync(DuplexPipelineResponse serviceMessage, IReadOnlyList<DuplexPipelinePolicy> pipeline, int currentIndex);

    protected static void ProcessNext(DuplexPipelineResponse serviceMessage, IReadOnlyList<DuplexPipelinePolicy> pipeline, int currentIndex)
    {
        throw new NotImplementedException();
    }

    protected static ValueTask ProcessNextAsync(DuplexPipelineResponse serviceMessage, IReadOnlyList<DuplexPipelinePolicy> pipeline, int currentIndex)
    {
        throw new NotImplementedException();
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
