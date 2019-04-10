// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp.Framing
{
    using System;
    using Azure.Amqp;
    using Azure.Amqp.Framing;

    sealed class AmqpRuleDescriptionCodec : DescribedList
    {
        public static readonly string Name = AmqpConstants.Vendor + ":rule-description:list";
        public const ulong Code = 0x0000013700000004;
        const int Fields = 4;

        public AmqpRuleDescriptionCodec() : base(Name, Code) { }

        public AmqpFilterCodec Filter
        {
            get;
            set;
        }

        public AmqpRuleActionCodec Action
        {
            get;
            set;
        }

        public string RuleName
        {
            get;
            set;
        }

        public DateTime? CreatedAt { get; set; }

        protected override int FieldCount => Fields;

        protected override void OnEncode(ByteBuffer buffer)
        {
            AmqpCodec.EncodeSerializable(this.Filter, buffer);
            AmqpCodec.EncodeSerializable(this.Action, buffer);
            AmqpCodec.EncodeString(this.RuleName, buffer);
            AmqpCodec.EncodeTimeStamp(this.CreatedAt, buffer);
        }

        protected override void OnDecode(ByteBuffer buffer, int count)
        {
            if (count-- > 0)
            {
                this.Filter = (AmqpFilterCodec)AmqpCodec.DecodeAmqpDescribed(buffer);
            }

            if (count-- > 0)
            {
                this.Action = (AmqpRuleActionCodec)AmqpCodec.DecodeAmqpDescribed(buffer);
            }

            if (count-- > 0)
            {
                this.RuleName = AmqpCodec.DecodeString(buffer);
            }

            if (count > 0)
            {
                this.CreatedAt = AmqpCodec.DecodeTimeStamp(buffer);
            }
        }

        protected override int OnValueSize()
        {
            return AmqpCodec.GetSerializableEncodeSize(this.Filter) +
                   AmqpCodec.GetSerializableEncodeSize(this.Action) +
                   AmqpCodec.GetStringEncodeSize(this.RuleName) +
                   AmqpCodec.GetTimeStampEncodeSize(this.CreatedAt);
        }
    }
}