// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Dynatrace.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Dynatrace
{
    public partial class DynatraceMonitorData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Identity))
            {
                writer.WritePropertyName("identity");
                var serializeOptions = new JsonSerializerOptions { Converters = { new DynatraceManagedServiceIdentityTypeConverter() } };
                JsonSerializer.Serialize(writer, Identity, serializeOptions);
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
            writer.WritePropertyName("location");
            writer.WriteStringValue(Location);
            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            if (Optional.IsDefined(MonitoringStatus))
            {
                writer.WritePropertyName("monitoringStatus");
                writer.WriteStringValue(MonitoringStatus.Value.ToString());
            }
            if (Optional.IsDefined(MarketplaceSubscriptionStatus))
            {
                writer.WritePropertyName("marketplaceSubscriptionStatus");
                writer.WriteStringValue(MarketplaceSubscriptionStatus.Value.ToString());
            }
            if (Optional.IsDefined(DynatraceEnvironmentProperties))
            {
                writer.WritePropertyName("dynatraceEnvironmentProperties");
                writer.WriteObjectValue(DynatraceEnvironmentProperties);
            }
            if (Optional.IsDefined(UserInfo))
            {
                writer.WritePropertyName("userInfo");
                writer.WriteObjectValue(UserInfo);
            }
            if (Optional.IsDefined(PlanData))
            {
                writer.WritePropertyName("planData");
                writer.WriteObjectValue(PlanData);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static DynatraceMonitorData DeserializeDynatraceMonitorData(JsonElement element)
        {
            Optional<ManagedServiceIdentity> identity = default;
            Optional<IDictionary<string, string>> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<ResourceManager.Models.SystemData> systemData = default;
            Optional<DynatraceMonitoringStatus> monitoringStatus = default;
            Optional<DynatraceMonitorMarketplaceSubscriptionStatus> marketplaceSubscriptionStatus = default;
            Optional<DynatraceEnvironmentProperties> dynatraceEnvironmentProperties = default;
            Optional<DynatraceMonitorUserInfo> userInfo = default;
            Optional<DynatraceBillingPlanInfo> planData = default;
            Optional<LiftrResourceCategory> liftrResourceCategory = default;
            Optional<int> liftrResourcePreference = default;
            Optional<DynatraceProvisioningState> provisioningState = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("identity"))
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
                if (property.NameEquals("location"))
                {
                    location = new AzureLocation(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<ResourceManager.Models.SystemData>(property.Value.ToString());
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("monitoringStatus"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            monitoringStatus = new DynatraceMonitoringStatus(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("marketplaceSubscriptionStatus"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            marketplaceSubscriptionStatus = new DynatraceMonitorMarketplaceSubscriptionStatus(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("dynatraceEnvironmentProperties"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            dynatraceEnvironmentProperties = DynatraceEnvironmentProperties.DeserializeDynatraceEnvironmentProperties(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("userInfo"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            userInfo = DynatraceMonitorUserInfo.DeserializeDynatraceMonitorUserInfo(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("planData"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            planData = DynatraceBillingPlanInfo.DeserializeDynatraceBillingPlanInfo(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("liftrResourceCategory"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            liftrResourceCategory = new LiftrResourceCategory(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("liftrResourcePreference"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            liftrResourcePreference = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"))
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
            }
            return new DynatraceMonitorData(id, name, type, systemData.Value, Optional.ToDictionary(tags), location, identity, Optional.ToNullable(monitoringStatus), Optional.ToNullable(marketplaceSubscriptionStatus), dynatraceEnvironmentProperties.Value, userInfo.Value, planData.Value, Optional.ToNullable(liftrResourceCategory), Optional.ToNullable(liftrResourcePreference), Optional.ToNullable(provisioningState));
        }
    }
}
