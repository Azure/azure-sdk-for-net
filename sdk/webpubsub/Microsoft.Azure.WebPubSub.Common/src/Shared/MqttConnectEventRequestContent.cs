// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Microsoft.Azure.WebPubSub.Common;

/// <summary>
/// Class to represent the request body of MqttConnectEvent for Newtonsoft.JSON deserialization.
/// <see cref="MqttConnectEventRequest"/> contains a field "ConnectionContext", which is not available during deserialization. Use a subclass to avoid a customized JSON converter./>
/// </summary>
internal class MqttConnectEventRequestContent : MqttConnectEventRequest
{
    public MqttConnectEventRequestContent(IReadOnlyDictionary<string, string[]> claims, IReadOnlyDictionary<string, string[]> query, IReadOnlyDictionary<string, string[]> headers, IReadOnlyList<string> subprotocols, IReadOnlyList<WebPubSubClientCertificate> clientCertificates, MqttConnectProperties mqtt) : base(null, claims, query, clientCertificates, headers, mqtt) { }
}