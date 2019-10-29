// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp.Framing
{
    using Azure.Amqp;

    sealed class AmqpEmptyRuleActionCodec : AmqpRuleActionCodec
    {
        public static readonly string Name = AmqpConstants.Vendor + ":empty-rule-action:list";
        public const ulong Code = 0x0000013700000005;
        const int Fields = 0;

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