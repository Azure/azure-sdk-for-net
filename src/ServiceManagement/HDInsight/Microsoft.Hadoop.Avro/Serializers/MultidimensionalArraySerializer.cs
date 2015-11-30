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
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;
    using Microsoft.Hadoop.Avro.Schema;

    /// <summary>
    /// Serialization of C# multidimensional array as Avro array of arrays.
    /// </summary>
    internal sealed class MultidimensionalArraySerializer : ObjectSerializerBase<ArraySchema>
    {
        public MultidimensionalArraySerializer(ArraySchema schema) : base(schema)
        {
        }

        /// <summary>
        /// Builds the serializer expression.
        /// Used as a trampoline function for BuildSerializerImpl.
        /// </summary>
        /// <param name="encoder">The encoder.</param>
        /// <param name="value">The value.</param>
        /// <returns>Serializing expression.</returns>
        protected override Expression BuildSerializerSafe(Expression encoder, Expression value)
        {
            int rank = this.Schema.RuntimeType.GetArrayRank();
            return this.BuildSerializerImpl(new List<Expression>(), encoder, value, 0, rank);
        }

        private Expression BuildSerializerImpl(
            List<Expression> indexes,
            Expression encoder,
            Expression value,
            int currentRank,
            int maxRank)
        {
            var body = new List<Expression>();
            if (currentRank == maxRank)
            {
                return this.Schema.ItemSchema.Serializer.BuildSerializer(encoder, Expression.ArrayIndex(value, indexes));
            }

            MethodInfo encodeArrayChunk = this.Encode("ArrayChunk");
            MethodInfo getLength = this.Schema.RuntimeType.GetMethod("GetLength");
            ParameterExpression length = Expression.Variable(typeof(int), "length");
            body.Add(Expression.Assign(length, Expression.Call(value, getLength, new Expression[] { Expression.Constant(currentRank) })));
            body.Add(Expression.Call(encoder, encodeArrayChunk, new Expression[] { length }));

            LabelTarget label = Expression.Label();
            ParameterExpression counter = Expression.Variable(typeof(int), "counter");
            body.Add(Expression.Assign(counter, Expression.Constant(0)));
            indexes.Add(counter);

            body.Add(
                Expression.Loop(
                    Expression.Block(
                        Expression.IfThen(Expression.GreaterThanOrEqual(counter, length), Expression.Break(label)),
                        this.BuildSerializerImpl(indexes, encoder, value, currentRank + 1, maxRank),
                        Expression.PreIncrementAssign(counter)),
                    label));

            body.Add(
                Expression.IfThen(
                    Expression.NotEqual(length, ConstantZero),
                    Expression.Call(encoder, encodeArrayChunk, ConstantZero)));
            return Expression.Block(new[] { counter, length }, body);
        }

        protected override Expression BuildDeserializerSafe(Expression decoder)
        {
            var body = new List<Expression>();

            Type type = this.Schema.RuntimeType;
            Type jaggedType = this.GenerateJaggedType(this.Schema.RuntimeType);

            ParameterExpression deserialized = Expression.Variable(jaggedType, "deserialized");
            body.Add(Expression.Assign(deserialized, this.GenerateBuildJaggedDeserializer(decoder, jaggedType, 0, type.GetArrayRank())));

            var lengths = new List<Expression>();
            Expression currentObject = deserialized;
            for (int i = 0; i < type.GetArrayRank(); i++)
            {
                lengths.Add(Expression.Property(currentObject, "Count"));
                currentObject = Expression.Property(currentObject, "Item", new Expression[] { Expression.Constant(0) });
            }

            ParameterExpression result = Expression.Variable(type, "result");
            body.Add(Expression.Assign(result, Expression.NewArrayBounds(type.GetElementType(), lengths)));
            body.Add(this.GenerateCopy(new List<Expression>(), result, deserialized, 0, type.GetArrayRank()));
            body.Add(result);
            return Expression.Block(new[] { deserialized, result }, body);
        }

        private Type GenerateJaggedType(Type sourceType)
        {
            int rank = sourceType.GetArrayRank();
            Type elementType = sourceType.GetElementType();
            Type result = elementType;
            for (int i = 0; i < rank; i++)
            {
                result = typeof(List<>).MakeGenericType(result);
            }
            return result;
        }

        private Expression GenerateBuildJaggedDeserializer(Expression decoder, Type valueType, int currentRank, int maxRank)
        {
            var body = new List<Expression>();
            if (currentRank == maxRank)
            {
                return this.Schema.ItemSchema.Serializer.BuildDeserializer(decoder);
            }

            ParameterExpression result = Expression.Variable(valueType, "result");
            ParameterExpression index = Expression.Variable(typeof(int), "index");
            ParameterExpression chunkSize = Expression.Variable(typeof(int), "chunkSize");

            body.Add(Expression.Assign(result, Expression.New(valueType)));
            body.Add(Expression.Assign(index, Expression.Constant(0)));

            LabelTarget internalLoopLabel = Expression.Label();
            ParameterExpression counter = Expression.Variable(typeof(int));
            body.Add(Expression.Assign(counter, Expression.Constant(0)));

            LabelTarget allRead = Expression.Label();

            body.Add(
                Expression.Loop(
                    Expression.Block(
                        Expression.Assign(chunkSize, Expression.Call(decoder, "DecodeArrayChunk", new Type[] { })),
                        Expression.IfThen(Expression.Equal(chunkSize, Expression.Constant(0)), Expression.Break(allRead)),
                        Expression.Assign(Expression.Property(result, "Capacity"), Expression.Add(index, chunkSize)),
                        Expression.Assign(counter, Expression.Constant(0)),
                        Expression.Loop(
                            Expression.Block(
                                Expression.IfThen(
                                    Expression.GreaterThanOrEqual(counter, chunkSize),
                                    Expression.Break(internalLoopLabel)),
                                Expression.Call(
                                    result,
                                    valueType.GetMethod("Add"),
                                    new[]
                                    {
                                        this.GenerateBuildJaggedDeserializer(
                                            decoder,
                                            valueType.GetGenericArguments()[0],
                                            currentRank + 1,
                                            maxRank)
                                    }),
                                Expression.PreIncrementAssign(index),
                                Expression.PreIncrementAssign(counter)),
                            internalLoopLabel)),
                    allRead));
            body.Add(result);
            return Expression.Block(new[] { result, index, chunkSize, counter }, body);
        }

        private Expression GenerateCopy(List<Expression> indexes, Expression destination, Expression source, int currentRank, int maxRank)
        {
            var body = new List<Expression>();
            if (currentRank == maxRank)
            {
                return Expression.Assign(Expression.ArrayAccess(destination, indexes), source);
            }

            ParameterExpression length = Expression.Variable(typeof(int), "length");
            body.Add(Expression.Assign(length, Expression.Property(source, "Count")));

            LabelTarget label = Expression.Label();
            ParameterExpression counter = Expression.Variable(typeof(int), "counter");
            body.Add(Expression.Assign(counter, Expression.Constant(0)));
            indexes.Add(counter);

            body.Add(
                Expression.Loop(
                    Expression.Block(
                        Expression.IfThen(Expression.GreaterThanOrEqual(counter, length), Expression.Break(label)),
                        this.GenerateCopy(
                            indexes,
                            destination,
                            Expression.Property(source, "Item", new Expression[] { counter }),
                            currentRank + 1,
                            maxRank),
                        Expression.PreIncrementAssign(counter)),
                    label));

            return Expression.Block(new[] { counter, length }, body);
        }
    }
}
