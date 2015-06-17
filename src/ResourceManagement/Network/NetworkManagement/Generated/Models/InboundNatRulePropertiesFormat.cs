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
    public partial class InboundNatRulePropertiesFormat
    {
        /// <summary>
        /// Gets or sets a reference to frontend IP Addresses
        /// </summary>
        [JsonProperty(PropertyName = "frontendIPConfiguration")]
        public ResourceId FrontendIPConfiguration { get; set; }

        /// <summary>
        /// Gets or sets a reference to a private ip address defined on a
        /// NetworkInterface of a VM. Traffic sent to frontendPort of each of
        /// the frontendIPConfigurations is forwarded to the backed IP
        /// </summary>
        [JsonProperty(PropertyName = "backendIPConfiguration")]
        public ResourceId BackendIPConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the transport potocol for the external endpoint.
        /// Possible values are Udp or Tcp
        /// </summary>
        [JsonProperty(PropertyName = "protocol")]
        public string Protocol { get; set; }

        /// <summary>
        /// Gets or sets the port for the external endpoint. You can spcify
        /// any port number you choose, but the port numbers specified for
        /// each role in the service must be unique. Possible values range
        /// between 1 and 65535, inclusive
        /// </summary>
        [JsonProperty(PropertyName = "frontendPort")]
        public int? FrontendPort { get; set; }

        /// <summary>
        /// Gets or sets a port used for internal connections on the endpoint.
        /// The localPort attribute maps the eternal port of the endpoint to
        /// an internal port on a role. This is useful in scenarios where a
        /// role must communicate to an internal compotnent on a port that is
        /// different from the one that is exposed externally. If not
        /// specified, the value of localPort is the same as the port
        /// attribute. Set the value of localPort to '*' to automatically
        /// assign an unallocated port that is discoverable using the runtime
        /// API
        /// </summary>
        [JsonProperty(PropertyName = "backendPort")]
        public int? BackendPort { get; set; }

        /// <summary>
        /// Gets or sets the timeout for the Tcp idle connection. The value
        /// can be set between 4 and 30 minutes. The default value is 4
        /// minutes. This emlement is only used when the protocol is set to
        /// Tcp
        /// </summary>
        [JsonProperty(PropertyName = "idleTimeoutInMinutes")]
        public int? IdleTimeoutInMinutes { get; set; }

        /// <summary>
        /// Configures a virtual machine's endpoint for the floating IP
        /// capability required to configure a SQL AlwaysOn availability
        /// Group. This setting is required when using the SQL Always ON
        /// availability Groups in SQL server. This setting can't be changed
        /// after you create the endpoint
        /// </summary>
        [JsonProperty(PropertyName = "enableFloatingIP")]
        public bool? EnableFloatingIP { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.FrontendIPConfiguration != null)
            {
                this.FrontendIPConfiguration.Validate();
            }
            if (this.BackendIPConfiguration != null)
            {
                this.BackendIPConfiguration.Validate();
            }
        }
    }
}
