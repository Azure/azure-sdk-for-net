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
    public partial class RoleInstanceView
    {
        /// <summary> Initializes a new instance of RoleInstanceView for deserialization. </summary>
        internal RoleInstanceView()
        {
        }

        /// <summary> The platform fault domain. </summary>
        public int? PlatformFaultDomain { get; }

        /// <summary> The platform update domain. </summary>
        public int? PlatformUpdateDomain { get; }

        /// <summary> The private ID. </summary>
        public string PrivateId { get; }

        /// <summary> The statuses. </summary>
        public IReadOnlyList<ResourceInstanceViewStatus> Statuses { get; }
    }
}
