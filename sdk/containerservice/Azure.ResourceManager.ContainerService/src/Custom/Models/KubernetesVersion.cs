// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    public partial class KubernetesVersion
    {
        /// <summary> Kubernetes support plans available for this version. </summary>
        [WirePath("capabilities.supportPlan")]
        public IReadOnlyList<KubernetesSupportPlan> CapabilitiesSupportPlan
        {
            get
            {
                return Capabilities?.SupportPlan?.ToArray();
            }
        }
    }
}
