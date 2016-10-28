// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition
{

    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition;
    using Microsoft.Azure.Management.Network.Fluent.InboundNatPool.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerTcpProbe.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.Definition;
    /// <summary>
    /// The stage of a load balancer definition describing the nature of the frontend of the load balancer: internal or Internet-facing.
    /// </summary>
    public interface IWithFrontend  :
        IWithPublicIpAddress<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPublicFrontendOrBackend>,
        IWithPublicFrontend,
        IWithPrivateFrontend
    {
    }
    /// <summary>
    /// The stage of a load balancer definition allowing to create the load balancer or start configuring optional inbound NAT rules or pools.
    /// </summary>
    public interface IWithCreateAndNatChoice  :
        IWithCreate,
        IWithInboundNatRule,
        IWithInboundNatPool
    {
    }
    /// <summary>
    /// The stage of a load balancer definition containing all the required inputs for
    /// the resource to be created (via {@link WithCreate#create()}), but also allowing
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        IDefinitionWithTags<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreate>
    {
    }
    /// <summary>
    /// The stage of a load balancer definition allowing to add a public IP address as the default public frontend.
    /// @param <ReturnT> the next stage of the definition
    /// </summary>
    public interface IWithPublicIpAddress<ReturnT> 
    {
        /// <summary>
        /// Assigns the provided public IP address to the default public frontend to the load balancer,
        /// making it an Internet-facing load balancer.
        /// <p>
        /// This will create a new default frontend for the load balancer under the name "default".
        /// <p>
        /// Once the first public frontend is specified, only public frontends can be added, not private.
        /// </summary>
        /// <param name="publicIpAddress">publicIpAddress an existing public IP address</param>
        /// <returns>the next stage of the definition</returns>
        ReturnT WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress);

        /// <summary>
        /// Creates a new public IP address as the default public frontend of the load balancer,
        /// using an automatically generated name and leaf DNS label
        /// derived from the load balancer's name, in the same resource group and region.
        /// <p>
        /// This will create a new default frontend for the load balancer under the name "default".
        /// <p>
        /// Once the first public frontend is specified, only public frontends can be added, not private.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        ReturnT WithNewPublicIpAddress();

        /// <summary>
        /// Adds a new public IP address as the default public frontend of the load balancer,
        /// using the specified DNS leaf label, an automatically generated frontend name derived from the DNS label,
        /// in the same resource group and region as the load balancer.
        /// </summary>
        /// <param name="dnsLeafLabel">dnsLeafLabel a DNS leaf label</param>
        /// <returns>the next stage of the definition</returns>
        ReturnT WithNewPublicIpAddress(string dnsLeafLabel);

        /// <summary>
        /// Adds a new public IP address to the front end of the load balancer,
        /// creating the public IP based on the provided {@link Creatable}
        /// stage of a public IP endpoint's definition.
        /// </summary>
        /// <param name="creatablePublicIpAddress">creatablePublicIpAddress the creatable stage of a public IP address definition</param>
        /// <returns>the next stage of the definition</returns>
        ReturnT WithNewPublicIpAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress> creatablePublicIpAddress);

    }
    /// <summary>
    /// The stage of a load balancer definition allowing to add a backend or start adding probes.
    /// </summary>
    public interface IWithBackendOrProbe  :
        IWithBackend,
        IWithProbe
    {
    }
    /// <summary>
    /// The stage of a load balancer definition allowing to create a new inbound NAT rule.
    /// </summary>
    public interface IWithInboundNatRule 
    {
        /// <summary>
        /// Begins the definition of a new inbound NAT rule to add to the load balancer.
        /// <p>
        /// The definition must be completed with a call to {@link InboundNatRule.DefinitionStages.WithAttach#attach()}
        /// </summary>
        /// <param name="name">name the name of the inbound NAT rule</param>
        /// <returns>the first stage of the new inbound NAT rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatRule.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule> DefineInboundNatRule(string name);

    }
    /// <summary>
    /// The stage of a load balancer definition allowing to add a virtual machine to
    /// the load balancer's backend pool.
    /// @param <ReturnT> the next stage of the definition
    /// </summary>
    public interface IWithVirtualMachine<ReturnT> 
    {
        /// <summary>
        /// Adds the specified set of virtual machines, assuming they are from the same
        /// availability set, to this load balancer's back end address pool.
        /// <p>
        /// This will create a new backend address pool for this load balancer and add references to
        /// the primary IP configurations of the primary network interfaces of each of the provided set of
        /// virtual machines.
        /// <p>
        /// If the virtual machines are not in the same availability set, the load balancer will still
        /// be created, but the virtual machines will not associated with its back end.
        /// <p>
        /// Only those virtual machines will be associated with the load balancer that already have an existing
        /// network interface. Virtual machines without a network interface will be skipped.
        /// </summary>
        /// <param name="vms">vms existing virtual machines</param>
        /// <returns>the next stage of the update</returns>
        ReturnT WithExistingVirtualMachines(params IHasNetworkInterfaces[] vms);

    }
    /// <summary>
    /// The stage of an Internet-facing load balancer definition allowing to add additional public frontends
    /// or add the first backend pool.
    /// </summary>
    public interface IWithPublicFrontendOrBackend  :
        IWithPublicFrontend,
        IWithBackend
    {
    }
    /// <summary>
    /// The first stage of a load balancer definition.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithGroup>
    {
    }
    /// <summary>
    /// The stage of a load balancer definition allowing to create a new inbound NAT pool for a virtual machine scale set.
    /// </summary>
    public interface IWithInboundNatPool 
    {
        /// <summary>
        /// Begins the definition of a new inbount NAT pool to add to the load balancer.
        /// <p>
        /// The definition must be completed with a call to {@link InboundNatPool.DefinitionStages.WithAttach#attach()}
        /// </summary>
        /// <param name="name">name the name of the inbound NAT pool</param>
        /// <returns>the first stage of the new inbound NAT pool definition</returns>
        Microsoft.Azure.Management.Network.Fluent.InboundNatPool.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatPool> DefineInboundNatPool(string name);

    }
    /// <summary>
    /// The stage of a load balancer definition allowing to create the load balancer or add an inbound NAT pool.
    /// </summary>
    public interface IWithCreateAndInboundNatPool  :
        IWithCreate,
        IWithInboundNatPool
    {
    }
    /// <summary>
    /// The stage of a load balancer definition allowing to add another probe or start adding load balancing rules.
    /// </summary>
    public interface IWithProbeOrLoadBalancingRule  :
        IWithProbe,
        IWithLoadBalancingRule
    {
    }
    /// <summary>
    /// The stage of a load balancer definition allowing to create a load balancing rule or create the load balancer.
    /// </summary>
    public interface IWithLoadBalancingRuleOrCreate  :
        IWithLoadBalancingRule,
        IWithCreateAndNatChoice
    {
    }
    /// <summary>
    /// The stage of an Internet-facing load balancer definition allowing to define one or more public frontends.
    /// </summary>
    public interface IWithPublicFrontend 
    {
        /// <summary>
        /// Begins the definition of a new load public balancer frontend.
        /// <p>
        /// The definition must be completed with a call to {@link PublicFrontend.DefinitionStages.WithAttach#attach()}
        /// </summary>
        /// <param name="name">name the name for the frontend</param>
        /// <returns>the first stage of the new frontend definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPublicFrontendOrBackend> DefinePublicFrontend(string name);

    }
    /// <summary>
    /// The stage of a load balancer definition allowing to specify an existing subnet as the private frontend.
    /// </summary>
    public interface IWithNetworkSubnet 
    {
        /// <summary>
        /// Assigns the specified subnet from the selected network as teh default private frontend of this load balancer,
        /// thereby making the load balancer internal.
        /// <p>
        /// Once the first private frontend is added, only private frontends can be added thereafter.
        /// </summary>
        /// <param name="network">network an existing virtual network</param>
        /// <param name="subnetName">subnetName the name of an existing subnet on the specified network</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontendOrBackend WithExistingSubnet(INetwork network, string subnetName);

    }
    /// <summary>
    /// The entirety of the load balancer definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IBlank,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithGroup,
        IWithFrontend,
        IWithCreate,
        IWithPublicFrontendOrBackend,
        IWithPrivateFrontendOrBackend,
        IWithNetworkSubnet,
        IWithBackend,
        IWithBackendOrProbe,
        IWithProbe,
        IWithProbeOrLoadBalancingRule,
        IWithLoadBalancingRule,
        IWithLoadBalancingRuleOrCreate,
        IWithCreateAndInboundNatPool,
        IWithCreateAndInboundNatRule,
        IWithCreateAndNatChoice
    {
    }
    /// <summary>
    /// The stage of a load balancer definition allowing to create a load balancing rule.
    /// </summary>
    public interface IWithLoadBalancingRule 
    {
        /// <summary>
        /// Creates a load balancing rule between the specified front end and back end ports and protocol.
        /// <p>
        /// The new rule will be assigned an automatically generated name.
        /// </summary>
        /// <param name="frontendPort">frontendPort the port number on the front end to accept incoming traffic on</param>
        /// <param name="protocol">protocol the protocol to load balance</param>
        /// <param name="backendPort">backendPort the port number on the back end to send load balanced traffic to</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate WithLoadBalancingRule(int frontendPort, string protocol, int backendPort);

        /// <summary>
        /// Creates a load balancing rule for the specified port and protocol and default frontend and backend associations.
        /// <p>
        /// The load balancing rule will created under the name "default". It will reference a backend, a frontend, and a load balancing probe all named "default".
        /// </summary>
        /// <param name="port">port the port number on the front and back end for the network traffic to be load balanced on</param>
        /// <param name="protocol">protocol the protocol to load balance</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate WithLoadBalancingRule(int port, string protocol);

        /// <summary>
        /// Begins the definition of a new load balancing rule to add to the load balancer.
        /// <p>
        /// The definition must be completed with a call to {@link LoadBalancingRule.DefinitionStages.WithAttach#attach()}
        /// </summary>
        /// <param name="name">name the name of the load balancing rule</param>
        /// <returns>the first stage of the new load balancing rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> DefineLoadBalancingRule(string name);

    }
    /// <summary>
    /// The stage of the load balancer definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.Resource.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithFrontend>
    {
    }
    /// <summary>
    /// The stage of a load balancer definition allowing to add a backend.
    /// </summary>
    public interface IWithBackend  :
        IWithVirtualMachine<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithBackendOrProbe>
    {
        /// <summary>
        /// Starts the definition of a backend.
        /// </summary>
        /// <param name="name">name the name to assign to the backend</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithBackendOrProbe> DefineBackend(string name);

    }
    /// <summary>
    /// The stage of the load balancer definition allowing to add a load balancing probe.
    /// </summary>
    public interface IWithProbe 
    {
        /// <summary>
        /// Adds a TCP probe checking the specified port.
        /// <p>
        /// The probe will be named using an automatically generated name.
        /// </summary>
        /// <param name="port">port the port number for the probe to monitor</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule WithTcpProbe(int port);

        /// <summary>
        /// Adds an HTTP probe checking for an HTTP 200 response from the specified path at regular intervals, using port 80.
        /// <p>
        /// An automatically generated name is assigned to the probe.
        /// </summary>
        /// <param name="requestPath">requestPath the path for the probe to invoke</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule WithHttpProbe(string requestPath);

        /// <summary>
        /// Begins the definition of a new TCP probe to add to the load balancer.
        /// <p>
        /// The definition must be completed with a call to {@link TcpProbe.DefinitionStages.WithAttach#attach()}
        /// </summary>
        /// <param name="name">name the name of the probe</param>
        /// <returns>the first stage of the new probe definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerTcpProbe.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule> DefineTcpProbe(string name);

        /// <summary>
        /// Begins the definition of a new HTTP probe to add to the load balancer.
        /// <p>
        /// The definition must be completed with a call to {@link HttpProbe.DefinitionStages.WithAttach#attach()}
        /// </summary>
        /// <param name="name">name the name of the probe</param>
        /// <returns>the first stage of the new probe definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule> DefineHttpProbe(string name);

    }
    /// <summary>
    /// The stage of an internal load balancer definition allowing to specify another private frontend or start specifying a backend.
    /// </summary>
    public interface IWithPrivateFrontendOrBackend  :
        IWithPrivateFrontend,
        IWithBackend
    {
    }
    /// <summary>
    /// The stage of an internal load balancer definition allowing to define one or more private frontends.
    /// </summary>
    public interface IWithPrivateFrontend  :
        IWithNetworkSubnet
    {
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontendOrBackend> DefinePrivateFrontend(string name);

    }
    /// <summary>
    /// The stage of a load balancer definition allowing to create the load balancer or add an inbound NAT rule.
    /// </summary>
    public interface IWithCreateAndInboundNatRule  :
        IWithCreate,
        IWithInboundNatRule
    {
    }
}