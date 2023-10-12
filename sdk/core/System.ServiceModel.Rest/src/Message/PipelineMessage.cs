// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ServiceModel.Rest.Internal;
using System.Threading;

namespace System.ServiceModel.Rest.Core;

public class PipelineMessage : IDisposable
{
    private PipelineResponse? _response;
    private bool _disposed;

    protected internal PipelineMessage(PipelineRequest request)
    {
        Request = request;
        _propertyBag = new ArrayBackedPropertyBag<ulong, object>();
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

    #region Pipeline invocation options

    public virtual CancellationToken CancellationToken { get; set; }

    private ArrayBackedPropertyBag<ulong, object> _propertyBag;

    public bool TryGetProperty(Type type, out object? value) =>
        _propertyBag.TryGetValue((ulong)type.TypeHandle.Value, out value);

    public void SetProperty(Type type, object value) =>
        _propertyBag.Set((ulong)type.TypeHandle.Value, value);

    private ResponseErrorClassifier _responseClassifier = RequestOptions.DefaultResponseClassifier;
    public virtual ResponseErrorClassifier ResponseClassifier
    {
        get => _responseClassifier;
        set => _responseClassifier = value;
    }

    #endregion

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
