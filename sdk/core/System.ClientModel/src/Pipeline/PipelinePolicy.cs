// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public abstract class PipelinePolicy
{
    public abstract void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline);

    public abstract ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline);

    protected virtual bool ProcessNext(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline)
    {
        IEnumerator<PipelinePolicy> enumerator = pipeline.GetEnumerator();

        PipelinePolicy policy = enumerator.Current;
        if (policy is null)
        {
            return false;
        }

        bool more = enumerator.MoveNext();
        message.NextPolicyIndex++;

        policy.Process(message, pipeline);

        message.NextPolicyIndex--;
        return more;
    }

    protected virtual async Task<bool> ProcessNextAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline)
    {
        IEnumerator<PipelinePolicy> enumerator = pipeline.GetEnumerator();

        PipelinePolicy policy = enumerator.Current;
        if (policy is null)
        {
            return false;
        }

        bool more = enumerator.MoveNext();
        message.NextPolicyIndex++;

        await policy.ProcessAsync(message, pipeline).ConfigureAwait(false);

        message.NextPolicyIndex--;
        return more;
    }
}
