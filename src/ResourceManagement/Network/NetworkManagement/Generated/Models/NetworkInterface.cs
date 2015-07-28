namespace Microsoft.Azure.Management.Network.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// A NetworkInterface in a resource group
    /// </summary>
    public partial class NetworkInterface : Resource
    {
        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource
        /// is updated
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets the reference of a VirtualMachine
        /// </summary>
        [JsonProperty(PropertyName = "properties.virtualMachine")]
        public SubResource VirtualMachine { get; set; }

        /// <summary>
        /// Gets or sets the reference of the NetworkSecurityGroup resource
        /// </summary>
        [JsonProperty(PropertyName = "properties.networkSecurityGroup")]
        public SubResource NetworkSecurityGroup { get; set; }

        /// <summary>
        /// Gets or sets list of IPConfigurations of the NetworkInterface
        /// </summary>
        [JsonProperty(PropertyName = "properties.ipConfigurations")]
        public IList<NetworkInterfaceIpConfiguration> IpConfigurations { get; set; }

        /// <summary>
        /// Gets or sets DNS Settings in  NetworkInterface
        /// </summary>
        [JsonProperty(PropertyName = "properties.dnsSettings")]
        public NetworkInterfaceDnsSettings DnsSettings { get; set; }

        /// <summary>
        /// Gets the MAC Address of the network interface
        /// </summary>
        [JsonProperty(PropertyName = "properties.macAddress")]
        public string MacAddress { get; set; }

        /// <summary>
        /// Gets whether this is a primary NIC on a virtual machine
        /// </summary>
        [JsonProperty(PropertyName = "properties.primary")]
        public bool? Primary { get; set; }

        /// <summary>
        /// Gets or sets Provisioning state of the PublicIP resource
        /// Updating/Deleting/Failed
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
