// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus;
using Azure.Provisioning.CloudMachine;

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
        var processor = _cm.Messaging.GetServiceBusProcessor();
        var cm = _cm;

        // TODO: How to unsubscribe?
        // TODO: Use a subscription filter to ignore Event Grid system events
        processor.ProcessMessageAsync += async (args) =>
        {
            received(args.Message.Body.ToString());
            await args.CompleteMessageAsync(args.Message).ConfigureAwait(false);
            await Task.CompletedTask.ConfigureAwait(false);
        };
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
        processor.StartProcessingAsync().GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
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
        ServiceBusSender sender = _cm.Subclients.Get(() => messagingServices.CreateSender());
        return sender;
    }

    internal ServiceBusProcessor GetServiceBusProcessor()
    {
        MessagingServices messagingServices = this;
        ServiceBusProcessor sender = _cm.Subclients.Get(() => messagingServices.CreateProcessor());
        return sender;
    }

    private ServiceBusSender CreateSender()
    {
        ServiceBusClient client = GetServiceBusClient();

        ClientConnectionOptions connection = _cm.GetConnectionOptions(typeof(ServiceBusClient));
        ServiceBusSender sender = client.CreateSender(connection.Id);
        return sender;
    }
    private ServiceBusClient CreateClient()
    {
        ClientConnectionOptions connection = _cm.GetConnectionOptions(typeof(ServiceBusClient));
        ServiceBusClient client = new(connection.Endpoint!.AbsoluteUri, connection.TokenCredential);
        return client;
    }
    private ServiceBusProcessor CreateProcessor()
    {
        ServiceBusClient client = GetServiceBusClient();

        ClientConnectionOptions connection = _cm.GetConnectionOptions(typeof(ServiceBusSender));
        ServiceBusProcessor processor = client.CreateProcessor(
            connection.Id,
            CloudMachineInfrastructure.SB_PRIVATE_SUB,
            new() { ReceiveMode = ServiceBusReceiveMode.PeekLock, MaxConcurrentCalls = 5 });
        processor.ProcessErrorAsync += (args) => throw new Exception("error processing event", args.Exception);
        return processor;
    }
}
