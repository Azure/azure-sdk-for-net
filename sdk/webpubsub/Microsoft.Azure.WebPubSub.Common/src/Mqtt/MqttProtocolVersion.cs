// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebPubSub.Common;

#nullable enable

/// <summary>
/// MQTT protocol versions supported by Web PubSub service.
/// </summary>
/// <remarks>This API involves general purpose MQTT API. We can make it public once those general purpose MQTT API are released in a shared package.</remarks>
internal enum MqttProtocolVersion
{
    /// <summary>
    /// MQTT 3.1.1
    /// </summary>
    V311 = 4,

    /// <summary>
    /// MQTT 5.0
    /// </summary>
    V500 = 5
}
