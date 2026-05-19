// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using Azure.ResourceManager.HybridCompute;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridCompute.Models
{
    [CodeGenSuppress("EsuKey", typeof(string), typeof(int?), typeof(IDictionary<string, BinaryData>))]
    [CodeGenSuppress("LicenseStatus")]
    [CodeGenSuppress("JsonModelWriteCore", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
    [CodeGenSuppress("DeserializeEsuKey", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class EsuKey
    {
        internal EsuKey(string sku, string licenseStatus, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Sku = sku;
            LicenseStatus = licenseStatus;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> The current status of the license profile key. </summary>
        [WirePath("licenseStatus")]
        public string LicenseStatus { get; }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EsuKey>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(EsuKey)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(Sku))
            {
                writer.WritePropertyName("sku"u8);
                writer.WriteStringValue(Sku);
            }
            if (Optional.IsDefined(LicenseStatus))
            {
                writer.WritePropertyName("licenseStatus"u8);
                if (int.TryParse(LicenseStatus, NumberStyles.Integer, CultureInfo.InvariantCulture, out int licenseStatus))
                {
                    writer.WriteNumberValue(licenseStatus);
                }
                else
                {
                    writer.WriteStringValue(LicenseStatus);
                }
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

        internal static EsuKey DeserializeEsuKey(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string sku = default;
            string licenseStatus = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("sku"u8))
                {
                    sku = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("licenseStatus"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    licenseStatus = prop.Value.ValueKind == JsonValueKind.String ? prop.Value.GetString() : prop.Value.GetRawText();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new EsuKey(sku, licenseStatus, additionalBinaryDataProperties);
        }
    }
}
