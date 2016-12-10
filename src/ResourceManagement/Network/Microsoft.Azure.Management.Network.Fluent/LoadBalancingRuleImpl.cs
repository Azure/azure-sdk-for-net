// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTG9hZEJhbGFuY2luZ1J1bGVJbXBs
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Management.Network.Fluent.Models;
    using Resource.Fluent;
    using Resource.Fluent.Core;
    using Resource.Fluent.Core.ChildResourceActions;
    using Rest.Azure;

    internal partial class LoadBalancingRuleImpl  :
        ChildResource<LoadBalancingRuleInner, LoadBalancerImpl, ILoadBalancer>,
        ILoadBalancingRule,
        LoadBalancingRule.Definition.IDefinition<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>,
        LoadBalancingRule.UpdateDefinition.IUpdateDefinition<LoadBalancer.Update.IUpdate>,
        LoadBalancingRule.Update.IUpdate
    {
        internal  LoadBalancingRuleImpl (LoadBalancingRuleInner inner, LoadBalancerImpl parent) : base(inner, parent)
        {
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
        }

        ///GENMHASH:D684E7477889A9013C81FAD82F69C54F:BD249A015EF71106387B78281489583A
        internal string Protocol()
        {
            return Inner.Protocol;
        }

        ///GENMHASH:45270A04ADC0E66DC30D125EAFB21FCA:7680AC472EE8EF19A209F24A5D2933FC
        internal bool FloatingIpEnabled()
        {
            return (Inner.EnableFloatingIP.HasValue) ? Inner.EnableFloatingIP.Value : false;
        }

        ///GENMHASH:D4505189DA8BE6159A0773DFA0AC5132:069B15B5D06A9F46C25E0C4E96ABB8F0
        internal int IdleTimeoutInMinutes()
        {
            return (Inner.IdleTimeoutInMinutes.HasValue) ? Inner.IdleTimeoutInMinutes.Value : 0;
        }

        ///GENMHASH:EB41BE025536B41812665B952EBF2040:D3C9E7CC0C7A90E56C9D56A260B7E36C
        internal int FrontendPort()
        {
            return Inner.FrontendPort;
        }

        ///GENMHASH:B7056D5E403DF443379DDF57BB0658A2:4D7E221DCF74AB728326D011461F9634
        internal int BackendPort()
        {
            return (Inner.BackendPort.HasValue) ? Inner.BackendPort.Value : 0;
        }

        ///GENMHASH:178F3E3CE98D4024826A091913F44F62:266824FDF79AEA8AE608736C3BC62D2D
        internal string LoadDistribution()
        {
            return Inner.LoadDistribution;
        }

        ///GENMHASH:B206A6556439FF2D98365C5283836AD5:B2B11D940759A460CF199E58286B6C80
        internal ILoadBalancerFrontend Frontend ()
        {
            var frontendRef = Inner.FrontendIPConfiguration;
            if (frontendRef == null)
            {
                return null;
            }
            else
            {
                string frontendName = ResourceUtils.NameFromResourceId(frontendRef.Id);
                ILoadBalancerFrontend frontend;
                Parent.Frontends().TryGetValue(frontendName, out frontend);
                return frontend;
            }
        }

        ///GENMHASH:5AC5C38B890C28F2C14CCD5CC0A89B49:3605EA2807E96DCF6C63B3F614F14D30
        internal ILoadBalancerBackend Backend ()
        {
            var backendRef = Inner.BackendAddressPool;
            if (backendRef == null)
            {
                return null;
            }
            else
            {
                string backendName = ResourceUtils.NameFromResourceId(backendRef.Id);
                ILoadBalancerBackend backend;
                Parent.Backends().TryGetValue(backendName, out backend);
                return backend;
            }
        }

        ///GENMHASH:7C8DB8F49BE9ADE0ACDDE918992D9275:6F4F6D22CFFEC9A948037CC8D6D8F853
        internal ILoadBalancerProbe Probe()
        {
            var probeRef = Inner.Probe;
            if (probeRef == null)
            {
                return null;
            }
            else
            {
                string probeName = ResourceUtils.NameFromResourceId(probeRef.Id);
                if (Parent.HttpProbes().ContainsKey(probeName))
                    return Parent.HttpProbes()[probeName];
                else if (Parent.TcpProbes().ContainsKey(probeName))
                    return Parent.TcpProbes()[probeName];
                else
                    return null;
            }
        }

        ///GENMHASH:0268D4A22C553236F2D086625BC961C0:99F3B859668CAC9A1F4A84E29AE2E9C5
        internal LoadBalancingRuleImpl WithIdleTimeoutInMinutes (int minutes)
        {
            Inner.IdleTimeoutInMinutes = minutes;
            return this;
        }

        ///GENMHASH:3014A102DFC74C0A4BD328894DA72021:2B4C4FEA610F44C48737D2BD835C9215
        internal LoadBalancingRuleImpl WithFloatingIp (bool enable)
        {
            Inner.EnableFloatingIP = enable;
            return this;
        }

        ///GENMHASH:B978A0452A50E17A6A319C98FF5CF3CB:4A97EF9CEF1AFD699FE25D0550B11E65
        internal LoadBalancingRuleImpl WithFloatingIpEnabled ()
        {
            return WithFloatingIp(true);
        }

        ///GENMHASH:AEF33425EF146B710C33427451DF23D6:47CF63204E86A1051FFDA5F21A6961B2
        internal LoadBalancingRuleImpl WithFloatingIpDisabled ()
        {
            return WithFloatingIp(false);
        }

        ///GENMHASH:475A4755B19EB893208FCC08E7664C5B:8E47A7551FAA8958BCB5314D0E665506
        internal LoadBalancingRuleImpl WithProtocol (string protocol)
        {
            Inner.Protocol = protocol;
            return this;
        }

        ///GENMHASH:1E7046ABBFA82B3370C0EE4358FCAAB3:15BD61EDB6F86027B2F2493FC49E3B09
        internal LoadBalancingRuleImpl WithFrontendPort (int port)
        {
            Inner.FrontendPort = port;

            // If backend port not specified earlier, make it the same as the frontend by default
            if (Inner.BackendPort == null || Inner.BackendPort == 0)
                Inner.BackendPort = port;
            return this;
        }

        ///GENMHASH:5FDFF29CFA414BCAD7FFD0841828BB7A:E66486C2053EF1D55C02E6EF2E4B2E42
        internal LoadBalancingRuleImpl WithBackendPort (int port)
        {
            Inner.BackendPort = port;
            return this;
        }

        ///GENMHASH:129F1484DB6983FA49EB300EBE8BB614:4E4D7CE935C5CC210DA1EEB68CB3F817
        internal LoadBalancingRuleImpl WithLoadDistribution (string loadDistribution)
        {
            Inner.LoadDistribution = loadDistribution;
            return this;
        }

        ///GENMHASH:2EC798C5560EA4F2234EFA1478E59C04:ED14BC5AA9F9F6F99EFCC8B58BEBAC1E
        internal LoadBalancingRuleImpl WithFrontend (string frontendName)
        {
            string id = Parent.FutureResourceId() + "/frontendIPConfigurations/" + frontendName;
            var frontendRef = new SubResource(id);
            Inner.FrontendIPConfiguration = frontendRef;
            return this;
        }

        ///GENMHASH:DCB0A32868BBB29D8909408454B2DAB8:5FEC910778A52886686B73C348BB1289
        internal LoadBalancingRuleImpl WithBackend (string backendName)
        {
            string id = Parent.FutureResourceId() + "/backendAddressPools/" + backendName;
            var backendRef = new SubResource(id);
            Inner.BackendAddressPool = backendRef;
            return this;
        }

        ///GENMHASH:E0DC5F5C03382BBF3A0349BC91DDC14F:72B8E820BF588C1F0281826429B332D7
        internal LoadBalancingRuleImpl WithProbe (string name)
        {
            string id = Parent.FutureResourceId() + "/probes/" + name;
            var probeRef = new SubResource(id);
            Inner.Probe = probeRef;
            return this;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:0FEBCFDFA0A1C79D1AF4C74F9AFCFD8C
        internal LoadBalancerImpl Attach ()
        {
            return Parent.WithLoadBalancingRule(this);
        }

        LoadBalancer.Update.IUpdate ISettable<LoadBalancer.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}
