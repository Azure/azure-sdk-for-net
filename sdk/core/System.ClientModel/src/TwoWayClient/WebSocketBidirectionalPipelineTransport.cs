// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.WebSockets;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives.BidirectionalClients;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public partial class WebSocketBidirectionalPipelineTransport : BidirectionalPipelineTransport,
    IDisposable, IAsyncDisposable
{
    private ClientWebSocket? _webSocket;

    private bool _disposed;

    public WebSocketBidirectionalPipelineTransport()
    {
        _webSocket = new();
    }

    protected override BidirectionalPipelineRequest CreateMessageCore()
    {
        return new WebSocketTransportClientMessage();
    }

    protected override void ProcessCore(BidirectionalPipelineRequest clientMessage)
    {
        throw new NotImplementedException();
    }

    protected override ValueTask ProcessCoreAsync(BidirectionalPipelineRequest clientMessage)
    {
        // Send the message over the WebSocket.

        AssertNotDisposed();

        // TODO: assert that message has content?
        // TODO: text vs. binary?
        // TODO: end of message?

        // TODO: implement Send using BinaryContent instead of BinaryData.
        throw new NotImplementedException();

//#if NET6_0_OR_GREATER
//        await _webSocket!.SendAsync((clientMessage.Content!).ToMemory(),
//            WebSocketMessageType.Text,
//            endOfMessage: true,
//            clientMessage.CancellationToken).ConfigureAwait(false);
//#else
//        // TODO: perf for netstandard2.0?
//        await _webSocket!.SendAsync(new ArraySegment<byte>(clientMessage.Content!.ToArray()),
//            WebSocketMessageType.Text,
//            endOfMessage: true,
//            clientMessage.CancellationToken).ConfigureAwait(false);
//#endif
    }

    protected override void ProcessCore(BidirectionalPipelineResponse serviceMessage)
    {
        throw new NotImplementedException();
    }

    protected override ValueTask ProcessCoreAsync(BidirectionalPipelineResponse serviceMessage)
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
                _webSocket?.Dispose();
                _webSocket = null;
            }

            _disposed = true;
        }
    }

    public ValueTask DisposeAsync()
    {
        // TODO: refresh on how to implement this; if we need it

        throw new NotImplementedException();
    }

    private void AssertNotDisposed()
    {
        if (_disposed || _webSocket is null)
        {
            throw new ObjectDisposedException(nameof(_webSocket));
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
