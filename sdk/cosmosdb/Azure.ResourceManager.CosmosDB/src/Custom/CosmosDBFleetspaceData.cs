// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.CosmosDB.Models;

namespace Azure.ResourceManager.CosmosDB
{
    public partial class CosmosDBFleetspaceData
    {
        // Restore { get; set; } for ProvisioningState (baseline AutoRest surface).
        /// <summary> A provisioning state of the Fleetspace. </summary>
        [WirePath("properties.provisioningState")]
        public CosmosDBStatus? ProvisioningState
        {
            get => Properties is null ? default : Properties.ProvisioningState;
            set => throw new NotSupportedException("ProvisioningState is read-only.");
        }
    }
}
