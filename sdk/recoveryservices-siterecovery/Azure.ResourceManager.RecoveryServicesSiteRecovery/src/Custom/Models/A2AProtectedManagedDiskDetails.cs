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
        // v1.x primary was `IsResyncRequired` (kept via client.tsp @@clientName) and v1.x ALSO
        // shipped `ResyncRequired` as a get-only alias on this model. Restore that alias.
        /// <summary> A value indicating whether resync is required for this disk. </summary>
        public bool? ResyncRequired => IsResyncRequired;

        // v1.x primary was `SiteRecoveryAllowedDiskLevelOperation` as IList<string>. We keep
        // the MPG-generated `AllowedDiskLevelOperation` (IReadOnlyList<string>) as the primary
        // here because (a) IReadOnlyList<> is the modern preferred shape and (b) it matches the
        // v1.x get-only alias on this same property. This forwarder restores the v1.x primary
        // name as an IList<> view over the same backing list.
        /// <summary> The disk level operations list. </summary>
        public IList<string> SiteRecoveryAllowedDiskLevelOperation => AllowedDiskLevelOperation as IList<string>;
    }
}
