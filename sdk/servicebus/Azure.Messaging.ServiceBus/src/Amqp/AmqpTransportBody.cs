// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Messaging.ServiceBus.Core;

namespace Azure.Messaging.ServiceBus.Amqp
{
    internal class AmqpTransportBody : TransportBody
    {
        public IEnumerable<ReadOnlyMemory<byte>> Data { get; set; }
    }
}
