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
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Globalization;
    using System.Runtime.Serialization;
    using Microsoft.Hadoop.Avro.Schema;

    /// <summary>
    /// Serializers C# classes/structs/AvroRecord into an Avro Record.
    /// </summary>
    internal sealed class ClassSerializer : ObjectSerializerBase<RecordSchema>
    {
        private Delegate cachedSerializer;
        private Delegate cachedDeserializer;
        private Delegate cachedSkipper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassSerializer"/> class.
        /// </summary>
        /// <param name="schema">The schema.</param>
        public ClassSerializer(RecordSchema schema) : base(schema)
        {
        }

        /// <summary>
        /// Builds the serializing expression.
        /// </summary>
        /// <param name="encoder">The encoder.</param>
        /// <param name="value">The value.</param>
        /// <returns>Expression, serializing the object.</returns>
        protected override Expression BuildSerializerSafe(Expression encoder, Expression value)
        {
            if (this.cachedSerializer != null)
            {
                return this.CallCachedSerialize(encoder, value);
            }

            // For handling potential recursive types.
            this.cachedSerializer = ((Expression<Func<int>>)(() => 0)).Compile();
            this.cachedSerializer = this.GenerateCachedSerializer();

            // For performance reasons we do not use a cached serializer
            // for the first encounter of the type in the schema tree.
            return this.SerializeFields(encoder, value);
        }

        /// <summary>
        /// Builds the deserializing expression.
        /// </summary>
        /// <param name="decoder">The decoder.</param>
        /// <returns>Expression, deserializing the object.</returns>
        protected override Expression BuildDeserializerSafe(Expression decoder)
        {
            if (this.cachedDeserializer != null)
            {
                return this.CallCachedDeserialize(decoder);
            }

            // For handling potential recursive types.
            this.cachedDeserializer = ((Expression<Func<int>>)(() => 0)).Compile();
            var deserializeLambda = this.GenerateCachedDeserializer();
            this.cachedDeserializer = deserializeLambda.Compile();

            return Expression.Invoke(deserializeLambda, decoder);
        }

        /// <summary>
        /// Builds the skipping expression.
        /// </summary>
        /// <param name="decoder">The decoder.</param>
        /// <returns>Expression, skipping the object.</returns>
        protected override Expression BuildSkipperSafe(Expression decoder)
        {
            if (this.cachedSkipper != null)
            {
                return this.CallCachedSkipper(decoder);
            }

            this.cachedSkipper = ((Expression<Func<int>>)(() => 0)).Compile();
            var skipLambda = this.GenerateCachedSkipper();
            this.cachedSkipper = skipLambda.Compile();
            return Expression.Invoke(skipLambda, decoder);
        }

        /// <summary>
        /// Generates a cached deserializer.
        /// </summary>
        /// <returns>Expression, representing a deserializer.</returns>
        private LambdaExpression GenerateCachedDeserializer()
        {
            Type objectType = this.Schema.RuntimeType;
            ParameterExpression decoderParam = Expression.Parameter(typeof(IDecoder), "decoder");
            ParameterExpression instance = Expression.Variable(objectType, "instance");

            var body = new List<Expression>();
            if (objectType.IsAnonymous() || objectType.IsKeyValuePair())
            {
                // Cannot create an object beforehand. Have to call a constructor with parameters.
                var properties = this.Schema.Fields.Select(f => f.TypeSchema.Serializer.BuildDeserializer(decoderParam));
                ConstructorInfo ctor = objectType
                    .GetConstructors()
                    .Single(c => c.GetParameters().Select(p => p.ParameterType).SequenceEqual(this.Schema.Fields.Select(f => f.TypeSchema.RuntimeType)));
                body.Add(Expression.Assign(instance, Expression.New(ctor, properties)));
            }
            else
            {
                body.Add(Expression.Assign(instance, Expression.New(objectType)));
                body.AddRange(
                    this.Schema.Fields.Select(
                        f => f.ShouldBeSkipped 
                            ? f.Builder.BuildSkipper(decoderParam)
                            : f.Builder.BuildDeserializer(decoderParam, instance)));
            }
            body.Add(instance);

            BlockExpression result = Expression.Block(new[] { instance }, body);
            Type resultingFunctionType = typeof(Func<,>).MakeGenericType(new[] { typeof(IDecoder), objectType });
            return Expression.Lambda(resultingFunctionType, result, decoderParam);
        }

        /// <summary>
        /// The corresponding deserializer has already been generated, 
        /// in order to break the infinite loop in case of recursive type simply call its cached value.
        /// </summary>
        /// <param name="decoder">The decoder.</param>
        /// <returns>Deserialization call.</returns>
        private Expression CallCachedDeserialize(Expression decoder)
        {
            Type objectType = this.Schema.RuntimeType;
            MethodInfo getDeserializer = this.GetType()
                .GetMethod("GetDeserializer", BindingFlags.Instance | BindingFlags.NonPublic).MakeGenericMethod(objectType);
            MethodCallExpression serializer = Expression.Call(Expression.Constant(this), getDeserializer);
            return Expression.Invoke(serializer, new[] { decoder });
        }

        /// <summary>
        /// The corresponding serializer has already been generated, in order to break the infinite loop in case of recursive type simply call its cached value.
        /// </summary>
        /// <param name="encoder">The encoder.</param>
        /// <param name="value">The value.</param>
        /// <returns>Serialization call.</returns>
        private Expression CallCachedSerialize(Expression encoder, Expression value)
        {
            MethodInfo getSerializer = this.GetType()
                .GetMethod("GetSerializer", BindingFlags.Instance | BindingFlags.NonPublic)
                .MakeGenericMethod(this.Schema.RuntimeType);
            MethodCallExpression serializer = Expression.Call(Expression.Constant(this), getSerializer);
            return Expression.Invoke(serializer, new[] { value, encoder });
        }

        /// <summary>
        /// Generates a cached serializer as a lambda.
        /// </summary>
        /// <returns>A serializer delegate.</returns>
        private Delegate GenerateCachedSerializer()
        {
            Type objectType = this.Schema.RuntimeType;
            ParameterExpression instanceParam = Expression.Parameter(objectType, "instance");
            ParameterExpression encoderParam = Expression.Parameter(typeof(IEncoder), "encoder");
            Expression block = this.SerializeFields(encoderParam, instanceParam);
            Type resultingFunctionType = typeof(Action<,>).MakeGenericType(new[] { objectType, typeof(IEncoder) });
            LambdaExpression lambda = Expression.Lambda(resultingFunctionType, block, instanceParam, encoderParam);
            return lambda.Compile();
        }

        /// <summary>
        /// Serializes the fields of the object.
        /// </summary>
        /// <param name="encoder">The encoder.</param>
        /// <param name="value">The value.</param>
        /// <returns>Expression, serializing the fields.</returns>
        private Expression SerializeFields(Expression encoder, Expression value)
        {
            var body = new List<Expression>();

            // Check for null.
            if (!this.Schema.RuntimeType.IsValueType)
            {
                var exception =
                    new SerializationException(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            "Unexpected null value for the object of type '{0}'. Please check the schema.",
                            this.Schema.RuntimeType));
                body.Add(Expression.IfThen(
                    Expression.Equal(value, Expression.Constant(null)),
                    Expression.Throw(Expression.Constant(exception))));
            }

            body.AddRange(from field in this.Schema.Fields select field.Builder.BuildSerializer(encoder, value));
            return body.Count != 0
                ? (Expression)Expression.Block(body)
                : Expression.Empty();
        }

        private LambdaExpression GenerateCachedSkipper()
        {
            ParameterExpression decoderParam = Expression.Parameter(typeof(IDecoder), "decoder");
            BlockExpression body =
                Expression.Block(this.Schema.Fields.Select(f => f.Builder.BuildSkipper(decoderParam)));
            Type resultingFunctionType = typeof(Action<>).MakeGenericType(new[] { typeof(IDecoder) });
            return Expression.Lambda(resultingFunctionType, body, decoderParam);
        }

        private Expression CallCachedSkipper(Expression decoder)
        {
            MethodInfo getSkipper = this.GetType().GetMethod("GetSkipper", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodCallExpression skipper = Expression.Call(Expression.Constant(this), getSkipper);
            return Expression.Invoke(skipper, new[] { decoder });
        }

        protected override void SerializeSafe(IEncoder encoder, object @object)
        {
            if (@object == null)
            {
                throw new ArgumentNullException("object");
            }

            var record = @object as AvroRecord;
            if (record == null)
            {
                throw new SerializationException(string.Format(CultureInfo.InvariantCulture, "Invalid record type '{0}'.", @object.GetType()));
            }

            foreach (var field in this.Schema.Fields)
            {
                field.Builder.Serialize(encoder, record);
            }
        }

        protected override object DeserializeSafe(IDecoder decoder)
        {
            var record = new AvroRecord(this.Schema);
            foreach (var field in this.Schema.Fields)
            {
                if (field.ShouldBeSkipped)
                {
                    field.Builder.Skip(decoder);
                }
                else
                {
                    field.Builder.Deserialize(decoder, record);
                }
            }
            return record;
        }

        protected override void SkipSafe(IDecoder decoder)
        {
            foreach (var field in this.Schema.Fields)
            {
                field.Builder.Skip(decoder);
            }
        }

        internal Action<TObject, IEncoder> GetSerializer<TObject>()
        {
            return this.cachedSerializer as Action<TObject, IEncoder>;
        }

        internal Func<IDecoder, TObject> GetDeserializer<TObject>()
        {
            return this.cachedDeserializer as Func<IDecoder, TObject>;
        }

        internal Action<IDecoder> GetSkipper()
        {
            return this.cachedSkipper as Action<IDecoder>;
        }
    }
}