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

    public DuplexPipelineRequest CreateRequest()
    {
        return CreateRequestCore();
    }

    public void Process(DuplexPipelineRequest request)
    {
        ProcessCore(request);
    }

    public ValueTask ProcessAsync(DuplexPipelineRequest request)
    {
        return ProcessCoreAsync(request);
    }

    public void Process(DuplexPipelineResponse response)
    {
        ProcessCore(response);
    }

    public ValueTask ProcessAsync(DuplexPipelineResponse response)
    {
        return ProcessCoreAsync(response);
    }

    protected abstract DuplexPipelineRequest CreateRequestCore();

    protected abstract void ProcessCore(DuplexPipelineRequest request);

    protected abstract ValueTask ProcessCoreAsync(DuplexPipelineRequest request);

    protected abstract void ProcessCore(DuplexPipelineResponse response);

    protected abstract ValueTask ProcessCoreAsync(DuplexPipelineResponse response);

    #region DuplexPipelinePolicy.Process overrides
    public sealed override void Process(DuplexPipelineRequest request, IReadOnlyList<DuplexPipelinePolicy> pipeline, int currentIndex)
    {
        Process(request);

        Debug.Assert(++currentIndex == pipeline.Count, "Transport is not at last position in pipeline.");
    }

    public sealed override async ValueTask ProcessAsync(DuplexPipelineRequest request, IReadOnlyList<DuplexPipelinePolicy> pipeline, int currentIndex)
    {
        await ProcessAsync(request).ConfigureAwait(false);

        Debug.Assert(++currentIndex == pipeline.Count, "Transport is not at last position in pipeline.");
    }

    public sealed override void Process(DuplexPipelineResponse response, IReadOnlyList<DuplexPipelinePolicy> pipeline, int currentIndex)
    {
        Process(response);

        Debug.Assert(++currentIndex == pipeline.Count, "Transport is not at last position in pipeline.");
    }

    public sealed override async ValueTask ProcessAsync(DuplexPipelineResponse response, IReadOnlyList<DuplexPipelinePolicy> pipeline, int currentIndex)
    {
        await ProcessAsync(response).ConfigureAwait(false);

        Debug.Assert(++currentIndex == pipeline.Count, "Transport is not at last position in pipeline.");
    }
    #endregion
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
