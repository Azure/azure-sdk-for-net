// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.CosmosDB.Models
{
    // Restore { get; set; } for ProvisioningState (baseline AutoRest surface). The generator no
    // longer emits ProvisioningState on this wrapper (spec marks it as Lifecycle.Read so the
    // implicit-flatten skips it on an input wrapper), so no [CodeGenSuppress] is needed — we
    // are adding a member, not replacing one.
    public partial class CosmosDBFleetspacePatch
    {
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
