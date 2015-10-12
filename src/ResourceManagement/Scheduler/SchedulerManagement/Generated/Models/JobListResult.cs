namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
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
