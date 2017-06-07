using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    [DataContract(Name = "Deployment", Namespace = AzureConstants.AzureSchemaNamespace)]
    internal class CreateVirtualMachineDeploymentInfo : AzureDataContractBase
    {
        private CreateVirtualMachineDeploymentInfo() { }

        internal static CreateVirtualMachineDeploymentInfo Create(string deploymentName, string deploymentLabel, PersistentVMRole vmRole)
        {
            //TODO: Validate params
            return new CreateVirtualMachineDeploymentInfo
            {
                Name = deploymentName,
                Label = deploymentLabel.EncodeBase64(),
                RoleList = new List<Role> { vmRole },
                _deploymentSlot = DeploymentSlot.Production
            };
        }

        internal static CreateVirtualMachineDeploymentInfo Create(string deploymentName, string deploymentLabel, List<PersistentVMRole> vmRoles, string virtualNetworkName = null /*, DnsServerCollection dns = null*/)
        {
            //TODO: Validate params
            return new CreateVirtualMachineDeploymentInfo
            {
                Name = deploymentName,
                Label = deploymentLabel.EncodeBase64(),
                RoleList = new List<Role>(vmRoles),
                VirtualNetworkName = virtualNetworkName,
                _deploymentSlot = DeploymentSlot.Production
            };
            
        }

        [DataMember(Order=0, IsRequired=true)]
        internal string Name { get; private set; }

        [DataMember(Name="DeploymentSlot", Order=1, IsRequired=true)]
        private DeploymentSlot _deploymentSlot;

        [DataMember(Order=2, IsRequired=true)]
        internal string Label { get; private set; }

        [DataMember(Order=3, IsRequired=true)]
        internal List<Role> RoleList { get; private set; }

        [DataMember(Order=4, IsRequired=false, EmitDefaultValue=false)]
        internal string VirtualNetworkName { get; private set; }

        //TODO: Dns
    }
}
