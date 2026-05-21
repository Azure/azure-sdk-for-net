// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

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
    // primaries to `IsResyncRequired` (matches v1.x primary) and `AllowedDiskLevelOperation`
    // (the IReadOnlyList<> shape — modern preferred, even though v1.x had this name as the
    // EBN shim, not the primary). The two forwarders below restore the remaining v1.x names
    // so ApiCompat against v1.3.1 passes. Both forwarders are EBN-hidden since callers should
    // prefer the primaries. Removing either client.tsp rename or either forwarder breaks ApiCompat.
    public partial class A2AProtectedManagedDiskDetails
    {
        // v1.x ALSO shipped `ResyncRequired` as a get-only alias on this model.
        /// <summary> A value indicating whether resync is required for this disk. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? ResyncRequired => IsResyncRequired;

        // v1.x primary was `SiteRecoveryAllowedDiskLevelOperation` as IList<string>. Restored
        // as an IList<> view over the IReadOnlyList<> primary's backing list.
        /// <summary> The disk level operations list. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> SiteRecoveryAllowedDiskLevelOperation => AllowedDiskLevelOperation as IList<string>;
    }
}
