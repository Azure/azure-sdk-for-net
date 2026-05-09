// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.AlertProcessingRules.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AlertProcessingRules
{
    // The TypeSpec spec uses common-types v3 where Resource.id is typed as `string`.
    // The C# mgmt generator therefore emits an internal ctor with `string id`, but the
    // TrackedResourceData base class requires `ResourceIdentifier`, causing a build error.
    // Suppress the generated ctor and provide a replacement that constructs a
    // ResourceIdentifier from the string id before forwarding to the base ctor.
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress(
        "AlertProcessingRuleData",
        typeof(string),
        typeof(string),
        typeof(ResourceType),
        typeof(SystemData),
        typeof(IDictionary<string, BinaryData>),
        typeof(IDictionary<string, string>),
        typeof(AzureLocation),
        typeof(AlertProcessingRuleProperties))]
    public partial class AlertProcessingRuleData
    {
        internal AlertProcessingRuleData(
            string id,
            string name,
            ResourceType resourceType,
            SystemData systemData,
            IDictionary<string, BinaryData> additionalBinaryDataProperties,
            IDictionary<string, string> tags,
            AzureLocation location,
            AlertProcessingRuleProperties properties)
            : base(id is null ? null : new ResourceIdentifier(id), name, resourceType, systemData, tags, location)
        {
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
            Properties = properties;
        }
    }
}
