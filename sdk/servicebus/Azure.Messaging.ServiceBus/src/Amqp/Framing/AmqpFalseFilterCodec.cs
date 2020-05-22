// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Amqp;

namespace Azure.Messaging.ServiceBus.Amqp.Framing
{
    internal sealed class AmqpFalseFilterCodec : AmqpFilterCodec
    {
        public static readonly string Name = AmqpConstants.Vendor + ":false-filter:list";
        public const ulong Code = 0x000001370000008;

        public AmqpFalseFilterCodec() : base(Name, Code) { }

        public override string ToString()
        {
            return "false()";
        }
    }
}
