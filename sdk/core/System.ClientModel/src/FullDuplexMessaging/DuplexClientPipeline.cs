// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives.FullDuplexMessaging;

/// <summary>
/// I feel comfortable calling this a DuplexClientPipeline if it's in a
/// namespace with the word FullDuplex in it.  If it was a half-duplex
/// communication channel, we would write "half," but the "full" is implied
/// the same way you don't put a coefficent of one in front of a variable
/// in algebraic representations.
/// </summary>

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public sealed class DuplexClientPipeline : IDisposable, IAsyncDisposable
{
    private readonly ReadOnlyMemory<DuplexPipelinePolicy> _policies;

    private bool _disposed;

    private DuplexClientPipeline(ReadOnlyMemory<DuplexPipelinePolicy> policies)
    {
        _policies = policies;
    }

    //public static DuplexClientPipeline Create(ReadOnlySpan<DuplexPipelinePolicy> policies)
    //{
    //    if (policies[policies.Length - 1] is not DuplexPipelineTransport)
    //    {
    //        throw new ArgumentException("The last policy must be of type 'DuplexPipelineTransport'.", nameof(policies));
    //    }

    //    throw new NotImplementedException();
    //}

    public static DuplexClientPipeline Create(PipelineResponse response, DuplexPipelineOptions options)
    {
        throw new NotImplementedException();
    }

    public DuplexPipelineRequest CreateMessage()
    {
        throw new NotImplementedException();
    }

    public void Send(DuplexPipelineRequest message)
    {
        throw new NotImplementedException();
    }

    public Task SendAsync(DuplexPipelineRequest message)
    {
        throw new NotImplementedException();
    }

    // TODO: What is sync story for recieve - does this work?
    // Returns a C# "stream" of service messages
    public IEnumerable<DuplexPipelineResponse> GetResponses()
    {
        throw new NotImplementedException();
    }

    // Returns a C# "async stream" of service messages
    public IAsyncEnumerable<DuplexPipelineResponse> GetResponsesAsync()
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
