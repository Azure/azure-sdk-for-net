using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    //TODO: Fill this in and move to its own file...
    [DataContract(Name = "PersistentVMRole", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class PersistentVMRole : Role
    {
        private PersistentVMRole() { }
        
        //these constructors used for specifying roles for CreateVirtualMachineDeployment and AddVirtualMachineRole
        public PersistentVMRole(string name, ProvisioningConfigurationSet provisioningConfigurationSet, OSVirtualHardDisk osDisk,
                                NetworkConfigurationSet networkConfigurationSet = null, string availabilitySetName = null,
                                DataVirtualHardDiskCollection dataDisks = null, InstanceSize roleSize = InstanceSize.Small)
        {
            //TODO: Validate Params!
            this.Name = name;
            this.RoleType = "PersitentVMRole";
            this.ConfigurationSets = new List<ConfigurationSet>();
            this.ConfigurationSets.Add(provisioningConfigurationSet);
            if (networkConfigurationSet != null)
            {
                this.ConfigurationSets.Add(networkConfigurationSet);
            }

            this.OSVirtualHardDisk = osDisk;
            this.AvailabilitySetName = availabilitySetName;
            this.DataVirtualHardDisks = dataDisks;
            this.RoleSize = roleSize;
        }

        [DataMember(Order = 0, IsRequired=false, EmitDefaultValue=false)]
        public string AvailabilitySetName { get; private set; }

        [DataMember(Order = 1, IsRequired = false, EmitDefaultValue = false)]
        public DataVirtualHardDiskCollection DataVirtualHardDisks { get; private set; }

        [DataMember(Order = 2, IsRequired = true)]
        public OSVirtualHardDisk OSVirtualHardDisk { get; private set; }

        [DataMember(Order = 3, IsRequired = true)]
        public InstanceSize RoleSize { get; private set; }
    }
}
