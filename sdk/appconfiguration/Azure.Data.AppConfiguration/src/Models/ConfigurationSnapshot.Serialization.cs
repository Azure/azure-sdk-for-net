// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Data.AppConfiguration
{
    // CUSTOM:
    // - Suppress serialization methods for MRW. These are implemented manually.
    [CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.ConfigurationSnapshot>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
    [CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.ConfigurationSnapshot>.Create", typeof(Utf8JsonReader), typeof(ModelReaderWriterOptions))]
    public partial class ConfigurationSnapshot : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("filters");
            writer.WriteStartArray();
            foreach (var item in Filters)
            {
                Utf8JsonWriterExtensions.WriteObjectValue(writer, item);
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
            Utf8JsonWriterExtensions.WriteObjectValue(content.JsonWriter, snapshot);
            return content;
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
            ((IUtf8JsonSerializable)this).Write(writer);
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
