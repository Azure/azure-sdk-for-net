// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Amqp.Framing
{
    using Microsoft.Azure.Amqp.Framing;
    using Microsoft.Azure.Amqp;

    internal abstract class AmqpFilterCodec : DescribedList
    {
        protected AmqpFilterCodec(string name, ulong code)
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
