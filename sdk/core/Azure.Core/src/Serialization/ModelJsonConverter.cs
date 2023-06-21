// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            var model = ModelSerializer.DeserializeObject(JsonDocument.ParseValue(ref reader).RootElement, typeToConvert, ConvertOptions(options)) as IModelSerializable;
            if (model is null)
                throw new InvalidOperationException($"Unexpected error when deserializing {typeToConvert.Name}.");

            return model;
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
            value.Serialize(writer, ConvertOptions(options));
        }

        private ModelSerializerOptions ConvertOptions(JsonSerializerOptions options)
        {
            ModelSerializerOptions serializableOptions = new ModelSerializerOptions();
            serializableOptions.IgnoreAdditionalProperties = IgnoreAdditionalProperties;
            serializableOptions.IgnoreReadOnlyProperties = options.IgnoreReadOnlyProperties;
            return serializableOptions;
        }
    }
}
