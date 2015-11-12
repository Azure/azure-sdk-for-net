
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
    public partial class ServiceBusQueueMessage : ServiceBusMessage
    {
        /// <summary>
        /// Initializes a new instance of the ServiceBusQueueMessage class.
        /// </summary>
        public ServiceBusQueueMessage() { }

        /// <summary>
        /// Initializes a new instance of the ServiceBusQueueMessage class.
        /// </summary>
        public ServiceBusQueueMessage(string queueName = default(string))
        {
            QueueName = queueName;
        }

        /// <summary>
        /// Gets or sets the queue name.
        /// </summary>
        [JsonProperty(PropertyName = "queueName")]
        public string QueueName { get; set; }

    }
}
