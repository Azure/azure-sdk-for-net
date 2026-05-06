// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.CosmosDB.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB
{
    // Restore { get; set; } for ProvisioningState (baseline AutoRest surface).
    [CodeGenSuppress("Properties")]
    [CodeGenSuppress("ProvisioningState")]
    public partial class CosmosDBFleetspaceData
    {
        [WirePath("properties")]
        internal FleetspaceProperties Properties { get; set; }

        /// <summary> A provisioning state of the Fleetspace. </summary>
        [WirePath("properties.provisioningState")]
        public CosmosDBStatus? ProvisioningState
        {
            get => Properties is null ? default : Properties.ProvisioningState;
            set
            {
                Properties ??= new FleetspaceProperties();
                Properties.ProvisioningState = value;
            }
        }
    }
}
