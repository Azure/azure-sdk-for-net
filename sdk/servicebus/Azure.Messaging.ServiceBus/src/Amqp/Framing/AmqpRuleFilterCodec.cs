// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Amqp.Framing
{
    internal abstract class AmqpRuleFilterCodec : DescribedList
    {
        protected AmqpRuleFilterCodec(string name, ulong code)
            : base(name, code)
        {
        }

        protected override int FieldCount => 0;

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
