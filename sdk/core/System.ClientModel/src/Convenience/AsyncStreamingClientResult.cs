// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace System.ClientModel;

/// <summary>
/// Represents an asynchronous streaming service response.
/// </summary>
/// <remarks>
/// The result owns the underlying response. Disposing the result disposes the
/// response and its content stream. Callers that access the response through
/// <see cref="ClientResult.GetRawResponse"/> should consume its content stream
/// and asynchronously dispose this result rather than disposing the response
/// directly.
///
/// This type does not implement <see cref="IDisposable"/> because a derived
/// result may require asynchronous cleanup of an active stream parser.
/// </remarks>
public abstract class AsyncStreamingClientResult : ClientResult, IAsyncDisposable
{
    private readonly object _disposeSync = new();
    private bool _disposeStarted;
    private bool _responseDisposed;

    /// <summary>
    /// Creates a new instance of <see cref="AsyncStreamingClientResult"/>.
    /// </summary>
    /// <param name="response">The streaming response.</param>
    protected internal AsyncStreamingClientResult(PipelineResponse response)
        : base(response)
    {
    }

    /// <summary>
    /// Asynchronously disposes the underlying response.
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        lock (_disposeSync)
        {
            if (_responseDisposed)
            {
                return;
            }

            _disposeStarted = true;
        }

        bool deferResponseDisposal = false;
        try
        {
            deferResponseDisposal =
                !(await DisposeResultAsync().ConfigureAwait(false));
        }
        finally
        {
            if (!deferResponseDisposal)
            {
                DisposeResponse();
            }
        }
    }

    internal virtual ValueTask<bool> DisposeResultAsync() => new(true);

    internal void DisposeResponse()
    {
        lock (_disposeSync)
        {
            if (_responseDisposed)
            {
                return;
            }

            _disposeStarted = true;
            _responseDisposed = true;
        }

        GetRawResponse().Dispose();
        GC.SuppressFinalize(this);
    }

    internal void ThrowIfDisposed()
    {
        lock (_disposeSync)
        {
            if (_disposeStarted)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }
    }
}
