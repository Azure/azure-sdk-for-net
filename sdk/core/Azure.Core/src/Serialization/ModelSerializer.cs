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
            options ??= ModelSerializerOptions.DefaultServiceOptions;

            var serializer = options.GenericTypeSerializerCreator is not null ? options.GenericTypeSerializerCreator(typeof(T)) : null;
            if (serializer is not null)
                return serializer.Serialize(model);

            return model.Serialize(options);
        }

        /// <summary>
        /// Serialize a model.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static BinaryData Serialize(object model, ModelSerializerOptions? options = default)
        {
            options ??= ModelSerializerOptions.DefaultServiceOptions;

            var iModel = model as IModelSerializable<object>;
            if (iModel is null)
                throw new InvalidOperationException($"{model.GetType().Name} does not implement {nameof(IModelSerializable<object>)}");

            var serializer = options.GenericTypeSerializerCreator is not null ? options.GenericTypeSerializerCreator(model.GetType()) : null;
            if (serializer is not null)
                return serializer.Serialize(model);

            return iModel.Serialize(options);
        }

        /// <summary>
        /// Serialize a XML model. Todo: collapse this method when working - need compile check over runtime
        /// </summary>
        /// <returns></returns>
        public static T Deserialize<T>(BinaryData data, ModelSerializerOptions? options = default) where T : class, IModelSerializable<T>
        {
            options ??= ModelSerializerOptions.DefaultServiceOptions;

            var genericDeserialize = GenericDeserialize(data, typeof(T), options);
            if (genericDeserialize is not null)
                return (T)genericDeserialize;

            var model = Activator.CreateInstance(typeof(T), true) as IModelSerializable<T>;

            return model!.Deserialize(data, options);
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="data"></param>
        /// <param name="returnType"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static object Deserialize(BinaryData data, Type returnType, ModelSerializerOptions? options = default)
        {
            options ??= ModelSerializerOptions.DefaultServiceOptions;

            var genericDeserialize = GenericDeserialize(data, returnType, options);
            if (genericDeserialize is not null)
                return genericDeserialize;

            var model = Activator.CreateInstance(returnType, true) as IModelSerializable<object>;

            return model!.Deserialize(data, options);
        }

        private static object? GenericDeserialize(BinaryData data, Type typeToConvert, ModelSerializerOptions options)
        {
            var serializer = options.GenericTypeSerializerCreator is not null ? options.GenericTypeSerializerCreator(typeToConvert) : null;
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
