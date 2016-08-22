
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class JobStateFilter
    {
        /// <summary>
        /// Initializes a new instance of the JobStateFilter class.
        /// </summary>
        public JobStateFilter() { }

        /// <summary>
        /// Initializes a new instance of the JobStateFilter class.
        /// </summary>
        public JobStateFilter(JobState? state = default(JobState?))
        {
            State = state;
        }

        /// <summary>
        /// Gets or sets the job state. Possible values include: 'Enabled',
        /// 'Disabled', 'Faulted', 'Completed'
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public JobState? State { get; set; }

    }
}
