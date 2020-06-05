// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Amqp;

namespace Azure.Messaging.ServiceBus.Amqp.Framing
{
    internal sealed class AmqpEmptyRuleActionCodec : AmqpRuleActionCodec
    {
        public const string Name = AmqpConstants.Vendor + ":empty-rule-action:list";
        public const ulong Code = 0x0000013700000005;
        private const int Fields = 0;

        public AmqpEmptyRuleActionCodec() : base(Name, Code) { }

        protected override int FieldCount => Fields;

        protected override void OnEncode(ByteBuffer buffer)
        {
        }

        protected override void OnDecode(ByteBuffer buffer, int count)
        {
        }

        protected override int OnValueSize()
        {
            return 0;
        }
    }
}
