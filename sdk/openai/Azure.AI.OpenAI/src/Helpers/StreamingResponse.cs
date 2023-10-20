// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;

namespace Azure;

/// <summary>
/// Represents an operation response with streaming content that can be deserialized and enumerated while the response
/// is still being received.
/// </summary>
/// <typeparam name="T"> The data type representative of distinct, streamable items. </typeparam>
public class StreamingResponse<T>
    : IDisposable
    , IAsyncEnumerable<T>
{
    private Response _rawResponse { get; }
    private IAsyncEnumerable<T> _asyncEnumerableSource { get; }
    private bool _disposedValue { get; set; }

    internal StreamingResponse(Response rawResponse,  IAsyncEnumerable<T> asyncEnumerableSource)
    {
        _rawResponse = rawResponse;
        _asyncEnumerableSource = asyncEnumerableSource;
    }

    /// <summary>
    /// Gets the underlying <see cref="Response"/> instance that this <see cref="StreamingResponse{T}"/> may enumerate
    /// over.
    /// </summary>
    /// <returns> The <see cref="Response"/> instance attached to this <see cref="StreamingResponse{T}"/>. </returns>
    public Response GetRawResponse() => _rawResponse;

    /// <summary>
    /// Gets the asynchronously enumerable collection of distinct, streamable items in the response.
    /// </summary>
    /// <remarks>
    /// <para> The return value of this method may be used with the "await foreach" statement. </para>
    /// <para>
    /// As <see cref="StreamingResponse{T}"/> explicitly implements <see cref="IAsyncEnumerable{T}"/>, callers may
    /// enumerate a <see cref="StreamingResponse{T}"/> instance directly instead of calling this method.
    /// </para>
    /// </remarks>
    /// <returns></returns>
    public IAsyncEnumerable<T> EnumerateValues() => this;

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _rawResponse?.Dispose();
            }
            _disposedValue = true;
        }
    }

    IAsyncEnumerator<T> IAsyncEnumerable<T>.GetAsyncEnumerator(CancellationToken cancellationToken)
        => _asyncEnumerableSource.GetAsyncEnumerator(cancellationToken);
}
