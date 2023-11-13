// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Threading;

namespace System.ClientModel.Primitives;

public class PipelineMessage : IDisposable
{
    private MessageResponse? _response;
    private bool _disposed;

    protected internal PipelineMessage(MessageRequest request)
    {
        Request = request;
        _propertyBag = new ArrayBackedPropertyBag<ulong, object>();
    }

    public virtual MessageRequest Request { get; }

    public virtual MessageResponse Response
    {
        get
        {
            if (_response is null)
            {
                throw new InvalidOperationException("Response has not been set on Message.");
            }

            return _response;
        }

        // This is set internally by the transport.
        protected internal set => _response = value;
    }

    public bool HasResponse => _response is not null;

    #region Pipeline invocation options

    public CancellationToken CancellationToken { get; set; }

    public MessageClassifier? MessageClassifier { get; protected internal set; }

    private ArrayBackedPropertyBag<ulong, object> _propertyBag;

    public bool TryGetProperty(Type type, out object? value) =>
        _propertyBag.TryGetValue((ulong)type.TypeHandle.Value, out value);

    public void SetProperty(Type type, object value) =>
        _propertyBag.Set((ulong)type.TypeHandle.Value, value);

    #endregion

    #region IDisposable

    protected virtual void Dispose(bool disposing)
    {
        if (disposing && !_disposed)
        {
            var request = Request;
            request?.Dispose();

            _propertyBag.Dispose();

            // TODO: this means we return a disposed response to the end-user.
            // Would be nice to possibly introduce an OnMessageDiposed pattern
            // to notify the response that it needs to dispose network resources
            // without being officially disposed itself?
            var response = _response;
            if (response != null)
            {
                _response = null;
                response.Dispose();
            }

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
