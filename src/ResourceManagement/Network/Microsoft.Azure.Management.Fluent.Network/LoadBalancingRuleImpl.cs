// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Network
{
    using Management.Network.Models;
    using Resource.Core;
    using Resource.Core.ChildResourceActions;
    using Rest.Azure;

    public partial class LoadBalancingRuleImpl  :
        ChildResource<LoadBalancingRuleInner, LoadBalancerImpl, ILoadBalancer>,
        ILoadBalancingRule,
        LoadBalancingRule.Definition.IDefinition<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>,
        LoadBalancingRule.UpdateDefinition.IUpdateDefinition<LoadBalancer.Update.IUpdate>,
        LoadBalancingRule.Update.IUpdate
    {
        internal  LoadBalancingRuleImpl (LoadBalancingRuleInner inner, LoadBalancerImpl parent) : base(inner.Name, inner, parent)
        {
        }

        override public string Name()
        {
            return Inner.Name;
        }

        public string Protocol
        {
            get
            {
                return Inner.Protocol;
            }
        }

        public bool FloatingIpEnabled
        {
            get
            {
                return (Inner.EnableFloatingIP.HasValue) ? Inner.EnableFloatingIP.Value : false;
            }
        }

        public int IdleTimeoutInMinutes
        {
            get
            {
                return (Inner.IdleTimeoutInMinutes.HasValue) ? Inner.IdleTimeoutInMinutes.Value : 0;
            }
        }

        public int FrontendPort
        {
            get
            {
                return Inner.FrontendPort;
            }
        }

        public int BackendPort
        {
            get
            {
                return (Inner.BackendPort.HasValue) ? Inner.BackendPort.Value : 0;
            }
        }

        public string LoadDistribution
        {
            get
            {
                return Inner.LoadDistribution;
            }
        }

        public IFrontend Frontend ()
        {
            var frontendRef = Inner.FrontendIPConfiguration;
            if (frontendRef == null)
            {
                return null;
            }
            else
            {
                string frontendName = ResourceUtils.NameFromResourceId(frontendRef.Id);
                IFrontend frontend;
                Parent.Frontends().TryGetValue(frontendName, out frontend);
                return frontend;
            }
        }

        public IBackend Backend ()
        {
            var backendRef = Inner.BackendAddressPool;
            if (backendRef == null)
            {
                return null;
            }
            else
            {
                string backendName = ResourceUtils.NameFromResourceId(backendRef.Id);
                IBackend backend;
                Parent.Backends().TryGetValue(backendName, out backend);
                return backend;
            }
        }

        public IProbe Probe()
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

        public LoadBalancingRuleImpl WithIdleTimeoutInMinutes (int minutes)
        {
            Inner.IdleTimeoutInMinutes = minutes;
            return this;
        }

        public LoadBalancingRuleImpl WithFloatingIp (bool enable)
        {
            Inner.EnableFloatingIP = enable;
            return this;
        }

        public LoadBalancingRuleImpl WithFloatingIpEnabled ()
        {
            return WithFloatingIp(true);
        }

        public LoadBalancingRuleImpl WithFloatingIpDisabled ()
        {
            return WithFloatingIp(false);
        }

        public LoadBalancingRuleImpl WithProtocol (string protocol)
        {
            Inner.Protocol = protocol;
            return this;
        }

        public LoadBalancingRuleImpl WithFrontendPort (int port)
        {
            Inner.FrontendPort = port;

            // If backend port not specified earlier, make it the same as the frontend by default
            if (Inner.BackendPort == null || Inner.BackendPort == 0)
                Inner.BackendPort = port;
            return this;
        }

        public LoadBalancingRuleImpl WithBackendPort (int port)
        {
            Inner.BackendPort = port;
            return this;
        }

        public LoadBalancingRuleImpl WithLoadDistribution (string loadDistribution)
        {
            Inner.LoadDistribution = loadDistribution;
            return this;
        }

        public LoadBalancingRuleImpl WithFrontend (string frontendName)
        {
            string id = Parent.FutureResourceId + "/frontendIPConfigurations/" + frontendName;
            var frontendRef = new SubResource(id);
            Inner.FrontendIPConfiguration = frontendRef;
            return this;
        }

        public LoadBalancingRuleImpl WithBackend (string backendName)
        {
            string id = Parent.FutureResourceId + "/backendAddressPools/" + backendName;
            var backendRef = new SubResource(id);
            Inner.BackendAddressPool = backendRef;
            return this;
        }

        public LoadBalancingRuleImpl WithProbe (string name)
        {
            string id = Parent.FutureResourceId + "/probes/" + name;
            var probeRef = new SubResource(id);
            Inner.Probe = probeRef;
            return this;
        }

        public LoadBalancerImpl Attach ()
        {
            return Parent.WithLoadBalancingRule(this);
        }

        LoadBalancer.Update.IUpdate ISettable<LoadBalancer.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}