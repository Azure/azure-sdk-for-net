// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Models
{
    /// <summary>
    /// Describes the mechanism for performing a scaling operation.
    /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="NamedPartitionAddOrRemoveScalingMechanism"/> and <see cref="PartitionInstanceCountScalingMechanism"/>.
    /// </summary>
    public abstract partial class ManagedServiceScalingMechanism
    {
        /// <summary> Initializes a new instance of <see cref="ManagedServiceScalingMechanism"/> for deserialization. </summary>
        protected ManagedServiceScalingMechanism()
        {
        }
    }
}
