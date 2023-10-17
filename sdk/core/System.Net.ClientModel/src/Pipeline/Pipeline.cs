// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace System.Net.ClientModel.Core.Pipeline;

public abstract class Pipeline<TMessage> where TMessage : PipelineMessage
{
    public abstract TMessage CreateMessage();

    public abstract void Send(TMessage message);

    public abstract ValueTask SendAsync(TMessage message);
}
