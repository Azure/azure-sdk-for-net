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
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.Serialization;
    using Microsoft.Hadoop.Avro.Schema;

    /// <summary>
    /// Serializes Guid as Avro fixed.
    /// </summary>
    internal sealed class GuidSerializer : ObjectSerializerBase<FixedSchema>
    {
        private readonly ConstructorInfo guidConstructor;

        /// <summary>
        /// Initializes a new instance of the <see cref="GuidSerializer"/> class.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Schema runtime type is expected to be of type guid.</exception>
        public GuidSerializer(FixedSchema schema) : base(schema)
        {
            if (schema.RuntimeType != typeof(Guid))
            {
                throw new SerializationException("Schema runtime type is expected to be of type guid.");
            }

            this.guidConstructor = this.Schema.RuntimeType.GetConstructor(new[] { typeof(byte[]) });
        }

        protected override Expression BuildSerializerSafe(Expression encoder, Expression value)
        {
            Expression toByteArray = Expression.Call(value, this.Schema.RuntimeType.GetMethod("ToByteArray"));
            return Expression.Call(encoder, this.Encode("Fixed"), new[] { toByteArray });
        }

        protected override Expression BuildDeserializerSafe(Expression decoder)
        {
            Expression byteArray = Expression.Call(decoder, Decode("Fixed"), new Expression[] { Expression.Constant(this.Schema.Size) });
            return Expression.New(this.guidConstructor, byteArray);
        }
    }
}
