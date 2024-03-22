// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary>
    /// A class representing a sub-resource that contains only the ID.
    /// </summary>
    [JsonConverter(typeof(WritableSubResourceConverter))]
    public partial class WritableSubResource : IUtf8JsonSerializable
    {
        /// <summary>
        /// Serialize the input WritableSubResource object.
        /// </summary>
        /// <param name="writer"> Input Json writer. </param>
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            if (writer is null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id");
                writer.WriteStringValue(Id);
            }
            writer.WriteEndObject();
        }

        /// <summary>
        /// Deserialize the input JSON element to a WritableSubResource object.
        /// </summary>
        /// <param name="element">The JSON element to be deserialized.</param>
        /// <returns>Deserialized WritableSubResource object.</returns>
        internal static WritableSubResource DeserializeWritableSubResource(JsonElement element)
        {
            ResourceIdentifier id = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
            }
            return new WritableSubResource(id);
        }

        internal partial class WritableSubResourceConverter : JsonConverter<WritableSubResource>
        {
            public override void Write(Utf8JsonWriter writer, WritableSubResource model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override WritableSubResource Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeWritableSubResource(document.RootElement);
            }
        }
    }
}
