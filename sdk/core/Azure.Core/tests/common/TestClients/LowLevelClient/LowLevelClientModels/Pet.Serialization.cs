// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;

namespace Azure.Core.Experimental.Tests.Models
{
    public partial class Pet : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);

            writer.WritePropertyName("species");
            writer.WriteStringValue(Species);

            writer.WriteEndObject();
        }

        internal static Pet DeserializePet(JsonElement element)
        {
            Optional<string> name = default;
            Optional<string> species = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("species"))
                {
                    species = property.Value.GetString();
                    continue;
                }
            }
            return new Pet(name.Value, species.Value);
        }
    }
}
