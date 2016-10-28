// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{

    using Management.Network.Fluent.Models;
    using Resource.Fluent;
    using Resource.Fluent.Core;
    using Resource.Fluent.Core.ChildResourceActions;
    using Rest.Azure;

    /// <summary>
    /// Implementation for IInboundNatRule.
    /// </summary>
    public partial class InboundNatRuleImpl  :
        ChildResource<InboundNatRuleInner, LoadBalancerImpl, ILoadBalancer>,
        IInboundNatRule,
        InboundNatRule.Definition.IDefinition<LoadBalancer.Definition.IWithCreateAndInboundNatRule>,
        InboundNatRule.UpdateDefinition.IUpdateDefinition<LoadBalancer.Update.IUpdate>,
        InboundNatRule.Update.IUpdate
    {
        internal InboundNatRuleImpl (InboundNatRuleInner inner, LoadBalancerImpl parent) 
            : base(inner, parent)
        {
        }

        public override string Name()
        {
            return Inner.Name;
        }

        internal string BackendNicIpConfigurationName()
        {
            var backendRef = Inner.BackendIPConfiguration;
            return (backendRef != null) ? backendRef.Id : null;
        }

        internal int BackendPort()
        {
            return (Inner.BackendPort.HasValue) ? Inner.BackendPort.Value : 0;
        }

        internal string BackendNetworkInterfaceId()
        {
            var backendRef = Inner.BackendIPConfiguration;
            return (backendRef != null) ? ResourceUtils.ParentResourcePathFromResourceId(backendRef.Id) : null;
        }

        internal string Protocol()
        {
            return Inner.Protocol;
        }

        internal int FrontendPort()
        {
            return (Inner.FrontendPort.HasValue) ? Inner.FrontendPort.Value : 0;
        }

        internal bool FloatingIpEnabled()
        {
            return (Inner.EnableFloatingIP.HasValue) ? Inner.EnableFloatingIP.Value : false;
        }

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

        internal int IdleTimeoutInMinutes()
        {
            return (Inner.IdleTimeoutInMinutes.HasValue) ? Inner.IdleTimeoutInMinutes.Value : 0;
        }

        internal InboundNatRuleImpl WithBackendPort (int port)
        {
            Inner.BackendPort = port;
            return this;
        }

        internal InboundNatRuleImpl WithFloatingIpEnabled ()
        {
            return WithFloatingIp(true);
        }

        internal InboundNatRuleImpl WithFloatingIpDisabled ()
        {
            return WithFloatingIp(false);
        }

        internal InboundNatRuleImpl WithFloatingIp (bool enabled)
        {
            Inner.EnableFloatingIP = enabled;
            return this;
        }

        internal InboundNatRuleImpl WithFrontendPort (int port)
        {
            Inner.FrontendPort = port;

            // By default, assume the same backend port
            return (BackendPort() == 0) ? WithBackendPort(port) : this;
        }

        internal InboundNatRuleImpl WithIdleTimeoutInMinutes (int minutes)
        {
            Inner.IdleTimeoutInMinutes = minutes;
            return this;
        }

        internal InboundNatRuleImpl WithProtocol (string protocol)
        {
            Inner.Protocol = protocol;
            return this;
        }

        internal InboundNatRuleImpl WithFrontend (string frontendName)
        {
            string frontendId = Parent.FutureResourceId() + "/frontendIPConfigurations/" + frontendName;
            SubResource frontendRef = new SubResource(frontendId);
            this.Inner.FrontendIPConfiguration = frontendRef;
            return this;
        }

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