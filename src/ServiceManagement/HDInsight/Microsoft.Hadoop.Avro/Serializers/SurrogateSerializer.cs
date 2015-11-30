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
    using Microsoft.Hadoop.Avro.Schema;

    /// <summary>
    /// Surrogate serializer.
    /// </summary>
    internal sealed class SurrogateSerializer : ObjectSerializerBase<SurrogateSchema>
    {
        private readonly AvroSerializerSettings settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="SurrogateSerializer"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="schema">The schema.</param>
        public SurrogateSerializer(AvroSerializerSettings settings, SurrogateSchema schema) : base(schema)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
            this.settings = settings;
        }

        protected override Expression BuildSerializerSafe(Expression encoder, Expression value)
        {
            var surrogate = Expression.Constant(this.settings.Surrogate);
            MethodInfo serialize = typeof(IAvroSurrogate).GetMethod("GetObjectToSerialize");

            Expression castValue = this.Schema.RuntimeType.IsValueType ? Expression.Convert(value, typeof(object)) : value;

            Expression obj = Expression.TypeAs(
                Expression.Call(surrogate, serialize, new[] { castValue, Expression.Constant(this.Schema.SurrogateType) }),
                this.Schema.SurrogateType);

            var tmp = Expression.Variable(this.Schema.SurrogateType, Guid.NewGuid().ToString());
            var assignment = Expression.Assign(tmp, obj);
            Expression serialized = this.Schema.Surrogate.Serializer.BuildSerializer(encoder, tmp);
            return Expression.Block(new[] { tmp }, new[] { assignment, serialized });
        }

        protected override Expression BuildDeserializerSafe(Expression decoder)
        {
            Expression obj = this.Schema.Surrogate.Serializer.BuildDeserializer(decoder);

            var surrogate = Expression.Constant(this.settings.Surrogate);
            MethodInfo deserialize = typeof(IAvroSurrogate).GetMethod("GetDeserializedObject");

            Expression deserialized = Expression.Call(surrogate, deserialize, new[] { obj, Expression.Constant(this.Schema.RuntimeType) });
            return this.Schema.RuntimeType.IsValueType
                ? Expression.Convert(deserialized, this.Schema.RuntimeType)
                : Expression.TypeAs(deserialized, this.Schema.RuntimeType);
        }
    }
}
