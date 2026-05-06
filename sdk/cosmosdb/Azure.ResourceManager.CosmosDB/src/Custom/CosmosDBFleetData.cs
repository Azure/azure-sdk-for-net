// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.CosmosDB.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB
{
    // Baseline (AutoRest) shipped ProvisioningState as { get; set; }. The TypeSpec spec
    // marks it @visibility(Lifecycle.Read) so MPG generates it as get-only. Re-declare
    // here with a setter that flows through the inner Properties to preserve the
    // legacy SDK surface.
    [CodeGenSuppress("Properties")]
    [CodeGenSuppress("ProvisioningState")]
    public partial class CosmosDBFleetData
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
