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
    public partial class JobCollectionProperties
    {
        /// <summary>
        /// Gets or sets the SKU.
        /// </summary>
        [JsonProperty(PropertyName = "sku")]
        public Sku Sku { get; set; }

        /// <summary>
        /// Gets or sets the state. Possible values for this property include:
        /// 'Enabled', 'Disabled', 'Suspended', 'Deleted'
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
