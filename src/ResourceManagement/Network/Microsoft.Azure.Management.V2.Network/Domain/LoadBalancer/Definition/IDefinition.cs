/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network.LoadBalancer.Definition
{

    using Microsoft.Azure.Management.V2.Network;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.Resource.Definition;
    /// <summary>
    /// The stage of the load balancer definition allowing to add a public ip address to the load
    /// balancer's front end.
    /// </summary>
    public interface IWithPublicIpAddresses 
    {
        /// <summary>
        /// Sets the provided set of public IP addresses as the front end for the load balancer, making it an Internet-facing load balancer.
        /// </summary>
        /// <param name="publicIpAddresses">publicIpAddresses existing public IP addresses</param>
        /// <returns>the next stage of the resource definition</returns>
        IWithCreate WithExistingPublicIpAddresses (IPublicIpAddress publicIpAddresses);

        /// <summary>
        /// Adds a new public IP address to the front end of the load balancer, using an automatically generated name and leaf DNS label
        /// derived from the load balancer's name, in the same resource group and region.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        IWithCreate WithNewPublicIpAddress ();

        /// <summary>
        /// Adds a new public IP address to the front end of the load balancer, using the specified DNS leaft label,
        /// an automatically generated name derived from the DNS label, in the same resource group and region.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        IWithCreate WithNewPublicIpAddress (string dnsLeafLabel);

        /// <summary>
        /// Adds a new public IP address to the front end of the load balancer, creating the public IP based on the provided {@link Creatable}
        /// stage of a public IP endpoint's definition.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        IWithCreate WithNewPublicIpAddress (ICreatable<Microsoft.Azure.Management.V2.Network.IPublicIpAddress> creatablePublicIpAddress);

    }
    /// <summary>
    /// The stage of the load balancer definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.V2.Network.LoadBalancer.Definition.IWithVirtualMachine>
    {
    }
    /// <summary>
    /// The first stage of a load balancer definition.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<Microsoft.Azure.Management.V2.Network.LoadBalancer.Definition.IWithGroup>
    {
    }
    /// <summary>
    /// The entirety of the load balancer definition.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        Microsoft.Azure.Management.V2.Network.LoadBalancer.Definition.IWithGroup,
        IWithVirtualMachine,
        IWithCreate
    {
    }
    /// <summary>
    /// The stage of the load balancer definition allowing to add a virtual machine to
    /// the load balancer's backend pool.
    /// </summary>
    public interface IWithVirtualMachine 
    {
        /// <summary>
        /// Adds the specified set of virtual machines, assuming they are from the same
        /// availability set, to this load balancer's back end address pool.
        /// <p>
        /// This will create a new back end address pool for this load balancer and add references to
        /// the primary IP configurations of the primary network interfaces of each of the provided set of
        /// virtual machines.
        /// <p>
        /// If the virtual machines are not in the same availability set, the load balancer will still
        /// be created, but the virtual machines will not associated with its back end.
        /// </summary>
        /// <param name="vms">vms existing virtual machines</param>
        /// <returns>the next stage of the update</returns>
        IWithCreate WithExistingVirtualMachines (ISupportsNetworkInterfaces vms);

    }
    /// <summary>
    /// The stage of the load balancer definition which contains all the minimum required inputs for
    /// the resource to be created (via {@link WithCreate#create()}), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<Microsoft.Azure.Management.V2.Network.ILoadBalancer>,
        IDefinitionWithTags<Microsoft.Azure.Management.V2.Network.LoadBalancer.Definition.IWithCreate>,
        IWithPublicIpAddresses
    {
    }
}