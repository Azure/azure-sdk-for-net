// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading.Tasks;
    using LoadBalancer.Definition;
    using LoadBalancer.Update;
    using Models;
    using HasPublicIpAddress.Definition;
    using HasPublicIpAddress.UpdateDefinition;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    internal partial class LoadBalancerImpl 
    {
        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associates it with the resource.
        /// The internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">The leaf domain label.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancer.Definition.IWithPublicFrontendOrBackend HasPublicIpAddress.Definition.IWithNewPublicIpAddress<LoadBalancer.Definition.IWithPublicFrontendOrBackend>.WithNewPublicIpAddress(string leafDnsLabel)
        {
            return this.WithNewPublicIpAddress(leafDnsLabel) as LoadBalancer.Definition.IWithPublicFrontendOrBackend;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associates it with the resource.
        /// The internal name for the public IP address will be derived from the DNS label.
        /// </summary>
        /// <param name="leafDnsLabel">The leaf domain label.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancer.Update.IUpdate HasPublicIpAddress.UpdateDefinition.IWithNewPublicIpAddress<LoadBalancer.Update.IUpdate>.WithNewPublicIpAddress(string leafDnsLabel)
        {
            return this.WithNewPublicIpAddress(leafDnsLabel) as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Assigns the specified subnet from the selected network as teh default private frontend of this load balancer,
        /// thereby making the load balancer internal.
        /// Once the first private frontend is added, only private frontends can be added thereafter.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <param name="subnetName">The name of an existing subnet on the specified network.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancer.Definition.IWithPrivateFrontendOrBackend LoadBalancer.Definition.IWithNetworkSubnet.WithFrontendSubnet(INetwork network, string subnetName)
        {
            return this.WithFrontendSubnet(network, subnetName) as LoadBalancer.Definition.IWithPrivateFrontendOrBackend;
        }

        /// <summary>
        /// Assigns the specified subnet from the specified network to the default frontend of this load balancer.
        /// </summary>
        /// <param name="network">An existing virtual network.</param>
        /// <param name="subnetName">The name of an existing subnet on the specified network.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancer.Update.IUpdate LoadBalancer.Update.IWithNetworkSubnet.WithFrontendSubnet(INetwork network, string subnetName)
        {
            return this.WithFrontendSubnet(network, subnetName) as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new inbount NAT pool to add to the load balancer.
        /// The definition must be completed with a call to LoadBalancerInboundNatPool.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the inbound NAT pool.</param>
        /// <return>The first stage of the new inbound NAT pool definition.</return>
        LoadBalancerInboundNatPool.Definition.IBlank<LoadBalancer.Definition.IWithCreateAndInboundNatPool> LoadBalancer.Definition.IWithInboundNatPool.DefineInboundNatPool(string name)
        {
            return this.DefineInboundNatPool(name) as LoadBalancerInboundNatPool.Definition.IBlank<LoadBalancer.Definition.IWithCreateAndInboundNatPool>;
        }

        /// <summary>
        /// Begins the definition of a new inbound NAT pool.
        /// </summary>
        /// <param name="name">The name of the inbound NAT pool.</param>
        /// <return>The first stage of the new inbound NAT pool definition.</return>
        LoadBalancerInboundNatPool.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate> LoadBalancer.Update.IWithInboundNatPool.DefineInboundNatPool(string name)
        {
            return this.DefineInboundNatPool(name) as LoadBalancerInboundNatPool.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the description of an update to an existing inbound NAT pool.
        /// </summary>
        /// <param name="name">The name of the inbound NAT pool to update.</param>
        /// <return>The first stage of the inbound NAT pool update.</return>
        LoadBalancerInboundNatPool.Update.IUpdate LoadBalancer.Update.IWithInboundNatPool.UpdateInboundNatPool(string name)
        {
            return this.UpdateInboundNatPool(name) as LoadBalancerInboundNatPool.Update.IUpdate;
        }

        /// <summary>
        /// Removes the specified inbound NAT pool from the load balancer.
        /// </summary>
        /// <param name="name">The name of an existing inbound NAT pool on this load balancer.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancer.Update.IUpdate LoadBalancer.Update.IWithInboundNatPool.WithoutInboundNatPool(string name)
        {
            return this.WithoutInboundNatPool(name) as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Begins the update of an internal load balancer frontend.
        /// </summary>
        /// <param name="name">The name for the frontend.</param>
        /// <return>The first stage of the new frontend definition.</return>
        LoadBalancerPrivateFrontend.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate> LoadBalancer.Update.IWithInternalFrontend.DefinePrivateFrontend(string name)
        {
            return this.DefinePrivateFrontend(name) as LoadBalancerPrivateFrontend.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the description of an update to an existing internal frontend.
        /// </summary>
        /// <param name="name">The name of an existing frontend from this load balancer.</param>
        /// <return>The first stage of the frontend update.</return>
        LoadBalancerPrivateFrontend.Update.IUpdate LoadBalancer.Update.IWithInternalFrontend.UpdateInternalFrontend(string name)
        {
            return this.UpdateInternalFrontend(name) as LoadBalancerPrivateFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new inbound NAT rule to add to the load balancer.
        /// The definition must be completed with a call to LoadBalancerInboundNatRule.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the inbound NAT rule.</param>
        /// <return>The first stage of the new inbound NAT rule definition.</return>
        LoadBalancerInboundNatRule.Definition.IBlank<LoadBalancer.Definition.IWithCreateAndInboundNatRule> LoadBalancer.Definition.IWithInboundNatRule.DefineInboundNatRule(string name)
        {
            return this.DefineInboundNatRule(name) as LoadBalancerInboundNatRule.Definition.IBlank<LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Begins the definition of a new inbound NAT rule.
        /// The definition must be completed with a call to LoadBalancerInboundNatRule.UpdateDefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name for the inbound NAT rule.</param>
        /// <return>The first stage of the new inbound NAT rule definition.</return>
        LoadBalancerInboundNatRule.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate> LoadBalancer.Update.IWithInboundNatRule.DefineInboundNatRule(string name)
        {
            return this.DefineInboundNatRule(name) as LoadBalancerInboundNatRule.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the description of an update to an existing inbound NAT rule.
        /// </summary>
        /// <param name="name">The name of the inbound NAT rule to update.</param>
        /// <return>The first stage of the inbound NAT rule update.</return>
        LoadBalancerInboundNatRule.Update.IUpdate LoadBalancer.Update.IWithInboundNatRule.UpdateInboundNatRule(string name)
        {
            return this.UpdateInboundNatRule(name) as LoadBalancerInboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Removes the specified inbound NAT rule from the load balancer.
        /// </summary>
        /// <param name="name">The name of an existing inbound NAT rule on this load balancer.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancer.Update.IUpdate LoadBalancer.Update.IWithInboundNatRule.WithoutInboundNatRule(string name)
        {
            return this.WithoutInboundNatRule(name) as LoadBalancer.Update.IUpdate;
        }

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
        LoadBalancer.Definition.IWithBackendOrProbe LoadBalancer.Definition.IWithVirtualMachine<LoadBalancer.Definition.IWithBackendOrProbe>.WithExistingVirtualMachines(params IHasNetworkInterfaces[] vms)
        {
            return this.WithExistingVirtualMachines(vms) as LoadBalancer.Definition.IWithBackendOrProbe;
        }

        /// <summary>
        /// Begins the definition of a new load public balancer frontend.
        /// The definition must be completed with a call to LoadBalancerPublicFrontend.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name for the frontend.</param>
        /// <return>The first stage of the new frontend definition.</return>
        LoadBalancerPublicFrontend.Definition.IBlank<LoadBalancer.Definition.IWithPublicFrontendOrBackend> LoadBalancer.Definition.IWithPublicFrontend.DefinePublicFrontend(string name)
        {
            return this.DefinePublicFrontend(name) as LoadBalancerPublicFrontend.Definition.IBlank<LoadBalancer.Definition.IWithPublicFrontendOrBackend>;
        }

        /// <summary>
        /// Begins the description of an update to an existing Internet-facing frontend.
        /// </summary>
        /// <param name="name">The name of the frontend to update.</param>
        /// <return>The first stage of the frontend update.</return>
        LoadBalancerPublicFrontend.Update.IUpdate LoadBalancer.Update.IWithInternetFrontend.UpdateInternetFrontend(string name)
        {
            return this.UpdateInternetFrontend(name) as LoadBalancerPublicFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Begins the update of a load balancer frontend.
        /// The definition must be completed with a call to LoadBalancerPublicFrontend.UpdateDefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name for the frontend.</param>
        /// <return>The first stage of the new frontend definition.</return>
        LoadBalancerPublicFrontend.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate> LoadBalancer.Update.IWithInternetFrontend.DefinePublicFrontend(string name)
        {
            return this.DefinePublicFrontend(name) as LoadBalancerPublicFrontend.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Removes the specified frontend from the load balancer.
        /// </summary>
        /// <param name="name">The name of an existing front end on this load balancer.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancer.Update.IUpdate LoadBalancer.Update.IWithInternetFrontend.WithoutFrontend(string name)
        {
            return this.WithoutFrontend(name) as LoadBalancer.Update.IUpdate;
        }

        LoadBalancerPrivateFrontend.Definition.IBlank<LoadBalancer.Definition.IWithPrivateFrontendOrBackend> LoadBalancer.Definition.IWithPrivateFrontend.DefinePrivateFrontend(string name)
        {
            return this.DefinePrivateFrontend(name) as LoadBalancerPrivateFrontend.Definition.IBlank<LoadBalancer.Definition.IWithPrivateFrontendOrBackend>;
        }

        /// <summary>
        /// Begins the definition of a new TCP probe to add to the load balancer.
        /// The definition must be completed with a call to LoadBalancerTcpProbe.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the probe.</param>
        /// <return>The first stage of the new probe definition.</return>
        LoadBalancerTcpProbe.Definition.IBlank<LoadBalancer.Definition.IWithProbeOrLoadBalancingRule> LoadBalancer.Definition.IWithProbe.DefineTcpProbe(string name)
        {
            return this.DefineTcpProbe(name) as LoadBalancerTcpProbe.Definition.IBlank<LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>;
        }

        /// <summary>
        /// Adds an HTTP probe checking for an HTTP 200 response from the specified path at regular intervals, using port 80.
        /// An automatically generated name is assigned to the probe.
        /// </summary>
        /// <param name="requestPath">The path for the probe to invoke.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancer.Definition.IWithProbeOrLoadBalancingRule LoadBalancer.Definition.IWithProbe.WithHttpProbe(string requestPath)
        {
            return this.WithHttpProbe(requestPath) as LoadBalancer.Definition.IWithProbeOrLoadBalancingRule;
        }

        /// <summary>
        /// Begins the definition of a new HTTP probe to add to the load balancer.
        /// The definition must be completed with a call to LoadBalancerHttpProbe.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the probe.</param>
        /// <return>The first stage of the new probe definition.</return>
        LoadBalancerHttpProbe.Definition.IBlank<LoadBalancer.Definition.IWithProbeOrLoadBalancingRule> LoadBalancer.Definition.IWithProbe.DefineHttpProbe(string name)
        {
            return this.DefineHttpProbe(name) as LoadBalancerHttpProbe.Definition.IBlank<LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>;
        }

        /// <summary>
        /// Adds a TCP probe checking the specified port.
        /// The probe will be named using an automatically generated name.
        /// </summary>
        /// <param name="port">The port number for the probe to monitor.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancer.Definition.IWithProbeOrLoadBalancingRule LoadBalancer.Definition.IWithProbe.WithTcpProbe(int port)
        {
            return this.WithTcpProbe(port) as LoadBalancer.Definition.IWithProbeOrLoadBalancingRule;
        }

        /// <summary>
        /// Begins the definition of a new TCP probe to add to the load balancer.
        /// The definition must be completed with a call to LoadBalancerHttpProbe.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the new probe.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerTcpProbe.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate> LoadBalancer.Update.IWithProbe.DefineTcpProbe(string name)
        {
            return this.DefineTcpProbe(name) as LoadBalancerTcpProbe.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Adds an HTTP probe checking for an HTTP 200 response from the specified path at regular intervals, using port 80.
        /// An automatically generated name is assigned to the probe.
        /// </summary>
        /// <param name="requestPath">The path for the probe to invoke.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancer.Update.IUpdate LoadBalancer.Update.IWithProbe.WithHttpProbe(string requestPath)
        {
            return this.WithHttpProbe(requestPath) as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Begins the description of an update to an existing HTTP probe on this load balancer.
        /// </summary>
        /// <param name="name">The name of the probe to update.</param>
        /// <return>The first stage of the probe update.</return>
        LoadBalancerHttpProbe.Update.IUpdate LoadBalancer.Update.IWithProbe.UpdateHttpProbe(string name)
        {
            return this.UpdateHttpProbe(name) as LoadBalancerHttpProbe.Update.IUpdate;
        }

        /// <summary>
        /// Removes the specified probe from the load balancer, if present.
        /// </summary>
        /// <param name="name">The name of the probe to remove.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancer.Update.IUpdate LoadBalancer.Update.IWithProbe.WithoutProbe(string name)
        {
            return this.WithoutProbe(name) as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new HTTP probe to add to the load balancer.
        /// The definition must be completed with a call to LoadBalancerHttpProbe.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the new probe.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerHttpProbe.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate> LoadBalancer.Update.IWithProbe.DefineHttpProbe(string name)
        {
            return this.DefineHttpProbe(name) as LoadBalancerHttpProbe.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the description of an update to an existing TCP probe on this load balancer.
        /// </summary>
        /// <param name="name">The name of the probe to update.</param>
        /// <return>The first stage of the probe update.</return>
        LoadBalancerTcpProbe.Update.IUpdate LoadBalancer.Update.IWithProbe.UpdateTcpProbe(string name)
        {
            return this.UpdateTcpProbe(name) as LoadBalancerTcpProbe.Update.IUpdate;
        }

        /// <summary>
        /// Adds a TCP probe checking the specified port.
        /// The probe will be named using an automatically generated name.
        /// </summary>
        /// <param name="port">The port number for the probe to monitor.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancer.Update.IUpdate LoadBalancer.Update.IWithProbe.WithTcpProbe(int port)
        {
            return this.WithTcpProbe(port) as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Creates a load balancing rule between the specified front end and back end ports and protocol.
        /// The new rule will be assigned an automatically generated name.
        /// </summary>
        /// <param name="frontendPort">The port number on the front end to accept incoming traffic on.</param>
        /// <param name="protocol">The protocol to load balance.</param>
        /// <param name="backendPort">The port number on the back end to send load balanced traffic to.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate LoadBalancer.Definition.IWithLoadBalancingRule.WithLoadBalancingRule(int frontendPort, string protocol, int backendPort)
        {
            return this.WithLoadBalancingRule(frontendPort, protocol, backendPort) as LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate;
        }

        /// <summary>
        /// Creates a load balancing rule for the specified port and protocol and default frontend and backend associations.
        /// The load balancing rule will created under the name "default". It will reference a backend, a frontend, and a load balancing probe all named "default".
        /// </summary>
        /// <param name="port">The port number on the front and back end for the network traffic to be load balanced on.</param>
        /// <param name="protocol">The protocol to load balance.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate LoadBalancer.Definition.IWithLoadBalancingRule.WithLoadBalancingRule(int port, string protocol)
        {
            return this.WithLoadBalancingRule(port, protocol) as LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate;
        }

        /// <summary>
        /// Begins the definition of a new load balancing rule to add to the load balancer.
        /// The definition must be completed with a call to LoadBalancingRule.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the load balancing rule.</param>
        /// <return>The first stage of the new load balancing rule definition.</return>
        LoadBalancingRule.Definition.IBlank<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> LoadBalancer.Definition.IWithLoadBalancingRule.DefineLoadBalancingRule(string name)
        {
            return this.DefineLoadBalancingRule(name) as LoadBalancingRule.Definition.IBlank<LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Removes the specified load balancing rule from the load balancer, if present.
        /// </summary>
        /// <param name="name">The name of the load balancing rule to remove.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancer.Update.IUpdate LoadBalancer.Update.IWithLoadBalancingRule.WithoutLoadBalancingRule(string name)
        {
            return this.WithoutLoadBalancingRule(name) as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Adds a load balancing rule between the specified front end and back end ports and protocol.
        /// The new rule will be created under the name "default".
        /// </summary>
        /// <param name="frontendPort">The port number on the front end to accept incoming traffic on.</param>
        /// <param name="protocol">The protocol to load balance.</param>
        /// <param name="backendPort">The port number on the back end to send load balanced traffic to.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancer.Update.IUpdate LoadBalancer.Update.IWithLoadBalancingRule.WithLoadBalancingRule(int frontendPort, string protocol, int backendPort)
        {
            return this.WithLoadBalancingRule(frontendPort, protocol, backendPort) as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Adds a load balancing rule for the specified port and protocol.
        /// The new rule will be created under the name "default".
        /// </summary>
        /// <param name="port">The port number on the front and back end for the network traffic to be load balanced on.</param>
        /// <param name="protocol">The protocol to load balance.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancer.Update.IUpdate LoadBalancer.Update.IWithLoadBalancingRule.WithLoadBalancingRule(int port, string protocol)
        {
            return this.WithLoadBalancingRule(port, protocol) as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new load balancing rule to add to the load balancer.
        /// The definition must be completed with a call to LoadBalancerTcpProbe.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the load balancing rule.</param>
        /// <return>The first stage of the new load balancing rule definition.</return>
        LoadBalancingRule.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate> LoadBalancer.Update.IWithLoadBalancingRule.DefineLoadBalancingRule(string name)
        {
            return this.DefineLoadBalancingRule(name) as LoadBalancingRule.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the description of an update to an existing load balancing rule on this load balancer.
        /// </summary>
        /// <param name="name">The name of the load balancing rule to update.</param>
        /// <return>The first stage of the load balancing rule update.</return>
        LoadBalancingRule.Update.IUpdate LoadBalancer.Update.IWithLoadBalancingRule.UpdateLoadBalancingRule(string name)
        {
            return this.UpdateLoadBalancingRule(name) as LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associates it with the resource.
        /// The internal name and DNS label for the public IP address will be derived from the resource's name.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancer.Definition.IWithPublicFrontendOrBackend HasPublicIpAddress.Definition.IWithNewPublicIpAddressNoDnsLabel<LoadBalancer.Definition.IWithPublicFrontendOrBackend>.WithNewPublicIpAddress()
        {
            return this.WithNewPublicIpAddress() as LoadBalancer.Definition.IWithPublicFrontendOrBackend;
        }

        /// <summary>
        /// Creates a new public IP address to associate with the resource.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancer.Definition.IWithPublicFrontendOrBackend HasPublicIpAddress.Definition.IWithNewPublicIpAddressNoDnsLabel<LoadBalancer.Definition.IWithPublicFrontendOrBackend>.WithNewPublicIpAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress> creatable)
        {
            return this.WithNewPublicIpAddress(creatable) as LoadBalancer.Definition.IWithPublicFrontendOrBackend;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associates it with the resource.
        /// The internal name and DNS label for the public IP address will be derived from the resource's name.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        LoadBalancer.Update.IUpdate HasPublicIpAddress.UpdateDefinition.IWithNewPublicIpAddressNoDnsLabel<LoadBalancer.Update.IUpdate>.WithNewPublicIpAddress()
        {
            return this.WithNewPublicIpAddress() as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address to associate with the resource.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancer.Update.IUpdate HasPublicIpAddress.UpdateDefinition.IWithNewPublicIpAddressNoDnsLabel<LoadBalancer.Update.IUpdate>.WithNewPublicIpAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress> creatable)
        {
            return this.WithNewPublicIpAddress(creatable) as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancer.Definition.IWithPublicFrontendOrBackend HasPublicIpAddress.Definition.IWithExistingPublicIpAddress<LoadBalancer.Definition.IWithPublicFrontendOrBackend>.WithExistingPublicIpAddress(string resourceId)
        {
            return this.WithExistingPublicIpAddress(resourceId) as LoadBalancer.Definition.IWithPublicFrontendOrBackend;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIpAddress">An existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancer.Definition.IWithPublicFrontendOrBackend HasPublicIpAddress.Definition.IWithExistingPublicIpAddress<LoadBalancer.Definition.IWithPublicFrontendOrBackend>.WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress)
        {
            return this.WithExistingPublicIpAddress(publicIpAddress) as LoadBalancer.Definition.IWithPublicFrontendOrBackend;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancer.Update.IUpdate HasPublicIpAddress.UpdateDefinition.IWithExistingPublicIpAddress<LoadBalancer.Update.IUpdate>.WithExistingPublicIpAddress(string resourceId)
        {
            return this.WithExistingPublicIpAddress(resourceId) as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIpAddress">An existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancer.Update.IUpdate HasPublicIpAddress.UpdateDefinition.IWithExistingPublicIpAddress<LoadBalancer.Update.IUpdate>.WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress)
        {
            return this.WithExistingPublicIpAddress(publicIpAddress) as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Gets inbound NAT pools, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool> Microsoft.Azure.Management.Network.Fluent.ILoadBalancer.InboundNatPools
        {
            get
            {
                return this.InboundNatPools() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool>;
            }
        }

        /// <summary>
        /// Gets HTTP probes of this load balancer, indexed by the name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerHttpProbe> Microsoft.Azure.Management.Network.Fluent.ILoadBalancer.HttpProbes
        {
            get
            {
                return this.HttpProbes() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerHttpProbe>;
            }
        }

        /// <summary>
        /// Gets resource IDs of the public IP addresses assigned to the frontends of this load balancer.
        /// </summary>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.Network.Fluent.ILoadBalancer.PublicIpAddressIds
        {
            get
            {
                return this.PublicIpAddressIds() as System.Collections.Generic.IList<string>;
            }
        }

        /// <summary>
        /// Gets frontends for this load balancer, for the incoming traffic to come from.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerFrontend> Microsoft.Azure.Management.Network.Fluent.ILoadBalancer.Frontends
        {
            get
            {
                return this.Frontends() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerFrontend>;
            }
        }

        /// <summary>
        /// Gets backends for this load balancer to load balance the incoming traffic among, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend> Microsoft.Azure.Management.Network.Fluent.ILoadBalancer.Backends
        {
            get
            {
                return this.Backends() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend>;
            }
        }

        /// <summary>
        /// Gets TCP probes of this load balancer, indexed by the name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerTcpProbe> Microsoft.Azure.Management.Network.Fluent.ILoadBalancer.TcpProbes
        {
            get
            {
                return this.TcpProbes() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerTcpProbe>;
            }
        }

        /// <summary>
        /// Gets inbound NAT rules for this balancer.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatRule> Microsoft.Azure.Management.Network.Fluent.ILoadBalancer.InboundNatRules
        {
            get
            {
                return this.InboundNatRules() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatRule>;
            }
        }

        /// <summary>
        /// Gets the associated load balancing rules from this load balancer, indexed by their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancingRule> Microsoft.Azure.Management.Network.Fluent.IHasLoadBalancingRules.LoadBalancingRules
        {
            get
            {
                return this.LoadBalancingRules() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancingRule>;
            }
        }

        /// <summary>
        /// Starts the definition of a backend.
        /// </summary>
        /// <param name="name">The name to assign to the backend.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancerBackend.Definition.IBlank<LoadBalancer.Definition.IWithBackendOrProbe> LoadBalancer.Definition.IWithBackend.DefineBackend(string name)
        {
            return this.DefineBackend(name) as LoadBalancerBackend.Definition.IBlank<LoadBalancer.Definition.IWithBackendOrProbe>;
        }

        /// <summary>
        /// Begins the definition of a new backend as part of this load balancer update.
        /// </summary>
        /// <param name="name">The name for the new backend.</param>
        /// <return>The first stage of the backend definition.</return>
        LoadBalancerBackend.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate> LoadBalancer.Update.IWithBackend.DefineBackend(string name)
        {
            return this.DefineBackend(name) as LoadBalancerBackend.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Removes the specified backend from the load balancer.
        /// </summary>
        /// <param name="name">The name of the backend to remove.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancer.Update.IUpdate LoadBalancer.Update.IWithBackend.WithoutBackend(string name)
        {
            return this.WithoutBackend(name) as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Begins the description of an update to an existing backend of this load balancer.
        /// </summary>
        /// <param name="name">The name of the backend to update.</param>
        /// <return>The first stage of the update.</return>
        LoadBalancerBackend.Update.IUpdate LoadBalancer.Update.IWithBackend.UpdateBackend(string name)
        {
            return this.UpdateBackend(name) as LoadBalancerBackend.Update.IUpdate;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancer Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Network.Fluent.ILoadBalancer;
        }
    }
}