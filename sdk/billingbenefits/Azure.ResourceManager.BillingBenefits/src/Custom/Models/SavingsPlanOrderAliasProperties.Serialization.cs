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
    // The service may return empty strings ("") for these ResourceIdentifier properties.
    // The default generated deserializer only checks for null, not empty strings, so
    // new ResourceIdentifier("") would throw ArgumentException at runtime.
    // These hooks skip empty strings to match the old autorest-generated behavior.
    [CodeGenSerialization(nameof(SavingsPlanOrderId), DeserializationValueHook = nameof(ReadResourceId))]
    [CodeGenSerialization(nameof(BillingScopeId), DeserializationValueHook = nameof(ReadResourceId))]
    internal partial class SavingsPlanOrderAliasProperties : IJsonModel<SavingsPlanOrderAliasProperties>
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
