// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives.TwoWayPipeline;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public sealed class TwoWayPipeline
{
    private readonly ReadOnlyMemory<TwoWayPipelinePolicy> _policies;

    private TwoWayPipeline(ReadOnlyMemory<TwoWayPipelinePolicy> policies)
    {
        _policies = policies;
    }

    public static TwoWayPipeline Create(ReadOnlySpan<TwoWayPipelinePolicy> policies)
    {
        if (policies[policies.Length - 1] is not TwoWayPipelineTransport)
        {
            throw new ArgumentException("The last policy must be of type 'TwoWayPipelineTransport'.", nameof(policies));
        }

        throw new NotImplementedException();
    }

    public static TwoWayPipeline Create(TwoWayPipelineOptions options)
    {
        throw new NotImplementedException();
    }

    public ClientPipelineMessage CreateMessage()
    {
        throw new NotImplementedException();
    }

    public void Send(ClientPipelineMessage message)
    {
        throw new NotImplementedException();
    }

    public Task SendAsync(ClientPipelineMessage message)
    {
        throw new NotImplementedException();
    }

    // TODO: What is sync story for recieve - does this work?
    public IEnumerable<ServicePipelineMessage> GetResponseStream()
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<ServicePipelineMessage> GetResponseStreamAsync()
    {
        throw new NotImplementedException();
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
