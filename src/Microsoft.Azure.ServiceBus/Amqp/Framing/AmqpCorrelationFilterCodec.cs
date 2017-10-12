// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp.Framing
{
    using System.Text;
    using Azure.Amqp;
    using Azure.Amqp.Encoding;

    sealed class AmqpCorrelationFilterCodec : AmqpFilterCodec
    {
        public static readonly string Name = AmqpConstants.Vendor + ":correlation-filter:list";
        public const ulong Code = 0x000001370000009;
        const int Fields = 9;

        AmqpMap properties;

        public AmqpCorrelationFilterCodec() : base(Name, Code)
        {
            this.properties = new AmqpMap();
        }

        public string CorrelationId { get; set; }

        public string MessageId { get; set; }

        public string To { get; set; }

        public string ReplyTo { get; set; }

        public string Label { get; set; }

        public string SessionId { get; set; }

        public string ReplyToSessionId { get; set; }

        public string ContentType { get; set; }

        public AmqpMap Properties => this.properties;

        protected override int FieldCount => Fields;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("correlation(");
            int count = 0;
            this.AddFieldToString(this.CorrelationId != null, sb, "id", this.CorrelationId, ref count);
            sb.Append(')');
            return sb.ToString();
        }

        protected override void OnEncode(ByteBuffer buffer)
        {
            AmqpCodec.EncodeString(this.CorrelationId, buffer);
            AmqpCodec.EncodeString(this.MessageId, buffer);
            AmqpCodec.EncodeString(this.To, buffer);
            AmqpCodec.EncodeString(this.ReplyTo, buffer);
            AmqpCodec.EncodeString(this.Label, buffer);
            AmqpCodec.EncodeString(this.SessionId, buffer);
            AmqpCodec.EncodeString(this.ReplyToSessionId, buffer);
            AmqpCodec.EncodeString(this.ContentType, buffer);
            AmqpCodec.EncodeMap(this.properties, buffer);
        }

        protected override void OnDecode(ByteBuffer buffer, int count)
        {
            if (count-- > 0)
            {
                this.CorrelationId = AmqpCodec.DecodeString(buffer);
            }

            if (count-- > 0)
            {
                this.MessageId = AmqpCodec.DecodeString(buffer);
            }

            if (count-- > 0)
            {
                this.To = AmqpCodec.DecodeString(buffer);
            }

            if (count-- > 0)
            {
                this.ReplyTo = AmqpCodec.DecodeString(buffer);
            }

            if (count-- > 0)
            {
                this.Label = AmqpCodec.DecodeString(buffer);
            }

            if (count-- > 0)
            {
                this.SessionId = AmqpCodec.DecodeString(buffer);
            }

            if (count-- > 0)
            {
                this.ReplyToSessionId = AmqpCodec.DecodeString(buffer);
            }

            if (count-- > 0)
            {
                this.ContentType = AmqpCodec.DecodeString(buffer);
            }

            if (count > 0)
            {
                this.properties = AmqpCodec.DecodeMap(buffer);
            }
        }

        protected override int OnValueSize()
        {
            int valueSize = AmqpCodec.GetStringEncodeSize(this.CorrelationId);
            valueSize += AmqpCodec.GetStringEncodeSize(this.MessageId);
            valueSize += AmqpCodec.GetStringEncodeSize(this.To);
            valueSize += AmqpCodec.GetStringEncodeSize(this.ReplyTo);
            valueSize += AmqpCodec.GetStringEncodeSize(this.Label);
            valueSize += AmqpCodec.GetStringEncodeSize(this.SessionId);
            valueSize += AmqpCodec.GetStringEncodeSize(this.ReplyToSessionId);
            valueSize += AmqpCodec.GetStringEncodeSize(this.ContentType);
            valueSize += AmqpCodec.GetMapEncodeSize(this.properties);

            return valueSize;
        }
    }
}