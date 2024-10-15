// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.ServiceBus;

namespace Azure.CloudMachine;

public readonly struct MessagingServices
{
    private readonly CloudMachineClient _cm;
    internal MessagingServices(CloudMachineClient cm) => _cm = cm;

    public void SendMessage(object serializable)
    {
        ServiceBusSender sender = GetSender();

        BinaryData serialized = BinaryData.FromObjectAsJson(serializable);
        ServiceBusMessage message = new(serialized);
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
        sender.SendMessageAsync(message).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
    }

    private ServiceBusSender GetSender()
    {
        string senderClientId = typeof(ServiceBusSender).FullName;
        CloudMachineClient cm = _cm;
        ServiceBusSender sender = _cm.Subclients.Get(senderClientId, () =>
        {
            string serviceBusClientId = typeof(ServiceBusClient).FullName;
            ServiceBusClient sb = cm.Subclients.Get(serviceBusClientId, () =>
            {
                string sbNamespace = cm.GetConfiguration(serviceBusClientId)!.Value.Endpoint;
                ServiceBusClient sb = new(sbNamespace, cm.Credential);
                return sb;
            });

            string ServiceBusSenderId = typeof(ServiceBusClient).FullName;
            string defaultTopic = cm.GetConfiguration(ServiceBusSenderId)!.Value.Endpoint;
            ServiceBusSender sender = sb.CreateSender(defaultTopic);
            return sender;
        });
        return sender;
    }

    public void WhenMessageReceived(Action<string> received)
    {
        throw new NotImplementedException();
    }
}
