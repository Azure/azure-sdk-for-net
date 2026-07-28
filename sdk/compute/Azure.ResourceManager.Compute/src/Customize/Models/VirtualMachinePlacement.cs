// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class VirtualMachinePlacement
    {
        // Customization: the previously-shipped surface exposed `ZonePlacementPolicy` as a `string`.
        // The TypeSpec `Placement.zonePlacementPolicy` is now an enum `ZonePlacementPolicyType`,
        // renamed via @@clientName to keep the new strongly-typed surface available while preserving
        // the legacy string-typed `ZonePlacementPolicy` property for backward compatibility.
        /// <summary> Specifies the policy for resource's placement in availability zone. Possible values are: **Any** (used for Virtual Machines), **Auto** (used for Virtual Machine Scale Sets) - An availability zone will be automatically picked by system as part of resource creation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ZonePlacementPolicy
        {
            get => ZonePlacementPolicyType?.ToString();
            set => ZonePlacementPolicyType = value == null ? null : new ZonePlacementPolicyType(value);
        }
    }
}
