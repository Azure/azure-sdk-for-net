// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using ApplicationGatewayFrontend.Definition;
    using ApplicationGatewayFrontend.UpdateDefinition;
    using Models;
    using Resource.Fluent;
    using Resource.Fluent.Core;
    using Resource.Fluent.Core.ChildResourceActions;

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

        ///GENMHASH:377296039E5241FB1B02988EFB811F77:EB7E862083A458D624358925C66523A7
        public IPublicIpAddress GetPublicIpAddress()
        {
            string pipId = PublicIpAddressId();
            if (pipId == null)
            {
                return null;
            }
            else
            {
                return Parent.Manager.PublicIpAddresses.GetById(pipId);
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

        ///GENMHASH:8E78B2392D3D6F9CD12A41F263DE68A1:E2FB3C470570EB032EC48D6BFD6A7AFF
        public string PublicIpAddressId()
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

        ///GENMHASH:8AA9D9D4B919CCB8947405FAA41035E2:516B6A004CB15A757AC222DE49CEC6EC
        public string PrivateIpAddress()
        {
            return Inner.PrivateIPAddress;
        }

        ///GENMHASH:26736A6ADD939D26955E1B3CFAB3B027:925E8594616C741FD699EF2269B3D731
        public IPAllocationMethod PrivateIpAllocationMethod()
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

        ///GENMHASH:E8683B20FED733D23930E96CCD1EB0A2:6BF6D743D6711AFFAF5F35FB435C360B
        public ApplicationGatewayFrontendImpl WithExistingSubnet(string parentNetworkResourceId, string subnetName)
        {
            var subnetRef = new SubResource()
            {
                Id = parentNetworkResourceId + "/subnets/" + subnetName
            };
            Inner.Subnet = subnetRef;

            // Ensure this frontend is not public
            WithoutPublicIpAddress();
            return this;
        }

        ///GENMHASH:6FE68F40574F5B84C669001E20CC658F:ACEAB57753CC554AC2DC8CB1B88AC346
        public ApplicationGatewayFrontendImpl WithExistingPublicIpAddress(IPublicIpAddress pip)
        {
            return WithExistingPublicIpAddress(pip.Id);
        }

        ///GENMHASH:DD83F863BB3E548AA6773EF2F2FDD700:488D62DEC18443445C34B6C753A0435A
        public ApplicationGatewayFrontendImpl WithExistingPublicIpAddress(string resourceId)
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

        public ApplicationGatewayFrontendImpl WithoutSubnet()
        {
            Inner.Subnet = null;
            Inner.PrivateIPAddress = null;
            Inner.PrivateIPAllocationMethod = null;
            return this;
        }

        ///GENMHASH:EA98B464B10BD645EE3B0689825B43B8:381025C979BFBD1E8A2299FD1136F281
        public ApplicationGatewayFrontendImpl WithPrivateIpAddressDynamic()
        {
            Inner.PrivateIPAddress = null;
            Inner.PrivateIPAllocationMethod = IPAllocationMethod.Dynamic.ToString();
            return this;
        }

        ///GENMHASH:6CDEF6BE4432158ED3F8917E000EAD56:9952D5FC5D28D16082887464EAAE7D3C
        public ApplicationGatewayFrontendImpl WithPrivateIpAddressStatic(string ipAddress)
        {
            Inner.PrivateIPAddress = ipAddress;
            Inner.PrivateIPAllocationMethod = IPAllocationMethod.Static.ToString();
            return this;
        }

        ///GENMHASH:1B49C92CBA9BDBBF9FBFD26544224384:2AADFAA8967336A82263A3FD701F270A
        public ApplicationGatewayFrontendImpl WithoutPublicIpAddress()
        {
            Inner.PublicIPAddress = null;
            return this;
        }

        #endregion
    }
}