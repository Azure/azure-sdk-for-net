// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Data.AppConfiguration
{
    public partial class ConfigurationSettingsSnapshot : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("filters");
            writer.WriteStartArray();
            foreach (var item in Filters)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(CompositionType))
            {
                writer.WritePropertyName("composition_type");
                writer.WriteStringValue(CompositionType.Value.ToString());
            }
            if (Optional.IsDefined(RetentionPeriod))
            {
                writer.WritePropertyName("retention_period");
                writer.WriteNumberValue(RetentionPeriod.Value);
            }
            if (Optional.IsCollectionDefined(Tags))
            {
                writer.WritePropertyName("tags");
                writer.WriteStartObject();
                foreach (var item in Tags)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }

        internal static ConfigurationSettingsSnapshot DeserializeSnapshot(JsonElement element)
        {
            Optional<string> name = default;
            Optional<SnapshotStatus> status = default;
            Optional<int> statusCode = default;
            IList<ConfigurationSettingFilter> filters = default;
            Optional<CompositionType> compositionType = default;
            Optional<DateTimeOffset> created = default;
            Optional<DateTimeOffset?> expires = default;
            Optional<long> retentionPeriod = default;
            Optional<long> size = default;
            Optional<long> itemsCount = default;
            Optional<IDictionary<string, string>> tags = default;
            Optional<string> etag = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("status"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    status = new SnapshotStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("status_code"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    statusCode = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("filters"))
                {
                    List<ConfigurationSettingFilter> array = new List<ConfigurationSettingFilter>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ConfigurationSettingFilter.DeserializeKeyValueFilter(item));
                    }
                    filters = array;
                    continue;
                }
                if (property.NameEquals("composition_type"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    compositionType = new CompositionType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("created"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    created = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("expires"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        expires = null;
                        continue;
                    }
                    expires = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("retention_period"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    retentionPeriod = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("size"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    size = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("items_count"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    itemsCount = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("tags"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    tags = dictionary;
                    continue;
                }
                if (property.NameEquals("etag"))
                {
                    etag = property.Value.GetString();
                    continue;
                }
            }
            return new ConfigurationSettingsSnapshot(name.Value, Optional.ToNullable(status), Optional.ToNullable(statusCode), filters, Optional.ToNullable(compositionType), Optional.ToNullable(created), Optional.ToNullable(expires), Optional.ToNullable(retentionPeriod), Optional.ToNullable(size), Optional.ToNullable(itemsCount), Optional.ToDictionary(tags), etag.Value);
        }

        // Mapping raw response to model
        internal static ConfigurationSettingsSnapshot FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeSnapshot(document.RootElement);
        }

        // Mapping model to raw request
        internal static RequestContent ToRequestContent(ConfigurationSettingsSnapshot snapshot)
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(snapshot);
            return content;
        }
    }
}
