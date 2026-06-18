// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ServiceEndpointPolicyDefinitionData type. </summary>
    [CodeGenSuppress("ServiceResources")]
    public partial class ServiceEndpointPolicyDefinitionData
    {
        /// <summary> Gets or sets the ServiceResources compatibility property. </summary>
        public IList<ResourceIdentifier> ServiceResources { get; } = new ChangeTrackingList<ResourceIdentifier>();
    }
}
