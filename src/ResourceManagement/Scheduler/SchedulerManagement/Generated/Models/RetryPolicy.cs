
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class RetryPolicy
    {
        /// <summary>
        /// Initializes a new instance of the RetryPolicy class.
        /// </summary>
        public RetryPolicy() { }

        /// <summary>
        /// Initializes a new instance of the RetryPolicy class.
        /// </summary>
        public RetryPolicy(RetryType? retryType = default(RetryType?), TimeSpan? retryInterval = default(TimeSpan?), int? retryCount = default(int?))
        {
            RetryType = retryType;
            RetryInterval = retryInterval;
            RetryCount = retryCount;
        }

        /// <summary>
        /// Gets or sets the retry strategy to be used. Possible values
        /// include: 'None', 'Fixed'
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
