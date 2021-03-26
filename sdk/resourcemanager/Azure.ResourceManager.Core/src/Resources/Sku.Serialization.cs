// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing SKU for resource.
    /// </summary>
    public sealed partial class Sku
    {
        /// <summary>
        /// Serialize the input Sku object.
        /// </summary>
        /// <param name="writer"> Input Json writer. </param>
        /// <param name="value"> Input Sku object. </param>
        internal static void Serialize(Utf8JsonWriter writer, Sku value)
        {
            if (writer is null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(value.Name))
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(value.Name);
            }
            if (Optional.IsDefined(value.Tier))
            {
                writer.WritePropertyName("tier");
                writer.WriteStringValue(value.Tier);
            }
            if (Optional.IsDefined(value.Size))
            {
                writer.WritePropertyName("size");
                writer.WriteStringValue(value.Size);
            }
            if (Optional.IsDefined(value.Family))
            {
                writer.WritePropertyName("family");
                writer.WriteStringValue(value.Family);
            }
            if (Optional.IsDefined(value.Capacity))
            {
                writer.WritePropertyName("capacity");
                writer.WriteNumberValue(value.Capacity.Value);
            }
            writer.WriteEndObject();
        }

        /// <summary>
        /// Deserialize the input Json object.
        /// </summary>
        /// <param name="element"> The Json object need to be deserialized. </param>
        internal static Sku Deserialize(JsonElement element)
        {
            Optional<string> name = default;
            Optional<string> tier = default;
            Optional<string> size = default;
            Optional<string> family = default;
            Optional<string> model = default;
            Optional<int> capacity = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("tier"))
                {
                    tier = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("size"))
                {
                    size = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("family"))
                {
                    family = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("model"))
                {
                    model = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("capacity"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    capacity = property.Value.GetInt32();
                    continue;
                }
            }

            return new Sku(name.Value, tier.Value, family.Value, size.Value, Optional.ToNullable(capacity));
        }
    }
}
