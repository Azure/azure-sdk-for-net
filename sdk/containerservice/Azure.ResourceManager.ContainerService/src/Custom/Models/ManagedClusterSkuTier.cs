// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    public readonly partial struct ManagedClusterSkuTier : IEquatable<ManagedClusterSkuTier>
    {
        private const string PaidValue = "Paid";

        /// <summary> Guarantees 99.95% availability of the Kubernetes API server endpoint for clusters that use Availability Zones and 99.9% of availability for clusters that don't use Availability Zones. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ManagedClusterSkuTier Paid { get; } = new ManagedClusterSkuTier(PaidValue);
    }
}
