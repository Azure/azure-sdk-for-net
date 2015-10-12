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
    public partial class RetryPolicy
    {
        /// <summary>
        /// Gets or sets the retry strategy to be used. Possible values for
        /// this property include: 'None', 'Fixed'
        /// </summary>
        [JsonProperty(PropertyName = "retryType")]
        public RetryType? RetryType { get; set; }

        /// <summary>
        /// Gets or sets the retry interval between retries.
        /// </summary>
        [JsonProperty(PropertyName = "retryInterval")]
        public TimeSpan? RetryInterval { get; set; }

        /// <summary>
        /// Gets or sets the number of times a retry should be attempted.
        /// </summary>
        [JsonProperty(PropertyName = "retryCount")]
        public int? RetryCount { get; set; }

    }
}
