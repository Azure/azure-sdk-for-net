// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

namespace Azure.ResourceManager.NetApp
{
    public partial class CapacityPoolData
    {
        public float? CustomThroughputMibps
        {
            get => CustomThroughputMibpsInt;
            set => CustomThroughputMibpsInt = value.HasValue ? (int?)value.Value : null;
        }
    }
}
