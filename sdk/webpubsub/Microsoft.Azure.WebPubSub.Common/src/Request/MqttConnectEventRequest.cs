// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common;

/// <summary>
/// MQTT Connect event request. It's sent when a MQTT client connects to the service.
/// </summary>
[DataContract]
public class MqttConnectEventRequest : ConnectEventRequest
{
    internal const string MqttPropertyName = "mqtt";
    private static readonly string[] MqttWebSocketSubprotocol = new string[] { "mqtt" };

    /// <summary>
    /// Creates a new instance of <see cref="MqttConnectEventRequest"/>.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="claims"></param>
    /// <param name="query"></param>
    /// <param name="certificates"></param>
    /// <param name="headers"></param>
    /// <param name="mqtt"></param>
    public MqttConnectEventRequest(MqttConnectionContext context, IReadOnlyDictionary<string, string[]> claims, IReadOnlyDictionary<string, string[]> query, IEnumerable<WebPubSubClientCertificate> certificates, IReadOnlyDictionary<string, string[]> headers, MqttConnectProperties mqtt) : base(context, claims, query, MqttWebSocketSubprotocol, certificates, headers)
    {
        Mqtt = mqtt;
    }

    /// <summary>
    /// The properties of the MQTT CONNECT packet.
    /// </summary>
    [DataMember(Name = MqttPropertyName)]
    [JsonPropertyName(MqttPropertyName)]
    public MqttConnectProperties Mqtt { get; }

    /// <summary>
    /// Create <see cref="EventErrorResponse"/> with general Web PubSub error code.
    /// </summary>
    /// <param name="code"><see cref="WebPubSubErrorCode"/>.</param>
    /// <param name="message">Detail error message.</param>
    /// <returns>A error response to return caller and will drop connection.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override EventErrorResponse CreateErrorResponse(WebPubSubErrorCode code, string? message = null)
    {
        return Mqtt.ProtocolVersion switch
        {
            MqttProtocolVersion.V311 => new MqttConnectEventErrorResponse(code.ToMqttV311ConnectReturnCode(), message),
            MqttProtocolVersion.V500 => new MqttConnectEventErrorResponse(code.ToMqttV500ConnectReasonCode(), message),
            _ => throw new ArgumentOutOfRangeException($"MQTT protocol version {Mqtt.ProtocolVersion} is invalid.")
        };
    }

    /// <summary>
    /// Create <see cref="MqttConnectEventResponse"/>.
    /// </summary>
    /// <param name="userId">Caller userId for current connection.</param>
    /// <param name="roles">User roles applied to current connection.</param>
    /// <param name="groups">Groups applied to current connection.</param>
    /// <returns>A connect response to return service.</returns>
    public MqttConnectEventResponse CreateMqttResponse(string userId, IEnumerable<string> groups, IEnumerable<string> roles)
    {
        return new MqttConnectEventResponse(userId, groups, roles);
    }

    /// <summary>
    /// Creates error response for MQTT protocol 5.0.
    /// </summary>
    /// <param name="code"></param>
    /// <param name="message"></param>
    /// <returns>A error response to return caller and will drop connection.</returns>
    public MqttConnectEventErrorResponse CreateMqttV50ErrorResponse(MqttV500ConnectReasonCode code, string? message = null)
    {
        if (Mqtt.ProtocolVersion != MqttProtocolVersion.V500)
        {
            throw new InvalidOperationException("The MQTT protocol version of the client is not 5.0.");
        }
        return new MqttConnectEventErrorResponse(code, message);
    }

    /// <summary>
    /// Creates error response for MQTT protocol 3.1.1.
    /// </summary>
    /// <param name="code"></param>
    /// <param name="message"></param>
    /// <returns>A error response to return caller and will drop connection.</returns>
    public MqttConnectEventErrorResponse CreateMqttV311ErrorResponse(MqttV311ConnectReturnCode code, string? message = null)
    {
        if (Mqtt.ProtocolVersion != MqttProtocolVersion.V311)
        {
            throw new InvalidOperationException("The MQTT protocol version of the client is not 3.1.1.");
        }
        return new MqttConnectEventErrorResponse(code, message);
    }
}
