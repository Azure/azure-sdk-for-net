// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Billing.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Billing
{
    public partial class BillingReservationData : IUtf8JsonSerializable, IJsonModel<BillingReservationData>
    {
        internal static BillingReservationData DeserializeBillingReservationData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int? etag = default;
            ReservationSkuProperty sku = default;
            IDictionary<string, string> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Azure.ResourceManager.Models.SystemData systemData = default;
            string reservedResourceType = default;
            InstanceFlexibility? instanceFlexibility = default;
            string displayName = default;
            IList<string> appliedScopes = default;
            string appliedScopeType = default;
            bool? archived = default;
            string capabilities = default;
            float? quantity = default;
            string provisioningState = default;
            DateTimeOffset? effectiveDateTime = default;
            DateTimeOffset? benefitStartTime = default;
            DateTimeOffset? lastUpdatedDateTime = default;
            DateTimeOffset? expiryDate = default;
            DateTimeOffset? expiryDateTime = default;
            DateTimeOffset? reviewDateTime = default;
            string skuDescription = default;
            ReservationExtendedStatusInfo extendedStatusInfo = default;
            ReservationBillingPlan? billingPlan = default;
            string displayProvisioningState = default;
            string provisioningSubState = default;
            DateTimeOffset? purchaseDate = default;
            DateTimeOffset? purchaseDateTime = default;
            ReservationSplitProperties splitProperties = default;
            ReservationMergeProperties mergeProperties = default;
            ReservationSwapProperties swapProperties = default;
            ReservationAppliedScopeProperties appliedScopeProperties = default;
            string billingScopeId = default;
            bool? renew = default;
            string renewSource = default;
            string renewDestination = default;
            ReservationRenewProperties renewProperties = default;
            string term = default;
            string userFriendlyAppliedScopeType = default;
            string userFriendlyRenewState = default;
            string productCode = default;
            string trend = default;
            IList<ReservationUtilizationAggregates> aggregates = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("etag"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    etag = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("sku"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    sku = ReservationSkuProperty.DeserializeReservationSkuProperty(property.Value, options);
                    continue;
                }
                if (property.NameEquals("tags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
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
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<Azure.ResourceManager.Models.SystemData>(property.Value.GetRawText());
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
                        if (property0.NameEquals("reservedResourceType"u8))
                        {
                            reservedResourceType = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("instanceFlexibility"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            int numericValue = property0.Value.GetInt32();
                            instanceFlexibility = numericValue switch
                            {
                                1 => "On",
                                2 => "Off",
                                _ => throw new InvalidOperationException($"Unexpected value for instanceFlexibility: {numericValue}")
                            };
                            continue;
                        }
                        if (property0.NameEquals("displayName"u8))
                        {
                            displayName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("appliedScopes"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<string> array = new List<string>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(item.GetString());
                            }
                            appliedScopes = array;
                            continue;
                        }
                        if (property0.NameEquals("appliedScopeType"u8))
                        {
                            appliedScopeType = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("archived"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            archived = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("capabilities"u8))
                        {
                            capabilities = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("quantity"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            quantity = property0.Value.GetSingle();
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            provisioningState = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("effectiveDateTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            effectiveDateTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("benefitStartTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            benefitStartTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("lastUpdatedDateTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            lastUpdatedDateTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("expiryDate"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            expiryDate = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("expiryDateTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            expiryDateTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("reviewDateTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            reviewDateTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("skuDescription"u8))
                        {
                            skuDescription = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("extendedStatusInfo"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            extendedStatusInfo = ReservationExtendedStatusInfo.DeserializeReservationExtendedStatusInfo(property0.Value, options);
                            continue;
                        }
                        if (property0.NameEquals("billingPlan"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            billingPlan = new ReservationBillingPlan(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("displayProvisioningState"u8))
                        {
                            displayProvisioningState = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("provisioningSubState"u8))
                        {
                            provisioningSubState = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("purchaseDate"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            purchaseDate = property0.Value.GetDateTimeOffset("D");
                            continue;
                        }
                        if (property0.NameEquals("purchaseDateTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            purchaseDateTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("splitProperties"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            splitProperties = ReservationSplitProperties.DeserializeReservationSplitProperties(property0.Value, options);
                            continue;
                        }
                        if (property0.NameEquals("mergeProperties"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            mergeProperties = ReservationMergeProperties.DeserializeReservationMergeProperties(property0.Value, options);
                            continue;
                        }
                        if (property0.NameEquals("swapProperties"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            swapProperties = ReservationSwapProperties.DeserializeReservationSwapProperties(property0.Value, options);
                            continue;
                        }
                        if (property0.NameEquals("appliedScopeProperties"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            appliedScopeProperties = ReservationAppliedScopeProperties.DeserializeReservationAppliedScopeProperties(property0.Value, options);
                            continue;
                        }
                        if (property0.NameEquals("billingScopeId"u8))
                        {
                            billingScopeId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("renew"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            renew = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("renewSource"u8))
                        {
                            renewSource = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("renewDestination"u8))
                        {
                            renewDestination = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("renewProperties"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            renewProperties = ReservationRenewProperties.DeserializeReservationRenewProperties(property0.Value, options);
                            continue;
                        }
                        if (property0.NameEquals("term"u8))
                        {
                            term = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("userFriendlyAppliedScopeType"u8))
                        {
                            userFriendlyAppliedScopeType = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("userFriendlyRenewState"u8))
                        {
                            userFriendlyRenewState = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("productCode"u8))
                        {
                            productCode = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("utilization"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            foreach (var property1 in property0.Value.EnumerateObject())
                            {
                                if (property1.NameEquals("trend"u8))
                                {
                                    trend = property1.Value.GetString();
                                    continue;
                                }
                                if (property1.NameEquals("aggregates"u8))
                                {
                                    if (property1.Value.ValueKind == JsonValueKind.Null)
                                    {
                                        continue;
                                    }
                                    List<ReservationUtilizationAggregates> array = new List<ReservationUtilizationAggregates>();
                                    foreach (var item in property1.Value.EnumerateArray())
                                    {
                                        array.Add(ReservationUtilizationAggregates.DeserializeReservationUtilizationAggregates(item, options));
                                    }
                                    aggregates = array;
                                    continue;
                                }
                            }
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new BillingReservationData(
                id,
                name,
                type,
                systemData,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                location,
                etag,
                sku,
                reservedResourceType,
                instanceFlexibility,
                displayName,
                appliedScopes ?? new ChangeTrackingList<string>(),
                appliedScopeType,
                archived,
                capabilities,
                quantity,
                provisioningState,
                effectiveDateTime,
                benefitStartTime,
                lastUpdatedDateTime,
                expiryDate,
                expiryDateTime,
                reviewDateTime,
                skuDescription,
                extendedStatusInfo,
                billingPlan,
                displayProvisioningState,
                provisioningSubState,
                purchaseDate,
                purchaseDateTime,
                splitProperties,
                mergeProperties,
                swapProperties,
                appliedScopeProperties,
                billingScopeId,
                renew,
                renewSource,
                renewDestination,
                renewProperties,
                term,
                userFriendlyAppliedScopeType,
                userFriendlyRenewState,
                productCode,
                trend,
                aggregates ?? new ChangeTrackingList<ReservationUtilizationAggregates>(),
                serializedAdditionalRawData);
        }
    }
}
