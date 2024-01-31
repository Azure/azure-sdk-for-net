// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace Plugins
{
    #region Snippet:PluginSender
    public class PluginSender : ServiceBusSender
    {
        private IEnumerable<Func<ServiceBusMessage, Task>> _plugins;

        internal PluginSender(string queueOrTopicName, ServiceBusClient client, IEnumerable<Func<ServiceBusMessage, Task>> plugins) : base(client, queueOrTopicName)
        {
            _plugins = plugins;
        }

        public override async Task SendMessageAsync(ServiceBusMessage message, CancellationToken cancellationToken = default)
        {
            foreach (var plugin in _plugins)
            {
                await plugin.Invoke(message);
            }
            await base.SendMessageAsync(message, cancellationToken).ConfigureAwait(false);
        }
    }
    #endregion
}