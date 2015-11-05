
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
    public partial class ServiceBusTopicMessage : ServiceBusMessage
    {
        /// <summary>
        /// Initializes a new instance of the ServiceBusTopicMessage class.
        /// </summary>
        public ServiceBusTopicMessage() { }

        /// <summary>
        /// Initializes a new instance of the ServiceBusTopicMessage class.
        /// </summary>
        public ServiceBusTopicMessage(string topicPath = default(string))
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
