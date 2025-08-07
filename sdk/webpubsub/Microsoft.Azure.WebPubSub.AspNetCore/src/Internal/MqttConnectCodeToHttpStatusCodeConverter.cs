// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using Microsoft.Azure.WebPubSub.Common;

namespace Microsoft.Azure.WebPubSub.AspNetCore;

internal static class MqttConnectCodeToHttpStatusCodeConverter
{
    public static HttpStatusCode ToHttpStatusCode(int mqttConnectCode)
    {
        if (mqttConnectCode < 0x80)
        {
            return (MqttV311ConnectReturnCode)mqttConnectCode switch
            {
                MqttV311ConnectReturnCode.UnacceptableProtocolVersion => HttpStatusCode.BadRequest,
                MqttV311ConnectReturnCode.IdentifierRejected => HttpStatusCode.BadRequest,
                MqttV311ConnectReturnCode.ServerUnavailable => HttpStatusCode.ServiceUnavailable,
                MqttV311ConnectReturnCode.BadUsernameOrPassword => HttpStatusCode.Unauthorized,
                MqttV311ConnectReturnCode.NotAuthorized => HttpStatusCode.Unauthorized,
                _ => throw new ArgumentOutOfRangeException($"Invalid MQTT connect return code: {mqttConnectCode}.")
            };
        }
        else
        {
            return (MqttV500ConnectReasonCode)mqttConnectCode switch
            {
                // Map to Unauthorized
                MqttV500ConnectReasonCode.NotAuthorized => HttpStatusCode.Unauthorized,
                MqttV500ConnectReasonCode.BadUserNameOrPassword => HttpStatusCode.Unauthorized,

                // Map to UserError
                MqttV500ConnectReasonCode.ClientIdentifierNotValid => HttpStatusCode.BadRequest,
                MqttV500ConnectReasonCode.MalformedPacket => HttpStatusCode.BadRequest,
                MqttV500ConnectReasonCode.UnsupportedProtocolVersion => HttpStatusCode.BadRequest,
                MqttV500ConnectReasonCode.BadAuthenticationMethod => HttpStatusCode.BadRequest,
                MqttV500ConnectReasonCode.TopicNameInvalid => HttpStatusCode.BadRequest,
                MqttV500ConnectReasonCode.PayloadFormatInvalid => HttpStatusCode.BadRequest,
                MqttV500ConnectReasonCode.ImplementationSpecificError => HttpStatusCode.BadRequest,
                MqttV500ConnectReasonCode.PacketTooLarge => HttpStatusCode.BadRequest,
                MqttV500ConnectReasonCode.RetainNotSupported => HttpStatusCode.BadRequest,
                MqttV500ConnectReasonCode.QosNotSupported => HttpStatusCode.BadRequest,

                // Too many requests
                MqttV500ConnectReasonCode.QuotaExceeded => HttpStatusCode.TooManyRequests,
                MqttV500ConnectReasonCode.ConnectionRateExceeded => HttpStatusCode.TooManyRequests,

                // Forbidden
                MqttV500ConnectReasonCode.Banned => HttpStatusCode.Forbidden,
                // Map to ServerError
                MqttV500ConnectReasonCode.UseAnotherServer => HttpStatusCode.InternalServerError,
                MqttV500ConnectReasonCode.ServerMoved => HttpStatusCode.InternalServerError,
                MqttV500ConnectReasonCode.ServerUnavailable => HttpStatusCode.InternalServerError,
                MqttV500ConnectReasonCode.ServerBusy => HttpStatusCode.InternalServerError,
                MqttV500ConnectReasonCode.UnspecifiedError => HttpStatusCode.InternalServerError,

                // These don't directly map and will throw an exception.
                //MqttV50ConnectReasonCode.Success => throw new ArgumentOutOfRangeException(nameof(code), code, "Success is not an error"),
                _ => throw new ArgumentOutOfRangeException($"Invalid MQTT connect return code: {mqttConnectCode}.")
            };
        }
    }
}
