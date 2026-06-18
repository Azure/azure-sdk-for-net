// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the P2SConnectionConfiguration type. </summary>
    [CodeGenSuppress("ConfigurationPolicyGroupAssociations")]
    public partial class P2SConnectionConfiguration
    {
        /// <summary> Gets or sets the ConfigurationPolicyGroupAssociations compatibility property. </summary>
        public IReadOnlyList<WritableSubResource> ConfigurationPolicyGroupAssociations => Properties?.ConfigurationPolicyGroupAssociations as IReadOnlyList<WritableSubResource>;
    }
}
