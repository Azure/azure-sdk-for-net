// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace System.ClientModel;

/// <summary>
/// Represents a streaming service response.
/// </summary>
/// <remarks>
/// The result owns the underlying response. Disposing the result disposes the
/// response and its content stream. Callers that access the response through
/// <see cref="ClientResult.GetRawResponse"/> should consume its content stream
/// and dispose this result rather than disposing the response directly.
/// </remarks>
public abstract class StreamingClientResult : ClientResult, IDisposable
{
    private readonly object _sync = new();
    private bool _disposeStarted;
    private bool _responseDisposed;

    /// <summary>
    /// Creates a new instance of <see cref="StreamingClientResult"/>.
    /// </summary>
    /// <param name="response">The streaming response.</param>
    protected internal StreamingClientResult(PipelineResponse response)
        : base(response)
    {
    }

    /// <summary>
    /// Disposes the underlying response.
    /// </summary>
    public void Dispose()
    {
        lock (_sync)
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
            deferResponseDisposal = !DisposeResult();
        }
        finally
        {
            if (!deferResponseDisposal)
            {
                DisposeResponse();
            }
        }
    }

    internal virtual bool DisposeResult()
    {
        return true;
    }

    internal void ThrowIfDisposed()
    {
        lock (_sync)
        {
            if (_disposeStarted)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }
    }

    private void DisposeResponse()
    {
        lock (_sync)
        {
            if (_responseDisposed)
            {
                return;
            }

            _responseDisposed = true;
        }

        GetRawResponse().Dispose();
        GC.SuppressFinalize(this);
    }
}
