// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives.FullDuplexMessaging;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public abstract class DuplexPipelineTransport : DuplexPipelinePolicy
{
    protected DuplexPipelineTransport() { }

    public DuplexPipelineRequest CreateMessage()
    {
        return CreateMessageCore();
    }

    public void Process(DuplexPipelineRequest clientMessage)
    {
        ProcessCore(clientMessage);
    }

    public ValueTask ProcessAsync(DuplexPipelineRequest clientMessage)
    {
        return ProcessCoreAsync(clientMessage);
    }

    public void Process(DuplexPipelineResponse serviceMessage)
    {
        ProcessCore(serviceMessage);
    }

    public ValueTask ProcessAsync(DuplexPipelineResponse serviceMessage)
    {
        return ProcessCoreAsync(serviceMessage);
    }

    protected abstract DuplexPipelineRequest CreateMessageCore();

    protected abstract void ProcessCore(DuplexPipelineRequest clientMessage);

    protected abstract ValueTask ProcessCoreAsync(DuplexPipelineRequest clientMessage);

    protected abstract void ProcessCore(DuplexPipelineResponse serviceMessage);

    protected abstract ValueTask ProcessCoreAsync(DuplexPipelineResponse serviceMessage);

    #region DuplexPipelinePolicy.Process overrides
    public sealed override void Process(DuplexPipelineRequest clientMessage, IReadOnlyList<DuplexPipelinePolicy> pipeline, int currentIndex)
    {
        Process(clientMessage);

        Debug.Assert(++currentIndex == pipeline.Count, "Transport is not at last position in pipeline.");
    }

    public sealed override async ValueTask ProcessAsync(DuplexPipelineRequest clientMessage, IReadOnlyList<DuplexPipelinePolicy> pipeline, int currentIndex)
    {
        await ProcessAsync(clientMessage).ConfigureAwait(false);

        Debug.Assert(++currentIndex == pipeline.Count, "Transport is not at last position in pipeline.");
    }

    public sealed override void Process(DuplexPipelineResponse serviceMessage, IReadOnlyList<DuplexPipelinePolicy> pipeline, int currentIndex)
    {
        Process(serviceMessage);

        Debug.Assert(++currentIndex == pipeline.Count, "Transport is not at last position in pipeline.");
    }

    public sealed override async ValueTask ProcessAsync(DuplexPipelineResponse serviceMessage, IReadOnlyList<DuplexPipelinePolicy> pipeline, int currentIndex)
    {
        await ProcessAsync(serviceMessage).ConfigureAwait(false);

        Debug.Assert(++currentIndex == pipeline.Count, "Transport is not at last position in pipeline.");
    }
    #endregion
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
