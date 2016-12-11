// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using LoadBalancer.Definition;
    using LoadBalancer.Update;
    using LoadBalancerInboundNatRule.Definition;
    using LoadBalancerInboundNatRule.Update;
    using LoadBalancerInboundNatRule.UpdateDefinition;
    using Models;
    using HasBackendPort.Definition;
    using HasBackendPort.UpdateDefinition;
    using HasBackendPort.Update;
    using HasFloatingIp.Definition;
    using HasFloatingIp.UpdateDefinition;
    using HasFloatingIp.Update;
    using HasFrontend.Definition;
    using HasFrontend.UpdateDefinition;
    using HasFrontend.Update;
    using HasFrontendPort.Definition;
    using HasFrontendPort.UpdateDefinition;
    using HasFrontendPort.Update;
    using HasProtocol.Definition;
    using HasProtocol.UpdateDefinition;
    using HasProtocol.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;

    internal partial class LoadBalancerInboundNatRuleImpl 
    {
        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasFloatingIp.UpdateDefinition.IWithFloatingIp<LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.WithFloatingIpEnabled()
        {
            return this.WithFloatingIpEnabled() as LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">True if floating IP should be enabled.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasFloatingIp.UpdateDefinition.IWithFloatingIp<LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.WithFloatingIp(bool enabled)
        {
            return this.WithFloatingIp(enabled) as LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasFloatingIp.UpdateDefinition.IWithFloatingIp<LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.WithFloatingIpDisabled()
        {
            return this.WithFloatingIpDisabled() as LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.Update.IUpdate HasFloatingIp.Update.IWithFloatingIp<LoadBalancerInboundNatRule.Update.IUpdate>.WithFloatingIpEnabled()
        {
            return this.WithFloatingIpEnabled() as LoadBalancerInboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">True if floating IP should be enabled.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.Update.IUpdate HasFloatingIp.Update.IWithFloatingIp<LoadBalancerInboundNatRule.Update.IUpdate>.WithFloatingIp(bool enabled)
        {
            return this.WithFloatingIp(enabled) as LoadBalancerInboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.Update.IUpdate HasFloatingIp.Update.IWithFloatingIp<LoadBalancerInboundNatRule.Update.IUpdate>.WithFloatingIpDisabled()
        {
            return this.WithFloatingIpDisabled() as LoadBalancerInboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule> HasFloatingIp.Definition.IWithFloatingIp<LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule>>.WithFloatingIpEnabled()
        {
            return this.WithFloatingIpEnabled() as LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">True if floating IP should be enabled.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule> HasFloatingIp.Definition.IWithFloatingIp<LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule>>.WithFloatingIp(bool enabled)
        {
            return this.WithFloatingIp(enabled) as LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule> HasFloatingIp.Definition.IWithFloatingIp<LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule>>.WithFloatingIpDisabled()
        {
            return this.WithFloatingIpDisabled() as LoadBalancerInboundNatRule.Definition.IWithAttach<LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Gets the protocol.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IHasProtocol<string>.Protocol
        {
            get
            {
                return this.Protocol();
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
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
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
        /// Gets the name of the IP configuration within the network interface associated with this NAT rule.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatRule.BackendNicIpConfigurationName
        {
            get
            {
                return this.BackendNicIpConfigurationName();
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
        /// Gets the state of the floating IP enablement.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IHasFloatingIp.FloatingIpEnabled
        {
            get
            {
                return this.FloatingIpEnabled();
            }
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update.IInUpdate<LoadBalancer.Update.IUpdate>.Attach()
        {
            return this.Attach() as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        LoadBalancer.Definition.IWithCreateAndInboundNatRule Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition.IInDefinition<LoadBalancer.Definition.IWithCreateAndInboundNatRule>.Attach()
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
        LoadBalancerInboundNatRule.UpdateDefinition.IWithFrontend<LoadBalancer.Update.IUpdate> HasProtocol.UpdateDefinition.IWithProtocol<LoadBalancerInboundNatRule.UpdateDefinition.IWithFrontend<LoadBalancer.Update.IUpdate>, TransportProtocol>.WithProtocol(TransportProtocol protocol)
        {
            return this.WithProtocol(protocol) as LoadBalancerInboundNatRule.UpdateDefinition.IWithFrontend<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancerInboundNatRule.Update.IUpdate HasProtocol.Update.IWithProtocol<LoadBalancerInboundNatRule.Update.IUpdate, TransportProtocol>.WithProtocol(TransportProtocol protocol)
        {
            return this.WithProtocol(protocol) as LoadBalancerInboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerInboundNatRule.Definition.IWithFrontend<LoadBalancer.Definition.IWithCreateAndInboundNatRule> HasProtocol.Definition.IWithProtocol<LoadBalancerInboundNatRule.Definition.IWithFrontend<LoadBalancer.Definition.IWithCreateAndInboundNatRule>, TransportProtocol>.WithProtocol(TransportProtocol protocol)
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