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
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;
    using Microsoft.Hadoop.Avro.Schema;

    /// <summary>
    /// Serializes C# double into Avro double type.
    /// </summary>
    internal sealed class DoubleSerializer : ObjectSerializerBase<DoubleSchema>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleSerializer"/> class.
        /// </summary>
        /// <param name="schema">The schema.</param>
        public DoubleSerializer(DoubleSchema schema) : base(schema)
        {
        }

        protected override Expression BuildSerializerSafe(Expression encoder, Expression value)
        {
            return Expression.Call(
                encoder,
                this.Encode<double>(),
                new Expression[] { Expression.Convert(value, typeof(double)) });
        }

        protected override Expression BuildDeserializerSafe(Expression decoder)
        {
            return Expression.Convert(
                Expression.Call(decoder, this.Decode<double>()),
                this.Schema.RuntimeType);
        }

        protected override Expression BuildSkipperSafe(Expression decoder)
        {
            return Expression.Call(decoder, this.Skip<double>());
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Internal + done in base class.")]
        protected override void SerializeSafe(IEncoder encoder, object @object)
        {
            encoder.Encode((double)@object);
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Internal + done in base class.")]
        protected override object DeserializeSafe(IDecoder decoder)
        {
            return decoder.DecodeDouble();
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Internal + done in base class.")]
        protected override void SkipSafe(IDecoder decoder)
        {
            decoder.SkipDouble();
        }
    }
}
