// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Threading;

namespace System.ClientModel.Primitives.TwoWayClient;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public abstract class TwoWayPipelineClientMessage : IDisposable
{
    protected TwoWayPipelineClientMessage() { }

    private ArrayBackedPropertyBag<ulong, object>? _propertyBag;
    private bool _disposedValue;

    private ArrayBackedPropertyBag<ulong, object> PropertyBag => _propertyBag ??= new();

    // TODO: Do we need to support the WS text/binary switch for Content?
    public BinaryContent? Content { get; set; }

    // TODO: settable here? Or better to use a RequestOptions.Apply paradigm?
    public CancellationToken CancellationToken { get; set; }

    public void SetProperty(Type key, object? value) =>
        PropertyBag.Set((ulong)key.TypeHandle.Value, value);

    public bool TryGetProperty(Type key, out object? value) =>
        PropertyBag.TryGetValue((ulong)key.TypeHandle.Value, out value);

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
                // TODO: dispose managed state (managed objects)
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            _disposedValue = true;
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
