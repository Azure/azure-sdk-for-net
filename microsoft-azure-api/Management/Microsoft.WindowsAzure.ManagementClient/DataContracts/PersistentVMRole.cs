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

        [DataMember(Order = 0, IsRequired=false, EmitDefaultValue=false)]
        public string AvailabilitySetName { get; private set; }

        [DataMember(Order = 1, IsRequired = false, EmitDefaultValue = false)]
        public DataVirtualHardDiskCollection DataVirtualHardDisks { get; private set; }

        [DataMember(Order = 2, IsRequired = false, EmitDefaultValue = false)]
        public OSVirtualHardDisk OSVirtualHardDisk { get; private set; }

        [DataMember(Order = 3, IsRequired = false, EmitDefaultValue = false)]
        public InstanceSize RoleSize { get; private set; }
    }
}
