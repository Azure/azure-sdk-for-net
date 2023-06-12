// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace Plugins
{
    public class PluginSessionReceiver : ServiceBusSessionReceiver
    {
        private IEnumerable<Func<ServiceBusReceivedMessage, Task>> _plugins;
        private readonly ServiceBusSessionReceiver _receiver;

        internal PluginSessionReceiver(ServiceBusSessionReceiver receiver, IEnumerable<Func<ServiceBusReceivedMessage, Task>> plugins)
        {
            _plugins = plugins;
            _receiver = receiver;
        }

        public override async Task<ServiceBusReceivedMessage> ReceiveMessageAsync(TimeSpan? maxWaitTime = null, CancellationToken cancellationToken = default)
        {
            ServiceBusReceivedMessage message = await _receiver.ReceiveMessageAsync(maxWaitTime, cancellationToken).ConfigureAwait(false);

            foreach (var plugin in _plugins)
            {
                await plugin.Invoke(message);
            }
            return message;
        }

        public override async Task CloseAsync(CancellationToken cancellationToken = default)
        {
            await _receiver.CloseAsync(cancellationToken);
        }

        public override async ValueTask DisposeAsync()
        {
            await _receiver.DisposeAsync();
        }
    }
}