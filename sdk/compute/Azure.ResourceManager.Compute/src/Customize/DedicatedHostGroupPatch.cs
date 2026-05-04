// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class DedicatedHostGroupPatch
    {
        // Customization: restored as IReadOnlyList<DedicatedHostInstanceViewWithName> to preserve the
        // previously-shipped API surface. The new spec emits this as a writable IList, which would be a
        // binary-breaking change for existing consumers.
        /// <summary> A list of references to all dedicated hosts in the dedicated host group. </summary>
        public IReadOnlyList<DedicatedHostInstanceViewWithName> InstanceViewHosts
        {
            get
            {
                return Properties is null ? new ChangeTrackingList<DedicatedHostInstanceViewWithName>() : (IReadOnlyList<DedicatedHostInstanceViewWithName>)Properties.InstanceViewHosts;
            }
        }
    }
}
