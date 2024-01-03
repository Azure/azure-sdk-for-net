// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives.Pipeline;

public abstract class PipelineTransport<TMessage> : IPipelinePolicy<TMessage>
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
    public abstract TMessage CreateMessage(RequestOptions options, ResponseErrorClassifier classifier);

    // Note: if we were willing to constrain TMessage, we could make
    // SetResponse a method on message instead of the transport?
    //public abstract void SetResponse(TMessage message, PipelineResponse response);

    public void Process(TMessage message, IPipelineEnumerator pipeline)
    {
        Debug.Assert(pipeline.Length == 0);

        Process(message);
    }

    public async ValueTask ProcessAsync(TMessage message, IPipelineEnumerator pipeline)
    {
        Debug.Assert(pipeline.Length == 0);

        await ProcessAsync(message).ConfigureAwait(false);
    }
}
