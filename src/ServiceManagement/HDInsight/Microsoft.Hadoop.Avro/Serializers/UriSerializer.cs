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
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.Serialization;
    using Microsoft.Hadoop.Avro.Schema;

    /// <summary>
    ///     Serializes Uri as Avro string.
    /// </summary>
    internal sealed class UriSerializer : ObjectSerializerBase<StringSchema>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UriSerializer"/> class.
        /// </summary>
        /// <param name="schema">The schema.</param>
        public UriSerializer(StringSchema schema) : base(schema)
        {
        }

        protected override Expression BuildSerializerSafe(Expression encoder, Expression value)
        {
            PropertyInfo original = this.Schema.RuntimeType.GetProperty("OriginalString");
            return Expression.Call(encoder, this.Encode<string>(), new Expression[] { Expression.Property(value, original) });
        }

        protected override Expression BuildDeserializerSafe(Expression decoder)
        {
            ConstructorInfo constructor = this.Schema.RuntimeType.GetConstructor(new[] { typeof(string) });
            if (constructor == null)
            {
                throw new SerializationException(string.Format(
                        CultureInfo.InvariantCulture,
                        "Type '{0}' is considered a 'Uri' and expected to have a constructor with a string parameter.",
                        this.Schema.RuntimeType));
            }

            return Expression.New(constructor, new Expression[] { Expression.Call(decoder, this.Decode<string>()) });
        }
    }
}
