// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.EventGrid
{
    public partial class EventGridPrivateLinkResourceData
    {
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EventGridPrivateLinkResourceData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(EventGridPrivateLinkResourceData)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(GroupId))
            {
                writer.WritePropertyName("groupId"u8);
                writer.WriteStringValue(GroupId);
            }
            if (Optional.IsDefined(DisplayName))
            {
                writer.WritePropertyName("displayName"u8);
                writer.WriteStringValue(DisplayName);
            }
            if (Optional.IsCollectionDefined(RequiredMembers))
            {
                writer.WritePropertyName("requiredMembers"u8);
                writer.WriteStartArray();
                foreach (string item in RequiredMembers)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(RequiredZoneNames))
            {
                writer.WritePropertyName("requiredZoneNames"u8);
                writer.WriteStartArray();
                foreach (string item in RequiredZoneNames)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();

            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (KeyValuePair<string, BinaryData> item in _additionalBinaryDataProperties)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(item.Value);
#else
                    using JsonDocument document = JsonDocument.Parse(item.Value);
                    JsonSerializer.Serialize(writer, document.RootElement);
#endif
                }
            }
        }

        BinaryData IPersistableModel<EventGridPrivateLinkResourceData>.Write(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EventGridPrivateLinkResourceData>)this).GetFormatFromOptions(options) : options.Format;
            return format switch
            {
                "J" => ModelReaderWriter.Write(this, options, AzureResourceManagerEventGridContext.Default),
                _ => throw new FormatException($"The model {nameof(EventGridPrivateLinkResourceData)} does not support writing '{options.Format}' format.")
            };
        }

        EventGridPrivateLinkResourceData IPersistableModel<EventGridPrivateLinkResourceData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EventGridPrivateLinkResourceData>)this).GetFormatFromOptions(options) : options.Format;
            return format switch
            {
                "J" => DeserializeEventGridPrivateLinkResourceData(JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions).RootElement, options),
                _ => throw new FormatException($"The model {nameof(EventGridPrivateLinkResourceData)} does not support reading '{options.Format}' format.")
            };
        }

        string IPersistableModel<EventGridPrivateLinkResourceData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<EventGridPrivateLinkResourceData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        EventGridPrivateLinkResourceData IJsonModel<EventGridPrivateLinkResourceData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeEventGridPrivateLinkResourceData(document.RootElement, options);
        }

        internal static EventGridPrivateLinkResourceData FromResponse(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeEventGridPrivateLinkResourceData(document.RootElement, ModelSerializationExtensions.WireOptions);
        }

        internal static EventGridPrivateLinkResourceData FromGeneratedModel(global::Azure.ResourceManager.EventGrid.Models.EventGridPrivateLinkResource model)
        {
            if (model is null)
            {
                return null;
            }

            return new EventGridPrivateLinkResourceData(
                model.Id,
                model.Name,
                model.Type ?? default,
                default,
                model.GroupId,
                model.DisplayName,
                new List<string>(model.RequiredMembers ?? Array.Empty<string>()),
                new List<string>(model.RequiredZoneNames ?? Array.Empty<string>()));
        }

        internal static EventGridPrivateLinkResourceData DeserializeEventGridPrivateLinkResourceData(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            ResourceIdentifier id = default;
            string name = default;
            ResourceType resourceType = default;
            SystemData systemData = default;
            string groupId = default;
            string displayName = default;
            IReadOnlyList<string> requiredMembers = Array.Empty<string>();
            IReadOnlyList<string> requiredZoneNames = Array.Empty<string>();
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new Dictionary<string, BinaryData>();

            foreach (JsonProperty prop in element.EnumerateObject())
            {
                if (prop.NameEquals("id"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        id = new ResourceIdentifier(prop.Value.GetString());
                    }
                    continue;
                }
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        resourceType = new ResourceType(prop.Value.GetString());
                    }
                    continue;
                }
                if (prop.NameEquals("systemData"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        systemData = ModelReaderWriter.Read<SystemData>(new BinaryData(Encoding.UTF8.GetBytes(prop.Value.GetRawText())), options, AzureResourceManagerEventGridContext.Default);
                    }
                    continue;
                }
                if (prop.NameEquals("properties"u8))
                {
                    foreach (JsonProperty property in prop.Value.EnumerateObject())
                    {
                        if (property.NameEquals("groupId"u8))
                        {
                            groupId = property.Value.GetString();
                        }
                        else if (property.NameEquals("displayName"u8))
                        {
                            displayName = property.Value.GetString();
                        }
                        else if (property.NameEquals("requiredMembers"u8))
                        {
                            List<string> items = new List<string>();
                            foreach (JsonElement item in property.Value.EnumerateArray())
                            {
                                items.Add(item.GetString());
                            }
                            requiredMembers = items;
                        }
                        else if (property.NameEquals("requiredZoneNames"u8))
                        {
                            List<string> items = new List<string>();
                            foreach (JsonElement item in property.Value.EnumerateArray())
                            {
                                items.Add(item.GetString());
                            }
                            requiredZoneNames = items;
                        }
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }

            return new EventGridPrivateLinkResourceData(id, name, resourceType, systemData, groupId, displayName, requiredMembers, requiredZoneNames, additionalBinaryDataProperties);
        }
    }
}
