
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
    public partial class JobHistoryListResult
    {
        /// <summary>
        /// Initializes a new instance of the JobHistoryListResult class.
        /// </summary>
        public JobHistoryListResult() { }

        /// <summary>
        /// Initializes a new instance of the JobHistoryListResult class.
        /// </summary>
        public JobHistoryListResult(IList<JobHistoryDefinition> value = default(IList<JobHistoryDefinition>), string nextLink = default(string))
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary>
        /// Gets or sets the job histories under job.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<JobHistoryDefinition> Value { get; set; }

        /// <summary>
        /// Gets or sets the URL to get the next set of job histories.
        /// </summary>
        [JsonProperty(PropertyName = "nextLink")]
        public string NextLink { get; set; }

    }
}
