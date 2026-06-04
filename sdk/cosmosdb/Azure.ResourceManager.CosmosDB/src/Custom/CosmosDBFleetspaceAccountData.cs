// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.CosmosDB.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB
{
    // Restore { get; set; } for ProvisioningState (baseline AutoRest surface).
    [CodeGenSuppress("ProvisioningState")]
    public partial class CosmosDBFleetspaceAccountData
    {
        /// <summary> A provisioning state of the FleetspaceAccount. </summary>
        [WirePath("properties.provisioningState")]
        public CosmosDBStatus? ProvisioningState
        {
            get => Properties is null ? default : Properties.ProvisioningState;
            set => throw new NotSupportedException("ProvisioningState is read-only.");
        }
    }
}
