// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci.Models
{
    /// <summary> Software Assurance properties of the cluster. </summary>
    public partial class SoftwareAssuranceProperties
    {
        /// <summary> Status of the Software Assurance for the cluster. </summary>
        public SoftwareAssuranceStatus? SoftwareAssuranceStatus { get; set; }
        /// <summary> TimeStamp denoting the latest SA benefit applicability is validated. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `LastUpdatedOn` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? LastUpdated { get => LastUpdatedOn; }
    }
}
