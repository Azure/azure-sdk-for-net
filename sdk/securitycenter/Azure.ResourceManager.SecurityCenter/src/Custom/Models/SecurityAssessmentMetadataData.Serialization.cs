// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.SecurityCenter
{
    public partial class SecurityAssessmentMetadataData : IUtf8JsonSerializable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializePolicyDefinitionId(JsonProperty property, ref Optional<ResourceIdentifier> policyDefinitionId)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            if (string.IsNullOrEmpty(property.Value.GetString()))
            {
                return;
            }
            policyDefinitionId = new ResourceIdentifier(property.Value.GetString());
        }
    }
}
