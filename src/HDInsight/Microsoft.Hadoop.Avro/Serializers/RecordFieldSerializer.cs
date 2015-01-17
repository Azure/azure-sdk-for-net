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
    /// Serializes class/struct field into Avro record field.
    /// </summary>
    internal sealed class RecordFieldSerializer : IFieldSerializer
    {
        private readonly RecordField schema;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecordFieldSerializer"/> class.
        /// </summary>
        /// <param name="schema">The schema.</param>
        public RecordFieldSerializer(RecordField schema)
        {
            this.schema = schema;
        }

        public Expression BuildSerializer(Expression encoder, Expression @object)
        {
            if (encoder == null)
            {
                throw new ArgumentNullException("encoder");
            }
            if (@object == null)
            {
                throw new ArgumentNullException("object");
            }

            var member = this.GetMember(@object);
            if (this.schema.TypeSchema.RuntimeType.IsValueType ||
                this.schema.MemberInfo is FieldInfo)
            {
                return this.schema.TypeSchema.Serializer.BuildSerializer(encoder, member);
            }

            var tmp = Expression.Variable(this.schema.TypeSchema.RuntimeType, Guid.NewGuid().ToString());
            var assignment = Expression.Assign(tmp, member);
            Expression serialized = this.schema.TypeSchema.Serializer.BuildSerializer(encoder, tmp);
            return Expression.Block(new[] { tmp }, new[] { assignment, serialized });
        }

        public Expression BuildDeserializer(Expression decoder, Expression @object)
        {
            if (decoder == null)
            {
                throw new ArgumentNullException("decoder");
            }
            if (@object == null)
            {
                throw new ArgumentNullException("object");
            }

            var value = this.schema.TypeSchema.Serializer.BuildDeserializer(decoder);
            var member = this.GetMember(@object);
            if (@object.Type.IsValueType)
            {
                var tmp = Expression.Variable(value.Type);
                return Expression.Block(
                    new[] { tmp },
                    Expression.Assign(tmp, value),
                    Expression.Assign(member, tmp));
            }

            return Expression.Assign(member, value);
        }

        public Expression BuildSkipper(Expression decoder)
        {
            if (decoder == null)
            {
                throw new ArgumentNullException("decoder");
            }
            return this.schema.TypeSchema.Serializer.BuildSkipper(decoder);
        }

        public void Serialize(IEncoder encoder, object @object)
        {
            var record = @object as AvroRecord;
            if (record == null)
            {
                throw new ArgumentException("Unexpected type.");
            }

            this.schema.TypeSchema.Serializer.Serialize(encoder, record[this.schema.Position]);
        }

        public void Deserialize(IDecoder decoder, object @object)
        {
            var record = @object as AvroRecord;
            if (record == null)
            {
                throw new ArgumentException("Unexpected type.");
            }

            record[this.schema.Position] = this.schema.UseDefaultValue
                ? this.schema.DefaultValue
                : this.schema.TypeSchema.Serializer.Deserialize(decoder);
        }

        public void Skip(IDecoder decoder)
        {
            this.schema.TypeSchema.Serializer.Skip(decoder);
        }

        private Expression GetMember(Expression @object)
        {
            MemberInfo info = this.schema.MemberInfo;
            var asPropertyInfo = info as PropertyInfo;
            var asFieldInfo = info as FieldInfo;
            if (asPropertyInfo == null && asFieldInfo == null)
            {
                throw new SerializationException(string.Format(CultureInfo.InvariantCulture, "Unsupported member '{0}'.", info));
            }

            return asPropertyInfo != null
                ? Expression.Property(@object, asPropertyInfo)
                : Expression.Field(@object, asFieldInfo);
        }
    }
}
