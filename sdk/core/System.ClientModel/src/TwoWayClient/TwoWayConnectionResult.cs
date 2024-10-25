// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

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
