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
    using System.Globalization;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.Serialization;
    using Microsoft.Hadoop.Avro.Schema;

    /// <summary>
    /// Serializers C# DateTimeOffset into an Avro string or long (posix).
    /// </summary>
    internal sealed class DateTimeOffsetSerializer : ObjectSerializerBase<PrimitiveTypeSchema>
    {
        private readonly bool usePosixTime;

        public DateTimeOffsetSerializer(PrimitiveTypeSchema schema, bool usePosixTime) : base(schema)
        {
            if (typeof(DateTimeOffset) != schema.RuntimeType)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Schema should have DateTimeOffset type."));
            }
            this.usePosixTime = usePosixTime;
        }

        protected override Expression BuildSerializerSafe(Expression encoder, Expression value)
        {
            MethodInfo convertDateTimeToPosixTime = typeof(DateTimeSerializer).GetMethod(
                "ConvertDateTimeToPosixTime", BindingFlags.Static | BindingFlags.Public);

            MethodInfo toString = this.Schema.RuntimeType.GetMethod("ToString", new[] { typeof(string) });
            PropertyInfo dateTime = this.Schema.RuntimeType.GetProperty("DateTime");
            return this.usePosixTime
                ? Expression.Call(
                    encoder,
                    this.Encode<long>(),
                    new Expression[] { Expression.Call(convertDateTimeToPosixTime, Expression.Property(value, dateTime)) })
                : Expression.Call(
                    encoder,
                    this.Encode<string>(),
                    new Expression[] { Expression.Call(value, toString, new Expression[] { Expression.Constant("o", typeof(string)) }) });
        }

        protected override Expression BuildDeserializerSafe(Expression decoder)
        {
            MethodInfo convertPosixTimeToDateTime = typeof(DateTimeSerializer).GetMethod(
                "ConvertPosixTimeToDateTime", BindingFlags.Static | BindingFlags.Public);
            MethodInfo parse = this.Schema.RuntimeType.GetMethod(
                "Parse", new[] { typeof(string), typeof(IFormatProvider), typeof(DateTimeStyles) });
            ConstructorInfo ctor = this.Schema.RuntimeType.GetConstructor(new[] { typeof(DateTime) });
            if (ctor == null)
            {
                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Cannot find an appropriate constructor on '{0}' class.", this.Schema.RuntimeType));
            }

            return this.usePosixTime
                ? (Expression)Expression.New(
                    ctor,
                    new Expression[] { Expression.Call(convertPosixTimeToDateTime, Expression.Call(decoder, this.Decode<long>())) })
                : Expression.Call(
                    parse, 
                    new Expression[]
                    {
                        Expression.Call(decoder, this.Decode<string>()),
                        Expression.Constant(null, typeof(IFormatProvider)),
                        Expression.Constant(DateTimeStyles.RoundtripKind)
                    });
        }
    }
}
