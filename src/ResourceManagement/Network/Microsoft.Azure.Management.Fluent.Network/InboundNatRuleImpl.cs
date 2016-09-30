// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{

    using Management.Network.Models;
    using Resource.Core;
    using Resource.Core.ChildResourceActions;
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
            : base(inner.Name, inner, parent)
        {
        }

        override public string Name
        {
            get
            {
                return Inner.Name;
            }
        }

        public string BackendNicIpConfigurationName
        {
            get
            {
                var backendRef = Inner.BackendIPConfiguration;
                return (backendRef != null) ? backendRef.Id : null;
            }
        }

        public int BackendPort
        {
            get
            {
                return (Inner.BackendPort.HasValue) ? (int) Inner.BackendPort.Value : 0;
            }
        }
        public string BackendNetworkInterfaceId
        {
            get
            {
                var backendRef = Inner.BackendIPConfiguration;
                return (backendRef != null) ? ResourceUtils.ParentResourcePathFromResourceId(backendRef.Id) : null;
            }
        }

        public string Protocol
        {
            get
            {
                return Inner.Protocol;
            }
        }

        public int FrontendPort
        {
            get
            {
                return (Inner.FrontendPort.HasValue) ? Inner.FrontendPort.Value : 0;
            }
        }

        public bool FloatingIpEnabled
        {
            get
            {
                return (Inner.EnableFloatingIP.HasValue) ? Inner.EnableFloatingIP.Value : false;
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
                string name = ResourceUtils.NameFromResourceId(frontendRef.Id);
                IFrontend frontend;
                Parent.Frontends().TryGetValue(name, out frontend);
                return frontend;
            }
        }

        public int IdleTimeoutInMinutes
        {
            get
            {
                return (Inner.IdleTimeoutInMinutes.HasValue) ? Inner.IdleTimeoutInMinutes.Value : 0;
            }
        }

        public InboundNatRuleImpl WithBackendPort (int port)
        {
            Inner.BackendPort = port;
            return this;
        }

        public InboundNatRuleImpl WithFloatingIpEnabled ()
        {
            return WithFloatingIp(true);
        }

        public InboundNatRuleImpl WithFloatingIpDisabled ()
        {
            return WithFloatingIp(false);
        }

        public InboundNatRuleImpl WithFloatingIp (bool enabled)
        {
            Inner.EnableFloatingIP = enabled;
            return this;
        }

        public InboundNatRuleImpl WithFrontendPort (int port)
        {
            Inner.FrontendPort = port;

            // By default, assume the same backend port
            return (BackendPort == 0) ? WithBackendPort(port) : this;
        }

        public InboundNatRuleImpl WithIdleTimeoutInMinutes (int minutes)
        {
            Inner.IdleTimeoutInMinutes = minutes;
            return this;
        }

        public InboundNatRuleImpl WithProtocol (string protocol)
        {
            Inner.Protocol = protocol;
            return this;
        }

        public InboundNatRuleImpl WithFrontend (string frontendName)
        {
            string frontendId = Parent.FutureResourceId + "/frontendIPConfigurations/" + frontendName;
            SubResource frontendRef = new SubResource(frontendId);
            this.Inner.FrontendIPConfiguration = frontendRef;
            return this;
        }

        public LoadBalancerImpl Attach ()
        {
            return Parent.WithInboundNatRule(this);
        }

        LoadBalancer.Update.IUpdate ISettable<LoadBalancer.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}