using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Compute.Models
{

    public partial class VirtualMachineScaleSetVMExtensionUpdate : SubResourceReadOnly
    {
        public VirtualMachineScaleSetVMExtensionUpdate(string id = default(string), string name = default(string), string type = default(string), string forceUpdateTag = default(string), string publisher = default(string), string type1 = default(string), string typeHandlerVersion = default(string), bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), object settings = default(object), object protectedSettings = default(object), bool? suppressFailures = default(bool?), KeyVaultSecretReference protectedSettingsFromKeyVault = default(KeyVaultSecretReference))
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
            SuppressFailures = suppressFailures;
            ProtectedSettingsFromKeyVault = protectedSettingsFromKeyVault;
            CustomInit();
        }
    }
}
