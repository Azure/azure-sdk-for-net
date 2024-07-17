// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.WebPubSub;

/// <summary>
/// The access type of clients.
/// </summary>
public enum WebPubSubClientAccess
{
    /// <summary>
    /// Default client access, whose access endpoint starts with "/client".
    /// </summary>
    Default,

    /// <summary>
    /// MQTT client access, whose access endpoint starts with "/clients/mqtt".
    /// </summary>
    Mqtt,
}
