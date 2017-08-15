// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using ResourceManager.Fluent;
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.ChildResourceActions;
    using System.Collections.Generic;

    
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTG9hZEJhbGFuY2luZ1J1bGVJbXBs
    internal partial class LoadBalancingRuleImpl :
        ChildResource<LoadBalancingRuleInner, LoadBalancerImpl, ILoadBalancer>,
        ILoadBalancingRule,
        LoadBalancingRule.Definition.IDefinition<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>,
        LoadBalancingRule.UpdateDefinition.IUpdateDefinition<LoadBalancer.Update.IUpdate>,
        LoadBalancingRule.Update.IUpdate
    {
        
        ///GENMHASH:4C26D71C3924F5428C00A7BBACA72319:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal  LoadBalancingRuleImpl (LoadBalancingRuleInner inner, LoadBalancerImpl parent) : base(inner, parent)
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

        
        ///GENMHASH:D4505189DA8BE6159A0773DFA0AC5132:A12F20EDB49307C5BFD8B28E927C67DA
        internal int IdleTimeoutInMinutes()
        {
            return (Inner.IdleTimeoutInMinutes.HasValue) ? Inner.IdleTimeoutInMinutes.Value : 0;
        }

        
        ///GENMHASH:EB41BE025536B41812665B952EBF2040:2150178DD754E6A8F7ED8A5D0F550A32
        internal int FrontendPort()
        {
            return Inner.FrontendPort;
        }

        
        ///GENMHASH:B7056D5E403DF443379DDF57BB0658A2:E7591344CFEDC51C8E94CD9321660C74
        internal int BackendPort()
        {
            return (Inner.BackendPort.HasValue) ? Inner.BackendPort.Value : 0;
        }

        
        ///GENMHASH:178F3E3CE98D4024826A091913F44F62:266824FDF79AEA8AE608736C3BC62D2D
        internal LoadDistribution LoadDistribution()
        {
            return Models.LoadDistribution.Parse(Inner.LoadDistribution);
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

        
        ///GENMHASH:9F652E3014CFE19CAA0C6277DC482B28:7680AC472EE8EF19A209F24A5D2933FC
        internal bool FloatingIPEnabled()
        {
            return (Inner.EnableFloatingIP.HasValue) ? Inner.EnableFloatingIP.Value : false;
        }


        
        ///GENMHASH:3B4F947690520A9551E547EA075C7B8D:EC0638BD2287003D415FE189FCA7BFEF
        internal LoadBalancingRuleImpl WithFloatingIPEnabled()
        {
            return WithFloatingIP(true);
        }

        
        ///GENMHASH:5008B0B94EBDA5778628983D2D2E26A8:2B4C4FEA610F44C48737D2BD835C9215
        internal LoadBalancingRuleImpl WithFloatingIP(bool enable)
        {
            Inner.EnableFloatingIP = enable;
            return this;
        }

        
        ///GENMHASH:E92525FEF2FA127571C46DB9C2932FDF:C173183A83601D48097DC0A45D5219A9
        internal LoadBalancingRuleImpl WithFloatingIPDisabled()
        {
            return WithFloatingIP(false);
        }

        
        ///GENMHASH:475A4755B19EB893208FCC08E7664C5B:8E47A7551FAA8958BCB5314D0E665506
        internal LoadBalancingRuleImpl WithProtocol(TransportProtocol protocol)
        {
            Inner.Protocol = protocol.ToString();
            return this;
        }

        
        ///GENMHASH:28BE1E1B1E22EAC47BEE4F62DA30BAA5:15BD61EDB6F86027B2F2493FC49E3B09
        internal LoadBalancingRuleImpl FromFrontendPort(int port)
        {
            Inner.FrontendPort = port;

            // If backend port not specified earlier, make it the same as the frontend by default
            if (Inner.BackendPort == null || Inner.BackendPort == 0)
                Inner.BackendPort = port;
            return this;
        }

        
        ///GENMHASH:8F944A7A767FBE2B46E3184BF5B97360:E66486C2053EF1D55C02E6EF2E4B2E42
        internal LoadBalancingRuleImpl ToBackendPort(int port)
        {
            Inner.BackendPort = port;
            return this;
        }

        
        ///GENMHASH:129F1484DB6983FA49EB300EBE8BB614:4E4D7CE935C5CC210DA1EEB68CB3F817
        internal LoadBalancingRuleImpl WithLoadDistribution (LoadDistribution loadDistribution)
        {
            Inner.LoadDistribution = loadDistribution.ToString();
            return this;
        }

        
        ///GENMHASH:2D9662B3F1282EE75401F103D056E914:22A702C2907DEBB1DEFF4C61C1ADF17C
        internal LoadBalancingRuleImpl FromFrontend(string frontendName)
        {
            var frontendRef = Parent.EnsureFrontendRef(frontendName);
            if (frontendRef != null)
            {
                Inner.FrontendIPConfiguration = frontendRef;
            }
            return this;
        }

        
        ///GENMHASH:ABF006C723CD07B4C16642781DD352C1:4E18550AA333BF4FEAE4287DC243F553
        internal LoadBalancingRuleImpl ToBackend(string backendName)
        {
            // Ensure existence of backend, creating one if needed
            Parent.DefineBackend(backendName).Attach();
            var backendRef = new SubResource()
            {
                Id = Parent.FutureResourceId() + "/backendAddressPools/" + backendName
            };
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

        
        ///GENMHASH:C4F27E8BA611AC74764FA8A94C3DF2D1:4D37ED0FD97954A596B35E0ADDA4A684
        internal LoadBalancingRuleImpl FromExistingPublicIPAddress(string resourceId)
        {
            return (null != resourceId) ? FromFrontend(Parent.EnsurePublicFrontendWithPip(resourceId).Name) : this;
        }

        
        ///GENMHASH:9B586EF5DD9ADE1279FCC07666652F54:23AD2163711B098A9F3D889DB9E53EF3
        internal LoadBalancingRuleImpl FromExistingPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            return (publicIPAddress != null) ? FromExistingPublicIPAddress(publicIPAddress.Id) : this;
        }

        
        ///GENMHASH:9324AD10F20137C7B4A5F3C5B476CA6A:6BA1DB83FAA1442223CC13159CA8F7A7
        internal LoadBalancingRuleImpl FromExistingSubnet(ISubnet subnet)
        {
            return (null != subnet)
                ? FromExistingSubnet(subnet.Parent.Id, subnet.Name)
                : this;
        }

        
        ///GENMHASH:90E5ACF853A52D9A53EBCA4AC7C4B888:0FD858F3A293F1C544665B2A4D42EF9F
        internal LoadBalancingRuleImpl FromExistingSubnet(INetwork network, string subnetName)
        {
            return (null != network && null != subnetName)
                ? FromExistingSubnet(network.Id, subnetName)
                : this;
        }

        
        ///GENMHASH:C60D8F9466757FEBCFE50980D9C02838:37CE302E6C655B9B6D3C7054ECC43FE4
        internal LoadBalancingRuleImpl FromExistingSubnet(string networkResourceId, string subnetName)
        {
            return (null != networkResourceId && null != subnetName)
                ? FromFrontend(Parent.EnsurePrivateFrontendWithSubnet(networkResourceId, subnetName).Name)
                : this;
        }

        
        ///GENMHASH:A3D4AA91AD97459B1911D4F17C8B14E9:6DEA3BB2D6FE24C09ED19C8B27692A2B
        internal LoadBalancingRuleImpl WithoutProbe()
        {
            Inner.Probe = null;
            return this;
        }

        ///GENMHASH:3D6201D8512E926DE24BDD3371013D56:4399C247773D60DA9B23CE6E5C5DA798
        internal LoadBalancingRuleImpl ToExistingVirtualMachines(ICollection<IHasNetworkInterfaces> vms)
        {
            if (vms != null)
            {
                var backend = Parent.EnsureUniqueBackend().WithExistingVirtualMachines(vms);
                ToBackend(backend.Name());
            }
            return this;
        }

        
        ///GENMHASH:A06762F766078FF434814FFED75659E8:C13DCA96BEF632229189D513ADD0635F
        internal LoadBalancingRuleImpl ToExistingVirtualMachines(params IHasNetworkInterfaces[] vms)
        {
            return (vms != null) ? ToExistingVirtualMachines(new List<IHasNetworkInterfaces>(vms)) : this;
        }

        
        ///GENMHASH:2E96099A7A467CF87865F3533CBDB32F:E43EAA0FF40B1EB92FF9CA531CE3334B
        internal LoadBalancingRuleImpl FromNewPublicIPAddress()
        {
            string dnsLabel = SdkContext.RandomResourceName("fe", 20);
            return FromNewPublicIPAddress(dnsLabel);
        }

        
        ///GENMHASH:4F8AF5E60457FDACF0707ABBD081EACF:9D863DCE5EEA7214E8AFD3B3448DD802
        internal LoadBalancingRuleImpl FromNewPublicIPAddress(ICreatable<IPublicIPAddress> pipDefinition)
        {
            string frontendName = SdkContext.RandomResourceName("fe", 20);
            Parent.WithNewPublicIPAddress(pipDefinition, frontendName);
            return FromFrontend(frontendName);
        }

        
        ///GENMHASH:231912283CEF63FBB9CE91CF555CD8FA:1AF279B8DF16DA46D565BBD15F5469E8
        internal LoadBalancingRuleImpl FromNewPublicIPAddress(string leafDnsLabel)
        {
            string frontendName = SdkContext.RandomResourceName("fe", 20);
            Parent.WithNewPublicIPAddress(leafDnsLabel, frontendName);
            return FromFrontend(frontendName);
        }
    }
}
