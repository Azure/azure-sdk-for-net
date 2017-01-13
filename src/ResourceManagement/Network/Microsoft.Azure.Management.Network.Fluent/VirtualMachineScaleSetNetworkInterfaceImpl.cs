// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Threading.Tasks;
    using System.Threading;

    internal partial class VirtualMachineScaleSetNetworkInterfaceImpl :
        ResourceBase<IVirtualMachineScaleSetNetworkInterface,
            NetworkInterfaceInner,
            VirtualMachineScaleSetNetworkInterfaceImpl,
            object,
            object,
            object>,
        IVirtualMachineScaleSetNetworkInterface
    {
        private INetworkInterfacesOperations client;
        private INetworkManager networkManager;
        private string scaleSetName;
        private string resourceGroupName;

        internal VirtualMachineScaleSetNetworkInterfaceImpl(string name,
                                                      string scaleSetName,
                                                      string resourceGroupName,
                                                      NetworkInterfaceInner innerObject,
                                                      INetworkInterfacesOperations client,
                                                      INetworkManager networkManager) : base(name, innerObject)
        {
            this.scaleSetName = scaleSetName;
            this.resourceGroupName = resourceGroupName;
            this.client = client;
            this.networkManager = networkManager;
        }

        internal bool IsIpForwardingEnabled()
        {
            if (Inner.EnableIPForwarding.HasValue)
            {
                return Inner.EnableIPForwarding.Value;
            }
            return false;
        }

        internal string MacAddress()
        {
            return Inner.MacAddress;
        }

        internal string InternalDnsNameLabel()
        {
            if (Inner.DnsSettings == null)
            {
                return null;
            }
            return Inner.DnsSettings.InternalDnsNameLabel;
        }

        internal string InternalFqdn()
        {
            if (Inner.DnsSettings == null)
            {
                return null;
            }
            return Inner.DnsSettings.InternalFqdn;
        }

        internal string InternalDomainNameSuffix()
        {
            if (Inner.DnsSettings == null)
            {
                return null;
            }
            return Inner.DnsSettings.InternalDomainNameSuffix;
        }

        internal IList<string> DnsServers()
        {
            if (Inner.DnsSettings == null || Inner.DnsSettings.DnsServers == null)
            {
                return new List<string>();
            }
            return Inner.DnsSettings.DnsServers;
        }

        internal IList<string> AppliedDnsServers()
        {
            if (Inner.DnsSettings == null || Inner.DnsSettings.AppliedDnsServers == null)
            {
                return new List<string>();
            }
            return Inner.DnsSettings.AppliedDnsServers;
        }

        internal string PrimaryPrivateIp()
        {
            IVirtualMachineScaleSetNicIpConfiguration primaryIpConfig = this.PrimaryIpConfiguration();
            if (primaryIpConfig == null)
            {
                return null;
            }
            return primaryIpConfig.PrivateIpAddress;
        }

        internal IPAllocationMethod PrimaryPrivateIpAllocationMethod()
        {
            IVirtualMachineScaleSetNicIpConfiguration primaryIpConfig = this.PrimaryIpConfiguration();
            if (primaryIpConfig == null)
            {
                return null;
            }
            return primaryIpConfig.PrivateIpAllocationMethod;
        }

        internal IReadOnlyDictionary<string, IVirtualMachineScaleSetNicIpConfiguration> IpConfigurations()
        {
            var inners = this.Inner.IpConfigurations;
            if (inners == null || inners.Count == 0)
            {
                return new Dictionary<string, IVirtualMachineScaleSetNicIpConfiguration>(); 
            }
            Dictionary<string, IVirtualMachineScaleSetNicIpConfiguration> nicIpConfigurations = new Dictionary<string, IVirtualMachineScaleSetNicIpConfiguration>();
            foreach (NetworkInterfaceIPConfigurationInner inner in inners)
            {
                VirtualMachineScaleSetNicIpConfigurationImpl nicIpConfiguration = new VirtualMachineScaleSetNicIpConfigurationImpl(inner, this, this.networkManager);
                nicIpConfigurations.Add(nicIpConfiguration.Name(), nicIpConfiguration);
            }
            return nicIpConfigurations;
        }

        internal IVirtualMachineScaleSetNicIpConfiguration PrimaryIpConfiguration()
        {
            foreach (var ipConfiguration in this.IpConfigurations().Values)
            {
                if (ipConfiguration.IsPrimary)
                {
                    return ipConfiguration;
                }
            }
            return null;
        }

        internal string NetworkSecurityGroupId()
        {
            if (this.Inner.NetworkSecurityGroup == null)
            {
                return null;
            }
            return this.Inner.NetworkSecurityGroup.Id;
        }

        internal INetworkSecurityGroup GetNetworkSecurityGroup()
        {
            var nsgId = this.NetworkSecurityGroupId();
            if (nsgId == null)
            {
                return null;
            }
            return networkManager
                .NetworkSecurityGroups
                .GetByGroup(ResourceUtils.GroupFromResourceId(nsgId),
                    ResourceUtils.NameFromResourceId(nsgId));
        }

        internal string VirtualMachineId()
        {
            if (this.Inner.VirtualMachine == null)
            {
                return null;
            }
            return this.Inner.VirtualMachine.Id;
        }

        public override async Task<IVirtualMachineScaleSetNetworkInterface> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // VMSS NIC is a read-only resource hence this operation is not supported.
            throw new NotSupportedException();
        }

        override public IVirtualMachineScaleSetNetworkInterface Refresh()
        {
            this.SetInner(this.client.GetVirtualMachineScaleSetNetworkInterface(this.resourceGroupName,
                    this.scaleSetName,
                    ResourceUtils.NameFromResourceId(this.VirtualMachineId()),
                    this.Name));
            return this;
        }
    }
}
