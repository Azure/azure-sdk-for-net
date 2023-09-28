// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core.Pipeline;

public abstract class Pipeline<TMessage>
{
    public abstract TMessage CreateMessage(RequestOptions options, ResponseErrorClassifier classifier);

    public abstract void Send(TMessage message);

    public abstract ValueTask SendAsync(TMessage message);
}
