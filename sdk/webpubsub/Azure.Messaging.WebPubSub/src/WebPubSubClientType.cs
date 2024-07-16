// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.WebPubSub;

/// <summary>
/// The type of client.
/// </summary>
public enum WebPubSubClientType
{
    /// <summary>
    /// Default client endpoint type, whose path starts with "/client".
    /// </summary>
    Default,

    /// <summary>
    /// MQTT client endpoint, whose path starts with "/clients/mqtt".
    /// </summary>
    Mqtt,
}
