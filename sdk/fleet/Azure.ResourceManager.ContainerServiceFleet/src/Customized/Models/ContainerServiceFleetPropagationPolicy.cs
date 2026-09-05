// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ContainerServiceFleet.Models
{
    public partial class ContainerServiceFleetPropagationPolicy
    {
        /// <summary> Policy defines how to select member clusters to place the selected resources. If unspecified, all the joined member clusters are selected. </summary>
        public ContainerServiceFleetPlacementPolicy DefaultClusterResourcePlacementPolicy
        {
            get => DefaultClusterResourcePlacement?.Policy;
            set
            {
                if (DefaultClusterResourcePlacement is null)
                {
                    DefaultClusterResourcePlacement = new ClusterResourcePlacementSpec();
                }

                DefaultClusterResourcePlacement.Policy = value;
            }
        }
    }
}