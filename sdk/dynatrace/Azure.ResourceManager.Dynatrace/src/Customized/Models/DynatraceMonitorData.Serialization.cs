// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Dynatrace.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Dynatrace
{
    public partial class DynatraceMonitorData : IUtf8JsonSerializable, IJsonModel<DynatraceMonitorData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DynatraceMonitorData>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<DynatraceMonitorData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Identity))
            {
                writer.WritePropertyName("identity"u8);
                var serializeOptions = new JsonSerializerOptions { Converters = { new DynatraceManagedServiceIdentityTypeConverter() } };
                JsonSerializer.Serialize(writer, Identity, serializeOptions);
            }
            if (Optional.IsCollectionDefined(Tags))
            {
                writer.WritePropertyName("tags"u8);
                writer.WriteStartObject();
                foreach (var item in Tags)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WritePropertyName("location"u8);
            writer.WriteStringValue(Location);
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(MonitoringStatus))
            {
                writer.WritePropertyName("monitoringStatus"u8);
                writer.WriteStringValue(MonitoringStatus.Value.ToString());
            }
            if (Optional.IsDefined(MarketplaceSubscriptionStatus))
            {
                writer.WritePropertyName("marketplaceSubscriptionStatus"u8);
                writer.WriteStringValue(MarketplaceSubscriptionStatus.Value.ToString());
            }
            if (Optional.IsDefined(DynatraceEnvironmentProperties))
            {
                writer.WritePropertyName("dynatraceEnvironmentProperties"u8);
                writer.WriteObjectValue(DynatraceEnvironmentProperties);
            }
            if (Optional.IsDefined(UserInfo))
            {
                writer.WritePropertyName("userInfo"u8);
                writer.WriteObjectValue(UserInfo);
            }
            if (Optional.IsDefined(PlanData))
            {
                writer.WritePropertyName("planData"u8);
                writer.WriteObjectValue(PlanData);
            }
            writer.WriteEndObject();
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
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
            writer.WriteEndObject();
        }

        DynatraceMonitorData IJsonModel<DynatraceMonitorData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DynatraceMonitorData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DynatraceMonitorData)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDynatraceMonitorData(document.RootElement, options);
        }

        internal static DynatraceMonitorData DeserializeDynatraceMonitorData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ManagedServiceIdentity identity = default;
            IDictionary<string, string> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            ResourceManager.Models.SystemData systemData = default;
            DynatraceMonitoringStatus? monitoringStatus = default;
            DynatraceMonitorMarketplaceSubscriptionStatus? marketplaceSubscriptionStatus = default;
            DynatraceEnvironmentProperties dynatraceEnvironmentProperties = default;
            DynatraceMonitorUserInfo userInfo = default;
            DynatraceBillingPlanInfo planData = default;
            LiftrResourceCategory? liftrResourceCategory = default;
            int? liftrResourcePreference = default;
            DynatraceProvisioningState? provisioningState = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("identity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    var serializeOptions = new JsonSerializerOptions { Converters = { new DynatraceManagedServiceIdentityTypeConverter() } };
                    identity = JsonSerializer.Deserialize<ManagedServiceIdentity>(property.Value.ToString(), serializeOptions);
                    continue;
                }
                if (property.NameEquals("tags"u8))
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
                if (property.NameEquals("location"u8))
                {
                    location = new AzureLocation(property.Value.GetString());
                    continue;
                }
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
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<ResourceManager.Models.SystemData>(property.Value.ToString());
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("monitoringStatus"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            monitoringStatus = new DynatraceMonitoringStatus(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("marketplaceSubscriptionStatus"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            marketplaceSubscriptionStatus = new DynatraceMonitorMarketplaceSubscriptionStatus(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("dynatraceEnvironmentProperties"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            dynatraceEnvironmentProperties = DynatraceEnvironmentProperties.DeserializeDynatraceEnvironmentProperties(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("userInfo"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            userInfo = DynatraceMonitorUserInfo.DeserializeDynatraceMonitorUserInfo(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("planData"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            planData = DynatraceBillingPlanInfo.DeserializeDynatraceBillingPlanInfo(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("liftrResourceCategory"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            liftrResourceCategory = new LiftrResourceCategory(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("liftrResourcePreference"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            liftrResourcePreference = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            provisioningState = new DynatraceProvisioningState(property0.Value.GetString());
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new DynatraceMonitorData(
                id,
                name,
                type,
                systemData,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                location, identity,
                monitoringStatus,
                marketplaceSubscriptionStatus,
                dynatraceEnvironmentProperties,
                userInfo,
                planData,
                liftrResourceCategory,
                liftrResourcePreference,
                provisioningState,
                serializedAdditionalRawData);
        }
        BinaryData IPersistableModel<DynatraceMonitorData>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DynatraceMonitorData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerDynatraceContext.Default);
                default:
                    throw new FormatException($"The model {nameof(DynatraceMonitorData)} does not support '{options.Format}' format.");
            }
        }

        DynatraceMonitorData IPersistableModel<DynatraceMonitorData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DynatraceMonitorData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeDynatraceMonitorData(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DynatraceMonitorData)} does not support '{options.Format}' format.");
            }
        }
        string IPersistableModel<DynatraceMonitorData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
