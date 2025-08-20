// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp.Framing
{
    using Azure.Amqp.Framing;
    using Azure.Amqp;

    abstract class AmqpFilterCodec : DescribedList
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
