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
    public partial class PublicIpAddress : Resource
    {
        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource
        /// is updated
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets PublicIP allocation method (Static/Dynamic). Possible
        /// values for this property include: 'Static', 'Dynamic'
        /// </summary>
        [JsonProperty(PropertyName = "publicIPAllocationMethod")]
        public IpAllocationMethod? PublicIPAllocationMethod { get; set; }

        /// <summary>
        /// Gets a reference to the network interface IP configurations using
        /// this public IP address
        /// </summary>
        [JsonProperty(PropertyName = "ipConfiguration")]
        public SubResource IpConfiguration { get; set; }

        /// <summary>
        /// Gets or sets FQDN of the DNS record associated with the public IP
        /// address
        /// </summary>
        [JsonProperty(PropertyName = "dnsSettings")]
        public PublicIpAddressDnsSettings DnsSettings { get; set; }

        /// <summary>
        /// Gets the assigned public IP address
        /// </summary>
        [JsonProperty(PropertyName = "ipAddress")]
        public string IpAddress { get; set; }

        /// <summary>
        /// Gets or sets the Idletimeout of the public IP address
        /// </summary>
        [JsonProperty(PropertyName = "idleTimeoutInMinutes")]
        public int? IdleTimeoutInMinutes { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            if (this.IpConfiguration != null)
            {
                this.IpConfiguration.Validate();
            }
            if (this.DnsSettings != null)
            {
                this.DnsSettings.Validate();
            }
        }
    }
}
