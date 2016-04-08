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
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Microsoft.Hadoop.Avro.Schema;

    /// <summary>
    /// Serializer of Union, used for reference types and interfaces/abstract classes.
    /// </summary>
    internal sealed class UnionSerializer : ObjectSerializerBase<UnionSchema>
    {
        private readonly ReadOnlyCollection<TypeSchema> itemSchemas;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnionSerializer"/> class.
        /// </summary>
        /// <param name="schema">The schema.</param>
        public UnionSerializer(UnionSchema schema) : base(schema)
        {
            this.itemSchemas = schema.Schemas;
        }

        protected override Expression BuildSerializerSafe(Expression encoder, Expression value)
        {
            // Indexing schemas according to their position.
            // according to avro spec http://avro.apache.org/docs/current/spec.html#Unions
            // Unions may not contain more than one schema with the same type, except for the named types record, fixed and enum. 
            // For example, unions containing two array types or two map types are not permitted, but two types with different names are permitted
            int schemaIndex = 0;

            var schemas = new List<IndexedSchema>(this.itemSchemas.Count);
            foreach (var typeSchema in this.itemSchemas)
            {
                // use FirstOrDefault rather than SingleOrDefault because we need to add all schema to the list.
                var existingSchema = schemas.FirstOrDefault(s => UnionSchema.IsSameTypeAs(s.Schema, typeSchema));
                var index = existingSchema != null ? existingSchema.Index : schemaIndex++;
                var indexSchema = new IndexedSchema {Schema = typeSchema, Index = index};
                schemas.Add(indexSchema);
            }

            // Nullable schemas.
            if (schemas.Count == 2 && schemas.Select(s => s.Schema).OfType<NullSchema>().Any())
            {
                return this.BuildNullableSerializer(encoder, value, schemas);
            }

            // Sort according to inheritance hierarchy - most specialized type goes first.
            schemas.Sort(this.MoreSpecializedTypesFirst);
            return this.BuildUnionSerializer(encoder, value, schemas);
        }

        protected override Expression BuildDeserializerSafe(Expression decoder)
        {
            ParameterExpression resultParameter = Expression.Variable(this.Schema.RuntimeType, "result");
            ParameterExpression unionTypeParameter = Expression.Variable(typeof(int), "unionType");
            BinaryExpression assignUnionType = Expression.Assign(unionTypeParameter, Expression.Call(decoder, this.Decode<int>(), new Expression[] { }));

            Expression elseBranch = Expression.Empty();
            ConditionalExpression conditions = null;
            for (int i = this.itemSchemas.Count - 1; i >= 0; i--)
            {
                conditions = Expression.IfThenElse(
                    Expression.Equal(unionTypeParameter, Expression.Constant(i)),
                    this.itemSchemas[i] is NullSchema
                        ? Expression.Assign(resultParameter, this.itemSchemas[i].Serializer.BuildDeserializer(decoder))
                        : Expression.Assign(
                            resultParameter,
                            Expression.Convert(this.itemSchemas[i].Serializer.BuildDeserializer(decoder), this.Schema.RuntimeType)),
                    elseBranch);
                elseBranch = conditions;
            }
            return Expression.Block(new[] { resultParameter, unionTypeParameter }, new Expression[] { assignUnionType, conditions, resultParameter });
        }

        protected override Expression BuildSkipperSafe(Expression decoder)
        {
            ParameterExpression unionType = Expression.Variable(typeof(int), "unionType");
            BinaryExpression assignUnionType = Expression.Assign(unionType, Expression.Call(decoder, this.Decode<int>(), new Expression[] { }));

            Expression elseBranch = Expression.Empty();
            ConditionalExpression conditions = null;
            for (int i = this.itemSchemas.Count - 1; i >= 0; i--)
            {
                conditions = Expression.IfThenElse(
                    Expression.Equal(unionType, Expression.Constant(i)),
                    this.itemSchemas[i].Serializer.BuildSkipper(decoder),
                    elseBranch);
                elseBranch = conditions;
            }
            return Expression.Block(new[] { unionType }, new Expression[] { assignUnionType, conditions });
        }

        private class IndexedSchema
        {
            public TypeSchema Schema { get; set; }

            public int Index { get; set; }
        }

        private Expression BuildNullableSerializer(Expression encoder, Expression value, IList<IndexedSchema> schemas)
        {
            var nullSchema = schemas.Single(e => e.Schema is NullSchema);
            var otherSchema = schemas.Single(e => e != nullSchema);
            var otherRuntimeSchema = otherSchema.Schema;

            if (!value.Type.CanContainNull())
            {
                return Expression.Block(
                    Expression.Call(encoder, this.Encode<int>(), new Expression[] { Expression.Constant(otherSchema.Index) }),
                    otherRuntimeSchema.Serializer.BuildSerializer(encoder, value));
            }

            return Expression.IfThenElse(
                Expression.Equal(value, Expression.Constant(null)),
                Expression.Block(
                    Expression.Call(encoder, this.Encode<int>(), new Expression[] { Expression.Constant(nullSchema.Index) }),
                    nullSchema.Schema.Serializer.BuildSerializer(encoder, value)),
                Expression.Block(
                    Expression.Call(encoder, this.Encode<int>(), new Expression[] { Expression.Constant(otherSchema.Index) }),
                    otherRuntimeSchema.Serializer.BuildSerializer(
                        encoder,
                        value.Type == otherRuntimeSchema.RuntimeType
                            ? value
                            : Expression.TypeAs(value, otherRuntimeSchema.RuntimeType))));
        }

        private Expression BuildUnionSerializer(Expression encoder, Expression value, IList<IndexedSchema> schemas)
        {
            Expression<Func<object, Exception>> messageFunc = objectType => new SerializationException(string.Format("Object type {0} does not match any item schema of the union: {1}", objectType == null ? null : objectType.GetType(), string.Join(",", schemas.Select(s => s.Schema.RuntimeType))));
            Expression elseBranch = Expression.Throw(Expression.Invoke(messageFunc, value));
            ConditionalExpression conditions = null;
            for (int i = schemas.Count - 1; i >= 0; i--)
            {
                var schema = schemas[i].Schema;
                Expression check = schema is NullSchema
                    ? (Expression)Expression.Equal(value, Expression.Constant(null))
                    : Expression.TypeIs(value, schema.RuntimeType);

                conditions = Expression.IfThenElse(
                    check,
                    Expression.Block(
                        Expression.Call(encoder, this.Encode<int>(), new Expression[] { Expression.Constant(schemas[i].Index) }),
                        schema.Serializer.BuildSerializer(
                            encoder,
                            value.Type == schema.RuntimeType ? value : Expression.Convert(value, schema.RuntimeType))),
                    elseBranch);
                elseBranch = conditions;
            }
            return conditions;
        }

        private int MoreSpecializedTypesFirst(IndexedSchema s1, IndexedSchema s2)
        {
            if (s1.Schema.RuntimeType.IsAssignableFrom(s2.Schema.RuntimeType))
            {
                return 1;
            }

            if (s2.Schema.RuntimeType.IsAssignableFrom(s1.Schema.RuntimeType))
            {
                return -1;
            }

            return s1.Index.CompareTo(s2.Index);
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Internal + done in base class.")]
        protected override void SerializeSafe(IEncoder encoder, object @object)
        {
            if (@object == null)
            {
                this.EncodeNullValue(encoder);
                return;
            }

            var record = @object as AvroRecord;
            if (record != null)
            {
                this.EncodeAvroRecord(encoder, record);
                return;
            }

            var enumeration = @object as AvroEnum;
            if (enumeration != null)
            {
                this.EncodeAvroEnum(encoder, enumeration);
                return;
            }

            var array = @object as Array;
            if (array != null && array.GetType() != typeof(byte[]))
            {
                this.EncodeAvroArray(encoder, array);
                return;
            }

            var dictionary = @object as IDictionary;
            if (dictionary != null)
            {
                this.EncodeAvroMap(encoder, dictionary);
                return;
            }

            this.EncodePrimitiveType(encoder, @object);
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Internal + done in base class.")]
        protected override object DeserializeSafe(IDecoder decoder)
        {
            int index = decoder.DecodeInt();
            return this.Schema.Schemas[index].Serializer.Deserialize(decoder);
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Internal + done in base class.")]
        protected override void SkipSafe(IDecoder decoder)
        {
            int index = decoder.DecodeInt();
            this.Schema.Schemas[index].Serializer.Skip(decoder);
        }

        private void EncodePrimitiveType(IEncoder encoder, object @object)
        {
            for (int i = 0; i < this.itemSchemas.Count; ++i)
            {
                if (this.itemSchemas[i].RuntimeType == @object.GetType() &&
                    !(this.itemSchemas[i] is NullSchema))
                {
                    encoder.Encode(i);
                    this.itemSchemas[i].Serializer.Serialize(encoder, @object);
                    return;
                }
            }
            throw new SerializationException(
                string.Format(CultureInfo.InvariantCulture, "Schema cannot be found for the object of type '{0}'.", @object.GetType()));
        }

        private void EncodeAvroMap(IEncoder encoder, IDictionary dictionary)
        {
            for (int i = 0; i < this.itemSchemas.Count; ++i)
            {
                var mapSchema = this.itemSchemas[i] as MapSchema;
                if (mapSchema != null)
                {
                    var valueType = dictionary.GetType().GetGenericArguments()[1];
                    if (mapSchema.ValueSchema.RuntimeType == valueType)
                    {
                        encoder.Encode(i);
                        this.Schema.Schemas[i].Serializer.Serialize(encoder, dictionary);
                        return;
                    }

                    throw new SerializationException(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            "Map value type does not match. Expected: '{0}', actual: '{1}.",
                            mapSchema.RuntimeType,
                            valueType));
                }
            }

            throw new SerializationException(
                        string.Format(CultureInfo.InvariantCulture, "The corresponding map schema is not found for type '{0}'.", dictionary.GetType()));
        }

        private void EncodeAvroArray(IEncoder encoder, Array array)
        {
            for (int i = 0; i < this.itemSchemas.Count; ++i)
            {
                var arraySchema = this.itemSchemas[i] as ArraySchema;
                if (arraySchema != null)
                {
                    var elementType = array.GetType().GetElementType();
                    if (arraySchema.ItemSchema.RuntimeType == elementType)
                    {
                        encoder.Encode(i);
                        this.itemSchemas[i].Serializer.Serialize(encoder, array);
                        return;
                    }

                    throw new SerializationException(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            "Element type of array schema does not match the object type. Expected: '{0}', actual: '{1}.",
                            arraySchema.RuntimeType,
                            elementType));
                }
            }
            throw new SerializationException(
                        string.Format(CultureInfo.InvariantCulture, "The corresponding array schema is not found for type '{0}'.", array.GetType()));
        }

        private void EncodeAvroEnum(IEncoder encoder, AvroEnum enumeration)
        {
            var enumSchema = enumeration.Schema as EnumSchema;
            for (int i = 0; i < this.itemSchemas.Count; ++i)
            {
                var itemEnumSchema = this.itemSchemas[i] as EnumSchema;
                if (itemEnumSchema != null)
                {
                    if (itemEnumSchema.FullName == enumSchema.FullName)
                    {
                        encoder.Encode(i);
                        this.itemSchemas[i].Serializer.Serialize(encoder, enumeration);
                        return;
                    }
                }
            }

            throw new SerializationException(
                        string.Format(CultureInfo.InvariantCulture, "The corresponding enumeration schema is not found for type '{0}'.", enumeration.GetType()));
        }

        private void EncodeAvroRecord(IEncoder encoder, AvroRecord record)
        {
            var recordSchema = record.Schema as RecordSchema;

            for (int i = 0; i < this.itemSchemas.Count; ++i)
            {
                var itemRecordSchema = this.itemSchemas[i] as RecordSchema;
                if (itemRecordSchema != null)
                {
                    if (itemRecordSchema.FullName == recordSchema.FullName)
                    {
                        encoder.Encode(i);
                        this.itemSchemas[i].Serializer.Serialize(encoder, record);
                        return;
                    }
                }
            }

            throw new SerializationException(
                        string.Format(CultureInfo.InvariantCulture, "The corresponding record schema is not found for type '{0}'.", record.GetType()));
        }

        private void EncodeNullValue(IEncoder encoder)
        {
            for (int i = 0; i < this.itemSchemas.Count; ++i)
            {
                if (this.itemSchemas[i] is NullSchema)
                {
                    encoder.Encode(i);
                    return;
                }
            }

            throw new SerializationException("Null schema is not found for null value.");
        }
    }
}
