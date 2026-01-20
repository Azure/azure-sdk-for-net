// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ServiceFabricManagedClusters.Models
{
    public partial class FaultSimulationDetails
    {
        /// <summary> List of node type simulations associated with the cluster fault simulation. </summary>
        public IReadOnlyList<NodeTypeFaultSimulation> NodeTypeFaultSimulation { get; }
    }
}
