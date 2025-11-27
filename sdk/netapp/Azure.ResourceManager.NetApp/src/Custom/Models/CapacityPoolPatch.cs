// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Capacity pool patch resource. </summary>
    public partial class CapacityPoolPatch : TrackedResourceData
    {
        /// <summary> Maximum throughput in MiB/s that can be achieved by this pool and this will be accepted as input only for manual qosType pool with Flexible service level. </summary>
        public float? CustomThroughputMibps
        {
            get
            {
                return CustomThroughputMibpsInt.HasValue ? (float?)CustomThroughputMibpsInt.Value : null;
            }
            set
            {
                CustomThroughputMibpsInt = value.HasValue ? (int)value.Value : null;
            }
        }
    }
}
