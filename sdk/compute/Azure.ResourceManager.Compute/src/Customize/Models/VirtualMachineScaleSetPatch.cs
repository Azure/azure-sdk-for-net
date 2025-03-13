// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class VirtualMachineScaleSetPatch : ComputeResourcePatch
    {
        /// <summary> The upgrade policy. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VirtualMachineScaleSetUpgradePolicy UpgradePolicy
        {
            get => Properties?.UpgradePolicy;
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachineScaleSetPatchProperties();
                }
                Properties.UpgradePolicy = value;
            }
        }

        /// <summary> Policy for automatic repairs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AutomaticRepairsPolicy AutomaticRepairsPolicy
        {
            get => Properties?.AutomaticRepairsPolicy;
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachineScaleSetPatchProperties();
                }
                Properties.AutomaticRepairsPolicy = value;
            }
        }

        /// <summary> The virtual machine profile. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VirtualMachineScaleSetUpdateVmProfile VirtualMachineProfile
        {
            get => Properties?.VirtualMachineProfile;
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachineScaleSetPatchProperties();
                }
                Properties.VirtualMachineProfile = value;
            }
        }

        /// <summary> Specifies whether the Virtual Machine Scale Set should be overprovisioned. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Overprovision
        {
            get => Properties?.Overprovision;
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachineScaleSetPatchProperties();
                }
                Properties.Overprovision = value;
            }
        }

        /// <summary> When Overprovision is enabled, extensions are launched only on the requested number of VMs which are finally kept. This property will hence ensure that the extensions do not run on the extra overprovisioned VMs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? DoNotRunExtensionsOnOverprovisionedVms
        {
            get => Properties?.DoNotRunExtensionsOnOverprovisionedVms;
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachineScaleSetPatchProperties();
                }
                Properties.DoNotRunExtensionsOnOverprovisionedVms = value;
            }
        }

        /// <summary> When true this limits the scale set to a single placement group, of max size 100 virtual machines. NOTE: If singlePlacementGroup is true, it may be modified to false. However, if singlePlacementGroup is false, it may not be modified to true. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? SinglePlacementGroup
        {
            get => Properties?.SinglePlacementGroup;
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachineScaleSetPatchProperties();
                }
                Properties.SinglePlacementGroup = value;
            }
        }

        /// <summary> Specifies additional capabilities enabled or disabled on the Virtual Machines in the Virtual Machine Scale Set. For instance: whether the Virtual Machines have the capability to support attaching managed data disks with UltraSSD_LRS storage account type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AdditionalCapabilities AdditionalCapabilities
        {
            get => Properties?.AdditionalCapabilities;
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachineScaleSetPatchProperties();
                }
                Properties.AdditionalCapabilities = value;
            }
        }

        /// <summary> Specifies the policies applied when scaling in Virtual Machines in the Virtual Machine Scale Set. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScaleInPolicy ScaleInPolicy
        {
            get => Properties?.ScaleInPolicy;
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachineScaleSetPatchProperties();
                }
                Properties.ScaleInPolicy = value;
            }
        }

        /// <summary> Gets or sets Id. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier ProximityPlacementGroupId
        {
            get => Properties?.ProximityPlacementGroupId;
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachineScaleSetPatchProperties();
                }
                Properties.ProximityPlacementGroupId = value;
            }
        }

        /// <summary> Specifies the desired targets for mixing Spot and Regular priority VMs within the same VMSS Flex instance. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VirtualMachineScaleSetPriorityMixPolicy PriorityMixPolicy
        {
            get => Properties?.PriorityMixPolicy;
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachineScaleSetPatchProperties();
                }
                Properties.PriorityMixPolicy = value;
            }
        }

        /// <summary> Specifies the Spot Restore properties for the virtual machine scale set. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SpotRestorePolicy SpotRestorePolicy
        {
            get => Properties?.SpotRestorePolicy;
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachineScaleSetPatchProperties();
                }
                Properties.SpotRestorePolicy = value;
            }
        }

        /// <summary> Policy for Resiliency. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResiliencyPolicy ResiliencyPolicy
        {
            get => Properties?.ResiliencyPolicy;
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachineScaleSetPatchProperties();
                }
                Properties.ResiliencyPolicy = value;
            }
        }

        /// <summary> Specifies the align mode between Virtual Machine Scale Set compute and storage Fault Domain count. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ZonalPlatformFaultDomainAlignMode? ZonalPlatformFaultDomainAlignMode
        {
            get => Properties?.ZonalPlatformFaultDomainAlignMode;
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachineScaleSetPatchProperties();
                }
                Properties.ZonalPlatformFaultDomainAlignMode = value;
            }
        }

        /// <summary> Specifies the sku profile for the virtual machine scale set. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ComputeSkuProfile SkuProfile
        {
            get => Properties?.SkuProfile;
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachineScaleSetPatchProperties();
                }
                Properties.SkuProfile = value;
            }
        }
    }
}
