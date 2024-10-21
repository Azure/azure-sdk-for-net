// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives.TwoWayPipeline;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public abstract class TwoWayPipelineTransport : TwoWayPipelinePolicy
{
    public TwoWayPipelineClientMessage CreateMessage()
    {
        return CreateMessageCore();
    }

    protected abstract TwoWayPipelineClientMessage CreateMessageCore();

    public void Process(TwoWayPipelineClientMessage clientMessage)
    {
        ProcessCore(clientMessage);
    }

    public ValueTask ProcessAsync(TwoWayPipelineClientMessage clientMessage)
    {
        return ProcessCoreAsync(clientMessage);
    }

    public void Process(TwoWayPipelineServiceMessage serviceMessage)
    {
        ProcessCore(serviceMessage);
    }

    public ValueTask ProcessAsync(TwoWayPipelineServiceMessage serviceMessage)
    {
        return ProcessCoreAsync(serviceMessage);
    }

    protected void ProcessCore(TwoWayPipelineClientMessage clientMessage)
    {
        throw new NotImplementedException();
    }

    protected ValueTask ProcessCoreAsync(TwoWayPipelineClientMessage clientMessage)
    {
        throw new NotImplementedException();
    }

    protected void ProcessCore(TwoWayPipelineServiceMessage serviceMessage)
    {
        throw new NotImplementedException();
    }

    protected ValueTask ProcessCoreAsync(TwoWayPipelineServiceMessage serviceMessage)
    {
        throw new NotImplementedException();
    }

    #region TwoWayPipelinePolicy.Process overrides
    public sealed override void Process(TwoWayPipelineClientMessage clientMessage, IReadOnlyList<TwoWayPipelinePolicy> pipeline, int currentIndex)
    {
        Process(clientMessage);

        Debug.Assert(++currentIndex == pipeline.Count, "Transport is not at last position in pipeline.");
    }

    public sealed override async ValueTask ProcessAsync(TwoWayPipelineClientMessage clientMessage, IReadOnlyList<TwoWayPipelinePolicy> pipeline, int currentIndex)
    {
        await ProcessAsync(clientMessage).ConfigureAwait(false);

        Debug.Assert(++currentIndex == pipeline.Count, "Transport is not at last position in pipeline.");
    }

    public sealed override void Process(TwoWayPipelineServiceMessage serviceMessage, IReadOnlyList<TwoWayPipelinePolicy> pipeline, int currentIndex)
    {
        Process(serviceMessage);

        Debug.Assert(++currentIndex == pipeline.Count, "Transport is not at last position in pipeline.");
    }

    public sealed override async ValueTask ProcessAsync(TwoWayPipelineServiceMessage serviceMessage, IReadOnlyList<TwoWayPipelinePolicy> pipeline, int currentIndex)
    {
        await ProcessAsync(serviceMessage).ConfigureAwait(false);

        Debug.Assert(++currentIndex == pipeline.Count, "Transport is not at last position in pipeline.");
    }
    #endregion
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
