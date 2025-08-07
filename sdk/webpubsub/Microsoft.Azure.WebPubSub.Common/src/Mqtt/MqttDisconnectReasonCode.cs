// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebPubSub.Common;

#nullable enable

/// <summary>
/// MQTT Disconnect Reason Codes
/// These codes represent the reasons for disconnecting an MQTT client as per MQTT 5.0 specification.
/// </summary>
public enum MqttDisconnectReasonCode : byte
{
    /// <summary>
    /// 0x00 - Normal disconnection
    /// Sent by: Client or Server
    /// Description: Close the connection normally. Do not send the Will Message.
    /// </summary>
    NormalDisconnection = 0x00,

    /// <summary>
    /// 0x04 - Disconnect with Will Message
    /// Sent by: Client
    /// Description: The Client wishes to disconnect but requires that the Server also publishes its Will Message.
    /// </summary>
    DisconnectWithWillMessage = 0x04,

    /// <summary>
    /// 0x80 - Unspecified error
    /// Sent by: Client or Server
    /// Description: The Connection is closed but the sender either does not wish to reveal the reason, or none of the other Reason Codes apply.
    /// </summary>
    UnspecifiedError = 0x80,

    /// <summary>
    /// 0x81 - Malformed Packet
    /// Sent by: Client or Server
    /// Description: The received packet does not conform to this specification.
    /// </summary>
    MalformedPacket = 0x81,

    /// <summary>
    /// 0x82 - Protocol Error
    /// Sent by: Client or Server
    /// Description: An unexpected or out of order packet was received.
    /// </summary>
    ProtocolError = 0x82,

    /// <summary>
    /// 0x83 - Implementation specific error
    /// Sent by: Client or Server
    /// Description: The packet received is valid but cannot be processed by this implementation.
    /// </summary>
    ImplementationSpecificError = 0x83,

    /// <summary>
    /// 0x87 - Not authorized
    /// Sent by: Server
    /// Description: The request is not authorized.
    /// </summary>
    NotAuthorized = 0x87,

    /// <summary>
    /// 0x89 - Server busy
    /// Sent by: Server
    /// Description: The Server is busy and cannot continue processing requests from this Client.
    /// </summary>
    ServerBusy = 0x89,

    /// <summary>
    /// 0x8B - Server shutting down
    /// Sent by: Server
    /// Description: The Server is shutting down.
    /// </summary>
    ServerShuttingDown = 0x8B,

    /// <summary>
    /// 0x8D - Keep Alive timeout
    /// Sent by: Server
    /// Description: The Connection is closed because no packet has been received for 1.5 times the Keepalive time.
    /// </summary>
    KeepAliveTimeout = 0x8D,

    /// <summary>
    /// 0x8E - Session taken over
    /// Sent by: Server
    /// Description: Another Connection using the same ClientID has connected causing this Connection to be closed.
    /// </summary>
    SessionTakenOver = 0x8E,

    /// <summary>
    /// 0x8F - Topic Filter invalid
    /// Sent by: Server
    /// Description: The Topic Filter is correctly formed, but is not accepted by this Server.
    /// </summary>
    TopicFilterInvalid = 0x8F,

    /// <summary>
    /// 0x90 - Topic Name invalid
    /// Sent by: Client or Server
    /// Description: The Topic Name is correctly formed, but is not accepted by this Client or Server.
    /// </summary>
    TopicNameInvalid = 0x90,

    /// <summary>
    /// 0x93 - Receive Maximum exceeded
    /// Sent by: Client or Server
    /// Description: The Client or Server has received more than Receive Maximum publication for which it has not sent PUBACK or PUBCOMP.
    /// </summary>
    ReceiveMaximumExceeded = 0x93,

    /// <summary>
    /// 0x94 - Topic Alias invalid
    /// Sent by: Client or Server
    /// Description: The Client or Server has received a PUBLISH packet containing a Topic Alias which is greater than the Maximum Topic Alias it sent in the CONNECT or CONNACK packet.
    /// </summary>
    TopicAliasInvalid = 0x94,

    /// <summary>
    /// 0x95 - Packet too large
    /// Sent by: Client or Server
    /// Description: The packet size is greater than Maximum Packet Size for this Client or Server.
    /// </summary>
    PacketTooLarge = 0x95,

    /// <summary>
    /// 0x96 - Message rate too high
    /// Sent by: Client or Server
    /// Description: The received data rate is too high.
    /// </summary>
    MessageRateTooHigh = 0x96,

    /// <summary>
    /// 0x97 - Quota exceeded
    /// Sent by: Client or Server
    /// Description: An implementation or administrative imposed limit has been exceeded.
    /// </summary>
    QuotaExceeded = 0x97,

    /// <summary>
    /// 0x98 - Administrative action
    /// Sent by: Client or Server
    /// Description: The Connection is closed due to an administrative action.
    /// </summary>
    AdministrativeAction = 0x98,

    /// <summary>
    /// 0x99 - Payload format invalid
    /// Sent by: Client or Server
    /// Description: The payload format does not match the one specified by the Payload Format Indicator.
    /// </summary>
    PayloadFormatInvalid = 0x99,

    /// <summary>
    /// 0x9A - Retain not supported
    /// Sent by: Server
    /// Description: The Server does not support retained messages.
    /// </summary>
    RetainNotSupported = 0x9A,

    /// <summary>
    /// 0x9B - QoS not supported
    /// Sent by: Server
    /// Description: The Client specified a QoS greater than the QoS specified in a Maximum QoS in the CONNACK.
    /// </summary>
    QosNotSupported = 0x9B,

    /// <summary>
    /// 0x9C - Use another server
    /// Sent by: Server
    /// Description: The Client should temporarily change its Server.
    /// </summary>
    UseAnotherServer = 0x9C,

    /// <summary>
    /// 0x9D - Server moved
    /// Sent by: Server
    /// Description: The Server is moved and the Client should permanently change its server location.
    /// </summary>
    ServerMoved = 0x9D,

    /// <summary>
    /// 0x9E - Shared Subscriptions not supported
    /// Sent by: Server
    /// Description: The Server does not support Shared Subscriptions.
    /// </summary>
    SharedSubscriptionsNotSupported = 0x9E,

    /// <summary>
    /// 0x9F - Connection rate exceeded
    /// Sent by: Server
    /// Description: This connection is closed because the connection rate is too high.
    /// </summary>
    ConnectionRateExceeded = 0x9F,

    /// <summary>
    /// 0xA0 - Maximum connect time
    /// Sent by: Server
    /// Description: The maximum connection time authorized for this connection has been exceeded.
    /// </summary>
    MaximumConnectTime = 0xA0,

    /// <summary>
    /// 0xA1 - Subscription Identifiers not supported
    /// Sent by: Server
    /// Description: The Server does not support Subscription Identifiers; the subscription is not accepted.
    /// </summary>
    SubscriptionIdentifiersNotSupported = 0xA1,

    /// <summary>
    /// 0xA2 - Wildcard Subscriptions not supported
    /// Sent by: Server
    /// Description: The Server does not support Wildcard Subscriptions; the subscription is not accepted.
    /// </summary>
    WildcardSubscriptionsNotSupported = 0xA2
}