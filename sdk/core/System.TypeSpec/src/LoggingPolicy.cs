// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core;

public class LoggingPolicy : IPipelinePolicy<PipelineMessage>
{
    private bool _enabled;

    public LoggingPolicy(bool isLoggingEnabled = true)
    {
        _enabled = isLoggingEnabled;
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