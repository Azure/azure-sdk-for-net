// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Maps.Common;

namespace Azure.Maps.Weather.Models
{
    public partial class StormSearchResultItem
    {
        internal static StormSearchResultItem DeserializeStormSearchResultItem(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string year = default;
            BasinId? basinId = default;
            string name = default;
            bool? isActive = default;
            bool? isRetired = default;
            bool? isSubtropical = default;
            int? govId = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("year"u8))
                {
                    year = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("basinId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    basinId = new BasinId(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("isActive"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    isActive = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("isRetired"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    isRetired = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("isSubtropical"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    isSubtropical = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("govId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    govId = property.Value.GetInt32();
                    continue;
                }
            }
            return new StormSearchResultItem(
                year,
                basinId,
                name,
                isActive,
                isRetired,
                isSubtropical,
                govId);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static StormSearchResultItem FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeStormSearchResultItem(document.RootElement);
        }
    }
}
