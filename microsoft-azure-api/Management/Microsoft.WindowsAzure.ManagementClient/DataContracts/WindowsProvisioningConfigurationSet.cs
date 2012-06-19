using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// Represents the Windows provisioning configuration set.
    /// </summary>
    [DataContract(Name = "WindowsProvisioningConfigurationSet", Namespace = AzureConstants.AzureSchemaNamespace)]
    public sealed class WindowsProvisioningConfigurationSet : ProvisioningConfigurationSet
    {
        private WindowsProvisioningConfigurationSet() { }

        public string ComputerName { get; private set; }

        public string AdminPassword { get; private set; }

        public bool ResetPasswordOnFirstLogon { get; private set; }

        public bool EnableAutomaticUpdate { get; private set; }

        //TODO: TimeZoneInfo
        public string TimeZone { get; private set; }
    }
}
