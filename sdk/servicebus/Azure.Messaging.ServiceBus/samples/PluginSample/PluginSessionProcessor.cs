// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace Plugins
{
    #region Snippet:PluginSessionProcessor
    public class PluginSessionProcessor : ServiceBusSessionProcessor
    {
        private IEnumerable<Func<ServiceBusReceivedMessage, Task>> _plugins;

        internal PluginSessionProcessor(string queueName, ServiceBusClient client, IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins, ServiceBusSessionProcessorOptions options) :
            base(client, queueName, options)
        {
            _plugins = plugins;
        }

        internal PluginSessionProcessor(string topicName, string subscriptionName, ServiceBusClient client, IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins, ServiceBusSessionProcessorOptions options) :
            base(client, topicName, subscriptionName, options)
        {
            _plugins = plugins;
        }

        protected override async Task OnProcessSessionMessageAsync(ProcessSessionMessageEventArgs args)
        {
            foreach (var plugin in _plugins)
            {
                await plugin.Invoke(args.Message);
            }

            await base.OnProcessSessionMessageAsync(args);
        }

        protected override Task OnProcessErrorAsync(ProcessErrorEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
    #endregion
}