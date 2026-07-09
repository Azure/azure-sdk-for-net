// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.Json;

namespace Azure.ResourceManager.SecurityInsights
{
    // Add this class due to the api compat check with properties that changed to dictionary types in 2024-01-01-preview version.
    public partial class SecurityInsightsWatchlistItemData
    {
        /// <summary> key-value pairs for a watchlist item. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("ItemsKeyValue is no longer supported. Use ItemsKeyValueDictionary instead.", false)]
        public BinaryData ItemsKeyValue
        {
            get => ToBinaryData(ItemsKeyValueDictionary);
            set => SetDictionary(ItemsKeyValueDictionary, value, nameof(ItemsKeyValue));
        }

        /// <summary> key-value pairs for a watchlist item entity mapping. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("EntityMapping is no longer supported. Use EntityMappingDictionary instead.", false)]
        public BinaryData EntityMapping
        {
            get => ToBinaryData(EntityMappingDictionary);
            set => SetDictionary(EntityMappingDictionary, value, nameof(EntityMapping));
        }

        private static BinaryData ToBinaryData(IDictionary<string, BinaryData> dictionary)
        {
            if (dictionary is null || dictionary.Count == 0)
            {
                return null;
            }

            using MemoryStream stream = new MemoryStream();
            using (Utf8JsonWriter writer = new Utf8JsonWriter(stream))
            {
                writer.WriteStartObject();
                foreach (var item in dictionary)
                {
                    writer.WritePropertyName(item.Key);
                    if (item.Value is null)
                    {
                        writer.WriteNullValue();
                    }
                    else
                    {
                        using JsonDocument document = JsonDocument.Parse(item.Value);
                        document.RootElement.WriteTo(writer);
                    }
                }
                writer.WriteEndObject();
            }

            return BinaryData.FromBytes(stream.ToArray());
        }

        private static void SetDictionary(IDictionary<string, BinaryData> dictionary, BinaryData value, string propertyName)
        {
            dictionary.Clear();
            if (value is null)
            {
                return;
            }

            using JsonDocument document = JsonDocument.Parse(value);
            if (document.RootElement.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            if (document.RootElement.ValueKind != JsonValueKind.Object)
            {
                throw new ArgumentException($"{propertyName} must contain a JSON object to map to the dictionary-based replacement property.", propertyName);
            }

            foreach (JsonProperty item in document.RootElement.EnumerateObject())
            {
                dictionary[item.Name] = BinaryData.FromString(item.Value.GetRawText());
            }
        }
    }
}
