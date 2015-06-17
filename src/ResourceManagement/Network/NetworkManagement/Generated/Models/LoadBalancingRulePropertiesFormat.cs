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
    public partial class LoadBalancingRulePropertiesFormat
    {
        /// <summary>
        /// Gets or sets a reference to frontend IP Addresses
        /// </summary>
        [JsonProperty(PropertyName = "frontendIPConfiguration")]
        public ResourceId FrontendIPConfiguration { get; set; }

        /// <summary>
        /// Gets or sets  a reference to a pool of DIPs. Inbound traffic is
        /// randomly load balanced across IPs in the backend IPs
        /// </summary>
        [JsonProperty(PropertyName = "backendAddressPool")]
        public ResourceId BackendAddressPool { get; set; }

        /// <summary>
        /// Gets or sets the reference of the load balancer probe used by the
        /// Load Balancing rule.
        /// </summary>
        [JsonProperty(PropertyName = "probe")]
        public ResourceId Probe { get; set; }

        /// <summary>
        /// Gets or sets the transport protocol for the external endpoint.
        /// Possible values are Udp or Tcp
        /// </summary>
        [JsonProperty(PropertyName = "protocol")]
        public string Protocol { get; set; }

        /// <summary>
        /// Gets or sets the load distribution policy for this rule
        /// </summary>
        [JsonProperty(PropertyName = "loadDistribution")]
        public string LoadDistribution { get; set; }

        /// <summary>
        /// Gets or sets the port for the external endpoint. You can specify
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
            if (this.BackendAddressPool != null)
            {
                this.BackendAddressPool.Validate();
            }
            if (this.Probe != null)
            {
                this.Probe.Validate();
            }
        }
    }
}
