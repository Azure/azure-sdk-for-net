// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.


namespace Microsoft.Azure.Management.Fluent.Dns.Models
{
    /// <summary>
    /// Describes a DNS zone.
    /// </summary>
    [Microsoft.Rest.Serialization.JsonTransformation]
    public partial class ZoneInner : Microsoft.Azure.Management.Resource.Fluent.Resource
    {
        /// <summary>
        /// Initializes a new instance of the ZoneZoneInner class.
        /// </summary>
        public ZoneInner() { }

        /// <summary>
        /// Initializes a new instance of the ZoneZoneInner class.
        /// </summary>
        /// <param name="location">the location</param>
        /// <param name="id">the id</param>
        /// <param name="name">the name</param>
        /// <param name="type">the type</param>
        /// <param name="tags">the tags</param>
        /// <param name="maxNumberOfRecordSets">the maximum number of record sets that can be created in this zone</param>
        /// <param name="numberOfRecordSets">the current number of record sets in this zone</param>
        /// <param name="nameServers">the name servers populated for this zone</param>
        public ZoneInner(string location = default(string), string id = default(string), string name = default(string), string type = default(string), System.Collections.Generic.IDictionary<string, string> tags = default(System.Collections.Generic.IDictionary<string, string>), long? maxNumberOfRecordSets = default(long?), long? numberOfRecordSets = default(long?), System.Collections.Generic.IList<string> nameServers = default(System.Collections.Generic.IList<string>))
            : base(location, id, name, type, tags)
        {
            MaxNumberOfRecordSets = maxNumberOfRecordSets;
            NumberOfRecordSets = numberOfRecordSets;
            NameServers = nameServers;
        }

        /// <summary>
        /// Gets or sets the ETag of the zone that is being updated, as received from a Get operation.
        /// </summary>
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of record sets that can be created in this zone.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.maxNumberOfRecordSets")]
        public long? MaxNumberOfRecordSets { get; set; }

        /// <summary>
        /// Gets or sets the current number of record sets in this zone.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.numberOfRecordSets")]
        public long? NumberOfRecordSets { get; set; }

        /// <summary>
        /// Gets the name servers populated for this zone. This is a read-only
        /// property and any attempt to set this value will be ignored.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.nameServers")]
        public System.Collections.Generic.IList<string> NameServers { get; set; }

    }
}
