// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives.BidirectionalClients;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public sealed class BidirectionalPipeline : IDisposable, IAsyncDisposable
{
    private readonly ReadOnlyMemory<BidirectionalPipelinePolicy> _policies;

    private bool _disposed;

    private BidirectionalPipeline(ReadOnlyMemory<BidirectionalPipelinePolicy> policies)
    {
        _policies = policies;
    }

    //public static TwoWayPipeline Create(ReadOnlySpan<TwoWayPipelinePolicy> policies)
    //{
    //    if (policies[policies.Length - 1] is not TwoWayPipelineTransport)
    //    {
    //        throw new ArgumentException("The last policy must be of type 'TwoWayPipelineTransport'.", nameof(policies));
    //    }

    //    throw new NotImplementedException();
    //}

    public static BidirectionalPipeline Create(PipelineResponse response, BidirectionalPipelineOptions options)
    {
        throw new NotImplementedException();
    }

    public BidirectionalPipelineRequest CreateMessage()
    {
        throw new NotImplementedException();
    }

    public void Send(BidirectionalPipelineRequest message)
    {
        throw new NotImplementedException();
    }

    public Task SendAsync(BidirectionalPipelineRequest message)
    {
        throw new NotImplementedException();
    }

    // TODO: What is sync story for recieve - does this work?
    public IEnumerable<BidirectionalPipelineResponse> GetResponseStream()
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<BidirectionalPipelineResponse> GetResponseStreamAsync()
    {
        throw new NotImplementedException();
    }

    // TODO: I believe we need these as a way to dispose the transport
    // as sessions that use these pipelines come in and out of existence.
    // TODO: validate hypotheses about WebSocket life-cycle
    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            _disposed = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public ValueTask DisposeAsync()
    {
        throw new NotImplementedException();
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
