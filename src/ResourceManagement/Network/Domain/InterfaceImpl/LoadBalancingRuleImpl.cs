// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition;
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
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    internal partial class LoadBalancingRuleImpl 
    {
        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancingRule.Update.IUpdate HasProtocol.Update.IWithProtocol<LoadBalancingRule.Update.IUpdate,Models.TransportProtocol>.WithProtocol(TransportProtocol protocol)
        {
            return this.WithProtocol(protocol) as LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithFrontend<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> HasProtocol.Definition.IWithProtocol<LoadBalancingRule.Definition.IWithFrontend<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>,Models.TransportProtocol>.WithProtocol(TransportProtocol protocol)
        {
            return this.WithProtocol(protocol) as LoadBalancingRule.Definition.IWithFrontend<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>;
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithFrontend<LoadBalancer.Update.IUpdate> HasProtocol.UpdateDefinition.IWithProtocol<LoadBalancingRule.UpdateDefinition.IWithFrontend<LoadBalancer.Update.IUpdate>,Models.TransportProtocol>.WithProtocol(TransportProtocol protocol)
        {
            return this.WithProtocol(protocol) as LoadBalancingRule.UpdateDefinition.IWithFrontend<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">True if floating IP should be enabled.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Update.IUpdate HasFloatingIP.Update.IWithFloatingIP<LoadBalancingRule.Update.IUpdate>.WithFloatingIP(bool enabled)
        {
            return this.WithFloatingIP(enabled) as LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Update.IUpdate HasFloatingIP.Update.IWithFloatingIP<LoadBalancingRule.Update.IUpdate>.WithFloatingIPEnabled()
        {
            return this.WithFloatingIPEnabled() as LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Update.IUpdate HasFloatingIP.Update.IWithFloatingIP<LoadBalancingRule.Update.IUpdate>.WithFloatingIPDisabled()
        {
            return this.WithFloatingIPDisabled() as LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">True if floating IP should be enabled.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> HasFloatingIP.Definition.IWithFloatingIP<LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>>.WithFloatingIP(bool enabled)
        {
            return this.WithFloatingIP(enabled) as LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>;
        }

        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> HasFloatingIP.Definition.IWithFloatingIP<LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>>.WithFloatingIPEnabled()
        {
            return this.WithFloatingIPEnabled() as LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>;
        }

        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> HasFloatingIP.Definition.IWithFloatingIP<LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>>.WithFloatingIPDisabled()
        {
            return this.WithFloatingIPDisabled() as LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>;
        }

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">True if floating IP should be enabled.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasFloatingIP.UpdateDefinition.IWithFloatingIP<LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.WithFloatingIP(bool enabled)
        {
            return this.WithFloatingIP(enabled) as LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasFloatingIP.UpdateDefinition.IWithFloatingIP<LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.WithFloatingIPEnabled()
        {
            return this.WithFloatingIPEnabled() as LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasFloatingIP.UpdateDefinition.IWithFloatingIP<LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.WithFloatingIPDisabled()
        {
            return this.WithFloatingIPDisabled() as LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the load distribution mode.
        /// </summary>
        /// <param name="loadDistribution">A supported load distribution mode.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Update.IUpdate LoadBalancingRule.Update.IWithLoadDistribution.WithLoadDistribution(LoadDistribution loadDistribution)
        {
            return this.WithLoadDistribution(loadDistribution) as LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a backend on this load balancer to send network traffic to.
        /// If a backend with the specified name does not yet exist on this load balancer, it will be created automatically.
        /// </summary>
        /// <param name="backendName">The name of a backend.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithBackendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> LoadBalancingRule.Definition.IWithBackend<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>.ToBackend(string backendName)
        {
            return this.ToBackend(backendName) as LoadBalancingRule.Definition.IWithBackendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>;
        }

        /// <summary>
        /// Specifies a backend on this load balancer to send network traffic to.
        /// If a backend with the specified name does not yet exist, it will be created automatically.
        /// </summary>
        /// <param name="backendName">The name of an existing backend.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithBackendPort<LoadBalancer.Update.IUpdate> LoadBalancingRule.UpdateDefinition.IWithBackend<LoadBalancer.Update.IUpdate>.ToBackend(string backendName)
        {
            return this.ToBackend(backendName) as LoadBalancingRule.UpdateDefinition.IWithBackendPort<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Adds the specified set of virtual machines, assuming they are from the same
        /// availability set, to a new back end address pool to be associated with this load balancing rule.
        /// This will add references to the primary IP configurations of the primary network interfaces of
        /// the provided set of virtual machines.
        /// If the virtual machines are not in the same availability set, they will not be associated with the backend.
        /// Only those virtual machines will be associated with the load balancer that already have an existing
        /// network interface. Virtual machines without a network interface will be skipped.
        /// </summary>
        /// <param name="vms">Existing virtual machines.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithBackendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> LoadBalancingRule.Definition.IWithVirtualMachineBeta<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>.ToExistingVirtualMachines(params IHasNetworkInterfaces[] vms)
        {
            return this.ToExistingVirtualMachines(vms) as LoadBalancingRule.Definition.IWithBackendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>;
        }

        /// <summary>
        /// Adds the specified set of virtual machines, assuming they are from the same
        /// availability set, to a new back end address pool to be associated with this load balancing rule.
        /// This will add references to the primary IP configurations of the primary network interfaces of
        /// the provided set of virtual machines.
        /// If the virtual machines are not in the same availability set, they will not be associated with the backend.
        /// Only those virtual machines will be associated with the load balancer that already have an existing
        /// network interface. Virtual machines without a network interface will be skipped.
        /// </summary>
        /// <param name="vms">Existing virtual machines.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithBackendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> LoadBalancingRule.Definition.IWithVirtualMachineBeta<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>.ToExistingVirtualMachines(ICollection<Microsoft.Azure.Management.Network.Fluent.IHasNetworkInterfaces> vms)
        {
            return this.ToExistingVirtualMachines(vms) as LoadBalancingRule.Definition.IWithBackendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>;
        }

        /// <summary>
        /// Adds the specified set of virtual machines, assuming they are from the same
        /// availability set, to a new back end address pool to be associated with this load balancing rule.
        /// This will add references to the primary IP configurations of the primary network interfaces of
        /// the provided set of virtual machines.
        /// If the virtual machines are not in the same availability set, they will not be associated with the backend.
        /// Only those virtual machines will be associated with the load balancer that already have an existing
        /// network interface. Virtual machines without a network interface will be skipped.
        /// </summary>
        /// <param name="vms">Existing virtual machines.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithBackendPort<LoadBalancer.Update.IUpdate> LoadBalancingRule.UpdateDefinition.IWithVirtualMachineBeta<LoadBalancer.Update.IUpdate>.ToExistingVirtualMachines(params IHasNetworkInterfaces[] vms)
        {
            return this.ToExistingVirtualMachines(vms) as LoadBalancingRule.UpdateDefinition.IWithBackendPort<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Adds the specified set of virtual machines, assuming they are from the same
        /// availability set, to a new back end address pool to be associated with this load balancing rule.
        /// This will add references to the primary IP configurations of the primary network interfaces of
        /// the provided set of virtual machines.
        /// If the virtual machines are not in the same availability set, they will not be associated with the backend.
        /// Only those virtual machines will be associated with the load balancer that already have an existing
        /// network interface. Virtual machines without a network interface will be skipped.
        /// </summary>
        /// <param name="vms">Existing virtual machines.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithBackendPort<LoadBalancer.Update.IUpdate> LoadBalancingRule.UpdateDefinition.IWithVirtualMachineBeta<LoadBalancer.Update.IUpdate>.ToExistingVirtualMachines(ICollection<Microsoft.Azure.Management.Network.Fluent.IHasNetworkInterfaces> vms)
        {
            return this.ToExistingVirtualMachines(vms) as LoadBalancingRule.UpdateDefinition.IWithBackendPort<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Associates the specified existing HTTP or TCP probe of this load balancer with the load balancing rule.
        /// </summary>
        /// <param name="name">The name of an existing HTTP or TCP probe.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> LoadBalancingRule.Definition.IWithProbe<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>.WithProbe(string name)
        {
            return this.WithProbe(name) as LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>;
        }

        /// <summary>
        /// Associates the specified existing HTTP or TCP probe of this load balancer with the load balancing rule.
        /// </summary>
        /// <param name="name">The name of an existing HTTP or TCP probe.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> LoadBalancingRule.UpdateDefinition.IWithProbe<LoadBalancer.Update.IUpdate>.WithProbe(string name)
        {
            return this.WithProbe(name) as LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
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
        LoadBalancer.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<LoadBalancer.Update.IUpdate>.Attach()
        {
            return this.Attach() as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a backend port to send network traffic to.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancingRule.Update.IUpdate HasBackendPort.Update.IWithBackendPort<LoadBalancingRule.Update.IUpdate>.ToBackendPort(int port)
        {
            return this.ToBackendPort(port) as LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a backend port to send network traffic to.
        /// If not specified, the same backend port number is assumed as that used by the frontend.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> HasBackendPort.Definition.IWithBackendPort<LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>>.ToBackendPort(int port)
        {
            return this.ToBackendPort(port) as LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>;
        }

        /// <summary>
        /// Specifies a backend port to send network traffic to.
        /// If not specified, the same backend port number is assumed as that used by the frontend.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> HasBackendPort.UpdateDefinition.IWithBackendPort<LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>>.ToBackendPort(int port)
        {
            return this.ToBackendPort(port) as LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        LoadBalancer.Definition.IWithLBRuleOrNatOrCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>.Attach()
        {
            return this.Attach() as LoadBalancer.Definition.IWithLBRuleOrNatOrCreate;
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
        /// Specifies the frontend port to receive network traffic on.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Update.IUpdate HasFrontendPort.Update.IWithFrontendPort<LoadBalancingRule.Update.IUpdate>.FromFrontendPort(int port)
        {
            return this.FromFrontendPort(port) as LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the frontend port to receive network traffic on.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithBackend<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> HasFrontendPort.Definition.IWithFrontendPort<LoadBalancingRule.Definition.IWithBackend<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>>.FromFrontendPort(int port)
        {
            return this.FromFrontendPort(port) as LoadBalancingRule.Definition.IWithBackend<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>;
        }

        /// <summary>
        /// Specifies the frontend port to receive network traffic on.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithBackend<LoadBalancer.Update.IUpdate> HasFrontendPort.UpdateDefinition.IWithFrontendPort<LoadBalancingRule.UpdateDefinition.IWithBackend<LoadBalancer.Update.IUpdate>>.FromFrontendPort(int port)
        {
            return this.FromFrontendPort(port) as LoadBalancingRule.UpdateDefinition.IWithBackend<LoadBalancer.Update.IUpdate>;
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
        Models.LoadDistribution Microsoft.Azure.Management.Network.Fluent.ILoadBalancingRule.LoadDistribution
        {
            get
            {
                return this.LoadDistribution() as Models.LoadDistribution;
            }
        }

        /// <summary>
        /// Specifies the load distribution mode.
        /// </summary>
        /// <param name="loadDistribution">A supported load distribution mode.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> LoadBalancingRule.Definition.IWithLoadDistribution<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>.WithLoadDistribution(LoadDistribution loadDistribution)
        {
            return this.WithLoadDistribution(loadDistribution) as LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>;
        }

        /// <summary>
        /// Specifies the load distribution mode.
        /// </summary>
        /// <param name="loadDistribution">A supported load distribution mode.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> LoadBalancingRule.UpdateDefinition.IWithLoadDistribution<LoadBalancer.Update.IUpdate>.WithLoadDistribution(LoadDistribution loadDistribution)
        {
            return this.WithLoadDistribution(loadDistribution) as LoadBalancingRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the number of minutes before an idle connection is closed.
        /// </summary>
        /// <param name="minutes">The desired number of minutes.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> LoadBalancingRule.Definition.IWithIdleTimeoutInMinutes<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>.WithIdleTimeoutInMinutes(int minutes)
        {
            return this.WithIdleTimeoutInMinutes(minutes) as LoadBalancingRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>;
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
        /// Specifies the frontend.
        /// </summary>
        /// <param name="frontendName">An existing frontend name from this load balancer.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancingRule.Update.IUpdate HasFrontend.Update.IWithFrontendBeta<LoadBalancingRule.Update.IUpdate>.FromFrontend(string frontendName)
        {
            return this.FromFrontend(frontendName) as LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Specifies an existing private subnet to receive network traffic from.
        /// If this load balancer already has a frontend referencing this subnet, that is the frontend that will be used.
        /// Else, an automatically named new private frontend will be created implicitly on the load balancer.
        /// </summary>
        /// <param name="networkResourceId">The resource ID of an existing network.</param>
        /// <param name="subnetName">The name of an existing subnet within the specified network.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> HasFrontend.Definition.IWithFrontendBeta<LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>>.FromExistingSubnet(string networkResourceId, string subnetName)
        {
            return this.FromExistingSubnet(networkResourceId, subnetName) as LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>;
        }

        /// <summary>
        /// Specifies an existing private subnet to receive network traffic from.
        /// If this load balancer already has a frontend referencing this subnet, that is the frontend that will be used.
        /// Else, an automatically named new private frontend will be created implicitly on the load balancer.
        /// </summary>
        /// <param name="network">An existing network.</param>
        /// <param name="subnetName">The name of an existing subnet within the specified network.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> HasFrontend.Definition.IWithFrontendBeta<LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>>.FromExistingSubnet(INetwork network, string subnetName)
        {
            return this.FromExistingSubnet(network, subnetName) as LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>;
        }

        /// <summary>
        /// Specifies an existing private subnet to receive network traffic from.
        /// If this load balancer already has a frontend referencing this subnet, that is the frontend that will be used.
        /// Else, an automatically named new private frontend will be created implicitly on the load balancer.
        /// </summary>
        /// <param name="subnet">An existing subnet.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> HasFrontend.Definition.IWithFrontendBeta<LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>>.FromExistingSubnet(ISubnet subnet)
        {
            return this.FromExistingSubnet(subnet) as LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>;
        }

        /// <summary>
        /// Specifies the frontend to receive network traffic from.
        /// </summary>
        /// <param name="frontendName">An existing frontend name on this load balancer.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> HasFrontend.Definition.IWithFrontendBeta<LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>>.FromFrontend(string frontendName)
        {
            return this.FromFrontend(frontendName) as LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>;
        }

        /// <summary>
        /// Specifies an existing public IP address to receive network traffic from.
        /// If this load balancer already has a frontend referencing this public IP address, that is the frontend that will be used.
        /// Else, an automatically named new public frontend will be created implicitly on the load balancer.
        /// </summary>
        /// <param name="publicIPAddress">An existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> HasFrontend.Definition.IWithFrontendBeta<LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>>.FromExistingPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            return this.FromExistingPublicIPAddress(publicIPAddress) as LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>;
        }

        /// <summary>
        /// Specifies an existing public IP address to receive network traffic from.
        /// If this load balancer already has a frontend referencing this public IP address, that is the frontend that will be used.
        /// Else, an automatically named new public frontend will be created implicitly on the load balancer.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> HasFrontend.Definition.IWithFrontendBeta<LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>>.FromExistingPublicIPAddress(string resourceId)
        {
            return this.FromExistingPublicIPAddress(resourceId) as LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>;
        }

        /// <summary>
        /// Specifies that network traffic should be received on a new public IP address that is to be created along with the load balancer
        /// in the same region and resource group but under the provided leaf DNS label, assuming it is available.
        /// A new automatically-named public frontend will be implicitly created on this load balancer for each such new public IP address, so make
        /// sure to use a unique DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">A unique leaf DNS label to create the public IP address under.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> HasFrontend.Definition.IWithFrontendBeta<LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>>.FromNewPublicIPAddress(string leafDnsLabel)
        {
            return this.FromNewPublicIPAddress(leafDnsLabel) as LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>;
        }

        /// <summary>
        /// Specifies that network traffic should be received on a new public IP address that is to be created along with the load balancer
        /// based on the provided definition.
        /// A new automatically-named public frontend will be implicitly created on this load balancer for each such new public IP address.
        /// </summary>
        /// <param name="pipDefinition">A definition for the new public IP.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> HasFrontend.Definition.IWithFrontendBeta<LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>>.FromNewPublicIPAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress> pipDefinition)
        {
            return this.FromNewPublicIPAddress(pipDefinition) as LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>;
        }

        /// <summary>
        /// Specifies that network traffic should be received on a new public IP address that is to be automatically created woth default settings
        /// along with the load balancer.
        /// A new automatically-named public frontend will be implicitly created on this load balancer for each such new public IP address.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> HasFrontend.Definition.IWithFrontendBeta<LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>>.FromNewPublicIPAddress()
        {
            return this.FromNewPublicIPAddress() as LoadBalancingRule.Definition.IWithFrontendPort<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>;
        }

        /// <summary>
        /// Specifies an existing private subnet to receive network traffic from.
        /// If this load balancer already has a frontend referencing this subnet, that is the frontend that will be used.
        /// Else, an automatically named new private frontend will be created implicitly on the load balancer.
        /// </summary>
        /// <param name="networkResourceId">The resource ID of an existing network.</param>
        /// <param name="subnetName">The name of an existing subnet within the specified network.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithFrontendPort<LoadBalancer.Update.IUpdate> HasFrontend.UpdateDefinition.IWithFrontendBeta<LoadBalancingRule.UpdateDefinition.IWithFrontendPort<LoadBalancer.Update.IUpdate>>.FromExistingSubnet(string networkResourceId, string subnetName)
        {
            return this.FromExistingSubnet(networkResourceId, subnetName) as LoadBalancingRule.UpdateDefinition.IWithFrontendPort<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies an existing private subnet to receive network traffic from.
        /// If this load balancer already has a frontend referencing this subnet, that is the frontend that will be used.
        /// Else, an automatically named new private frontend will be created implicitly on the load balancer.
        /// </summary>
        /// <param name="network">An existing network.</param>
        /// <param name="subnetName">The name of an existing subnet within the specified network.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithFrontendPort<LoadBalancer.Update.IUpdate> HasFrontend.UpdateDefinition.IWithFrontendBeta<LoadBalancingRule.UpdateDefinition.IWithFrontendPort<LoadBalancer.Update.IUpdate>>.FromExistingSubnet(INetwork network, string subnetName)
        {
            return this.FromExistingSubnet(network, subnetName) as LoadBalancingRule.UpdateDefinition.IWithFrontendPort<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies an existing private subnet to receive network traffic from.
        /// If this load balancer already has a frontend referencing this subnet, that is the frontend that will be used.
        /// Else, an automatically named new private frontend will be created implicitly on the load balancer.
        /// </summary>
        /// <param name="subnet">An existing subnet.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithFrontendPort<LoadBalancer.Update.IUpdate> HasFrontend.UpdateDefinition.IWithFrontendBeta<LoadBalancingRule.UpdateDefinition.IWithFrontendPort<LoadBalancer.Update.IUpdate>>.FromExistingSubnet(ISubnet subnet)
        {
            return this.FromExistingSubnet(subnet) as LoadBalancingRule.UpdateDefinition.IWithFrontendPort<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the frontend to associate.
        /// </summary>
        /// <param name="frontendName">An existing frontend name.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithFrontendPort<LoadBalancer.Update.IUpdate> HasFrontend.UpdateDefinition.IWithFrontendBeta<LoadBalancingRule.UpdateDefinition.IWithFrontendPort<LoadBalancer.Update.IUpdate>>.FromFrontend(string frontendName)
        {
            return this.FromFrontend(frontendName) as LoadBalancingRule.UpdateDefinition.IWithFrontendPort<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies an existing public IP address to receive network traffic from.
        /// If this load balancer already has a frontend referencing this public IP address, that is the frontend that will be used.
        /// Else, an automatically named new public frontend will be created implicitly on the load balancer.
        /// </summary>
        /// <param name="publicIPAddress">An existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithFrontendPort<LoadBalancer.Update.IUpdate> HasFrontend.UpdateDefinition.IWithFrontendBeta<LoadBalancingRule.UpdateDefinition.IWithFrontendPort<LoadBalancer.Update.IUpdate>>.FromExistingPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            return this.FromExistingPublicIPAddress(publicIPAddress) as LoadBalancingRule.UpdateDefinition.IWithFrontendPort<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies an existing public IP address to receive network traffic from.
        /// If this load balancer already has a frontend referencing this public IP address, that is the frontend that will be used.
        /// Else, an automatically named new public frontend will be created implicitly on the load balancer.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancingRule.UpdateDefinition.IWithFrontendPort<LoadBalancer.Update.IUpdate> HasFrontend.UpdateDefinition.IWithFrontendBeta<LoadBalancingRule.UpdateDefinition.IWithFrontendPort<LoadBalancer.Update.IUpdate>>.FromExistingPublicIPAddress(string resourceId)
        {
            return this.FromExistingPublicIPAddress(resourceId) as LoadBalancingRule.UpdateDefinition.IWithFrontendPort<LoadBalancer.Update.IUpdate>;
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
        /// Associates the specified existing HTTP or TCP probe of this load balancer with the load balancing rule.
        /// </summary>
        /// <param name="name">The name of an existing HTTP or TCP probe.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancingRule.Update.IUpdate LoadBalancingRule.Update.IWithProbe.WithProbe(string name)
        {
            return this.WithProbe(name) as LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Removes any association with a probe and falls back to Azure's default probing mechanism.
        /// </summary>
        /// <return>The next stage of the update.</return>
        LoadBalancingRule.Update.IUpdate LoadBalancingRule.Update.IWithProbe.WithoutProbe()
        {
            return this.WithoutProbe() as LoadBalancingRule.Update.IUpdate;
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
        Models.TransportProtocol Microsoft.Azure.Management.Network.Fluent.IHasProtocol<Models.TransportProtocol>.Protocol
        {
            get
            {
                return this.Protocol() as Models.TransportProtocol;
            }
        }
    }
}