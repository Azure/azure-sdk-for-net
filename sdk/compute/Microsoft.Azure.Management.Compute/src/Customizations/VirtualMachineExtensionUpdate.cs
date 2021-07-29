namespace Microsoft.Azure.Management.Compute.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Describes a Virtual Machine Extension.
    /// </summary>
    public partial class VirtualMachineExtensionUpdate : UpdateResource
    {
        public VirtualMachineExtensionUpdate(IDictionary<string, string> tags = default(IDictionary<string, string>), string forceUpdateTag = default(string), string publisher = default(string), string type = default(string), string typeHandlerVersion = default(string), bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), object settings = default(object), object protectedSettings = default(object))
            : base(tags)
        {
            ForceUpdateTag = forceUpdateTag;
            Publisher = publisher;
            Type = type;
            TypeHandlerVersion = typeHandlerVersion;
            AutoUpgradeMinorVersion = autoUpgradeMinorVersion;
            EnableAutomaticUpgrade = enableAutomaticUpgrade;
            Settings = settings;
            ProtectedSettings = protectedSettings;
            CustomInit();
        }

        public VirtualMachineExtensionUpdate(IDictionary<string, string> tags = default(IDictionary<string, string>), string forceUpdateTag = default(string), string publisher = default(string), string type = default(string), string typeHandlerVersion = default(string), bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), object settings = default(object))
            : base(tags)
        {
            ForceUpdateTag = forceUpdateTag;
            Publisher = publisher;
            Type = type;
            TypeHandlerVersion = typeHandlerVersion;
            AutoUpgradeMinorVersion = autoUpgradeMinorVersion;
            EnableAutomaticUpgrade = enableAutomaticUpgrade;
            Settings = settings;
            CustomInit();
        }
    }
}