// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class DedicatedHostInstanceView
    {
        /// <summary> The unutilized capacity of the dedicated host represented in terms of each VM size that is allowed to be deployed to the dedicated host. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<DedicatedHostAllocatableVm> AvailableCapacityAllocatableVms
        {
            get => AvailableCapacity?.AllocatableVMs is { } list ? (IReadOnlyList<DedicatedHostAllocatableVm>)list : null;
        }
    }
}
