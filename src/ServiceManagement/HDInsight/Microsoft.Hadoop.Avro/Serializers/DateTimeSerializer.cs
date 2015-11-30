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
    using Microsoft.Hadoop.Avro.Schema;

    /// <summary>
    /// Serializers DateTime type either in Posix format or as number of ticks.
    /// </summary>
    internal sealed class DateTimeSerializer : ObjectSerializerBase<LongSchema>
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private readonly bool usePosixTime;

        public DateTimeSerializer(LongSchema schema, bool usePosixTime) : base(schema)
        {
            if (typeof(DateTime) != schema.RuntimeType)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Only type DateTime is supported."));
            }

            this.usePosixTime = usePosixTime;
        }

        protected override Expression BuildSerializerSafe(Expression encoder, Expression value)
        {
            MethodInfo convertDateTimeToPosixTime = typeof(DateTimeSerializer).GetMethod(
                "ConvertDateTimeToPosixTime", BindingFlags.Static | BindingFlags.Public);

            return Expression.Call(
                encoder,
                this.Encode<long>(),
                new[]
                {
                    this.usePosixTime
                        ? Expression.Call(convertDateTimeToPosixTime, value)
                        : (Expression)Expression.Property(value, this.Schema.RuntimeType.GetProperty("Ticks"))
                });
        }

        protected override Expression BuildDeserializerSafe(Expression decoder)
        {
            MethodInfo convertPosixTimeToDateTime = typeof(DateTimeSerializer).GetMethod(
                "ConvertPosixTimeToDateTime", BindingFlags.Static | BindingFlags.Public);

            ConstructorInfo ctor = typeof(DateTime).GetConstructor(new[] { typeof(long) });
            if (ctor == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "'{0}' is expected to have a constructor with a single parameter of type long.",
                        typeof(DateTime)));
            }
            return this.usePosixTime
                       ? Expression.Call(convertPosixTimeToDateTime, Expression.Call(decoder, this.Decode<long>()))
                       : (Expression)Expression.New(ctor, Expression.Call(decoder, this.Decode<long>()));
        }

        public static long ConvertDateTimeToPosixTime(DateTime value)
        {
            var truncated = new DateTime(value.Ticks - (value.Ticks % TimeSpan.TicksPerSecond));
            var different = truncated - UnixEpoch;
            return (long)different.TotalSeconds;
        }

        public static DateTime ConvertPosixTimeToDateTime(long seconds)
        {
            return UnixEpoch.AddSeconds(seconds);
        }
    }
}
