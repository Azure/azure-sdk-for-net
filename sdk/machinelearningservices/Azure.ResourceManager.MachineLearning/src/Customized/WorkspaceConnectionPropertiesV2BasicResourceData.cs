// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: preserve ArmResource identity fields for the custom base model without spec-side hierarchy building.
    [CodeGenType("WorkspaceConnectionPropertiesV2BasicResourceData")]
    public partial class MachineLearningWorkspaceConnectionData : ResourceData
    {
        internal MachineLearningWorkspaceConnectionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, BinaryData> additionalBinaryDataProperties, Models.MachineLearningWorkspaceConnectionProperties properties)
        {
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
            Properties = properties;
        }
    }
}
