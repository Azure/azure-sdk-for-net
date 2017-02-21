// MIT

namespace Microsoft.Azure.Management.IotHub.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The properties of the provisioned Event Hub-compatible endpoint used
    /// by the IoT hub.
    /// </summary>
    public partial class EventHubProperties
    {
        /// <summary>
        /// Initializes a new instance of the EventHubProperties class.
        /// </summary>
        public EventHubProperties() { }

        /// <summary>
        /// Initializes a new instance of the EventHubProperties class.
        /// </summary>
        public EventHubProperties(long? retentionTimeInDays = default(long?), int? partitionCount = default(int?), IList<string> partitionIds = default(IList<string>), string path = default(string), string endpoint = default(string))
        {
            RetentionTimeInDays = retentionTimeInDays;
            PartitionCount = partitionCount;
            PartitionIds = partitionIds;
            Path = path;
            Endpoint = endpoint;
        }

        /// <summary>
        /// The retention time for device-to-cloud messages in days. See:
        /// https://docs.microsoft.com/azure/iot-hub/iot-hub-devguide-messaging#device-to-cloud-messages
        /// </summary>
        [JsonProperty(PropertyName = "retentionTimeInDays")]
        public long? RetentionTimeInDays { get; set; }

        /// <summary>
        /// The number of paritions for receiving device-to-cloud messages in
        /// the Event Hub-compatible endpoint. See:
        /// https://docs.microsoft.com/azure/iot-hub/iot-hub-devguide-messaging#device-to-cloud-messages.
        /// </summary>
        [JsonProperty(PropertyName = "partitionCount")]
        public int? PartitionCount { get; set; }

        /// <summary>
        /// The partition ids in the Event Hub-compatible endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "partitionIds")]
        public IList<string> PartitionIds { get; private set; }

        /// <summary>
        /// The Event Hub-compatible name.
        /// </summary>
        [JsonProperty(PropertyName = "path")]
        public string Path { get; private set; }

        /// <summary>
        /// The Event Hub-compatible endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "endpoint")]
        public string Endpoint { get; private set; }

    }
}
