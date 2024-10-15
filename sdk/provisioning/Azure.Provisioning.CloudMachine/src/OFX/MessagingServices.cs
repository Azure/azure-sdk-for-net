// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Azure.Provisioning.CloudMachine;

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

            string ServiceBusSenderId = typeof(ServiceBusSender).FullName;
            string defaultTopic = cm.GetConfiguration(ServiceBusSenderId)!.Value.Endpoint;
            ServiceBusSender sender = sb.CreateSender(defaultTopic);
            return sender;
        });
        return sender;
    }

    internal ServiceBusProcessor GetProcessor()
    {
        string processorClientId = typeof(ServiceBusProcessor).FullName;
        CloudMachineClient cm = _cm;
        ServiceBusProcessor processor = cm.Subclients.Get(processorClientId, () =>
        {
            string serviceBusClientId = typeof(ServiceBusClient).FullName;
            ServiceBusClient sb = cm.Subclients.Get(serviceBusClientId, () =>
            {
                string sbNamespace = cm.GetConfiguration(serviceBusClientId)!.Value.Endpoint;
                ServiceBusClient sb = new(sbNamespace, cm.Credential);
                return sb;
            });

            string ServiceBusSenderId = typeof(ServiceBusSender).FullName;
            string defaultTopic = cm.GetConfiguration(ServiceBusSenderId)!.Value.Endpoint;
            ServiceBusProcessor processor = sb.CreateProcessor(
                defaultTopic,
                CloudMachineInfrastructure.SB_PRIVATE_SUB,
                new() { ReceiveMode = ServiceBusReceiveMode.PeekLock, MaxConcurrentCalls = 5 });
        processor.ProcessErrorAsync += (args) => throw new Exception("error processing event", args.Exception);
            return processor;
        });
        return processor;
    }

    public void WhenMessageReceived(Action<string> received)
    {
        var processor = _cm.Messaging.GetProcessor();
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
}
