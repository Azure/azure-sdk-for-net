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

    public RetryPolicy(int maxRetries, int delayMiliseconds = 500)
    {
        _maxRetries = maxRetries;
        _delay = delayMiliseconds;
    }
    public override void Process(PipelineMessage message, IEnumerator<PipelinePolicy> pipeline)
    {
        throw new NotImplementedException();
    }
    public override ValueTask ProcessAsync(PipelineMessage message, IEnumerator<PipelinePolicy> pipeline)
    {
        throw new NotImplementedException();
    }
}
