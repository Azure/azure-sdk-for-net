// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{

    using Microsoft.Azure.Management.Network.Fluent.HasBackendPort.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.Update;
    using Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontend.Definition;
    using Microsoft.Azure.Management.Network.Fluent.InboundNatRule.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontend.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update;
    public partial class InboundNatRuleImpl 
    {
        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.UpdateDefinition.IWithFloatingIp<Microsoft.Azure.Management.Network.Fluent.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>.WithFloatingIpEnabled() { 
            return this.WithFloatingIpEnabled() as Microsoft.Azure.Management.Network.Fluent.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">enabled true if floating IP should be enabled</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.UpdateDefinition.IWithFloatingIp<Microsoft.Azure.Management.Network.Fluent.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>.WithFloatingIp(bool enabled) { 
            return this.WithFloatingIp( enabled) as Microsoft.Azure.Management.Network.Fluent.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.UpdateDefinition.IWithFloatingIp<Microsoft.Azure.Management.Network.Fluent.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>.WithFloatingIpDisabled() { 
            return this.WithFloatingIpDisabled() as Microsoft.Azure.Management.Network.Fluent.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule> Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.Definition.IWithFloatingIp<Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule>>.WithFloatingIpEnabled() { 
            return this.WithFloatingIpEnabled() as Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">enabled true if floating IP should be enabled</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule> Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.Definition.IWithFloatingIp<Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule>>.WithFloatingIp(bool enabled) { 
            return this.WithFloatingIp( enabled) as Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule> Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.Definition.IWithFloatingIp<Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule>>.WithFloatingIpDisabled() { 
            return this.WithFloatingIpDisabled() as Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.Update.IWithFloatingIp<Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Update.IUpdate>.WithFloatingIpEnabled() { 
            return this.WithFloatingIpEnabled() as Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">enabled true if floating IP should be enabled</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.Update.IWithFloatingIp<Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Update.IUpdate>.WithFloatingIp(bool enabled) { 
            return this.WithFloatingIp( enabled) as Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.Update.IWithFloatingIp<Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Update.IUpdate>.WithFloatingIpDisabled() { 
            return this.WithFloatingIpDisabled() as Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the idle connection timeout in minutes.
        /// </summary>
        /// <param name="minutes">minutes a number of minutes</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Update.IWithIdleTimeout.WithIdleTimeoutInMinutes(int minutes) { 
            return this.WithIdleTimeoutInMinutes( minutes) as Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Update.IUpdate;
        }

        /// <returns>the associated frontend</returns>
        Microsoft.Azure.Management.Network.Fluent.IFrontend Microsoft.Azure.Management.Network.Fluent.IHasFrontend.Frontend
        {
            get
            { 
            return this.Frontend() as Microsoft.Azure.Management.Network.Fluent.IFrontend;
            }
        }
        /// <returns>the protocol</returns>
        string Microsoft.Azure.Management.Network.Fluent.IHasProtocol<string>.Protocol
        {
            get
            { 
            return this.Protocol() as string;
            }
        }
        /// <returns>the backend port number the network traffic is sent to</returns>
        int Microsoft.Azure.Management.Network.Fluent.IHasBackendPort.BackendPort
        {
            get
            { 
            return this.BackendPort();
            }
        }
        /// <summary>
        /// Specifies the frontend port.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.InboundNatRule.UpdateDefinition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>.WithFrontendPort(int port) { 
            return this.WithFrontendPort( port) as Microsoft.Azure.Management.Network.Fluent.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the frontend port.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule> Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule>.WithFrontendPort(int port) { 
            return this.WithFrontendPort( port) as Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Specifies the idle connection timeout in minutes.
        /// </summary>
        /// <param name="minutes">minutes a number of minutes</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.InboundNatRule.UpdateDefinition.IWithIdleTimeout<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>.WithIdleTimeoutInMinutes(int minutes) { 
            return this.WithIdleTimeoutInMinutes( minutes) as Microsoft.Azure.Management.Network.Fluent.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the idle connection timeout in minutes.
        /// </summary>
        /// <param name="minutes">minutes a number of minutes</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule> Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition.IWithIdleTimeout<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule>.WithIdleTimeoutInMinutes(int minutes) { 
            return this.WithIdleTimeoutInMinutes( minutes) as Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update.IInUpdate<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>.Attach() { 
            return this.Attach() as Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate;
        }

        /// <returns>the state of the floating IP enablement</returns>
        bool Microsoft.Azure.Management.Network.Fluent.IHasFloatingIp.FloatingIpEnabled
        {
            get
            { 
            return this.FloatingIpEnabled();
            }
        }
        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition.IInDefinition<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule>.Attach() { 
            return this.Attach() as Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">protocol a transport protocol</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatRule.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.HasProtocol.UpdateDefinition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.InboundNatRule.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>,string>.WithProtocol(string protocol) { 
            return this.WithProtocol( protocol) as Microsoft.Azure.Management.Network.Fluent.InboundNatRule.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">protocol a transport protocol</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule> Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule>,string>.WithProtocol(string protocol) { 
            return this.WithProtocol( protocol) as Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">protocol a transport protocol</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.HasProtocol.Update.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Update.IUpdate,string>.WithProtocol(string protocol) { 
            return this.WithProtocol( protocol) as Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the frontend to associate.
        /// </summary>
        /// <param name="frontendName">frontendName an existing frontend name on this load balancer</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatRule.UpdateDefinition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.HasFrontend.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.InboundNatRule.UpdateDefinition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>.WithFrontend(string frontendName) { 
            return this.WithFrontend( frontendName) as Microsoft.Azure.Management.Network.Fluent.InboundNatRule.UpdateDefinition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the frontend to associate.
        /// </summary>
        /// <param name="frontendName">frontendName an existing frontend name on this load balancer</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule> Microsoft.Azure.Management.Network.Fluent.HasFrontend.Definition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule>>.WithFrontend(string frontendName) { 
            return this.WithFrontend( frontendName) as Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Specifies the frontend.
        /// </summary>
        /// <param name="frontendName">frontendName an existing frontend name from this load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.HasFrontend.Update.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Update.IUpdate>.WithFrontend(string frontendName) { 
            return this.WithFrontend( frontendName) as Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the frontend port.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Update.IWithFrontendPort.WithFrontendPort(int port) { 
            return this.WithFrontendPort( port) as Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the backend port.
        /// <p>
        /// If not specified, the same backend port number is assumed as that used by the frontend.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.HasBackendPort.UpdateDefinition.IWithBackendPort<Microsoft.Azure.Management.Network.Fluent.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>.WithBackendPort(int port) { 
            return this.WithBackendPort( port) as Microsoft.Azure.Management.Network.Fluent.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the backend port.
        /// <p>
        /// If not specified, the same backend port number is assumed as that used by the frontend.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule> Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Definition.IWithBackendPort<Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule>>.WithBackendPort(int port) { 
            return this.WithBackendPort( port) as Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Specifies the backend port.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Update.IWithBackendPort<Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Update.IUpdate>.WithBackendPort(int port) { 
            return this.WithBackendPort( port) as Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Update.IUpdate;
        }

        /// <returns>the resource ID of the network interface assigned as the backend of this inbound NAT rule</returns>
        string Microsoft.Azure.Management.Network.Fluent.IInboundNatRule.BackendNetworkInterfaceId
        {
            get
            { 
            return this.BackendNetworkInterfaceId() as string;
            }
        }
        /// <returns>the frontend port number associated with this NAT rule</returns>
        int Microsoft.Azure.Management.Network.Fluent.IInboundNatRule.FrontendPort
        {
            get
            { 
            return this.FrontendPort();
            }
        }
        /// <returns>the number of minutes before an idle connection is closed</returns>
        int Microsoft.Azure.Management.Network.Fluent.IInboundNatRule.IdleTimeoutInMinutes
        {
            get
            { 
            return this.IdleTimeoutInMinutes();
            }
        }
        /// <returns>the name of the IP configuration within the network interface associated with this NAT rule</returns>
        string Microsoft.Azure.Management.Network.Fluent.IInboundNatRule.BackendNicIpConfigurationName
        {
            get
            { 
            return this.BackendNicIpConfigurationName() as string;
            }
        }
        /// <returns>the name of this child object</returns>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IChildResource<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>.Name
        {
            get
            { 
            return this.Name() as string;
            }
        }
    }
}