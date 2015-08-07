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
    public partial class JobErrorAction
    {
        /// <summary>
        /// Gets or sets the job error action type. Possible values for this
        /// property include: 'Http', 'Https', 'StorageQueue'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public JobActionType? Type { get; set; }

        /// <summary>
        /// Gets or sets the http requests.
        /// </summary>
        [JsonProperty(PropertyName = "request")]
        public HttpRequest Request { get; set; }

        /// <summary>
        /// Gets or sets the storage queue message.
        /// </summary>
        [JsonProperty(PropertyName = "queueMessage")]
        public StorageQueueMessage QueueMessage { get; set; }

        /// <summary>
        /// Gets or sets the retry policy.
        /// </summary>
        [JsonProperty(PropertyName = "retryPolicy")]
        public RetryPolicy RetryPolicy { get; set; }

    }
}
