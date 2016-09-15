/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update
{

    using Microsoft.Azure.Management.V2.Network;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResourceActions;
    using Microsoft.Azure.Management.V2.Network.NetworkInterface.Update;
    /// <summary>
    /// The stage of the network interface IP configuration update allowing to specify the load balancer
    /// back end address pool to add it to.
    /// </summary>
    public interface IWithBackendAddressPool 
    {
        /// <summary>
        /// Adds this network interface's IP configuration to the provided back end address pool of
        /// the specified load balancer.
        /// </summary>
        /// <param name="name">name the name of an existing load balancer back end address pool</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate WithBackendAddressPool (string name);

    }
    /// <summary>
    /// The stage of the network interface's IP configuration allowing to specify the load balancer
    /// to associate this IP configuration with.
    /// </summary>
    public interface IWithLoadBalancer 
    {
        /// <summary>
        /// Specifies the load balancer to associate this IP configuration with.
        /// </summary>
        /// <param name="loadBalancer">loadBalancer an existing load balancer</param>
        /// <returns>the next stage of the update</returns>
        IWithBackendAddressPool WithExistingLoadBalancer (ILoadBalancer loadBalancer);

    }
    /// <summary>
    /// The stage of the network interface IP configuration update allowing to specify public IP address.
    /// </summary>
    public interface IWithPublicIpAddress 
    {
        /// <summary>
        /// Create a new public IP address to associate the network interface IP configuration with,
        /// based on the provided definition.
        /// <p>
        /// If there is public IP associated with the IP configuration then that will be removed in
        /// favour of this.
        /// </summary>
        /// <param name="creatable">creatable a creatable definition for a new public IP</param>
        /// <returns>the next stage of the network interface IP configuration update</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate WithNewPublicIpAddress (ICreatable<Microsoft.Azure.Management.V2.Network.IPublicIpAddress> creatable);

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associate it
        /// with the IP configuration.
        /// <p>
        /// The internal name and DNS label for the public IP address will be derived from the network interface
        /// name, if there is an existing public IP association then that will be removed in favour of this.
        /// </summary>
        /// <returns>the next stage of the network interface IP configuration update</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate WithNewPublicIpAddress ();

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS
        /// label and associate it with the IP configuration.
        /// <p>
        /// The internal name for the public IP address will be derived from the DNS label, if there is an existing
        /// public IP association then that will be removed in favour of this
        /// </summary>
        /// <param name="leafDnsLabel">leafDnsLabel the leaf domain label</param>
        /// <returns>the next stage of the network interface IP configuration update</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate WithNewPublicIpAddress (string leafDnsLabel);

        /// <summary>
        /// Specifies that remove any public IP associated with the IP configuration.
        /// </summary>
        /// <returns>the next stage of the network interface IP configuration update</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate WithoutPublicIpAddress ();

    }
    /// <summary>
    /// The stage of the network interface IP configuration update allowing to specify subnet.
    /// </summary>
    public interface IWithSubnet 
    {
        /// <summary>
        /// Associate a subnet with the network interface IP configuration.
        /// </summary>
        /// <param name="name">name the subnet name</param>
        /// <returns>the next stage of the network interface IP configuration update</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate WithSubnet (string name);

    }
    /// <summary>
    /// The stage of the network interface IP configuration update allowing to specify private IP.
    /// </summary>
    public interface IWithPrivateIp 
    {
        /// <summary>
        /// Enables dynamic private IP address allocation within the specified existing virtual network
        /// subnet to the network interface IP configuration.
        /// </summary>
        /// <returns>the next stage of the network interface IP configuration update</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate WithPrivateIpAddressDynamic ();

        /// <summary>
        /// Assigns the specified static private IP address within the specified existing virtual network
        /// subnet to the network interface IP configuration.
        /// </summary>
        /// <param name="staticPrivateIpAddress">staticPrivateIpAddress the static IP address within the specified subnet to assign to</param>
        /// <param name="the">the  IP configuration</param>
        /// <returns>the next stage of the network interface IP configuration update</returns>
        Microsoft.Azure.Management.V2.Network.NicIpConfiguration.Update.IUpdate WithPrivateIpAddressStatic (string staticPrivateIpAddress);

    }
    /// <summary>
    /// The entirety of a network interface IP configuration update as part of a network interface update.
    /// </summary>
    public interface IUpdate  :
        ISettable<Microsoft.Azure.Management.V2.Network.NetworkInterface.Update.IUpdate>,
        IWithSubnet,
        IWithPrivateIp,
        IWithPublicIpAddress,
        IWithLoadBalancer,
        IWithBackendAddressPool
    {
    }
}