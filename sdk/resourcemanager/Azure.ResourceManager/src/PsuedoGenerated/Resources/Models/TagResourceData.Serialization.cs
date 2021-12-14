// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    public partial class TagResourceData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("properties");
            writer.WriteObjectValue(Properties);
            writer.WriteEndObject();
        }

        internal static TagResourceData DeserializeTagsResource(JsonElement element)
        {
            Optional<ResourceIdentifier> id = default;
            Optional<string> name = default;
            Optional<string> type = default;
            Tag properties = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    properties = Tag.DeserializeTags(property.Value);
                    continue;
                }
            }
            return new TagResourceData(id.Value, name.Value, type.Value, properties);
        }
    }
}
