// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ContainerService.Models
{
    public partial class AgentPoolGpuProfile
    {
        /// <summary> The NVIDIA GPU management mode. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("nvidia.managementMode")]
        public GpuManagementMode? NvidiaManagementMode
        {
            get => Nvidia?.ManagementMode;
            set
            {
                Nvidia ??= new AgentPoolNvidiaGpuProfile();
                Nvidia.ManagementMode = value;
            }
        }
    }
}
