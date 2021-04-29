using Azure.ResourceManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Azure.ResourceManager.Compute.Models;

namespace Proto.Compute.Convenience
{
    /// <summary>
    /// A class representing a builder object to help create a virtual machine.
    /// </summary>
    public class VirtualMachineScaleSetModelBuilder : VirtualMachineScaleSetModelBuilderBase
    {
        private VirtualMachineScaleSetData _model;

        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualMachineModelBuilder"/> class.
        /// </summary>
        /// <param name="containerOperations"> The container to create the virtual machine in. </param>
        /// <param name="model"> The data model representing the virtual machine to create. </param>
        public VirtualMachineScaleSetModelBuilder(VirtualMachineScaleSetContainer containerOperations, VirtualMachineScaleSetData model) 
            : base(containerOperations, model)
        {
            // TODO: GENERATOR Update Builder after models are incorporated in generated models
            _model = model;
        }

        public override VirtualMachineScaleSetModelBuilderBase WithUseWindowsImage(string computerNamePrefix, string adminUser, string password)
        {
            _model.VirtualMachineProfile.OsProfile = new VirtualMachineScaleSetOSProfile()
            {
                ComputerNamePrefix = computerNamePrefix,
                AdminUsername = adminUser,
                AdminPassword = password,
                WindowsConfiguration = new WindowsConfiguration { TimeZone = "Pacific Standard Time", ProvisionVMAgent = true }
            };

            return this;
        }

        public override VirtualMachineScaleSetModelBuilderBase WithUseLinuxImage(string computerNamePrefix, string adminUser, string password)
        {
            _model.VirtualMachineProfile.OsProfile = new VirtualMachineScaleSetOSProfile()
            {
                ComputerNamePrefix = computerNamePrefix,
                AdminUsername = adminUser,
                AdminPassword = password,
                LinuxConfiguration = new LinuxConfiguration
                {
                    DisablePasswordAuthentication = false,
                    ProvisionVMAgent = true
                }
            };

            return this;
        }

        public override VirtualMachineScaleSetModelBuilderBase WithRequiredPrimaryNetworkInterface(
            string name,
            ResourceIdentifier subNetResourceId,
            ICollection<ResourceIdentifier> backendAddressPoolResourceIds,
            ICollection<ResourceIdentifier> inboundNatPoolResourceIds)
        {
            var ipconfig = new VirtualMachineScaleSetIPConfiguration($"{name}PrimaryIPConfig")
            {
                Subnet = new ApiEntityReference() { Id = subNetResourceId },
            };
            foreach (var id in backendAddressPoolResourceIds)
            {
                ipconfig.LoadBalancerBackendAddressPools.Add(
                    new Azure.ResourceManager.Compute.Models.SubResource { Id = id });
            }
            foreach (var id in inboundNatPoolResourceIds)
            {
                ipconfig.LoadBalancerInboundNatPools.Add(
                    new Azure.ResourceManager.Compute.Models.SubResource { Id = id });
            }

            var nicConfig = new VirtualMachineScaleSetNetworkConfiguration(name)
            {
                Primary = true,
            };
            nicConfig.IpConfigurations.Add(ipconfig);

            _model.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations.Add(nicConfig);

            return this;
        }

        public override VirtualMachineScaleSetModelBuilderBase WithRequiredLoadBalancer(ResourceIdentifier asetResourceId)
        {
            return this;
        }
    }
}
