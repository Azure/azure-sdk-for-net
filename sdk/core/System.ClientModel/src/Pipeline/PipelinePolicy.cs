// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

/// <summary>
/// A policy that can be added to a <see cref="ClientPipeline"/> to process a
/// <see cref="PipelineMessage"/> during a call to
/// <see cref="ClientPipeline.Send(PipelineMessage)"/>. Types deriving from
/// <see cref="PipelinePolicy"/> can read or modify the
/// <see cref="PipelineMessage.Request"/>, implement functionality based on
/// <see cref="PipelineMessage.Response"/>, and must pass control to the next
/// <see cref="PipelinePolicy"/> in the pipeline by calling
/// <see cref="ProcessNext(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>.
/// </summary>
public abstract class PipelinePolicy
{
    /// <summary>
    /// Process the provided <see cref="PipelineMessage"/> according to the
    /// intended purpose of this <see cref="PipelinePolicy"/>instance.
    /// Derived types must pass control to the next
    /// <see cref="PipelinePolicy"/> in the pipeline by calling
    /// <see cref="ProcessNext(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> to process.</param>
    /// <param name="pipeline">The collection of <see cref="PipelinePolicy"/>
    /// instances in the <see cref="ClientPipeline"/> instance whose
    /// <see cref="ClientPipeline.Send(PipelineMessage)"/> method was called to invoke
    /// this method.</param>
    /// <param name="currentIndex">The index of this policy in the
    /// <paramref name="pipeline"/> policy list. This value should be passed to
    /// <see cref="ProcessNext(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>
    /// to pass control to the next policy in the pipeline.</param>
    public abstract void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex);

    /// <summary>
    /// Process the provided <see cref="PipelineMessage"/> according to the
    /// intended purpose of this <see cref="PipelinePolicy"/>instance.
    /// Derived types must pass control to the next
    /// <see cref="PipelinePolicy"/> in the pipeline by calling
    /// <see cref="ProcessNextAsync(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> to process.</param>
    /// <param name="pipeline">The collection of <see cref="PipelinePolicy"/>
    /// instances in the <see cref="ClientPipeline"/> instance whose
    /// <see cref="ClientPipeline.SendAsync(PipelineMessage)"/> method was called to invoke
    /// this method.</param>
    /// <param name="currentIndex">The index of this policy in the
    /// <paramref name="pipeline"/> policy list. This value should be passed to
    /// <see cref="ProcessNextAsync(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>
    /// to pass control to the next policy in the pipeline.</param>
    public abstract ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex);

    /// <summary>
    /// Passes control to the next <see cref="PipelinePolicy"/> in the
    /// <see cref="ClientPipeline"/>.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> to process.</param>
    /// <param name="pipeline">The collection of <see cref="PipelinePolicy"/>
    /// instances in the <see cref="ClientPipeline"/>.</param>
    /// <param name="currentIndex">The index of this policy in the
    /// <paramref name="pipeline"/> policy list. The derived-type implementation
    /// of <see cref="Process(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>
    /// should pass the value of <paramref name="currentIndex"/> it received
    /// without modifying it.</param>
    protected static void ProcessNext(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        currentIndex++;

        Debug.Assert(currentIndex < pipeline.Count);

        pipeline[currentIndex].Process(message, pipeline, currentIndex);
    }

    /// <summary>
    /// Passes control to the next <see cref="PipelinePolicy"/> in the
    /// <see cref="ClientPipeline"/>.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> to process.</param>
    /// <param name="pipeline">The collection of <see cref="PipelinePolicy"/>
    /// instances in the <see cref="ClientPipeline"/>.</param>
    /// <param name="currentIndex">The index of this policy in the
    /// <paramref name="pipeline"/> policy list. The derived-type implementation
    /// of <see cref="ProcessAsync(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>
    /// should pass the value of <paramref name="currentIndex"/> it received
    /// without modifying it.</param>
    protected static async ValueTask ProcessNextAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        currentIndex++;

        Debug.Assert(currentIndex < pipeline.Count);

        await pipeline[currentIndex].ProcessAsync(message, pipeline, currentIndex).ConfigureAwait(false);
    }
}
