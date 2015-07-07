namespace Microsoft.Azure.Management.Compute.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Azure;

    /// <summary>
    /// </summary>
    public partial class InstanceViewStatus
    {
        /// <summary>
        /// Gets or sets the status Code.
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the level Code. Possible values for this property
        /// include: 'Info', 'Warning', 'Error'
        /// </summary>
        [JsonProperty(PropertyName = "level")]
        public StatusLevelTypes? Level { get; set; }

        /// <summary>
        /// Gets or sets the short localizable label for the status.
        /// </summary>
        [JsonProperty(PropertyName = "displayStatus")]
        public string DisplayStatus { get; set; }

        /// <summary>
        /// Gets or sets the optional detailed Message, including for alerts
        /// and error messages.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the time of the status.
        /// </summary>
        [JsonProperty(PropertyName = "time")]
        public DateTime? Time { get; set; }

    }
}
