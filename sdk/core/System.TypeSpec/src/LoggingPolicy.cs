// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System.ServiceModel.Rest;

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
        if (_enabled) Console.WriteLine("Message Processing");
        Pipeline<PipelineMessage>.ProcessNext(message, pipeline);
    }

    public async ValueTask ProcessAsync(PipelineMessage message, ReadOnlyMemory<IPipelinePolicy<PipelineMessage>> pipeline)
    {
        if (_enabled) Console.WriteLine("Message Processing");
        await Pipeline<PipelineMessage>.ProcessNextAsync(message, pipeline).ConfigureAwait(false);
    }
}