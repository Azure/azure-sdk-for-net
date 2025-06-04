// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Compute
{
    public partial class VirtualMachineScaleSetData : TrackedResourceData
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
                    Properties = new VirtualMachineScaleSetProperties();
                }
                Properties.UpgradePolicy = value;
            }
        }

        /// <summary> The ScheduledEventsPolicy. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScheduledEventsPolicy ScheduledEventsPolicy
        {
            get => Properties?.ScheduledEventsPolicy;
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachineScaleSetProperties();
                }
                Properties.ScheduledEventsPolicy = value;
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
                    Properties = new VirtualMachineScaleSetProperties();
                }
                Properties.AutomaticRepairsPolicy = value;
            }
        }

        /// <summary> The virtual machine profile. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VirtualMachineScaleSetVmProfile VirtualMachineProfile
        {
            get => Properties?.VirtualMachineProfile;
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachineScaleSetProperties();
                }
                Properties.VirtualMachineProfile = value;
            }
        }

        /// <summary> The provisioning state, which only appears in the response. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ProvisioningState => Properties?.ProvisioningState;

        /// <summary> Specifies whether the Virtual Machine Scale Set should be overprovisioned. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Overprovision
        {
            get => Properties?.Overprovision;
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachineScaleSetProperties();
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
                    Properties = new VirtualMachineScaleSetProperties();
                }
                Properties.DoNotRunExtensionsOnOverprovisionedVms = value;
            }
        }

        /// <summary> Specifies the ID which uniquely identifies a Virtual Machine Scale Set. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string UniqueId => Properties?.UniqueId;

        /// <summary> When true this limits the scale set to a single placement group, of max size 100 virtual machines. NOTE: If singlePlacementGroup is true, it may be modified to false. However, if singlePlacementGroup is false, it may not be modified to true. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? SinglePlacementGroup
        {
            get => Properties?.SinglePlacementGroup;
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachineScaleSetProperties();
                }
                Properties.SinglePlacementGroup = value;
            }
        }

        /// <summary> Whether to force strictly even Virtual Machine distribution cross x-zones in case there is zone outage. zoneBalance property can only be set if the zones property of the scale set contains more than one zone. If there are no zones or only one zone specified, then zoneBalance property should not be set. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? ZoneBalance
        {
            get => Properties?.ZoneBalance;
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachineScaleSetProperties();
                }
                Properties.ZoneBalance = value;
            }
        }

        /// <summary> Fault Domain count for each placement group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? PlatformFaultDomainCount
        {
            get => Properties?.PlatformFaultDomainCount;
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachineScaleSetProperties();
                }
                Properties.PlatformFaultDomainCount = value;
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
                    Properties = new VirtualMachineScaleSetProperties();
                }
                Properties.ProximityPlacementGroupId = value;
            }
        }

        /// <summary> Gets or sets Id. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier HostGroupId
        {
            get => Properties?.HostGroupId;
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachineScaleSetProperties();
                }
                Properties.HostGroupId = value;
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
                    Properties = new VirtualMachineScaleSetProperties();
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
                    Properties = new VirtualMachineScaleSetProperties();
                }
                Properties.ScaleInPolicy = value;
            }
        }

        /// <summary> Specifies the orchestration mode for the virtual machine scale set. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OrchestrationMode? OrchestrationMode
        {
            get => Properties?.OrchestrationMode;
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachineScaleSetProperties();
                }
                Properties.OrchestrationMode = value;
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
                    Properties = new VirtualMachineScaleSetProperties();
                }
                Properties.SpotRestorePolicy = value;
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
                    Properties = new VirtualMachineScaleSetProperties();
                }
                Properties.PriorityMixPolicy = value;
            }
        }

        /// <summary> Specifies the time at which the Virtual Machine Scale Set resource was created. Minimum api-version: 2021-11-01. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? TimeCreated => Properties?.TimeCreated;

        /// <summary> Optional property which must either be set to True or omitted. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsMaximumCapacityConstrained
        {
            get => Properties?.IsMaximumCapacityConstrained;
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachineScaleSetProperties();
                }
                Properties.IsMaximumCapacityConstrained = value;
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
                    Properties = new VirtualMachineScaleSetProperties();
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
                    Properties = new VirtualMachineScaleSetProperties();
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
                    Properties = new VirtualMachineScaleSetProperties();
                }
                Properties.SkuProfile = value;
            }
        }
    }
}
