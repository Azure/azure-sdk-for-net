// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.CommonProperties.Models;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CommonProperties
{
    // TODO: Remove this workaround when the common-properties spec adopts ARM common types v5.
    // Common types v3 projects id as string, while TrackedResourceData requires ResourceIdentifier.
    [CodeGenSuppress("ManagedIdentityTrackedResourceData", typeof(string), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(ManagedIdentityTrackedResourceProperties), typeof(ManagedServiceIdentity), typeof(IDictionary<string, BinaryData>))]
    public partial class ManagedIdentityTrackedResourceData
    {
        internal ManagedIdentityTrackedResourceData(string id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ManagedIdentityTrackedResourceProperties properties, ManagedServiceIdentity identity, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(id is null ? null : new ResourceIdentifier(id), name, resourceType, systemData, tags, location)
        {
            Properties = properties;
            Identity = identity;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }
    }
}
