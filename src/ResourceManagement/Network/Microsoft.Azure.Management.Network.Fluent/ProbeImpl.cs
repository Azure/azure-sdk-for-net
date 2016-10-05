// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Resource.Fluent.Core;
    using Management.Network.Fluent.Models;
    using System.Collections.Generic;
    using Resource.Fluent.Core.ChildResourceActions;
    using Rest.Azure;

    public partial class ProbeImpl  :
        ChildResource<ProbeInner, LoadBalancerImpl, ILoadBalancer>,
        ITcpProbe,
        TcpProbe.Definition.IDefinition<LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>,
        TcpProbe.UpdateDefinition.IUpdateDefinition<LoadBalancer.Update.IUpdate>,
        TcpProbe.Update.IUpdate,
        IHttpProbe,
        HttpProbe.Definition.IDefinition<LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>,
        HttpProbe.UpdateDefinition.IUpdateDefinition<LoadBalancer.Update.IUpdate>,
        HttpProbe.Update.IUpdate
    {
        internal ProbeImpl (ProbeInner inner, LoadBalancerImpl parent) : base(inner, parent)
        {
        }

        internal int IntervalInSeconds()
        {
            return (Inner.IntervalInSeconds.HasValue) ? Inner.IntervalInSeconds.Value : 0;
        }

        internal int Port()
        {
            return Inner.Port;
        }

        internal int NumberOfProbes()
        {
            return (Inner.NumberOfProbes.HasValue) ? Inner.NumberOfProbes.Value : 0;
        }

        public override string Name()
        {
            return Inner.Name;
        }

        internal string Protocol()
        {
            return Inner.Protocol;
        }

        internal string RequestPath()
        {
            return Inner.RequestPath;
        }

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

        internal ProbeImpl WithPort (int port)
        {
            Inner.Port = port;
            return this;
        }

        internal ProbeImpl WithRequestPath (string requestPath)
        {
            Inner.RequestPath = requestPath;
            return this;
        }

        internal ProbeImpl WithIntervalInSeconds (int seconds)
        {
            Inner.IntervalInSeconds = seconds;
            return this;
        }

        internal ProbeImpl WithNumberOfProbes (int probes)
        {
            Inner.NumberOfProbes = probes;
            return this;
        }

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