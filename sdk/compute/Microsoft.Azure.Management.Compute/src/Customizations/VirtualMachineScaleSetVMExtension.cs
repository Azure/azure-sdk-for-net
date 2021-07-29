namespace Microsoft.Azure.Management.Compute.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Describes a VMSS VM Extension.
    /// </summary>
    public partial class VirtualMachineScaleSetVMExtension : SubResourceReadOnly
    {
        public VirtualMachineScaleSetVMExtension(string id = default(string), string name = default(string), string type = default(string), string forceUpdateTag = default(string), string publisher = default(string), string type1 = default(string), string typeHandlerVersion = default(string), bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), object settings = default(object), object protectedSettings = default(object), string provisioningState = default(string), VirtualMachineExtensionInstanceView instanceView = default(VirtualMachineExtensionInstanceView))
            : base(id)
        {
            Name = name;
            Type = type;
            ForceUpdateTag = forceUpdateTag;
            Publisher = publisher;
            Type1 = type1;
            TypeHandlerVersion = typeHandlerVersion;
            AutoUpgradeMinorVersion = autoUpgradeMinorVersion;
            EnableAutomaticUpgrade = enableAutomaticUpgrade;
            Settings = settings;
            ProtectedSettings = protectedSettings;
            ProvisioningState = provisioningState;
            InstanceView = instanceView;
            CustomInit();
        }
        public VirtualMachineScaleSetVMExtension(string id = default(string), string name = default(string), string type = default(string), string forceUpdateTag = default(string), string publisher = default(string), string type1 = default(string), string typeHandlerVersion = default(string), bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), object settings = default(object), object protectedSettings = default(object), string provisioningState = default(string))
            : base(id)
        {
            Name = name;
            Type = type;
            ForceUpdateTag = forceUpdateTag;
            Publisher = publisher;
            Type1 = type1;
            TypeHandlerVersion = typeHandlerVersion;
            AutoUpgradeMinorVersion = autoUpgradeMinorVersion;
            EnableAutomaticUpgrade = enableAutomaticUpgrade;
            Settings = settings;
            ProtectedSettings = protectedSettings;
            ProvisioningState = provisioningState;
            CustomInit();
        }
        public VirtualMachineScaleSetVMExtension(string id = default(string), string name = default(string), string type = default(string), string forceUpdateTag = default(string), string publisher = default(string), string type1 = default(string), string typeHandlerVersion = default(string), bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), object settings = default(object), object protectedSettings = default(object))
             : base(id)
        {
            Name = name;
            Type = type;
            ForceUpdateTag = forceUpdateTag;
            Publisher = publisher;
            Type1 = type1;
            TypeHandlerVersion = typeHandlerVersion;
            AutoUpgradeMinorVersion = autoUpgradeMinorVersion;
            EnableAutomaticUpgrade = enableAutomaticUpgrade;
            Settings = settings;
            ProtectedSettings = protectedSettings;
            CustomInit();
        }
        public VirtualMachineScaleSetVMExtension(string id = default(string), string name = default(string), string type = default(string), string forceUpdateTag = default(string), string publisher = default(string), string type1 = default(string), string typeHandlerVersion = default(string), bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), object settings = default(object))
            : base(id)
        {
            Name = name;
            Type = type;
            ForceUpdateTag = forceUpdateTag;
            Publisher = publisher;
            Type1 = type1;
            TypeHandlerVersion = typeHandlerVersion;
            AutoUpgradeMinorVersion = autoUpgradeMinorVersion;
            EnableAutomaticUpgrade = enableAutomaticUpgrade;
            Settings = settings;
            CustomInit();
        }
    }
}