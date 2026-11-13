// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The service can return an empty string for policyDefinitionId; keep ResourceIdentifier deserialization tolerant while preserving the generated wire name and public type.
    [CodeGenSerialization(nameof(PolicyDefinitionId), DeserializationValueHook = nameof(DeserializePolicyDefinitionId))]
    public partial class SecurityAssessmentMetadataProperties
    {
        private static void DeserializePolicyDefinitionId(JsonProperty property, ref ResourceIdentifier policyDefinitionId)
        {
            if (property.Value.ValueKind != JsonValueKind.Null && !string.IsNullOrEmpty(property.Value.GetString()))
            {
                policyDefinitionId = new ResourceIdentifier(property.Value.GetString());
            }
        }
    }
}
