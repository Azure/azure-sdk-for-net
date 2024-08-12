// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebPubSub.Common;

internal class MqttDisconnectedEventRequestDeserializationHelper
{
    public MqttDisconnectedEventRequestDeserializationHelper(string reason, MqttDisconnectedEventRequestProperties mqtt)
    {
        Reason = reason;
        Mqtt = mqtt;
    }

    public string Reason { get; }

    public MqttDisconnectedEventRequestProperties Mqtt { get; }
}
