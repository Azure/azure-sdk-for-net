// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
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

    private readonly ServiceBusSender _sender;
    private readonly ServiceBusProcessor _processor;

    internal MessagingServices(ProjectClient project) {
        ServiceBusClient sb = project.GetServiceBusClient(project.ProjectId);
        _sender = project.GetServiceBusSender(project.ProjectId, "cm_servicebus_topic_private");
        _processor = project.GetServiceBusProcessor(project.ProjectId, "cm_servicebus_subscription_private");
    }

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
        BinaryData serialized = BinaryData.FromObjectAsJson(serializable);
        ServiceBusMessage message = new(serialized);
        await _sender.SendMessageAsync(message).ConfigureAwait(false);
    }

    /// <summary>
    /// Adds a function to be called when a message is received.
    /// </summary>
    /// <param name="received"></param>
    public void WhenMessageReceived(Action<string> received)
    {
        // TODO: How to unsubscribe?
        // TODO: Use a subscription filter to ignore Event Grid system events
        _processor.ProcessMessageAsync += async (args) =>
        {
            received(args.Message.Body.ToString());
            await args.CompleteMessageAsync(args.Message).ConfigureAwait(false);
            await Task.CompletedTask.ConfigureAwait(false);
        };
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
        _processor.StartProcessingAsync().GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
    }
}
