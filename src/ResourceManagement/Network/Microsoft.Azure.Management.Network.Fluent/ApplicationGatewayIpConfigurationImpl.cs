// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using ApplicationGateway.Definition;
    using ApplicationGateway.Update;
    using ApplicationGatewayIpConfiguration.Definition;
    using ApplicationGatewayIpConfiguration.Update;
    using ApplicationGatewayIpConfiguration.UpdateDefinition;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.UpdateDefinition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using Resource.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// Implementation for ApplicationGatewayIpConfiguration.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXBwbGljYXRpb25HYXRld2F5SXBDb25maWd1cmF0aW9uSW1wbA==
    internal partial class ApplicationGatewayIpConfigurationImpl :
        ChildResource<Models.ApplicationGatewayIPConfigurationInner, Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayImpl, Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        IApplicationGatewayIpConfiguration,
        IDefinition<ApplicationGateway.Definition.IWithCreate>,
        IUpdateDefinition<ApplicationGateway.Update.IUpdate>,
        ApplicationGatewayIpConfiguration.Update.IUpdate
    {
        ///GENMHASH:777AE9B7CB4EA1B471FA1957A07DF81F:447635D831A0A80A464ADA6413BED58F
        public ISubnet GetSubnet()
        {
            //$ return this.Parent().Manager().GetAssociatedSubnet(this.Inner.Subnet());

            return null;
        }

        ///GENMHASH:309BFD95E2855ABD94CC4CEB845632F5:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal ApplicationGatewayIpConfigurationImpl(ApplicationGatewayIPConfigurationInner inner, ApplicationGatewayImpl parent) : base(inner, parent)
        {
            //$ super(inner, parent);
            //$ }

        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            //$ return this.Inner.Name();

            return null;
        }

        ///GENMHASH:1C444C90348D7064AB23705C542DDF18:7C10C7860B6E28E6D17CB999015864B9
        public string NetworkId()
        {
            //$ SubResource subnetRef = this.Inner.Subnet();
            //$ if (subnetRef != null) {
            //$ return ResourceUtils.ParentResourceIdFromResourceId(subnetRef.Id());
            //$ } else {
            //$ return null;
            //$ }

            return null;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:4174C1298FBF6ABE50F5AB6DA4F03B10
        public ApplicationGatewayImpl Attach()
        {
            //$ return this.Parent().WithConfig(this);

            return null;
        }

        ///GENMHASH:EE79C3B68C4C6A99234BB004EDCAD67A:7289832C1662E22EA7E068290C483F1B
        public ApplicationGatewayIpConfigurationImpl WithExistingSubnet(ISubnet subnet)
        {
            //$ return this.WithExistingSubnet(subnet.Parent().Id(), subnet.Name());

            return this;
        }

        ///GENMHASH:5647899224D30C7B5E1FDCD2D9AAB1DB:F08EFDCC8A8286B3C9226D19B2EA7889
        public ApplicationGatewayIpConfigurationImpl WithExistingSubnet(INetwork network, string subnetName)
        {
            //$ return this.WithExistingSubnet(network.Id(), subnetName);

            return this;
        }

        ///GENMHASH:E8683B20FED733D23930E96CCD1EB0A2:B9B4B506ED0B45772F0E2468D5E88107
        public ApplicationGatewayIpConfigurationImpl WithExistingSubnet(string networkId, string subnetName)
        {
            //$ SubResource subnetRef = new SubResource().WithId(networkId + "/subnets/" + subnetName);
            //$ this.Inner.WithSubnet(subnetRef);
            //$ return this;

            return this;
        }

        ///GENMHASH:C57133CD301470A479B3BA07CD283E86:AF6B5F15AE40A0AA08ADA331F3C75492
        public string SubnetName()
        {
            //$ SubResource subnetRef = this.Inner.Subnet();
            //$ if (subnetRef != null) {
            //$ return ResourceUtils.NameFromResourceId(subnetRef.Id());
            //$ } else {
            //$ return null;
            //$ }

            return null;
        }

        ApplicationGateway.Update.IUpdate ISettable<ApplicationGateway.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}