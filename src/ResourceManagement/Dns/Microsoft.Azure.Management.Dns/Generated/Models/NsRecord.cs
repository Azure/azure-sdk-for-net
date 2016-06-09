
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
    /// An NS record.
    /// </summary>
    public partial class NsRecord
    {
        /// <summary>
        /// Initializes a new instance of the NsRecord class.
        /// </summary>
        public NsRecord() { }

        /// <summary>
        /// Initializes a new instance of the NsRecord class.
        /// </summary>
        public NsRecord(string nsdname = default(string))
        {
            Nsdname = nsdname;
        }

        /// <summary>
        /// Gets or sets the name server name for this record, without a
        /// terminating dot.
        /// </summary>
        [JsonProperty(PropertyName = "nsdname")]
        public string Nsdname { get; set; }

    }
}
