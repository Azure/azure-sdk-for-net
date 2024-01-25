// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Data.AppConfiguration
{
    public partial class ConfigurationSnapshot : IUtf8JsonSerializable
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
            if (Optional.IsDefined(SnapshotComposition))
            {
                writer.WritePropertyName("composition_type");
                writer.WriteStringValue(SnapshotComposition.Value.ToString());
            }
            if (Optional.IsDefined(RetentionPeriod))
            {
                writer.WritePropertyName("retention_period");
                writer.WriteNumberValue(RetentionPeriod.Value.TotalSeconds);
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

        internal static ConfigurationSnapshot DeserializeSnapshot(JsonElement element)
        {
            Optional<string> name = default;
            Optional<ConfigurationSnapshotStatus> status = default;
            IList<ConfigurationSettingsFilter> filters = default;
            Optional<SnapshotComposition> snapshotComposition = default;
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
                    status = new ConfigurationSnapshotStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("filters"))
                {
                    List<ConfigurationSettingsFilter> array = new List<ConfigurationSettingsFilter>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ConfigurationSettingsFilter.DeserializeKeyValueFilter(item));
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
                    snapshotComposition = new SnapshotComposition(property.Value.GetString());
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
            return new ConfigurationSnapshot(name.Value, Optional.ToNullable(status), filters, Optional.ToNullable(snapshotComposition), Optional.ToNullable(created), Optional.ToNullable(expires), Optional.ToNullable(retentionPeriod), Optional.ToNullable(size), Optional.ToNullable(itemsCount), Optional.ToDictionary(tags), new ETag(etag.Value));
        }

        // Mapping raw response to model
        internal static ConfigurationSnapshot FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeSnapshot(document.RootElement);
        }

        // Mapping model to raw request
        internal static RequestContent ToRequestContent(ConfigurationSnapshot snapshot)
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(snapshot);
            return content;
        }
    }
}
