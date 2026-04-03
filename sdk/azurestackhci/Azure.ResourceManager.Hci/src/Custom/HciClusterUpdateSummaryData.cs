// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Hci
{
    // Backward compat: the GA SDK (1.2.1) exposed LastCheckedOn/LastUpdatedOn as aliases
    // for the generated LastChecked/LastUpdated properties.
    // Both names must coexist since we can't remove either without a breaking change.
    public partial class HciClusterUpdateSummaryData
    {
        /// <summary> Last time the update service successfully checked for updates. </summary>
        [WirePath("properties.lastChecked")]
        public DateTimeOffset? LastCheckedOn { get => LastChecked; set => LastChecked = value; }

        /// <summary> Last time an update installation completed successfully. </summary>
        [WirePath("properties.lastUpdated")]
        public DateTimeOffset? LastUpdatedOn { get => LastUpdated; set => LastUpdated = value; }
    }
}
