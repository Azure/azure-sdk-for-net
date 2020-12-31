// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Amqp;

namespace Azure.Messaging.ServiceBus.Amqp.Framing
{
    internal sealed class AmqpFalseRuleFilterCodec : AmqpRuleFilterCodec
    {
        public const string Name = AmqpConstants.Vendor + ":false-filter:list";
        public const ulong Code = 0x000001370000008;

        public AmqpFalseRuleFilterCodec() : base(Name, Code) { }

        public override string ToString()
        {
            return "false()";
        }
    }
}
