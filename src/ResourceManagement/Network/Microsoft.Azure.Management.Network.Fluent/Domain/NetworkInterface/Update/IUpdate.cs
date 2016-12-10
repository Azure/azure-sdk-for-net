// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Network.Fluent.NicIpConfiguration.Update;
    using Microsoft.Azure.Management.Network.Fluent.NicIpConfiguration.UpdateDefinition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Update;

    /// <summary>
    /// The stage of the network interface update allowing to enable or disable IP forwarding.
    /// </summary>
    public interface IWithIpForwarding 
    {
        /// <summary>
        /// Disable IP forwarding in the network interface.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update.IUpdate WithoutIpForwarding();

        /// <summary>
        /// Enable IP forwarding in the network interface.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update.IUpdate WithIpForwarding();
    }

    /// <summary>
    /// The stage of the network interface update allowing to associate public IP address with it's primary
    /// IP configuration.
    /// </summary>
    public interface IWithPrimaryPublicIpAddress 
    {
        /// <summary>
        /// Create a new public IP address to associate the network interface's primary IP configuration,
        /// based on the provided definition.
        /// <p>
        /// if there is public IP associated with the primary IP configuration then that will be removed in
        /// favour of this.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update.IUpdate WithNewPrimaryPublicIpAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress> creatable);

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associate it
        /// with the network interface's primary IP configuration.
        /// <p>
        /// the internal name and DNS label for the public IP address will be derived from the network interface name,
        /// if there is an existing public IP association then that will be removed in favour of this.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update.IUpdate WithNewPrimaryPublicIpAddress();

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource, with the specified DNS label
        /// and associate it with the network interface's primary IP configuration.
        /// <p>
        /// the internal name for the public IP address will be derived from the DNS label, if there is an existing
        /// public IP association then that will be removed in favour of this.
        /// </summary>
        /// <param name="leafDnsLabel">The leaf domain label.</param>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update.IUpdate WithNewPrimaryPublicIpAddress(string leafDnsLabel);

        /// <summary>
        /// Specifies that remove any public IP associated with the network interface's primary IP configuration.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update.IUpdate WithoutPrimaryPublicIpAddress();

        /// <summary>
        /// Associates an existing public IP address with the network interface's primary IP configuration.
        /// if there is an existing public IP association then that will be removed in favour of this.
        /// </summary>
        /// <param name="publicIpAddress">An existing public IP address.</param>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update.IUpdate WithExistingPrimaryPublicIpAddress(IPublicIpAddress publicIpAddress);
    }

    /// <summary>
    /// The stage of the network interface update allowing to specify subnet.
    /// </summary>
    public interface IWithPrimaryNetworkSubnet 
    {
        /// <summary>
        /// Associate a subnet with the network interface.
        /// </summary>
        /// <param name="name">The subnet name.</param>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update.IUpdate WithSubnet(string name);
    }

    /// <summary>
    /// The stage of the network interface update allowing to configure IP configuration.
    /// </summary>
    public interface IWithIpConfiguration 
    {
        /// <summary>
        /// Starts definition of a secondary IP configuration.
        /// </summary>
        /// <param name="name">Name for the IP configuration.</param>
        Microsoft.Azure.Management.Network.Fluent.NicIpConfiguration.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update.IUpdate> DefineSecondaryIpConfiguration(string name);

        /// <summary>
        /// Starts update of an IP configuration.
        /// </summary>
        /// <param name="name">Name of the IP configuration.</param>
        Microsoft.Azure.Management.Network.Fluent.NicIpConfiguration.Update.IUpdate UpdateIpConfiguration(string name);
    }

    /// <summary>
    /// The stage of the network interface update allowing to specify private IP address within
    /// a virtual network subnet.
    /// </summary>
    public interface IWithPrimaryPrivateIp 
    {
        /// <summary>
        /// Enables dynamic private IP address allocation within the specified existing virtual network
        /// subnet for the network interface's primary IP configuration.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update.IUpdate WithPrimaryPrivateIpAddressDynamic();

        /// <summary>
        /// Assigns the specified static private IP address within the specified existing virtual network
        /// subnet to the network interface's primary IP configuration.
        /// </summary>
        /// <param name="staticPrivateIpAddress">
        /// The static IP address within the specified subnet to assign to
        /// the primary IP configuration.
        /// </param>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update.IUpdate WithPrimaryPrivateIpAddressStatic(string staticPrivateIpAddress);
    }

    /// <summary>
    /// The template for an update operation, containing all the settings that
    /// can be modified.
    /// <p>
    /// Call Update.apply() to apply the changes to the resource in Azure.
    /// </summary>
    public interface IUpdate  :
        IAppliable<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>,
        IUpdateWithTags<Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update.IUpdate>,
        IWithPrimaryNetworkSubnet,
        IWithPrimaryPrivateIp,
        IWithPrimaryPublicIpAddress,
        IWithNetworkSecurityGroup,
        IWithIpForwarding,
        IWithDnsServer,
        IWithIpConfiguration,
        IWithLoadBalancer
    {
    }

    /// <summary>
    /// The stage of the network interface update allowing to associate it with a load balancer.
    /// </summary>
    public interface IWithLoadBalancer 
    {
        /// <summary>
        /// Associates the network interface's primary IP configuration with a backend of an existing load balancer.
        /// </summary>
        /// <param name="loadBalancer">An existing load balancer.</param>
        /// <param name="backendName">The name of an existing backend on that load balancer.</param>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update.IUpdate WithExistingLoadBalancerBackend(ILoadBalancer loadBalancer, string backendName);

        /// <summary>
        /// Associates the network interface's primary IP configuration with an inbound NAT rule of an existing load balancer.
        /// </summary>
        /// <param name="loadBalancer">An existing load balancer.</param>
        /// <param name="inboundNatRuleName">The name of an existing inbound NAT rule on the selected load balancer.</param>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update.IUpdate WithExistingLoadBalancerInboundNatRule(ILoadBalancer loadBalancer, string inboundNatRuleName);

        /// <summary>
        /// Removes all the existing associations with any load balancer inbound NAT rules.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update.IUpdate WithoutLoadBalancerInboundNatRules();

        /// <summary>
        /// Removes all the existing associations with any load balancer backends.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update.IUpdate WithoutLoadBalancerBackends();
    }

    /// <summary>
    /// The stage of the network interface update allowing to specify DNS servers.
    /// </summary>
    public interface IWithDnsServer 
    {
        /// <summary>
        /// Specifies the IP address of the custom DNS server to associate with the network interface.
        /// <p>
        /// Note this method's effect is additive, i.e. each time it is used, the new dns server is
        /// added to the network interface.
        /// </summary>
        /// <param name="ipAddress">The IP address of the DNS server.</param>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update.IUpdate WithDnsServer(string ipAddress);

        /// <summary>
        /// Removes a DNS server associated with the network interface.
        /// </summary>
        /// <param name="ipAddress">The IP address of the DNS server.</param>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update.IUpdate WithoutDnsServer(string ipAddress);

        /// <summary>
        /// Specifies to use the default Azure DNS server for the network interface.
        /// <p>
        /// Using azure DNS server will remove any custom DNS server associated with this network interface.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update.IUpdate WithAzureDnsServer();
    }

    /// <summary>
    /// The stage of the network interface update allowing to associate network security group.
    /// </summary>
    public interface IWithNetworkSecurityGroup 
    {
        /// <summary>
        /// Specifies that remove any network security group associated with the network interface.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update.IUpdate WithoutNetworkSecurityGroup();

        /// <summary>
        /// Create a new network security group to associate with network interface, based on the provided definition.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new network security group.</param>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update.IUpdate WithNewNetworkSecurityGroup(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup> creatable);

        /// <summary>
        /// Associates an existing network security group with the network interface.
        /// </summary>
        /// <param name="networkSecurityGroup">An existing network security group.</param>
        Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Update.IUpdate WithExistingNetworkSecurityGroup(INetworkSecurityGroup networkSecurityGroup);
    }
}