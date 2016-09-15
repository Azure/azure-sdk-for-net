
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class StorageQueueMessage
    {
        /// <summary>
        /// Initializes a new instance of the StorageQueueMessage class.
        /// </summary>
        public StorageQueueMessage() { }

        /// <summary>
        /// Initializes a new instance of the StorageQueueMessage class.
        /// </summary>
        public StorageQueueMessage(string storageAccount = default(string), string queueName = default(string), string sasToken = default(string), string message = default(string))
        {
            StorageAccount = storageAccount;
            QueueName = queueName;
            SasToken = sasToken;
            Message = message;
        }

        /// <summary>
        /// Gets or sets the storage account name.
        /// </summary>
        [JsonProperty(PropertyName = "storageAccount")]
        public string StorageAccount { get; set; }

        /// <summary>
        /// Gets or sets the queue name.
        /// </summary>
        [JsonProperty(PropertyName = "queueName")]
        public string QueueName { get; set; }

        /// <summary>
        /// Gets or sets the SAS key.
        /// </summary>
        [JsonProperty(PropertyName = "sasToken")]
        public string SasToken { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

    }
}
