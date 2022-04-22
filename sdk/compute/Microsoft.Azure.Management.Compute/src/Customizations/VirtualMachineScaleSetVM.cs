namespace Microsoft.Azure.Management.Compute.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Describes a virtual machine scale set virtual machine .
    /// </summary>
    public partial class VirtualMachineScaleSetVM : Resource
    {
        /// <summary>
        /// Initializes a new instance of the VirtualMachineScaleSetVM class.
        /// </summary>
        /// <param name="location">Resource location</param>
        /// <param name="id">Resource Id</param>
        /// <param name="name">Resource name</param>
        /// <param name="type">Resource type</param>
        /// <param name="tags">Resource tags</param>
        /// <param name="instanceId">The virtual machine instance ID.</param>
        /// <param name="sku">The virtual machine SKU.</param>
        /// <param name="latestModelApplied">Specifies whether the latest model
        /// has been applied to the virtual machine.</param>
        /// <param name="vmId">Azure VM unique ID.</param>
        /// <param name="instanceView">The virtual machine instance
        /// view.</param>
        /// <param name="hardwareProfile">Specifies the hardware settings for
        /// the virtual machine.</param>
        /// <param name="storageProfile">Specifies the storage settings for the
        /// virtual machine disks.</param>
        /// <param name="additionalCapabilities">Specifies additional
        /// capabilities enabled or disabled on the virtual machine in the
        /// scale set. For instance: whether the virtual machine has the
        /// capability to support attaching managed data disks with
        /// UltraSSD_LRS storage account type.</param>
        /// <param name="osProfile">Specifies the operating system settings for
        /// the virtual machine.</param>
        /// <param name="securityProfile">Specifies the Security related
        /// profile settings for the virtual machine.</param>
        /// <param name="networkProfile">Specifies the network interfaces of
        /// the virtual machine.</param>
        /// <param name="networkProfileConfiguration">Specifies the network
        /// profile configuration of the virtual machine.</param>
        /// <param name="diagnosticsProfile">Specifies the boot diagnostic
        /// settings state. &lt;br&gt;&lt;br&gt;Minimum api-version:
        /// 2015-06-15.</param>
        /// <param name="availabilitySet">Specifies information about the
        /// availability set that the virtual machine should be assigned to.
        /// Virtual machines specified in the same availability set are
        /// allocated to different nodes to maximize availability. For more
        /// information about availability sets, see [Availability sets
        /// overview](https://docs.microsoft.com/azure/virtual-machines/availability-set-overview).
        /// &lt;br&gt;&lt;br&gt; For more information on Azure planned
        /// maintenance, see [Maintenance and updates for Virtual Machines in
        /// Azure](https://docs.microsoft.com/azure/virtual-machines/maintenance-and-updates)
        /// &lt;br&gt;&lt;br&gt; Currently, a VM can only be added to
        /// availability set at creation time. An existing VM cannot be added
        /// to an availability set.</param>
        /// <param name="provisioningState">The provisioning state, which only
        /// appears in the response.</param>
        /// <param name="licenseType">Specifies that the image or disk that is
        /// being used was licensed on-premises. &lt;br&gt;&lt;br&gt; Possible
        /// values for Windows Server operating system are:
        /// &lt;br&gt;&lt;br&gt; Windows_Client &lt;br&gt;&lt;br&gt;
        /// Windows_Server &lt;br&gt;&lt;br&gt; Possible values for Linux
        /// Server operating system are: &lt;br&gt;&lt;br&gt; RHEL_BYOS (for
        /// RHEL) &lt;br&gt;&lt;br&gt; SLES_BYOS (for SUSE)
        /// &lt;br&gt;&lt;br&gt; For more information, see [Azure Hybrid Use
        /// Benefit for Windows
        /// Server](https://docs.microsoft.com/azure/virtual-machines/windows/hybrid-use-benefit-licensing)
        /// &lt;br&gt;&lt;br&gt; [Azure Hybrid Use Benefit for Linux
        /// Server](https://docs.microsoft.com/azure/virtual-machines/linux/azure-hybrid-benefit-linux)
        /// &lt;br&gt;&lt;br&gt; Minimum api-version: 2015-06-15</param>
        /// <param name="modelDefinitionApplied">Specifies whether the model
        /// applied to the virtual machine is the model of the virtual machine
        /// scale set or the customized model for the virtual machine.</param>
        /// <param name="protectionPolicy">Specifies the protection policy of
        /// the virtual machine.</param>
        /// <param name="plan">Specifies information about the marketplace
        /// image used to create the virtual machine. This element is only used
        /// for marketplace images. Before you can use a marketplace image from
        /// an API, you must enable the image for programmatic use.  In the
        /// Azure portal, find the marketplace image that you want to use and
        /// then click **Want to deploy programmatically, Get Started -&gt;**.
        /// Enter any required information and then click **Save**.</param>
        /// <param name="resources">The virtual machine child extension
        /// resources.</param>
        /// <param name="zones">The virtual machine zones.</param>
        public VirtualMachineScaleSetVM(string location, string id, string name, string type, IDictionary<string, string> tags, string instanceId, Sku sku, bool? latestModelApplied, string vmId, VirtualMachineScaleSetVMInstanceView instanceView, HardwareProfile hardwareProfile, StorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, OSProfile osProfile, SecurityProfile securityProfile, NetworkProfile networkProfile, VirtualMachineScaleSetVMNetworkProfileConfiguration networkProfileConfiguration, DiagnosticsProfile diagnosticsProfile, SubResource availabilitySet, string provisioningState, string licenseType, string modelDefinitionApplied, VirtualMachineScaleSetVMProtectionPolicy protectionPolicy, Plan plan, IList<VirtualMachineExtension> resources, IList<string> zones)
            : base(location, id, name, type, tags)
        {
            InstanceId = instanceId;
            Sku = sku;
            LatestModelApplied = latestModelApplied;
            VmId = vmId;
            InstanceView = instanceView;
            HardwareProfile = hardwareProfile;
            StorageProfile = storageProfile;
            AdditionalCapabilities = additionalCapabilities;
            OsProfile = osProfile;
            SecurityProfile = securityProfile;
            NetworkProfile = networkProfile;
            NetworkProfileConfiguration = networkProfileConfiguration;
            DiagnosticsProfile = diagnosticsProfile;
            AvailabilitySet = availabilitySet;
            ProvisioningState = provisioningState;
            LicenseType = licenseType;
            ModelDefinitionApplied = modelDefinitionApplied;
            ProtectionPolicy = protectionPolicy;
            Plan = plan;
            Resources = resources;
            Zones = zones;
            CustomInit();
        }
        
        
        public VirtualMachineScaleSetVM(string location, string id, string name, string type, IDictionary<string, string> tags, string instanceId, Sku sku, bool? latestModelApplied, string vmId, VirtualMachineScaleSetVMInstanceView instanceView, HardwareProfile hardwareProfile, StorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, OSProfile osProfile, SecurityProfile securityProfile, NetworkProfile networkProfile, VirtualMachineScaleSetVMNetworkProfileConfiguration networkProfileConfiguration, DiagnosticsProfile diagnosticsProfile, SubResource availabilitySet, string provisioningState, string licenseType, string modelDefinitionApplied, VirtualMachineScaleSetVMProtectionPolicy protectionPolicy, Plan plan, IList<VirtualMachineExtension> resources)
            : base(location, id, name, type, tags)
        {
            InstanceId = instanceId;
            Sku = sku;
            LatestModelApplied = latestModelApplied;
            VmId = vmId;
            InstanceView = instanceView;
            HardwareProfile = hardwareProfile;
            StorageProfile = storageProfile;
            AdditionalCapabilities = additionalCapabilities;
            OsProfile = osProfile;
            SecurityProfile = securityProfile;
            NetworkProfile = networkProfile;
            NetworkProfileConfiguration = networkProfileConfiguration;
            DiagnosticsProfile = diagnosticsProfile;
            AvailabilitySet = availabilitySet;
            ProvisioningState = provisioningState;
            LicenseType = licenseType;
            ModelDefinitionApplied = modelDefinitionApplied;
            ProtectionPolicy = protectionPolicy;
            Plan = plan;
            Resources = resources;
            CustomInit();
        }
        
        
        public VirtualMachineScaleSetVM(string location, string id, string name, string type, IDictionary<string, string> tags, string instanceId, Sku sku, bool? latestModelApplied, string vmId, VirtualMachineScaleSetVMInstanceView instanceView, HardwareProfile hardwareProfile, StorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, OSProfile osProfile, SecurityProfile securityProfile, NetworkProfile networkProfile, VirtualMachineScaleSetVMNetworkProfileConfiguration networkProfileConfiguration, DiagnosticsProfile diagnosticsProfile, SubResource availabilitySet, string provisioningState, string licenseType, string modelDefinitionApplied, VirtualMachineScaleSetVMProtectionPolicy protectionPolicy, Plan plan)
            : base(location, id, name, type, tags)
        {
            InstanceId = instanceId;
            Sku = sku;
            LatestModelApplied = latestModelApplied;
            VmId = vmId;
            InstanceView = instanceView;
            HardwareProfile = hardwareProfile;
            StorageProfile = storageProfile;
            AdditionalCapabilities = additionalCapabilities;
            OsProfile = osProfile;
            SecurityProfile = securityProfile;
            NetworkProfile = networkProfile;
            NetworkProfileConfiguration = networkProfileConfiguration;
            DiagnosticsProfile = diagnosticsProfile;
            AvailabilitySet = availabilitySet;
            ProvisioningState = provisioningState;
            LicenseType = licenseType;
            ModelDefinitionApplied = modelDefinitionApplied;
            ProtectionPolicy = protectionPolicy;
            Plan = plan;
            CustomInit();
        }
        
        
        public VirtualMachineScaleSetVM(string location, string id, string name, string type, IDictionary<string, string> tags, string instanceId, Sku sku, bool? latestModelApplied, string vmId, VirtualMachineScaleSetVMInstanceView instanceView, HardwareProfile hardwareProfile, StorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, OSProfile osProfile, SecurityProfile securityProfile, NetworkProfile networkProfile, VirtualMachineScaleSetVMNetworkProfileConfiguration networkProfileConfiguration, DiagnosticsProfile diagnosticsProfile, SubResource availabilitySet, string provisioningState, string licenseType, string modelDefinitionApplied, VirtualMachineScaleSetVMProtectionPolicy protectionPolicy)
            : base(location, id, name, type, tags)
        {
            InstanceId = instanceId;
            Sku = sku;
            LatestModelApplied = latestModelApplied;
            VmId = vmId;
            InstanceView = instanceView;
            HardwareProfile = hardwareProfile;
            StorageProfile = storageProfile;
            AdditionalCapabilities = additionalCapabilities;
            OsProfile = osProfile;
            SecurityProfile = securityProfile;
            NetworkProfile = networkProfile;
            NetworkProfileConfiguration = networkProfileConfiguration;
            DiagnosticsProfile = diagnosticsProfile;
            AvailabilitySet = availabilitySet;
            ProvisioningState = provisioningState;
            LicenseType = licenseType;
            ModelDefinitionApplied = modelDefinitionApplied;
            ProtectionPolicy = protectionPolicy;
            CustomInit();
        }
    }
    
}
