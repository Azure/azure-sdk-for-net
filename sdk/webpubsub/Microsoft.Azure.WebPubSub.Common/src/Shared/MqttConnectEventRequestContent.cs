// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common;

/// <summary>
/// Class to represent the request body of MqttConnectEvent for Newtonsoft.JSON deserialization.
/// <see cref="MqttConnectEventRequest"/> contains a field "ConnectionContext", which is not available during deserialization. Use a subclass to avoid a customized JSON converter./>
/// </summary>
internal class MqttConnectEventRequestContent
{
    internal const string ClaimsProperty = "claims";
    internal const string QueryProperty = "query";
    internal const string HeadersProperty = "headers";
    internal const string SubprotocolsProperty = "subprotocols";
    internal const string ClientCertificatesProperty = "clientCertificates";
    internal const string MqttPropertyName = "mqtt";

    /// <summary>
    /// User Claims.
    /// </summary>
    [JsonPropertyName(ClaimsProperty)]
    [DataMember(Name = ClaimsProperty)]
    public IReadOnlyDictionary<string, string[]> Claims { get; set; }

    /// <summary>
    /// Request query.
    /// </summary>
    [JsonPropertyName(QueryProperty)]
    [DataMember(Name = QueryProperty)]
    public IReadOnlyDictionary<string, string[]> Query { get; set; }

    /// <summary>
    /// Request headers.
    /// </summary>
    [JsonPropertyName(HeadersProperty)]
    [DataMember(Name = HeadersProperty)]
    public IReadOnlyDictionary<string, string[]> Headers { get; set; }

    /// <summary>
    /// Supported subprotocols.
    /// </summary>
    [JsonPropertyName(SubprotocolsProperty)]
    [DataMember(Name = SubprotocolsProperty)]
    public IReadOnlyList<string> Subprotocols { get; set; }

    /// <summary>
    /// Client certificates.
    /// </summary>
    [JsonPropertyName(ClientCertificatesProperty)]
    [DataMember(Name = ClientCertificatesProperty)]
    public IReadOnlyList<WebPubSubClientCertificate> ClientCertificates { get; set; }

    /// <summary>
    /// The properties of the MQTT CONNECT packet.
    /// </summary>
    [DataMember(Name = MqttPropertyName)]
    [JsonPropertyName(MqttPropertyName)]
    public MqttConnectProperties Mqtt { get; set; }
}