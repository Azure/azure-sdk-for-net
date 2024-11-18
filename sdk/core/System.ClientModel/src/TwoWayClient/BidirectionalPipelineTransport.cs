// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives.BidirectionalClients;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public abstract class BidirectionalPipelineTransport : BidirectionalPipelinePolicy
{
    protected BidirectionalPipelineTransport() { }

    public BidirectionalPipelineRequest CreateMessage()
    {
        return CreateMessageCore();
    }

    public void Process(BidirectionalPipelineRequest clientMessage)
    {
        ProcessCore(clientMessage);
    }

    public ValueTask ProcessAsync(BidirectionalPipelineRequest clientMessage)
    {
        return ProcessCoreAsync(clientMessage);
    }

    public void Process(BidirectionalPipelineResponse serviceMessage)
    {
        ProcessCore(serviceMessage);
    }

    public ValueTask ProcessAsync(BidirectionalPipelineResponse serviceMessage)
    {
        return ProcessCoreAsync(serviceMessage);
    }

    protected abstract BidirectionalPipelineRequest CreateMessageCore();

    protected abstract void ProcessCore(BidirectionalPipelineRequest clientMessage);

    protected abstract ValueTask ProcessCoreAsync(BidirectionalPipelineRequest clientMessage);

    protected abstract void ProcessCore(BidirectionalPipelineResponse serviceMessage);

    protected abstract ValueTask ProcessCoreAsync(BidirectionalPipelineResponse serviceMessage);

    #region BidirectionalPipelinePolicy.Process overrides
    public sealed override void Process(BidirectionalPipelineRequest clientMessage, IReadOnlyList<BidirectionalPipelinePolicy> pipeline, int currentIndex)
    {
        Process(clientMessage);

        Debug.Assert(++currentIndex == pipeline.Count, "Transport is not at last position in pipeline.");
    }

    public sealed override async ValueTask ProcessAsync(BidirectionalPipelineRequest clientMessage, IReadOnlyList<BidirectionalPipelinePolicy> pipeline, int currentIndex)
    {
        await ProcessAsync(clientMessage).ConfigureAwait(false);

        Debug.Assert(++currentIndex == pipeline.Count, "Transport is not at last position in pipeline.");
    }

    public sealed override void Process(BidirectionalPipelineResponse serviceMessage, IReadOnlyList<BidirectionalPipelinePolicy> pipeline, int currentIndex)
    {
        Process(serviceMessage);

        Debug.Assert(++currentIndex == pipeline.Count, "Transport is not at last position in pipeline.");
    }

    public sealed override async ValueTask ProcessAsync(BidirectionalPipelineResponse serviceMessage, IReadOnlyList<BidirectionalPipelinePolicy> pipeline, int currentIndex)
    {
        await ProcessAsync(serviceMessage).ConfigureAwait(false);

        Debug.Assert(++currentIndex == pipeline.Count, "Transport is not at last position in pipeline.");
    }
    #endregion
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
