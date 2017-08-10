// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Models;
    using ResourceManager.Fluent;
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// Implementation for LoadBalancerInboundNatPool.
    /// </summary>
    
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTG9hZEJhbGFuY2VySW5ib3VuZE5hdFBvb2xJbXBs
    internal partial class LoadBalancerInboundNatPoolImpl :
        ChildResource<InboundNatPoolInner, LoadBalancerImpl, ILoadBalancer>,
        ILoadBalancerInboundNatPool,
        LoadBalancerInboundNatPool.Definition.IDefinition<LoadBalancer.Definition.IWithCreateAndInboundNatPool>,
        LoadBalancerInboundNatPool.UpdateDefinition.IUpdateDefinition<LoadBalancer.Update.IUpdate>,
        LoadBalancerInboundNatPool.Update.IUpdate
    {
        
        ///GENMHASH:8B165FB10D00FDA08609F56F3BB16BB8:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal LoadBalancerInboundNatPoolImpl (InboundNatPoolInner inner, LoadBalancerImpl parent)
            : base(inner, parent)
        {
        }

        
        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
        }

        
        ///GENMHASH:D684E7477889A9013C81FAD82F69C54F:BD249A015EF71106387B78281489583A
        internal TransportProtocol Protocol()
        {
            return TransportProtocol.Parse(Inner.Protocol);
        }

        
        ///GENMHASH:B7056D5E403DF443379DDF57BB0658A2:E7591344CFEDC51C8E94CD9321660C74
        internal int BackendPort()
        {
            return Inner.BackendPort;
        }

        
        ///GENMHASH:B206A6556439FF2D98365C5283836AD5:7883B26044DD9E80AC6D8A9F847E6900
        internal ILoadBalancerFrontend Frontend ()
        {
            ILoadBalancerFrontend frontend;
            string name = ResourceUtils.NameFromResourceId(Inner.FrontendIPConfiguration.Id);
            Parent.Frontends().TryGetValue(name, out frontend);
            return frontend;
        }

        
        ///GENMHASH:2102448B6A6EA7F1973CA8DA21C276B3:C69FE1B9C4A435E89D7D136C58A54FEB
        internal int FrontendPortRangeStart()
        {
            return Inner.FrontendPortRangeStart;
        }

        
        ///GENMHASH:2878757D0F89ECB374D335D6532EDE05:934F312EF757F3FA57D2678CE8D679B9
        internal int FrontendPortRangeEnd()
        {
            return Inner.FrontendPortRangeEnd;
        }

        
        ///GENMHASH:8F944A7A767FBE2B46E3184BF5B97360:E66486C2053EF1D55C02E6EF2E4B2E42
        internal LoadBalancerInboundNatPoolImpl ToBackendPort(int port)
        {
            Inner.BackendPort = port;
            return this;
        }

        
        ///GENMHASH:475A4755B19EB893208FCC08E7664C5B:8E47A7551FAA8958BCB5314D0E665506
        internal LoadBalancerInboundNatPoolImpl WithProtocol(TransportProtocol protocol)
        {
            Inner.Protocol = protocol.ToString();
            return this;
        }

        
        ///GENMHASH:2D9662B3F1282EE75401F103D056E914:22A702C2907DEBB1DEFF4C61C1ADF17C
        internal LoadBalancerInboundNatPoolImpl FromFrontend(string frontendName)
        {
            SubResource frontendRef = new SubResource(Parent.FutureResourceId() + "/frontendIPConfigurations/" + frontendName);
            Inner.FrontendIPConfiguration = frontendRef;
            return this;
        }

        
        ///GENMHASH:A35BE32FA7E3E3B6830FC9FC8FEB749B:D8E7C90FCF82DEB3BE8CE74FBEB12F82
        internal LoadBalancerInboundNatPoolImpl FromFrontendPortRange(int from, int to)
        {
            Inner.FrontendPortRangeStart = from;
            Inner.FrontendPortRangeEnd = to;
            return this;
        }

        
        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:9F2023060E78B2CFF2E9C0B57FE36805
        internal LoadBalancerImpl Attach ()
        {
            return Parent.WithInboundNatPool(this);
        }

        LoadBalancer.Update.IUpdate ISettable<LoadBalancer.Update.IUpdate>.Parent()
        {
            return Parent;
        }

        
        ///GENMHASH:2E96099A7A467CF87865F3533CBDB32F:E43EAA0FF40B1EB92FF9CA531CE3334B
        internal LoadBalancerInboundNatPoolImpl FromNewPublicIPAddress()
        {
            string dnsLabel = SdkContext.RandomResourceName("fe", 20);
            return FromNewPublicIPAddress(dnsLabel);
        }

        
        ///GENMHASH:4F8AF5E60457FDACF0707ABBD081EACF:9D863DCE5EEA7214E8AFD3B3448DD802
        internal LoadBalancerInboundNatPoolImpl FromNewPublicIPAddress(ICreatable<IPublicIPAddress> pipDefinition)
        {
            string frontendName = SdkContext.RandomResourceName("fe", 20);
            Parent.WithNewPublicIPAddress(pipDefinition, frontendName);
            FromFrontend(frontendName);
            return this;
        }

        
        ///GENMHASH:231912283CEF63FBB9CE91CF555CD8FA:1AF279B8DF16DA46D565BBD15F5469E8
        internal LoadBalancerInboundNatPoolImpl FromNewPublicIPAddress(string leafDnsLabel)
        {
            string frontendName = SdkContext.RandomResourceName("fe", 20);
            Parent.WithNewPublicIPAddress(leafDnsLabel, frontendName);
            FromFrontend(frontendName);
            return this;
        }

        
        ///GENMHASH:C4F27E8BA611AC74764FA8A94C3DF2D1:4D37ED0FD97954A596B35E0ADDA4A684
        internal LoadBalancerInboundNatPoolImpl FromExistingPublicIPAddress(string resourceId)
        {
            return (null != resourceId) ? FromFrontend(Parent.EnsurePublicFrontendWithPip(resourceId).Name) : this;
        }

        
        ///GENMHASH:9B586EF5DD9ADE1279FCC07666652F54:23AD2163711B098A9F3D889DB9E53EF3
        internal LoadBalancerInboundNatPoolImpl FromExistingPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            return (publicIPAddress != null) ? FromExistingPublicIPAddress(publicIPAddress.Id) : this;
        }

        
        ///GENMHASH:9324AD10F20137C7B4A5F3C5B476CA6A:6BA1DB83FAA1442223CC13159CA8F7A7
        internal LoadBalancerInboundNatPoolImpl FromExistingSubnet(ISubnet subnet)
        {
            return (null != subnet)
                ? FromExistingSubnet(subnet.Parent.Id, subnet.Name)
                : this;
        }

        
        ///GENMHASH:90E5ACF853A52D9A53EBCA4AC7C4B888:0FD858F3A293F1C544665B2A4D42EF9F
        internal LoadBalancerInboundNatPoolImpl FromExistingSubnet(INetwork network, string subnetName)
        {
            return (null != network && null != subnetName)
                ? FromExistingSubnet(network.Id, subnetName)
                : this;
        }

        
        ///GENMHASH:C60D8F9466757FEBCFE50980D9C02838:37CE302E6C655B9B6D3C7054ECC43FE4
        internal LoadBalancerInboundNatPoolImpl FromExistingSubnet(string networkResourceId, string subnetName)
        {
            return (null != networkResourceId && null != subnetName)
                ? FromFrontend(Parent.EnsurePrivateFrontendWithSubnet(networkResourceId, subnetName).Name)
                : this;
        }
    }
}
