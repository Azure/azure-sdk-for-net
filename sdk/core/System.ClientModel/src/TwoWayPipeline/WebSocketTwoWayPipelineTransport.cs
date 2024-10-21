// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives.TwoWayPipeline;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class WebSocketTwoWayPipelineTransport : TwoWayPipelineTransport,
    IDisposable, IAsyncDisposable
{
    private ClientWebSocket? _webSocket;

    private bool _disposed;

    public WebSocketTwoWayPipelineTransport()
    {
        _webSocket = new();
    }

    protected override TwoWayPipelineClientMessage CreateMessageCore()
    {
        throw new NotImplementedException();
    }

    protected override void ProcessCore(TwoWayPipelineClientMessage clientMessage)
    {
        throw new NotImplementedException();
    }

    protected override ValueTask ProcessCoreAsync(TwoWayPipelineClientMessage clientMessage)
    {
        throw new NotImplementedException();
    }

    protected override void ProcessCore(TwoWayPipelineServiceMessage serviceMessage)
    {
        throw new NotImplementedException();
    }

    protected override ValueTask ProcessCoreAsync(TwoWayPipelineServiceMessage serviceMessage)
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
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
