// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common;

#nullable enable

/// <summary>
/// Represents the properties of an MQTT disconnection event.
/// </summary>
[DataContract]
[JsonConverter(typeof(MqttDisconnectedEventRequestPropertiesJsonConverter))]
public class MqttDisconnectedEventRequestProperties
{
    internal const string InitiatedByClientProperty = "initiatedByClient";
    internal const string DisconnectPacketProperty = "disconnectPacket";

    /// <summary>
    /// Indicates whether the disconnection is initiated by the client.
    /// </summary>
    [DataMember(Name = InitiatedByClientProperty)]
    public bool InitiatedByClient { get; internal set; }

    internal MqttDisconnectedEventRequestProperties() { }

    ///// <summary>
    ///// The DISCONNECT packet properties to end the last physical connection. It may be sent by the client or server.
    /////</summary>
    //[IgnoreDataMember]
    //internal MqttDisconnectPacketProperties? DisconnectPacket { get; }

    //internal MqttDisconnectedEventRequestProperties(bool initiatedByClient, MqttDisconnectPacketProperties? disconnectPacket)
    //{
    //    InitiatedByClient = initiatedByClient;
    //    DisconnectPacket = disconnectPacket;
    //}
}
