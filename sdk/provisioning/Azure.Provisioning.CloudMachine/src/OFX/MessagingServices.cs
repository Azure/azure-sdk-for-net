// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Messaging.ServiceBus;

namespace Azure.CloudMachine;

public readonly struct MessagingServices
{
    private readonly CloudMachineClient _cm;
    internal MessagingServices(CloudMachineClient cm) => _cm = cm;

    public void SendMessage(object serializable)
    {
        ServiceBusSender sender = GetServiceBusSender();

        BinaryData serialized = BinaryData.FromObjectAsJson(serializable);
        ServiceBusMessage message = new(serialized);
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
        sender.SendMessageAsync(message).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
    }

    public void WhenMessageReceived(Action<string> received)
    {
        throw new NotImplementedException();
    }

    private ServiceBusClient GetServiceBusClient()
    {
        MessagingServices messagingServices = this;
        ServiceBusClient client = _cm.Subclients.Get(() => messagingServices.CreateClient());
        return client;
    }

    private ServiceBusSender GetServiceBusSender()
    {
        MessagingServices messagingServices = this;
        ServiceBusSender sender = _cm.Subclients.Get(() => messagingServices.GreateSender());
        return sender;
    }

    private ServiceBusSender GreateSender()
    {
        ServiceBusClient client = GetServiceBusClient();

        ClientConnectionOptions connection = _cm.GetConnectionOptions(typeof(ServiceBusClient));
        ServiceBusSender sender = client.CreateSender(connection.Id);
        return sender;
    }
    private ServiceBusClient CreateClient()
    {
        ClientConnectionOptions connection = _cm.GetConnectionOptions(typeof(ServiceBusClient));
        ServiceBusClient client = new(connection.Id, connection.TokenCredential);
        return client;
    }
}
