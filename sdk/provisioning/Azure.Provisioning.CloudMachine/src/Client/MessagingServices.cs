// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Azure.Provisioning.Expressions;

namespace Azure.CloudMachine;

public static class MessagingServices
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "AZC0107:DO NOT call public asynchronous method in synchronous scope.", Justification = "<Pending>")]
    public static void SendMessage(this CloudMachineClient cm, object serializable)
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

    public static void WhenMessageReceived(this CloudMachineClient cm, Action<string> received)
    {
        throw new NotImplementedException();
    }
}
