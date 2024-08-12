// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;

namespace Microsoft.Azure.WebPubSub.Common;

/// <summary>
/// A request that is sent when an MQTT session is created.
/// </summary>
[DataContract]
public sealed class MqttConnectedEventRequest : ConnectedEventRequest
{
    /// <summary>
    /// Creates a new instance of <see cref="MqttConnectedEventRequest"/>.
    /// </summary>
    /// <param name="context"></param>
    public MqttConnectedEventRequest(MqttConnectionContext context) : base(context)
    {
    }
}
