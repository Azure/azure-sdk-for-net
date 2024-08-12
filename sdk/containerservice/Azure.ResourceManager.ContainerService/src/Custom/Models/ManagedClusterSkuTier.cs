// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ContainerService.Models
{
    /// <summary> If not specified, the default is 'Free'. See [uptime SLA](https://docs.microsoft.com/azure/aks/uptime-sla) for more details. </summary>
    public readonly partial struct ManagedClusterSkuTier : IEquatable<ManagedClusterSkuTier>
    {
        private const string PaidValue = "Paid";

        /// <summary> Guarantees 99.95% availability of the Kubernetes API server endpoint for clusters that use Availability Zones and 99.9% of availability for clusters that don't use Availability Zones. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ManagedClusterSkuTier Paid { get; } = new ManagedClusterSkuTier(PaidValue);
    }
}
