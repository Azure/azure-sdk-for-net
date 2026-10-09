// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.ResourceHealth
{
    // The service's properties.dependsOn list is unrelated to ProvisionableResource.DependsOn,
    // which controls Bicep deployment ordering. Rename only the flattened provisioning member
    // to avoid hiding the inherited property. A shared TypeSpec rename would also change the
    // DependsOn API already shipped by Azure.ResourceManager.ResourceHealth 1.1.0.
    public partial class ResourceHealthMetadataEntity
    {
        /// <summary> Gets the list of keys on which this entity depends. </summary>
        [CodeGenMember("DependsOn")]
        public BicepList<string> MetadataDependencies => Properties.DependsOn;
    }
}
