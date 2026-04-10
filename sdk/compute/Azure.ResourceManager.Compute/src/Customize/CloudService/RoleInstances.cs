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
    public partial class RoleInstances
    {
        /// <summary> Initializes a new instance of RoleInstances. </summary>
        /// <param name="roleInstancesValue"> The role instances. </param>
        public RoleInstances(IEnumerable<string> roleInstancesValue)
        {
            RoleInstancesValue = roleInstancesValue != null ? new List<string>(roleInstancesValue) : new List<string>();
        }

        /// <summary> The role instances. </summary>
        public IList<string> RoleInstancesValue { get; }
    }
}
