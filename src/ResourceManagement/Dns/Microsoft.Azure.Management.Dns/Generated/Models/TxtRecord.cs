
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
    /// A TXT record.
    /// </summary>
    public partial class TxtRecord
    {
        /// <summary>
        /// Initializes a new instance of the TxtRecord class.
        /// </summary>
        public TxtRecord() { }

        /// <summary>
        /// Initializes a new instance of the TxtRecord class.
        /// </summary>
        public TxtRecord(IList<string> value = default(IList<string>))
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the text value of this record.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<string> Value { get; set; }

    }
}
