// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
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
            JsonModelWriteCore(writer, ModelSerializationExtensions.WireOptions);
            writer.WriteEndObject();
        }

        internal static ConfigurationSnapshot DeserializeSnapshot(JsonElement element)
        {
            string name = default;
            ConfigurationSnapshotStatus status = default;
            IList<ConfigurationSettingsFilter> filters = default;
            SnapshotComposition? snapshotComposition = default;
            DateTimeOffset? created = default;
            DateTimeOffset? expires = default;
            long? retentionPeriod = default;
            long? size = default;
            long? itemsCount = default;
            IDictionary<string, string> tags = default;
            string etag = default;
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
                        array.Add(ConfigurationSettingsFilter.DeserializeConfigurationSettingsFilter(item, ModelSerializationExtensions.WireOptions));
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
            return new ConfigurationSnapshot(
                name,
                status,
                filters,
                snapshotComposition,
                created,
                expires,
                retentionPeriod,
                size,
                itemsCount,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                new ETag(etag));
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ConfigurationSnapshot>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ConfigurationSnapshot)} does not support writing '{format}' format.");
            }
            if (options.Format != "W")
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (options.Format != "W" && Optional.IsDefined(Status))
            {
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(Status.Value.ToString());
            }
            writer.WritePropertyName("filters"u8);
            writer.WriteStartArray();
            foreach (ConfigurationSettingsFilter item in Filters)
            {
                writer.WriteObjectValue(item, options);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(SnapshotComposition))
            {
                writer.WritePropertyName("composition_type"u8);
                writer.WriteStringValue(SnapshotComposition.Value.ToString());
            }
            if (options.Format != "W" && Optional.IsDefined(CreatedOn))
            {
                writer.WritePropertyName("created"u8);
                writer.WriteStringValue(CreatedOn.Value, "O");
            }
            if (options.Format != "W" && Optional.IsDefined(ExpiresOn))
            {
                writer.WritePropertyName("expires"u8);
                writer.WriteStringValue(ExpiresOn.Value, "O");
            }
            if (Optional.IsDefined(RetentionPeriod))
            {
                writer.WritePropertyName("retention_period"u8);
                writer.WriteNumberValue(RetentionPeriod.Value.TotalSeconds);
            }
            if (options.Format != "W" && Optional.IsDefined(SizeInBytes))
            {
                writer.WritePropertyName("size"u8);
                writer.WriteNumberValue(SizeInBytes.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(ItemCount))
            {
                writer.WritePropertyName("items_count"u8);
                writer.WriteNumberValue(ItemCount.Value);
            }
            if (Optional.IsCollectionDefined(Tags))
            {
                writer.WritePropertyName("tags"u8);
                writer.WriteStartObject();
                foreach (var item in Tags)
                {
                    writer.WritePropertyName(item.Key);
                    if (item.Value == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (options.Format != "W" && Optional.IsDefined(ETag))
            {
                writer.WritePropertyName("etag"u8);
                writer.WriteObjectValue(ETag, options);
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        internal static ConfigurationSnapshot DeserializeConfigurationSnapshot(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return DeserializeSnapshot(element);
        }
    }
}
