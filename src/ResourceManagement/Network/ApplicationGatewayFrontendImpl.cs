// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using ApplicationGatewayFrontend.Definition;
    using ApplicationGatewayFrontend.UpdateDefinition;
    using Models;
    using ResourceManager.Fluent;
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// Implementation for ApplicationGatewayFrontend.
    /// </summary>
    
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXBwbGljYXRpb25HYXRld2F5RnJvbnRlbmRJbXBs
    internal partial class ApplicationGatewayFrontendImpl :
        ChildResource<ApplicationGatewayFrontendIPConfigurationInner, ApplicationGatewayImpl, IApplicationGateway>,
        IApplicationGatewayFrontend,
        IDefinition<ApplicationGateway.Definition.IWithListener>,
        IUpdateDefinition<ApplicationGateway.Update.IUpdate>,
        ApplicationGatewayFrontend.Update.IUpdate
    {
        
        ///GENMHASH:6C169A817DC3F6F4927C26EB324FD8B5:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal ApplicationGatewayFrontendImpl(ApplicationGatewayFrontendIPConfigurationInner inner, ApplicationGatewayImpl parent) : base(inner, parent)
        {
        }

        #region Actions

        
        ///GENMHASH:166583FE514624A3D800151836CD57C1:CC312A186A3A88FA6CF6445A4520AE59
        public IPublicIPAddress GetPublicIPAddress()
        {
            string pipId = PublicIPAddressId();
            if (pipId == null)
            {
                return null;
            }
            else
            {
                return Parent.Manager.PublicIPAddresses.GetById(pipId);
            }
        }

        
        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:FE436520410AAD95E2287867567BC278
        public ApplicationGatewayImpl Attach()
        {
            return Parent.WithFrontend(this);
        }

        
        ///GENMHASH:777AE9B7CB4EA1B471FA1957A07DF81F:447635D831A0A80A464ADA6413BED58F
        public ISubnet GetSubnet()
        {
            return Parent.Manager.GetAssociatedSubnet(Inner.Subnet);
        }

        #endregion

        #region Accessors

        
        ///GENMHASH:6A7F875381DF37D9F784810F1A3E35BE:C4BB293D7BE83843DB9F85EA7205F9BB
        public bool IsPrivate()
        {
            return (Inner.Subnet != null);
        }

        
        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
        }

        
        ///GENMHASH:5EF934D4E2CF202DF23C026435D9F6D6:E2FB3C470570EB032EC48D6BFD6A7AFF
        public string PublicIPAddressId()
        {
            if (Inner.PublicIPAddress != null)
            {
                return Inner.PublicIPAddress.Id;
            }
            else
            {
                return null;
            }
        }

        
        ///GENMHASH:2911D7234EA1C2B2AC65B607D78B6E4A:38017BCE9C42CC6C34351378D14F8A09
        public bool IsPublic()
        {
            return (Inner.PublicIPAddress != null);
        }

        ApplicationGateway.Update.IUpdate ISettable<ApplicationGateway.Update.IUpdate>.Parent()
        {
            return Parent;
        }

        
        ///GENMHASH:1C444C90348D7064AB23705C542DDF18:7C10C7860B6E28E6D17CB999015864B9
        public string NetworkId()
        {
            var subnetRef = Inner.Subnet;
            if (subnetRef != null)
            {
                return ResourceUtils.ParentResourcePathFromResourceId(subnetRef.Id);
            }
            else
            {
                return null;
            }
        }

        
        ///GENMHASH:C57133CD301470A479B3BA07CD283E86:AF6B5F15AE40A0AA08ADA331F3C75492
        public string SubnetName()
        {
            var subnetRef = Inner.Subnet;
            if (subnetRef != null)
            {
                return ResourceUtils.NameFromResourceId(subnetRef.Id);
            }
            else
            {
                return null;
            }
        }

        
        ///GENMHASH:F4EEE08685E447AE7D2A8F7252EC223A:516B6A004CB15A757AC222DE49CEC6EC
        public string PrivateIPAddress()
        {
            return Inner.PrivateIPAddress;
        }

        
        ///GENMHASH:FCB784E90DCC27EAC6AD4B4C988E2752:925E8594616C741FD699EF2269B3D731
        public IPAllocationMethod PrivateIPAllocationMethod()
        {
            return IPAllocationMethod.Parse(Inner.PrivateIPAllocationMethod);
        }

        #endregion

        #region Withers

        
        ///GENMHASH:5647899224D30C7B5E1FDCD2D9AAB1DB:F08EFDCC8A8286B3C9226D19B2EA7889
        public ApplicationGatewayFrontendImpl WithExistingSubnet(INetwork network, string subnetName)
        {
            return WithExistingSubnet(network.Id, subnetName);
        }

        
        ///GENMHASH:E8683B20FED733D23930E96CCD1EB0A2:D46E32F223224E6AB5C12C956BB18C94
        public ApplicationGatewayFrontendImpl WithExistingSubnet(string parentNetworkResourceId, string subnetName)
        {
            var subnetRef = new SubResource()
            {
                Id = parentNetworkResourceId + "/subnets/" + subnetName
            };
            Inner.Subnet = subnetRef;

            // Ensure this frontend is not public
            WithoutPublicIPAddress();
            return this;
        }

        
        ///GENMHASH:BE684C4F4845D0C09A9399569DFB7A42:096D95C5168036459198B2B1F15EC515
        public ApplicationGatewayFrontendImpl WithExistingPublicIPAddress(IPublicIPAddress pip)
        {
            return WithExistingPublicIPAddress(pip.Id);
        }

        
        ///GENMHASH:3C078CA3D79C59C878B566E6BDD55B86:5185A4691911407C18CF3290890D0252
        public ApplicationGatewayFrontendImpl WithExistingPublicIPAddress(string resourceId)
        {
            var pipRef = new SubResource()
            {
                Id = resourceId
            };

            Inner.PublicIPAddress = pipRef;

            // Ensure no conflicting public and private settings
            WithoutSubnet();
            return this;
        }

        
        ///GENMHASH:A280AFBA3926E1E20A16C1DA07F8C6A3:144D0CF08C876F0017D38A9B294CEBC7
        public ApplicationGatewayFrontendImpl WithoutSubnet()
        {
            Inner.Subnet = null;
            Inner.PrivateIPAddress = null;
            Inner.PrivateIPAllocationMethod = null;
            return this;
        }

        
        ///GENMHASH:26224359DA104EABE1EDF7F491D110F7:381025C979BFBD1E8A2299FD1136F281
        public ApplicationGatewayFrontendImpl WithPrivateIPAddressDynamic()
        {
            Inner.PrivateIPAddress = null;
            Inner.PrivateIPAllocationMethod = IPAllocationMethod.Dynamic.ToString();
            return this;
        }

        
        ///GENMHASH:9946B3475EBD5468D4462F188EEE86C2:9952D5FC5D28D16082887464EAAE7D3C
        public ApplicationGatewayFrontendImpl WithPrivateIPAddressStatic(string ipAddress)
        {
            Inner.PrivateIPAddress = ipAddress;
            Inner.PrivateIPAllocationMethod = IPAllocationMethod.Static.ToString();
            return this;
        }

        
        ///GENMHASH:C4684C8A47F80967DA864E1AB75147B5:2AADFAA8967336A82263A3FD701F270A
        public ApplicationGatewayFrontendImpl WithoutPublicIPAddress()
        {
            Inner.PublicIPAddress = null;
            return this;
        }

        #endregion
    }
}
