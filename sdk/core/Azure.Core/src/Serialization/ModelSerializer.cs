// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
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
        public static BinaryData Serialize<T>(T model, ModelSerializerOptions? options = default) where T : IModelSerializable<T>
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

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
            options ??= ModelSerializerOptions.DefaultWireOptions;

            var iModel = model as IModelSerializable<object>;
            if (iModel is null)
                throw new InvalidOperationException($"{model.GetType().Name} does not implement {nameof(IModelSerializable<object>)}");

            return iModel.Serialize(options);
        }

        /// <summary>
        /// Serialize a XML model. Todo: collapse this method when working - need compile check over runtime
        /// </summary>
        /// <returns></returns>
        public static T Deserialize<T>(BinaryData data, ModelSerializerOptions? options = default) where T : IModelSerializable<T>
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            return GetInstance<T>().Deserialize(data, options);
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
            options ??= ModelSerializerOptions.DefaultWireOptions;

            return GetInstance(returnType).Deserialize(data, options);
        }

        /// <summary>
        /// Converts an <see cref="IModelJsonSerializable{T}"/> into a <see cref="BinaryData"/>.
        /// </summary>
        /// <param name="model">The model to convert.</param>
        /// <param name="options">The <see cref="ModelSerializerOptions"/> to use.</param>
        /// <returns>A binary representation of the serialized model.</returns>
        public static BinaryData ConvertToBinaryData(IModelJsonSerializable<object> model, ModelSerializerOptions? options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;
            using var writer = new SequenceWriter();
            using var jsonWriter = new Utf8JsonWriter(writer);
            model.Serialize(jsonWriter, options);
            jsonWriter.Flush();
            writer.TryComputeLength(out var length);
            using var stream = new MemoryStream((int)length);
            writer.CopyTo(stream, default);
            return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
        }

        /// <summary>
        /// Converts an <see cref="IModelXmlSerializable{T}"/> into a <see cref="BinaryData"/>.
        /// </summary>
        /// <param name="model">The model to convert.</param>
        /// <param name="options">The <see cref="ModelSerializerOptions"/> to use.</param>
        /// <returns>A binary representation of the serialized model.</returns>
        public static BinaryData ConvertToBinaryData(IModelXmlSerializable<object> model, ModelSerializerOptions? options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;
            using MemoryStream stream = new MemoryStream();
            using XmlWriter writer = XmlWriter.Create(stream);
            model.Serialize(writer, options);
            writer.Flush();
            return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
        }

        private static IModelSerializable<object> GetInstance(Type returnType)
        {
            var model = GetObjectInstance(returnType) as IModelSerializable<object>;
            if (model is null)
                throw new InvalidOperationException($"{returnType.Name} does not implement {nameof(IModelSerializable<object>)}");
            return model;
        }

        private static IModelSerializable<T> GetInstance<T>() where T : IModelSerializable<T>
        {
            var model = GetObjectInstance(typeof(T)) as IModelSerializable<T>;
            if (model is null)
                throw new InvalidOperationException($"{typeof(T).Name} does not implement {nameof(IModelSerializable<T>)}");
            return model;
        }

        private static object GetObjectInstance(Type returnType)
        {
            var typeToActivate = returnType.IsAbstract ? returnType.Assembly.GetTypes().FirstOrDefault(t => t.Name == $"Unknown{returnType.Name}") : returnType;
            if (typeToActivate is null)
                throw new InvalidOperationException($"Unable to find type Unknown{returnType.Name} in assembly {returnType.Assembly.FullName}.");
            var obj = Activator.CreateInstance(typeToActivate, true);
            if (obj is null)
                throw new InvalidOperationException($"Unable to create instance of {typeToActivate.Name}.");
            return obj;
        }
    }
}
