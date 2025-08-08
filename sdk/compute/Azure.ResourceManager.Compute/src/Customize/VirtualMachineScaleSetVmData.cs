// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Compute
{
    public partial class VirtualMachineScaleSetVmData : TrackedResourceData
    {
        /// <summary> Specifies whether the latest model has been applied to the virtual machine. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? LatestModelApplied => Properties?.LatestModelApplied;
        /// <summary> Azure VM unique ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string VmId => Properties?.VmId;
        /// <summary> The virtual machine instance view. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VirtualMachineScaleSetVmInstanceView InstanceView => Properties?.InstanceView;
        /// <summary> Specifies the hardware settings for the virtual machine. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VirtualMachineHardwareProfile HardwareProfile
        {
            get => Properties?.HardwareProfile;
            set
            {
                if (Properties == null)
                    Properties = new VirtualMachineScaleSetVmProperties();
                Properties.HardwareProfile = value;
            }
        }
        /// <summary> Specifies the resilient VM deletion status for the virtual machine. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResilientVmDeletionStatus? ResilientVmDeletionStatus
        {
            get => Properties?.ResilientVmDeletionStatus;
            set
            {
                if (Properties == null)
                    Properties = new VirtualMachineScaleSetVmProperties();
                Properties.ResilientVmDeletionStatus = value;
            }
        }
        /// <summary> Specifies the storage settings for the virtual machine disks. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VirtualMachineStorageProfile StorageProfile
        {
            get => Properties?.StorageProfile;
            set
            {
                if (Properties == null)
                    Properties = new VirtualMachineScaleSetVmProperties();
                Properties.StorageProfile = value;
            }
        }
        /// <summary> Specifies additional capabilities enabled or disabled on the virtual machine in the scale set. For instance: whether the virtual machine has the capability to support attaching managed data disks with UltraSSD_LRS storage account type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AdditionalCapabilities AdditionalCapabilities
        {
            get => Properties?.AdditionalCapabilities;
            set
            {
                if (Properties == null)
                    Properties = new VirtualMachineScaleSetVmProperties();
                Properties.AdditionalCapabilities = value;
            }
        }
        /// <summary> Specifies the operating system settings for the virtual machine. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VirtualMachineOSProfile OSProfile
        {
            get => Properties?.OSProfile;
            set
            {
                if (Properties == null)
                    Properties = new VirtualMachineScaleSetVmProperties();
                Properties.OSProfile = value;
            }
        }
        /// <summary> Specifies the Security related profile settings for the virtual machine. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SecurityProfile SecurityProfile
        {
            get => Properties?.SecurityProfile;
            set
            {
                if (Properties == null)
                    Properties = new VirtualMachineScaleSetVmProperties();
                Properties.SecurityProfile = value;
            }
        }
        /// <summary> Specifies the network interfaces of the virtual machine. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VirtualMachineNetworkProfile NetworkProfile
        {
            get => Properties?.NetworkProfile;
            set
            {
                if (Properties == null)
                    Properties = new VirtualMachineScaleSetVmProperties();
                Properties.NetworkProfile = value;
            }
        }
        /// <summary> The list of network configurations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<VirtualMachineScaleSetNetworkConfiguration> NetworkInterfaceConfigurations => Properties?.NetworkInterfaceConfigurations;

        /// <summary> Boot Diagnostics is a debugging feature which allows you to view Console Output and Screenshot to diagnose VM status. **NOTE**: If storageUri is being specified then ensure that the storage account is in the same region and subscription as the VM. You can easily view the output of your console log. Azure also enables you to see a screenshot of the VM from the hypervisor. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BootDiagnostics BootDiagnostics
        {
            get => Properties?.BootDiagnostics;
            set
            {
                if (Properties == null)
                    Properties = new VirtualMachineScaleSetVmProperties();
                Properties.BootDiagnostics = value;
            }
        }

        /// <summary> Gets or sets Id. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier AvailabilitySetId
        {
            get => Properties?.AvailabilitySetId;
            set
            {
                if (Properties == null)
                    Properties = new VirtualMachineScaleSetVmProperties();
                Properties.AvailabilitySetId = value;
            }
        }

        /// <summary> The provisioning state, which only appears in the response. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ProvisioningState => Properties?.ProvisioningState;
        /// <summary> Specifies that the image or disk that is being used was licensed on-premises. &lt;br&gt;&lt;br&gt; Possible values for Windows Server operating system are: &lt;br&gt;&lt;br&gt; Windows_Client &lt;br&gt;&lt;br&gt; Windows_Server &lt;br&gt;&lt;br&gt; Possible values for Linux Server operating system are: &lt;br&gt;&lt;br&gt; RHEL_BYOS (for RHEL) &lt;br&gt;&lt;br&gt; SLES_BYOS (for SUSE) &lt;br&gt;&lt;br&gt; For more information, see [Azure Hybrid Use Benefit for Windows Server](https://docs.microsoft.com/azure/virtual-machines/windows/hybrid-use-benefit-licensing) &lt;br&gt;&lt;br&gt; [Azure Hybrid Use Benefit for Linux Server](https://docs.microsoft.com/azure/virtual-machines/linux/azure-hybrid-benefit-linux) &lt;br&gt;&lt;br&gt; Minimum api-version: 2015-06-15. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string LicenseType
        {
            get => Properties?.LicenseType;
            set
            {
                if (Properties == null)
                    Properties = new VirtualMachineScaleSetVmProperties();
                Properties.LicenseType = value;
            }
        }
        /// <summary> Specifies whether the model applied to the virtual machine is the model of the virtual machine scale set or the customized model for the virtual machine. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ModelDefinitionApplied => Properties?.ModelDefinitionApplied;
        /// <summary> Specifies the protection policy of the virtual machine. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VirtualMachineScaleSetVmProtectionPolicy ProtectionPolicy
        {
            get => Properties?.ProtectionPolicy;
            set
            {
                if (Properties == null)
                    Properties = new VirtualMachineScaleSetVmProperties();
                Properties.ProtectionPolicy = value;
            }
        }
        /// <summary> UserData for the VM, which must be base-64 encoded. Customer should not pass any secrets in here. Minimum api-version: 2021-03-01. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string UserData
        {
            get => Properties?.UserData;
            set
            {
                if (Properties == null)
                    Properties = new VirtualMachineScaleSetVmProperties();
                Properties.UserData = value;
            }
        }
        /// <summary> Specifies the time at which the Virtual Machine resource was created. Minimum api-version: 2021-11-01. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? TimeCreated => Properties?.TimeCreated;
    }
}
