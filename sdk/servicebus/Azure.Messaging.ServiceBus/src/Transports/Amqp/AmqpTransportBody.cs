// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Messaging.ServiceBus.Transports.Amqp
{
    internal class AmqpTransportBody : ITransportBody
    {
        public AmqpBodyType BodyType { get; set; }

        public IEnumerable<ReadOnlyMemory<byte>> Data { get; set; }

        public IEnumerable<IList> Sequence { get; set; }

        public object Value { get; set; }

        public BinaryData Body { get; set; }
    }
}
