namespace Microsoft.Azure.Management.Network.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Azure;

    /// <summary>
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
        [JsonProperty(PropertyName = "virtualMachine")]
        public SubResource VirtualMachine { get; set; }

        /// <summary>
        /// Gets or sets the reference of the NetworkSecurityGroup resource
        /// </summary>
        [JsonProperty(PropertyName = "networkSecurityGroup")]
        public SubResource NetworkSecurityGroup { get; set; }

        /// <summary>
        /// Gets or sets list of IPConfigurations of the NetworkInterface
        /// </summary>
        [JsonProperty(PropertyName = "ipConfigurations")]
        public IList<NetworkInterfaceIpConfiguration> IpConfigurations { get; set; }

        /// <summary>
        /// Gets or sets DNS Settings in  NetworkInterface
        /// </summary>
        [JsonProperty(PropertyName = "dnsSettings")]
        public NetworkInterfaceDnsSettings DnsSettings { get; set; }

        /// <summary>
        /// Gets the MAC Address of the network interface
        /// </summary>
        [JsonProperty(PropertyName = "macAddress")]
        public string MacAddress { get; set; }

        /// <summary>
        /// Gets whether this is a primary NIC on a virtual machine
        /// </summary>
        [JsonProperty(PropertyName = "primary")]
        public bool? Primary { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            if (this.VirtualMachine != null)
            {
                this.VirtualMachine.Validate();
            }
            if (this.NetworkSecurityGroup != null)
            {
                this.NetworkSecurityGroup.Validate();
            }
            if (this.IpConfigurations != null)
            {
                foreach ( var element in this.IpConfigurations)
            {
                if (element != null)
            {
                element.Validate();
            }
            }
            }
            if (this.DnsSettings != null)
            {
                this.DnsSettings.Validate();
            }
        }
    }
}
