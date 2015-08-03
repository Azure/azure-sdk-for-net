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
    using System.Globalization;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using Microsoft.Hadoop.Avro.Schema;

    internal sealed class NullableSerializer : ObjectSerializerBase<NullableSchema>
    {
        public NullableSerializer(NullableSchema schema) : base(schema)
        {
        }

        protected override Expression BuildSerializerSafe(Expression encoder, Expression value)
        {
            var exception = new SerializationException(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "Unexpected null value for the object of type '{0}'. Please check the schema.",
                    this.Schema.RuntimeType));
            return Expression.IfThenElse(
                Expression.Equal(value, Expression.Constant(null)),
                Expression.Throw(Expression.Constant(exception)),
                this.Schema.ValueSchema.Serializer.BuildSerializer(encoder, Expression.Property(value, "Value")));
        }

        protected override Expression BuildDeserializerSafe(Expression decoder)
        {
            return Expression.Convert(this.Schema.ValueSchema.Serializer.BuildDeserializer(decoder), this.Schema.RuntimeType);
        }
    }
}
