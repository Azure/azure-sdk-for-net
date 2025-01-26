// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives.FullDuplexMessaging;

/// <summary>
/// This is intended to be the base type for a subclient that holds a
/// two-way pipeline, similar to how OperationResult is the base type for a
/// subclient that polls for updates to a long-running operation.
/// </summary>
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class DuplexConnectionResult : IDisposable /*TODO: IAsyncDisposable? */
{
    private DuplexClientPipeline? _pipeline;

    private bool _disposed;

    protected DuplexConnectionResult(PipelineResponse response, DuplexPipelineOptions options)
    {
        _pipeline = DuplexClientPipeline.Create(response, options);
    }

    public DuplexClientPipeline Pipeline => _pipeline ?? throw new ObjectDisposedException("TBD");

    // Protocol layer async DuplexClientResult
    // Note: idea is that convenience method overload will add DuplexClientResult<T>
    // and take CancellationToken instead.
    // Note: this returns a nullable value so that the stream can return null values
    // as a heartbeat to pump the result stream to give the client notification it
    // can iterate the event-loop even when no service message has been delivered on
    // the result stream.
    public virtual IAsyncEnumerable<DuplexClientResult?> GetResultsAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    // Protocol layer sync method
    public virtual IEnumerable<DuplexClientResult?> GetResults(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    // effectively the base-layer protocol message
    // only difference between this and Pipeline.Send is that DuplexRequestOptions
    // can mutate the pipeline before sending.
    // Intention is that client authors will layer protocol methods around this
    // as a convenience to them, but open question whether we would expose this
    // to end users instead of protocol methods.  We probably still want named
    // protocol methods to provide discoverable convenience overloads.
    protected async Task SendAsync(BinaryContent content, DuplexRequestOptions? options = default)
    {
        using DuplexPipelineRequest message = Pipeline.CreateMessage();
        message.Content = content;

        options?.Apply(message);
        await Pipeline.SendAsync(message).ConfigureAwait(false);
    }

    protected void Send(BinaryContent content, DuplexRequestOptions? options = default)
    {
        using DuplexPipelineRequest message = Pipeline.CreateMessage();
        message.Content = content;

        options?.Apply(message);
        Pipeline.Send(message);
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _pipeline?.Dispose();
                _pipeline = null;
            }

            _disposed = true;
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
