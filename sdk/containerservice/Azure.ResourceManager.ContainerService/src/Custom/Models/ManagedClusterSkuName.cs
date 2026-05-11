// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    public readonly partial struct ManagedClusterSkuName : IEquatable<ManagedClusterSkuName>
    {
        private const string BasicValue = "Basic";

        /// <summary> Basic. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ManagedClusterSkuName Basic { get; } = new ManagedClusterSkuName(BasicValue);
    }
}
