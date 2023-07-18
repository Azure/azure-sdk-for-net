// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Xml;

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
        public static BinaryData Serialize<T>(T model, ModelSerializerOptions? options = default) where T : IModelSerializable
        {
            options ??= new ModelSerializerOptions();

            if (options.Serializers.TryGetValue(typeof(T), out var serializer))
                return serializer.Serialize(model);

            switch (model)
            {
                case IJsonModelSerializable jsonModel:
                    return SerializeJson(jsonModel, options);
                case IXmlModelSerializable xmlModel:
                    return SerializeXml(xmlModel, options);
                default:
                    throw new NotSupportedException("Model type is not supported.");
            }
        }

        private static BinaryData SerializeXml(IXmlModelSerializable xmlModel, ModelSerializerOptions options)
        {
            using MemoryStream stream = new MemoryStream();
            using XmlWriter writer = XmlWriter.Create(stream);
            xmlModel.Serialize(writer, options);
            writer.Flush();
            return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
        }

        private static BinaryData SerializeJson(IJsonModelSerializable jsonModel, ModelSerializerOptions options)
        {
            using var multiBufferRequestContent = new MultiBufferRequestContent();
            using var writer = new Utf8JsonWriter(multiBufferRequestContent);
            jsonModel.Serialize(writer, options);
            writer.Flush();
            multiBufferRequestContent.TryComputeLength(out var length);
            using var stream = new MemoryStream((int)length);
            multiBufferRequestContent.WriteTo(stream, default);
            return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
        }

        /// <summary>
        /// Serialize a XML model. Todo: collapse this method when working - need compile check over runtime
        /// </summary>
        /// <returns></returns>
        public static T Deserialize<T>(BinaryData data, ModelSerializerOptions? options = default) where T : class, IModelSerializable
        {
            return (T)Deserialize(data, typeof(T), options ?? new ModelSerializerOptions());
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="data"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static object Deserialize(BinaryData data, Type typeToConvert, ModelSerializerOptions options)
        {
            if (options.Serializers.TryGetValue(typeToConvert, out var serializer))
            {
                var obj = serializer.Deserialize(data.ToStream(), typeToConvert, default);
                return obj ?? throw new InvalidOperationException();
            }

            if (typeToConvert.IsAbstract)
                return DeserializeObject(data, typeToConvert, options);

            var model = Activator.CreateInstance(typeToConvert, true) as IModelSerializable;

            return model!.Deserialize(data, options);
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
