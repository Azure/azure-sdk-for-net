// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Threading;

namespace System.ClientModel.Primitives.FullDuplexMessaging;

/// <summary>
/// Data to send via full-duplex pipeline.
/// In WebSockets, a message can be sent across one or more frames.
/// The BCL type has opted not to use the word "frame" in their naming.
/// Client data and service data feels like it reflects the general-
/// purpose concept of either a message or a frame.
///
/// We use the name `Request` to indicate it is client data being
/// sent over the full-duplex connection, and to align with SCM
/// naming of an outgoing message sent by the client.
/// </summary>
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public abstract class DuplexPipelineRequest : IDisposable
{
    protected DuplexPipelineRequest() { }

    private ArrayBackedPropertyBag<ulong, object>? _propertyBag;
    private bool _disposedValue;

    private ArrayBackedPropertyBag<ulong, object> PropertyBag => _propertyBag ??= new();

    // TODO: Do we need to support the WS text/binary switch for Content?
    // TODO: Could this be BinaryData instead?  If so, it wouldn't need to be disposed,
    // But perhaps dispose is not catastrophic, if the contract is that the pipeline
    // will dispose it?  What is the contract?
    // I don't think this can be BinaryData, since we need to be able to send arbitrarily
    // large audio without buffering in-memory.
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
