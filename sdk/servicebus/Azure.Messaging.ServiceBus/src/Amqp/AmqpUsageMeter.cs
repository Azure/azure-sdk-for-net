// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Microsoft.Azure.Amqp;

namespace Azure.Messaging.ServiceBus.Amqp
{
    internal class AmqpUsageMeter : IAmqpUsageMeter
    {
        private readonly ServiceBusTransportMetrics _metrics;

        public AmqpUsageMeter(ServiceBusTransportMetrics metrics)
        {
            _metrics = metrics;
        }
        public void OnTransportWrite(int bufferSize, int writeSize, long queueSize, long latencyTicks)
        {
            // not implemented
        }

        public void OnTransportRead(int bufferSize, int readSize, int cacheHits, long latencyTicks)
        {
            // not implemented
        }

        public void OnRead(AmqpConnection connection, ulong frameCode, int numberOfBytes)
        {
            switch (frameCode)
            {
                case 0x00:
                    _metrics.LastHeartBeat = DateTimeOffset.UtcNow;
                    break;
                case 0x10:
                    _metrics.LastConnectionOpen = DateTimeOffset.UtcNow;
                    break;
                case 0x18:
                    _metrics.LastConnectionClose = DateTimeOffset.UtcNow;
                    break;
            }
        }

        public void OnWrite(AmqpConnection connection, ulong frameCode, int numberOfBytes)
        {
            // not implemented
        }
    }
}