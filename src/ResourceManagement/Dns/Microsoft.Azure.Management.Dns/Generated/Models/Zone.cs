
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
    /// Describes a DNS zone.
    /// </summary>
    public partial class Zone : Resource
    {
        /// <summary>
        /// Initializes a new instance of the Zone class.
        /// </summary>
        public Zone() { }

        /// <summary>
        /// Initializes a new instance of the Zone class.
        /// </summary>
        public Zone(string location, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), string etag = default(string), ZoneProperties properties = default(ZoneProperties))
            : base(location, id, name, type, tags)
        {
            Etag = etag;
            Properties = properties;
        }

        /// <summary>
        /// Gets or sets the ETag of the zone that is being updated, as
        /// received from a Get operation.
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets the properties of the zone.
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public ZoneProperties Properties { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
