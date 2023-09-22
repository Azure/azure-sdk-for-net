// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core;

public abstract class Pipeline<TMessage>
{
    public abstract TMessage CreateMessage(string verb, Uri uri);

    public abstract void Send(TMessage message);

    public abstract ValueTask SendAsync(TMessage message);

    public static void ProcessNext(TMessage message, ReadOnlyMemory<IPipelinePolicy<TMessage>> pipeline)
    {
        pipeline.Span[0].Process(message, pipeline.Slice(1));
    }

    public static async ValueTask ProcessNextAsync(TMessage message, ReadOnlyMemory<IPipelinePolicy<TMessage>> pipeline)
    {
        await pipeline.Span[0].ProcessAsync(message, pipeline.Slice(1)).ConfigureAwait(false);
    }
}
