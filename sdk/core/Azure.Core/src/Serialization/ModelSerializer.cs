﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using System.Text.Json;

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
        public static Stream Serialize<T>(T model, ModelSerializerOptions? options = default) where T : class, IModelSerializable
        {
            // if options.Serializers is set and the model is in the dictionary, use the serializer
            if (options != null)
            {
                ObjectSerializer? serializer;

                if (options.Serializers.TryGetValue(typeof(T), out serializer))
                {
                    BinaryData data = serializer.Serialize(model);
                    return data.ToStream();
                }
            }
            // else use default STJ serializer
            Stream stream = new MemoryStream();
            var writer = new Utf8JsonWriter(stream);
            model.Serialize(writer, options ?? new ModelSerializerOptions());
            writer.Flush();
            return stream;
        }

        /// <summary>
        /// Deserialize a model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static T Deserialize<T>(Stream stream, ModelSerializerOptions? options = default) where T : class, IModelSerializable
        {
            if (options != null)
            {
                ObjectSerializer? serializer;

                if (options.Serializers.TryGetValue(typeof(T), out serializer))
                {
                    var obj = serializer.Deserialize(stream, typeof(T), default); //problem here T is Envelope<T> and typeof(T) is Envelope<T> but we want typeof(T) to be DogListProperty
                    if (obj is null)
                        throw new InvalidOperationException();
                    else
                        return (T)obj;
                }
            }

            return DeserializeWithReflection<T>(JsonDocument.Parse(stream).RootElement, options);
        }

        private static T DeserializeWithReflection<T>(JsonElement rootElement, ModelSerializerOptions? options) where T : class, IModelSerializable
        {
            Type typeToConvert = typeof(T);
            options ??= new ModelSerializerOptions();

            T? model = DeserializeObject(rootElement, typeToConvert, options) as T;
            if (model is null)
                throw new InvalidOperationException($"Unexpected error when deserializing {typeToConvert.Name}.");

            return model;
        }

        internal static object? DeserializeObject(JsonElement rootElement, Type typeToConvert, ModelSerializerOptions options)
        {
            var classNameInMethod = typeToConvert.Name.AsSpan();
            int backtickIndex = classNameInMethod.IndexOf('`');
            if (backtickIndex != -1)
                classNameInMethod = classNameInMethod.Slice(0, backtickIndex);
            var methodName = $"Deserialize{classNameInMethod.ToString()}";

            var method = typeToConvert.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static);
            if (method is null)
                throw new NotSupportedException($"{typeToConvert.Name} does not have a deserialize method defined.");

            return method.Invoke(null, new object[] { rootElement, options });
        }

        /// <summary>
        /// Deserialize a model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string json, ModelSerializerOptions? options = default) where T : class, IModelSerializable
        {
            using Stream stream = new MemoryStream();
            using StreamWriter writer = new StreamWriter(stream);
            writer.Write(json);
            stream.Position = 0;
            ObjectSerializer? serializer;

            if (options != null)
            {
                if (options.Serializers.TryGetValue(typeof(T), out serializer))
                {
                    var obj = serializer.Deserialize(stream, typeof(T), default);
                    if (obj is null)
                        throw new InvalidOperationException();
                    else
                        return (T)obj;
                }
            }

            return DeserializeWithReflection<T>(JsonDocument.Parse(stream).RootElement, options);
        }
    }
}
