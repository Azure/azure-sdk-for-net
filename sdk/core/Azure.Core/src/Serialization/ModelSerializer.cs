﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Serializer class for Azure models.
    /// </summary>
    public static class ModelSerializer
    {
        /// <summary>
        /// Serialize a model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static BinaryData Serialize<T>(T model, ModelSerializerOptions? options = default) where T : IModelSerializable<T>
        {
            options ??= new ModelSerializerOptions(ModelSerializerFormat.Wire);

            var serializer = options.Value.UnknownTypeSerializationFallback is not null ? options.Value.UnknownTypeSerializationFallback(typeof(T)) : null;
            if (serializer is not null)
                return serializer.Serialize(model);

            return model.Serialize(options.Value);
        }

        /// <summary>
        /// Serialize a model.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static BinaryData Serialize(object model, ModelSerializerOptions? options = default)
        {
            options ??= new ModelSerializerOptions(ModelSerializerFormat.Wire);

            var iModel = model as IModelSerializable;
            if (iModel is null)
                throw new InvalidOperationException($"{model.GetType().Name} does not implement {nameof(IModelSerializable)}");

            var serializer = options.Value.UnknownTypeSerializationFallback is not null ? options.Value.UnknownTypeSerializationFallback(model.GetType()) : null;
            if (serializer is not null)
                return serializer.Serialize(model);

            return iModel.Serialize(options.Value);
        }

        /// <summary>
        /// Serialize a XML model. Todo: collapse this method when working - need compile check over runtime
        /// </summary>
        /// <returns></returns>
        public static T Deserialize<T>(BinaryData data, ModelSerializerOptions? options = default) where T : class, IModelSerializable<T>
        {
            options ??= new ModelSerializerOptions(ModelSerializerFormat.Wire);

            var genericDeserialize = GenericDeserialize(data, typeof(T), options.Value);
            if (genericDeserialize is not null)
                return (T)genericDeserialize;

            var model = Activator.CreateInstance(typeof(T), true) as IModelSerializable<T>;

            return model!.Deserialize(data, options.Value);
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="data"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static object Deserialize(BinaryData data, Type typeToConvert, ModelSerializerOptions? options = default)
        {
            options ??= new ModelSerializerOptions(ModelSerializerFormat.Wire);

            var genericDeserialize = GenericDeserialize(data, typeToConvert, options.Value);
            if (genericDeserialize is not null)
                return genericDeserialize;

            var model = Activator.CreateInstance(typeToConvert, true) as IModelSerializable;

            return model!.Deserialize(data, options.Value);
        }

        private static object? GenericDeserialize(BinaryData data, Type typeToConvert, ModelSerializerOptions options)
        {
            var serializer = options.UnknownTypeSerializationFallback is not null ? options.UnknownTypeSerializationFallback(typeToConvert) : null;
            if (serializer is not null)
            {
                var obj = serializer.Deserialize(data.ToStream(), typeToConvert, default);
                return obj ?? throw new InvalidOperationException();
            }

            if (typeToConvert.IsAbstract)
                return DeserializeObject(data, typeToConvert, options);

            return null;
        }

        private static readonly Type[] _combinedDeserializeMethodParameters = new Type[] { typeof(BinaryData), typeof(ModelSerializerOptions) };

        internal static object DeserializeObject(BinaryData data, Type typeToConvert, ModelSerializerOptions options)
        {
            var classNameInMethod = typeToConvert.Name.AsSpan();
            int backtickIndex = classNameInMethod.IndexOf('`');
            if (backtickIndex != -1)
                classNameInMethod = classNameInMethod.Slice(0, backtickIndex);
            var methodName = $"Deserialize{classNameInMethod.ToString()}";

            var method = typeToConvert.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static, null, _combinedDeserializeMethodParameters, null);
            if (method is null)
                throw new NotSupportedException($"{typeToConvert.Name} does not have a deserialize method defined.");

            return method.Invoke(null, new object[] { data, options })!;
        }
    }
}
