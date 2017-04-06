// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasBackendPort.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasFloatingIP.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasFloatingIP.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasFloatingIP.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontend.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontend.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontendPort.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontendPort.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontendPort.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;

    internal partial class LoadBalancerInboundNatRuleImpl 
    {
        /// <summary>
        /// Gets the protocol.
        /// </summary>
        Models.TransportProtocol Microsoft.Azure.Management.Network.Fluent.IHasProtocol<Models.TransportProtocol>.Protocol
        {
            get
            {
                return this.Protocol() as Models.TransportProtocol;
            }
        }

        /// <summary>
        /// Gets the associated frontend.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancerFrontend Microsoft.Azure.Management.Network.Fluent.IHasFrontend.Frontend
        {
            get
            {
                return this.Frontend() as Microsoft.Azure.Management.Network.Fluent.ILoadBalancerFrontend;
            }
        }

        /// <summary>
        /// Specifies the idle connection timeout in minutes.
        /// </summary>
        /// <param name="minutes">A number of minutes.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancerInboundNatRule.Update.IUpdate LoadBalancerInboundNatRule.Update.IWithIdleTimeout.WithIdleTimeoutInMinutes(int minutes)
        {
            return this.WithIdleTimeoutInMinutes(minutes) as LoadBalancerInboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the backend port number the network traffic is sent to.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IHasBackendPort.BackendPort
        {
            get
            {
                return this.BackendPort();
            }
        }

        /// <summary>
        /// Gets the resource ID of the network interface assigned as the backend of this inbound NAT rule.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatRule.BackendNetworkInterfaceId
        {
            get
            {
                return this.BackendNetworkInterfaceId();
            }
        }

        /// <summary>
        /// Gets the name of the IP configuration within the network interface associated with this NAT rule.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatRule.BackendNicIPConfigurationName
        {
            get
            {
                return this.BackendNicIPConfigurationName();
            }
        }

        /// <summary>
        /// Gets the number of minutes before an idle connection is closed.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatRule.IdleTimeoutInMinutes
        {
            get
            {
                return this.IdleTimeoutInMinutes();
            }
        }

        /// <summary>
        /// Specifies the idle connection timeout in minutes.
        /// </summary>
        /// <param name="minutes">A number of minutes.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> LoadBalancerInboundNatRule.UpdateDefinition.IWithIdleTimeout<LoadBalancer.Update.IUpdate>.WithIdleTimeoutInMinutes(int minutes)
        {
            return this.WithIdleTimeoutInMinutes(minutes) as LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the idle connection timeout in minutes.
        /// </summary>
        /// <param name="minutes">A number of minutes.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule> LoadBalancerInboundNatRule.Definition.IWithIdleTimeout<LoadBalancer.Definition.IWithCreateAndInboundNatRule>.WithIdleTimeoutInMinutes(int minutes)
        {
            return this.WithIdleTimeoutInMinutes(minutes) as LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        LoadBalancer.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<LoadBalancer.Update.IUpdate>.Attach()
        {
            return this.Attach() as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        LoadBalancer.Definition.IWithCreateAndInboundNatRule Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<LoadBalancer.Definition.IWithCreateAndInboundNatRule>.Attach()
        {
            return this.Attach() as LoadBalancer.Definition.IWithCreateAndInboundNatRule;
        }

        /// <summary>
        /// Gets the frontend port number the inbound network traffic is received on.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IHasFrontendPort.FrontendPort
        {
            get
            {
                return this.FrontendPort();
            }
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.UpdateDefinition.IWithFrontend<LoadBalancer.Update.IUpdate> HasProtocol.UpdateDefinition.IWithProtocol<LoadBalancerInboundNatRule.UpdateDefinition.IWithFrontend<LoadBalancer.Update.IUpdate>,Models.TransportProtocol>.WithProtocol(TransportProtocol protocol)
        {
            return this.WithProtocol(protocol) as LoadBalancerInboundNatRule.UpdateDefinition.IWithFrontend<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancerInboundNatRule.Update.IUpdate HasProtocol.Update.IWithProtocol<LoadBalancerInboundNatRule.Update.IUpdate,Models.TransportProtocol>.WithProtocol(TransportProtocol protocol)
        {
            return this.WithProtocol(protocol) as LoadBalancerInboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.Definition.IWithFrontend<LoadBalancer.Definition.IWithCreateAndInboundNatRule> HasProtocol.Definition.IWithProtocol<LoadBalancerInboundNatRule.Definition.IWithFrontend<LoadBalancer.Definition.IWithCreateAndInboundNatRule>,Models.TransportProtocol>.WithProtocol(TransportProtocol protocol)
        {
            return this.WithProtocol(protocol) as LoadBalancerInboundNatRule.Definition.IWithFrontend<LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Specifies the frontend to associate.
        /// </summary>
        /// <param name="frontendName">An existing frontend name.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.UpdateDefinition.IWithFrontendPort<LoadBalancer.Update.IUpdate> HasFrontend.UpdateDefinition.IWithFrontend<LoadBalancerInboundNatRule.UpdateDefinition.IWithFrontendPort<LoadBalancer.Update.IUpdate>>.WithFrontend(string frontendName)
        {
            return this.WithFrontend(frontendName) as LoadBalancerInboundNatRule.UpdateDefinition.IWithFrontendPort<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the frontend.
        /// </summary>
        /// <param name="frontendName">An existing frontend name from this load balancer.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancerInboundNatRule.Update.IUpdate HasFrontend.Update.IWithFrontend<LoadBalancerInboundNatRule.Update.IUpdate>.WithFrontend(string frontendName)
        {
            return this.WithFrontend(frontendName) as LoadBalancerInboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the frontend to associate.
        /// </summary>
        /// <param name="frontendName">An existing frontend name on this load balancer.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithCreateAndInboundNatRule> HasFrontend.Definition.IWithFrontend<LoadBalancerInboundNatRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithCreateAndInboundNatRule>>.WithFrontend(string frontendName)
        {
            return this.WithFrontend(frontendName) as LoadBalancerInboundNatRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Specifies the backend port.
        /// If not specified, the same backend port number is assumed as that used by the frontend.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasBackendPort.UpdateDefinition.IWithBackendPort<LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.WithBackendPort(int port)
        {
            return this.WithBackendPort(port) as LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the backend port.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancerInboundNatRule.Update.IUpdate HasBackendPort.Update.IWithBackendPort<LoadBalancerInboundNatRule.Update.IUpdate>.WithBackendPort(int port)
        {
            return this.WithBackendPort(port) as LoadBalancerInboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the backend port.
        /// If not specified, the same backend port number is assumed as that used by the frontend.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule> HasBackendPort.Definition.IWithBackendPort<LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule>>.WithBackendPort(int port)
        {
            return this.WithBackendPort(port) as LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Gets the state of the floating IP enablement.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IHasFloatingIP.FloatingIPEnabled
        {
            get
            {
                return this.FloatingIPEnabled();
            }
        }

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">True if floating IP should be enabled.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasFloatingIP.UpdateDefinition.IWithFloatingIP<LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.WithFloatingIP(bool enabled)
        {
            return this.WithFloatingIP(enabled) as LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasFloatingIP.UpdateDefinition.IWithFloatingIP<LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.WithFloatingIPEnabled()
        {
            return this.WithFloatingIPEnabled() as LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasFloatingIP.UpdateDefinition.IWithFloatingIP<LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.WithFloatingIPDisabled()
        {
            return this.WithFloatingIPDisabled() as LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">True if floating IP should be enabled.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.Update.IUpdate HasFloatingIP.Update.IWithFloatingIP<LoadBalancerInboundNatRule.Update.IUpdate>.WithFloatingIP(bool enabled)
        {
            return this.WithFloatingIP(enabled) as LoadBalancerInboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.Update.IUpdate HasFloatingIP.Update.IWithFloatingIP<LoadBalancerInboundNatRule.Update.IUpdate>.WithFloatingIPEnabled()
        {
            return this.WithFloatingIPEnabled() as LoadBalancerInboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.Update.IUpdate HasFloatingIP.Update.IWithFloatingIP<LoadBalancerInboundNatRule.Update.IUpdate>.WithFloatingIPDisabled()
        {
            return this.WithFloatingIPDisabled() as LoadBalancerInboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">True if floating IP should be enabled.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule> HasFloatingIP.Definition.IWithFloatingIP<LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule>>.WithFloatingIP(bool enabled)
        {
            return this.WithFloatingIP(enabled) as LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule> HasFloatingIP.Definition.IWithFloatingIP<LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule>>.WithFloatingIPEnabled()
        {
            return this.WithFloatingIPEnabled() as LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule> HasFloatingIP.Definition.IWithFloatingIP<LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule>>.WithFloatingIPDisabled()
        {
            return this.WithFloatingIPDisabled() as LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Specifies the frontend port.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasFrontendPort.UpdateDefinition.IWithFrontendPort<LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.WithFrontendPort(int port)
        {
            return this.WithFrontendPort(port) as LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the frontend port.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.Update.IUpdate HasFrontendPort.Update.IWithFrontendPort<LoadBalancerInboundNatRule.Update.IUpdate>.WithFrontendPort(int port)
        {
            return this.WithFrontendPort(port) as LoadBalancerInboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the frontend port.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule> HasFrontendPort.Definition.IWithFrontendPort<LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule>>.WithFrontendPort(int port)
        {
            return this.WithFrontendPort(port) as LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }
    }
}