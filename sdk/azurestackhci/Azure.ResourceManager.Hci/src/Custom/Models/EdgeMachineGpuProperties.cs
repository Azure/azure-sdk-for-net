// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    public partial class EdgeMachineGpuProperties
    {
        /// <summary> Indicates whether the GPU is assignable. </summary>
        [CodeGenMember("Assignable")]
        public bool? IsAssignable { get; }

        /// <summary> Indicates whether the GPU is partitionable. </summary>
        [CodeGenMember("Partitionable")]
        public bool? IsPartitionable { get; }
    }
}
