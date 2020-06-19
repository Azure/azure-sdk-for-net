// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Messaging.ServiceBus.Core;

namespace Azure.Messaging.ServiceBus.Amqp
{
    internal class AmqpTransportBody : TransportBody
    {
        public AmqpBodyType BodyType { get; set; }

        public IEnumerable<ReadOnlyMemory<byte>> Data { get; set; }

        public IEnumerable<IList> Sequence { get; set; }

        public object Value { get; set; }

        // This will only be set on received messages.
        // On sent messages, we do not check the amount of Data elements provided.
        public int DataCount { get; set; }
    }
}
