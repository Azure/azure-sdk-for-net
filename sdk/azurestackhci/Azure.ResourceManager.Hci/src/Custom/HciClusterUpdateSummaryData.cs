// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Hci
{
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
