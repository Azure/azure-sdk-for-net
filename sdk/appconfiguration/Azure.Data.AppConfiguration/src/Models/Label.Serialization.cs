// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Data.AppConfiguration
{
#pragma warning disable AZC0012 // Avoid single word type names
    public partial class Label : IUtf8JsonSerializable
#pragma warning restore AZC0012 // Avoid single word type names
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }

        internal static Label DeserializeLabel(JsonElement element)
        {
            string name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
            }
            return new Label(name);
        }
    }
}
