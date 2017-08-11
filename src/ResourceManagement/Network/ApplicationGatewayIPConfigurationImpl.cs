// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using ApplicationGatewayIPConfiguration.Definition;
    using ApplicationGatewayIPConfiguration.UpdateDefinition;
    using Models;
    using ResourceManager.Fluent;
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// Implementation for ApplicationGatewayIPConfiguration.
    /// </summary>
    
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXBwbGljYXRpb25HYXRld2F5SVBDb25maWd1cmF0aW9uSW1wbA==
    internal partial class ApplicationGatewayIPConfigurationImpl :
        ChildResource<ApplicationGatewayIPConfigurationInner, ApplicationGatewayImpl, IApplicationGateway>,
        IApplicationGatewayIPConfiguration,
        IDefinition<ApplicationGateway.Definition.IWithCreate>,
        IUpdateDefinition<ApplicationGateway.Update.IUpdate>,
        ApplicationGatewayIPConfiguration.Update.IUpdate
    {
        
        ///GENMHASH:3F67D491EFF1C2D2F2A2A82BD90496E3:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal ApplicationGatewayIPConfigurationImpl(ApplicationGatewayIPConfigurationInner inner, ApplicationGatewayImpl parent) : base(inner, parent)
        {
        }

        #region Actions

        
        ///GENMHASH:777AE9B7CB4EA1B471FA1957A07DF81F:447635D831A0A80A464ADA6413BED58F
        public ISubnet GetSubnet()
        {
            return Parent.Manager.GetAssociatedSubnet(Inner.Subnet);
        }

        
        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:4174C1298FBF6ABE50F5AB6DA4F03B10
        public ApplicationGatewayImpl Attach()
        {
            return Parent.WithConfig(this);
        }

        #endregion

        #region Accessors

        ApplicationGateway.Update.IUpdate ISettable<ApplicationGateway.Update.IUpdate>.Parent()
        {
            return Parent;
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

        
        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
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

        #endregion

        #region Withers

        
        ///GENMHASH:EE79C3B68C4C6A99234BB004EDCAD67A:7289832C1662E22EA7E068290C483F1B
        public ApplicationGatewayIPConfigurationImpl WithExistingSubnet(ISubnet subnet)
        {
            return WithExistingSubnet(subnet.Parent.Id, subnet.Name);
        }

        
        ///GENMHASH:5647899224D30C7B5E1FDCD2D9AAB1DB:F08EFDCC8A8286B3C9226D19B2EA7889
        public ApplicationGatewayIPConfigurationImpl WithExistingSubnet(INetwork network, string subnetName)
        {
            return WithExistingSubnet(network.Id, subnetName);
        }

        
        ///GENMHASH:E8683B20FED733D23930E96CCD1EB0A2:B9B4B506ED0B45772F0E2468D5E88107
        public ApplicationGatewayIPConfigurationImpl WithExistingSubnet(string networkId, string subnetName)
        {
            var subnetRef = new SubResource()
            {
                Id = networkId + "/subnets/" + subnetName
            };

            Inner.Subnet = subnetRef;
            return this;
        }

        #endregion
    }
}
