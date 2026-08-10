// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridContainerService.Models
{
    // TypeSpec generates this compatibility base model as output-only even though the previous
    // SDK exposed a public constructor and mutable creation properties.
    [CodeGenSuppress("HybridContainerServiceAgentPoolProfile")]
    public partial class HybridContainerServiceAgentPoolProfile
    {
        /// <summary> Initializes a new instance of <see cref="HybridContainerServiceAgentPoolProfile"/>. </summary>
        public HybridContainerServiceAgentPoolProfile()
        {
            NodeLabels = new ChangeTrackingDictionary<string, string>();
            NodeTaints = new ChangeTrackingList<string>();
        }

        /// <summary> The particular KubernetesVersion Image OS Type (Linux, Windows). </summary>
        [CodeGenMember("OSType")]
        public HybridContainerServiceOSType? OSType { get; set; }

        /// <summary> Specifies the OS SKU used by the agent pool. </summary>
        [CodeGenMember("OSSku")]
        public HybridContainerServiceOSSku? OSSku { get; set; }

        /// <summary> The maximum number of nodes for auto-scaling. </summary>
        [CodeGenMember("MaxCount")]
        public int? MaxCount { get; set; }

        /// <summary> The minimum number of nodes for auto-scaling. </summary>
        [CodeGenMember("MinCount")]
        public int? MinCount { get; set; }

        /// <summary> Whether to enable auto-scaler. </summary>
        [CodeGenMember("EnableAutoScaling")]
        public bool? EnableAutoScaling { get; set; }

        /// <summary> The maximum number of pods that can run on a node. </summary>
        [CodeGenMember("MaxPods")]
        public int? MaxPods { get; set; }
    }
}
