// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    [CodeGenSuppress("SoftwareAssuranceStatus")]
    public partial class SoftwareAssuranceProperties
    {
        /// <summary> Status of the Software Assurance for the cluster. </summary>
        [WirePath("softwareAssuranceStatus")]
        public SoftwareAssuranceStatus? SoftwareAssuranceStatus { get; set; }

        /// <summary> TimeStamp denoting the latest SA benefit applicability is validated. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `LastUpdated` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("lastUpdated")]
        public DateTimeOffset? LastUpdatedOn => LastUpdated;
    }
}
