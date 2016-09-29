// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{
    using Resource.Core;
    using Management.Network.Models;
    using System.Collections.Generic;
    using Resource.Core.ChildResourceActions;
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
        internal ProbeImpl (ProbeInner inner, LoadBalancerImpl parent) : base(inner.Name, inner, parent)
        {
        }

        public int IntervalInSeconds
        {
            get
            {
                return (Inner.IntervalInSeconds.HasValue) ? Inner.IntervalInSeconds.Value : 0;
            }
        }

        public int Port
        {
            get
            {
                return Inner.Port;
            }
        }

        public int NumberOfProbes
        {
            get
            {
                return (Inner.NumberOfProbes.HasValue) ? Inner.NumberOfProbes.Value : 0;
            }
        }

        override public string Name
        {
            get
            {
                return Inner.Name;
            }
        }

        public string Protocol
        {
            get
            {
                return Inner.Protocol;
            }
        }

        public string RequestPath
        {
            get
            {
                return Inner.RequestPath;
            }
        }
        public IDictionary<string, ILoadBalancingRule> LoadBalancingRules ()
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

        public ProbeImpl WithPort (int port)
        {
            Inner.Port = port;
            return this;
        }

        public ProbeImpl WithRequestPath (string requestPath)
        {
            Inner.RequestPath = requestPath;
            return this;
        }

        public ProbeImpl WithIntervalInSeconds (int seconds)
        {
            Inner.IntervalInSeconds = seconds;
            return this;
        }

        public ProbeImpl WithNumberOfProbes (int probes)
        {
            Inner.NumberOfProbes = probes;
            return this;
        }

        public LoadBalancerImpl Attach ()
        {
            return Parent.WithProbe(this);
        }

        LoadBalancer.Update.IUpdate ISettable<LoadBalancer.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}