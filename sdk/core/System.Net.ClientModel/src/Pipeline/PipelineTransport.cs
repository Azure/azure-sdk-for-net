// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Threading.Tasks;

namespace System.Net.ClientModel.Core.Pipeline;

public abstract class PipelineTransport<TMessage> : PipelinePolicy<TMessage>
    where TMessage : PipelineMessage
{
    /// <summary>
    /// TBD: needed for inheritdoc.
    /// </summary>
    /// <param name="message"></param>
    public abstract void Process(TMessage message);

    /// <summary>
    /// TBD: needed for inheritdoc.
    /// </summary>
    /// <param name="message"></param>
    public abstract ValueTask ProcessAsync(TMessage message);

    /// <summary>
    /// TBD: needed for inheritdoc.
    /// </summary>
    public abstract TMessage CreateMessage();

    // These methods from PipelinePolicy just say "you've reached the end
    // of the line", i.e. they stop the invocation of the policy chain.
    public override void Process(TMessage message, IPipelineEnumerator pipeline)
    {
        Debug.Assert(pipeline.Length == 0);

        Process(message);
    }

    public override async ValueTask ProcessAsync(TMessage message, IPipelineEnumerator pipeline)
    {
        Debug.Assert(pipeline.Length == 0);

        await ProcessAsync(message).ConfigureAwait(false);
    }
}
