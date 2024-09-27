// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebPubSub.Common;

namespace Microsoft.Azure.WebPubSub.AspNetCore;

/// <summary>
/// Throw this exception to reject the MQTT connection to control the reason code (MQTT 5.0) or return code (MQTT 3.1.1), user properties in the MQTT CONNACK packet.
/// </summary>
public class MqttConnectionException : Exception
{
    /// <summary>
    /// Creates a new instance of <see cref="MqttConnectionException"/>.
    /// </summary>
    /// <param name="mqttErrorResponse"></param>
    public MqttConnectionException(MqttConnectEventErrorResponse mqttErrorResponse) : base(mqttErrorResponse.ErrorMessage)
    {
        MqttErrorResponse = mqttErrorResponse;
    }

    internal MqttConnectEventErrorResponse MqttErrorResponse { get; }
}
