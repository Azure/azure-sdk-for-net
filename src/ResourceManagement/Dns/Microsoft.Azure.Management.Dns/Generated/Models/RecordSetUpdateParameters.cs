
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
    /// Parameters supplied to update a RecordSet.
    /// </summary>
    public partial class RecordSetUpdateParameters
    {
        /// <summary>
        /// Initializes a new instance of the RecordSetUpdateParameters class.
        /// </summary>
        public RecordSetUpdateParameters() { }

        /// <summary>
        /// Initializes a new instance of the RecordSetUpdateParameters class.
        /// </summary>
        public RecordSetUpdateParameters(RecordSet recordSet = default(RecordSet))
        {
            RecordSet = recordSet;
        }

        /// <summary>
        /// Gets or sets information about the RecordSet being updated.
        /// </summary>
        [JsonProperty(PropertyName = "RecordSet")]
        public RecordSet RecordSet { get; set; }

    }
}
