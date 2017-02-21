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
    /// The properties of the feedback queue for cloud-to-device messages.
    /// </summary>
    public partial class FeedbackProperties
    {
        /// <summary>
        /// Initializes a new instance of the FeedbackProperties class.
        /// </summary>
        public FeedbackProperties() { }

        /// <summary>
        /// Initializes a new instance of the FeedbackProperties class.
        /// </summary>
        public FeedbackProperties(TimeSpan? lockDurationAsIso8601 = default(TimeSpan?), TimeSpan? ttlAsIso8601 = default(TimeSpan?), int? maxDeliveryCount = default(int?))
        {
            LockDurationAsIso8601 = lockDurationAsIso8601;
            TtlAsIso8601 = ttlAsIso8601;
            MaxDeliveryCount = maxDeliveryCount;
        }

        /// <summary>
        /// The lock duration for the feedback queue. See:
        /// https://docs.microsoft.com/azure/iot-hub/iot-hub-devguide-messaging#cloud-to-device-messages.
        /// </summary>
        [JsonProperty(PropertyName = "lockDurationAsIso8601")]
        public TimeSpan? LockDurationAsIso8601 { get; set; }

        /// <summary>
        /// The period of time for which a message is available to consume
        /// before it is expired by the IoT hub. See:
        /// https://docs.microsoft.com/azure/iot-hub/iot-hub-devguide-messaging#cloud-to-device-messages.
        /// </summary>
        [JsonProperty(PropertyName = "ttlAsIso8601")]
        public TimeSpan? TtlAsIso8601 { get; set; }

        /// <summary>
        /// The number of times the IoT hub attempts to deliver a message on
        /// the feedback queue. See:
        /// https://docs.microsoft.com/azure/iot-hub/iot-hub-devguide-messaging#cloud-to-device-messages.
        /// </summary>
        [JsonProperty(PropertyName = "maxDeliveryCount")]
        public int? MaxDeliveryCount { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.MaxDeliveryCount > 100)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "MaxDeliveryCount", 100);
            }
            if (this.MaxDeliveryCount < 1)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "MaxDeliveryCount", 1);
            }
        }
    }
}
