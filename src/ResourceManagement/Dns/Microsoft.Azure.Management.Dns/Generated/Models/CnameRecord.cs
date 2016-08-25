
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
    /// A CNAME record.
    /// </summary>
    public partial class CnameRecord
    {
        /// <summary>
        /// Initializes a new instance of the CnameRecord class.
        /// </summary>
        public CnameRecord() { }

        /// <summary>
        /// Initializes a new instance of the CnameRecord class.
        /// </summary>
        public CnameRecord(string cname = default(string))
        {
            Cname = cname;
        }

        /// <summary>
        /// Gets or sets the canonical name for this record without a
        /// terminating dot.
        /// </summary>
        [JsonProperty(PropertyName = "cname")]
        public string Cname { get; set; }

    }
}
