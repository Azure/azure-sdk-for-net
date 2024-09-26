// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.ServiceBus;

namespace Azure.CloudMachine;

public static class MessagingServices
{
    public static void Send(this CloudMachineClient cm, object serializable)
    {
        ServiceBusSender sender = cm.ClientCache.Get("cm_default_topic", () =>
        {
            ServiceBusClient sb = new(cm.Properties.ServiceBusNamespace, cm.Credential);
            ServiceBusSender sender = sb.CreateSender("cm_default_topic");
            return sender;
        });

        BinaryData serialized = BinaryData.FromObjectAsJson(serializable);
        ServiceBusMessage message = new(serialized);
        sender.SendMessageAsync(message);
    }
}
