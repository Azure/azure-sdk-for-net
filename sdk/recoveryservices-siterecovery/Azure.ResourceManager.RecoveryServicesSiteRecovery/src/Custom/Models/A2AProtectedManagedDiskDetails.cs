// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    public partial class A2AProtectedManagedDiskDetails
    {
        // v1.x get-only alias for the `IsResyncRequired` primary.
        /// <summary> A value indicating whether resync is required for this disk. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? ResyncRequired => IsResyncRequired;

        // v1.x get-only IReadOnlyList<> view of the `SiteRecoveryAllowedDiskLevelOperation` primary.
        /// <summary> The disk level operations list. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<string> AllowedDiskLevelOperation => (IReadOnlyList<string>)SiteRecoveryAllowedDiskLevelOperation;
    }
}
