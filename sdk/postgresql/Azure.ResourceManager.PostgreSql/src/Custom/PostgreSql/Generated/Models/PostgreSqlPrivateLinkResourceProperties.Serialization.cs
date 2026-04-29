// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.ResourceManager.PostgreSql.FlexibleServers;

namespace Azure.ResourceManager.PostgreSql.Models
{
    /// <summary> Properties of a private link resource. </summary>
    public partial class PostgreSqlPrivateLinkResourceProperties : IJsonModel<PostgreSqlPrivateLinkResourceProperties>, IPersistableModel<PostgreSqlPrivateLinkResourceProperties>
    {
        private IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="PostgreSqlPrivateLinkResourceProperties"/>. </summary>
        internal PostgreSqlPrivateLinkResourceProperties(string groupId, IReadOnlyList<string> requiredMembers, IList<string> requiredZoneNames, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            GroupId = groupId;
            RequiredMembers = requiredMembers;
            RequiredZoneNames = requiredZoneNames;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Initializes a new instance of <see cref="PostgreSqlPrivateLinkResourceProperties"/> for deserialization. </summary>
        internal PostgreSqlPrivateLinkResourceProperties()
        {
        }

        /// <summary> The private link resource group id. </summary>
        [WirePath("groupId")]
        public string GroupId { get; }

        /// <summary> The private link resource required member names. </summary>
        [WirePath("requiredMembers")]
        public IReadOnlyList<string> RequiredMembers { get; }

        /// <summary> The private link resource required zone names. </summary>
        public IList<string> RequiredZoneNames { get; }

        void IJsonModel<PostgreSqlPrivateLinkResourceProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<PostgreSqlPrivateLinkResourceProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PostgreSqlPrivateLinkResourceProperties)} does not support writing '{format}' format.");
            }
            if (options.Format != "W" && Optional.IsDefined(GroupId))
            {
                writer.WritePropertyName("groupId"u8);
                writer.WriteStringValue(GroupId);
            }
            if (options.Format != "W" && Optional.IsCollectionDefined(RequiredMembers))
            {
                writer.WritePropertyName("requiredMembers"u8);
                writer.WriteStartArray();
                foreach (var item in RequiredMembers)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(RequiredZoneNames))
            {
                writer.WritePropertyName("requiredZoneNames"u8);
                writer.WriteStartArray();
                foreach (var item in RequiredZoneNames)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
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

        PostgreSqlPrivateLinkResourceProperties IJsonModel<PostgreSqlPrivateLinkResourceProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PostgreSqlPrivateLinkResourceProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PostgreSqlPrivateLinkResourceProperties)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePostgreSqlPrivateLinkResourceProperties(document.RootElement, options);
        }

        BinaryData IPersistableModel<PostgreSqlPrivateLinkResourceProperties>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PostgreSqlPrivateLinkResourceProperties>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerPostgreSqlContext.Default);
                default:
                    throw new FormatException($"The model {nameof(PostgreSqlPrivateLinkResourceProperties)} does not support writing '{options.Format}' format.");
            }
        }

        PostgreSqlPrivateLinkResourceProperties IPersistableModel<PostgreSqlPrivateLinkResourceProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PostgreSqlPrivateLinkResourceProperties>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializePostgreSqlPrivateLinkResourceProperties(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(PostgreSqlPrivateLinkResourceProperties)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<PostgreSqlPrivateLinkResourceProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static PostgreSqlPrivateLinkResourceProperties DeserializePostgreSqlPrivateLinkResourceProperties(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string groupId = default;
            IReadOnlyList<string> requiredMembers = default;
            IList<string> requiredZoneNames = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("groupId"u8))
                {
                    groupId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("requiredMembers"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    requiredMembers = array;
                    continue;
                }
                if (prop.NameEquals("requiredZoneNames"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    requiredZoneNames = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new PostgreSqlPrivateLinkResourceProperties(groupId, requiredMembers, requiredZoneNames ?? new ChangeTrackingList<string>(), additionalBinaryDataProperties);
        }
    }
}
