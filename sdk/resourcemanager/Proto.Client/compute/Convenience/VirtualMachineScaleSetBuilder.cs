using Azure.ResourceManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Azure.ResourceManager.Compute.Models;

namespace Proto.Compute
{
    /// <summary>
    /// A class representing a builder object to help create a virtual machine.
    /// </summary>
    public partial class VirtualMachineScaleSetBuilder
    {
        public VirtualMachineScaleSetBuilder WithUseWindowsImage(string computerNamePrefix, string adminUser, string password)
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

        public VirtualMachineScaleSetBuilder WithUseLinuxImage(string computerNamePrefix, string adminUser, string password)
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

        public VirtualMachineScaleSetBuilder WithRequiredPrimaryNetworkInterface(
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

        public VirtualMachineScaleSetBuilder WithRequiredLoadBalancer(ResourceIdentifier asetResourceId)
        {
            return this;
        }
    }
}
