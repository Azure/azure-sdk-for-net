// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.BillingBenefits.Models
{
    // The service may return empty strings ("") for these ResourceIdentifier properties
    // (e.g., subscriptionId="" when scope is ManagementGroup, resourceGroupId="" when scope is Single subscription).
    // The default generated deserializer only checks for null, not empty strings, so
    // new ResourceIdentifier("") would throw ArgumentException at runtime.
    // These hooks skip empty strings to match the old autorest-generated behavior.
    [CodeGenSerialization(nameof(ManagementGroupId), DeserializationValueHook = nameof(ReadResourceId))]
    [CodeGenSerialization(nameof(SubscriptionId), DeserializationValueHook = nameof(ReadResourceId))]
    [CodeGenSerialization(nameof(ResourceGroupId), DeserializationValueHook = nameof(ReadResourceId))]
    public partial class BillingBenefitsAppliedScopeProperties : IJsonModel<BillingBenefitsAppliedScopeProperties>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadResourceId(JsonProperty property, ref ResourceIdentifier id)
        {
            var value = property.Value.GetString();
            if (!string.IsNullOrEmpty(value))
            {
                id = new ResourceIdentifier(value);
            }
        }
    }
}
