// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.CosmosDB.Models
{
    public partial class CosmosDBFleetspacePatch
    {
        /// <summary> A provisioning state of the Fleetspace. </summary>
        [WirePath("properties.provisioningState")]
        public CosmosDBStatus? ProvisioningState
        {
            get => Properties is null ? default : Properties.ProvisioningState;
            set => throw new NotSupportedException("ProvisioningState is read-only.");
        }
    }
}
