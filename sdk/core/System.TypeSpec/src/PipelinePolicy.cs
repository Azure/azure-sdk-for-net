// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest;

/// <summary>
/// TBD.
/// </summary>
public abstract class PipelinePolicy // base of HttpPipelinePolicy
{
    public abstract void Process(PipelineMessage message, IEnumerator<PipelinePolicy> pipeline);

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="pipeline"></param>
    /// <returns></returns>
    public abstract ValueTask ProcessAsync(PipelineMessage message, IEnumerator<PipelinePolicy> pipeline);

    /// <summary>
    /// Invokes the next <see cref="PipelinePolicy"/> in the <paramref name="pipeline"/>.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> next policy would be applied to.</param>
    /// <param name="pipeline">The set of <see cref="PipelinePolicy"/> to execute after next one.</param>
    /// <returns>The <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    protected static ValueTask ProcessNextAsync(PipelineMessage message, IEnumerator<PipelinePolicy> pipeline)
    {
        if (!pipeline.MoveNext()) return default(ValueTask);
        return pipeline.Current.ProcessAsync(message, pipeline);
    }

    /// <summary>
    /// Invokes the next <see cref="PipelinePolicy"/> in the <paramref name="pipeline"/>.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> next policy would be applied to.</param>
    /// <param name="pipeline">The set of <see cref="PipelinePolicy"/> to execute after next one.</param>
    protected static void ProcessNext(PipelineMessage message, IEnumerator<PipelinePolicy> pipeline)
    {
        if (!pipeline.MoveNext()) return;
        pipeline.Current.ProcessAsync(message, pipeline);
    }
}
