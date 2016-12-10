// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using LoadBalancer.Definition;
    using LoadBalancer.Update;
    using LoadBalancingRule.Definition;
    using LoadBalancingRule.Update;
    using LoadBalancingRule.UpdateDefinition;
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

    internal partial class LoadBalancingRuleImpl 
    {
        /// <summary>
        /// Specifies the load distribution mode.
        /// </summary>
        /// <param name="loadDistribution">A supported load distribution mode.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> LoadBalancingRule.Definition.IWithLoadDistribution<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>.WithLoadDistribution(string loadDistribution)
        {
            return this.WithLoadDistribution(loadDistribution) as LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Specifies the load distribution mode.
        /// </summary>
        /// <param name="loadDistribution">A supported load distribution mode.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> LoadBalancingRule.UpdateDefinition.IWithLoadDistribution<LoadBalancer.Update.IUpdate>.WithLoadDistribution(string loadDistribution)
        {
            return this.WithLoadDistribution(loadDistribution) as LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancingRule.Update.IUpdate HasProtocol.Update.IWithProtocol<LoadBalancingRule.Update.IUpdate,string>.WithProtocol(string protocol)
        {
            return this.WithProtocol(protocol) as LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithFrontend<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> HasProtocol.Definition.IWithProtocol<LoadBalancingRule.Definition.IWithFrontend<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>,string>.WithProtocol(string protocol)
        {
            return this.WithProtocol(protocol) as LoadBalancingRule.Definition.IWithFrontend<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithFrontend<LoadBalancer.Update.IUpdate> HasProtocol.UpdateDefinition.IWithProtocol<LoadBalancingRule.UpdateDefinition.IWithFrontend<LoadBalancer.Update.IUpdate>,string>.WithProtocol(string protocol)
        {
            return this.WithProtocol(protocol) as LoadBalancingRule.UpdateDefinition.IWithFrontend<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the load distribution mode.
        /// </summary>
        /// <param name="loadDistribution">A supported load distribution mode.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Update.IUpdate LoadBalancingRule.Update.IWithLoadDistribution.WithLoadDistribution(string loadDistribution)
        {
            return this.WithLoadDistribution(loadDistribution) as LoadBalancingRule.Update.IUpdate;
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
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update.IInUpdate<LoadBalancer.Update.IUpdate>.Attach()
        {
            return this.Attach() as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the backend port.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancingRule.Update.IUpdate HasBackendPort.Update.IWithBackendPort<LoadBalancingRule.Update.IUpdate>.WithBackendPort(int port)
        {
            return this.WithBackendPort(port) as LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the backend port.
        /// If not specified, the same backend port number is assumed as that used by the frontend.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> HasBackendPort.Definition.IWithBackendPort<LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>>.WithBackendPort(int port)
        {
            return this.WithBackendPort(port) as LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Specifies the backend port.
        /// If not specified, the same backend port number is assumed as that used by the frontend.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasBackendPort.UpdateDefinition.IWithBackendPort<LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.WithBackendPort(int port)
        {
            return this.WithBackendPort(port) as LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition.IInDefinition<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>.Attach()
        {
            return this.Attach() as LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate;
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
        /// Associates the load balancing rule with the specified backend of this load balancer.
        /// A backedn with the specified name must already exist on this load balancer.
        /// </summary>
        /// <param name="backendName">The name of an existing backend.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithBackendPort<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> LoadBalancingRule.Definition.IWithBackend<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>.WithBackend(string backendName)
        {
            return this.WithBackend(backendName) as LoadBalancingRule.Definition.IWithBackendPort<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Associates the load balancing rule with the specified backend of this load balancer.
        /// A backedn with the specified name must already exist on this load balancer.
        /// </summary>
        /// <param name="backendName">The name of an existing backend.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithBackendPort<LoadBalancer.Update.IUpdate> LoadBalancingRule.UpdateDefinition.IWithBackend<LoadBalancer.Update.IUpdate>.WithBackend(string backendName)
        {
            return this.WithBackend(backendName) as LoadBalancingRule.UpdateDefinition.IWithBackendPort<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the frontend port.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Update.IUpdate HasFrontendPort.Update.IWithFrontendPort<LoadBalancingRule.Update.IUpdate>.WithFrontendPort(int port)
        {
            return this.WithFrontendPort(port) as LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the frontend port.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithProbe<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> HasFrontendPort.Definition.IWithFrontendPort<LoadBalancingRule.Definition.IWithProbe<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>>.WithFrontendPort(int port)
        {
            return this.WithFrontendPort(port) as LoadBalancingRule.Definition.IWithProbe<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Specifies the frontend port.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithProbe<LoadBalancer.Update.IUpdate> HasFrontendPort.UpdateDefinition.IWithFrontendPort<LoadBalancingRule.UpdateDefinition.IWithProbe<LoadBalancer.Update.IUpdate>>.WithFrontendPort(int port)
        {
            return this.WithFrontendPort(port) as LoadBalancingRule.UpdateDefinition.IWithProbe<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Gets the number of minutes before an inactive connection is closed.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.ILoadBalancingRule.IdleTimeoutInMinutes
        {
            get
            {
                return this.IdleTimeoutInMinutes();
            }
        }

        /// <summary>
        /// Gets the probe associated with the load balancing rule.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancerProbe Microsoft.Azure.Management.Network.Fluent.ILoadBalancingRule.Probe
        {
            get
            {
                return this.Probe() as Microsoft.Azure.Management.Network.Fluent.ILoadBalancerProbe;
            }
        }

        /// <summary>
        /// Gets the backend associated with the load balancing rule.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend Microsoft.Azure.Management.Network.Fluent.ILoadBalancingRule.Backend
        {
            get
            {
                return this.Backend() as Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend;
            }
        }

        /// <summary>
        /// Gets the method of load distribution.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.ILoadBalancingRule.LoadDistribution
        {
            get
            {
                return this.LoadDistribution();
            }
        }

        /// <summary>
        /// Specifies the number of minutes before an idle connection is closed.
        /// </summary>
        /// <param name="minutes">The desired number of minutes.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> LoadBalancingRule.Definition.IWithIdleTimeoutInMinutes<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>.WithIdleTimeoutInMinutes(int minutes)
        {
            return this.WithIdleTimeoutInMinutes(minutes) as LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Specifies the number of minutes before an idle connection is closed.
        /// </summary>
        /// <param name="minutes">The desired number of minutes.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> LoadBalancingRule.UpdateDefinition.IWithIdleTimeoutInMinutes<LoadBalancer.Update.IUpdate>.WithIdleTimeoutInMinutes(int minutes)
        {
            return this.WithIdleTimeoutInMinutes(minutes) as LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Associates the specified existing HTTP or TCP probe of this load balancer with the load balancing rule.
        /// </summary>
        /// <param name="name">The name of an existing HTTP or TCP probe.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithBackend<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> LoadBalancingRule.Definition.IWithProbe<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>.WithProbe(string name)
        {
            return this.WithProbe(name) as LoadBalancingRule.Definition.IWithBackend<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Associates the specified existing HTTP or TCP probe of this load balancer with the load balancing rule.
        /// </summary>
        /// <param name="name">The name of an existing HTTP or TCP probe.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithBackend<LoadBalancer.Update.IUpdate> LoadBalancingRule.UpdateDefinition.IWithProbe<LoadBalancer.Update.IUpdate>.WithProbe(string name)
        {
            return this.WithProbe(name) as LoadBalancingRule.UpdateDefinition.IWithBackend<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Update.IUpdate HasFloatingIp.Update.IWithFloatingIp<LoadBalancingRule.Update.IUpdate>.WithFloatingIpEnabled()
        {
            return this.WithFloatingIpEnabled() as LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">True if floating IP should be enabled.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Update.IUpdate HasFloatingIp.Update.IWithFloatingIp<LoadBalancingRule.Update.IUpdate>.WithFloatingIp(bool enabled)
        {
            return this.WithFloatingIp(enabled) as LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Update.IUpdate HasFloatingIp.Update.IWithFloatingIp<LoadBalancingRule.Update.IUpdate>.WithFloatingIpDisabled()
        {
            return this.WithFloatingIpDisabled() as LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> HasFloatingIp.Definition.IWithFloatingIp<LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>>.WithFloatingIpEnabled()
        {
            return this.WithFloatingIpEnabled() as LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">True if floating IP should be enabled.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> HasFloatingIp.Definition.IWithFloatingIp<LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>>.WithFloatingIp(bool enabled)
        {
            return this.WithFloatingIp(enabled) as LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> HasFloatingIp.Definition.IWithFloatingIp<LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>>.WithFloatingIpDisabled()
        {
            return this.WithFloatingIpDisabled() as LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasFloatingIp.UpdateDefinition.IWithFloatingIp<LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.WithFloatingIpEnabled()
        {
            return this.WithFloatingIpEnabled() as LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">True if floating IP should be enabled.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasFloatingIp.UpdateDefinition.IWithFloatingIp<LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.WithFloatingIp(bool enabled)
        {
            return this.WithFloatingIp(enabled) as LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasFloatingIp.UpdateDefinition.IWithFloatingIp<LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.WithFloatingIpDisabled()
        {
            return this.WithFloatingIpDisabled() as LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the frontend.
        /// </summary>
        /// <param name="frontendName">An existing frontend name from this load balancer.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancingRule.Update.IUpdate HasFrontend.Update.IWithFrontend<LoadBalancingRule.Update.IUpdate>.WithFrontend(string frontendName)
        {
            return this.WithFrontend(frontendName) as LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the frontend to associate.
        /// </summary>
        /// <param name="frontendName">An existing frontend name on this load balancer.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> HasFrontend.Definition.IWithFrontend<LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>>.WithFrontend(string frontendName)
        {
            return this.WithFrontend(frontendName) as LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Specifies the frontend to associate.
        /// </summary>
        /// <param name="frontendName">An existing frontend name.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithFrontendPort<LoadBalancer.Update.IUpdate> HasFrontend.UpdateDefinition.IWithFrontend<LoadBalancingRule.UpdateDefinition.IWithFrontendPort<LoadBalancer.Update.IUpdate>>.WithFrontend(string frontendName)
        {
            return this.WithFrontend(frontendName) as LoadBalancingRule.UpdateDefinition.IWithFrontendPort<LoadBalancer.Update.IUpdate>;
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
        /// Specifies the number of minutes before an idle connection is closed.
        /// </summary>
        /// <param name="minutes">The desired number of minutes.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancingRule.Update.IUpdate LoadBalancingRule.Update.IWithIdleTimeoutInMinutes.WithIdleTimeoutInMinutes(int minutes)
        {
            return this.WithIdleTimeoutInMinutes(minutes) as LoadBalancingRule.Update.IUpdate;
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
    }
}