
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
    /// Represents the properties of the zone.
    /// </summary>
    public partial class ZoneProperties
    {
        /// <summary>
        /// Initializes a new instance of the ZoneProperties class.
        /// </summary>
        public ZoneProperties() { }

        /// <summary>
        /// Initializes a new instance of the ZoneProperties class.
        /// </summary>
        public ZoneProperties(long? maxNumberOfRecordSets = default(long?), long? numberOfRecordSets = default(long?), IList<string> nameServers = default(IList<string>))
        {
            MaxNumberOfRecordSets = maxNumberOfRecordSets;
            NumberOfRecordSets = numberOfRecordSets;
            NameServers = nameServers;
        }

        /// <summary>
        /// Gets or sets the maximum number of record sets that can be created
        /// in this zone.
        /// </summary>
        [JsonProperty(PropertyName = "maxNumberOfRecordSets")]
        public long? MaxNumberOfRecordSets { get; set; }

        /// <summary>
        /// Gets or sets the current number of record sets in this zone.
        /// </summary>
        [JsonProperty(PropertyName = "numberOfRecordSets")]
        public long? NumberOfRecordSets { get; set; }

        /// <summary>
        /// Gets the name servers populated for this zone. This is a read-only
        /// property and any attempt to set this value will be ignored.
        /// </summary>
        [JsonProperty(PropertyName = "nameServers")]
        public IList<string> NameServers { get; private set; }

    }
}
