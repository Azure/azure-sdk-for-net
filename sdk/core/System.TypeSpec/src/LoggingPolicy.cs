// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core;

public class ConsoleLoggingPolicy : IPipelinePolicy<PipelineMessage>
{
    private bool _enabled;

    public ConsoleLoggingPolicy(bool isLoggingEnabled = true)
    {
        _enabled = isLoggingEnabled;
    }

    public void Process(PipelineMessage message, PipelineEnumerator pipeline)
    {
        if (_enabled) Console.WriteLine("Message Processing");
        pipeline.ProcessNext();
    }

    public async ValueTask ProcessAsync(PipelineMessage message, PipelineEnumerator pipeline)
    {
        if (_enabled) Console.WriteLine("Message Processing");
        await pipeline.ProcessNextAsync().ConfigureAwait(false);
    }
}