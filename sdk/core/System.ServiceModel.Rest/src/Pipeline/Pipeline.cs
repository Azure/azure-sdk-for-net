// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core.Pipeline;

// TODO: if we want this to be non-HTTP, should it not be in a "Rest" namespace?
public abstract class Pipeline<TMessage, TOptions>
{
    public abstract TMessage CreateMessage();

    public abstract void Send(TMessage message, TOptions options);

    public abstract ValueTask SendAsync(TMessage message, TOptions options);
}
