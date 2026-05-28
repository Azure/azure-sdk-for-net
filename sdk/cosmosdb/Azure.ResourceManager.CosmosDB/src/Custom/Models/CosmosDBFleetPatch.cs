// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // Restore { get; set; } for ProvisioningState (baseline AutoRest surface). The wrapper
    // currently emits no flattened ProvisioningState proxy at all (FleetResourceProperties has
    // only a read-only `provisioningState`, and MPG skips emitting Properties + flatten proxies
    // for a wrapper whose only inner field is read-only). We therefore add `internal Properties`
    // (required by the auto-generated MRW serialization at .Serialization.cs line 88/91) plus a
    // user-facing `public ProvisioningState` proxy; no [CodeGenSuppress] is needed because the
    // generator does not emit either member on this class.
    public partial class CosmosDBFleetPatch
    {
        [WirePath("properties")]
        internal FleetResourceProperties Properties { get; set; }

        /// <summary> A provisioning state of the Fleet. </summary>
        [WirePath("properties.provisioningState")]
        public CosmosDBStatus? ProvisioningState
        {
            get => Properties is null ? default : Properties.ProvisioningState;
            set
            {
                Properties ??= new FleetResourceProperties();
                Properties.ProvisioningState = value;
            }
        }
    }
}
