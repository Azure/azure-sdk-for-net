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
    using System.Globalization;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.Serialization;
    using Microsoft.Hadoop.Avro.Schema;

    /// <summary>
    /// Represents C# enumerables as Avro arrays.
    /// </summary>
    internal sealed class EnumerableSerializer : ObjectSerializerBase<ArraySchema>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerableSerializer"/> class.
        /// </summary>
        /// <param name="schema">The schema.</param>
        public EnumerableSerializer(ArraySchema schema)
            : base(schema)
        {
        }

        /// <summary>
        /// Builds the serialization expression for enumerables.
        /// Serialization happens in chunks of 1024 elements and uses a buffer to avoid memory allocations.
        /// </summary>
        /// <param name="encoder">The encoder.</param>
        /// <param name="value">The value.</param>
        /// <returns>Expression, serializing an enumerable.</returns>
        protected override Expression BuildSerializerSafe(Expression encoder, Expression value)
        {
            Type listType = typeof(List<>).MakeGenericType(new[] { this.Schema.ItemSchema.RuntimeType });
            Type enumeratorType = typeof(IEnumerator<>).MakeGenericType(this.Schema.ItemSchema.RuntimeType);
            Type enumerableType = typeof(IEnumerable<>).MakeGenericType(this.Schema.ItemSchema.RuntimeType);
            MethodInfo encodeArrayChunk = this.Encode("ArrayChunk");
            MethodInfo getEnumerator = enumerableType.GetMethod("GetEnumerator");
            MethodInfo moveNext = typeof(IEnumerator).GetMethod("MoveNext");
            MethodInfo clear = listType.GetMethod("Clear");
            MethodInfo add = listType.GetMethod("Add");

            var bufferSize = Expression.Variable(typeof(int), "bufferSize");
            var buffer = Expression.Variable(listType, "buffer");
            var counter = Expression.Variable(typeof(int), "counter");
            var item = Expression.Variable(this.Schema.ItemSchema.RuntimeType, "item");
            var enumerator = Expression.Variable(enumeratorType, "enumerator");
            var chunkCounter = Expression.Variable(typeof(int), "chunkCounter");

            var arrayBreak = Expression.Label("arrayBreak");
            var chunkBreak = Expression.Label("chunkBreak");
            var lastChunkBreak = Expression.Label("lastChunkBreak");

            return Expression.Block(
                new[]
                {
                    bufferSize,
                    buffer,
                    counter,
                    item,
                    enumerator,
                    chunkCounter
                },
                Expression.Assign(bufferSize, Expression.Constant(1024)),
                Expression.Assign(buffer, Expression.New(listType)),
                Expression.Assign(counter, Expression.Constant(0)),
                Expression.Assign(enumerator, Expression.Call(value, getEnumerator)),
                Expression.Loop(
                    Expression.IfThenElse(
                        Expression.NotEqual(Expression.Call(enumerator, moveNext), Expression.Constant(false)),
                        Expression.Block(
                            Expression.Assign(item, Expression.Property(enumerator, "Current")),
                            Expression.IfThenElse(
                                Expression.Equal(counter, Expression.Constant(1024)),
                                Expression.Block(
                                    Expression.Call(encoder, encodeArrayChunk, new Expression[] { Expression.Constant(1024) }),
                                    Expression.Assign(counter, ConstantZero),
                                    Expression.Assign(chunkCounter, ConstantZero),
                                    Expression.Loop(
                                        Expression.Block(
                                            Expression.IfThen(Expression.GreaterThanOrEqual(chunkCounter, Expression.Property(buffer, "Count")), Expression.Break(chunkBreak)),
                                            this.Schema.ItemSchema.Serializer.BuildSerializer(encoder, Expression.Property(buffer, "Item", chunkCounter)),
                                            Expression.PreIncrementAssign(chunkCounter)),
                                            chunkBreak),
                                    Expression.Call(buffer, clear)),
                                Expression.Block(
                                    Expression.Call(buffer, add, new Expression[] { item }),
                                    Expression.PreIncrementAssign(counter)))),
                        Expression.Break(arrayBreak)),
                    arrayBreak),
                Expression.Call(encoder, encodeArrayChunk, new Expression[] { Expression.Property(buffer, "Count") }),
                Expression.Assign(counter, Expression.Constant(0)),
                Expression.Loop(
                    Expression.Block(
                        Expression.IfThen(Expression.GreaterThanOrEqual(chunkCounter, Expression.Property(buffer, "Count")), Expression.Break(lastChunkBreak)),
                        this.Schema.ItemSchema.Serializer.BuildSerializer(encoder, Expression.Property(buffer, "Item", chunkCounter)),
                        Expression.PreIncrementAssign(chunkCounter)),
                    lastChunkBreak),
                Expression.IfThen(
                    Expression.NotEqual(Expression.Property(buffer, listType, "Count"), Expression.Constant(0)),
                    Expression.Call(encoder, encodeArrayChunk, new[] { ConstantZero })));
        }

        protected override Expression BuildDeserializerSafe(Expression decoder)
        {
            MethodInfo addElement = this.GetAddMethod();

            var type = this.Schema.RuntimeType;
            var result = Expression.Variable(type, "result");
            var index = Expression.Variable(typeof(int), "index");
            var chunkSize = Expression.Variable(typeof(int), "chunkSize");
            var counter = Expression.Variable(typeof(int), "counter");

            LabelTarget chunkLoop = Expression.Label();
            LabelTarget enumerableLoop = Expression.Label();

            var ctor = type.GetConstructor(new Type[] { });
            if (ctor == null)
            {
                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Collection type '{0}' does not have parameterless constructor.", type));
            }

            return Expression.Block(
                new[] { result, index, chunkSize, counter },
                Expression.Assign(result, Expression.New(ctor)),
                Expression.Assign(index, Expression.Constant(0)),
                Expression.Loop(
                    Expression.Block(
                        Expression.Assign(chunkSize, Expression.Call(decoder, "DecodeArrayChunk", new Type[] { })),
                        Expression.IfThen(Expression.Equal(chunkSize, Expression.Constant(0)), Expression.Break(enumerableLoop)),
                        Expression.Assign(counter, Expression.Constant(0)),
                        Expression.Loop(
                            Expression.Block(
                                Expression.IfThen(
                                    Expression.GreaterThanOrEqual(counter, chunkSize), Expression.Break(chunkLoop)),
                                Expression.Call(result, addElement, new[] { this.Schema.ItemSchema.Serializer.BuildDeserializer(decoder) }),
                                Expression.PreIncrementAssign(index),
                                Expression.PreIncrementAssign(counter)),
                            chunkLoop)),
                    enumerableLoop),
                result);
        }

        private MethodInfo GetAddMethod()
        {
            Type type = this.Schema.RuntimeType;
            MethodInfo result = type.GetMethodByName("Add", this.Schema.ItemSchema.RuntimeType);
            if (result == null)
            {
                result = type.GetMethodByName("Enqueue", this.Schema.ItemSchema.RuntimeType);
            }

            if (result == null)
            {
                result = type.GetMethodByName("Push", this.Schema.ItemSchema.RuntimeType);
            }

            if (result == null)
            {
                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Collection type '{0}' does not have Add/Enqueue/Push method.", type));
            }
            return result;
        }
    }
}
