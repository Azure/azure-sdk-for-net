// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.PolicyInsights.Models
{
    // Workaround for a generator bug: the auto-emitted DeserializeComponentEventDetails references
    // an undeclared local 'additionalProperties0' (the body declares 'additionalProperties').
    // This file suppresses the broken method and re-emits a corrected copy.
    // Remove this customization once the upstream generator bug is fixed.
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress(
        "DeserializeComponentEventDetails",
        typeof(JsonElement),
        typeof(ModelReaderWriterOptions))]
    public partial class ComponentEventDetails
    {
        internal static ComponentEventDetails DeserializeComponentEventDetails(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResourceIdentifier id = default;
            string name = default;
            ResourceType resourceType = default;
            SystemData systemData = default;
            DateTimeOffset? timestamp = default;
            Guid? tenantId = default;
            string principalOid = default;
            string policyDefinitionAction = default;
            ChangeTrackingDictionary<string, BinaryData> additionalProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("id"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    id = new ResourceIdentifier(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    resourceType = new ResourceType(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("systemData"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = ModelReaderWriter.Read<SystemData>(new BinaryData(Encoding.UTF8.GetBytes(prop.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerPolicyInsightsContext.Default);
                    continue;
                }
                if (prop.NameEquals("timestamp"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    timestamp = prop.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (prop.NameEquals("tenantId"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    tenantId = new Guid(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("principalOid"u8))
                {
                    principalOid = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("policyDefinitionAction"u8))
                {
                    policyDefinitionAction = prop.Value.GetString();
                    continue;
                }
                additionalProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
            return new ComponentEventDetails(
                id,
                name,
                resourceType,
                systemData,
                timestamp,
                tenantId,
                principalOid,
                policyDefinitionAction,
                new ReadOnlyDictionary<string, BinaryData>(additionalProperties));
        }
    }
}
