using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Core;
using System;
using System.Collections.Generic;

namespace Proto.Network
{
    /// <summary>
    /// A network interface in a resource group.
    /// </summary>
    public class NetworkInterfaceData : TrackedResource<ResourceGroupResourceIdentifier, Azure.ResourceManager.Network.Models.NetworkInterface>
    {
        /// <summary>
        /// The ARM resource type for this <see cref="NetworkInterface"/>.
        /// </summary>
        public static ResourceType ResourceType => "Microsoft.Network/networkInterfaces";

        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkInterface"/> class.
        /// </summary>
        /// <param name="nic"> The low level network interace model. </param>
        public NetworkInterfaceData(Azure.ResourceManager.Network.Models.NetworkInterface nic) : base(nic.Id, nic.Location, nic)
        {
        }

        /// <summary>
        /// Gets the resource tags.
        /// </summary>
        public override IDictionary<string, string> Tags => Model.Tags;

        /// <summary>
        /// Gets the resource name.
        /// </summary>
        public override string Name => Model.Name;

        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource is updated.
        /// </summary>
        public string Etag => Model.Etag;

        /// <summary>
        /// Gets the reference to a linked virtual machine.
        /// </summary>
        public SubResource VirtualMachine => Model.VirtualMachine;

        /// <summary>
        ///  Gets the reference to the linked NetworkSecurityGroup resource.
        /// </summary>
        public Azure.ResourceManager.Network.Models.NetworkSecurityGroup NetworkSecurityGroup
        {
            get => Model.NetworkSecurityGroup;
            set => Model.NetworkSecurityGroup = value;
        }

        /// <summary>
        /// Gets a reference to the private endpoint to which the network interface is linked.
        /// </summary>
        public PrivateEndpoint PrivateEndpoint => Model.PrivateEndpoint;

        /// <summary>
        /// Gets or sets a list of IPConfigurations of the network interface.
        /// </summary>
        public IList<NetworkInterfaceIPConfiguration> IpConfigurations
        {
            get => Model.IpConfigurations;
        }

        /// <summary>
        /// Gets a list of TapConfigurations of the newtork interface.
        /// </summary>
        public IReadOnlyList<NetworkInterfaceTapConfiguration> TapConfigurations=> Model.TapConfigurations;

        /// <summary>
        /// Gets or sets the DNS settings in network interface.
        /// </summary>
        public NetworkInterfaceDnsSettings DnsSettings
        {
            get => Model.DnsSettings;
            set => Model.DnsSettings = value;
        }

        /// <summary>
        /// Gets the MAC address of the network interface.
        /// </summary>
        public string MacAddress => Model.MacAddress;

        /// <summary>
        /// Gets a value indicating whether this is a primary network interface on a virtual machine.
        /// </summary>
        public bool? Primary => Model.Primary;

        /// <summary>
        /// Gets or sets a value determining if the network interface is accelerated networking enabled.
        /// </summary>
        public bool? EnableAcceleratedNetworking
        {
            get => Model.EnableAcceleratedNetworking;
            set => Model.EnableAcceleratedNetworking = value;
        }

        /// <summary>
        /// Gets or sets a value Indicating whether IP forwarding is enabled on this network interface.
        /// </summary>
        public bool? EnableIPForwarding
        {
            get => Model.EnableIPForwarding;
            set => Model.EnableIPForwarding = value;
        }

        /// <summary>
        /// Gets a list of references to linked BareMetal resources.
        /// </summary>
        public IReadOnlyList<string> HostedWorkloads => Model.HostedWorkloads;

        /// <summary>
        /// Gets the resource GUID property of the network interface resource.
        /// </summary>
        public string ResourceGuid => Model.ResourceGuid;

        /// <summary>
        /// Gets the provisioning state of the network interface resource.
        /// </summary>
        public ProvisioningState? ProvisioningState => Model.ProvisioningState;
    }
}
