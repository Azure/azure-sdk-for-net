
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
    /// A PTR record.
    /// </summary>
    public partial class PtrRecord
    {
        /// <summary>
        /// Initializes a new instance of the PtrRecord class.
        /// </summary>
        public PtrRecord() { }

        /// <summary>
        /// Initializes a new instance of the PtrRecord class.
        /// </summary>
        public PtrRecord(string ptrdname = default(string))
        {
            Ptrdname = ptrdname;
        }

        /// <summary>
        /// Gets or sets the PTR target domain name for this record without a
        /// terminating dot.
        /// </summary>
        [JsonProperty(PropertyName = "ptrdname")]
        public string Ptrdname { get; set; }

    }
}
