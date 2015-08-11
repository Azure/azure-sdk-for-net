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
    using System.Globalization;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using Microsoft.Hadoop.Avro.Schema;

    internal sealed class NullSerializer : ObjectSerializerBase<NullSchema>
    {
        public NullSerializer(NullSchema schema) : base(schema)
        {
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Internal + done in base class.")]
        protected override Expression BuildSerializerSafe(Expression encoder, Expression value)
        {
            return Expression.IfThen(
                    Expression.NotEqual(value, Expression.Constant(null, value.Type)),
                    Expression.Throw(Expression.Constant(new SerializationException()), typeof(SerializationException)));
        }

        protected override Expression BuildDeserializerSafe(Expression decoder)
        {
            if (this.Schema.RuntimeType.CanContainNull())
            {
                return Expression.Constant(null, this.Schema.RuntimeType);
            }

            var exception = new SerializationException(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "Unexpected null value for the object of type '{0}'. Please check the schema.",
                    this.Schema.RuntimeType));
            return Expression.Throw(Expression.Constant(exception), this.Schema.RuntimeType);
        }

        protected override Expression BuildSkipperSafe(Expression decoder)
        {
            return Expression.Empty();
        }

        protected override void SerializeSafe(IEncoder encoder, object @object)
        {
            if (@object != null)
            {
                throw new SerializationException(string.Format(CultureInfo.InvariantCulture, "Not null object is serialized as null."));
            }
        }

        protected override object DeserializeSafe(IDecoder decoder)
        {
            return null;
        }

        protected override void SkipSafe(IDecoder decoder)
        {
        }
    }
}
