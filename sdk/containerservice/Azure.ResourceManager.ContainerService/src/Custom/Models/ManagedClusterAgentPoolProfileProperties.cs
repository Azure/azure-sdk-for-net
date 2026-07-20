// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    /// <summary>
    /// Properties for the container service agent pool profile.
    /// Serialized Name: ManagedClusterAgentPoolProfileProperties
    /// </summary>
    public partial class ManagedClusterAgentPoolProfileProperties
    {
        /// <summary> This can either be set to an integer (e.g. '5') or a percentage (e.g. '50%'). If a percentage is specified, it is the percentage of the total agent pool size at the time of the upgrade. For percentages, fractional nodes are rounded up. If not specified, the default is 1. For more information, including best practices, see: https://docs.microsoft.com/azure/aks/upgrade-cluster#customize-node-surge-upgrade. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string UpgradeMaxSurge
        {
            get => UpgradeSettings is null ? default : UpgradeSettings.MaxSurge;
            set
            {
                if (UpgradeSettings is null)
                    UpgradeSettings = new AgentPoolUpgradeSettings();
                UpgradeSettings.MaxSurge = value;
            }
        }

        /// <summary> Specifications on how to scale the VirtualMachines agent pool to a fixed size. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("virtualMachinesProfile.scale.manual")]
        public IList<ManualScaleProfile> ScaleManual
        {
            get => VirtualMachinesScaleManual;
        }

        /// <summary> Specifications on how to scale the VirtualMachines agent pool to a fixed size. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("virtualMachinesProfile.scale.manual")]
        public IList<ManualScaleProfile> VirtualMachinesScaleManual
        {
            get
            {
                if (VirtualMachinesProfile is null)
                    VirtualMachinesProfile = new VirtualMachinesProfile();
                return VirtualMachinesProfile.Scale.Manual;
            }
        }

        /// <summary> Whether to install GPU drivers. When it's not specified, default is Install. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("gpuProfile.driver")]
        public AgentPoolGpuDriver? GpuDriver
        {
            get => GpuProfile is null ? default : GpuProfile.Driver;
            set
            {
                if (GpuProfile is null)
                    GpuProfile = new AgentPoolGpuProfile();
                GpuProfile.Driver = value;
            }
        }

        /// <summary> Whether to enable auto-scaler. </summary>
        [WirePath("enableAutoScaling")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableAutoScaling { get => IsAutoScalingEnabled; set => IsAutoScalingEnabled = value; }

        /// <summary> Whether each node is allocated its own public IP. </summary>
        [WirePath("enableNodePublicIP")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableNodePublicIP { get => IsNodePublicIpEnabled; set => IsNodePublicIpEnabled = value; }

        /// <summary> Whether to enable host based OS and data drive encryption. </summary>
        [WirePath("enableEncryptionAtHost")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableEncryptionAtHost { get => IsEncryptionAtHostEnabled; set => IsEncryptionAtHostEnabled = value; }

        /// <summary> Whether to use a FIPS-enabled OS. </summary>
        [WirePath("enableFIPS")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableFips { get => IsFipsEnabled; set => IsFipsEnabled = value; }

        /// <summary> Whether to enable UltraSSD. </summary>
        [WirePath("enableUltraSSD")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableUltraSsd { get => IsUltraSsdEnabled; set => IsUltraSsdEnabled = value; }
    }
}
