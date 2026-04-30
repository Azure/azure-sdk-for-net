// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    public partial class SoftwareAssuranceProperties
    {
        /// <summary> Status of the Software Assurance for the cluster. </summary>
        [WirePath("softwareAssuranceStatus")]
        public SoftwareAssuranceStatus? SoftwareAssuranceStatus { get; set; }

        /// <summary> TimeStamp denoting the latest SA benefit applicability is validated. </summary>
        [WirePath("lastUpdated")]
        public DateTimeOffset? LastUpdatedOn { get; }

        /// <summary> TimeStamp denoting the latest SA benefit applicability is validated. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `LastUpdatedOn` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? LastUpdated => throw new NotSupportedException("This property is obsolete, use LastUpdatedOn instead.");
    }
}
