// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using System.Collections.Generic;
    using ResourceManager.Fluent.Core;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Linq;

    /// <summary>
    /// Implementation for Network
    /// </summary>
    
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTmV0d29ya0ltcGw=
    internal partial class NetworkImpl :
        GroupableParentResource<INetwork,
            VirtualNetworkInner,
            NetworkImpl,
            INetworkManager,
            Network.Definition.IWithGroup,
            Network.Definition.IWithCreate,
            Network.Definition.IWithCreate,
            Network.Update.IUpdate>,
        INetwork,
        Network.Definition.IDefinition,
        Network.Update.IUpdate
    {
        private Dictionary<string, ISubnet> subnets;
        
        ///GENMHASH:7BEA0E65533989105BEBCE9663A14E3A:3881994DCADCE14215F82F0CC81BDD88
        internal NetworkImpl(string name, VirtualNetworkInner innerModel, INetworkManager networkManager)
            : base(name, innerModel, networkManager)
        {
        }

        
        ///GENMHASH:6D9F740D6D73C56877B02D9F1C96F6E7:7D80D923C32722759F2DC956E9A32D71
        override protected void InitializeChildrenFromInner()
        {
            subnets = new Dictionary<string, ISubnet>();
            IList<SubnetInner> inners = Inner.Subnets;
            if (inners != null)
            {
                foreach (var inner in inners)
                {
                    SubnetImpl subnet = new SubnetImpl(inner, this);
                    subnets[inner.Name] = subnet;
                }
            }
        }

        
        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:D273A9F25EE8363ADDB7479305202A25
        protected override async Task<VirtualNetworkInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.VirtualNetworks.GetAsync(ResourceGroupName, Name, cancellationToken: cancellationToken);
        }

        
        ///GENMHASH:F792498DBF3C736E27E066C92C2E7F7A:129071765816A335066AAC27F7CCCEAD
        internal NetworkImpl WithSubnet(SubnetImpl subnet)
        {
            if (subnet != null)
            {
                subnets[subnet.Name()] = subnet;
            }
            return this;
        }

        
        ///GENMHASH:C46E686F6BFED9BDC32DE6EB942E24F4:5C325A68AD1779341F5DE4F1F9B669CB
        internal NetworkImpl WithDnsServer(string ipAddress)
        {
            if (Inner.DhcpOptions == null)
                Inner.DhcpOptions = new DhcpOptions();

            if (Inner.DhcpOptions.DnsServers == null)
                Inner.DhcpOptions.DnsServers = new List<string>();

            Inner.DhcpOptions.DnsServers.Add(ipAddress);
            return this;
        }

        
        ///GENMHASH:9047F7688B1B60794F60BC930616198C:5A25E7A3D3CA299925A5FF1DA732AFE4
        internal NetworkImpl WithSubnet(string name, string cidr)
        {
            return DefineSubnet(name)
                .WithAddressPrefix(cidr)
                .Attach();
        }

        
        ///GENMHASH:F6CBC7DFB0D824D353A7DFE6057B8612:8CF7AA492E5A9A8A95128893182A62A1
        internal NetworkImpl WithSubnets(IDictionary<string, string> nameCidrPairs)
        {
            subnets.Clear();
            foreach (var pair in nameCidrPairs)
            {
                WithSubnet(pair.Key, pair.Value);
            }
            return this;
        }

        
        ///GENMHASH:BCFE5A6437DFDD16AB17155407828358:D7A6E191BE445D616C7D7458438BA4AC
        internal NetworkImpl WithoutSubnet(string name)
        {
            subnets.Remove(name);
            return this;
        }

        
        ///GENMHASH:BF356D3C256200922092FDECCE2AEA83:2164178F2F2E4C2173DC1A4CB8E69169
        internal NetworkImpl WithAddressSpace(string cidr)
        {
            if (Inner.AddressSpace == null)
                Inner.AddressSpace = new AddressSpace();

            if (Inner.AddressSpace.AddressPrefixes == null)
                Inner.AddressSpace.AddressPrefixes = new List<string>();

            Inner.AddressSpace.AddressPrefixes.Add(cidr);
            return this;
        }

        
        ///GENMHASH:0A2FDD020AE5A41E49EC1B3AEB02B394:3B60772E45391CEB653A6108BC6868A5
        internal SubnetImpl DefineSubnet(string name)
        {
            SubnetInner inner = new SubnetInner(name: name);
            return new SubnetImpl(inner, this);
        }

        
        ///GENMHASH:0A630A9A81A6D7FB1D87E339FE830A51:FD878AA481D05018C98B67E014CFC475
        internal IReadOnlyList<string> AddressSpaces()
        {
            if (Inner.AddressSpace == null)
                return new List<string>();
            else if (Inner.AddressSpace.AddressPrefixes == null)
                return new List<string>();
            else
                return Inner.AddressSpace.AddressPrefixes?.ToList();
        }

        
        ///GENMHASH:286FDAB5963B6F7C00ABEDCF6FE545B5:6FEBAF2F043487BFE65A5D9D04AA1315
        internal IReadOnlyList<string> DnsServerIPs()
        {
            if (Inner.DhcpOptions == null)
                return new List<string>();
            else if (Inner.DhcpOptions.DnsServers == null)
                return new List<string>();
            else
                return Inner.DhcpOptions.DnsServers?.ToList();
        }

        
        ///GENMHASH:690E8F594CD13FA2074316AFD9B45928:8131F4AA7A989D064C8AB8B74BFCAD25
        internal IReadOnlyDictionary<string, ISubnet> Subnets()
        {
            return subnets;
        }

        
        ///GENMHASH:AC21A10EE2E745A89E94E447800452C1:E0C348C98FD0505C2908FDDC5F7096A1
        override protected void BeforeCreating()
        {
            // Ensure address spaces
            if (AddressSpaces().Count == 0)
            {
                WithAddressSpace("10.0.0.0/16"); // Default address space
            }

            if (IsInCreateMode)
            {
                // Create a subnet as needed, covering the entire first address space
                if (subnets.Count == 0)
                {
                    WithSubnet("subnet1", AddressSpaces()[0]);
                }
            }

            // Reset and update subnets
            Inner.Subnets = InnersFromWrappers<SubnetInner, ISubnet>(subnets.Values);
        }

        
        ///GENMHASH:F91F57741BB7E185BF012523964DEED0:B855D73B977281A4DC1F154F5A7D4DC5
        protected override void AfterCreating()
        {
            InitializeChildrenFromInner();
        }

        
        ///GENMHASH:073D775B4A47FA2FF6211510FDF879F4:D226D5E398319C2E7C55CCC94D6E4793
        internal SubnetImpl UpdateSubnet(string name)
        {
            ISubnet subnet;
            subnets.TryGetValue(name, out subnet);
            return (SubnetImpl)subnet;
        }

        
        ///GENMHASH:359B78C1848B4A526D723F29D8C8C558:A394B5B2A4C946983BF7F8DE2DAA697E
        protected async override Task<VirtualNetworkInner> CreateInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.VirtualNetworks.CreateOrUpdateAsync(ResourceGroupName, Name, Inner, cancellationToken);
        }
    }
}
