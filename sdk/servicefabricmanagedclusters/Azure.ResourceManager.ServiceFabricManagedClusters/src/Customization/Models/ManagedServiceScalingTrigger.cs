// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Models
{
    /// <summary>
    /// Describes the trigger for performing a scaling operation.
    /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="AveragePartitionLoadScalingTrigger"/> and <see cref="AverageServiceLoadScalingTrigger"/>.
    /// </summary>
    public abstract partial class ManagedServiceScalingTrigger
    {
        /// <summary> Initializes a new instance of <see cref="ManagedServiceScalingTrigger"/> for deserialization. </summary>
        protected ManagedServiceScalingTrigger()
        {
        }
    }
}
