// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class KubernetesClusterNode
    {
        /// <summary> The resource ID of the bare metal machine that hosts this node. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BareMetalMachineId
        {
            get => BareMetalMachineArmId is null ? default : BareMetalMachineArmId.ToString();
        }

        /// <summary> The resource ID of the agent pool that this node belongs to. This value is not represented on control plane nodes. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string AgentPoolId
        {
            get => AgentPoolArmId is null ? default : AgentPoolArmId.ToString();
        }
    }
}
