
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class ServiceBusTopicMessage : ServiceBusMessage
    {
        /// <summary>
        /// Initializes a new instance of the ServiceBusTopicMessage class.
        /// </summary>
        public ServiceBusTopicMessage() { }

        /// <summary>
        /// Initializes a new instance of the ServiceBusTopicMessage class.
        /// </summary>
        public ServiceBusTopicMessage(ServiceBusAuthentication authentication = default(ServiceBusAuthentication), ServiceBusBrokeredMessageProperties brokeredMessageProperties = default(ServiceBusBrokeredMessageProperties), IDictionary<string, string> customMessageProperties = default(IDictionary<string, string>), string message = default(string), string namespaceProperty = default(string), ServiceBusTransportType? transportType = default(ServiceBusTransportType?), string topicPath = default(string))
            : base(authentication, brokeredMessageProperties, customMessageProperties, message, namespaceProperty, transportType)
        {
            TopicPath = topicPath;
        }

        /// <summary>
        /// Gets or sets the topic path.
        /// </summary>
        [JsonProperty(PropertyName = "topicPath")]
        public string TopicPath { get; set; }

    }
}
