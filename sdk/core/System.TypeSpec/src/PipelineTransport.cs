// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core;

public abstract class PipelineTransport<TMessage> : IPipelinePolicy<TMessage>
{
    public abstract void Process(TMessage message);

    public abstract ValueTask ProcessAsync(TMessage message);

    public abstract TMessage CreateMessage(string verb, Uri uri);

    public void Process(TMessage message, ReadOnlyMemory<IPipelinePolicy<TMessage>> pipeline)
    {
        Debug.Assert(pipeline.Length == 0);
        Process(message);
    }

    public async ValueTask ProcessAsync(TMessage message, ReadOnlyMemory<IPipelinePolicy<TMessage>> pipeline)
    {
        Debug.Assert(pipeline.Length == 0);
        await ProcessAsync(message).ConfigureAwait(false);
    }
}
