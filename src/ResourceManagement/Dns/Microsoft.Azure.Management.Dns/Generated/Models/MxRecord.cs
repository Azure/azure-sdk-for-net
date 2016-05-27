
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
    /// An MX record.
    /// </summary>
    public partial class MxRecord
    {
        /// <summary>
        /// Initializes a new instance of the MxRecord class.
        /// </summary>
        public MxRecord() { }

        /// <summary>
        /// Initializes a new instance of the MxRecord class.
        /// </summary>
        public MxRecord(int? preference = default(int?), string exchange = default(string))
        {
            Preference = preference;
            Exchange = exchange;
        }

        /// <summary>
        /// Gets or sets the preference metric for this record.
        /// </summary>
        [JsonProperty(PropertyName = "preference")]
        public int? Preference { get; set; }

        /// <summary>
        /// Gets or sets the domain name of the mail host, without a
        /// terminating dot.
        /// </summary>
        [JsonProperty(PropertyName = "exchange")]
        public string Exchange { get; set; }

    }
}
