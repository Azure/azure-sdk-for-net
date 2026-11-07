// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.ResourceManager.Monitor;

namespace Azure.ResourceManager.Monitor.Models
{
    internal partial class VMInsightsOnboardingStatusProperties
    {
        // The GA model allowed these values to be omitted, while the current spec marks them required.
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VMInsightsOnboardingStatusProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
                throw new FormatException($"The model {nameof(VMInsightsOnboardingStatusProperties)} does not support writing '{format}' format.");

            if (ResourceId != null)
                writer.WriteString("resourceId", ResourceId);
            if (OnboardingStatus.ToString() is string onboardingStatus)
                writer.WriteString("onboardingStatus", onboardingStatus);
            if (DataStatus.ToString() is string dataStatus)
                writer.WriteString("dataStatus", dataStatus);
            if (Optional.IsCollectionDefined(Data))
            {
                writer.WritePropertyName("data"u8);
                writer.WriteStartArray();
                foreach (DataContainer item in Data)
                    writer.WriteObjectValue(item, options);
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

        // The GA deserializer treated explicit nulls for these fields as absent.
        internal static VMInsightsOnboardingStatusProperties DeserializeVMInsightsOnboardingStatusProperties(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
                return null;

            string resourceId = default;
            OnboardingStatus onboardingStatus = default;
            DataStatus dataStatus = default;
            IList<DataContainer> data = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("resourceId"u8))
                {
                    resourceId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("onboardingStatus"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                        onboardingStatus = new OnboardingStatus(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("dataStatus"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                        dataStatus = new DataStatus(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("data"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        data = new List<DataContainer>();
                        foreach (var item in prop.Value.EnumerateArray())
                            data.Add(DataContainer.DeserializeDataContainer(item, options));
                    }
                    continue;
                }
                if (options.Format != "W")
                    additionalBinaryDataProperties.Add(prop.Name, prop.Value.GetUtf8Bytes());
            }
            return new VMInsightsOnboardingStatusProperties(resourceId, onboardingStatus, dataStatus, data ?? new ChangeTrackingList<DataContainer>(), additionalBinaryDataProperties);
        }
    }
}
