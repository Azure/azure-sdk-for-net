// /********************************************************
// *                                                       *
// *   Copyright (C) Microsoft. All rights reserved.       *
// *                                                       *
// ********************************************************/

namespace Microsoft.Hadoop.Avro.SerializerBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;
    using Microsoft.Hadoop.Avro.Schema;

    internal sealed class DynamicRecordFieldSerializer : IFieldSerializer
    {
        private readonly RecordField schema;

        public DynamicRecordFieldSerializer(RecordField schema)
        {
            this.schema = schema;
        }

        public Expression BuildSerializer(Expression encoder, Type encoderType, Expression value)
        {
            MethodInfo info = typeof(DynamicRecordFieldExpressionSerializer).GetMethod("GetSerializableValue");
            Expression field = Expression.Call(
                Expression.Constant(this, typeof(DynamicRecordFieldExpressionSerializer)),
                info,
                new List<Expression> { Expression.Constant(this.schema, typeof(RecordField)), value });

            return this.schema.TypeSchema.Builder.BuildSerializer(encoder, encoderType, Expression.Convert(field, this.schema.TypeSchema.RuntimeType));
        }

        public Expression BuildDeserializer(Expression decoder, Type decoderType, Expression @object)
        {
            MethodInfo info = typeof(DynamicRecordFieldExpressionSerializer).GetMethod("SetDeserializableValue");

            Expression field = this.schema.TypeSchema.Builder.BuildDeserializer(decoder, decoderType);
            Expression casted = Expression.Convert(field, typeof(object));
            return Expression.Call(
                Expression.Constant(this, typeof(DynamicRecordFieldExpressionSerializer)),
                info,
                new List<Expression> { Expression.Constant(this.schema, typeof(RecordField)), @object, casted });
        }

        public Expression BuildSkipper(Expression decoder, Type decoderType)
        {
            return this.schema.TypeSchema.Builder.BuildSkipper(decoder, decoderType);
        }

        public object GetSerializableValue(RecordField field, object record)
        {
            var r = record as AvroRecord;
            return r[field.Position];
        }

        public void SetDeserializableValue(RecordField field, object record, object value)
        {
            var r = record as AvroRecord;
            r[field.Position] = value;
        }
    }
}
