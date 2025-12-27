// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Models
{
    /// <summary>
    /// Describes how the service is partitioned.
    /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="UniformInt64RangePartitionScheme"/>, <see cref="SingletonPartitionScheme"/>, and <see cref="NamedPartitionScheme"/>.
    /// </summary>
    public abstract partial class ManagedServicePartitionScheme
    {
        /// <summary> Initializes a new instance of <see cref="ManagedServicePartitionScheme"/> for deserialization. </summary>
        protected ManagedServicePartitionScheme()
        {
        }
    }
}
