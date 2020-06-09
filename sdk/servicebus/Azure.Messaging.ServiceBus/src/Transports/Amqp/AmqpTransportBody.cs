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

        public ReadOnlyMemory<byte> Data
        {
            get => Body.AsBytes();
            set => Body = new BinaryData(value);
        }

        public IEnumerable<IList> Sequence { get; set; }

        public object Value { get; set; }

        public BinaryData Body { get; set; }
    }
}
