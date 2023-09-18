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
    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="pipeline"></param>
    public abstract void Process(PipelineMessage message, IEnumerator<PipelinePolicy> pipeline);

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="pipeline"></param>
    /// <returns></returns>
    public abstract ValueTask ProcessAsync(PipelineMessage message, IEnumerator<PipelinePolicy> pipeline);
}
