// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebPubSub.Common;

internal static class WebPubSubErrorCodeExtensions
{
    public static MqttV311ConnectReturnCode ToMqttV311ConnectReturnCode(this WebPubSubErrorCode code)
    {
        return code switch
        {
            WebPubSubErrorCode.Unauthorized => MqttV311ConnectReturnCode.NotAuthorized,
            WebPubSubErrorCode.UserError => MqttV311ConnectReturnCode.BadUsernameOrPassword,
            WebPubSubErrorCode.ServerError => MqttV311ConnectReturnCode.ServerUnavailable,
            _ => throw new ArgumentOutOfRangeException(nameof(code), code, null)
        };
    }

    public static MqttV500ConnectReasonCode ToMqttV500ConnectReasonCode(this WebPubSubErrorCode code)
    {
        return code switch
        {
            WebPubSubErrorCode.Unauthorized => MqttV500ConnectReasonCode.NotAuthorized,
            WebPubSubErrorCode.UserError => MqttV500ConnectReasonCode.BadUserNameOrPassword,
            WebPubSubErrorCode.ServerError => MqttV500ConnectReasonCode.ServerUnavailable,
            _ => throw new ArgumentOutOfRangeException(nameof(code), code, null)
        };
    }

    public static WebPubSubErrorCode FromMqttV311ConnectReturnCode(MqttV311ConnectReturnCode code)
    {
        return code switch
        {
            //MqttV311ConnectReturnCode.ConnectionAccepted => throw new ArgumentOutOfRangeException(nameof(code), $"MQTT 'ConnectionAccepted' return code cannot be converted to a Web PubSub error code."),
            MqttV311ConnectReturnCode.UnacceptableProtocolVersion => WebPubSubErrorCode.UserError,
            MqttV311ConnectReturnCode.IdentifierRejected => WebPubSubErrorCode.UserError,
            MqttV311ConnectReturnCode.ServerUnavailable => WebPubSubErrorCode.ServerError,
            MqttV311ConnectReturnCode.BadUsernameOrPassword => WebPubSubErrorCode.UserError,
            MqttV311ConnectReturnCode.NotAuthorized => WebPubSubErrorCode.Unauthorized,
            _ => throw new ArgumentOutOfRangeException(nameof(code), code, null)
        };
    }

    public static WebPubSubErrorCode FromMqttV500ConnectReasonCode(this MqttV500ConnectReasonCode code)
    {
        return code switch
        {
            // Map to Unauthorized
            MqttV500ConnectReasonCode.NotAuthorized => WebPubSubErrorCode.Unauthorized,

            // Map to UserError
            MqttV500ConnectReasonCode.BadUserNameOrPassword => WebPubSubErrorCode.UserError,
            MqttV500ConnectReasonCode.ClientIdentifierNotValid => WebPubSubErrorCode.UserError,
            MqttV500ConnectReasonCode.MalformedPacket => WebPubSubErrorCode.UserError,
            MqttV500ConnectReasonCode.UnsupportedProtocolVersion => WebPubSubErrorCode.UserError,
            MqttV500ConnectReasonCode.BadAuthenticationMethod => WebPubSubErrorCode.UserError,
            MqttV500ConnectReasonCode.TopicNameInvalid => WebPubSubErrorCode.UserError,
            MqttV500ConnectReasonCode.PayloadFormatInvalid => WebPubSubErrorCode.UserError,
            MqttV500ConnectReasonCode.Banned => WebPubSubErrorCode.UserError,
            MqttV500ConnectReasonCode.ConnectionRateExceeded => WebPubSubErrorCode.UserError,
            MqttV500ConnectReasonCode.ImplementationSpecificError => WebPubSubErrorCode.UserError,
            MqttV500ConnectReasonCode.PacketTooLarge => WebPubSubErrorCode.UserError,
            MqttV500ConnectReasonCode.QuotaExceeded => WebPubSubErrorCode.UserError,
            MqttV500ConnectReasonCode.RetainNotSupported => WebPubSubErrorCode.UserError,
            MqttV500ConnectReasonCode.QosNotSupported => WebPubSubErrorCode.UserError,

            // Map to ServerError
            MqttV500ConnectReasonCode.UseAnotherServer => WebPubSubErrorCode.ServerError,
            MqttV500ConnectReasonCode.ServerMoved => WebPubSubErrorCode.ServerError,
            MqttV500ConnectReasonCode.ServerUnavailable => WebPubSubErrorCode.ServerError,
            MqttV500ConnectReasonCode.ServerBusy => WebPubSubErrorCode.ServerError,
            MqttV500ConnectReasonCode.UnspecifiedError => WebPubSubErrorCode.ServerError,

            // These don't directly map and will throw an exception.
            //MqttV50ConnectReasonCode.Success => throw new ArgumentOutOfRangeException(nameof(code), code, "Success is not an error"),
            MqttV500ConnectReasonCode.ProtocolError => throw new ArgumentOutOfRangeException(nameof(code), code, "Protocol Error"),

            _ => throw new ArgumentOutOfRangeException(nameof(code), code, "Unsupported MqttV500ConnectReasonCode")
        };
    }
}
