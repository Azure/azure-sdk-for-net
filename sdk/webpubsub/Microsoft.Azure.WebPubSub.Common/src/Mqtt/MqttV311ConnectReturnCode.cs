// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebPubSub.Common;

/// <summary>
/// MQTT 3.1.1 Connect Return Codes.
/// </summary>
public enum MqttV311ConnectReturnCode : byte
{
    /// <summary>
    /// 0x01: Connection refused, unacceptable protocol version
    /// The Server does not support the level of the MQTT protocol requested by the Client.
    /// </summary>
    UnacceptableProtocolVersion = 0x01,

    /// <summary>
    /// 0x02: Connection refused, identifier rejected
    /// The Client identifier is correct UTF-8 but not allowed by the Server.
    /// </summary>
    IdentifierRejected = 0x02,

    /// <summary>
    /// 0x03: Connection refused, server unavailable
    /// The Network Connection has been made but the MQTT service is unavailable.
    /// </summary>
    ServerUnavailable = 0x03,

    /// <summary>
    /// 0x04: Connection refused, bad user name or password
    /// The data in the user name or password is malformed.
    /// </summary>
    BadUsernameOrPassword = 0x04,

    /// <summary>
    /// 0x05: Connection refused, not authorized
    /// The Client is not authorized to connect.
    /// </summary>
    NotAuthorized = 0x05,
}