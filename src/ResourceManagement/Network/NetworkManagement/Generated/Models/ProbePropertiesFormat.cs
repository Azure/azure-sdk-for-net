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
    public partial class ProbePropertiesFormat
    {
        /// <summary>
        /// Gets Load balancer rules that use this probe
        /// </summary>
        [JsonProperty(PropertyName = "loadBalancingRules")]
        public IList<ResourceId> LoadBalancingRules { get; set; }

        /// <summary>
        /// Gets or sets the protocol of the end point. Possible values are
        /// http pr Tcp. If Tcp is specified, a received ACK is required for
        /// the probe to be successful. If http is specified,a 200 OK
        /// response from the specifies URI is required for the probe to be
        /// successful
        /// </summary>
        [JsonProperty(PropertyName = "protocol")]
        public string Protocol { get; set; }

        /// <summary>
        /// Gets or sets Port for communicating the probe. Possible values
        /// range from 1 to 65535, inclusive.
        /// </summary>
        [JsonProperty(PropertyName = "port")]
        public int? Port { get; set; }

        /// <summary>
        /// Gets or sets the interval, in seconds, for how frequently to probe
        /// the endpoint for health status. Typically, the interval is
        /// slightly less than half the allocated timeout period (in seconds)
        /// which allows two full probes before taking the instance out of
        /// rotation. The default value is 15, the minimum value is 5
        /// </summary>
        [JsonProperty(PropertyName = "intervalInSeconds")]
        public int? IntervalInSeconds { get; set; }

        /// <summary>
        /// Gets or sets the number of probes where if no response, will
        /// result in stopping further traffic from being delivered to the
        /// endpoint. This values allows endponints to be taken out of
        /// rotation faster or slower than the typical times used in Azure.
        /// </summary>
        [JsonProperty(PropertyName = "numberOfProbes")]
        public int? NumberOfProbes { get; set; }

        /// <summary>
        /// Gets or sets the URI used for requesting health status from the
        /// VM. Path is required if a protocol is set to http. Otherwise, it
        /// is not allowed. There is no default value
        /// </summary>
        [JsonProperty(PropertyName = "requestPath")]
        public string RequestPath { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.LoadBalancingRules != null)
            {
                foreach ( var element in this.LoadBalancingRules)
            {
                if (element != null)
            {
                element.Validate();
            }
            }
            }
        }
    }
}
