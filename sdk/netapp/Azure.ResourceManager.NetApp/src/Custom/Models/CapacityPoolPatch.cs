// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    // Backward compatibility: v1.15.0 exposed CustomThroughputMibps as float? on
    // CapacityPoolPatch. The TypeSpec spec defines the field as int (CustomThroughputMibpsInt
    // in csharp); this float? overload forwards to the int? backing property to keep the
    // legacy property compiling.
    public partial class CapacityPoolPatch
    {
        public float? CustomThroughputMibps
        {
            get => CustomThroughputMibpsInt;
            set => CustomThroughputMibpsInt = value.HasValue ? (int?)value.Value : null;
        }
    }
}
