// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition
{
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.Definition;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerTcpProbe.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;

    /// <summary>
    /// The stage of a load balancer definition allowing to create a load balancing rule.
    /// </summary>
    public interface IWithLoadBalancingRule 
    {
        /// <summary>
        /// Begins the definition of a new load balancing rule to add to the load balancer.
        /// The definition must be completed with a call to  LoadBalancingRule.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the load balancing rule.</param>
        /// <return>The first stage of the new load balancing rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> DefineLoadBalancingRule(string name);

        /// <summary>
        /// Creates a load balancing rule between the specified front end and back end ports and protocol.
        /// The new rule will be assigned an automatically generated name.
        /// </summary>
        /// <param name="frontendPort">The port number on the front end to accept incoming traffic on.</param>
        /// <param name="protocol">The protocol to load balance.</param>
        /// <param name="backendPort">The port number on the back end to send load balanced traffic to.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate WithLoadBalancingRule(int frontendPort, TransportProtocol protocol, int backendPort);

        /// <summary>
        /// Creates a load balancing rule for the specified port and protocol and default frontend and backend associations.
        /// The load balancing rule will created under the name "default". It will reference a backend, a frontend, and a load balancing probe all named "default".
        /// </summary>
        /// <param name="port">The port number on the front and back end for the network traffic to be load balanced on.</param>
        /// <param name="protocol">The protocol to load balance.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate WithLoadBalancingRule(int port, TransportProtocol protocol);
    }

    /// <summary>
    /// The stage of a load balancer definition allowing to create the load balancer or start configuring optional inbound NAT rules or pools.
    /// </summary>
    public interface IWithCreateAndNatChoice  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreate,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithInboundNatRule,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithInboundNatPool
    {
    }

    /// <summary>
    /// The stage of an Internet-facing load balancer definition allowing to define one or more public frontends.
    /// </summary>
    public interface IWithPublicFrontend 
    {
        /// <summary>
        /// Begins the definition of a new load public balancer frontend.
        /// The definition must be completed with a call to  LoadBalancerPublicFrontend.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name for the frontend.</param>
        /// <return>The first stage of the new frontend definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPublicFrontendOrBackend> DefinePublicFrontend(string name);
    }

    /// <summary>
    /// The entirety of the load balancer definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IBlank,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithGroup,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithFrontend,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreate,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPublicFrontendOrBackend,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontendOrBackend,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithNetworkSubnet,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithBackend,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithBackendOrProbe,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbe,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrNat,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRule,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatPool,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndNatChoice
    {
    }

    /// <summary>
    /// The stage of a load balancer definition allowing to add a virtual machine to
    /// the load balancer's backend pool.
    /// </summary>
    /// <typeparam name="ReturnT">The next stage of the definition.</typeparam>
    public interface IWithVirtualMachine<ReturnT> 
    {
        /// <summary>
        /// Adds the specified set of virtual machines, assuming they are from the same
        /// availability set, to this load balancer's back end address pool.
        /// This will create a new backend address pool for this load balancer and add references to
        /// the primary IP configurations of the primary network interfaces of each of the provided set of
        /// virtual machines.
        /// If the virtual machines are not in the same availability set, the load balancer will still
        /// be created, but the virtual machines will not associated with its back end.
        /// Only those virtual machines will be associated with the load balancer that already have an existing
        /// network interface. Virtual machines without a network interface will be skipped.
        /// </summary>
        /// <param name="vms">Existing virtual machines.</param>
        /// <return>The next stage of the update.</return>
        ReturnT WithExistingVirtualMachines(params IHasNetworkInterfaces[] vms);
    }

    /// <summary>
    /// The stage of an Internet-facing load balancer definition allowing to add additional public frontends
    /// or add the first backend pool.
    /// </summary>
    public interface IWithPublicFrontendOrBackend  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPublicFrontend,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithBackend
    {
    }

    /// <summary>
    /// The stage of a load balancer definition allowing to create the load balancer or add an inbound NAT pool.
    /// </summary>
    public interface IWithCreateAndInboundNatPool  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreate,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithInboundNatPool
    {
    }

    /// <summary>
    /// The stage of a load balancer definition allowing to add another probe or start adding load balancing rules.
    /// </summary>
    public interface IWithProbeOrLoadBalancingRule  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbe,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRule
    {
    }

    /// <summary>
    /// The stage of a load balancer definition describing the nature of the frontend of the load balancer: internal or Internet-facing.
    /// </summary>
    public interface IWithFrontend  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPublicIPAddress<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPublicFrontendOrBackend>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPublicFrontend,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontend
    {
    }

    /// <summary>
    /// The stage of a load balancer definition allowing to create a new inbound NAT pool for a virtual machine scale set.
    /// </summary>
    public interface IWithInboundNatPool 
    {
        /// <summary>
        /// Begins the definition of a new inbount NAT pool to add to the load balancer.
        /// The definition must be completed with a call to  LoadBalancerInboundNatPool.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the inbound NAT pool.</param>
        /// <return>The first stage of the new inbound NAT pool definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatPool> DefineInboundNatPool(string name);
    }

    /// <summary>
    /// The stage of a load balancer definition allowing to specify an existing subnet as the private frontend.
    /// </summary>
    public interface IWithNetworkSubnet 
    {
        /// <summary>
        /// Assigns the specified subnet from the selected network as teh default private frontend of this load balancer,
        /// thereby making the load balancer internal.
        /// Once the first private frontend is added, only private frontends can be added thereafter.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <param name="subnetName">The name of an existing subnet on the specified network.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontendOrBackend WithFrontendSubnet(INetwork network, string subnetName);
    }

    /// <summary>
    /// The stage of a load balancer definition allowing to add a public IP address as the default public frontend.
    /// </summary>
    /// <typeparam name="ReturnT">The next stage of the definition.</typeparam>
    public interface IWithPublicIPAddress<ReturnT>  :
        Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Definition.IWithPublicIPAddress<ReturnT>
    {
    }

    /// <summary>
    /// The stage of a load balancer definition allowing to add a backend or start adding probes, or NAT rules, or NAT pools.
    /// </summary>
    public interface IWithBackendOrProbe  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithBackend,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrNat
    {
    }

    /// <summary>
    /// The first stage of a load balancer definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of an internal load balancer definition allowing to specify another private frontend or start specifying a backend.
    /// </summary>
    public interface IWithPrivateFrontendOrBackend  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontend,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithBackend
    {
    }

    /// <summary>
    /// The stage of the load balancer definition allowing to add a load balancing probe.
    /// </summary>
    public interface IWithProbe 
    {
        /// <summary>
        /// Adds an HTTP probe checking for an HTTP 200 response from the specified path at regular intervals, using port 80.
        /// An automatically generated name is assigned to the probe.
        /// </summary>
        /// <param name="requestPath">The path for the probe to invoke.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule WithHttpProbe(string requestPath);

        /// <summary>
        /// Begins the definition of a new TCP probe to add to the load balancer.
        /// The definition must be completed with a call to  LoadBalancerTcpProbe.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the probe.</param>
        /// <return>The first stage of the new probe definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerTcpProbe.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule> DefineTcpProbe(string name);

        /// <summary>
        /// Begins the definition of a new HTTP probe to add to the load balancer.
        /// The definition must be completed with a call to  LoadBalancerHttpProbe.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the probe.</param>
        /// <return>The first stage of the new probe definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule> DefineHttpProbe(string name);

        /// <summary>
        /// Adds a TCP probe checking the specified port.
        /// The probe will be named using an automatically generated name.
        /// </summary>
        /// <param name="port">The port number for the probe to monitor.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule WithTcpProbe(int port);
    }

    /// <summary>
    /// The stage of a load balancer definition allowing to add a backend.
    /// </summary>
    public interface IWithBackend  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithVirtualMachine<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithBackendOrProbe>
    {
        /// <summary>
        /// Starts the definition of a backend.
        /// </summary>
        /// <param name="name">The name to assign to the backend.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithBackendOrProbe> DefineBackend(string name);
    }

    /// <summary>
    /// The stage of a load balancer definition allowing to create the load balancer or add an inbound NAT rule.
    /// </summary>
    public interface IWithCreateAndInboundNatRule  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreate,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithInboundNatRule
    {
    }

    /// <summary>
    /// The stage of a load balancer definition allowing to create a load balancing rule or create the load balancer.
    /// </summary>
    public interface IWithLoadBalancingRuleOrCreate  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRule,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndNatChoice
    {
    }

    /// <summary>
    /// The stage of a load balancer definition allowing to create a new inbound NAT rule.
    /// </summary>
    public interface IWithInboundNatRule 
    {
        /// <summary>
        /// Begins the definition of a new inbound NAT rule to add to the load balancer.
        /// The definition must be completed with a call to  LoadBalancerInboundNatRule.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the inbound NAT rule.</param>
        /// <return>The first stage of the new inbound NAT rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule> DefineInboundNatRule(string name);
    }

    /// <summary>
    /// The stage of a load balancer definition allowing to add a probe or an inbound NAT rule or pool.
    /// </summary>
    public interface IWithProbeOrNat  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbe,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithInboundNatRule,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithInboundNatPool
    {
    }

    /// <summary>
    /// The stage of a load balancer definition containing all the required inputs for
    /// the resource to be created (via  WithCreate.create()), but also allowing
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The stage of an internal load balancer definition allowing to define one or more private frontends.
    /// </summary>
    public interface IWithPrivateFrontend  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithNetworkSubnet
    {
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontendOrBackend> DefinePrivateFrontend(string name);
    }

    /// <summary>
    /// The stage of the load balancer definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithFrontend>
    {
    }
}