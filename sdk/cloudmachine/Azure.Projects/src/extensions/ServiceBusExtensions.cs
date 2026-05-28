// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using Azure.Core;
using Azure.Messaging.ServiceBus;

namespace Azure.Projects;

/// <summary>
/// Extension methods for <see cref="ProjectClient"/>.
/// </summary>
public static class ServiceBusExtensions
{
    /// <summary>
    /// Creates a <see cref="ServiceBusClient"/> instance using the connection string from the project client.
    /// </summary>
    /// <param name="provider"></param>
    /// <param name="namespaceName"></param>
    /// <returns></returns>
    public static  ServiceBusClient GetServiceBusClient(this ClientConnectionProvider provider, string namespaceName = default)
    {
        ServiceBusClientKey serviceBusClientKey = new(namespaceName);
        ServiceBusClient client = provider.Subclients.GetClient(serviceBusClientKey, () => CreateClient(provider, namespaceName));
        return client;
    }

    /// <summary>
    /// Creates a <see cref="ServiceBusSender"/> instance using the connection string from the project client.
    /// </summary>
    /// <param name="project"></param>
    /// <param name="namespaceName"></param>
    /// <param name="topicName"></param>
    /// <returns></returns>
    public static ServiceBusSender GetServiceBusSender(this ClientConnectionProvider project, string namespaceName, string topicName)
    {
        ServiceBusSenderKey serviceBusSenderKey = new(namespaceName, topicName);
        ServiceBusSender sender = project.Subclients.GetClient(serviceBusSenderKey, () => CreateSender(project, namespaceName, topicName));
        return sender;
    }

    /// <summary>
    /// Creates a <see cref="ServiceBusProcessor"/> instance using the connection string from the project client.
    /// </summary>
    /// <param name="project"></param>
    /// <param name="namespaceName"></param>
    /// <param name="subscriptionName"></param>
    /// <returns></returns>
    public static ServiceBusProcessor GetServiceBusProcessor(this ClientConnectionProvider project, string namespaceName, string subscriptionName)
    {
        ServiceBusProcessorKey serviceBusProcessorKey = new(namespaceName, subscriptionName);
        ServiceBusProcessor processor = project.Subclients.GetClient(serviceBusProcessorKey, () =>
            CreateProcessor(project, namespaceName, subscriptionName)
        );
        return processor;
    }

    private static ServiceBusSender CreateSender(ClientConnectionProvider project, string namespaceName, string topicName)
    {
        ServiceBusClient client = project.GetServiceBusClient(namespaceName);
        ServiceBusSender sender = client.CreateSender(topicName);
        return sender;
    }
    private static ServiceBusClient CreateClient(ClientConnectionProvider project, string namespaceName)
    {
        ClientConnection connection = project.GetConnection(typeof(ServiceBusClient).FullName);

        if (!connection.TryGetLocatorAsUri(out Uri uri))
        {
            throw new InvalidOperationException("The connection is not a valid URI.");
        }

        ServiceBusClient client = new(uri.AbsoluteUri, (TokenCredential)connection.Credential);
        return client;
    }
    private static ServiceBusProcessor CreateProcessor(ClientConnectionProvider project, string namespaceName, string subscriptionName)
    {
        ServiceBusClient client = project.GetServiceBusClient(namespaceName);

        ClientConnection connection = project.GetConnection(subscriptionName);
        string[] topicAndSubscription = connection.Locator.Split('/');
        ServiceBusProcessor processor = client.CreateProcessor(topicAndSubscription[0], topicAndSubscription[1], new() { MaxConcurrentCalls = 5 });
        processor.ProcessErrorAsync += (args) => throw new Exception("error processing event", args.Exception);
        return processor;
    }

    private record ServiceBusClientKey(string NamespaceName);

    private record ServiceBusSenderKey(string NamespaceName, string TopicName);

    private record ServiceBusProcessorKey(string NamespaceName, string SubscriptionName);
}
