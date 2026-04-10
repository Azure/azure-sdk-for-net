// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class CloudServiceInstanceView
    {
        /// <summary> Initializes a new instance of CloudServiceInstanceView for deserialization. </summary>
        internal CloudServiceInstanceView()
        {
        }

        /// <summary> The role instance statuses summary. </summary>
        public IReadOnlyList<StatusCodeCount> RoleInstanceStatusesSummary { get; }

        /// <summary> The SDK version. </summary>
        public string SdkVersion { get; }

        /// <summary> The private IDs. </summary>
        public IReadOnlyList<string> PrivateIds { get; }

        /// <summary> The statuses. </summary>
        public IReadOnlyList<ResourceInstanceViewStatus> Statuses { get; }
    }
}
