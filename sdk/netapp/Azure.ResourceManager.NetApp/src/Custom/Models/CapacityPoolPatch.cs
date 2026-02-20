// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class CapacityPoolPatch
    {
        public int? CustomThroughputMibpsInt
        {
            get => CustomThroughputMibps;
            set => CustomThroughputMibps = value;
        }
    }
}
