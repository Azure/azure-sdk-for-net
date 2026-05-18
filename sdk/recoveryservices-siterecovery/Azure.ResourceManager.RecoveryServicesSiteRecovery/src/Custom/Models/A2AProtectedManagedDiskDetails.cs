// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    public partial class A2AProtectedManagedDiskDetails
    {
        // Legacy v1.x AutoRest SDK shipped BOTH `IsResyncRequired` (with setter, from the auto
        // "Is" prefix on booleans) AND a get-only `ResyncRequired` alias on this specific model
        // (the legacy SDK had its own back-compat customization). The MPG-generated public
        // surface only carries `IsResyncRequired`; this forwarder restores `ResyncRequired` so
        // ApiCompat against the v1.x baseline passes. See client.tsp for the @@clientName that
        // pins the generated name to `IsResyncRequired`.
        /// <summary> A value indicating whether resync is required for this disk. </summary>
        public bool? ResyncRequired => IsResyncRequired;

        /// <summary> The disk level operations list. </summary>
        public IList<string> SiteRecoveryAllowedDiskLevelOperation => AllowedDiskLevelOperation as IList<string>;
    }
}
