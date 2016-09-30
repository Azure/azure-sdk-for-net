// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{

    using Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update;
    using Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.Definition;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.Fluent.Network.HasFrontend.Definition;
    using Microsoft.Azure.Management.Fluent.Network.HasProtocol.Definition;
    using Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition;
    using Microsoft.Azure.Management.Fluent.Network.HasFrontend.Update;
    using Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update;
    using Microsoft.Azure.Management.Fluent.Network.HasBackendPort.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Network.HasBackendPort.Definition;
    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.Update;
    using Microsoft.Azure.Management.Fluent.Network.HasProtocol.Update;
    using Microsoft.Azure.Management.Fluent.Network.HasFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Network.HasProtocol.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition;
    using Microsoft.Azure.Management.Fluent.Network.HasBackendPort.Update;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Update;
    public partial class LoadBalancingRuleImpl 
    {
        /// <summary>
        /// Specifies the load distribution mode.
        /// </summary>
        /// <param name="loadDistribution">loadDistribution a supported load distribution mode</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithLoadDistribution<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>.WithLoadDistribution (string loadDistribution) { 
            return this.WithLoadDistribution( loadDistribution) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Specifies the load distribution mode.
        /// </summary>
        /// <param name="loadDistribution">loadDistribution a supported load distribution mode</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithLoadDistribution<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>.WithLoadDistribution (string loadDistribution) { 
            return this.WithLoadDistribution( loadDistribution) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">protocol a transport protocol</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HasProtocol.Update.IWithProtocol<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate,string>.WithProtocol (string protocol) { 
            return this.WithProtocol( protocol) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">protocol a transport protocol</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> Microsoft.Azure.Management.Fluent.Network.HasProtocol.Definition.IWithProtocol<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>,string>.WithProtocol (string protocol) { 
            return this.WithProtocol( protocol) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">protocol a transport protocol</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HasProtocol.UpdateDefinition.IWithProtocol<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>,string>.WithProtocol (string protocol) { 
            return this.WithProtocol( protocol) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the load distribution mode.
        /// </summary>
        /// <param name="loadDistribution">loadDistribution a supported load distribution mode</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IWithLoadDistribution.WithLoadDistribution (string loadDistribution) { 
            return this.WithLoadDistribution( loadDistribution) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate;
        }

        /// <returns>the state of the floating IP enablement</returns>
        bool? Microsoft.Azure.Management.Fluent.Network.IHasFloatingIp.FloatingIpEnabled
        {
            get
            {
                return this.FloatingIpEnabled;
            }
        }
        /// <returns>the associated frontend</returns>
        Microsoft.Azure.Management.Fluent.Network.IFrontend Microsoft.Azure.Management.Fluent.Network.IHasFrontend.Frontend () { 
            return this.Frontend() as Microsoft.Azure.Management.Fluent.Network.IFrontend;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Update.IInUpdate<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>.Attach () { 
            return this.Attach() as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the backend port.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HasBackendPort.Update.IWithBackendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate>.WithBackendPort (int port) { 
            return this.WithBackendPort( port) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the backend port.
        /// <p>
        /// If not specified, the same backend port number is assumed as that used by the frontend.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> Microsoft.Azure.Management.Fluent.Network.HasBackendPort.Definition.IWithBackendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>>.WithBackendPort (int port) { 
            return this.WithBackendPort( port) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Specifies the backend port.
        /// <p>
        /// If not specified, the same backend port number is assumed as that used by the frontend.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HasBackendPort.UpdateDefinition.IWithBackendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>>.WithBackendPort (int port) { 
            return this.WithBackendPort( port) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Definition.IInDefinition<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>.Attach () { 
            return this.Attach() as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate;
        }

        /// <returns>the name of this child object</returns>
        string Microsoft.Azure.Management.Fluent.Resource.Core.IChildResource<Microsoft.Azure.Management.Fluent.Network.ILoadBalancer>.Name
        {
            get
            {
                return this.Name() as string;
            }
        }
        /// <summary>
        /// Associates the load balancing rule with the specified backend of this load balancer.
        /// <p>
        /// A backedn with the specified name must already exist on this load balancer.
        /// </summary>
        /// <param name="backendName">backendName the name of an existing backend</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithBackendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithBackend<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>.WithBackend (string backendName) { 
            return this.WithBackend( backendName) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithBackendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Associates the load balancing rule with the specified backend of this load balancer.
        /// <p>
        /// A backedn with the specified name must already exist on this load balancer.
        /// </summary>
        /// <param name="backendName">backendName the name of an existing backend</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithBackendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithBackend<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>.WithBackend (string backendName) { 
            return this.WithBackend( backendName) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithBackendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the frontend port to load balance.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IWithFrontendPort.WithFrontendPort (int port) { 
            return this.WithFrontendPort( port) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate;
        }

        /// <returns>the load balanced front end port</returns>
        int? Microsoft.Azure.Management.Fluent.Network.ILoadBalancingRule.FrontendPort
        {
            get
            {
                return this.FrontendPort;
            }
        }
        /// <returns>the number of minutes before an inactive connection is closed</returns>
        int? Microsoft.Azure.Management.Fluent.Network.ILoadBalancingRule.IdleTimeoutInMinutes
        {
            get
            {
                return this.IdleTimeoutInMinutes;
            }
        }
        /// <returns>the probe associated with the load balancing rule</returns>
        Microsoft.Azure.Management.Fluent.Network.IProbe Microsoft.Azure.Management.Fluent.Network.ILoadBalancingRule.Probe () { 
            return this.Probe() as Microsoft.Azure.Management.Fluent.Network.IProbe;
        }

        /// <returns>the backend associated with the load balancing rule</returns>
        Microsoft.Azure.Management.Fluent.Network.IBackend Microsoft.Azure.Management.Fluent.Network.ILoadBalancingRule.Backend () { 
            return this.Backend() as Microsoft.Azure.Management.Fluent.Network.IBackend;
        }

        /// <returns>the method of load distribution</returns>
        string Microsoft.Azure.Management.Fluent.Network.ILoadBalancingRule.LoadDistribution
        {
            get
            {
                return this.LoadDistribution as string;
            }
        }
        /// <summary>
        /// Specifies the number of minutes before an idle connection is closed.
        /// </summary>
        /// <param name="minutes">minutes the desired number of minutes</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithIdleTimeoutInMinutes<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>.WithIdleTimeoutInMinutes (int minutes) { 
            return this.WithIdleTimeoutInMinutes( minutes) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Specifies the number of minutes before an idle connection is closed.
        /// </summary>
        /// <param name="minutes">minutes the desired number of minutes</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithIdleTimeoutInMinutes<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>.WithIdleTimeoutInMinutes (int minutes) { 
            return this.WithIdleTimeoutInMinutes( minutes) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Associates the specified existing HTTP or TCP probe of this load balancer with the load balancing rule.
        /// </summary>
        /// <param name="name">name the name of an existing HTTP or TCP probe</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithBackend<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithProbe<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>.WithProbe (string name) { 
            return this.WithProbe( name) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithBackend<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Associates the specified existing HTTP or TCP probe of this load balancer with the load balancing rule.
        /// </summary>
        /// <param name="name">name the name of an existing HTTP or TCP probe</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithBackend<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithProbe<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>.WithProbe (string name) { 
            return this.WithProbe( name) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithBackend<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.Update.IWithFloatingIp<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate>.WithFloatingIpEnabled () { 
            return this.WithFloatingIpEnabled() as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">enabled true if floating IP should be enabled</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.Update.IWithFloatingIp<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate>.WithFloatingIp (bool enabled) { 
            return this.WithFloatingIp( enabled) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.Update.IWithFloatingIp<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate>.WithFloatingIpDisabled () { 
            return this.WithFloatingIpDisabled() as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.Definition.IWithFloatingIp<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>>.WithFloatingIpEnabled () { 
            return this.WithFloatingIpEnabled() as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">enabled true if floating IP should be enabled</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.Definition.IWithFloatingIp<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>>.WithFloatingIp (bool enabled) { 
            return this.WithFloatingIp( enabled) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.Definition.IWithFloatingIp<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>>.WithFloatingIpDisabled () { 
            return this.WithFloatingIpDisabled() as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.UpdateDefinition.IWithFloatingIp<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>>.WithFloatingIpEnabled () { 
            return this.WithFloatingIpEnabled() as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">enabled true if floating IP should be enabled</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.UpdateDefinition.IWithFloatingIp<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>>.WithFloatingIp (bool enabled) { 
            return this.WithFloatingIp( enabled) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.UpdateDefinition.IWithFloatingIp<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>>.WithFloatingIpDisabled () { 
            return this.WithFloatingIpDisabled() as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the frontend.
        /// </summary>
        /// <param name="frontendName">frontendName an existing frontend name from this load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.HasFrontend.Update.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate>.WithFrontend (string frontendName) { 
            return this.WithFrontend( frontendName) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the frontend to associate.
        /// </summary>
        /// <param name="frontendName">frontendName an existing frontend name on this load balancer</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithFrontendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> Microsoft.Azure.Management.Fluent.Network.HasFrontend.Definition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithFrontendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>>.WithFrontend (string frontendName) { 
            return this.WithFrontend( frontendName) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithFrontendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Specifies the frontend to associate.
        /// </summary>
        /// <param name="frontendName">frontendName an existing frontend name on this load balancer</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithFrontendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.HasFrontend.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithFrontendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>>.WithFrontend (string frontendName) { 
            return this.WithFrontend( frontendName) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithFrontendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
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
        /// Specifies the number of minutes before an idle connection is closed.
        /// </summary>
        /// <param name="minutes">minutes the desired number of minutes</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IWithIdleTimeoutInMinutes.WithIdleTimeoutInMinutes (int minutes) { 
            return this.WithIdleTimeoutInMinutes( minutes) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate;
        }

        /// <returns>the protocol</returns>
        string Microsoft.Azure.Management.Fluent.Network.IHasProtocol<string>.Protocol () {
                return this.Protocol as string;
        }

        /// <summary>
        /// Specifies the frontend port to load balance.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithProbe<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithFrontendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>.WithFrontendPort (int port) { 
            return this.WithFrontendPort( port) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithProbe<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Specifies the frontend port to load balance.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithProbe<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithFrontendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>.WithFrontendPort (int port) { 
            return this.WithFrontendPort( port) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithProbe<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

    }
}