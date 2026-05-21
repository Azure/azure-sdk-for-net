// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    // v1.x AutoRest baseline shipped FOUR API names for the two underlying spec properties
    // `resyncRequired` and `allowedDiskLevelOperation` on this model:
    //
    //   primary                                                       legacy back-compat shim
    //   ─────────────────────────────────────────────────────────     ─────────────────────────────
    //   IsResyncRequired                       { get; set; }      +   ResyncRequired                       { get; }
    //   SiteRecoveryAllowedDiskLevelOperation  { get; } IList<>   +   AllowedDiskLevelOperation            { get; } IReadOnlyList<>
    //
    // MPG can only produce ONE name per spec property. The renames in client.tsp pin the
    // primaries to `IsResyncRequired` and `AllowedDiskLevelOperation` (matching the v1.x
    // primary for resync, and matching the v1.x shim element-type for the disk-op list — note
    // that `AllowedDiskLevelOperation` is the IReadOnlyList view, not the IList one). The two
    // forwarders below restore the remaining two v1.x names so ApiCompat against v1.3.1 passes.
    // Removing either client.tsp rename or either forwarder breaks ApiCompat.
    public partial class A2AProtectedManagedDiskDetails
    {
        /// <summary> A value indicating whether resync is required for this disk. </summary>
        public bool? ResyncRequired => IsResyncRequired;

        /// <summary> The disk level operations list. </summary>
        public IList<string> SiteRecoveryAllowedDiskLevelOperation => AllowedDiskLevelOperation as IList<string>;
    }
}
