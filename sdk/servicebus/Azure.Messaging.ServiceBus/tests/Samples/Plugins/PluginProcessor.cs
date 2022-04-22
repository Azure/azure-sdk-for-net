// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    #region Snippet:PluginProcessor
    public class PluginProcessor : ServiceBusProcessor
    {
        private IEnumerable<Func<ServiceBusReceivedMessage, Task>> _plugins;

        internal PluginProcessor(string queueName, ServiceBusClient client, IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins, ServiceBusProcessorOptions options) :
            base(client, queueName, options)
        {
            _plugins = plugins;
        }

        internal PluginProcessor(string topicName, string subscriptionName, ServiceBusClient client, IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins, ServiceBusProcessorOptions options) :
            base(client, topicName, subscriptionName, options)
        {
            _plugins = plugins;
        }

        protected internal override async Task OnProcessMessageAsync(ProcessMessageEventArgs args)
        {
            foreach (var plugin in _plugins)
            {
                await plugin.Invoke(args.Message);
            }

            await base.OnProcessMessageAsync(args);
        }
    }
    #endregion
}