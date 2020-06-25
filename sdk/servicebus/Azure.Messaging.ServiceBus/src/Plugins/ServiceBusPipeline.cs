// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Diagnostics;
using Azure.Messaging.ServiceBus.Plugins;

namespace Azure.Messaging.ServiceBus
{
    internal class ServiceBusPipeline
    {
        private ReadOnlyMemory<ServiceBusPlugin> _pipeline;

        public ServiceBusPipeline(ReadOnlyMemory<ServiceBusPlugin> pipeline)
        {
            _pipeline = pipeline;
        }

        public ValueTask ProcessSendAsync(ServiceBusMessage message)
        {
            if (_pipeline.Length > 0)
            {
                return _pipeline.Span[0].ProcessSendAsync(message, _pipeline.Slice(1));
            }
            return default;
        }
        public ValueTask ProcessReceiveAsync(ServiceBusReceivedMessage message)
        {
            if (_pipeline.Length > 0)
            {
                return _pipeline.Span[0].ProcessReceiveAsync(message, _pipeline.Slice(1));
            }
            return default;
        }
    }
}
