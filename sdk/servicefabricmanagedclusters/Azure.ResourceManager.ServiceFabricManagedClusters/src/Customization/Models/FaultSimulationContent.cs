// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Models
{
    /// <summary>
    /// Parameters for Fault Simulation action.
    /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="ZoneFaultSimulationContent"/>.
    /// </summary>
    public abstract partial class FaultSimulationContent
    {
        /// <summary> Initializes a new instance of <see cref="FaultSimulationContent"/> for deserialization. </summary>
        protected FaultSimulationContent()
        {
        }
    }
}
