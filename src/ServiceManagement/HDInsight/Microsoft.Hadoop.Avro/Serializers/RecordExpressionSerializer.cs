// /********************************************************
// *                                                       *
// *   Copyright (C) Microsoft. All rights reserved.       *
// *                                                       *
// ********************************************************/

namespace Microsoft.Hadoop.Avro.SerializerBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using Microsoft.Hadoop.Avro.Schema;

    internal sealed class RecordSerializer : ObjectSerializerBase
    {
        private readonly RecordSchema schema;
        private readonly HashSet<RecordSchema> visited;
        private readonly HashSet<RecordSchema> deserializerVisited;
        private readonly HashSet<RecordSchema> skipperVisited;

        private Delegate recursiveSerializer;
        private Delegate recursiveDeserializer;
        private Delegate recursiveSkipper;

        public RecordExpressionSerializer(RecordSchema schema)
        {
            this.schema = schema;
            this.visited = new HashSet<RecordSchema>();
            this.deserializerVisited = new HashSet<RecordSchema>();
            this.skipperVisited = new HashSet<RecordSchema>();
        }

        public Expression BuildSerializer(Expression encoder, Type encoderType, Expression value)
        {
            Type runtimeObjectType = this.schema.RuntimeType;

            Expression castedValue = Expression.Convert(value, runtimeObjectType);

            if (this.visited.Contains(this.schema))
            {
                // Serializer has already been generated, access it using a level of indirection thru the serializer registry.
                MethodInfo getSerializer = typeof(RecordExpressionSerializer)
                    .GetMethod("GetSerializer")
                    .MakeGenericMethod(runtimeObjectType, encoderType);
                MethodCallExpression serializer = Expression.Call(Expression.Constant(this), getSerializer);
                return Expression.Invoke(serializer, new[] { castedValue, encoder });
            }

            this.visited.Add(this.schema);

            ParameterExpression instanceParam = Expression.Parameter(runtimeObjectType, "instance");
            ParameterExpression encoderParam = Expression.Parameter(encoderType, "encoder");
            Expression block = this.GenerateSerializerAction(encoderParam, encoderType, instanceParam);

            Type genericFuncType = typeof(Action<,>);
            Type resultingFunctionType = genericFuncType.MakeGenericType(new[] { runtimeObjectType, encoderType });

            LambdaExpression lambda = Expression.Lambda(resultingFunctionType, block, instanceParam, encoderParam);
            this.recursiveSerializer = lambda.Compile();
            return Expression.Invoke(lambda, new[] { castedValue, encoder });
        }

        public Action<TObject, TEncoder> GetSerializer<TObject, TEncoder>()
        {
            return this.recursiveSerializer as Action<TObject, TEncoder>;
        }

        public Func<TDecoder, TObject> GetDeserializer<TObject, TDecoder>()
        {
            return this.recursiveDeserializer as Func<TDecoder, TObject>;
        }

        public Action<TDecoder> GetSkipper<TDecoder>()
        {
            return this.recursiveSkipper as Action<TDecoder>;
        }

        private Expression GenerateSerializerAction(Expression encoder, Type encoderType, Expression value)
        {
            var body = new List<Expression>();

            LabelTarget target = Expression.Label();
            if (!this.schema.RuntimeType.IsValueType)
            {
                body.Add(Expression.IfThen(Expression.Equal(value, Expression.Constant(null)), Expression.Return(target)));
            }
            body.AddRange(from field in this.schema.Fields select field.Builder.BuildSerializer(encoder, encoderType, value));
            body.Add(Expression.Label(target));
            return Expression.Block(body);
        }

        public Expression BuildDeserializer(Expression decoder, Type decoderType)
        {
            Type objectType = this.schema.RuntimeType;

            if (this.deserializerVisited.Contains(this.schema))
            {
                MethodInfo getDeserializer = typeof(RecordExpressionSerializer).GetMethod("GetDeserializer").MakeGenericMethod(objectType, decoderType);
                MethodCallExpression serializer = Expression.Call(Expression.Constant(this), getDeserializer);
                return Expression.Invoke(serializer, new[] { decoder });
            }
            this.deserializerVisited.Add(this.schema);

            ParameterExpression decoderParam = Expression.Parameter(decoderType, "decoder");
            ParameterExpression instance = Expression.Variable(objectType, "instance");

            var body = new List<Expression>();

            MethodInfo info = typeof(RecordExpressionSerializer).GetMethod("CreateRecord");
            Expression newObject = Expression.Call(Expression.Constant(this, typeof(RecordExpressionSerializer)), info);
            body.Add(Expression.Assign(instance, newObject));

            foreach (RecordField field in this.schema.Fields)
            {
                body.Add(
                    field.ShouldBeSkipped
                        ? field.Builder.BuildSkipper(decoderParam, decoderType)
                        : field.Builder.BuildDeserializer(decoderParam, decoderType, instance));
            }
            body.Add(instance);

            BlockExpression result = Expression.Block(new[] { instance }, body);

            Type genericFuncType = typeof(Func<,>);
            Type resultingFunctionType = genericFuncType.MakeGenericType(new[] { decoderType, objectType });

            LambdaExpression lambda = Expression.Lambda(resultingFunctionType, result, decoderParam);
            this.recursiveDeserializer = lambda.Compile();
            return Expression.Invoke(lambda, decoder);
        }

        public AvroRecord CreateRecord()
        {
            return new AvroRecord(schema);
        }

        public Expression BuildSkipper(Expression decoder, Type decoderType)
        {
            if (this.skipperVisited.Contains(this.schema))
            {
                MethodInfo getSkipper = typeof(RecordExpressionSerializer).GetMethod("GetSkipper").MakeGenericMethod(decoderType);
                MethodCallExpression skipper = Expression.Call(Expression.Constant(this), getSkipper);
                return Expression.Invoke(skipper, new[] { decoder });
            }
            this.skipperVisited.Add(this.schema);

            ParameterExpression decoderParam = Expression.Parameter(decoderType, "decoder");
            var body = new List<Expression>();

            foreach (RecordField field in this.schema.Fields)
            {
                body.Add(field.Builder.BuildSkipper(decoderParam, decoderType));
            }

            BlockExpression result = Expression.Block(body);

            Type genericFuncType = typeof(Action<>);
            Type resultingFunctionType = genericFuncType.MakeGenericType(new[] { decoderType });

            LambdaExpression lambda = Expression.Lambda(resultingFunctionType, result, decoderParam);
            this.recursiveSkipper = lambda.Compile();
            return Expression.Invoke(lambda, decoder);
        }
    }
}