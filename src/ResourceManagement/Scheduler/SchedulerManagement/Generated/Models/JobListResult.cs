
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
    public partial class JobListResult
    {
        /// <summary>
        /// Initializes a new instance of the JobListResult class.
        /// </summary>
        public JobListResult() { }

        /// <summary>
        /// Initializes a new instance of the JobListResult class.
        /// </summary>
        public JobListResult(IList<JobDefinition> value = default(IList<JobDefinition>), string nextLink = default(string))
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary>
        /// Gets or sets all jobs under job collection.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<JobDefinition> Value { get; set; }

        /// <summary>
        /// Gets or sets the URL to get the next set of jobs.
        /// </summary>
        [JsonProperty(PropertyName = "nextLink")]
        public string NextLink { get; set; }

    }
}
