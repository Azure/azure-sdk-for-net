// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Containers.Apps.Sandbox.Models;

namespace Azure.Containers.Apps.Sandbox
{
    internal interface ISandboxWebSocketClient : IDisposable, IAsyncDisposable
    {
        Task SendAsync(BinaryData data, SandboxStreamMessageType type, CancellationToken cancellationToken);
        Task<SandboxStreamMessage> ReceiveAsync(CancellationToken cancellationToken);
    }
}
