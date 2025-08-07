// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    /// <summary> A2A protected managed disk details. </summary>
    public partial class A2AProtectedManagedDiskDetails
    {
        /// <summary> The disk level operations list. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<string> AllowedDiskLevelOperation { get; }

        /// <summary> A value indicating whether resync is required for this disk. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? ResyncRequired { get; }
    }
}
