﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

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
        public static Stream Serialize<T>(T model, SerializableOptions? options = default) where T : IJsonSerializable, new()
        {
            // if options.Serializers is set and the model is in the dictionary, use the serializer
            if (options != null && options.Serializers != null && typeof(T) != null)
            {
                ObjectSerializer? serializer;

                if (options.Serializers.TryGetValue(typeof(T), out serializer))
                {
                    System.BinaryData data = serializer.Serialize(model);
                    return data.ToStream();
                }
            }
            // else use default STJ serializer
            IJsonSerializable serializable = (model ??= new T()) as IJsonSerializable;
            Stream stream = new MemoryStream();
            serializable.Serialize(stream, options);
            return stream;
        }

        /// <summary>
        /// Deserialize a model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static T Deserialize<T>(Stream stream, SerializableOptions? options = default) where T : IJsonSerializable, new()
        {
            if (options != null && options.Serializers != null)
            {
                var obj = options.Serializers[typeof(T)].Deserialize(stream, typeof(T), default);
                if (obj is null)
                    throw new InvalidOperationException();
                else
                    return (T)obj;
            }

            IJsonSerializable serializable = new T();
            serializable.Deserialize(stream, options);
            return (T)serializable;
        }

        /// <summary>
        /// Deserialize a model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string json, SerializableOptions? options = default) where T : IJsonSerializable, new()
        {
            using Stream stream = new MemoryStream();
            using StreamWriter writer = new StreamWriter(stream);
            writer.Write(json);
            stream.Position = 0;

            if (options != null && options.Serializers != null)
            {
                var obj = options.Serializers[typeof(T)].Deserialize(stream, typeof(T), default);
                if (obj is null)
                    throw new InvalidOperationException();
                else
                    return (T)obj;
            }

            IJsonSerializable serializable = new T();
            serializable.Deserialize(stream, options);
            return (T)serializable;
        }
    }
}
