// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using ResourceManager.Fluent.Core;
    using Models;
    using System.Collections.Generic;
    using ResourceManager.Fluent.Core.ChildResourceActions;
    using ResourceManager.Fluent;
    
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTG9hZEJhbGFuY2VyUHJvYmVJbXBs
    internal partial class LoadBalancerProbeImpl :
        ChildResource<ProbeInner, LoadBalancerImpl, ILoadBalancer>,
        ILoadBalancerTcpProbe,
        LoadBalancerTcpProbe.Definition.IDefinition<LoadBalancer.Definition.IWithCreate>,
        LoadBalancerTcpProbe.UpdateDefinition.IUpdateDefinition<LoadBalancer.Update.IUpdate>,
        LoadBalancerTcpProbe.Update.IUpdate,
        ILoadBalancerHttpProbe,
        LoadBalancerHttpProbe.Definition.IDefinition<LoadBalancer.Definition.IWithCreate>,
        LoadBalancerHttpProbe.UpdateDefinition.IUpdateDefinition<LoadBalancer.Update.IUpdate>,
        LoadBalancerHttpProbe.Update.IUpdate
    {
        
        ///GENMHASH:10DF065A3AFBF3A48B39C711B19A71DB:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal LoadBalancerProbeImpl (ProbeInner inner, LoadBalancerImpl parent) : base(inner, parent)
        {
        }

        
        ///GENMHASH:8C9CA8DCBA99337975C849D250F5CDBA:623849181C184FE8B1B0D0B95891F044
        internal int IntervalInSeconds()
        {
            return (Inner.IntervalInSeconds.HasValue) ? Inner.IntervalInSeconds.Value : 0;
        }

        
        ///GENMHASH:BF1200B4E784F046AF04467F35BAC1C4:F0090A6ECB1B91C3BCFD966232A4C1D4
        internal int Port()
        {
            return Inner.Port;
        }

        
        ///GENMHASH:697E5879EDE9EFEA39889351CBFB2225:87AA991D2E429F5E9DF46FBEDEF21ECB
        internal int NumberOfProbes()
        {
            return (Inner.NumberOfProbes.HasValue) ? Inner.NumberOfProbes.Value : 0;
        }

        
        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
        }

        
        ///GENMHASH:D684E7477889A9013C81FAD82F69C54F:BD249A015EF71106387B78281489583A
        internal ProbeProtocol Protocol()
        {
            return ProbeProtocol.Parse(Inner.Protocol);
        }

        
        ///GENMHASH:CD9660909A783C7A19B69D9C4BEFDB0D:15B8E37173B939243D943218C9497C44
        internal string RequestPath()
        {
            return Inner.RequestPath;
        }

        
        ///GENMHASH:4EDB057B59A7F7BB0C722F8A1399C004:A2F94AF9792429D630DA94FCC75CFD8B
        internal IReadOnlyDictionary<string, ILoadBalancingRule> LoadBalancingRules ()
        {
            var rules = new Dictionary<string, ILoadBalancingRule>();
            if (Inner.LoadBalancingRules != null)
            {
                foreach (SubResource inner in Inner.LoadBalancingRules)
                {
                    string name = ResourceUtils.NameFromResourceId(inner.Id);
                    ILoadBalancingRule rule;
                    if (Parent.LoadBalancingRules().TryGetValue(name, out rule))
                    {
                        rules[name] = rule;
                    }
                }  
            }
            return rules;
        }

        
        ///GENMHASH:7884DB3A8071CC7B3FBB06615EBA996B:CA52EFCC70207EE737066999569A5D75
        internal LoadBalancerProbeImpl WithPort (int port)
        {
            Inner.Port = port;
            return this;
        }

        
        ///GENMHASH:E5040D5D566E64C5982966EEC7BD4A48:333B6A52178548189FEE7228FCD7E279
        internal LoadBalancerProbeImpl WithRequestPath (string requestPath)
        {
            Inner.RequestPath = requestPath;
            return this;
        }

        
        ///GENMHASH:21347502092D7D54D77A473F6F895F36:C91A276EBB597052EA561EA14B85148B
        internal LoadBalancerProbeImpl WithIntervalInSeconds (int seconds)
        {
            Inner.IntervalInSeconds = seconds;
            return this;
        }

        
        ///GENMHASH:DCA4C95FF3B426EF8B1D61F5343F1F48:BC7D00BB836A322EF71EAA7349A76B67
        internal LoadBalancerProbeImpl WithNumberOfProbes (int probes)
        {
            Inner.NumberOfProbes = probes;
            return this;
        }

        
        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:DC5402587DE18D89F2F72B8535043012
        internal LoadBalancerImpl Attach ()
        {
            return Parent.WithProbe(this);
        }

        LoadBalancer.Update.IUpdate ISettable<LoadBalancer.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}
