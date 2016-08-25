
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class JobHistoryFilter
    {
        /// <summary>
        /// Initializes a new instance of the JobHistoryFilter class.
        /// </summary>
        public JobHistoryFilter() { }

        /// <summary>
        /// Initializes a new instance of the JobHistoryFilter class.
        /// </summary>
        public JobHistoryFilter(JobExecutionStatus? status = default(JobExecutionStatus?))
        {
            Status = status;
        }

        /// <summary>
        /// Gets or sets the job execution status. Possible values include:
        /// 'Completed', 'Failed', 'Postponed'
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public JobExecutionStatus? Status { get; set; }

    }
}
