// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci.Models
{
    public partial class HciPackageVersionInfo
    {
        /// <summary> Last time this component was updated. </summary>
        [WirePath("lastUpdated")]
        public DateTimeOffset? LastUpdatedOn { get; set; }

        /// <summary> Last time this component was updated. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `LastUpdatedOn` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? LastUpdated
        {
            get => throw new NotSupportedException("This property is obsolete, use LastUpdatedOn instead.");
            set => throw new NotSupportedException("This property is obsolete, use LastUpdatedOn instead.");
        }
    }
}
