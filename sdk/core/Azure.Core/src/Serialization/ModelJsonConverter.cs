// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// .
    /// </summary>
#pragma warning disable AZC0014 // Avoid using banned types in public API
    public class ModelJsonConverter : JsonConverter<IModelSerializable>
#pragma warning restore AZC0014 // Avoid using banned types in public API
    {
        /// <summary>
        /// .
        /// </summary>
        public bool IgnoreAdditionalProperties { get; set; } = true;

        /// <summary>
        /// .
        /// </summary>
        public Dictionary<Type, ObjectSerializer> Serializers { get; set; } = new Dictionary<Type, ObjectSerializer>();

        /// <summary>
        /// .
        /// </summary>
        public ModelJsonConverter() { }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="ignoreAdditionalProperties"></param>
        public ModelJsonConverter(bool ignoreAdditionalProperties)
        {
            IgnoreAdditionalProperties = ignoreAdditionalProperties;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="typeToConvert"></param>
        /// <returns></returns>
        public override bool CanConvert(Type typeToConvert)
        {
            return !Attribute.IsDefined(typeToConvert, typeof(JsonConverterAttribute));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
#pragma warning disable AZC0014 // Avoid using banned types in public API
        public override IModelSerializable Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
#pragma warning restore AZC0014 // Avoid using banned types in public API
        {
            return (IModelSerializable)ModelSerializer.Deserialize(BinaryData.FromString(JsonDocument.ParseValue(ref reader).RootElement.GetRawText()), typeToConvert, ConvertOptions(options));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
#pragma warning disable AZC0014 // Avoid using banned types in public API
        public override void Write(Utf8JsonWriter writer, IModelSerializable value, JsonSerializerOptions options)
#pragma warning restore AZC0014 // Avoid using banned types in public API
        {
            BinaryData data = value.Serialize(ConvertOptions(options));
#if NET6_0_OR_GREATER
            writer.WriteRawValue(data);
#else
            JsonSerializer.Serialize(writer, JsonDocument.Parse(data.ToString()).RootElement);
#endif
        }

        private ModelSerializerOptions ConvertOptions(JsonSerializerOptions options)
        {
            ModelSerializerOptions serializableOptions = new ModelSerializerOptions();
            serializableOptions.IgnoreAdditionalProperties = IgnoreAdditionalProperties;
            serializableOptions.Serializers = Serializers;
            serializableOptions.IgnoreReadOnlyProperties = options.IgnoreReadOnlyProperties;
            return serializableOptions;
        }
    }
}
