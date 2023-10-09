// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ServiceModel.Rest.Core;

public class PipelineMessage : IDisposable
{
    private PipelineResponse? _response;
    private bool _disposed;

    protected internal PipelineMessage(PipelineRequest request)
    {
        Request = request;
    }

    public virtual PipelineRequest Request { get; }

    public virtual PipelineResponse Response
    {
        get
        {
            if (_response is null)
            {
                throw new InvalidOperationException("Response has not been set on Message.");
            }

            return _response;
        }

        set => _response = value;
    }

    public bool HasResponse => _response is not null;

    #region IDisposable

    protected virtual void Dispose(bool disposing)
    {
        if (disposing && !_disposed)
        {
            var response = _response;
            response?.Dispose();
            _response = null;

            _disposed = true;
        }
    }

    public virtual void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion
}
