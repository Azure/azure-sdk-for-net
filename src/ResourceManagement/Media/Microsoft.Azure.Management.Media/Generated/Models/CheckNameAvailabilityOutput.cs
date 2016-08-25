
namespace Microsoft.Azure.Management.Media.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The response body for CheckNameAvailability API.
    /// </summary>
    public partial class CheckNameAvailabilityOutput
    {
        /// <summary>
        /// Initializes a new instance of the CheckNameAvailabilityOutput
        /// class.
        /// </summary>
        public CheckNameAvailabilityOutput() { }

        /// <summary>
        /// Initializes a new instance of the CheckNameAvailabilityOutput
        /// class.
        /// </summary>
        public CheckNameAvailabilityOutput(bool? nameAvailable = default(bool?), EntityNameUnavailabilityReason? reason = default(EntityNameUnavailabilityReason?), string message = default(string))
        {
            NameAvailable = nameAvailable;
            Reason = reason;
            Message = message;
        }

        /// <summary>
        /// Specifies if the name is available.
        /// </summary>
        [JsonProperty(PropertyName = "nameAvailable")]
        public bool? NameAvailable { get; set; }

        /// <summary>
        /// Specifies the reason if the name is not available. Possible values
        /// include: 'None', 'Invalid', 'AlreadyExists'
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public EntityNameUnavailabilityReason? Reason { get; set; }

        /// <summary>
        /// Specifies the detailed reason if the name is not available.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

    }
}
