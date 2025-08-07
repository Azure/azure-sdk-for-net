// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Microsoft.Azure.WebPubSub.Common;

#nullable enable

internal class MqttConnectEventErrorResponseContent : MqttConnectEventErrorResponse
{
    public MqttConnectEventErrorResponseContent(MqttConnectEventErrorResponsePropertiesContent mqtt) : base(new MqttConnectEventErrorResponseProperties((MqttV500ConnectReasonCode)mqtt.Code))
    {
        Mqtt.Reason = mqtt.Reason;
        Mqtt.UserProperties = mqtt.UserProperties;
        // Set the proper WebPubSubErrorCode
        if (mqtt.Code < 0x80)
        {
            // MQTT 3.1.1
            Code = WebPubSubErrorCodeExtensions.FromMqttV311ConnectReturnCode((MqttV311ConnectReturnCode)mqtt.Code);
        }
        else
        {
            // MQTT 5.0
            Code = WebPubSubErrorCodeExtensions.FromMqttV500ConnectReasonCode((MqttV500ConnectReasonCode)mqtt.Code);
        }
    }
}

internal class MqttConnectEventErrorResponsePropertiesContent : MqttConnectEventErrorResponseProperties
{
    public MqttConnectEventErrorResponsePropertiesContent(int code, string? reason, IReadOnlyList<MqttUserProperty>? userProperties) : base((MqttV500ConnectReasonCode)code)
    {
        Reason = reason;
        UserProperties = userProperties;
    }
}