using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Core;
using System;
using System.Collections.Generic;

namespace Proto.Compute
{
    /// <summary>
    /// A class representing the VirtualMachine data model.
    /// </summary>
    public class VirtualMachineData : TrackedResource<ResourceGroupResourceIdentifier, Azure.ResourceManager.Compute.Models.VirtualMachine>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualMachineData"/> class.
        /// </summary>
        /// <param name="vm"> The virtual machine to initialize. </param>
        public VirtualMachineData(Azure.ResourceManager.Compute.Models.VirtualMachine vm) : base(vm.Id, vm.Location, vm)
        {
        }

        /// <summary> Resource tags. </summary>
        public override IDictionary<string, string> Tags => Model.Tags;

        /// <summary> Resource name. </summary>
        public override string Name => Model.Name;

        /// <summary> The virtual machine instance view. </summary>
        public VirtualMachineInstanceView InstanceView => Model.InstanceView;

        /// <summary> The provisioning state, which only appears in the response. </summary>
        public string ProvisioningState => Model.ProvisioningState;

        /// <summary> Specifies information about the dedicated host that the virtual machine resides in. &lt;br&gt;&lt;br&gt;Minimum api-version: 2018-10-01. </summary>
        public SubResource Host
        {
            get => Model.Host;
            set => Model.Host = value;
        }

        /// <summary> Specifies the billing related details of a Azure Spot virtual machine. &lt;br&gt;&lt;br&gt;Minimum api-version: 2019-03-01. </summary>
        public BillingProfile BillingProfile
        {
            get => Model.BillingProfile;
            set => Model.BillingProfile = value;
        }

        /// <summary> Specifies the eviction policy for the Azure Spot virtual machine and Azure Spot scale set. &lt;br&gt;&lt;br&gt;For Azure Spot virtual machines, the only supported value is &apos;Deallocate&apos; and the minimum api-version is 2019-03-01. &lt;br&gt;&lt;br&gt;For Azure Spot scale sets, both &apos;Deallocate&apos; and &apos;Delete&apos; are supported and the minimum api-version is 2017-10-30-preview. </summary>
        public VirtualMachineEvictionPolicyTypes? EvictionPolicy
        {
            get => Model.EvictionPolicy;
            set => Model.EvictionPolicy = value;
        }

        /// <summary> Specifies the priority for the virtual machine. &lt;br&gt;&lt;br&gt;Minimum api-version: 2019-03-01. </summary>
        public VirtualMachinePriorityTypes? Priority
        {
            get => Model.Priority;
            set => Model.Priority = value;
        }

        /// <summary> Specifies information about the proximity placement group that the virtual machine should be assigned to. &lt;br&gt;&lt;br&gt;Minimum api-version: 2018-04-01. </summary>
        public SubResource ProximityPlacementGroup
        {
            get => Model.ProximityPlacementGroup;
            set => Model.ProximityPlacementGroup = value;
        }

        /// <summary> Specifies information about the virtual machine scale set that the virtual machine should be assigned to. Virtual machines specified in the same virtual machine scale set are allocated to different nodes to maximize availability. Currently, a VM can only be added to virtual machine scale set at creation time. An existing VM cannot be added to a virtual machine scale set. &lt;br&gt;&lt;br&gt;This property cannot exist along with a non-null properties.availabilitySet reference. &lt;br&gt;&lt;br&gt;Minimum api‐version: 2019‐03‐01. </summary>
        public SubResource VirtualMachineScaleSet
        {
            get => Model.VirtualMachineScaleSet;
            set => Model.VirtualMachineScaleSet = value;
        }

        /// <summary> Specifies information about the availability set that the virtual machine should be assigned to. Virtual machines specified in the same availability set are allocated to different nodes to maximize availability. For more information about availability sets, see [Manage the availability of virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-manage-availability?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json). &lt;br&gt;&lt;br&gt; For more information on Azure planned maintenance, see [Planned maintenance for virtual machines in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-planned-maintenance?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json) &lt;br&gt;&lt;br&gt; Currently, a VM can only be added to availability set at creation time. The availability set to which the VM is being added should be under the same resource group as the availability set resource. An existing VM cannot be added to an availability set. &lt;br&gt;&lt;br&gt;This property cannot exist along with a non-null properties.virtualMachineScaleSet reference. </summary>
        public SubResource AvailabilitySet
        {
            get => Model.AvailabilitySet;
            set => Model.AvailabilitySet = value;
        }

        /// <summary> Specifies the boot diagnostic settings state. &lt;br&gt;&lt;br&gt;Minimum api-version: 2015-06-15. </summary>
        public DiagnosticsProfile DiagnosticsProfile
        {
            get => Model.DiagnosticsProfile;
            set => Model.DiagnosticsProfile = value;
        }

        /// <summary> Specifies the network interfaces of the virtual machine. </summary>
        public NetworkProfile NetworkProfile
        {
            get => Model.NetworkProfile;
            set => Model.NetworkProfile = value;
        }

        /// <summary> Specifies the operating system settings used while creating the virtual machine. Some of the settings cannot be changed once VM is provisioned. </summary>
        public OSProfile OsProfile
        {
            get => Model.OsProfile;
            set => Model.OsProfile = value;
        }

        /// <summary> Specifies additional capabilities enabled or disabled on the virtual machine. </summary>
        public AdditionalCapabilities AdditionalCapabilities
        {
            get => Model.AdditionalCapabilities;
            set => Model.AdditionalCapabilities = value;
        }

        /// <summary> Specifies the storage settings for the virtual machine disks. </summary>
        public StorageProfile StorageProfile
        {
            get => Model.StorageProfile;
            set => Model.StorageProfile = value;
        }

        /// <summary> Specifies the hardware settings for the virtual machine. </summary>
        public HardwareProfile HardwareProfile
        {
            get => Model.HardwareProfile;
            set => Model.HardwareProfile = value;
        }

        /// <summary> The virtual machine zones. </summary>
        public IList<string> Zones
        {
            get => Model.Zones;
        }

        /// <summary> The identity of the virtual machine, if configured. </summary>
        public ResourceIdentity Identity
        {
            get => VmIdentityToIdentity(Model.Identity);
        }

        private ResourceIdentity VmIdentityToIdentity(VirtualMachineIdentity vmIdentity)
        {
            SystemAssignedIdentity systemAssignedIdentity = new SystemAssignedIdentity(new Guid(vmIdentity.TenantId), new Guid(vmIdentity.PrincipalId));
            var userAssignedIdentities = new Dictionary<ResourceGroupResourceIdentifier, UserAssignedIdentity>();
            if (vmIdentity.UserAssignedIdentities != null)
            {
                foreach (var entry in vmIdentity.UserAssignedIdentities)
                {
                    var resourceId = new ResourceGroupResourceIdentifier(entry.Key);
                    var userAssignedIdentity = new UserAssignedIdentity(new Guid(entry.Value.ClientId), new Guid(entry.Value.PrincipalId));
                    userAssignedIdentities[resourceId] = userAssignedIdentity;
                }
            }

            return new ResourceIdentity(systemAssignedIdentity, userAssignedIdentities);
        }

        /// <summary>
        /// Gets the virtual machine extensions.
        /// </summary>
        public IReadOnlyList<VirtualMachineExtension> Resources => Model.Resources;

        /// <summary> Specifies information about the marketplace image used to create the virtual machine. This element is only used for marketplace images. Before you can use a marketplace image from an API, you must enable the image for programmatic use.  In the Azure portal, find the marketplace image that you want to use and then click **Want to deploy programmatically, Get Started -&gt;**. Enter any required information and then click **Save**. </summary>
        public Azure.ResourceManager.Compute.Models.Plan Plan
        {
            get => Model.Plan;
            set => Model.Plan = value;
        }

        /// <summary> Specifies that the image or disk that is being used was licensed on-premises. This element is only used for images that contain the Windows Server operating system. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; Windows_Client &lt;br&gt;&lt;br&gt; Windows_Server &lt;br&gt;&lt;br&gt; If this element is included in a request for an update, the value must match the initial value. This value cannot be updated. &lt;br&gt;&lt;br&gt; For more information, see [Azure Hybrid Use Benefit for Windows Server](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-hybrid-use-benefit-licensing?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json) &lt;br&gt;&lt;br&gt; Minimum api-version: 2015-06-15. </summary>
        public string LicenseType
        {
            get => Model.LicenseType;
            set => Model.LicenseType = value;
        }

        /// <summary> Specifies the VM unique ID which is a 128-bits identifier that is encoded and stored in all Azure IaaS VMs SMBIOS and can be read using platform BIOS commands. </summary>
        public string VmId => Model.VmId;
    }
}
