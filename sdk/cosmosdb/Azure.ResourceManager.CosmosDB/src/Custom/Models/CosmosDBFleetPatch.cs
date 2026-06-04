// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.CosmosDB.Models
{
    public partial class CosmosDBFleetPatch
    {
        /// <summary> A provisioning state of the Fleet. </summary>
        [WirePath("properties.provisioningState")]
        public CosmosDBStatus? ProvisioningState
        {
            get => default;
            set => throw new NotSupportedException("ProvisioningState is read-only.");
        }
    }
}
