// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.WebPubSub;

/// <summary>
/// The client protocol.
/// </summary>
public enum WebPubSubClientProtocol
{
    /// <summary>
    /// Default client protocol, whose access endpoint starts with "/client".
    /// </summary>
    Default,

    /// <summary>
    /// MQTT client protocol, whose access endpoint starts with "/clients/mqtt".
    /// </summary>
    Mqtt,

    /// <summary>
    /// SocketIO client protocol, whose access endpoint starts with "/clients/socketio".
    /// </summary>
    SocketIO,
}
