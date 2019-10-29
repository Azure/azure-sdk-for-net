// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp.Framing
{
    using System.Text;
    using Azure.Amqp;

    sealed class AmqpSqlFilterCodec : AmqpFilterCodec
    {
        public static readonly string Name = AmqpConstants.Vendor + ":sql-filter:list";
        public const ulong Code = 0x000001370000006;
        const int Fields = 2;

        public AmqpSqlFilterCodec() : base(Name, Code) { }

        public string Expression { get; set; }

        public int? CompatibilityLevel { get; set; }

        protected override int FieldCount => Fields;

        public override string ToString()
        {
            var stringBuilder = new StringBuilder("sql(");
            var count = 0;
            this.AddFieldToString(this.Expression != null, stringBuilder, "expression", this.Expression, ref count);
            this.AddFieldToString(this.CompatibilityLevel != null, stringBuilder, "level", this.CompatibilityLevel, ref count);
            stringBuilder.Append(')');
            return stringBuilder.ToString();
        }

        protected override void OnEncode(ByteBuffer buffer)
        {
            AmqpCodec.EncodeString(this.Expression, buffer);
            AmqpCodec.EncodeInt(this.CompatibilityLevel, buffer);
        }

        protected override void OnDecode(ByteBuffer buffer, int count)
        {
            if (count-- > 0)
            {
                this.Expression = AmqpCodec.DecodeString(buffer);
            }

            if (count > 0)
            {
                this.CompatibilityLevel = AmqpCodec.DecodeInt(buffer);
            }
        }

        protected override int OnValueSize()
        {
            return AmqpCodec.GetStringEncodeSize(this.Expression) +
                   AmqpCodec.GetIntEncodeSize(this.CompatibilityLevel);
        }
    }

}
