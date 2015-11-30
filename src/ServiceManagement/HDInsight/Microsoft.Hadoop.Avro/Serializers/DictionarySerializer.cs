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
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.Serialization;
    using Microsoft.Hadoop.Avro.Schema;

    /// <summary>
    ///     Serializers C# IDictionary{string, T} as Avro map.
    /// </summary>
    internal sealed class DictionarySerializer : ObjectSerializerBase<MapSchema>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DictionarySerializer"/> class.
        /// </summary>
        /// <param name="schema">The schema.</param>
        public DictionarySerializer(MapSchema schema) : base(schema)
        {
        }

        protected override Expression BuildSerializerSafe(Expression encoder, Expression value)
        {
            var elementType = typeof(KeyValuePair<,>).MakeGenericType(new[] { this.Schema.KeySchema.RuntimeType, this.Schema.ValueSchema.RuntimeType });
            var enumeratorType = typeof(IEnumerator<>).MakeGenericType(new[] { elementType });
            var enumerableType = typeof(IEnumerable<>).MakeGenericType(elementType);
            MethodInfo getEnumerator = enumerableType.GetMethod("GetEnumerator");
            var moveNext = typeof(IEnumerator).GetMethod("MoveNext");
            var current = enumeratorType.GetProperty("Current");
            var key = elementType.GetProperty("Key");
            var val = elementType.GetProperty("Value");

            var body = new List<Expression>();
            MethodInfo encodeMapChunk = this.Encode("MapChunk");
            PropertyInfo count = this.Schema.RuntimeType.GetPropertyByName("Count");

            ParameterExpression mapLength = Expression.Variable(typeof(int), "length");
            body.Add(Expression.Assign(mapLength, Expression.Property(value, count)));

            ParameterExpression enumerator = Expression.Variable(enumeratorType, "enumerator");
            ParameterExpression enumerable = Expression.Variable(enumerableType, "enumarable");
            body.Add(Expression.Assign(enumerable, Expression.TypeAs(value, enumerableType)));
            body.Add(Expression.Assign(enumerator, Expression.Call(enumerable, getEnumerator)));

            body.Add(Expression.Call(encoder, encodeMapChunk, new Expression[] { mapLength }));
            LabelTarget label = Expression.Label();
            body.Add(
                Expression.TryFinally(
                    Expression.Loop(
                        Expression.IfThenElse(
                            Expression.NotEqual(Expression.Call(enumerator, moveNext), Expression.Constant(false)),
                            Expression.Block(
                                this.Schema.KeySchema.Serializer.BuildSerializer(encoder, Expression.Property(Expression.Property(enumerator, current), key)),
                                this.Schema.ValueSchema.Serializer.BuildSerializer(encoder, Expression.Property(Expression.Property(enumerator, current), val))),
                            Expression.Break(label)),
                        label),
                    Expression.Call(Expression.TypeAs(enumerator, typeof(IDisposable)), typeof(IDisposable).GetMethod("Dispose"))));

            body.Add(
                Expression.IfThen(
                    Expression.NotEqual(mapLength, Expression.Constant(0)),
                    Expression.Call(encoder, encodeMapChunk, new[] { ConstantZero })));
            return Expression.Block(new[] { mapLength, enumerator, enumerable }, body);
        }

        protected override Expression BuildDeserializerSafe(Expression decoder)
        {
            var body = new List<Expression>();

            Type type = this.Schema.RuntimeType;
            MethodInfo addElement = type.GetMethod("Add", new[] { this.Schema.KeySchema.RuntimeType, this.Schema.ValueSchema.RuntimeType });
            if (addElement == null)
            {
                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Method 'Add' is not found in type '{0}'.", type));
            }

            ParameterExpression result = Expression.Variable(type, "result");
            var ctor = type.GetConstructor(new Type[] { });
            if (ctor == null)
            {
                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Parameterless constructor is not found in type '{0}'.", type));
            }
            body.Add(Expression.Assign(result, Expression.New(ctor)));

            ParameterExpression index = Expression.Variable(typeof(int), "index");
            body.Add(Expression.Assign(index, ConstantZero));

            ParameterExpression chunkSize = Expression.Variable(typeof(int), "chunkSize");
            ParameterExpression counter = Expression.Variable(typeof(int), "counter");
            LabelTarget chunkReadLoop = Expression.Label();
            LabelTarget mapReadLoop = Expression.Label();
            body.Add(
                Expression.Loop(
                    Expression.Block(
                        Expression.Assign(chunkSize, Expression.Call(decoder, "DecodeMapChunk", new Type[] { })),
                        Expression.IfThen(Expression.Equal(chunkSize, Expression.Constant(0)), Expression.Break(mapReadLoop)),
                        Expression.Assign(counter, ConstantZero),
                        Expression.Loop(
                            Expression.Block(
                                Expression.IfThen(Expression.GreaterThanOrEqual(counter, chunkSize), Expression.Break(chunkReadLoop)),
                                Expression.Call(
                                    result,
                                    addElement,
                                    new[]
                                    {
                                        this.Schema.KeySchema.Serializer.BuildDeserializer(decoder),
                                        this.Schema.ValueSchema.Serializer.BuildDeserializer(decoder)
                                    }),
                                Expression.PreIncrementAssign(index),
                                Expression.PreIncrementAssign(counter)),
                            chunkReadLoop)),
                    mapReadLoop));
            body.Add(result);
            return Expression.Block(new[] { result, index, chunkSize, counter }, body);
        }

        protected override Expression BuildSkipperSafe(Expression decoder)
        {
            var body = new List<Expression>();

            ParameterExpression index = Expression.Variable(typeof(int), "index");
            ParameterExpression chunkSize = Expression.Variable(typeof(int), "chunkSize");

            body.Add(Expression.Assign(index, ConstantZero));

            ParameterExpression counter = Expression.Variable(typeof(int), "counter");
            LabelTarget chunkSkipLoop = Expression.Label();
            LabelTarget mapSkipLoop = Expression.Label();
            body.Add(
                Expression.Loop(
                    Expression.Block(
                        Expression.Assign(chunkSize, Expression.Call(decoder, "DecodeMapChunk", new Type[] { })),
                        Expression.IfThen(Expression.Equal(chunkSize, Expression.Constant(0)), Expression.Break(mapSkipLoop)),
                        Expression.Assign(counter, ConstantZero),
                        Expression.Loop(
                            Expression.Block(
                                Expression.IfThen(Expression.GreaterThanOrEqual(counter, chunkSize), Expression.Break(chunkSkipLoop)),
                                this.Schema.KeySchema.Serializer.BuildSkipper(decoder),
                                this.Schema.ValueSchema.Serializer.BuildSkipper(decoder),
                                Expression.PreIncrementAssign(index),
                                Expression.PreIncrementAssign(counter)),
                            chunkSkipLoop)),
                    mapSkipLoop));
            return Expression.Block(new[] { index, chunkSize, counter }, body);
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Internal + done in base class.")]
        protected override void SerializeSafe(IEncoder encoder, object @object)
        {
            var dictionary = @object as IDictionary;
            if (dictionary == null)
            {
                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Invalid map type '{0}'. Only dictionaries are supported.", @object.GetType()));
            }

            encoder.EncodeMapChunk(dictionary.Count);
            foreach (DictionaryEntry element in dictionary)
            {
                var key = element.Key as string;
                if (key == null)
                {
                    throw new SerializationException(
                        string.Format(CultureInfo.InvariantCulture, "Invalid key type '{0}'. Only strings are supported.", element.Key.GetType()));

                }
                encoder.Encode(key);
                this.Schema.ValueSchema.Serializer.Serialize(encoder, element.Value);
            }

            if (dictionary.Count != 0)
            {
                encoder.EncodeMapChunk(0);
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Internal + done in base class.")]
        protected override object DeserializeSafe(IDecoder decoder)
        {
            int length = decoder.DecodeMapChunk();
            var result = new Dictionary<string, object>();

            while (length != 0)
            {
                for (int i = 0; i < length; ++i)
                {
                    result.Add(decoder.DecodeString(), this.Schema.ValueSchema.Serializer.Deserialize(decoder));
                }
                length = decoder.DecodeMapChunk();
            }
            return result;
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Internal + done in base class.")]
        protected override void SkipSafe(IDecoder decoder)
        {
            int length = decoder.DecodeMapChunk();
            while (length != 0)
            {
                for (int i = 0; i < length; ++i)
                {
                    decoder.SkipString();
                    this.Schema.ValueSchema.Serializer.Skip(decoder);
                }
                length = decoder.DecodeMapChunk();
            }
        }
    }
}
