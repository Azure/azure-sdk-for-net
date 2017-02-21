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
    /// The properties indicating whether a given IoT hub name is available.
    /// </summary>
    public partial class IotHubNameAvailabilityInfo
    {
        /// <summary>
        /// Initializes a new instance of the IotHubNameAvailabilityInfo class.
        /// </summary>
        public IotHubNameAvailabilityInfo() { }

        /// <summary>
        /// Initializes a new instance of the IotHubNameAvailabilityInfo class.
        /// </summary>
        public IotHubNameAvailabilityInfo(bool? nameAvailable = default(bool?), IotHubNameUnavailabilityReason? reason = default(IotHubNameUnavailabilityReason?), string message = default(string))
        {
            NameAvailable = nameAvailable;
            Reason = reason;
            Message = message;
        }

        /// <summary>
        /// The value which indicates whether the provided name is available.
        /// </summary>
        [JsonProperty(PropertyName = "nameAvailable")]
        public bool? NameAvailable { get; private set; }

        /// <summary>
        /// The reason for unavailability. Possible values include: 'Invalid',
        /// 'AlreadyExists'
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public IotHubNameUnavailabilityReason? Reason { get; private set; }

        /// <summary>
        /// The detailed reason message.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

    }
}
