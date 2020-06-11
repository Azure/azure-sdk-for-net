// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using Microsoft.Azure.Amqp;

namespace Azure.Messaging.ServiceBus.Amqp.Framing
{
    internal sealed class AmqpSqlRuleFilterCodec : AmqpRuleFilterCodec
    {
        public const string Name = AmqpConstants.Vendor + ":sql-filter:list";
        public const ulong Code = 0x000001370000006;
        private const int Fields = 2;

        public AmqpSqlRuleFilterCodec() : base(Name, Code) { }

        public string Expression { get; set; }

        public int? CompatibilityLevel { get; set; }

        protected override int FieldCount => Fields;

        public override string ToString()
        {
            var stringBuilder = new StringBuilder("sql(");
            var count = 0;
            AddFieldToString(Expression != null, stringBuilder, "expression", Expression, ref count);
            AddFieldToString(CompatibilityLevel != null, stringBuilder, "level", CompatibilityLevel, ref count);
            stringBuilder.Append(')');
            return stringBuilder.ToString();
        }

        protected override void OnEncode(ByteBuffer buffer)
        {
            AmqpCodec.EncodeString(Expression, buffer);
            AmqpCodec.EncodeInt(CompatibilityLevel, buffer);
        }

        protected override void OnDecode(ByteBuffer buffer, int count)
        {
            if (count-- > 0)
            {
                Expression = AmqpCodec.DecodeString(buffer);
            }

            if (count > 0)
            {
                CompatibilityLevel = AmqpCodec.DecodeInt(buffer);
            }
        }

        protected override int OnValueSize()
        {
            return AmqpCodec.GetStringEncodeSize(Expression) +
                   AmqpCodec.GetIntEncodeSize(CompatibilityLevel);
        }
    }
}
