// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.ContainerService.Models;
using Azure.ResourceManager.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService
{
    public partial class ContainerServiceAgentPoolData : ResourceData
    {
        /// <summary> This can either be set to an integer (e.g. '5') or a percentage (e.g. '50%'). If a percentage is specified, it is the percentage of the total agent pool size at the time of the upgrade. For percentages, fractional nodes are rounded up. If not specified, the default is 1. For more information, including best practices, see: https://docs.microsoft.com/azure/aks/upgrade-cluster#customize-node-surge-upgrade. </summary>
        [WirePath("properties.upgradeSettings.maxSurge")]
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

        /// <summary> Whether to install GPU drivers. When it's not specified, default is Install. </summary>
        [WirePath("properties.gpuProfile.driver")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AgentPoolGpuDriver? GpuDriver
        {
            get => Properties?.GpuProfile is null ? default : Properties.GpuProfile.Driver;
            set
            {
                if (Properties is null)
                    Properties = new ManagedClusterAgentPoolProfileProperties();
                if (Properties.GpuProfile is null)
                    Properties.GpuProfile = new AgentPoolGpuProfile();
                Properties.GpuProfile.Driver = value;
            }
        }

        /// <summary> Specifications on how to scale the VirtualMachines agent pool to a fixed size. </summary>
        [WirePath("properties.virtualMachinesProfile.scale.manual")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ManualScaleProfile> ScaleManual
        {
            get => VirtualMachinesScaleManual;
        }

        /// <summary> Specifications on how to scale the VirtualMachines agent pool to a fixed size. </summary>
        [WirePath("properties.virtualMachinesProfile.scale.manual")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ManualScaleProfile> VirtualMachinesScaleManual
        {
            get => VirtualMachinesScale?.Manual;
        }

        /// <summary> The type of Agent Pool. </summary>
        [WirePath("properties.type")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AgentPoolType? TypePropertiesType { get => AgentPoolType; set => AgentPoolType = value; }

        /// <summary> Whether to enable auto-scaler. </summary>
        [WirePath("properties.enableAutoScaling")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableAutoScaling { get => IsAutoScalingEnabled; set => IsAutoScalingEnabled = value; }

        /// <summary> Whether each node is allocated its own public IP. </summary>
        [WirePath("properties.enableNodePublicIP")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableNodePublicIP { get => IsNodePublicIpEnabled; set => IsNodePublicIpEnabled = value; }

        /// <summary> Whether to enable host based OS and data drive encryption. </summary>
        [WirePath("properties.enableEncryptionAtHost")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableEncryptionAtHost { get => IsEncryptionAtHostEnabled; set => IsEncryptionAtHostEnabled = value; }

        /// <summary> Whether to use a FIPS-enabled OS. </summary>
        [WirePath("properties.enableFIPS")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableFips { get => IsFipsEnabled; set => IsFipsEnabled = value; }

        /// <summary> Whether to enable UltraSSD. </summary>
        [WirePath("properties.enableUltraSSD")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableUltraSsd { get => IsUltraSsdEnabled; set => IsUltraSsdEnabled = value; }
    }
}
