
namespace Microsoft.Azure.Management.Dns.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// An SRV record.
    /// </summary>
    public partial class SrvRecord
    {
        /// <summary>
        /// Initializes a new instance of the SrvRecord class.
        /// </summary>
        public SrvRecord() { }

        /// <summary>
        /// Initializes a new instance of the SrvRecord class.
        /// </summary>
        public SrvRecord(int? priority = default(int?), int? weight = default(int?), int? port = default(int?), string target = default(string))
        {
            Priority = priority;
            Weight = weight;
            Port = port;
            Target = target;
        }

        /// <summary>
        /// Gets or sets the priority metric for this record.
        /// </summary>
        [JsonProperty(PropertyName = "priority")]
        public int? Priority { get; set; }

        /// <summary>
        /// Gets or sets the weight metric for this this record.
        /// </summary>
        [JsonProperty(PropertyName = "weight")]
        public int? Weight { get; set; }

        /// <summary>
        /// Gets or sets the port of the service for this record.
        /// </summary>
        [JsonProperty(PropertyName = "port")]
        public int? Port { get; set; }

        /// <summary>
        /// Gets or sets the domain name of the target for this record,
        /// without a terminating dot.
        /// </summary>
        [JsonProperty(PropertyName = "target")]
        public string Target { get; set; }

    }
}
