
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// </summary>
    public partial class JobCollectionListResult
    {
        /// <summary>
        /// Initializes a new instance of the JobCollectionListResult class.
        /// </summary>
        public JobCollectionListResult() { }

        /// <summary>
        /// Initializes a new instance of the JobCollectionListResult class.
        /// </summary>
        public JobCollectionListResult(IList<JobCollectionDefinition> value = default(IList<JobCollectionDefinition>), string nextLink = default(string))
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary>
        /// Gets the job collections.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<JobCollectionDefinition> Value { get; private set; }

        /// <summary>
        /// Gets or sets the URL to get the next set of job collections.
        /// </summary>
        [JsonProperty(PropertyName = "nextLink")]
        public string NextLink { get; set; }

    }
}
