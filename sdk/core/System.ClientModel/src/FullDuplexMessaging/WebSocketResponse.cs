// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Threading;

namespace System.ClientModel.Primitives.FullDuplexMessaging;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public abstract class WebSocketResponse : DuplexPipelineResponse
{
    // Can be Text, Blob, or ArrayBuffer
    public abstract string ContentType { get; }

    // Indicates whether this frame is the last fragment of a complete logical
    // transmission from the service.
    public abstract bool LastOfMessage { get; }

    // These are only used for Close events, which we should filter out
    //public abstract string StatusCode { get; }
    //public abstract string Reason { get; }

    // These are on the WebSocket, not the message
    //public abstract string Protocol { get; }
    //public abstract string BinaryType { get; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
