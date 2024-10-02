// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.ServiceBus;

namespace Azure.CloudMachine;

public static class MessagingServices
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "AZC0107:DO NOT call public asynchronous method in synchronous scope.", Justification = "<Pending>")]
    public static void Send(this CloudMachineClient cm, object serializable)
    {
        ServiceBusSender sender = cm.ClientCache.Get("cm_default_topic_sender", () =>
        {
            ServiceBusClient sb = cm.ClientCache.Get(cm.Properties.ServiceBusNamespace, () =>
            {
                ServiceBusClient sb = new(cm.Properties.ServiceBusNamespace, cm.Credential);
                return sb;
            });

            ServiceBusSender sender = sb.CreateSender("cm_default_topic_sender");
            return sender;
        });

        BinaryData serialized = BinaryData.FromObjectAsJson(serializable);
        ServiceBusMessage message = new(serialized);
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
        sender.SendMessageAsync(message).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
    }

    public static void StrartReceiving<T>(this CloudMachineClient cm, Action<T> handler)
    {
        throw new NotImplementedException();
    }

    public static void StrartReceiving<T>(this CloudMachineClient cm, Action<CloudMachineClient, T> handler)
    {
        ServiceBusReceiver receiver = cm.ClientCache.Get("cm_default_topic_receiver", () =>
        {
            ServiceBusClient sb = cm.ClientCache.Get(cm.Properties.ServiceBusNamespace, () =>
            {
                ServiceBusClient sb = new(cm.Properties.ServiceBusNamespace, cm.Credential);
                return sb;
            });

            ServiceBusReceiver receiver = sb.CreateReceiver("cm_default_topic_receiver");
            return receiver;
        });

        throw new NotImplementedException();
    }
}
