// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CommonProperties
{
    // TODO: Remove this workaround when the common-properties spec adopts ARM common types v5.
    // Common types v3 projects id as string, while TrackedResourceData requires ResourceIdentifier.
    [CodeGenSuppress("ConfidentialResourceData", typeof(string), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(global::Azure.ResourceManager.CommonProperties.Models.ConfidentialResourceProperties), typeof(IDictionary<string, BinaryData>))]
    public partial class ConfidentialResourceData
    {
        internal ConfidentialResourceData(string id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, global::Azure.ResourceManager.CommonProperties.Models.ConfidentialResourceProperties properties, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(id is null ? null : new ResourceIdentifier(id), name, resourceType, systemData, tags, location)
        {
            Properties = properties;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }
    }
}
