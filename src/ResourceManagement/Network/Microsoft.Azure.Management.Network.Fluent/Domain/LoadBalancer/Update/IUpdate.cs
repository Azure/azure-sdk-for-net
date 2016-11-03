// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update
{

    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerTcpProbe.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerTcpProbe.Update;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.UpdateDefinition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.UpdateDefinition;
    /// <summary>
    /// The stage of the load balancer update allowing to add, remove or modify probes.
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
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate WithTcpProbe(int port);

        /// <summary>
        /// Adds an HTTP probe checking for an HTTP 200 response from the specified path at regular intervals, using port 80.
        /// <p>
        /// An automatically generated name is assigned to the probe.
        /// </summary>
        /// <param name="requestPath">requestPath the path for the probe to invoke</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate WithHttpProbe(string requestPath);

        /// <summary>
        /// Begins the definition of a new HTTP probe to add to the load balancer.
        /// <p>
        /// The definition must be completed with a call to {@link HttpProbe.DefinitionStages.WithAttach#attach()}
        /// </summary>
        /// <param name="name">name the name of the new probe</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> DefineHttpProbe(string name);

        /// <summary>
        /// Begins the definition of a new TCP probe to add to the load balancer.
        /// <p>
        /// The definition must be completed with a call to {@link HttpProbe.DefinitionStages.WithAttach#attach()}
        /// </summary>
        /// <param name="name">name the name of the new probe</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerTcpProbe.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> DefineTcpProbe(string name);

        /// <summary>
        /// Removes the specified probe from the load balancer, if present.
        /// </summary>
        /// <param name="name">name the name of the probe to remove</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate WithoutProbe(string name);

        /// <summary>
        /// Begins the description of an update to an existing TCP probe on this load balancer.
        /// </summary>
        /// <param name="name">name the name of the probe to update</param>
        /// <returns>the first stage of the probe update</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerTcpProbe.Update.IUpdate UpdateTcpProbe(string name);

        /// <summary>
        /// Begins the description of an update to an existing HTTP probe on this load balancer.
        /// </summary>
        /// <param name="name">name the name of the probe to update</param>
        /// <returns>the first stage of the probe update</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.Update.IUpdate UpdateHttpProbe(string name);

    }
    /// <summary>
    /// The stage of a load balancer update allowing to add a public IP address as the default public frontend.
    /// </summary>
    public interface IWithPublicIpAddress 
    {
        /// <summary>
        /// Assigns the provided public IP address to the default public frontend to the load balancer.
        /// <p>
        /// This will create a new default frontend for the load balancer under the name "default", if one does not already exist.
        /// </summary>
        /// <param name="publicIpAddress">publicIpAddress an existing public IP address</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress);

        /// <summary>
        /// Creates a new public IP address as the default public frontend of the load balancer,
        /// using an automatically generated name and leaf DNS label
        /// derived from the load balancer's name, in the same resource group and region.
        /// <p>
        /// This will create a new default frontend for the load balancer under the name "default", if one does not already exist.
        /// </summary>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate WithNewPublicIpAddress();

        /// <summary>
        /// Adds a new public IP address as the default public frontend of the load balancer,
        /// using the specified DNS leaf label, an automatically generated frontend name derived from the DNS label,
        /// in the same resource group and region as the load balancer.
        /// </summary>
        /// <param name="dnsLeafLabel">dnsLeafLabel a DNS leaf label</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate WithNewPublicIpAddress(string dnsLeafLabel);

        /// <summary>
        /// Adds a new public IP address to the default front end of the load balancer.
        /// </summary>
        /// <param name="creatablePublicIpAddress">creatablePublicIpAddress the creatable stage of a public IP address definition</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate WithNewPublicIpAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress> creatablePublicIpAddress);

    }
    /// <summary>
    /// The stage of a load balancer update allowing to specify a subnet to assign to the load balancer's frontend.
    /// </summary>
    public interface IWithNetworkSubnet 
    {
        /// <summary>
        /// Assigns the specified subnet from the specified network to the default frontend of this load balancer.
        /// </summary>
        /// <param name="network">network an existing virtual network</param>
        /// <param name="subnetName">subnetName the name of an existing subnet on the specified network</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate WithExistingSubnet(INetwork network, string subnetName);

    }
    /// <summary>
    /// The stage of the load balancer update allowing to add or remove backends.
    /// </summary>
    public interface IWithBackend 
    {
        /// <summary>
        /// Removes the specified backend from the load balancer.
        /// </summary>
        /// <param name="name">name the name of the backend to remove</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate WithoutBackend(string name);

        /// <summary>
        /// Begins the definition of a new backend as part of this load balancer update.
        /// </summary>
        /// <param name="name">name the name for the new backend</param>
        /// <returns>the first stage of the backend definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> DefineBackend(string name);

        /// <summary>
        /// Begins the description of an update to an existing backend of this load balancer.
        /// </summary>
        /// <param name="name">name the name of the backend to update</param>
        /// <returns>the first stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.Update.IUpdate UpdateBackend(string name);

    }
    /// <summary>
    /// The template for a load balancer update operation, containing all the settings that
    /// can be modified.
    /// <p>
    /// Call {@link Update#apply()} to apply the changes to the resource in Azure.
    /// </summary>
    public interface IUpdate  :
        IAppliable<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        IUpdateWithTags<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>,
        IWithProbe,
        IWithBackend,
        IWithLoadBalancingRule,
        IWithInternetFrontend,
        IWithInternalFrontend,
        IWithNetworkSubnet,
        IWithInboundNatRule,
        IWithInboundNatPool
    {
    }
    /// <summary>
    /// The stage of a load balancer update allowing to define, remove or edit Internet-facing frontends.
    /// </summary>
    public interface IWithInternetFrontend  :
        IWithPublicIpAddress
    {
        /// <summary>
        /// Begins the update of a load balancer frontend.
        /// <p>
        /// The definition must be completed with a call to {@link PublicFrontend.UpdateDefinitionStages.WithAttach#attach()}
        /// </summary>
        /// <param name="name">name the name for the frontend</param>
        /// <returns>the first stage of the new frontend definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> DefinePublicFrontend(string name);

        /// <summary>
        /// Removes the specified frontend from the load balancer.
        /// </summary>
        /// <param name="name">name the name of an existing front end on this load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate WithoutFrontend(string name);

        /// <summary>
        /// Begins the description of an update to an existing Internet-facing frontend.
        /// </summary>
        /// <param name="name">name the name of the frontend to update</param>
        /// <returns>the first stage of the frontend update</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.Update.IUpdate UpdateInternetFrontend(string name);

    }
    /// <summary>
    /// The stage of a load balancer update allowing to define, remove or edit inbound NAT rules.
    /// </summary>
    public interface IWithInboundNatRule 
    {
        /// <summary>
        /// Removes the specified inbound NAT rule from the load balancer.
        /// </summary>
        /// <param name="name">name the name of an existing inbound NAT rule on this load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate WithoutInboundNatRule(string name);

        /// <summary>
        /// Begins the definition of a new inbound NAT rule.
        /// <p>
        /// The definition must be completed with a call to {@link InboundNatRule.UpdateDefinitionStages.WithAttach#attach()}
        /// </summary>
        /// <param name="name">name the name for the inbound NAT rule</param>
        /// <returns>the first stage of the new inbound NAT rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> DefineInboundNatRule(string name);

        /// <summary>
        /// Begins the description of an update to an existing inbound NAT rule.
        /// </summary>
        /// <param name="name">name the name of the inbound NAT rule to update</param>
        /// <returns>the first stage of the inbound NAT rule update</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Update.IUpdate UpdateInboundNatRule(string name);

    }
    /// <summary>
    /// The stage of a load balancer update allowing to define one or more private frontends.
    /// </summary>
    public interface IWithInternalFrontend  :
        IWithNetworkSubnet
    {
        /// <summary>
        /// Begins the update of an internal load balancer frontend.
        /// </summary>
        /// <param name="name">name the name for the frontend</param>
        /// <returns>the first stage of the new frontend definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> DefinePrivateFrontend(string name);

        /// <summary>
        /// Begins the description of an update to an existing internal frontend.
        /// </summary>
        /// <param name="name">name the name of an existing frontend from this load balancer</param>
        /// <returns>the first stage of the frontend update</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.Update.IUpdate UpdateInternalFrontend(string name);

    }
    /// <summary>
    /// The stage of the load balancer update allowing to add, remove or modify load balancing rules.
    /// </summary>
    public interface IWithLoadBalancingRule 
    {
        /// <summary>
        /// Adds a load balancing rule between the specified front end and back end ports and protocol.
        /// <p>
        /// The new rule will be created under the name "default".
        /// </summary>
        /// <param name="frontendPort">frontendPort the port number on the front end to accept incoming traffic on</param>
        /// <param name="protocol">protocol the protocol to load balance</param>
        /// <param name="backendPort">backendPort the port number on the back end to send load balanced traffic to</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate WithLoadBalancingRule(int frontendPort, string protocol, int backendPort);

        /// <summary>
        /// Adds a load balancing rule for the specified port and protocol.
        /// <p>
        /// The new rule will be created under the name "default".
        /// </summary>
        /// <param name="port">port the port number on the front and back end for the network traffic to be load balanced on</param>
        /// <param name="protocol">protocol the protocol to load balance</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate WithLoadBalancingRule(int port, string protocol);

        /// <summary>
        /// Begins the definition of a new load balancing rule to add to the load balancer.
        /// <p>
        /// The definition must be completed with a call to {@link TcpProbe.DefinitionStages.WithAttach#attach()}
        /// </summary>
        /// <param name="name">name the name of the load balancing rule</param>
        /// <returns>the first stage of the new load balancing rule definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> DefineLoadBalancingRule(string name);

        /// <summary>
        /// Removes the specified load balancing rule from the load balancer, if present.
        /// </summary>
        /// <param name="name">name the name of the load balancing rule to remove</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate WithoutLoadBalancingRule(string name);

        /// <summary>
        /// Begins the description of an update to an existing load balancing rule on this load balancer.
        /// </summary>
        /// <param name="name">name the name of the load balancing rule to update</param>
        /// <returns>the first stage of the load balancing rule update</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate UpdateLoadBalancingRule(string name);

    }
    /// <summary>
    /// The stage of a load balancer update allowing to create a new inbound NAT pool for a virtual machine scale set.
    /// </summary>
    public interface IWithInboundNatPool 
    {
        /// <summary>
        /// Removes the specified inbound NAT pool from the load balancer.
        /// </summary>
        /// <param name="name">name the name of an existing inbound NAT pool on this load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate WithoutInboundNatPool(string name);

        /// <summary>
        /// Begins the definition of a new inbound NAT pool.
        /// </summary>
        /// <param name="name">name the name of the inbound NAT pool</param>
        /// <returns>the first stage of the new inbound NAT pool definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> DefineInboundNatPool(string name);

        /// <summary>
        /// Begins the description of an update to an existing inbound NAT pool.
        /// </summary>
        /// <param name="name">name the name of the inbound NAT pool to update</param>
        /// <returns>the first stage of the inbound NAT pool update</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Update.IUpdate UpdateInboundNatPool(string name);

    }
}