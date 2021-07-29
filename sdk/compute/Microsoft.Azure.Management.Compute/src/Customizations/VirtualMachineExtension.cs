namespace Microsoft.Azure.Management.Compute.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class VirtualMachineExtension : Resource
    {
        public VirtualMachineExtension(string location, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), string forceUpdateTag = default(string), string publisher = default(string), string virtualMachineExtensionType = default(string), string typeHandlerVersion = default(string), bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), object settings = default(object), object protectedSettings = default(object), string provisioningState = default(string), VirtualMachineExtensionInstanceView instanceView = default(VirtualMachineExtensionInstanceView))
            : base(location, id, name, type, tags)
        {
            ForceUpdateTag = forceUpdateTag;
            Publisher = publisher;
            VirtualMachineExtensionType = virtualMachineExtensionType;
            TypeHandlerVersion = typeHandlerVersion;
            AutoUpgradeMinorVersion = autoUpgradeMinorVersion;
            EnableAutomaticUpgrade = enableAutomaticUpgrade;
            Settings = settings;
            ProtectedSettings = protectedSettings;
            ProvisioningState = provisioningState;
            InstanceView = instanceView;
            CustomInit();
        }

        public VirtualMachineExtension(string location, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), string forceUpdateTag = default(string), string publisher = default(string), string virtualMachineExtensionType = default(string), string typeHandlerVersion = default(string), bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), object settings = default(object), object protectedSettings = default(object), string provisioningState = default(string))
            : base(location, id, name, type, tags)
        {
            ForceUpdateTag = forceUpdateTag;
            Publisher = publisher;
            VirtualMachineExtensionType = virtualMachineExtensionType;
            TypeHandlerVersion = typeHandlerVersion;
            AutoUpgradeMinorVersion = autoUpgradeMinorVersion;
            EnableAutomaticUpgrade = enableAutomaticUpgrade;
            Settings = settings;
            ProtectedSettings = protectedSettings;
            ProvisioningState = provisioningState;
            CustomInit();
        }

        public VirtualMachineExtension(string location, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), string forceUpdateTag = default(string), string publisher = default(string), string virtualMachineExtensionType = default(string), string typeHandlerVersion = default(string), bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), object settings = default(object), object protectedSettings = default(object))
            : base(location, id, name, type, tags)
        {
            ForceUpdateTag = forceUpdateTag;
            Publisher = publisher;
            VirtualMachineExtensionType = virtualMachineExtensionType;
            TypeHandlerVersion = typeHandlerVersion;
            AutoUpgradeMinorVersion = autoUpgradeMinorVersion;
            EnableAutomaticUpgrade = enableAutomaticUpgrade;
            Settings = settings;
            ProtectedSettings = protectedSettings;
            CustomInit();
        }

        public VirtualMachineExtension(string location, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), string forceUpdateTag = default(string), string publisher = default(string), string virtualMachineExtensionType = default(string), string typeHandlerVersion = default(string), bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), object settings = default(object))
            : base(location, id, name, type, tags)
        {
            ForceUpdateTag = forceUpdateTag;
            Publisher = publisher;
            VirtualMachineExtensionType = virtualMachineExtensionType;
            TypeHandlerVersion = typeHandlerVersion;
            AutoUpgradeMinorVersion = autoUpgradeMinorVersion;
            EnableAutomaticUpgrade = enableAutomaticUpgrade;
            Settings = settings;
            CustomInit();
        }
    }

}