// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Avro.Serializers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using Microsoft.Hadoop.Avro.Schema;

    /// <summary>
    /// Serializes C# enum/AvroEnum into Avro enum.
    /// </summary>
    internal sealed class EnumSerializer : ObjectSerializerBase<EnumSchema>
    {
        private readonly long[] valueMapping;

        public EnumSerializer(EnumSchema schema)
            : base(schema)
        {
            this.valueMapping = this.Schema.AvroToCSharpValueMapping;
        }

        protected override Expression BuildSerializerSafe(Expression encoder, Expression value)
        {
            var cases = new List<SwitchCase>(this.valueMapping.Length);
            for (int i = 0; i < this.valueMapping.Length; ++i)
            {
                cases.Add(
                    Expression.SwitchCase(
                        Expression.Call(encoder, this.Encode<int>(), new Expression[] { Expression.Constant(i, typeof(int)) }),
                        Expression.Convert(Expression.Constant(this.valueMapping[i]), this.Schema.RuntimeType)));
            }
            return Expression.Switch(value, Expression.Throw(Expression.New(typeof(ArgumentOutOfRangeException))), cases.ToArray());
        }

        protected override Expression BuildDeserializerSafe(Expression decoder)
        {
            return Expression.Convert(
                    Expression.ArrayIndex(Expression.Constant(this.valueMapping), Expression.Call(decoder, this.Decode<int>())),
                    this.Schema.RuntimeType);
        }

        protected override Expression BuildSkipperSafe(Expression decoder)
        {
            return Expression.Call(decoder, this.Skip<int>());
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Internal + done in base class.")]
        protected override void SerializeSafe(IEncoder encoder, object @object)
        {
            if (@object == null)
            {
                throw new ArgumentNullException("object");
            }

            var @enum = @object as AvroEnum;
            if (@enum == null)
            {
                throw new SerializationException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "Invalid enumeration type '{0}'. Please, use '{1}' instead.",
                        @object.GetType(),
                        typeof(AvroEnum)));
            }

            string normalized1 = @enum.Schema.ToString();
            string normalized2 = this.Schema.ToString();
            if (normalized1 != normalized2)
            {
                throw new SerializationException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "Enumeration schemas do not match: '{0}' != '{1}'.",
                        normalized1,
                        normalized2));
            }
            encoder.Encode(@enum.IntegerValue);
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Internal + done in base class.")]
        protected override object DeserializeSafe(IDecoder decoder)
        {
            return new AvroEnum(this.Schema) { IntegerValue = decoder.DecodeInt() };
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Internal + done in base class.")]
        protected override void SkipSafe(IDecoder decoder)
        {
            decoder.SkipInt();
        }
    }
}
