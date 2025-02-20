// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebPubSub.Common;

/// <summary>
/// MQTT Connect Reason Codes
/// These codes represent the reasons for the outcome of an MQTT CONNECT packet as per MQTT 5.0 specification.
/// </summary>
public enum MqttV500ConnectReasonCode : byte
{
    /// <summary>
    /// 0x80 - Unspecified error
    /// Description: The Server does not wish to reveal the reason for the failure, or none of the other Reason Codes apply.
    /// </summary>
    UnspecifiedError = 0x80,

    /// <summary>
    /// 0x81 - Malformed Packet
    /// Description: Data within the CONNECT packet could not be correctly parsed.
    /// </summary>
    MalformedPacket = 0x81,

    /// <summary>
    /// 0x82 - Protocol Error
    /// Description: Data in the CONNECT packet does not conform to this specification.
    /// </summary>
    ProtocolError = 0x82,

    /// <summary>
    /// 0x83 - Implementation specific error
    /// Description: The CONNECT is valid but is not accepted by this Server.
    /// </summary>
    ImplementationSpecificError = 0x83,

    /// <summary>
    /// 0x84 - Unsupported Protocol Version
    /// Description: The Server does not support the version of the MQTT protocol requested by the Client.
    /// </summary>
    UnsupportedProtocolVersion = 0x84,

    /// <summary>
    /// 0x85 - Client Identifier not valid
    /// Description: The Client Identifier is a valid string but is not allowed by the Server.
    /// </summary>
    ClientIdentifierNotValid = 0x85,

    /// <summary>
    /// 0x86 - Bad User Name or Password
    /// Description: The Server does not accept the User Name or Password specified by the Client.
    /// </summary>
    BadUserNameOrPassword = 0x86,

    /// <summary>
    /// 0x87 - Not authorized
    /// Description: The Client is not authorized to connect.
    /// </summary>
    NotAuthorized = 0x87,

    /// <summary>
    /// 0x88 - Server unavailable
    /// Description: The MQTT Server is not available.
    /// </summary>
    ServerUnavailable = 0x88,

    /// <summary>
    /// 0x89 - Server busy
    /// Description: The Server is busy. Try again later.
    /// </summary>
    ServerBusy = 0x89,

    /// <summary>
    /// 0x8A - Banned
    /// Description: This Client has been banned by administrative action. Contact the server administrator.
    /// </summary>
    Banned = 0x8A,

    /// <summary>
    /// 0x8C - Bad authentication method
    /// Description: The authentication method is not supported or does not match the authentication method currently in use.
    /// </summary>
    BadAuthenticationMethod = 0x8C,

    /// <summary>
    /// 0x90 - Topic Name invalid
    /// Description: The Will Topic Name is not malformed, but is not accepted by this Server.
    /// </summary>
    TopicNameInvalid = 0x90,

    /// <summary>
    /// 0x95 - Packet too large
    /// Description: The CONNECT packet exceeded the maximum permissible size.
    /// </summary>
    PacketTooLarge = 0x95,

    /// <summary>
    /// 0x97 - Quota exceeded
    /// Description: An implementation or administrative imposed limit has been exceeded.
    /// </summary>
    QuotaExceeded = 0x97,

    /// <summary>
    /// 0x99 - Payload format invalid
    /// Description: The Will Payload does not match the specified Payload Format Indicator.
    /// </summary>
    PayloadFormatInvalid = 0x99,

    /// <summary>
    /// 0x9A - Retain not supported
    /// Description: The Server does not support retained messages, and Will Retain was set to 1.
    /// </summary>
    RetainNotSupported = 0x9A,

    /// <summary>
    /// 0x9B - QoS not supported
    /// Description: The Server does not support the QoS set in Will QoS.
    /// </summary>
    QosNotSupported = 0x9B,

    /// <summary>
    /// 0x9C - Use another server
    /// Description: The Client should temporarily use another server.
    /// </summary>
    UseAnotherServer = 0x9C,

    /// <summary>
    /// 0x9D - Server moved
    /// Description: The Client should permanently use another server.
    /// </summary>
    ServerMoved = 0x9D,

    /// <summary>
    /// 0x9F - Connection rate exceeded
    /// Description: The connection rate limit has been exceeded.
    /// </summary>
    ConnectionRateExceeded = 0x9F
}
