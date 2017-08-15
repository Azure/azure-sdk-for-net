// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{

    using Models;
    using ResourceManager.Fluent;
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.ChildResourceActions;
    using LoadBalancerInboundNatRule.Definition;
    using LoadBalancerInboundNatRule.UpdateDefinition;
    using LoadBalancerInboundNatRule.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Implementation for IInboundNatRule.
    /// </summary>
    
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTG9hZEJhbGFuY2VySW5ib3VuZE5hdFJ1bGVJbXBs
    internal partial class LoadBalancerInboundNatRuleImpl :
        ChildResource<InboundNatRuleInner, LoadBalancerImpl, ILoadBalancer>,
        ILoadBalancerInboundNatRule,
        IDefinition<LoadBalancer.Definition.IWithCreateAndInboundNatRule>,
        IUpdateDefinition<LoadBalancer.Update.IUpdate>,
        IUpdate
    {
        
        ///GENMHASH:0247BE594FD61996B4DC82285FEB3F41:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal LoadBalancerInboundNatRuleImpl (InboundNatRuleInner inner, LoadBalancerImpl parent)
            : base(inner, parent)
        {
        }

        
        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
        }

        
        ///GENMHASH:3AE760873BE74E748FB229EE55DF8575:95D3F5CFE09B0E2E9B28D965A3849DF2
        internal string BackendNicIPConfigurationName()
        {
            var backendRef = Inner.BackendIPConfiguration;
            return (backendRef != null) ? ResourceUtils.NameFromResourceId(backendRef.Id) : null;
        }


        
        ///GENMHASH:B7056D5E403DF443379DDF57BB0658A2:E7591344CFEDC51C8E94CD9321660C74
        internal int BackendPort()
        {
            return (Inner.BackendPort.HasValue) ? Inner.BackendPort.Value : 0;
        }

        
        ///GENMHASH:1E1724F49386B38C4557AB9149CEB346:6F5B73524E5F4DCC4417F37C1DD049C3
        internal string BackendNetworkInterfaceId()
        {
            var backendRef = Inner.BackendIPConfiguration;
            return (backendRef != null) ? ResourceUtils.ParentResourcePathFromResourceId(backendRef.Id) : null;
        }

        
        ///GENMHASH:D684E7477889A9013C81FAD82F69C54F:BD249A015EF71106387B78281489583A
        internal TransportProtocol Protocol()
        {
            return TransportProtocol.Parse(Inner.Protocol);
        }

        
        ///GENMHASH:EB41BE025536B41812665B952EBF2040:2150178DD754E6A8F7ED8A5D0F550A32
        internal int FrontendPort()
        {
            return (Inner.FrontendPort.HasValue) ? Inner.FrontendPort.Value : 0;
        }

        
        ///GENMHASH:9F652E3014CFE19CAA0C6277DC482B28:2B1E42135D8F461075F6C93109D81B1E
        internal bool FloatingIPEnabled()
        {
            return (Inner.EnableFloatingIP.HasValue) ? Inner.EnableFloatingIP.Value : false;
        }

        
        ///GENMHASH:B206A6556439FF2D98365C5283836AD5:7883B26044DD9E80AC6D8A9F847E6900
        internal ILoadBalancerFrontend Frontend ()
        {
            var frontendRef = Inner.FrontendIPConfiguration;
            if (frontendRef == null)
            {
                return null;
            }
            else
            {
                string name = ResourceUtils.NameFromResourceId(frontendRef.Id);
                ILoadBalancerFrontend frontend;
                Parent.Frontends().TryGetValue(name, out frontend);
                return frontend;
            }
        }

        
        ///GENMHASH:D4505189DA8BE6159A0773DFA0AC5132:A12F20EDB49307C5BFD8B28E927C67DA
        internal int IdleTimeoutInMinutes()
        {
            return (Inner.IdleTimeoutInMinutes.HasValue) ? Inner.IdleTimeoutInMinutes.Value : 0;
        }

        
        ///GENMHASH:8F944A7A767FBE2B46E3184BF5B97360:E66486C2053EF1D55C02E6EF2E4B2E42
        internal LoadBalancerInboundNatRuleImpl ToBackendPort(int port)
        {
            Inner.BackendPort = port;
            return this;
        }


        
        ///GENMHASH:3B4F947690520A9551E547EA075C7B8D:EC0638BD2287003D415FE189FCA7BFEF
        internal LoadBalancerInboundNatRuleImpl WithFloatingIPEnabled()
        {
            return WithFloatingIP(true);
        }

        
        ///GENMHASH:E92525FEF2FA127571C46DB9C2932FDF:C173183A83601D48097DC0A45D5219A9
        internal LoadBalancerInboundNatRuleImpl WithFloatingIPDisabled()
        {
            return WithFloatingIP(false);
        }

        
        ///GENMHASH:5008B0B94EBDA5778628983D2D2E26A8:C6041F299FBFCE9AAD7D298C090F2168
        internal LoadBalancerInboundNatRuleImpl WithFloatingIP(bool enabled)
        {
            Inner.EnableFloatingIP = enabled;
            return this;
        }

        
        ///GENMHASH:28BE1E1B1E22EAC47BEE4F62DA30BAA5:9A8039E8CC75D0F91AD3B37E67C058A0
        internal LoadBalancerInboundNatRuleImpl FromFrontendPort(int port)
        {
            Inner.FrontendPort = port;

            // By default, assume the same backend port
            return (BackendPort() == 0) ? ToBackendPort(port) : this;
        }

        
        ///GENMHASH:0268D4A22C553236F2D086625BC961C0:99F3B859668CAC9A1F4A84E29AE2E9C5
        internal LoadBalancerInboundNatRuleImpl WithIdleTimeoutInMinutes (int minutes)
        {
            Inner.IdleTimeoutInMinutes = minutes;
            return this;
        }

        
        ///GENMHASH:475A4755B19EB893208FCC08E7664C5B:8E47A7551FAA8958BCB5314D0E665506
        internal LoadBalancerInboundNatRuleImpl WithProtocol(TransportProtocol protocol)
        {
            Inner.Protocol = protocol.ToString();
            return this;
        }

        
        ///GENMHASH:2D9662B3F1282EE75401F103D056E914:22A702C2907DEBB1DEFF4C61C1ADF17C
        internal LoadBalancerInboundNatRuleImpl FromFrontend(string frontendName)
        {
            var frontendRef = Parent.EnsureFrontendRef(frontendName);
            if (frontendRef != null)
            {
                Inner.FrontendIPConfiguration = frontendRef;
            }

            return this;
        }


        
        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:AE6D0A410FDC2FD1926B3D6450E25FAB
        internal LoadBalancerImpl Attach ()
        {
            return Parent.WithInboundNatRule(this);
        }

        LoadBalancer.Update.IUpdate ISettable<LoadBalancer.Update.IUpdate>.Parent()
        {
            return Parent;
        }

        
        ///GENMHASH:2E96099A7A467CF87865F3533CBDB32F:E43EAA0FF40B1EB92FF9CA531CE3334B
        internal LoadBalancerInboundNatRuleImpl FromNewPublicIPAddress()
        {
            string dnsLabel = SdkContext.RandomResourceName("fe", 20);
            return FromNewPublicIPAddress(dnsLabel);
        }

        
        ///GENMHASH:4F8AF5E60457FDACF0707ABBD081EACF:BB34114B12E158F7762684AAB656686B
        internal LoadBalancerInboundNatRuleImpl FromNewPublicIPAddress(ICreatable<IPublicIPAddress> pipDefinition)
        {
            string frontendName = SdkContext.RandomResourceName("fe", 20);
            Parent.WithNewPublicIPAddress(pipDefinition, frontendName);
            return FromFrontend(frontendName);
        }

        
        ///GENMHASH:231912283CEF63FBB9CE91CF555CD8FA:70F30E8379F2B602E1D713AD1CD4A187
        internal LoadBalancerInboundNatRuleImpl FromNewPublicIPAddress(string leafDnsLabel)
        {
            string frontendName = SdkContext.RandomResourceName("fe", 20);
            Parent.WithNewPublicIPAddress(leafDnsLabel, frontendName);
            return FromFrontend(frontendName);
        }

        
        ///GENMHASH:C4F27E8BA611AC74764FA8A94C3DF2D1:4D37ED0FD97954A596B35E0ADDA4A684
        internal LoadBalancerInboundNatRuleImpl FromExistingPublicIPAddress(string resourceId)
        {
            return (null != resourceId) ? FromFrontend(Parent.EnsurePublicFrontendWithPip(resourceId).Name) : this;
        }

        
        ///GENMHASH:9B586EF5DD9ADE1279FCC07666652F54:23AD2163711B098A9F3D889DB9E53EF3
        internal LoadBalancerInboundNatRuleImpl FromExistingPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            return (publicIPAddress != null) ? FromExistingPublicIPAddress(publicIPAddress.Id) : this;
        }

        
        ///GENMHASH:9324AD10F20137C7B4A5F3C5B476CA6A:6BA1DB83FAA1442223CC13159CA8F7A7
        internal LoadBalancerInboundNatRuleImpl FromExistingSubnet(ISubnet subnet)
        {
            return (null != subnet)
                ? FromExistingSubnet(subnet.Parent.Id, subnet.Name)
                : this;
        }

        
        ///GENMHASH:90E5ACF853A52D9A53EBCA4AC7C4B888:0FD858F3A293F1C544665B2A4D42EF9F
        internal LoadBalancerInboundNatRuleImpl FromExistingSubnet(INetwork network, string subnetName)
        {
            return (null != network && null != subnetName)
                ? FromExistingSubnet(network.Id, subnetName)
                : this;
        }

        
        ///GENMHASH:C60D8F9466757FEBCFE50980D9C02838:37CE302E6C655B9B6D3C7054ECC43FE4
        internal LoadBalancerInboundNatRuleImpl FromExistingSubnet(string networkResourceId, string subnetName)
        {
            return (null != networkResourceId && null != subnetName)
                ? FromFrontend(this.Parent.EnsurePrivateFrontendWithSubnet(networkResourceId, subnetName).Name)
                : this;
        }
    }
}
