// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // Spec marks provisioningState as @visibility(Lifecycle.Read), so MPG generates
    // a get-only property. Baseline (AutoRest) shipped { get; set; }. Re-declare the
    // property here so the outer wrapper (CosmosDBFleetData) can write through.
    [CodeGenSuppress("ProvisioningState")]
    internal partial class FleetResourceProperties
    {
        /// <summary> A provisioning state of the Fleet. </summary>
        public CosmosDBStatus? ProvisioningState { get; set; }
    }
}
