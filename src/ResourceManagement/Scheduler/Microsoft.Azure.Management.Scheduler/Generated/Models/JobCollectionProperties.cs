
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class JobCollectionProperties
    {
        /// <summary>
        /// Initializes a new instance of the JobCollectionProperties class.
        /// </summary>
        public JobCollectionProperties() { }

        /// <summary>
        /// Initializes a new instance of the JobCollectionProperties class.
        /// </summary>
        public JobCollectionProperties(Sku sku = default(Sku), JobCollectionState? state = default(JobCollectionState?), JobCollectionQuota quota = default(JobCollectionQuota))
        {
            Sku = sku;
            State = state;
            Quota = quota;
        }

        /// <summary>
        /// Gets or sets the SKU.
        /// </summary>
        [JsonProperty(PropertyName = "sku")]
        public Sku Sku { get; set; }

        /// <summary>
        /// Gets or sets the state. Possible values include: 'Enabled',
        /// 'Disabled', 'Suspended', 'Deleted'
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public JobCollectionState? State { get; set; }

        /// <summary>
        /// Gets or sets the job collection quota.
        /// </summary>
        [JsonProperty(PropertyName = "quota")]
        public JobCollectionQuota Quota { get; set; }

    }
}
