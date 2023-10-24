// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace System.Net.ClientModel.Core.Pipeline;

// TODO: if we want this to be non-HTTP, should it not be in a "Rest" namespace?
public abstract class Pipeline<TMessage>
{
    public abstract TMessage CreateMessage(RequestOptions options, ResponseErrorClassifier classifier);

    public abstract void Send(TMessage message);

    public abstract ValueTask SendAsync(TMessage message);
}
