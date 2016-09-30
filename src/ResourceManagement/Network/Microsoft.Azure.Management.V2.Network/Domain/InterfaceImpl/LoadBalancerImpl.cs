// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{

    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition;
    using Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.Fluent.Resource.Core;
    public partial class LoadBalancerImpl 
    {
        /// <summary>
        /// Assigns the provided public IP address to the default public frontend to the load balancer.
        /// <p>
        /// This will create a new default frontend for the load balancer under the name "default", if one does not already exist.
        /// </summary>
        /// <param name="publicIpAddress">publicIpAddress an existing public IP address</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithPublicIpAddress.WithExistingPublicIpAddress (IPublicIpAddress publicIpAddress) { 
            return this.WithExistingPublicIpAddress( publicIpAddress) as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address as the default public frontend of the load balancer,
        /// using an automatically generated name and leaf DNS label
        /// derived from the load balancer's name, in the same resource group and region.
        /// <p>
        /// This will create a new default frontend for the load balancer under the name "default", if one does not already exist.
        /// </summary>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithPublicIpAddress.WithNewPublicIpAddress () { 
            return this.WithNewPublicIpAddress() as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Adds a new public IP address as the default public frontend of the load balancer,
        /// using the specified DNS leaf label, an automatically generated frontend name derived from the DNS label,
        /// in the same resource group and region as the load balancer.
        /// </summary>
        /// <param name="dnsLeafLabel">dnsLeafLabel a DNS leaf label</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithPublicIpAddress.WithNewPublicIpAddress (string dnsLeafLabel) { 
            return this.WithNewPublicIpAddress( dnsLeafLabel) as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Adds a new public IP address to the default front end of the load balancer.
        /// </summary>
        /// <param name="creatablePublicIpAddress">creatablePublicIpAddress the creatable stage of a public IP address definition</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithPublicIpAddress.WithNewPublicIpAddress (ICreatable<Microsoft.Azure.Management.Fluent.Network.IPublicIpAddress> creatablePublicIpAddress) { 
            return this.WithNewPublicIpAddress( creatablePublicIpAddress) as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Assigns the specified subnet from the selected network as teh default private frontend of this load balancer,
        /// thereby making the load balancer internal.
        /// <p>
        /// Once the first private frontend is added, only private frontends can be added thereafter.
        /// </summary>
        /// <param name="network">network an existing virtual network</param>
        /// <param name="subnetName">subnetName the name of an existing subnet on the specified network</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithPrivateFrontendOrBackend Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithNetworkSubnet.WithExistingSubnet (INetwork network, string subnetName) { 
            return this.WithExistingSubnet( network,  subnetName) as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithPrivateFrontendOrBackend;
        }

        /// <summary>
        /// Assigns the specified subnet from the specified network to the default frontend of this load balancer.
        /// </summary>
        /// <param name="network">network an existing virtual network</param>
        /// <param name="subnetName">subnetName the name of an existing subnet on the specified network</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithNetworkSubnet.WithExistingSubnet (INetwork network, string subnetName) { 
            return this.WithExistingSubnet( network,  subnetName) as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new inbount NAT pool to add to the load balancer.
        /// <p>
        /// The definition must be completed with a call to {@link InboundNatPool.DefinitionStages.WithAttach#attach()}
        /// </summary>
        /// <param name="name">name the name of the inbound NAT pool</param>
        /// <returns>the first stage of the new inbound NAT pool definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Definition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatPool> Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithInboundNatPool.DefineInboundNatPool (string name) { 
            return this.DefineInboundNatPool( name) as Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Definition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatPool>;
        }

        /// <summary>
        /// Begins the definition of a new inbound NAT pool.
        /// </summary>
        /// <param name="name">name the name of the inbound NAT pool</param>
        /// <returns>the first stage of the new inbound NAT pool definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatPool.UpdateDefinition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithInboundNatPool.DefineInboundNatPool (string name) { 
            return this.DefineInboundNatPool( name) as Microsoft.Azure.Management.Fluent.Network.InboundNatPool.UpdateDefinition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the description of an update to an existing inbound NAT pool.
        /// </summary>
        /// <param name="name">name the name of the inbound NAT pool to update</param>
        /// <returns>the first stage of the inbound NAT pool update</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithInboundNatPool.UpdateInboundNatPool (string name) { 
            return this.UpdateInboundNatPool( name) as Microsoft.Azure.Management.Fluent.Network.InboundNatPool.Update.IUpdate;
        }

        /// <summary>
        /// Removes the specified inbound NAT pool from the load balancer.
        /// </summary>
        /// <param name="name">name the name of an existing inbound NAT pool on this load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithInboundNatPool.WithoutInboundNatPool (string name) { 
            return this.WithoutInboundNatPool( name) as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate;
        }

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
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithPublicFrontendOrBackend Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithPublicIpAddress<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithPublicFrontendOrBackend>.WithExistingPublicIpAddress (IPublicIpAddress publicIpAddress) { 
            return this.WithExistingPublicIpAddress( publicIpAddress) as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithPublicFrontendOrBackend;
        }

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
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithPublicFrontendOrBackend Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithPublicIpAddress<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithPublicFrontendOrBackend>.WithNewPublicIpAddress () { 
            return this.WithNewPublicIpAddress() as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithPublicFrontendOrBackend;
        }

        /// <summary>
        /// Adds a new public IP address as the default public frontend of the load balancer,
        /// using the specified DNS leaf label, an automatically generated frontend name derived from the DNS label,
        /// in the same resource group and region as the load balancer.
        /// </summary>
        /// <param name="dnsLeafLabel">dnsLeafLabel a DNS leaf label</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithPublicFrontendOrBackend Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithPublicIpAddress<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithPublicFrontendOrBackend>.WithNewPublicIpAddress (string dnsLeafLabel) { 
            return this.WithNewPublicIpAddress( dnsLeafLabel) as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithPublicFrontendOrBackend;
        }

        /// <summary>
        /// Adds a new public IP address to the front end of the load balancer,
        /// creating the public IP based on the provided {@link Creatable}
        /// stage of a public IP endpoint's definition.
        /// </summary>
        /// <param name="creatablePublicIpAddress">creatablePublicIpAddress the creatable stage of a public IP address definition</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithPublicFrontendOrBackend Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithPublicIpAddress<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithPublicFrontendOrBackend>.WithNewPublicIpAddress (ICreatable<Microsoft.Azure.Management.Fluent.Network.IPublicIpAddress> creatablePublicIpAddress) { 
            return this.WithNewPublicIpAddress( creatablePublicIpAddress) as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithPublicFrontendOrBackend;
        }

        /// <summary>
        /// Begins the update of an internal load balancer frontend.
        /// </summary>
        /// <param name="name">name the name for the frontend</param>
        /// <returns>the first stage of the new frontend definition</returns>
        Microsoft.Azure.Management.Fluent.Network.PrivateFrontend.UpdateDefinition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithInternalFrontend.DefinePrivateFrontend (string name) { 
            return this.DefinePrivateFrontend( name) as Microsoft.Azure.Management.Fluent.Network.PrivateFrontend.UpdateDefinition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the description of an update to an existing internal frontend.
        /// </summary>
        /// <param name="name">name the name of an existing frontend from this load balancer</param>
        /// <returns>the first stage of the frontend update</returns>
        Microsoft.Azure.Management.Fluent.Network.PrivateFrontend.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithInternalFrontend.UpdateInternalFrontend (string name) { 
            return this.UpdateInternalFrontend( name) as Microsoft.Azure.Management.Fluent.Network.PrivateFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new inbound NAT rule to add to the load balancer.
        /// <p>
        /// The definition must be completed with a call to {@link InboundNatRule.DefinitionStages.WithAttach#attach()}
        /// </summary>
        /// <param name="name">name the name of the inbound NAT rule</param>
        /// <returns>the first stage of the new inbound NAT rule definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule> Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithInboundNatRule.DefineInboundNatRule (string name) { 
            return this.DefineInboundNatRule( name) as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Definition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Begins the definition of a new inbound NAT rule.
        /// <p>
        /// The definition must be completed with a call to {@link InboundNatRule.UpdateDefinitionStages.WithAttach#attach()}
        /// </summary>
        /// <param name="name">name the name for the inbound NAT rule</param>
        /// <returns>the first stage of the new inbound NAT rule definition</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithInboundNatRule.DefineInboundNatRule (string name) { 
            return DefineInboundNatRule( name) as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the description of an update to an existing inbound NAT rule.
        /// </summary>
        /// <param name="name">name the name of the inbound NAT rule to update</param>
        /// <returns>the first stage of the inbound NAT rule update</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithInboundNatRule.UpdateInboundNatRule (string name) { 
            return UpdateInboundNatRule( name) as Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Removes the specified inbound NAT rule from the load balancer.
        /// </summary>
        /// <param name="name">name the name of an existing inbound NAT rule on this load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithInboundNatRule.WithoutInboundNatRule (string name) { 
            return WithoutInboundNatRule( name) as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate;
        }

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
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithBackendOrProbe Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithVirtualMachine<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithBackendOrProbe>.WithExistingVirtualMachines (params IHasNetworkInterfaces[] vms) { 
            return WithExistingVirtualMachines( vms) as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithBackendOrProbe;
        }

        /// <summary>
        /// Begins the definition of a new load public balancer frontend.
        /// <p>
        /// The definition must be completed with a call to {@link PublicFrontend.DefinitionStages.WithAttach#attach()}
        /// </summary>
        /// <param name="name">name the name for the frontend</param>
        /// <returns>the first stage of the new frontend definition</returns>
        Microsoft.Azure.Management.Fluent.Network.PublicFrontend.Definition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithPublicFrontendOrBackend> Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithPublicFrontend.DefinePublicFrontend (string name) { 
            return DefinePublicFrontend( name) as Microsoft.Azure.Management.Fluent.Network.PublicFrontend.Definition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithPublicFrontendOrBackend>;
        }

        /// <summary>
        /// Begins the description of an update to an existing Internet-facing frontend.
        /// </summary>
        /// <param name="name">name the name of the frontend to update</param>
        /// <returns>the first stage of the frontend update</returns>
        Microsoft.Azure.Management.Fluent.Network.PublicFrontend.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithInternetFrontend.UpdateInternetFrontend (string name) { 
            return UpdateInternetFrontend( name) as Microsoft.Azure.Management.Fluent.Network.PublicFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Begins the update of a load balancer frontend.
        /// <p>
        /// The definition must be completed with a call to {@link PublicFrontend.UpdateDefinitionStages.WithAttach#attach()}
        /// </summary>
        /// <param name="name">name the name for the frontend</param>
        /// <returns>the first stage of the new frontend definition</returns>
        Microsoft.Azure.Management.Fluent.Network.PublicFrontend.UpdateDefinition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithInternetFrontend.DefinePublicFrontend (string name) { 
            return this.DefinePublicFrontend( name) as Microsoft.Azure.Management.Fluent.Network.PublicFrontend.UpdateDefinition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Removes the specified frontend from the load balancer.
        /// </summary>
        /// <param name="name">name the name of an existing front end on this load balancer</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithInternetFrontend.WithoutFrontend (string name) { 
            return this.WithoutFrontend( name) as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate;
        }

        Microsoft.Azure.Management.Fluent.Network.PrivateFrontend.Definition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithPrivateFrontendOrBackend> Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithPrivateFrontend.DefinePrivateFrontend (string name) { 
            return this.DefinePrivateFrontend( name) as Microsoft.Azure.Management.Fluent.Network.PrivateFrontend.Definition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithPrivateFrontendOrBackend>;
        }

        /// <summary>
        /// Begins the definition of a new TCP probe to add to the load balancer.
        /// <p>
        /// The definition must be completed with a call to {@link TcpProbe.DefinitionStages.WithAttach#attach()}
        /// </summary>
        /// <param name="name">name the name of the probe</param>
        /// <returns>the first stage of the new probe definition</returns>
        Microsoft.Azure.Management.Fluent.Network.TcpProbe.Definition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule> Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbe.DefineTcpProbe (string name) { 
            return this.DefineTcpProbe( name) as Microsoft.Azure.Management.Fluent.Network.TcpProbe.Definition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>;
        }

        /// <summary>
        /// Adds an HTTP probe checking for an HTTP 200 response from the specified path at regular intervals, using port 80.
        /// <p>
        /// An automatically generated name is assigned to the probe.
        /// </summary>
        /// <param name="requestPath">requestPath the path for the probe to invoke</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbe.WithHttpProbe (string requestPath) { 
            return this.WithHttpProbe( requestPath) as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule;
        }

        /// <summary>
        /// Begins the definition of a new HTTP probe to add to the load balancer.
        /// <p>
        /// The definition must be completed with a call to {@link HttpProbe.DefinitionStages.WithAttach#attach()}
        /// </summary>
        /// <param name="name">name the name of the probe</param>
        /// <returns>the first stage of the new probe definition</returns>
        Microsoft.Azure.Management.Fluent.Network.HttpProbe.Definition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule> Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbe.DefineHttpProbe (string name) { 
            return this.DefineHttpProbe( name) as Microsoft.Azure.Management.Fluent.Network.HttpProbe.Definition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule>;
        }

        /// <summary>
        /// Adds a TCP probe checking the specified port.
        /// <p>
        /// The probe will be named using an automatically generated name.
        /// </summary>
        /// <param name="port">port the port number for the probe to monitor</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbe.WithTcpProbe (int port) { 
            return this.WithTcpProbe( port) as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithProbeOrLoadBalancingRule;
        }

        /// <summary>
        /// Begins the definition of a new TCP probe to add to the load balancer.
        /// <p>
        /// The definition must be completed with a call to {@link HttpProbe.DefinitionStages.WithAttach#attach()}
        /// </summary>
        /// <param name="name">name the name of the new probe</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.TcpProbe.UpdateDefinition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithProbe.DefineTcpProbe (string name) { 
            return this.DefineTcpProbe( name) as Microsoft.Azure.Management.Fluent.Network.TcpProbe.UpdateDefinition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the description of an update to an existing HTTP probe on this load balancer.
        /// </summary>
        /// <param name="name">name the name of the probe to update</param>
        /// <returns>the first stage of the probe update</returns>
        Microsoft.Azure.Management.Fluent.Network.HttpProbe.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithProbe.UpdateHttpProbe (string name) { 
            return this.UpdateHttpProbe( name) as Microsoft.Azure.Management.Fluent.Network.HttpProbe.Update.IUpdate;
        }

        /// <summary>
        /// Adds an HTTP probe checking for an HTTP 200 response from the specified path at regular intervals, using port 80.
        /// <p>
        /// An automatically generated name is assigned to the probe.
        /// </summary>
        /// <param name="requestPath">requestPath the path for the probe to invoke</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithProbe.WithHttpProbe (string requestPath) { 
            return this.WithHttpProbe( requestPath) as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Removes the specified probe from the load balancer, if present.
        /// </summary>
        /// <param name="name">name the name of the probe to remove</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithProbe.WithoutProbe (string name) { 
            return this.WithoutProbe( name) as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new HTTP probe to add to the load balancer.
        /// <p>
        /// The definition must be completed with a call to {@link HttpProbe.DefinitionStages.WithAttach#attach()}
        /// </summary>
        /// <param name="name">name the name of the new probe</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.HttpProbe.UpdateDefinition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithProbe.DefineHttpProbe (string name) { 
            return this.DefineHttpProbe( name) as Microsoft.Azure.Management.Fluent.Network.HttpProbe.UpdateDefinition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the description of an update to an existing TCP probe on this load balancer.
        /// </summary>
        /// <param name="name">name the name of the probe to update</param>
        /// <returns>the first stage of the probe update</returns>
        Microsoft.Azure.Management.Fluent.Network.TcpProbe.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithProbe.UpdateTcpProbe (string name) { 
            return this.UpdateTcpProbe( name) as Microsoft.Azure.Management.Fluent.Network.TcpProbe.Update.IUpdate;
        }

        /// <summary>
        /// Adds a TCP probe checking the specified port.
        /// <p>
        /// The probe will be named using an automatically generated name.
        /// </summary>
        /// <param name="port">port the port number for the probe to monitor</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithProbe.WithTcpProbe (int port) { 
            return this.WithTcpProbe( port) as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Creates a load balancing rule between the specified front end and back end ports and protocol.
        /// <p>
        /// The new rule will be assigned an automatically generated name.
        /// </summary>
        /// <param name="frontendPort">frontendPort the port number on the front end to accept incoming traffic on</param>
        /// <param name="protocol">protocol the protocol to load balance</param>
        /// <param name="backendPort">backendPort the port number on the back end to send load balanced traffic to</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRule.WithLoadBalancingRule (int frontendPort, string protocol, int backendPort) { 
            return this.WithLoadBalancingRule( frontendPort,  protocol,  backendPort) as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate;
        }

        /// <summary>
        /// Creates a load balancing rule for the specified port and protocol and default frontend and backend associations.
        /// <p>
        /// The load balancing rule will created under the name "default". It will reference a backend, a frontend, and a load balancing probe all named "default".
        /// </summary>
        /// <param name="port">port the port number on the front and back end for the network traffic to be load balanced on</param>
        /// <param name="protocol">protocol the protocol to load balance</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRule.WithLoadBalancingRule (int port, string protocol) { 
            return this.WithLoadBalancingRule( port,  protocol) as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate;
        }

        /// <summary>
        /// Begins the definition of a new load balancing rule to add to the load balancer.
        /// <p>
        /// The definition must be completed with a call to {@link LoadBalancingRule.DefinitionStages.WithAttach#attach()}
        /// </summary>
        /// <param name="name">name the name of the load balancing rule</param>
        /// <returns>the first stage of the new load balancing rule definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate> Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRule.DefineLoadBalancingRule (string name) { 
            return this.DefineLoadBalancingRule( name) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithLoadBalancingRuleOrCreate>;
        }

        /// <summary>
        /// Removes the specified load balancing rule from the load balancer, if present.
        /// </summary>
        /// <param name="name">name the name of the load balancing rule to remove</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithLoadBalancingRule.WithoutLoadBalancingRule (string name) { 
            return this.WithoutLoadBalancingRule( name) as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Adds a load balancing rule between the specified front end and back end ports and protocol.
        /// <p>
        /// The new rule will be created under the name "default".
        /// </summary>
        /// <param name="frontendPort">frontendPort the port number on the front end to accept incoming traffic on</param>
        /// <param name="protocol">protocol the protocol to load balance</param>
        /// <param name="backendPort">backendPort the port number on the back end to send load balanced traffic to</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithLoadBalancingRule.WithLoadBalancingRule (int frontendPort, string protocol, int backendPort) { 
            return this.WithLoadBalancingRule( frontendPort,  protocol,  backendPort) as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Adds a load balancing rule for the specified port and protocol.
        /// <p>
        /// The new rule will be created under the name "default".
        /// </summary>
        /// <param name="port">port the port number on the front and back end for the network traffic to be load balanced on</param>
        /// <param name="protocol">protocol the protocol to load balance</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithLoadBalancingRule.WithLoadBalancingRule (int port, string protocol) { 
            return this.WithLoadBalancingRule( port,  protocol) as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new load balancing rule to add to the load balancer.
        /// <p>
        /// The definition must be completed with a call to {@link TcpProbe.DefinitionStages.WithAttach#attach()}
        /// </summary>
        /// <param name="name">name the name of the load balancing rule</param>
        /// <returns>the first stage of the new load balancing rule definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithLoadBalancingRule.DefineLoadBalancingRule (string name) { 
            return this.DefineLoadBalancingRule( name) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the description of an update to an existing load balancing rule on this load balancer.
        /// </summary>
        /// <param name="name">name the name of the load balancing rule to update</param>
        /// <returns>the first stage of the load balancing rule update</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithLoadBalancingRule.UpdateLoadBalancingRule (string name) { 
            return this.UpdateLoadBalancingRule( name) as Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Update.IUpdate;
        }

        /// <returns>inbound NAT pools, indexed by name</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Network.IInboundNatPool> Microsoft.Azure.Management.Fluent.Network.ILoadBalancer.InboundNatPools () { 
            return this.InboundNatPools() as System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Network.IInboundNatPool>;
        }

        /// <returns>HTTP probes of this load balancer, indexed by the name</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Network.IHttpProbe> Microsoft.Azure.Management.Fluent.Network.ILoadBalancer.HttpProbes () { 
            return this.HttpProbes() as System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Network.IHttpProbe>;
        }

        /// <returns>resource IDs of the public IP addresses assigned to the frontends of this load balancer</returns>
        System.Collections.Generic.List<string> Microsoft.Azure.Management.Fluent.Network.ILoadBalancer.PublicIpAddressIds
        {
            get
            {
                return this.PublicIpAddressIds as System.Collections.Generic.List<string>;
            }
        }
        /// <returns>frontends for this load balancer, for the incoming traffic to come from.</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Network.IFrontend> Microsoft.Azure.Management.Fluent.Network.ILoadBalancer.Frontends () { 
            return this.Frontends() as System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Network.IFrontend>;
        }

        /// <returns>backends for this load balancer to load balance the incoming traffic among, indexed by name</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Network.IBackend> Microsoft.Azure.Management.Fluent.Network.ILoadBalancer.Backends () { 
            return this.Backends() as System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Network.IBackend>;
        }

        /// <returns>TCP probes of this load balancer, indexed by the name</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Network.ITcpProbe> Microsoft.Azure.Management.Fluent.Network.ILoadBalancer.TcpProbes () { 
            return this.TcpProbes() as System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Network.ITcpProbe>;
        }

        /// <returns>inbound NAT rules for this balancer</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Network.IInboundNatRule> Microsoft.Azure.Management.Fluent.Network.ILoadBalancer.InboundNatRules () { 
            return this.InboundNatRules() as System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Network.IInboundNatRule>;
        }

        /// <returns>the associated load balancing rules from this load balancer, indexed by their names</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Network.ILoadBalancingRule> Microsoft.Azure.Management.Fluent.Network.IHasLoadBalancingRules.LoadBalancingRules () { 
            return this.LoadBalancingRules() as System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Network.ILoadBalancingRule>;
        }

        /// <summary>
        /// Starts the definition of a backend.
        /// </summary>
        /// <param name="name">name the name to assign to the backend</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.Backend.Definition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithBackendOrProbe> Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithBackend.DefineBackend (string name) { 
            return this.DefineBackend( name) as Microsoft.Azure.Management.Fluent.Network.Backend.Definition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithBackendOrProbe>;
        }

        /// <summary>
        /// Begins the definition of a new backend as part of this load balancer update.
        /// </summary>
        /// <param name="name">name the name for the new backend</param>
        /// <returns>the first stage of the backend definition</returns>
        Microsoft.Azure.Management.Fluent.Network.Backend.UpdateDefinition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate> Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithBackend.DefineBackend (string name) { 
            return this.DefineBackend( name) as Microsoft.Azure.Management.Fluent.Network.Backend.UpdateDefinition.IBlank<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Removes the specified backend from the load balancer.
        /// </summary>
        /// <param name="name">name the name of the backend to remove</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithBackend.WithoutBackend (string name) { 
            return this.WithoutBackend( name) as Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Begins the description of an update to an existing backend of this load balancer.
        /// </summary>
        /// <param name="name">name the name of the backend to update</param>
        /// <returns>the first stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.Backend.Update.IUpdate Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IWithBackend.UpdateBackend (string name) { 
            return this.UpdateBackend( name) as Microsoft.Azure.Management.Fluent.Network.Backend.Update.IUpdate;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <returns>the refreshed resource</returns>
        Microsoft.Azure.Management.Fluent.Network.ILoadBalancer Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Fluent.Network.ILoadBalancer>.Refresh () { 
            return this.Refresh() as Microsoft.Azure.Management.Fluent.Network.ILoadBalancer;
        }

    }
}