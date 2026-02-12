// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.GuestConfiguration.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.GuestConfiguration.Models
{
    /// <summary> Guest configuration is an Azure resource putting guest configuration assignments on the machine. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class GuestConfigurationResourceData : IJsonModel<GuestConfigurationResourceData>, IPersistableModel<GuestConfigurationResourceData>
    {
        /// <summary> Initializes a new instance of <see cref="GuestConfigurationResourceData"/>. </summary>
        public GuestConfigurationResourceData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="GuestConfigurationResourceData"/>. </summary>
        internal GuestConfigurationResourceData(ResourceIdentifier id, string name, AzureLocation? location, ResourceType? resourceType, SystemData systemData)
        {
            Id = id;
            Name = name;
            Location = location;
            ResourceType = resourceType;
            SystemData = systemData;
        }

        /// <summary> ARM resource id of the guest configuration assignment. </summary>
        [WirePath("id")]
        public ResourceIdentifier Id { get; }
        /// <summary> Name of the guest configuration assignment. </summary>
        [WirePath("name")]
        public string Name { get; set; }
        /// <summary> Region where the VM is located. </summary>
        [WirePath("location")]
        public AzureLocation? Location { get; set; }
        /// <summary> The type of the resource. </summary>
        [WirePath("type")]
        public ResourceType? ResourceType { get; }
        /// <summary> Azure Resource Manager metadata containing createdBy and modifiedBy information. </summary>
        [WirePath("systemData")]
        public SystemData SystemData { get; }

        void IJsonModel<GuestConfigurationResourceData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<GuestConfigurationResourceData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(GuestConfigurationResourceData)} does not support writing '{format}' format.");
            }
            if (Id != null)
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (Name != null)
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Location != null)
            {
                writer.WritePropertyName("location"u8);
                writer.WriteStringValue(Location.Value.Name);
            }
            if (ResourceType != null)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(ResourceType.Value.ToString());
            }
            if (SystemData != null)
            {
                writer.WritePropertyName("systemData"u8);
                writer.WriteRawValue(ModelReaderWriter.Write(SystemData, ModelSerializationExtensions.WireOptions, AzureResourceManagerGuestConfigurationContext.Default));
            }
        }

        GuestConfigurationResourceData IJsonModel<GuestConfigurationResourceData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<GuestConfigurationResourceData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(GuestConfigurationResourceData)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeGuestConfigurationResourceData(document.RootElement);
        }

        BinaryData IPersistableModel<GuestConfigurationResourceData>.Write(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<GuestConfigurationResourceData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(GuestConfigurationResourceData)} does not support writing '{format}' format.");
            }
            using var stream = new System.IO.MemoryStream();
            using var writer = new Utf8JsonWriter(stream);
            ((IJsonModel<GuestConfigurationResourceData>)this).Write(writer, options);
            writer.Flush();
            return new BinaryData(stream.ToArray());
        }

        GuestConfigurationResourceData IPersistableModel<GuestConfigurationResourceData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<GuestConfigurationResourceData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(GuestConfigurationResourceData)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeGuestConfigurationResourceData(document.RootElement);
        }

        string IPersistableModel<GuestConfigurationResourceData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static GuestConfigurationResourceData DeserializeGuestConfigurationResourceData(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResourceIdentifier id = default;
            string name = default;
            AzureLocation? location = default;
            ResourceType? resourceType = default;
            SystemData systemData = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        id = new ResourceIdentifier(property.Value.GetString());
                    }
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("location"u8))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        location = new AzureLocation(property.Value.GetString());
                    }
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        resourceType = new ResourceType(property.Value.GetString());
                    }
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        systemData = ModelReaderWriter.Read<SystemData>(new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerGuestConfigurationContext.Default);
                    }
                    continue;
                }
            }
            return new GuestConfigurationResourceData(id, name, location, resourceType, systemData);
        }
    }
}
