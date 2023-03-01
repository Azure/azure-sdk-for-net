// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.BillingBenefits.Models
{
    public partial class BillingBenefitsAppliedScopeProperties
    {
        internal static BillingBenefitsAppliedScopeProperties DeserializeBillingBenefitsAppliedScopeProperties(JsonElement element)
        {
            Optional<Guid> tenantId = default;
            Optional<ResourceIdentifier> managementGroupId = default;
            Optional<ResourceIdentifier> subscriptionId = default;
            Optional<ResourceIdentifier> resourceGroupId = default;
            Optional<string> displayName = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tenantId"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    tenantId = property.Value.GetGuid();
                    continue;
                }
                if (property.NameEquals("managementGroupId"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    var val = property.Value.GetString();
                    if (!string.IsNullOrEmpty(val))
                    {
                        managementGroupId = new ResourceIdentifier(val);
                    }
                    continue;
                }
                if (property.NameEquals("subscriptionId"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    var val = property.Value.GetString();
                    if (!string.IsNullOrEmpty(val))
                    {
                        subscriptionId = new ResourceIdentifier(val);
                    }
                    continue;
                }
                if (property.NameEquals("resourceGroupId"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    var val = property.Value.GetString();
                    if (!string.IsNullOrEmpty(val))
                    {
                        resourceGroupId = new ResourceIdentifier(val);
                    }
                    continue;
                }
                if (property.NameEquals("displayName"))
                {
                    displayName = property.Value.GetString();
                    continue;
                }
            }
            return new BillingBenefitsAppliedScopeProperties(Optional.ToNullable(tenantId), managementGroupId.Value, subscriptionId.Value, resourceGroupId.Value, displayName.Value);
        }
    }
}
