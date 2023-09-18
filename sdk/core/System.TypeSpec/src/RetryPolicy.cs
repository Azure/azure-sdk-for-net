// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest;

/// <summary>
/// TBD.
/// </summary>
public class RetryPolicy : PipelinePolicy
{
    private int _maxRetries;
    private int _delay;

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="maxRetries"></param>
    /// <param name="delayMiliseconds"></param>
    public RetryPolicy(int maxRetries, int delayMiliseconds = 500)
    {
        _maxRetries = maxRetries;
        _delay = delayMiliseconds;
    }
    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="pipeline"></param>
    /// <exception cref="NotImplementedException"></exception>
    public override void Process(PipelineMessage message, IEnumerator<PipelinePolicy> pipeline)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="pipeline"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override ValueTask ProcessAsync(PipelineMessage message, IEnumerator<PipelinePolicy> pipeline)
    {
        throw new NotImplementedException();
    }
}
