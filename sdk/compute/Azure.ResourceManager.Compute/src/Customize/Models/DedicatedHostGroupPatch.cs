// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class DedicatedHostGroupPatch
    {
        /// <summary> A list of references to all dedicated hosts in the dedicated host group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<SubResource> Hosts
        {
            get => DedicatedHosts;
        }
    }
}
