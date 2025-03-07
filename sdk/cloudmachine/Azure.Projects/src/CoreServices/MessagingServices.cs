// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus;

namespace Azure.Projects;

/// <summary>
/// The messaging services for the project client.
/// </summary>
public readonly struct MessagingServices
{
    internal const string DEFAULT_SB_TOPIC = "cm_servicebus_default_topic";

    private readonly ProjectClient _cm;
    internal MessagingServices(ProjectClient cm) => _cm = cm;

    /// <summary>
    /// Sends a message to the service bus.
    /// </summary>
    /// <param name="serializable"></param>
    public void SendJson(object serializable)
    {
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
        SendJsonAsync(serializable).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
    }

    /// <summary>
    /// Sends a message to the service bus.
    /// </summary>
    /// <param name="serializable"></param>
    public async Task SendJsonAsync(object serializable)
    {
        ServiceBusSender sender = GetServiceBusSender();

        BinaryData serialized = BinaryData.FromObjectAsJson(serializable);
        ServiceBusMessage message = new(serialized);
        await sender.SendMessageAsync(message).ConfigureAwait(false);
    }

    /// <summary>
    /// Adds a function to be called when a message is received.
    /// </summary>
    /// <param name="received"></param>
    public void WhenMessageReceived(Action<string> received)
    {
        ServiceBusProcessor processor = _cm.Messaging.GetServiceBusProcessor(default);
        ProjectClient cm = _cm;

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
        ServiceBusClient client = _cm.Subclients.GetClient(() => messagingServices.CreateClient(), null);
        return client;
    }

    private ServiceBusSender GetServiceBusSender()
    {
        MessagingServices messagingServices = this;
        ServiceBusSender sender = _cm.Subclients.GetClient(() => messagingServices.CreateSender(), null);
        return sender;
    }

    internal ServiceBusProcessor GetServiceBusProcessor(string subscriptionName)
    {
        MessagingServices messagingServices = this;
        ServiceBusProcessor processor = _cm.Subclients.GetClient(() => messagingServices.CreateProcessor(subscriptionName), subscriptionName);
        return processor;
    }

    private ServiceBusSender CreateSender()
    {
        ServiceBusClient client = GetServiceBusClient();

        ClientConnection connection = _cm.GetConnection(DEFAULT_SB_TOPIC);
        ServiceBusSender sender = client.CreateSender(connection.Locator);
        return sender;
    }
    private ServiceBusClient CreateClient()
    {
        ClientConnection connection = _cm.GetConnection(typeof(ServiceBusClient).FullName);

        if (!connection.TryGetLocatorAsUri(out Uri uri))
        {
            throw new InvalidOperationException("The connection is not a valid URI.");
        }

        ServiceBusClient client = new(uri.AbsoluteUri, (TokenCredential)connection.Credential);
        return client;
    }
    private ServiceBusProcessor CreateProcessor(string subscriptionName)
    {
        ServiceBusClient client = GetServiceBusClient();

        ClientConnection connection = _cm.GetConnection(subscriptionName);
        string[] topicAndSubscription = connection.Locator.Split('/');
        ServiceBusProcessor processor = client.CreateProcessor(topicAndSubscription[0], topicAndSubscription[1], new() { MaxConcurrentCalls = 5 });
        processor.ProcessErrorAsync += (args) => throw new Exception("error processing event", args.Exception);
        return processor;
    }
}
