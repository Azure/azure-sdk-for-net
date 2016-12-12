// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTG9hZEJhbGFuY2VySW5ib3VuZE5hdFJ1bGVJbXBs
namespace Microsoft.Azure.Management.Network.Fluent
{

    using Models;
    using Resource.Fluent;
    using Resource.Fluent.Core;
    using Resource.Fluent.Core.ChildResourceActions;
    using LoadBalancerInboundNatRule.Definition;
    using LoadBalancerInboundNatRule.UpdateDefinition;
    using LoadBalancerInboundNatRule.Update;

    /// <summary>
    /// Implementation for IInboundNatRule.
    /// </summary>
    internal partial class LoadBalancerInboundNatRuleImpl  :
        ChildResource<InboundNatRuleInner, LoadBalancerImpl, ILoadBalancer>,
        ILoadBalancerInboundNatRule,
        IDefinition<LoadBalancer.Definition.IWithCreateAndInboundNatRule>,
        IUpdateDefinition<LoadBalancer.Update.IUpdate>,
        IUpdate
    {
        internal LoadBalancerInboundNatRuleImpl (InboundNatRuleInner inner, LoadBalancerImpl parent) 
            : base(inner, parent)
        {
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
        }

        ///GENMHASH:A04DB70162C9B77030D8C475F6838904:95D3F5CFE09B0E2E9B28D965A3849DF2
        internal string BackendNicIpConfigurationName()
        {
            var backendRef = Inner.BackendIPConfiguration;
            return (backendRef != null) ? backendRef.Id : null;
        }

        ///GENMHASH:B7056D5E403DF443379DDF57BB0658A2:351B0447D40855BF2C2A04E4C733F5D9
        internal int BackendPort()
        {
            return (Inner.BackendPort.HasValue) ? Inner.BackendPort.Value : 0;
        }

        ///GENMHASH:1E1724F49386B38C4557AB9149CEB346:1BEBA13C1A163C64C4863B602DCEC4A7
        internal string BackendNetworkInterfaceId()
        {
            var backendRef = Inner.BackendIPConfiguration;
            return (backendRef != null) ? ResourceUtils.ParentResourcePathFromResourceId(backendRef.Id) : null;
        }

        ///GENMHASH:D684E7477889A9013C81FAD82F69C54F:BD249A015EF71106387B78281489583A
        internal string Protocol()
        {
            return Inner.Protocol;
        }

        ///GENMHASH:EB41BE025536B41812665B952EBF2040:319A4DEE75B5885594E0F7F65D52BE4C
        internal int FrontendPort()
        {
            return (Inner.FrontendPort.HasValue) ? Inner.FrontendPort.Value : 0;
        }

        ///GENMHASH:45270A04ADC0E66DC30D125EAFB21FCA:2B1E42135D8F461075F6C93109D81B1E
        internal bool FloatingIpEnabled()
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

        ///GENMHASH:D4505189DA8BE6159A0773DFA0AC5132:069B15B5D06A9F46C25E0C4E96ABB8F0
        internal int IdleTimeoutInMinutes()
        {
            return (Inner.IdleTimeoutInMinutes.HasValue) ? Inner.IdleTimeoutInMinutes.Value : 0;
        }

        ///GENMHASH:5FDFF29CFA414BCAD7FFD0841828BB7A:E66486C2053EF1D55C02E6EF2E4B2E42
        internal LoadBalancerInboundNatRuleImpl WithBackendPort (int port)
        {
            Inner.BackendPort = port;
            return this;
        }

        ///GENMHASH:B978A0452A50E17A6A319C98FF5CF3CB:4A97EF9CEF1AFD699FE25D0550B11E65
        internal LoadBalancerInboundNatRuleImpl WithFloatingIpEnabled ()
        {
            return WithFloatingIp(true);
        }

        ///GENMHASH:AEF33425EF146B710C33427451DF23D6:47CF63204E86A1051FFDA5F21A6961B2
        internal LoadBalancerInboundNatRuleImpl WithFloatingIpDisabled ()
        {
            return WithFloatingIp(false);
        }

        ///GENMHASH:3014A102DFC74C0A4BD328894DA72021:C6041F299FBFCE9AAD7D298C090F2168
        internal LoadBalancerInboundNatRuleImpl WithFloatingIp (bool enabled)
        {
            Inner.EnableFloatingIP = enabled;
            return this;
        }

        ///GENMHASH:1E7046ABBFA82B3370C0EE4358FCAAB3:3A9C28855748583C3C53EE7A5D64D465
        internal LoadBalancerInboundNatRuleImpl WithFrontendPort (int port)
        {
            Inner.FrontendPort = port;

            // By default, assume the same backend port
            return (BackendPort() == 0) ? WithBackendPort(port) : this;
        }

        ///GENMHASH:0268D4A22C553236F2D086625BC961C0:99F3B859668CAC9A1F4A84E29AE2E9C5
        internal LoadBalancerInboundNatRuleImpl WithIdleTimeoutInMinutes (int minutes)
        {
            Inner.IdleTimeoutInMinutes = minutes;
            return this;
        }

        ///GENMHASH:475A4755B19EB893208FCC08E7664C5B:8E47A7551FAA8958BCB5314D0E665506
        internal LoadBalancerInboundNatRuleImpl WithProtocol (TransportProtocol protocol)
        {
            Inner.Protocol = protocol.ToString();
            return this;
        }

        ///GENMHASH:2EC798C5560EA4F2234EFA1478E59C04:ED14BC5AA9F9F6F99EFCC8B58BEBAC1E
        internal LoadBalancerInboundNatRuleImpl WithFrontend (string frontendName)
        {
            string frontendId = Parent.FutureResourceId() + "/frontendIPConfigurations/" + frontendName;
            SubResource frontendRef = new SubResource(frontendId);
            Inner.FrontendIPConfiguration = frontendRef;
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
    }
}
