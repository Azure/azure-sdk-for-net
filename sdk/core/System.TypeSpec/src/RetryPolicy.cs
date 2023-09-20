// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core;

public class RetryPolicy : IPipelinePolicy<PipelineMessage>
{
    private int _maxRetries;
    private int _delay;

    public RetryPolicy(int maxRetries, int delayMiliseconds = 500)
    {
        _maxRetries = maxRetries;
        _delay = delayMiliseconds;
    }
    public void Process(PipelineMessage message, ReadOnlyMemory<IPipelinePolicy<PipelineMessage>> pipeline)
    {
        throw new NotImplementedException();
    }
    public ValueTask ProcessAsync(PipelineMessage message, ReadOnlyMemory<IPipelinePolicy<PipelineMessage>> pipeline)
    {
        throw new NotImplementedException();
    }
}
