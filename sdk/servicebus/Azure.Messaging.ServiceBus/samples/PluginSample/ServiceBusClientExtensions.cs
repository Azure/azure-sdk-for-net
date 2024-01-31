// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace Plugins
{
    public static class ServiceBusClientExtensions
    {
        #region Snippet:ServiceBusExtensions
        public static PluginSender CreatePluginSender(
            this ServiceBusClient client,
            string queueOrTopicName,
            IEnumerable<Func<ServiceBusMessage, Task>> plugins)
        {
            return new PluginSender(queueOrTopicName, client, plugins);
        }

        public static PluginReceiver CreatePluginReceiver(
            this ServiceBusClient client,
            string queueName,
            IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins,
            ServiceBusReceiverOptions options = default)
        {
            return new PluginReceiver(queueName, client, plugins, options ?? new ServiceBusReceiverOptions());
        }

        public static PluginReceiver CreatePluginReceiver(
            this ServiceBusClient client,
            string topicName,
            string subscriptionName,
            IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins,
            ServiceBusReceiverOptions options = default)
        {
            return new PluginReceiver(topicName, subscriptionName, client, plugins, options ?? new ServiceBusReceiverOptions());
        }

        public static PluginProcessor CreatePluginProcessor(
            this ServiceBusClient client,
            string queueName,
            IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins,
            ServiceBusProcessorOptions options = default)
        {
            return new PluginProcessor(queueName, client, plugins, options ?? new ServiceBusProcessorOptions());
        }

        public static PluginProcessor CreatePluginProcessor(
            this ServiceBusClient client,
            string topicName,
            string subscriptionName,
            IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins,
            ServiceBusProcessorOptions options = default)
        {
            return new PluginProcessor(topicName, subscriptionName, client, plugins, options ?? new ServiceBusProcessorOptions());
        }

        public static PluginSessionProcessor CreatePluginSessionProcessor(
            this ServiceBusClient client,
            string queueName,
            IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins,
            ServiceBusSessionProcessorOptions options = default)
        {
            return new PluginSessionProcessor(queueName, client, plugins, options ?? new ServiceBusSessionProcessorOptions());
        }

        public static PluginSessionProcessor CreatePluginSessionProcessor(
            this ServiceBusClient client,
            string topicName,
            string subscriptionName,
            IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins,
            ServiceBusSessionProcessorOptions options = default)
        {
            return new PluginSessionProcessor(topicName, subscriptionName, client, plugins, options ?? new ServiceBusSessionProcessorOptions());
        }
        #endregion

        public static async Task<PluginSessionReceiver> AcceptNextSessionPluginAsync(
            this ServiceBusClient client,
            string queueName,
            IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins,
            ServiceBusSessionReceiverOptions options = default,
            CancellationToken cancellationToken = default)
        {
            var receiver = await client.AcceptNextSessionAsync(queueName, options, cancellationToken);
            return new PluginSessionReceiver(receiver, plugins);
        }
    }
}