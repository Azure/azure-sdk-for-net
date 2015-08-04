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
    public partial class StorageQueueMessage
    {
        /// <summary>
        /// Gets or sets the Storage Account Name for the request.
        /// </summary>
        [JsonProperty(PropertyName = "storageAccount")]
        public string StorageAccount { get; set; }

        /// <summary>
        /// Gets or sets the Queue Name for the request.
        /// </summary>
        [JsonProperty(PropertyName = "queueName")]
        public string QueueName { get; set; }

        /// <summary>
        /// Gets or sets the SAS Key for the request.
        /// </summary>
        [JsonProperty(PropertyName = "sasToken")]
        public string SasToken { get; set; }

        /// <summary>
        /// Gets or sets the message for the request.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

    }
}
