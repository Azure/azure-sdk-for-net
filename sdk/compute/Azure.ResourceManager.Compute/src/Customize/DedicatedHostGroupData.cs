// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute
{
    public partial class DedicatedHostGroupData
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

        // Backward compatibility: the generated Compute-local property is named DedicatedHostResources and uses
        // ComputeSubResourceData. Restore the old DedicatedHosts property with ARM common SubResource.
        /// <summary> A list of references to all dedicated hosts in the dedicated host group. </summary>
        public IReadOnlyList<SubResource> DedicatedHosts => DedicatedHostResources?.Select(value => ResourceManagerModelFactory.SubResource(value.Id)).ToArray();
    }
}
