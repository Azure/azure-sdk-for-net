// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.ServiceBus;

namespace Azure.CloudMachine;

public static class MessagingServices
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "AZC0107:DO NOT call public asynchronous method in synchronous scope.", Justification = "<Pending>")]
    public static void SendMessage(this CloudMachineClient cm, object serializable)
    {
        string senderClientId = typeof(ServiceBusSender).FullName;
        ServiceBusSender sender = cm.Subclients.Get(senderClientId, () =>
        {
            string serviceBusClientId = typeof(ServiceBusClient).FullName;
            ServiceBusClient sb = cm.Subclients.Get(serviceBusClientId, () =>
            {
                string sbNamespace = cm.GetConnection(serviceBusClientId)!.Value.Endpoint;

                ServiceBusClient sb = new(sbNamespace, cm.Credential);
                return sb;
            });

            string ServiceBusSenderId = typeof(ServiceBusClient).FullName;
            string defaultTopic = cm.GetConnection(ServiceBusSenderId)!.Value.Endpoint;
            ServiceBusSender sender = sb.CreateSender(defaultTopic);
            return sender;
        });

        BinaryData serialized = BinaryData.FromObjectAsJson(serializable);
        ServiceBusMessage message = new(serialized);
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
        sender.SendMessageAsync(message).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
    }

    public static void WhenMessageReceived(this CloudMachineClient cm, Action<string> received)
    {
        throw new NotImplementedException();
    }
}
