
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class ServiceBusMessage
    {
        /// <summary>
        /// Initializes a new instance of the ServiceBusMessage class.
        /// </summary>
        public ServiceBusMessage() { }

        /// <summary>
        /// Initializes a new instance of the ServiceBusMessage class.
        /// </summary>
        public ServiceBusMessage(ServiceBusAuthentication authentication = default(ServiceBusAuthentication), ServiceBusBrokeredMessageProperties brokeredMessageProperties = default(ServiceBusBrokeredMessageProperties), IDictionary<string, string> customMessageProperties = default(IDictionary<string, string>), string message = default(string), string namespaceProperty = default(string), ServiceBusTransportType? transportType = default(ServiceBusTransportType?))
        {
            Authentication = authentication;
            BrokeredMessageProperties = brokeredMessageProperties;
            CustomMessageProperties = customMessageProperties;
            Message = message;
            NamespaceProperty = namespaceProperty;
            TransportType = transportType;
        }

        /// <summary>
        /// Gets or sets the authentication.
        /// </summary>
        [JsonProperty(PropertyName = "authentication")]
        public ServiceBusAuthentication Authentication { get; set; }

        /// <summary>
        /// Gets or sets the brokered message properties.
        /// </summary>
        [JsonProperty(PropertyName = "brokeredMessageProperties")]
        public ServiceBusBrokeredMessageProperties BrokeredMessageProperties { get; set; }

        /// <summary>
        /// Gets or sets the custom message properties.
        /// </summary>
        [JsonProperty(PropertyName = "customMessageProperties")]
        public IDictionary<string, string> CustomMessageProperties { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the namespace.
        /// </summary>
        [JsonProperty(PropertyName = "namespace")]
        public string NamespaceProperty { get; set; }

        /// <summary>
        /// Gets or sets the transport type. Possible values include:
        /// 'NotSpecified', 'NetMessaging', 'AMQP'
        /// </summary>
        [JsonProperty(PropertyName = "transportType")]
        public ServiceBusTransportType? TransportType { get; set; }

    }
}
