// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Management.Network.Fluent.Models;
    using Resource.Fluent.Core;
    using Resource.Fluent.Core.ChildResourceActions;
    using Rest.Azure;

    public partial class LoadBalancingRuleImpl  :
        ChildResource<LoadBalancingRuleInner, LoadBalancerImpl, ILoadBalancer>,
        ILoadBalancingRule,
        LoadBalancingRule.Definition.IDefinition<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>,
        LoadBalancingRule.UpdateDefinition.IUpdateDefinition<LoadBalancer.Update.IUpdate>,
        LoadBalancingRule.Update.IUpdate
    {
        internal  LoadBalancingRuleImpl (LoadBalancingRuleInner inner, LoadBalancerImpl parent) : base(inner, parent)
        {
        }

        public override string Name()
        {
            return Inner.Name;
        }

        internal string Protocol()
        {
            return Inner.Protocol;
        }

        internal bool FloatingIpEnabled()
        {
            return (Inner.EnableFloatingIP.HasValue) ? Inner.EnableFloatingIP.Value : false;
        }

        internal int IdleTimeoutInMinutes()
        {
            return (Inner.IdleTimeoutInMinutes.HasValue) ? Inner.IdleTimeoutInMinutes.Value : 0;
        }

        internal int FrontendPort()
        {
            return Inner.FrontendPort;
        }

        internal int BackendPort()
        {
            return (Inner.BackendPort.HasValue) ? Inner.BackendPort.Value : 0;
        }

        internal string LoadDistribution()
        {
            return Inner.LoadDistribution;
        }

        internal IFrontend Frontend ()
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

        internal IBackend Backend ()
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

        internal IProbe Probe()
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

        internal LoadBalancingRuleImpl WithIdleTimeoutInMinutes (int minutes)
        {
            Inner.IdleTimeoutInMinutes = minutes;
            return this;
        }

        internal LoadBalancingRuleImpl WithFloatingIp (bool enable)
        {
            Inner.EnableFloatingIP = enable;
            return this;
        }

        internal LoadBalancingRuleImpl WithFloatingIpEnabled ()
        {
            return WithFloatingIp(true);
        }

        internal LoadBalancingRuleImpl WithFloatingIpDisabled ()
        {
            return WithFloatingIp(false);
        }

        internal LoadBalancingRuleImpl WithProtocol (string protocol)
        {
            Inner.Protocol = protocol;
            return this;
        }

        internal LoadBalancingRuleImpl WithFrontendPort (int port)
        {
            Inner.FrontendPort = port;

            // If backend port not specified earlier, make it the same as the frontend by default
            if (Inner.BackendPort == null || Inner.BackendPort == 0)
                Inner.BackendPort = port;
            return this;
        }

        internal LoadBalancingRuleImpl WithBackendPort (int port)
        {
            Inner.BackendPort = port;
            return this;
        }

        internal LoadBalancingRuleImpl WithLoadDistribution (string loadDistribution)
        {
            Inner.LoadDistribution = loadDistribution;
            return this;
        }

        internal LoadBalancingRuleImpl WithFrontend (string frontendName)
        {
            string id = Parent.FutureResourceId() + "/frontendIPConfigurations/" + frontendName;
            var frontendRef = new SubResource(id);
            Inner.FrontendIPConfiguration = frontendRef;
            return this;
        }

        internal LoadBalancingRuleImpl WithBackend (string backendName)
        {
            string id = Parent.FutureResourceId() + "/backendAddressPools/" + backendName;
            var backendRef = new SubResource(id);
            Inner.BackendAddressPool = backendRef;
            return this;
        }

        internal LoadBalancingRuleImpl WithProbe (string name)
        {
            string id = Parent.FutureResourceId() + "/probes/" + name;
            var probeRef = new SubResource(id);
            Inner.Probe = probeRef;
            return this;
        }

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