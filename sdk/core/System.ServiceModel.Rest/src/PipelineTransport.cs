// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core.Pipeline;

public abstract class PipelineTransport<TMessage> : IPipelinePolicy<TMessage>
    // TODO: remove this constraint
    where TMessage : PipelineMessage
{
    /// <summary>
    /// TBD: needed for inheritdoc
    /// </summary>
    /// <param name="message"></param>
    public abstract void Process(TMessage message);

    /// <summary>
    /// TBD: needed for inheritdoc
    /// </summary>
    /// <param name="message"></param>
    public abstract ValueTask ProcessAsync(TMessage message);

    /// <summary>
    /// TBD: needed for inheritdoc
    /// </summary>
    public abstract TMessage CreateMessage(RequestOptions options, ResponseErrorClassifier classifier);

    public void Process(TMessage message, PipelineEnumerator pipeline)
    {
        Debug.Assert(pipeline.Length == 0);

        Process(message);

        message.Response.IsError = message.ResponseClassifier.IsErrorResponse(message);
    }

    public async ValueTask ProcessAsync(TMessage message, PipelineEnumerator pipeline)
    {
        Debug.Assert(pipeline.Length == 0);

        await ProcessAsync(message).ConfigureAwait(false);

        message.Response.IsError = message.ResponseClassifier.IsErrorResponse(message);
    }
}
