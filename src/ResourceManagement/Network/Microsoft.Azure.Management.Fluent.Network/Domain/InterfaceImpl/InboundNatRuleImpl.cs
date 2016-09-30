// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{

    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.Definition;
    using Microsoft.Azure.Management.Fluent.Network.HasFrontend.Definition;
    using Microsoft.Azure.Management.Fluent.Network.HasProtocol.Definition;
    using Microsoft.Azure.Management.Fluent.Network.HasFrontend.Update;
    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition;
    using Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update;
    using Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Network.HasBackendPort.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Network.HasBackendPort.Definition;
    using Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.Update;
    using Microsoft.Azure.Management.Fluent.Network.HasFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Network.HasProtocol.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Network.HasProtocol.Update;
    using Microsoft.Azure.Management.Fluent.Network.HasBackendPort.Update;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update;
    using Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Update;
    public partial class InboundNatRuleImpl 
    {
        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.UpdateDefinition.IWithFloatingIp<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>>.WithFloatingIpEnabled () { 
            return this.WithFloatingIpEnabled() as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">enabled true if floating IP should be enabled</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.UpdateDefinition.IWithFloatingIp<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>>.WithFloatingIp (bool enabled) { 
            return this.WithFloatingIp( enabled) as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.UpdateDefinition.IWithFloatingIp<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>>.WithFloatingIpDisabled () { 
            return this.WithFloatingIpDisabled() as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule> Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.Definition.IWithFloatingIp<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule>>.WithFloatingIpEnabled () { 
            return this.WithFloatingIpEnabled() as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">enabled true if floating IP should be enabled</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule> Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.Definition.IWithFloatingIp<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule>>.WithFloatingIp (bool enabled) { 
            return this.WithFloatingIp( enabled) as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule> Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.Definition.IWithFloatingIp<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule>>.WithFloatingIpDisabled () { 
            return this.WithFloatingIpDisabled() as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.Update.IWithFloatingIp<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate>.WithFloatingIpEnabled () { 
            return this.WithFloatingIpEnabled() as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">enabled true if floating IP should be enabled</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.Update.IWithFloatingIp<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate>.WithFloatingIp (bool enabled) { 
            return this.WithFloatingIp( enabled) as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.Update.IWithFloatingIp<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate>.WithFloatingIpDisabled () { 
            return this.WithFloatingIpDisabled() as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the idle connection timeout in minutes.
        /// </summary>
        /// <param name="minutes">minutes a number of minutes</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IWithIdleTimeout.WithIdleTimeoutInMinutes (int minutes) { 
            return this.WithIdleTimeoutInMinutes( minutes) as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate;
        }

        /// <returns>the associated frontend</returns>
        Microsoft.Azure.Management.Fluent.Network.IFrontend Microsoft.Azure.Management.Fluent.Network.IHasFrontend.Frontend () { 
            return this.Frontend() as Microsoft.Azure.Management.Fluent.Network.IFrontend;
        }

        /// <returns>the protocol</returns>
        string Microsoft.Azure.Management.Fluent.Network.IHasProtocol<string>.Protocol () {
                return this.Protocol as string;
        }

        /// <returns>the backend port number the network traffic is sent to</returns>
        int? Microsoft.Azure.Management.Fluent.Network.IHasBackendPort.BackendPort
        {
            get
            {
                return this.BackendPort;
            }
        }
        /// <summary>
        /// Specifies the frontend port.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithFrontendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>.WithFrontendPort (int port) { 
            return this.WithFrontendPort( port) as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the frontend port.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule> Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IWithFrontendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule>.WithFrontendPort (int port) { 
            return this.WithFrontendPort( port) as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Specifies the idle connection timeout in minutes.
        /// </summary>
        /// <param name="minutes">minutes a number of minutes</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithIdleTimeout<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>.WithIdleTimeoutInMinutes (int minutes) { 
            return this.WithIdleTimeoutInMinutes( minutes) as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the idle connection timeout in minutes.
        /// </summary>
        /// <param name="minutes">minutes a number of minutes</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule> Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IWithIdleTimeout<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule>.WithIdleTimeoutInMinutes (int minutes) { 
            return this.WithIdleTimeoutInMinutes( minutes) as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Update.IInUpdate<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>.Attach () { 
            return this.Attach() as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate;
        }

        /// <returns>the state of the floating IP enablement</returns>
        bool? Microsoft.Azure.Management.Fluent.Network.IHasFloatingIp.FloatingIpEnabled
        {
            get
            {
                return this.FloatingIpEnabled;
            }
        }
        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Definition.IInDefinition<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule>.Attach () { 
            return this.Attach() as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">protocol a transport protocol</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HasProtocol.UpdateDefinition.IWithProtocol<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>,string>.WithProtocol (string protocol) { 
            return this.WithProtocol( protocol) as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">protocol a transport protocol</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule> Microsoft.Azure.Management.Fluent.Network.HasProtocol.Definition.IWithProtocol<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule>,string>.WithProtocol (string protocol) { 
            return this.WithProtocol( protocol) as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">protocol a transport protocol</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HasProtocol.Update.IWithProtocol<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate,string>.WithProtocol (string protocol) { 
            return this.WithProtocol( protocol) as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the frontend to associate.
        /// </summary>
        /// <param name="frontendName">frontendName an existing frontend name on this load balancer</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithFrontendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HasFrontend.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithFrontendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>>.WithFrontend (string frontendName) { 
            return this.WithFrontend( frontendName) as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithFrontendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the frontend to associate.
        /// </summary>
        /// <param name="frontendName">frontendName an existing frontend name on this load balancer</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IWithFrontendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule> Microsoft.Azure.Management.Fluent.Network.HasFrontend.Definition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IWithFrontendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule>>.WithFrontend (string frontendName) { 
            return this.WithFrontend( frontendName) as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IWithFrontendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Specifies the frontend.
        /// </summary>
        /// <param name="frontendName">frontendName an existing frontend name from this load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HasFrontend.Update.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate>.WithFrontend (string frontendName) { 
            return this.WithFrontend( frontendName) as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the frontend port.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IWithFrontendPort.WithFrontendPort (int port) { 
            return this.WithFrontendPort( port) as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the backend port.
        /// <p>
        /// If not specified, the same backend port number is assumed as that used by the frontend.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HasBackendPort.UpdateDefinition.IWithBackendPort<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>>.WithBackendPort (int port) { 
            return this.WithBackendPort( port) as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the backend port.
        /// <p>
        /// If not specified, the same backend port number is assumed as that used by the frontend.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule> Microsoft.Azure.Management.Fluent.Network.HasBackendPort.Definition.IWithBackendPort<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule>>.WithBackendPort (int port) { 
            return this.WithBackendPort( port) as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Specifies the backend port.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HasBackendPort.Update.IWithBackendPort<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate>.WithBackendPort (int port) { 
            return this.WithBackendPort( port) as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate;
        }

        /// <returns>the resource ID of the network interface assigned as the backend of this inbound NAT rule</returns>
        string Microsoft.Azure.Management.Fluent.Network.IInboundNatRule.BackendNetworkInterfaceId
        {
            get
            {
                return this.BackendNetworkInterfaceId as string;
            }
        }
        /// <returns>the frontend port number associated with this NAT rule</returns>
        int? Microsoft.Azure.Management.Fluent.Network.IInboundNatRule.FrontendPort
        {
            get
            {
                return this.FrontendPort;
            }
        }
        /// <returns>the number of minutes before an idle connection is closed</returns>
        int? Microsoft.Azure.Management.Fluent.Network.IInboundNatRule.IdleTimeoutInMinutes
        {
            get
            {
                return this.IdleTimeoutInMinutes;
            }
        }
        /// <returns>the name of the IP configuration within the network interface associated with this NAT rule</returns>
        string Microsoft.Azure.Management.Fluent.Network.IInboundNatRule.BackendNicIpConfigurationName
        {
            get
            {
                return this.BackendNicIpConfigurationName as string;
            }
        }
        /// <returns>the name of this child object</returns>
        string Microsoft.Azure.Management.Fluent.Resource.Core.IChildResource<Microsoft.Azure.Management.Fluent.Network.ILoadBalancer>.Name
        {
            get
            {
                return this.Name() as string;
            }
        }
    }
}