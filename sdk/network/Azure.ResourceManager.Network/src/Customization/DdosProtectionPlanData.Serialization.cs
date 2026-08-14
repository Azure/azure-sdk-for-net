// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> A DDoS protection plan in a resource group. </summary>
    [CodeGenSuppress("DdosProtectionPlanData", typeof(DdosProtectionPlanPropertiesFormat), typeof(string), typeof(ETag?), typeof(IDictionary<string, BinaryData>))]
    [CodeGenSuppress("JsonModelWriteCore", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
    [CodeGenSuppress("DeserializeDdosProtectionPlanData", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class DdosProtectionPlanData
    {
        // The migration customizes this model to inherit TrackedResourceData, but the current generator
        // still emits serialization against the service-defined base shape. Preserve inherited ARM fields
        // from the raw payload until the generator custom-base serialization fix is available.
        // TODO: Remove this SDK-side workaround after adopting the generator custom-base serialization fix.
        internal DdosProtectionPlanData(DdosProtectionPlanPropertiesFormat properties, string name, ETag? eTag, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(NetworkResourceDataSerializationCompatibility.GetId(additionalBinaryDataProperties), name ?? NetworkResourceDataSerializationCompatibility.GetName(additionalBinaryDataProperties), NetworkResourceDataSerializationCompatibility.GetResourceType(additionalBinaryDataProperties), NetworkResourceDataSerializationCompatibility.GetSystemData(additionalBinaryDataProperties), NetworkResourceDataSerializationCompatibility.GetTags(additionalBinaryDataProperties), NetworkResourceDataSerializationCompatibility.GetLocation(additionalBinaryDataProperties))
        {
            Properties = properties;
            Name = name ?? NetworkResourceDataSerializationCompatibility.GetName(additionalBinaryDataProperties);
            ETag = eTag;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        // The generated writer does not call TrackedResourceData.JsonModelWriteCore after the custom base
        // replacement, so request bodies miss inherited fields such as location.
        // TODO: Remove this SDK-side workaround after adopting the generator custom-base serialization fix.
        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<DdosProtectionPlanData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DdosProtectionPlanData)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(Properties))
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteObjectValue(Properties, options);
            }
            if (options.Format != "W" && Optional.IsDefined(ETag))
            {
                writer.WritePropertyName("etag"u8);
                writer.WriteStringValue(ETag.Value.ToString());
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
                {
                    if (NetworkResourceDataSerializationCompatibility.IsFrameworkResourceDataProperty(item.Key))
                    {
                        continue;
                    }
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

        // The generated deserializer ignores inherited ARM fields in wire format; keep them in the raw
        // metadata bag so the custom constructor can initialize TrackedResourceData.
        // TODO: Remove this SDK-side workaround after adopting the generator custom-base serialization fix.
        internal static DdosProtectionPlanData DeserializeDdosProtectionPlanData(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            DdosProtectionPlanPropertiesFormat properties = default;
            string name = default;
            ETag? eTag = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = NetworkResourceDataSerializationCompatibility.CreateAdditionalData(element, options, prop =>
            {
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    return true;
                }
                if (prop.NameEquals("properties"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        properties = DdosProtectionPlanPropertiesFormat.DeserializeDdosProtectionPlanPropertiesFormat(prop.Value, options);
                    }
                    return true;
                }
                if (prop.NameEquals("etag"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        eTag = new ETag(prop.Value.GetString());
                    }
                    return true;
                }
                return false;
            });
            return new DdosProtectionPlanData(properties, name, eTag, additionalBinaryDataProperties);
        }
    }
}
