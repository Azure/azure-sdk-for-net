
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class ServiceBusQueueMessage : ServiceBusMessage
    {
        /// <summary>
        /// Initializes a new instance of the ServiceBusQueueMessage class.
        /// </summary>
        public ServiceBusQueueMessage() { }

        /// <summary>
        /// Initializes a new instance of the ServiceBusQueueMessage class.
        /// </summary>
        public ServiceBusQueueMessage(ServiceBusAuthentication authentication = default(ServiceBusAuthentication), ServiceBusBrokeredMessageProperties brokeredMessageProperties = default(ServiceBusBrokeredMessageProperties), IDictionary<string, string> customMessageProperties = default(IDictionary<string, string>), string message = default(string), string namespaceProperty = default(string), ServiceBusTransportType? transportType = default(ServiceBusTransportType?), string queueName = default(string))
            : base(authentication, brokeredMessageProperties, customMessageProperties, message, namespaceProperty, transportType)
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
