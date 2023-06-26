﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Serializer class for Azure models.
    /// </summary>
    public static class ModelSerializer
    {
        #region JsonSerialize
        /// <summary>
        /// Serialize a model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static Stream SerializeJson<T>(T model, ModelSerializerOptions? options = default) where T : class, IJsonSerializableModel
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
        #endregion

        #region XmlSerialize
        /// <summary>
        /// Serialize a XML model. Todo: collapse this method when working - need compile check over runtime
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static Stream SerializeXml<T>(T model, ModelSerializerOptions? options = default) where T : class, IXmlSerializableModel
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
            // else use default XmlWriter
            Stream stream = new MemoryStream();
            var writer = XmlWriter.Create(stream, new XmlWriterSettings
            {
                Encoding = new UTF8Encoding(false),
                OmitXmlDeclaration = true,
                Indent = true
            });

            model.Serialize(writer, options ?? new ModelSerializerOptions());
            writer.Flush();
            return stream;
        }
        #endregion

        #region GenericSerialize
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
            return model.Serialize(options ?? new ModelSerializerOptions());
        }
        #endregion

        #region XmlDeserialize
        /// <summary>
        /// Serialize a XML model. Todo: collapse this method when working - need compile check over runtime
        /// </summary>
        /// <returns></returns>
        public static T DeserializeXml<T>(Stream stream, ModelSerializerOptions? options = default) where T : class, IXmlSerializableModel
        {
            if (options != null)
            {
                ObjectSerializer? serializer;

                if (options.Serializers.TryGetValue(typeof(T), out serializer))
                {
                    var obj = serializer.Deserialize(stream, typeof(T), default);
                    if (obj is null)
                        throw new InvalidOperationException();
                    else
                        return (T)obj;
                }
            }

            return DeserializeWithReflectionXml<T>(XElement.Load(stream), options);
        }

        private static T DeserializeWithReflectionXml<T>(XElement xmlElement, ModelSerializerOptions? options) where T : class, IXmlSerializableModel
        {
            Type typeToConvert = typeof(T);
            options ??= new ModelSerializerOptions();

            T? model = DeserializeObjectXml(xmlElement, typeToConvert, options) as T;
            if (model is null)
                throw new InvalidOperationException($"Unexpected error when deserializing {typeToConvert.Name}.");

            return model;
        }

        internal static object? DeserializeObjectXml(XElement xmlElement, Type typeToConvert, ModelSerializerOptions options)
        {
            var classNameInMethod = typeToConvert.Name.AsSpan();
            int backtickIndex = classNameInMethod.IndexOf('`');
            if (backtickIndex != -1)
                classNameInMethod = classNameInMethod.Slice(0, backtickIndex);
            var methodName = $"Deserialize{classNameInMethod.ToString()}";

            var method = typeToConvert.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static);
            if (method is null)
                throw new NotSupportedException($"{typeToConvert.Name} does not have a deserialize method defined.");

            return method.Invoke(null, new object[] { xmlElement, options });
        }
        #endregion

        #region JsonDeserialize
        /// <summary>
        /// Deserialize a model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static T DeserializeJson<T>(string json, ModelSerializerOptions? options = default) where T : class, IJsonSerializableModel
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

            return DeserializeWithReflectionJson<T>(JsonDocument.Parse(stream).RootElement, options);
        }

        /// <summary>
        /// Deserialize a model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static T DeserializeJson<T>(Stream stream, ModelSerializerOptions? options = default) where T : class, IJsonSerializableModel
        {
            if (options != null)
            {
                ObjectSerializer? serializer;

                if (options.Serializers.TryGetValue(typeof(T), out serializer))
                {
                    var obj = serializer.Deserialize(stream, typeof(T), default);
                    if (obj is null)
                        throw new InvalidOperationException();
                    else
                        return (T)obj;
                }
            }

            return DeserializeWithReflectionJson<T>(JsonDocument.Parse(stream).RootElement, options);
        }

        private static T DeserializeWithReflectionJson<T>(JsonElement rootElement, ModelSerializerOptions? options) where T : class, IJsonSerializableModel
        {
            Type typeToConvert = typeof(T);
            options ??= new ModelSerializerOptions();

            T? model = DeserializeObjectJson(rootElement, typeToConvert, options) as T;
            if (model is null)
                throw new InvalidOperationException($"Unexpected error when deserializing {typeToConvert.Name}.");

            return model;
        }

        internal static object? DeserializeObjectJson(JsonElement rootElement, Type typeToConvert, ModelSerializerOptions options)
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
        #endregion

        #region GenericDeserialize
        /// <summary>
        /// Serialize a XML model. Todo: collapse this method when working - need compile check over runtime
        /// </summary>
        /// <returns></returns>
        public static T Deserialize<T>(Stream stream, ModelSerializerOptions? options = default) where T : class, IModelSerializable
        {
            if (options != null)
            {
                ObjectSerializer? serializer;

                if (options.Serializers.TryGetValue(typeof(T), out serializer))
                {
                    var obj = serializer.Deserialize(stream, typeof(T), default);
                    if (obj is null)
                        throw new InvalidOperationException();
                    else
                        return (T)obj;
                }
            }

            return DeserializeWithReflection<T>(stream, options);
        }

        private static T DeserializeWithReflection<T>(Stream stream, ModelSerializerOptions? options) where T : class, IModelSerializable
        {
            Type typeToConvert = typeof(T);
            options ??= new ModelSerializerOptions();

            T? model = DeserializeObject(stream, typeToConvert, options) as T;
            if (model is null)
                throw new InvalidOperationException($"Unexpected error when deserializing {typeToConvert.Name}.");

            return model;
        }

        private static readonly Type[] _combinedDeserializeMethodParameters = new Type[] { typeof(Stream), typeof(ModelSerializerOptions) };

        internal static object? DeserializeObject(Stream stream, Type typeToConvert, ModelSerializerOptions options)
        {
            var classNameInMethod = typeToConvert.Name.AsSpan();
            int backtickIndex = classNameInMethod.IndexOf('`');
            if (backtickIndex != -1)
                classNameInMethod = classNameInMethod.Slice(0, backtickIndex);
            var methodName = $"Deserialize{classNameInMethod.ToString()}";

            var method = typeToConvert.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static, null, _combinedDeserializeMethodParameters, null);
            if (method is null)
                throw new NotSupportedException($"{typeToConvert.Name} does not have a deserialize method defined.");

            return method.Invoke(null, new object[] { stream, options });
        }
        #endregion
    }
}
