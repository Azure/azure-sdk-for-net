// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public abstract class PipelinePolicy
{
    public abstract void Process(PipelineMessage message, IEnumerable<PipelinePolicy> pipeline);

    public abstract ValueTask ProcessAsync(PipelineMessage message, IEnumerable<PipelinePolicy> pipeline);

    public bool ProcessNext(PipelineMessage message, IEnumerable<PipelinePolicy> pipeline)
    {
        IEnumerator<PipelinePolicy> enumerator = pipeline.GetEnumerator();

        if (!enumerator.MoveNext())
        {
            return false;
        }

        enumerator.Current.Process(message, pipeline);
        return true;
    }

    public async Task<bool> ProcessNextAsync(PipelineMessage message, IEnumerable<PipelinePolicy> pipeline)
    {
        IEnumerator<PipelinePolicy> enumerator = pipeline.GetEnumerator();

        if (!enumerator.MoveNext())
        {
            return false;
        }

        await enumerator.Current.ProcessAsync(message, pipeline).ConfigureAwait(false);
        return true;
    }
}
