// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTG9hZEJhbGFuY2VyUHJvYmVJbXBs
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Resource.Fluent.Core;
    using Models;
    using System.Collections.Generic;
    using Resource.Fluent.Core.ChildResourceActions;
    using Resource.Fluent;

    internal partial class LoadBalancerProbeImpl  :
        ChildResource<ProbeInner, LoadBalancerImpl, ILoadBalancer>,
        ILoadBalancerTcpProbe,
        LoadBalancerTcpProbe.Definition.IDefinition<LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>,
        LoadBalancerTcpProbe.UpdateDefinition.IUpdateDefinition<LoadBalancer.Update.IUpdate>,
        LoadBalancerTcpProbe.Update.IUpdate,
        ILoadBalancerHttpProbe,
        LoadBalancerHttpProbe.Definition.IDefinition<LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>,
        LoadBalancerHttpProbe.UpdateDefinition.IUpdateDefinition<LoadBalancer.Update.IUpdate>,
        LoadBalancerHttpProbe.Update.IUpdate
    {
        internal LoadBalancerProbeImpl (ProbeInner inner, LoadBalancerImpl parent) : base(inner, parent)
        {
        }

        ///GENMHASH:8C9CA8DCBA99337975C849D250F5CDBA:CD735CB21F06B6FCB31FB4DD288CB78E
        internal int IntervalInSeconds()
        {
            return (Inner.IntervalInSeconds.HasValue) ? Inner.IntervalInSeconds.Value : 0;
        }

        ///GENMHASH:BF1200B4E784F046AF04467F35BAC1C4:862EBACEFE3957DB1BC39C20E2DBEF46
        internal int Port()
        {
            return Inner.Port;
        }

        ///GENMHASH:697E5879EDE9EFEA39889351CBFB2225:C161E010112B932166BE53F219677ECE
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
        internal string Protocol()
        {
            return Inner.Protocol;
        }

        ///GENMHASH:CD9660909A783C7A19B69D9C4BEFDB0D:15B8E37173B939243D943218C9497C44
        internal string RequestPath()
        {
            return Inner.RequestPath;
        }

        ///GENMHASH:4EDB057B59A7F7BB0C722F8A1399C004:A2F94AF9792429D630DA94FCC75CFD8B
        internal IDictionary<string, ILoadBalancingRule> LoadBalancingRules ()
        {
            IDictionary<string, ILoadBalancingRule> rules = new SortedDictionary<string, ILoadBalancingRule>();
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
