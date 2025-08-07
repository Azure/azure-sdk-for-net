// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ContainerService.Models
{
    /// <summary> The name of a managed cluster SKU. </summary>
    public readonly partial struct ManagedClusterSkuName : IEquatable<ManagedClusterSkuName>
    {
        private const string BasicValue = "Basic";

        /// <summary> Basic. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ManagedClusterSkuName Basic { get; } = new ManagedClusterSkuName(BasicValue);
    }
}
