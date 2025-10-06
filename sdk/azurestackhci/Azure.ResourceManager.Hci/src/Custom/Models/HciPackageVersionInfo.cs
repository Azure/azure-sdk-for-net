// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci.Models
{
    /// <summary> Current version of each updatable component. </summary>
    public partial class HciPackageVersionInfo
    {
        /// <summary> Last time this component was updated. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `LastUpdatedOn` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? LastUpdated { get => LastUpdatedOn; set => LastUpdatedOn = value; }
    }
}
