// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest;

public class LoggingPolicy : PipelinePolicy
{
    private bool _enabled;

    public LoggingPolicy(bool isLoggingEnabled = true)
    {
        _enabled = isLoggingEnabled;
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