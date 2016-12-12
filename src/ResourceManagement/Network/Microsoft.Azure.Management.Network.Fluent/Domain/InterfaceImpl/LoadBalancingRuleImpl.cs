// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{

    using Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasBackendPort.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontend.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontend.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.UpdateDefinition;
    public partial class LoadBalancingRuleImpl 
    {
        /// <summary>
        /// Specifies the load distribution mode.
        /// </summary>
        /// <param name="loadDistribution">loadDistribution a supported load distribution mode</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithLoadDistribution<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>.WithLoadDistribution(string loadDistribution) { 
            return this.WithLoadDistribution( loadDistribution) as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Specifies the load distribution mode.
        /// </summary>
        /// <param name="loadDistribution">loadDistribution a supported load distribution mode</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithLoadDistribution<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>.WithLoadDistribution(string loadDistribution) { 
            return this.WithLoadDistribution( loadDistribution) as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">protocol a transport protocol</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.HasProtocol.Update.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate,string>.WithProtocol(string protocol) { 
            return this.WithProtocol( protocol) as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">protocol a transport protocol</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>,string>.WithProtocol(string protocol) { 
            return this.WithProtocol( protocol) as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">protocol a transport protocol</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.HasProtocol.UpdateDefinition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>,string>.WithProtocol(string protocol) { 
            return this.WithProtocol( protocol) as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the load distribution mode.
        /// </summary>
        /// <param name="loadDistribution">loadDistribution a supported load distribution mode</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IWithLoadDistribution.WithLoadDistribution(string loadDistribution) { 
            return this.WithLoadDistribution( loadDistribution) as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate;
        }

        /// <returns>the state of the floating IP enablement</returns>
        bool Microsoft.Azure.Management.Network.Fluent.IHasFloatingIp.FloatingIpEnabled
        {
            get
            { 
            return this.FloatingIpEnabled();
            }
        }
        /// <returns>the associated frontend</returns>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancerFrontend Microsoft.Azure.Management.Network.Fluent.IHasFrontend.Frontend
        {
            get
            { 
            return this.Frontend() as Microsoft.Azure.Management.Network.Fluent.ILoadBalancerFrontend;
            }
        }
        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update.IInUpdate<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>.Attach() { 
            return this.Attach() as Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the backend port.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Update.IWithBackendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate>.WithBackendPort(int port) { 
            return this.WithBackendPort( port) as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the backend port.
        /// <p>
        /// If not specified, the same backend port number is assumed as that used by the frontend.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Definition.IWithBackendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>>.WithBackendPort(int port) { 
            return this.WithBackendPort( port) as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Specifies the backend port.
        /// <p>
        /// If not specified, the same backend port number is assumed as that used by the frontend.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.HasBackendPort.UpdateDefinition.IWithBackendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>.WithBackendPort(int port) { 
            return this.WithBackendPort( port) as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition.IInDefinition<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>.Attach() { 
            return this.Attach() as Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate;
        }

        /// <returns>the name of this child object</returns>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
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
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithBackendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithBackend<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>.WithBackend(string backendName) { 
            return this.WithBackend( backendName) as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithBackendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Associates the load balancing rule with the specified backend of this load balancer.
        /// <p>
        /// A backedn with the specified name must already exist on this load balancer.
        /// </summary>
        /// <param name="backendName">backendName the name of an existing backend</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithBackendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithBackend<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>.WithBackend(string backendName) { 
            return this.WithBackend( backendName) as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithBackendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the frontend port to load balance.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IWithFrontendPort.WithFrontendPort(int port) { 
            return this.WithFrontendPort( port) as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate;
        }

        /// <returns>the load balanced front end port</returns>
        int Microsoft.Azure.Management.Network.Fluent.ILoadBalancingRule.FrontendPort
        {
            get
            { 
            return this.FrontendPort();
            }
        }
        /// <returns>the number of minutes before an inactive connection is closed</returns>
        int Microsoft.Azure.Management.Network.Fluent.ILoadBalancingRule.IdleTimeoutInMinutes
        {
            get
            { 
            return this.IdleTimeoutInMinutes();
            }
        }
        /// <returns>the probe associated with the load balancing rule</returns>
        Microsoft.Azure.Management.Network.Fluent.IProbe Microsoft.Azure.Management.Network.Fluent.ILoadBalancingRule.Probe
        {
            get
            { 
            return this.Probe() as Microsoft.Azure.Management.Network.Fluent.IProbe;
            }
        }
        /// <returns>the backend associated with the load balancing rule</returns>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend Microsoft.Azure.Management.Network.Fluent.ILoadBalancingRule.Backend
        {
            get
            { 
            return this.Backend() as Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend;
            }
        }
        /// <returns>the method of load distribution</returns>
        string Microsoft.Azure.Management.Network.Fluent.ILoadBalancingRule.LoadDistribution
        {
            get
            { 
            return this.LoadDistribution() as string;
            }
        }
        /// <summary>
        /// Specifies the number of minutes before an idle connection is closed.
        /// </summary>
        /// <param name="minutes">minutes the desired number of minutes</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithIdleTimeoutInMinutes<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>.WithIdleTimeoutInMinutes(int minutes) { 
            return this.WithIdleTimeoutInMinutes( minutes) as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Specifies the number of minutes before an idle connection is closed.
        /// </summary>
        /// <param name="minutes">minutes the desired number of minutes</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithIdleTimeoutInMinutes<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>.WithIdleTimeoutInMinutes(int minutes) { 
            return this.WithIdleTimeoutInMinutes( minutes) as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Associates the specified existing HTTP or TCP probe of this load balancer with the load balancing rule.
        /// </summary>
        /// <param name="name">name the name of an existing HTTP or TCP probe</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithBackend<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithProbe<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>.WithProbe(string name) { 
            return this.WithProbe( name) as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithBackend<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Associates the specified existing HTTP or TCP probe of this load balancer with the load balancing rule.
        /// </summary>
        /// <param name="name">name the name of an existing HTTP or TCP probe</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithBackend<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithProbe<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>.WithProbe(string name) { 
            return this.WithProbe( name) as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithBackend<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.Update.IWithFloatingIp<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate>.WithFloatingIpEnabled() { 
            return this.WithFloatingIpEnabled() as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">enabled true if floating IP should be enabled</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.Update.IWithFloatingIp<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate>.WithFloatingIp(bool enabled) { 
            return this.WithFloatingIp( enabled) as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.Update.IWithFloatingIp<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate>.WithFloatingIpDisabled() { 
            return this.WithFloatingIpDisabled() as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.Definition.IWithFloatingIp<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>>.WithFloatingIpEnabled() { 
            return this.WithFloatingIpEnabled() as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">enabled true if floating IP should be enabled</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.Definition.IWithFloatingIp<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>>.WithFloatingIp(bool enabled) { 
            return this.WithFloatingIp( enabled) as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.Definition.IWithFloatingIp<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>>.WithFloatingIpDisabled() { 
            return this.WithFloatingIpDisabled() as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.UpdateDefinition.IWithFloatingIp<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>.WithFloatingIpEnabled() { 
            return this.WithFloatingIpEnabled() as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">enabled true if floating IP should be enabled</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.UpdateDefinition.IWithFloatingIp<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>.WithFloatingIp(bool enabled) { 
            return this.WithFloatingIp( enabled) as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.UpdateDefinition.IWithFloatingIp<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>.WithFloatingIpDisabled() { 
            return this.WithFloatingIpDisabled() as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the frontend.
        /// </summary>
        /// <param name="frontendName">frontendName an existing frontend name from this load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.HasFrontend.Update.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate>.WithFrontend(string frontendName) { 
            return this.WithFrontend( frontendName) as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the frontend to associate.
        /// </summary>
        /// <param name="frontendName">frontendName an existing frontend name on this load balancer</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> Microsoft.Azure.Management.Network.Fluent.HasFrontend.Definition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>>.WithFrontend(string frontendName) { 
            return this.WithFrontend( frontendName) as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Specifies the frontend to associate.
        /// </summary>
        /// <param name="frontendName">frontendName an existing frontend name on this load balancer</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.HasFrontend.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>.WithFrontend(string frontendName) { 
            return this.WithFrontend( frontendName) as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
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
        /// Specifies the number of minutes before an idle connection is closed.
        /// </summary>
        /// <param name="minutes">minutes the desired number of minutes</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IWithIdleTimeoutInMinutes.WithIdleTimeoutInMinutes(int minutes) { 
            return this.WithIdleTimeoutInMinutes( minutes) as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate;
        }

        /// <returns>the protocol</returns>
        string Microsoft.Azure.Management.Network.Fluent.IHasProtocol<string>.Protocol
        {
            get
            { 
            return this.Protocol() as string;
            }
        }
        /// <summary>
        /// Specifies the frontend port to load balance.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithProbe<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>.WithFrontendPort(int port) { 
            return this.WithFrontendPort( port) as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithProbe<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Specifies the frontend port to load balance.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithProbe<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>.WithFrontendPort(int port) { 
            return this.WithFrontendPort( port) as Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithProbe<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>;
        }

    }
}