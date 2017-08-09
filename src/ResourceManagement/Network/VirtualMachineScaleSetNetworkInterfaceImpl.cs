// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using System;
    using System.Collections.Generic;
    using Models;
    using ResourceManager.Fluent.Core;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Linq;

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVTY2FsZVNldE5ldHdvcmtJbnRlcmZhY2VJbXBs
    internal partial class VirtualMachineScaleSetNetworkInterfaceImpl :
        ResourceBase<IVirtualMachineScaleSetNetworkInterface,
            NetworkInterfaceInner,
            VirtualMachineScaleSetNetworkInterfaceImpl,
            object,
            object,
            object>,
        IVirtualMachineScaleSetNetworkInterface
    {
        private INetworkManager networkManager;
        private string scaleSetName;
        private string resourceGroupName;

        ///GENMHASH:B6961E0C7CB3A9659DE0E1489F44A936:7F318EC07B9B39F28BFF2277E89C7E0E
        internal INetworkManager Manager()
        {
            return networkManager;
        }

        ///GENMHASH:58CB1E72215B0CE0B66E8501BD8CBEBE:439E0C2DF4933E12F325E65917F2747B
        internal VirtualMachineScaleSetNetworkInterfaceImpl(
            string name,
            string scaleSetName,
            string resourceGroupName,
            NetworkInterfaceInner innerObject,
            INetworkManager networkManager) : base(name, innerObject)
        {
            this.scaleSetName = scaleSetName;
            this.resourceGroupName = resourceGroupName;
            this.networkManager = networkManager;
        }

        
        ///GENMHASH:FC029B56426CB2BA739B4DBD40ECED47:38C266FAF73EE2B36653A8316233F345
        public bool IsAcceleratedNetworkingEnabled()
        {
            return (Inner.EnableAcceleratedNetworking.HasValue) ? Inner.EnableAcceleratedNetworking.Value : false;
        }

        ///GENMHASH:0BD4C4C178DAB2C4BDA6BE54D2B912D5:8574363DCCF2F083DA5ADD2B4079AAAA
        internal bool IsIPForwardingEnabled()
        {
            if (Inner.EnableIPForwarding.HasValue)
            {
                return Inner.EnableIPForwarding.Value;
            }
            return false;
        }

        ///GENMHASH:58FE825A07E34384FA845B00D2554839:C3490FB601F6C84962573C9CA536B1DE
        internal string MacAddress()
        {
            return Inner.MacAddress;
        }

        ///GENMHASH:349C4E09DD850CE224A3467EF70DD6FF:4162BFA327E930CD02DB573B2A10EF0C
        internal string InternalDnsNameLabel()
        {
            if (Inner.DnsSettings == null)
            {
                return null;
            }
            return Inner.DnsSettings.InternalDnsNameLabel;
        }

        ///GENMHASH:F024226BEBD3E09E89CF44CD0AC59AE1:BD59AC48573B4A3AAA33D4E1004B6A7C
        internal string InternalFqdn()
        {
            if (Inner.DnsSettings == null)
            {
                return null;
            }
            return Inner.DnsSettings.InternalFqdn;
        }

        ///GENMHASH:E0135EB00D1A398C77458FC7B4F10581:F7D108E5D4C7EEBDBAD8FC5EA4B98704
        internal string InternalDomainNameSuffix()
        {
            if (Inner.DnsSettings == null)
            {
                return null;
            }
            return Inner.DnsSettings.InternalDomainNameSuffix;
        }

        ///GENMHASH:B1AD13DA0902D51846B309BF1324B456:F69A44CB1446FB801558CF5F1266373A
        internal IReadOnlyList<string> DnsServers()
        {
            if (Inner.DnsSettings == null || Inner.DnsSettings.DnsServers == null)
            {
                return new List<string>();
            }
            return Inner.DnsSettings.DnsServers?.ToList();
        }

        ///GENMHASH:9647B31AF7C6E31D3F4BB97FF05EB53A:81711423A616C21FA22BBF43358C90A3
        internal IReadOnlyList<string> AppliedDnsServers()
        {
            if (Inner.DnsSettings == null || Inner.DnsSettings.AppliedDnsServers == null)
            {
                return new List<string>();
            }
            return Inner.DnsSettings.AppliedDnsServers?.ToList();
        }

        ///GENMHASH:2332F9479F460CE970138ADD35B5AF72:81DD338E367BE383AB07F90D379D4169
        internal string PrimaryPrivateIP()
        {
            IVirtualMachineScaleSetNicIPConfiguration primaryIPConfig = this.PrimaryIPConfiguration();
            if (primaryIPConfig == null)
            {
                return null;
            }
            return primaryIPConfig.PrivateIPAddress;
        }

        ///GENMHASH:35898863669BD2284D4018DCF2B2BA41:78EDBA70ED91E43FF49DED1F543F70A9
        internal IPAllocationMethod PrimaryPrivateIPAllocationMethod()
        {
            IVirtualMachineScaleSetNicIPConfiguration primaryIPConfig = this.PrimaryIPConfiguration();
            if (primaryIPConfig == null)
            {
                return null;
            }
            return primaryIPConfig.PrivateIPAllocationMethod;
        }

        ///GENMHASH:8535B0E23E6704558262509B5A55B45D:DC42EDDCD5DEDAB8530D71E520987309
        internal IReadOnlyDictionary<string, IVirtualMachineScaleSetNicIPConfiguration> IPConfigurations()
        {
            var inners = Inner.IpConfigurations;
            if (inners == null || inners.Count == 0)
            {
                return new Dictionary<string, IVirtualMachineScaleSetNicIPConfiguration>(); 
            }
            Dictionary<string, IVirtualMachineScaleSetNicIPConfiguration> nicIPConfigurations = new Dictionary<string, IVirtualMachineScaleSetNicIPConfiguration>();
            foreach (NetworkInterfaceIPConfigurationInner inner in inners)
            {
                VirtualMachineScaleSetNicIPConfigurationImpl nicIPConfiguration = new VirtualMachineScaleSetNicIPConfigurationImpl(inner, this, this.networkManager);
                nicIPConfigurations.Add(nicIPConfiguration.Name(), nicIPConfiguration);
            }
            return nicIPConfigurations;
        }

        ///GENMHASH:1A5C835DC24ABE531CD7B4E1F2C4F391:C8B43C460FF52E73ACCA0D7F7E5AEAF7
        internal IVirtualMachineScaleSetNicIPConfiguration PrimaryIPConfiguration()
        {
            foreach (var ipConfiguration in this.IPConfigurations().Values)
            {
                if (ipConfiguration.IsPrimary)
                {
                    return ipConfiguration;
                }
            }
            return null;
        }

        ///GENMHASH:A9777D8010E6AF7B603113E49858FE75:B0A9D91C2AB3F485D446C37381230468
        internal string NetworkSecurityGroupId()
        {
            if (Inner.NetworkSecurityGroup == null)
            {
                return null;
            }
            return Inner.NetworkSecurityGroup.Id;
        }

        ///GENMHASH:2E4015B29759BBD97527EBAE809B083C:C619F91ACE96093121F642E1C3407708
        internal INetworkSecurityGroup GetNetworkSecurityGroup()
        {
            var nsgId = this.NetworkSecurityGroupId();
            if (nsgId == null)
            {
                return null;
            }
            return networkManager
                .NetworkSecurityGroups
                .GetByResourceGroup(ResourceUtils.GroupFromResourceId(nsgId),
                    ResourceUtils.NameFromResourceId(nsgId));
        }

        ///GENMHASH:3E35FB42190F8D9DBB9DAD636FA3EDE3:47B189F9F04AB401E91BAD78BBA18F59
        internal string VirtualMachineId()
        {
            if (Inner.VirtualMachine == null)
            {
                return null;
            }
            return Inner.VirtualMachine.Id;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:F8B080FEED43CEE9F7A1003FB3C6B46C
        public override Task<IVirtualMachineScaleSetNetworkInterface> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // VMSS NIC is a read-only resource hence this operation is not supported.
            throw new NotSupportedException();
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:BFAD97EE50A0D70973FC60FEA6C5FD16
        protected override async Task<NetworkInterfaceInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager().Inner.NetworkInterfaces.GetVirtualMachineScaleSetNetworkInterfaceAsync(
                resourceGroupName,
                scaleSetName,
                ResourceUtils.NameFromResourceId(VirtualMachineId()),
                Name, cancellationToken: cancellationToken);
        }

    }
}
