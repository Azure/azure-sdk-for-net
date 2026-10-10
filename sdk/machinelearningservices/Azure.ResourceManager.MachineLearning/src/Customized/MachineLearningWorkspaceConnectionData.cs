// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.MachineLearning.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.MachineLearning
{
    public partial class MachineLearningWorkspaceConnectionData
    {
        // Customized: generated serialization constructs this resource data from a string id,
        // while the generated resource data constructor uses ResourceIdentifier.
        internal MachineLearningWorkspaceConnectionData(string id, string name, ResourceType resourceType, SystemData systemData, MachineLearningWorkspaceConnectionProperties properties, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : this(id is null ? null : new ResourceIdentifier(id), name, resourceType, systemData, properties, additionalBinaryDataProperties)
        {
        }
    }
}
