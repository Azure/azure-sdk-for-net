
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
    [JsonTransformation]
    public partial class Zone : Resource
    {
        /// <summary>
        /// Initializes a new instance of the Zone class.
        /// </summary>
        public Zone() { }

        /// <summary>
        /// Initializes a new instance of the Zone class.
        /// </summary>
        public Zone(string location, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), string etag = default(string), long? maxNumberOfRecordSets = default(long?), long? numberOfRecordSets = default(long?), IList<string> nameServers = default(IList<string>))
            : base(location, id, name, type, tags)
        {
            Etag = etag;
            MaxNumberOfRecordSets = maxNumberOfRecordSets;
            NumberOfRecordSets = numberOfRecordSets;
            NameServers = nameServers;
        }

        /// <summary>
        /// Gets or sets the ETag of the zone that is being updated, as
        /// received from a Get operation.
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of record sets that can be created
        /// in this zone.
        /// </summary>
        [JsonProperty(PropertyName = "properties.maxNumberOfRecordSets")]
        public long? MaxNumberOfRecordSets { get; set; }

        /// <summary>
        /// Gets or sets the current number of record sets in this zone.
        /// </summary>
        [JsonProperty(PropertyName = "properties.numberOfRecordSets")]
        public long? NumberOfRecordSets { get; set; }

        /// <summary>
        /// Gets the name servers populated for this zone. This is a read-only
        /// property and any attempt to set this value will be ignored.
        /// </summary>
        [JsonProperty(PropertyName = "properties.nameServers")]
        public IList<string> NameServers { get; private set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
