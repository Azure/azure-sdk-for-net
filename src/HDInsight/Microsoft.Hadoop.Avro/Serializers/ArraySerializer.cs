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
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.Serialization;
    using Microsoft.Hadoop.Avro.Schema;

    /// <summary>
    /// Array serializer. Serializers C# arrays into Avro arrays.
    /// </summary>
    internal sealed class ArraySerializer : ObjectSerializerBase<ArraySchema>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ArraySerializer" /> class.
        /// </summary>
        /// <param name="schema">The schema.</param>
        public ArraySerializer(ArraySchema schema) : base(schema)
        {
            if (!schema.RuntimeType.IsArray && schema.RuntimeType != typeof(Array))
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Only arrays allowed."));
            }
        }

        protected override Expression BuildSerializerSafe(Expression encoder, Expression value)
        {
            PropertyInfo getLength = this.Schema.RuntimeType.GetProperty("Length");
            if (getLength == null)
            {
                throw new SerializationException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "Runtime type '{0}' is being serialized as array, but does not have 'Length' property.",
                        this.Schema.RuntimeType));
            }

            var body = new List<Expression>();

            ParameterExpression arrayLength = Expression.Variable(typeof(int), "arrayLength");
            body.Add(Expression.Assign(arrayLength, Expression.Property(value, getLength)));
            body.Add(Expression.Call(encoder, this.Encode("ArrayChunk"), new Expression[] { arrayLength }));

            LabelTarget label = Expression.Label();
            ParameterExpression counter = Expression.Variable(typeof(int), "counter");
            body.Add(Expression.Assign(counter, ConstantZero));

            body.Add(
                Expression.Loop(
                    Expression.Block(
                        Expression.IfThen(Expression.GreaterThanOrEqual(counter, arrayLength), Expression.Break(label)),
                        this.Schema.ItemSchema.Serializer.BuildSerializer(encoder, Expression.ArrayAccess(value, counter)),
                        Expression.PreIncrementAssign(counter)),
                    label));

            body.Add(
                Expression.IfThen(
                    Expression.NotEqual(arrayLength, ConstantZero),
                    Expression.Call(encoder, this.Encode("ArrayChunk"), new[] { ConstantZero })));

            return Expression.Block(new[] { arrayLength, counter }, body);
        }

        protected override Expression BuildDeserializerSafe(Expression decoder)
        {
            Type arrayType = this.Schema.RuntimeType;

            MethodInfo resize = typeof(Array).GetMethod("Resize").MakeGenericMethod(arrayType.GetElementType());
            var body = new List<Expression>();

            ParameterExpression result = Expression.Variable(arrayType, "result");
            body.Add(Expression.Assign(result, Expression.NewArrayBounds(arrayType.GetElementType(), ConstantZero)));

            ParameterExpression index = Expression.Variable(typeof(int), "index");
            body.Add(Expression.Assign(index, ConstantZero));

            ParameterExpression chunkSize = Expression.Variable(typeof(int), "chunkSize");
            ParameterExpression counter = Expression.Variable(typeof(int), "counter");

            LabelTarget chunkReadLoop = Expression.Label();
            LabelTarget arrayReadLoop = Expression.Label();

            body.Add(
                Expression.Loop(
                    Expression.Block(
                        Expression.Assign(chunkSize, Expression.Call(decoder, this.Decode("ArrayChunk"))),
                        Expression.IfThen(Expression.Equal(chunkSize, ConstantZero), Expression.Break(arrayReadLoop)),
                        Expression.Call(resize, result, Expression.Add(index, chunkSize)),
                        Expression.Assign(counter, ConstantZero),
                        Expression.Loop(
                            Expression.Block(
                                Expression.IfThen(
                                    Expression.GreaterThanOrEqual(counter, chunkSize), Expression.Break(chunkReadLoop)),
                                Expression.Assign(
                                    Expression.ArrayAccess(result, index), this.Schema.ItemSchema.Serializer.BuildDeserializer(decoder)),
                                Expression.PreIncrementAssign(index),
                                Expression.PreIncrementAssign(counter)),
                            chunkReadLoop)),
                    arrayReadLoop));
            body.Add(result);
            return Expression.Block(new[] { result, index, chunkSize, counter }, body);
        }

        protected override Expression BuildSkipperSafe(Expression decoder)
        {
            var body = new List<Expression>();

            ParameterExpression index = Expression.Variable(typeof(int), "index");
            body.Add(Expression.Assign(index, ConstantZero));

            ParameterExpression counter = Expression.Variable(typeof(int), "counter");
            ParameterExpression chunkSize = Expression.Variable(typeof(int), "chunkSize");

            LabelTarget chunkSkipLoop = Expression.Label();
            LabelTarget arraySkipLoop = Expression.Label();

            body.Add(
                Expression.Loop(
                    Expression.Block(
                        Expression.Assign(chunkSize, Expression.Call(decoder, this.Decode("ArrayChunk"))),
                        Expression.IfThen(Expression.Equal(chunkSize, ConstantZero), Expression.Break(arraySkipLoop)),
                        Expression.Assign(counter, ConstantZero),
                        Expression.Loop(
                            Expression.Block(
                                Expression.IfThen(
                                    Expression.GreaterThanOrEqual(counter, chunkSize), Expression.Break(chunkSkipLoop)),
                                this.Schema.ItemSchema.Serializer.BuildSkipper(decoder),
                                Expression.PreIncrementAssign(index),
                                Expression.PreIncrementAssign(counter)),
                            chunkSkipLoop)),
                    arraySkipLoop));
            return Expression.Block(new[] { index, chunkSize, counter }, body);
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Internal + done in base class.")]
        protected override void SerializeSafe(IEncoder encoder, object @object)
        {
            var array = @object as Array;
            if (array == null)
            {
                throw new SerializationException(string.Format(CultureInfo.InvariantCulture, "Unexpected type '{0}'. Array was expected.", @object.GetType()));
            }

            encoder.EncodeArrayChunk(array.Length);
            for (int i = 0; i < array.Length; ++i)
            {
                this.Schema.ItemSchema.Serializer.Serialize(encoder, array.GetValue(i));
            }

            if (array.Length != 0)
            {
                encoder.EncodeArrayChunk(0);
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Internal + done in base class.")]
        protected override object DeserializeSafe(IDecoder decoder)
        {
            var result = new object[0];
            int length = decoder.DecodeArrayChunk();
            while (length != 0)
            {
                int oldValue = result.Length;
                Array.Resize(ref result, result.Length + length);

                for (int i = oldValue; i < result.Length; ++i)
                {
                    result[i] = this.Schema.ItemSchema.Serializer.Deserialize(decoder);
                }

                length = decoder.DecodeArrayChunk();
            }
            return result;
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Internal + done in base class.")]
        protected override void SkipSafe(IDecoder decoder)
        {
            int length = decoder.DecodeArrayChunk();
            while (length != 0)
            {
                for (int i = 0; i < length; ++i)
                {
                    this.Schema.ItemSchema.Serializer.Skip(decoder);
                }
                length = decoder.DecodeArrayChunk();
            }
        }
    }
}
