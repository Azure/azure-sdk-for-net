// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    public partial class SiteRecoverySupportedOperatingSystems
    {
        /// <summary> The supported operating systems property list. </summary>
        public IReadOnlyList<SiteRecoverySupportedOSProperty> SupportedOSList
            => (IReadOnlyList<SiteRecoverySupportedOSProperty>)SupportedOSListInternal;
    }
}
