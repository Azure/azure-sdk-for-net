// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci.Models
{
    public partial class HciPackageVersionInfo
    {
        /// <summary> Last time this component was updated. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `LastUpdated` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("lastUpdated")]
        public DateTimeOffset? LastUpdatedOn
        {
            get => LastUpdated;
            set => LastUpdated = value;
        }
    }
}
