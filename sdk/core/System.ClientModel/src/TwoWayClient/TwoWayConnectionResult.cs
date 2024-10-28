// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives.TwoWayClient;

/// <summary>
/// This is intended to be the base type for a subclient that holds a
/// two-way pipeline, similar to how OperationResult is the base type for a
/// subclient that polls for updates to a long-running operation.
/// </summary>
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class TwoWayConnectionResult : IDisposable /*TODO: IAsyncDisposable? */
{
    private readonly TwoWayPipelineOptions _options;
    private TwoWayPipeline? _pipeline;

    private bool _disposed;

    protected TwoWayConnectionResult(PipelineResponse response, TwoWayPipelineOptions? options = default)
    {
        _options = options ?? new TwoWayPipelineOptions();

        _pipeline = TwoWayPipeline.Create(response, _options);
    }

    public TwoWayPipeline Pipeline => _pipeline ?? throw new ObjectDisposedException("TBD");

    // Protocol layer async method
    // Note: idea is that convenience method overload will add TwoWayResponse<T>
    // and take CancellationToken instead.
    public virtual IAsyncEnumerable<TwoWayResult> GetResponsesAsync(TwoWayMessageOptions options)
    {
        throw new NotImplementedException();
    }

    // Protocol layer sync method
    public virtual IEnumerable<TwoWayResult> GetResponses(TwoWayMessageOptions options)
    {
        throw new NotImplementedException();
    }

    // effectively the base-layer protocol message
    // only difference between this and Pipeline.Send is that TwoWayMessageOptions
    // can mutate the pipeline before sending.
    // Intention is that client authors will layer protocol methods around this
    // as a convenience to them, but open question whether we would expose this
    // to end users instead of protocol methods.  We probably still want named
    // protocol methods to provide discoverable convenience overloads.
    protected async Task SendAsync(BinaryContent content, TwoWayMessageOptions? options = default)
    {
        using TwoWayPipelineClientMessage message = Pipeline.CreateMessage();
        message.Content = content;

        options?.Apply(message);
        await Pipeline.SendAsync(message).ConfigureAwait(false);
    }

    protected void Send(BinaryContent content, TwoWayMessageOptions? options = default)
    {
        using TwoWayPipelineClientMessage message = Pipeline.CreateMessage();
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
