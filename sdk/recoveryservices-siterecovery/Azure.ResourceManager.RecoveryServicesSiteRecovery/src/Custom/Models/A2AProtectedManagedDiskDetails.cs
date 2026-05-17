// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    public partial class A2AProtectedManagedDiskDetails
    {
        /// <summary> A value indicating whether resync is required for this disk. </summary>
        public bool? ResyncRequired => IsResyncRequired;

        /// <summary> The disk level operations list. </summary>
        public IList<string> SiteRecoveryAllowedDiskLevelOperation => AllowedDiskLevelOperation as IList<string>;
    }
}
