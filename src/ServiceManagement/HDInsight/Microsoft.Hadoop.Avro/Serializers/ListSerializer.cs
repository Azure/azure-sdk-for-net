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
    using System.Globalization;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.Serialization;
    using Microsoft.Hadoop.Avro.Schema;

    /// <summary>
    /// Serializers C# list into Avro array.
    /// </summary>
    internal sealed class ListSerializer : ObjectSerializerBase<ArraySchema>
    {
        public ListSerializer(ArraySchema schema) : base(schema)
        {
        }

        protected override Expression BuildSerializerSafe(Expression encoder, Expression value)
        {
            MethodInfo encodeArrayChunk = this.Encode("ArrayChunk");
            PropertyInfo count = this.Schema.RuntimeType.GetPropertyByName("Count");
            if (count == null)
            {
                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Collection type '{0}' does not have Count property.", this.Schema.RuntimeType));
            }

            var body = new List<Expression>();

            ParameterExpression listCount = Expression.Variable(typeof(int), "count");
            body.Add(Expression.Assign(listCount, Expression.Property(value, count)));
            body.Add(Expression.Call(encoder, encodeArrayChunk, new Expression[] { listCount }));

            ParameterExpression counter = Expression.Variable(typeof(int), "counter");
            body.Add(Expression.Assign(counter, ConstantZero));

            LabelTarget label = Expression.Label();
            body.Add(
                Expression.Loop(
                    Expression.Block(
                        Expression.IfThen(Expression.GreaterThanOrEqual(counter, listCount), Expression.Break(label)),
                        this.Schema.ItemSchema.Serializer.BuildSerializer(encoder, Expression.Property(value, "Item", counter)),
                        Expression.PreIncrementAssign(counter)),
                    label));

            body.Add(
                Expression.IfThen(
                    Expression.NotEqual(listCount, Expression.Constant(0)),
                    Expression.Call(encoder, encodeArrayChunk, new[] { ConstantZero })));

            return Expression.Block(new[] { counter, listCount }, body);
        }

        protected override Expression BuildDeserializerSafe(Expression decoder)
        {
            var body = new List<Expression>();

            Type type = this.Schema.RuntimeType;
            MethodInfo addElement = type.GetMethod("Add", new[] { this.Schema.ItemSchema.RuntimeType });
            if (addElement == null)
            {
                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Collection type '{0}' does not have Add method.", this.Schema.RuntimeType));
            }

            var ctor = type.GetConstructor(new Type[] { });
            if (ctor == null)
            {
                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Collection type '{0}' does not have parameterless constructor.", type));
            }

            ParameterExpression result = Expression.Variable(type);
            ParameterExpression index = Expression.Variable(typeof(int));
            ParameterExpression currentNumberOfElements = Expression.Variable(typeof(int));

            body.Add(Expression.Assign(result, Expression.New(ctor)));
            body.Add(Expression.Assign(index, Expression.Constant(0)));

            ParameterExpression counter = Expression.Variable(typeof(int));
            LabelTarget internalLoopLabel = Expression.Label();

            LabelTarget allRead = Expression.Label();
            body.Add(
                Expression.Loop(
                    Expression.Block(
                        Expression.Assign(currentNumberOfElements, Expression.Call(decoder, "DecodeArrayChunk", new Type[] { })),
                        Expression.IfThen(Expression.Equal(currentNumberOfElements, Expression.Constant(0)), Expression.Break(allRead)),
                        Expression.Assign((type.GetProperty("Capacity") != null) ? Expression.Property(result, "Capacity") : (Expression)counter, Expression.Add(index, currentNumberOfElements)),
                        Expression.Assign(counter, Expression.Constant(0)),
                        Expression.Loop(
                            Expression.Block(
                                Expression.IfThen(
                                    Expression.GreaterThanOrEqual(counter, currentNumberOfElements), Expression.Break(internalLoopLabel)),
                                Expression.Call(result, addElement,  new[] { this.Schema.ItemSchema.Serializer.BuildDeserializer(decoder) }),
                                Expression.PreIncrementAssign(index),
                                Expression.PreIncrementAssign(counter)),
                            internalLoopLabel)),
                    allRead));
            body.Add(result);
            return Expression.Block(new[] { result, index, currentNumberOfElements, counter }, body);
        }
    }
}
