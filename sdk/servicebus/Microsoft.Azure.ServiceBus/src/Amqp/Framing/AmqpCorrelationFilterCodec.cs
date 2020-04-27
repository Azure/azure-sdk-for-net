// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp.Framing
{
    using System.Text;
    using Azure.Amqp;
    using Azure.Amqp.Encoding;

    internal sealed class AmqpCorrelationFilterCodec : AmqpFilterCodec
    {
        public static readonly string Name = AmqpConstants.Vendor + ":correlation-filter:list";
        public const ulong Code = 0x000001370000009;
        private const int Fields = 9;

        private AmqpMap _properties;

        public AmqpCorrelationFilterCodec() : base(Name, Code)
        {
            _properties = new AmqpMap();
        }

        public string CorrelationId { get; set; }

        public string MessageId { get; set; }

        public string To { get; set; }

        public string ReplyTo { get; set; }

        public string Label { get; set; }

        public string SessionId { get; set; }

        public string ReplyToSessionId { get; set; }

        public string ContentType { get; set; }

        public AmqpMap Properties => _properties;

        protected override int FieldCount => Fields;

        public override string ToString()
        {
            var stringBuilder = new StringBuilder("correlation(");
            var count = 0;
            AddFieldToString(CorrelationId != null, stringBuilder, "id", CorrelationId, ref count);
            stringBuilder.Append(')');
            return stringBuilder.ToString();
        }

        protected override void OnEncode(ByteBuffer buffer)
        {
            AmqpCodec.EncodeString(CorrelationId, buffer);
            AmqpCodec.EncodeString(MessageId, buffer);
            AmqpCodec.EncodeString(To, buffer);
            AmqpCodec.EncodeString(ReplyTo, buffer);
            AmqpCodec.EncodeString(Label, buffer);
            AmqpCodec.EncodeString(SessionId, buffer);
            AmqpCodec.EncodeString(ReplyToSessionId, buffer);
            AmqpCodec.EncodeString(ContentType, buffer);
            AmqpCodec.EncodeMap(_properties, buffer);
        }

        protected override void OnDecode(ByteBuffer buffer, int count)
        {
            if (count-- > 0)
            {
                CorrelationId = AmqpCodec.DecodeString(buffer);
            }

            if (count-- > 0)
            {
                MessageId = AmqpCodec.DecodeString(buffer);
            }

            if (count-- > 0)
            {
                To = AmqpCodec.DecodeString(buffer);
            }

            if (count-- > 0)
            {
                ReplyTo = AmqpCodec.DecodeString(buffer);
            }

            if (count-- > 0)
            {
                Label = AmqpCodec.DecodeString(buffer);
            }

            if (count-- > 0)
            {
                SessionId = AmqpCodec.DecodeString(buffer);
            }

            if (count-- > 0)
            {
                ReplyToSessionId = AmqpCodec.DecodeString(buffer);
            }

            if (count-- > 0)
            {
                ContentType = AmqpCodec.DecodeString(buffer);
            }

            if (count > 0)
            {
                _properties = AmqpCodec.DecodeMap(buffer);
            }
        }

        protected override int OnValueSize()
        {
            return AmqpCodec.GetStringEncodeSize(CorrelationId) +
                   AmqpCodec.GetStringEncodeSize(MessageId) +
                   AmqpCodec.GetStringEncodeSize(To) +
                   AmqpCodec.GetStringEncodeSize(ReplyTo) +
                   AmqpCodec.GetStringEncodeSize(Label) +
                   AmqpCodec.GetStringEncodeSize(SessionId) +
                   AmqpCodec.GetStringEncodeSize(ReplyToSessionId) +
                   AmqpCodec.GetStringEncodeSize(ContentType) +
                   AmqpCodec.GetMapEncodeSize(_properties);
        }
    }
}