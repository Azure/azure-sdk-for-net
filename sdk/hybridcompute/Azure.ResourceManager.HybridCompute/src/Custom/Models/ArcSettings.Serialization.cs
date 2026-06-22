// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.HybridCompute.Models
{
    /// <summary> The ArcSettings. </summary>
    public partial class ArcSettings : IUtf8JsonSerializable, IJsonModel<ArcSettings>, IPersistableModel<ArcSettings>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ArcSettings>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<ArcSettings>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ArcSettings>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ArcSettings)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (options.Format != "W" && Optional.IsDefined(TenantId))
            {
                writer.WritePropertyName("tenantId"u8);
                writer.WriteStringValue(TenantId.Value);
            }
            writer.WritePropertyName("gatewayProperties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(GatewayResourceId))
            {
                writer.WritePropertyName("gatewayResourceId"u8);
                writer.WriteStringValue(GatewayResourceId);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        ArcSettings IJsonModel<ArcSettings>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => FromArcSettingsData(((IJsonModel<ArcSettingsData>)new ArcSettingsData()).Create(ref reader, options));

        BinaryData IPersistableModel<ArcSettings>.Write(ModelReaderWriterOptions options)
        {
            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            ((IJsonModel<ArcSettings>)this).Write(writer, options);
            writer.Flush();
            return BinaryData.FromBytes(stream.ToArray());
        }

        ArcSettings IPersistableModel<ArcSettings>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            return FromArcSettingsData(ArcSettingsData.DeserializeArcSettingsData(document.RootElement, options));
        }

        string IPersistableModel<ArcSettings>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        private static ArcSettingsData ToArcSettingsData(ArcSettings arcSettings)
        {
            string tenantId = arcSettings.TenantId?.ToString();
            SettingsGatewayProperties gatewayProperties = arcSettings.GatewayResourceId is null ? default : new SettingsGatewayProperties(arcSettings.GatewayResourceId, null);

            return new ArcSettingsData(
                arcSettings.Id,
                arcSettings.Name,
                arcSettings.ResourceType,
                arcSettings.SystemData,
                tenantId is null && gatewayProperties is null ? default : new SettingsProperties(tenantId, gatewayProperties, null),
                additionalBinaryDataProperties: null);
        }

        private static ArcSettings FromArcSettingsData(ArcSettingsData data)
        {
            if (data is null)
            {
                return null;
            }

            Guid? tenantId = Guid.TryParse(data.TenantId, out Guid parsedTenantId) ? parsedTenantId : default(Guid?);
            return new ArcSettings(data.Id, data.Name, data.ResourceType, data.SystemData, tenantId, data.GatewayResourceId, serializedAdditionalRawData: null);
        }
    }
}
