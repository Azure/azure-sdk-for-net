// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Add
    /// </summary>
#pragma warning disable AZC0014 // Avoid using banned types in public API
    public class ModelJsonConverter : JsonConverter<IJsonModelSerializable>
#pragma warning restore AZC0014 // Avoid using banned types in public API
    {
        /// <summary>
        /// .
        /// </summary>
        public ModelSerializerOptions Options { get; }

        /// <summary>
        /// ModelSerializerFormat that determines Format of serialized model. ModelSerializerFormat.Data = data format which means both properties are false, ModelSerializerFormat.Wire = wire format which means both properties are true Default is ModelSerializerFormat.Data.
        /// </summary>
        public ModelSerializerFormat Format { get; }

        /// <summary>
        /// .
        /// </summary>
        public Dictionary<Type, ObjectSerializer> Serializers { get; set; } = new Dictionary<Type, ObjectSerializer>();

        /// <summary>
        /// String that determines Format of serialized model. "D" = data format which means both properties are false, "W" = wire format which means both properties are true Default is "D".
        /// </summary>
        public ModelJsonConverter(string format = "D")
        {
            Format = format;
            Options = new ModelSerializerOptions(Format);
            Options.Serializers = Serializers;
        }

        /// <summary>
        /// Check if a certain type can be converted to IModelSerializable
        /// </summary>
        /// <param name="typeToConvert"></param>
        /// <returns></returns>
        public override bool CanConvert(Type typeToConvert)
        {
            return !Attribute.IsDefined(typeToConvert, typeof(JsonConverterAttribute));
        }

        /// <summary>
        /// todo
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
#pragma warning disable AZC0014 // Avoid using banned types in public API
        public override IJsonModelSerializable Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
#pragma warning restore AZC0014 // Avoid using banned types in public API
        {
            return (IJsonModelSerializable)ModelSerializer.Deserialize(BinaryData.FromString(JsonDocument.ParseValue(ref reader).RootElement.GetRawText()), typeToConvert, Options);
        }

        /// <summary>
        /// todo
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
#pragma warning disable AZC0014 // Avoid using banned types in public API
        public override void Write(Utf8JsonWriter writer, IJsonModelSerializable value, JsonSerializerOptions options)
#pragma warning restore AZC0014 // Avoid using banned types in public API
        {
            value.Serialize(writer, Options);
        }
    }
}
