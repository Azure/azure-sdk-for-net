// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppSubscriptionQuotaItem : IUtf8JsonSerializable, IJsonModel<NetAppSubscriptionQuotaItem>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<NetAppSubscriptionQuotaItem>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<NetAppSubscriptionQuotaItem>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <summary> Writes this model as JSON. </summary>
        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The model serialization options. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (Id != null)
            {
                writer.WriteString("id", Id.ToString());
            }
            if (Name != null)
            {
                writer.WriteString("name", Name);
            }
            if (ResourceType != default)
            {
                writer.WriteString("type", ResourceType.ToString());
            }
            if (SystemData != null)
            {
                writer.WritePropertyName("systemData");
                writer.WriteRawValue(ModelReaderWriter.Write(SystemData, options, AzureResourceManagerNetAppContext.Default));
            }

            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            if (Current.HasValue)
            {
                writer.WriteNumber("current", Current.Value);
            }
            if (Default.HasValue)
            {
                writer.WriteNumber("default", Default.Value);
            }
            if (Usage.HasValue)
            {
                writer.WriteNumber("usage", Usage.Value);
            }
            writer.WriteEndObject();
        }

        NetAppSubscriptionQuotaItem IJsonModel<NetAppSubscriptionQuotaItem>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNetAppSubscriptionQuotaItem(document.RootElement, options);
        }

        internal static NetAppSubscriptionQuotaItem DeserializeNetAppSubscriptionQuotaItem(JsonElement element, ModelReaderWriterOptions options = null)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            ResourceIdentifier id = default;
            string name = default;
            ResourceType resourceType = default;
            Azure.ResourceManager.Models.SystemData systemData = default;
            int? current = default;
            int? @default = default;
            int? usage = default;

            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    resourceType = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8) && property.Value.ValueKind != JsonValueKind.Null)
                {
                    systemData = ModelReaderWriter.Read<Azure.ResourceManager.Models.SystemData>(BinaryData.FromString(property.Value.GetRawText()), options ?? ModelSerializationExtensions.WireOptions, AzureResourceManagerNetAppContext.Default);
                    continue;
                }
                if (property.NameEquals("properties"u8) && property.Value.ValueKind == JsonValueKind.Object)
                {
                    foreach (var nestedProperty in property.Value.EnumerateObject())
                    {
                        if (nestedProperty.NameEquals("current"u8) && nestedProperty.Value.ValueKind != JsonValueKind.Null)
                        {
                            current = nestedProperty.Value.GetInt32();
                            continue;
                        }
                        if (nestedProperty.NameEquals("default"u8) && nestedProperty.Value.ValueKind != JsonValueKind.Null)
                        {
                            @default = nestedProperty.Value.GetInt32();
                            continue;
                        }
                        if (nestedProperty.NameEquals("usage"u8) && nestedProperty.Value.ValueKind != JsonValueKind.Null)
                        {
                            usage = nestedProperty.Value.GetInt32();
                            continue;
                        }
                    }
                }
            }

            return new NetAppSubscriptionQuotaItem(id, name, resourceType, systemData, current, @default, usage);
        }

        BinaryData IPersistableModel<NetAppSubscriptionQuotaItem>.Write(ModelReaderWriterOptions options)
            => ModelReaderWriter.Write(this, options, AzureResourceManagerNetAppContext.Default);

        NetAppSubscriptionQuotaItem IPersistableModel<NetAppSubscriptionQuotaItem>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeNetAppSubscriptionQuotaItem(document.RootElement, options);
        }

        string IPersistableModel<NetAppSubscriptionQuotaItem>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
