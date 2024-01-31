// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace Plugins
{
    #region Snippet:PluginReceiver
    public class PluginReceiver : ServiceBusReceiver
    {
        private IEnumerable<Func<ServiceBusReceivedMessage, Task>> _plugins;

        internal PluginReceiver(string queueName, ServiceBusClient client, IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins, ServiceBusReceiverOptions options) :
            base(client, queueName, options)
        {
            _plugins = plugins;
        }

        internal PluginReceiver(string topicName, string subscriptionName, ServiceBusClient client, IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins, ServiceBusReceiverOptions options) :
            base(client, topicName, subscriptionName, options)
        {
            _plugins = plugins;
        }

        public override async Task<ServiceBusReceivedMessage> ReceiveMessageAsync(TimeSpan? maxWaitTime = null, CancellationToken cancellationToken = default)
        {
            ServiceBusReceivedMessage message = await base.ReceiveMessageAsync(maxWaitTime, cancellationToken).ConfigureAwait(false);

            foreach (var plugin in _plugins)
            {
                await plugin.Invoke(message);
            }
            return message;
        }
    }
    #endregion
}