// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Amqp.Framing
{
    internal sealed class AmqpRuleDescriptionCodec : DescribedList
    {
        public const string Name = AmqpConstants.Vendor + ":rule-description:list";
        public const ulong Code = 0x0000013700000004;
        private const int Fields = 4;

        public AmqpRuleDescriptionCodec() : base(Name, Code) { }

        public AmqpRuleFilterCodec Filter { get; set; }

        public AmqpRuleActionCodec Action { get; set; }

        public string RuleName { get; set; }

        public DateTime? CreatedAt { get; set; }

        protected override int FieldCount => Fields;

        protected override void OnEncode(ByteBuffer buffer)
        {
            AmqpCodec.EncodeSerializable(Filter, buffer);
            AmqpCodec.EncodeSerializable(Action, buffer);
            AmqpCodec.EncodeString(RuleName, buffer);
            AmqpCodec.EncodeTimeStamp(CreatedAt, buffer);
        }

        protected override void OnDecode(ByteBuffer buffer, int count)
        {
            if (count-- > 0)
            {
                Filter = (AmqpRuleFilterCodec)AmqpCodec.DecodeAmqpDescribed(buffer);
            }

            if (count-- > 0)
            {
                Action = (AmqpRuleActionCodec)AmqpCodec.DecodeAmqpDescribed(buffer);
            }

            if (count-- > 0)
            {
                RuleName = AmqpCodec.DecodeString(buffer);
            }

            if (count > 0)
            {
                CreatedAt = AmqpCodec.DecodeTimeStamp(buffer);
            }
        }

        protected override int OnValueSize()
        {
            return AmqpCodec.GetSerializableEncodeSize(Filter) +
                   AmqpCodec.GetSerializableEncodeSize(Action) +
                   AmqpCodec.GetStringEncodeSize(RuleName) +
                   AmqpCodec.GetTimeStampEncodeSize(CreatedAt);
        }
    }
}
