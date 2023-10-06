// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core.Pipeline;

//public abstract class PipelineTransport<TMessage, TPolicy> : IPipelinePolicy<TMessage, TPolicy>
//    where TPolicy : IPipelinePolicy<TMessage, TPolicy>

public abstract class PipelineTransport<TMessage, TPolicy>
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
}
