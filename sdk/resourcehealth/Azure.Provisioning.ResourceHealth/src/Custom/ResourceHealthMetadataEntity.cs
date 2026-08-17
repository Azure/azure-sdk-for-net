// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.ResourceHealth
{
    public partial class ResourceHealthMetadataEntity
    {
        /// <summary> Gets the list of keys on which this entity depends. </summary>
        [CodeGenMember("DependsOn")]
        public BicepList<string> MetadataDependencies => Properties.DependsOn;
    }
}
